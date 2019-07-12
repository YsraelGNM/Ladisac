

Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ITiposBienesServiciosRepositorio

        Function GetById(ByVal id As String) As BE.TiposBienesServicios
        Function Mantenance(ByVal item As TiposBienesServicios) As Boolean

    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface
'End Namespace