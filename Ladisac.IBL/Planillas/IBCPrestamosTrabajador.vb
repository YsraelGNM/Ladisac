Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCPrestamosTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.PrestamosTrabajador)
#End Region

#Region "Consulta"
        Function PrestamosTrabajadorQuery(ByVal codigo As String, ByVal nombre As String)
        Function PrestamosTrabajadroSeek(ByVal serie As String, ByVal numero As String)
#End Region

    End Interface

End Namespace




'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCDatosTrabajadorJudicial
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial)

'#End Region
'#Region "consulta"
'        Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String)
'        Function DatosTrabajadorJudicialSeek(ByVal serie As String, ByVal numero As String)

'#End Region

'    End Interface

'End Namespace