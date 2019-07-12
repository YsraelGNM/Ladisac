Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDespachoSalidaDetalleRepositorio
        Function GetById(ByVal DSD_ID As Integer) As DespachoSalidaDetalle
        Sub Maintenance(ByVal DespachoSalidaDetalle As DespachoSalidaDetalle)
        Function ListaDespachoSalidaDetalle() As String
    End Interface

End Namespace

