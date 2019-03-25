<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInputQRCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pgbQRCode = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxInputQR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbQRNo = New System.Windows.Forms.Label()
        Me.pbQRCode = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BgDataTableAdapter = New CellController.DBxDataSetTableAdapters.BGDataTableAdapter()
        Me.LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1 = New CellController.DBxDataSetTableAdapters.LCQW_UNION_WORK_DENPYO_PRINTTableAdapter()
        Me.DBxDataSet = New CellController.DBxDataSet()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgbQRCode
        '
        Me.pgbQRCode.ForeColor = System.Drawing.SystemColors.Desktop
        Me.pgbQRCode.Location = New System.Drawing.Point(122, 48)
        Me.pgbQRCode.Maximum = 276
        Me.pgbQRCode.Name = "pgbQRCode"
        Me.pgbQRCode.Size = New System.Drawing.Size(326, 23)
        Me.pgbQRCode.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(230, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Wafer Fab Lot No.  :"
        '
        'tbxInputQR
        '
        Me.tbxInputQR.Location = New System.Drawing.Point(59, 67)
        Me.tbxInputQR.Name = "tbxInputQR"
        Me.tbxInputQR.Size = New System.Drawing.Size(29, 20)
        Me.tbxInputQR.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(117, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(331, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Please scan WaferSlip QRCode"
        '
        'lbQRNo
        '
        Me.lbQRNo.AutoSize = True
        Me.lbQRNo.Font = New System.Drawing.Font("Papyrus", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQRNo.Location = New System.Drawing.Point(433, 80)
        Me.lbQRNo.Name = "lbQRNo"
        Me.lbQRNo.Size = New System.Drawing.Size(28, 33)
        Me.lbQRNo.TabIndex = 8
        Me.lbQRNo.Text = "1"
        '
        'pbQRCode
        '
        Me.pbQRCode.ErrorImage = Nothing
        Me.pbQRCode.Image = Global.CellController.My.Resources.Resources.QRCode
        Me.pbQRCode.Location = New System.Drawing.Point(17, 15)
        Me.pbQRCode.Name = "pbQRCode"
        Me.pbQRCode.Size = New System.Drawing.Size(81, 75)
        Me.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbQRCode.TabIndex = 9
        Me.pbQRCode.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(17, 116)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(444, 121)
        Me.DataGridView1.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 249)
        Me.Panel1.TabIndex = 13
        '
        'BgDataTableAdapter
        '
        Me.BgDataTableAdapter.ClearBeforeFill = True
        '
        'LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1
        '
        Me.LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1.ClearBeforeFill = True
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FormInputQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(474, 249)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.pgbQRCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbQRCode)
        Me.Controls.Add(Me.tbxInputQR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbQRNo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormInputQRCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormInputQRCode"
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pgbQRCode As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents pbQRCode As PictureBox
    Friend WithEvents tbxInputQR As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbQRNo As Label
    Friend WithEvents BgDataTableAdapter As DBxDataSetTableAdapters.BGDataTableAdapter
    Friend WithEvents LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1 As DBxDataSetTableAdapters.LCQW_UNION_WORK_DENPYO_PRINTTableAdapter
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DBxDataSet As DBxDataSet
    Friend WithEvents Panel1 As Panel
End Class
