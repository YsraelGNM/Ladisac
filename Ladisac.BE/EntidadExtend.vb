Partial Public Class Entidad

    Public Function Clone() As DocuMovimientoDetalle
        Return DirectCast(Me.MemberwiseClone(), DocuMovimientoDetalle)
    End Function

End Class
