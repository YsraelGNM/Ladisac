Partial Public Class OrdenTrabajoPersonal

    Public Function Clone() As OrdenTrabajoPersonal
        Return DirectCast(Me.MemberwiseClone(), OrdenTrabajoPersonal)
    End Function

End Class
