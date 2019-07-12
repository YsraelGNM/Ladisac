Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoManttoRepositorio
        Function GetById(ByVal TMO_Id As Integer) As TipoMantto
        Sub Maintenance(ByVal TipoMantto As TipoMantto)
        Function ListaTipoMantto() As String
    End Interface

End Namespace

