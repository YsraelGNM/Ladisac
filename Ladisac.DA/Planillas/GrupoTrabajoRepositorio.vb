﻿Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class GrupoTrabajoRepositorio
        Implements IGrupoTrabajoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function GetById(ByVal pedido As String, ByVal numero As String) As BE.GrupoTrabajo Implements IGrupoTrabajoRepositorio.GetById
            Dim result As GrupoTrabajo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()

                result = (From c In context.GrupoTrabajo _
                            Where c.prd_Periodo_id = pedido And c.grt_NumeroProd = numero _
                          Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IGrupoTrabajoRepositorio.Maintenance
            Try

                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.GrupoTrabajo.ApplyChanges(item)
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
'    Public Class DatosTrabajadorJudicialRepositorio
'        Implements IDatosTrabajadorJudicialRepositorio

'        <Dependency()> _
'        Public Property ContainserService As IUnityContainer


'        Public Function GetById(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As BE.DatosTrabajadorJudicial Implements IDatosTrabajadorJudicialRepositorio.GetById
'            Dim result As DatosTrabajadorJudicial = Nothing
'            Try
'                Dim context = ContainserService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DatosTrabajadorJudicial.Include("Personas").Include("Personas1").Include("DetalleTrabajadorJudicial.Conceptos").Include("DetalleTrabajadorJudicial.TiposPlanillas") _
'                           Where c.dtj_SerieJudi = dtj_SerieJudi And _
'                          c.dtj_NumeroJudi = dtj_NumeroJudi Select c).FirstOrDefault()

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result


'        End Function

'        Public Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial) As Object Implements IDatosTrabajadorJudicialRepositorio.Maintenance
'            Try
'                Dim context = ContainserService.Resolve(Of LadisacEntities)()
'                context.DatosTrabajadorJudicial.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()

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

