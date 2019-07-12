Partial Public Class ParametroEntidad

    Public Function Clone() As ParametroEntidad
        Return DirectCast(Me.MemberwiseClone(), ParametroEntidad)
    End Function

End Class
