Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmReporteHorasPlanillasProduccion
        <Dependency()> _
        Public Property BCConceptosPlanilla As BL.IBCConceptosPlanilla

        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property BCPlanilla As BL.IBCPlanilla

        Dim orptHorasPlanillasProduccion As New rptHorasPlanillasProduccion


        Private Sub btnBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoleta.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentos)()
            frm.inicio(Constants.BuscadoresNames.BuscarPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtSerie.Text = .Cells("Serie").Value()
                    txtNumero.Text = .Cells("Numero").Value
                    txtDescripcion.Text = .Cells("Descripcion").Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
        End Sub

        Private Function validarSeleccionHora(ByVal serie As String, ByVal numero As String) As Boolean
            Dim result As Boolean = True
            Dim x As Integer = 0
            While (dgvPLanillas.RowCount > x)

                If (dgvPLanillas.Rows(x).Cells(0).Value = serie AndAlso dgvPLanillas.Rows(x).Cells(1).Value = numero) Then
                    ErrorProvider1.SetError(dgvPLanillas, "YA existe EL registro")

                    result = False
                    Exit While
                Else
                    ErrorProvider1.SetError(dgvPLanillas, "")

                End If
                x += 1
            End While

            Return result

        End Function

        Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
            If (txtSerie.Text <> "") Then

                If (validarSeleccionHora(txtSerie.Text, txtNumero.Text)) Then
                    dgvPLanillas.Rows.Add(txtSerie.Text, txtNumero.Text, txtDescripcion.Text)
                    txtSerie.Text = ""
                    txtNumero.Text = ""
                    txtDescripcion.Text = ""
                Else
                    MsgBox("Ya existe el Numero de Boleta")
                End If



            Else
                MsgBox("Buscar Primero una Boleta")
            End If
        End Sub

        Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click

            If (dgvPLanillas.SelectedRows.Count > 0) Then
                dgvPLanillas.Rows.Remove(dgvPLanillas.SelectedRows(0))
            Else
                MsgBox(" Seleccione un registro ")
            End If
        End Sub

        Private Sub btnPeriodoDesde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoDesde.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoDesde.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value


            End If

            frm.Dispose()
        End Sub

        Private Sub btnPeriodoHasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoHasta.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoHasta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

            End If

            frm.Dispose()
        End Sub

        Private Sub btnAgregarPorRango_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPorRango.Click
            Dim oDataTable As New DataTable
            Dim x As Integer = 0
            oDataTable = Me.BCPlanilla.spPlanillaBuscarSelectXML(txtPeriodoDesde.Text, txtPeriodoHasta.Text, Nothing, Nothing, Nothing)
            While (oDataTable.Rows.Count > x)



                If (validarSeleccionHora(oDataTable.Rows(x).Item("Serie"), oDataTable.Rows(x).Item("Numero"))) Then
                    dgvPLanillas.Rows.Add(oDataTable.Rows(x).Item("Serie"), oDataTable.Rows(x).Item("Numero"), oDataTable.Rows(x).Item("Descripcion"))

                End If

                x += 1

            End While

        End Sub

        Private Sub frmReporteHorasPlanillasProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
            If (dgvPLanillas.Rows.Count > 0) Then


                oTable = Me.BCConsultasReportesPlanillas.spReporteHorasPlanillasproduccion(BCUtil.getXml(dgvPLanillas, 0, 1))
                If (oTable.Rows.Count > 0) Then

                    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                    orptHorasPlanillasProduccion.Database.Tables(0).SetDataSource(oTable)

                    ' oRPTPLLXAcumuladosXTrabajador.DataDefinition.FormulaFields("SubTitulo").Text = "'Del Periodo " & txtPeridoDesde.Text & "  Al Periodo" & txtPeriodoHasta.Text & " '"

                    frm.Reporte(orptHorasPlanillasProduccion)

                    frm.ShowDialog()

                Else
                    MsgBox("NO hay Datos a Mostrar")
                End If

            End If
        End Sub
    End Class
End Namespace
