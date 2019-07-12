Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetallePlanilla
#Region "Mantenimiento"
        'll
        Function Maintenance(ByVal item As BE.DetallePlanillas)
        Function SPDetallePlanillasUpdate(ByVal xml As String)
#End Region

#Region "Consulta"

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

