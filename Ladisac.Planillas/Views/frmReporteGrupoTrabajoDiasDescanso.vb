Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReporteGrupoTrabajoDiasDescanso

        <Dependency()> _
        Public Property BCGrupoTrabajoDiasDescanso As BL.IBCGrupoTrabajoDiasDescanso

        Dim oReporte As New rptReporteGrupoTrabajoDiasDescanso
        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0

            oTable = Me.BCGrupoTrabajoDiasDescanso.spGrupoTrabajoDiasDescansoReporte(CDate(dateDesde.Text), txtTrabajador.Tag, 0)
            If (oTable.Rows.Count > 0) Then
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                oReporte.Database.Tables(0).SetDataSource(oTable)
                oReporte.DataDefinition.FormulaFields("Fecha").Text = "'" & dateDesde.Text & "'"
                frm.Reporte(oReporte)
                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If

        End Sub
    End Class
End Namespace
