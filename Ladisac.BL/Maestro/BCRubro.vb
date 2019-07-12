Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCRubro
        Implements IBCRubro

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRubro() As String Implements IBCRubro.ListaRubro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRubroRepositorio)()
                result = rep.ListaRubro
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoRubro(ByVal mRubro As BE.Rubro) Implements IBCRubro.MantenimientoRubro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRubroRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRubro.ChangeTracker.State = ObjectState.Added) Then
                        mRubro.RUB_ID = bcherramientas.Get_Id("Rubro")
                    ElseIf (mRubro.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mRubro)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function RubroGetById(ByVal RUB_ID As Integer) As BE.Rubro Implements IBCRubro.RubroGetById
            Dim result As Rubro = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRubroRepositorio)()
                result = rep.GetById(RUB_ID)
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
