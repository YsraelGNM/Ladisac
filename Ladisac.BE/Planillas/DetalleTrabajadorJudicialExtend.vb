Imports Ladisac.BE
Partial Public Class DetalleTrabajadorJudicial

    Public Function Clone() As DetalleTrabajadorJudicial
        Return DirectCast(Me.MemberwiseClone(), DetalleTrabajadorJudicial)
    End Function

End Class
