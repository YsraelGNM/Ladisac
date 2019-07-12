Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleGrupoTrabajoRepositorio

        Function GetById(ByVal pedido As String, ByVal numero As String, ByVal items As String) As BE.DetalleGrupoTrabajo
        Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IDetalleTrabajadorJudicialRepositorio
'        Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String)
'        Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial)


'    End Interface
'End Namespace