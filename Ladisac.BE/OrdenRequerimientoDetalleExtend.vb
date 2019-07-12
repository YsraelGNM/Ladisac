
Partial Public Class OrdenRequerimientoDetalle

    Public Function Clone() As OrdenRequerimientoDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
    End Function

End Class
