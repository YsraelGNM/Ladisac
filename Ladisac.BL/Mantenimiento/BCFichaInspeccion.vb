Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCFichaInspeccion
        Implements IBCFichaInspeccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function FichaInspeccionGetById(FIN_ID As Integer) As BE.FichaInspeccion Implements IBCFichaInspeccion.FichaInspeccionGetById
            Dim result As FichaInspeccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFichaInspeccionRepositorio)()
                result = rep.GetById(FIN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFichaInspeccion() As String Implements IBCFichaInspeccion.ListaFichaInspeccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFichaInspeccionRepositorio)()
                result = rep.ListaFichaInspeccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoFichaInspeccion(mFichaInspeccion As BE.FichaInspeccion) Implements IBCFichaInspeccion.MantenimientoFichaInspeccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFichaInspeccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mFichaInspeccion.ChangeTracker.State = ObjectState.Added) Then
                        mFichaInspeccion.FIN_ID = bcherramientas.Get_Id("FichaInspeccion")
                    ElseIf (mFichaInspeccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim nFID As Integer = bcherramientas.Get_Id("FichaInspeccionDetalle")
                    For Each mItem In mFichaInspeccion.FichaInspeccionDetalle.ToList
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.FID_ID = nFID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        nFID += 1
                    Next

                    rep.Maintenance(mFichaInspeccion)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ReporteFichaInspeccion() As System.Data.DataTable Implements IBCFichaInspeccion.ReporteFichaInspeccion
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spReporteFichaInspeccion", "0")
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
