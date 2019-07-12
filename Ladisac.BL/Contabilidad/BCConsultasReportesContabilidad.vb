Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Windows.Forms
Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCConsultasReportesContabilidad
        Implements IBCConsultasReportesContabilidad



        ' comentario
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As IBCUtil

        Public Function HojaTrabajoXMLQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As Object Implements IBCConsultasReportesContabilidad.HojaTrabajoXMLQuery

            Dim result As String = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPHojaTrabajo, periodo, nivelInicio, nivelFin, acumuladoMensual, libro)
                ' Scope.Complete()
                ' End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function HojaTrabajoReporteQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As Object Implements IBCConsultasReportesContabilidad.HojaTrabajoReporteQuery

            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPHojaTrabajoReporte, periodo, nivelInicio, nivelFin, acumuladoMensual, libro)
                'Scope.Complete()

                'End Using

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result


        End Function


        Public Function HojaTrabajoReporteNuevoQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As Object Implements IBCConsultasReportesContabilidad.HojaTrabajoReporteNuevoQuery

            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte("con.SPHojaTrabajoReporteNuevo", periodo, nivelInicio, nivelFin, acumuladoMensual, libro)
                'Scope.Complete()

                'End Using

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result


        End Function

        Public Function ConsultaCABAsientosContables(ByVal periodo As String, ByVal libro As String) As Object Implements IBCConsultasReportesContabilidad.ConsultaCABAsientosContables

            Dim result As String = Nothing
            Try
                '  Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConsultaCABAsientosContables, periodo, libro)
                'Scope.Complete()

                'End Using


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function ConsultaCABAsientosContablesNuevo(ByVal periodo As String, ByVal libro As String, ByVal Voucher As String, ByVal Nombre As String, ByVal Serie As String, ByVal Numero As String) As Object Implements IBCConsultasReportesContabilidad.ConsultaCABAsientosContablesNuevo

            Dim result As String = Nothing
            Try
                '  Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConsultaCABAsientosContablesNuevo, periodo, libro, Voucher, Nombre, Serie, Numero)
                'Scope.Complete()

                'End Using


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConsultaDETAsientosContables(ByVal periodo As String, ByVal libro As String, ByVal voucher As String) As Object Implements IBCConsultasReportesContabilidad.ConsultaDETAsientosContables

            Dim result As String = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPConsultaDETAsientosContables, periodo, libro, voucher)
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

        Public Function RPTFormatoVenta14(ByVal periodo As String) As DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoVenta14


            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spFormatoVenta14, periodo)
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

        Public Function RPTFormatoCompra81(ByVal periodo As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoCompra81

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spFormatoCompra81, periodo)
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

        Public Function RPTFormatoCuenta(ByVal periodo As String, ByVal libro As String, ByVal cuenta As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoCuenta
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spFormatoCuenta, periodo, libro, cuenta)
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


        Public Function RPTFormatoMayorGeneral61(ByVal periodo As String, ByVal nivel As Integer) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoMayorGeneral61

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPFormaroMayorGeneral61, periodo, nivel)
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

        Public Function RPTFormatoInventarioYBalance32(ByVal Periodo As String, ByVal formato As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoInventarioYBalance32

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spFormato3_2, Periodo, formato)
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

        Public Function RPTFormatoSaldoClientes33(ByVal Periodo As String, ByVal formato As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoSaldoClientes33
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPFormatoSaldoClientes33, Periodo, formato)
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

        Public Function RPTFormatosTributos310(ByVal periodo As String, ByVal formato As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatosTributos310
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPFormatosTributos310, periodo, formato)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function


        Public Function RPTFormatoCuentaContable(ByVal nivel As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoCuentaContable
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spFormatoCuentaContable, nivel)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function RPTReportAsientosConProblemas(ByVal periodo As String, ByVal libro As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTReportAsientosConProblemas
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportAsientosConProblemas, periodo, libro)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function RPTReportComprobantes(ByVal dateDesde As Date, ByVal dateHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, Optional ByVal serie As String = Nothing, Optional ByVal numero As String = Nothing, Optional ByVal PER_ID As String = Nothing) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTReportComprobantes
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportComprobantes, dateDesde, dateHasta, tdo_Id, dtd_Id, serie, numero, PER_ID)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function
        Public Function FormatoMayorAuxiliarDetalladoXLS(ByVal cIdAnoMes As String, ByVal cIdCuentaInicial As String, ByVal cIdCuentaFinal As String, ByVal cIdCentroCosto As String, ByVal cIdLibro As String, ByVal cMesAcumulado As String, ByVal lSoloReparables As Integer, ByVal idUsuario As String) As Object Implements IBCConsultasReportesContabilidad.FormatoMayorAuxiliarDetalladoXLS
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spFormatoMayorAuxiliarDetallado, cIdAnoMes, cIdCuentaInicial, cIdCuentaFinal, cIdCentroCosto, cIdLibro, cMesAcumulado, lSoloReparables, idUsuario)
                BCUtil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function


        Public Function SPExportarComprasSunatPLEXML(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPExportarComprasSunatPLEXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarComprasSunatPLE, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPExportarComprasNoDocimiciliadosSunatPLEXML(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPExportarComprasNoDomiciliadosSunatPLEXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarComprasNoDomiciliadosSunatPLE, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPExportarVentasSunatPLEXML(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPExportarVentasSunatPLEXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarVentasSunatPLE, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPExportarAsientosSunatPLE51XML(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPExportarAsientosSunatPLE51XML
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarAsientosSunatPLE51, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function SPExportarMayorSunatPLE(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPExportarMayorSunatPLE
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarMayorSunatPLE, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function SPExportarDetracciones(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal Numero As String, ByVal Serie As String, Optional ByVal rucEmpresa As String = "20120877055", Optional ByVal nombreEmpresa As String = "LADRILLERA EL DIAMANTE SAC") As Object Implements IBCConsultasReportesContabilidad.SPExportarDetracciones

            Dim result As DataTable = Nothing
            Dim SaveFileDialog1 As New SaveFileDialog
            Dim X As Integer = 0
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPExportarDetracciones, CCT_ID, TDO_ID, DTD_ID, Numero, Serie, rucEmpresa, nombreEmpresa)

                '------------------------------


                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "D" & rucEmpresa & Right("00000" & Numero, 6) & ".txt"
                SaveFileDialog1.ShowDialog()


                If (SaveFileDialog1.FileName <> "") Then



                    Dim objStreamWriter As StreamWriter
                    objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)

                    While (result.Rows.Count > X)


                        objStreamWriter.WriteLine(result.Rows(X).Item(0).ToString)

                        X += 1

                    End While


                    objStreamWriter.Close()

                Else
                    MsgBox("Poner ,Nombre del Archivo")

                End If

                '------------------------------
            Catch ex As Exception

                MsgBox("Error al Generar el archivo", MsgBoxStyle.Information)

            End Try
            Return False

        End Function

        Public Function spSaldosKardex(ByVal sfiltro As String) As Object Implements IBCConsultasReportesContabilidad.spSaldosKardex

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spSaldosKardex, sfiltro)
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
        Public Function spExportarSunatPDT697(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.spExportarSunatPDT697
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spExportarSunatPDT697, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spExportarSunatPDT697Comprobantes(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.spExportarSunatPDT697Comprobantes
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spExportarSunatPDT697Comprobantes, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function
        Public Function spExportarSunatPDT626(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.spExportarSunatPDT626
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spExportarSunatPDT626, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPSelectReportRegistroComprasCentroCosto(ByVal periodoInicial As String, ByVal periodoFinal As String, ByVal persona As String, ByVal centroCosto As String) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportRegistroComprasCentroCosto
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPSelectReportRegistroComprasCentroCosto, periodoInicial, periodoFinal, persona, centroCosto)
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

        Public Function SPSelectReportMayorAuxiliarMeses(ByVal periodo As String, ByVal cuenta As String) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportMayorAuxiliarMeses
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPSelectReportMayorAuxiliarMeses, periodo, cuenta)
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

        Public Function SPSelectReportDestinoCompras(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportDestinoCompras
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPSelectReportDestinoCompras, periodo)
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

        Public Function spVentasDiamanteComercializadora(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String) As Object Implements IBCConsultasReportesContabilidad.spVentasDiamanteComercializadora

            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spVentasDiamanteComercializadora, fechaInicio, fechaFin, cliente, vendedor, puntoVenta, articulo)
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

        Public Function spEstadoDeDocumentosFechasVentas(ByVal PuntoVenta As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal vendedor As String) As Object Implements IBCConsultasReportesContabilidad.spEstadoDeDocumentosFechasVentas
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spEstadoDeDocumentosFechasVentas, PuntoVenta, FechaDesde, FechaHasta, vendedor)
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

        Public Function spVentasDiamanteComercializadoraaAcumuladoVendedor(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String) As Object Implements IBCConsultasReportesContabilidad.spVentasDiamanteComercializadoraaAcumuladoVendedor
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spVentasDiamanteComercializadoraaAcumuladoVendedor, fechaInicio, fechaFin, cliente, vendedor, puntoVenta, articulo)
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

        Public Function spVentasDiamanteComercializadoraaAcumuladoArticulo(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String) As Object Implements IBCConsultasReportesContabilidad.spVentasDiamanteComercializadoraaAcumuladoArticulo
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spVentasDiamanteComercializadoraaAcumuladoArticulo, fechaInicio, fechaFin, cliente, vendedor, puntoVenta, articulo)
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

        Public Function spExportarSunatPDT321(ByVal periodo As String) As Object Implements IBCConsultasReportesContabilidad.spExportarSunatPDT321

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spExportarSunatPDT321, periodo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function spResumenComprobanteRetencion(ByVal fecha As String) As Object Implements IBCConsultasReportesContabilidad.spResumenComprobanteRetencion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spResumenComprobanteRetencion, fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function SPLibroDiarioGeneral(ByVal periodo As String, ByVal libro As String) As Object Implements IBCConsultasReportesContabilidad.SPLibroDiarioGeneral
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPLibroDiarioGeneral, periodo, libro)
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

        Public Function SPSelectReportCuentasProveedor(ByVal xmlCuentas As String, ByVal todasLasCuentas As Single, ByVal xmlProveedores As String, ByVal TodosLosProveedores As Single, ByVal desdeFecha As Date, ByVal hastaFecha As Date) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportCuentasProveedor


            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportCuentasProveedor, xmlCuentas, todasLasCuentas, xmlProveedores, TodosLosProveedores, desdeFecha, hastaFecha)
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


        Public Function SPSelectReportDAOTComprasDetalle(ByVal año As Integer, ByVal persona As String) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportDAOTComprasDetalle
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportDAOTComprasDetalle, año, persona)
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

        Public Function SPSelectReportDAOTComprasResumen(ByVal año As Integer) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportDAOTComprasResumen
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportDAOTComprasResumen, año)
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

        Public Function SPSelectReportDAOTVentasDetalle(ByVal año As Integer, ByVal persona As String) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportDAOTVentasDetalle
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportDAOTVentasDetalle, año, persona)
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

        Public Function SPSelectReportDAOTVentasResumen(ByVal año As Integer) As Object Implements IBCConsultasReportesContabilidad.SPSelectReportDAOTVentasResumen

            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPSelectReportDAOTVentasResumen, año)
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

        Public Function spAnalisisCuentasCorrientes(ByVal PeriodoIni As String, ByVal PeriodoFin As String, ByVal CuentaIni As String, ByVal CuentaFin As String, ByVal Per_Id As String, ByVal Tip_Per As Integer?, ByVal Libro As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.spAnalisisCuentasCorrientes
            Dim result As DataTable = Nothing
            Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
            result = rep.EjecutarReporte("Con.spAnalisisCuentasCorrientes", PeriodoIni, PeriodoFin, CuentaIni, CuentaFin, Per_Id, Tip_Per, Libro)
            Return result
        End Function

        Public Function spBalance(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.spBalance
            Dim result As DataTable = Nothing
            Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
            result = rep.EjecutarReporte("Con.SPBalance", periodo, nivelInicio, nivelFin, acumuladoMensual, libro)
            Return result
        End Function

        Public Function spGananciasPerdidas(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.spGananciasPerdidas
            Dim result As DataTable = Nothing
            Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
            result = rep.EjecutarReporte("Con.SPGananciasPerdidas", periodo, nivelInicio, nivelFin, acumuladoMensual, libro)
            Return result
        End Function


        Public Function RPTFormatoDigitos(ByVal periodo As String, ByVal libro As String, ByVal digitos As Integer) As System.Data.DataTable Implements IBCConsultasReportesContabilidad.RPTFormatoDigitos
            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spFormatoDigitos, periodo, libro, digitos)
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
    End Class

End Namespace

