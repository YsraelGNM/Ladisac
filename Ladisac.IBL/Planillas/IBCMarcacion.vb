Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCMarcacion
#Region "Mantenimiento"
        Sub maintenance(ByVal item As List(Of Marcaciones))

#End Region

#Region "Consultas"
        Function MarcacionQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal per_id As String)
        Function MarcacionSeek(ByVal fech As Date, ByVal per_id As String)
        Function SPDetalleMarcacionSelect(ByVal persona As String, ByVal fecha As Date)
        Function SPMarcacionColtronSelectXML(ByVal personas As String, ByVal fecha As Date)
        Function ReporteTardanzaXMes(ByVal FecIni As Date, ByVal FecFin As Date) As DataTable
#End Region
    End Interface

End Namespace




'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Interface IBCPeriodisidad
'#Region "Mantenimiento"
'        Sub Maintenance(ByVal item As Periodisidad)

'#End Region

'#Region "Consulta"
'        Function PeriodisidadQuery(ByVal pec_Periodisidad_Id As String, ByVal pec_Descripcion As String)
'        Function PeriodisidadSeek(ByVal id As String) As BE.Periodisidad

'#End Region

'    End Interface
'End Namespace
