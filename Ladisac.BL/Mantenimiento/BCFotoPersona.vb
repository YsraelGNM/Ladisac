Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCFotoPersona
        Implements IBCFotoPersona

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function FotoPersonaGetById(ByVal FOP_ID As Integer) As BE.FotoPersonas Implements IBCFotoPersona.FotoPersonaGetById
            Dim result As FotoPersonas = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFotoPersonaRepositorio)()
                result = rep.GetById(FOP_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFotoPersonas() As String Implements IBCFotoPersona.ListaFotoPersonas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFotoPersonaRepositorio)()
                result = rep.ListaFotoPersona
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoFotoPersona(ByVal mFotoPersona As BE.FotoPersonas) Implements IBCFotoPersona.MantenimientoFotoPersona
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFotoPersonaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mFotoPersona.ChangeTracker.State = ObjectState.Added) Then
                        mFotoPersona.FOP_ID = bcherramientas.Get_Id("FotoPersona")
                    ElseIf (mFotoPersona.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mFotoPersona)

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
