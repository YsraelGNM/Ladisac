﻿Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IGrupoTrabajoDiasDescansoRepositorio

        Function Maintenance(ByVal fechaInicio As Date, ByVal xml As String, ByVal USU_ID As String)

    End Interface
End Namespace




'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface IGrupoTrabajoRepositorio
'        Function GetById(ByVal perido As String, ByVal numero As String) As BE.GrupoTrabajo
'        Function Maintenance(ByVal item As BE.GrupoTrabajo)

'    End Interface


'End Namespace