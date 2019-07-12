Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA
    Public Class CtaCteRepositorio
        Implements ICtaCteRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.CtaCte Implements ICtaCteRepositorio.GetById
            Dim result As BE.CtaCte = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.CtaCte Where c.CCT_ID = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.CtaCte) As Boolean Implements ICtaCteRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.CtaCte.ApplyChanges(item)
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

