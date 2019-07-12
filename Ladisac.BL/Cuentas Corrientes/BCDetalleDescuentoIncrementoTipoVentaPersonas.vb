Imports Ladisac.BENamespace Ladisac.BLPublic Class BCDetalleDescuentoIncrementoTipoVentaPersonas        Implements IBCDetalleDescuentoIncrementoTipoVentaPersonas        <Dependency()> _        Public Property ContainerService As IUnityContainer        Public Function Mantenimiento(ByVal Item As BE.DetalleDescuentoIncrementoTipoVentaPersonas) As Short Implements IBCDetalleDescuentoIncrementoTipoVentaPersonas.Mantenimiento            Try                Dim rep = ContainerService.Resolve(Of DA.IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio)()                Using Scope As New System.Transactions.TransactionScope()                    If Item.ChangeTracker.State <> ObjectState.Deleted Then                        If Item.ProcesarVerificarDatos() = 0 Then                            Mantenimiento = 0                            Exit Function                        End If                    End If                    Mantenimiento = rep.Maintenance(Item)                    Scope.Complete()                End Using            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                'If (rethrow) Then                'Throw                'End If                If ex.InnerException Is Nothing Then                    Item.vMensajeError = ex.Message                Else                    Item.vMensajeError = ex.InnerException.Message                End If                Mantenimiento = 0            End Try        End Function
        Public Function DeleteRegistro(ByVal item As BE.DetalleDescuentoIncrementoTipoVentaPersonas, ByVal cDTP_ID As String, ByVal cART_ID As String, ByVal cDDT_ITEM As Short) As Short Implements IBCDetalleDescuentoIncrementoTipoVentaPersonas.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cDTP_ID, cART_ID, cDDT_ITEM)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    item.vMensajeError = ex.Message
                Else
                    item.vMensajeError = ex.InnerException.Message
                End If
                DeleteRegistro = 0
            End Try

        End Function
    End ClassEnd Namespace