Public Class Setting
#Region "Commomn Define"
    Event E_FormClosing(ByVal Flag As Integer)
    Event E_SlInfo(ByVal msg As String)      '170105 \783 Add Info
    Dim MySettingsEquipmentIP As String
    Dim MySettingsProcessName As String
    Dim MySettingsMCType As String
    Dim MySettingsDBConnSTR As String
    Dim MySettingsEquipmentNo As String
    Dim MySettingsUserAuthenOP As String
    Dim MySettingsUserAuthenGL As String
    Dim MySettingsMDISizable As Boolean
    Dim MySettingsMDITableFrm As Boolean
    Dim MySettingsMDIQRSystem As Boolean
    Dim MySettingsFrmProdTableInfo As Boolean
    Dim MySettingsFrmProdTableDetail As Boolean





    Friend Enum SecsSettingCloseFlag
        Normal
        Warning
        ForceOFF
    End Enum
    Dim RestartRequestFlag As New SecsSettingCloseFlag
#End Region
    Private Sub Setting_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If rbSecsEna.Checked Then
            If Not My.Settings.SECS_Enable Then     'Set RestartRequestFlag mis check
                My.Settings.SECS_Enable = True
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If
        End If

        If rbSecsDis.Checked Then
            If My.Settings.SECS_Enable Then     'Set RestartRequestFlag mis check
                My.Settings.SECS_Enable = False
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If rbTDCDisa.Checked Then
            If My.Settings.TDC_Enable Then     'Set RestartRequestFlag mis check
                My.Settings.TDC_Enable = False
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If rbTDCEna.Checked Then
            If Not My.Settings.TDC_Enable Then     'Set RestartRequestFlag mis check
                My.Settings.TDC_Enable = True
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If
        End If

        If rbnWFLoadEna.Checked Then
            If Not My.Settings.WaferMappingUse Then     'Set RestartRequestFlag mis check
                My.Settings.WaferMappingUse = True
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If rbnWFLoadDisa.Checked Then
            If My.Settings.WaferMappingUse Then     'Set RestartRequestFlag mis check
                My.Settings.WaferMappingUse = False
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If rbnDCSlip.Checked Then
            If Not My.Settings.DCSlip Then     'Set RestartRequestFlag mis check
                My.Settings.DCSlip = True
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If rbnWorkSlip.Checked Then
            If My.Settings.DCSlip Then     'Set RestartRequestFlag mis check
                My.Settings.DCSlip = False
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If
        End If

        If rbProEna.Checked Then
            If rbSecsEna.Checked Then                          'Auto Disable if secs enable
                My.Settings.CsProtocol_Enable = False

            Else
                If Not My.Settings.CsProtocol_Enable Then     'Set RestartRequestFlag mis check
                    My.Settings.CsProtocol_Enable = True
                    RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
                End If
            End If


        End If

        If rbProDis.Checked Then
            If My.Settings.CsProtocol_Enable Then     'Set RestartRequestFlag mis check
                My.Settings.CsProtocol_Enable = False
                RestartRequestFlag = SecsSettingCloseFlag.Warning
            End If
        End If

        If (My.Settings.MDISizable Xor MySettingsMDISizable) Then      '160929 \783 Add FormSetting Screen
            My.Settings.MDISizable = MySettingsMDISizable
            RestartRequestFlag = SecsSettingCloseFlag.Warning
        End If

        If (My.Settings.MDIQRSystem Xor MySettingsMDIQRSystem) Then      '160929 \783 Add FormSetting Screen
            My.Settings.MDIQRSystem = MySettingsMDIQRSystem
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        End If

        If (My.Settings.MDITableFrmDisable Xor MySettingsMDITableFrm) Then      '160929 \783 Add FormSetting Screen
            My.Settings.MDITableFrmDisable = MySettingsMDITableFrm
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        End If

        If (My.Settings.FrmProdTableInfo Xor MySettingsFrmProdTableInfo) Then    '161222 \783 Add/Remove tabpage
            My.Settings.FrmProdTableInfo = MySettingsFrmProdTableInfo
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        End If

        If (My.Settings.FrmProdTableIDetail Xor MySettingsFrmProdTableDetail) Then    '161222 \783 Add/Remove tabpage
            My.Settings.FrmProdTableIDetail = MySettingsFrmProdTableDetail
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        End If


        RaiseEvent E_FormClosing(RestartRequestFlag)
    End Sub

    Private Sub Setting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Page1
        dgvSetting.Rows.Add(7)
        dgvSetting.Item("ColName", 0).Value = "ProcessName"
        dgvSetting.Item("ColName", 1).Value = "MCType"
        'dgvSetting.Item("ColName", 2).Value = "EquipmentIP"
        dgvSetting.Item("ColName", 2).Value = "EquipmentNo"
        dgvSetting.Item("ColName", 3).Value = "SecsConnStr"    '\783 161102 Separate secsConn and DBConn
        dgvSetting.Item("ColName", 4).Value = "UserAuthenOP"
        dgvSetting.Item("ColName", 5).Value = "UserAuthenGL"
        dgvSetting.Item("ColName", 6).Value = "DBxConnectionString"

        dgvSetting.Item("Value", 0).Value = My.Settings.ProcessName
        dgvSetting.Item("Value", 1).Value = My.Settings.MCType
        'dgvSetting.Item("Value", 2).Value = My.Settings.EquipmentIP
        dgvSetting.Item("Value", 2).Value = My.Settings.EquipmentNo
        dgvSetting.Item("Value", 3).Value = My.Settings.SecsConnStr
        dgvSetting.Item("Value", 4).Value = My.Settings.UserAuthenOP
        dgvSetting.Item("Value", 5).Value = My.Settings.UserAuthenGL
        dgvSetting.Item("Value", 6).Value = My.Settings.DBxConnectionString

        'Page2


        'Page3
        dgvTimer.Rows.Add(5)
        dgvTimer.Item("ParaName", 0).Value = "T3 Reply Timeout"
        dgvTimer.Item("ParaName", 1).Value = "T5 Connect Separation Timeout     "
        dgvTimer.Item("ParaName", 2).Value = "T6 ControlTransaction Timeout     "
        dgvTimer.Item("ParaName", 3).Value = "T7 NOT Connected Timeout"
        dgvTimer.Item("ParaName", 4).Value = "LinkTest_Interval"



        'Page4
        If My.Settings.SECS_Enable Then                 '170105 \783 \Config SECSGEM ID

            Try
                SecsID = CType(RdXml(PathXmlObj & "\SECSID.xml"), SecsGemID)
            Catch ex As Exception

            End Try



            SecsID.EditIndex = -1
            dgvCEID.Rows.Add("LotStart")
            dgvCEID.Rows.Add("LotEnd")
            dgvSVID.Rows.Add("LotNo")          '0
            dgvSVID.Rows.Add("Good Cat1")
            dgvSVID.Rows.Add("Good Cat2")
            dgvSVID.Rows.Add("NgBin1")            '3
            dgvSVID.Rows.Add("NgBin2")
            dgvSVID.Rows.Add("NgBin3")
            dgvSVID.Rows.Add("NgBin4")
            dgvSVID.Rows.Add("NgBin5")
            dgvSVID.Rows.Add("NgBin6")

        End If



        'Page6

        dgvFormSetting.Rows.Add(5)
        dgvFormSetting.Item("Title", 0).Value = "MDI Form Sizable"    '160929 \\783 Add Form setting
        dgvFormSetting.Item("Title", 1).Value = "MDI Form Table Disable"
        dgvFormSetting.Item("Title", 2).Value = "MDI Form QR System"   '161029 \783 Add QRsetting
        dgvFormSetting.Item("Title", 3).Value = "FrmProdTable Production Info. Enable"   '161222 \783 Add/Remove tabpage
        dgvFormSetting.Item("Title", 4).Value = "FrmProdTable Production Details Enable"


        Dim MDISizeAbleValue As New DataGridViewComboBoxCell
        MDISizeAbleValue.Items.Add("True")
        MDISizeAbleValue.Items.Add("False")                    'Add combo box value
        MDISizeAbleValue.Value = My.Settings.MDISizable.ToString
        dgvFormSetting.Item("Settingx", 0) = MDISizeAbleValue

    
        Dim MDITableValue As New DataGridViewComboBoxCell
        MDITableValue.Items.AddRange("True", "False")
        MDITableValue.Value = My.Settings.MDITableFrmDisable.ToString
        dgvFormSetting.Item("Settingx", 1) = MDITableValue


        Dim MDIQRSystem As New DataGridViewComboBoxCell
        MDIQRSystem.Items.AddRange("True", "False")
        MDIQRSystem.Value = My.Settings.MDIQRSystem.ToString
        dgvFormSetting.Item("Settingx", 2) = MDIQRSystem




        Dim FrmProdTableInfo As New DataGridViewComboBoxCell        '161222 \783 Add/Remove tabpage
        FrmProdTableInfo.Items.AddRange("True", "False")
        FrmProdTableInfo.Value = My.Settings.FrmProdTableInfo.ToString
        dgvFormSetting.Item("Settingx", 3) = FrmProdTableInfo


        Dim FrmProdTableDetail As New DataGridViewComboBoxCell        '161222 \783 Add/Remove tabpage
        FrmProdTableDetail.Items.AddRange("True", "False")
        FrmProdTableDetail.Value = My.Settings.FrmProdTableIDetail.ToString
        dgvFormSetting.Item("Settingx", 4) = FrmProdTableDetail



        MySettingsMDISizable = My.Settings.MDISizable
        MySettingsMDITableFrm = My.Settings.MDITableFrmDisable
        MySettingsMDIQRSystem = My.Settings.MDIQRSystem
        MySettingsFrmProdTableInfo = My.Settings.FrmProdTableInfo       '161222 \783 Add/Remove tabpage
        MySettingsFrmProdTableDetail = My.Settings.FrmProdTableIDetail



        If My.Settings.SECS_Enable Then
            rbSecsEna.Checked = True

        Else
            rbSecsDis.Checked = True
            tbSetting.TabPages.Remove(tbEventReport)       '170106 \783 Hide EventReport if nouse secsgem
        End If
        If My.Settings.TDC_Enable Then
            rbTDCEna.Checked = True
            SlipSetting.Enabled = False

        Else
            rbTDCDisa.Checked = True
            SlipSetting.Enabled = True
        End If


        If My.Settings.WaferMappingUse Then
            rbnWFLoadEna.Checked = True
        Else
            rbnWFLoadDisa.Checked = True
        End If

        If My.Settings.DCSlip Then
            rbnDCSlip.Checked = True
        Else
            rbnWorkSlip.Checked = True
        End If

        If My.Settings.CsProtocol_Enable Then
            rbProEna.Checked = True
        Else
            rbProDis.Checked = True
        End If


        cbxHostSend.Checked = My.Settings.S1F13_Setting    '160627 \783 Eq comm revise


    End Sub

  


    Private Function ConnStrTest(ByVal ConnStr As String) As String
        'Data Source=172.16.0.102;Initial Catalog=DBx;Persist Security Info=True;User ID=dbxuser
        If ConnStr = My.Settings.SecsConnStr Then
            Return "True"
            Exit Function
        End If

        Try
            Dim sqlconnection As New System.Data.SqlClient.SqlConnection(ConnStr)

            Try
                sqlconnection.Open()
                sqlconnection.Close()

            Catch ex As Exception
                Return "False :" & ex.ToString

            Finally

                sqlconnection.Dispose()

            End Try
        Catch ex As Exception
            Return "False :" & ex.ToString
        End Try
        Return "True :"
    End Function


    Private Sub tbComSetting_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles tbComSetting.Paint
        Dim myPen As Pen
        myPen = New Pen(Color.CadetBlue, 1)
        e.Graphics.DrawLine(myPen, 4, 28, Me.Width - 29, 28)
    End Sub


    Private Sub dgvSetting_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSetting.CellEndEdit
        If Not e.ColumnIndex = 1 Then
            Exit Sub
        End If
        Dim value As String = dgvSetting.Item("Value", e.RowIndex).Value.ToString
        Select Case dgvSetting.Item(0, e.RowIndex).Value.ToString
            Case "ProcessName"
                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.ProcessName
                    Exit Sub
                End If

                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsProcessName = value

            Case ("MCType")
                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.MCType
                    Exit Sub
                End If
                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsMCType = value

            Case "EquipmentIP"
                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.EquipmentIP

                    Exit Sub
                End If
                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsEquipmentIP = value

            Case "DBConnSTR"

                If value = My.Settings.SecsConnStr Then
                    Exit Sub
                End If

                Dim Ans = ConnStrTest(value)

                If Ans Like "False*" Then
                    MsgBox("----------------------------------------" & vbCrLf & _
                            " Connection string check false PLease check your setting" & vbCrLf & _
                            "----------------------------------------" & vbCrLf & _
                            Ans)
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.SecsConnStr

                    Exit Sub
                End If

                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsDBConnSTR = value


            Case "EquipmentNo"

                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.EquipmentNo
                    Exit Sub
                End If
                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsEquipmentNo = value

            Case "UserAuthenGL"
                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.UserAuthenGL
                    Exit Sub
                End If
                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsUserAuthenGL = value



            Case "UserAuthenOP"

                If value = "" Then
                    dgvSetting.Item("Value", e.RowIndex).Value = My.Settings.UserAuthenOP
                    Exit Sub
                End If
                dgvSetting.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.YellowGreen
                MySettingsUserAuthenOP = value

            Case "DBxConnectionString"                      '\783 161102 saparate dbconn and secs con
                dgvSetting.Item("Value", 6).Value = My.Settings.DBxConnectionString

        End Select


    End Sub


    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim SaveFlag As Boolean

        If MySettingsEquipmentIP <> "" And Not (My.Settings.EquipmentIP = MySettingsEquipmentIP) Then
            My.Settings.EquipmentIP = MySettingsEquipmentIP
            RestartRequestFlag = SecsSettingCloseFlag.Warning                      'Restart Msg Display
            SaveFlag = True
        End If

        If MySettingsMCType <> "" And Not (My.Settings.MCType = MySettingsMCType) Then
            My.Settings.MCType = MySettingsMCType
            RestartRequestFlag = SecsSettingCloseFlag.Warning                     'Restart Msg Display
            SaveFlag = True
        End If
        If MySettingsProcessName <> "" Then
            My.Settings.ProcessName = MySettingsProcessName
            RestartRequestFlag = SecsSettingCloseFlag.Warning                     'Restart Msg Display
            SaveFlag = True
        End If
        If MySettingsEquipmentNo <> "" And Not (My.Settings.EquipmentNo = MySettingsEquipmentNo) Then
            My.Settings.EquipmentNo = MySettingsEquipmentNo
            RestartRequestFlag = SecsSettingCloseFlag.Warning                     'Restart Msg Display
            SaveFlag = True
        End If

        If MySettingsDBConnSTR <> "" Then
            My.Settings.SecsConnStr = MySettingsDBConnSTR
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF                      'Restart Msg Display
            SaveFlag = True
        End If

        If MySettingsUserAuthenOP <> "" And Not (My.Settings.UserAuthenOP = MySettingsUserAuthenOP) Then
            My.Settings.UserAuthenOP = MySettingsUserAuthenOP
            RestartRequestFlag = SecsSettingCloseFlag.Warning                     'Restart Msg Display
            SaveFlag = True
        End If
        If MySettingsUserAuthenGL <> "" And Not (My.Settings.UserAuthenGL = MySettingsUserAuthenGL) Then
            My.Settings.UserAuthenGL = MySettingsUserAuthenGL
            RestartRequestFlag = SecsSettingCloseFlag.Warning                     'Restart Msg Display
            SaveFlag = True
        End If


        MySettingsEquipmentIP = ""
        MySettingsMCType = ""
        MySettingsProcessName = ""
        MySettingsDBConnSTR = ""
        MySettingsEquipmentNo = ""
        MySettingsUserAuthenGL = ""
        MySettingsUserAuthenOP = ""

        If SaveFlag Then
            MsgBox("Save Success")
        Else
            MsgBox("Save is not process")
        End If
        For i As Integer = 0 To dgvSetting.Rows.Count - 1
            dgvSetting.Rows(i).Cells(1).Style.ForeColor = Color.Black
        Next


    End Sub

    'Tab Select
    Private Sub tbSetting_Selected(sender As Object, e As System.Windows.Forms.TabControlEventArgs) Handles tbSetting.Selected

        Select Case e.TabPage.Name

            Case "tbComSetting"
                dgvSetting.Item("Value", 0).Value = My.Settings.ProcessName
                dgvSetting.Item("Value", 1).Value = My.Settings.MCType
                dgvSetting.Item("Value", 2).Value = My.Settings.EquipmentNo
                dgvSetting.Item("Value", 3).Value = My.Settings.SecsConnStr
                dgvSetting.Item("Value", 4).Value = My.Settings.UserAuthenOP
                dgvSetting.Item("Value", 5).Value = My.Settings.UserAuthenGL
                dgvSetting.Item("Value", 6).Value = My.Settings.DBxConnectionString

            Case "tbSecsGem"
                tbxEqiupIP.Text = My.Settings.EquipmentIP
                tbxEqiupPort.Text = CStr(My.Settings.SECS_PortNumber)
                lblDevicceID.Text = CStr(My.Settings.GEM_DeviceID)


                dgvTimer.Item("ParaValue", 0).Value = My.Settings.GEM_T3_Interval
                dgvTimer.Item("ParaValue", 1).Value = My.Settings.GEM_T5_Interval
                dgvTimer.Item("ParaValue", 2).Value = My.Settings.GEM_T6_Interval
                dgvTimer.Item("ParaValue", 3).Value = My.Settings.GEM_T7_Interval
                dgvTimer.Item("ParaValue", 4).Value = My.Settings.GEM_LinkTest_Interval

            Case "tbTDC"
            Case "tbCsPro"
                tbxCsIP.Text = My.Settings.EquipmentIP
                tbxCsPort.Text = CStr(My.Settings.CsProtocolPort)

            Case "tbFormSet"

            Case "tbEventReport"   '170105 \783 \Config SECSGEM ID

               
                cmsCeidValue.Items.Clear()
                Dim Keys As String
                cmsCeidValue.Items.Add("None,0").Name = "None"
                For i = 0 To LinkTable.Rows.Count - 1
                    Keys = LinkTable.Rows(i)(4).ToString & "," & LinkTable.Rows(i)(1).ToString
                    cmsCeidValue.Items.Add(Keys).Name = Keys
                    If cmsCeidValue.Items.Contains(cmsCeidValue.Items(Keys)) Then
                        Continue For
                    End If

                Next

                cmsSvidValue.Items.Clear()
                cmsSvidValue.Items.Add("None,0").Name = "None"
                For i = 1 To DefReport.Rows.Count - 1
                    Keys = DefReport.Rows(i)(4).ToString & "," & DefReport.Rows(i)(2).ToString
                    If cmsSvidValue.Items.Contains(cmsSvidValue.Items(Keys)) Then
                        Continue For
                    End If
                    cmsSvidValue.Items.Add(Keys).Name = Keys

                Next

                dgvCEID.Rows(0).Cells(1).Value = SecsID.LotStartECID
                dgvCEID.Rows(1).Cells(1).Value = SecsID.LotEndECID
                dgvSVID.Rows(0).Cells(1).Value = SecsID.LotIDSVID
                dgvSVID.Rows(1).Cells(1).Value = SecsID.GoodCat1SVID
                dgvSVID.Rows(2).Cells(1).Value = SecsID.GoodCat2SVID
                dgvSVID.Rows(3).Cells(1).Value = SecsID.NgBin1SVID
                dgvSVID.Rows(4).Cells(1).Value = SecsID.NgBin2SVID
                dgvSVID.Rows(5).Cells(1).Value = SecsID.NgBin3SVID
                dgvSVID.Rows(6).Cells(1).Value = SecsID.NgBin4SVID
                dgvSVID.Rows(7).Cells(1).Value = SecsID.NgBin5SVID
                dgvSVID.Rows(8).Cells(1).Value = SecsID.NgBin6SVID


                If My.Settings.EventReportEnable Then
                    EnableToolStripMenuItem.Text = "Enable"
                Else
                    EnableToolStripMenuItem.Text = "Disable"
                End If


        End Select

    End Sub

    Private Sub btnEquipIPChg_Click(sender As System.Object, e As System.EventArgs) Handles btnEquipIPChg.Click
        Dim IPFormat As Integer = tbxEqiupIP.Text.Split(CChar(".")).Length
        If tbxEqiupIP.Text = "" Or IPFormat <> 4 Then
            tbxEqiupIP.Text = My.Settings.EquipmentIP
            Exit Sub
        End If
        If tbxEqiupIP.Text = My.Settings.EquipmentIP Then
            tbxEqiupIP.Text = My.Settings.EquipmentIP
            Exit Sub
        End If
        RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        My.Settings.EquipmentIP = tbxEqiupIP.Text
        tbxEqiupIP.ForeColor = Color.YellowGreen
    End Sub
    Private Sub btnCsIPChg_Click(sender As System.Object, e As System.EventArgs) Handles btnCsIPChg.Click
        Dim IPFormat As Integer = tbxCsIP.Text.Split(CChar(".")).Length
        If tbxCsIP.Text = "" Or IPFormat <> 4 Then
            tbxCsIP.Text = My.Settings.EquipmentIP
            Exit Sub
        End If
        If tbxCsIP.Text = My.Settings.EquipmentIP Then
            tbxCsIP.Text = My.Settings.EquipmentIP
            Exit Sub
        End If
        RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
        My.Settings.EquipmentIP = tbxCsIP.Text
        tbxCsIP.ForeColor = Color.YellowGreen
    End Sub



    Private Sub btnEquipPortChg_Click(sender As System.Object, e As System.EventArgs) Handles btnEquipPortChg.Click
        If CInt(tbxEqiupPort.Text) = My.Settings.SECS_PortNumber Then
            Exit Sub
        End If
        If IsNumeric(tbxEqiupPort.Text) Then
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            My.Settings.SECS_PortNumber = CInt(tbxEqiupPort.Text)
            tbxEqiupPort.ForeColor = Color.YellowGreen
        End If
    End Sub

    Private Sub btnCsPortChg_Click(sender As System.Object, e As System.EventArgs) Handles btnCsPortChg.Click
        If CInt(tbxCsPort.Text) = My.Settings.CsProtocolPort Then
            Exit Sub
        End If
        If IsNumeric(tbxCsPort.Text) Then
            RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            My.Settings.CsProtocolPort = CInt(tbxCsPort.Text)
            tbxCsPort.ForeColor = Color.YellowGreen
        End If
    End Sub

    Private Sub btnTimeoutChg_Click(sender As System.Object, e As System.EventArgs) Handles btnTimeoutChg.Click
        Try


            If dgvTimer.Item("ParaValue", 0).Value IsNot Nothing And Not CInt(dgvTimer.Item("ParaValue", 0).Value) = My.Settings.GEM_T3_Interval Then
                My.Settings.GEM_T3_Interval = CInt(dgvTimer.Item("ParaValue", 0).Value)
                dgvTimer.Item("ParaValue", 0).Style.ForeColor = Color.YellowGreen
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF

            End If

            If dgvTimer.Item("ParaValue", 1).Value IsNot Nothing And Not (CInt(dgvTimer.Item("ParaValue", 1).Value) = My.Settings.GEM_T5_Interval) Then
                My.Settings.GEM_T5_Interval = CInt(dgvTimer.Item("ParaValue", 1).Value)
                dgvTimer.Item("ParaValue", 1).Style.ForeColor = Color.YellowGreen
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If

            If dgvTimer.Item("ParaValue", 2).Value IsNot Nothing And Not CInt(dgvTimer.Item("ParaValue", 2).Value) = My.Settings.GEM_T6_Interval Then
                My.Settings.GEM_T6_Interval = CInt(dgvTimer.Item("ParaValue", 2).Value)
                dgvTimer.Item("ParaValue", 2).Style.ForeColor = Color.YellowGreen
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If

            If dgvTimer.Item("ParaValue", 3).Value IsNot Nothing And Not CInt(dgvTimer.Item("ParaValue", 3).Value) = My.Settings.GEM_T7_Interval Then
                My.Settings.GEM_T7_Interval = CInt(dgvTimer.Item("ParaValue", 3).Value)
                dgvTimer.Item("ParaValue", 3).Style.ForeColor = Color.YellowGreen
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If

            If dgvTimer.Item("ParaValue", 4).Value IsNot Nothing And Not CInt(dgvTimer.Item("ParaValue", 4).Value) = My.Settings.GEM_LinkTest_Interval Then
                My.Settings.GEM_LinkTest_Interval = CInt(dgvTimer.Item("ParaValue", 4).Value)
                dgvTimer.Item("ParaValue", 4).Style.ForeColor = Color.YellowGreen
                RestartRequestFlag = SecsSettingCloseFlag.ForceOFF
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub tbSecsGem_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles tbSecsGem.Paint
        Dim myPen As Pen

        myPen = New Pen(Color.Gray, 1)
        e.Graphics.DrawLine(myPen, CInt(tbSetting.Width / 2), 0, CInt(tbSetting.Width / 2), tbSetting.Height)
    End Sub


    Private Sub AddUserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddUserToolStripMenuItem.Click
        If Not OprData.UserLevel = CommonData.Level.ADMIN Then
            MsgBox("The only admin level is allowed.")
            Exit Sub
        End If
        Dim AddUser As New LoginUser
        AddUser.ShowDialog()
    End Sub



    Private Sub rbProEna_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbProEna.CheckedChanged
        If rbProDis.Checked Then     'exit from Double Display 
            Exit Sub
        End If
        If rbSecsEna.Checked Then
            MsgBox("Please Disable Secs before setting")
            rbProDis.Checked = True
            Exit Sub
        End If
    End Sub

    Private Sub rbSecsEna_Click(sender As Object, e As System.EventArgs) Handles rbSecsEna.Click
        If rbProDis.Checked Then     'exit from Double Display 
            Exit Sub
        End If
        If rbSecsEna.Checked Then
            MsgBox("Custom protocol will be disable")
            rbProDis.Checked = True
            Exit Sub
        End If
    End Sub

    Private Sub cbxHostSend_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbxHostSend.CheckedChanged
        If My.Settings.S1F13_Setting Xor cbxHostSend.Checked Then
            My.Settings.S1F13_Setting = cbxHostSend.Checked      '160627 \783 Eq comm revise
        End If


    End Sub





    Private Sub dgvFormSetting_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFormSetting.CellEndEdit

        'Dim value As String = dgvFormSetting.Item("Settingx", e.RowIndex).Value.ToString
        'Select Case dgvFormSetting.Item(0, e.RowIndex).Value.ToString
        '    Case "MDI Form Sizable"
        '        MySettingsMDISizable = CBool(value)
        '        If MySettingsMDISizable <> My.Settings.MDISizable Then
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
        '        Else
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.Black
        '        End If

        '    Case "MDI Form Table Disable"
        '        MySettingsMDITableFrm = CBool(value)
        '        If MySettingsMDITableFrm <> My.Settings.MDITableFrmDisable Then
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
        '        Else
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.Black
        '        End If

        '    Case "MDI Form QR System"                                    '161029 \783 Add QRSystem
        '        MySettingsMDIQRSystem = CBool(value)
        '        If MySettingsMDIQRSystem <> My.Settings.MDIQRSystem Then
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
        '        Else
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.Black
        '        End If
        '    Case "FrmProdTable Production Info. Enable"                   '161222 \783 Add/Remove tabpage
        '        MySettingsFrmProdTableInfo = CBool(value)
        '        If MySettingsFrmProdTableInfo <> My.Settings.FrmProdTableInfo Then
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
        '        Else
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.Black
        '        End If

        '    Case "FrmProdTable Production Details Enable"             '161222 \783 Add/Remove tabpage
        '        MySettingsFrmProdTableDetail = CBool(value)
        '        If MySettingsFrmProdTableDetail <> My.Settings.FrmProdTableIDetail Then
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
        '        Else
        '            dgvFormSetting.Rows(e.RowIndex).Cells(0).Style.ForeColor = Color.Black
        '        End If

        'End Select


    End Sub
    '161229 \783 Revise function
    Private Sub dgvFormSetting_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvFormSetting.EditingControlShowing
        If dgvFormSetting.CurrentCell.ColumnIndex = 1 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                ' Remove an existing event-handler, if present, to avoid 
                ' adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)

                ' Add the event handler. 
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
            End If
        End If
    End Sub

    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        Dim value As String = combo.Text
        Select Case dgvFormSetting.Item(0, dgvFormSetting.CurrentCell.RowIndex).Value.ToString
            Case "MDI Form Sizable"
                MySettingsMDISizable = CBool(value)
                If MySettingsMDISizable <> My.Settings.MDISizable Then
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
                Else
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.Black
                End If

            Case "MDI Form Table Disable"
                MySettingsMDITableFrm = CBool(value)
                If MySettingsMDITableFrm <> My.Settings.MDITableFrmDisable Then
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
                Else
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.Black
                End If

            Case "MDI Form QR System"                                    '161029 \783 Add QRSystem
                MySettingsMDIQRSystem = CBool(value)
                If MySettingsMDIQRSystem <> My.Settings.MDIQRSystem Then
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
                Else
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.Black
                End If
            Case "FrmProdTable Production Info. Enable"                   '161222 \783 Add/Remove tabpage
                MySettingsFrmProdTableInfo = CBool(value)
                If MySettingsFrmProdTableInfo <> My.Settings.FrmProdTableInfo Then
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
                Else
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.Black
                End If

            Case "FrmProdTable Production Details Enable"             '161222 \783 Add/Remove tabpage
                MySettingsFrmProdTableDetail = CBool(value)
                If MySettingsFrmProdTableDetail <> My.Settings.FrmProdTableIDetail Then
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.YellowGreen
                Else
                    dgvFormSetting.Rows(dgvFormSetting.CurrentCell.RowIndex).Cells(0).Style.ForeColor = Color.Black
                End If

        End Select




        'Console.WriteLine("Row: {0}, Value: {1}", dgvFormSetting.CurrentCell.RowIndex, combo.SelectedItem)
aaa:
    End Sub

    Private Sub dgvCEID_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCEID.CellClick  '170105 \783 \Config SECSGEM ID
        SecsID.EditIndex = -1      'PositionClear
        If e.ColumnIndex = 1 Then

            cmsCeidValue.Show(MousePosition)
            SecsID.EditIndex = e.RowIndex
        End If

    End Sub

    '170105 \783 \Config SECSGEM ID ----------------------------------------------------------------

    Private Sub cmsCeidValue_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmsCeidValue.ItemClicked
        If SecsID.EditIndex = -1 Then
            Exit Sub
        End If

        dgvCEID.Rows(SecsID.EditIndex).Cells(1).Value = e.ClickedItem.Text.Split(CChar(","))(1)
        SecsID.EditIndex = -1


    End Sub

    Private Sub dgvSVID_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSVID.CellClick
        SecsID.EditIndex = -1      'PositionClear
        If e.ColumnIndex = 1 Then
            cmsSvidValue.Enabled = True
            cmsSvidValue.Show(MousePosition)
            SecsID.EditIndex = e.RowIndex
        End If
    End Sub

    Private Sub cmsSvidValue_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmsSvidValue.ItemClicked
        If SecsID.EditIndex = -1 Then
            Exit Sub
        End If

        dgvSVID.Rows(SecsID.EditIndex).Cells(1).Value = e.ClickedItem.Text.Split(CChar(","))(1)
        SecsID.EditIndex = -1
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try

            SecsID.LotStartECID = CUInt(dgvCEID.Rows(0).Cells(1).Value)
            SecsID.LotEndECID = CUInt(dgvCEID.Rows(1).Cells(1).Value)
            SecsID.LotIDSVID = CUInt(dgvSVID.Rows(0).Cells(1).Value)
            SecsID.GoodCat1SVID = CUInt(dgvSVID.Rows(1).Cells(1).Value)
            SecsID.GoodCat2SVID = CUInt(dgvSVID.Rows(2).Cells(1).Value)
            SecsID.NgBin1SVID = CUInt(dgvSVID.Rows(3).Cells(1).Value)
            SecsID.NgBin2SVID = CUInt(dgvSVID.Rows(4).Cells(1).Value)
            SecsID.NgBin3SVID = CUInt(dgvSVID.Rows(5).Cells(1).Value)
            SecsID.NgBin4SVID = CUInt(dgvSVID.Rows(6).Cells(1).Value)
            SecsID.NgBin5SVID = CUInt(dgvSVID.Rows(7).Cells(1).Value)
            SecsID.NgBin6SVID = CUInt(dgvSVID.Rows(8).Cells(1).Value)

            WrXml(PathXmlObj & "\SECSID.xml", SecsID)
            RaiseEvent E_SlInfo("SECS ID Save Success")

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "Save SecsID Err")
        End Try


    End Sub
   
  
    Private Sub EnableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnableToolStripMenuItem.Click
        If My.Settings.EventReportEnable Then

            My.Settings.EventReportEnable = False
            EnableToolStripMenuItem.Text = "Disable"

        Else
            My.Settings.EventReportEnable = True
            EnableToolStripMenuItem.Text = "Enable"

        End If
    End Sub

    Private Sub rbTDCEna_CheckedChanged(sender As Object, e As EventArgs) Handles rbTDCEna.CheckedChanged, rbTDCDisa.CheckedChanged
        Dim val As RadioButton = CType(sender, RadioButton)
        If val.Name = "rbTDCEna" Then
            My.Settings.DCSlip = False
            SlipSetting.Enabled = False
            rbnWorkSlip.Checked = True
        Else
            SlipSetting.Enabled = True
        End If

    End Sub


    '170105 \783 \Config SECSGEM ID ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




End Class