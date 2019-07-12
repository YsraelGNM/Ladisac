Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReportePersonaTipoFichas

        Dim oReporte1 As New rptFichaPersona
        Dim oReporte2 As New rptPeriodoLaboral
        Dim oReporte3 As New rptReportePeriodoVacaciones

        Private sBuscar As String
        Private sbusco As String

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        Public Sub inicio(ByVal queBusco As String)

            sbusco = queBusco
            VerificarControles()
        End Sub
        Private Sub VerificarControles()

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePersonaTipoFichas) Then
                Panel2.Visible = False
               End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoLaboral) Then
                Panel2.Visible = True
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoVacaciones) Then
                Panel2.Visible = True
            End If


        End Sub


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

        Private Sub btnTipoADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoADD.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTipos.Tag = .Cells(0).Value
                    txtTipos.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            Try

           
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePersonaTipoFichas) Then

                oTable = Me.BCConsultasReportesPlanillas.SPReporteFichaTrabajador(txtTrabajador.Tag, txtTipos.Tag, txtAreaTrabajo.Tag)
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoLaboral) Then

                    oTable = Me.BCConsultasReportesPlanillas.SPReportePeriodoLaboral(txtTipos.Tag, txtAreaTrabajo.Tag, txtTrabajador.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text))
                End If
                If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoVacaciones) Then
                    oTable = Me.BCConsultasReportesPlanillas.SPReportePeriodoVacaciones(txtTipos.Tag, txtAreaTrabajo.Tag, txtTrabajador.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text))

                End If
            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePersonaTipoFichas) Then

                    oReporte1.Database.Tables(0).SetDataSource(oTable)
                    frm.Reporte(oReporte1)
                End If
                If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoLaboral) Then
                    oReporte2.Database.Tables(0).SetDataSource(oTable)
                    frm.Reporte(oReporte2)
                    End If

                    If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoVacaciones) Then
                        oReporte3.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(oReporte3)
                    End If






                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
                End If

            Catch ex As Exception
                MsgBox("No se pudo Generar el Reporte")
            End Try
        End Sub

        Private Sub frmReportePersonaTipoFichas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnAreaTrabajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAreaTrabajo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.AreaTrabajos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtAreaTrabajo.Tag = .Cells(0).Value
                    txtAreaTrabajo.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub


    End Class
End Namespace