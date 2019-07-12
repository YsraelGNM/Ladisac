Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DescuentoIncrementoTipoVentaPersonasRepositorio
        Implements IDescuentoIncrementoTipoVentaPersonasRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DescuentoIncrementoTipoVentaPersonas) As Short Implements IDescuentoIncrementoTipoVentaPersonasRepositorio.Maintenance
            'Try
            Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
            context.DescuentoIncrementoTipoVentaPersonas.ApplyChanges(item)
            'context.ObjectStateManager.ChangeObjectState(item, EntityState.Modified)
            context.SaveChanges()
            'context.AcceptAllChanges()
            item.AcceptChanges()
            Maintenance = 1
            'Catch ex As Exception
            'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
            'If (rethrow) Then
            'Throw
            'End If
            'Maintenance = 0
            'End Try
        End Function
    End Class
End Namespace
