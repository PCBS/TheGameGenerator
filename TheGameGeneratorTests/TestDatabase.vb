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
        Assert.AreEqual(0, pairs.Count)
        For Each pair As veci() In pairs
            Assert.AreEqual(pair(0).socket, pair(1).socket)
        Next
    End Sub

End Class