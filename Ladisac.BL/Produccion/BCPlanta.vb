Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlanta
        Implements IBCPlanta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaPlanta() As String Implements IBCPlanta.ListaPlanta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantaRepositorio)()
                result = rep.ListaPlanta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoPlanta(ByVal mPlanta As BE.Planta) Implements IBCPlanta.MantenimientoPlanta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mPlanta.ChangeTracker.State = ObjectState.Added) Then
                        mPlanta.PLA_ID = bcherramientas.Get_Id("Planta")
                    ElseIf (mPlanta.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mPlanta)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function PlantaGetById(ByVal PLA_ID As Integer) As BE.Planta Implements IBCPlanta.PlantaGetById
            Dim result As Planta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlantaRepositorio)()
                result = rep.GetById(PLA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PlantaGrupoTrabajoQuery(ByVal id As Integer, ByVal descripcion As String) As Object Implements IBCPlanta.PlantaGrupoTrabajoQuery

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPlantaSelectXML, id, descripcion)
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
