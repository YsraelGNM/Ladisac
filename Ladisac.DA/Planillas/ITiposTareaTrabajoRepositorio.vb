Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ITiposTareaTrabajoRepositorio
        Function GetById(ByVal id As String) As TiposTareaTrabajo
        Function Mantenance(ByVal item As TiposTareaTrabajo) As Boolean

    End Interface

End Namespace


