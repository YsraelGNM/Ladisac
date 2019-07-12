Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IAreaRepositorio
        Function GetById(ByVal ARE_Id As Integer) As Area
        Sub Maintenance(ByVal Area As Area)
        Function ListaArea() As String
    End Interface

End Namespace

