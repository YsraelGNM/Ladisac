Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleFletesTransporte
        Implements IBCDetalleFletesTransporte

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.DetalleFletesTransporte) As Short Implements IBCDetalleFletesTransporte.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleFletesTransporteRepositorio)()
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

        Public Function DeleteRegistro(ByVal Item As BE.DetalleFletesTransporte, ByVal cFLE_ID As String, ByVal cFDE_ID As String, ByVal cDIS_ID As String) As Short Implements IBCDetalleFletesTransporte.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleFletesTransporteRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()

                    DeleteRegistro = rep.DeleteRegistro(Item, cFLE_ID, cFDE_ID, cDIS_ID)
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

                DeleteRegistro = 0
            End Try
        End Function
    End Class
End Namespace

