Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCaracteristica
        Implements IBCCaracteristica

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CaracteristicaGetById(ByVal CTT_ID As Integer) As BE.Caracteristica Implements IBCCaracteristica.CaracteristicaGetById
            Dim result As Caracteristica = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaracteristicaRepositorio)()
                result = rep.GetById(CTT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCaracteristica() As String Implements IBCCaracteristica.ListaCaracteristica
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaracteristicaRepositorio)()
                result = rep.ListaCaracteristica
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCaracteristica(ByVal mCaracteristica As BE.Caracteristica) Implements IBCCaracteristica.MantenimientoCaracteristica
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaracteristicaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCaracteristica.ChangeTracker.State = ObjectState.Added) Then
                        mCaracteristica.CTT_ID = bcherramientas.Get_Id("Caracteristica")
                    ElseIf (mCaracteristica.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCaracteristica)

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
