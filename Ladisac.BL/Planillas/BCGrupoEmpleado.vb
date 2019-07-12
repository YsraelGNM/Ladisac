Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCGrupoEmpleado
        Implements IBCGrupoEmpleado

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function GrupoEmpleadoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing) As Object Implements IBCGrupoEmpleado.GrupoEmpleadoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPGrupoEmpleadoSelectXML, desde, hasta, observaciones)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function GrupoEmpleadoSeek(ByVal numero As String, ByVal periodo As String) As Object Implements IBCGrupoEmpleado.GrupoEmpleadoSeek
            Dim result As BE.GrupoEmpleado = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoEmpleadoRepositorio)()
                result = rep.GetById(periodo, numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.GrupoEmpleado) As Object Implements IBCGrupoEmpleado.Maintenance
            Dim x As Integer = 0
            Dim bes As Boolean = False

            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IGrupoEmpleadoRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoEmpleadoRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    bes = True
                    sCorrelativo = BCUtil.GetId("pla.GrupoEmpleado", "gre_Numero", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
                    item.gre_Numero = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleGrupoEmpleado)

                For Each RowDET In item.DetalleGrupoEmpleado
                    Dim NewDET As New DetalleGrupoEmpleado
                    NewDET = RowDET.Clone
                    NewDET.gre_Numero = item.gre_Numero
                    NewDET.prd_Periodo_id = item.prd_Periodo_id


                    listaDET.Add(NewDET)

                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleGrupoEmpleado = Nothing
                item.Personas = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True


                If (Not bes) Then
                    item.ChangeTracker.State = ObjectState.Modified
                End If
                x = CInt(BCUtil.GetId("pla.DetalleGrupoEmpleado", "gre_Item", 10, " where gre_Numero='" & item.gre_Numero & "'  and prd_Periodo_id='" & item.prd_Periodo_id & "'"))

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 40, 0))

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then

                            mItemIngreso.gre_Item = Right("0000" & x.ToString(), 4)
                            mItemIngreso.ChangeTracker.State = ObjectState.Added
                            x += 1
                        Else
                            mItemIngreso.ChangeTracker.State = ObjectState.Modified
                        End If
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        mItemIngreso.Personas = Nothing
                        mItemIngreso.GrupoEmpleado = Nothing

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
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

        Public Function SPGrupoEmpleadoDelete(ByVal item As BE.GrupoEmpleado) As Object Implements IBCGrupoEmpleado.SPGrupoEmpleadoDelete
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPGrupoEmpleadoDelete, item.prd_Periodo_id, item.gre_Numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function SPGrupoEmpleadoHorasSelect(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal PER_ID As String) As Object Implements IBCGrupoEmpleado.SPGrupoEmpleadoHorasSelect

            Dim result As DataTable = Nothing

            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPGrupoEmpleadoHorasSelect, fechaDesde, fechaHasta, PER_ID)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPPvwGrupoEmpleadoHorasSelectXML(ByVal fechaDesde As Date, ByVal FechaHasta As Date, ByVal idpersona As String, ByVal sXMLTiposTrabajador As String) As Object Implements IBCGrupoEmpleado.SPPvwGrupoEmpleadoHorasSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPvwGrupoEmpleadoHorasSelectXML, fechaDesde, FechaHasta, idpersona, sXMLTiposTrabajador)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPDetalleHorasXTrabajadorEmpleado(ByVal fechaDesde As Date, ByVal fechaHast As Date, ByVal sPerosna As String) As Object Implements IBCGrupoEmpleado.SPDetalleHorasXTrabajadorEmpleado
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()

                result = rep.EjecutarReporte(DA.SPNames.SPDetalleHorasXTrabajadorEmpleado, fechaDesde, fechaHast, sPerosna)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spDetalleGrupoEmpleadoMaintenanceSelect(ByVal prd_Periodo As String, ByVal gre_Numero As String) As Object Implements IBCGrupoEmpleado.spDetalleGrupoEmpleadoMaintenanceSelect
            Dim result As DataTable = Nothing

            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDetalleGrupoEmpleadoMaintenanceSelect, prd_Periodo, gre_Numero)

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


