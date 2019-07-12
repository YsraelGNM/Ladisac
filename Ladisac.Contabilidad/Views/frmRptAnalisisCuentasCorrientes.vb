Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.Contabilidad.Views

Public Class frmRptAnalisisCuentasCorrientes
    <Dependency()> _
    Public Property BCConsultasReportesContabilidad As Ladisac.BL.IBCConsultasReportesContabilidad

    Private Sub frmRptAnalisisCuentasCorrientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim TipoPer As Integer
        TipoPer = IIf(chk1.Checked, 1, IIf(chk2.Checked, 2, IIf(chk3.Checked, 3, IIf(chk4.Checked, 4, IIf(chk5.Checked, 5, IIf(chk6.Checked, 6, IIf(chk7.Checked, 7, IIf(chk8.Checked, 8, 0))))))))

        Dim dt As DataTable = BCConsultasReportesContabilidad.spAnalisisCuentasCorrientes(txtPeriodoInicial.Text, txtPeriodoFinal.Text, txtCtaInicial.Text, txtCtaFinal.Text, txtPersona.Tag, TipoPer, txtLibro.Tag)
        'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
        'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
        'Me.ReportViewer1.LocalReport.SetParameters(parametro)
        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsAnalisisCuentasCorrientes", dt))
            ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(14) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Periodo", chkPeriodo.Checked)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Cuenta", chkCuenta.Checked)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Persona", chkPersona.Checked)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Documento", chkDocumento.Checked)
            parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Detalle", chkDetalle.Checked)
            parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("ConSaldo", rbtConSaldo.Checked)
            parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("SinSaldo", rbtSinSaldo.Checked)
            parametro(7) = New Microsoft.Reporting.WinForms.ReportParameter("PI", txtPeriodoInicial.Text)
            parametro(8) = New Microsoft.Reporting.WinForms.ReportParameter("PF", txtPeriodoFinal.Text)
            parametro(9) = New Microsoft.Reporting.WinForms.ReportParameter("CI", txtCtaInicial.Text)
            parametro(10) = New Microsoft.Reporting.WinForms.ReportParameter("CF", txtCtaFinal.Text)
            parametro(11) = New Microsoft.Reporting.WinForms.ReportParameter("LIBRO", txtLibro.Text)
            Dim Saldo As String = IIf(rbtAmbos.Checked, "Ambos", IIf(rbtConSaldo.Checked, "Con Saldo", "Sin Saldo"))
            parametro(12) = New Microsoft.Reporting.WinForms.ReportParameter("SALDO", Saldo)
            parametro(13) = New Microsoft.Reporting.WinForms.ReportParameter("PER_ID", txtPersona.Text)
            Dim TPer As String = IIf(chk1.Checked, chk1.Text, IIf(chk2.Checked, chk2.Text, IIf(chk3.Checked, chk3.Text, IIf(chk4.Checked, chk4.Text, IIf(chk5.Checked, chk5.Text, IIf(chk6.Checked, chk6.Text, IIf(chk7.Checked, chk7.Text, IIf(chk8.Checked, chk8.Text, chk0.Text))))))))
            parametro(14) = New Microsoft.Reporting.WinForms.ReportParameter("TPERSONA", TPer)

            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsAnalisisCuentasCorrientes", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub


    Private Sub txtPeriodoInicial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodoInicial.DoubleClick
        Try
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            frm.cargarDatos()
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodoInicial.Text = .Cells(0).Value
                End With
            End If
            frm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPeriodoFinal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodoFinal.DoubleClick
        Try
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            frm.cargarDatos()
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodoFinal.Text = .Cells(0).Value
                End With
            End If
            frm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPersona_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersona.DoubleClick
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

    Private Sub txtLibro_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLibro.DoubleClick
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

    Private Sub txtCtaInicial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaInicial.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)
        If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
            txtCtaInicial.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            'txtCtaInicial.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCtaFinal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaFinal.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)
        If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
            txtCtaFinal.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            'txtCtaInicial.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub ReportViewer1_ReportRefresh(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.ReportRefresh
        Dim parametro(14) As Microsoft.Reporting.WinForms.ReportParameter
        parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Periodo", chkPeriodo.Checked)
        parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Cuenta", chkCuenta.Checked)
        parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Persona", chkPersona.Checked)
        parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Documento", chkDocumento.Checked)
        parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Detalle", chkDetalle.Checked)
        parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("ConSaldo", rbtConSaldo.Checked)
        parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("SinSaldo", rbtSinSaldo.Checked)
        parametro(7) = New Microsoft.Reporting.WinForms.ReportParameter("PI", txtPeriodoInicial.Text)
        parametro(8) = New Microsoft.Reporting.WinForms.ReportParameter("PF", txtPeriodoFinal.Text)
        parametro(9) = New Microsoft.Reporting.WinForms.ReportParameter("CI", txtCtaInicial.Text)
        parametro(10) = New Microsoft.Reporting.WinForms.ReportParameter("CF", txtCtaFinal.Text)
        parametro(11) = New Microsoft.Reporting.WinForms.ReportParameter("LIBRO", txtLibro.Text)
        Dim Saldo As String = IIf(rbtAmbos.Checked, "Ambos", IIf(rbtConSaldo.Checked, "Con Saldo", "Sin Saldo"))
        parametro(12) = New Microsoft.Reporting.WinForms.ReportParameter("SALDO", Saldo)
        parametro(13) = New Microsoft.Reporting.WinForms.ReportParameter("PER_ID", txtPersona.Text)
        Dim TPer As String = IIf(chk1.Checked, chk1.Text, IIf(chk2.Checked, chk2.Text, IIf(chk3.Checked, chk3.Text, IIf(chk4.Checked, chk4.Text, IIf(chk5.Checked, chk5.Text, IIf(chk6.Checked, chk6.Text, IIf(chk7.Checked, chk7.Text, IIf(chk8.Checked, chk8.Text, chk0.Text))))))))
        parametro(14) = New Microsoft.Reporting.WinForms.ReportParameter("TPERSONA", TPer)
        Me.ReportViewer1.LocalReport.SetParameters(parametro)
        ReportViewer1.RefreshReport()
    End Sub
End Class
