Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleComedorRepositorio

        Function GetById(ByVal numero As String, ByVal persona As String)
        Function Maintenance(ByVal item As DetalleComedorPLL)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IDetallePermisosTrabajadorRepositorio

'        Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador
'        Function Maintenance(ByVal item As DetallePermisosTrabajador)

'    End Interface

'End Namespace
