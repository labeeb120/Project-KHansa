Public Class FrmMain
    Private CurrentUser As String
    Private CurrentRole As String

    Public Sub New(username As String, role As String)
        InitializeComponent()
        CurrentUser = username
        CurrentRole = role
        lblWelcome.Text = $"مرحباً بك، {username} ({TranslateRole(role)})"

        ' Apply permissions
        If CurrentRole <> "Admin" Then
            ' If there were specific restricted buttons, we would disable them here
            ' btnReports.Enabled = False
        End If
    End Sub

    Private Function TranslateRole(role As String) As String
        Select Case role.ToLower()
            Case "admin" : Return "مدير النظام"
            Case Else : Return "مستخدم"
        End Select
    End Function

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
        Application.Restart()
    End Sub
End Class
