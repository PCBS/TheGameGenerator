Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TheGameGenerator

<TestClass()> Public Class TestDatabase

    <TestMethod()> Public Sub CreateAnInstanceOfDatabase()
        Assert.IsNotNull(New TheGameGenerator.Database)
    End Sub

    <TestMethod()> Public Sub PC_RAMmodifier()
        Dim pc As New TheGameGenerator.PC(Nothing, Nothing, New List(Of veci), New List(Of veci), Nothing)
        pc.RAM.Add(New veci With {.vykon = 1})
        Assert.AreEqual(0.2, pc.RAMmodifier)
        pc.RAM.Add(New veci With {.vykon = 1})
        Assert.AreEqual(0.4, pc.RAMmodifier)
        pc.RAM.Add(New veci With {.vykon = 2})
        Assert.AreEqual(0.6, pc.RAMmodifier)
        pc.RAM.Add(New veci With {.vykon = 4})
        Assert.AreEqual(1.0, pc.RAMmodifier)
        'TODO: add test fo every value
    End Sub

    <TestMethod()> Public Sub TestMB_CPUPairs()
        Dim DB As New TheGameGenerator.Database
        Dim pairs = DB.GenerateMB_CPUPairs()
        Assert.AreEqual(77, pairs.Count, 0, "There are not exactly 77 MB-CPU pairs. Did the Database change?")
        For Each pair As veci() In pairs
            Assert.AreNotEqual("", pair(0).socket)
            Assert.AreNotEqual("", pair(1).socket)
            Assert.AreEqual(pair(0).socket, pair(1).socket, String.Format("Mismatched MB-CPU pair! id:{0} and id:{1} have differnet sockets!", pair(0).idveci, pair(1).idveci))
        Next
    End Sub

    <TestMethod()> Public Sub TestGPUsingles()
        Dim DB As New TheGameGenerator.Database
        Dim pairs = DB.GenerateGPUPairs(1)
        Assert.AreEqual(46, pairs.Count, 0, "There are not exactly 46 GPUs. Did the Database change?")
    End Sub

    <TestMethod()> Public Sub TestGPUall()
        Dim DB As New TheGameDB
        Dim Data As New TheGameGenerator.Database
        Dim count = Math.Pow(DB.vecis.Where(Function(v) v.typ = "gpu").Count, DB.vecis.Where(Function(v) v.typ = "mb").Max(Function(mb) CInt(mb.sloty.Split(";")(1))))
        Dim pairs = Data.GenerateGPUPairs(0)
        Assert.AreEqual(count, pairs.Count, 0, "There are not exactly " & count & " GPU pairs. Did the Database change?")
    End Sub

    <TestMethod()> Public Sub TestGenerateAllPCs()
        Dim Data As New TheGameGenerator.Database
        Assert.IsNotNull(Data.GenerateAllPCs())
    End Sub

End Class