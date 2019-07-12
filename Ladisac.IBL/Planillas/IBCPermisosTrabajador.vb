Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCPermisosTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.PermisosTrabajador)
#End Region
#Region "Consulta"
        Function PermisosTrabajadorQuery(ByVal numero As String, ByVal persona As String, ByVal codigo As String)
        Function PermisosTrabajadorSeek(ByVal numero As String)
#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCPrestamosTrabajador
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.PrestamosTrabajador)
'#End Region

'#Region "Consulta"
'        Function PrestamosTrabajadorQuery(ByVal codigo As String, ByVal nombre As String)
'        Function PrestamosTrabajadroSeek(ByVal serie As String, ByVal numero As String)
'#End Region

'    End Interface

'End Namespace
