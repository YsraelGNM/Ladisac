Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCInspeccionPreOrdenTrabajo

#Region "Mantenimientos"
        Sub MantenimientoInspeccionPreOrdenTrabajo(ByVal mInspeccionPreOrdenTrabajo As InspeccionPreOrdenTrabajo)
#End Region

#Region "Querys"
        Function InspeccionPreOrdenTrabajoGetById(ByVal IOT_ID As Integer) As InspeccionPreOrdenTrabajo
        Function ListaInspeccionPreOrdenTrabajo() As String
#End Region

    End Interface

End Namespace
