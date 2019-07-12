Partial Public Class DocuMovimientoDetalle

    Dim pALM_ID_TRANSFERENCIA As Integer
    Dim pEsDevolucion As Boolean
    Dim pAlm_Ori As Integer
    Dim pArt_Ori As String

    Public Property ALM_ID_TRANSFERENCIA() As Integer
        Get
            Return pALM_ID_TRANSFERENCIA
        End Get
        Set(ByVal value As Integer)
            pALM_ID_TRANSFERENCIA = value
        End Set
    End Property

    Public Property EsDevolucion() As Boolean
        Get
            Return pEsDevolucion
        End Get
        Set(ByVal value As Boolean)
            pEsDevolucion = value
        End Set
    End Property

    Public Property Alm_Ori() As Integer
        Get
            Return pAlm_Ori
        End Get
        Set(ByVal value As Integer)
            pAlm_Ori = value
        End Set
    End Property

    Public Property Art_Ori() As String
        Get
            Return pArt_Ori
        End Get
        Set(ByVal value As String)
            pArt_Ori = value
        End Set
    End Property

    Public Function Clone() As DocuMovimientoDetalle
        Return DirectCast(Me.MemberwiseClone(), DocuMovimientoDetalle)
    End Function


End Class
