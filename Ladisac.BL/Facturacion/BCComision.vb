Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCComision
        Implements IBCComision


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoComision(ByVal Item As BE.Comision) As Short Implements IBCComision.MantenimientoComision
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComisionRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoComision = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoComision = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoComision = 0
            End Try
        End Function
    End Class
End Namespace