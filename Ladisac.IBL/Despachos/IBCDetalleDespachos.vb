Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDetalleDespachos
        Function Mantenimiento(ByVal Item As DetalleDespachos) As Short
        Function DeleteRegistro(ByVal item As DetalleDespachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDE_SERIE As String, ByVal cDDE_NUMERO As String, ByVal cDDE_ITEM As Int16) As Short

        Function spActualizarRegistro(ByVal Orm As DetalleDespachos) As Short
        Function spinsertarRegistro(ByVal Orm As DetalleDespachos) As Short
        Function spEliminarRegistro(ByVal Orm As DetalleDespachos) As Short

        Function ItemDetalleDespachos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDde_Serie As String, ByVal cDde_Numero As String) As Integer
    End Interface
End Namespace
