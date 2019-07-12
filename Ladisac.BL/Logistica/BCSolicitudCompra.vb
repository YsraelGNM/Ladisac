Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSolicitudCompra
        Implements IBCSolicitudCompra

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSolicitudCompra() As String Implements IBCSolicitudCompra.ListaSolicitudCompra
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudCompraRepositorio)()
                result = rep.ListaSolicitudCompra
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function SolicitudCompraGetById(ByVal SOC_ID As Integer) As BE.SolicitudCompra Implements IBCSolicitudCompra.SolicitudCompraGetById
            Dim result As SolicitudCompra = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudCompraRepositorio)()
                result = rep.GetById(SOC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoSolicitudCompra(ByVal mSolicitudCompra As BE.SolicitudCompra) Implements IBCSolicitudCompra.MantenimientoSolicitudCompra
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudCompraRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.ISolicitudCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSolicitudCompra.ChangeTracker.State = ObjectState.Added) Then
                        mSolicitudCompra.SOC_ID = bcherramientas.Get_Id("SolicitudCompra")
                    ElseIf (mSolicitudCompra.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaSolicitudCompraDetalle As New List(Of SolicitudCompraDetalle)
                    For Each mObj In mSolicitudCompra.SolicitudCompraDetalle
                        Dim mSolicitudCompraDetalle As New SolicitudCompraDetalle
                        mSolicitudCompraDetalle = mObj.Clone
                        mListaSolicitudCompraDetalle.Add(mSolicitudCompraDetalle)
                    Next


                    mSolicitudCompra.ChangeTracker.ChangeTrackingEnabled = False
                    mSolicitudCompra.SolicitudCompraDetalle = Nothing
                    mSolicitudCompra.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mSolicitudCompra)

                    For Each mItem In mListaSolicitudCompraDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.SCD_ID = bcherramientas.Get_Id("SolicitudCompraDetalle")
                            mItem.SOC_ID = mSolicitudCompra.SOC_ID
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

        Public Function ImpresionSolicitudDeCompra(ByVal SOC_ID As Integer) As String Implements IBCSolicitudCompra.ImpresionSolicitudDeCompra
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionSolicitudDeCompra", SOC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoSolicitudCompraDetalle(ByVal mSolicitudCompraDetalle As BE.SolicitudCompraDetalle) Implements IBCSolicitudCompra.MantenimientoSolicitudCompraDetalle
            Try
                Dim repDeta = ContainerService.Resolve(Of DA.ISolicitudCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSolicitudCompraDetalle.ChangeTracker.State = ObjectState.Added) Then

                    ElseIf (mSolicitudCompraDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    repDeta.Maintenance(mSolicitudCompraDetalle)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function SolicitudCompraDetalleGetById(ByVal SCD_ID As Integer) As BE.SolicitudCompraDetalle Implements IBCSolicitudCompra.SolicitudCompraDetalleGetById
            Dim result As SolicitudCompraDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudCompraDetalleRepositorio)()
                result = rep.GetById(SCD_ID)
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
