Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleDespachosRepositorio
        Function Maintenance(ByVal item As DetalleDespachos) As Short
        Function DeleteRegistro(ByVal item As DetalleDespachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDE_SERIE As String, ByVal cDDE_NUMERO As String, ByVal cDDE_ITEM As Int16) As Short
        Function spActualizarRegistro(ByVal Orm As DetalleDespachos) As Short
        Function spInsertarRegistro(ByVal Orm As DetalleDespachos) As Short
        Function spEliminarRegistro(ByVal Orm As DetalleDespachos) As Short
    End Interface
End Namespace
