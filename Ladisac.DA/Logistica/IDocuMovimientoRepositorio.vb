Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDocuMovimientoRepositorio
        Function GetById(ByVal DMO_Id As Integer) As DocuMovimiento
        Sub Maintenance(ByVal DocuMovimiento As DocuMovimiento)
        Function ListaDocuMovimiento(ByVal Filtro As String) As DataSet
        Function ListaSalidaXReqXDocu(ByVal DMO_ID As Nullable(Of Integer)) As DataSet
        Function ListaIngresoXFacXDocu(ByVal DMO_ID As Nullable(Of Integer), ByVal ART_ID As String) As DataSet
        Function GetByIdSCO(ByVal SCO_Id As Integer) As DocuMovimiento
        Function GetByIdDRU(ByVal DRU_Id As Integer) As DocuMovimiento
        Function GetByIdCCO(ByVal CCO_Id As Integer) As DocuMovimiento
        Function GetByIdCME(ByVal CME_Id As Integer) As DocuMovimiento
        Function GetColByIdCME(ByVal CME_Id As Integer) As List(Of DocuMovimiento)
        Function GetColByIdCCO_CONTEO(ByVal CCO_Id As Integer) As List(Of DocuMovimiento)
        Function GetColRecicladoCrudoByIdPRO_ID(ByVal PRO_ID As Integer) As List(Of DocuMovimiento)
        Sub ActualizarIngresoTransformacion(ByVal TFO_ID As Nullable(Of Integer))

    End Interface

End Namespace

