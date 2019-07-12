Partial Public Class SalidaCombustible
    Dim pIGV As Decimal
    Dim pMessageId As String
    Dim pId_Grifo As Integer

    Public Property IGV() As Decimal
        Get
            Return pIGV
        End Get
        Set(ByVal value As Decimal)
            pIGV = value
        End Set
    End Property

    Public Property MessageId() As String
        Get
            Return pMessageId
        End Get
        Set(ByVal value As String)
            pMessageId = value
        End Set
    End Property

    Public Property Id_Grifo() As Integer
        Get
            Return pId_Grifo
        End Get
        Set(ByVal value As Integer)
            pId_Grifo = value
        End Set
    End Property

End Class
