Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDocuIso

#Region "Mantenimientos"
        Sub MantenimientoDocuIso(ByVal mDocuIso As DocuIso)
#End Region

#Region "Querys"
        Function DocuIsoGetById(ByVal DIS_ID As Integer) As DocuIso
        Function ListaDocuIso() As String
        Function ListaDocuIsoVigente(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal PER_ID As String, ByVal ARE_DESCRIPCION As String) As List(Of DocuIso)
#End Region

    End Interface

End Namespace
