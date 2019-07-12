
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views

    Public Class frmBuscarPeriodoNumero

        Private sBuscar As String
        Private sBusco As String

        <Dependency()> _
        Public Property BCPeriodos As Ladisac.BL.IBCPeriodos

        <Dependency()> _
        Public Property BCLibrosContables As Ladisac.BL.IBCLibrosContables

        <Dependency()> _
        Public Property BCAsientosManuales As Ladisac.BL.IBCAsientosManuales


        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco
            llenarCombo()

        End Sub
        Private Sub llenarCombo()
            Dim query As String = Nothing

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.AsientosManuales) Then
                query = BCLibrosContables.LibrosContablesQuery(Nothing, Nothing, Nothing)
                If (query <> Nothing) Then
                    Dim ds As New DataSet

                    Dim rea As New StringReader(query)
                    If (query <> "") Then

                        ds.ReadXml(rea)
                        cboLIbro.DataSource = ds.Tables(0)
                        cboLIbro.DisplayMember = "Abreviatura"
                        cboLIbro.ValueMember = "ID"

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
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.AsientosManuales) Then

                query = Me.BCAsientosManuales.AsientosManualesQuery(cboLIbro.SelectedValue.ToString, txtPeriodo.Text, txtNumero.Text)

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
            txtNumero.Focus()
        End Sub

        Private Sub btnBuscarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value()
            End If
            frm.Dispose()
        End Sub

        Private Sub txtNumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress

            If (e.KeyChar = Chr(Keys.Enter)) Then
                If (dgbRegistro.RowCount <= 0) Then
                    Me.Dispose()
                End If

            End If
        End Sub
    End Class
End Namespace