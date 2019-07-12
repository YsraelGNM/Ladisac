Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCExtrusora
        Implements IBCExtrusora

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ExtrusoraGetById(ByVal EXT_ID As Integer) As BE.Extrusora Implements IBCExtrusora.ExtrusoraGetById
            Dim result As Extrusora = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IExtrusoraRepositorio)()
                result = rep.GetById(EXT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaExtrusora() As String Implements IBCExtrusora.ListaExtrusora
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IExtrusoraRepositorio)()
                result = rep.ListaExtrusora
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoExtrusora(ByVal mExtrusora As BE.Extrusora) Implements IBCExtrusora.MantenimientoExtrusora
            Try
                Dim rep = ContainerService.Resolve(Of DA.IExtrusoraRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mExtrusora.ChangeTracker.State = ObjectState.Added) Then
                        mExtrusora.EXT_ID = bcherramientas.Get_Id("Extrusora")
                    ElseIf (mExtrusora.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mExtrusora)

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
