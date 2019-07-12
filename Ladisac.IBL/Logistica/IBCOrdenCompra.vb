Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenCompra

#Region "Mantenimientos"
        Function MantenimientoOrdenCompra(ByVal mOrdenCompra As OrdenCompra) As Integer
        Sub MantenimientoOrdenCompraDetalle(ByVal mOrdenCompraDetalle As OrdenCompraDetalle)
#End Region

#Region "Querys"
        Function OrdenCompraGetById(ByVal OCO_ID As Integer) As OrdenCompra
        Function OrdenCompraDetalleGetById(ByVal OCD_ID As Integer) As OrdenCompraDetalle
        Function ListaOrdenCompra() As String
        Function ImpresionOrdenCompra(ByVal OCO_ID) As String
        Function ListaOrdenCompraID(ByVal OCO_ID As Nullable(Of Integer)) As DataSet
        Function ListaProgramacionPagoProveedor(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Proveedor As String) As String
#End Region

    End Interface

End Namespace
