Partial Public Class OrdenCompraDetalle

    Dim pPCD As BE.ProcesoCompraDetalle

    Public Property ProcesoCompraDetalle As BE.ProcesoCompraDetalle
        Get
            Return pPCD
        End Get
        Set(ByVal value As BE.ProcesoCompraDetalle)
            pPCD = value
        End Set
    End Property

    Public Function Clone() As OrdenCompraDetalle
        Return DirectCast(Me.MemberwiseClone(), OrdenCompraDetalle)
    End Function

End Class
