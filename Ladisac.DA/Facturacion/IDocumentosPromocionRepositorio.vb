Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDocumentosPromocionRepositorio
        Function Maintenance(ByVal item As DocumentosPromocion) As Short
        Function DeleteRegistro(ByVal item As DocumentosPromocion, ByVal cDPR_NUMERO As String, ByVal cDPR_TIPO_PROMOCION As String) As Short
        Function spActualizarRegistro(ByVal Orm As DocumentosPromocion) As Short
        Function spInsertarRegistro(ByVal Orm As DocumentosPromocion) As Short
        Function spEliminarRegistro(ByVal Orm As DocumentosPromocion) As Short
    End Interface
End Namespace
