Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Namespace Ladisac.Despachos.Views

    Public Class frmDespachoSalida
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCDespachoSalida As Ladisac.BL.IBCDespachoSalida
        <Dependency()> _
        Public Property BCMaestro As Ladisac.BL.IBCMaestro

        Protected mDSA As DespachoSalida
        Private Compuesto1 As New Ladisac.BE.DetalleDespachos

        Structure stArticuloSalida
            Public Item As Integer
            Public ART_ID As String
            Public CodArticulo As String
            Public Descripcion As String
            Public Cantidad As Decimal
        End Structure

        Dim mArticuloSalida() As stArticuloSalida

        Dim CodigoTDO_ID As String
        Dim CodigoDTD_ID As String
        Dim CodigoDES_SERIE As String
        Dim CodigoDES_NUMERO As String

        Private Sub frmDespachoSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Sub LimpiarControles()
            txtGuiaRemision.Text = String.Empty
            txtGuiaRemision.Tag = Nothing
            txtObservaciones.Text = String.Empty
            txtCodigo.Text = String.Empty
            dtpFecha.Value = Today

            dgvArticuloOriginal.Rows.Clear()
            dgvArticuloSalida.Rows.Clear()
            '--------------------------
            Error_Validacion.Clear()
        End Sub

        Private Sub txtGuiaRemision_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGuiaRemision.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
            frm.Tabla = "DespachoSalida"
            frm.Tipo = txtGuiaRemision.Text
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CodigoTDO_ID = frm.dgvLista.CurrentRow.Cells(5).Value
                CodigoDTD_ID = frm.dgvLista.CurrentRow.Cells(6).Value
                CodigoDES_SERIE = frm.dgvLista.CurrentRow.Cells(1).Value
                CodigoDES_NUMERO = frm.dgvLista.CurrentRow.Cells(2).Value

                Compuesto1.Vista = "ListarRegistros"
                Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
                Dim ds As New DataSet
                Dim sr As New StringReader(BCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                    CodigoTDO_ID, _
                                                                    CodigoDTD_ID, _
                                                                    CodigoDES_SERIE, _
                                                                    CodigoDES_NUMERO, _
                                                                    Nothing))
                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    For Each mFila In ds.Tables(0).Rows
                        Dim nRow As New DataGridViewRow
                        dgvArticuloOriginal.Rows.Add(nRow)
                        dgvArticuloOriginal.Rows(dgvArticuloOriginal.Rows.Count - 1).Cells("CodArticulo").Value = mFila("CódigoArticulo")
                        dgvArticuloOriginal.Rows(dgvArticuloOriginal.Rows.Count - 1).Cells("CodArticulo").Tag = mFila("Item")
                        dgvArticuloOriginal.Rows(dgvArticuloOriginal.Rows.Count - 1).Cells("Descripcion").Value = mFila("DescripciónArticulo")
                        dgvArticuloOriginal.Rows(dgvArticuloOriginal.Rows.Count - 1).Cells("Cantidad").Value = mFila("Cantidad")
                    Next
                    txtGuiaRemision.Text = CodigoDES_SERIE & " - " & CodigoDES_NUMERO
                End If

            End If
            frm.Dispose()
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()
            Dim nRow As New DataGridViewRow
            dgvArticuloSalida.Rows.Add(nRow)
        End Sub

        Private Sub dgvArticuloSalida_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticuloSalida.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            Select Case dgvArticuloSalida.Columns(e.ColumnIndex).Name
                Case "CodArticulo1"
                    frm.Tabla = "Ladrillo"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvArticuloSalida.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvArticuloSalida.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value
                        dgvArticuloSalida.CurrentRow.Cells("Descripcion1").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Descripcion
                    End If
            End Select
            frm.Dispose()
        End Sub

        Private Sub dgvArticuloSalida_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticuloSalida.CellEndEdit
            If dgvArticuloSalida.CurrentRow.Cells("CodArticulo1").Tag IsNot Nothing And dgvArticuloSalida.CurrentRow.Cells("Cantidad1").Value > 0 Then
                Dim mFila As New stArticuloSalida
                mFila.Item = dgvArticuloOriginal.CurrentRow.Cells("CodArticulo").Tag
                mFila.ART_ID = dgvArticuloSalida.CurrentRow.Cells("CodArticulo1").Tag
                mFila.CodArticulo = dgvArticuloSalida.CurrentRow.Cells("CodArticulo1").Value
                mFila.Descripcion = dgvArticuloSalida.CurrentRow.Cells("Descripcion1").Value
                mFila.Cantidad = dgvArticuloSalida.CurrentRow.Cells("Cantidad1").Value
            End If
        End Sub


    End Class

End Namespace
