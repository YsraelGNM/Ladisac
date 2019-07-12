Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IPuntoVentaRepositorio
        Function Maintenance(ByVal item As PuntoVenta) As Short
        Function GetById(ByVal PVE_ID As String) As PuntoVenta
    End Interface
End Namespace
