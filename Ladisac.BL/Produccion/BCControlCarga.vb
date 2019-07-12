Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlCarga
        Implements IBCControlCarga

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlCargaGetById(ByVal CAR_ID As Integer) As BE.ControlCarga Implements IBCControlCarga.ControlCargaGetById
            Dim result As ControlCarga = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCargaRepositorio)()
                result = rep.GetById(CAR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlCarga(ByVal PRO_ID As Nullable(Of Integer)) As String Implements IBCControlCarga.ListaControlCarga
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCargaRepositorio)()
                result = rep.ListaControlCarga(PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlCarga(ByVal mControlCarga As BE.ControlCarga) Implements IBCControlCarga.MantenimientoControlCarga
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlCargaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlCarga.ChangeTracker.State = ObjectState.Added) Then
                        mControlCarga.CAR_ID = bcherramientas.Get_Id("ControlCarga")
                    ElseIf (mControlCarga.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlCarga)

                    Scope.Complete()

                    ''''''''''''''''''''''Pasar a Spring
                    If Interfase_CargaHorno(mControlCarga.CAR_ID) = "0" Then
                        Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    End If
                    ''''''''''''''''''''''''''''''''''''

                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function Interfase_CargaHorno(ByVal CAR_ID As Integer) As String Implements IBCControlCarga.Interfase_CargaHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_CargaHorno", CAR_ID)
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
