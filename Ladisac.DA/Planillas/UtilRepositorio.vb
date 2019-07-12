Imports Microsoft.Practices.Unity
Imports Ladisac.BE
'Imports System.Text

Namespace Ladisac.DA
    Public Class UtilRepositorio
        Implements IUtilRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetId(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String Implements IUtilRepositorio.GetId
            Dim result As String = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = context.SPCorrelativo(sTabla, sCampo, sNumeroDigitos, sWhere).FirstOrDefault()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

       

    End Class
End Namespace
