Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDocumentos
        Function Mantenimiento(ByVal Item As Documentos) As Short
        Function spActualizarDocumentosTIV_ID(ByVal Item As Documentos) As Short

        Function spActualizarDocumentosDOC_ESTADO(ByVal TDO_ID As String, _
                                                 ByVal DTD_ID As String,
                                                 ByVal DOC_SERIE As String,
                                                 ByVal DOC_NUMERO As String,
                                                 ByVal DOC_ESTADO As Int16) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String, _
                              ByVal cDTD_ID As String, _
                              ByVal cCCT_ID As String, _
                              ByVal cDOC_SERIE As String, _
                              ByVal cDOC_NUMERO As String, _
                              ByVal cDOC_ORDEN_COMPRA As String, _
                              ByVal cDOC_TIPO_ORDEN_COMPRA As Int16, _
                              ByVal cPER_ID_REC As String, _
                              ByVal cTDP_ID_REC As String, _
                              ByVal cDIR_ID_ENT_REC As String, _
                              ByVal cPVE_ID As String, _
                              ByVal cPVE_ID_DES As String, _
                              ByVal cMON_ID As String, _
                              ByVal cTIV_ID As String, _
                              ByVal cPER_ID_CLI As String, _
                              ByVal cTDP_ID_CLI As String, _
                              ByVal cPER_ID_CON As String, _
                              ByVal cDOC_FECHA_EMI As DateTime, _
                              ByVal cDOC_FECHA_ENT As DateTime, _
                              ByVal cDOC_FECHA_EXP As DateTime, _
                              ByVal cDIR_ID_FIS As String, _
                              ByVal cDIR_ID_DOM As String, _
                              ByVal cDIR_ID_ENT As String, _
                              ByVal cDIR_ID_COB As String, _
                              ByVal cPER_ID_VEN As String, _
                              ByVal cPER_ID_COB As String, _
                              ByVal cPER_ID_PRO As String, _
                              ByVal cPER_ID_GRU As String, _
                              ByVal cDOC_TIPO_LISTA As Int16, _
                              ByVal cDOC_MONTO_TOTAL As Double, _
                              ByVal cDOC_CONTRAVALOR As Double, _
                              ByVal cDOC_IGV_POR As Double, _
                              ByVal cDOC_ASIENTO As Boolean, _
                              ByVal cDOC_CIERRE As Int16, _
                              ByVal cFLE_ID As String, _
                              ByVal cDOC_MONTO_FLE As Double, _
                              ByVal cDOC_REQUIERE_GUIA As Boolean, _
                              ByVal cTDO_ID_AFE As String, _
                              ByVal cDTD_ID_AFE As String, _
                              ByVal cCCT_ID_AFE As String, _
                              ByVal cDOC_SERIE_AFE As String, _
                              ByVal cDOC_NUMERO_AFE As String, _
                              ByVal cDOC_MOT_EMI As Int16, _
                              ByVal cDOC_NOMBRE_RECEP As String, _
                              ByVal cDOC_DNI_RECEP As String, _
                              ByVal cDOC_FEC_RECEP As DateTime, _
                              ByVal cDOC_ENTREGADO As Boolean, _
                              ByVal cCAF_IX_NUMERO_PRO As String, _
                              ByVal cCAF_IX_ORDEN_COM As String, _
                              ByVal cLPR_ID As String, _
                              ByVal cUSU_ID As String, _
                              ByVal cDOC_FEC_GRAB As DateTime, _
                              ByVal cDOC_ESTADO As Int16, _
                              ByVal cDOC_MONTO_PERCEPCION As Double, _
                              ByVal cTDO_ID_GEN As String, _
                              ByVal cDTD_ID_GEN As String, _
                              ByVal cCCT_ID_GEN As String, _
                              ByVal cDOC_SERIE_GEN As String, _
                              ByVal cDOC_NUMERO_GEN As String, _
                              ByVal cDOC_OBSERVACIONES As String, _
                              ByVal cDOC_ATENCION As String, _
                              ByVal cDOC_HORA_INICIO As DateTime, _
                              ByVal cDOC_HORA_FIN As DateTime) As Short
        Function spInsertarRegistro(ByVal Orm As Documentos) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cDOC_SERIE As String, _
                                    ByVal cDOC_NUMERO As String) As Short
        Function GetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As Documentos

    End Interface
End Namespace
