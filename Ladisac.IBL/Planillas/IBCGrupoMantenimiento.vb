
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCGrupoMantenimiento
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.GrupoMantenimiento)
#End Region

#Region "Consultas"
        Function GrupoMantenimientoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing)
        Function GrupoMantenimientoSeek(ByVal numero As String, ByVal periodo As String)
        Function SPGrupoMantenimientoDelete(ByVal item As BE.GrupoMantenimiento)
        Function SPDetalleGrupoMantenimientoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String)
        Function SPGrupoMantenimientoOrdenTrabajoSelectXML(ByVal orden As String, ByVal entidad As String, ByVal descripcion As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function SPPvwGrupoMantenimientoHorasSelectXML(ByVal fechaDesde As Date, ByVal FechaHasta As Date, ByVal idpersona As String)
        Function SPDetalleHorasXTrabajadorMantenimiento(ByVal fechaDesde As Date, ByVal fechaHast As Date, ByVal sPerosna As String)

#End Region
    End Interface




End Namespace