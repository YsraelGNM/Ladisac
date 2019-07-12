Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCDetalleGrupoEmpleado
        Implements IBCDetalleGrupoEmpleado
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.DetalleGrupoEmpleado) As Object Implements IBCDetalleGrupoEmpleado.Maintenance

            Try
                Dim rep = ContainerService.Resolve(Of DA.DetalleGrupoEmpleadoRepositorio)()
                Return rep.Maintenance(item)
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




'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCDetalleGrupoTrabajo
'        Implements IBCDetalleGrupoTrabajo
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function DetalleGrupoTrabajoQuery(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String) As Object Implements IBCDetalleGrupoTrabajo.DetalleGrupoTrabajoQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetalleGrupoTrabajoSelectXML, prd_Periodo_id, grt_NumeroProd, dgt_Item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function DetalleGrupoTrabajoSeek(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String) As Object Implements IBCDetalleGrupoTrabajo.DetalleGrupoTrabajoSeek
'            Dim result As BE.DetalleGrupoTrabajo = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                result = rep.GetById(prd_Periodo_id, grt_NumeroProd, dgt_Item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo) As Object Implements IBCDetalleGrupoTrabajo.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                Return rep.Maintenance(item)
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



''Imports Ladisac.BE
''Namespace Ladisac.BL

''    Public Class BCDetalleTrabajadorJudicial
''        Implements IBCDetalleTrabajadorJudicial
''        <Dependency()> _
''        Public Property ContainerService As IUnityContainer

''        Public Function DetalleTrabajadorJudicialQuery(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String, Optional ByVal tip_TipoPlan_Id As String = Nothing) As Object Implements IBCDetalleTrabajadorJudicial.DetalleTrabajadorJudicialQuery
''            Dim result As String = Nothing
''            Try
''                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
''                result = rep.EjecutarReporte(DA.SPNames.SPDetalleTrabajadorJudicialSelectXML, dtj_SerieJudi, dtj_NumeroJudi, tip_TipoPlan_Id)
''            Catch ex As Exception
''                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
''                If (rethrow) Then
''                    Throw
''                End If
''            End Try
''            Return result
''        End Function

''        Public Function DetalleTrabajadorJudicialSeek(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As Object Implements IBCDetalleTrabajadorJudicial.DetalleTrabajadorJudicialSeek
''            Dim result As DetalleTrabajadorJudicial = Nothing
''            Try
''                Dim rep = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
''                result = rep.GetById(tip_TipoPlan_Id, dtj_SerieJudi, dtj_NumeroJudi)
''            Catch ex As Exception
''                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
''                If (rethrow) Then
''                    Throw
''                End If

''            End Try
''            Return result
''        End Function

''        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial) As Object Implements IBCDetalleTrabajadorJudicial.Maintenance
''            Try
''                Dim rep = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
''                Return rep.Maintenance(item)
''            Catch ex As Exception
''                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
''                If (rethrow) Then
''                    Throw
''                End If
''            End Try
''            Return False
''        End Function
''    End Class

''End Namespace


