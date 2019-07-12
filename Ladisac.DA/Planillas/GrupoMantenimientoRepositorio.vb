Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class GrupoMantenimientoRepositorio
        Implements IGrupoMantenimientoRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function GetById(ByVal periodo As String, ByVal numero As String) As BE.GrupoMantenimiento Implements IGrupoMantenimientoRepositorio.GetById
            Dim result As GrupoMantenimiento = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()

                result = (From c In context.GrupoMantenimiento _
                          .Include("Personas") _
                          .Include("DetalleGrupoMantenimiento") _
                          .Include("DetalleGrupoMantenimiento.Personas") _
                          .Include("DetalleGrupoMantenimiento.OrdenTrabajo") _
                          .Include("DetalleGrupoMantenimiento.OrdenTrabajo.Entidad") _
                            Where c.prd_Periodo_id = periodo And c.grm_Numero = numero _
                          Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.GrupoMantenimiento) As Object Implements IGrupoMantenimientoRepositorio.Maintenance
            Try

                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.GrupoMantenimiento.ApplyChanges(item)
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

'    Public Class GrupoTrabajoRepositorio
'        Implements IGrupoTrabajoRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Function GetById(ByVal pedido As String, ByVal numero As String) As BE.GrupoTrabajo Implements IGrupoTrabajoRepositorio.GetById
'            Dim result As GrupoTrabajo = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()

'                result = (From c In context.GrupoTrabajo _
'                            Where c.prd_Periodo_id = pedido And c.grt_NumeroProd = numero _
'                          Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IGrupoTrabajoRepositorio.Maintenance
'            Try

'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.GrupoTrabajo.ApplyChanges(item)
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
