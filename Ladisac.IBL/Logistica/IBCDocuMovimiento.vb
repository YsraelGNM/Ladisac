Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDocuMovimiento

#Region "Mantenimientos"
        Function MantenimientoDocuMovimiento(ByVal mDocuMovimiento As DocuMovimiento) As Integer
        Sub ActualizarIngresoTransformacion(ByVal TFO_ID As Nullable(Of Integer))
#End Region

#Region "Querys"
        Function DocuMovimientoGetById(ByVal DMO_ID As Integer) As DocuMovimiento
        Function DocuMovimientoDetalleGetById(ByVal DMD_ID As Integer) As DocuMovimientoDetalle
        Function ListaDocuMovimiento(ByVal Filtro As String) As DataSet
        Function TCCompraDia(ByVal MON_ID As String, ByVal Fecha As DateTime) As Decimal
        Function ListaSalidaXReq() As String
        Function ListadoIngresoxProveedor(ByVal PER_ID_PROVEEDOR As String, ByVal ART_ID As String, ByVal FAM_ID As String, ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String
        Function ListaGuiasFacturadas(ByVal ALM_ID As String, ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String
        Function ListaSalidaXReqXDocu(ByVal DMO_ID As Nullable(Of Integer)) As DataSet
        Function ListaIngresoXFacXDocu(ByVal DMO_ID As Nullable(Of Integer), ByVal ART_ID As String) As DataSet
        Function ListaLiquidacionMateriaPrima(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String
        Function Interfase_IngresoAlmacenProductoTerminado(ByVal DMO_ID As Integer) As String
        Function Interfase_PasarSpring(ByVal Fecha As Date, ByVal TipoTransaccion As String, ByVal Item As String) As String

#End Region

    End Interface

End Namespace
