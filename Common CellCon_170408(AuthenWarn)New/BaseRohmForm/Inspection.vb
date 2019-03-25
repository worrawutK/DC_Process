Public Class Inspection
    Public m_BGDataTable As DBxDataSet.BGDataDataTable
    Dim row As Integer
    Dim Final As Boolean
    Dim WaferSizeChange As String
    Dim TapeChange As String
    Dim CutterChange As String
    Dim InspectionJudgement As String = "Pass"

    Private Sub tbxGLNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxGLNo.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then
            If GroupMemberTableAdapter1.Fill(DBxDataSet1.GroupMember, My.Settings.UserAuthenGL, tbxGLNo.Text.Trim) = 0 Then
                MsgBox("GLNo : ไม่มี license หรือ license หมดอายุ(" & My.Settings.UserAuthenGL & ")") 'Invalid
                tbxGLNo.Text = ""
                tbxGLNo.Focus()
            Else
                'End Process
                '    '    rbtInspectFail.Show()
                '    '    rbtInspectPass.Show()
                '    '    pnlGLNo.Hide()
            End If
        End If
    End Sub
    Public Sub GetBGDatatable(ByVal table As DBxDataSet.BGDataDataTable, ByRef Rows As Integer, ByRef Final_Lot As Boolean)
        m_BGDataTable = table
        row = Rows
        Final = Final_Lot

    End Sub
    Private Sub btEnd_Click(sender As Object, e As EventArgs) Handles btEnd.Click
        If rbtInspectFail.Checked AndAlso tbxGLNo.Text.Length <> 6 Then
            MsgBox("กรุณา GL Confirm")
            Exit Sub
        End If
        Dim StartTime As DateTime = Now

        Dim dataRo As DBxDataSet.BGDataRow = m_BGDataTable.Item(row)
        With dataRo
            '.WaferSizeChange = WaferSizeChange
            ' .WaferSizeChangeFrom = cbxWaferSizeChangeFrom.Text
            ' .WaferSizeChangeTo = cbxWaferSizeChangeTo.Text
            '   .TapeChange = TapeChange
            '  .TapeLotNo = tbxTapeChangeLotNo.Text
            '  .ValidityPeriod = Format(dtpTapeChangeValidity.Value, "yyyy-MM-dd HH:mm:ss")
            ' .CutterStatus = cbxCutterStatus.Text
            ' .CutterChange = CutterChange
            '   .CutterTemp = tbxCutterTemp.Text
            ' .RecipeNo = cbxRecipeNo.Text
            .InspectionJudgement = InspectionJudgement
            .GLCheck = tbxGLNo.Text

            'If Final = True Then
            '    'BgDataTableAdapter.Update(m_BGDataTable)
            '    For Each Rowdata As DBxDataSet.BGDataRow In m_BGDataTable
            '        Rowdata.FinishTime = CDate(Format(StartTime, "yyyy-MM-dd HH:mm:ss"))
            '        For i As Integer = 0 To m_BGDataTable.Columns.Count - 1
            '            If String.IsNullOrEmpty(Rowdata.Item(i).ToString) Then

            '                Rowdata.Item(i) = "**"

            '            End If
            '        Next
            '    Next
            '    BgDataTableAdapter1.Update(m_BGDataTable)
            'End If
        End With
        ' DataGridView1.DataSource = m_BGDataTable

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub rbtInspectPass_CheckedChanged(sender As Object, e As EventArgs) Handles rbtInspectPass.CheckedChanged, rbtInspectFail.CheckedChanged
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Checked AndAlso val.Text <> "" Then
            If val.Name = "rbtInspectFail" Then
                pnlGLNo.Visible = True
                tbxGLNo.Text = ""
                tbxGLNo.Focus()
            Else
                tbxGLNo.Text = ""
                  pnlGLNo.Visible = False
            End If
            InspectionJudgement = val.Text
        End If

    End Sub
End Class