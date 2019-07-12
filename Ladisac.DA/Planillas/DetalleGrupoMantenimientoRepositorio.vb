
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA

    Public Class DetalleGrupoMantenimientoRepositorio
        Implements IDetalleGrupoMantenimientoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal Item As BE.DetalleGrupoMantenimiento) As Object Implements IDetalleGrupoMantenimientoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()

                context.DetalleGrupoMantenimiento.ApplyChanges(Item)
                context.SaveChanges()
                context.AcceptAllChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return True

        End Function
    End Class

End Namespace

