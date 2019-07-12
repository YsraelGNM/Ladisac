Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCDireccionesPersonas
        Implements IBCDireccionesPersonas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public MensajeError As String = ""

        Public Function MantenimientoDireccionesPersonas(ByVal Item As BE.DireccionesPersonas) As Short Implements IBCDireccionesPersonas.MantenimientoDireccionesPersonas
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoDireccionesPersonas = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoDireccionesPersonas = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If Not IsNothing(ex.InnerException) Then
                    Item.vMensajeError = ex.InnerException.Message
                Else
                    Item.vMensajeError = ex.Message
                End If

                MantenimientoDireccionesPersonas = 0
            End Try
        End Function

        Public Function spEliminarDireccionesPersonasPER_ID(ByVal PER_ID As String) As Short Implements IBCDireccionesPersonas.spEliminarDireccionesPersonasPER_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                    rep.spEliminarDireccionesPersonasPER_ID(PER_ID)
                    Scope.Complete()
                    spEliminarDireccionesPersonasPER_ID = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    If ex.InnerException Is Nothing Then
                        MensajeError &= ex.Message
                    Else
                        MensajeError &= ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spEliminarDireccionesPersonasPER_ID = 0
                End Try
            End Using
        End Function

        Public Function DeleteRegistro(ByVal item As BE.DireccionesPersonas, ByVal cPER_ID As String, ByVal cDIR_ID As String) As Short Implements IBCDireccionesPersonas.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cPER_ID, cDIR_ID)
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

        Public Function spActualizarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cDIR_DESCRIPCION As String, ByVal cDIR_TIPO As Short, ByVal cDIR_REFERENCIA As String, ByVal cDIS_ID As String, ByVal cUSU_ID As String, ByVal cDIR_FEC_GRAB As Date, ByVal cDIR_ESTADO As Boolean) As Short Implements IBCDireccionesPersonas.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                    rep.spActualizarRegistro(cDIR_ID, cPER_ID, cDIR_DESCRIPCION, cDIR_TIPO, cDIR_REFERENCIA, cDIS_ID, cUSU_ID, cDIR_FEC_GRAB, cDIR_ESTADO)
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

        Public Function spInsertarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cDIR_DESCRIPCION As String, ByVal cDIR_TIPO As Short, ByVal cDIR_REFERENCIA As String, ByVal cDIS_ID As String, ByVal cUSU_ID As String, ByVal cDIR_FEC_GRAB As Date, ByVal cDIR_ESTADO As Boolean) As Short Implements IBCDireccionesPersonas.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                    rep.spInsertarRegistro(cDIR_ID, cPER_ID, cDIR_DESCRIPCION, cDIR_TIPO, cDIR_REFERENCIA, cDIS_ID, cUSU_ID, cDIR_FEC_GRAB, cDIR_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cDIR_ID As String, ByVal cPER_ID As String) As Short Implements IBCDireccionesPersonas.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                    rep.spEliminarRegistro(cDIR_ID, cPER_ID)
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

        Public Function spEliminarRegistroNuevo(ByVal cDIR_ID As String, ByVal cPER_ID As String, ByVal cUSU_ID As String) As Short Implements IBCDireccionesPersonas.spEliminarRegistroNuevo
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDireccionesPersonasRepositorio)()
                    rep.spEliminarRegistroNuevo(cDIR_ID, cPER_ID, cUSU_ID)
                    Scope.Complete()
                    spEliminarRegistroNuevo = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroNuevo = 0
                End Try
            End Using
        End Function
    End Class
End Namespace


