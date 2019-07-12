Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ITipoVentaRepositorio
        Function Maintenance(ByVal item As TipoVenta) As Short
        Function GetById(ByVal TIV_Id As String) As TipoVenta
        Function ListaTipoVenta() As String
    End Interface
End Namespace
