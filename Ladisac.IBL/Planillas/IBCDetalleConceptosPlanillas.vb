Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDetalleConceptosPlanillas
#Region "Mantenimiento"
        Function Maintenance(ByVal item As DetalleConceptosPlanillas)
#End Region
#Region "Consulta"

        Function DetalleConceptosPlanillasQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String)
        Function DetalleConceptosPlanillasSeek(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String) As BE.DetalleConceptosPlanillas
        Function DetalleConceptosPlanillasDetalleQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal cop_Descripcion As String)
        Function DetalleConceptosPlanillasListaQuery(ByVal tit_TipoTrab_Id As String, ByVal tip_Descripcion As String, ByVal concepto As String, Optional ByVal Es_judicial As Boolean = Nothing, Optional ByVal Es_Descuento As Boolean = Nothing)

        'SPDetalleConceptosPlanillasListaSelectXML
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
