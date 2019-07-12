Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCConfiguracionFormatos
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.ConfiguracionFormatos)
#End Region
#Region "Consultas"
        Function ConfiguracionFormatosQuery(ByVal descripcion As String)
        Function ConfiguracionFormatosSeek(ByVal id As String)
#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCCtaCte

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As CtaCte)
'#End Region

'#Region "Consulta"
'        Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String)
'        Function CtaCteSeek(ByVal id As String) As BE.CtaCte
'#End Region

'    End Interface

'End Namespace