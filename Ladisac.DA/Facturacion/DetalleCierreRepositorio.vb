Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleCierreRepositorio
        Implements IDetalleCierreRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetalleCierre) As Short Implements IDetalleCierreRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleCierre.ApplyChanges(item)
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

        Public Function DeleteRegistro(ByVal item As BE.DetalleCierre, ByVal cCIE_ID As String, ByVal cDTD_ID As String) As Short Implements IDetalleCierreRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetalleCierre Where c.CIE_ID = cCIE_ID And c.DTD_ID = cDTD_ID Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
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
