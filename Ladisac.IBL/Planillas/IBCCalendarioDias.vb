Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCCalendarioDias

#Region "mantenimiento"
        Function Maintenance(ByVal item As BE.CalendarioDias)

#End Region
#Region "Consulta"
        Function CalendarioDiasQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function CalendarioDiasSeek(ByVal id As Date)

#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCAreaTrabajos

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As AreaTrabajos)

'#End Region
'#Region "Consulta"
'        Function AreaTrabajosQuery(Optional ByVal id As String = Nothing, Optional ByVal nombre As String = Nothing)
'        Function AreaTrabajoSeek(ByVal id As String) As BE.AreaTrabajos
'#End Region
'    End Interface

'End Namespace
