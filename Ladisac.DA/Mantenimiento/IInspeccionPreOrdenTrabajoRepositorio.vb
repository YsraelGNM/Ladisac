Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IInspeccionPreOrdenTrabajoRepositorio
        Function GetById(ByVal IOT_Id As Integer) As InspeccionPreOrdenTrabajo
        Sub Maintenance(ByVal InspeccionPreOrdenTrabajo As InspeccionPreOrdenTrabajo)
        Function ListaInspeccionPreOrdenTrabajo() As String
    End Interface

End Namespace

