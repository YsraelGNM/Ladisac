Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenDespachoDetalleRepositorio
        Function GetById(ByVal ODD_ID As Integer) As OrdenDespachoDetalle
        Sub Maintenance(ByVal OrdenDespachoDetalle As OrdenDespachoDetalle)
        Function ListaOrdenDespachoDetalle() As String
    End Interface

End Namespace

