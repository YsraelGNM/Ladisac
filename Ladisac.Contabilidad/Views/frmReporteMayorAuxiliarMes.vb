Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms


Namespace Ladisac.Contabilidad.Views
    Public Class frmReporteMayorAuxiliarMes

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad


        <Dependency()> _
        Public Property SessionService As Foundation.Services.ISessionService

        Dim oReporte As New rptMayorAuxiliarMeses
        Dim oReporte1 As New rptMayorAuxiliarMesesNuevo
        Private Sub btbBuscarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbBuscarCargo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)
            If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
                txtCuentaCargo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtDescripcioncargo.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodo.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable

            Try
                'oTable = Me.BCConsultasReportesContabilidad.SPSelectReportMayorAuxiliarMeses(txtPeriodo.Text, txtCuentaCargo.Text)
                'Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                'oreporte.Database.Tables(0).SetDataSource(oTable)

                'frm.Reporte(oreporte)
                'frm.ShowDialog()

                oTable = Me.BCConsultasReportesContabilidad.SPSelectReportMayorAuxiliarMeses(txtPeriodo.Text, txtCuentaCargo.Text)
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                oReporte1.DataDefinition.FormulaFields("Ruc").Text = "'" & SessionService.RUCEmpresa & "'"
                oReporte1.DataDefinition.FormulaFields("RazonSocial").Text = "'" & SessionService.NombreEmpresa & "'"



                oReporte1.Database.Tables(0).SetDataSource(oTable)

                frm.Reporte(oReporte1)
                frm.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace

