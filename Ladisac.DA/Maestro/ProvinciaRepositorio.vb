Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class ProvinciaRepositorio
        Implements DA.IProvinciaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.Provincia) As Short Implements IProvinciaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Provincia.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function
    End Class
End Namespace

