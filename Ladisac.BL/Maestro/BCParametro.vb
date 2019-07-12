Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCParametro
        Implements IBCParametro

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaParametro() As String Implements IBCParametro.ListaParametro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                result = rep.ListaParametro
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoParametro(ByVal mParametro As BE.Parametro) Implements IBCParametro.MantenimientoParametro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mParametro.ChangeTracker.State = ObjectState.Added) Then
                        mParametro.PAR_ID = bcherramientas.Get_IdTx("Parametro")
                    ElseIf (mParametro.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mParametro)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ParametroGetById(ByVal PAR_ID As String) As BE.Parametro Implements IBCParametro.ParametroGetById
            Dim result As Parametro = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                result = rep.GetById(PAR_ID)
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
