Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class PlanillasComedorHorasRepositorio
        Implements IPlanillasComedorHorasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.PlanillasComedorHoras) As Object Implements IPlanillasComedorHorasRepositorio.Maintenance

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.PlanillasComedorHoras.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
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


'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Imports System.Text

'Namespace Ladisac.DA

'    Public Class PlanillaRepositorio
'        Implements IPlanillaRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetbyId(ByVal serie As String, ByVal numero As String, ByVal tipoDoc As String) As BE.Planillas Implements IPlanillaRepositorio.GetbyId
'            Dim result As BE.Planillas = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.Planillas.Include("DetallePlanillas") Where c.pla_SeriePlani = serie And c.pla_Numero = numero And c.tdo_Id = tipoDoc Select c).FirstOrDefault
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.Planillas) As Object Implements IPlanillaRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.Planillas.ApplyChanges(item)
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