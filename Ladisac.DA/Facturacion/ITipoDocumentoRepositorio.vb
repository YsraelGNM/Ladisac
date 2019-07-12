Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ITipoDocumentoRepositorio
        Function Maintenance(ByVal item As TipoDocumentos) As Short
        Function GetById(ByVal TDO_Id As String) As TipoDocumentos
        Function ListaTipoDocumento() As String
    End Interface
End Namespace

