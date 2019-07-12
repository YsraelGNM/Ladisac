Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCModeloArticulo

#Region "Mantenimientos"
        Sub MantenimientoModeloArticulo(ByVal mModeloArticulo As ModeloArticulos)
#End Region

#Region "Querys"
        Function ModeloArticuloGetById(ByVal MOD_ID As String) As ModeloArticulos
        Function ListaModeloArticulo() As String
#End Region

    End Interface

End Namespace
