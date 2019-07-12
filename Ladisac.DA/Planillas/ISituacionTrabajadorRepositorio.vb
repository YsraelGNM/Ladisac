Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ISituacionTrabajadorRepositorio

        Function GetById(ByVal id As String) As SituacionTrabajador
        Function ManTenance(ByVal item As SituacionTrabajador) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.DA

'    Public Interface ISituacionEspecialTrabajadorRepositorio

'        Function GetById(ByVal id As String) As SituacionEspecialTrabajador
'        Function Mantenance(ByVal item As SituacionEspecialTrabajador) As Boolean

'    End Interface

'End Namespace
