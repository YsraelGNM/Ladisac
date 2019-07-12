Public Class UIException
    Inherits ApplicationException


    Public Property UIMessage As String

    Public Sub New()


    End Sub
    Public Sub New(ByVal message As String)
        Me.UIMessage = message
    End Sub


End Class
