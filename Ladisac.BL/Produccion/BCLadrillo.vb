Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCLadrillo
        Implements IBCLadrillo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function LadrilloGetById(ByVal LAD_ID As String) As BE.Ladrillo Implements IBCLadrillo.LadrilloGetById
            Dim result As Ladrillo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloRepositorio)()
                result = rep.GetById(LAD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLadrillo() As String Implements IBCLadrillo.ListaLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloRepositorio)()
                result = rep.ListaLadrillo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoLadrillo(ByVal mLadrillo As BE.Ladrillo) Implements IBCLadrillo.MantenimientoLadrillo
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mLadrillo.ChangeTracker.State = ObjectState.Added) Then
                        mLadrillo.LAD_ID = bcherramientas.Get_Id("Ladrillo")
                    ElseIf (mLadrillo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mLadrillo)

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
