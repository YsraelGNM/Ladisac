Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCMoneda
        Implements IBCMoneda
        Implements IBCMonedaQueries
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MonedaQuery(Optional ByVal monId As String = Nothing) As String Implements IBCMonedaQueries.MonedaQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.MonedasQuery, monId)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MonedaSeek(ByVal monId As String) As BE.Moneda Implements IBCMonedaQueries.MonedaSeek
            Dim result As Moneda = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMonedaRepositorio)()
                result = rep.GetById(monId)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoMonedaDescripcion(ByVal id As String, ByVal descripcion As String) Implements IBCMoneda.MantenimientoMonedaDescripcion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMonedaRepositorio)()
                rep.ModificarDescription(id, descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function MantenimientoMoneda(ByVal Item As BE.Moneda) As Short Implements IBCMoneda.MantenimientoMoneda
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMonedaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoMoneda = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoMoneda = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoMoneda = 0
            End Try
        End Function

        Public Function ListaMoneda() As String Implements IBCMoneda.ListaMoneda
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMonedaRepositorio)()
                result = rep.ListaMoneda
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


