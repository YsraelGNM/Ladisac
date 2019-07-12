
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views

    Public Class frmBuscarDocumentosPendientes

        Private sBuscar As String
        Private sBusco As String

        <Dependency()> _
        Public Property BCProvisionCompras As Ladisac.BL.IBCProvisionCompras
        <Dependency()> _
        Public Property BCLeasing As BL.IBCLeasing


        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil


        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco

        End Sub

        Private Sub btnDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumento.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.TiposComprobantesSelectXML)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow

                    'txtCuentaCorriente.Text = .Cells(0).Value
                    txtTipoDocumento.Text = .Cells(1).Value
                    txtDocumento.Tag = .Cells(2).Value
                    txtDocumento.Text = .Cells(3).Value

                End With
            End If
            frm.Dispose()
        End Sub

        Sub ocultarColumnas()
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.SaldosKardexDocumentosXML) Then

                dgvDetalle.Columns("per_id_cli").Visible = False
                dgvDetalle.Columns("cct_id_ref").Visible = False
                dgvDetalle.Columns("cct_descripcion_ref").Visible = False
                dgvDetalle.Columns("tdo_id_ref").Visible = False

            End If


        End Sub

        Public Sub cargarDatos()

            Dim query As String = Nothing

            dgvDetalle.DataSource = Nothing

            'SPComprobantes 

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.SaldosKardexDocumentosXML) Then

                query = Me.BCProvisionCompras.SaldosKardexDocumentosXML(Nothing, Nothing, txtPersona.Tag, "012", IIf(txtTipoDocumento.Tag = "", Nothing, txtTipoDocumento.Tag), IIf(txtDocumento.Tag = "", Nothing, txtDocumento.Tag), IIf(txtSerie.Text = "", Nothing, BCUtil.derecha("0000" & txtSerie.Text, 3)), IIf(txtNumero.Text = "", Nothing, BCUtil.derecha("00000000000000" & txtNumero.Text, 10)), Nothing, 1)

            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LeasingLista) Then

                query = Me.BCLeasing.LeasingListaQuery(txtSerie.Text, txtNumero.Text, txtPersona.Tag)

            End If


            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvDetalle.DataSource = ds.Tables(0)

                    ocultarColumnas()

                Else
                    dgvDetalle.DataSource = Nothing
                End If

            Else
                dgvDetalle.DataSource = Nothing
            End If


        End Sub



        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            If e.RowIndex >= 0 Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

            cargarDatos()

        End Sub

        Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
            If dgvDetalle.SelectedRows.Count > 0 Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Seleccione registros")
            End If
        End Sub

        Private Sub frmBuscarDocumentosPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtPersona.ReadOnly = False
            btnDocumento.Enabled = True
            txtSerie.Focus()
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ReferenciaProvisionCompras) Then
                txtPersona.ReadOnly = True
                btnDocumento.Enabled = False

            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LeasingLista) Then
                txtPersona.ReadOnly = True
                btnDocumento.Enabled = False

            End If
        End Sub
    End Class
End Namespace
