Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IConceptosTrabajadorRepositorio
        Function GetById(ByVal per_Id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As ConceptosTrabajador
        Function Mantenance(ByVal item As BE.ConceptosTrabajador)

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface
'End Namespace