Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCRolPersonaTipoPersona
        Implements IBCRolPersonaTipoPersona

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoRolPersonaTipoPersona(ByVal Item As BE.RolPersonaTipoPersona) As Short Implements IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoRolPersonaTipoPersona = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoRolPersonaTipoPersona = rep.Maintenance(Item)
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

                MantenimientoRolPersonaTipoPersona = 0
            End Try
        End Function

        Public Function spEliminarRolPersonaTipoPersonaPER_ID(ByVal PER_ID As String) As Short Implements IBCRolPersonaTipoPersona.spEliminarRolPersonaTipoPersonaPER_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
                    rep.spEliminarRolPersonaTipoPersonaPER_ID(PER_ID)
                    Scope.Complete()
                    spEliminarRolPersonaTipoPersonaPER_ID = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRolPersonaTipoPersonaPER_ID = 0
                End Try
            End Using
        End Function

        'Public Function DeleteRegistro(ByVal item As BE.RolPersonaTipoPersona, ByVal cPER_ID As String, ByVal cTPE_ID As String) As Short Implements IBCRolPersonaTipoPersona.DeleteRegistro
        '    Try
        '        Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
        '        Using Scope As New System.Transactions.TransactionScope()
        '            DeleteRegistro = rep.DeleteRegistro(item, cPER_ID, cTPE_ID)
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

        Public Function spActualizarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String, ByVal cUSU_ID As String, ByVal cRTP_FEC_GRAB As Date, ByVal cRTP_ESTADO As Boolean) As Short Implements IBCRolPersonaTipoPersona.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
                    rep.spActualizarRegistro(cPER_ID, cTPE_ID, cUSU_ID, cRTP_FEC_GRAB, cRTP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String) As Short Implements IBCRolPersonaTipoPersona.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
                    rep.spEliminarRegistro(cPER_ID, cTPE_ID)
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

        Public Function spInsertarRegistro(ByVal cPER_ID As String, ByVal cTPE_ID As String, ByVal cUSU_ID As String, ByVal cRTP_FEC_GRAB As Date, ByVal cRTP_ESTADO As Boolean) As Short Implements IBCRolPersonaTipoPersona.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IRolPersonaTipoPersonaRepositorio)()
                    rep.spInsertarRegistro(cPER_ID, cTPE_ID, cUSU_ID, cRTP_FEC_GRAB, cRTP_ESTADO)
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
