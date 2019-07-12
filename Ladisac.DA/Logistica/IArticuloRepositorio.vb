Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IArticuloRepositorio
        Function GetById(ByVal ART_Id As String) As Articulos
        Sub Maintenance(ByVal Articulo As Articulos)
        Function ListaArticulo() As String
        Function ListaArticuloSumins(ByVal ART_Id As String) As DataSet
        Function ListaArticuloOrdenTrabajoSumins(ByVal ENO_ID As String, ByVal MTO_ID As String, ByVal ART_CODIGO As String) As DataSet
    End Interface

End Namespace

