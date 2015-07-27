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

    <DataSource("veci")> <TestMethod()> Public Sub TestVeciValues()
        Assert.IsTrue(Integer.TryParse(TestContext.DataRow("idveci"), Nothing))
        Assert.IsFalse(TestContext.DataRow("nazev").ToString = "")
        Select Case TestContext.DataRow("typ")
            Case "mb"
                Assert.AreEqual(1, TestContext.DataRow("vykon"))
                Assert.AreEqual(0, TestContext.DataRow("spotreba"))
                Assert.AreNotEqual("", TestContext.DataRow("socket"), String.Format("Socket for MB id='{0}' nazev='{1}' is empty!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev")))
                Dim sloty() As String = TestContext.DataRow("sloty").ToString.Split(";")
                Assert.AreEqual(3, sloty.Count, String.Format("There are not exactly 3 types of slots in MB id='{0}' nazev='{1}', but {2} ({3})", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty.Count, TestContext.DataRow("sloty").ToString))
                Dim slotInt As UInteger
                Assert.IsTrue(Integer.TryParse(sloty(0), slotInt), String.Format("RAM slot count ({2}) in MB id='{0}' nazev='{1}' is not number!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(0)))
                Assert.AreNotEqual(0, CInt(slotInt), String.Format("RAM slot count ({2}) in MB id='{0}' nazev='{1}' can't be 0!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(0)))
                Assert.IsTrue(Integer.TryParse(sloty(1), slotInt), String.Format("GPU slot count ({2}) in MB id='{0}' nazev='{1}' is not number!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(1)))
                Assert.AreNotEqual(0, CInt(slotInt), String.Format("GPU slot count ({2}) in MB id='{0}' nazev='{1}' can't be 0!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(1)))
                Assert.IsTrue(Integer.TryParse(sloty(2), slotInt), String.Format("HDD/SSD slot count ({2}) in MB id='{0}' nazev='{1}' is not number!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(2)))
                Assert.AreNotEqual(0, CInt(slotInt), String.Format("HDD/SSD slot count ({2}) in MB id='{0}' nazev='{1}' can't be 0!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev"), sloty(2)))
            Case "cpu"
                Assert.IsTrue(TestContext.DataRow("vykon") Mod 25 = 0)
                Assert.IsTrue(TestContext.DataRow("spotreba") > 0)
                Assert.AreNotEqual("", TestContext.DataRow("socket"), String.Format("Socket for CPU id='{0}' nazev='{1}' is empty!", TestContext.DataRow("idveci"), TestContext.DataRow("nazev")))
                Assert.AreEqual("", TestContext.DataRow("sloty"))
                'TODO: pridat ostatni kontroly, prozatim spoleham ze databaze bude OK
            Case "gpu"
            Case "ram"
            Case "hdd"
            Case "psu"
            Case Else
        End Select
    End Sub

End Class