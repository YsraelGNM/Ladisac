Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCPais
        Implements IBCPais
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoPais(ByVal Item As BE.Pais) As Short Implements IBCPais.MantenimientoPais
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPaisRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoPais = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoPais = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoPais = 0
            End Try
        End Function
    End Class
End Namespace
