Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISituacionEspecialTrabajadorRepositorio

        Function GetById(ByVal id As String) As SituacionEspecialTrabajador
        Function Mantenance(ByVal item As SituacionEspecialTrabajador) As Boolean

    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IRegimenPensionarioRepositorio

'        Function GetById(ByVal id As String) As RegimenPensionario
'        Function Mantenance(ByVal item As RegimenPensionario) As Boolean

'    End Interface

'End Namespace