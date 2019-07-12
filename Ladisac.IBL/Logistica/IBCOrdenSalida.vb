Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenSalida

#Region "Mantenimientos"
        Sub MantenimientoOrdenSalida(ByVal mOrdenSalida As OrdenSalida)
#End Region

#Region "Querys"
        Function OrdenSalidaGetById(ByVal OSA_ID As Integer) As OrdenSalida
        Function ListaOrdenSalida() As String
        Function ImpresionOrdenDeSalida(ByVal OSA_ID As Integer) As String
        Function ReporteOrdenSalida(ByVal FecIni As Date, ByVal FecFin As Date) As DataTable
#End Region

    End Interface

End Namespace
