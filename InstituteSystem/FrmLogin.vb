Imports System.Data.OleDb

Public Class FrmLogin
    Private Sub btnSelectDB_Click(sender As Object, e As EventArgs) Handles btnSelectDB.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Access Database (*.accdb;*.mdb)|*.accdb;*.mdb"
            If ofd.ShowDialog() = DialogResult.OK Then
                txtDBPath.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dbPath As String = txtDBPath.Text.Trim()

        If String.IsNullOrEmpty(dbPath) Then
            MessageBox.Show("Please select a database path.")
            Return
        End If

        ' Attempt to connect and initialize
        If DatabaseManager.Connect(dbPath) Then
            DatabaseManager.InitializeDatabase()

            ' Validate User - Using Parameterized Query to prevent SQL Injection
            Dim user As String = txtUsername.Text.Trim()
            Dim pass As String = txtPassword.Text.Trim()

            Dim sql As String = "SELECT * FROM Users WHERE Username = ? AND [Password] = ?"
            Dim parameters As OleDbParameter() = {
                New OleDbParameter("@user", user),
                New OleDbParameter("@pass", pass)
            }

            Dim dt As DataTable = DatabaseManager.GetDataTableWithParams(sql, parameters)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Success
                Dim role As String = dt.Rows(0)("Role").ToString()
                MessageBox.Show($"Welcome {user}! Logged in as {role}")

                ' Open Main Form
                Dim mainForm As New FrmMain(user, role)
                mainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password.")
            End If
        Else
            MessageBox.Show("Failed to connect to database. Make sure the file exists and is a valid Access database.")
        End If
    End Sub
End Class
