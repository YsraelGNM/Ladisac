Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCConsultasReportesPlanillas
        Implements IBCConsultasReportesPlanillas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function SPSelectReportPLLXAcumuladosXTrabajador(ByVal conceptosXML As String, ByVal ListaPlanillas As String, ByVal idpersona As String) As Object Implements IBCConsultasReportesPlanillas.SPSelectReportPLLXAcumuladosXTrabajador
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPSelectReportPLLXAcumuladosXTrabajador, conceptosXML, ListaPlanillas, idpersona)
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

        Public Function SPPlanillaImprimir(ByVal serie As String, ByVal numero As String, ByVal persona As String) As Object Implements IBCConsultasReportesPlanillas.SPPlanillaImprimir
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPPlanillaImprimir, serie, numero, persona)
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

        Public Function SPTrabajadorCumpleaños(ByVal tit_TipoTrab_Id As String, ByVal sit_SituaTrab_Id As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As Object Implements IBCConsultasReportesPlanillas.SPTrabajadorCumpleaños
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPTrabajadorCumpleaños, tit_TipoTrab_Id, sit_SituaTrab_Id, FechaDesde, FechaHasta)
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

        Public Function SPReporteDatosTrabajadorJudicial(ByVal activo As Short, ByVal persona_id As String) As Object Implements IBCConsultasReportesPlanillas.SPReporteDatosTrabajadorJudicial
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteDatosTrabajadorJudicial, activo, persona_id)
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

        Public Function SPReporteFichaTrabajador(ByVal persona_id As String, ByVal tipoTrabajador_id As String, ByVal art_AreaTrab_Id As String) As Object Implements IBCConsultasReportesPlanillas.SPReporteFichaTrabajador
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteFichaTrabajador, persona_id, tipoTrabajador_id, art_AreaTrab_Id)
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

        Public Function SPReportePeriodoLaboral(ByVal sTipo As String, ByVal sArea As String, ByVal persona_id As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCConsultasReportesPlanillas.SPReportePeriodoLaboral
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReportePeriodoLaboral, sTipo, sArea, persona_id, fechaDesde, fechaHasta)
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

        Public Function SPReportePeriodoVacaciones(ByVal sTipo As String, ByVal sArea As String, ByVal persona_id As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCConsultasReportesPlanillas.SPReportePeriodoVacaciones
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReportePeriodoVacaciones, sTipo, sArea, persona_id, fechaDesde, fechaHasta)
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

        Public Function SPReporteComedor(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String, ByVal per_IdComedor As String, ByVal per_idTrabajador As String) As Object Implements IBCConsultasReportesPlanillas.SPReporteComedor
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteComedor, fechaDesde, fechaHasta, tic_TipoConcep_Id, con_Conceptos_Id, per_IdComedor, per_idTrabajador)
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


        Public Function SPReporteGrupoTrabajoHoras(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal persona_id As String, ByVal tipo As Boolean, Optional ByVal filtro As Int16 = 0) As Object Implements IBCConsultasReportesPlanillas.SPReporteGrupoTrabajoHoras
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteGrupoTrabajoHoras, fechaDesde, fechaHasta, persona_id, filtro, tipo)
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

        Public Function spPlanillaBuscarPlameSelectXML(ByVal sPeriodo As String) As Object Implements IBCConsultasReportesPlanillas.spPlanillaBuscarPlameSelectXML
            Dim result As String = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spPlanillaBuscarPlameSelectXML, sPeriodo)
                ' Scope.Complete()
                '   End Using


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPPlanillaExportarPlameIngreEgresAportaciones(ByVal slistadoXML As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As Object Implements IBCConsultasReportesPlanillas.SPPlanillaExportarPlameIngreEgresAportaciones
            Dim result As String = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPlanillaExportarPlameIngreEgresAportaciones, slistadoXML, tic_TipoConcep_Id, con_Conceptos_Id)
                'Scope.Complete()
                ' End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPReporteGrupoMantenimientoAgrupado(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersonas As String) As Object Implements IBCConsultasReportesPlanillas.SPReporteGrupoMantenimientoAgrupado
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteGrupoMantenimientoAgrupado, fechaDesde, fechaHasta, sPersonas)
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

        Public Function SPReporteGrupoMantenimientoDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersonas As String) As Object Implements IBCConsultasReportesPlanillas.SPReporteGrupoMantenimientoDetalle
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPReporteGrupoMantenimientoDetalle, fechaDesde, fechaHasta, sPersonas)
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

        Public Function SPPlanillaImprimirLista(ByVal xml As String) As Object Implements IBCConsultasReportesPlanillas.SPPlanillaImprimirLista
            Dim result As DataTable = Nothing


            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(1, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPPlanillaImprimirLista, xml)
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

        Public Function spReportePermisosTrabajador(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal trabajador As String, ByVal autoriza As String) As Object Implements IBCConsultasReportesPlanillas.spReportePermisosTrabajador
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spReportePermisosTrabajador, fechaInicio, fechaFin, trabajador, autoriza)
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


        Public Function spReporteHorasPlanillasproduccion(ByVal xml As String) As Object Implements IBCConsultasReportesPlanillas.spReporteHorasPlanillasproduccion
            Dim result As DataTable = Nothing
            Try

                'Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 45, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spReporteHorasPlanillasproduccion, xml)
                ' Scope.Complete()

                ' End Using

            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
            End Try
            Return result
        End Function

        Public Function spReportePlanillaConsolidado(ByVal sxml As String) As Object Implements IBCConsultasReportesPlanillas.spReportePlanillaConsolidado

            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spReportePlanillaConsolidado, sxml)
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

        Public Function SPSelectReportPLLXAcumuladosXListaTrabajador(ByVal conceptosXML As String, ByVal ListaPlanillas As String) As Object Implements IBCConsultasReportesPlanillas.SPSelectReportPLLXAcumuladosXListaTrabajador
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPSelectReportPLLXAcumuladosXListaTrabajador, conceptosXML, ListaPlanillas)
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

        Public Function spReporteReparotrabajador(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal sAutoriza As String, ByVal sTrabajador As String) As Object Implements IBCConsultasReportesPlanillas.spReporteReparotrabajador
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spReporteReparotrabajador, fechaInicio, fechaFin, sAutoriza, sTrabajador)
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

        Public Function spReportePlanillaConsolidadoSuma(ByVal sxml As String) As Object Implements IBCConsultasReportesPlanillas.spReportePlanillaConsolidadoSuma
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte("pla.spReportePlanillaConsolidadoSuma", sxml)
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

        Public Function SPPlanillaExportarPlameJornadaLaboral(ByVal slistadoXML As String) As Object Implements IBCConsultasReportesPlanillas.SPPlanillaExportarPlameJornadaLaboral
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("pla.spPlanillaExportarPlameJornadaLaboral", slistadoXML)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function AjusteMinimoEsSalud(ByVal Periodo As String) As Object Implements IBCConsultasReportesPlanillas.AjusteMinimoEsSalud
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("pla.spRecalculoMinimoEsSalud", Periodo)
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
