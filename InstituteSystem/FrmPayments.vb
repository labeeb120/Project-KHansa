Imports System.Data.OleDb

Public Class FrmPayments
    Private Sub FrmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPayments()
    End Sub

    Private Sub LoadPayments()
        Dim dt As DataTable = DatabaseManager.GetDataTable("SELECT StudentName AS [اسم الطالبة], Amount AS [المبلغ], PaymentDate AS [التاريخ], Notes AS [ملاحظات] FROM Payments ORDER BY PaymentDate DESC")
        dgvPayments.DataSource = dt
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim studentName As String = txtStudentName.Text.Trim()
        Dim amountStr As String = txtAmount.Text.Trim()
        Dim notes As String = txtNotes.Text.Trim()

        ' Validation
        If studentName = "" OrElse amountStr = "" Then
            MessageBox.Show("يرجى ملء جميع الحقول المطلوبة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(amountStr, amount) Then
            MessageBox.Show("يرجى إدخال مبلغ صحيح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Save to DB
        Dim sql As String = "INSERT INTO Payments (StudentName, Amount, PaymentDate, Notes) VALUES (?, ?, ?, ?)"
        Dim params As OleDbParameter() = {
            New OleDbParameter("@sname", studentName),
            New OleDbParameter("@amt", amount),
            New OleDbParameter("@date", DateTime.Now),
            New OleDbParameter("@notes", notes)
        }

        If DatabaseManager.ExecuteAction(sql, params) > 0 Then
            MessageBox.Show("تم حفظ الدفعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPayments()
            txtStudentName.Clear()
            txtAmount.Clear()
            txtNotes.Clear()
            txtStudentName.Focus()
        End If
    End Sub
End Class
