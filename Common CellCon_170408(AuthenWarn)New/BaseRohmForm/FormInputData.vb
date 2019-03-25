Public Class FormInputData
    Public m_BGDataTable As DBxDataSet.BGDataDataTable
    Dim row As Integer
    Dim Final As Boolean
    Dim WaferSizeChange As String = "No"
    Dim TapeChange As String = "No"
    Dim CutterChange As String = "No"
    Dim InspectionJudgement As String
    Dim OPNo As String
    Enum Area
        WaferSize
        Cutter
        TapeChange
        Recipe
        All
    End Enum
    Private Sub FormInputData_Load(sender As Object, e As EventArgs) Handles Me.Load
        '    DataGridView1.DataSource = m_BGDataTable
        Dim data As DBxDataSet.BGDataRow = m_BGDataTable.Item(row)
        tbxWaferFabNo.Text = data.WaferFabLotNo
        ControlArea("No", Area.All)

        cbxRecipeNo.Text = My.Settings.RecipeNo
    End Sub

    Private Sub btnInputDataOK_Click(sender As Object, e As EventArgs) Handles btnInputDataOK.Click
        If cbxRecipeNo.Text = "" Then
            MsgBox("กรุณาเลือก RecipeNo")
            Exit Sub
        End If
        If rbtWaferSizeYes.Checked AndAlso (cbxWaferSizeChangeFrom.Text = "" OrElse cbxWaferSizeChangeTo.Text = "") Then
            MsgBox("กรุณาใส่ข้อมูลให้ครบ")
            Exit Sub
        End If
        If rbtCutterYes.Checked AndAlso cbxCutterStatus.Text = "" Then
            MsgBox("กรุณาใส่ข้อมูลให้ครบ")
            Exit Sub
        End If
        If cbLeftCassette.Checked = False AndAlso cbRightCassette.Checked = False Then
            MsgBox("กรุณาเลือก LeftCassette หรือ RightCassette ")
            Exit Sub
        End If
        Dim StartTime As DateTime = Now

        Dim dataRo As DBxDataSet.BGDataRow = m_BGDataTable.Item(row)
        With dataRo
            .WaferSizeChange = WaferSizeChange
            .WaferSizeChangeFrom = cbxWaferSizeChangeFrom.Text
            .WaferSizeChangeTo = cbxWaferSizeChangeTo.Text
            .TapeChange = TapeChange
            .TapeLotNo = tbxTapeChangeLotNo.Text
            If TapeChange.ToUpper = "YES" Then
                .ValidityPeriod = Format(dtpTapeChangeValidity.Value, "yyyy-MM-dd")
            End If

            .CutterStatus = cbxCutterStatus.Text
            .CutterChange = CutterChange
            .CutterTemp = tbxCutterTemp.Text
            .RecipeNo = cbxRecipeNo.Text
            .InspectionJudgement = InspectionJudgement
            '  .GLCheck = tbxGLNo.Text
            .OPStart = OPNo
            If Final = True Then
                'BgDataTableAdapter.Update(m_BGDataTable)
                For Each Rowdata As DBxDataSet.BGDataRow In m_BGDataTable
                    With Rowdata
                        .StartTime = CDate(Format(StartTime, "yyyy-MM-dd HH:mm:ss"))

                    End With
                Next
                '    DataGridView1.DataSource = m_BGDataTable
                BgDataTableAdapter.Update(m_BGDataTable)
            End If
        End With
        My.Settings.RecipeNo = cbxRecipeNo.Text
        My.Settings.Save()
        If cbLeftCassette.Checked And cbRightCassette.Checked Then
            CassetteStatus = EquipmentCassetteStatus.AllCassette
        ElseIf cbLeftCassette.Checked And cbRightCassette.Checked = False Then
            CassetteStatus = EquipmentCassetteStatus.LeftCassette
        ElseIf cbRightCassette.Checked And cbLeftCassette.Checked = False Then
            CassetteStatus = EquipmentCassetteStatus.RightCassette
        End If
        Me.DialogResult = DialogResult.OK
    End Sub
    Public Sub GetBGDatatable(ByVal table As DBxDataSet.BGDataDataTable, _OPNo As String, ByRef Rows As Integer, ByRef Final_Lot As Boolean, End_Lot As Boolean)
        m_BGDataTable = table
        row = Rows
        Final = Final_Lot
        OPNo = _OPNo
    End Sub

    Private Sub rbtWaferSizeYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtWaferSizeYes.CheckedChanged, rbtWaferSizeNo.CheckedChanged
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Checked And val.Text <> "" Then
            WaferSizeChange = val.Text
            ControlArea(val.Text, Area.WaferSize)
        End If

    End Sub
    Private Sub ControlArea(val As String, _Area As Integer)
        If _Area = Area.WaferSize OrElse _Area = Area.All Then
            If val.ToUpper = "YES" Then
                pnlWaferSize.Enabled = True
            Else
                pnlWaferSize.Enabled = False
            End If
        End If
        If _Area = Area.TapeChange OrElse _Area = Area.All Then
            If val.ToUpper = "YES" Then
                pnlTapeChange.Enabled = True
            Else
                pnlTapeChange.Enabled = False
            End If
        End If

        If _Area = Area.Cutter OrElse _Area = Area.All Then
            If val.ToUpper = "YES" Then
                pnlCutterChange.Enabled = True
            Else
                pnlCutterChange.Enabled = False
            End If
        End If

        'If _Area = Area.Recipe OrElse _Area = Area.All Then

        '    If val.ToUpper = "FAIL" Then
        '        pnlGLNo.Visible = True
        '        tbxGLNo.Focus()
        '    Else
        '        pnlGLNo.Visible = False
        '    End If
        'End If

    End Sub

    Private Sub rbtTapeChangeYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtTapeChangeYes.CheckedChanged, rbtTapeChangeNo.CheckedChanged
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Checked AndAlso val.Text <> "" Then
            TapeChange = val.Text
            ControlArea(val.Text, Area.TapeChange)
        End If

    End Sub

    Private Sub rbtCutterYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCutterYes.CheckedChanged, rbtCutterNo.CheckedChanged
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Checked AndAlso val.Text <> "" Then
            CutterChange = val.Text
            ControlArea(val.Text, Area.Cutter)
        End If

    End Sub

    Private Sub rbtInspectPass_CheckedChanged(sender As Object, e As EventArgs)
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Checked AndAlso val.Text <> "" Then
            InspectionJudgement = val.Text
            ControlArea(val.Text, Area.Recipe)
        End If

    End Sub

    Private Sub btnInputDataClear_Click(sender As Object, e As EventArgs) Handles btnInputDataClear.Click
        Me.DialogResult = DialogResult.OK
    End Sub



    'Private Sub tbxGLNo_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
    '        If GroupMemberTableAdapter1.Fill(DBxDataSet1.GroupMember, My.Settings.UserAuthenGL, tbxGLNo.Text.Trim) = 0 Then
    '            MsgBox("GLNo : Invalid")
    '            tbxGLNo.Text = Nothing
    '            tbxGLNo.Focus()
    '        Else
    '            '    '    rbtInspectFail.Show()
    '            '    '    rbtInspectPass.Show()
    '            '    '    pnlGLNo.Hide()
    '        End If
    '    End If
    'End Sub
End Class