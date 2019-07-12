Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenCompraDetalleRepositorio
        Function GetById(ByVal OCD_Id As Integer) As OrdenCompraDetalle
        Sub Maintenance(ByVal OrdenCompraDetalle As OrdenCompraDetalle)
        Function ListaOrdenCompraDetalle() As String
    End Interface

End Namespace

