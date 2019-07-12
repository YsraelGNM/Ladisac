Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlQuema
        Implements IBCControlQuema

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlQuemaGetById(ByVal COQ_ID As Integer) As BE.ControlQuema Implements IBCControlQuema.ControlQuemaGetById
            Dim result As ControlQuema = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlQuemaRepositorio)()
                result = rep.GetById(COQ_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlQuema() As String Implements IBCControlQuema.ListaControlQuema
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlQuemaRepositorio)()
                result = rep.ListaControlQuema
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlQuema(ByVal mControlQuema As BE.ControlQuema) Implements IBCControlQuema.MantenimientoControlQuema
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlQuemaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlQuema.ChangeTracker.State = ObjectState.Added) Then
                        mControlQuema.COQ_ID = bcherramientas.Get_Id("ControlQuema")
                    ElseIf (mControlQuema.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlQuema)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaControlQuemaCombustible() As String Implements IBCControlQuema.ListaControlQuemaCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaControlQuemaCombustible")
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
