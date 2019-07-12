Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCProvisionCompras

#Region "Maintenance"

        Function Maintenance(ByVal item As BE.ProvisionCompras)
        Function MaintenanceDelete(ByVal item As BE.ProvisionCompras)
        Function spDetalleProvisionCompras(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal cuc_IdOld As String, ByVal cuc_Idnew As String)
#End Region
#Region "Consulta"


        Function ProvisionComprasQuery(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal nombre As String, ByVal tdo_Id As String, ByVal prc_Serie As String, ByVal prc_Numero As String)
        Function ProvisionDividendosQuery(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal nombre As String, ByVal tdo_Id As String, ByVal prc_Serie As String, ByVal prc_Numero As String)
        Function ProvisionComprasSeek(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String)
        Function ProvisionComprasTipoComprobantes(ByVal DTD_DESCRIPCION As String) As String
        Function ProvisionComprasTipoComprobantesDividendos(ByVal DTD_DESCRIPCION As String) As String

        Function PuntoVenta(ByVal descripcion As String) As String
        Function TipoVenta(ByVal descripcion As String) As String
        Function comprasQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String
        Function comprasservicioQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String
        Function comprasplanillaQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String
        Function comprasrendicionQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String

        Function comprasXRefQuery(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal dtd_Id As String, ByVal per_Id As String, Optional ByVal Serie As String = Nothing, Optional ByVal numero As String = Nothing)
        Function DocuMovimientoLogistica(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String) As String
        Function SPDocuMovimientoDetalleXML(ByVal DMO_ID As String)
        Function SPDocuMovimientoDetalleServicioXML(ByVal DMO_ID As String)
        Function SPDocuMovimientoDetallePlanillaXML(ByVal DMO_ID As String)
        Function SPDocuMovimientoDetalleRendicionXML(ByVal DMO_ID As String)

        Function SaldosKardexDocumentosXML(ByVal CCT_ID As String, ByVal CCC_ID As String, ByVal PER_ID_CLI As String, ByVal CCT_ID_REF As String, ByVal TDO_ID_REF As String, ByVal DTD_ID_REF As String, ByVal DOC_SERIE_REF As String, ByVal DOC_NUMERO_REF As String, ByVal Documento As String, Optional ByVal ProcesarAnticipoPorCobrar As Int16 = 1)
        Function spProvisionComprasImprime(ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal prd_Periodo_id As String)

#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCAsientosManuales
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.AsientosManuales)

'#End Region
'#Region "Consulta"
'        Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)
'        Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)

'#End Region
'    End Interface

'End Namespace