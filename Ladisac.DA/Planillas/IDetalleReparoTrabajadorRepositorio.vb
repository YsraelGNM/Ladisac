Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IDetalleReparoTrabajadorRepositorio
        Function GetById(ByVal numero As String, ByVal item As String) As BE.DetalleReparoTrabajador
        Function maintenance(ByVal item As DetalleReparoTrabajador)

    End Interface


End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IDetallePermisosTrabajadorRepositorio

'        Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador
'        Function Maintenance(ByVal item As DetallePermisosTrabajador)

'    End Interface

'End Namespace
