Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlInspeccion
        Implements IBCControlInspeccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlInspeccionGetById(ByVal CIN_ID As Integer) As BE.ControlInspeccion Implements IBCControlInspeccion.ControlInspeccionGetById
            Dim result As ControlInspeccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlInspeccionRepositorio)()
                result = rep.GetById(CIN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlInspeccion() As String Implements IBCControlInspeccion.ListaControlInspeccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlInspeccionRepositorio)()
                result = rep.ListaControlInspeccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlInspeccion(ByVal mControlInspeccion As BE.ControlInspeccion) Implements IBCControlInspeccion.MantenimientoControlInspeccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlInspeccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlInspeccion.ChangeTracker.State = ObjectState.Added) Then
                        mControlInspeccion.CIN_ID = bcherramientas.Get_Id("ControlInspeccion")
                    ElseIf (mControlInspeccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlInspeccion)

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
