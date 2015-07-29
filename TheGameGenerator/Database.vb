Imports Serilog
Public Class Database
    Implements IDisposable
    Dim DB As New TheGameDB()
    Sub New()

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Me.DB.Dispose()
    End Sub

    Public Function GetItemInfo(id As Integer) As veci
        Return DB.vecis.Find(id)
    End Function

    Public Function GetAllItems() As Entity.DbSet(Of veci)
        Return DB.vecis
    End Function

#Region "Generate Groups"
    Public Function GenerateMB_CPUPairs() As List(Of veci())
        Dim MB_CPU_pairs As New List(Of veci())
        Dim mbs As New List(Of veci)
        mbs.AddRange(DB.vecis.Where(Function(a) a.typ = "mb"))
        For Each _mb As veci In mbs
            Dim cpus As New List(Of veci)
            cpus.AddRange(DB.vecis.Where(Function(a) a.typ = "cpu" And a.socket = _mb.socket))
            For Each _cpu As veci In cpus
                Log.Debug("Selected pair MB: name:{MBname} socket:{MBsocket} with a CPU: name:{CPUname} socket:{CPUsocket}", _mb.nazev, _mb.socket, _cpu.nazev, _cpu.socket)
                Log.Verbose("Selected pair {@MB} with {@CPU}", _mb, _cpu)
                MB_CPU_pairs.Add({_mb, _cpu})
            Next
        Next
        Return MB_CPU_pairs
    End Function
    Public Function GenerateGPUPairs(maxGPUs As UInteger) As List(Of List(Of veci)) 'TODO: logging and paralell
        Select Case maxGPUs
            Case 0
                Return (GenerateGPUPairs(DB.vecis.Where(Function(v) v.typ = "mb").Max(Function(mb) CInt(mb.sloty.Split(";")(1)))))
            Case 1
                Dim groups As New List(Of List(Of veci))
                Dim gpus As New List(Of veci)
                gpus.AddRange(DB.vecis.Where(Function(a) a.typ = "gpu"))
                For Each gpu In gpus
                    Dim l As New List(Of veci)
                    l.Add(gpu)
                    groups.Add(l)
                Next
                Return groups
            Case Else
                Dim groups As New List(Of List(Of veci))
                For Each gpulist In GenerateGPUPairs(maxGPUs - 1)
                    For Each gpu In GenerateGPUPairs(1)
                        Dim l As New List(Of veci)
                        l.AddRange(gpulist)
                        l.AddRange(gpu)
                        groups.Add(l)
                    Next
                Next
                Return groups
        End Select
    End Function

    Public Function GenerateRAMPairs()
        Throw New NotImplementedException
    End Function

    Public Function GenerateAllPCs()
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

    Public ReadOnly Property RAMmodifier As Double
        Get
            Dim ramkap As Integer = RAM.Sum(Function(ram) ram.vykon)
            Select Case ramkap
                Case Is >= 64
                    Return 2.0
                Case Is >= 32
                    Return 1.8
                Case Is >= 24
                    Return 1.6
                Case Is >= 16
                    Return 1.4
                Case Is >= 12
                    Return 1.2
                Case Is >= 8
                    Return 1.0
                Case Is >= 6
                    Return 0.8
                Case Is >= 4
                    Return 0.6
                Case Is >= 2
                    Return 0.4
                Case Is >= 1
                    Return 0.2
                Case Else
                    Return 0
            End Select
        End Get
    End Property

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
        GPU = New List(Of veci)
        GPU.AddRange(_gpu)
        RAM = New List(Of veci)
        RAM.AddRange(_ram)
        HDD = _hdd
        Log.Information("Creating a PC ({@PC})", Me)
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
        GPU = New List(Of veci)
        GPU.AddRange(_gpu)
        RAM = New List(Of veci)
        RAM.AddRange(_ram)
        HDD = _hdd
        AddBestPSU(DB)
        Log.Information("Creating a PC ({@PC})", Me)
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
        GPU = New List(Of veci)
        GPU.AddRange(_gpu)
        RAM = New List(Of veci)
        RAM.AddRange(_ram)
        HDD = _hdd
        PSU = _psu
        Log.Information("Creating a PC ({@PC})", Me)
    End Sub

End Class
