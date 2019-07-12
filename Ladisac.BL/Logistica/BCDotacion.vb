Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDotacion
        Implements IBCDotacion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function DotacionGetById(ByVal DOT_ID As Integer) As BE.Dotacion Implements IBCDotacion.DotacionGetById
            Dim result As Dotacion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDotacionRepositorio)()
                result = rep.GetById(DOT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDotacion() As String Implements IBCDotacion.ListaDotacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDotacionRepositorio)()
                result = rep.ListaDotacion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoDotacion(ByVal mDotacion As BE.Dotacion) Implements IBCDotacion.MantenimientoDotacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDotacionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mDotacion.ChangeTracker.State = ObjectState.Added) Then
                        mDotacion.DOT_ID = bcherramientas.Get_Id("Dotacion")
                    ElseIf (mDotacion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mDotacion)

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
