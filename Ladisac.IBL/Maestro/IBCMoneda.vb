Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCMoneda
        Function MantenimientoMoneda(ByVal Item As Moneda) As Short
        Sub MantenimientoMonedaDescripcion(ByVal id As String, ByVal descripcion As String)
        Function ListaMoneda() As String
    End Interface
End Namespace

