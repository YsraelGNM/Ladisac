Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleDocumentosPromocionRepositorio
        Function Maintenance(ByVal item As DetalleDocumentosPromocion) As Short
        Function spActualizarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spInsertarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spEliminarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spEliminarRegistroGeneral(ByVal Orm As DetalleDocumentosPromocion) As Short
    End Interface
End Namespace
