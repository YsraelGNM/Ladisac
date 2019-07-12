Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCDocPersonas
        Implements IBCDocPersonas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoDocPersonas(ByVal Item As BE.DocPersonas) As Short Implements IBCDocPersonas.MantenimientoDocPersonas
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoDocPersonas = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoDocPersonas = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoDocPersonas = 0
            End Try
        End Function

        Public Function spEliminarDocPersonasPER_ID(ByVal PER_ID As String) As Short Implements IBCDocPersonas.spEliminarDocPersonasPER_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                    rep.spEliminarDocPersonasPER_ID(PER_ID)
                    Scope.Complete()
                    spEliminarDocPersonasPER_ID = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarDocPersonasPER_ID = 0
                End Try
            End Using
        End Function

        'Public Function DeleteRegistro(ByVal item As BE.DocPersonas, ByVal cPER_ID As String, ByVal cTDP_ID As String) As Short Implements IBCDocPersonas.DeleteRegistro
        '    Try
        '        Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
        '        Using Scope As New System.Transactions.TransactionScope()
        '            DeleteRegistro = rep.DeleteRegistro(item, cPER_ID, cTDP_ID)
        '            Scope.Complete()
        '        End Using
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        'If (rethrow) Then
        '        'Throw
        '        'End If
        '        If ex.InnerException Is Nothing Then
        '            item.vMensajeError = ex.Message
        '        Else
        '            item.vMensajeError = ex.InnerException.Message
        '        End If
        '        DeleteRegistro = 0
        '    End Try
        'End Function

        Public Function EliminarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String) As Short Implements IBCDocPersonas.EliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                    rep.EliminarRegistro(cPER_ID, cTDP_ID)
                    Scope.Complete()
                    EliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    EliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function ActualizarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String, ByVal cDOP_NUMERO As String, ByVal cUSU_ID As String, ByVal cDOP_FEC_GRAB As Date, ByVal cDOP_ESTADO As Boolean) As Short Implements IBCDocPersonas.ActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                    rep.ActualizarRegistro(cPER_ID, cTDP_ID, cDOP_NUMERO, cUSU_ID, cDOP_FEC_GRAB, cDOP_ESTADO)
                    Scope.Complete()
                    ActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    ActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function InsertarRegistro(ByVal cPER_ID As String, ByVal cTDP_ID As String, ByVal cDOP_NUMERO As String, ByVal cUSU_ID As String, ByVal cDOP_FEC_GRAB As Date, ByVal cDOP_ESTADO As Boolean) As Short Implements IBCDocPersonas.InsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                    rep.InsertarRegistro(cPER_ID, cTDP_ID, cDOP_NUMERO, cUSU_ID, cDOP_FEC_GRAB, cDOP_ESTADO)
                    Scope.Complete()
                    InsertarRegistro = 1
                Catch ex As Exception
                    Scope.Dispose()
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message

                    InsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function DocPersonaGetById_Numero(ByVal DOP_Numero As String) As BE.DocPersonas Implements IBCDocPersonas.DocPersonaGetById_Numero
            Dim result As DocPersonas = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocPersonasRepositorio)()
                result = rep.DocPersonaGetById_Numero(DOP_Numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace
