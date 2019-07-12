Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenTrabajoEntidadRepositorio
        Function GetById(ByVal OTE_Id As Integer) As OrdenTrabajoEntidad
        Sub Maintenance(ByVal OrdenTrabajoEntidad As OrdenTrabajoEntidad)
        Function ListaOrdenTrabajoEntidad() As String
    End Interface

End Namespace

