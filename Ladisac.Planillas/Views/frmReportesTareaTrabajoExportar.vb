
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmReportesTareaTrabajoExportar
        <Dependency()> _
        Public Property BCTareaTrabajo As BL.IBCTareaTrabajo

        Dim oReporte As New rptReportesTareaTrabajoExportar

        Private Sub btnTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTareaTrabajo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtTipo.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipo.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                oTable = Me.BCTareaTrabajo.SPTareaTrabajoExportarSelect(txtTipo.Tag)
                oReporte.Database.Tables(0).SetDataSource(oTable)
                frm.Reporte(oReporte)
                frm.ShowDialog()


            Catch ex As Exception
                MsgBox("No se pudo Generar el Reporte")
            End Try
        End Sub
    End Class
End Namespace
