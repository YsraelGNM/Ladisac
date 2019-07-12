Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IGrupoMantenimientoRepositorio

        Function GetById(ByVal periodo As String, ByVal numero As String) As BE.GrupoMantenimiento
        Function Maintenance(ByVal item As BE.GrupoMantenimiento)

    End Interface

End Namespace



'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface IGrupoTrabajoRepositorio
'        Function GetById(ByVal perido As String, ByVal numero As String) As BE.GrupoTrabajo
'        Function Maintenance(ByVal item As BE.GrupoTrabajo)

'    End Interface


'End Namespace
