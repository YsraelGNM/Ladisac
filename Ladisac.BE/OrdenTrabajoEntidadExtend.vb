Partial Public Class OrdenTrabajoEntidad

    Public Function Clone() As OrdenTrabajoEntidad
        Return DirectCast(Me.MemberwiseClone(), OrdenTrabajoEntidad)
    End Function

End Class
