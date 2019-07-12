Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPlanMantenimiento

#Region "Mantenimientos"
        Sub MantenimientoPlanMantenimiento(ByVal mPlanMantenimiento As PlanMantto)
#End Region

#Region "Querys"
        Function PlanMantenimientoGetById(ByVal PMO_ID As Integer) As PlanMantto
        Function ListaPlanMantenimiento() As String
#End Region

    End Interface

End Namespace
