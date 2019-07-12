Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReportePersona

        Dim oReporte As New rptDatosTrabajadorJudicialPorcentajes

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

            oTable = Me.BCConsultasReportesPlanillas.SPReporteDatosTrabajadorJudicial(CInt(chkActivo.Checked), txtTrabajador.Tag)
            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                oReporte.Database.Tables(0).SetDataSource(oTable)
                frm.Reporte(oReporte)
                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If

        End Sub

        Private Sub frmReportePersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace