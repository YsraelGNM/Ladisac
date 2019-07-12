Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCRendicionCuenta
        Implements IBCRendicionCuenta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRendicionCuenta() As String Implements IBCRendicionCuenta.ListaRendicionCuenta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionCuentaRepositorio)()
                result = rep.ListaRendicionCuenta
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub MantenimientoRendicionCuenta(ByVal mRendicionCuenta As BE.RendicionCuenta) Implements IBCRendicionCuenta.MantenimientoRendicionCuenta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionCuentaRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IRendicionCuentaDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRendicionCuenta.ChangeTracker.State = ObjectState.Added) Then
                        mRendicionCuenta.REC_ID = bcherramientas.Get_Id("RendicionCuenta")
                    ElseIf (mRendicionCuenta.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaRendicionCuentaDetalle As New List(Of RendicionCuentaDetalle)
                    For Each mObj In mRendicionCuenta.RendicionCuentaDetalle


                        Dim mRendicionCuentaDetalle As New RendicionCuentaDetalle
                        mRendicionCuentaDetalle = mObj.Clone
                        mListaRendicionCuentaDetalle.Add(mRendicionCuentaDetalle)
                    Next


                    mRendicionCuenta.ChangeTracker.ChangeTrackingEnabled = False
                    mRendicionCuenta.RendicionCuentaDetalle = Nothing
                    mRendicionCuenta.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mRendicionCuenta)

                    For Each mItem In mListaRendicionCuentaDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.RCD_ID = bcherramientas.Get_Id("RendicionCuentaDetalle")
                            mItem.REC_ID = mRendicionCuenta.REC_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function RendicionCuentaGetById(ByVal REC_ID As Integer) As BE.RendicionCuenta Implements IBCRendicionCuenta.RendicionCuentaGetById
            Dim result As RendicionCuenta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionCuentaRepositorio)()
                result = rep.GetById(REC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRendicionCuentaConserge(ByVal USU_ID As String) As String Implements IBCRendicionCuenta.ListaRendicionCuentaConserge
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPCSinCotizacionConserje", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function RendicionCuentaDetalleGetById(ByVal PCD_ID As Integer) As BE.RendicionCuentaDetalle Implements IBCRendicionCuenta.RendicionCuentaDetalleGetById
            Dim result As RendicionCuentaDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionCuentaDetalleRepositorio)()
                result = rep.GetById(PCD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoRendicionCuentaDetalle(ByVal mRendicionCuentaDetalle As BE.RendicionCuentaDetalle) Implements IBCRendicionCuenta.MantenimientoRendicionCuentaDetalle
            Try
                Dim repDeta = ContainerService.Resolve(Of DA.IRendicionCuentaDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRendicionCuentaDetalle.ChangeTracker.State = ObjectState.Added) Then
                       
                    ElseIf (mRendicionCuentaDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    repDeta.Maintenance(mRendicionCuentaDetalle)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace
