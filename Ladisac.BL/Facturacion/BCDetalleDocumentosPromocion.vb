Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleDocumentosPromocion
        Implements IBCDetalleDocumentosPromocion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.DetalleDocumentosPromocion) As Short Implements IBCDetalleDocumentosPromocion.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosPromocionRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            Mantenimiento = 0
                            Exit Function
                        End If
                    End If
                    Mantenimiento = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                Mantenimiento = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IBCDetalleDocumentosPromocion.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosPromocionRepositorio)()
                    rep.spActualizarRegistro(Orm)
                    Scope.Complete()
                    spActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IBCDetalleDocumentosPromocion.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosPromocionRepositorio)()
                    rep.spInsertarRegistro(Orm)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IBCDetalleDocumentosPromocion.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosPromocionRepositorio)()
                    rep.spEliminarRegistro(Orm)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistroGeneral(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IBCDetalleDocumentosPromocion.spEliminarRegistroGeneral
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosPromocionRepositorio)()
                    rep.spEliminarRegistroGeneral(Orm)
                    Scope.Complete()
                    spEliminarRegistroGeneral = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spEliminarRegistroGeneral = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
