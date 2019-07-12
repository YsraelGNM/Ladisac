Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDespachosRepositorio
        Function Maintenance(ByVal item As Despachos) As Short

        Function spInsertarProgramacion(ByVal TDO_ID_CRO As String,
                                       ByVal DTD_ID_CRO As String,
                                       ByVal DES_SERIE_CRO As String,
                                       ByVal DES_NUMERO_CRO As String,
                                       ByVal TDO_ID_DES As String, _
                                       ByVal DTD_ID_DES As String,
                                       ByVal DES_SERIE_DES As String,
                                       ByVal DES_NUMERO_DES As String,
                                       ByVal USU_ID As String,
                                       ByVal PRO_ESTADO As Int16) As Short

        Function spActualizarDespachosDES_ESTADO(ByVal TDO_ID As String, _
                                                 ByVal DTD_ID As String,
                                                 ByVal DES_SERIE As String,
                                                 ByVal DES_NUMERO As String,
                                                 ByVal DES_ESTADO As Int16) As Short
        Function spActualizarDespachosDES_ESTADOEnDistribuidora(ByVal TDO_ID As String, _
                                                 ByVal DTD_ID As String,
                                                 ByVal DES_SERIE As String,
                                                 ByVal DES_NUMERO As String,
                                                 ByVal DES_ESTADO As Int16) As Short

        Function spActualizarDespachosDES_FEC_SAL_PLA(ByVal Orm As Despachos) As Short
        Function spEnviarCorreoDespacho(ByVal Orm As Despachos) As Short
        Function spActualizarDespachosDES_FEC_CAR_DES(ByVal Orm As Despachos) As Short


        Function DeleteRegistro(ByVal item As Despachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDES_SERIE As String, ByVal cDES_NUMERO As String) As Short

        Function spActualizarDocuMovimiento(ByVal Orm As Despachos) As Short
        Function spValidarSalidaVigilancia(ByVal Orm As Despachos) As Short

        Function spActualizarRegistro(ByVal Orm As Despachos) As Short
        Function spInsertarRegistro(ByVal Orm As Despachos) As Short
        Function spEliminarRegistro(ByVal Orm As Despachos) As Short


        Function spActualizarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short
        Function spInsertarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short

        Function EjecutarReporte(ByVal report As String, ByVal ParamArray params As Object()) As DataTable

        Function GetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As Despachos

    End Interface
End Namespace

