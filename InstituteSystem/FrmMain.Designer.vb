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
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.PanelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(0, 0)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(400, 60)
        Me.lblWelcome.Text = "مرحباً بك"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPayments
        '
        Me.btnPayments.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayments.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnPayments.ForeColor = System.Drawing.Color.White
        Me.btnPayments.Location = New System.Drawing.Point(50, 80)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Size = New System.Drawing.Size(300, 50)
        Me.btnPayments.Text = "إدارة مقبوضات الطالبات"
        Me.btnPayments.UseVisualStyleBackColor = False
        '
        'btnExpenses
        '
        Me.btnExpenses.BackColor = System.Drawing.Color.FromArgb(233, 30, 99)
        Me.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenses.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnExpenses.ForeColor = System.Drawing.Color.White
        Me.btnExpenses.Location = New System.Drawing.Point(50, 140)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Size = New System.Drawing.Size(300, 50)
        Me.btnExpenses.Text = "إدارة مصروفات المعهد"
        Me.btnExpenses.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.FromArgb(63, 81, 181)
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnReports.ForeColor = System.Drawing.Color.White
        Me.btnReports.Location = New System.Drawing.Point(50, 200)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(300, 50)
        Me.btnReports.Text = "التقارير المالية"
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(158, 158, 158)
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(150, 270)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(100, 30)
        Me.btnLogout.Text = "تسجيل الخروج"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.PanelHeader.Controls.Add(Me.lblWelcome)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(400, 60)
        '
        'FrmMain
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(400, 320)
        Me.Controls.Add(Me.PanelHeader)
        Me.Controls.Add(Me.btnPayments)
        Me.Controls.Add(Me.btnExpenses)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnLogout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الواجهة الرئيسية"
        Me.PanelHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnPayments As System.Windows.Forms.Button
    Friend WithEvents btnExpenses As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
End Class
