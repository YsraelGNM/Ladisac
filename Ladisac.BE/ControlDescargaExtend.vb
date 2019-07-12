Partial Public Class ControlDescarga
    Dim pCaCoDe_Detalle As List(Of CaCoDe_Detalle)

    Public Property CaCoDe_Detalle As List(Of CaCoDe_Detalle)
        Get
            Return pCaCoDe_Detalle
        End Get
        Set(ByVal value As List(Of CaCoDe_Detalle))
            pCaCoDe_Detalle = value
        End Set
    End Property

End Class
