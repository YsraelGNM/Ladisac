Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSalidaSecadero
        Implements IBCSalidaSecadero

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSalidaSecadero() As String Implements IBCSalidaSecadero.ListaSalidaSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaSecaderoRepositorio)()
                result = rep.ListaSalidaSecadero
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoSalidaSecadero(ByVal mSalidaSecadero As BE.SalidaSecadero) Implements IBCSalidaSecadero.MantenimientoSalidaSecadero
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaSecaderoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.ISalidaSecaderoDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSalidaSecadero.ChangeTracker.State = ObjectState.Added) Then
                        mSalidaSecadero.SSE_ID = bcherramientas.Get_Id("SalidaSecadero")
                    ElseIf (mSalidaSecadero.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of SalidaSecaderoDetalle)
                    For Each mObj In mSalidaSecadero.SalidaSecaderoDetalle
                        Dim mDet As New SalidaSecaderoDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mSalidaSecadero.ChangeTracker.ChangeTrackingEnabled = False
                    mSalidaSecadero.SalidaSecaderoDetalle = Nothing
                    mSalidaSecadero.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mSalidaSecadero)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DSE_ID = bcherramientas.Get_Id("SalidaSecaderoDetalle")
                            mItem.SSE_ID = mSalidaSecadero.SSE_ID
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

        Public Function SalidaSecaderoGetById(ByVal SSE_ID As Integer) As BE.SalidaSecadero Implements IBCSalidaSecadero.SalidaSecaderoGetById
            Dim result As SalidaSecadero = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaSecaderoRepositorio)()
                result = rep.GetById(SSE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaSecaderoCombustible() As String Implements IBCSalidaSecadero.ListaSalidaSecaderoCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaSalidaSecaderoCombustible")
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
