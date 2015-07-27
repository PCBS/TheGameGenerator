Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TestDatabase

    <TestMethod()> Public Sub TestMethod1()
        Assert.IsNotNull(New TheGameGenerator.Database)
    End Sub

End Class