Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICatsRepositorio
        Function GetById(ByVal CAT_Id As Integer) As Cats
        Sub Maintenance(ByVal Cats As Cats)
        Function ListaCat() As String
    End Interface

End Namespace

