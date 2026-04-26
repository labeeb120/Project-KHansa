Imports System.Data.OleDb

Public Class FrmExpenses
    Private Sub FrmExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExpenses()
    End Sub

    Private Sub LoadExpenses()
        dgvExpenses.DataSource = DatabaseManager.GetDataTable("SELECT * FROM Expenses ORDER BY ExpenseDate DESC")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim description As String = txtDescription.Text.Trim()
        Dim amountStr As String = txtAmount.Text.Trim()
        Dim category As String = txtCategory.Text.Trim()

        If description = "" Or amountStr = "" Then
            MessageBox.Show("Please fill all required fields.")
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(amountStr, amount) Then
            MessageBox.Show("Invalid amount.")
            Return
        End If

        Dim sql As String = "INSERT INTO Expenses (Description, Amount, ExpenseDate, Category) VALUES (?, ?, ?, ?)"
        Dim params As OleDbParameter() = {
            New OleDbParameter("@desc", description),
            New OleDbParameter("@amt", amount),
            New OleDbParameter("@date", DateTime.Now),
            New OleDbParameter("@cat", category)
        }

        If DatabaseManager.ExecuteAction(sql, params) > 0 Then
            MessageBox.Show("Expense recorded successfully.")
            LoadExpenses()
            txtDescription.Clear()
            txtAmount.Clear()
            txtCategory.Clear()
        End If
    End Sub
End Class
