Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReporteGrupoTrabajoHora
        Dim oReporte As New rptReporteGrupoTrabajoHora
        Dim oreporte3 As New rptReporteGrupoTrabajoHoraSoloTotales
        Dim oreporte5 As New rptReporteGrupoTrabajoHoraSoloTotalesReales

        Dim oReporte2 As New rptReporteGrupoTrabajoHoraXSemana
        Dim oReporte4 As New rptReporteGrupoTrabajoHoraXSemanaSoloTotales
        Dim oReporte6 As New rptReporteGrupoTrabajoHoraXSemanaSoloTotalesReales

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


            If (rdbSoloSemana.Checked) Then
                oTable = Me.BCConsultasReportesPlanillas.SPReporteGrupoTrabajoHoras(CDate(dateDesde.Text), CDate(dateDesde.Text), txtTrabajador.Tag, rdbSoloSemana.Checked, cboFiltro.SelectedIndex)
            Else
                oTable = Me.BCConsultasReportesPlanillas.SPReporteGrupoTrabajoHoras(CDate(dateDesde.Text), CDate(dateHasta.Text), txtTrabajador.Tag, rdbSoloSemana.Checked, cboFiltro.SelectedIndex)

            End If

            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                If (rdbSoloSemana.Checked) Then

                    If (rdbMostrarTotales.Checked) Then
                        oReporte4.Database.Tables(0).SetDataSource(oTable)
                        oReporte4.DataDefinition.FormulaFields("Fecha").Text = "'" & dateDesde.Text & "'"
                        frm.Reporte(oReporte4)
                    ElseIf (rdbHoraReales.Checked) Then
                        oReporte6.Database.Tables(0).SetDataSource(oTable)
                        oReporte6.DataDefinition.FormulaFields("Fecha").Text = "'" & dateDesde.Text & "'"
                        frm.Reporte(oReporte6)
                    Else
                        oReporte2.Database.Tables(0).SetDataSource(oTable)
                        oReporte2.DataDefinition.FormulaFields("Fecha").Text = "'" & dateDesde.Text & "'"
                        frm.Reporte(oReporte2)
                    End If

                Else

                    If (rdbMostrarTotales.Checked) Then
                        oreporte3.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(oreporte3)
                    ElseIf (rdbHoraReales.Checked) Then
                        oreporte5.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(oreporte5)
                    Else

                        oReporte.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(oReporte)
                    End If

                End If

                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If

        End Sub

        Private Sub frmReporteGrupoTrabajoHora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            cboFiltro.SelectedIndex = 0
            Label2.Visible = Not rdbSoloSemana.Checked
            dateHasta.Visible = Not rdbSoloSemana.Checked

        End Sub

      
        Private Sub rdbSoloSemana_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSoloSemana.CheckedChanged
            Label2.Visible = Not rdbSoloSemana.Checked
            dateHasta.Visible = Not rdbSoloSemana.Checked
        End Sub
    End Class
End Namespace


'Namespace Ladisac.Planillas.Views
'    Public Class frmReportePersona

'        Dim oReporte As New rptDatosTrabajadorJudicialPorcentajes

'        <Dependency()> _
'        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas


'        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click
'            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
'            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

'            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

'                With frm.dgbRegistro.CurrentRow

'                    txtTrabajador.Tag = .Cells(0).Value()
'                    txtTrabajador.Text = .Cells(2).Value
'                    ' menuBuscar()
'                End With

'            End If
'            frm.Dispose()
'        End Sub

'        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
'            Dim oTable As New DataTable
'            Dim x As Integer = 0

'            oTable = Me.BCConsultasReportesPlanillas.SPReporteDatosTrabajadorJudicial(CInt(chkActivo.Checked), txtTrabajador.Tag)
'            If (oTable.Rows.Count > 0) Then

'                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

'                oReporte.Database.Tables(0).SetDataSource(oTable)
'                frm.Reporte(oReporte)
'                frm.ShowDialog()

'            Else
'                MsgBox("NO hay Datos a Mostrar")
'            End If

'        End Sub

'        Private Sub frmReportePersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'        End Sub
'    End Class
'End Namespace
