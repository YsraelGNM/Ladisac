Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IDetallePermisosTrabajadorRepositorio

        Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador
        Function Maintenance(ByVal item As DetallePermisosTrabajador)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IDetallePrestamosTrabajadorRepositorio

'        Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador
'        Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean

'    End Interface

'End Namespace
