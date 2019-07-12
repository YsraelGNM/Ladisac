Imports Microsoft.Practices.UnityImports Ladisac.BEImports System.TextNamespace Ladisac.DAPublic Class DetalleDescuentoIncrementoTipoVentaPersonasRepositorio        Implements IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio        <Dependency()> _        Public Property ContainerService As IUnityContainer        Public Function Maintenance(ByVal item As BE.DetalleDescuentoIncrementoTipoVentaPersonas) As Short Implements IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio.Maintenance            Try                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()                context.DetalleDescuentoIncrementoTipoVentaPersonas.ApplyChanges(item)                context.SaveChanges()                item.AcceptChanges()                Maintenance = 1            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                If (rethrow) Then                    Throw                End If                Maintenance = 0            End Try        End Function
        Public Function DeleteRegistro(ByVal item As BE.DetalleDescuentoIncrementoTipoVentaPersonas, ByVal cDTP_ID As String, ByVal cART_ID As String, ByVal cDDT_ITEM As Short) As Short Implements IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetalleDescuentoIncrementoTipoVentaPersonas Where c.DTP_ID = cDTP_ID And c.ART_ID = cART_ID And c.DDT_ITEM = cDDT_ITEM Select c).FirstOrDefault()
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
    End ClassEnd Namespace