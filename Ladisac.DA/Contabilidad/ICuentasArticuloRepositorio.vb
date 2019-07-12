Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ICuentasArticuloRepositorio
        Function GetById(ByVal id As String) As BE.CuentasArticulo
        Function Mantenance(ByVal item As CuentasArticulo) As Boolean
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface ILibrosContablesRepositorio
'        Function GetById(ByVal id As String) As LibrosContables
'        Function Mantenance(ByVal item As LibrosContables) As Boolean


'    End Interface

'End Namespace
