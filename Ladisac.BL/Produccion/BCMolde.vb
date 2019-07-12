Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCMolde
        Implements IBCMolde

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaMolde() As String Implements IBCMolde.ListaMolde
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMoldeRepositorio)()
                result = rep.ListaMolde
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoMolde(ByVal mMolde As BE.Molde) Implements IBCMolde.MantenimientoMolde
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMoldeRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mMolde.ChangeTracker.State = ObjectState.Added) Then
                        mMolde.MOL_ID = bcherramientas.Get_Id("Molde")
                    ElseIf (mMolde.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mMolde)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function MoldeGetById(ByVal MOL_ID As Integer) As BE.Molde Implements IBCMolde.MoldeGetById
            Dim result As Molde = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMoldeRepositorio)()
                result = rep.GetById(MOL_ID)
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
