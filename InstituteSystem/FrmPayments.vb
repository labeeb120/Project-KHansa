Imports System.Data.OleDb

Public Class FrmPayments
    Private Sub FrmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPayments()
    End Sub

    Private Sub LoadPayments()
        dgvPayments.DataSource = DatabaseManager.GetDataTable("SELECT StudentName, Amount, PaymentDate, Notes FROM Payments ORDER BY PaymentDate DESC")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim studentName As String = txtStudentName.Text.Trim()
        Dim amountStr As String = txtAmount.Text.Trim()
        Dim notes As String = txtNotes.Text.Trim()

        If studentName = "" Or amountStr = "" Then
            MessageBox.Show("Please fill all required fields.")
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(amountStr, amount) Then
            MessageBox.Show("Invalid amount.")
            Return
        End If

        ' Use StudentName directly as requested for simplicity, but parameterized
        Dim sql As String = "INSERT INTO Payments (StudentName, Amount, PaymentDate, Notes) VALUES (?, ?, ?, ?)"
        Dim params As OleDbParameter() = {
            New OleDbParameter("@sname", studentName),
            New OleDbParameter("@amt", amount),
            New OleDbParameter("@date", DateTime.Now),
            New OleDbParameter("@notes", notes)
        }

        If DatabaseManager.ExecuteAction(sql, params) > 0 Then
            MessageBox.Show("Payment recorded successfully.")
            LoadPayments()
            txtStudentName.Clear()
            txtAmount.Clear()
            txtNotes.Clear()
        End If
    End Sub
End Class
