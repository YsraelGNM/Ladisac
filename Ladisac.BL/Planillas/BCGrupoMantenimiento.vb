Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCGrupoMantenimiento
        Implements IBCGrupoMantenimiento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function GrupoMantenimientoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing) As Object Implements IBCGrupoMantenimiento.GrupoMantenimientoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPGrupoMantenimientoSelectXML, desde, hasta, observaciones)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function GrupoMantenimientoSeek(ByVal numero As String, ByVal periodo As String) As Object Implements IBCGrupoMantenimiento.GrupoMantenimientoSeek
            Dim result As BE.GrupoMantenimiento = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoMantenimientoRepositorio)()
                result = rep.GetById(periodo, numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.GrupoMantenimiento) As Object Implements IBCGrupoMantenimiento.Maintenance
            Dim x As Integer = 0
            Dim bes As Boolean = False
            Dim iOrden As Integer
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IGrupoMantenimientoRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoMantenimientoRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    bes = True
                    sCorrelativo = BCUtil.GetId("pla.GrupoMantenimiento", "grm_Numero", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
                    item.grm_Numero = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleGrupoMantenimiento)

                For Each RowDET In item.DetalleGrupoMantenimiento
                    Dim NewDET As New DetalleGrupoMantenimiento
                    NewDET = RowDET.Clone
                    NewDET.grm_Numero = item.grm_Numero
                    NewDET.prd_Periodo_id = item.prd_Periodo_id

                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.grm_Item) > x) Then
                            x = Val(NewDET.grm_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleGrupoMantenimiento = Nothing
                item.Personas = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True


                If (Not bes) Then
                    item.ChangeTracker.State = ObjectState.Modified
                End If

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            x += 1
                            mItemIngreso.grm_Item = Right("0000" & x.ToString(), 3)
                            mItemIngreso.ChangeTracker.State = ObjectState.Added
                        Else
                            mItemIngreso.ChangeTracker.State = ObjectState.Modified
                        End If
                        iOrden = IIf(IsDBNull(mItemIngreso.OTR_ID), 0, mItemIngreso.OTR_ID)
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        mItemIngreso.OrdenTrabajo = Nothing
                        mItemIngreso.Personas = Nothing
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        mItemIngreso.OTR_ID = IIf(iOrden = 0, Nothing, iOrden)
                        repDET.Maintenance(mItemIngreso)
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

        Public Function SPDetalleGrupoMantenimientoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String) As Object Implements IBCGrupoMantenimiento.SPDetalleGrupoMantenimientoMaintenanceSelect

        End Function

        Public Function SPGrupoMantenimientoDelete(ByVal item As BE.GrupoMantenimiento) As Object Implements IBCGrupoMantenimiento.SPGrupoMantenimientoDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPGrupoMantenimientoDelete, item.prd_Periodo_id, item.grm_Numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function SPGrupoMantenimientoOrdenTrabajoSelectXML(ByVal orden As String, ByVal entidad As String, ByVal descripcion As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCGrupoMantenimiento.SPGrupoMantenimientoOrdenTrabajoSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPGrupoMantenimientoOrdenTrabajoSelectXML, orden, entidad, descripcion, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPPvwGrupoMantenimientoHorasSelectXML(ByVal fechaDesde As Date, ByVal FechaHasta As Date, ByVal idpersona As String) As Object Implements IBCGrupoMantenimiento.SPPvwGrupoMantenimientoHorasSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()

                result = rep.EjecutarReporte(DA.SPNames.SPPvwGrupoMantenimientoHorasSelectXML, fechaDesde, FechaHasta, idpersona)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPDetalleHorasXTrabajadorMantenimiento(ByVal fechaDesde As Date, ByVal fechaHast As Date, ByVal sPerosna As String) As Object Implements IBCGrupoMantenimiento.SPDetalleHorasXTrabajadorMantenimiento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()

                result = rep.EjecutarReporte(DA.SPNames.SPDetalleHorasXTrabajadorMantenimiento, fechaDesde, fechaHast, sPerosna)

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

'        Public Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing) As Object Implements IBCGrupoTrabajo.GrupoTrabajoQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoSelectXML, desde, hasta, observaciones)
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
'            Dim iIdplanta, iIdProduccion As Integer
'            Dim iIdTipo, idTarea As String

'            Try
'                Dim repCAB = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
'                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                Dim sCorrelativo As String = Nothing

'                Using Scope As New System.Transactions.TransactionScope
'                    If (item.ChangeTracker.State = ObjectState.Added) Then
'                        sCorrelativo = BCUtil.GetId("pla.GrupoTrabajo", "grt_NumeroProd", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
'                        item.grt_NumeroProd = sCorrelativo
'                    End If

'                    Dim listaDET As New List(Of DetalleGrupoTrabajo)

'                    For Each RowDET In item.DetalleGrupoTrabajo
'                        Dim NewDET As New DetalleGrupoTrabajo
'                        NewDET = RowDET.Clone
'                        NewDET.grt_NumeroProd = item.grt_NumeroProd
'                        NewDET.prd_Periodo_id = item.prd_Periodo_id

'                        If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
'                            If (Val(NewDET.dgt_Item) > x) Then
'                                x = Val(NewDET.dgt_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
'                            End If

'                        End If
'                        listaDET.Add(NewDET)

'                    Next
'                    item.ChangeTracker.ChangeTrackingEnabled = False
'                    item.DetalleGrupoTrabajo = Nothing
'                    item.ChangeTracker.ChangeTrackingEnabled = True
'                    repCAB.Maintenance(item)

'                    For Each mItemIngreso In listaDET

'                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                            x += 1
'                            mItemIngreso.dgt_Item = Right("0000" & x.ToString(), 3)
'                        End If
'                        If (mItemIngreso.ChangeTracker.State <> ObjectState.Deleted) Then
'                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False


'                            mItemIngreso.Personas = Nothing
'                            If Not (mItemIngreso.Pla_id Is Nothing OrElse Val(mItemIngreso.Pla_id) <= 0) Then
'                                iIdplanta = mItemIngreso.Pla_id
'                            End If
'                            If Not (mItemIngreso.pro_Id Is Nothing OrElse Val(mItemIngreso.pro_Id) <= 0) Then
'                                iIdProduccion = mItemIngreso.pro_Id
'                            End If

'                            If Not (mItemIngreso.tit_TipTarea_Id Is Nothing OrElse Val(mItemIngreso.tit_TipTarea_Id) <= 0) Then
'                                iIdTipo = mItemIngreso.tit_TipTarea_Id
'                            End If
'                            If Not (mItemIngreso.ttr_TareaTrab_Id Is Nothing OrElse Val(mItemIngreso.ttr_TareaTrab_Id) <= 0) Then
'                                idTarea = mItemIngreso.ttr_TareaTrab_Id
'                            End If

'                            mItemIngreso.Planta = Nothing
'                            mItemIngreso.Produccion = Nothing
'                            mItemIngreso.TareaTrabajo = Nothing
'                            mItemIngreso.AreaTrabajos = Nothing

'                            If Not (iIdplanta <= 0) Then
'                                mItemIngreso.Pla_id = iIdplanta
'                            End If
'                            If Not (iIdProduccion <= 0) Then
'                                mItemIngreso.pro_Id = iIdProduccion
'                            End If

'                            If Not (iIdTipo Is Nothing Or iIdTipo = "") Then
'                                mItemIngreso.tit_TipTarea_Id = iIdTipo
'                            End If
'                            If Not (idTarea Is Nothing OrElse idTarea = "") Then
'                                mItemIngreso.ttr_TareaTrab_Id = idTarea
'                            End If


'                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
'                        End If

'                        mItemIngreso.grt_NumeroProd = item.grt_NumeroProd
'                        repDET.Maintenance(mItemIngreso)
'                    Next

'                    Scope.Complete()
'                End Using

'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return False
'        End Function

'        Public Function GrupoTrabajoHorasSeek(ByVal desdeFecha As Date, ByVal hastaFecha As Date) As Object Implements IBCGrupoTrabajo.GrupoTrabajoHorasSeek
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPPvwGrupoTrabajoHorasSelectXML, desdeFecha, hastaFecha)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function DetalleHorasXTrabajador(ByVal desdeFecha As Date, ByVal hastaFecha As Date, ByVal idPersona As String) As Object Implements IBCGrupoTrabajo.DetalleHorasXTrabajador
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetalleHorasXTrabajador, desdeFecha, hastaFecha, idPersona)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function SPGrupoTrabajoDelete(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.SPGrupoTrabajoDelete
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoDelete, item.prd_Periodo_id, item.grt_NumeroProd)
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return False
'        End Function



'        Public Function SPDetalleGrupoTrabajoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String) As Object Implements IBCGrupoTrabajo.SPDetalleGrupoTrabajoMaintenanceSelect
'            Dim result As DataTable = Nothing
'            Try

'                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetalleGrupoTrabajoMaintenanceSelect, prd_Periodo_id, grt_NumeroProd)

'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function
'    End Class

'End Namespace


