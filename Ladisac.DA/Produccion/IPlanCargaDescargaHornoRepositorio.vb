Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPlanCargaDescargaHornoRepositorio
        Function GetById(ByVal CDH_ID As Integer) As PlanCargaDescargaHorno
        Sub Maintenance(ByVal PlanCargaDescargaHorno As PlanCargaDescargaHorno)
        Function ListaPlanCargaDescargaHorno() As String
    End Interface

End Namespace

