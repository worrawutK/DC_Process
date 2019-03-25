<Serializable()> _
Public Class Equipment         '160906 \783 Revise
 

#Region "===   SVID   ==="
    Private m_CurrentPPID As String
    Public Property CurrentPPID() As String
        Get
            Return m_CurrentPPID
        End Get
        Set(ByVal value As String)
            m_CurrentPPID = value
        End Set
    End Property

    Private m_ControlState As ControlStateType
    Public Property ControlState() As ControlStateType
        Get
            Return m_ControlState
        End Get
        Set(ByVal value As ControlStateType)
            m_ControlState = value

        End Set
    End Property

    Private m_EQCassetteLeftStatus As EquipmentCassette
    Public Property EQCassetteLeftStatus() As EquipmentCassette
        Get
            Return m_EQCassetteLeftStatus
        End Get
        Set(ByVal value As EquipmentCassette)
            m_EQCassetteLeftStatus = value
        End Set
    End Property
    Private m_EQCassetteRightStatus As EquipmentCassette
    Public Property EQCassetteRightStatus() As EquipmentCassette
        Get
            Return m_EQCassetteRightStatus
        End Get
        Set(ByVal value As EquipmentCassette)
            m_EQCassetteRightStatus = value
        End Set
    End Property

    Private m_EQStatus As EquipmentState
    Public Property EQStatus() As EquipmentState
        Get
            Return m_EQStatus
        End Get
        Set(ByVal value As EquipmentState)
            m_EQStatus = value
        End Set
    End Property

    Private m_PreEQStatus As EquipmentState
    Public Property PreEQStatus() As EquipmentState
        Get
            Return m_PreEQStatus
        End Get
        Set(ByVal value As EquipmentState)
            m_PreEQStatus = value
        End Set
    End Property

    Private _LotID As String            '170105 \783 \Config SECSGEM ID
    Public Property LotID() As String
        Get
            Return _LotID
        End Get
        Set(ByVal value As String)
            _LotID = value
        End Set
    End Property
    Private _GoodPcs As String
    Public Property GoodPcs() As String
        Get
            Return _GoodPcs
        End Get
        Set(ByVal value As String)
            _GoodPcs = value
        End Set
    End Property

    Private _GoodCat1 As String             '170105 \783 \Config SECSGEM ID
    Public Property GoodCat1() As String
        Get
            Return _GoodCat1
        End Get
        Set(ByVal value As String)
            _GoodCat1 = value
        End Set
    End Property

    Private _GoodCat2 As String             '170105 \783 \Config SECSGEM ID
    Public Property GoodCat2() As String
        Get
            Return _GoodCat2
        End Get
        Set(ByVal value As String)
            _GoodCat2 = value
        End Set
    End Property
    Private _NGbin1 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin1() As String
        Get
            Return _NGbin1
        End Get
        Set(ByVal value As String)
            _NGbin1 = value
        End Set
    End Property
    Private _NGbin2 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin2() As String
        Get
            Return _NGbin2
        End Get
        Set(ByVal value As String)
            _NGbin2 = value
        End Set
    End Property
    Private _NGbin3 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin3() As String
        Get
            Return _NGbin3
        End Get
        Set(ByVal value As String)
            _NGbin3 = value
        End Set
    End Property
    Private _NGbin4 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin4() As String
        Get
            Return _NGbin4
        End Get
        Set(ByVal value As String)
            _NGbin4 = value
        End Set
    End Property
    Private _NGbin5 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin5() As String
        Get
            Return _NGbin5
        End Get
        Set(ByVal value As String)
            _NGbin5 = value
        End Set
    End Property
    Private _NGbin6 As String              '170105 \783 \Config SECSGEM ID
    Public Property NGbin6() As String
        Get
            Return _NGbin6
        End Get
        Set(ByVal value As String)
            _NGbin6 = value
        End Set
    End Property



    Private _NGPcs As String
    Public Property NGPcs() As String
        Get
            Return _NGPcs
        End Get
        Set(ByVal value As String)
            _NGPcs = value
        End Set
    End Property
    ' BG Tape-------------------;
    Private _Clock As String
    Public Property Clock() As String
        Get
            Return _Clock
        End Get
        Set(ByVal value As String)
            _Clock = value
        End Set
    End Property



    '==============================;
#End Region

#Region "===   ECID   ==="
    Private m_DeviceId As UShort
    Public Property DeviceId() As UShort
        Get
            Return m_DeviceId
        End Get
        Set(ByVal value As UShort)
            m_DeviceId = value
        End Set
    End Property


#End Region



End Class
