Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCHorno
        Implements IBCHorno

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function HornoGetById(ByVal HOR_ID As Integer) As BE.Horno Implements IBCHorno.HornoGetById
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

        Public Function ListaHorno() As String Implements IBCHorno.ListaHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHornoRepositorio)()
                result = rep.ListaHorno
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoHorno(ByVal mHorno As BE.Horno) Implements IBCHorno.MantenimientoHorno
            Try
                Dim rep = ContainerService.Resolve(Of DA.IHornoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mHorno.ChangeTracker.State = ObjectState.Added) Then
                        mHorno.HOR_ID = bcherramientas.Get_Id("Horno")
                    ElseIf (mHorno.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mHorno)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaCanchaSecadero(ByVal ENO_ID As String) As String Implements IBCHorno.ListaCanchaSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaCanchaSecadero", ENO_ID)
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
