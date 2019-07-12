Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDetalleDocumentosPromocion
        Function Mantenimiento(ByVal Item As DetalleDocumentosPromocion) As Short
        Function spActualizarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spInsertarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spEliminarRegistro(ByVal Orm As DetalleDocumentosPromocion) As Short
        Function spEliminarRegistroGeneral(ByVal Orm As DetalleDocumentosPromocion) As Short
    End Interface
End Namespace
