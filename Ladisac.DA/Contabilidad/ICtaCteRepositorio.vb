Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface ICtaCteRepositorio


        Function GetById(ByVal id As String) As CtaCte
        Function Mantenance(ByVal item As CtaCte) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface
'End Namespace