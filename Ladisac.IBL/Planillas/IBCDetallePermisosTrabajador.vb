Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetallePermisosTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.DetallePermisosTrabajador)
#End Region

#Region "Consulta"
        Function DetallePermisosTrabajadroQuery(ByVal numero As String, ByVal item As String)
        Function DetallePermisosTrabajadorSeek(ByVal numero As String, ByVal item As String)
#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCDetallePrestamosTrabajador
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As DetallePrestamosTrabajador)

'#End Region

'#Region "consulta"
'        Function DetallePrestamosTrabajadorQuery(ByVal serie As String, ByVal numero As String, ByVal item As String)
'        Function DetallePrestamosTrabajadorSeek(ByVal serie As String, ByVal numero As String, ByVal item As String)

'#End Region

'    End Interface

'End Namespace
