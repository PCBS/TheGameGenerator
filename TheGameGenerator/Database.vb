Public Class Database
    Dim DB As New TheGameDB()
    Structure lists
        'TODO list of cpu a tak dal
    End Structure
    Sub New()

    End Sub
    Public Function GetItemInfo(id As Integer) As veci
        Return DB.vecis.Find(id)
    End Function

    Public Function BuildLists() As lists
        'todo vygenerovat listy a pak je vratit, volat metody na jednotlive listy
    End Function

End Class
