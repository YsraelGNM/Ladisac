Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleTrabajadorHorasRepositorio
        Function GetById(ByVal tipoTrabajadro As String, ByVal numero As String, ByVal item As String)
        Function Maintenance(ByVal item As BE.DetalleTrabajadorHoras) As Boolean
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IDetallePrestamosTrabajadorRepositorio

'        Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador
'        Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean

'    End Interface

'End Namespace
