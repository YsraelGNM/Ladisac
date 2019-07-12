Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCInventario

#Region "Mantenimientos"
        Sub MantenimientoInventario(ByVal mInventario As Inventario)
        Sub MantenimientoInventarioMassive(ByVal colInventario As List(Of Inventario))
#End Region

#Region "Querys"
        Function InventarioGetById(ByVal INV_ID As Integer) As Inventario
        Function InventarioGetById_Fecha(ByVal Fecha As Date) As System.Linq.IQueryable(Of Inventario)
        Function ListaInventario() As String
        Function ListaAInventariar(ByVal Fecha As Date, ByVal ALM_ID As Integer, ByVal UBI_ID As Integer) As String
#End Region

    End Interface

End Namespace
