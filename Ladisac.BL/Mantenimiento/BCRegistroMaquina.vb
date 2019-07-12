Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCRegistroMaquina
        Implements IBCRegistroMaquina

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRegistroMaquina() As String Implements IBCRegistroMaquina.ListaRegistroMaquina
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroMaquinaRepositorio)()
                result = rep.ListaRegistroMaquina
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoRegistroMaquina(ByVal mRegistroMaquina As BE.RegistroMaquina) Implements IBCRegistroMaquina.MantenimientoRegistroMaquina
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroMaquinaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRegistroMaquina.ChangeTracker.State = ObjectState.Added) Then
                        mRegistroMaquina.RMA_ID = bcherramientas.Get_Id("RegistroMaquina")
                    ElseIf (mRegistroMaquina.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    rep.Maintenance(mRegistroMaquina)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function RegistroMaquinaGetById(ByVal RMA_ID As Integer) As BE.RegistroMaquina Implements IBCRegistroMaquina.RegistroMaquinaGetById
            Dim result As RegistroMaquina = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroMaquinaRepositorio)()
                result = rep.GetById(RMA_ID)
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
