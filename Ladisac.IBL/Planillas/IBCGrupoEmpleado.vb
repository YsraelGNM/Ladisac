
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCGrupoEmpleado
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.GrupoEmpleado)
#End Region

#Region "Consultas"

        Function GrupoEmpleadoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing)
        Function GrupoEmpleadoSeek(ByVal numero As String, ByVal periodo As String)
        Function SPGrupoEmpleadoDelete(ByVal item As BE.GrupoEmpleado)
        Function SPGrupoEmpleadoHorasSelect(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal PER_ID As String)
        'Function SPDetalleGrupoMantenimientoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String)
        'Function SPGrupoMantenimientoOrdenTrabajoSelectXML(ByVal orden As String, ByVal entidad As String, ByVal descripcion As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function SPPvwGrupoEmpleadoHorasSelectXML(ByVal fechaDesde As Date, ByVal FechaHasta As Date, ByVal idpersona As String, ByVal sXMLTiposTrabajador As String)
        Function SPDetalleHorasXTrabajadorEmpleado(ByVal fechaDesde As Date, ByVal fechaHast As Date, ByVal sPerosna As String)
        Function spDetalleGrupoEmpleadoMaintenanceSelect(ByVal prd_Periodo As String, ByVal gre_Numero As String)
#End Region
    End Interface




End Namespace