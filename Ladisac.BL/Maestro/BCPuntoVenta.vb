Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPuntoVenta
        Implements IBCPuntoVenta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoPuntoVenta(ByVal Item As BE.PuntoVenta) As Short Implements IBCPuntoVenta.MantenimientoPuntoVenta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuntoVentaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoPuntoVenta = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoPuntoVenta = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoPuntoVenta = 0
            End Try
        End Function

        Public Function PuntoVentaGetById(ByVal PVE_ID As String) As BE.PuntoVenta Implements IBCPuntoVenta.PuntoVentaGetById
            Dim result As PuntoVenta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuntoVentaRepositorio)()
                result = rep.GetById(PVE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPuntoVentaXUsu_Id(ByVal USU_ID As String) As String Implements IBCPuntoVenta.ListaPuntoVentaXUsu_Id
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPuntoventaXUsu_id", USU_ID)
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
