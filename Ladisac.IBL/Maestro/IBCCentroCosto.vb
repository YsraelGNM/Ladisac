Imports Ladisac.BE
Namespace Ladisac.Bl
    Public Interface IBCCentroCosto
#Region "Mantenimientos"

#End Region
#Region "Query"
        Function CentroCostoQuery(Optional ByVal Id As String = Nothing, Optional ByVal descripcion As String = Nothing)

#End Region

    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.BL

'    Public Interface IBCTipoVenta

'#Region "Mantenimientos"
'        Sub MantenimientoTipoVenta(ByVal mTipoVenta As TipoVenta)
'#End Region

'#Region "Querys"
'        Function TipoVentaGetById(ByVal TIV_ID As String) As TipoVenta
'        Function ListaTipoVenta() As String
'#End Region

'    End Interface

'End Namespace