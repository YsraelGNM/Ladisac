Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTiposPlanillas

#Region "Mantenimiento"
        Function Maintenance(ByVal item As TiposPlanillas)

#End Region

#Region "Consulta"

        Function TiposPlanillasQuery(ByVal tip_TipoPlan_Id As String, ByVal tip_Descripcion As String)
        Function TiposPlanillasSeek(ByVal id As String) As BE.TiposPlanillas

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
