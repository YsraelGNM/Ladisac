
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDatosLaborales
        Implements IBCDatosLaborales

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DatosLaboralesQuery(ByVal per_Id As String) As Object Implements IBCDatosLaborales.DatosLaboralesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDatosLaboralesSelectXML, per_Id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function DatosLaboralesSeek(ByVal per_Id As String) As Object Implements IBCDatosLaborales.DatosLaboralesSeek
            Dim result As DatosLaborales = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosLaboralesRepositorio)()
                result = rep.GetById(per_Id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.DatosLaborales) As Object Implements IBCDatosLaborales.Mantenance

            Dim x As Int16 = 0
            Dim y As Int16 = 0
            Try
                Dim reCAB = ContainerService.Resolve(Of DA.IDatosLaboralesRepositorio)()
                Dim repDETVAcaciones = ContainerService.Resolve(Of DA.ICronogramaVacacionesRepositorio)()
                Dim repDETPeriodoLaboral = ContainerService.Resolve(Of DA.IPeriodoLaboralRepositorio)()
                'Dim sCorrelativo As String = Nothing


                'lista vacaciones
                Dim listaDETVAcaciones As New List(Of CronogramaVacaciones)
                For Each RowDET In item.CronogramaVacaciones
                    Dim NewDET As New CronogramaVacaciones
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.crv_ItemCroVaca) > x) Then
                            x = Val(NewDET.crv_ItemCroVaca)
                        End If
                    End If
                    listaDETVAcaciones.Add(NewDET)

                Next
                ' lista periodo laboral
                Dim listaDETPeriodoLaboral As New List(Of PeriodoLaboral)
                For Each RowDET In item.PeriodoLaboral
                    Dim NewDET As New PeriodoLaboral
                    NewDET = RowDET.Clone
                    If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                        If (Val(NewDET.ItemPeriodoLaboral) > y) Then
                            y = Val(NewDET.ItemPeriodoLaboral)
                        End If
                    End If
                    listaDETPeriodoLaboral.Add(NewDET)

                Next

                item.ChangeTracker.ChangeTrackingEnabled = False
                item.CronogramaVacaciones = Nothing
                item.PeriodoLaboral = Nothing
                item.ChangeTracker.ChangeTrackingEnabled = True

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    reCAB.Mantenance(item)
                    'vacaciones
                    For Each mItemIngreso In listaDETVAcaciones

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            x += 1
                            mItemIngreso.crv_ItemCroVaca = Right("0000" & x.ToString(), 3)
                        End If
                        repDETVAcaciones.Mantenace(mItemIngreso)
                    Next


                    'periodo laboral
                    For Each mItemIngreso In listaDETPeriodoLaboral

                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            y += 1
                            mItemIngreso.ItemPeriodoLaboral = Right("0000" & y.ToString(), 3)
                        End If
                        repDETPeriodoLaboral.Maintenance(mItemIngreso)
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
            'Try
            '    Dim rep = ContainerService.Resolve(Of Ladisac.DA.IDatosLaboralesRepositorio)()
            '    Return rep.Mantenance(item)
            'Catch ex As Exception
            '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
            '    If (rethrow) Then
            '        Throw
            '    End If
            'End Try

            'Return False

        End Function


        Public Function DatosLaboralesListaQuery(ByVal per_Id As String, ByVal dal_CodigoTrabajador As String, ByVal nombre As String, Optional ByVal tit_TipoTrab_Id As String = Nothing, Optional ByVal rep_RegiPension_id As String = Nothing) As Object Implements IBCDatosLaborales.DatosLaboralesListaQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDatosLaboralesListaSelectXML, per_Id, dal_CodigoTrabajador, nombre, tit_TipoTrab_Id, rep_RegiPension_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function BuscarPersonaEntidad(Optional ByVal id As String = Nothing, Optional ByVal nombre As String = Nothing, Optional ByVal trabajador As String = Nothing, Optional ByVal banco As String = Nothing, Optional ByVal ruc As String = Nothing, Optional ByVal dni As String = Nothing) As Object Implements IBCDatosLaborales.BuscarPersonaEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPersonasEntidadSelectXML, id, nombre, trabajador, banco, ruc, dni)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DatosLaboralesDetalleQuery(ByVal per_Id As String, ByVal codigo As String, ByVal nombre As String) As Object Implements IBCDatosLaborales.DatosLaboralesDetalleQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDatosLaboralesDetalleSelectXML, per_Id, codigo, nombre)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function EstadoCivilXML() As Object Implements IBCDatosLaborales.EstadoCivilXML
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPEstadoCivilXML)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function spDatosLaboralesPanelSelect(ByVal TipoTRabajador As String, ByVal situacionTrabajador As String, ByVal AreaTrabajo As String) As Object Implements IBCDatosLaborales.spDatosLaboralesPanelSelect
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDatosLaboralesPanelSelect, TipoTRabajador, situacionTrabajador, AreaTrabajo)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result


        End Function

        Public Function spDatosLaboralesPanelHorasSelect(ByVal TipoTRabajador As String, ByVal situacionTrabajador As String, ByVal fechaInicio As Date, ByVal fechaHasta As Date) As Object Implements IBCDatosLaborales.spDatosLaboralesPanelHorasSelect
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDatosLaboralesPanelHorasSelect, TipoTRabajador, situacionTrabajador, fechaInicio, fechaHasta)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function GetByCodTrabajador(ByVal Codigo As String) As DatosLaborales Implements IBCDatosLaborales.GetByCodTrabajador
            Dim result As DatosLaborales = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosLaboralesRepositorio)()
                result = rep.GetByCodTrabajador(Codigo)
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
