Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCTiposContratos


#Region "Mantenimiento"
        Sub Maintenance(ByVal item As TiposContratos)
#End Region

#Region "Consulta"
        Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String)
        Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos
#End Region

    End Interface

End Namespace

'Imports Ladisac.BE

'Namespace Ladisac.BL

'    Public Interface IBCConceptos

'#Region "Mantenimiento"

'        Sub Maintenance(ByVal item As Conceptos)

'#End Region

'#Region "Consulta"

'        Function ConceptosQuery(Optional ByVal con_Conceptos_Id As String = Nothing, Optional ByVal tic_TipoConcep_Id As String = Nothing, Optional ByVal con_Conceptoas As String = Nothing, Optional ByVal con_Descripcion As String = Nothing) As String
'        Function ConceptosSeek(ByVal conId As String) As BE.Conceptos

'#End Region
'    End Interface


'End Namespace
