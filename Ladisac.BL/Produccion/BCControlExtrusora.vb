Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlExtrusora
        Implements IBCControlExtrusora

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlExtrusoraGetById(ByVal CEX_ID As Integer) As BE.ControlExtrusora Implements IBCControlExtrusora.ControlExtrusoraGetById
            Dim result As ControlExtrusora = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlExtrusoraRepositorio)()
                result = rep.GetById(CEX_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlExtrusora() As String Implements IBCControlExtrusora.ListaControlExtrusora
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlExtrusoraRepositorio)()
                result = rep.ListaControlExtrusora
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlExtrusora(ByVal mControlExtrusora As BE.ControlExtrusora) Implements IBCControlExtrusora.MantenimientoControlExtrusora
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlExtrusoraRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlExtrusoraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlExtrusora.ChangeTracker.State = ObjectState.Added) Then
                        mControlExtrusora.CEX_ID = bcherramientas.Get_Id("ControlExtrusora")
                    ElseIf (mControlExtrusora.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlExtrusoraDetalle)
                    For Each mObj In mControlExtrusora.ControlExtrusoraDetalle
                        Dim mDet As New ControlExtrusoraDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mControlExtrusora.ChangeTracker.ChangeTrackingEnabled = False
                    mControlExtrusora.ControlExtrusoraDetalle = Nothing
                    mControlExtrusora.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlExtrusora)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DEX_ID = bcherramientas.Get_Id("ControlExtrusoraDetalle")
                            mItem.CEX_ID = mControlExtrusora.CEX_ID
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

        Public Function ValidarHoroDigital(ByVal CPA_ID As Integer, ByVal HoroDigital As Decimal) As String Implements IBCControlExtrusora.ValidarHoroDigital
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spValidarHoroDigital", CPA_ID, HoroDigital)
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
