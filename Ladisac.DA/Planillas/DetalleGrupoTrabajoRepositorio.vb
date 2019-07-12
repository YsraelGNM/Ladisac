Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetalleGrupoTrabajoRepositorio
        Implements IDetalleGrupoTrabajoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal pedido As String, ByVal numero As String, ByVal items As String) As BE.DetalleGrupoTrabajo Implements IDetalleGrupoTrabajoRepositorio.GetById
            Dim result As BE.DetalleGrupoTrabajo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleGrupoTrabajo _
                          Where c.prd_Periodo_id = pedido And _
                          c.grt_NumeroProd = numero And _
                          c.dgt_Item = items Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo) As Object Implements IDetalleGrupoTrabajoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleGrupoTrabajo.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return True

        End Function
    End Class

End Namespace

'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Imports System.Text

'Namespace Ladisac.DA
'    Public Class DetalleTrabajadorJudicialRepositorio
'        Implements IDetalleTrabajadorJudicialRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Function GetById(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As Object Implements IDetalleTrabajadorJudicialRepositorio.GetById
'            Dim result As DetalleTrabajadorJudicial = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetalleTrabajadorJudicial _
'                         Where c.tip_TipoPlan_Id = tip_TipoPlan_Id And _
'                         c.dtj_SerieJudi = dtj_SerieJudi And _
'                         c.dtj_NumeroJudi = dtj_NumeroJudi).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function
'        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial) As Object Implements IDetalleTrabajadorJudicialRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleTrabajadorJudicial.ApplyChanges(item)
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
