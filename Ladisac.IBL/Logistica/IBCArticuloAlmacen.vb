Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCArticuloAlmacen

#Region "Mantenimientos"
        Sub MantenimientoArticuloAlmacen(ByVal mArticuloAlmacen As ArticuloAlmacen)
#End Region

#Region "Querys"
        Function ArticuloAlmacenGetById(ByVal ARA_ID As Integer) As ArticuloAlmacen
        Function ArticuloAlmacenGetById(ByVal Art_Id As String, ByVal ALM_Id As Integer) As ArticuloAlmacen
        Function ListaArticuloAlmacen(ByVal Art_Id As String, ByVal ALM_Id As Nullable(Of Integer))
        Function ListaArticuloAlmacenPermitido(ByVal Art_Id As String, ByVal ALM_Id As Nullable(Of Integer))
        Function TotalStock(ByVal Art_Id As String) As Decimal
#End Region

    End Interface

End Namespace
