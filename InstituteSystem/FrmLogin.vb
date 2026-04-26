Imports System.Data.OleDb

Public Class FrmLogin
    Private Sub btnSelectDB_Click(sender As Object, e As EventArgs) Handles btnSelectDB.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "Access Database (*.accdb)|*.accdb|Older Access Database (*.mdb)|*.mdb"
            sfd.Title = "اختر مسار حفظ قاعدة البيانات"
            sfd.FileName = "InstituteDB.accdb"

            ' If the user wants to select an existing one, they can, but SaveFileDialog allows creating new too.
            ' Actually, for Access, if the file doesn't exist, we usually need ADOX to create it.
            ' Since we are in a limited environment, we will assume the user selects an existing file or we tell them to create one.
            If sfd.ShowDialog() = DialogResult.OK Then
                txtDBPath.Text = sfd.FileName
                ' Check if file exists, if not, we try to "initialize" it.
                ' Note: OleDb can't create the .accdb file itself without ADOX.
                ' We'll advise the user to ensure an empty file exists if it doesn't.
                If Not System.IO.File.Exists(sfd.FileName) Then
                    MessageBox.Show("يرجى التأكد من وجود ملف قاعدة بيانات فارغ في المسار المحدد قبل المتابعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Using
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dbPath As String = txtDBPath.Text.Trim()
        Dim user As String = txtUsername.Text.Trim()
        Dim pass As String = txtPassword.Text.Trim()

        ' Validations
        If String.IsNullOrEmpty(dbPath) Then
            MessageBox.Show("يرجى تحديد مسار قاعدة البيانات أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(user) OrElse String.IsNullOrEmpty(pass) Then
            MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Attempt to connect
        If DatabaseManager.Connect(dbPath) Then
            ' Ensure tables and admin user exist
            DatabaseManager.InitializeDatabase()

            ' Validate Login
            Dim sql As String = "SELECT * FROM Users WHERE Username = ? AND [Password] = ?"
            Dim parameters As OleDbParameter() = {
                New OleDbParameter("@u", user),
                New OleDbParameter("@p", pass)
            }

            Dim dt As DataTable = DatabaseManager.GetDataTableWithParams(sql, parameters)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim role As String = dt.Rows(0)("Role").ToString()
                ' Open Main Form
                Dim mainForm As New FrmMain(user, role)
                mainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة.", "خطأ في الدخول", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            ' Connection failure handled inside DatabaseManager.Connect
        End If
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Default values for testing or ease of use
        txtUsername.Text = "admin"
        txtPassword.Text = "admin123"
    End Sub
End Class
