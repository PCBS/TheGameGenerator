Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TheGameGeneratorLib

<TestClass()> Public Class TestLib

    <TestMethod()> Public Sub LibraryExists()
        Assert.AreNotEqual(Nothing, New MainLib)
    End Sub

End Class