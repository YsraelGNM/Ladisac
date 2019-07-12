Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenRequerimientoDetalleRepositorio
        Function GetById(ByVal ORD_Id As Integer) As OrdenRequerimientoDetalle
        Sub Maintenance(ByVal OrdenRequerimientoDetalle As OrdenRequerimientoDetalle)
        Function ListaOrdenRequerimientoDetalle() As String
    End Interface

End Namespace

