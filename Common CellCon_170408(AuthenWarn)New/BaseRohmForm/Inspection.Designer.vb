<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inspection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbRecipe = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbtInspectFail = New System.Windows.Forms.RadioButton()
        Me.rbtInspectPass = New System.Windows.Forms.RadioButton()
        Me.pnlGLNo = New System.Windows.Forms.Panel()
        Me.tbxGLNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btEnd = New System.Windows.Forms.Button()
        Me.GroupMemberTableAdapter1 = New CellController.DBxDataSetTableAdapters.GroupMemberTableAdapter()
        Me.DBxDataSet1 = New CellController.DBxDataSet()
        Me.BgDataTableAdapter1 = New CellController.DBxDataSetTableAdapters.BGDataTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbRecipe.SuspendLayout()
        Me.pnlGLNo.SuspendLayout()
        CType(Me.DBxDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbRecipe
        '
        Me.gbRecipe.Controls.Add(Me.Label10)
        Me.gbRecipe.Controls.Add(Me.rbtInspectFail)
        Me.gbRecipe.Controls.Add(Me.rbtInspectPass)
        Me.gbRecipe.Controls.Add(Me.pnlGLNo)
        Me.gbRecipe.Location = New System.Drawing.Point(25, 23)
        Me.gbRecipe.Name = "gbRecipe"
        Me.gbRecipe.Size = New System.Drawing.Size(217, 140)
        Me.gbRecipe.TabIndex = 17
        Me.gbRecipe.TabStop = False
        Me.gbRecipe.Text = "Inspect"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Inspection Judgement"
        '
        'rbtInspectFail
        '
        Me.rbtInspectFail.AutoSize = True
        Me.rbtInspectFail.Location = New System.Drawing.Point(109, 72)
        Me.rbtInspectFail.Name = "rbtInspectFail"
        Me.rbtInspectFail.Size = New System.Drawing.Size(41, 17)
        Me.rbtInspectFail.TabIndex = 7
        Me.rbtInspectFail.Text = "Fail"
        Me.rbtInspectFail.UseVisualStyleBackColor = True
        '
        'rbtInspectPass
        '
        Me.rbtInspectPass.AutoSize = True
        Me.rbtInspectPass.Checked = True
        Me.rbtInspectPass.Location = New System.Drawing.Point(27, 72)
        Me.rbtInspectPass.Name = "rbtInspectPass"
        Me.rbtInspectPass.Size = New System.Drawing.Size(48, 17)
        Me.rbtInspectPass.TabIndex = 6
        Me.rbtInspectPass.TabStop = True
        Me.rbtInspectPass.Text = "Pass"
        Me.rbtInspectPass.UseVisualStyleBackColor = True
        '
        'pnlGLNo
        '
        Me.pnlGLNo.Controls.Add(Me.tbxGLNo)
        Me.pnlGLNo.Controls.Add(Me.Label13)
        Me.pnlGLNo.Location = New System.Drawing.Point(10, 100)
        Me.pnlGLNo.Name = "pnlGLNo"
        Me.pnlGLNo.Size = New System.Drawing.Size(201, 31)
        Me.pnlGLNo.TabIndex = 13
        Me.pnlGLNo.Visible = False
        '
        'tbxGLNo
        '
        Me.tbxGLNo.Location = New System.Drawing.Point(80, 4)
        Me.tbxGLNo.Name = "tbxGLNo"
        Me.tbxGLNo.Size = New System.Drawing.Size(110, 20)
        Me.tbxGLNo.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "GLNo."
        '
        'btEnd
        '
        Me.btEnd.Location = New System.Drawing.Point(167, 169)
        Me.btEnd.Name = "btEnd"
        Me.btEnd.Size = New System.Drawing.Size(75, 23)
        Me.btEnd.TabIndex = 18
        Me.btEnd.Text = "End"
        Me.btEnd.UseVisualStyleBackColor = True
        '
        'GroupMemberTableAdapter1
        '
        Me.GroupMemberTableAdapter1.ClearBeforeFill = True
        '
        'DBxDataSet1
        '
        Me.DBxDataSet1.DataSetName = "DBxDataSet"
        Me.DBxDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BgDataTableAdapter1
        '
        Me.BgDataTableAdapter1.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(268, 201)
        Me.Panel1.TabIndex = 15
        '
        'Inspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(268, 201)
        Me.Controls.Add(Me.btEnd)
        Me.Controls.Add(Me.gbRecipe)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Inspection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inspection"
        Me.gbRecipe.ResumeLayout(False)
        Me.gbRecipe.PerformLayout()
        Me.pnlGLNo.ResumeLayout(False)
        Me.pnlGLNo.PerformLayout()
        CType(Me.DBxDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbRecipe As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents rbtInspectFail As RadioButton
    Friend WithEvents rbtInspectPass As RadioButton
    Friend WithEvents pnlGLNo As Panel
    Friend WithEvents tbxGLNo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btEnd As Button
    Friend WithEvents GroupMemberTableAdapter1 As DBxDataSetTableAdapters.GroupMemberTableAdapter
    Friend WithEvents DBxDataSet1 As DBxDataSet
    Friend WithEvents BgDataTableAdapter1 As DBxDataSetTableAdapters.BGDataTableAdapter
    Friend WithEvents Panel1 As Panel
End Class
