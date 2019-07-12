Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlPaqueteo
        Implements IBCControlPaqueteo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlPaqueteoGetById(ByVal PQT_ID As Integer) As BE.ControlPaqueteo Implements IBCControlPaqueteo.ControlPaqueteoGetById
            Dim result As ControlPaqueteo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPaqueteoRepositorio)()
                result = rep.GetById(PQT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlPaqueteo(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCControlPaqueteo.ListaControlPaqueteo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPaqueteoRepositorio)()
                result = rep.ListaControlPaqueteo(FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlPaqueteo(ByVal mControlPaqueteo As BE.ControlPaqueteo) Implements IBCControlPaqueteo.MantenimientoControlPaqueteo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPaqueteoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlPaqueteo.ChangeTracker.State = ObjectState.Added) Then
                        mControlPaqueteo.PQT_ID = bcherramientas.Get_Id("ControlPaqueteo")
                    ElseIf (mControlPaqueteo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlPaqueteo)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ControlPaqueteoGetByPro_Id(ByVal PRO_ID As Integer) As BE.ControlPaqueteo Implements IBCControlPaqueteo.ControlPaqueteoGetByPro_Id
            Dim result As ControlPaqueteo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPaqueteoRepositorio)()
                result = rep.GetByPro_Id(PRO_ID)
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
