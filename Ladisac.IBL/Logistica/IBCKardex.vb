Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCKardex

#Region "Mantenimientos"
        Sub MantenimientoKardex(ByVal mKardex As Kardex)
        Sub RehacerKardex(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date)
#End Region

#Region "Querys"
        Function KardexGetById(ByVal KAR_ID As Integer) As Kardex
        Function ListaKardex(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        Function ListaKardexLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        Function ListaKardexLote(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As String
        Function ListaConsumoCombustible(ByVal Per_Id_Empresa As String, ByVal Unt_Id As String, ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaStockMinimo() As String
        Function ListaDocOperacion(ByVal IngresoSalida As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal ALM_ID As Nullable(Of Integer), ByVal ART_ID As String) As String
        Function ListaSaldoXAlmacen(ByVal Art_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date) As String
        Function ListaKardexConsolidado(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        Function ListaKardexContabilidad(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Nullable(Of Integer), ByVal ART_Id As String, ByVal Anual As Boolean, ByVal Mensual As Boolean, ByVal Tipo As String, Optional ByVal DetRes As Boolean = False) As String
        Function ListaReporteTickets(ByVal Per_Id_Empresa As String, ByVal Tipo As String, ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function spSaldoAlmaReparableSuministro(ByVal fechaInicio As Date, ByVal fechaHasta As Date)
        Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal
        Function ReporteAnticuamiento(ByVal FecIni As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        Function ListaTiempoAtencionOR(ByVal FecIni As Date, ByVal FecFin As Date) As DataTable
#End Region

    End Interface

End Namespace
