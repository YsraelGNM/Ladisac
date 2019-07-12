Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCMedioPagoTesoreria
        Function Mantenimiento(ByVal Item As MedioPagoTesoreria) As Short
        Function DeleteRegistro(ByVal item As MedioPagoTesoreria, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As String) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String, _
    ByVal cDTD_ID As String, _
    ByVal cCCC_ID As String, _
    ByVal cMPT_SERIE As String, _
    ByVal cMPT_NUMERO As String, _
    ByVal cMPT_ITEM As Int16, _
    ByVal cMPT_IMPORTE_AFECTO As Double, _
    ByVal cMPT_PORCENTAJE As Double, _
    ByVal cCHE_ID As String, _
    ByVal cMPT_MEDIO_PAGO As Int16, _
    ByVal cMPT_SERIE_MEDIO As String, _
    ByVal cMPT_NUMERO_MEDIO As String, _
    ByVal cMPT_GIRADO_A As String, _
    ByVal cMPT_CONCEPTO As String, _
    ByVal cMPT_UBICACION As Int16, _
    ByVal cPER_ID_BAN As String, _
    ByVal cMPT_DIFERIDO As Boolean, _
    ByVal cMPT_FECHA_DIFERIDO As DateTime, _
    ByVal cMPT_RECEPCION As Int16, _
    ByVal cUSU_ID As String, _
    ByVal cMPT_FEC_GRAB As DateTime, _
    ByVal cMPT_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String, _
            ByVal cDTD_ID As String, _
            ByVal cCCC_ID As String, _
            ByVal cMPT_SERIE As String, _
            ByVal cMPT_NUMERO As String, _
            ByVal cMPT_ITEM As Int16, _
            ByVal cMPT_IMPORTE_AFECTO As Double, _
            ByVal cMPT_PORCENTAJE As Double, _
            ByVal cCHE_ID As String, _
            ByVal cMPT_MEDIO_PAGO As Int16, _
            ByVal cMPT_SERIE_MEDIO As String, _
            ByVal cMPT_NUMERO_MEDIO As String, _
            ByVal cMPT_GIRADO_A As String, _
            ByVal cMPT_CONCEPTO As String, _
            ByVal cMPT_UBICACION As Int16, _
            ByVal cPER_ID_BAN As String, _
            ByVal cMPT_DIFERIDO As Boolean, _
            ByVal cMPT_FECHA_DIFERIDO As DateTime, _
            ByVal cMPT_RECEPCION As Int16, _
            ByVal cUSU_ID As String, _
            ByVal cMPT_FEC_GRAB As DateTime, _
            ByVal cMPT_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cMPT_SERIE As String, _
                                    ByVal cMPT_NUMERO As String, _
                                    ByVal cMPT_ITEM As Int16) As Short
        Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cMPT_SERIE As String, _
                                    ByVal cMPT_NUMERO As String) As Short
        Function spActualizarMPT_UBICACION(ByVal cTDO_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cPER_ID_BAN As String, _
                                    ByVal cMPT_SERIE_MEDIO As String, _
                                    ByVal cMPT_NUMERO_MEDIO As String, _
                                    ByVal cMPT_UBICACION As Int16) As Short
    End Interface
End Namespace
