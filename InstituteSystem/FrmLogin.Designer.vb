Partial Class FrmLogin
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
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnSelectDB = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtDBPath = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(100, 50)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(200, 23)
        Me.txtUsername.PlaceholderText = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(100, 90)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(200, 23)
        Me.txtPassword.PlaceholderText = "Password"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(100, 130)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(200, 30)
        Me.btnLogin.Text = "Login"
        '
        'btnSelectDB
        '
        Me.btnSelectDB.Location = New System.Drawing.Point(310, 170)
        Me.btnSelectDB.Name = "btnSelectDB"
        Me.btnSelectDB.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectDB.Text = "Browse..."
        '
        'txtDBPath
        '
        Me.txtDBPath.Location = New System.Drawing.Point(100, 170)
        Me.txtDBPath.Name = "txtDBPath"
        Me.txtDBPath.Size = New System.Drawing.Size(200, 23)
        Me.txtDBPath.PlaceholderText = "Database Path"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(10, 210)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(380, 23)
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmLogin
        '
        Me.ClientSize = New System.Drawing.Size(400, 250)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnSelectDB)
        Me.Controls.Add(Me.txtDBPath)
        Me.Controls.Add(Me.lblStatus)
        Me.Name = "FrmLogin"
        Me.Text = "Institute System - Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnSelectDB As System.Windows.Forms.Button
    Friend WithEvents txtDBPath As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
