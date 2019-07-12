Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlanillasComedorHoras
        Implements IBCPlanillasComedorHoras

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.PlanillasComedorHoras) As Object Implements IBCPlanillasComedorHoras.Maintenance
            Try

                Dim rep = ContainerService.Resolve(Of DA.IPlanillasComedorHorasRepositorio)()
                Return rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                Throw
            End Try
            Return False
        End Function
    End Class

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCCalendarioDias
'        Implements IBCCalendarioDias
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer