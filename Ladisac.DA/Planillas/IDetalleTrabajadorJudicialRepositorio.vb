Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleTrabajadorJudicialRepositorio
        Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String)
        Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial)


    End Interface
End Namespace

