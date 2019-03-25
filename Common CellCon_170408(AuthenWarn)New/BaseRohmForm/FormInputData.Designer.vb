<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputData
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
        Me.gbWaferSizeChange = New System.Windows.Forms.GroupBox()
        Me.pnlWaferSize = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxWaferSizeChangeTo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxWaferSizeChangeFrom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtWaferSizeNo = New System.Windows.Forms.RadioButton()
        Me.rbtWaferSizeYes = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxCutterStatus = New System.Windows.Forms.ComboBox()
        Me.tbxCutterTemp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnInputDataClear = New System.Windows.Forms.Button()
        Me.btnInputDataOK = New System.Windows.Forms.Button()
        Me.pnlCutterChange = New System.Windows.Forms.Panel()
        Me.gbCutter = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rbtCutterNo = New System.Windows.Forms.RadioButton()
        Me.rbtCutterYes = New System.Windows.Forms.RadioButton()
        Me.gbTapeChange = New System.Windows.Forms.GroupBox()
        Me.pnlTapeChange = New System.Windows.Forms.Panel()
        Me.tbxTapeChangeLotNo = New System.Windows.Forms.TextBox()
        Me.dtpTapeChangeValidity = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbtTapeChangeNo = New System.Windows.Forms.RadioButton()
        Me.rbtTapeChangeYes = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxWaferFabNo = New System.Windows.Forms.TextBox()
        Me.BgDataTableAdapter = New CellController.DBxDataSetTableAdapters.BGDataTableAdapter()
        Me.DBxDataSet1 = New CellController.DBxDataSet()
        Me.GroupMemberTableAdapter1 = New CellController.DBxDataSetTableAdapters.GroupMemberTableAdapter()
        Me.gbRecipe = New System.Windows.Forms.GroupBox()
        Me.cbRightCassette = New System.Windows.Forms.CheckBox()
        Me.cbLeftCassette = New System.Windows.Forms.CheckBox()
        Me.cbxRecipeNo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbWaferSizeChange.SuspendLayout()
        Me.pnlWaferSize.SuspendLayout()
        Me.pnlCutterChange.SuspendLayout()
        Me.gbCutter.SuspendLayout()
        Me.gbTapeChange.SuspendLayout()
        Me.pnlTapeChange.SuspendLayout()
        CType(Me.DBxDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRecipe.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbWaferSizeChange
        '
        Me.gbWaferSizeChange.Controls.Add(Me.pnlWaferSize)
        Me.gbWaferSizeChange.Controls.Add(Me.Label1)
        Me.gbWaferSizeChange.Controls.Add(Me.rbtWaferSizeNo)
        Me.gbWaferSizeChange.Controls.Add(Me.rbtWaferSizeYes)
        Me.gbWaferSizeChange.Location = New System.Drawing.Point(17, 49)
        Me.gbWaferSizeChange.Name = "gbWaferSizeChange"
        Me.gbWaferSizeChange.Size = New System.Drawing.Size(217, 145)
        Me.gbWaferSizeChange.TabIndex = 13
        Me.gbWaferSizeChange.TabStop = False
        Me.gbWaferSizeChange.Text = "WaferSize"
        Me.gbWaferSizeChange.UseCompatibleTextRendering = True
        '
        'pnlWaferSize
        '
        Me.pnlWaferSize.Controls.Add(Me.Label2)
        Me.pnlWaferSize.Controls.Add(Me.cbxWaferSizeChangeTo)
        Me.pnlWaferSize.Controls.Add(Me.Label3)
        Me.pnlWaferSize.Controls.Add(Me.cbxWaferSizeChangeFrom)
        Me.pnlWaferSize.Enabled = False
        Me.pnlWaferSize.Location = New System.Drawing.Point(25, 69)
        Me.pnlWaferSize.Name = "pnlWaferSize"
        Me.pnlWaferSize.Size = New System.Drawing.Size(160, 67)
        Me.pnlWaferSize.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From"
        '
        'cbxWaferSizeChangeTo
        '
        Me.cbxWaferSizeChangeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxWaferSizeChangeTo.FormattingEnabled = True
        Me.cbxWaferSizeChangeTo.Items.AddRange(New Object() {"8", "12"})
        Me.cbxWaferSizeChangeTo.Location = New System.Drawing.Point(57, 38)
        Me.cbxWaferSizeChangeTo.Name = "cbxWaferSizeChangeTo"
        Me.cbxWaferSizeChangeTo.Size = New System.Drawing.Size(96, 21)
        Me.cbxWaferSizeChangeTo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To"
        '
        'cbxWaferSizeChangeFrom
        '
        Me.cbxWaferSizeChangeFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxWaferSizeChangeFrom.FormattingEnabled = True
        Me.cbxWaferSizeChangeFrom.Items.AddRange(New Object() {"8", "12"})
        Me.cbxWaferSizeChangeFrom.Location = New System.Drawing.Point(57, 7)
        Me.cbxWaferSizeChangeFrom.Name = "cbxWaferSizeChangeFrom"
        Me.cbxWaferSizeChangeFrom.Size = New System.Drawing.Size(96, 21)
        Me.cbxWaferSizeChangeFrom.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "WaferSizeChange"
        '
        'rbtWaferSizeNo
        '
        Me.rbtWaferSizeNo.AutoSize = True
        Me.rbtWaferSizeNo.Checked = True
        Me.rbtWaferSizeNo.Location = New System.Drawing.Point(130, 48)
        Me.rbtWaferSizeNo.Name = "rbtWaferSizeNo"
        Me.rbtWaferSizeNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtWaferSizeNo.TabIndex = 1
        Me.rbtWaferSizeNo.TabStop = True
        Me.rbtWaferSizeNo.Text = "No"
        Me.rbtWaferSizeNo.UseVisualStyleBackColor = True
        '
        'rbtWaferSizeYes
        '
        Me.rbtWaferSizeYes.AutoSize = True
        Me.rbtWaferSizeYes.Location = New System.Drawing.Point(48, 48)
        Me.rbtWaferSizeYes.Name = "rbtWaferSizeYes"
        Me.rbtWaferSizeYes.Size = New System.Drawing.Size(43, 17)
        Me.rbtWaferSizeYes.TabIndex = 0
        Me.rbtWaferSizeYes.Text = "Yes"
        Me.rbtWaferSizeYes.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Status"
        '
        'cbxCutterStatus
        '
        Me.cbxCutterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCutterStatus.FormattingEnabled = True
        Me.cbxCutterStatus.Items.AddRange(New Object() {"OK", "NG"})
        Me.cbxCutterStatus.Location = New System.Drawing.Point(62, 7)
        Me.cbxCutterStatus.Name = "cbxCutterStatus"
        Me.cbxCutterStatus.Size = New System.Drawing.Size(69, 21)
        Me.cbxCutterStatus.TabIndex = 2
        '
        'tbxCutterTemp
        '
        Me.tbxCutterTemp.Location = New System.Drawing.Point(62, 38)
        Me.tbxCutterTemp.Name = "tbxCutterTemp"
        Me.tbxCutterTemp.Size = New System.Drawing.Size(69, 20)
        Me.tbxCutterTemp.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Temp"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(50, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Wafer Fab No. :"
        '
        'btnInputDataClear
        '
        Me.btnInputDataClear.Location = New System.Drawing.Point(278, 354)
        Me.btnInputDataClear.Name = "btnInputDataClear"
        Me.btnInputDataClear.Size = New System.Drawing.Size(75, 35)
        Me.btnInputDataClear.TabIndex = 18
        Me.btnInputDataClear.Text = "Close"
        Me.btnInputDataClear.UseVisualStyleBackColor = True
        '
        'btnInputDataOK
        '
        Me.btnInputDataOK.Location = New System.Drawing.Point(126, 354)
        Me.btnInputDataOK.Name = "btnInputDataOK"
        Me.btnInputDataOK.Size = New System.Drawing.Size(75, 35)
        Me.btnInputDataOK.TabIndex = 17
        Me.btnInputDataOK.Text = "OK"
        Me.btnInputDataOK.UseVisualStyleBackColor = True
        '
        'pnlCutterChange
        '
        Me.pnlCutterChange.Controls.Add(Me.Label11)
        Me.pnlCutterChange.Controls.Add(Me.cbxCutterStatus)
        Me.pnlCutterChange.Controls.Add(Me.tbxCutterTemp)
        Me.pnlCutterChange.Controls.Add(Me.Label7)
        Me.pnlCutterChange.Enabled = False
        Me.pnlCutterChange.Location = New System.Drawing.Point(28, 69)
        Me.pnlCutterChange.Name = "pnlCutterChange"
        Me.pnlCutterChange.Size = New System.Drawing.Size(142, 70)
        Me.pnlCutterChange.TabIndex = 13
        '
        'gbCutter
        '
        Me.gbCutter.Controls.Add(Me.pnlCutterChange)
        Me.gbCutter.Controls.Add(Me.Label9)
        Me.gbCutter.Controls.Add(Me.rbtCutterNo)
        Me.gbCutter.Controls.Add(Me.rbtCutterYes)
        Me.gbCutter.Location = New System.Drawing.Point(254, 49)
        Me.gbCutter.Name = "gbCutter"
        Me.gbCutter.Size = New System.Drawing.Size(217, 145)
        Me.gbCutter.TabIndex = 15
        Me.gbCutter.TabStop = False
        Me.gbCutter.Text = "Cutter"
        Me.gbCutter.UseCompatibleTextRendering = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "CutterChange"
        '
        'rbtCutterNo
        '
        Me.rbtCutterNo.AutoSize = True
        Me.rbtCutterNo.Checked = True
        Me.rbtCutterNo.Location = New System.Drawing.Point(124, 48)
        Me.rbtCutterNo.Name = "rbtCutterNo"
        Me.rbtCutterNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtCutterNo.TabIndex = 1
        Me.rbtCutterNo.TabStop = True
        Me.rbtCutterNo.Text = "No"
        Me.rbtCutterNo.UseVisualStyleBackColor = True
        '
        'rbtCutterYes
        '
        Me.rbtCutterYes.AutoSize = True
        Me.rbtCutterYes.Location = New System.Drawing.Point(48, 48)
        Me.rbtCutterYes.Name = "rbtCutterYes"
        Me.rbtCutterYes.Size = New System.Drawing.Size(43, 17)
        Me.rbtCutterYes.TabIndex = 0
        Me.rbtCutterYes.Text = "Yes"
        Me.rbtCutterYes.UseVisualStyleBackColor = True
        '
        'gbTapeChange
        '
        Me.gbTapeChange.Controls.Add(Me.pnlTapeChange)
        Me.gbTapeChange.Controls.Add(Me.rbtTapeChangeNo)
        Me.gbTapeChange.Controls.Add(Me.rbtTapeChangeYes)
        Me.gbTapeChange.Controls.Add(Me.Label4)
        Me.gbTapeChange.Location = New System.Drawing.Point(17, 200)
        Me.gbTapeChange.Name = "gbTapeChange"
        Me.gbTapeChange.Size = New System.Drawing.Size(217, 140)
        Me.gbTapeChange.TabIndex = 14
        Me.gbTapeChange.TabStop = False
        Me.gbTapeChange.Text = "TapeChange"
        '
        'pnlTapeChange
        '
        Me.pnlTapeChange.Controls.Add(Me.tbxTapeChangeLotNo)
        Me.pnlTapeChange.Controls.Add(Me.dtpTapeChangeValidity)
        Me.pnlTapeChange.Controls.Add(Me.Label5)
        Me.pnlTapeChange.Controls.Add(Me.Label6)
        Me.pnlTapeChange.Enabled = False
        Me.pnlTapeChange.Location = New System.Drawing.Point(9, 69)
        Me.pnlTapeChange.Name = "pnlTapeChange"
        Me.pnlTapeChange.Size = New System.Drawing.Size(200, 66)
        Me.pnlTapeChange.TabIndex = 11
        '
        'tbxTapeChangeLotNo
        '
        Me.tbxTapeChangeLotNo.Location = New System.Drawing.Point(82, 2)
        Me.tbxTapeChangeLotNo.Name = "tbxTapeChangeLotNo"
        Me.tbxTapeChangeLotNo.Size = New System.Drawing.Size(110, 20)
        Me.tbxTapeChangeLotNo.TabIndex = 8
        '
        'dtpTapeChangeValidity
        '
        Me.dtpTapeChangeValidity.Location = New System.Drawing.Point(82, 30)
        Me.dtpTapeChangeValidity.Name = "dtpTapeChangeValidity"
        Me.dtpTapeChangeValidity.Size = New System.Drawing.Size(110, 20)
        Me.dtpTapeChangeValidity.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "LotNo."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Validity"
        '
        'rbtTapeChangeNo
        '
        Me.rbtTapeChangeNo.AutoSize = True
        Me.rbtTapeChangeNo.Checked = True
        Me.rbtTapeChangeNo.Location = New System.Drawing.Point(130, 47)
        Me.rbtTapeChangeNo.Name = "rbtTapeChangeNo"
        Me.rbtTapeChangeNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtTapeChangeNo.TabIndex = 7
        Me.rbtTapeChangeNo.TabStop = True
        Me.rbtTapeChangeNo.Text = "No"
        Me.rbtTapeChangeNo.UseVisualStyleBackColor = True
        '
        'rbtTapeChangeYes
        '
        Me.rbtTapeChangeYes.AutoSize = True
        Me.rbtTapeChangeYes.Location = New System.Drawing.Point(48, 47)
        Me.rbtTapeChangeYes.Name = "rbtTapeChangeYes"
        Me.rbtTapeChangeYes.Size = New System.Drawing.Size(43, 17)
        Me.rbtTapeChangeYes.TabIndex = 6
        Me.rbtTapeChangeYes.Text = "Yes"
        Me.rbtTapeChangeYes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "TapeChange"
        '
        'tbxWaferFabNo
        '
        Me.tbxWaferFabNo.Location = New System.Drawing.Point(165, 17)
        Me.tbxWaferFabNo.Name = "tbxWaferFabNo"
        Me.tbxWaferFabNo.Size = New System.Drawing.Size(274, 20)
        Me.tbxWaferFabNo.TabIndex = 20
        '
        'BgDataTableAdapter
        '
        Me.BgDataTableAdapter.ClearBeforeFill = True
        '
        'DBxDataSet1
        '
        Me.DBxDataSet1.DataSetName = "DBxDataSet"
        Me.DBxDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupMemberTableAdapter1
        '
        Me.GroupMemberTableAdapter1.ClearBeforeFill = True
        '
        'gbRecipe
        '
        Me.gbRecipe.Controls.Add(Me.cbRightCassette)
        Me.gbRecipe.Controls.Add(Me.cbLeftCassette)
        Me.gbRecipe.Controls.Add(Me.cbxRecipeNo)
        Me.gbRecipe.Controls.Add(Me.Label8)
        Me.gbRecipe.Location = New System.Drawing.Point(254, 200)
        Me.gbRecipe.Name = "gbRecipe"
        Me.gbRecipe.Size = New System.Drawing.Size(217, 140)
        Me.gbRecipe.TabIndex = 21
        Me.gbRecipe.TabStop = False
        Me.gbRecipe.Text = "Recipe"
        '
        'cbRightCassette
        '
        Me.cbRightCassette.AutoSize = True
        Me.cbRightCassette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbRightCassette.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbRightCassette.Location = New System.Drawing.Point(19, 93)
        Me.cbRightCassette.Name = "cbRightCassette"
        Me.cbRightCassette.Size = New System.Drawing.Size(163, 29)
        Me.cbRightCassette.TabIndex = 19
        Me.cbRightCassette.Text = "RightCassette"
        Me.cbRightCassette.UseVisualStyleBackColor = True
        '
        'cbLeftCassette
        '
        Me.cbLeftCassette.AutoSize = True
        Me.cbLeftCassette.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbLeftCassette.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbLeftCassette.Location = New System.Drawing.Point(19, 58)
        Me.cbLeftCassette.Name = "cbLeftCassette"
        Me.cbLeftCassette.Size = New System.Drawing.Size(149, 29)
        Me.cbLeftCassette.TabIndex = 19
        Me.cbLeftCassette.Text = "LeftCassette"
        Me.cbLeftCassette.UseVisualStyleBackColor = True
        '
        'cbxRecipeNo
        '
        Me.cbxRecipeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRecipeNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbxRecipeNo.FormattingEnabled = True
        Me.cbxRecipeNo.Items.AddRange(New Object() {"08", "12"})
        Me.cbxRecipeNo.Location = New System.Drawing.Point(90, 19)
        Me.cbxRecipeNo.Name = "cbxRecipeNo"
        Me.cbxRecipeNo.Size = New System.Drawing.Size(122, 33)
        Me.cbxRecipeNo.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "RecipeNo."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnInputDataOK)
        Me.Panel1.Controls.Add(Me.btnInputDataClear)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(486, 411)
        Me.Panel1.TabIndex = 22
        '
        'FormInputData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(486, 411)
        Me.Controls.Add(Me.gbRecipe)
        Me.Controls.Add(Me.gbWaferSizeChange)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.gbCutter)
        Me.Controls.Add(Me.gbTapeChange)
        Me.Controls.Add(Me.tbxWaferFabNo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormInputData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormInputData"
        Me.gbWaferSizeChange.ResumeLayout(False)
        Me.gbWaferSizeChange.PerformLayout()
        Me.pnlWaferSize.ResumeLayout(False)
        Me.pnlWaferSize.PerformLayout()
        Me.pnlCutterChange.ResumeLayout(False)
        Me.pnlCutterChange.PerformLayout()
        Me.gbCutter.ResumeLayout(False)
        Me.gbCutter.PerformLayout()
        Me.gbTapeChange.ResumeLayout(False)
        Me.gbTapeChange.PerformLayout()
        Me.pnlTapeChange.ResumeLayout(False)
        Me.pnlTapeChange.PerformLayout()
        CType(Me.DBxDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRecipe.ResumeLayout(False)
        Me.gbRecipe.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbWaferSizeChange As GroupBox
    Friend WithEvents pnlWaferSize As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxWaferSizeChangeTo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxWaferSizeChangeFrom As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbtWaferSizeNo As RadioButton
    Friend WithEvents rbtWaferSizeYes As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents cbxCutterStatus As ComboBox
    Friend WithEvents tbxCutterTemp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnInputDataClear As Button
    Friend WithEvents btnInputDataOK As Button
    Friend WithEvents pnlCutterChange As Panel
    Friend WithEvents gbCutter As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents rbtCutterNo As RadioButton
    Friend WithEvents rbtCutterYes As RadioButton
    Friend WithEvents gbTapeChange As GroupBox
    Friend WithEvents pnlTapeChange As Panel
    Friend WithEvents tbxTapeChangeLotNo As TextBox
    Friend WithEvents dtpTapeChangeValidity As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents rbtTapeChangeNo As RadioButton
    Friend WithEvents rbtTapeChangeYes As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents tbxWaferFabNo As TextBox
    Friend WithEvents BgDataTableAdapter As DBxDataSetTableAdapters.BGDataTableAdapter
    Friend WithEvents DBxDataSet1 As DBxDataSet
    Friend WithEvents GroupMemberTableAdapter1 As DBxDataSetTableAdapters.GroupMemberTableAdapter
    Friend WithEvents gbRecipe As GroupBox
    Friend WithEvents cbxRecipeNo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbRightCassette As CheckBox
    Friend WithEvents cbLeftCassette As CheckBox
End Class
