Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCReparoTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.ReparoTrabajador)

#End Region
#Region "Consulta"
        Function ReparoTrabajadorQuery(ByVal numero As String, ByVal observaciones As String, ByVal desdeFecha As DateTime, ByVal hastaFecha As DateTime)
        Function ReparoTrabajadorSeek(ByVal numero As String)
        Function SPDetalleReparoTrabajadorSelect(ByVal numero As String)
#End Region
    End Interface
End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCPermisosTrabajador
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)
'#End Region
'#Region "Consulta"
'        Function PermisosTrabajadorQuery(ByVal numero As String, ByVal persona As String, ByVal codigo As String)
'        Function PermisosTrabajadorSeek(ByVal numero As String)
'#End Region
'    End Interface

'End Namespace