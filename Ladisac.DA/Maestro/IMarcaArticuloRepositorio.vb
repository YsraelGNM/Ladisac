Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IMarcaArticuloRepositorio
        Function GetById(ByVal MAR_Id As String) As MarcaArticulos
        Sub Maintenance(ByVal Marca As MarcaArticulos)
        Function ListaMarca() As String
    End Interface

End Namespace

