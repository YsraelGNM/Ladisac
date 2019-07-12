Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms
Imports Ladisac.Contabilidad.Views
Imports System.Data

Namespace Ladisac.Facturacion.Views
    Public Class frmReporteAnalisisVentas

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        Dim oreporte As New rptAnalsisVentaXPuntoVentaResumen
        Dim oreporte02 As New rptAnanalisisVentasXVendedor
        Dim oreporte03 As New rptAnalisisVentasXTonelajeXMes
        Dim oreporte04 As New rptAnalisisVentasXVendedorDetalle
        Dim oreporte05 As New rptAnalisisVentasGraficaTonelajeXMes
        Dim oReporte06 As New rptAnalisisVentasXTipoClienteArticulo
        Dim oReporte07 As New rptAnalisisVentaTonelaje
        Dim oReporte08 As New rptAnalisisVentasRecordVendedor
        Dim oReporte09 As New rptAnalisisVentasRecordArticulo
        Dim oReporte10 As New rptAnalisisVentaTonelajeForma1

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click

            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value()
                        txtPersona.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnAgencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgencia.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.PuntoVenta)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPuntoVenta.Tag = .Cells(0).Value
                        txtPuntoVenta.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnCLSPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLSPersona.Click
            txtPersona.Text = ""
            txtPersona.Tag = ""

        End Sub

        Private Sub btnVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVendedor.Click

            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtVendedor.Tag = .Cells(0).Value()
                        txtVendedor.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnClsVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClsVendedor.Click
            txtVendedor.Text = ""
            txtVendedor.Tag = ""
        End Sub

        Private Sub btnArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticulo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ArticulosLadrillo)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        btnArticulo.Tag = .Cells(0).Value()
                        btnArticulo.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
            Dim sPuntoVenta As String = ""
            Dim sArticulo As String = ""
            Dim sVendedor As String = ""
            Dim sCliente As String = ""
            If (txtPuntoVenta.Tag <> "") Then
                sPuntoVenta = " Origen: " & txtPuntoVenta.Text
            End If
            If (txtArticulo.Tag <> "") Then
                sArticulo = " Articulo: " & txtArticulo.Text
            End If
            If (txtVendedor.Tag <> "") Then
                sVendedor = " Vendedor: " & txtVendedor.Text
            End If
            If (txtVendedor.Tag <> "") Then
                sCliente = " Cliente: " & txtVendedor.Text
            End If

            Try



                If (rdbPuntoVentaResumen.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oreporte.Database.Tables(0).SetDataSource(oTable)
                    oreporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & dateHasta.Text & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & " '"
                    frm.Reporte(oreporte)
                End If

                If (rdbVentasVendedor.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oreporte02.Database.Tables(0).SetDataSource(oTable)
                    oreporte02.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"
                    frm.Reporte(oreporte02)
                End If
                If (rdbReportexMes.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oreporte03.Database.Tables(0).SetDataSource(oTable)
                    oreporte03.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & " '"
                    frm.Reporte(oreporte03)
                End If

                If (rdbVendedorResumenLadrillo.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oreporte04.Database.Tables(0).SetDataSource(oTable)
                    oreporte04.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & " '"
                    frm.Reporte(oreporte04)
                End If
                If (rdbGraficaEmpresaMes.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oreporte05.Database.Tables(0).SetDataSource(oTable)
                    oreporte05.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oreporte05)
                End If
                If (rdbVentasTipoVleinteArticulo.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oReporte06.Database.Tables(0).SetDataSource(oTable)
                    oReporte06.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oReporte06)
                End If

                If (rdbTonelaje.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oReporte07.Database.Tables(0).SetDataSource(oTable)
                    oReporte07.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oReporte07)
                End If

                If (rdbVentasRecordVendedor.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadoraaAcumuladoVendedor(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oReporte08.Database.Tables(0).SetDataSource(oTable)
                    oReporte08.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oReporte08)

                End If

                If (rdbVentasRecordArticulo.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadoraaAcumuladoArticulo(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oReporte09.Database.Tables(0).SetDataSource(oTable)
                    oReporte09.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oReporte09)

                End If

                If (rbtTonelajeResumenForma1.Checked) Then
                    oTable = Me.BCConsultasReportesContabilidad.spVentasDiamanteComercializadora(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtVendedor.Tag, txtPuntoVenta.Tag, txtArticulo.Tag)

                    oReporte10.Database.Tables(0).SetDataSource(oTable)
                    oReporte10.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & sPuntoVenta & sArticulo & sVendedor & sCliente & " '"
                    frm.Reporte(oReporte10)
                End If


                frm.ShowDialog()


            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnLimpiarDependencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarDependencia.Click

            txtPuntoVenta.Text = ""
            txtPuntoVenta.Tag = ""

        End Sub

       
    End Class
End Namespace
