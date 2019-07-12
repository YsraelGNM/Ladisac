
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDatosTrabajadorJudicial
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial)

#End Region
#Region "consulta"
        Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String)
        Function DatosTrabajadorJudicialSeek(ByVal serie As String, ByVal numero As String)

#End Region

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCNivelEducacion

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As NivelEducacion)
'#End Region

'#Region "Consulta"
'        Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String)
'        Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion

'#End Region

'    End Interface

'End Namespace