Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing

Public Class frmRptPesoQuema
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    Dim MyDataGridViewPrinter As DataGridViewPrinter

    Private Sub frmRptPesoQuema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        'Select Case e.ColumnIndex
        '    Case 0
        '        frm.Tipo = dtpFecha.Value.Date
        '        frm.Tabla = "PesoQuema"
        '        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            For Each mItem As DataGridViewRow In frm.dgvLista.Rows
        '                Dim nRow As New DataGridViewRow
        '                dgvDetalle.Rows.Add(nRow)
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'PRO_ID
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_DESCRIPCION").Value = frm.dgvLista.CurrentRow.Cells(2).Value
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_FECHA").Value = frm.dgvLista.CurrentRow.Cells(1).Value
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPE_PESO").Value = frm.dgvLista.CurrentRow.Cells(3).Value
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPE_PORCENTAJE_HUMEDAD").Value = frm.dgvLista.CurrentRow.Cells(4).Value
        '                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAR_FECHA").Value = frm.dgvLista.CurrentRow.Cells(5).Value
        '            Next
        '        End If
        'End Select
        'frm.Dispose()
    End Sub

    Sub AgregarCargas()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tipo = dtpFecha.Value.Date
        frm.Tabla = "PesoQuema"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each mItem As DataGridViewRow In frm.dgvLista.Rows
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Value = mItem.Cells(0).Value  'PRO_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_DESCRIPCION").Value = mItem.Cells(2).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_FECHA").Value = mItem.Cells(1).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPE_PESO").Value = mItem.Cells(3).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPE_PORCENTAJE_HUMEDAD").Value = mItem.Cells(4).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAR_FECHA").Value = mItem.Cells(5).Value
            Next
        End If
        frm.Dispose()
    End Sub

    Private Sub btnAgregarFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFila.Click
        'Dim nRow As New DataGridViewRow
        'dgvDetalle.Rows.Add(nRow)
        AgregarCargas()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If SetupThePrinting() Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Function SetupThePrinting() As Boolean
        Dim MyPrintDialog As New PrintDialog()
        MyPrintDialog.AllowCurrentPage = False
        MyPrintDialog.AllowPrintToFile = False
        MyPrintDialog.AllowSelection = False
        MyPrintDialog.AllowSomePages = False
        MyPrintDialog.PrintToFile = False
        MyPrintDialog.ShowHelp = False
        MyPrintDialog.ShowNetwork = False

        If MyPrintDialog.ShowDialog() <> DialogResult.OK Then
            Return False
        End If

        PrintDocument1.DocumentName = "Pesos para la Quema"
        PrintDocument1.PrinterSettings = MyPrintDialog.PrinterSettings
        PrintDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
        PrintDocument1.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)

        MyDataGridViewPrinter = New DataGridViewPrinter(dgvDetalle, PrintDocument1, True, True, "Pesos y Humedades Cargadas en Horno", New Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)

        Return True
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim more As Boolean = MyDataGridViewPrinter.DrawDataGridView(e.Graphics)
        If more = True Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        If SetupThePrinting() Then
            Dim MyPrintPreviewDialog As New PrintPreviewDialog()
            MyPrintPreviewDialog.Document = PrintDocument1
            MyPrintPreviewDialog.ShowDialog()
        End If

    End Sub
End Class
