Imports Ladisac.BE
Namespace Ladisac.DA


    Public Interface IDatosLaboralesRepositorio

        Function GetById(ByVal per_Id As String) As BE.DatosLaborales
        Function Mantenance(ByVal item As BE.DatosLaborales) As Boolean
        Function GetByCodTrabajador(ByVal Codigo As String) As BE.DatosLaborales

    End Interface


End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IConceptosPlanillaRepositorio

'        Function GetById(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String) As BE.ConceptosPlanilla
'        Function Mantenance(ByVal item As ConceptosPlanilla) As Boolean


'    End Interface

'End Namespace
