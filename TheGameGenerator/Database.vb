Public Class Database
    Dim DB As New TheGameDB()
    Sub New()

    End Sub
    Public Function GetItemInfo(id As Integer) As veci
        Return DB.vecis.Find(id)
    End Function
End Class
