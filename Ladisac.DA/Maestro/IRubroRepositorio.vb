Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRubroRepositorio
        Function GetById(ByVal RUB_ID As Integer) As Rubro
        Sub Maintenance(ByVal Rubro As Rubro)
        Function ListaRubro() As String
    End Interface

End Namespace

