Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDocuIsoRepositorio
        Function GetById(ByVal DIS_Id As Integer) As DocuIso
        Sub Maintenance(ByVal DocuIso As DocuIso)
        Function ListaDocuIso() As String
        Function ListaDocuIsoXAreXDtdXNombre(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal Nombre As String) As List(Of DocuIso)
        Function ListaDocuIsoVigente(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal PER_ID As String, ByVal ARE_DESCRIPCION As String) As List(Of DocuIso)
    End Interface

End Namespace

