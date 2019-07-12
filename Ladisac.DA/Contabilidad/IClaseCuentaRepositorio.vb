Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IClaseCuentaRepositorio
        Function GetById(ByVal id As String) As ClaseCuenta
        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
    End Interface
End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface ICuentasContablesRepositorio
'        Function GetById(ByVal id As String) As CuentasContables
'        Function Mantenance(ByVal item As CuentasContables) As Boolean
'    End Interface

'End Namespace

