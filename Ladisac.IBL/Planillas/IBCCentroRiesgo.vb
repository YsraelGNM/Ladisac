Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCCentroRiesgo
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.CentroRiesgo)
#End Region
#Region "Consulta"
        Function CentroRiesgoQuery(ByVal id As String, Optional ByVal descripcion As String = Nothing)
        Function CentroRiesgoSeek(ByVal id As String) As BE.CentroRiesgo

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
