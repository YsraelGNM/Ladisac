Partial Public Class imagen

    Public Function Clone() As Imagen
        Return DirectCast(Me.MemberwiseClone(), Imagen)
    End Function

End Class
