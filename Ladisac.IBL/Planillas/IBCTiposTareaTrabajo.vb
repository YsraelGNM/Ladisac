Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTiposTareaTrabajo

#Region "Mantenimiento"
        Function Maintenance(ByVal item As TiposTareaTrabajo)

#End Region
#Region "Consultas"
        Function TiposTareaTrabajoQuery(ByVal id As String, ByVal descripcion As String)
        Function TiposTareaTrabajoSeek(ByVal id As String) As TiposTareaTrabajo

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
