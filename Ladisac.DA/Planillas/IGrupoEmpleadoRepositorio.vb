Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IGrupoEmpleadoRepositorio

        Function GetById(ByVal periodo As String, ByVal numero As String) As BE.GrupoEmpleado
        Function Maintenance(ByVal item As BE.GrupoEmpleado)

    End Interface

End Namespace



'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface IGrupoTrabajoRepositorio
'        Function GetById(ByVal perido As String, ByVal numero As String) As BE.GrupoTrabajo
'        Function Maintenance(ByVal item As BE.GrupoTrabajo)

'    End Interface


'End Namespace
