
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmReportesPermisosTrabajador

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        Dim oReporte As New rptReportesPermisosTrabajador
        Dim oReporte2 As New rptReporteReparoTrabajador
        Public Property sBuscar() As String


        Private Sub btnTipoADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoADD.Click
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

        Private Sub btnSituacionADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionADD.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtAutoriza.Tag = .Cells(0).Value()
                    txtAutoriza.Text = .Cells(2).Value
                    ' menuBuscar()
                End With

            End If


            frm.Dispose()
        End Sub

        Private Sub btnTipoCl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoCl.Click

            txtTrabajador.Tag = ""
            txtTrabajador.Text = ""

        End Sub

        Private Sub btnSituacionCL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionCL.Click

            txtAutoriza.Tag = ""
            txtAutoriza.Text = ""

        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                If (sBuscar = Constants.MenuNames.ReportesPermisosTrabajador) Then

                    oTable = Me.BCConsultasReportesPlanillas.spReportePermisosTrabajador(CDate(dateDesde.Text), CDate(dateHasta.Text), txtTrabajador.Tag, txtAutoriza.Tag)
                    oReporte.Database.Tables(0).SetDataSource(oTable)
                    frm.Reporte(oReporte)

                End If


                If (sBuscar = Constants.MenuNames.ReportesReparoTrabajador) Then

                    oTable = Me.BCConsultasReportesPlanillas.spReporteReparotrabajador(CDate(dateDesde.Text), CDate(dateHasta.Text), txtAutoriza.Tag, txtTrabajador.Tag)
                    oReporte2.Database.Tables(0).SetDataSource(oTable)
                    frm.Reporte(oReporte2)

                End If

                frm.ShowDialog()

               
            Catch ex As Exception
                MsgBox("No se pudo Generar el Reporte")
            End Try
        End Sub

       
    End Class
End Namespace
