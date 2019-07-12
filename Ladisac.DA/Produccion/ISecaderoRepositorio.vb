Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISecaderoRepositorio
        Function GetById(ByVal SEC_Id As Integer) As Secadero
        Sub Maintenance(ByVal Secadero As Secadero)
        Function ListaSecadero() As String
    End Interface

End Namespace

