
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCGrupoTrabajo
        Implements IBCGrupoTrabajo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing) As Object Implements IBCGrupoTrabajo.GrupoTrabajoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoSelectXML, desde, hasta, observaciones)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function GrupoTrabajoSeek(ByVal numero As String, ByVal periodo As String) As Object Implements IBCGrupoTrabajo.GrupoTrabajoSeek
            Dim result As BE.GrupoTrabajo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
                result = rep.GetById(periodo, numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.Maintenance
            Dim x As Integer = 0
            Dim iIdplanta, iIdProduccion As Integer
            Dim iIdTipo, idTarea As String

            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.GrupoTrabajo", "grt_NumeroProd", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
                    item.grt_NumeroProd = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleGrupoTrabajo)

                For Each RowDET In item.DetalleGrupoTrabajo
                    Dim NewDET As New DetalleGrupoTrabajo
                    NewDET = RowDET.Clone
                    NewDET.grt_NumeroProd = item.grt_NumeroProd
                    NewDET.prd_Periodo_id = item.prd_Periodo_id

                    'If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                    '    If (Val(NewDET.dgt_Item) > x) Then
                    '        x = Val(NewDET.dgt_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                    '    End If

                    'End If
                    listaDET.Add(NewDET)

                Next
                x = BCUtil.GetId("pla.DetalleGrupoTrabajo", "dgt_Item", 4, " where grt_NumeroProd='" & item.grt_NumeroProd & "' and  prd_Periodo_id='" & item.prd_Periodo_id & "'")


                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleGrupoTrabajo = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True



                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))


                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then

                            mItemIngreso.dgt_Item = Right("0000000" & x.ToString(), 4)
                            x += 1
                        End If
                        If (mItemIngreso.ChangeTracker.State <> ObjectState.Deleted) Then
                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False


                            mItemIngreso.Personas = Nothing
                            If Not (mItemIngreso.Pla_id Is Nothing OrElse Val(mItemIngreso.Pla_id) <= 0) Then
                                iIdplanta = mItemIngreso.Pla_id
                            Else
                                iIdplanta = 0
                            End If
                            If Not (mItemIngreso.pro_Id Is Nothing OrElse Val(mItemIngreso.pro_Id) <= 0) Then
                                iIdProduccion = mItemIngreso.pro_Id
                            Else
                                iIdProduccion = 0
                            End If

                            If Not (mItemIngreso.tit_TipTarea_Id Is Nothing OrElse Val(mItemIngreso.tit_TipTarea_Id) <= 0) Then
                                iIdTipo = mItemIngreso.tit_TipTarea_Id
                            Else
                                iIdTipo = Nothing
                            End If
                            If Not (mItemIngreso.ttr_TareaTrab_Id Is Nothing OrElse Val(mItemIngreso.ttr_TareaTrab_Id) <= 0) Then
                                idTarea = mItemIngreso.ttr_TareaTrab_Id
                            Else
                                idTarea = Nothing
                            End If

                            mItemIngreso.Planta = Nothing
                            mItemIngreso.Produccion = Nothing
                            mItemIngreso.TareaTrabajo = Nothing
                            mItemIngreso.AreaTrabajos = Nothing

                            If Not (iIdplanta <= 0) Then
                                mItemIngreso.Pla_id = iIdplanta
                            Else
                                mItemIngreso.Pla_id = Nothing
                            End If
                            If Not (iIdProduccion <= 0) Then
                                mItemIngreso.pro_Id = iIdProduccion
                            Else
                                mItemIngreso.pro_Id = Nothing
                            End If

                            If Not (iIdTipo Is Nothing Or iIdTipo = "") Then
                                mItemIngreso.tit_TipTarea_Id = iIdTipo
                            Else
                                mItemIngreso.tit_TipTarea_Id = Nothing
                            End If
                            If Not (idTarea Is Nothing OrElse idTarea = "") Then
                                mItemIngreso.ttr_TareaTrab_Id = idTarea
                            Else
                                mItemIngreso.ttr_TareaTrab_Id = Nothing
                            End If


                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        End If

                        mItemIngreso.grt_NumeroProd = item.grt_NumeroProd
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

        Public Function MaintenanceTarea(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.MaintenanceTarea
            Dim x As Integer = 0
            Dim iIdplanta, iIdProduccion As Integer
            Dim iIdTipo, idTarea As String

            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IGrupoTrabajoRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
                Dim sCorrelativo As String = Nothing


                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.GrupoTrabajo", "grt_NumeroProd", 10, " where prd_Periodo_id='" & item.prd_Periodo_id & "'")
                    item.grt_NumeroProd = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleGrupoTrabajo)

                For Each RowDET In item.DetalleGrupoTrabajo
                    Dim NewDET As New DetalleGrupoTrabajo
                    NewDET = RowDET.Clone
                    NewDET.grt_NumeroProd = item.grt_NumeroProd
                    NewDET.prd_Periodo_id = item.prd_Periodo_id

                    'If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                    '    If (Val(NewDET.dgt_Item) > x) Then
                    '        x = Val(NewDET.dgt_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                    '    End If

                    'End If
                    listaDET.Add(NewDET)

                Next

                x = BCUtil.GetId("pla.DetalleGrupoTrabajo", "dgt_Item", 4, " where grt_NumeroProd='" & item.grt_NumeroProd & "' and  prd_Periodo_id='" & item.prd_Periodo_id & "'")

                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleGrupoTrabajo = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True

                Using Scope As New System.Transactions.TransactionScope

                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            x += 1
                            mItemIngreso.dgt_Item = Right("000000" & x.ToString(), 4)
                        End If
                        If (mItemIngreso.ChangeTracker.State <> ObjectState.Deleted) Then
                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False


                            mItemIngreso.Personas = Nothing
                            If Not (mItemIngreso.Pla_id Is Nothing OrElse Val(mItemIngreso.Pla_id) <= 0) Then
                                iIdplanta = mItemIngreso.Pla_id
                            End If
                            If Not (mItemIngreso.pro_Id Is Nothing OrElse Val(mItemIngreso.pro_Id) <= 0) Then
                                iIdProduccion = mItemIngreso.pro_Id
                            End If

                            If Not (mItemIngreso.tit_TipTarea_Id Is Nothing OrElse Val(mItemIngreso.tit_TipTarea_Id) <= 0) Then
                                iIdTipo = mItemIngreso.tit_TipTarea_Id
                            End If
                            If Not (mItemIngreso.ttr_TareaTrab_Id Is Nothing OrElse Val(mItemIngreso.ttr_TareaTrab_Id) <= 0) Then
                                idTarea = mItemIngreso.ttr_TareaTrab_Id
                            End If

                            mItemIngreso.Planta = Nothing
                            mItemIngreso.Produccion = Nothing
                            mItemIngreso.TareaTrabajo = Nothing
                            mItemIngreso.AreaTrabajos = Nothing

                            If Not (iIdplanta <= 0) Then
                                mItemIngreso.Pla_id = iIdplanta
                            End If
                            If Not (iIdProduccion <= 0) Then
                                mItemIngreso.pro_Id = iIdProduccion
                            End If

                            If Not (iIdTipo Is Nothing Or iIdTipo = "") Then
                                mItemIngreso.tit_TipTarea_Id = iIdTipo
                            End If
                            If Not (idTarea Is Nothing OrElse idTarea = "") Then
                                mItemIngreso.ttr_TareaTrab_Id = idTarea
                            End If


                            mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True
                        End If

                        mItemIngreso.grt_NumeroProd = item.grt_NumeroProd

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

        Public Function GrupoTrabajoHorasSeek(ByVal desdeFecha As Date, ByVal hastaFecha As Date, Optional ByVal idPersona As String = "") As Object Implements IBCGrupoTrabajo.GrupoTrabajoHorasSeek
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPvwGrupoTrabajoHorasSelectXML, desdeFecha, hastaFecha, idPersona)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function DetalleHorasXTrabajador(ByVal desdeFecha As Date, ByVal hastaFecha As Date, ByVal idPersona As String) As Object Implements IBCGrupoTrabajo.DetalleHorasXTrabajador
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleHorasXTrabajador, desdeFecha, hastaFecha, idPersona)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SPGrupoTrabajoDelete(ByVal item As BE.GrupoTrabajo) As Object Implements IBCGrupoTrabajo.SPGrupoTrabajoDelete

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPGrupoTrabajoDelete, item.prd_Periodo_id, item.grt_NumeroProd)
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False
        End Function



        Public Function SPDetalleGrupoTrabajoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String) As Object Implements IBCGrupoTrabajo.SPDetalleGrupoTrabajoMaintenanceSelect
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleGrupoTrabajoMaintenanceSelect, prd_Periodo_id, grt_NumeroProd)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spGrupoTrabajoQuemaSecaderoSelectXML(ByVal Tipo As String, ByVal fecha As Date, ByVal codigoOP As String, ByVal codigoPersona As String, ByVal nombePersona As String) As Object Implements IBCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spGrupoTrabajoQuemaSecaderoSelectXML, Tipo, fecha, Val(codigoOP), codigoPersona, nombePersona)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML(ByVal fecha As Date, ByVal codigo As String, ByVal tipo As String) As Object Implements IBCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML, fecha, Val(codigo), tipo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function SPReporteTrabajoHoraDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersona As String) As Object Implements IBCGrupoTrabajo.SPReporteTrabajoHoraDetalle
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPReporteTrabajoHoraDetalle, fechaDesde, fechaHasta, sPersona)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spGrupoTrabajoSecaderoAgrupagoModificarSelectXML(ByVal Fecha As Date, ByVal periodo As String, ByVal numero As String) As Object Implements IBCGrupoTrabajo.spGrupoTrabajoSecaderoAgrupagoModificarSelectXML
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spGrupoTrabajoSecaderoAgrupagoModificarSelectXML, Fecha, periodo, numero)

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

