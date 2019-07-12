Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ICuentasContablesRepositorio
        Function GetById(ByVal id As String) As CuentasContables
        Function Mantenance(ByVal item As CuentasContables) As Boolean
    End Interface

End Namespace



