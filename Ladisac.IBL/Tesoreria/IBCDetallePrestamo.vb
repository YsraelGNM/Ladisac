Imports Ladisac.BE
Namespace Ladisac.BL
    ''iii
    Public Interface IBCDetallePrestamo
        Function Mantenimiento(ByVal Item As DetallePrestamo) As Short
        Function DeleteRegistro(ByVal item As DetallePrestamo, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String, ByVal cDPR_ITEM As String) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String, ByVal cMON_ID As String, ByVal cDPR_ITEM As Int16, ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime, ByVal cDPR_CAPITAL As Double, ByVal cDPR_INTERES As Double, ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double, ByVal cDPR_CONTRAVALOR As Double, ByVal cDPR_OBSERVACIONES As String, ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDPR_SERIE_DOC As String, ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String, ByVal cUSU_ID As String, ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String, ByVal cMON_ID As String, ByVal cDPR_ITEM As Int16, ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime, ByVal cDPR_CAPITAL As Double, ByVal cDPR_INTERES As Double, ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double, ByVal cDPR_CONTRAVALOR As Double, ByVal cDPR_OBSERVACIONES As String, ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDPR_SERIE_DOC As String, ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String, ByVal cUSU_ID As String, ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cDPR_SERIE As String, _
                                    ByVal cDPR_NUMERO As String, _
                                    ByVal cDPR_ITEM As Int16) As Short
        Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cDPR_SERIE As String, _
                                    ByVal cDPR_NUMERO As String) As Short
    End Interface
End Namespace
