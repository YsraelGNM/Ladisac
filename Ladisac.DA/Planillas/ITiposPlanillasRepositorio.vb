Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITiposPlanillasRepositorio
        Function GetById(ByVal id As String) As TiposPlanillas
        Function Mantenance(ByVal item As TiposPlanillas)
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface ITiposContratosRepositorio
'        Function GetById(ByVal id As String) As TiposContratos
'        Sub Mantenance(ByVal item As TiposContratos)
'    End Interface
'End Namespace

