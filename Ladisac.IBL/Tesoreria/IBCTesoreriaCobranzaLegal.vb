Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTesoreriaCobranzaLegal
        Function spActualizarRegistro(ByVal cTDO_ID As String, _
            ByVal cDTD_ID As String, _
            ByVal cCCT_ID As String, _
            ByVal cTCL_SERIE As String, _
            ByVal cTCL_NUMERO As String, _
            ByVal cTCL_FECHA_EMI As DateTime, _
            ByVal cPER_ID_CLI As String, _
            ByVal cMON_ID As String, _
            ByVal cTCL_MONTO As Decimal, _
            ByVal cUSU_ID As String, _
            ByVal cTCL_FEC_GRAB As DateTime, _
            ByVal cTCL_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCT_ID As String, _
           ByVal cTCL_SERIE As String, _
           ByVal cTCL_NUMERO As String, _
           ByVal cTCL_FECHA_EMI As DateTime, _
           ByVal cPER_ID_CLI As String, _
           ByVal cMON_ID As String, _
           ByVal cTCL_MONTO As Decimal, _
           ByVal cUSU_ID As String, _
           ByVal cTCL_FEC_GRAB As DateTime, _
           ByVal cTCL_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cTCL_SERIE As String, _
                                    ByVal cTCL_NUMERO As String, _
                                    ByVal cPER_ID_CLI As String) As Short

    End Interface
End Namespace
