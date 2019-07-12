Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCTipoPersonas
        Implements IBCTipoPersonas


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoTipoPersonas(ByVal Item As BE.TipoPersonas) As Short Implements IBCTipoPersonas.MantenimientoTipoPersonas
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoPersonasRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoTipoPersonas = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoTipoPersonas = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoTipoPersonas = 0
            End Try
        End Function
    End Class
End Namespace
