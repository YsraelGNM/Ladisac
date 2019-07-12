Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IProduccionRepositorio
        Function GetById(ByVal PRO_Id As Integer) As Produccion
        Sub Maintenance(ByVal Produccion As Produccion)
        Function ListaProduccion() As String
        Function ListaControlParadasPorDia(ByVal Fecha As Date) As String
        Function ReporteFinalProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean?) As String
        Function ReporteFinalProduccionDiario(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean?, ByVal LAD_ID As String) As String
        Function ReporteFinalProduccionComparativo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?) As String
        Function ReporteFinalProduccionFinalizada(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean) As String
        Function ListaCombustibleHorno(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String
        Function ListaResumenParadas(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String
        Function ListaResumenParadasForma1(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String
        Function ReporteSalidaSecadero(ByVal FecIni As Date, ByVal FecFin As Date, ByVal SEC_ID As Integer?) As String
        Function ListaProduccionFecha(ByVal Fecha As Date, ByVal PLA_ID As Integer) As List(Of Produccion)
        Function VwProduccionByPro_Id(ByVal PRO_ID As Integer) As vwReporteFinalProduccion2
    End Interface

End Namespace

