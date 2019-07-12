Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IPlanillaRepositorio

        Function GetbyId(ByVal serie As String, ByVal numero As String, ByVal tipoDoc As String) As BE.Planillas
        Function Maintenance(ByVal item As BE.Planillas)

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IPermisosTrabajadorRepositorio
'        Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)

'    End Interface

'End Namespace