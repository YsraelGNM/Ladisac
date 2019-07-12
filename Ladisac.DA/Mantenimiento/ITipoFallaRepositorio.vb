Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoFallaRepositorio
        Function GetById(ByVal TFA_Id As Integer) As TipoFalla
        Sub Maintenance(ByVal TipoFalla As TipoFalla)
        Function ListaTipoFalla() As String
    End Interface

End Namespace

