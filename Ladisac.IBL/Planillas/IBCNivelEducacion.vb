Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCNivelEducacion

#Region "Mantenimiento"
        Function Maintenance(ByVal item As NivelEducacion)
#End Region

#Region "Consulta"
        Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String)
        Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion

#End Region

    End Interface

End Namespace

'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Interface IBCTiposContratos


'#Region "Mantenimiento"
'        Sub Maintenance(ByVal item As TiposContratos)
'#End Region

'#Region "Consulta"
'        Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String)
'        Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos
'#End Region

'    End Interface

'End Namespace
