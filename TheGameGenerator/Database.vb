Public Class Database
    Dim DB As New TheGameDB()
    Sub New()

    End Sub
    Public Function GetItemInfo(id As Integer) As veci
        Return DB.vecis.Find(id)
    End Function

    Public Function GetAllItems() As Entity.DbSet(Of veci)
        Return DB.vecis
    End Function

#Region "Generate Groups"
    Public Function GenerateMB_CPUPairs()
        Throw New NotImplementedException
    End Function
    Public Function GenerateGPUPairs()
        Throw New NotImplementedException
    End Function
    Public Function GenerateRAMPairs()
        Throw New NotImplementedException
    End Function
#End Region

End Class
Public Class PC
    Public MB As veci
    Public CPU As veci
    Public GPU As List(Of veci)
    Public RAM As List(Of veci)
    Public HDD As veci
    Public PSU As veci
    Private _vykon As Integer = -1
    Public ReadOnly Property Vykon() As Integer
        Get
            If _vykon = -1 Then
                _vykon = GetVykon()
            End If
            Return _vykon
        End Get
    End Property

    Public Sub AddBestPSU(DB As TheGameDB)
        Throw New NotImplementedException
    End Sub
    Private Function ResearchNeeded(DB As TheGameDB) As vyzkumy
        Throw New NotImplementedException
    End Function
    Sub New()
        Throw New NotImplementedException
    End Sub

    Private Function GetVykon() As Integer
        Throw New NotImplementedException
    End Function

End Class