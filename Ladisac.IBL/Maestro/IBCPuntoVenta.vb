Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCPuntoVenta
        Function MantenimientoPuntoVenta(ByVal Item As PuntoVenta) As Short
        Function PuntoVentaGetById(ByVal PVE_ID As String) As PuntoVenta
        Function ListaPuntoVentaXUsu_Id(ByVal USU_ID As String) As String
    End Interface
End Namespace
