Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCMantto
        Implements IBCMantto

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaMantto() As String Implements IBCMantto.ListaMantto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IManttoRepositorio)()
                result = rep.ListaMantto
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoMantto(ByVal mMantto As BE.Mantto) Implements IBCMantto.MantenimientoMantto
            Try
                Dim rep = ContainerService.Resolve(Of DA.IManttoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mMantto.ChangeTracker.State = ObjectState.Added) Then
                        mMantto.MTO_ID = bcherramientas.Get_Id("Mantto")
                    ElseIf (mMantto.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mMantto)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ManttoGetById(ByVal MTO_ID As Integer) As BE.Mantto Implements IBCMantto.ManttoGetById
            Dim result As Mantto = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IManttoRepositorio)()
                result = rep.GetById(MTO_ID)
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
