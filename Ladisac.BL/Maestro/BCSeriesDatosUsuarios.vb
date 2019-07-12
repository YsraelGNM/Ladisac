Imports Ladisac.BENamespace Ladisac.BLPublic Class BCSeriesDatosUsuarios        Implements IBCSeriesDatosUsuarios        <Dependency()> _        Public Property ContainerService As IUnityContainer        Public Function Mantenimiento(ByVal Item As BE.SeriesDatosUsuarios) As Short Implements IBCSeriesDatosUsuarios.Mantenimiento            Try                Dim rep = ContainerService.Resolve(Of DA.ISeriesDatosUsuariosRepositorio)()                Using Scope As New System.Transactions.TransactionScope()                    If Item.ChangeTracker.State <> ObjectState.Deleted Then                        If Item.ProcesarVerificarDatos() = 0 Then                            Mantenimiento = 0                            Exit Function                        End If                    End If                    Mantenimiento = rep.Maintenance(Item)                    Scope.Complete()                End Using            Catch ex As Exception                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)                'If (rethrow) Then                'Throw                'End If                If ex.InnerException Is Nothing Then                    Item.vMensajeError = ex.Message                Else                    Item.vMensajeError = ex.InnerException.Message                End If                Mantenimiento = 0            End Try        End Function
        Public Function DeleteRegistro(ByVal item As BE.SeriesDatosUsuarios, ByVal cDAU_ID As String, ByVal cPVE_ID As String, ByVal cTDO_ID As String, ByVal cCTD_COR_SERIE As String) As Short Implements IBCSeriesDatosUsuarios.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISeriesDatosUsuariosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cDAU_ID, cPVE_ID, cTDO_ID, cCTD_COR_SERIE)
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