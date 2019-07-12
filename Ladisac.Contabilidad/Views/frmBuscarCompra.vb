
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views

    Public Class frmBuscarCompra

        Private sBuscar As String
        Private sBusco As String

        <Dependency()> _
        Public Property BCPeriodos As Ladisac.BL.IBCPeriodos

        <Dependency()> _
        Public Property BCLibrosContables As Ladisac.BL.IBCLibrosContables

        <Dependency()> _
        Public Property BCProvisionCompras As Ladisac.BL.IBCProvisionCompras

        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco
            llenarCombo()

        End Sub
        Private Sub llenarCombo()

            Dim query As String = Nothing

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionCompras) Then
                query = BCLibrosContables.LibrosContablesQuery(Nothing, Nothing, Nothing)
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        cboLIbro.DataSource = ds.Tables(0)
                        cboLIbro.DisplayMember = "Abreviatura"
                        cboLIbro.ValueMember = "ID"
                        cboLIbro.SelectedValue = "001"
                    Else
                        dgbRegistro.DataSource = Nothing
                    End If
                End If
            ElseIf (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionDividendos) Then
                query = BCLibrosContables.LibrosContablesDividendosQuery(Nothing, Nothing, Nothing)
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        cboLIbro.DataSource = ds.Tables(0)
                        cboLIbro.DisplayMember = "Abreviatura"
                        cboLIbro.ValueMember = "ID"
                        cboLIbro.SelectedValue = "050"
                    Else
                        dgbRegistro.DataSource = Nothing
                    End If
                End If
            End If

        End Sub

        Public Sub cargarDatos()
            Dim query As String = Nothing
            'If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ClaseCuenta) Then
            '    query = Me.IBCClaseCuenta.ClaseCuentaQuery(Nothing, txtBuscar.Text.Trim)
            'End If
            dgbRegistro.DataSource = Nothing
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionCompras) Then
                query = Me.BCProvisionCompras.ProvisionComprasQuery(txtPeriodo.Text, txtVoucher.Text, cboLIbro.SelectedValue.ToString, txtpersona.Text, Nothing, txtSerie.Text, txtNumero.Text)
            ElseIf (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionDividendos) Then
                query = Me.BCProvisionCompras.ProvisionComprasQuery(txtPeriodo.Text, txtVoucher.Text, cboLIbro.SelectedValue.ToString, txtpersona.Text, Nothing, txtSerie.Text, txtNumero.Text)
            End If

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            Else
                dgbRegistro.DataSource = Nothing
            End If


        End Sub
        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick
            If e.RowIndex >= 0 Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
        End Sub

        Private Sub frmBuscarPeriodoNumero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnBuscarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value()
            End If
            frm.Dispose()
        End Sub


        Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
Handles txtNumero.KeyDown, txtSerie.KeyDown, txtpersona.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
                Case 40 : dgbRegistro.Focus()
            End Select



        End Sub

        Private Sub dataRegistros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgbRegistro.KeyDown
            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        e.SuppressKeyPress = True

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
            End Select



        End Sub


    End Class
End Namespace