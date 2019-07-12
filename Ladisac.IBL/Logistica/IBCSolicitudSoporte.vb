Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSolicitudSoporte

#Region "Mantenimientos"
        Function MantenimientoSolicitudSoporte(ByVal mSolicitudSoporte As SolicitudSoporte) As Integer
#End Region

#Region "Querys"
        Function SolicitudSoporteGetById(ByVal SOS_ID As Integer) As SolicitudSoporte
        Function ListaSolicitudSoporte() As String
        Function ReporteSoSo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Area As String, ByVal PER_ID_SOLICITADO As String) As DataTable
#End Region

    End Interface

End Namespace
