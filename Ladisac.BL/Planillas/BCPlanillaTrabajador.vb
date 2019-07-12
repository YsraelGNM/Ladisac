Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCPlanillaTrabajador
        Implements IBCPlanillaTrabajador

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.PlanillaTrabajador) As Object Implements IBCPlanillaTrabajador.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanillaTrabajadorRepositorio)()
                Return rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                Throw
            End Try
        End Function

        Public Function spDatosLaboralesXPlanillaTrabajador(ByVal sXml As String) As Object Implements IBCPlanillaTrabajador.spDatosLaboralesXPlanillaTrabajador
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDatosLaboralesXPlanillaTrabajador, sXml)

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


'Imports Ladisac.BE

'Namespace Ladisac.BL

'    Public Class BCPlanillasComedorHoras
'        Implements IBCPlanillasComedorHoras

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Maintenance(ByVal item As BE.PlanillasComedorHoras) As Object Implements IBCPlanillasComedorHoras.Maintenance
'            Try

'                Dim rep = ContainerService.Resolve(Of DA.IPlanillasComedorHorasRepositorio)()
'                Return rep.Maintenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                Throw
'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace

