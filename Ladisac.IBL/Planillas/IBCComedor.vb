Imports Ladisac.BE


Namespace Ladisac.BL
    Public Interface IBCComedor


#Region "Mantenimiento"
        Function Maintenance(ByVal item As ComedorPLL)
        Function MaintenanceDelete(ByVal item As BE.ComedorPLL)
        Sub ImportarDescuentoComedor()
#End Region

#Region "consultas"

        Function ComedorQuery(ByVal numero As String, ByVal observaciones As String, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime)
        Function ComedorSeek(ByVal numero As String)
        Function spDetalleComedorMaintenanceSelect(ByVal numero As String)
        Function spListaDetalleComedorDescuento(ByVal FecIni As Date, ByVal FecFin As Date) As DataTable
        Function spDetallePrestamoSelect(ByVal FechaFin As Date)

#End Region

    End Interface
End Namespace
