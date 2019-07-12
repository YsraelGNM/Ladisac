Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCCorrelativoTipoDocumento
        Implements IBCCorrelativoTipoDocumento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.CorrelativoTipoDocumento) As Short Implements IBCCorrelativoTipoDocumento.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
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

        Public Function spActualizarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements IBCCorrelativoTipoDocumento.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
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

        Public Function spEliminarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements IBCCorrelativoTipoDocumento.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
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

        Public Function spInsertarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements IBCCorrelativoTipoDocumento.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
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

        Public Function spActualizarRegistroDespacho(ByVal Orm As BE.CorrelativoTipoDocumento) As Short Implements IBCCorrelativoTipoDocumento.spActualizarRegistroDespacho
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
                rep.spActualizarRegistro(Orm)
                spActualizarRegistroDespacho = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                spActualizarRegistroDespacho = 0
            End Try
        End Function
    End Class
End Namespace
