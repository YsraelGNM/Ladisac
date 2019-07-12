Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IComedorRepositorio
        Function getById(ByVal numero As String) As BE.ComedorPLL
        Function Maintenance(ByVal item As ComedorPLL)
        Function MaintenanceDelete(ByVal item As BE.ComedorPLL)

    End Interface


End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IPermisosTrabajadorRepositorio
'        Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)

'    End Interface

'End Namespace