Imports Ladisac.BE
Imports System.Windows.Forms
Namespace Ladisac.BL

    Public Class BCPlanilla
        Implements IBCPlanilla

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        <Dependency()> _
        Public Property oPrueba As BL.IBCConsultasReportesContabilidad

        Public Function Maintenance(ByVal item As BE.Planillas) As Object Implements IBCPlanilla.Maintenance

            Dim x, y As Integer
            Dim tipoConcepto, concepto As String
            Dim idpersona As String
            item.tdo_Id = "042" ' tambien modificar en maintenanceInsert y prodedures como : SPPlanillasDetatalleKardexCtaCteRegenerar

            Try

                Dim repCAB = ContainerService.Resolve(Of DA.IPlanillaRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetallePlanillaRepositorio)()
                Dim repDETCOHO = ContainerService.Resolve(Of DA.IPlanillasComedorHorasRepositorio)()
                Dim repDETTra = ContainerService.Resolve(Of DA.IPlanillaTrabajadorRepositorio)()

                Dim sCorrelativo As String = Nothing
                If (item.ChangeTracker.State = ObjectState.Added) Then

                    If (item.pla_Numero = "") Then
                        sCorrelativo = BCUtil.GetId("pla.Planillas", "pla_Numero", 10, " where tdo_Id='" & item.tdo_Id & "' and pla_SeriePlani='" & item.pla_SeriePlani & "'")
                        item.pla_Numero = sCorrelativo

                    Else
                        item.pla_Numero = Right("00000000000000" & Trim(item.pla_Numero.ToString), 10)
                    End If

                End If

                Dim listaDET As New List(Of BE.DetallePlanillas)
                Dim listaDETCOHO As New List(Of BE.PlanillasComedorHoras)
                Dim listaDETTrab As New List(Of BE.PlanillaTrabajador)
                x = 0
                For Each RowDET In item.DetallePlanillas
                    Dim NewDET As New DetallePlanillas
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.dep_Item) > x) Then
                            x = Val(NewDET.dep_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDET.Add(NewDET)

                Next

                y = 0
                For Each RowDET In item.PlanillasComedorHoras
                    Dim NewDET As New PlanillasComedorHoras
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.item) > y) Then
                            y = Val(NewDET.item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                        End If

                    End If
                    listaDETCOHO.Add(NewDET)

                Next
                y = 0
                For Each RowDET In item.PlanillaTrabajador
                    Dim NewDET As New PlanillaTrabajador
                    NewDET = RowDET.Clone

                    listaDETTrab.Add(NewDET)

                Next


                item.ChangeTracker.ChangeTrackingEnabled = False

                item.DetallePlanillas = Nothing
                item.PlanillasComedorHoras = Nothing
                item.PlanillaTrabajador = Nothing

                item.ChangeTracker.ChangeTrackingEnabled = True

                ' desactivar generara movimiento kardexctacte
                item.pla_GenerarTesoreria = True




                ' Trabajador  planillas 
                Dim col As New DataGridViewTextBoxColumn
                col.DataPropertyName = "PropertyName"
                col.HeaderText = "per_id"
                col.Name = "per_id"

                Dim oDataGrid As New DataGridView
                oDataGrid.Columns.Add(col)


                For Each mItemIngreso In listaDETTrab
                    oDataGrid.Rows.Add(mItemIngreso.per_Id)

                Next
                Dim sXMLListaPersonas As String = BCUtil.getXml(oDataGrid, 0)

                '  Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(1, 30, 0))


                ' repCAB.Maintenance(item) 
                ' detalle de planillas 

                For Each mItemIngreso In listaDET

                    tipoConcepto = mItemIngreso.tic_TipoConcep_Id
                    concepto = mItemIngreso.con_Conceptos_Id
                    idpersona = mItemIngreso.per_Id

                    mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                    mItemIngreso.Conceptos = Nothing
                    mItemIngreso.DatosLaborales = Nothing

                    mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True

                    mItemIngreso.tic_TipoConcep_Id = tipoConcepto
                    mItemIngreso.con_Conceptos_Id = concepto
                    mItemIngreso.per_Id = idpersona

                    x += 1
                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then

                        mItemIngreso.dep_Item = Right("000000000" & x.ToString(), 4)

                    End If

                    mItemIngreso.tdo_Id = item.tdo_Id
                    mItemIngreso.pla_Numero = item.pla_Numero

                    '  repDET.Maintenance(mItemIngreso)
                    item.DetallePlanillas.Add(mItemIngreso)
                Next

                'planillas  detalle de horas y comedor

                For Each mItemIngreso In listaDETCOHO

                    y += 1
                    If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then

                        mItemIngreso.item = Right("000000" & y.ToString(), 3)

                    End If

                    mItemIngreso.tdo_Id = item.tdo_Id
                    mItemIngreso.pla_SeriePlani = item.pla_SeriePlani
                    mItemIngreso.pla_Numero = item.pla_Numero
                    mItemIngreso.pla_Numero = item.pla_Numero

                    'repDETCOHO.Maintenance(mItemIngreso)
                    item.PlanillasComedorHoras.Add(mItemIngreso)

                Next



                For Each mItemIngreso In listaDETTrab


                    item.ChangeTracker.ChangeTrackingEnabled = False

                    mItemIngreso.Planillas = Nothing

                    item.ChangeTracker.ChangeTrackingEnabled = True

                    mItemIngreso.tdo_Id = item.tdo_Id
                    mItemIngreso.pla_SeriePlani = item.pla_SeriePlani
                    mItemIngreso.pla_Numero = item.pla_Numero
                    mItemIngreso.pla_Numero = item.pla_Numero

                    'repDETTra.Maintenance(mItemIngreso)
                    item.PlanillaTrabajador.Add(mItemIngreso)

                Next

                ' generamos movimientos de kardexCtaTe
                '  SPPlanillasDetatalleKardexCtaCteRegenerar(item.pla_SeriePlani, item.pla_Numero, sXMLListaPersonas)


                ' item.MarkAsModified()
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(2, 30, 0))

                    repCAB.Maintenance(item)

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
        Public Function PlanillaQuery(ByVal numero As String, ByVal descripcion As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCPlanilla.PlanillaQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPlantaSelectXML, numero, descripcion, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PlanillaSeek(ByVal pla_SeriePlani As String, ByVal pla_Numero As String, ByVal tdo_Id As String) As Object Implements IBCPlanilla.PlanillaSeek
            Dim result As BE.Planillas = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlanillaRepositorio)()
                result = rep.GetbyId(pla_SeriePlani, pla_Numero, tdo_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function TrabajadorParaPlanillasSeek(ByVal sXml As String, Optional ByVal tip_TipoPlan_Id As String = "") As Object Implements IBCPlanilla.TrabajadorParaPlanillasSeek
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTrabajadorParaPlanillasSelectXML, sXml, tip_TipoPlan_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function ListaDescuentoJudicialXPlanilla(Optional ByVal tipoPlanilla As String = "") As Object Implements IBCPlanilla.ListaDescuentoJudicialXPlanilla
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spListaDescuentoJudicialXPlanilla, tipoPlanilla)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Function TrabajadorCalculoPlanillas(ByVal listaComedorXML As String, _
                                            ByVal listaHoraXML As String, _
                                            ByVal listaJudicialXML As String, _
                                            ByVal ListaPagosAplicarXML As String, _
                                            ByVal ListaPersonas As String, _
                                            ByVal tipoPlanilla As String, _
                                            ByVal PeriodoDesde As String, _
                                            ByVal PeriodoHasta As String, _
                                            ByVal tit_TipoTrab_Id As String, _
                                            ByVal ItemConceptoPlanilla As String) As Object Implements IBCPlanilla.TrabajadorCalculoPlanillas



            Dim result As DataTable = Nothing

            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spTrabajadorCalculoPlanillas, _
                                             listaComedorXML, _
                                             listaHoraXML, _
                                             listaJudicialXML, _
                                             ListaPagosAplicarXML, _
                                             ListaPersonas, _
                                             tipoPlanilla, _
                                             PeriodoDesde, _
                                             PeriodoHasta, _
                                             tit_TipoTrab_Id, _
                                             ItemConceptoPlanilla)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function spTrabajadorPagosParaPlanillasSeek(ByVal sXml As String) As Object Implements IBCPlanilla.spTrabajadorPagosParaPlanillasSeek
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spTrabajadorPagosParaPlanillasXML, sXml)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function
        Public Function spTrabajadorPagosXDocPlanillas(ByVal TDO_ID_DOC As String, ByVal DTD_ID_DOC As String, ByVal SerieRef As String, ByVal NumeroRef As String) As Object Implements IBCPlanilla.spTrabajadorPagosXDocPlanillas

            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spTrabajadorPagosXDocPlanillas, TDO_ID_DOC, DTD_ID_DOC, SerieRef, NumeroRef)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function


        Public Function spDetallePrestamoParaPlanilla(ByVal TDO_ID_DOC As String, ByVal DTD_ID_DOC As String, ByVal SerieRef As String, ByVal NumeroRef As String) As Object Implements IBCPlanilla.spDetallePrestamoParaPlanilla
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDetallePrestamoParaPlanilla, TDO_ID_DOC, DTD_ID_DOC, SerieRef, NumeroRef)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function spPlanillaBuscarSelectXML(ByVal periodoDesde As String, ByVal periodoHasta As String, ByVal serie As String, ByVal numero As String, ByVal descripcion As String) As Object Implements IBCPlanilla.spPlanillaBuscarSelectXML

            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaBuscarSelectXML, periodoDesde, periodoHasta, serie, numero, descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result


        End Function


        Public Function MaintenanceInsert(ByVal sXmlCabecera As String, ByVal sXmlDetalle As String, ByVal pla_SeriePlani As String, ByVal xmlComedorHora As String) As Object Implements IBCPlanilla.MaintenanceInsert
            Dim result As String = Nothing
            Dim tdo_Id As String = "042"
            Dim sCorrelativo As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPlanillaInsert, sXmlCabecera, sXmlDetalle, xmlComedorHora, tdo_Id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function spPlanillaPersonaSelectXML(ByVal serie As String, ByVal numero As String) As Object Implements IBCPlanilla.spPlanillaPersonaSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaPersonaSelectXML, serie, numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function spPlanillaPersonaDetalleSelectXML(ByVal serie As String, ByVal numero As String, ByVal personas_id As String) As Object Implements IBCPlanilla.spPlanillaPersonaDetalleSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaPersonaDetalleSelectXML, serie, numero, personas_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function SPPlanillaDelete(ByVal serie As String, ByVal numero As String, ByVal persona_id As String) As Object Implements IBCPlanilla.SPPlanillaDelete

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPPlanillaDelete, serie, numero, persona_id)
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False
        End Function

        Public Function spPlanillaPersonaTotalesSelectXML(ByVal xmlLista As String) As Object Implements IBCPlanilla.spPlanillaPersonaTotalesSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaPersonaTotalesSelectXML, xmlLista)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function


        Public Function SPPlanillaUpdate(ByVal sXmlCabecera As String, ByVal sXmlDetalle As String, ByVal pla_SeriePlani As String, ByVal xmlComedorHora As String, ByVal numero As String) As Object Implements IBCPlanilla.SPPlanillaUpdate
            Dim result As String = Nothing
            Dim tdo_Id As String = "042"
            Dim sCorrelativo As String = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPPlanillaUpdate, sXmlCabecera, sXmlDetalle, xmlComedorHora, tdo_Id)
                    Scope.Complete()

                End Using



            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function SPPlanillasDetatalleKardexCtaCteRegenerar(ByVal serie As String, ByVal numero As String, ByVal listadoPersonas As String) As Object Implements IBCPlanilla.SPPlanillasDetatalleKardexCtaCteRegenerar

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPPlanillasDetatalleKardexCtaCteRegenerar, serie _
                                    , numero _
                                    , listadoPersonas)
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function spPorcentajeMesPlanilla(ByVal FI As Date, ByVal Ffi As Date, ByVal Fin As Date, ByVal FF As Date, ByVal Per_id As String, ByVal ElegirMes As Integer, ByVal trh_Numero As String) As Decimal Implements IBCPlanilla.spPorcentajeMesPlanilla
            Dim result As DataTable = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("pla.spPorcentajeMesPlanilla", FI, Ffi, Fin, FF, Per_id, ElegirMes, trh_Numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Dim Porc As Decimal
            If IsDBNull(result.Rows(0).Item(0)) Then
                Porc = 0
            Else
                Porc = result.Rows(0).Item(0)
            End If
            Return Porc
        End Function
    End Class

End Namespace
