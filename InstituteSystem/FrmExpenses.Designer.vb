Partial Class FrmExpenses
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
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvExpenses = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(120, 20)
        Me.txtDescription.Size = New System.Drawing.Size(200, 23)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 60)
        Me.Label2.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(120, 60)
        Me.txtAmount.Size = New System.Drawing.Size(100, 23)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 100)
        Me.Label3.Text = "Category:"
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(120, 100)
        Me.txtCategory.Size = New System.Drawing.Size(200, 23)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(120, 140)
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.Text = "Save Expense"
        '
        'dgvExpenses
        '
        Me.dgvExpenses.Location = New System.Drawing.Point(20, 180)
        Me.dgvExpenses.Size = New System.Drawing.Size(440, 200)
        '
        'FrmExpenses
        '
        Me.ClientSize = New System.Drawing.Size(480, 400)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvExpenses)
        Me.Name = "FrmExpenses"
        Me.Text = "Manage Institute Expenses"
        Me.StartPosition = FormStartPosition.CenterParent
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvExpenses As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
