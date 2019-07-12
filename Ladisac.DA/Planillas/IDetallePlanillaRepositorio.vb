Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IDetallePlanillaRepositorio
        Function GetById(ByVal tipoDoc As String, ByVal serie As String, ByVal numero As String, ByVal items As String) As BE.DetallePlanillas
        Function Maintenance(ByVal item As DetallePlanillas)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IDetallePermisosTrabajadorRepositorio

'        Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador
'        Function Maintenance(ByVal item As DetallePermisosTrabajador)

'    End Interface

'End Namespace