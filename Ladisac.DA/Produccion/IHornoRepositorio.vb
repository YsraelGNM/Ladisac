Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IHornoRepositorio
        Function GetById(ByVal HOR_Id As Integer) As Horno
        Sub Maintenance(ByVal Horno As Horno)
        Function ListaHorno() As String
    End Interface

End Namespace

