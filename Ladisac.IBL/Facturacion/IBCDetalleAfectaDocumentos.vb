Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDetalleAfectaDocumentos
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

        Function spInsertarRegistro(ByVal Orm As DetalleAfectaDocumentos) As Short

        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cDDA_SERIE As String, _
                                    ByVal cDDA_NUMERO As String, _
                                    ByVal cDDA_ITEM As Int16) As Short

        Function ItemDetalleAfectaDocumentos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDaa_Serie As String, ByVal cDaa_Numero As String) As Integer

    End Interface
End Namespace

