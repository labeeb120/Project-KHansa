Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnPayments = New System.Windows.Forms.Button()
        Me.btnExpenses = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.Location = New System.Drawing.Point(20, 20)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(360, 30)
        Me.lblWelcome.Text = "Welcome, User"
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        '
        'btnPayments
        '
        Me.btnPayments.Location = New System.Drawing.Point(50, 70)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Size = New System.Drawing.Size(300, 40)
        Me.btnPayments.Text = "Manage Student Payments"
        '
        'btnExpenses
        '
        Me.btnExpenses.Location = New System.Drawing.Point(50, 120)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Size = New System.Drawing.Size(300, 40)
        Me.btnExpenses.Text = "Manage Institute Expenses"
        '
        'btnReports
        '
        Me.btnReports.Location = New System.Drawing.Point(50, 170)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(300, 40)
        Me.btnReports.Text = "Financial Reports"
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(50, 240)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(300, 30)
        Me.btnLogout.Text = "Logout"
        '
        'FrmMain
        '
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnPayments)
        Me.Controls.Add(Me.btnExpenses)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnLogout)
        Me.Name = "FrmMain"
        Me.Text = "Institute Management System - Main"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnPayments As System.Windows.Forms.Button
    Friend WithEvents btnExpenses As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
End Class
