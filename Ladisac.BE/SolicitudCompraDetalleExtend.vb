Partial Public Class SolicitudCompraDetalle

    Public Function Clone() As SolicitudCompraDetalle
        'Dim other As OrdenRequerimientoDetalle = DirectCast(Me.MemberwiseClone(), OrdenRequerimientoDetalle)
        'Return other
        Return DirectCast(Me.MemberwiseClone(), SolicitudCompraDetalle)
    End Function

End Class
