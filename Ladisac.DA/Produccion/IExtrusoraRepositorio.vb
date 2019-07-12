Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IExtrusoraRepositorio
        Function GetById(ByVal EXT_Id As Integer) As Extrusora
        Sub Maintenance(ByVal Extrusora As Extrusora)
        Function ListaExtrusora() As String
    End Interface

End Namespace

