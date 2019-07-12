Partial Public Class MaleconPuerta
    Dim pPuertaHorno As PuertaHorno

    Public Property PuertaHorno() As PuertaHorno
        Get
            Return pPuertaHorno
        End Get
        Set(ByVal value As PuertaHorno)
            pPuertaHorno = value
        End Set
    End Property

End Class
