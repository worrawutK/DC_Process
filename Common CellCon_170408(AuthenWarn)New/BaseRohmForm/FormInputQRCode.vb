Imports yezpedLibrary.WaferSlip

Public Class FormInputQRCode
    Public m_QRCode(0) As String
    Public m_OPNo As String
    Public m_QRNo As Integer
    'Event MessageError(Text As String)
    Public m_BGTable As DBxDataSet.BGDataDataTable
    Public ErrorMsg As String
    Dim Final As Boolean

    '   Dim m_frmMain As MDIParent1

    'Public Sub New(frmMain As MDIParent1)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    m_frmMain = frmMain

    'End Sub

    Private Sub FormInputQRCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Label1.Text = "Please scan WaferSlip QRCode"
        m_QRNo = 1
        m_OPNo = ""
        m_QRCode(0) = ""
        lbQRNo.Text = m_QRNo.ToString
        pgbQRCode.Value = 0
        tbxInputQR.Focus()
        If Final = False Then
            m_BGTable = New DBxDataSet.BGDataDataTable
        End If

        ' m_frmMain.ToolStripStatusLabel2.Text = ""
    End Sub
    Private Sub tbxInputQR_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbxInputQR.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 27 Then
            Me.Close()
            Exit Sub
        End If
        'If Microsoft.VisualBasic.Asc(e.KeyChar) <> 13 Then
        '    If pgbQRCode.Value > 255 Then
        '        MsgBox("Data is wrong" & vbNewLine & "Please scan QRCode again")
        '        pgbQRCode.Value = 0
        '        Exit Sub
        '    End If
        '    pgbQRCode.Value = pgbQRCode.Value + 1
        '    Exit Sub
        'End If
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Then

            If Final = True Then
                If tbxInputQR.Text.Length = 6 OrElse tbxInputQR.Text.Length = 7 Then
                    If tbxInputQR.Text.Length = 7 Then tbxInputQR.Text = tbxInputQR.Text.Substring(1, 6)

                    If My.Settings.PersonAuthorization = True Then
                        'Dim workslip As New WorkingSlipQRCode
                        'workslip.SplitQRCode(Para.QrData)

                        Dim Authen As New Authentication
                        Authen.PermiisionCheck(tbxInputQR.Text, My.Settings.UserAuthenOP, My.Settings.UserAuthenGL, My.Settings.ProcessName, My.Settings.ProcessName & "-" & My.Settings.EquipmentNo)
                        If Authen.Ispass = False Then
                            'ErrorMsg = Authen.ErrorMessage
                            MsgBox(Authen.ErrorMessage)
                            tbxInputQR.Text = ""
                            pgbQRCode.Value = 0
                            tbxInputQR.Focus()
                            Exit Sub

                        End If

                    End If

                    ' MainForm.ReceiveAllDataQRCode(m_OPNo, m_QRCode)
                    Dim StartTime As DateTime = Now
                    For Each Rowdata As DBxDataSet.BGDataRow In m_BGTable
                        Rowdata.FinishTime = CDate(Format(StartTime, "yyyy-MM-dd HH:mm:ss"))
                        Rowdata.OPEnd = tbxInputQR.Text
                        For i As Integer = 0 To m_BGTable.Columns.Count - 1
                            If String.IsNullOrEmpty(Rowdata.Item(i).ToString) Then

                                Rowdata.Item(i) = "**"

                            End If
                        Next
                    Next
                    BgDataTableAdapter.Update(m_BGTable)
                    Final = False

                    Me.DialogResult = DialogResult.OK

                End If
                Exit Sub
            End If


            If tbxInputQR.Text.Length >= 254 Then
                Try

                    If tbxInputQR.Text.Length > 254 Then
                        tbxInputQR.Text = tbxInputQR.Text.Substring(0, 254)
                    End If


                    Dim DCSlip As WaferSlip = New WaferSlip
                    DCSlip.FullCode = tbxInputQR.Text
                    LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1.Fill(DBxDataSet.LCQW_UNION_WORK_DENPYO_PRINT, DCSlip.Chip)

                    '    BGDataTableAdapter
                    'BgDataTableAdapter.Fill(m_BGTable, "BG-BG-02")
                    'For Each data As DBxDataSet.BGDataRow In m_BGTable
                    '    If data.WaferFabLotNo = DCSlip.WFLotNo AndAlso data.WaferNo = DCSlip.WaferNo Then
                    '        MsgBox("Slip นี้ถูกยิ่งเข้าไปแล้ว")
                    '        tbxInputQR.Text = ""
                    '        pgbQRCode.Value = 0
                    '        tbxInputQR.Focus()
                    '        Exit Sub
                    '    End If
                    'Next
                    Dim pkg As String = "**"
                    If DBxDataSet.LCQW_UNION_WORK_DENPYO_PRINT.Count > 0 Then
                        pkg = DBxDataSet.LCQW_UNION_WORK_DENPYO_PRINT.Rows(0).Item("FORM_NAME_1").ToString.ToUpper()
                    End If



                    Dim row As DBxDataSet.BGDataRow = m_BGTable.NewBGDataRow
                    With row
                        .MCNo = My.Settings.HeaderProcess & My.Settings.EquipmentNo
                        .MCType = My.Settings.MCType
                        .ProductionDate = Now
                        .PackageName = pkg
                        .WaferFabLotNo = DCSlip.WFLotNo
                        .DeviceName = DCSlip.AssyLot
                        .WaferQtyIn = DCSlip.Wafer
                        .WaferQtyOut = .WaferQtyIn 'DCSlip.WaferNo
                        .WaferNo = DCSlip.WaferNo
                        '   .OPStart = OprData.OPID
                        '.WaferSizeChange = "No"
                        '.WaferSizeChangeFrom = "**"
                        '.WaferSizeChangeTo = "**"
                        '.WaferSize = "12"
                        '.TapeChange = "No"
                        '.TapeLotNo = "**"
                        '.ValidityPeriod = "**"
                        '.CutterChange = "No"
                        '.CutterStatus = "**"
                        '.CutterTemp = "**"
                        '.RecipeNo = "12"
                        '.DirtyBackside = "**"
                        '.ForeignMaterialOnBackside = "**"
                        '.UnevenBacksideFace = "**"
                        '.WaferCrack = "**"
                        '.WaferChipping = "**"
                        '.WaferBroken = "**"
                        '.WaferScratch = "**"
                        '.AbnormalBacksideFace1 = "**"
                        '.AbnormalBacksideFace2 = "**"
                        '.InspectionJudgement = "Pass"
                        '.WaferTickness = "**"
                        '.BladeChange = "**"
                        '.BladeChangeBrokenWF = "**"
                        ' .StartTime = CDate(Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        '.OPStart = ""
                        '.FinishTime = Now
                        '.OPEnd = ""
                        '.Remark = "**"
                        '.RemarkDetail = "**"
                        '.GLCheck = "**"

                    End With

                    'm_BGTable.
                    m_BGTable.Rows.InsertAt(row, 0)
                    '  m_BGTable.Rows.Add(row)
                    DataGridView1.DataSource = m_BGTable
                    ' m_BGTable = DBxDataSet.BGData
                    tbxInputQR.Text = ""
                    pgbQRCode.Value = 0
                    tbxInputQR.Focus()
                    m_QRNo += 1
                    lbQRNo.Text = m_QRNo.ToString
                    Exit Sub
                Catch ex As Exception
                    ' RaiseEvent MessageError("QR Length :" & tbxInputQR.Text.Length & ">>" & ex.Message.ToString)
                    MsgBox("QR Length :" & tbxInputQR.Text.Length & ">>" & ex.Message.ToString)
                    tbxInputQR.Text = ""
                    pgbQRCode.Value = 0
                    tbxInputQR.Focus()
                    Exit Sub
                End Try
            End If

            If m_QRNo > 1 Then

                If tbxInputQR.Text.Length = 6 OrElse tbxInputQR.Text.Length = 7 Then
                    If tbxInputQR.Text.Length = 7 Then tbxInputQR.Text = tbxInputQR.Text.Substring(1, 6)
                    m_OPNo = tbxInputQR.Text
                    ' MainForm.ReceiveAllDataQRCode(m_OPNo, m_QRCode)
                    tbxInputQR.Text = ""
                    tbxInputQR.Focus()

                    Me.DialogResult = DialogResult.OK
                    Exit Sub
                End If
            End If

            MsgBox("QR Length :" & tbxInputQR.Text.Length)
            '  MsgBox("Invalid Data")
            tbxInputQR.Text = ""
            pgbQRCode.Value = 0
            tbxInputQR.Focus()

        Else
            Try
                pgbQRCode.Value = pgbQRCode.Value + 1
            Catch ex As Exception

            End Try

        End If

    End Sub
    Public Sub GetBGDatatableEnd(ByVal table As DBxDataSet.BGDataDataTable, ByRef Final_Lot As Boolean)
        m_BGTable = table
        Final = Final_Lot
    End Sub

End Class