Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCFaltaSancion
        Implements IBCFaltaSancion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function FaltaSancionGetById(ByVal FSA_ID As Integer) As BE.FaltaSancion Implements IBCFaltaSancion.FaltaSancionGetById
            Dim result As FaltaSancion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFaltaSancionRepositorio)()
                result = rep.GetById(FSA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFaltaSancion() As String Implements IBCFaltaSancion.ListaFaltaSancion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFaltaSancionRepositorio)()
                result = rep.ListaFaltaSancion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoFaltaSancion(ByVal mFaltaSancion As BE.FaltaSancion) Implements IBCFaltaSancion.MantenimientoFaltaSancion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFaltaSancionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mFaltaSancion.ChangeTracker.State = ObjectState.Added) Then
                        mFaltaSancion.FSA_ID = bcherramientas.Get_Id("FaltaSancion")
                    ElseIf (mFaltaSancion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mFaltaSancion)

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
