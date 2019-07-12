Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCDepartamento
        Implements IBCDepartamento
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoDepartamento(ByVal Item As BE.Departamento) As Short Implements IBCDepartamento.MantenimientoDepartamento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDepartamentoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoDepartamento = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoDepartamento = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoDepartamento = 0
            End Try
        End Function
    End Class
End Namespace

