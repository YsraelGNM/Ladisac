Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class PuntoVentaRepositorio
        Implements DA.IPuntoVentaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.PuntoVenta) As Short Implements IPuntoVentaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.PuntoVenta.ApplyChanges(item)
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

        Public Function GetById(ByVal PVE_ID As String) As BE.PuntoVenta Implements IPuntoVentaRepositorio.GetById
            Dim result As PuntoVenta = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.PuntoVenta Where c.PVE_ID = PVE_ID Select c).FirstOrDefault
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
