Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDatosUsuarios
        Implements IBCDatosUsuarios

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Mantenimiento(ByVal Item As BE.DatosUsuarios) As Short Implements IBCDatosUsuarios.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosUsuariosRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.DatosUsuarios, ByVal cDAU_ID As String) As Short Implements IBCDatosUsuarios.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosUsuariosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cDAU_ID)
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

        Public Function GetById(ByVal DAU_Id As String) As BE.DatosUsuarios Implements IBCDatosUsuarios.GetById
            Dim result As DatosUsuarios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosUsuariosRepositorio)()
                result = rep.GetById(DAU_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdByUSU(ByVal USU_Id As String) As BE.DatosUsuarios Implements IBCDatosUsuarios.GetByIdByUSU
            Dim result As DatosUsuarios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosUsuariosRepositorio)()
                result = rep.GetByIdByUSU(USU_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdByPER(ByVal PER_Id As String) As BE.DatosUsuarios Implements IBCDatosUsuarios.GetByIdByPER
            Dim result As DatosUsuarios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosUsuariosRepositorio)()
                result = rep.GetByIdByPER(PER_Id)
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
