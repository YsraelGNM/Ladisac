Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ITrabajadorHorasRepositorio
        Function GetById(ByVal tipo As String, ByVal numero As String)
        Function Maintenance(ByVal item As TrabajadorHoras)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IPermisosTrabajadorRepositorio
'        Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)

'    End Interface

'End Namespace
