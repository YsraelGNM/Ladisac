Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDocumentoGuias

#Region "Mantenimientos"
        Sub MantenimientoDocumentoGuias(ByVal mDocumentoGuias As DocumentoGuias)
#End Region

#Region "Querys"
        Function DocumentoGuiasGetById(ByVal DGU_ID As Integer) As DocumentoGuias
        Function ListaDocumentoGuias() As String
        Function ListaGuiasTransportista(ByVal Per_Id As String, ByVal FecIni As Date, ByVal FecFin As Date) As String
#End Region

    End Interface

End Namespace
