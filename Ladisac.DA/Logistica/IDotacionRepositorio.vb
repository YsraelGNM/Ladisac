Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDotacionRepositorio
        Function GetById(ByVal DOT_Id As Integer) As Dotacion
        Sub Maintenance(ByVal Dotacion As Dotacion)
        Function ListaDotacion() As String
    End Interface

End Namespace

