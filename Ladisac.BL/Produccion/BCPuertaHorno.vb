Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPuertaHorno
        Implements IBCPuertaHorno

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaPuertaHorno() As String Implements IBCPuertaHorno.ListaPuertaHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuertaHornoRepositorio)()
                result = rep.ListaPuertaHorno
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoPuertaHorno(ByVal mPuertaHorno As BE.PuertaHorno) Implements IBCPuertaHorno.MantenimientoPuertaHorno
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuertaHornoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mPuertaHorno.ChangeTracker.State = ObjectState.Added) Then
                        mPuertaHorno.PUE_ID = bcherramientas.Get_Id("PuertaHorno")
                    ElseIf (mPuertaHorno.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mPuertaHorno)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function PuertaHornoGetById(ByVal PUE_ID As Integer) As BE.PuertaHorno Implements IBCPuertaHorno.PuertaHornoGetById
            Dim result As PuertaHorno = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuertaHornoRepositorio)()
                result = rep.GetById(PUE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function HornoGetById(ByVal HOR_ID As Integer) As BE.Horno Implements IBCPuertaHorno.HornoGetById
            Dim result As Horno = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHornoRepositorio)()
                result = rep.GetById(HOR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPuertaHornoByHorno(ByVal HOR_ID As Integer) As String Implements IBCPuertaHorno.ListaPuertaHornoByHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPuertaHornoRepositorio)()
                result = rep.ListaPuertaHornoByHorno(HOR_ID)
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
