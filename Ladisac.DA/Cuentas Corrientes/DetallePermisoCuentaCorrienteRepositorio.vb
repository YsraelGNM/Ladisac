Imports Microsoft.Practices.UnityImports Ladisac.BEImports System.TextNamespace Ladisac.DAPublic Class DetallePermisoCuentaCorrienteRepositorioImplements IDetallePermisoCuentaCorrienteRepositorio        <Dependency()> _        Public Property ContainerService As IUnityContainer        Public Function Maintenance(ByVal item As BE.DetallePermisoCuentaCorriente) As Short Implements IDetallePermisoCuentaCorrienteRepositorio.Maintenance            Try                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()                context.DetallePermisoCuentaCorriente.ApplyChanges(item)                context.SaveChanges()                item.AcceptChanges()                Maintenance = 1            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                If (rethrow) Then                    Throw                End If                Maintenance = 0            End Try        End Function        Public Function DeleteRegistro(ByVal item As BE.DetallePermisoCuentaCorriente, _
                                       ByVal cPEU_ID As String,
                                       ByVal cCCT_ID As String) As Short Implements IDetallePermisoCuentaCorrienteRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                item = (From c In context.DetallePermisoCuentaCorriente Where c.PEU_ID = cPEU_ID And c.CCT_ID = cCCT_ID Select c).FirstOrDefault()
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
        End FunctionEnd ClassEnd Namespace