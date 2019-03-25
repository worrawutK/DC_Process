Imports System.Threading
Imports System.ComponentModel
Imports System.IO
Imports Rohm.Apcs.Tdc
Imports XtraLibrary.SecsGem
Imports MapConverterForCanon
Imports yezpedLibrary.WaferSlip
Imports Rohm.Ems
'Imports System.Runtime.InteropServices
'Imports System.Text
'Imports System.Xml.Serialization
'Imports System.Xml
'Imports System.Runtime.Serialization
'Imports nLibrary
'Imports System.Runtime.Serialization.Formatters.Soap
'Imports System.Net
'Imports iLibrary


Public Class ProcessForm
    Public m_EmsClient As EmsServiceClient = New EmsServiceClient("DC", "http://webserv.thematrix.net:7777/EmsService")
    Dim rs As New Resizer
    Event MessageFrmMain(Txt As String)
    ' Dim WithEvents ResizeMDI As MDIParent1
#Region "Commomn Define"

    '  Dim BG_TB As New DBxDataSet.BGDataDataTable
    'Dim BG_AP As New DBxDataSetTableAdapters.BGDataTableAdapter
    Event E_MakeAlarmCellCon(ByVal AlarmMessage As String, ByVal Location As String, ByVal Status As String, ByVal AlarmID As String)
    Event E_Update_dgvProductionInfo1(ByVal _CarrierID As String, ByVal LotID As String, ByVal Package As String, ByVal Device As String, ByVal REMARK As String, ByVal StartTime As String)
    Event E_Update_dgvProductionInfoEnd(ByVal _UnloadCarrierID As String, ByVal LotNo As String, ByVal Count As String, ByVal Remark As String)
    Event E_Update_dgvProductionDetail(ByVal itemID As String, ByVal type As String, ByVal action As String, ByVal location As String)
    Event E_AlarmTable(ByVal AlarmALCD As Boolean, ByVal AlarmALID As String, ByVal AlarmALTX As String, ByVal AlarmType As String)
    Event E_FormFill()
    Event E_ProductionTableCall(ByVal TabPage As String)
    Event E_ConsoleShow()
    Event E_CsProtocol_SendMsg(ByVal msg As String)
    'Event E_QRReadSuccess()
    Event E_SlInfo(ByVal msg As String)
    Event E_EqConnect()
    Event E_QRReadOPIDSuccess()
    Event E_LRCheck(ByVal EqNo As String, ByVal LotNo As String)
    Event E_LSCheck(ByVal EQNo As String, ByVal LotNo As String, ByVal StartTime As Date, ByVal OPID As String, ByVal StartMode As RunModeType)
    Event E_LECheck(ByVal EQNo As String, ByVal LotNo As String, ByVal EndTime As Date, ByVal GoodPcs As Integer, ByVal NgPcs As Integer, ByVal OPID As String, ByVal EndMode As EndModeType)
    Event E_HostSend(ByVal msg As SecsMessageBase)
    Event E_TransactionDataSave(ByVal QrData As String)
    Event E_HostReply(ByVal Pri As SecsMessageBase, ByVal Secn As SecsMessageBase)
    Event E_HelperCall(ByVal Tabpage As String)
    Event AlramShow(ByVal AlarmALCD As Boolean, ByVal AlarmALID As String, ByVal AlarmALTX As String, ByVal AlarmType As String, AddAlarm As Boolean)

    'Explain Event  ----------------------------------------------------------------------------------------------------------------------

    'Event E_MakeAlarmCellCon                   : Display Alarm of processing(Code) in table
    'Event E_Update_dgvProductionInfo1          : Production start carrier information table 
    'Event E_Update_dgvProductionInfoEnd        : Production end carrier information table
    'Event E_Update_dgvProductionDetail         : Production detail table        
    'Event E_AlarmTable                         : Secs/Gem or Equipment Alarm table
    'Event E_FormFill                           : Maximize Production form
    'Event E_ProductionTableCall                : Table form call
    'Event E_ConsoleShow                        : Communication log console (Use in Secs/Gem Only)                          :
    'Event E_CsProtocol_SendMsg                 : Custom protocol send
    'Event E_QRReadSuccess                      : QR read data send (Autherize check), must set parameter 'OprData.QrData, OprData.OPID' first
    'Event E_SlInfo                             : Show message at State label in MDIParent form
    'Event E_EqConnect                          : Connect to equipment
    'Event E_QRReadOPIDSuccess                  : OPID QR data
    'Event E_LRCheck                            : LR Check TDC Auto reply to Sub LR_Reply()
    'Event E_LSCheck                            : LS Check TDC Auto reply to Sub LS_Reply()
    'Event E_LECheck                            : LE Check TDC Auto reply to Sub LE_Reply()
    'Event E_HostSend                           : Secs/Gem protcol send
    'Event E_TransactionDataSave                : Save QR to Transaction data

    '----------------------------------------------------------------------------------------------------------------------------------------



    'Dim PathXmlObj As String = "D:\RohmSystem\rCellcon\" & My.Settings.MCType
    'Dim BackUpObj As String = "D:\RohmSystem\rCellcon\" & My.Settings.MCType & "\BackUpObj"
    'Dim BackUpObjOld As String = "D:\RohmSystem\rCellcon\" & My.Settings.MCType & "\BackUpObjOld"


    Private Delegate Sub S6F11Delegate(ByVal Obj As S6F11)
    Private Delegate Sub S2F42Delegate(ByVal CMD As String, ByVal Reply As S2F42)
    Private Delegate Sub SxFxxDelegate(ByVal e As SecondarySecsMessageEventArgs)
    Private Delegate Sub SxFxxPriDelegate(ByVal state As Object)

    Dim m_Equipment As New Equipment
    Dim WaferMapData As New List(Of String)

    Dim AlarmHashT As New Hashtable
    Structure AlarmKeys
        Dim AlarmID As Integer
        Dim AlarmMessage As String
        Dim AlarmNo As Integer
        Dim AlarmSet As Boolean
    End Structure

#End Region


#Region "Form main zone"


    Private Sub ProcessForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OprData.FRMProductAlive = False

    End Sub

    'Private Sub ResizeFrm() Handles ResizeMDI.rs
    '    rs.ResizeAllControls(Me)
    'End Sub
    Private Sub ProcessForm_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim myPen As Pen
        'myPen = New Pen(Color.RoyalBlue, 17)
        'e.Graphics.DrawLine(myPen, 0, 10, Me.Width, 10)
        'myPen = New Pen(Color.MidnightBlue, 1)
        'e.Graphics.DrawLine(myPen, 0, 19, Me.Width, 19)
        'myPen = New Pen(Color.PowderBlue, 25)
        'e.Graphics.DrawLine(myPen, 0, 110, Me.Width, 110)
        'myPen = New Pen(Color.CadetBlue, 1)
        'e.Graphics.DrawLine(myPen, 1, 122, Me.Width, 122)

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams   'Disable Close(x) Button
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    ' Command For Clear all data table

    Private Sub FrmTableDataClear()                 '160712 \783 PrdTable Clear
        RaiseEvent E_AlarmTable(False, _PrdTableClear, "", "")
        RaiseEvent E_MakeAlarmCellCon(_PrdTableClear, "", "", "")
        RaiseEvent E_Update_dgvProductionDetail(_PrdTableClear, "", "", "")
        RaiseEvent E_Update_dgvProductionInfo1(_PrdTableClear, "", "", "", "", "")
    End Sub



    Private Sub AlarmTable(ByVal AlarmALCD As Boolean, ByVal AlarmALID As String, ByVal AlarmALTX As String, Optional ByVal AlarmType As String = "0")
        RaiseEvent E_AlarmTable(AlarmALCD, AlarmALID, AlarmALTX, AlarmType)
    End Sub
    Private Sub MakeAlarmCellCon(ByVal AlarmMessage As String, Optional ByVal Location As String = "", Optional ByVal Status As String = "", Optional ByVal AlarmID As String = "")
        RaiseEvent E_MakeAlarmCellCon(AlarmMessage, Location, Status, AlarmID)
    End Sub
    Private Sub Update_dgvProductionInfo1(ByVal _CarrierID As String, ByVal LotID As String, ByVal Package As String, ByVal Device As String, Optional ByVal Remark As String = "", Optional ByVal StartTime As String = "")
        RaiseEvent E_Update_dgvProductionInfo1(_CarrierID, LotID, Package, Device, Remark, StartTime)
    End Sub
    Private Sub Update_dgvProductionDetail(ByVal itemID As String, ByVal type As String, ByVal action As String, Optional ByVal location As String = "")
        RaiseEvent E_Update_dgvProductionDetail(itemID, type, action, location)
    End Sub
    Private Sub Update_dgvProductionInfoEnd(ByVal _UnloadCarrierID As String, ByVal LotNo As String, Optional ByVal Count As String = "", Optional ByVal Remark As String = "")

        RaiseEvent E_Update_dgvProductionInfoEnd(_UnloadCarrierID, LotNo, Count, Remark)
    End Sub
    Private Sub EqConnectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EqConnectToolStripMenuItem.Click

        If Not (My.Settings.CsProtocol_Enable Or My.Settings.SECS_Enable) Then    'Enable Check
            Exit Sub
        End If
        If Not (OprData.CSConnect = "Disconnect") Then  ''Or CommuniationState Like "NOT COMMUNICATING") Then  '160627 EqConnect revise
            Exit Sub
        End If

        RaiseEvent E_EqConnect()

    End Sub

    'Private Sub pbxLogo_Click(sender As System.Object, e As System.EventArgs) Handles pbxLogo.Click
    '    RaiseEvent E_FormFill()
    'End Sub
    Private Sub QRMenuToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QRMenuToolStripMenuItem.Click


        'If Not QRWorkingSlipInputInitailCheck(True) Then      'Check Before Input
        '    Exit Sub
        'End If

        'Dim TypeOfLanguage = New System.Globalization.CultureInfo("en")                        'Change keyboard to Eng keyboard
        'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)

        ' If OprData.QrReadSystemOn Then

        'lbOPID.Text = ""
        'lbInputTotal.Text = ""
        RaiseEvent E_HelperCall("tbOther")   '170224 \783 Helper form addition

        'Else
        '    RaiseEvent E_SlInfo("QrReadSystemOn Config is OFF ")
        '  End If



    End Sub


    Private Sub ProcessForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '=== Query 
        'EMS
        Try
            '  Dim MCNo As String = My.Settings.EquipmentNo.Split(CType("-", Char()))(1) & "-" & My.Settings.EquipmentNo.Split(CType("-", Char()))(2)
            Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(My.Settings.EquipmentNo, My.Settings.HeaderProcess & My.Settings.EquipmentNo, My.Settings.ProcessName, My.Settings.MCType, "", 0, 0, 0, 0, 0)
            m_EmsClient.Register(reg)


        Catch ex As Exception
            SaveLog(Message.Cellcon, "EmsMachineRegisterInfo :" & ex.ToString)
        End Try

        If My.Settings.DCSlip = True Then  'DC Slip and Work Slip tabcontrol
            TabControl1.TabPages.Remove(tapWorkSlip)
            If TabControl1.TabPages(0) Is DBNull.Value Then
                TabControl1.TabPages.Add(tapDCSlip)
            End If
        Else
            TabControl1.TabPages.Remove(tapDCSlip)
            If TabControl1.TabPages(0) Is DBNull.Value Then
                TabControl1.TabPages.Add(tapWorkSlip)
            End If
        End If



        Dim TypeOfLanguage = New System.Globalization.CultureInfo("en")                        'Change keyboard to Eng keyboard
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        lbProcess.Text = "PROCESS : " & My.Settings.ProcessName
        OprData.FRMProductAlive = True
        If Not My.Settings.TDC_Enable Then
            lbSpMode.Text = "!!! TDC DISABLE !!!"
        End If

        Dim permission As New AuthenticationUser.AuthenUser
        If OprData.CSConnect = "Disconnect" And My.Settings.CsProtocol_Enable Then
            Me.BackColor = Color.Red
        End If
        If Not CommuniationState Like "COMMUNICATING*" And My.Settings.SECS_Enable Then
            Me.BackColor = Color.Red
        End If
        lbMcNo.Text = My.Settings.EquipmentNo
        lbDCMCNo.Text = My.Settings.EquipmentNo
        If My.Settings.SECS_Enable Then
            If m_DefinedReportDic.Count = 0 Then
                MsgBox("Process Deny : Define Report 'm_DefinedReportDic' is empty' Please Download Report")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))   'Close form in the form load event
            End If

        End If

        If Not CommuniationState Like "COMMUNICATING*" And My.Settings.SECS_Enable Then
            Me.BackColor = Color.Red
            S1F3GetCassette()
        End If
        Try
            If My.Settings.UserAuthenOP = "NOUSE" Then
                'Exit Sub
            Else
                If permission.CheckMachineAutomotive(My.Settings.ProcessName, My.Settings.EquipmentNo) Then
                    pbxAutoM.Visible = True
                End If
            End If

            'LoadAlarmMessage
            If Not My.Computer.Network.IsAvailable Then                'unplug check
                MsgBox("PC Nework point unplug")
                GoTo DBxServerEndLoop
            End If
            If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
                MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
                GoTo DBxServerEndLoop
            End If
            pbxLogo.BringToFront()                  'Display revise 160627 \783 


DBxServerEndLoop:

        Catch ex As Exception    'Net Work Error

        End Try
        rs.FindAllControls(Me)
        '   XXX()
        BGDataTableAdapter.Fill(DBxDataSet.BGData, My.Settings.HeaderProcess & My.Settings.EquipmentNo)
    End Sub

    Private Sub ProductTableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductTableToolStripMenuItem.Click
        RaiseEvent E_ProductionTableCall("tbAlarmCellCon")
    End Sub

    Private Sub SecsConsoleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SecsConsoleToolStripMenuItem.Click
        RaiseEvent E_ConsoleShow()
    End Sub


    Private Sub BMRequestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BMRequestToolStripMenuItem.Click
        Dim tmpStr As String

        tmpStr = "MCNo=" & My.Settings.EquipmentNo
        tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
        If lbStartTime.Text <> "" Then 'AndAlso lbEndTime.Text = "" Then
            tmpStr = tmpStr & "&MCStatus=Running"
        Else
            tmpStr = tmpStr & "&MCStatus=Stop"
        End If

        tmpStr = tmpStr & "&AlarmNo="
        tmpStr = tmpStr & "&AlarmName="

        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
        'Process.Start("C:\WINDOWS\system32\osk.exe")
    End Sub

    Private Sub PMRepairToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PMRepairToolStripMenuItem.Click
        Dim MCNo As String = My.Settings.EquipmentNo
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)
        'Process.Start("C:\WINDOWS\system32\osk.exe")
    End Sub


    Private Sub ByAutoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ByAutoToolStripMenuItem.Click  '161019 \783
        Try
            Dim requestUrl As String             'Call Andon by pass parameter 161029 \783
            requestUrl = String.Format("http://webserv.thematrix.net/andontmn/Client/Default.aspx?p={0}&mc={1}&lot={2}&pkg={3}&dv={4}&line={5}&op={6}",
                                        My.Settings.ProcessName, lbMcNo.Text, lbLotNo.Text, lbPackage.Text, lbDevice.Text, "", lbOPID.Text)
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe " & requestUrl, AppWinStyle.NormalFocus)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ByManualToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ByManualToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C     'Maual input
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub APCSStaffToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles APCSStaffToolStripMenuItem.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ApcsStaff", AppWinStyle.NormalFocus)

    End Sub

    Private Sub WorkRecordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WorkRecordToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    ''Pass Result QR Read of FrmTable
    Public Sub QrSlipOK()
        If My.Settings.DCSlip Then
            Dim DCSlipQR As New WaferSlip
            DCSlipQR.FullCode = OprData.QrData
            lbDCDevice.Text = DCSlipQR.AssyLot
            '  lbDCOrderNo.Text = DCSlipQR.OrderNo
            ' lbDCCode.Text = DCSlipQR.DCCode
            'lbDCPlasma.Text = DCSlipQR.Plasma
            'lbDCCodeNo.Text = DCSlipQR.CodeNo
            lbDCWFLotNo.Text = DCSlipQR.WFLotNo
            lbDCWaferNo.Text = DCSlipQR.WaferNo
            'lbDCWFNo1.Text = DCSlipQR.WFNo1
            'lbDCWFNo2.Text = DCSlipQR.WFNo2
            'lbDCWFNo3.Text = DCSlipQR.WFNo3
            'lbDCWFNo4.Text = DCSlipQR.WFNo4
            'lbDCWFNo5.Text = DCSlipQR.WFNo5
            'lbDCWFNo6.Text = DCSlipQR.WFNo6
            'lbDCWFNo7.Text = DCSlipQR.WFNo7
            'lbDCWFNo8.Text = DCSlipQR.WFNo8
            'lbDCWFNo9.Text = DCSlipQR.WFNo9
            'lbDCWFNo10.Text = DCSlipQR.WFNo10
            'lbDCWFNo11.Text = DCSlipQR.WFNo11
            'lbDCWFNo12.Text = DCSlipQR.WFNo12
            'lbDCWFNo13.Text = DCSlipQR.WFNo13
            'lbDCWFNo14.Text = DCSlipQR.WFNo14
            'lbDCWFNo15.Text = DCSlipQR.WFNo15
            'lbDCWFNo16.Text = DCSlipQR.WFNo16
            'lbDCWFNo17.Text = DCSlipQR.WFNo17
            'lbDCWFNo18.Text = DCSlipQR.WFNo18
            'lbDCWFNo19.Text = DCSlipQR.WFNo19
            'lbDCWFNo20.Text = DCSlipQR.WFNo20
            'lbDCWFNo21.Text = DCSlipQR.WFNo21
            'lbDCWFNo22.Text = DCSlipQR.WFNo22
            'lbDCWFNo23.Text = DCSlipQR.WFNo23
            'lbDCWFNo24.Text = DCSlipQR.WFNo24
            'lbDCWFNo25.Text = DCSlipQR.WFNo25

            'lbDCWAQtyNo1.Text = DCSlipQR.WAQtyNo1
            'lbDCWAQtyNo2.Text = DCSlipQR.WAQtyNo2
            'lbDCWAQtyNo3.Text = DCSlipQR.WAQtyNo3
            'lbDCWAQtyNo4.Text = DCSlipQR.WAQtyNo4
            'lbDCWAQtyNo5.Text = DCSlipQR.WAQtyNo5
            'lbDCWAQtyNo6.Text = DCSlipQR.WAQtyNo6
            'lbDCWAQtyNo7.Text = DCSlipQR.WAQtyNo7
            'lbDCWAQtyNo8.Text = DCSlipQR.WAQtyNo8
            'lbDCWAQtyNo9.Text = DCSlipQR.WAQtyNo9
            'lbDCWAQtyNo10.Text = DCSlipQR.WAQtyNo10
            'lbDCWAQtyNo11.Text = DCSlipQR.WAQtyNo11
            'lbDCWAQtyNo12.Text = DCSlipQR.WAQtyNo12
            'lbDCWAQtyNo13.Text = DCSlipQR.WAQtyNo13
            'lbDCWAQtyNo14.Text = DCSlipQR.WAQtyNo14
            'lbDCWAQtyNo15.Text = DCSlipQR.WAQtyNo15
            'lbDCWAQtyNo16.Text = DCSlipQR.WAQtyNo16
            'lbDCWAQtyNo17.Text = DCSlipQR.WAQtyNo17
            'lbDCWAQtyNo18.Text = DCSlipQR.WAQtyNo18
            'lbDCWAQtyNo19.Text = DCSlipQR.WAQtyNo19
            'lbDCWAQtyNo20.Text = DCSlipQR.WAQtyNo20
            'lbDCWAQtyNo21.Text = DCSlipQR.WAQtyNo21
            'lbDCWAQtyNo22.Text = DCSlipQR.WAQtyNo22
            'lbDCWAQtyNo23.Text = DCSlipQR.WAQtyNo23
            'lbDCWAQtyNo24.Text = DCSlipQR.WAQtyNo24
            'lbDCWAQtyNo25.Text = DCSlipQR.WAQtyNo25
        Else
            Dim WorkSlipQR As New WorkingSlipQRCode
            WorkSlipQR.SplitQRCode(OprData.QrData)
            lbLotNo.Text = WorkSlipQR.LotNo
            lbPackage.Text = WorkSlipQR.Package
            lbDevice.Text = WorkSlipQR.Device
            lbRecipe.Text = WorkSlipQR.Code
            OprData.WaferLotID = WorkSlipQR.WFLotNo
            lbWaferLotNo.Text = WorkSlipQR.WFLotNo

            RaiseEvent E_TransactionDataSave(OprData.QrData)



        End If


    End Sub


#End Region


#Region "Xml File Manage (ObjClass serailize in folder EquipmentObj)"

    '1. 'WrXml()   For Write to Serailize file to path PathXmlObj
    '    RdXml()   For Read to Serailize file
    '2. After lotend 




    ' -------------------Keep all file of  PathXmlObj in LotNo and move to BackUpObj Directory
    Private Sub MakeLotFolderToBackUp(ByVal LotNo As String)
        Dim LotDirName As String = BackUpObj & "\" & LotNo & "_" & Format(Now, "yyyyMMddTHHmmss")
        System.IO.Directory.CreateDirectory(LotDirName)
        For Each fi As FileInfo In New DirectoryInfo(CellconObjPath).GetFiles
            File.Move(fi.FullName, LotDirName & "\" & fi.Name)
        Next
        BackUpLotClean()
    End Sub

    ''' Clean log by limit folder size  delete form old to new defualt 5M
    '''

    Private Sub CleanLog(Optional ByVal DirSizeLimit_Mbyte As Integer = 200)   '161212 \783 Add clean log

        Try
            Dim Mlmt As Integer = DirSizeLimit_Mbyte * 1000000
            Dim orderedFiles = New System.IO.DirectoryInfo(DIR_LOG).GetFiles().OrderByDescending(Function(x) x.CreationTime).ToArray   'Order by create data(Not Modify) 
            Dim index As Integer = 0
            Dim DirSize As Integer = 0

            For i = 0 To orderedFiles.Length - 1
                DirSize = CInt(DirSize + orderedFiles(i).Length)  'File Over Size count
                index = +1
                If Mlmt < DirSize Then
                    index = i
                    Exit For
                End If
            Next
            If index >= orderedFiles.Length - 1 Then
                Exit Sub
            End If

            For i = index To orderedFiles.Length - 1  'Delete from index that over size
                File.Delete(orderedFiles(i).FullName)
            Next


        Catch ex As Exception
            SaveCatchLog(ex.ToString, "CleanLog()")
        End Try

    End Sub

    '--------------------- Cleanning Directory in  backup 
    Private WithEvents BackUp As New BackgroundWorker

    Friend Sub BackUpLotClean()
        BackUp.RunWorkerAsync()
    End Sub
    Private Sub DoBackup(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackUp.DoWork
        Try

            Dim Dirs = Directory.GetDirectories(BackUpObj)
            If Dirs.Count > 100 Then   'Store 100 Folders over then move to BackUpOld 100 files
                For Each DirSo In Dirs
                    Dim DirInfo As New System.IO.DirectoryInfo(DirSo)
                    Directory.Move(DirSo, Path.Combine(BackUpObjOld, DirInfo.Name))
                Next
            End If
            Dim OldDirs = Directory.GetDirectories(BackUpObjOld)
            If OldDirs.Count > 100 Then           'if over 100  Folders del 10 Folders of BackUpOld
                Dim DirDes = From l In OldDirs Order By Directory.GetCreationTime(l) Ascending    'SortFile by Modify time
                For i = 0 To 10
                    Directory.Delete(DirDes(i), True)             'Del 10 Folders
                Next

            End If
            e.Result = ""
        Catch ex As Exception
            e.Result = ex.ToString
        End Try

    End Sub
    Private Sub Backup_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackUp.RunWorkerCompleted
        Dim result As String = CStr(e.Result)
        SaveCatchLog(result, "DoBackUp()")
    End Sub



#End Region

#Region "SecsComm"

    'Remote Command change in S2F41 Class for customize to each CPVAL format.------------------160705 \783 Addition Remote example
    'Example for CPVAL is string type
    Private Sub SendRemoteCommand(ByVal RCmd As String, Optional ByVal CmdPName As String = "", Optional ByVal CmdPVal As String = "")
        Dim cmd As S2F41 = New S2F41()
        cmd.RemoteCommand = RCmd
        If CmdPName <> "" And CmdPVal <> "" Then
            cmd.AddVariable(CmdPName, CmdPVal)
        End If
        RaiseEvent E_HostSend(cmd)
    End Sub


    '---------------------------------------------------------------------------------------------------------------------


    Private m_SxFxx As SxFxxDelegate = New SxFxxDelegate(AddressOf m_Host_ReceivedSecondaryMessage)

    Friend Sub m_Host_ReceivedSecondaryMessage(ByVal e As SecondarySecsMessageEventArgs)
        If Me.InvokeRequired Then
            'http://kristofverbiest.blogspot.com/2007/02/avoid-invoke-prefer-begininvoke.html
            Me.BeginInvoke(m_SxFxx, e)
            Exit Sub
        End If

        Dim priMsg As SecsMessageBase = e.Primary
        Dim sndMsg As SecsMessageBase = e.Secondary

        Select Case sndMsg.Stream
            Case 2
                Select Case sndMsg.Function    '160903 \783 add S2F42
                    Case 42
                        Dim reply As New S2F42
                        reply = DirectCast(sndMsg, S2F42)
                        Dim remote As New S2F41
                        remote = DirectCast(priMsg, S2F41)

                        Select Case remote.RemoteCommand

                            Case "RCMD_LOCK", "RCMD_RESTART", "RCMD_START", "RCMD_TUBE_ACCEPT"
                                If reply.HCACK <> HCACK.OK Then

                                End If
                            Case "RCMD_PPSELECT"
                                If reply.HCACK <> HCACK.OK AndAlso reply.HCACK <> HCACK.RejectedAlreadyInDesired Then

                                End If


                        End Select

                End Select
            Case 7
                Select Case sndMsg.Function

                    Case 2
                        Dim reply As S7F2 = DirectCast(sndMsg, S7F2)      '160727 RecipeBodyManage
                        If reply.PPGNT = PPGNT.Ok Then
                            Dim msg As New S7F3
                            'Dim bFile As Byte() = File.ReadAllBytes(RecipeDir & "\" & OprData.PPIDMange & ".bin")
                            Dim RecipeR As New PDE
                            RecipeR = ReadFromXmlPDE(RecipeDir & "\" & OprData.PPIDMange & ".xml") '160811 \783 recipe Program Develop Element

                            msg.Setparameter(OprData.PPIDMange, RecipeR.PPBody)
                            RaiseEvent E_HostSend(msg)

                        Else
                            RaiseEvent E_SlInfo("HostRequestDownLoadToEq Abort. Equipment  >> " & reply.PPGNT.ToString)
                        End If

                    Case 4
                        Dim reply As S7F4 = DirectCast(sndMsg, S7F4)      '160727 RecipeBodyManage
                        If reply.ACK7 = ACKC7.Accepted Then
                            RaiseEvent E_SlInfo("HostRequestDownLoadToEq Successful")
                            For Each _file As String In Directory.GetFiles(RecipeDir)   'After success will delete all file ,Protect load mis form remaining file 
                                File.Delete(_file)
                            Next

                        Else

                            RaiseEvent E_SlInfo("HostRequestDownLoadToEq Error. Equipment  >> " & reply.ACK7.ToString)
                        End If

                    Case 6
                        Dim rcmd As S7F6 = DirectCast(sndMsg, S7F6)
                        If rcmd.PPID = "PPIDisNull" Then     '160916 \783 Support ListZero Length
                            MakeAlarmCellCon("HostRequestUplaodToHost is Denied", "S7F6")
                            RaiseEvent E_SlInfo("S7SF6 Request denied")
                            Exit Sub
                        End If

                        Dim recipex As New PDE       'Can Set anymore property of PDE 
                        recipex.PPBody = rcmd.PPBody

                        Dim temptextspilt As String() = rcmd.PPID.Split(CChar("\"))

                        recipex.Name = temptextspilt(temptextspilt.Length - 1)
                        recipex.FullDownLoadname = rcmd.PPID
                        recipex.PathOfFile = RecipeDir
                        recipex.CreateDate = Format(Now, "yyyyMMddTHHmmss")
                        recipex.MCType = My.Settings.MCType
                        WriteToXmlPDE(RecipeDir & "\" & recipex.Name & "_" & Format(Now, "yyyyMMddTHHmmss") & ".xml", recipex) '160811 \783 recipe Program Definition Element


                        RaiseEvent E_SlInfo("HostRequestUplaodToHost Successful PPID : " & rcmd.PPID)
                    Case 18
                        Dim reply As S7F18 = DirectCast(sndMsg, S7F18)
                        If reply.ACK7 = ACKC7.Accepted Then

                        End If

                End Select 'End S7

        End Select



    End Sub

    Private m_SxFxxPri As SxFxxPriDelegate = New SxFxxPriDelegate(AddressOf m_Host_ReceivedPrimaryMessage)
    Friend Sub m_Host_ReceivedPrimaryMessage(ByVal state As Object)
        If Me.InvokeRequired Then
            'http://kristofverbiest.blogspot.com/2007/02/avoid-invoke-prefer-begininvoke.html
            Me.BeginInvoke(m_SxFxxPri, state)
            Exit Sub
        End If
        Try


            Dim msg As SecsMessageBase = DirectCast(state, SecsMessageBase)
            Select Case msg.Stream
                Case 1
                    Select Case msg.Function
                        Case 13
                            '   Dim S1F13x As New S1F13E()
                            '   S1F13x = DirectCast(msg, S1F13E)
                            '  Dim S1F14 As New S1F14
                            '  RaiseEvent E_HostReply(S1F13x, S1F14)
                    End Select
                Case 12
                    Select Case msg.Function
                        Case 1
                            Dim S12F1 As New S12F1Esec()
                            S12F1 = DirectCast(msg, S12F1Esec)

                            Dim S12F2 As New S12F2
                            RaiseEvent E_HostReply(S12F1, S12F2)     'Acknowledge Only
                        Case 3
                            Dim S12F3 As New S12F3
                            S12F3 = DirectCast(msg, S12F3)
                            WaferMapDownLoadToEq(S12F3)

                        Case 5
                            Dim S12F5 As New S12F5Esec()
                            S12F5 = DirectCast(msg, S12F5Esec)

                            Dim S12F6 As New S12f6
                            RaiseEvent E_HostReply(S12F5, S12F6)     'Acknowledge Only

                        Case 9
                            Dim S12F9 As New S12F9()
                            S12F9 = DirectCast(msg, S12F9)


                            Dim S12F10 As New S12F10
                            RaiseEvent E_HostReply(S12F9, S12F10)     'Acknowledge Only
                        Case 15
                            Dim S12F15 As New S12F15
                            S12F15 = DirectCast(msg, S12F15)

                            If S12F15.MID = OprData.WaferID Then
                                Dim S12F16 As New S12F16
                                S12F16.SetS12F16_Esec(S12F15.MID, S12F15.IDTYP, WaferMapData)
                                RaiseEvent E_HostReply(S12F15, S12F16)
                            Else
                                MakeAlarmCellCon("MapData Request ID : " & S12F15.MID & "ไม่ตรงกับข้อมูลใน Working Slip : " & OprData.WaferID)
                                Dim S12F16 As New S12F16
                                S12F16.SetS12F16_Esec(S12F15.MID, S12F15.IDTYP, "")      'A zero length list returned means no such MID 
                                RaiseEvent E_HostSend(S12F16)

                            End If
                    End Select

            End Select


        Catch ex As Exception
            SaveCatchLog(ex.ToString, "m_Host_ReceivedPrimaryMessage()_ProcessForm")
        End Try

    End Sub


    Private m_S6F11 As S6F11Delegate = New S6F11Delegate(AddressOf OnS6F11)


    Friend Sub OnS6F11(ByVal request As S6F11) '160801 \783 Add parameter m_Equipment
        If Me.InvokeRequired Then
            'http://kristofverbiest.blogspot.com/2007/02/avoid-invoke-prefer-begininvoke.html
            Me.BeginInvoke(m_S6F11, request)
            Exit Sub
        End If
        request.ApplyStatusVariableValue(m_Equipment, m_DefinedReportDic)  'Macthing  S6F11 with  Define report for decode SVID

        'm_Equipment are object of SVIDs if usage by S6F11  , Please define property of equiptment object refer to SVID Name in equipment specification. 
        'Must set SVID value in S6F11 Class to m_Equipment object


        If My.Settings.EventReportEnable Then
            Select Case request.CEID ''Control Status
                'm_equipment are SVID of CEID that define in report.
                Case CStr(SecsID.LotStartECID)
                    Lotstart(CType(CellConTag.LSMode, Rohm.Apcs.Tdc.RunModeType))

                Case CStr(SecsID.LotEndECID)
                    CellConTag.NGbin1 = m_Equipment.NGbin1
                    CellConTag.NGbin2 = m_Equipment.NGbin2
                    CellConTag.NGbin3 = m_Equipment.NGbin3
                    CellConTag.NGbin4 = m_Equipment.NGbin4
                    CellConTag.NGbin5 = m_Equipment.NGbin5
                    CellConTag.NGbin6 = m_Equipment.NGbin6
                    CellConTag.GoodCat1 = m_Equipment.GoodCat1
                    CellConTag.GoodCat2 = m_Equipment.GoodCat2
                    LotEnd()
            End Select
        End If


        Select Case request.CEID ''Control Status

            Case CStr(9)    'Processing State Change
                lbMCStatus.Text = m_Equipment.EQStatus.ToString
                'lbMCStatus.Text = CStr(m_Equipment.EQStatus)
            Case CStr(18)    'RightCassStatus
                lbMCRightCassette.Text = m_Equipment.EQCassetteRightStatus.ToString
                'If m_Equipment.EQCassetteRightStatus = EquipmentCassette.CassetteEnd And CassetteStatus = EquipmentCassetteStatus.RightCassette Then
                '    EndLot()
                'End If
                CheckEnd(request.CEID)
            Case CStr(19)    'LeftCassStatus
                CheckEnd(request.CEID)
                lbMCLeftCassette.Text = m_Equipment.EQCassetteLeftStatus.ToString
                'If m_Equipment.EQCassetteRightStatus = EquipmentCassette.CassetteEnd And CassetteStatus = EquipmentCassetteStatus.RightCassette Then
                '    EndLot()
                'End If
                'm_equipment are SVID of CEID that define in report.
        End Select


    End Sub
    Private Sub CheckEnd(ByVal CEID As String)
        If CassetteStatus = EquipmentCassetteStatus.AllCassette Then
            If m_Equipment.EQCassetteRightStatus = EquipmentCassette.CassetteEnd And m_Equipment.EQCassetteLeftStatus = EquipmentCassette.CassetteEnd Then
                EndLot()
            End If
        Else
            Select Case CEID
                Case "18"
                    If m_Equipment.EQCassetteRightStatus = EquipmentCassette.CassetteEnd And CassetteStatus = EquipmentCassetteStatus.RightCassette Then
                        EndLot()
                    End If
                Case "19"
                    If m_Equipment.EQCassetteLeftStatus = EquipmentCassette.CassetteEnd And CassetteStatus = EquipmentCassetteStatus.LeftCassette Then
                        EndLot()
                    End If
            End Select
        End If






    End Sub
    Private Sub HostRequestDownLoadToEq(ByVal PPID As String) '160727 RecipeBodyManage
        Dim msg As New S7F1
        If File.Exists(RecipeDir & "\" & PPID & ".xml") = True Then
            OprData.PPIDMange = PPID
            Dim bFile As Byte() = ReadFromXmlPDE(RecipeDir & "\" & PPID & ".xml").PPBody     '160811 \783 recipe Program Definition Element
            msg.Setparameter(PPID, bFile.Length)
            RaiseEvent E_HostSend(msg)
        Else
            RaiseEvent E_SlInfo("ไม่พบไฟล์ชื่อ " & PPID & "ใน Folder" & RecipeDir)
        End If

    End Sub

    Private Sub HostRequestUplaodToHost(ByVal PPID As String)   '160727 RecipeBodyManage

        Dim S7F5 As New S7F5(PPID)
        RaiseEvent E_HostSend(S7F5)
    End Sub

    Private Sub WaferMapDownLoadToEq(ByVal S12F3R As S12F3)  'Request by Eq download to Eq.
        Dim WaferIndex As Integer
        Dim res As New MapData

        If S12F3R.MID.Length <> 7 Then   'Check format 9999-99
            MakeAlarmCellCon("Wafer No. format Err(9999-99) : " & S12F3R.MID, "Machine Ring WaferNo. Read")
            Dim S12F19x As New S12F19(MAPER.FormatError, 0)
            RaiseEvent E_HostReply(S12F3R, S12F19x)
            Exit Sub
        End If

        If Not Directory.Exists(WaferMapDir & "\" & OprData.WaferLotID) Then   'Check target Map file 
            MakeAlarmCellCon("ไม่พบ Directory " & WaferMapDir & "\" & OprData.WaferLotID)
            Dim S12F19x As New S12F19(MAPER.IDNoFound, 0)
            RaiseEvent E_HostReply(S12F3R, S12F19x)
            Exit Sub
        End If

        If Not IsNumeric(Microsoft.VisualBasic.Right(S12F3R.MID, 2)) Then     'Check wafer no. is numberic ?
            MakeAlarmCellCon("Wafer No. not found : " & S12F3R.MID, "Ring WaferNo. Read")
            Dim S12F19x As New S12F19(MAPER.IDNoFound, 0)
            RaiseEvent E_HostReply(S12F3R, S12F19x)
            Exit Sub
        End If

        If Not OprData.WaferLotID Like "*" & Microsoft.VisualBasic.Left(S12F3R.MID, 4) Then 'Check Read ID and Work Slip ID
            MakeAlarmCellCon("Wafer No (" & S12F3R.MID & ").ไม่ตรงกับข้อมูลใน Working Slip WaferID (" & OprData.WaferLotID & ")", "Ring WaferNo. Read")
            Dim S12F19x As New S12F19(MAPER.IDNoFound, 0)
            RaiseEvent E_HostReply(S12F3R, S12F19x)
            Exit Sub

        End If


        WaferIndex = CInt(Microsoft.VisualBasic.Right(S12F3R.MID, 2))
        WaferMapData.Clear()

        res = RohmMapConvert.Read(WaferMapDir & "\" & OprData.WaferLotID, S12F3R.FNLOC, S12F3R.NULBC, S12F3R.BCEQU, "M", WaferIndex)

        lbWaferNo.Text = S12F3R.MID
        OprData.WaferID = S12F3R.MID

        If (CellConTag.WaferID.Exists(Function(x) x = OprData.WaferID)) Then     'if exist remove  and new add
            CellConTag.WaferID.Remove(OprData.WaferID)
            CellConTag.WaferID.Add(OprData.WaferID)
        Else
            CellConTag.WaferID.Add(OprData.WaferID)
        End If

        Dim S12F4 As New S12F4
        Dim RefpList As New List(Of Point)
        RefpList.Add(res.REFP)
        S12F4.SetS12F4_Esec(S12F3R.MID, S12F3R.IDTYP, S12F3R.FNLOC, S12F3R.ORLOC, RefpList, CUShort(res.ROWCT), CUShort(res.COLCT), res.PRDCT, S12F3R.BCEQU, S12F3R.NULBC)
        RaiseEvent E_HostReply(S12F3R, S12F4)
        WaferMapData = res.BINLT
        RaiseEvent E_SlInfo("Host sends Map set up data")

    End Sub
#End Region


#Region "===AuthenticationUser"


    'Dim ETC2 As String                          'From QR Code ,Check ETC2 = BDXX-M/BJ/C is auto motive
    'Dim strNextOperatorNo As String              'OP No.
    'Dim GetUserAuthenGroupByMCType As String       'M/C Type ( Refer with DBx.Group)
    'Dim GL_Group As String                         'GL Gruop ( Refer with DBx.Group)
    'Dim Process As String                        'Process Ex. "FL"
    'Dim MCNo As String                           'MC No Ex "FL-V-01"
    Friend ErrMesETG As String
    Friend Function PermiisionCheck(ByVal ETC2 As String, ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String, ByVal Procees As String, ByVal MCNo As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean
        ErrMesETG = ""
        OprData.PermitCheckResult = "Check"
        Try

            If permission.CheckAutomotiveLot(ETC2) Then
                OprData.AutoMotiveLot = True
                'This lot is Automotive
                If Not permission.CheckMachineAutomotive(Procees, MCNo) Then          '(EQP.Machine.MCNo = @MCNo) AND (LSIProcess.Name = @ProcessName) AND (EQP.Machine.Automotive = 'true')
                    ErrMesETG = "MC No.นี้ไม่สามารถรัน Lot Automotive ได้ "
                    '_OperatorAlarm = "Machine cannot run the automotive lot,Please contact ETG"
                    'MsgBox("MC No.นี้ไม่สามารถรัน Lot Automotive ได้  กรุณาติดต่อ ETG/SYSTEM")
                    OprData.PermitCheckResult = "False : Not Machine AutoMotive (Auotmotive Lot) MC No. " & MCNo
                    Return False
                End If

                Dim UserAuthen As Boolean = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)        '170408 \783 Authen Detail warning
                Dim UserAutoMotive As Boolean = permission.AuthenUser(strNextOperatorNo, "AUTOMOTIVE")                  '170408 \783 Authen Detail warning
                Dim UserGL As Boolean = permission.AuthenUser(strNextOperatorNo, GL_Group) 'GL Can run every condition  '170408 \783 Authen Detail warning

                AuthenPass = UserAuthen And UserAutoMotive

                If AuthenPass = False Then AuthenPass = UserGL 'GL Can run every condition
                If AuthenPass = False Then
                    If Not UserAuthen Then
                        ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้ (license หมดอายุ หรือ ไม่มี license ,GroupCheck: " & GetUserAuthenGroupByMCType & ")" & "กรุณาติดต่อ ETG"
                    End If
                    If Not UserAutoMotive Then
                        ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้ GroupCheck: AUTOMOTIVE กรุณาติดต่อ ETG"
                    End If
                    If Not UserGL Then
                        ErrMesETG = "OP No(GL).นี้ไม่สามารถรัน Lot Automotive ได้ GroupCheck: " & GL_Group & ")" & "กรุณาติดต่อ ETG"
                    End If
                    OprData.PermitCheckResult = "False : Not Operaotr AutoMotive OP ID. " & strNextOperatorNo
                End If
                If AuthenPass Then
                    OprData.PermitCheckResult = "True : (Automotive Lot)"

                End If
            Else
                OprData.PermitCheckResult = "False : Not Operaotr AutoMotive (Auotmotive Lot) OP ID. " & strNextOperatorNo
                OprData.AutoMotiveLot = False
                'This lot isn't Automotive
                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
                ' AuthenPass = True
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรัน Lotนี้ ได้ (license หมดอายุ หรือ ไม่มี license ,GroupCheck: " & GetUserAuthenGroupByMCType & ")" & "กรุณาติดต่อ ETG"   '170408 \783 Authen Detail warning
                    '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
                    OprData.PermitCheckResult = "False : OP ID No license or expire license (Normal Lot) OP ID. " & strNextOperatorNo
                End If
                If AuthenPass Then
                    OprData.PermitCheckResult = "True : (Normal Lot)"

                End If
            End If


            Return AuthenPass
        Catch ex As Exception 'Network Error
            ErrMesETG = "Connection Error"
            Return False
        End Try
    End Function


    Public Function UserAuthen(ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean

        AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
        If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
        If AuthenPass = False Then
            ErrMesETG = "OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG" 'MsgBox("OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG/SYSTEM")
            '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
        End If

        Return AuthenPass
    End Function

    Public Function MachineAuomotive(ByVal Procees As String, ByVal MCNo As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Return permission.CheckMachineAutomotive(Procees, MCNo)           '(EQP.Machine.MCNo = @MCNo) AND (LSIProcess.Name = @ProcessName) AND (EQP.Machine.Automotive = 'true')
    End Function


#End Region

#Region "TDC"
    'USE Raise Event for Send TDC
    'Event E_LRCheck(ByVal EqNo As String, ByVal LotNo As String)
    'Event E_LSCheck(ByVal EQNo As String, ByVal LotNo As String, ByVal StartTime As Date, ByVal OPID As String, ByVal StartMode As RunModeType)
    'Event E_LECheck(ByVal EQNo As String, ByVal LotNo As String, ByVal EndTime As Date, ByVal GoodPcs As Integer, ByVal NgPcs As Integer, ByVal OPID As String, ByVal EndMode As EndModeType)


    Public Sub LR_Reply(ByVal Rpl As TdcLotRequestResponse, ByVal m_TdcService As TdcService)
        Try
            'Rpl.LotNoTag
            Using proxy As CellController.RohmService.ApcsWebServiceSoapClient = New CellController.RohmService.ApcsWebServiceSoapClient() 'LockFormService
                If proxy.LotRptIgnoreError(Rpl.MCNo, Rpl.ErrorCode) Then
                    CellConTag.LRReply = "True :" & "ServiceUnlockMode " & Format(Now, "yyyyMMddTHH:mm:ss") '170404 \783
                    GoTo OKAns
                End If
            End Using

            If OprData.MachineLockByTDC Then  'UnLock = True
                CellConTag.LRReply = "True :" & "TDCUnlockMode Active " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                GoTo OKAns
            End If

            If Rpl.HasError Then
                CellConTag.LRReply = "False :" & Rpl.ErrorCode & " : " & Rpl.ErrorMessage & " " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                ''MakeAlarmCellCon(Rpl.LotNo & " : " & Rpl.ErrorMessage)
                Select Case Rpl.ErrorCode
                    Case "01"

                    Case "02"
                    Case "03"
                    Case "04"
                    Case "05"
                    Case "06"
                    Case "70"
                    Case "71"
                    Case "72"
                    Case "99"

                End Select

                Dim li As LotInfo
                Dim m_dlg As TdcAlarmMessageForm

                li = m_TdcService.GetLotInfo(Rpl.LotNo, Rpl.MCNo)
                m_dlg = New TdcAlarmMessageForm(Rpl.ErrorCode, Rpl.ErrorMessage, Rpl.LotNo, li)
                m_dlg.ShowDialog()
                GoTo EndLoop
            End If


            CellConTag.LRReply = "True : " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
OKAns:

            'Coding here if Ans OK

EndLoop:
            lbLotInfoTDC.Text = CellConTag.LRReply
            'If CellconTagList.ContainsKey(Rpl.LotNo) Then  'Remove before add if already exist   'For MultiCelcon
            '    CellconTagList.Remove(Rpl.LotNo)
            'End If
            'CellconTagList.Add(Rpl.LotNo, CellConTag)



        Catch ex As Exception
            SaveCatchLog(ex.ToString, "LR_Reply()")
        End Try


    End Sub
    Public Sub Loaddata()
        BGDataTableAdapter.Fill(DBxDataSet.BGData, My.Settings.HeaderProcess & My.Settings.EquipmentNo)
        ' DataGridView2.DataSource = DBxDataSet.BGData

    End Sub

    Public Sub LS_Reply(ByVal Rpl As TdcResponse, ByVal m_TdcService As TdcService)
        Try

            ' Rpl .LotNoTag 
            If OprData.MachineLockByTDC Then  'UnLock = True
                CellConTag.LSReply = "True :" & "TDCUnlockMode Active " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                GoTo OKAns
            End If
            If Rpl.HasError Then
                CellConTag.LSReply = "False :" & Rpl.ErrorCode & " : " & Rpl.ErrorMessage & " " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                'MakeAlarmCellCon(Rpl.LotNo & " : " & Rpl.ErrorMessage)
                Select Case Rpl.ErrorCode
                    Case "01"
                    Case "02"
                    Case "03"
                    Case "04"
                    Case "05"
                    Case "06"
                    Case "70"
                    Case "71"
                    Case "72"
                    Case "99"
                End Select

                Dim li As LotInfo
                Dim m_dlg As TdcAlarmMessageForm

                '  li = m_TdcService.GetLotInfo(Rpl.LotNo, My.Settings.ProcessName & "-" & My.Settings.EquipmentNo)
                li = m_TdcService.GetLotInfo(Rpl.LotNo, My.Settings.HeaderProcess & My.Settings.EquipmentNo)
                m_dlg = New TdcAlarmMessageForm(Rpl.ErrorCode, Rpl.ErrorMessage, Rpl.LotNo, li)
                m_dlg.ShowDialog()

                GoTo EndLoop
            End If
            CellConTag.LSReply = "True : " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
OKAns:

            'Coding here if Ans OK
EndLoop:
            lbLotInfoTDC.Text = CellConTag.LSReply
            If lbLotNo.Text <> "" Then    '170404 \783
                WriteToXmlCellcon(CellconObjPath & "\" & Rpl.LotNo & ".xml", CellConTag)  '170126 \783 CellconTag
            End If

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "LS_Reply()")
        End Try
    End Sub

    Public Sub LE_Reply(ByVal Rpl As TdcResponse, ByVal m_TdcService As TdcService)
        Try

            ' Rpl .LotNoTag 
            If OprData.MachineLockByTDC Then  'UnLock = True
                CellConTag.LEReply = "True :" & "TDCUnlockMode Active " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                GoTo OKAns
            End If
            If Rpl.HasError Then
                CellConTag.LEReply = "False :" & Rpl.ErrorCode & " : " & " " & Rpl.ErrorMessage & " " & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
                MakeAlarmCellCon(Rpl.LotNo & " : " & Rpl.ErrorMessage)
                Select Case Rpl.ErrorCode
                    Case "01"
                    Case "02"
                    Case "03"
                    Case "04"
                    Case "05"
                    Case "06"
                    Case "70"
                    Case "71"
                    Case "72"
                    Case "99"
                End Select
                Dim li As LotInfo
                Dim m_dlg As TdcAlarmMessageForm

                'li = m_TdcService.GetLotInfo(Rpl.LotNo, My.Settings.ProcessName & "-" & My.Settings.EquipmentNo)
                li = m_TdcService.GetLotInfo(Rpl.LotNo, My.Settings.HeaderProcess & My.Settings.EquipmentNo)
                m_dlg = New TdcAlarmMessageForm(Rpl.ErrorCode, Rpl.ErrorMessage, Rpl.LotNo, li)
                m_dlg.ShowDialog()

                GoTo EndLoop
            End If
            CellConTag.LEReply = "True :" & Format(Now, "yyyyMMddTHH:mm:ss") '170126 \783 CellconTag
OKAns:

            'Coding here if Ans OK

EndLoop:
            lbLotInfoTDC.Text = Rpl.ErrorCode & " : " & " " & Rpl.ErrorMessage
            If lbLotNo.Text <> "" Then    '170404 \783
                WriteToXmlCellcon(CellconObjPath & "\" & Rpl.LotNo & ".xml", CellConTag)  '170126 \783 CellconTag
            End If

            'If CellconTagList.ContainsKey(Rpl.LotNo) Then
            '    CellconTagList.Remove(Rpl.LotNo)
            'End If

            CellConTag = New CellConObj              'Clear data

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "LE_Reply()")
        End Try
    End Sub


#End Region

#Region "Custom Protolcol"

    Friend Sub RcvManage(ByVal data As String)       'If  My.Settings.CsProtocol Disable data will not come

        Dim Parameter As String
        Parameter = data
        Dim RcvManage_Task As New BackgroundWorker
        AddHandler RcvManage_Task.DoWork, AddressOf RcvManage_Dowork
        AddHandler RcvManage_Task.RunWorkerCompleted, AddressOf RcvManage_RunComplete
        RcvManage_Task.RunWorkerAsync(Parameter)
    End Sub


    Private Sub RcvManage_Dowork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim Agr As String
        Agr = CType(e.Argument, String)

        Dim CmdHeader As String
        Dim Cmddata() As String = Agr.Split(CChar(","))
        CmdHeader = Cmddata(0)

        Select Case CmdHeader
            'Case "LR "
            '    LR(Agr)

            'Case "LS "
            '    Send("LS,00")       'LS No use Equiptment can not stop after sent LS to Cellcon

            'Case "LE "
            '    LE(Agr)
            'BackUpLotClean()

            'Case "SC "

            '    SC(Agr)

        End Select


        e.Result = Agr
    End Sub

    Private Sub RcvManage_RunComplete(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        Dim Agr As String
        Agr = CType(e.Result, String)

    End Sub

    Private Sub Send(ByVal str As String)              ''If  My.Settings.CsProtocol Disable data will not go
        If Not My.Settings.CsProtocol_Enable Then
            Exit Sub
        End If

        RaiseEvent E_CsProtocol_SendMsg(str & vbCr)
    End Sub

    Delegate Sub AccessControlDelg(ByVal data As String)
    Private m_LR As AccessControlDelg = New AccessControlDelg(AddressOf LR)
    Private m_SC As AccessControlDelg = New AccessControlDelg(AddressOf SC)
    Private m_LE As AccessControlDelg = New AccessControlDelg(AddressOf LE)

    'LR ,QR CodeData,OpNo,InputQty,RecipeName,EqStationNo[CR]
    Private Sub LR(ByVal Cmddatax As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(m_LR, Cmddatax)
            Exit Sub
        End If
        Try
            'USE Raise Event for Send TDC
            'Event E_LRCheck(ByVal EqNo As String, ByVal LotNo As String)
            'LotRequest()

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "LR()")
        End Try

    End Sub


    'SC ,99,AlarmNo[Cr]   --- 01 AlarmSet,00 AalrmClear
    Private Sub SC(ByVal Cmddatax As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(m_SC, Cmddatax)
            Exit Sub
        End If
        Try

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "SC()")
        End Try


    End Sub


    ' LE ,LotNo.[CR]

    Private Sub LE(ByVal Cmddatax As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(m_LE, Cmddatax)
            Exit Sub
        End If

        Try
            'USE Raise Event for Send TDC
            'Event E_LECheck(ByVal EQNo As String, ByVal LotNo As String, ByVal EndTime As Date, ByVal GoodPcs As Integer, ByVal NgPcs As Integer, ByVal OPID As String, ByVal EndMode As EndModeType)


        Catch ex As Exception
            SaveCatchLog(ex.ToString, "LE()")
        End Try


    End Sub


    Private Sub SendRM_LOCK()
        'Send("RM,LOCK")
    End Sub


#End Region

#Region "Lot Management"

    Public Sub DataInitialSucess(ByVal WorkSlipQR As WorkingSlipQRCode)
        OprData.WaferLotID = WorkSlipQR.WFLotNo
        lbWaferLotNo.Text = WorkSlipQR.WFLotNo
        FrmTableDataClear()
        LotRequest()

    End Sub



    Private Sub LotRequest()
        If lbLotNo.Text = "" Then
            MakeAlarmCellCon("LotNo is nothing", "TDC Lot Request")
            RaiseEvent E_SlInfo("LotNo is nothing")
            Exit Sub
        End If
        CellConTag = New CellConObj    'Clear CellconTag   '170126 \783 CellconTag
        CellConTag.Process = My.Settings.ProcessName
        CellConTag.LotID = lbLotNo.Text
        CellConTag.Package = lbPackage.Text
        CellConTag.DeviceName = lbDevice.Text
        CellConTag.Recipe = lbRecipe.Text
        CellConTag.QrData = OprData.QrData
        CellConTag.MCNo = lbMcNo.Text
        CellConTag.OPID = lbOPID.Text
        CellConTag.INPUTQty = lbInputTotal.Text
        CellConTag.WaferLotID = OprData.WaferLotID
        CellConTag.LSMode = OprData.LSMode


        If OprData.WaferID <> "" And My.Settings.WaferMappingUse Then
            CellConTag.CurrentWaferID = OprData.WaferID
            If (CellConTag.WaferID.Exists(Function(x) x = OprData.WaferID)) Then     'if exist remove  and new add
                CellConTag.WaferID.Remove(OprData.WaferID)
                CellConTag.WaferID.Add(OprData.WaferID)
            Else
                CellConTag.WaferID.Add(OprData.WaferID)
            End If
            OprData.WaferID = ""                     'Clear Data after save
        End If

        CellConTag.PermitCheckResult = OprData.PermitCheckResult
        OprData.PermitCheckResult = ""
        If Not My.Settings.TDC_Enable Then
            CellConTag.LRReply = "TDC Disable"
        End If

        RaiseEvent E_LRCheck(lbMcNo.Text, lbLotNo.Text)


    End Sub


    Private Sub Lotstart(Optional ByVal LsMode As RunModeType = RunModeType.Normal)

        Dim datex As Date = Now
        lbStartTime.Text = Format(datex, "yyyy/MM/dd HH:mm:ss")
        CellConTag.LotStartTime = lbStartTime.Text
        RaiseEvent E_LSCheck(lbMcNo.Text, lbLotNo.Text, datex, lbOPID.Text, LsMode)
        If Not My.Settings.TDC_Enable Then
            CellConTag.LSReply = "TDC Disable"
            If lbLotNo.Text <> "" Then    '170404 \783
                WriteToXmlCellcon(CellconObjPath & "\" & lbLotNo.Text & ".xml", CellConTag)  '170126 \783 CellconTag
            End If

        End If

    End Sub


    Private Sub LotEnd(Optional ByVal LeMode As EndModeType = EndModeType.Normal)

        Dim datex As Date = Now
        lbEndTime.Text = Format(datex, "yyyy/MM/dd HH:mm:ss")
        CellConTag.LotEndTime = lbEndTime.Text

        CellConTag.TotalGoodPcs = CellConTag.GoodCat1 + CellConTag.GoodCat2
        CellConTag.TotalNGPcs = CellConTag.NGbin1 + CellConTag.NGbin2 + CellConTag.NGbin3 + CellConTag.NGbin4 + CellConTag.NGbin5 + CellConTag.NGbin6
        lbNGTotal.Text = CellConTag.TotalNGPcs
        lbGoodTotal.Text = CellConTag.TotalGoodPcs


        RaiseEvent E_LECheck(lbMcNo.Text, lbLotNo.Text, datex, CInt(lbGoodTotal.Text), CInt(lbNGTotal.Text), lbOPID.Text, LeMode)
        CleanLog(1000) '1G backup limit
        BackUpLotClean()
        If Not My.Settings.TDC_Enable Then
            CellConTag.LEReply = "TDC Disable"
            If lbLotNo.Text <> "" Then    '170404 \783
                WriteToXmlCellcon(CellconObjPath & "\" & lbLotNo.Text & ".xml", CellConTag)  '170126 \783 CellconTag
            End If

            CellConTag = New CellConObj              'Clear data
        End If
    End Sub

    Private Sub Reload(Optional ByVal LotId As String = "")  '170330 \783 Reload File Addition
        Try
            If LotId = "" Then
                Dim QrForm As New QrInput(QrInput.QrType.WorkingSlip)
                QrForm.Label1.Text = "สแกน QR ของ Working Slip"
                QrForm.ShowDialog()
                If OprData.ReloadLot = "" Then
                    MakeAlarmCellCon("อ่านค่า Working Slip ล้มเหลว", "Reload Data", "OprData.ReloadLot ไม่มีค่า")
                    Exit Sub
                End If
                LotId = OprData.ReloadLot

            End If

            If Not File.Exists(CellconObjPath & "\" & LotId & ".xml") Then
                MakeAlarmCellCon("ไม่พบ File ที่ต้องการ Load (" & LotId & ".xml)", "Reload Data", "File.exists()")
                Exit Sub
            End If
            CellConTag = ReadFromXmlCellcon(CellconObjPath & "\" & LotId & ".xml")

            CellConTag.ReloadLot = OprData.ReloadLot & "_" & Format(Now, "yyyy/MM/ddTHH:mm:ss")
            RefreshLb()


        Catch ex As Exception
            SaveCatchLog(ex.ToString, " Reload()")
        End Try
    End Sub


    Public Function WaferMapReadFromZion() As Boolean

        Try

            If Not My.Computer.Network.IsAvailable Then                'unplug check
                MakeAlarmCellCon("PC Nework point unplug")
                Return False
            End If

            If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
                MakeAlarmCellCon("การเชื่อมต่อกับ" & _ipServer & "ล้มเหลวไม่สามารถดำเนินการต่อได้")
                Return False
            End If

            If Directory.Exists(WaferMapDir) Then                    'Delete All 
                Directory.Delete(WaferMapDir, True)
            End If

            If Not Directory.Exists("\\" & _ipServer & "\WaferMapping\" & OprData.WaferLotID) Then
                MakeAlarmCellCon("ไม่พบ Wafer LotID " & OprData.WaferLotID & " ใน Server(" & _ipServer & ")")
                Return False
            End If

            Directory.CreateDirectory("\\" & _ipServer & "\WaferMapping\" & OprData.WaferLotID)
            My.Computer.FileSystem.CopyDirectory("\\" & _ipServer & "\WaferMapping\" & OprData.WaferLotID & "\", WaferMapDir & "\" & OprData.WaferLotID)
            RaiseEvent E_SlInfo("WaferMapping load from Server Successful")
            Return True

        Catch ex As Exception
            SaveCatchLog(ex.ToString, "WaferMapReadFromZion()")
            MakeAlarmCellCon("Copy directory WaferMapping  from Server Err")
            Return False
        End Try


    End Function
#End Region

#Region "===  KeyBoard Control"
    Dim KYB As KeyBoard

    Private Sub KeyBoardCall(ByVal OBJ As TextBox, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")
        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetTextBox = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.Owner = Me
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag

        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_close

    End Sub


    Private Sub KeyBoardCall(ByVal OBJ As Label, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")

        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetLabel = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.Owner = Me
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_close

    End Sub

    Private Sub KeyBoardCallDialog(ByVal OBJ As Label, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")

        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetLabel = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag

        KYB.ShowDialog()
        KYB.Close()
        KYB.TagID = ""
    End Sub



    Private Sub KYB_close(sender As Object, e As FormClosedEventArgs)
        lbProcess.Focus()                   'tbxCtrl unfocus
        KYB.TagID = ""
    End Sub





#End Region

#Region "Debug"

    Public Sub ax()
        MsgBox("text")
    End Sub


    Dim ID As Integer
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)



        'AlarmTable(True, CStr(ID), "TEXT")
        'Update_dgvProductionInfo1(CStr(A), "555", "22", "33")
        'ID += 1
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim AX As New Thread(AddressOf A1)
        Dim BX As New Thread(AddressOf B1)
        AX.Start()
        BX.Start()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dim CX As New Thread(AddressOf c1)
        CX.Start()
    End Sub


    Dim OBJA As New Object
    Dim A As Integer
    Private Sub A1()

        'SyncLock OBJA
        'Thread.Sleep(2000)
        'End SyncLock

        Update_dgvProductionDetail(CStr(A), "AA", "")
        A += 1
    End Sub
    Private Sub B1()

        SaveCatchLog("TestCatchlog", "B")
        'Thread.Sleep(100)
        'SyncLock OBJA
        'Thread.Sleep(2000)
        'End SyncLock
        'Update_dgvProductionInfo1("Carr", CStr(A), "B", "BB")
    End Sub
    Private Sub c1()

        Update_dgvProductionInfoEnd(CStr(A), "555", "C")
        A += 1
    End Sub


    Private Sub S2F43UseSample()

        Dim SF As New S2F43
        Dim Func As Byte() = {11, 12, 13}
        SF.AddStream(6, Func)
        Func = {1, 2, 3}
        SF.AddStream(1, Func)
        RaiseEvent E_HostSend(SF)

    End Sub

    Private Sub DataBaseUpdateByDataRowSample()
        'Try
        '    Dim tb As New DBxDataSet.IPDDataDataTable
        '    Dim Qry As New DBxDataSetTableAdapters.IPDDataTableAdapter
        '    Qry.FillBy(tb, "1111111111")
        '    Dim Dr As DBxDataSet.IPDDataRow
        '    Dr = CType(tb.Rows(0), DBxDataSet.IPDDataRow)
        '    Dr.InFrame = 23
        '    Try
        '        Dim a = Qry.Update(Dr)

        '    Catch ex As InvalidOperationException
        '        MsgBox("Update Fail : " & ex.ToString)
        '    Catch ex As DBConcurrencyException
        '        MsgBox("Update Fail : " & ex.ToString)

        '    End Try

        'Catch ex As Exception


        'End Try
    End Sub
    Dim TimeOut As Boolean
    Dim Tmp As Object
    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        'Dim p As New PDE
        'Dim para As New PDE.PDEparameter
        'para.inputBounds = "4 - 7"
        'para.unit = "mm"

        'p._relatedParameters.Add(para)
        'p.MCType = "ESEC"
        'p.Name = "ppid"
        'para = New PDE.PDEparameter
        'para.unit = "uu"
        'para.inputBounds = "1-2"
        'p._relatedParameters.Add(para)

        'Dim by As Byte()
        'by = {0, 0, 2, 8}

        'p.PPBody = by


        'WriteToXml(PathXmlObj & "\P.xml", p)
        'Dim x As New PDE
        'x = ReadFromXml(PathXmlObj & "\P.xml")
        ''WrXml(PathXmlObj & "\P.xml", p)
        'RaiseEvent E_MakeAlarmCellCon("กรูราใส่จำนวนงาน Input ก่อน ", "Input Menu", "Waring", "001")
        'MsgBox(Format(Now, "yyyyMMddTHHmmss"))

        'HostRequestDownLoadToEq("TEST1")
        'HostRequestUplaodToHost("TEST1")

        ''SendRemoteCommand("START",

        'Dim s7f17 As New S7F17
        's7f17.AddPPID("555")
        's7f17.AddPPID("444")
        'RaiseEvent E_HostSend(s7f17)
        'CleanLog(2)


        'Dim TEST As New S2F15
        'TEST.AddListEcid(2, CStr(300), SecsFormat.U2)

        'RaiseEvent E_HostSend(TEST)
        'RaiseEvent E_Update_dgvProductionDetail("1", "2", "3", "4")
        'DataGridView1.DataSource = DefReport

        'RaiseEvent E_MakeAlarmCellCon("5555", "", "", "")


        LotRequest()





    End Sub


    Private Sub timeOutx()
        TimeOut = True
    End Sub

#End Region

#Region "User Coding Area"
    Function QRWorkingSlipInputInitailCheck(ByVal BeAfRead As Boolean, Optional ByVal WorkSlipQR As WorkingSlipQRCode = Nothing) As Boolean   'Before Read = True, After Read =False

        'Coding Here
        'Before Read Working Slip check ===================================================================================================
        '------------------------------
        If BeAfRead Then




            'After Read Working Slip check ========================================================================================================
            '----------------------------
        Else



        End If

        Return True
    End Function


    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        OprData.WaferLotID = TextBox1.Text
        WaferMapReadFromZion()
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Lotstart(CType(CellConTag.LSMode, RunModeType))



        'RaiseEvent E_MakeAlarmCellCon("5555", "", "", "")

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        LotEnd(EndModeType.Normal)
    End Sub



    Private Sub RefreshLb()  '170330 \783 Reload File Addition

        lbLotNo.Text = CellConTag.LotID
        lbPackage.Text = CellConTag.Package
        lbDevice.Text = CellConTag.DeviceName
        lbRecipe.Text = CellConTag.Recipe
        lbMcNo.Text = CellConTag.MCNo
        lbOPID.Text = CellConTag.OPID
        lbInputTotal.Text = CellConTag.INPUTQty
        lbStartTime.Text = CellConTag.LotStartTime
        lbEndTime.Text = CellConTag.LotEndTime


        lbWaferLotNo.Text = CellConTag.WaferLotID
        lbWaferNo.Text = CellConTag.CurrentWaferID

    End Sub





#End Region


    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        HostRequestDownLoadToEq(TextBox2.Text)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        HostRequestUplaodToHost(TextBox2.Text)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        '  SendRemoteCommand("PPSELECT", "PPID", "8OF_BT-130E-KL")
        'Dim S1F17 As New S1F17TEST
        'RaiseEvent E_HostSend(S1F17)
        'Reload()
        MakeAlarmCellCon("ooo")

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        LotRequest()
    End Sub

    Private Sub ProcessForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        rs.ResizeAllControls(Me)
        If TimerResize1.Enabled = False Then
            TimerResize1.Start()
        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If lbDCEndTime.Text = "" AndAlso lbDCStartTime.Text <> "" Then
            Exit Sub 'running
        End If
        Dim frmInputQR As FormInputQRCode = New FormInputQRCode ' New FormInputQRCode(Me)
        RaiseEvent MessageFrmMain("Please Read DC Slip QR Data")

        If frmInputQR.ShowDialog() = DialogResult.OK Then
            Dim rowNum As Integer
            rowNum = 0
            For Each data As DataRow In frmInputQR.m_BGTable
                '  MsgBox(data.Item(2))
                Dim frmInputData As FormInputData = New FormInputData
                Dim EndLot As Boolean = False
                If rowNum = frmInputQR.m_BGTable.Count - 1 Then
                    EndLot = True
                End If
                frmInputData.GetBGDatatable(frmInputQR.m_BGTable, frmInputQR.m_OPNo, (frmInputQR.m_BGTable.Count - 1 - rowNum), EndLot, False)
                frmInputData.ShowDialog()
                rowNum += 1
            Next
            RaiseEvent MessageFrmMain("Input Success")
            Try
                m_EmsClient.SetCurrentLot(My.Settings.EquipmentNo, lbDCWFLotNo.Text, 0)
                m_EmsClient.SetActivity(My.Settings.EquipmentNo, "Running", TmeCategory.NetOperationTime)
            Catch ex As Exception
                SaveLog(Message.Cellcon, "SetActivity Running:" & ex.ToString)
            End Try
        End If
        BGDataTableAdapter.Fill(DBxDataSet.BGData, My.Settings.HeaderProcess & My.Settings.EquipmentNo)
        '  DataGridView2.DataSource = DBxDataSet.BGData
        ' Loaddata()
        ' Timer1.Start()
        'If Not QRWorkingSlipInputInitailCheck(True) Then      'Check Before Input
        '    Exit Sub
        'End If

        ''Dim TypeOfLanguage = New System.Globalization.CultureInfo("en")                        'Change keyboard to Eng keyboard
        ''InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)

        'If OprData.QrReadSystemOn Then

        '    lbOPID.Text = ""
        '    lbInputTotal.Text = ""
        '    RaiseEvent E_HelperCall("tbOther")   '170224 \783 Helper form addition

        'Else
        '    RaiseEvent E_SlInfo("QrReadSystemOn Config is OFF ")
        'End If

        ''rs.ResizeAllControls(Me)
        'EMS monitor

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerResize1.Tick

        rs.ResizeAllControls(Me)
        TimerResize1.Stop()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        '  MsgBox(CassetteStatus.ToString)
        EndLot()
    End Sub
    Private Sub EndLot()
        If lbDCStartTime.Text = "" Or lbDCEndTime.Text <> "" Then
            Exit Sub
        End If

        Dim frmInputINS As Inspection = New Inspection ' New FormInputQRCode(Me)
        Dim rowNum As Integer
        rowNum = 0
        For Each data As DataRow In DBxDataSet.BGData
            '  MsgBox(data.Item(2))

            Dim EndLot As Boolean = False
            If rowNum = DBxDataSet.BGData.Count - 1 Then
                EndLot = True
            End If
            frmInputINS.GetBGDatatable(DBxDataSet.BGData, rowNum, EndLot)
            frmInputINS.ShowDialog()
            '  frmInputData.GetBGDatatable(DBxDataSet.BGData, frmInputQR., rowNum, EndLot)
            rowNum += 1
        Next
        Dim frmInputQR As FormInputQRCode = New FormInputQRCode
        frmInputQR.GetBGDatatableEnd(frmInputINS.m_BGDataTable, True)
        frmInputQR.Label1.Text = "สแกน OP No."
        frmInputQR.Label2.Text = ""
        frmInputQR.DataGridView1.Visible = False
        frmInputQR.ShowDialog()
        CassetteStatus = EquipmentCassetteStatus.NoCassette
        'EMS end 
        Try
            m_EmsClient.SetOutput(My.Settings.EquipmentNo, 0, 0) '        m_EmsClient.SetOutput("MCNO", "Good", "Input" - "Good")
            m_EmsClient.SetLotEnd(My.Settings.EquipmentNo) 'LA-01
            m_EmsClient.SetActivity(My.Settings.EquipmentNo, "Stop", TmeCategory.StopLoss)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop:" & ex.ToString)
        End Try
    End Sub
    Public Enum Message
        Send
        Rcv
        Cellcon
    End Enum
    Public Sub SaveLog(ByVal MessageStatus As Integer, ByVal txt As String)

        If Not System.IO.File.Exists(My.Application.Info.DirectoryPath & "\EMS") Then
            System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\EMS")
        End If

        Dim file_Log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\LogFile.txt", True)
        If MessageStatus = Message.Send Then
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> Send >> " & txt)
        ElseIf MessageStatus = Message.Rcv Then
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> Rcv >> " & txt)
        Else
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & " >> " & txt)
        End If

        file_Log.Close()
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

        itemToolMenu()
    End Sub
    Private Sub itemToolMenu()
        If My.Settings.PersonAuthorization = True Then
            ONToolStripMenuItem.Checked = True
            OFFToolStripMenuItem.Checked = False
        Else
            ONToolStripMenuItem.Checked = False
            OFFToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItem.Click
        My.Settings.PersonAuthorization = True
        My.Settings.Save()
        itemToolMenu()
    End Sub

    Private Sub OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.Click
        My.Settings.PersonAuthorization = False
        My.Settings.Save()
        itemToolMenu()
    End Sub

    Private Sub TDCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TDCToolStripMenuItem.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/apcscontrolsystem/", AppWinStyle.NormalFocus)
    End Sub


    Private Sub S1F3GetCassette()
        Dim S1F3 As New S1F3
        S1F3.AddSvid(12)
        S1F3.AddSvid(13)


        RaiseEvent E_HostSend(S1F3)
    End Sub
#Region "Reply Secs"

    Public Sub ReplyS1F3(ByVal SVIDVal As List(Of String))  'Return List of SVID Value


        For i = 0 To SVIDVal.Count - 1

            If lbMCLeftCassette.Text = "Left" Then
                lbMCLeftCassette.Text = CType(SVIDVal(i), EquipmentCassette).ToString
                Continue For
            End If
            If lbMCRightCassette.Text = "Right" Then
                lbMCRightCassette.Text = CType(SVIDVal(i), EquipmentCassette).ToString
                Continue For
            End If
            'If tbxSVID3.Text <> "" And lbSVID3Reply.Text = "Reply : " Then
            '    lbSVID3Reply.Text = "Reply : " & SVIDVal(i)
            '    Continue For
            'End If
        Next



    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SendRemoteCommand("BUZZER_RESET")
        '  RaiseEvent AlramShow(True, "", "", "0", False)
        'lbWaferLotNo.Text = "XYLC"
    End Sub

    Private Sub JudgementStandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JudgementStandToolStripMenuItem.Click
        Try
            Process.Start("D:\BG\BG Tape .pdf")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    'Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    '    m_Equipment.EQCassetteRightStatus = EquipmentCassette.NoCassette
    '    m_Equipment.EQCassetteLeftStatus = EquipmentCassette.CassetteEnd
    '    CheckEnd("19")
    'End Sub



#End Region



    'Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    '    SaveLog(1, "Message")
    'End Sub


End Class