Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTipoVenta
        Implements IBCTipoVenta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function ListaTipoVenta() As String Implements IBCTipoVenta.ListaTipoVenta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoVentaRepositorio)()
                result = rep.ListaTipoVenta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function Mantenimiento(ByVal Item As BE.TipoVenta) As Short Implements IBCTipoVenta.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoVentaRepositorio)()
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
                Item.vMensajeError = ex.InnerException.Message
                Mantenimiento = 0
            End Try
        End Function
        Public Function TipoVentaGetById(ByVal TIV_ID As String) As BE.TipoVenta Implements IBCTipoVenta.TipoVentaGetById

        End Function
    End Class
End Namespace


