Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPlanCargaDescargaHorno

#Region "Mantenimientos"
        Sub MantenimientoPlanCargaDescargaHorno(ByVal mPlanCargaDescargaHorno As PlanCargaDescargaHorno)
#End Region

#Region "Querys"
        Function PlanCargaDescargaHornoGetById(ByVal CDH_ID As Integer) As BE.PlanCargaDescargaHorno
        Function ListaPlanCargaDescargaHorno() As String
#End Region

    End Interface

End Namespace
