Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CheckDB
    Dim DB As New TheGameGenerator.Database
    Private _testContext As TestContext
    Public Property TestContext() As TestContext
        Get
            Return _testContext
        End Get
        Set(ByVal value As TestContext)
            _testContext = value
        End Set
    End Property

#Region "CheckDatabaseNotNull"

    <DataSource("veci")> <TestMethod()> Public Sub TestVeciNotNull()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

    <DataSource("recepty")> <TestMethod()> Public Sub TestReceptyNotNull()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

    <DataSource("vyzkumy")> <TestMethod()> Public Sub TestVyzkumyNotNull()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

#End Region

    <DataSource("veci")> <TestMethod()> Public Sub TestVeci()
        Assert.AreEqual(TestContext.DataRow("nazev"), DB.GetItemInfo(TestContext.DataRow("idveci"))) 'TODO fix
    End Sub

End Class