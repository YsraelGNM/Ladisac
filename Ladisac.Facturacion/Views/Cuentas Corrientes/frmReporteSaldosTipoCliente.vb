Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmReporteSaldosTipoCliente

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Dim oReporte As New ReporteSaldosTipoCliente
        Dim oReporte2 As New ReporteSaldosTipoClientesDetalle
        Dim oReporte3 As New ReporteContraEntregaPendienteCancelar
        Private Simple3 As New Ladisac.BE.RolPersonaTipoPersona

        <Dependency()> _
        Public Property BCKardexCtaCte As BL.IBCKardexCtaCte

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim otable As DataTable

            Dim frm = ContainerService.Resolve(Of Ladisac.Reporteador)()

            If (rdbGeneral.Checked) Then

                otable = BCKardexCtaCte.spSaldosTipoCliente(Nothing, CDate(dateHasta.Text))
                oReporte.Database.Tables(0).SetDataSource(otable)
                ' oreporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde" & dateDesde.Text & "  hasta " & dateHasta.Text & "'"
                frm.Reporte(oReporte)

            End If

            If (rdbDetalle.Checked) Then

                otable = BCKardexCtaCte.spSaldosTipoCliente(cboTipoCliente.SelectedValue, CDate(dateHasta.Text))
                oReporte2.Database.Tables(0).SetDataSource(otable)
                ' oreporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde" & dateDesde.Text & "  hasta " & dateHasta.Text & "'"
                frm.Reporte(oReporte2)
            End If

            If (chkContraEntregaSinCancelar.Checked) Then

                otable = BCKardexCtaCte.spContraEntregaPendienteCancelar(CDate(dateDesde.Text), CDate(dateHasta.Text), Nothing)
                oReporte3.Database.Tables(0).SetDataSource(otable)
                oReporte3.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde" & dateDesde.Text & "  hasta " & dateHasta.Text & "'"
                frm.Reporte(oReporte3)

            End If
            frm.Show()
        End Sub

        Private Sub rdbGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbGeneral.CheckedChanged

            cboTipoCliente.Enabled = Not rdbGeneral.Checked

        End Sub

        Private Sub rdbDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDetalle.CheckedChanged
            If rdbDetalle.Checked Then
                cboTipoCliente.Enabled = True
            Else
                cboTipoCliente.Enabled = False
            End If

        End Sub

        Private Sub frmReporteSaldosTipoCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False

            lblDesde.Visible = False
            dateDesde.Visible = False

            BuscarTipoCliente("000001")
        End Sub

        Public Sub BuscarTipoCliente(ByVal CodigoPER_ID As String)
            Simple3.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple3.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    cboTipoCliente.DataSource = ds.Tables(0)
                    cboTipoCliente.DisplayMember = "Descripción"
                    cboTipoCliente.ValueMember = "Código"
                End If
            Else
                cboTipoCliente.DataSource = Nothing
            End If
        End Sub

        Private Sub chkContraEntregaSinCancelar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContraEntregaSinCancelar.CheckedChanged
            lblDesde.Visible = chkContraEntregaSinCancelar.Checked
            dateDesde.Visible = chkContraEntregaSinCancelar.Checked


        End Sub
    End Class
End Namespace
