Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCKardexCtaCte
        Function Mantenimiento(ByVal Item As KardexCtaCte) As Short
        Function SaldoDocumentoXML(ByVal Filtro As String) As String
        Function DeleteRegistro(ByVal item As KardexCtaCte, ByVal cDOCUMENTO As String, ByVal cITEM As Int16) As Short

        Function ItemKardexCtaCte(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String) As Integer
        Function ItemKardexCtaCteExtorno(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String) As Integer
        Function ItemKardexCtaCteDudosa(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String, ByVal cPER_ID_CLI As String) As Integer
        Function ItemKardexCtaCteLegal(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String, ByVal cPER_ID_CLI As String) As Integer

        Function spActualizarRegistro(ByVal cDOC_FECHA_EMI_REF As DateTime, _
            ByVal cDOC_FECHA_VEN_REF As DateTime, _
            ByVal cCUC_ID_REF As String, _
            ByVal cCCO_ID_REF As String, _
            ByVal cCCC_ID_REF As String, _
            ByVal cCCT_ID_REF As String, _
            ByVal cTDO_ID_REF As String, _
            ByVal cDTD_ID_REF As String, _
            ByVal cDOC_SERIE_REF As String, _
            ByVal cDOC_NUMERO_REF As String, _
            ByVal cITEM_REF As Int16, _
            ByVal cMON_ID_CCC As String, _
            ByVal cCCC_ID As String, _
            ByVal cCCT_ID As String, _
            ByVal cTDO_ID As String, _
            ByVal cDTD_ID As String, _
            ByVal cDOC_SERIE As String, _
            ByVal cDOC_NUMERO As String, _
            ByVal cITEM As Int16, _
            ByVal cMON_ID As String, _
            ByVal cPER_ID_CLI As String, _
            ByVal cCARGO As Double, _
            ByVal cABONO As Double, _
            ByVal cDTE_CONTRAVALOR_DOC As Double, _
            ByVal cMPT_MEDIO_PAGO As Int16, _
            ByVal cMPT_NUMERO_MEDIO As String, _
            ByVal cPER_ID_BAN As String, _
            ByVal cDOCUMENTO As String) As Short
        Function spInsertarRegistro(ByVal cDOC_FECHA_EMI_REF As DateTime, _
          ByVal cDOC_FECHA_VEN_REF As DateTime, _
          ByVal cCUC_ID_REF As String, _
          ByVal cCCO_ID_REF As String, _
          ByVal cCCC_ID_REF As String, _
          ByVal cCCT_ID_REF As String, _
          ByVal cTDO_ID_REF As String, _
          ByVal cDTD_ID_REF As String, _
          ByVal cDOC_SERIE_REF As String, _
          ByVal cDOC_NUMERO_REF As String, _
          ByVal cITEM_REF As Int16, _
          ByVal cMON_ID_CCC As String, _
          ByVal cCCC_ID As String, _
          ByVal cCCT_ID As String, _
          ByVal cTDO_ID As String, _
          ByVal cDTD_ID As String, _
          ByVal cDOC_SERIE As String, _
          ByVal cDOC_NUMERO As String, _
          ByVal cITEM As Int16, _
          ByVal cMON_ID As String, _
          ByVal cPER_ID_CLI As String, _
          ByVal cCARGO As Double, _
          ByVal cABONO As Double, _
          ByVal cDTE_CONTRAVALOR_DOC As Double, _
          ByVal cMPT_MEDIO_PAGO As Int16, _
          ByVal cMPT_NUMERO_MEDIO As String, _
          ByVal cPER_ID_BAN As String, _
          ByVal cDOCUMENTO As String) As Short
        Function spEliminarRegistro(ByVal cITEM As Int16, _
          ByVal cDOCUMENTO As String) As Short

        Function spEliminarRegistroExtorno(ByVal cITEM As Int16, _
          ByVal cDOCUMENTO As String) As Short


        Function spEliminarRegistroCobranza(ByVal cITEM As Int16, _
            ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short

        Function spEliminarRegistroLegal(ByVal cITEM As Int16, _
            ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short


        Function spEliminarRegistroVoucher(ByVal cITEM As Int16, _
                                           ByVal cCCC_ID As String, _
                                           ByVal cDOCUMENTO As String) As Short

        Function spSaldosTipoCliente(ByVal idTipoCliente As String, ByVal fechaHasta As Date)
        Function spDepositoTerceros(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal responsable As String, ByVal Banco As String, ByVal Cliente As String, ByVal DepositoTerceroNcargo As String)
        Function SpMovimientoCajaPorOrigen(ByVal fechaDesde As Date, ByVal fechaHasta As Date) '' movimienot de caja finanzas 
        Function SpMovimientoCajaPorOrigenDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date) '' movimiento de caja finanzas detalle
        Function spContraEntregaPendienteCancelar(ByVal desde As Date, ByVal hasta As Date, ByVal persona As String) 'reporte 
        Function spVentaDiariaFinanzas(ByVal fechaDesde As Date, ByVal fechaHasta As Date)
    End Interface
End Namespace
