Imports System.Data.OleDb

Public Class FrmExpenses
    Private Sub FrmExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExpenses()
    End Sub

    Private Sub LoadExpenses()
        Dim dt As DataTable = DatabaseManager.GetDataTable("SELECT Description AS [الوصف], Amount AS [المبلغ], ExpenseDate AS [التاريخ], Category AS [الفئة] FROM Expenses ORDER BY ExpenseDate DESC")
        dgvExpenses.DataSource = dt
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim description As String = txtDescription.Text.Trim()
        Dim amountStr As String = txtAmount.Text.Trim()
        Dim category As String = txtCategory.Text.Trim()

        ' Validation
        If description = "" OrElse amountStr = "" Then
            MessageBox.Show("يرجى ملء جميع الحقول المطلوبة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(amountStr, amount) Then
            MessageBox.Show("يرجى إدخال مبلغ صحيح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Save to DB
        Dim sql As String = "INSERT INTO Expenses (Description, Amount, ExpenseDate, Category) VALUES (?, ?, ?, ?)"
        Dim params As OleDbParameter() = {
            New OleDbParameter("@desc", description),
            New OleDbParameter("@amt", amount),
            New OleDbParameter("@date", DateTime.Now),
            New OleDbParameter("@cat", category)
        }

        If DatabaseManager.ExecuteAction(sql, params) > 0 Then
            MessageBox.Show("تم حفظ المصروف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadExpenses()
            txtDescription.Clear()
            txtAmount.Clear()
            txtCategory.Clear()
            txtDescription.Focus()
        End If
    End Sub
End Class
