Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPlanMantenimientoRepositorio
        Function GetById(ByVal PMO_Id As Integer) As PlanMantto
        Sub Maintenance(ByVal PlanMantenimiento As PlanMantto)
        Function ListaPlanMantenimiento() As String
    End Interface

End Namespace

