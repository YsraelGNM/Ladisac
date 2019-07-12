Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlDescarga
        Implements IBCControlDescarga

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlDescargaGetById(ByVal DES_ID As Integer) As BE.ControlDescarga Implements IBCControlDescarga.ControlDescargaGetById
            Dim result As ControlDescarga = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRepositorio)()
                result = rep.GetById(DES_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlDescarga() As String Implements IBCControlDescarga.ListaControlDescarga
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRepositorio)()
                result = rep.ListaControlDescarga
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlDescarga(ByVal mControlDescarga As BE.ControlDescarga) Implements IBCControlDescarga.MantenimientoControlDescarga
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlDescarga.ChangeTracker.State = ObjectState.Added) Then
                        mControlDescarga.DES_ID = bcherramientas.Get_Id("ControlDescarga")
                    ElseIf (mControlDescarga.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlDescarga)

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
