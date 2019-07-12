Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCDetalleListaPrecios
        Implements IBCDetalleListaPrecios

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function MantenimientoDetalleListaPrecios(ByVal Item As BE.DetalleListaPrecios) As Short Implements IBCDetalleListaPrecios.MantenimientoDetalleListaPrecios
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleListaPreciosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoDetalleListaPrecios = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoDetalleListaPrecios = rep.Maintenance(Item)
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

                MantenimientoDetalleListaPrecios = 0
            End Try
        End Function

        'Public Function DeleteRegistroDetalleListaPrecios(ByVal Item As BE.DetalleListaPrecios, ByVal cLPR_ID As String, ByVal cART_ID As String) As Short Implements IBCDetalleListaPrecios.DeleteRegistroDetalleListaPrecios
        '    Try
        '        Dim rep = ContainerService.Resolve(Of DA.IDetalleListaPreciosRepositorio)()
        '        Using Scope As New System.Transactions.TransactionScope()
        '            'If Item.ChangeTracker.State <> ObjectState.Deleted Then
        '            'If Item.ProcesarVerificarDatos() = 0 Then
        '            'DeleteRegistroDetalleListaPrecios = 0
        '            'Exit Function
        '            'End If
        '            'End If
        '            DeleteRegistroDetalleListaPrecios = rep.DeleteRegistro(Item, cLPR_ID, cART_ID)
        '            Scope.Complete()
        '        End Using
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        'If (rethrow) Then
        '        'Throw
        '        'End If
        '        If ex.InnerException Is Nothing Then
        '            Item.vMensajeError = ex.Message
        '        Else
        '            Item.vMensajeError = ex.InnerException.Message
        '        End If

        '        DeleteRegistroDetalleListaPrecios = 0
        '    End Try
        'End Function

        Public Function spActualizarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String, ByVal cDLP_PRECIO_MINIMO As Double, ByVal cDLP_PRECIO_UNITARIO As Double, ByVal cDLP_RECARGO_ENVIO As Double, ByVal cUSU_ID As String, ByVal cDLP_FEC_GRAB As Date, ByVal cDLP_ESTADO As Boolean) As Short Implements IBCDetalleListaPrecios.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleListaPreciosRepositorio)()
                    rep.spActualizarRegistro(cLPR_ID, cART_ID, cDLP_PRECIO_MINIMO, cDLP_PRECIO_UNITARIO, cDLP_RECARGO_ENVIO, cUSU_ID, cDLP_FEC_GRAB, cDLP_ESTADO)
                    Scope.Complete()
                    spActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String) As Short Implements IBCDetalleListaPrecios.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleListaPreciosRepositorio)()
                    rep.spEliminarRegistro(cLPR_ID, cART_ID)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String, ByVal cDLP_PRECIO_MINIMO As Double, ByVal cDLP_PRECIO_UNITARIO As Double, ByVal cDLP_RECARGO_ENVIO As Double, ByVal cUSU_ID As String, ByVal cDLP_FEC_GRAB As Date, ByVal cDLP_ESTADO As Boolean) As Short Implements IBCDetalleListaPrecios.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleListaPreciosRepositorio)()
                    rep.spInsertarRegistro(cLPR_ID, cART_ID, cDLP_PRECIO_MINIMO, cDLP_PRECIO_UNITARIO, cDLP_RECARGO_ENVIO, cUSU_ID, cDLP_FEC_GRAB, cDLP_ESTADO)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
