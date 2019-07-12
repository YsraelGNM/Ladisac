Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCArticulo

#Region "Mantenimientos"
        Sub MantenimientoArticulo(ByVal mArticulo As Articulos)
#End Region

#Region "Querys"
        Function ArticuloGetById(ByVal ART_ID As String) As Articulos
        Function ListaArticulo() As String
        Function ListaArticuloOrdenTrabajo(ByVal ENO_ID As String, ByVal MTO_ID As String) As String
        Function ListaArticuloControlParada() As String
        Function ListaArticuloSumins(ByVal ART_Id As String) As DataSet
        Function ListaArticuloOrdenTrabajoSumins(ByVal ENO_ID As String, ByVal MTO_ID As String, ByVal ART_CODIGO As String) As DataSet
        Function ListaArticuloMateriaPrima() As String
        Function ListaArticuloMateriaPrimaMezcla() As String
        Function ListaArticuloServicio(ByVal ART_Codigo As String) As String
        Function ListaArticuloSucursal(ByVal ART_Codigo As String) As String

#End Region

    End Interface

End Namespace
