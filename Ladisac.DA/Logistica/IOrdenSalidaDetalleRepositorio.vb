Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenSalidaDetalleRepositorio
        Function GetById(ByVal OSD_Id As Integer) As OrdenSalidaDetalle
        Sub Maintenance(ByVal OrdenSalidaDetalle As OrdenSalidaDetalle)
        Function ListaOrdenSalidaDetalle() As String
    End Interface

End Namespace

