Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCEspecificacion
        Implements IBCEspecificacion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function EspecificacionGetById(ByVal ESP_ID As Integer) As BE.Especificacion Implements IBCEspecificacion.EspecificacionGetById
            Dim result As Especificacion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEspecificacionRepositorio)()
                result = rep.GetById(ESP_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEspecificacion() As String Implements IBCEspecificacion.ListaEspecificacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEspecificacionRepositorio)()
                result = rep.ListaEspecificacion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoEspecificacion(ByVal mEspecificacion As BE.Especificacion) Implements IBCEspecificacion.MantenimientoEspecificacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEspecificacionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mEspecificacion.ChangeTracker.State = ObjectState.Added) Then
                        mEspecificacion.ESP_ID = bcherramientas.Get_Id("Especificacion")
                    ElseIf (mEspecificacion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mEspecificacion)

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
