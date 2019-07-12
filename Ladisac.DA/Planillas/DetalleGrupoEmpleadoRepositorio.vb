
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA

    Public Class DetalleGrupoEmpleadoRepositorio
        Implements IDetalleGrupoEmpleadoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal Item As BE.DetalleGrupoEmpleado) As Object Implements IDetalleGrupoEmpleadoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()

                context.DetalleGrupoEmpleado.ApplyChanges(Item)
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

