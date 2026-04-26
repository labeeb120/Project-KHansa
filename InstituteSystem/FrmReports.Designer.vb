Partial Class FrmReports
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
        Me.btnMonthly = New System.Windows.Forms.Button()
        Me.btnAnnual = New System.Windows.Forms.Button()
        Me.dgvReports = New System.Windows.Forms.DataGridView()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.PanelSummary = New System.Windows.Forms.Panel()
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSummary.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMonthly
        '
        Me.btnMonthly.BackColor = System.Drawing.Color.FromArgb(33, 150, 243)
        Me.btnMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMonthly.ForeColor = System.Drawing.Color.White
        Me.btnMonthly.Location = New System.Drawing.Point(310, 20)
        Me.btnMonthly.Name = "btnMonthly"
        Me.btnMonthly.Size = New System.Drawing.Size(150, 35)
        Me.btnMonthly.Text = "تقرير الشهر الحالي"
        Me.btnMonthly.UseVisualStyleBackColor = False
        '
        'btnAnnual
        '
        Me.btnAnnual.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnAnnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnual.ForeColor = System.Drawing.Color.White
        Me.btnAnnual.Location = New System.Drawing.Point(150, 20)
        Me.btnAnnual.Name = "btnAnnual"
        Me.btnAnnual.Size = New System.Drawing.Size(150, 35)
        Me.btnAnnual.Text = "تقرير السنة الحالية"
        Me.btnAnnual.UseVisualStyleBackColor = False
        '
        'dgvReports
        '
        Me.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReports.BackgroundColor = System.Drawing.Color.White
        Me.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReports.Location = New System.Drawing.Point(20, 70)
        Me.dgvReports.Name = "dgvReports"
        Me.dgvReports.ReadOnly = True
        Me.dgvReports.Size = New System.Drawing.Size(440, 240)
        '
        'lblSummary
        '
        Me.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        Me.lblSummary.Location = New System.Drawing.Point(0, 0)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(440, 60)
        Me.lblSummary.Text = "الإيرادات: 0 | المصروفات: 0 | الصافي: 0"
        Me.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelSummary
        '
        Me.PanelSummary.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
        Me.PanelSummary.Controls.Add(Me.lblSummary)
        Me.PanelSummary.Location = New System.Drawing.Point(20, 320)
        Me.PanelSummary.Name = "PanelSummary"
        Me.PanelSummary.Size = New System.Drawing.Size(440, 60)
        '
        'FrmReports
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 400)
        Me.Controls.Add(Me.btnMonthly)
        Me.Controls.Add(Me.btnAnnual)
        Me.Controls.Add(Me.dgvReports)
        Me.Controls.Add(Me.PanelSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmReports"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "التقارير المالية"
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSummary.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnMonthly As System.Windows.Forms.Button
    Friend WithEvents btnAnnual As System.Windows.Forms.Button
    Friend WithEvents dgvReports As System.Windows.Forms.DataGridView
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents PanelSummary As System.Windows.Forms.Panel
End Class
