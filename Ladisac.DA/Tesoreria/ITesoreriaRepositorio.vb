Imports Ladisac.BE
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cTES_SERIE As String, _
           ByVal cTES_NUMERO As String, _
           ByVal cTES_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cTES_MONTO_TOTAL As Double, _
           ByVal cTES_ASIENTO As Boolean, _
           ByVal cTES_CIERRE As Int16, _
           ByVal cUSU_ID As String, _
           ByVal cTES_FEC_GRAB As DateTime, _
           ByVal cTES_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID as string, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cTES_SERIE As String, _
           ByVal cTES_NUMERO As String, _
           ByVal cTES_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cTES_MONTO_TOTAL As Double, _
           ByVal cTES_ASIENTO As Boolean, _
           ByVal cTES_CIERRE As Int16, _
           ByVal cUSU_ID As String, _
           ByVal cTES_FEC_GRAB As DateTime, _
           ByVal cTES_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cTES_SERIE As String, _
                                    ByVal cTES_NUMERO As String) As Short
    End Interface