Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDocuIsoDetalleRepositorio
        Function GetById(ByVal DID_Id As Integer) As DocuIsoDetalle
        Sub Maintenance(ByVal DocuIsoDetalle As DocuIsoDetalle)
        Function ListaDocuIsoDetalle() As String
    End Interface

End Namespace

