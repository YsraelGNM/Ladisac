
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmBuscarDocumentos
        Private sBuscar As String()
        Private sbusco As String
        <Dependency()> _
        Public Property BCPlanilla As Ladisac.BL.IBCPlanilla

        Public Sub inicio(ByVal queBusco As String)

            sbusco = queBusco

        End Sub

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Dim query As String = Nothing

            dgbRegistro.DataSource = Nothing
            'If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.BuscarPlanilla) Then

            dgbRegistro.DataSource = Me.BCPlanilla.spPlanillaBuscarSelectXML(txtPeriodo.Text, txtPeriodo.Text, txtSerie.Text.Trim, txtNumero.Text, txtDescripcion.Text)


            dgbRegistro.Columns(0).Width = 30
            dgbRegistro.Columns(1).Width = 50
            dgbRegistro.Columns(2).Width = 50
            dgbRegistro.Columns(3).Width = 50
            dgbRegistro.Columns(4).Width = 50
            dgbRegistro.Columns(5).Width = 280

            'End If


            'If (query <> Nothing) Then
            '    Dim ds As New DataSet
            '    Dim rea As New StringReader(query)
            '    If (query <> "") Then
            '        ds.ReadXml(rea)
            '        dgbRegistro.DataSource = ds.Tables(0)

            '    Else
            '        dgbRegistro.DataSource = Nothing
            '    End If
            'End If

        End Sub

        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick

            If e.RowIndex >= 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End Sub

        Private Sub frmBuscarSimple_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            txtSerie.Focus()
        End Sub

        Private Sub frmBuscarSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtSerie.Focus()
        End Sub

        Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

        End Sub
    End Class
End Namespace