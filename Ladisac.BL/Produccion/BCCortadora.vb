Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCortadora
        Implements IBCCortadora

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CortadoraGetById(ByVal COR_ID As Integer) As BE.Cortadora Implements IBCCortadora.CortadoraGetById
            Dim result As Cortadora = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICortadoraRepositorio)()
                result = rep.GetById(COR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCortadora() As String Implements IBCCortadora.ListaCortadora
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICortadoraRepositorio)()
                result = rep.ListaCortadora
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCortadora(ByVal mCortadora As BE.Cortadora) Implements IBCCortadora.MantenimientoCortadora
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICortadoraRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCortadora.ChangeTracker.State = ObjectState.Added) Then
                        mCortadora.COR_ID = bcherramientas.Get_Id("Cortadora")
                    ElseIf (mCortadora.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCortadora)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace
