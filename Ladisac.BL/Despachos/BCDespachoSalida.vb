Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDespachoSalida
        Implements IBCDespachoSalida

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DespachoSalidaGetById(ByVal DSA_ID As Integer) As BE.DespachoSalida Implements IBCDespachoSalida.DespachoSalidaGetById
            Dim result As DespachoSalida = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachoSalidaRepositorio)()
                result = rep.GetById(DSA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDespachoSalida() As String Implements IBCDespachoSalida.ListaDespachoSalida
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachoSalidaRepositorio)()
                result = rep.ListaDespachoSalida
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub MantenimientoDespachoSalida(ByVal mDespachoSalida As BE.DespachoSalida) Implements IBCDespachoSalida.MantenimientoDespachoSalida
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachoSalidaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mDespachoSalida.ChangeTracker.State = ObjectState.Added) Then
                        mDespachoSalida.DSA_ID = bcherramientas.Get_Id("DespachoSalida")
                    ElseIf (mDespachoSalida.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mCod As Integer = bcherramientas.Get_Id("DespachoSalidaDetalle")
                    For Each mItem In mDespachoSalida.DespachoSalidaDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DSD_ID = mCod
                            mCod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mDespachoSalida)

                    Scope.Complete()

                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDespacho(ByVal Numero As String) As String Implements IBCDespachoSalida.ListaDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDespacho", Numero)
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
