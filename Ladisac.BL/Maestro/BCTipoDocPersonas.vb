Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCTipoDocPersonas
        Implements IBCTipoDocPersonas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoTipoDocPersonas(ByVal Item As BE.TipoDocPersonas) As Short Implements IBCTipoDocPersonas.MantenimientoTipoDocPersonas
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoDocPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoTipoDocPersonas = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoTipoDocPersonas = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoTipoDocPersonas = 0
            End Try
        End Function
    End Class
End Namespace
