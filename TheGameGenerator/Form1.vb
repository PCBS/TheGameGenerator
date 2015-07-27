Public Class Form1
    Dim DB As New TheGameDB()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(DB.vecis.First.nazev)
    End Sub
End Class
