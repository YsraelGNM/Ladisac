Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICortadoraRepositorio
        Function GetById(ByVal COR_Id As Integer) As Cortadora
        Sub Maintenance(ByVal Cortadora As Cortadora)
        Function ListaCortadora() As String
    End Interface

End Namespace

