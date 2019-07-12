Partial Public Class GuiaRemisionDetalle

    Public Function Clone() As GuiaRemisionDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), GuiaRemisionDetalle)
    End Function

End Class
