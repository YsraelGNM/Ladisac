Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleAfectaDocumentosRepositorio
        Function spActualizarRegistro(ByVal cTDO_ID As String,
                                      ByVal cDTD_ID As String,
                                      ByVal cDDA_SERIE As String,
                                      ByVal cDDA_NUMERO As String,
                                      ByVal cDDA_ITEM As Int16,
                                      ByVal cTDO_ID_AFE As String,
                                      ByVal cDTD_ID_AFE As String,
                                      ByVal cCCT_ID_AFE As String,
                                      ByVal cDOC_SERIE_AFE As String,
                                      ByVal cDOC_NUMERO_AFE As String,
                                      ByVal cDDA_PRE_TOTAL As Double,
                                      ByVal cDDA_OBS As String,
                                      ByVal cUSU_ID As String,
                                      ByVal cDDA_FEC_GRAB As DateTime,
                                      ByVal cDDA_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String,
                                      ByVal cDTD_ID As String,
                                      ByVal cDDA_SERIE As String,
                                      ByVal cDDA_NUMERO As String,
                                      ByVal cDDA_ITEM As Int16,
                                      ByVal cTDO_ID_AFE As String,
                                      ByVal cDTD_ID_AFE As String,
                                      ByVal cCCT_ID_AFE As String,
                                      ByVal cDOC_SERIE_AFE As String,
                                      ByVal cDOC_NUMERO_AFE As String,
                                      ByVal cDDA_PRE_TOTAL As Double,
                                      ByVal cDDA_OBS As String,
                                      ByVal cUSU_ID As String,
                                      ByVal cDDA_FEC_GRAB As DateTime,
                                      ByVal cDDA_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cDDA_SERIE As String, _
                                    ByVal cDDA_NUMERO As String, _
                                    ByVal cDDA_ITEM As Int16) As Short
    End Interface
End Namespace
