
Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ITiposTrabajadorRepositorio
        Function GetById(ByVal id As String) As TiposTrabajador
        Function Mantenance(ByVal item As TiposTrabajador) As Boolean
    End Interface
End Namespace

