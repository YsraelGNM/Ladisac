
Partial Public Class ProcesoCompraDetalle

    Public Function Clone() As ProcesoCompraDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), ProcesoCompraDetalle)
    End Function

End Class
