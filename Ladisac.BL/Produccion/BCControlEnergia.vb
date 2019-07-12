Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCControlEnergia
        Implements IBCControlEnergia

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlEnergiaGetById(ByVal CEN_ID As Integer) As BE.ControlEnergia Implements IBCControlEnergia.ControlEnergiaGetById
            Dim result As ControlEnergia = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlEnergiaRepositorio)()
                result = rep.GetById(CEN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlEnergia(ByVal mControlEnergia As BE.ControlEnergia) Implements IBCControlEnergia.MantenimientoControlEnergia
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlEnergiaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlEnergia.ChangeTracker.State = ObjectState.Added) Then
                        mControlEnergia.CEN_ID = bcherramientas.Get_Id("ControlEnergia")
                    ElseIf (mControlEnergia.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlEnergia)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListadoControlEnergia() As String Implements IBCControlEnergia.ListadoControlEnergia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlEnergiaRepositorio)()
                result = rep.ListaControlEnergia
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListadoAreaConsumoEnergia() As String Implements IBCControlEnergia.ListadoAreaConsumoEnergia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaAreaConsumoEnergia")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArConEne(ByVal ArConEne As Integer?) As String Implements IBCControlEnergia.ListaArConEne
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArConEne", ArConEne)
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

