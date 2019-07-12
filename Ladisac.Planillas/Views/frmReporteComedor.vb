Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views

    Public Class frmReporteComedor

    


        Dim oReporte As New rptComedor

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

        Private Sub btnConceptoBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConceptoBuscar.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value

            End If

            frm.Dispose()
        End Sub

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.BuscarPersona)
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPersona.Tag = .Cells(0).Value
                    txtPersona.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

      
        Private Sub btnNumero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumero.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.Comedor)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtNumero.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0

            oTable = Me.BCConsultasReportesPlanillas.SPReporteComedor(CDate(dateDesde.Text), CDate(dateHasta.Text), txtTipoConcepto.Tag, txtConcepto.Tag, txtPersona.Tag, txtTrabajador.Tag)
            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                oReporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde:" & dateDesde.Text & "  Hasta " & dateHasta.Text & " '"
                oReporte.Database.Tables(0).SetDataSource(oTable)
                frm.Reporte(oReporte)
                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If
        End Sub
    End Class
End Namespace
