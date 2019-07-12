Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports System.Collections.Specialized
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration
Imports System.Text

Namespace Infrastructure
    <ConfigurationElementType(GetType(CustomHandlerData))> _
    Public Class UIExceptionHandlerPolicy
        Implements IExceptionHandler
        Public Sub New(ByVal args As NameValueCollection)

        End Sub


        Public Function HandleException(ByVal exception As System.Exception, ByVal handlingInstanceId As System.Guid) As System.Exception Implements Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler.HandleException
            Dim sb As New StringBuilder
            sb.AppendLine(exception.Message)
            If (exception.InnerException IsNot Nothing) Then
                sb.AppendLine(exception.InnerException.Message)
            End If
            System.Windows.Forms.MessageBox.Show(sb.ToString)
            Return exception
        End Function
    End Class

End Namespace
