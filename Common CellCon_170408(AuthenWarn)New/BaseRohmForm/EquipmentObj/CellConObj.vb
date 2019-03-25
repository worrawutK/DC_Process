
Public Class CellConObj          '160906 \783 Add Class


#Region "TDC Object ---------------"

    'Private _TDCEnable As Boolean
    'Public Property TDCEnable As Boolean
    '    Get
    '        Return _TDCEnable
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _TDCEnable = value
    '    End Set
    'End Property

    Private _Process As String
    Public Property Process() As String
        Get
            Return _Process
        End Get
        Set(ByVal value As String)
            _Process = value
        End Set
    End Property
    Private _MCNo As String
    Public Property MCNo() As String
        Get
            Return _MCNo
        End Get
        Set(ByVal value As String)
            _MCNo = value
        End Set
    End Property
    Private _LotStartTime As String
    Public Property LotStartTime() As String
        Get
            Return _LotStartTime
        End Get
        Set(ByVal value As String)
            _LotStartTime = value
        End Set
    End Property

    Private _LotEndTime As String
    Public Property LotEndTime() As String
        Get
            Return _LotEndTime
        End Get
        Set(ByVal value As String)
            _LotEndTime = value
        End Set
    End Property

    'Private _LRStatus As String
    'Public Property LRStatus() As String
    '    Get
    '        Return _LRStatus
    '    End Get
    '    Set(ByVal value As String)
    '        _LRStatus = value
    '    End Set
    'End Property

    Private _LRReply As String
    Public Property LRReply() As String
        Get
            Return _LRReply
        End Get
        Set(ByVal value As String)
            _LRReply = value
        End Set
    End Property

    'Private _LSStatus As String
    'Public Property LSStatus() As String
    '    Get
    '        Return _LSStatus
    '    End Get
    '    Set(ByVal value As String)
    '        _LSStatus = value
    '    End Set
    'End Property

    Private _LSReply As String
    Public Property LSReply() As String
        Get
            Return _LSReply
        End Get
        Set(ByVal value As String)
            _LSReply = value
        End Set
    End Property

    Private _LSMode As Integer
    Public Property LSMode() As Integer
        Get
            Return _LSMode
        End Get
        Set(ByVal value As Integer)
            _LSMode = value
        End Set
    End Property

    'Private _LEStatus As String
    'Public Property LEStatus() As String
    '    Get
    '        Return _LEStatus
    '    End Get
    '    Set(ByVal value As String)
    '        _LEStatus = value
    '    End Set
    'End Property

    Private _LEReply As String
    Public Property LEReply() As String
        Get
            Return _LEReply
        End Get
        Set(ByVal value As String)
            _LEReply = value
        End Set
    End Property

    Private _LEMode As Integer
    Public Property LEMode() As Integer
        Get
            Return _LEMode
        End Get
        Set(ByVal value As Integer)
            _LEMode = value
        End Set
    End Property


    Private _TotalGoodPcs As String = "0"         'Total Good
    Public Property TotalGoodPcs() As String
        Get
            Return _TotalGoodPcs
        End Get
        Set(ByVal value As String)
            _TotalGoodPcs = value
        End Set
    End Property

    Private _TotalNGPcs As String = "0"            'Total Ng
    Public Property TotalNGPcs() As String
        Get
            Return _TotalNGPcs
        End Get
        Set(ByVal value As String)
            _TotalNGPcs = value
        End Set
    End Property



    Private _GoodCat1 As String = "0"            '170105 \783 \Config SECSGEM ID
    Public Property GoodCat1() As String
        Get
            Return _GoodCat1
        End Get
        Set(ByVal value As String)
            _GoodCat1 = value
        End Set
    End Property

    Private _GoodCat2 As String = "0"         '170105 \783 \Config SECSGEM ID
    Public Property GoodCat2() As String
        Get
            Return _GoodCat2
        End Get
        Set(ByVal value As String)
            _GoodCat2 = value
        End Set
    End Property
    Private _NGbin1 As String = "0"              '170105 \783 \Config SECSGEM ID
    Public Property NGbin1() As String
        Get
            Return _NGbin1
        End Get
        Set(ByVal value As String)
            _NGbin1 = value
        End Set
    End Property
    Private _NGbin2 As String = "0"         '170105 \783 \Config SECSGEM ID
    Public Property NGbin2() As String
        Get
            Return _NGbin2
        End Get
        Set(ByVal value As String)
            _NGbin2 = value
        End Set
    End Property
    Private _NGbin3 As String = "0"          '170105 \783 \Config SECSGEM ID
    Public Property NGbin3() As String
        Get
            Return _NGbin3
        End Get
        Set(ByVal value As String)
            _NGbin3 = value
        End Set
    End Property
    Private _NGbin4 As String = "0"       '170105 \783 \Config SECSGEM ID
    Public Property NGbin4() As String
        Get
            Return _NGbin4
        End Get
        Set(ByVal value As String)
            _NGbin4 = value
        End Set
    End Property
    Private _NGbin5 As String = "0"         '170105 \783 \Config SECSGEM ID
    Public Property NGbin5() As String
        Get
            Return _NGbin5
        End Get
        Set(ByVal value As String)
            _NGbin5 = value
        End Set
    End Property
    Private _NGbin6 As String = "0"        '170105 \783 \Config SECSGEM ID
    Public Property NGbin6() As String
        Get
            Return _NGbin6
        End Get
        Set(ByVal value As String)
            _NGbin6 = value
        End Set
    End Property





    Private _LotID As String
    Public Property LotID() As String
        Get
            Return _LotID
        End Get
        Set(ByVal value As String)
            _LotID = value
        End Set
    End Property


    Private _Package As String
    Public Property Package() As String
        Get
            Return _Package
        End Get
        Set(ByVal value As String)
            _Package = value
        End Set
    End Property

    Private _DeviceName As String
    Public Property DeviceName() As String
        Get
            Return _DeviceName
        End Get
        Set(ByVal value As String)
            _DeviceName = value
        End Set
    End Property


    Private _OPID As String
    Public Property OPID() As String
        Get
            Return _OPID
        End Get
        Set(ByVal value As String)
            _OPID = value
        End Set
    End Property
#End Region   '     ========= TDC Object

    'Private _WaferID As String()
    'Public Property WaferID() As String()
    '    Get
    '        Return _WaferID
    '    End Get
    '    Set(ByVal value As String())
    '        _WaferID = value

    '    End Set
    'End Property
    Private _WaferLotID As String
    Public Property WaferLotID() As String
        Get
            Return _WaferLotID
        End Get
        Set(ByVal value As String)
            _WaferLotID = value

        End Set
    End Property
    Private _CurrentWaferID As String                            '170330 \783
    Public Property CurrentWaferID() As String
        Get
            Return _CurrentWaferID
        End Get
        Set(ByVal value As String)
            _CurrentWaferID = value

        End Set
    End Property


    Private _WaferID As New List(Of String)
    Public Property WaferID() As List(Of String)
        Get
            Return _WaferID
        End Get
        Set(ByVal value As List(Of String))
            _WaferID = value

        End Set
    End Property
    Private _recipe As String
    Public Property Recipe() As String
        Get
            Return _recipe
        End Get
        Set(ByVal value As String)
            _recipe = value

        End Set
    End Property


    Private _INPUTQty As String
    Public Property INPUTQty() As String
        Get
            Return _INPUTQty
        End Get
        Set(ByVal value As String)
            _INPUTQty = value
        End Set
    End Property
    Private _PermitCheckResult As String
    Public Property PermitCheckResult() As String
        Get
            Return _PermitCheckResult
        End Get
        Set(ByVal value As String)
            _PermitCheckResult = value
        End Set
    End Property
    Private _MagazineNo As String
    Public Property MagazineNo() As String
        Get
            Return _MagazineNo
        End Get
        Set(ByVal value As String)
            _MagazineNo = value
        End Set
    End Property

    Private _QrData As String
    Public Property QrData() As String
        Get
            Return _QrData
        End Get
        Set(ByVal value As String)
            _QrData = value

        End Set
    End Property

    Private _ReloadLot As String
    Public Property ReloadLot As String
        Get
            Return _ReloadLot
        End Get
        Set(ByVal value As String)
            _ReloadLot = value

        End Set
    End Property


End Class
