Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IReparoTrabajadorRepositorio
        Function GetById(ByVal numero As String) As BE.ReparoTrabajador
        Function Maintenance(ByVal item As BE.ReparoTrabajador)
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IPermisosTrabajadorRepositorio
'        Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)

'    End Interface

'End Namespace
