Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms
Imports Ladisac.Contabilidad.Views
Imports System.Data

Namespace Ladisac.Facturacion.Views
    Public Class frmEstadoDeDocumentosFechasVentas

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Dim oReporte As New rptEstadoDeDocumentosFechasVentas
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

        Private Sub btnLimpiarDependencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarDependencia.Click
            txtPuntoVenta.Text = ""
            txtPuntoVenta.Tag = ""

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

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
            Dim sPuntoVenta As String = ""

            Dim sVendedor As String = ""

            If (txtPuntoVenta.Tag <> "") Then
                sPuntoVenta = " Origen: " & txtPuntoVenta.Text
            End If
           
            If (txtVendedor.Tag <> "") Then
                sVendedor = " Vendedor: " & txtVendedor.Text
            End If
         

            Try
                oTable = Me.BCConsultasReportesContabilidad.spEstadoDeDocumentosFechasVentas(txtPuntoVenta.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text), txtVendedor.Tag)


                oReporte.Database.Tables(0).SetDataSource(oTable)
                oReporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & "  " & sPuntoVenta & "  " & sVendedor & " '"
                frm.Reporte(oReporte)

                frm.ShowDialog()


            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace
