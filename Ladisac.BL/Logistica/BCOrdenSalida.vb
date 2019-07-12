Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenSalida
        Implements IBCOrdenSalida

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenSalida() As String Implements IBCOrdenSalida.ListaOrdenSalida
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenSalidaRepositorio)()
                result = rep.ListaOrdenSalida
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoOrdenSalida(ByVal mOrdenSalida As BE.OrdenSalida) Implements IBCOrdenSalida.MantenimientoOrdenSalida
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenSalidaRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenSalidaDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenSalida.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenSalida.OSA_ID = bcherramientas.Get_Id("OrdenSalida")
                    ElseIf (mOrdenSalida.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaOrdenSalidaDetalle As New List(Of OrdenSalidaDetalle)
                    For Each mObj In mOrdenSalida.OrdenSalidaDetalle
                        Dim mOrdenSalidaDetalle As New OrdenSalidaDetalle
                        mOrdenSalidaDetalle = mObj.Clone
                        mListaOrdenSalidaDetalle.Add(mOrdenSalidaDetalle)
                    Next

                    mOrdenSalida.ChangeTracker.ChangeTrackingEnabled = False
                    mOrdenSalida.OrdenSalidaDetalle = Nothing
                    mOrdenSalida.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mOrdenSalida)

                    For Each mItem In mListaOrdenSalidaDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.OSD_ID = bcherramientas.Get_Id("OrdenSalidaDetalle")
                            mItem.OSA_ID = mOrdenSalida.OSA_ID
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

        Public Function OrdenSalidaGetById(ByVal OSA_ID As Integer) As BE.OrdenSalida Implements IBCOrdenSalida.OrdenSalidaGetById
            Dim result As OrdenSalida = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenSalidaRepositorio)()
                result = rep.GetById(OSA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImpresionOrdenDeSalida(ByVal OSA_ID As Integer) As String Implements IBCOrdenSalida.ImpresionOrdenDeSalida
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionOrdenDeSalida", OSA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteOrdenSalida(ByVal FecIni As Date, ByVal FecFin As Date) As System.Data.DataTable Implements IBCOrdenSalida.ReporteOrdenSalida
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spReporteOrdenSalida", FecIni, FecFin)
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
