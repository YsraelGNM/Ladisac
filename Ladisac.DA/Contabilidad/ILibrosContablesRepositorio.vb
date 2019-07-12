Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ILibrosContablesRepositorio
        Function GetById(ByVal id As String) As LibrosContables
        Function Mantenance(ByVal item As LibrosContables) As Boolean


    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface
'End Namespace
