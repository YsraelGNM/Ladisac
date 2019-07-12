Partial Public Class TransformacionDetalle

    Public Function Clone() As TransformacionDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), TransformacionDetalle)
    End Function

End Class
