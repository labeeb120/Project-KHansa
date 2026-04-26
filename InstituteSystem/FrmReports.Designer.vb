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
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMonthly
        '
        Me.btnMonthly.Location = New System.Drawing.Point(20, 20)
        Me.btnMonthly.Size = New System.Drawing.Size(150, 30)
        Me.btnMonthly.Text = "Current Month Report"
        '
        'btnAnnual
        '
        Me.btnAnnual.Location = New System.Drawing.Point(180, 20)
        Me.btnAnnual.Size = New System.Drawing.Size(150, 30)
        Me.btnAnnual.Text = "Current Year Report"
        '
        'dgvReports
        '
        Me.dgvReports.Location = New System.Drawing.Point(20, 70)
        Me.dgvReports.Size = New System.Drawing.Size(440, 250)
        '
        'lblSummary
        '
        Me.lblSummary.Location = New System.Drawing.Point(20, 330)
        Me.lblSummary.Size = New System.Drawing.Size(440, 40)
        Me.lblSummary.Text = "Total Revenue: 0 | Total Expenses: 0 | Balance: 0"
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'FrmReports
        '
        Me.ClientSize = New System.Drawing.Size(480, 400)
        Me.Controls.Add(Me.btnMonthly)
        Me.Controls.Add(Me.btnAnnual)
        Me.Controls.Add(Me.dgvReports)
        Me.Controls.Add(Me.lblSummary)
        Me.Name = "FrmReports"
        Me.Text = "Financial Reports"
        Me.StartPosition = FormStartPosition.CenterParent
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents btnMonthly As System.Windows.Forms.Button
    Friend WithEvents btnAnnual As System.Windows.Forms.Button
    Friend WithEvents dgvReports As System.Windows.Forms.DataGridView
    Friend WithEvents lblSummary As System.Windows.Forms.Label
End Class
