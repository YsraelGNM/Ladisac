Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.Contabilidad.Views

Public Class frmReporteBalance
    <Dependency()> _
    Public Property BCConsultasReportesContabilidad As Ladisac.BL.IBCConsultasReportesContabilidad

    Private Sub frmReporteBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
        Try
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodo.Text = .Cells(0).Value

                End With
            End If
            frm.Dispose()
        Catch ex As Exception
            MsgBox("Seleccione un Periodo")
        End Try

    End Sub

    Private Sub btnLibro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibro.Click
        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            With frm.dgbRegistro.CurrentRow
                txtLibro.Tag = .Cells(0).Value
                txtLibro.Text = .Cells(1).Value
            End With
        End If
        frm.Dispose()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try

            Dim dtB As DataTable = BCConsultasReportesContabilidad.spBalance(txtPeriodo.Text, 1, cboNiveles.SelectedIndex + 1, cboVerPor.Text.Substring(0, 1), txtLibro.Tag)
            Dim dtGP As DataTable = BCConsultasReportesContabilidad.spGananciasPerdidas(txtPeriodo.Text, 1, cboNiveles.SelectedIndex + 1, cboVerPor.Text.Substring(0, 1), txtLibro.Tag)
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)


            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsBalance", dtB))
            ' ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(14) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Periodo", chkPeriodo.Checked)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Cuenta", chkCuenta.Checked)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Persona", chkPersona.Checked)
            'parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Documento", chkDocumento.Checked)
            'parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Detalle", chkDetalle.Checked)
            'parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("ConSaldo", rbtConSaldo.Checked)
            'parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("SinSaldo", rbtSinSaldo.Checked)
            'parametro(7) = New Microsoft.Reporting.WinForms.ReportParameter("PI", txtPeriodoInicial.Text)
            'parametro(8) = New Microsoft.Reporting.WinForms.ReportParameter("PF", txtPeriodoFinal.Text)
            'parametro(9) = New Microsoft.Reporting.WinForms.ReportParameter("CI", txtCtaInicial.Text)
            'parametro(10) = New Microsoft.Reporting.WinForms.ReportParameter("CF", txtCtaFinal.Text)
            'parametro(11) = New Microsoft.Reporting.WinForms.ReportParameter("LIBRO", txtLibro.Text)
            'Dim Saldo As String = IIf(rbtAmbos.Checked, "Ambos", IIf(rbtConSaldo.Checked, "Con Saldo", "Sin Saldo"))
            'parametro(12) = New Microsoft.Reporting.WinForms.ReportParameter("SALDO", Saldo)
            'parametro(13) = New Microsoft.Reporting.WinForms.ReportParameter("PER_ID", txtPersona.Text)
            'Dim TPer As String = IIf(chk1.Checked, chk1.Text, IIf(chk2.Checked, chk2.Text, IIf(chk3.Checked, chk3.Text, IIf(chk4.Checked, chk4.Text, IIf(chk5.Checked, chk5.Text, IIf(chk6.Checked, chk6.Text, IIf(chk7.Checked, chk7.Text, IIf(chk8.Checked, chk8.Text, chk0.Text))))))))
            'parametro(14) = New Microsoft.Reporting.WinForms.ReportParameter("TPERSONA", TPer)

            '' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)

            ReportViewer2.LocalReport.DataSources.Clear()
            ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsGananciasPerdidas", dtGP))

            ReportViewer1.RefreshReport()
            ReportViewer2.RefreshReport()

        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsBalance", New DataTable()))
            ReportViewer1.RefreshReport()

            ReportViewer2.LocalReport.DataSources.Clear()
            ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsGananciasPerdidas", New DataTable()))
            ReportViewer2.RefreshReport()
        End Try
    End Sub

End Class
