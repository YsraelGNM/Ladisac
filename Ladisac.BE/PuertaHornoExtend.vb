Partial Public Class PuertaHorno
    Dim pHorno As Horno

    Public Property Horno() As Horno
        Get
            Return pHorno
        End Get
        Set(ByVal value As Horno)
            pHorno = value
        End Set
    End Property

End Class
