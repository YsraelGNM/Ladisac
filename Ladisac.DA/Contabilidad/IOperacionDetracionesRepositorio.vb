Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IOperacionDetracionesRepositorio

        Function GetById(ByVal id As String) As BE.OperacionDetraciones
        Function Mantenance(ByVal item As BE.OperacionDetraciones) As Boolean

    End Interface

End Namespace
'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface

'End Namespace