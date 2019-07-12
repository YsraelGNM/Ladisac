Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlantillaDocuIso
        Implements IBCPlantillaDocuIso

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaPlantillaDocuIso() As String Implements IBCPlantillaDocuIso.ListaPlantillaDocuIso
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantillaDocuIsoRepositorio)()
                result = rep.ListaPlantillaDocuIso
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoPlantillaDocuIso(ByVal mPlantillaDocuIso As BE.PlantillaDocuIso) Implements IBCPlantillaDocuIso.MantenimientoPlantillaDocuIso
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantillaDocuIsoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mPlantillaDocuIso.ChangeTracker.State = ObjectState.Added) Then
                        mPlantillaDocuIso.PDI_ID = bcherramientas.Get_Id("PlantillaDocuIso")
                    ElseIf (mPlantillaDocuIso.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mPlantillaDocuIso)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function PlantillaDocuIsoGetById(ByVal PDI_ID As Integer) As BE.PlantillaDocuIso Implements IBCPlantillaDocuIso.PlantillaDocuIsoGetById
            Dim result As PlantillaDocuIso = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantillaDocuIsoRepositorio)()
                result = rep.GetById(PDI_ID)
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
