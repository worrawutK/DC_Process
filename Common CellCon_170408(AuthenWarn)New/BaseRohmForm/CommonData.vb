Public Class CommonData
    Public Enum Level
        OP
        ADMIN
        ENGINEER
    End Enum
    Private _OPID As String
    Public Property OPID() As String
        Get
            Return _OPID
        End Get
        Set(ByVal value As String)
            _OPID = value

        End Set
    End Property
    'Private _LotID As String
    'Public Property LotID() As String
    '    Get
    '        Return _LotID
    '    End Get
    '    Set(ByVal value As String)
    '        _LotID = value

    '    End Set
    'End Property
    'Private _Package As String
    'Public Property Package() As String
    '    Get
    '        Return _Package
    '    End Get
    '    Set(ByVal value As String)
    '        _Package = value

    '    End Set
    'End Property

    'Private _Device As String
    'Public Property Device() As String
    '    Get
    '        Return _Device
    '    End Get
    '    Set(ByVal value As String)
    '        _Device = value

    '    End Set
    'End Property
   
    Private _WaferLotID As String = ""
    Public Property WaferLotID() As String
        Get
            Return _WaferLotID
        End Get
        Set(ByVal value As String)
            _WaferLotID = value

        End Set
    End Property
    'Private _WaferID As New List(Of String)
    'Public Property WaferID() As List(Of String)
    '    Get
    '        Return _WaferID
    '    End Get
    '    Set(ByVal value As List(Of String))
    '        _WaferID = value

    '    End Set
    'End Propert

    Private _WaferID As String = ""
    Public Property WaferID() As String
        Get
            Return _WaferID
        End Get
        Set(ByVal value As String)
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

    Private _UserID As String
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value

        End Set
    End Property
    Private _UserLoginResult As Boolean
    Public Property UserLoginResult() As Boolean
        Get
            Return _UserLoginResult
        End Get
        Set(ByVal value As Boolean)
            _UserLoginResult = value

        End Set
    End Property

    Private _UserLevel As Level
    Public Property UserLevel() As Level
        Get
            Return _UserLevel
        End Get
        Set(ByVal value As Level)
            _UserLevel = value

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

    Private _AutoMotiveLot As Boolean
    Public Property AutoMotiveLot() As Boolean
        Get
            Return _AutoMotiveLot
        End Get
        Set(ByVal value As Boolean)
            _AutoMotiveLot = value

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
    Private _CSConnect As String = "Disconnect"    '160627 \783 Eq Com revise
    Public Property CSConnect() As String
        Get
            Return _CSConnect
        End Get
        Set(ByVal value As String)
            _CSConnect = value

        End Set
    End Property
    Private _FRMProductAlive As Boolean
    Public Property FRMProductAlive() As Boolean
        Get
            Return _FRMProductAlive
        End Get
        Set(ByVal value As Boolean)
            _FRMProductAlive = value

        End Set
    End Property


    Private _FRMTcpIpClientTestAlive As Boolean
    Public Property FRMTcpIpClientTestAlive() As Boolean
        Get
            Return _FRMTcpIpClientTestAlive
        End Get
        Set(ByVal value As Boolean)
            _FRMTcpIpClientTestAlive = value

        End Set
    End Property

    Private _AlrmtimerCount As Integer
    Public Property AlrmtimerCount() As Integer
        Get
            Return _AlrmtimerCount
        End Get
        Set(ByVal value As Integer)
            _AlrmtimerCount = value

        End Set
    End Property

  

    Private _DisaTableFrmShow As Boolean
    Public Property DisaTableFrmShow() As Boolean
        Get
            Return _DisaTableFrmShow
        End Get
        Set(ByVal value As Boolean)
            _DisaTableFrmShow = value

        End Set
    End Property
    Private _QrReadSystemOn As Boolean
    Public Property QrReadSystemOn() As Boolean
        Get
            Return _QrReadSystemOn
        End Get
        Set(ByVal value As Boolean)
            _QrReadSystemOn = value

        End Set
    End Property
 

    Private _MachineLockByTDC As Boolean
    Public Property MachineLockByTDC() As Boolean
        Get
            Return _MachineLockByTDC
        End Get
        Set(ByVal value As Boolean)
            _MachineLockByTDC = value

        End Set
    End Property

    Private _tLib As Boolean = True             '160706 \783 NewSML Convert
    Public Property tLib() As Boolean
        Get
            Return _tLib
        End Get
        Set(ByVal value As Boolean)
            _tLib = value

        End Set
    End Property

    Private _PPIDMange As String                   '160727 RecipeBodyManage
    Public Property PPIDMange() As String
        Get
            Return _PPIDMange
        End Get
        Set(ByVal value As String)
            _PPIDMange = value

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
    Private _ReloadLot As String         '170330 \783 Reload File Addition
    Public Property ReloadLot As String
        Get
            Return _ReloadLot
        End Get
        Set(ByVal value As String)
            _ReloadLot = value

        End Set
    End Property
End Class
