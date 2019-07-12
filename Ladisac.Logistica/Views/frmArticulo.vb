Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class frmArticulo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCArticulo As Ladisac.BL.IBCArticulo
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupoLineas
    <Dependency()> _
    Public Property BCMarca As Ladisac.BL.IBCMarcaArticulo
    <Dependency()> _
    Public Property BCModelo As Ladisac.BL.IBCModeloArticulo
    <Dependency()> _
    Public Property BCUnidadMedida As Ladisac.BL.IBCUnidadMedida
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro

    Protected mArticulo As Articulos

    Private Property Control As Object

    'codigo modificado
    Private Sub frmArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarGrupo()
        CargarMarca()
        CargarModelo()
        CargarUnidadMedida()
        LimpiarControles()
        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.

        txtCodigo.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 20
        txtCodigoArticulo.TabIndex = 1
        txtDescripcion.TabIndex = 2
        txtCodigoFabricante.TabIndex = 3
        txtDescripcionFabricante.TabIndex = 4
        rbNacional.TabIndex = 5
        rbInternacional.TabIndex = 6
        cboUnidadMedida.TabIndex = 7
        cboMarca.TabIndex = 8
        cboModelo.TabIndex = 9
        txtColor.TabIndex = 10
        cboGrupo.TabIndex = 11
        cboIgv.TabIndex = 12
        chkAfePercepcion.TabIndex = 13
        chkAfeRetencion.TabIndex = 14
        chkAcpNegativo.TabIndex = 15
        numFactor.TabIndex = 16
        numART_ORDEN_REPORTE.TabIndex = 17
        rbSi.TabIndex = 18
        rbNo.TabIndex = 19
        txtFichaTecnica.TabIndex = 20
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Articulo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarArticulo(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    'modificacion de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '-----------------------------------------------
        If Control = True Then
            MessageBox.Show("Debe de llenar los espaciones selecionados")

        ElseIf Control = False Then

            If mArticulo IsNot Nothing Then
                mArticulo.ART_Codigo = txtCodigoArticulo.Text
                mArticulo.ART_DESCRIPCION = txtDescripcion.Text
                mArticulo.ART_COD_FAB = txtCodigoFabricante.Text
                mArticulo.ART_DESC_FAB = txtDescripcionFabricante.Text
                If rbNacional.Checked = True Then mArticulo.ART_ORIGEN = 0 Else mArticulo.ART_ORIGEN = 1
                mArticulo.UM_ID = cboUnidadMedida.SelectedValue
                mArticulo.MAR_ID = cboMarca.SelectedValue
                mArticulo.MOD_ID = cboModelo.SelectedValue
                mArticulo.ART_COLOR = txtColor.Text
                mArticulo.GLI_ID = cboGrupo.SelectedValue
                If rbSi.Checked = True Then mArticulo.ART_CONT_STOCK = 1 Else mArticulo.ART_CONT_STOCK = 0
                mArticulo.ART_FICHA_TEC = txtFichaTecnica.Text
                mArticulo.ART_INC_IGV = cboIgv.SelectedIndex
                mArticulo.ART_AFE_PER = chkAfePercepcion.Checked
                mArticulo.ART_AFE_RET = chkAfeRetencion.Checked
                mArticulo.ART_PRE_NEG = chkAcpNegativo.Checked
                mArticulo.TIB_TIPOBIEN_ID = txtDetraccion.Tag
                mArticulo.ART_FACTOR = numFactor.Value
                mArticulo.ART_ORDEN_REPORTE = numART_ORDEN_REPORTE.Value

                If Not picArticulo.Image Is Nothing Then
                    Dim ms As New MemoryStream
                    picArticulo.Image.Save(ms, picArticulo.Image.RawFormat)
                    Dim arrImage() As Byte = ms.GetBuffer
                    mArticulo.ART_FOTO = arrImage
                Else
                    mArticulo.ART_FOTO = Nothing
                End If

                If txtCUC_ID_1.Text.Length > 0 Then mArticulo.CUC_ID_1 = txtCUC_ID_1.Text
                If txtCUC_ID_2.Text.Length > 0 Then mArticulo.CUC_ID_2 = txtCUC_ID_2.Text
                If txtCUC_ID_3.Text.Length > 0 Then mArticulo.CUC_ID_3 = txtCUC_ID_3.Text
                If txtCUC_ID_4.Text.Length > 0 Then mArticulo.CUC_ID_4 = txtCUC_ID_4.Text

                mArticulo.ART_LEADTIME = numLeadTime.Value

                mArticulo.ART_ESTADO = chkActivo.Checked
                mArticulo.ART_FEC_GRAB = Now
                mArticulo.USU_ID = SessionServer.UserId
                BCArticulo.MantenimientoArticulo(mArticulo)
                MessageBox.Show(mArticulo.ART_ID)
                MessageBox.Show(mArticulo.ART_Codigo)
                LimpiarControles()
            End If

        End If


        '----------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mArticulo = New Articulos
        mArticulo.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)

        txtCodigoArticulo.Focus()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mArticulo.ART_ID
        txtCodigoArticulo.Text = mArticulo.ART_Codigo
        txtDescripcion.Text = mArticulo.ART_DESCRIPCION
        txtCodigoFabricante.Text = mArticulo.ART_COD_FAB
        txtDescripcionFabricante.Text = mArticulo.ART_DESC_FAB
        If mArticulo.ART_ORIGEN = 0 Then rbNacional.Checked = True Else rbInternacional.Checked = True
        cboUnidadMedida.SelectedValue = mArticulo.UM_ID
        If mArticulo.MAR_ID IsNot Nothing Then cboMarca.SelectedValue = mArticulo.MAR_ID
        If mArticulo.MOD_ID IsNot Nothing Then cboModelo.SelectedValue = mArticulo.MOD_ID
        txtColor.Text = mArticulo.ART_COLOR
        cboGrupo.SelectedValue = mArticulo.GLI_ID
        If mArticulo.ART_CONT_STOCK = 0 Then rbNo.Checked = True Else rbSi.Checked = True
        txtFichaTecnica.Text = mArticulo.ART_FICHA_TEC
        cboIgv.SelectedIndex = mArticulo.ART_INC_IGV
        chkAfePercepcion.Checked = mArticulo.ART_AFE_PER
        chkAfeRetencion.Checked = mArticulo.ART_AFE_RET
        chkAcpNegativo.Checked = mArticulo.ART_PRE_NEG
        If mArticulo.TiposBienesServicios IsNot Nothing Then
            txtDetraccion.Text = mArticulo.TiposBienesServicios.tib_Poncentaje & " - " & mArticulo.TiposBienesServicios.tib_Descripcion
            txtDetraccion.Tag = mArticulo.TIB_TIPOBIEN_ID
        End If


        numFactor.Value = mArticulo.ART_FACTOR
        numART_ORDEN_REPORTE.Value = mArticulo.ART_ORDEN_REPORTE
        numLeadTime.Value = mArticulo.ART_LEADTIME


        If Not mArticulo.ART_FOTO Is Nothing Then
            If mArticulo.ART_FOTO.Length > 0 Then
                Dim binario() As Byte
                binario = mArticulo.ART_FOTO
                Dim ms As New MemoryStream(binario)
                picArticulo.Image = Image.FromStream(ms)
            End If
        End If

        txtCUC_ID_1.Text = mArticulo.CUC_ID_1
        txtCUC_ID_2.Text = mArticulo.CUC_ID_2
        txtCUC_ID_3.Text = mArticulo.CUC_ID_3
        txtCUC_ID_4.Text = mArticulo.CUC_ID_4

        chkActivo.Checked = mArticulo.ART_ESTADO

    End Sub

    Sub CargarArticulo(ByVal ART_Id As String)
        mArticulo = BCArticulo.ArticuloGetById(ART_Id)
        mArticulo.MarkAsModified()
    End Sub

    Sub CargarGrupo()
        Dim ds As New DataSet
        Dim query = BCGrupo.ListaGrupoLineas
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboGrupo
            .DisplayMember = "Grupo_Linea_Familia"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarModelo()
        Dim ds As New DataSet
        Dim query = BCModelo.ListaModeloArticulo
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboModelo
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarMarca()
        Dim ds As New DataSet
        Dim query = BCMarca.ListaMarcaArticulo
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboMarca
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarUnidadMedida()
        Dim ds As New DataSet
        Dim query = BCUnidadMedida.ListaUnidadMedida
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboUnidadMedida
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mArticulo = Nothing
        txtCodigo.Text = String.Empty
        txtCodigoArticulo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtCodigoFabricante.Text = String.Empty
        txtDescripcionFabricante.Text = String.Empty
        rbNacional.Checked = True
        cboUnidadMedida.SelectedIndex = -1
        cboMarca.SelectedIndex = -1
        cboModelo.SelectedIndex = -1
        txtColor.Text = String.Empty
        cboGrupo.SelectedIndex = -1
        rbSi.Checked = True
        txtFichaTecnica.Text = String.Empty
        cboIgv.SelectedIndex = 1
        chkAfePercepcion.Checked = False
        chkAfeRetencion.Checked = False
        chkAcpNegativo.Checked = False
        txtDetraccion.Text = String.Empty
        txtDetraccion.Tag = Nothing
        numFactor.Value = 1
        numART_ORDEN_REPORTE.Value = 5
        numLeadTime.Value = 0
        picArticulo.Image = Nothing
        txtCUC_ID_1.Text = String.Empty
        txtCUC_ID_2.Text = String.Empty
        txtCUC_ID_3.Text = String.Empty
        txtCUC_ID_4.Text = String.Empty

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub ResetRutaImagen()
        With ofImagen
            .Reset()
            .Filter = "Jpg files (*.jpg)|*.jpg|Bmp files (*.bmp)|*.bmp|All files (*.*)|*.*"
            .FilterIndex = 0
        End With
    End Sub

    Private Sub picArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picArticulo.DoubleClick
        ResetRutaImagen()
        If Me.ofImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.picArticulo.Image = Image.FromFile(ofImagen.FileName)
        End If
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripcion") : txtDescripcion.Focus() : flag = False
        'If Len(txtCodigoFabricante.Text.Trim) = 0 Then Error_validacion.SetError(txtCodigoFabricante, "Ingrese el Codigo del Fabricante") : txtCodigoFabricante.Focus() : flag = False
        'If Len(txtDescripcionFabricante.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcionFabricante, "Ingrese la Descripcion del Fabricante") : txtDescripcionFabricante.Focus() : flag = False
        If Len(cboUnidadMedida.Text.Trim) = 0 Then Error_validacion.SetError(cboUnidadMedida, "Ingrese las Unidades de Medida") : cboUnidadMedida.Focus() : flag = False
        'If Len(cboMarca.Text.Trim) = 0 Then Error_validacion.SetError(cboMarca, "Ingrese la Marca") : cboMarca.Focus() : flag = False
        'If Len(cboModelo.Text.Trim) = 0 Then Error_validacion.SetError(cboModelo, "Ingrese el Modelo") : cboModelo.Focus() : flag = False
        'If Len(txtColor.Text.Trim) = 0 Then Error_validacion.SetError(txtColor, "Ingrese el Color") : txtColor.Focus() : flag = False
        If Len(cboGrupo.Text.Trim) = 0 Then Error_validacion.SetError(cboGrupo, "Ingrese el Grupo") : cboGrupo.Focus() : flag = False
        'If Len(txtFichaTecnica.Text.Trim) = 0 Then Error_validacion.SetError(txtFichaTecnica, "Ingrese la Ficha Tecnica") : txtFichaTecnica.Focus() : flag = False
        'If Len(cboIgv.Text.Trim) = 0 Then Error_validacion.SetError(cboIgv, "Ingrese el IGV") : cboIgv.Focus() : flag = False
        'If Len(numFactor.Text.Trim) = 0 Then Error_validacion.SetError(numFactor, "Ingrese el Numero") : numFactor.Focus() : flag = False

        If SessionServer.UserId <> "ADMIN" Then
            If BCParametro.ParametroGetById("GRUPOSERV").PAR_VALOR1.Contains("/" & cboGrupo.SelectedValue & "/") Then
                Try
                    If Not BCParametro.ParametroGetById(SessionServer.UserId & "PERMSERV").PAR_VALOR1.Contains("/" & cboGrupo.SelectedValue & "/") Then 'Esto sirve para documentos no libres y usuario por documento
                        MessageBox.Show("No está autorizado ha crear servicios. Se cancelara el guardado.")
                        flag = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("No está autorizado ha crear servicios. Se cancelara el guardado.")
                    flag = False
                End Try
            End If
        End If
        

        If flag = False Then
            MessageBox.Show("Debe de ingresar datos los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtDescripcion.MaxLength = 160
        Me.txtCodigoFabricante.MaxLength = 45
        Me.txtDescripcionFabricante.MaxLength = 45
        Me.cboUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboUnidadMedida.MaxLength = 45
        Me.cboMarca.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboMarca.MaxLength = 45
        Me.cboModelo.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboModelo.MaxLength = 45
        Me.txtColor.MaxLength = 15
        Me.cboGrupo.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboGrupo.MaxLength = 45
        Me.txtFichaTecnica.MaxLength = 255
        Me.cboIgv.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboIgv.MaxLength = 18
        Me.numFactor.Maximum = 99 : Me.numFactor.DecimalPlaces = 2

    End Sub

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
        If mArticulo IsNot Nothing Then
            mArticulo.MarkAsDeleted()
            BCArticulo.MantenimientoArticulo(mArticulo)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
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

    Private Sub txtDetraccion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDetraccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "TiposBienesServicios"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDetraccion.Tag = frm.dgvLista.CurrentRow.Cells("ID").Value 'tib_id
            txtDetraccion.Text = Math.Round(CDbl(frm.dgvLista.CurrentRow.Cells(2).Value), 2).ToString & " - " & frm.dgvLista.CurrentRow.Cells(1).Value 'Porcentaje - Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCUC_ID_1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUC_ID_1.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentasContables"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCUC_ID_1.Text = frm.dgvLista.CurrentRow.Cells(0).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCUC_ID_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUC_ID_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCUC_ID_1_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCUC_ID_2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUC_ID_2.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentasContables"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCUC_ID_2.Text = frm.dgvLista.CurrentRow.Cells(0).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCUC_ID_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUC_ID_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCUC_ID_2_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCUC_ID_3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUC_ID_3.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentasContables"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCUC_ID_3.Text = frm.dgvLista.CurrentRow.Cells(0).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCUC_ID_3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUC_ID_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCUC_ID_3_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCUC_ID_4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUC_ID_4.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuentasContables"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCUC_ID_4.Text = frm.dgvLista.CurrentRow.Cells(0).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCUC_ID_4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUC_ID_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCUC_ID_4_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        If chkActivo.Checked Then
            chkActivo.Text = "ACTIVO"
        Else
            chkActivo.Text = "NO ACTIVO"
        End If
    End Sub
End Class
