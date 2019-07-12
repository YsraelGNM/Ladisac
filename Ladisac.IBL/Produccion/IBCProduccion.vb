Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCProduccion

#Region "Mantenimientos"
        Sub MantenimientoProduccion(ByVal mProduccion As Produccion)
#End Region

#Region "Querys"
        Function ProduccionGetById(ByVal PRO_ID As Integer) As Produccion
        Function ListaProduccion() As String
        Function ListaControlParadasPorDia(ByVal Fecha As Date) As String
        Function ListaControlParadasPorDiaForma1(ByVal Fecha As Date) As String
        Function ListaResumenControlParadasPorDia(ByVal Fecha As Date) As String
        Function ListaQuemaLadrillo(ByVal HOR_Id As Integer, ByVal Fecha As Date) As String
        Function ListaVueltasHornoXAnio(ByVal HOR_Id As Integer, ByVal Anio As Integer) As String
        Function ListaDesHorXPuerta(ByVal Fecha As Date, ByVal HOR_Id As Integer) As String
        Function ConsumoR500PorDia(ByVal Fecha As Date) As String
        Function ListaCombustibleHorno(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String
        Function ListaCombustibleXQuemador(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String
        Function ProcesoTerminado(ByVal Fecha As Date) As String
        Function ReporteSalidaSecadero(ByVal FecIni As Date, ByVal FecFin As Date, ByVal SEC_ID As Integer) As String
        Function PesoQuema(ByVal Fecha As Date) As String
        Function ListaPesosYHumedadesPorDia(ByVal Fecha As Date) As String
        Function ReporteInspecciones(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PER_ID As String, ByVal LAD_ID As String, ByVal PRO_ID As Integer) As String
        Function ConteoYCargaXProduccion(ByVal PRO_ID As Integer) As String
        Function ReporteFinalProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer), ByVal TPR_ID As Nullable(Of Integer), ByVal EXT_ID As Nullable(Of Integer), ByVal Finalizada As Nullable(Of Boolean)) As String
        Function ReporteFinalProduccionDiario(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer), ByVal TPR_ID As Nullable(Of Integer), ByVal EXT_ID As Nullable(Of Integer), ByVal Finalizada As Nullable(Of Boolean), ByVal LAD_ID As String) As String
        Function ReporteFinalProduccionComparativo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer), ByVal TPR_ID As Nullable(Of Integer), ByVal EXT_ID As Nullable(Of Integer)) As String
        Function ReporteFinalProduccionFinalizada(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer), ByVal TPR_ID As Nullable(Of Integer), ByVal EXT_ID As Nullable(Of Integer), ByVal Finalizada As Boolean) As String
        Function FactoresProduccion(ByVal Fecha As Date) As String
        Function FactoresProduccionSecadero(ByVal Fecha As Date) As String
        Function FactoresProduccionResumen(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer)) As String
        Function SalidaVagonXDia(ByVal FechaIni As Date, ByVal FechaFin As Date) As String
        Function ListaConsumoCombustibleXResponsable(ByVal FecIni As Date, ByVal FecFin As Date, ByVal HOR_Id As Nullable(Of Integer))
        Function ListaProduccionParaSecadero() As String
        Function ListaResumenParadas(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String
        Function ListaResumenParadasForma1(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String
        Function ListaTnQuemadas(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaTnProducidas(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaSalidaHornoVsDespacho(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaDistribucionCombustibleProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaQuema As Boolean) As String
        Function ListaReciclajeVentaLadrillox12Mes(ByVal Anio As Integer, ByVal Mes As Integer) As String
        Function ListaDistribucionEnergiaProduccion(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ReporteBrutoNetoMateriaPrima(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer), ByVal TPR_ID As Nullable(Of Integer), ByVal EXT_ID As Nullable(Of Integer), ByVal Finalizada As Nullable(Of Boolean), ByVal LAD_ID As String) As String
        Function ListaProduccionFecha(ByVal Fecha As Date, ByVal PLA_ID As Integer) As List(Of Produccion)
        Function ListaReciclajeVentaLadrilloXAnioSeparado(ByVal Anio As Integer) As DataTable
        Function ListaCantidadQuemadaXAnio(ByVal Anio As Integer) As DataTable
        Function ListaTNQuemadaXAnio(ByVal Anio As Integer) As DataTable
        Function ReporteSalidaHornoXAnio(ByVal Anio As Integer) As DataTable
        Function ProduccionxFecha() As DataTable
        Function Interfase_PrecioLadrilloCrudo(ByVal PRO_ID) As DataTable
        Function Interfase_RecCrudoFinalProduccion(ByVal PRO_ID As Integer, ByVal UndRec As Integer) As DataTable
        Function ListaProduccionVagones(ByVal Pro_Id As Nullable(Of Integer)) As String
        Function VwProduccionByPro_Id(ByVal PRO_ID As Integer) As vwReporteFinalProduccion2

#End Region

#Region "Consultas - usadas en planillas "
        Function ProduccionGrupoTrabajoQuery(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function ProduccionCargaConteoSelectXML(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal fechaConteoCarga As Date)
        Function ProduccionGrupoTrabajoSinFechaQuery(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaHasta As Date, ByVal seBuscaPorFecha As Boolean)

#End Region

    End Interface

End Namespace
