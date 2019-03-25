Public Class AlarmTable
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Me.Dock = DockStyle.None
        Me.WindowState = FormWindowState.Minimized  '160624 Fix Display
        Timer1.Stop()
        Timer1.Enabled = False
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Form1_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate

        Me.Dock = DockStyle.None
        Me.WindowState = FormWindowState.Minimized
        '  Me.WindowState = FormWindowState.Minimized
        Timer1.Enabled = False
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
    'Public Delegate Sub AlarmTableDelegate(ByVal ALCD As Boolean, ByVal ALID As String, ByVal ALTX As String, ByVal AlarmType As String)
    'Private Sub MessageAlarm(ByVal ALCD As Boolean, ByVal ALID As String, ByVal ALTX As String, Optional ByVal AlarmType As String = "0")
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New AlarmTableDelegate(AddressOf MessageAlarm), ALCD, ALID, ALTX, AlarmType)
    '    Else

    '    End If
    'End Sub

    'Private Sub AlarmTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DBxDataSet.DCAlarmInfo' table. You can move, or remove it, as needed.
    '    '  Me.DCAlarmInfoTableAdapter.Fill(Me.DBxDataSet.DCAlarmInfo)

    'End Sub

    'Public Sub AddAlarm(ByVal ALCD As Boolean, ByVal ALID As String, ByVal ALTX As String, ByVal AlarmType As String, WaferFabLotNo As String, WaferNo As String, Optional update As Boolean = False)
    '    If update = True Then
    '        If ALCD Then

    '            Dim AlarmID As Integer? = GetAlarmIDAdapter1.SearchAlarmID(My.Settings.MCType, CInt(ALID))
    '            If AlarmID Is Nothing Then
    '                'not Alarm
    '                Exit Sub
    '            End If

    '            Dim Row As DBxDataSet.DCAlarmInfoRow = DBxDataSet.DCAlarmInfo.NewDCAlarmInfoRow
    '            Row.AlarmID = CInt(AlarmID)
    '            Row.WaferFabLotNo = WaferFabLotNo
    '            Row.WaferNo = WaferNo
    '            Row.RecordTime = CDate(Format(Now, "yyyy-MM-dd HH:mm:ss"))
    '            Row.MCNo = My.Settings.EquipmentNo
    '            Row.AlarmMessage = ALTX
    '            DBxDataSet.DCAlarmInfo.AddDCAlarmInfoRow(Row)
    '        Else
    '            For Each data As DBxDataSet.DCAlarmInfoRow In DBxDataSet.DCAlarmInfo
    '                If data.WaferFabLotNo = WaferFabLotNo AndAlso data.WaferNo = WaferNo AndAlso data.IsClearTimeNull Then
    '                    data.ClearTime = CDate(Format(Now, "yyyy-MM-dd HH:mm:ss"))
    '                End If

    '            Next
    '        End If

    '        ' DCAlarmInfoTableAdapter.Update(DBxDataSet.DCAlarmInfo)
    '    End If

    'End Sub
End Class