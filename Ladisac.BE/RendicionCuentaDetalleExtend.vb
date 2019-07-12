Partial Public Class RendicionCuentaDetalle

    Public Function Clone() As RendicionCuentaDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), RendicionCuentaDetalle)
    End Function

End Class
