Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class PlanillaTrabajadorRepositorio
        Implements IPlanillaTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.PlanillaTrabajador) As Object Implements IPlanillaTrabajadorRepositorio.Maintenance

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.PlanillaTrabajador.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function
    End Class

End Namespace





'Namespace Ladisac.DA

'    Public Class PlanillasComedorHorasRepositorio
'        Implements IPlanillasComedorHorasRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function Maintenance(ByVal item As BE.PlanillasComedorHoras) As Object Implements IPlanillasComedorHorasRepositorio.Maintenance

'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.PlanillasComedorHoras.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return False
'        End Function
'    End Class
'End Namespace
