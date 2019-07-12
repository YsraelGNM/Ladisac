Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlPeso
        Implements IBCControlPeso

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlPesoGetById(ByVal CPE_ID As Integer) As BE.ControlPeso Implements IBCControlPeso.ControlPesoGetById
            Dim result As ControlPeso = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPesoRepositorio)()
                result = rep.GetById(CPE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlPeso() As String Implements IBCControlPeso.ListaControlPeso
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPesoRepositorio)()
                result = rep.ListaControlPeso
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlPeso(ByVal mControlPeso As BE.ControlPeso) Implements IBCControlPeso.MantenimientoControlPeso
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPesoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlPesoDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlPeso.ChangeTracker.State = ObjectState.Added) Then
                        mControlPeso.CPE_ID = bcherramientas.Get_Id("ControlPeso")
                    ElseIf (mControlPeso.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlPesoDetalle)
                    For Each mObj In mControlPeso.ControlPesoDetalle
                        Dim mDet As New ControlPesoDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mControlPeso.ChangeTracker.ChangeTrackingEnabled = False
                    mControlPeso.ControlPesoDetalle = Nothing
                    mControlPeso.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlPeso)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DPE_ID = bcherramientas.Get_Id("ControlPesoDetalle")
                            mItem.CPE_ID = mControlPeso.CPE_ID
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

        Public Function ControlPesoGetByIdPRO(ByVal PRO_ID As Integer) As BE.ControlPeso Implements IBCControlPeso.ControlPesoGetByIdPRO
            Dim result As ControlPeso = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPesoRepositorio)()
                result = rep.GetByIdPRO(PRO_ID)
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
