Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IDetalleConceptoPensionarioRepositorio

        Function GetById(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As BE.DetalleConceptosPensionarios
        Function Mantenance(ByVal item As BE.DetalleConceptosPensionarios) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace