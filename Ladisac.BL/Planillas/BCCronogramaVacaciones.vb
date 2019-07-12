
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCCronogramaVacaciones
        Implements BL.IBCCronogramaVacaciones

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function CronogramaVacacionesQuery(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As Object Implements IBCCronogramaVacaciones.CronogramaVacacionesQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCronogramaVacacionesSelectXML, per_Id, crv_ItemCroVaca)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function CronogramaVacacionesSeek(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.CronogramaVacaciones Implements IBCCronogramaVacaciones.CronogramaVacacionesSeek
            Dim result As BE.CronogramaVacaciones = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICronogramaVacacionesRepositorio)()
                result = rep.getById(per_Id, crv_ItemCroVaca)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal items As System.Collections.Generic.List(Of BE.CronogramaVacaciones)) As Object Implements IBCCronogramaVacaciones.Maintenance
            Dim x As Integer = 0
            Try
                Dim repDET = ContainerService.Resolve(Of DA.ICronogramaVacacionesRepositorio)()
                Dim sCorrelativo As String = Nothing
                Using Scope As New System.Transactions.TransactionScope
                    sCorrelativo = BCUtil.GetId("pla.CronogramaVacaciones", "crv_ItemCroVaca", 3, " where per_Id='" & items(0).per_Id & "'")

                    x = CInt(sCorrelativo)

                    For Each mItemIngreso In items
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.crv_ItemCroVaca = Right("0000" & x.ToString(), 3)
                            x += 1
                        End If
                        repDET.Mantenace(mItemIngreso)
                    Next
                    Scope.Complete()

                End Using
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spPlanillaCronogramaVacacionesBuscarSelectXML(ByVal per_id As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal tip_TipoPlan_Id As String) As Object Implements IBCCronogramaVacaciones.spPlanillaCronogramaVacacionesBuscarSelectXML

            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaCronogramaVacacionesBuscarSelectXML, per_id, FechaDesde, FechaHasta, tip_TipoPlan_Id)
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
'    Public Class BCGrupoTrabajo
'        Implements IBCGrupoTrabajo
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal usuario As String = Nothing) As Object Implements IBCGrupoTrabajo.GrupoTrabajoQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoSelectXML, desde, hasta, usuario)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function GrupoTrabajoSeek(ByVal numero As String, ByVal periodo As String) As Object Implements IBCGrupoTrabajo.GrupoTrabajoSeek
'            Dim result As BE.GrupoTrabajo = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
'                result = rep.GetById(periodo, numero)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.GrupoTrabajoRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                ' Using Scope As New System.Transactions.TransactionScope

'                If (item.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.GrupoTrabajo", "grt_NumeroProd", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
'                    item.grt_NumeroProd = sCorrelativo
'                End If
'                Dim listaDET As New List(Of DetalleGrupoTrabajo)

'                For Each RowDET In item.DetalleGrupoTrabajo
'                    Dim NewDET As New DetalleGrupoTrabajo
'                    NewDET = RowDET.Close
'                    NewDET.grt_NumeroProd = item.grt_NumeroProd
'                    NewDET.prd_Periodo_id = item.prd_Periodo_id
'                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                        If (Val(NewDET.dgt_Item) > x) Then
'                            x = Val(NewDET.dgt_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                        End If

'                    End If
'                    listaDET.Add(NewDET)


'                Next
'                item.ChangeTracker.ChangeTrackingEnabled = False
'                item.DetalleGrupoTrabajo = Nothing
'                item.ChangeTracker.ChangeTrackingEnabled = True
'                repCAB.Maintenance(item)
'                For Each mItemIngreso In listaDET
'                    x += 1
'                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                        mItemIngreso.dgt_Item = Right("0000" & x.ToString(), 3)
'                    End If

'                    mItemIngreso.grt_NumeroProd = item.grt_NumeroProd
'                    repDET.Maintenance(mItemIngreso)
'                Next

'                '  Scope.Complete()
'                ' End Using

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
