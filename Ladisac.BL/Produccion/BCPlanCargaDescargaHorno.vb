Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlanCargaDescargaHorno
        Implements IBCPlanCargaDescargaHorno

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaPlanCargaDescargaHorno() As String Implements IBCPlanCargaDescargaHorno.ListaPlanCargaDescargaHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanCargaDescargaHornoRepositorio)()
                result = rep.ListaPlanCargaDescargaHorno
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoPlanCargaDescargaHorno(ByVal mPlanCargaDescargaHorno As BE.PlanCargaDescargaHorno) Implements IBCPlanCargaDescargaHorno.MantenimientoPlanCargaDescargaHorno
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanCargaDescargaHornoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mPlanCargaDescargaHorno.ChangeTracker.State = ObjectState.Added) Then
                        mPlanCargaDescargaHorno.CDH_ID = bcherramientas.Get_Id("PlanCargaDescargaHorno")
                    ElseIf (mPlanCargaDescargaHorno.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mPlanCargaDescargaHorno)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function PlanCargaDescargaHornoGetById(ByVal CDH_ID As Integer) As BE.PlanCargaDescargaHorno Implements IBCPlanCargaDescargaHorno.PlanCargaDescargaHornoGetById
            Dim result As PlanCargaDescargaHorno = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanCargaDescargaHornoRepositorio)()
                result = rep.GetById(CDH_ID)
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
