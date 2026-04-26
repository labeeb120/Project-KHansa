Imports System.Data.OleDb

Public Class FrmReports
    Private Sub btnMonthly_Click(sender As Object, e As EventArgs) Handles btnMonthly.Click
        LoadReport(DateTime.Now.Month, DateTime.Now.Year)
    End Sub

    Private Sub btnAnnual_Click(sender As Object, e As EventArgs) Handles btnAnnual.Click
        LoadReport(0, DateTime.Now.Year)
    End Sub

    Private Sub LoadReport(month As Integer, year As Integer)
        ' Totals Calculation - Using basic Access SQL functions
        Dim revenueSql As String = "SELECT SUM(Amount) FROM Payments WHERE YEAR(PaymentDate) = " & year
        Dim expenseSql As String = "SELECT SUM(Amount) FROM Expenses WHERE YEAR(ExpenseDate) = " & year

        If month > 0 Then
            revenueSql &= " AND MONTH(PaymentDate) = " & month
            expenseSql &= " AND MONTH(ExpenseDate) = " & month
        End If

        Dim dtRevenueTotal As DataTable = DatabaseManager.GetDataTable(revenueSql)
        Dim dtExpenseTotal As DataTable = DatabaseManager.GetDataTable(expenseSql)

        Dim totalRevenue As Decimal = 0
        If dtRevenueTotal.Rows.Count > 0 AndAlso Not IsDBNull(dtRevenueTotal.Rows(0)(0)) Then
            totalRevenue = CDec(dtRevenueTotal.Rows(0)(0))
        End If

        Dim totalExpense As Decimal = 0
        If dtExpenseTotal.Rows.Count > 0 AndAlso Not IsDBNull(dtExpenseTotal.Rows(0)(0)) Then
            totalExpense = CDec(dtExpenseTotal.Rows(0)(0))
        End If

        Dim balance As Decimal = totalRevenue - totalExpense

        lblSummary.Text = $"إجمالي الإيرادات: {totalRevenue:N2} | إجمالي المصروفات: {totalExpense:N2} | الصافي: {balance:N2}"

        ' Populating DataGridView with a Unified View
        Dim listSql As String = "SELECT PaymentDate AS [التاريخ], 'إيراد' AS [النوع], StudentName AS [البيان], Amount AS [المبلغ] FROM Payments WHERE YEAR(PaymentDate) = " & year
        If month > 0 Then listSql &= " AND MONTH(PaymentDate) = " & month

        listSql &= " UNION ALL "

        listSql &= "SELECT ExpenseDate AS [التاريخ], 'مصروف' AS [النوع], Description AS [البيان], -Amount AS [المبلغ] FROM Expenses WHERE YEAR(ExpenseDate) = " & year
        If month > 0 Then listSql &= " AND MONTH(ExpenseDate) = " & month

        listSql &= " ORDER BY [التاريخ] DESC"

        dgvReports.DataSource = DatabaseManager.GetDataTable(listSql)
    End Sub

    Private Sub FrmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load monthly report by default
        btnMonthly.PerformClick()
    End Sub
End Class
