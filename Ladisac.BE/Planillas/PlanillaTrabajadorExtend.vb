Imports Ladisac.BE
Partial Public Class PlanillaTrabajador
    Public Function Clone() As PlanillaTrabajador
        Return DirectCast(Me.MemberwiseClone, PlanillaTrabajador)

    End Function
End Class

