
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmReporteCuentasProveedor


        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Dim oReporte As New rptSelectReportCuentasProveedorXAcumulado


        Sub buscarPersona()
            Try

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                frm.campo1 = "SI"

                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow

                        dgvProveedor.Rows.Add(.Cells(0).Value, .Cells(1).Value)

                    End With

                End If
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
            buscarPersona()
        End Sub

        Private Sub btnQuitarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarProveedor.Click
            If (dgvProveedor.SelectedRows.Count > 0) Then

                dgvProveedor.Rows.Remove(dgvProveedor.SelectedRows(0))

            End If
        End Sub

        Private Sub btnBuscarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click


            Try


                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarDosParametros)()
                frm.inicio(Constants.BuscadoresNames.CuentasContables)

                If (frm.ShowDialog = DialogResult.OK) Then
                    dgvCuentas.Rows.Add(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                End If
                frm.Dispose()


            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnQuitarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarCuenta.Click
            If (dgvCuentas.SelectedRows.Count > 0) Then

                dgvCuentas.Rows.Remove(dgvProveedor.SelectedRows(0))

            End If
        End Sub

        Private Sub chkTodosProveedores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosProveedores.CheckedChanged

            If (chkTodosProveedores.Checked) Then
                GroupBox1.Enabled = False
            Else
                GroupBox1.Enabled = True
            End If

        End Sub

        Private Sub chkcuentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcuentas.CheckedChanged
            If (chkcuentas.Checked) Then
                GroupBox2.Enabled = False
            Else
                GroupBox2.Enabled = True
            End If
        End Sub

        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.Dispose()
        End Sub

        Private Sub brnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnGenerar.Click
            Dim oTable As New DataTable

            Try

                oTable = Me.BCConsultasReportesContabilidad.SPSelectReportCuentasProveedor(BCUtil.getXml(dgvCuentas, 0), chkcuentas.Checked, BCUtil.getXml(dgvProveedor, 0), chkTodosProveedores.Checked, CDate(dateDesde.Text), CDate(dateHasta.Text))

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                oReporte.Database.Tables(0).SetDataSource(oTable)

                frm.Reporte(oReporte)
                frm.ShowDialog()


            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

            Dim oTablita As New DataTable

            oTablita = Me.BCConsultasReportesContabilidad.SPSelectReportCuentasProveedor(BCUtil.getXml(dgvCuentas, 0), chkcuentas.Checked, BCUtil.getXml(dgvProveedor, 0), chkTodosProveedores.Checked, CDate(dateDesde.Text), CDate(dateHasta.Text))
            BCUtil.excelExportar(oTablita)
          
        End Sub
    End Class
End Namespace
