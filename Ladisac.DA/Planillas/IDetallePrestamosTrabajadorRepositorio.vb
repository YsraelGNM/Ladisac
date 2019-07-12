Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetallePrestamosTrabajadorRepositorio

        Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador
        Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IDetalleTrabajadorJudicialRepositorio
'        Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String)
'        Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial)


'    End Interface
'End Namespace

