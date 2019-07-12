Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Public Class frmOrdenDespacho
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCOrdenDespacho As Ladisac.BL.IBCOrdenDespacho

    Protected mODE As OrdenDespacho
    Dim Rpt As New rptOrdenDespacho

    Private Sub frmOrdenDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mODE = Nothing
        txtCodigo.Text = String.Empty
        dtpFecha.Value = Today
        txtTicket.Text = String.Empty
        txtPlaca.Text = String.Empty
        txtPlaca.Tag = Nothing
        txtTN.Text = 0
        txtTara.Text = 0
        txtTNDespachado.Text = 0
        txtDestino.Text = String.Empty
        dgvDetalle.Rows.Clear()
        Error_Validacion.Clear()
    End Sub

    'valida controles desactivacion
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op
            Me.tsbReportes.Enabled = op


        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op
            Me.tsbReportes.Enabled = op

        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op
            Me.tsbReportes.Enabled = op

        End If
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mODE = New OrdenDespacho
        mODE.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    Private Sub txtTicket_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTicket.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()

        frm.Tabla = "Pesaje"
        frm.Tipo = IIf(txtTicket.Text.Length > 0, txtTicket.Text, Nothing)
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTicket.Text = frm.dgvLista.CurrentRow.Cells("Ticket").Value
            txtPlaca.Text = frm.dgvLista.CurrentRow.Cells("Placa").Value
            txtTara.Text = frm.dgvLista.CurrentRow.Cells("Peso1").Value
        End If

        frm.Dispose()
    End Sub

    Private Sub txtTicket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTicket.KeyDown
        If e.KeyCode = Keys.Enter Then txtTicket_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPlaca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()

        frm.Tabla = "PlacaPesaje"
        frm.Tipo = txtPlaca.Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlaca.Text = frm.dgvLista.CurrentRow.Cells("uni_id").Value
            txtPlaca.Tag = frm.dgvLista.CurrentRow.Cells("uni_id").Value
        End If

        frm.Dispose()
    End Sub

    Private Sub txtPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlaca_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(e.ColumnIndex).Name
            Case "ART_DESCRIPCION"
                frm.Tabla = "LadrilloDespacho"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentRow.Cells("ART_ID").Value = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Descripcion
                    'dgvDetalle.CurrentRow.Cells("ODD_PESO_LADRILLO").Value = frm.dgvLista.CurrentRow.Cells("Peso").Value 'Peso_Ladrillo
                End If
            Case "NUMERO_DOCUMENTO"
                If MessageBox.Show("Es Cronograma de Despacho?", "Origen Busqueda", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    frm.Tabla = "CronogramaXdespachar"
                    frm.Tipo = Today
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim cont As Integer = 0
                        For Each mitem As DataGridViewRow In frm.dgvLista.Rows
                            If mitem.Selected Then
                                If cont = 0 Then
                                    dgvDetalle.CurrentCell.Value = mitem.Cells("DTD_DESCRIPCION_DOC").Value.ToString.Substring(0, 3) & " " & mitem.Cells("DES_SERIE_DOC").Value & "-" & mitem.Cells("DES_NUMERO_DOC").Value
                                    dgvDetalle.CurrentRow.Cells("TDO_ID_DOC").Value = mitem.Cells("TDO_ID_DOC").Value
                                    dgvDetalle.CurrentRow.Cells("DTD_ID_DOC").Value = mitem.Cells("DTD_ID_DOC").Value
                                    dgvDetalle.CurrentRow.Cells("DDE_SERIE_DOC").Value = mitem.Cells("DES_SERIE_DOC").Value
                                    dgvDetalle.CurrentRow.Cells("DDE_NUMERO_DOC").Value = mitem.Cells("DES_NUMERO_DOC").Value
                                    dgvDetalle.CurrentRow.Cells("DDE_ITEM_DOC").Value = mitem.Cells("DDE_ITEM").Value
                                    dgvDetalle.CurrentRow.Cells("ART_ID").Value = mitem.Cells("ART_Id").Value
                                    dgvDetalle.CurrentRow.Cells("ART_DESCRIPCION").Value = mitem.Cells("ART_DESCRIPCION").Value
                                    'dgvDetalle.CurrentRow.Cells("ODD_PESO_LADRILLO").Value = mitem.Cells("Peso").Value 'Peso_Ladrillo
                                    dgvDetalle.CurrentRow.Cells("CANT_ORDENADA").Value = mitem.Cells("SALDO").Value
                                    cont = 1
                                Else
                                    Dim nRow As New DataGridViewRow
                                    dgvDetalle.Rows.Add(nRow)
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NUMERO_DOCUMENTO").Value = mitem.Cells("DTD_DESCRIPCION_DOC").Value.ToString.Substring(0, 3) & " " & mitem.Cells("DES_SERIE_DOC").Value & "-" & mitem.Cells("DES_NUMERO_DOC").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TDO_ID_DOC").Value = mitem.Cells("TDO_ID_DOC").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID_DOC").Value = mitem.Cells("DTD_ID_DOC").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_SERIE_DOC").Value = mitem.Cells("DES_SERIE_DOC").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_NUMERO_DOC").Value = mitem.Cells("DES_NUMERO_DOC").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_ITEM_DOC").Value = mitem.Cells("DDE_ITEM").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Value = mitem.Cells("ART_Id").Value
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_DESCRIPCION").Value = mitem.Cells("ART_DESCRIPCION").Value
                                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_PESO_LADRILLO").Value = mitem.Cells("Peso").Value 'Peso_Ladrillo
                                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_ORDENADA").Value = mitem.Cells("SALDO").Value

                                End If
                            End If
                        Next
                    End If
                Else 'Es Orden de Requerimiento
                    frm.Tabla = "OrdenRequerimientoLadrillo"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim cont As Integer = 0
                        For Each mitem As DataGridViewRow In frm.dgvLista.Rows
                            If mitem.Selected Then
                                If cont = 0 Then
                                    dgvDetalle.CurrentCell.Value = "O.R. Ladrillo Nro." & mitem.Cells("Numero").Value
                                    dgvDetalle.CurrentRow.Cells("TDO_ID_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DTD_ID_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DDE_SERIE_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DDE_NUMERO_DOC").Value = mitem.Cells("Numero").Value
                                    dgvDetalle.CurrentRow.Cells("DDE_ITEM_DOC").Value = cont + 1
                                    dgvDetalle.CurrentRow.Cells("ART_ID").Value = mitem.Cells("Codigo").Value
                                    dgvDetalle.CurrentRow.Cells("ART_DESCRIPCION").Value = mitem.Cells("Descripcion").Value
                                    dgvDetalle.CurrentRow.Cells("CANT_ORDENADA").Value = mitem.Cells("Cantidad").Value - mitem.Cells("CantidadAtendida").Value
                                    cont = 1
                                Else
                                    Dim nRow As New DataGridViewRow
                                    dgvDetalle.Rows.Add(nRow)
                                    dgvDetalle.CurrentCell.Value = "O.R. Ladrillo Nro." & mitem.Cells("Numero").Value
                                    dgvDetalle.CurrentRow.Cells("TDO_ID_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DTD_ID_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DDE_SERIE_DOC").Value = Nothing
                                    dgvDetalle.CurrentRow.Cells("DDE_NUMERO_DOC").Value = mitem.Cells("Numero").Value
                                    dgvDetalle.CurrentRow.Cells("DDE_ITEM_DOC").Value = cont + 1
                                    dgvDetalle.CurrentRow.Cells("ART_ID").Value = mitem.Cells("Codigo").Value
                                    dgvDetalle.CurrentRow.Cells("ART_DESCRIPCION").Value = mitem.Cells("Descripcion").Value
                                    dgvDetalle.CurrentRow.Cells("CANT_ORDENADA").Value = mitem.Cells("Cantidad").Value - mitem.Cells("CantidadAtendida").Value

                                End If
                            End If
                        Next
                    End If
                End If
               
            Case "ALM_ID"
                frm.Tabla = "Almacen"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Alm_descripcion
                End If
        End Select
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "OrdenDespacho"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenDespacho(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarOrdenDespacho(ByVal ODE_Id As Integer)
        mODE = BCOrdenDespacho.OrdenDespachoGetById(ODE_Id)
        mODE.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mODE.ODE_ID
        dtpFecha.Value = mODE.ODE_FECHA
        txtTicket.Text = mODE.TICKET.ToString
        txtPlaca.Tag = mODE.UNI_ID
        txtPlaca.Text = mODE.PLACA
        txtDestino.Text = mODE.ODE_DESTINO
        txtTN.Text = mODE.CARGA
        txtTara.Text = mODE.TARA

        For Each mItem In mODE.OrdenDespachoDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_ID").Value = mItem.ODD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_ORDENADA").Value = mItem.CANT_ORDENADA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_DESPACHADA").Value = mItem.CANT_DESPACHADA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TDO_ID_DOC").Value = mItem.TDO_ID_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID_DOC").Value = mItem.DTD_ID_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_SERIE_DOC").Value = mItem.DDE_SERIE_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_NUMERO_DOC").Value = mItem.DDE_NUMERO_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DDE_ITEM_DOC").Value = mItem.DDE_ITEM_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Value = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_DESCRIPCION").Value = mItem.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_PESO_LADRILLO").Value = mItem.ODD_PESO_LADRILLO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NUMERO_DOCUMENTO").Value = mItem.NUMERO_DOCUMENTO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_OBSERVACION").Value = mItem.ODD_OBSERVACION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.ALM_ID
            If mItem.ALM_ID IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Value = mItem.Almacen.ALM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Peso").Value = (dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_DESPACHADA").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ODD_PESO_LADRILLO").Value) / 1000
            Totales()
        Next
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        dgvDetalle.EndEdit()

        If mODE IsNot Nothing Then
            mODE.ODE_FECHA = dtpFecha.Value
            If IsNumeric(txtTicket.Text) Then mODE.TICKET = CInt(txtTicket.Text)
            mODE.UNI_ID = txtPlaca.Tag
            mODE.PLACA = txtPlaca.Text
            mODE.ODE_DESTINO = txtDestino.Text
            mODE.CARGA = txtTN.Text
            mODE.TARA = txtTara.Text

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("ODD_ID").Tag Is Nothing Then
                    With CType(mDetalle.Cells("ODD_ID").Tag, OrdenDespachoDetalle)
                        .CANT_ORDENADA = CDbl(mDetalle.Cells("CANT_ORDENADA").Value)
                        .CANT_DESPACHADA = CDbl(mDetalle.Cells("CANT_DESPACHADA").Value)
                        .TDO_ID_DOC = mDetalle.Cells("TDO_ID_DOC").Value
                        .DTD_ID_DOC = mDetalle.Cells("DTD_ID_DOC").Value
                        .DDE_SERIE_DOC = mDetalle.Cells("DDE_SERIE_DOC").Value
                        .DDE_NUMERO_DOC = mDetalle.Cells("DDE_NUMERO_DOC").Value
                        .DDE_ITEM_DOC = CInt(mDetalle.Cells("DDE_ITEM_DOC").Value)
                        .ART_ID = mDetalle.Cells("ART_ID").Value
                        .ART_DESCRIPCION = mDetalle.Cells("ART_DESCRIPCION").Value
                        .ODD_PESO_LADRILLO = CDbl(mDetalle.Cells("ODD_PESO_LADRILLO").Value)
                        .NUMERO_DOCUMENTO = mDetalle.Cells("NUMERO_DOCUMENTO").Value
                        .ODD_OBSERVACION = mDetalle.Cells("ODD_OBSERVACION").Value
                        If CInt(mDetalle.Cells("ALM_ID").Tag) <> 0 Then .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag) Else .ALM_ID = Nothing
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("ART_DESCRIPCION").Value Is Nothing Then
                    Dim nOOD As New OrdenDespachoDetalle
                    With nOOD
                        .CANT_ORDENADA = CDbl(mDetalle.Cells("CANT_ORDENADA").Value)
                        .CANT_DESPACHADA = CDbl(mDetalle.Cells("CANT_DESPACHADA").Value)
                        .TDO_ID_DOC = mDetalle.Cells("TDO_ID_DOC").Value
                        .DTD_ID_DOC = mDetalle.Cells("DTD_ID_DOC").Value
                        .DDE_SERIE_DOC = mDetalle.Cells("DDE_SERIE_DOC").Value
                        .DDE_NUMERO_DOC = mDetalle.Cells("DDE_NUMERO_DOC").Value
                        .DDE_ITEM_DOC = CInt(mDetalle.Cells("DDE_ITEM_DOC").Value)
                        .ART_ID = mDetalle.Cells("ART_ID").Value
                        .ART_DESCRIPCION = mDetalle.Cells("ART_DESCRIPCION").Value
                        .ODD_PESO_LADRILLO = CDbl(mDetalle.Cells("ODD_PESO_LADRILLO").Value)
                        .NUMERO_DOCUMENTO = mDetalle.Cells("NUMERO_DOCUMENTO").Value
                        .ODD_OBSERVACION = mDetalle.Cells("ODD_OBSERVACION").Value
                        If CInt(mDetalle.Cells("ALM_ID").Tag) <> 0 Then .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag) Else .ALM_ID = Nothing
                        .MarkAsAdded()
                    End With
                    mODE.OrdenDespachoDetalle.Add(nOOD)
                End If
            Next

            mODE.ODE_ESTADO = True
            mODE.ODE_FEC_GRAB = Now
            mODE.USU_ID = SessionServer.UserId

            BCOrdenDespacho.MantenimientoOrdenDespacho(mODE)
            MessageBox.Show(mODE.ODE_ID)
            Imprimir()
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_validacion.Clear()
        If Len(txtPlaca.Text.Trim) = 0 Then Error_Validacion.SetError(txtPlaca, "Ingrese la Placa") : txtPlaca.Focus() : flag = False
        If Len(txtTara.Text.Trim) = 0 Then Error_Validacion.SetError(txtPlaca, "Ingrese la Tara") : txtTara.Focus() : flag = False
        If Len(txtTN.Text.Trim) = 0 Then Error_Validacion.SetError(txtPlaca, "Ingrese el TN") : txtTN.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)

    End Sub
    Public Overrides Sub OnManEditar()
        Call validacion_desactivacion(True, 6)
    End Sub
    Public Overrides Sub OnManCancelarEdicion()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManEliminar()
        If mODE IsNot Nothing Then
            For cont = mODE.OrdenDespachoDetalle.Count - 1 To 0 Step -1
                mODE.OrdenDespachoDetalle(cont).MarkAsDeleted()
            Next
            mODE.MarkAsDeleted()
            BCOrdenDespacho.MantenimientoOrdenDespacho(mODE)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    Public Overrides Sub OnReportes()
        Imprimir()
    End Sub

    Sub Imprimir()
        If mODE IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim mDs As New dsOrdenDespacho
                    For Each mItem In mODE.OrdenDespachoDetalle
                        Dim nR As DataRow
                        nR = mDs.OrdenDespacho.NewRow
                        nR.Item("ODE_ID") = mODE.ODE_ID
                        nR.Item("ODE_FECHA") = mODE.ODE_FECHA.Value.Date
                        nR.Item("TICKET") = mODE.TICKET
                        nR.Item("PLACA") = mODE.PLACA
                        nR.Item("ODE_DESTINO") = mODE.ODE_DESTINO
                        nR.Item("CARGA") = mODE.CARGA.Value.ToString("0.00")
                        nR.Item("CANT_ORDENADA") = mItem.CANT_ORDENADA.Value.ToString("0.000")
                        nR.Item("ART_DESCRIPCION") = mItem.ART_DESCRIPCION
                        'nR.Item("ODD_PESO_LADRILLO") = mItem.ODD_PESO_LADRILLO.Value.ToString
                        nR.Item("NUMERO_DOCUMENTO") = mItem.NUMERO_DOCUMENTO
                        nR.Item("ODD_OBSERVACION") = mItem.ODD_OBSERVACION
                        nR.Item("TARA") = mODE.TARA
                        mDs.OrdenDespacho.AddOrdenDespachoRow(nR)
                    Next
                    Rpt.SetDataSource(mDs.Tables(0))
                    Rpt.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
                    Rpt.PrintToPrinter(1, False, 1, 1)

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CANT_DESPACHADA", "ODD_PESO_LADRILLO"
                CType(sender, DataGridView).CurrentRow.Cells("Peso").Value = (CType(sender, DataGridView).CurrentRow.Cells("CANT_DESPACHADA").Value * CType(sender, DataGridView).CurrentRow.Cells("ODD_PESO_LADRILLO").Value) / 1000
        End Select
        Totales()
    End Sub

    Sub Totales()
        txtTNDespachado.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("Peso").Value)), 3)
    End Sub


    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub
End Class
