Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IMaleconPuertaRepositorio
        Function GetById(ByVal MAL_Id As Integer) As MaleconPuerta
        Sub Maintenance(ByVal MaleconPuerta As MaleconPuerta)
        Function ListaMaleconPuerta() As String
    End Interface

End Namespace

