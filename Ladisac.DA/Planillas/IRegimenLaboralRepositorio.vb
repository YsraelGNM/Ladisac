Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IRegimenLaboralRepositorio
        Function GetById(ByVal id As String) As RegimenLaboral
        Function Mantenance(ByVal item As RegimenLaboral) As Boolean
    End Interface
End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace