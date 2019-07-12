Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCMaleconPuerta
        Implements IBCMaleconPuerta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaMaleconPuerta() As String Implements IBCMaleconPuerta.ListaMaleconPuerta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaleconPuertaRepositorio)()
                result = rep.ListaMaleconPuerta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MaleconPuertaGetById(ByVal MAL_ID As Integer) As BE.MaleconPuerta Implements IBCMaleconPuerta.MaleconPuertaGetById
            Dim result As MaleconPuerta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaleconPuertaRepositorio)()
                result = rep.GetById(MAL_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoMaleconPuerta(ByVal mMaleconPuerta As BE.MaleconPuerta) Implements IBCMaleconPuerta.MantenimientoMaleconPuerta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaleconPuertaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mMaleconPuerta.ChangeTracker.State = ObjectState.Added) Then
                        mMaleconPuerta.MAL_ID = bcherramientas.Get_Id("MaleconPuerta")
                    ElseIf (mMaleconPuerta.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mMaleconPuerta)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function PuertaHornoGetById(ByVal PUE_ID As Integer) As BE.PuertaHorno Implements IBCMaleconPuerta.PuertaHornoGetById
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
    End Class

End Namespace
