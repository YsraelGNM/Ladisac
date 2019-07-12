Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmConsultaAsientoContable

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodo.Text = .Cells(0).Value

                End With
            End If
            frm.Dispose()
        End Sub

       
        Private Sub btnLibro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibro.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtLibro.Tag = .Cells(0).Value
                    txtLibro.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub
        Function validar() As Boolean
            Dim result As Boolean = True
            If (txtPeriodo.Text = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If


            If (txtLibro.Tag = "") Then
                ErrorProvider1.SetError(txtLibro, "Libro")
                result = False
            Else
                ErrorProvider1.SetError(txtLibro, Nothing)

            End If
            Return result

        End Function
        Sub detalle(ByVal periodo As String, ByVal libro As String, ByVal voucher As String)

            Dim query As String
            If (validar()) Then
                query = BCConsultasReportesContabilidad.ConsultaDETAsientosContables(txtPeriodo.Text, txtLibro.Tag, voucher)

                If (query <> Nothing) Then
                    Dim ds As New DataSet

                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        dgvDetalle.DataSource = ds.Tables(0)
                        dgvDetalle.Columns("CargoMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvDetalle.Columns("AbonoMN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvDetalle.Columns("CargoME").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgvDetalle.Columns("AbonoME").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Else
                        dgvDetalle.DataSource = Nothing
                    End If
                End If

            End If
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim query As String
            If (validar()) Then
                dgvCabecera.DataSource = Nothing
                dgvDetalle.DataSource = Nothing
                'query = BCConsultasReportesContabilidad.ConsultaCABAsientosContables(txtPeriodo.Text, txtLibro.Tag)
                query = BCConsultasReportesContabilidad.ConsultaCABAsientosContablesNuevo(txtPeriodo.Text, txtLibro.Tag, txtVoucher.Text, txtNombre.Text, txtSerie.Text, txtNumero.Text)
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        dgvCabecera.DataSource = ds.Tables(0)
                    Else
                        dgvCabecera.DataSource = Nothing
                    End If
                End If
            End If
        End Sub

     
        Private Sub dgvCabecera_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCabecera.RowHeaderMouseDoubleClick
            If (dgvCabecera.SelectedRows.Count > 0) Then
                detalle(txtPeriodo.Text, txtLibro.Tag, dgvCabecera.SelectedRows(0).Cells(2).Value)
            End If
        End Sub

        Private Sub txtVoucher_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVoucher.Validated
            If Len(Trim(txtVoucher.Text)) > 0 Then
                txtVoucher.Text = Strings.StrDup(6 - Len(Trim(txtVoucher.Text)), "0") & Trim(txtVoucher.Text)
            End If
        End Sub
    End Class
End Namespace