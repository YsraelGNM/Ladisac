Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReporteGrupoMantenimiento


        Dim oReporteGrupo As New rptReporteGrupoMantenimientoAgrupado
        Dim oReporteDetalle As New rptReporteGrupoMantenimientoDetalle

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtTrabajador.Tag = .Cells(0).Value()
                    txtTrabajador.Text = .Cells(2).Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
            If (rdbAgrupar.Checked) Then
                oTable = Me.BCConsultasReportesPlanillas.SPReporteGrupoMantenimientoAgrupado(CDate(dateDesde.Value), CDate(dateHasta.Value), txtTrabajador.Tag)

                oReporteGrupo.Database.Tables(0).SetDataSource(oTable)
                oReporteGrupo.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  Hasta" & dateHasta.Text & " '"
                frm.Reporte(oReporteGrupo)
            Else
                oTable = Me.BCConsultasReportesPlanillas.SPReporteGrupoMantenimientoDetalle(CDate(dateDesde.Value), CDate(dateHasta.Value), txtTrabajador.Tag)
                oReporteDetalle.Database.Tables(0).SetDataSource(oTable)
                oReporteDetalle.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  Hasta" & dateHasta.Text & " '"
                frm.Reporte(oReporteDetalle)
            End If
            If (oTable.Rows.Count > 0) Then
                frm.ShowDialog()
            Else
                MsgBox("NO hay Datos a Mostrar")
            End If
        End Sub
    End Class
End Namespace
