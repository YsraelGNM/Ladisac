﻿Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IDetalleGrupoMantenimientoRepositorio
        Function Maintenance(ByVal Item As BE.DetalleGrupoMantenimiento)

    End Interface
End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IDetalleGrupoTrabajoRepositorio

'        Function GetById(ByVal pedido As String, ByVal numero As String, ByVal items As String) As BE.DetalleGrupoTrabajo
'        Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo)

'    End Interface

'End Namespace