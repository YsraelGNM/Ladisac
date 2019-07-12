Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCContactoPersona
        Implements IBCContactoPersona

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.ContactoPersona) As Short Implements IBCContactoPersona.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
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

        'Public Function DeleteRegistro(ByVal item As BE.ContactoPersona, ByVal cPER_ID As String, ByVal cCOP_ID As String) As Short Implements IBCContactoPersona.DeleteRegistro
        '    Try
        '        Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
        '        Using Scope As New System.Transactions.TransactionScope()
        '            DeleteRegistro = rep.DeleteRegistro(item, cPER_ID, cCOP_ID)
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

        Public Function ActualizarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String, ByVal cCOP_TIPO As Short, ByVal cCOP_DESCRIPCION As String, ByVal cCOP_DIRECCION As String, ByVal cCOP_TELEFONO As String, ByVal cCOP_EMAIL As String, ByVal cUSU_ID As String, ByVal cCOP_FEC_GRAB As Date, ByVal cCOP_ESTADO As Boolean) As Short Implements IBCContactoPersona.ActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
                    rep.ActualizarRegistro(cPER_ID, cCOP_ID, cCOP_TIPO, cCOP_DESCRIPCION, cCOP_DIRECCION, cCOP_TELEFONO, cCOP_EMAIL, cUSU_ID, cCOP_FEC_GRAB, cCOP_ESTADO)
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

        Public Function EliminarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String) As Short Implements IBCContactoPersona.EliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
                    rep.EliminarRegistro(cPER_ID, cCOP_ID)
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

        Public Function InsertarRegistro(ByVal cPER_ID As String, ByVal cCOP_ID As String, ByVal cCOP_TIPO As Short, ByVal cCOP_DESCRIPCION As String, ByVal cCOP_DIRECCION As String, ByVal cCOP_TELEFONO As String, ByVal cCOP_EMAIL As String, ByVal cUSU_ID As String, ByVal cCOP_FEC_GRAB As Date, ByVal cCOP_ESTADO As Boolean) As Short Implements IBCContactoPersona.InsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
                    rep.InsertarRegistro(cPER_ID, cCOP_ID, cCOP_TIPO, cCOP_DESCRIPCION, cCOP_DIRECCION, cCOP_TELEFONO, cCOP_EMAIL, cUSU_ID, cCOP_FEC_GRAB, cCOP_ESTADO)
                    Scope.Complete()
                    InsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    InsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarContactoPersonaPER_ID(ByVal PER_ID As String) As Short Implements IBCContactoPersona.spEliminarContactoPersonaPER_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IContactoPersonaRepositorio)()
                    rep.spEliminarContactoPersonaPER_ID(PER_ID)
                    Scope.Complete()
                    spEliminarContactoPersonaPER_ID = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarContactoPersonaPER_ID = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
