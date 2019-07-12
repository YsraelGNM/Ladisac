Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IInventarioRepositorio
        Function GetById(ByVal INV_Id As Integer) As Inventario
        Function GetById_Fecha(ByVal Fecha As Date) As System.Linq.IQueryable(Of Inventario)
        Sub Maintenance(ByVal Inventario As Inventario)
        Function ListaInventario() As String
        Function ListaAInventariar(ByVal Fecha As Date, ByVal ALM_ID As Integer, ByVal UBI_ID As Integer) As String

        Sub MaintenanceMassive(ByVal colInventario As List(Of Inventario))
        Function AddToContext(ByVal context As Object, ByVal mInventario As Inventario, ByRef count As Integer, ByVal commitCount As Integer, ByVal recreateContext As Boolean) As Object
    End Interface

End Namespace

