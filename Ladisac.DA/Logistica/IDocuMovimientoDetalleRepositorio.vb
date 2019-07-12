Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDocuMovimientoDetalleRepositorio
        Function GetById(ByVal DMD_Id As Integer) As DocuMovimientoDetalle
        Sub Maintenance(ByVal DocuMovimientoDetalle As DocuMovimientoDetalle)
        Function ListaDocuMovimientoDetalle() As String
    End Interface

End Namespace

