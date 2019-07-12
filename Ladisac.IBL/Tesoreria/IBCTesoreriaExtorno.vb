Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTesoreriaExtorno
        Function spActualizarRegistro(ByVal cTDO_ID As String, _
            ByVal cDTD_ID As String, _
            ByVal cCCC_ID As String, _
            ByVal cTEX_SERIE As String, _
            ByVal cTEX_NUMERO As String, _
            ByVal cTEX_FECHA_EMI As DateTime, _
            ByVal cUSU_ID As String, _
            ByVal cTEX_FEC_GRAB As DateTime, _
            ByVal cTEX_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cTEX_SERIE As String, _
           ByVal cTEX_NUMERO As String, _
           ByVal cTEX_FECHA_EMI As DateTime, _
           ByVal cUSU_ID As String, _
           ByVal cTEX_FEC_GRAB As DateTime, _
           ByVal cTEX_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cTEX_SERIE As String, _
                                    ByVal cTEX_NUMERO As String) As Short

    End Interface
End Namespace
