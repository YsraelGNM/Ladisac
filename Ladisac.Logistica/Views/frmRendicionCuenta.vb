Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRendicionCuenta
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCRendicionCuenta As Ladisac.BL.IBCRendicionCuenta
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCMoneda As Ladisac.BL.IBCMoneda
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()>
    Public Property BCAlmacen As Ladisac.BL.IBCAlmacen

    Protected mREC As RendicionCuenta
    Protected mDocu As DocuMovimiento

    Structure CopiaDatosDocumento
        Dim TipoDocumento As String
        Dim TipoMoneda As String
        Dim TipoCambio As String
        Dim Serie As String
        Dim NumeroDocumento As String
        Dim Fecha As Date
        Dim Proveedor As String
        Dim DescriProveedor As String
        Dim Almacen As String
        Dim DescriAlmacen As String
    End Structure

    Dim mCopiaDD As New CopiaDatosDocumento

    Private Sub frmRendicionCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call validacion_desactivacion(False, 1)
        LimpiarControles()
        CargarColumnCboTipoDocumento()
        CargarColumnCboTipoMoneda()
    End Sub

    Sub CargarColumnCboTipoMoneda()
        Dim ds As New DataSet
        Dim query = BCMoneda.ListaMoneda
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Dim mCbo As New DataGridViewComboBoxColumn
        With mCbo
            .Name = "TipoMoneda"
            .HeaderText = "TipoMoneda"
            .DisplayMember = "MON_Simbolo"
            .ValueMember = "MON_ID"
            .DataSource = ds.Tables(0)
        End With
        AddHandler dgvDetalle.CellValueChanged, AddressOf LastColumnComboSelectionChanged
        dgvDetalle.Columns.Add(mCbo)
        dgvDetalle.Columns("TipoMoneda").DisplayIndex = 1
    End Sub

    Sub CargarColumnCboTipoDocumento()
        Dim ds As New DataSet
        Dim query = BCTipoDocumento.ListaDetalleTipoDocumentoRendicion
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Dim mCbo As New DataGridViewComboBoxColumn
        With mCbo
            .Name = "TipoDocumento"
            .HeaderText = "TipoDocumento"
            .DisplayMember = "DTD_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
        dgvDetalle.Columns.Add(mCbo)
        dgvDetalle.Columns("TipoDocumento").DisplayIndex = 0
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case dgvDetalle.CurrentCell.ColumnIndex
            Case 5
                frm.Tabla = "Persona"
                frm.Tipo = "Proveedor"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'codigo
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                End If
            Case 8
                frm.Tabla = "AlmacenRendicion"
                frm.Art_Id = dgvDetalle.CurrentRow.Cells("Articulo").Tag
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'codigo
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                End If

        End Select
        frm.Dispose()
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        Dim flag As Boolean = True

        Error_validacion.Clear()

        If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False

        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            If (mItem.Cells("Total").Value * mItem.Cells("TipoCambio").Value) > BCParametro.ParametroGetById("MontoRendicion").PAR_VALOR1 Then
                flag = False
                MessageBox.Show("El monto esta por encima de lo permitido.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit For
            End If
        Next

        If flag = False Then
            MessageBox.Show("Debe de ingresar datos en los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()
        If Not validar_controles() Then Exit Sub
        mREC.REC_FECHA = dtpFecha.Value
        mREC.REC_OBSERVACION = txtObservaciones.Text
        mREC.REC_ESTADO = True
        mREC.REC_FEC_GRAB = Now
        mREC.USU_ID = SessionServer.UserId
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If Not mDetalle.Cells("NumeroDocumento").Tag Is Nothing Then
                With CType(mDetalle.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle)
                    .RCD_TIPO_CAMBIO = CDec(mDetalle.Cells("TipoCambio").Value)
                    .RCD_SERIE_DOC = mDetalle.Cells("Serie").Value
                    .RCD_NUMERO_DOC = mDetalle.Cells("NumeroDocumento").Value
                    .RCD_FECHA = CDate(mDetalle.Cells("Fecha").Value)
                    .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                    .ART_ID = mDetalle.Cells("Articulo").Tag
                    .ALM_ID = CType(mDetalle.Cells("Almacen").Tag, Integer)
                    .RCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .RCD_PU = CDec(mDetalle.Cells("PrecioUnitario").Value)
                    .RCD_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .PCD_ID = CInt(mDetalle.Cells("ProcesoCompraDetalle").Value)
                    .DTD_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(0, 3)
                    .TDO_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(3, 3)
                    If mDetalle.Cells("TipoDocumento").Value.ToString.ToString.Length = 9 Then .CCT_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(6, 3) Else .CCT_ID = ""
                    .MON_ID = mDetalle.Cells("TipoMoneda").Value
                    .MarkAsModified()
                End With

            ElseIf Not mDetalle.Cells("Total").Value Is Nothing Then
                Dim nRCD As New RendicionCuentaDetalle
                With nRCD
                    .TDO_ID = mDetalle.Cells("TipoDocumento").Tag
                    .RCD_TIPO_CAMBIO = CDec(mDetalle.Cells("TipoCambio").Value)
                    .RCD_SERIE_DOC = mDetalle.Cells("Serie").Value
                    .RCD_NUMERO_DOC = mDetalle.Cells("NumeroDocumento").Value
                    .RCD_FECHA = CDate(mDetalle.Cells("Fecha").Value)
                    .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                    .ART_ID = mDetalle.Cells("Articulo").Tag
                    .ALM_ID = CType(mDetalle.Cells("Almacen").Tag, Integer)
                    .RCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .RCD_PU = CDec(mDetalle.Cells("PrecioUnitario").Value)
                    .RCD_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .PCD_ID = CInt(mDetalle.Cells("ProcesoCompraDetalle").Value)
                    .DTD_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(0, 3)
                    .TDO_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(3, 3)
                    If mDetalle.Cells("TipoDocumento").Value.ToString.ToString.Length = 9 Then .CCT_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(6, 3) Else .CCT_ID = ""
                    .MON_ID = mDetalle.Cells("TipoMoneda").Value
                    .MarkAsAdded()
                End With
                mREC.RendicionCuentaDetalle.Add(nRCD)
            End If
        Next
        BCRendicionCuenta.MantenimientoRendicionCuenta(mREC)
        MessageBox.Show(mREC.REC_ID)
        LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

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
            Me.tsbReportes.Enabled = Not op


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
            Me.tsbReportes.Enabled = Not op

        End If
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "RendicionCuenta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarRendicionCuenta(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarRendicionCuenta(ByVal REC_ID As Integer)
        mREC = BCRendicionCuenta.RendicionCuentaGetById(REC_ID)
        mREC.MarkAsModified()
    End Sub

    Sub LimpiarControles()
        txtCodigo.Text = String.Empty
        txtObservaciones.Text = String.Empty
        dgvDetalle.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mREC.REC_ID
        txtObservaciones.Text = mREC.REC_OBSERVACION
        dtpFecha.Text = mREC.REC_FECHA

        For Each mItem In mREC.RendicionCuentaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumento").Value = mItem.DTD_ID & mItem.TDO_ID & mItem.CCT_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoMoneda").Value = mItem.MON_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoCambio").Value = mItem.RCD_TIPO_CAMBIO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = mItem.RCD_SERIE_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NumeroDocumento").Value = mItem.RCD_NUMERO_DOC
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("NumeroDocumento").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Fecha").Value = mItem.RCD_FECHA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Proveedor").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Proveedor").Tag = mItem.PER_ID_PROVEEDOR
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodArt").Value = mItem.Articulos.ART_Codigo
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Tag = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Value = mItem.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Unid").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Almacen").Tag = mItem.ALM_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Almacen").Value = mItem.Almacen.ALM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.RCD_CANTIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PrecioUnitario").Value = mItem.RCD_PU
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value = mItem.RCD_PU * mItem.RCD_CANTIDAD

            If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "038013012" Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = SessionServer.IGV
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = mItem.RCD_PU * mItem.RCD_CANTIDAD + mItem.RCD_PU * mItem.RCD_CANTIDAD * SessionServer.IGV / 100
            Else
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = mItem.RCD_PU * mItem.RCD_CANTIDAD
            End If

            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mItem.RCD_OBSERVACION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DMD_ID").Value = mItem.DMD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ProcesoCompraDetalle").Value = mItem.PCD_ID
        Next
    End Sub

    Public Overrides Sub OnManNuevo()
        'LimpiarControles()
        mREC = New RendicionCuenta
        mREC.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        btnPendientes_Click(Nothing, Nothing)
        txtObservaciones.Focus()
    End Sub

    Private Sub btnPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendientes.Click
        If mREC Is Nothing Then dgvDetalle.Rows.Clear()
        Try
            Dim ds As New DataSet
            Dim query = BCRendicionCuenta.ListaRendicionCuentaConserge(SessionServer.UserId)

            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            For Each mItem In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodArt").Value = mItem("ART_Codigo")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Value = mItem("ART_Descripcion")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Tag = mItem("ART_ID")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Unid").Value = mItem("UM_DESCRIPCION")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem("PCD_CANT")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ProcesoCompraDetalle").Value = mItem("PCD_ID")
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mItem("PRC_ID")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = "(Ingreso Proceso Compra Nro:" & mItem("PRC_ID") & ")"
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LastColumnComboSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If dgvDetalle.CurrentCell.OwningColumn.Name = "TipoMoneda" Then
            dgvDetalle.CurrentRow.Cells("TipoCambio").Value = BCDocuMovimiento.TCCompraDia(dgvDetalle.CurrentCell.Value, dtpFecha.Value)
        End If
    End Sub

    Private Sub btndocumentacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndocumentacion.Click
        Try
            If mREC IsNot Nothing Then

                Dim NroIn = (From GridFila In dgvDetalle.Rows Where GridFila.Cells("Documentacion").Value = True Select Prov = GridFila.cells("Proveedor").Value, Serie = GridFila.cells("Serie").value, Nro = GridFila.cells("NumeroDocumento").value, Doc = GridFila.cells("TipoDocumento").value, Mon = GridFila.cells("TipoMoneda").value, TC = GridFila.cells("TipoCambio").value).Distinct

                For Each NroInList In NroIn.ToList
                    If NroInList.Prov.ToString.Length > 0 And NroInList.Nro.ToString.Length > 0 And NroInList.Doc.ToString.Length > 0 Then
                        Dim mGridItems = From ForInsert As DataGridViewRow In dgvDetalle.Rows Where ForInsert.Cells("Documentacion").Value = True And ForInsert.Cells("Proveedor").Value = NroInList.Prov And ForInsert.Cells("Serie").Value = NroInList.Serie And ForInsert.Cells("NumeroDocumento").Value = NroInList.Nro And ForInsert.Cells("TipoDocumento").Value = NroInList.Doc Select ForInsert

                        Dim mDocu As New DocuMovimiento
                        mDocu.DMO_FECHA = Now
                        mDocu.DTD_ID = NroInList.Doc.ToString.Substring(0, 3)
                        mDocu.TDO_ID = NroInList.Doc.ToString.Substring(3, 3)
                        mDocu.CCT_ID = NroInList.Doc.ToString.Substring(6, 3)
                        mDocu.DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById(NroInList.Doc.ToString.Substring(0, 3))
                        mDocu.PER_ID_PROVEEDOR = mGridItems(0).Cells("Proveedor").Tag
                        mDocu.Personas = CType(mGridItems(0).Cells("NumeroDocumento").Tag, RendicionCuentaDetalle).Personas
                        mDocu.DMO_SERIE = NroInList.Serie
                        mDocu.DMO_NRO = NroInList.Nro
                        mDocu.DMO_FECHA_DOCUMENTO = CDate(mGridItems(0).Cells("Fecha").Value)
                        mDocu.REC_ID = mREC.REC_ID
                        mDocu.MON_ID = mGridItems(0).Cells("TipoMoneda").Value
                        mDocu.DOCU_AFECTA_KARDEX = True
                        mDocu.DMO_ESTADO = True
                        mDocu.DMO_FEC_GRAB = Now
                        mDocu.USU_ID = SessionServer.UserId
                        'Referencia
                        mDocu.DTD_ID_REF = NroInList.Doc.ToString.Substring(0, 3)
                        mDocu.TDO_ID_REF = NroInList.Doc.ToString.Substring(3, 3)
                        mDocu.CCT_ID_REF = NroInList.Doc.ToString.Substring(6, 3)
                        mDocu.DMO_SERIE_REF = NroInList.Serie
                        mDocu.DMO_NRO_REF = NroInList.Nro

                        mDocu.MarkAsAdded()

                        For Each Item In mGridItems.ToList
                            Dim nDMD As New DocuMovimientoDetalle
                            With nDMD
                                .ALM_ID = Item.Cells("Almacen").Tag
                                .ART_ID = Item.Cells("Articulo").Tag
                                .DMD_CANTIDAD = Item.Cells("Cantidad").Value
                                .DMD_PRECIO_UNITARIO = Item.Cells("PrecioUnitario").Value
                                .DMD_IGV = CDec(Item.Cells("IGV").Value)
                                .DMD_CONTRAVALOR = Item.Cells("Cantidad").Value * Item.Cells("PrecioUnitario").Value * Item.Cells("TipoCambio").Value
                                .DMD_GLOSA = Item.Cells("Observacion").Value & " RCTA.: " & mREC.REC_ID.ToString
                                .RCD_ID = CType(Item.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle).RCD_ID
                                .MarkAsAdded()
                            End With
                            mDocu.DocuMovimientoDetalle.Add(nDMD)
                        Next

                        If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocu) = 1 Then
                            MessageBox.Show(mDocu.DMO_ID)
                            mDocu = BCDocuMovimiento.DocuMovimientoGetById(mDocu.DMO_ID)

                            Try 'Para la impresion
                                Dim frm As New frmDocuMovimiento
                                frm.SessionServer = SessionServer
                                frm.BCArticuloAlmacen = BCArticuloAlmacen
                                frm.mDocu = mDocu
                                frm.BCAlmacen = BCAlmacen
                                frm.OnReportes()
                            Catch ex As Exception
                                MessageBox.Show("No se pudo Imprimir.")
                            End Try
                        Else
                            LimpiarControles()
                            Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")
                        End If

                    End If
                Next
            End If
            LimpiarControles()
        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar datos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

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
        If mREC IsNot Nothing Then
            For Each mItem In mREC.RendicionCuentaDetalle
                If mItem.DMD_ID > 0 Then
                    MessageBox.Show("No se puede eliminar la Rendicion de Compras por que hay Items Documentados.")
                    Exit Sub
                End If
            Next
            For cont As Integer = 0 To mREC.RendicionCuentaDetalle.Count - 1
                mREC.RendicionCuentaDetalle(cont).MarkAsDeleted()
            Next
            mREC.MarkAsDeleted()
            BCRendicionCuenta.MantenimientoRendicionCuenta(mREC)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.CurrentCell.OwningColumn.Name
            Case "Cantidad", "PrecioUnitario"
                dgvDetalle.CurrentRow.Cells("SubTotal").Value = Math.Round(dgvDetalle.CurrentRow.Cells("Cantidad").Value * dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value, 6)
                If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "038013012" Or dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "082013012" Then
                    dgvDetalle.CurrentRow.Cells("IGV").Value = 0
                    dgvDetalle.CurrentRow.Cells("Total").Value = 0
                    dgvDetalle.CurrentRow.Cells("IGV").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value * (SessionServer.IGV / 100)
                    dgvDetalle.CurrentRow.Cells("Total").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value + dgvDetalle.CurrentRow.Cells("IGV").Value, 6)
                Else
                    dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value
                End If

            Case "SubTotal"
                dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value / dgvDetalle.CurrentRow.Cells("Cantidad").Value, 6)

                If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "038013012" Or dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "082013012" Then
                    dgvDetalle.CurrentRow.Cells("IGV").Value = 0
                    dgvDetalle.CurrentRow.Cells("Total").Value = 0
                    dgvDetalle.CurrentRow.Cells("IGV").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value * (SessionServer.IGV / 100)
                    dgvDetalle.CurrentRow.Cells("Total").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value + dgvDetalle.CurrentRow.Cells("IGV").Value, 6)
                Else
                    dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value
                    dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value / dgvDetalle.CurrentRow.Cells("Cantidad").Value, 6)
                End If

            Case "Total"
                If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "038013012" Or dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "082013012" Then
                    If dgvDetalle.CurrentRow.Cells("Total").Value > 0 Then
                        dgvDetalle.CurrentRow.Cells("SubTotal").Value = 0
                        dgvDetalle.CurrentRow.Cells("IGV").Value = 0
                        dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = 0

                        dgvDetalle.CurrentRow.Cells("SubTotal").Value = Math.Round(dgvDetalle.CurrentRow.Cells("Total").Value / (1 + (SessionServer.IGV / 100)), 6)
                        dgvDetalle.CurrentRow.Cells("IGV").Value = dgvDetalle.CurrentRow.Cells("Total").Value - dgvDetalle.CurrentRow.Cells("SubTotal").Value
                        dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value / dgvDetalle.CurrentRow.Cells("Cantidad").Value, 6)
                    End If
                Else
                    If dgvDetalle.CurrentRow.Cells("Total").Value > 0 Then
                        dgvDetalle.CurrentRow.Cells("SubTotal").Value = dgvDetalle.CurrentRow.Cells("Total").Value
                        dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = Math.Round(dgvDetalle.CurrentRow.Cells("SubTotal").Value / dgvDetalle.CurrentRow.Cells("Cantidad").Value, 6)
                    End If
                End If
            Case "Documentacion"
                If (dgvDetalle.CurrentRow.Cells("DMD_ID").Value & "").ToString.Length > 0 Then
                    dgvDetalle.CurrentRow.Cells("Documentacion").Value = False
                End If
            Case "TipoDocumento"
                dgvDetalle.CurrentRow.Cells("Total").Value = 0
                dgvDetalle.CurrentRow.Cells("SubTotal").Value = 0
                dgvDetalle.CurrentRow.Cells("IGV").Value = 0
                dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = 0
        End Select
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(Nothing, Nothing)
        End If
        'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        'If e.KeyCode = Keys.Enter Then
        '    Select Case dgvDetalle.CurrentCell.ColumnIndex
        '        Case 5
        '            frm.Tabla = "Persona"
        '            frm.Tipo = "Proveedor"
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(2).Value 'codigo
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
        '            End If
        '        Case 7
        '            frm.Tabla = "AlmacenRendicion"
        '            frm.Art_Id = dgvDetalle.CurrentRow.Cells("Articulo").Tag
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'codigo
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
        '            End If
        '    End Select
        'End If
        'frm.Dispose()
    End Sub

    Private Sub DevolverInicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DevolverInicio.Click
        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            If mItem.Selected Then
                If (mItem.Cells("DMD_ID").Value & "").ToString.Length = 0 Then
                    If Not mItem.Cells("NumeroDocumento").Tag Is Nothing Then
                        CType(mItem.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle).MarkAsDeleted()
                        BCRendicionCuenta.MantenimientoRendicionCuentaDetalle(CType(mItem.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle))
                    Else
                        Dim mPCD As ProcesoCompraDetalle
                        mPCD = BCProcesoCompra.ProcesoCompraDetalleGetById(mItem.Cells("ProcesoCompraDetalle").Value)
                        mPCD.MarkAsDeleted()
                        BCProcesoCompra.MantenimientoProcesoCompraDetalle(mPCD)
                    End If
                End If
            End If
        Next
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("NumeroDocumento").Tag Is Nothing Then
            If (dgvDetalle.CurrentRow.Cells("DMD_ID").Value & "").ToString.Length > 0 Then
                e.Cancel = True
                MessageBox.Show("No se puede eliminar el Item, porque esta procesado.")
                Exit Sub
            Else
                CType(e.Row.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle).MarkAsDeleted()
            End If
        End If
    End Sub

    Private Sub Copiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Copiar.Click
        With mCopiaDD
            .TipoDocumento = dgvDetalle.CurrentRow.Cells("TipoDocumento").Value
            .TipoMoneda = dgvDetalle.CurrentRow.Cells("TipoMoneda").Value
            .TipoCambio = dgvDetalle.CurrentRow.Cells("TipoCambio").Value
            .Serie = dgvDetalle.CurrentRow.Cells("Serie").Value
            .NumeroDocumento = dgvDetalle.CurrentRow.Cells("NumeroDocumento").Value
            .Fecha = dgvDetalle.CurrentRow.Cells("Fecha").Value
            .Proveedor = dgvDetalle.CurrentRow.Cells("Proveedor").Tag
            .DescriProveedor = dgvDetalle.CurrentRow.Cells("Proveedor").Value
            .Almacen = dgvDetalle.CurrentRow.Cells("Almacen").Tag
            .DescriAlmacen = dgvDetalle.CurrentRow.Cells("Almacen").Value
        End With
    End Sub

    Private Sub Pegar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pegar.Click
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If mFila.Selected Then
                mFila.Cells("TipoDocumento").Value = mCopiaDD.TipoDocumento
                mFila.Cells("TipoMoneda").Value = mCopiaDD.TipoMoneda
                mFila.Cells("TipoCambio").Value = mCopiaDD.TipoCambio
                mFila.Cells("Serie").Value = mCopiaDD.Serie
                mFila.Cells("NumeroDocumento").Value = mCopiaDD.NumeroDocumento
                mFila.Cells("Fecha").Value = mCopiaDD.Fecha
                mFila.Cells("Proveedor").Tag = mCopiaDD.Proveedor
                mFila.Cells("Proveedor").Value = mCopiaDD.DescriProveedor
                mFila.Cells("Almacen").Tag = mCopiaDD.Almacen
                mFila.Cells("Almacen").Value = mCopiaDD.DescriAlmacen
            End If
        Next
    End Sub
End Class