<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlarmTable
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RecordTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MCNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WaferFabLotNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WaferNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClearTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmMessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCAlarmInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBxDataSet = New CellController.DBxDataSet()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AlarmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DCAlarmInfoTableAdapter = New CellController.DBxDataSetTableAdapters.DCAlarmInfoTableAdapter()
        Me.GetAlarmIDAdapter1 = New CellController.DBxDataSetTableAdapters.GetAlarmIDAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCAlarmInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(708, 185)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RecordTimeDataGridViewTextBoxColumn, Me.MCNoDataGridViewTextBoxColumn, Me.AlarmIDDataGridViewTextBoxColumn, Me.WaferFabLotNoDataGridViewTextBoxColumn, Me.WaferNoDataGridViewTextBoxColumn, Me.ClearTimeDataGridViewTextBoxColumn, Me.AlarmMessageDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.DCAlarmInfoBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(708, 185)
        Me.DataGridView1.TabIndex = 0
        '
        'RecordTimeDataGridViewTextBoxColumn
        '
        Me.RecordTimeDataGridViewTextBoxColumn.DataPropertyName = "RecordTime"
        DataGridViewCellStyle1.Format = "G"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.RecordTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.RecordTimeDataGridViewTextBoxColumn.HeaderText = "RecordTime"
        Me.RecordTimeDataGridViewTextBoxColumn.Name = "RecordTimeDataGridViewTextBoxColumn"
        Me.RecordTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecordTimeDataGridViewTextBoxColumn.Width = 150
        '
        'MCNoDataGridViewTextBoxColumn
        '
        Me.MCNoDataGridViewTextBoxColumn.DataPropertyName = "MCNo"
        Me.MCNoDataGridViewTextBoxColumn.HeaderText = "MCNo"
        Me.MCNoDataGridViewTextBoxColumn.Name = "MCNoDataGridViewTextBoxColumn"
        Me.MCNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AlarmIDDataGridViewTextBoxColumn
        '
        Me.AlarmIDDataGridViewTextBoxColumn.DataPropertyName = "AlarmID"
        Me.AlarmIDDataGridViewTextBoxColumn.HeaderText = "AlarmID"
        Me.AlarmIDDataGridViewTextBoxColumn.Name = "AlarmIDDataGridViewTextBoxColumn"
        Me.AlarmIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WaferFabLotNoDataGridViewTextBoxColumn
        '
        Me.WaferFabLotNoDataGridViewTextBoxColumn.DataPropertyName = "WaferFabLotNo"
        Me.WaferFabLotNoDataGridViewTextBoxColumn.HeaderText = "WaferFabLotNo"
        Me.WaferFabLotNoDataGridViewTextBoxColumn.Name = "WaferFabLotNoDataGridViewTextBoxColumn"
        Me.WaferFabLotNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WaferNoDataGridViewTextBoxColumn
        '
        Me.WaferNoDataGridViewTextBoxColumn.DataPropertyName = "WaferNo"
        Me.WaferNoDataGridViewTextBoxColumn.HeaderText = "WaferNo"
        Me.WaferNoDataGridViewTextBoxColumn.Name = "WaferNoDataGridViewTextBoxColumn"
        Me.WaferNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ClearTimeDataGridViewTextBoxColumn
        '
        Me.ClearTimeDataGridViewTextBoxColumn.DataPropertyName = "ClearTime"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ClearTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ClearTimeDataGridViewTextBoxColumn.HeaderText = "ClearTime"
        Me.ClearTimeDataGridViewTextBoxColumn.Name = "ClearTimeDataGridViewTextBoxColumn"
        Me.ClearTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ClearTimeDataGridViewTextBoxColumn.Width = 150
        '
        'AlarmMessageDataGridViewTextBoxColumn
        '
        Me.AlarmMessageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AlarmMessageDataGridViewTextBoxColumn.DataPropertyName = "AlarmMessage"
        Me.AlarmMessageDataGridViewTextBoxColumn.HeaderText = "AlarmMessage"
        Me.AlarmMessageDataGridViewTextBoxColumn.Name = "AlarmMessageDataGridViewTextBoxColumn"
        Me.AlarmMessageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DCAlarmInfoBindingSource
        '
        Me.DCAlarmInfoBindingSource.DataMember = "DCAlarmInfo"
        Me.DCAlarmInfoBindingSource.DataSource = Me.DBxDataSet
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.GhostWhite
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlarmToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(708, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AlarmToolStripMenuItem
        '
        Me.AlarmToolStripMenuItem.Name = "AlarmToolStripMenuItem"
        Me.AlarmToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.AlarmToolStripMenuItem.Text = "Alarm"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'DCAlarmInfoTableAdapter
        '
        Me.DCAlarmInfoTableAdapter.ClearBeforeFill = True
        '
        'AlarmTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 209)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AlarmTable"
        Me.Text = "AlarmTable"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCAlarmInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents AlarmToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DBxDataSet As DBxDataSet
    Friend WithEvents DCAlarmInfoBindingSource As BindingSource
    Friend WithEvents DCAlarmInfoTableAdapter As DBxDataSetTableAdapters.DCAlarmInfoTableAdapter
    Friend WithEvents RecordTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MCNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AlarmIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WaferFabLotNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WaferNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClearTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AlarmMessageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GetAlarmIDAdapter1 As DBxDataSetTableAdapters.GetAlarmIDAdapter
End Class
