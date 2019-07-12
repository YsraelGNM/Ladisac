Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTipoVenta
        Function Mantenimiento(ByVal Item As TipoVenta) As Short
        Function TipoVentaGetById(ByVal TIV_ID As String) As TipoVenta
        Function ListaTipoVenta() As String
    End Interface
End Namespace
