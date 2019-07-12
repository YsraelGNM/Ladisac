Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlanMantenimiento
        Implements IBCPlanMantenimiento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaPlanMantenimiento() As String Implements IBCPlanMantenimiento.ListaPlanMantenimiento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanMantenimientoRepositorio)()
                result = rep.ListaPlanMantenimiento
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoPlanMantenimiento(ByVal mPlanMantenimiento As BE.PlanMantto) Implements IBCPlanMantenimiento.MantenimientoPlanMantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanMantenimientoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.ISuministroPlanManttoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mPlanMantenimiento.ChangeTracker.State = ObjectState.Added) Then
                        mPlanMantenimiento.PMO_ID = bcherramientas.Get_Id("PlanMantenimiento")
                    ElseIf (mPlanMantenimiento.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaSuministro As New List(Of SuministroPlanMantto)
                    For Each mObj In mPlanMantenimiento.SuministroPlanMantto
                        Dim mSuPlMa As New SuministroPlanMantto
                        mSuPlMa = mObj.Clone
                        mListaSuministro.Add(mSuPlMa)
                    Next

                    mPlanMantenimiento.ChangeTracker.ChangeTrackingEnabled = False
                    mPlanMantenimiento.SuministroPlanMantto = Nothing
                    mPlanMantenimiento.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mPlanMantenimiento)

                    For Each mItem In mListaSuministro
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.SPM_ID = bcherramientas.Get_Id("SuministroPlanMantto")
                            mItem.PMO_ID = mPlanMantenimiento.PMO_ID
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

        Public Function PlanMantenimientoGetById(ByVal PMO_ID As Integer) As BE.PlanMantto Implements IBCPlanMantenimiento.PlanMantenimientoGetById
            Dim result As PlanMantto = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanMantenimientoRepositorio)()
                result = rep.GetById(PMO_ID)
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
