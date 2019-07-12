Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IPeriodoLaboralRepositorio

        Function getById(ByVal per_Id As String, ByVal ItemPeriodoLaboral As String)
        Function Maintenance(ByVal item As PeriodoLaboral)
    End Interface
End Namespace





'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface ICronogramaVacacionesRepositorio

'        Function getById(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As CronogramaVacaciones
'        Function Mantenace(ByVal item As BE.CronogramaVacaciones) As Boolean

'    End Interface
'End Namespace
