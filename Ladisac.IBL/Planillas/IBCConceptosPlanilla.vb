Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCConceptosPlanilla

#Region "Mantenimiento"
        Function Mantenance(ByVal item As ConceptosPlanilla)
#End Region

#Region "Consulta"

        Function ConceptosPlanillasQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String)
        Function ConceptosPlanillaSeek(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As ConceptosPlanilla
        Function ConceptosPlanillasDetalleQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String)
        Function ConceptosXTipoPlanillaSelectXML(Optional ByVal tit_TipoTrab_Id As String = Nothing, Optional ByVal tip_TipoPlan_Id As String = Nothing, Optional ByVal ItemConceptoPlanilla As String = Nothing)

#End Region


    End Interface


End Namespace




'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Interface IBCSituacionTrabajador
'#Region "Mantenimientos"
'        Function Mantenance(ByVal item As SituacionTrabajador)
'#End Region
'#Region "Consulta"

'        Function SituacionTrabajadorQuery(ByVal sit_SituaTrab_Id As String, ByVal sit_Descripcion As String)
'        Function SituacionTrabajadorSeek(ByVal id As String) As SituacionTrabajador

'#End Region
'    End Interface

'End Namespace