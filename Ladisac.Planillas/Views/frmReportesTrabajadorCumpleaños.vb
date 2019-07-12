
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views

    Public Class frmReportesTrabajadorCumpleaños

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        Dim oReporte As New rptCumpleaños

        Private Sub frmReportesTrabajadorCumpleaños_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Private Sub btnSituacionADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionADD.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.SituacionTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtSituacion.Tag = .Cells(0).Value
                    txtSituacion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnTipoCl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoCl.Click

            txtTipos.Tag = Nothing
            txtTipos.Text = ""

        End Sub

        Private Sub btnSituacionCL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionCL.Click

            txtSituacion.Tag = Nothing
            txtSituacion.Text = ""

        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0

            oTable = Me.BCConsultasReportesPlanillas.SPTrabajadorCumpleaños(txtTipos.Tag, txtSituacion.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text))
            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                oReporte.Database.Tables(0).SetDataSource(oTable)


                frm.Reporte(oReporte)

                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If


        End Sub

        Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

        End Sub
    End Class
End Namespace
