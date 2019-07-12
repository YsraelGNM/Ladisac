Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmCuentaRendir
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCCuentaRendir As Ladisac.BL.IBCCuentaRendir
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCMoneda As Ladisac.BL.IBCMoneda
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCTesoreria As Ladisac.BL.IBCTesoreria
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo


    Dim mOT As OrdenTrabajo
    Public mCRE As CuentaRendir

    Structure CopiaDatosDocumento
        Dim TipoDocumento As String
        Dim TipoMoneda As String
        Dim TipoCambio As String
        Dim Serie As String
        Dim Numero As String
        Dim Fecha As Date
        Dim Proveedor As String
        Dim DescriProveedor As String
    End Structure

    Dim mCopiaDD As New CopiaDatosDocumento

    Private Sub frmRendicionCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)

        CargarColumnCboTipoDocumento()
        CargarColumnCboTipoMoneda()

        If mCRE IsNot Nothing Then
            If mCRE.CRE_ID > 0 Then LlenarControles()
            Totales()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If

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
        Dim query = BCTipoDocumento.ListaDetalleTipoDocumentoCuentaRendir
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
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "Proveedor"
                frm.Tabla = "Persona"
                frm.Tipo = "Proveedor"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'codigo
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                End If

            Case "CodArt"
                If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value.ToString.Substring(0, 3) = "077" Then 'Planilla de Movilidad
                    frm.Tabla = "RendicionGastos"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentRow.Cells("TipoMoneda").Value = "001"
                        dgvDetalle.CurrentRow.Cells("Fecha").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'Fecha
                        dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells("Fecha")
                        LastColumnComboSelectionChanged(sender, e)
                        dgvDetalle.CurrentRow.Cells("RGA_ID").Value = CInt(frm.dgvLista.CurrentRow.Cells(0).Value)  'Codigo
                        dgvDetalle.CurrentRow.Cells("Serie").Value = 2
                        dgvDetalle.CurrentRow.Cells("Numero").Value = frm.dgvLista.CurrentRow.Cells(0).Value
                        dgvDetalle.CurrentRow.Cells("Articulo").Value = "Planilla de Movilidad" 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'Total
                        dgvDetalle.CurrentRow.Cells("Proveedor").Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value  'Per_Id de planilla de movilidad
                        dgvDetalle.CurrentRow.Cells("Proveedor").Value = frm.dgvLista.CurrentRow.Cells("Nombre").Value  'Nombre de planilla de movilidad

                    End If
                Else
                    frm.Tabla = "ArticuloServicio"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Codigo
                        dgvDetalle.CurrentRow.Cells("Articulo").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("Unid").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'UnidadMedida
                    End If
                End If
        End Select
        frm.Dispose()
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        Dim flag As Boolean = True

        Error_validacion.Clear()

        If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
        If Len((txtOT.Tag & "").Trim) = 0 Then Error_validacion.SetError(txtOT, "Ingrese el Codigo de la O.T.") : txtOT.Focus() : flag = False
        If Len((txtObservaciones.Text & "").Trim) = 0 Then Error_validacion.SetError(txtObservaciones, "Ingrese Concepto, Destino u Observacion.") : txtObservaciones.Focus() : flag = False

        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            If mItem.Cells("Total").Value <= 0.0 Then
                flag = False
                Error_validacion.SetError(dgvDetalle, "Error en el Monto.")
                dgvDetalle.Focus()
                MessageBox.Show("El monto no puede ser menor o igual a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        mCRE.CRE_FECHA = dtpFecha.Value
        mCRE.CRE_FECHA_REGULARIZACION = dtpFechaRegularizacion.Value
        mCRE.TDO_ID_TES = txtCodigo.Tag
        mCRE.DTD_ID_TES = txtDTD_ID_TES.Tag
        mCRE.CCC_ID_TES = txtNombreTes.Tag
        mCRE.TES_SERIE = txtSerieTes.Text
        mCRE.TES_NUMERO = txtNumeroTes.Text
        mCRE.DTD_IDe_TES = txtImporteTes.Tag
        mCRE.CRE_OBSERVACION = txtObservaciones.Text
        mCRE.CRE_FEC_INI_VIAJE = dtpFecIniViaje.Value
        mCRE.CRE_FEC_FIN_VIAJE = dtpFecFinViaje.Value
        mCRE.OTR_ID = txtOT.Tag
        mCRE.CRE_ESTADO = True
        mCRE.CRE_FEC_GRAB = Now
        mCRE.USU_ID = SessionServer.UserId

        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If Not mDetalle.Cells("CRD_ID").Tag Is Nothing Then
                With CType(mDetalle.Cells("CRD_ID").Tag, CuentaRendirDetalle)
                    .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                    .TDO_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(3, 3)
                    .DTD_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(0, 3)
                    If mDetalle.Cells("TipoDocumento").Value.ToString.ToString.Length = 9 Then .CCT_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(6, 3) Else .CCT_ID = ""
                    .MON_ID = mDetalle.Cells("TipoMoneda").Value
                    .CRD_TIPO_CAMBIO = CDec(mDetalle.Cells("TipoCambio").Value)
                    .CRD_SERIE_DOC = mDetalle.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
                    .CRD_NUMERO_DOC = mDetalle.Cells("Numero").Value.ToString.Trim.PadLeft(10, "0")
                    .CRD_FECHA = CDate(mDetalle.Cells("Fecha").Value)
                    .ART_ID = mDetalle.Cells("CodArt").Tag
                    .CRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .CRD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PrecioUnitario").Value)
                    .CRD_IGV = CDec(mDetalle.Cells("IGV").Value)
                    .CRD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PrecioUnitario").Value)) * CDec(mDetalle.Cells("TipoCambio").Value)
                    .CRD_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .RGA_ID = mDetalle.Cells("RGA_ID").Value
                    .MarkAsModified()
                End With

            ElseIf Not mDetalle.Cells("Total").Value Is Nothing Then
                Dim nCRD As New CuentaRendirDetalle
                With nCRD
                   .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                    .TDO_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(3, 3)
                    .DTD_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(0, 3)
                    If mDetalle.Cells("TipoDocumento").Value.ToString.ToString.Length = 9 Then .CCT_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(6, 3) Else .CCT_ID = ""
                    .MON_ID = mDetalle.Cells("TipoMoneda").Value
                    .CRD_TIPO_CAMBIO = CDec(mDetalle.Cells("TipoCambio").Value)
                    .CRD_SERIE_DOC = mDetalle.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
                    .CRD_NUMERO_DOC = mDetalle.Cells("Numero").Value.ToString.Trim.PadLeft(10, "0")
                    .CRD_FECHA = CDate(mDetalle.Cells("Fecha").Value)
                    .ART_ID = mDetalle.Cells("CodArt").Tag
                    .CRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .CRD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PrecioUnitario").Value)
                    .CRD_IGV = CDec(mDetalle.Cells("IGV").Value)
                    .CRD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PrecioUnitario").Value)) * CDec(mDetalle.Cells("TipoCambio").Value)
                    .CRD_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .RGA_ID = mDetalle.Cells("RGA_ID").Value
                    .MarkAsAdded()
                End With
                mCRE.CuentaRendirDetalle.Add(nCRD)
            End If
        Next
        If BCCuentaRendir.MantenimientoCuentaRendir(mCRE) = 1 Then
            MessageBox.Show(mCRE.CRE_ID)
            mCRE = BCCuentaRendir.CuentaRendirGetById(mCRE.CRE_ID)
            OnReportes()
            LimpiarControles()
        Else
            MessageBox.Show("Error al insertar.")
            LimpiarControles()
            Exit Sub
        End If

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
            Me.tsbReportes.Enabled = op

        End If
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentaRendir"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarCuentaRendir(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarCuentaRendir(ByVal CRE_ID As Integer)
        mCRE = BCCuentaRendir.CuentaRendirGetById(CRE_ID)
        mCRE.MarkAsModified()
    End Sub

    Sub LimpiarControles()
        txtCodigo.Text = String.Empty
        txtCodigo.Tag = Nothing
        txtDTD_ID_TES.Text = String.Empty
        txtDTD_ID_TES.Tag = Nothing
        txtSerieTes.Text = String.Empty
        txtNumeroTes.Text = String.Empty
        txtNombreTes.Text = String.Empty
        txtNombreTes.Tag = Nothing
        txtImporteTes.Text = String.Empty
        txtImporteTes.Tag = Nothing
        txtAreaTes.Text = String.Empty
        txtObservaciones.Text = String.Empty
        txtOT.Text = String.Empty
        txtOT.Tag = Nothing
        dtpFecha.Value = Today
        dtpFechaRegularizacion.Value = Today
        dtpFecIniViaje.Value = Today
        dtpFecFinViaje.Value = Today
        dgvDetalle.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCRE.CRE_ID
        txtCodigo.Tag = mCRE.TDO_ID_TES
        txtDTD_ID_TES.Text = mCRE.Tesoreria.DetalleTipoDocumentos.DTD_DESCRIPCION
        txtDTD_ID_TES.Tag = mCRE.DTD_ID_TES
        txtSerieTes.Text = mCRE.TES_SERIE
        txtNumeroTes.Text = mCRE.TES_NUMERO
        txtNombreTes.Text = mCRE.Tesoreria.DetalleTesoreria(0).Personas.PER_APE_PAT & " " & mCRE.Tesoreria.DetalleTesoreria(0).Personas.PER_APE_MAT & " " & mCRE.Tesoreria.DetalleTesoreria(0).Personas.PER_NOMBRES
        txtNombreTes.Tag = mCRE.CCC_ID_TES
        txtImporteTes.Text = mCRE.Tesoreria.TES_MONTO_TOTAL
        txtImporteTes.Tag = mCRE.DTD_IDe_TES
        txtAreaTes.Text = mCRE.Tesoreria.DetalleTesoreria(0).Personas.DatosLaborales(0).AreaTrabajos.art_Descripcion
        txtObservaciones.Text = mCRE.CRE_OBSERVACION
        txtOT.Text = mCRE.OTR_ID
        txtOT.Tag = mCRE.OTR_ID

        dtpFecha.Text = mCRE.CRE_FECHA
        dtpFechaRegularizacion.Value = mCRE.CRE_FECHA_REGULARIZACION
        dtpFecIniViaje.Value = mCRE.CRE_FEC_INI_VIAJE
        dtpFecFinViaje.Value = mCRE.CRE_FEC_FIN_VIAJE


        For Each mItem In mCRE.CuentaRendirDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CRD_ID").Tag = mItem
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Fecha")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Fecha").Value = mItem.CRD_FECHA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoDocumento").Value = mItem.DTD_ID & mItem.TDO_ID & mItem.CCT_ID
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoMoneda")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoMoneda").Value = mItem.MON_ID
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoCambio")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TipoCambio").Value = mItem.CRD_TIPO_CAMBIO
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = mItem.CRD_SERIE_DOC
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.CRD_NUMERO_DOC
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Proveedor")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Proveedor").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Proveedor").Tag = mItem.PER_ID_PROVEEDOR
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodArt")
            If mItem.Articulos IsNot Nothing Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodArt").Value = mItem.Articulos.ART_Codigo
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CodArt").Tag = mItem.ART_ID
            End If
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo")
            If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value.ToString.Substring(0, 3) = "077" Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Value = "Planilla de Movilidad"
            Else
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Articulo").Value = mItem.Articulos.ART_DESCRIPCION
            End If
            If mItem.Articulos IsNot Nothing Then
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Unid")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Unid").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
            End If
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.CRD_CANTIDAD
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PrecioUnitario")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PrecioUnitario").Value = mItem.CRD_PRECIO_UNITARIO
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value = mItem.CRD_PRECIO_UNITARIO * mItem.CRD_CANTIDAD

            If dgvDetalle.CurrentRow.Cells("TipoDocumento").Value = "038013012" Then
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = mItem.CRD_PRECIO_UNITARIO * mItem.CRD_CANTIDAD * SessionServer.IGV / 100
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Tag = SessionServer.IGV
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = mItem.CRD_PRECIO_UNITARIO * mItem.CRD_CANTIDAD + mItem.CRD_PRECIO_UNITARIO * mItem.CRD_CANTIDAD * SessionServer.IGV / 100

            Else
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = 0.0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Tag = 0.0
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = CDec(mItem.CRD_PRECIO_UNITARIO * mItem.CRD_CANTIDAD)

            End If
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mItem.CRD_OBSERVACION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGA_ID").Value = mItem.RGA_ID
        Next
        Totales()
    End Sub

    Public Overrides Sub OnManNuevo()
        'LimpiarControles()
        mCRE = New CuentaRendir
        mCRE.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtObservaciones.Focus()
    End Sub

    'Private Sub LastColumnComboSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    If dgvDetalle.CurrentCell.OwningColumn.Name = "TipoMoneda" Then
    '        dgvDetalle.CurrentRow.Cells("TipoCambio").Value = BCDocuMovimiento.TCCompraDia(dgvDetalle.CurrentCell.Value, dtpFecha.Value)
    '    End If
    'End Sub

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
        If mCRE IsNot Nothing Then
            mCRE.CRE_ESTADO = False
            mCRE.MarkAsModified()
            BCCuentaRendir.MantenimientoCuentaRendir(mCRE)
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
            Case "TipoDocumento"
                dgvDetalle.CurrentRow.Cells("Total").Value = 0
                dgvDetalle.CurrentRow.Cells("SubTotal").Value = 0
                dgvDetalle.CurrentRow.Cells("IGV").Value = 0
                dgvDetalle.CurrentRow.Cells("PrecioUnitario").Value = 0
        End Select
        Totales()
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        'If Not e.Row.Cells("NumeroDocumento").Tag Is Nothing Then
        '    If (dgvDetalle.CurrentRow.Cells("DMD_ID").Value & "").ToString.Length > 0 Then
        '        e.Cancel = True
        '        MessageBox.Show("No se puede eliminar el Item, porque esta procesado.")
        '        Exit Sub
        '    Else
        '        CType(e.Row.Cells("NumeroDocumento").Tag, RendicionCuentaDetalle).MarkAsDeleted()
        '    End If
        'End If
    End Sub

    Private Sub Copiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Copiar.Click
        With mCopiaDD
            .TipoDocumento = dgvDetalle.CurrentRow.Cells("TipoDocumento").Value
            .TipoMoneda = dgvDetalle.CurrentRow.Cells("TipoMoneda").Value
            .TipoCambio = dgvDetalle.CurrentRow.Cells("TipoCambio").Value
            .Serie = dgvDetalle.CurrentRow.Cells("Serie").Value
            .Numero = dgvDetalle.CurrentRow.Cells("Numero").Value
            .Fecha = dgvDetalle.CurrentRow.Cells("Fecha").Value
            .Proveedor = dgvDetalle.CurrentRow.Cells("Proveedor").Tag
            .DescriProveedor = dgvDetalle.CurrentRow.Cells("Proveedor").Value
        End With
    End Sub

    Private Sub Pegar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pegar.Click
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If mFila.Selected Then
                mFila.Cells("TipoDocumento").Value = mCopiaDD.TipoDocumento
                mFila.Cells("TipoMoneda").Value = mCopiaDD.TipoMoneda
                mFila.Cells("TipoCambio").Value = mCopiaDD.TipoCambio
                mFila.Cells("Serie").Value = mCopiaDD.Serie
                mFila.Cells("Numero").Value = mCopiaDD.Numero
                mFila.Cells("Fecha").Value = mCopiaDD.Fecha
                mFila.Cells("Proveedor").Tag = mCopiaDD.Proveedor
                mFila.Cells("Proveedor").Value = mCopiaDD.DescriProveedor
            End If
        Next
    End Sub

    Private Sub txtDTD_ID_TES_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDTD_ID_TES.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentaRendirTesoreria"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCodigo.Tag = frm.dgvLista.CurrentRow.Cells("TDO_ID").Value
            txtDTD_ID_TES.Text = frm.dgvLista.CurrentRow.Cells("DTD_DESCRIPCION").Value
            txtDTD_ID_TES.Tag = frm.dgvLista.CurrentRow.Cells("DTD_ID").Value
            txtSerieTes.Text = frm.dgvLista.CurrentRow.Cells("TES_SERIE").Value
            txtNumeroTes.Text = frm.dgvLista.CurrentRow.Cells("TES_NUMERO").Value
            txtNombreTes.Text = frm.dgvLista.CurrentRow.Cells("Nombre").Value
            txtNombreTes.Tag = frm.dgvLista.CurrentRow.Cells("CCC_ID").Value
            txtImporteTes.Text = frm.dgvLista.CurrentRow.Cells("TES_MONTO_TOTAL").Value
            txtImporteTes.Tag = frm.dgvLista.CurrentRow.Cells("DTD_IDe").Value
            txtAreaTes.Text = frm.dgvLista.CurrentRow.Cells("Area").Value
            dtpFecha.Value = frm.dgvLista.CurrentRow.Cells("TES_FECHA_EMI").Value
        End If
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub txtDTD_ID_TES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDTD_ID_TES.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDTD_ID_TES_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Sub Totales()
        txtTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("Total").Value)), 2)
    End Sub

    Private Sub LastColumnComboSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If dgvDetalle.CurrentCell.OwningColumn.Name = "TipoMoneda" Then
            If dgvDetalle.CurrentRow.Cells("Fecha").Value IsNot Nothing Then
                dgvDetalle.CurrentRow.Cells("TipoCambio").Value = BCDocuMovimiento.TCCompraDia(dgvDetalle.CurrentCell.Value, dgvDetalle.CurrentRow.Cells("Fecha").Value)
            Else
                MessageBox.Show("Coloque la fecha de emision del documento.")
            End If
        End If
        If dgvDetalle.CurrentCell.OwningColumn.Name = "TipoDocumento" Then
            If dgvDetalle.CurrentCell.Value.ToString.Substring(0, 3) = "038" Or dgvDetalle.CurrentCell.Value.ToString.Substring(0, 3) = "082" Or dgvDetalle.CurrentCell.Value.ToString.Substring(0, 3) = "144" Or dgvDetalle.CurrentCell.Value.ToString.Substring(0, 3) = "216" Or dgvDetalle.CurrentCell.Value.ToString.Substring(0, 3) = "066" Then dgvDetalle.CurrentRow.Cells("IGV").Tag = SessionServer.IGV Else dgvDetalle.CurrentRow.Cells("IGV").Tag = "0"
            dgvDetalle.CurrentRow.Cells("Total").Value = CDec(0.0)
        End If
        If dgvDetalle.CurrentCell.OwningColumn.Name = "Fecha" Then
            If dgvDetalle.CurrentRow.Cells("TipoMoneda").Value IsNot Nothing Then
                dgvDetalle.CurrentRow.Cells("TipoCambio").Value = BCDocuMovimiento.TCCompraDia(dgvDetalle.CurrentRow.Cells("TipoMoneda").Value, dgvDetalle.CurrentRow.Cells("Fecha").Value)
            End If
        End If
    End Sub

    Private Sub txtOT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOT.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Dim Her = ContainerService.Resolve(Of Herramientas)()
        frm.Tabla = "OrdenTrabajoOR"
        frm.Tipo = IIf(txtOT.Text = "", Nothing, txtOT.Text)
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            mOT = BCOrdenTrabajo.OrdenTrabajoGetById(key)
            If Her.PermisoEntidad(mOT.ENO_ID) = False Then MsgBox("No le corresponde esta Area.") : frm.Dispose() : Exit Sub
            txtOT.Text = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id
            txtOT.Tag = CInt(frm.dgvLista.CurrentRow.Cells(0).Value)  'OTR_Id
        End If
    End Sub

    Private Sub txtOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOT.KeyDown
        If e.KeyCode = Keys.Enter Then txtOT_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnReportes()
        If mCRE IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim ds As New dsImpresionCuentaRendir
                    Dim rpt As New rptCuentaRendir

                    Dim dt As DataTable = BCCuentaRendir.ImprimirCuentaRendir(mCRE.CRE_ID)
                    ds.Tables(0).Merge(dt)
                    rpt.SetDataSource(ds.Tables(0))
                    rpt.PrintToPrinter(PrintDialog1.PrinterSettings, PrintDialog1.PrinterSettings.DefaultPageSettings, False)
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub
End Class