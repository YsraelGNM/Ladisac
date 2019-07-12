Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCProvincia
        Implements IBCProvincia
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoProvincia(ByVal Item As BE.Provincia) As Short Implements IBCProvincia.MantenimientoProvincia
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProvinciaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoProvincia = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoProvincia = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoProvincia = 0
            End Try
        End Function
    End Class
End Namespace
