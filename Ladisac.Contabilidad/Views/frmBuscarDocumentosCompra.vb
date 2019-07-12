
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views


    Public Class frmBuscarDocumentosCompra

        Private sBuscar As String
        Private sBusco As String
        Private dFecha As Date
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property campo1 As String
        Public Property campo2 As String


        <Dependency()> _
        Public Property BCProvisionCompras As Ladisac.BL.IBCProvisionCompras

        <Dependency()> _
        Public Property BCComprobantes As Ladisac.BL.IBCComprobantes

        <Dependency()> _
        Public Property BCLeasing As BL.IBCLeasing


        Public Sub inicio(ByVal queBusco As String, Optional ByVal vfecha As Date = #1/1/2000#)
            sBusco = queBusco
            dFecha = vfecha
            Me.lblTitle.Text = queBusco

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


        Public Sub cargarDatos()
            Dim query As String = Nothing
            dgvDetalle.DataSource = Nothing

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompra) Then
                query = Me.BCProvisionCompras.comprasQuery(txtDocumento.Tag, txtSerie.Text, txtNumero.Text, CDate(dateDesde.Value.AddDays(-30)), CDate(dateHasta.Text), txtPersona.Text, Val(txtOrden.Text), Val(txtOrdenCompra.Text))
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosRendicionEntregas) Then
                query = Me.BCProvisionCompras.comprasrendicionQuery(txtDocumento.Tag, txtSerie.Text, txtNumero.Text, CDate(dateDesde.Value.AddDays(-30)), CDate(dateHasta.Text), txtPersona.Text, Val(txtOrden.Text), Val(txtOrdenCompra.Text))
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompraServicio) Then
                query = Me.BCProvisionCompras.comprasservicioQuery(txtDocumento.Tag, txtSerie.Text, txtNumero.Text, CDate(dateDesde.Value.AddDays(-30)), CDate(dateHasta.Text), txtPersona.Text, Val(txtOrden.Text), Val(txtOrdenCompra.Text))
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosPlanillaMovilidad) Then
                query = Me.BCProvisionCompras.comprasplanillaQuery(txtDocumento.Tag, txtSerie.Text, txtNumero.Text, CDate(dateDesde.Value.AddDays(-30)), CDate(dateHasta.Text), txtPersona.Text, Val(txtOrden.Text), Val(txtOrdenCompra.Text))
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionComprasXRef) Then
                query = Me.BCProvisionCompras.comprasXRefQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), txtDocumento.Tag, txtPersona.Tag, txtSerie.Text, txtNumero.Text)
            End If

            'ReferenciaProvisionCompras
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ReferenciaProvisionCompras) Then
                query = Me.BCProvisionCompras.DocuMovimientoLogistica(txtDocumento.Tag, txtSerie.Text, txtNumero.Text, CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Text)
            End If

            'SPDetalleComprobantesListaXML
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.DetalleComprobantesLista) Then
                'query = Me.BCComprobantes.ComprobantesListaQuery(txtTipoDocumento.Tag, txtDocumento.Tag, txtSerie.Text, txtNumero.Text, txtPersona.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text), campo1, campo2)
                query = Me.BCComprobantes.ComprobantesListaQuery1(txtTipoDocumento.Tag, txtDocumento.Tag, txtSerie.Text, txtNumero.Text, txtPersona.Tag, CDate(dateDesde.Text), CDate(dateHasta.Text), campo1, campo2, dFecha)
            End If

            'SPComprobantes
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes) Then
                query = Me.BCComprobantes.ComprobantesQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), campo1, campo2, txtSerie.Text, txtNumero.Text, txtPersona.Text)
            End If
            'SPComprobantes43
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes43) Then
                query = Me.BCComprobantes.ComprobantesQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), campo1, campo2, txtSerie.Text, txtNumero.Text, txtPersona.Text)
            End If
            'leasing
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Leasing) Then
                query = Me.BCLeasing.LeasingQuery(txtSerie.Text, txtNumero.Text, txtPersona.Text, CDate(dateDesde.Text), CDate(dateHasta.Text))
            End If

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvDetalle.DataSource = ds.Tables(0)
                    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionComprasXRef) Then
                        dgvDetalle.Columns(0).Visible = False
                        dgvDetalle.Columns(1).Visible = False
                        dgvDetalle.Columns(2).Visible = False
                        dgvDetalle.Columns("Serie").Width = 50
                    End If
                    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.DetalleComprobantesLista) Then
                        Try
                            dgvDetalle.Columns("tdo_Id").Visible = False
                            dgvDetalle.Columns("dtd_Id").Visible = False
                        Catch ex As Exception
                        End Try
                    End If
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


        Private Sub frmBuscarDocumentosCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtPersona.ReadOnly = False
            btnDocumento.Enabled = True
            txtSerie.Focus()

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ReferenciaProvisionCompras) Then
                txtPersona.ReadOnly = True
                btnDocumento.Enabled = False
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Leasing) Then
                txtPersona.ReadOnly = False
                btnDocumento.Enabled = False
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes) Then
                ' txtPersona.ReadOnly = True
                btnDocumento.Enabled = False
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompra) Or _
               (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosPlanillaMovilidad) Or _
               (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompraServicio) Then
                lblOrden.Visible = True
                txtOrden.Visible = True
                lblOrdenCompra.Visible = True
                txtOrdenCompra.Visible = True
                txtOrdenCompra.Focus()
            End If
        End Sub

        Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtNumero.KeyDown, _
            txtSerie.KeyDown, _
            txtPersona.KeyDown, _
            txtOrden.KeyDown, _
            txtOrdenCompra.KeyDown, _
            dateDesde.KeyDown, _
            dateHasta.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgvDetalle.SelectedRows.Count >= 0 Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Case 27 : Me.Close()
                Case 40 : dgvDetalle.Focus()
            End Select
        End Sub

        Private Sub dataRegistros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            Select Case e.KeyValue
                Case 13
                    If dgvDetalle.SelectedRows.Count >= 0 Then

                        e.SuppressKeyPress = True
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
            End Select



        End Sub

        Private Sub dateDesde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dateDesde.KeyPress

            If (e.KeyChar = Chr(Keys.Enter)) Then
                If (dgvDetalle.RowCount <= 0) Then
                    Me.Dispose()
                End If

            End If
        End Sub

        Private Sub txtOrden_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrden.TextChanged
            If (txtOrden.Text.Length >= 2) Then
                cargarDatos()
            End If
        End Sub

        Private Sub txtOrdenCompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdenCompra.TextChanged
            If (txtOrdenCompra.Text.Length >= 2) Then
                cargarDatos()
            End If
        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

        End Sub
    End Class
End Namespace
