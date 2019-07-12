Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRendicionCuentaDetalleRepositorio
        Function GetById(ByVal RCD_ID As Integer) As RendicionCuentaDetalle
        Sub Maintenance(ByVal RendicionCuentaDetalle As RendicionCuentaDetalle)
        Function ListaRendicionCuentaDetalle() As String
    End Interface

End Namespace

