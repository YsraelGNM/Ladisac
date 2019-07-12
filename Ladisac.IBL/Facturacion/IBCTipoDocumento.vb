Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCTipoDocumento

#Region "Mantenimientos"
        Function Mantenimiento(ByVal Item As TipoDocumentos) As Short
#End Region

#Region "Querys"
        Function TipoDocumentoGetById(ByVal DTD_ID As String) As DetalleTipoDocumentos
        Function ListaDetalleTipoDocumento() As String
        Function ListaDetalleTipoDocumentoRendicion() As String
        Function ListaDetalleTipoDocumentoSalidaCombustible() As String
        Function ListaDetalleTipoDocumentoISO() As String
        Function ListaDetalleTipoDocumentoRecepcion() As String
        Function ListaDetalleTipoDocumentoCuentaRendir() As String
        Function ListaDetalleTipoDocumentoServicio() As String
#End Region

    End Interface

End Namespace
