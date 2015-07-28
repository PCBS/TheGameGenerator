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
    Public ReadOnly Property Vykon() As Integer
        Get
            Return Math.Min(CPU.vykon, GPUvykon) * 2 * RAMmodifier * HDDmodifier
        End Get
    End Property

    Private Property GPUvykon As Integer

    Private Property RAMmodifier As Integer

    Private Property HDDmodifier As Integer

    Public Sub AddBestPSU(DB As TheGameDB)
        Throw New NotImplementedException
    End Sub
    Private Function ResearchNeeded(DB As TheGameDB) As vyzkumy
        Throw New NotImplementedException
    End Function
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        Throw New NotImplementedException
    End Sub
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="_mb"></param>
    ''' <param name="_cpu"></param>
    ''' <param name="_gpu"></param>
    ''' <param name="_ram"></param>
    ''' <param name="_hdd"></param>
    ''' <remarks></remarks>
    Sub New(_mb As veci, _cpu As veci, _gpu As List(Of veci), _ram As List(Of veci), _hdd As veci)
        MB = _mb
        CPU = _cpu
        GPU.AddRange(_gpu)
        RAM.AddRange(_ram)
        HDD = _hdd
    End Sub
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="_mb"></param>
    ''' <param name="_cpu"></param>
    ''' <param name="_gpu"></param>
    ''' <param name="_ram"></param>
    ''' <param name="_hdd"></param>
    ''' <param name="DB"></param>
    ''' <remarks></remarks>
    Sub New(_mb As veci, _cpu As veci, _gpu As List(Of veci), _ram As List(Of veci), _hdd As veci, DB As TheGameDB)
        MB = _mb
        CPU = _cpu
        GPU.AddRange(_gpu)
        RAM.AddRange(_ram)
        HDD = _hdd
        AddBestPSU(DB)
    End Sub
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="_mb"></param>
    ''' <param name="_cpu"></param>
    ''' <param name="_gpu"></param>
    ''' <param name="_ram"></param>
    ''' <param name="_hdd"></param>
    ''' <param name="_psu"></param>
    ''' <remarks></remarks>
    Sub New(_mb As veci, _cpu As veci, _gpu As List(Of veci), _ram As List(Of veci), _hdd As veci, _psu As veci)
        MB = _mb
        CPU = _cpu
        GPU.AddRange(_gpu)
        RAM.AddRange(_ram)
        HDD = _hdd
        PSU = _psu
    End Sub

End Class