Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleDocumentosRepositorio
        Function Maintenance(ByVal item As DetalleDocumentos) As Short
        Function DeleteRegistro(ByVal item As DetalleDocumentos, ByVal cTDO_ID As String, _
                                                                 ByVal cDTD_ID As String, _
                                                                 ByVal cDDO_SERIE As String, _
                                                                 ByVal cDDO_NUMERO As String, _
                                                                 ByVal cDDO_ITEM As Int16) As Short
        Function spActualizarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String,
           ByVal cDDO_SERIE As String,
           ByVal cDDO_NUMERO As String,
           ByVal cDDO_ITEM As Int16,
           ByVal cART_ID_IMP As String,
           ByVal cART_ID_KAR As String,
           ByVal cDDO_ART_FACTOR As Double,
           ByVal cDDO_CANTIDAD As Double,
           ByVal cDDO_INC_IGV As Int16,
           ByVal cDDO_DES_INC_PRE As Double,
           ByVal cDDO_PRE_UNI As Double,
           ByVal cDDO_IGV_POR As Double,
           ByVal cDDO_MONTO_IGV As Double,
           ByVal cDDO_PRE_TOTAL As Double,
           ByVal cDDO_OBS_DSC_ART As String,
           ByVal cTDO_ID_ANT As String,
           ByVal cDTD_ID_ANT As String,
           ByVal cCCT_ID_ANT As String,
           ByVal cDDO_SERIE_ANT As String,
           ByVal cDDO_NUMERO_ANT As String,
           ByVal cART_AFE_PER As Boolean,
           ByVal cUSU_ID As String,
           ByVal cDDO_FEC_GRAB As DateTime,
           ByVal cDDO_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String,
           ByVal cDDO_SERIE As String,
           ByVal cDDO_NUMERO As String,
           ByVal cDDO_ITEM As Int16,
           ByVal cART_ID_IMP As String,
           ByVal cART_ID_KAR As String,
           ByVal cDDO_ART_FACTOR As Double,
           ByVal cDDO_CANTIDAD As Double,
           ByVal cDDO_INC_IGV As Int16,
           ByVal cDDO_DES_INC_PRE As Double,
           ByVal cDDO_PRE_UNI As Double,
           ByVal cDDO_IGV_POR As Double,
           ByVal cDDO_MONTO_IGV As Double,
           ByVal cDDO_PRE_TOTAL As Double,
           ByVal cDDO_OBS_DSC_ART As String,
           ByVal cTDO_ID_ANT As String,
           ByVal cDTD_ID_ANT As String,
           ByVal cCCT_ID_ANT As String,
           ByVal cDDO_SERIE_ANT As String,
           ByVal cDDO_NUMERO_ANT As String,
           ByVal cART_AFE_PER As Boolean,
           ByVal cUSU_ID As String,
           ByVal cDDO_FEC_GRAB As DateTime,
           ByVal cDDO_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cDDO_SERIE As String, _
                                    ByVal cDDO_NUMERO As String, _
                                    ByVal cDDO_ITEM As Int16) As Short

    End Interface
End Namespace
