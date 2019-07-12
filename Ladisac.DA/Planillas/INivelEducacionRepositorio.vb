Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface INivelEducacionRepositorio

        Function GetById(ByVal id As String) As NivelEducacion
        Function Mantenance(ByVal item As NivelEducacion) As Boolean

    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface ITiposContratosRepositorio
'        Function GetById(ByVal id As String) As TiposContratos
'        Sub Mantenance(ByVal item As TiposContratos)

'    End Interface

'End Namespace
