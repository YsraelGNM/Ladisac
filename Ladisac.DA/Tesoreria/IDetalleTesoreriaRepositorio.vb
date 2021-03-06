Imports Ladisac.BE
Namespace Ladisac.DA
    ''' <summary>
    ''' kkkk
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IDetalleTesoreriaRepositorio
        Function Maintenance(ByVal item As DetalleTesoreria) As Short
        Function DeleteRegistro(ByVal item As DetalleTesoreria, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTD_ID As String, ByVal cDTE_ITEM As String) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String,
           ByVal cCCC_ID As String,
           ByVal cCCT_ID As String,
           ByVal cDTE_SERIE As String,
           ByVal cDTE_NUMERO As String,
           ByVal cDTE_ITEM As Int16,
           ByVal cCCC_ID_CLI As String,
           ByVal cDTE_DESTINO As Int16,
           ByVal cCCO_ID As String,
           ByVal cCUC_ID As String,
           ByVal cPER_ID_CLI As String,
           ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String,
           ByVal cCCT_ID_DOC As String,
           ByVal cDTE_SERIE_DOC As String,
           ByVal cDTE_NUMERO_DOC As String,
           ByVal cDTE_FEC_VEN As DateTime,
           ByVal cMON_ID_DOC As String,
           ByVal cDTE_IMPORTE_DOC As Double,
           ByVal cDTE_CONTRAVALOR_DOC As Double,
           ByVal cPER_ID_CLI_1 As String,
           ByVal cTDO_ID_DOC_1 As String,
           ByVal cDTD_ID_DOC_1 As String,
           ByVal cCCT_ID_DOC_1 As String,
           ByVal cDTE_SERIE_DOC_1 As String,
           ByVal cDTE_NUMERO_DOC_1 As String,
           ByVal cDTE_FEC_VEN_1 As DateTime,
           ByVal cMON_ID_DOC_1 As String,
           ByVal cDTE_IMPORTE_DOC_1 As Double,
           ByVal cDTE_CONTRAVALOR_DOC_1 As Double,
           ByVal cDTE_OBSERVACIONES As String,
           ByVal cDTE_OPE_CONTABLE As Int16,
           ByVal cDTE_MOVIMIENTO As Int16,
           ByVal cDTE_TIPO_RECIBO As Int16,
           ByVal cDTE_CAPITAL_DOC As Double,
           ByVal cDTE_INTERES_DOC As Double,
           ByVal cDTE_GASTOS_DOC As Double,
           ByVal cDTD_IDe As String,
           ByVal cUSU_ID As String,
           ByVal cDTE_FEC_GRAB As DateTime,
           ByVal cDTE_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String,
           ByVal cCCC_ID As String,
           ByVal cCCT_ID As String,
           ByVal cDTE_SERIE As String,
           ByVal cDTE_NUMERO As String,
           ByVal cDTE_ITEM As Int16,
           ByVal cCCC_ID_CLI As String,
           ByVal cDTE_DESTINO As Int16,
           ByVal cCCO_ID As String,
           ByVal cCUC_ID As String,
           ByVal cPER_ID_CLI As String,
           ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String,
           ByVal cCCT_ID_DOC As String,
           ByVal cDTE_SERIE_DOC As String,
           ByVal cDTE_NUMERO_DOC As String,
           ByVal cDTE_FEC_VEN As DateTime,
           ByVal cMON_ID_DOC As String,
           ByVal cDTE_IMPORTE_DOC As Double,
           ByVal cDTE_CONTRAVALOR_DOC As Double,
           ByVal cPER_ID_CLI_1 As String,
           ByVal cTDO_ID_DOC_1 As String,
           ByVal cDTD_ID_DOC_1 As String,
           ByVal cCCT_ID_DOC_1 As String,
           ByVal cDTE_SERIE_DOC_1 As String,
           ByVal cDTE_NUMERO_DOC_1 As String,
           ByVal cDTE_FEC_VEN_1 As DateTime,
           ByVal cMON_ID_DOC_1 As String,
           ByVal cDTE_IMPORTE_DOC_1 As Double,
           ByVal cDTE_CONTRAVALOR_DOC_1 As Double,
           ByVal cDTE_OBSERVACIONES As String,
           ByVal cDTE_OPE_CONTABLE As Int16,
           ByVal cDTE_MOVIMIENTO As Int16,
           ByVal cDTE_TIPO_RECIBO As Int16,
           ByVal cDTE_CAPITAL_DOC As Double,
           ByVal cDTE_INTERES_DOC As Double,
           ByVal cDTE_GASTOS_DOC As Double,
           ByVal cDTD_IDe As String,
           ByVal cUSU_ID As String,
           ByVal cDTE_FEC_GRAB As DateTime,
           ByVal cDTE_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cDTE_SERIE As String, _
                                    ByVal cDTE_NUMERO As String, _
                                    ByVal cDTE_ITEM As Int16) As Short
    End Interface
End Namespace
