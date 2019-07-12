Partial Public Class Especificacion

    Public Function Clone() As Especificacion
        Return DirectCast(Me.MemberwiseClone(), Especificacion)
    End Function

End Class
