Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CheckDB

    Private _testContext As TestContext
    Public Property TestContext() As TestContext
        Get
            Return _testContext
        End Get
        Set(ByVal value As TestContext)
            _testContext = value
        End Set
    End Property


    <DataSource("veci")> <TestMethod()> Public Sub TestVeci()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

    <DataSource("recepty")> <TestMethod()> Public Sub TestRecepty()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

    <DataSource("vyzkumy")> <TestMethod()> Public Sub TestVyzkumy()
        Assert.IsNotNull(TestContext.DataRow)
    End Sub

End Class