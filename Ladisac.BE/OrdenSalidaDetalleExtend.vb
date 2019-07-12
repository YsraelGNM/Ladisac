Partial Public Class OrdenSalidaDetalle

    Public Function Clone() As OrdenSalidaDetalle

        Return DirectCast(Me.MemberwiseClone(), OrdenSalidaDetalle)

    End Function

End Class
