Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCMarcaArticulo

#Region "Mantenimientos"
        Sub MantenimientoMarcaArticulo(ByVal mMarcaArticulo As MarcaArticulos)
#End Region

#Region "Querys"
        Function MarcaArticuloGetById(ByVal MAR_ID As String) As MarcaArticulos
        Function ListaMarcaArticulo() As String
#End Region

    End Interface

End Namespace
