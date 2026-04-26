Public Class FrmMain
    Private CurrentUser As String
    Private CurrentRole As String

    Public Sub New(username As String, role As String)
        InitializeComponent()
        CurrentUser = username
        CurrentRole = role
        lblWelcome.Text = $"Welcome, {username} ({role})"

        ' Apply permissions if needed
        If CurrentRole <> "Admin" Then
            ' For example, hide reports for non-admins
            ' btnReports.Enabled = False
        End If
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        Dim f As New FrmPayments()
        f.ShowDialog()
    End Sub

    Private Sub btnExpenses_Click(sender As Object, e As EventArgs) Handles btnExpenses.Click
        Dim f As New FrmExpenses()
        f.ShowDialog()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Dim f As New FrmReports()
        f.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        ' In a real app, you might want to show the login form again
        Application.Restart()
    End Sub
End Class
