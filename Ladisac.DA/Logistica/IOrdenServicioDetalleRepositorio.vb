Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenServicioDetalleRepositorio
        Function GetById(ByVal OSD_Id As Integer) As OrdenServicioDetalle
        Sub Maintenance(ByVal OrdenServicioDetalle As OrdenServicioDetalle)
        Function ListaOrdenServicioDetalle() As String
    End Interface

End Namespace

