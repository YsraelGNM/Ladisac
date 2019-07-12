Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSecadero
        Implements IBCSecadero

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSecadero() As String Implements IBCSecadero.ListaSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISecaderoRepositorio)()
                result = rep.ListaSecadero
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoSecadero(ByVal mSecadero As BE.Secadero) Implements IBCSecadero.MantenimientoSecadero
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISecaderoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSecadero.ChangeTracker.State = ObjectState.Added) Then
                        mSecadero.SEC_ID = bcherramientas.Get_Id("Secadero")
                    ElseIf (mSecadero.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mSecadero)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function SecaderoGetById(ByVal SEC_ID As Integer) As BE.Secadero Implements IBCSecadero.SecaderoGetById
            Dim result As Secadero = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISecaderoRepositorio)()
                result = rep.GetById(SEC_ID)
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
