Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ICorrelativoTipoDocumentoRepositorio
        Function Maintenance(ByVal item As CorrelativoTipoDocumento) As Short

        Function spActualizarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short
        Function spInsertarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short
        Function spEliminarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short
    End Interface
End Namespace
