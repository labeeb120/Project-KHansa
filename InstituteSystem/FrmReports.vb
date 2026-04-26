Imports System.Data.OleDb

Public Class FrmReports
    Private Sub btnMonthly_Click(sender As Object, e As EventArgs) Handles btnMonthly.Click
        LoadReport(DateTime.Now.Month, DateTime.Now.Year)
    End Sub

    Private Sub btnAnnual_Click(sender As Object, e As EventArgs) Handles btnAnnual.Click
        LoadReport(0, DateTime.Now.Year)
    End Sub

    Private Sub LoadReport(month As Integer, year As Integer)
        ' Totals Calculation
        Dim revenueSql As String = "SELECT SUM(Amount) FROM Payments WHERE YEAR(PaymentDate) = " & year
        Dim expenseSql As String = "SELECT SUM(Amount) FROM Expenses WHERE YEAR(ExpenseDate) = " & year

        If month > 0 Then
            revenueSql &= " AND MONTH(PaymentDate) = " & month
            expenseSql &= " AND MONTH(ExpenseDate) = " & month
        End If

        Dim dtRevenueTotal As DataTable = DatabaseManager.GetDataTable(revenueSql)
        Dim dtExpenseTotal As DataTable = DatabaseManager.GetDataTable(expenseSql)

        Dim totalRevenue As Decimal = If(IsDBNull(dtRevenueTotal.Rows(0)(0)), 0, CDec(dtRevenueTotal.Rows(0)(0)))
        Dim totalExpense As Decimal = If(IsDBNull(dtExpenseTotal.Rows(0)(0)), 0, CDec(dtExpenseTotal.Rows(0)(0)))
        Dim balance As Decimal = totalRevenue - totalExpense

        lblSummary.Text = $"Total Revenue: {totalRevenue:C} | Total Expenses: {totalExpense:C} | Balance: {balance:C}"

        ' Populating DataGridView with a Unified View (Union of Payments and Expenses)
        Dim listSql As String = "SELECT PaymentDate AS [Date], 'Revenue' AS Type, StudentName AS Description, Amount FROM Payments WHERE YEAR(PaymentDate) = " & year
        If month > 0 Then listSql &= " AND MONTH(PaymentDate) = " & month

        listSql &= " UNION ALL "

        listSql &= "SELECT ExpenseDate AS [Date], 'Expense' AS Type, Description, -Amount FROM Expenses WHERE YEAR(ExpenseDate) = " & year
        If month > 0 Then listSql &= " AND MONTH(ExpenseDate) = " & month

        listSql &= " ORDER BY [Date] DESC"

        dgvReports.DataSource = DatabaseManager.GetDataTable(listSql)
    End Sub
End Class
