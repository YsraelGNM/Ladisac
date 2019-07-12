Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IPermisosTrabajadorRepositorio
        Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador
        Function Maintenance(ByVal item As BE.PermisosTrabajador)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IPrestamosTrabajadorRepositorio
'        Function GetById(ByVal serie As String, ByVal numero As String) As BE.PrestamosTrabajador
'        Function Maintenance(ByVal item As BE.PrestamosTrabajador)

'    End Interface

'End Namespace

