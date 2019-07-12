Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDetalleAfectaProductoDocumentos
        Function Mantenimiento(ByVal Item As DetalleAfectaProductoDocumentos) As Short

        Function spActualizarRegistro(ByVal cTDO_ID As String,
                                      ByVal cDTD_ID As String,
                                      ByVal cDAP_SERIE As String,
                                      ByVal cDAP_NUMERO As String,
                                      ByVal cDAP_ITEM As Int16,
                                      ByVal cTDO_ID_AFP As String,
                                      ByVal cDTD_ID_AFP As String,
                                      ByVal cCCT_ID_AFP As String,
                                      ByVal cDOC_SERIE_AFP As String,
                                      ByVal cDOC_NUMERO_AFP As String,
                                      ByVal cART_ID As String,
                                      ByVal cDAP_CANTIDAD As Double,
                                      ByVal cDAP_OBS As String,
                                      ByVal cTDO_ID_DEV As String,
                                      ByVal cDTD_ID_DEV As String,
                                      ByVal cCCT_ID_DEV As String,
                                      ByVal cDES_SERIE_DEV As String,
                                      ByVal cDES_NUMERO_DEV As String,
                                      ByVal cART_ID_DEV As String,
                                      ByVal cDDE_CANTIDAD_DEV As Double,
                                      ByVal cUSU_ID As String,
                                      ByVal cDAP_FEC_GRAB As DateTime,
                                      ByVal cDAP_ESTADO As Boolean) As Short

        Function spInsertarRegistro(ByVal Orm As DetalleAfectaProductoDocumentos) As Short

        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cDAP_SERIE As String, _
                                    ByVal cDAP_NUMERO As String, _
                                    ByVal cDAP_ITEM As Int16) As Short

        Function ItemDetalleAfectaProductoDocumentos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDap_Serie As String, ByVal cDap_Numero As String) As Integer

    End Interface
End Namespace
