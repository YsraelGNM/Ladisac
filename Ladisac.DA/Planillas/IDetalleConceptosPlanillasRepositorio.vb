Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleConceptosPlanillasRepositorio

        Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, ByVal dcp_ItemDetConcPlan As String) As BE.DetalleConceptosPlanillas
        Function Mantenance(ByVal item As BE.DetalleConceptosPlanillas) As Boolean

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace
