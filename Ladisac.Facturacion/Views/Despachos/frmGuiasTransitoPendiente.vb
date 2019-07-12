Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Public Class frmGuiasTransitoPendiente
    <Dependency()>
    Public Property SessionService As Ladisac.Foundation.Services.ISessionService
    <Dependency()>
    Public Property BCDespachos As Ladisac.BL.BCDespachos

    Dim Rpt As New rptGuiasEnTransitoPendiente

    Private Sub frmGuiasTransitoPendiente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar()
        dgvProcesar.Rows.Clear()
        Dim query As String
        Dim ds As New DataSet
        query = BCDespachos.ListaGuiasEnTransitoPendientes(txtAlmacen.Tag)
        If Not query = "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each mItem In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                dgvProcesar.Rows.Add(nRow)
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DTD_DESCRIPCION").Value = mItem("DTD_DESCRIPCION")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DMO_SERIE").Value = mItem("DMO_SERIE")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DMO_NRO").Value = mItem("DMO_NRO")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DMO_FECHA_DOCUMENTO").Value = mItem("DMO_FECHA_DOCUMENTO")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DES_FEC_SAL_PLA").Value = mItem("DES_FEC_SAL_PLA")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("Placa").Value = mItem("Placa")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("Transportista").Value = mItem("Transportista")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("ART_DESCRIPCION").Value = mItem("ART_DESCRIPCION")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("TSa").Value = mItem("TSa")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("PROCESO").Value = False
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("DTD_ID").Value = mItem("DTD_ID")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 1).Cells("TDO_ID").Value = mItem("TDO_ID")
            Next
        End If
    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "AlmacenXPuntoventa"
        frm.Tipo = SessionService.UserId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAlmacen.Tag = frm.dgvLista.CurrentRow.Cells("ALM_ID").Value
            txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells("ALM_DESCRIPCION").Value
            btnBuscar()
        Else
            txtAlmacen.Tag = Nothing
            txtAlmacen.Text = String.Empty
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAlmacen_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Procesar()
        btnBuscar()
    End Sub

    Private Sub Procesar()
        dgvProcesar.EndEdit()

        Try
            Dim Lista1 = From mGrid As DataGridViewRow In dgvProcesar.Rows Where mGrid.Cells("PROCESO").Value = True Group mGrid By TDO_ID = mGrid.Cells("TDO_ID").Value, DTD_ID = mGrid.Cells("DTD_ID").Value, DES_SERIE = mGrid.Cells("DMO_SERIE").Value, DES_NUMERO = mGrid.Cells("DMO_NRO").Value Into Gpr = Group _
          Select TDO_ID, DTD_ID, DES_SERIE, DES_NUMERO

            For Each mItem In Lista1.ToList
                BCDespachos.PasarTransito_AlmacenUsu(mItem.TDO_ID, mItem.DTD_ID, mItem.DES_SERIE, mItem.DES_NUMERO, txtAlmacen.Tag, SessionService.UserId, dtpFecha.Value)
            Next

        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar Documentos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Imprimir()
    End Sub

    Sub Imprimir()

        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim mDs As New dsGuiasEnTransitoPendiente
                For Each mItem As DataGridViewRow In dgvProcesar.Rows
                    Dim nR As DataRow
                    nR = mDs.GuiasEnTransitoPendiente.NewRow
                    nR.Item("Documento") = mItem.Cells("DTD_DESCRIPCION").Value
                    nR.Item("Serie") = mItem.Cells("DMO_SERIE").Value
                    nR.Item("Numero") = mItem.Cells("DMO_NRO").Value
                    nR.Item("Fecha") = mItem.Cells("DMO_FECHA_DOCUMENTO").Value
                    nR.Item("FechaHoraSalidaPlanta") = mItem.Cells("DES_FEC_SAL_PLA").Value
                    nR.Item("Transportista") = mItem.Cells("Transportista").Value
                    nR.Item("Placa") = mItem.Cells("Placa").Value
                    nR.Item("Articulo") = mItem.Cells("ART_DESCRIPCION").Value
                    nR.Item("Cantidad") = mItem.Cells("TSa").Value
                    mDs.GuiasEnTransitoPendiente.AddGuiasEnTransitoPendienteRow(nR)
                Next
                Rpt.SetDataSource(mDs.Tables(0))
                Rpt.SetParameterValue("Almacen", txtAlmacen.Text)
                'Rpt.DataDefinition.ParameterFields("Almacen").CurrentValues = "'" & txtAlmacen.Text & "'"
                Rpt.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
                Rpt.PrintToPrinter(1, False, 1, 1)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
End Class
