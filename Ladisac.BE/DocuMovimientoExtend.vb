Partial Public Class DocuMovimiento
    Dim pALM_ID_REF As Integer
    Dim pFecOri As Date


    Public Property ALM_ID_REF() As Nullable(Of Integer)
        Get
            Return pALM_ID_REF
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If value Is Nothing Then
                pALM_ID_REF = Nothing
            Else
                pALM_ID_REF = value
            End If
        End Set
    End Property

    Public Property FecOri() As Nullable(Of Date)
        Get
            Return pFecOri
        End Get
        Set(ByVal value As Nullable(Of Date))
            If value Is Nothing Then
                pFecOri = Nothing
            Else
                pFecOri = value
            End If
        End Set
    End Property

    Public Function Clone() As DocuMovimiento

        Return DirectCast(Me.MemberwiseClone(), DocuMovimiento)

    End Function

End Class
