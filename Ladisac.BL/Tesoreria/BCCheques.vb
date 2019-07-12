Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCCheques
        Implements IBCCheques

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.Cheques) As Short Implements IBCCheques.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IChequesRepositorio)()
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

        Public Function spActualizarCorrelativo(ByVal Orm As BE.Cheques) As Short Implements IBCCheques.spActualizarCorrelativo
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IChequesRepositorio)()
                    rep.spActualizarCorrelativo(Orm)
                    Scope.Complete()
                    spActualizarCorrelativo = 1
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
                    spActualizarCorrelativo = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
