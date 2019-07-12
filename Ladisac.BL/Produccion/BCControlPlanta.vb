Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlPlanta
        Implements IBCControlPlanta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlPlantaGetById(ByVal CPL_ID As Integer) As BE.ControlPlanta Implements IBCControlPlanta.ControlPlantaGetById
            Dim result As ControlPlanta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPlantaRepositorio)()
                result = rep.GetById(CPL_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlPlanta() As String Implements IBCControlPlanta.ListaControlPlanta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPlantaRepositorio)()
                result = rep.ListaControlPlanta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlPlanta(ByVal mControlPlanta As BE.ControlPlanta) Implements IBCControlPlanta.MantenimientoControlPlanta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlPlantaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlPlanta.ChangeTracker.State = ObjectState.Added) Then
                        mControlPlanta.CPL_ID = bcherramientas.Get_Id("ControlPlanta")
                    ElseIf (mControlPlanta.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    Dim Cod As Integer = bcherramientas.Get_Id("ControlPlantaDetalle")
                    For Each mItem In mControlPlanta.ControlPlantaDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DPL_ID = Cod
                            Cod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then
                        End If
                    Next
                    rep.Maintenance(mControlPlanta)

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
