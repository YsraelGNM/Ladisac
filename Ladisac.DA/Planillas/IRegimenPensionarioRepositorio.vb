Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IRegimenPensionarioRepositorio

        Function GetById(ByVal id As String) As RegimenPensionario
        Function Mantenance(ByVal item As RegimenPensionario) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace
