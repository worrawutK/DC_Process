Imports XtraLibrary.SecsGem
Public Class S1F13E
    Inherits SecsMessageBase
    Private m_L2 As SecsItemList = New SecsItemList("L2")
    Dim m_DataMDLN As SecsItemAscii
    Dim m_DataSOFTREV As SecsItemAscii
    Public Sub New()
        MyBase.New(1, 13, False)
        AddItem(m_L2)
        m_DataMDLN = New SecsItemAscii("MDLN")
        m_L2.AddItem(m_DataMDLN)
        m_DataSOFTREV = New SecsItemAscii("SOFTREV")
        m_L2.AddItem(m_DataSOFTREV)
    End Sub
    Public ReadOnly Property MDLN() As String
        Get

            Return m_DataMDLN.Value
        End Get
    End Property
    Public ReadOnly Property SOFTREV() As String
        Get

            Return m_DataSOFTREV.Value
        End Get
    End Property
End Class
