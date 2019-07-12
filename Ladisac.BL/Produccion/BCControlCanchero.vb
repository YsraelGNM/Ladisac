Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlCanchero
        Implements IBCControlCanchero

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlCancheroGetById(ByVal CCA_ID As Integer) As BE.ControlCanchero Implements IBCControlCanchero.ControlCancheroGetById
            Dim result As ControlCanchero = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCancheroRepositorio)()
                result = rep.GetById(CCA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlCanchero() As String Implements IBCControlCanchero.ListaControlCanchero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCancheroRepositorio)()
                result = rep.ListaControlCanchero
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlCanchero(ByVal mControlCanchero As BE.ControlCanchero) Implements IBCControlCanchero.MantenimientoControlCanchero
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCancheroRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlCancheroDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlCanchero.ChangeTracker.State = ObjectState.Added) Then
                        mControlCanchero.CCA_ID = bcherramientas.Get_Id("ControlCanchero")
                    ElseIf (mControlCanchero.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlCancheroDetalle)
                    For Each mObj In mControlCanchero.ControlCancheroDetalle
                        Dim mDet As New ControlCancheroDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mControlCanchero.ChangeTracker.ChangeTrackingEnabled = False
                    mControlCanchero.ControlCancheroDetalle = Nothing
                    mControlCanchero.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlCanchero)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DCA_ID = bcherramientas.Get_Id("ControlCancheroDetalle")
                            mItem.CCA_ID = mControlCanchero.CCA_ID
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

        Public Function GetByPro_Id(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlCanchero) Implements IBCControlCanchero.GetByPro_Id
            Dim result As List(Of ControlCanchero) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCancheroRepositorio)()
                result = rep.GetByPro_Id(PRO_Id)
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
