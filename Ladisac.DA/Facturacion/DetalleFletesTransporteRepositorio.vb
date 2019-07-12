Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleFletesTransporteRepositorio
        Implements IDetalleFletesTransporteRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal Item As BE.DetalleFletesTransporte) As Short Implements IDetalleFletesTransporteRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleFletesTransporte.ApplyChanges(Item)
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

        Public Function DeleteRegistro(ByVal item As BE.DetalleFletesTransporte, _
                                       ByVal cFLE_ID As String, _
                                       ByVal cFDE_ID As String, _
                                       ByVal cDIS_ID As String
                                       ) As Short Implements IDetalleFletesTransporteRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                item = (From c In context.DetalleFletesTransporte Where c.FLE_ID = cFLE_ID And c.FDE_ID = cFDE_ID And c.DIS_ID = cDIS_ID Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
                'context.DetalleListaPrecios.ApplyChanges(item)
                'context.SaveChanges()
                'item.AcceptChanges()
                'DeleteRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

    End Class
End Namespace
