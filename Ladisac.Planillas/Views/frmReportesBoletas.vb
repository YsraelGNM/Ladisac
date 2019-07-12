
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmReportesBoletas

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        Dim oReporte As New rptPlanillasBoletas

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

        Private Sub btnBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoleta.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentos)()
            frm.inicio(Constants.BuscadoresNames.BuscarPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtSerie.Text = .Cells(2).Value()
                    txtNumero.Text = .Cells(3).Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            If (validar()) Then
               

                oTable = Me.BCConsultasReportesPlanillas.SPPlanillaImprimir(txtSerie.Text, txtNumero.Text, txtTrabajador.Tag)
                If (oTable.Rows.Count > 0) Then

                    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                    oReporte.Database.Tables(0).SetDataSource(oTable)

               
                    frm.Reporte(oReporte)

                    frm.ShowDialog()

                Else
                    MsgBox("NO hay Datos a Mostrar")
                End If

            End If
        End Sub
        Function validar() As Boolean
            Dim result As Boolean = True
            If (txtNumero.Text = "") Then
                ErrorProvider1.SetError(txtNumero, "Numero ")
                result = False
            Else
                ErrorProvider1.SetError(txtNumero, Nothing)
            End If
            Return result
        End Function

        Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

        End Sub
    End Class
End Namespace