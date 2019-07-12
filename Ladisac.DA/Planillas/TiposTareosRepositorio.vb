Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA
    Public Class TiposTareosRepositorio
        Implements ITiposTareosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal id As String) As BE.TiposTareos Implements ITiposTareosRepositorio.GetById
            Dim result As TiposTareos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TiposTareos Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.TiposTareos) As Boolean Implements ITiposTareosRepositorio.Mantenance


            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TiposTareos.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function
    End Class
End Namespace
