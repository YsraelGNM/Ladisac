Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IGrupoTrabajoRepositorio
        Function GetById(ByVal perido As String, ByVal numero As String) As BE.GrupoTrabajo
        Function Maintenance(ByVal item As BE.GrupoTrabajo)

    End Interface


End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface IDatosTrabajadorJudicialRepositorio
'        Function GetById(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As BE.DatosTrabajadorJudicial
'        Function Maintenance(ByVal item As DatosTrabajadorJudicial)

'    End Interface

'End Namespace

