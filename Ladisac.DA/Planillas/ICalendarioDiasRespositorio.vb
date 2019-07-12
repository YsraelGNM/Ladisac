Imports Ladisac.DA
Namespace Ladisac.DA
    Public Interface ICalendarioDiasRespositorio
        Function GetbyId(ByVal id As Date) As BE.CalendarioDias
        Function Mantenance(ByVal item As BE.CalendarioDias) As Boolean


    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IAreaTrabajosRepositorio
'        Function GetById(ByVal id As String) As AreaTrabajos
'        Function Mantenance(ByVal item As AreaTrabajos) As Boolean

'    End Interface

'End Namespace