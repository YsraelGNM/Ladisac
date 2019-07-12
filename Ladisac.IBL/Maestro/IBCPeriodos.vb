Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCPeriodos

#Region "mantenimiento"
        Function Maintenance(ByVal items As Periodo)

#End Region

#Region "Consulta"
        Function PeriodoQuery(ByVal id As String)
        Function PeriodoSeek(ByVal id As String) As BE.Periodo

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
