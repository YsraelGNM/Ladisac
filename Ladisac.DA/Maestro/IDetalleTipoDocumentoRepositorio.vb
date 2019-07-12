Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IDetalleTipoDocumentoRepositorio
        Function Maintenance(ByVal item As DetalleTipoDocumentos) As Short
        Function DeleteRegistro(ByVal item As DetalleTipoDocumentos, ByVal cDTD_ID As String) As Short
        Function GetById(ByVal DTD_Id As String) As DetalleTipoDocumentos
        Function ListaDetalleTipoDocumento() As String
        Function ListaDetalleTipoDocumentoRendicion() As String
    End Interface
End Namespace

