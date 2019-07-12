Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenTrabajo

#Region "Mantenimientos"
        Sub MantenimientoOrdenTrabajo(ByVal mOrdenTrabajo As OrdenTrabajo)
#End Region

#Region "Querys"
        Function OrdenTrabajoGetById(ByVal OTR_ID As Integer) As OrdenTrabajo
        Function ListaOrdenTrabajo() As String
        Function ListaOrdenTrabajoParaOR() As String
        Function ListaHistoricoOrdenTrabajo(ByVal ENO_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Gru_Id As Nullable(Of Integer)) As String
        Function ListaArticulosXOT(ByVal OTR_ID As Integer) As String
        Function ListaOTXMesXSemanaxAnio(ByVal Anio As Nullable(Of Integer), ByVal Gru_Id As Nullable(Of Integer)) As String
        Function ListaHijosEntidad(ByVal ENO_ID As Integer) As String
        Function ListaPersonalXOT(ByVal OTR_ID As Integer) As String
        Function ListaOrdenTrabajoOR(ByVal OTR_ID As Nullable(Of Integer)) As DataSet
        Function ImprimirOrdenTrabajo(ByVal OTR_ID As Integer) As String

#End Region

    End Interface

End Namespace
