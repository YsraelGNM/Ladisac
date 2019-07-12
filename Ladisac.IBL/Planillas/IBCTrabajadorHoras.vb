
Imports Ladisac.BL

Namespace Ladisac.BL
    Public Interface IBCTrabajadorHoras
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.TrabajadorHoras)
#End Region

#Region "Consulta"

        Function TrabajadorHorasQuery(ByVal numero As String, ByVal desdesFecha As Date, ByVal hastaFecha As Date, ByVal observaciones As String)
        Function TrabajadorHorasSeek(ByVal tipoTrabajador As String, ByVal numero As String) As BE.TrabajadorHoras
        Function SPDetalleTrabajadorHorasMaintenanceSelect(ByVal tipoTrabajador As String, ByVal numero As String) As DataTable

#End Region


    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCDetallePermisosTrabajador
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.DetallePermisosTrabajador)
'#End Region

'#Region "Consulta"
'        Function DetallePermisosTrabajadroQuery(ByVal numero As String, ByVal item As String)
'        Function DetallePermisosTrabajadorSeek(ByVal numero As String, ByVal item As String)
'#End Region
'    End Interface

'End Namespace