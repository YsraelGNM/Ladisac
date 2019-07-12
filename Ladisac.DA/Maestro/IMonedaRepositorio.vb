Imports Ladisac.BE
'
Namespace Ladisac.DA
    Public Interface IMonedaRepositorio
        Function GetById(ByVal id As String) As Moneda
        Function Maintenance(ByVal item As Moneda) As Short
        Sub ModificarDescription(ByVal Id As String, ByVal Description As String)
        Function ListaMoneda() As String
    End Interface
End Namespace




