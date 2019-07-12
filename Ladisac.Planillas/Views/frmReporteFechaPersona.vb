Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views

    Public Class frmReporteFechaPersona

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        <Dependency()> _
        Public Property BCGrupoTrabajo As BL.IBCGrupoTrabajo

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

            Dim oTabble As DataTable

            oTabble = BCGrupoTrabajo.SPReporteTrabajoHoraDetalle(CDate(dateDesde.Value), CDate(dateHasta.Value), txtTrabajador.Tag)

            BCUtil.excelExportar(oTabble)

        End Sub
    End Class
End Namespace
