Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCAreaTrabajos

#Region "Mantenimiento"
        Function Maintenance(ByVal item As AreaTrabajos)

#End Region
#Region "Consulta"
        Function AreaTrabajosQuery(Optional ByVal id As String = Nothing, Optional ByVal nombre As String = Nothing, Optional ByVal art_EsPlanilla As Integer = Nothing)
        Function AreaTrabajoSeek(ByVal id As String) As BE.AreaTrabajos
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
