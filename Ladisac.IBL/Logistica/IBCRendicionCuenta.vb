Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRendicionCuenta

#Region "Mantenimientos"
        Sub MantenimientoRendicionCuenta(ByVal mRendicionCuenta As RendicionCuenta)
        Sub MantenimientoRendicionCuentaDetalle(ByVal mRendicionCuentaDetalle As RendicionCuentaDetalle)
#End Region

#Region "Querys"
        Function RendicionCuentaGetById(ByVal REC_ID As Integer) As RendicionCuenta
        Function ListaRendicionCuentaConserge(ByVal USU_ID As String) As String
        Function ListaRendicionCuenta() As String
        Function RendicionCuentaDetalleGetById(ByVal PCD_ID As Integer) As RendicionCuentaDetalle
#End Region

    End Interface

End Namespace
