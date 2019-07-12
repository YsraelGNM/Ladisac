Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenTrabajoRepositorio
        Function GetById(ByVal OTR_Id As Integer) As OrdenTrabajo
        Sub Maintenance(ByVal OrdenTrabajo As OrdenTrabajo)
        Function ListaOrdenTrabajo() As String
        Function ListaOrdenTrabajoOR(ByVal OTR_ID As Nullable(Of Integer)) As DataSet
    End Interface

End Namespace

