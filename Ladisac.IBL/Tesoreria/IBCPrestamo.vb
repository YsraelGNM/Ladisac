Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCPrestamo
        Function Mantenimiento(ByVal Item As Prestamo) As Short
        Function DeleteRegistro(ByVal item As Prestamo, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cPRE_SERIE As String, ByVal cPRE_NUMERO As String) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cPRE_SERIE As String, _
           ByVal cPRE_NUMERO As String, _
           ByVal cPRE_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cPRE_MONTO_TOTAL As Double, _
           ByVal cPRE_TIPO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPRE_FEC_GRAB As DateTime, _
           ByVal cPRE_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cPRE_SERIE As String, _
           ByVal cPRE_NUMERO As String, _
           ByVal cPRE_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cPRE_MONTO_TOTAL As Double, _
           ByVal cPRE_TIPO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPRE_FEC_GRAB As DateTime, _
           ByVal cPRE_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cPRE_SERIE As String, _
                                    ByVal cPRE_NUMERO As String) As Short
        Function spActualizarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As Tesoreria) As Short
        Function spEliminarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As Tesoreria) As Short
    End Interface
End Namespace
