
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IConceptosPlanillaRepositorio

        Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As BE.ConceptosPlanilla
        Function Mantenance(ByVal item As ConceptosPlanilla) As Boolean


    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface ISituacionTrabajadorRepositorio

'        Function GetById(ByVal id As String) As SituacionTrabajador
'        Function ManTenance(ByVal item As SituacionTrabajador) As Boolean

'    End Interface

'End Namespace

