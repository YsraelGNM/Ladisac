Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCCorrelativoTipoDocumento
        Function Mantenimiento(ByVal Item As CorrelativoTipoDocumento) As Short
        Function spActualizarRegistroDespacho(ByVal Orm As CorrelativoTipoDocumento) As Short
        Function spActualizarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short
        Function spInsertarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short
        Function spEliminarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short

    End Interface
End Namespace
