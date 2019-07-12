Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmKardexDocumento
        'Inherits System.Windows.Forms.Form
        Inherits Ladisac.Foundation.Views.ViewManMaster

        'Form reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.btnImprimirValorizado = New System.Windows.Forms.Button()
            Me.rbPendientesAtencionVendedorXArtículo = New System.Windows.Forms.RadioButton()
            Me.pnFormato = New System.Windows.Forms.Panel()
            Me.rbFormato3 = New System.Windows.Forms.RadioButton()
            Me.rbFormato2 = New System.Windows.Forms.RadioButton()
            Me.rbFormato1 = New System.Windows.Forms.RadioButton()
            Me.chkAnuladas = New System.Windows.Forms.CheckBox()
            Me.pnTipoResumenReporte = New System.Windows.Forms.Panel()
            Me.rbDetalle = New System.Windows.Forms.RadioButton()
            Me.rbResumen = New System.Windows.Forms.RadioButton()
            Me.pnTipoReporteGuias = New System.Windows.Forms.Panel()
            Me.rbGuiasPorArticulo = New System.Windows.Forms.RadioButton()
            Me.rbGuias = New System.Windows.Forms.RadioButton()
            Me.chkFormato = New System.Windows.Forms.CheckBox()
            Me.chkMostrarValorizado = New System.Windows.Forms.CheckBox()
            Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
            Me.lblEstado = New System.Windows.Forms.Label()
            Me.btnIniciar = New System.Windows.Forms.Button()
            Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
            Me.txtprogreso = New System.Windows.Forms.TextBox()
            Me.rbPendientesAtencionVendedor = New System.Windows.Forms.RadioButton()
            Me.rbPendientesAtencion = New System.Windows.Forms.RadioButton()
            Me.rbPendientesAtencionCliente = New System.Windows.Forms.RadioButton()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
            Me.chkMostrarDirecciones = New System.Windows.Forms.CheckBox()
            Me.chkMostrarSaldoCero = New System.Windows.Forms.CheckBox()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.txtALM_DESCRIPCION_LLEGADA = New System.Windows.Forms.TextBox()
            Me.lblALM_ID_LLEGADA = New System.Windows.Forms.Label()
            Me.txtALM_ID_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtALM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblALM_ID = New System.Windows.Forms.Label()
            Me.txtALM_ID = New System.Windows.Forms.TextBox()
            Me.chkResumenDetalle = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.chkTodosDocumentos = New System.Windows.Forms.CheckBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_CLI = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.lblDOCUMENTO = New System.Windows.Forms.Label()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.txtTIP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblTIP_ID = New System.Windows.Forms.Label()
            Me.txtTIP_ID = New System.Windows.Forms.TextBox()
            Me.chkFiltrarXFechas = New System.Windows.Forms.CheckBox()
            Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.lblFechaInicial = New System.Windows.Forms.Label()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.lblFechaFinal = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtCCT_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtCCT_ID = New System.Windows.Forms.TextBox()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            Me.btnImprimirValorizadoSinComercializadora = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            Me.pnFormato.SuspendLayout()
            Me.pnTipoResumenReporte.SuspendLayout()
            Me.pnTipoReporteGuias.SuspendLayout()
            CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(687, 28)
            Me.lblTitle.Text = "Kardex de documento"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.btnImprimirValorizadoSinComercializadora)
            Me.pnCuerpo.Controls.Add(Me.btnImprimirValorizado)
            Me.pnCuerpo.Controls.Add(Me.rbPendientesAtencionVendedorXArtículo)
            Me.pnCuerpo.Controls.Add(Me.pnFormato)
            Me.pnCuerpo.Controls.Add(Me.chkAnuladas)
            Me.pnCuerpo.Controls.Add(Me.pnTipoResumenReporte)
            Me.pnCuerpo.Controls.Add(Me.pnTipoReporteGuias)
            Me.pnCuerpo.Controls.Add(Me.chkFormato)
            Me.pnCuerpo.Controls.Add(Me.chkMostrarValorizado)
            Me.pnCuerpo.Controls.Add(Me.NumericUpDown1)
            Me.pnCuerpo.Controls.Add(Me.lblEstado)
            Me.pnCuerpo.Controls.Add(Me.btnIniciar)
            Me.pnCuerpo.Controls.Add(Me.ProgressBar1)
            Me.pnCuerpo.Controls.Add(Me.txtprogreso)
            Me.pnCuerpo.Controls.Add(Me.rbPendientesAtencionVendedor)
            Me.pnCuerpo.Controls.Add(Me.rbPendientesAtencion)
            Me.pnCuerpo.Controls.Add(Me.rbPendientesAtencionCliente)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.chkMostrarDirecciones)
            Me.pnCuerpo.Controls.Add(Me.chkMostrarSaldoCero)
            Me.pnCuerpo.Controls.Add(Me.dgvDatos)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID)
            Me.pnCuerpo.Controls.Add(Me.chkResumenDetalle)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.chkTodosDocumentos)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtNumero)
            Me.pnCuerpo.Controls.Add(Me.lblDOCUMENTO)
            Me.pnCuerpo.Controls.Add(Me.txtSerie)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.chkFiltrarXFechas)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.lblFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.lblFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(631, 280)
            Me.pnCuerpo.TabIndex = 119
            '
            'btnImprimirValorizado
            '
            Me.btnImprimirValorizado.Enabled = False
            Me.btnImprimirValorizado.Location = New System.Drawing.Point(204, 238)
            Me.btnImprimirValorizado.Name = "btnImprimirValorizado"
            Me.btnImprimirValorizado.Size = New System.Drawing.Size(84, 35)
            Me.btnImprimirValorizado.TabIndex = 56
            Me.btnImprimirValorizado.Text = "Valorizado"
            Me.btnImprimirValorizado.UseVisualStyleBackColor = True
            Me.btnImprimirValorizado.Visible = False
            '
            'rbPendientesAtencionVendedorXArtículo
            '
            Me.rbPendientesAtencionVendedorXArtículo.AutoSize = True
            Me.rbPendientesAtencionVendedorXArtículo.Location = New System.Drawing.Point(94, 222)
            Me.rbPendientesAtencionVendedorXArtículo.Name = "rbPendientesAtencionVendedorXArtículo"
            Me.rbPendientesAtencionVendedorXArtículo.Size = New System.Drawing.Size(357, 17)
            Me.rbPendientesAtencionVendedorXArtículo.TabIndex = 55
            Me.rbPendientesAtencionVendedorXArtículo.TabStop = True
            Me.rbPendientesAtencionVendedorXArtículo.Text = "Documentos de venta pendientes de atención por vendedor x artículo"
            Me.rbPendientesAtencionVendedorXArtículo.UseVisualStyleBackColor = True
            Me.rbPendientesAtencionVendedorXArtículo.Visible = False
            '
            'pnFormato
            '
            Me.pnFormato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnFormato.Controls.Add(Me.rbFormato3)
            Me.pnFormato.Controls.Add(Me.rbFormato2)
            Me.pnFormato.Controls.Add(Me.rbFormato1)
            Me.pnFormato.Enabled = False
            Me.pnFormato.Location = New System.Drawing.Point(254, 174)
            Me.pnFormato.Name = "pnFormato"
            Me.pnFormato.Size = New System.Drawing.Size(356, 42)
            Me.pnFormato.TabIndex = 54
            Me.pnFormato.Visible = False
            '
            'rbFormato3
            '
            Me.rbFormato3.AutoSize = True
            Me.rbFormato3.Checked = True
            Me.rbFormato3.Location = New System.Drawing.Point(207, 2)
            Me.rbFormato3.Name = "rbFormato3"
            Me.rbFormato3.Size = New System.Drawing.Size(145, 17)
            Me.rbFormato3.TabIndex = 2
            Me.rbFormato3.TabStop = True
            Me.rbFormato3.Text = "Detalle venta por artículo"
            Me.rbFormato3.UseVisualStyleBackColor = True
            '
            'rbFormato2
            '
            Me.rbFormato2.AutoSize = True
            Me.rbFormato2.Location = New System.Drawing.Point(3, 18)
            Me.rbFormato2.Name = "rbFormato2"
            Me.rbFormato2.Size = New System.Drawing.Size(198, 17)
            Me.rbFormato2.TabIndex = 1
            Me.rbFormato2.Text = "Record de venta por artículo/cliente"
            Me.rbFormato2.UseVisualStyleBackColor = True
            '
            'rbFormato1
            '
            Me.rbFormato1.AutoSize = True
            Me.rbFormato1.Location = New System.Drawing.Point(3, 2)
            Me.rbFormato1.Name = "rbFormato1"
            Me.rbFormato1.Size = New System.Drawing.Size(198, 17)
            Me.rbFormato1.TabIndex = 0
            Me.rbFormato1.Text = "Record de venta por cliente/artículo"
            Me.rbFormato1.UseVisualStyleBackColor = True
            '
            'chkAnuladas
            '
            Me.chkAnuladas.AutoSize = True
            Me.chkAnuladas.Location = New System.Drawing.Point(461, 122)
            Me.chkAnuladas.Name = "chkAnuladas"
            Me.chkAnuladas.Size = New System.Drawing.Size(93, 17)
            Me.chkAnuladas.TabIndex = 54
            Me.chkAnuladas.Text = "Solo anuladas"
            Me.chkAnuladas.UseVisualStyleBackColor = True
            Me.chkAnuladas.Visible = False
            '
            'pnTipoResumenReporte
            '
            Me.pnTipoResumenReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnTipoResumenReporte.Controls.Add(Me.rbDetalle)
            Me.pnTipoResumenReporte.Controls.Add(Me.rbResumen)
            Me.pnTipoResumenReporte.Enabled = False
            Me.pnTipoResumenReporte.Location = New System.Drawing.Point(522, 231)
            Me.pnTipoResumenReporte.Name = "pnTipoResumenReporte"
            Me.pnTipoResumenReporte.Size = New System.Drawing.Size(88, 42)
            Me.pnTipoResumenReporte.TabIndex = 53
            Me.pnTipoResumenReporte.Visible = False
            '
            'rbDetalle
            '
            Me.rbDetalle.AutoSize = True
            Me.rbDetalle.Location = New System.Drawing.Point(3, 18)
            Me.rbDetalle.Name = "rbDetalle"
            Me.rbDetalle.Size = New System.Drawing.Size(58, 17)
            Me.rbDetalle.TabIndex = 1
            Me.rbDetalle.Text = "Detalle"
            Me.rbDetalle.UseVisualStyleBackColor = True
            '
            'rbResumen
            '
            Me.rbResumen.AutoSize = True
            Me.rbResumen.Checked = True
            Me.rbResumen.Location = New System.Drawing.Point(3, 2)
            Me.rbResumen.Name = "rbResumen"
            Me.rbResumen.Size = New System.Drawing.Size(70, 17)
            Me.rbResumen.TabIndex = 0
            Me.rbResumen.TabStop = True
            Me.rbResumen.Text = "Resumen"
            Me.rbResumen.UseVisualStyleBackColor = True
            '
            'pnTipoReporteGuias
            '
            Me.pnTipoReporteGuias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnTipoReporteGuias.Controls.Add(Me.rbGuiasPorArticulo)
            Me.pnTipoReporteGuias.Controls.Add(Me.rbGuias)
            Me.pnTipoReporteGuias.Enabled = False
            Me.pnTipoReporteGuias.Location = New System.Drawing.Point(399, 231)
            Me.pnTipoReporteGuias.Name = "pnTipoReporteGuias"
            Me.pnTipoReporteGuias.Size = New System.Drawing.Size(117, 42)
            Me.pnTipoReporteGuias.TabIndex = 52
            Me.pnTipoReporteGuias.Visible = False
            '
            'rbGuiasPorArticulo
            '
            Me.rbGuiasPorArticulo.AutoSize = True
            Me.rbGuiasPorArticulo.Location = New System.Drawing.Point(3, 18)
            Me.rbGuiasPorArticulo.Name = "rbGuiasPorArticulo"
            Me.rbGuiasPorArticulo.Size = New System.Drawing.Size(111, 17)
            Me.rbGuiasPorArticulo.TabIndex = 1
            Me.rbGuiasPorArticulo.Text = "Guías por artículo"
            Me.rbGuiasPorArticulo.UseVisualStyleBackColor = True
            '
            'rbGuias
            '
            Me.rbGuias.AutoSize = True
            Me.rbGuias.Checked = True
            Me.rbGuias.Location = New System.Drawing.Point(3, 2)
            Me.rbGuias.Name = "rbGuias"
            Me.rbGuias.Size = New System.Drawing.Size(54, 17)
            Me.rbGuias.TabIndex = 0
            Me.rbGuias.TabStop = True
            Me.rbGuias.Text = "Guías"
            Me.rbGuias.UseVisualStyleBackColor = True
            '
            'chkFormato
            '
            Me.chkFormato.AutoSize = True
            Me.chkFormato.Checked = True
            Me.chkFormato.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkFormato.Location = New System.Drawing.Point(322, 122)
            Me.chkFormato.Name = "chkFormato"
            Me.chkFormato.Size = New System.Drawing.Size(117, 17)
            Me.chkFormato.TabIndex = 50
            Me.chkFormato.Text = "Por punto de venta"
            Me.chkFormato.UseVisualStyleBackColor = True
            '
            'chkMostrarValorizado
            '
            Me.chkMostrarValorizado.AutoSize = True
            Me.chkMostrarValorizado.Location = New System.Drawing.Point(94, 222)
            Me.chkMostrarValorizado.Name = "chkMostrarValorizado"
            Me.chkMostrarValorizado.Size = New System.Drawing.Size(75, 17)
            Me.chkMostrarValorizado.TabIndex = 49
            Me.chkMostrarValorizado.Text = "Valorizado"
            Me.chkMostrarValorizado.UseVisualStyleBackColor = True
            Me.chkMostrarValorizado.Visible = False
            '
            'NumericUpDown1
            '
            Me.NumericUpDown1.Location = New System.Drawing.Point(9, 245)
            Me.NumericUpDown1.Name = "NumericUpDown1"
            Me.NumericUpDown1.Size = New System.Drawing.Size(80, 20)
            Me.NumericUpDown1.TabIndex = 48
            Me.NumericUpDown1.Visible = False
            '
            'lblEstado
            '
            Me.lblEstado.AutoSize = True
            Me.lblEstado.Location = New System.Drawing.Point(7, 247)
            Me.lblEstado.Name = "lblEstado"
            Me.lblEstado.Size = New System.Drawing.Size(39, 13)
            Me.lblEstado.TabIndex = 47
            Me.lblEstado.Text = "Label1"
            Me.lblEstado.Visible = False
            '
            'btnIniciar
            '
            Me.btnIniciar.Location = New System.Drawing.Point(8, 242)
            Me.btnIniciar.Name = "btnIniciar"
            Me.btnIniciar.Size = New System.Drawing.Size(81, 23)
            Me.btnIniciar.TabIndex = 46
            Me.btnIniciar.Text = "Button1"
            Me.btnIniciar.UseVisualStyleBackColor = True
            Me.btnIniciar.Visible = False
            '
            'ProgressBar1
            '
            Me.ProgressBar1.Location = New System.Drawing.Point(8, 242)
            Me.ProgressBar1.Name = "ProgressBar1"
            Me.ProgressBar1.Size = New System.Drawing.Size(82, 23)
            Me.ProgressBar1.TabIndex = 45
            Me.ProgressBar1.Visible = False
            '
            'txtprogreso
            '
            Me.txtprogreso.Location = New System.Drawing.Point(10, 244)
            Me.txtprogreso.Name = "txtprogreso"
            Me.txtprogreso.Size = New System.Drawing.Size(80, 20)
            Me.txtprogreso.TabIndex = 44
            Me.txtprogreso.Visible = False
            '
            'rbPendientesAtencionVendedor
            '
            Me.rbPendientesAtencionVendedor.AutoSize = True
            Me.rbPendientesAtencionVendedor.Location = New System.Drawing.Point(94, 204)
            Me.rbPendientesAtencionVendedor.Name = "rbPendientesAtencionVendedor"
            Me.rbPendientesAtencionVendedor.Size = New System.Drawing.Size(310, 17)
            Me.rbPendientesAtencionVendedor.TabIndex = 43
            Me.rbPendientesAtencionVendedor.TabStop = True
            Me.rbPendientesAtencionVendedor.Text = "Documentos de venta pendientes de atención por vendedor"
            Me.rbPendientesAtencionVendedor.UseVisualStyleBackColor = True
            '
            'rbPendientesAtencion
            '
            Me.rbPendientesAtencion.AutoSize = True
            Me.rbPendientesAtencion.Location = New System.Drawing.Point(94, 172)
            Me.rbPendientesAtencion.Name = "rbPendientesAtencion"
            Me.rbPendientesAtencion.Size = New System.Drawing.Size(282, 17)
            Me.rbPendientesAtencion.TabIndex = 41
            Me.rbPendientesAtencion.TabStop = True
            Me.rbPendientesAtencion.Text = "Documentos de venta pendientes de atención general"
            Me.rbPendientesAtencion.UseVisualStyleBackColor = True
            '
            'rbPendientesAtencionCliente
            '
            Me.rbPendientesAtencionCliente.AutoSize = True
            Me.rbPendientesAtencionCliente.Location = New System.Drawing.Point(94, 188)
            Me.rbPendientesAtencionCliente.Name = "rbPendientesAtencionCliente"
            Me.rbPendientesAtencionCliente.Size = New System.Drawing.Size(296, 17)
            Me.rbPendientesAtencionCliente.TabIndex = 42
            Me.rbPendientesAtencionCliente.TabStop = True
            Me.rbPendientesAtencionCliente.Text = "Documentos de venta pendientes de atención por cliente"
            Me.rbPendientesAtencionCliente.UseVisualStyleBackColor = True
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(5, 43)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ID.TabIndex = 39
            Me.lblPVE_ID.Text = "Punto venta"
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(94, 43)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(47, 20)
            Me.txtPVE_ID.TabIndex = 38
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(147, 43)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(463, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 37
            '
            'dtpFechaInicial
            '
            Me.dtpFechaInicial.Enabled = False
            Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicial.Location = New System.Drawing.Point(94, 150)
            Me.dtpFechaInicial.Name = "dtpFechaInicial"
            Me.dtpFechaInicial.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicial.TabIndex = 13
            Me.dtpFechaInicial.Value = New Date(1900, 1, 1, 9, 35, 0, 0)
            Me.dtpFechaInicial.Visible = False
            '
            'chkMostrarDirecciones
            '
            Me.chkMostrarDirecciones.AutoSize = True
            Me.chkMostrarDirecciones.Enabled = False
            Me.chkMostrarDirecciones.Location = New System.Drawing.Point(95, 150)
            Me.chkMostrarDirecciones.Name = "chkMostrarDirecciones"
            Me.chkMostrarDirecciones.Size = New System.Drawing.Size(172, 17)
            Me.chkMostrarDirecciones.TabIndex = 36
            Me.chkMostrarDirecciones.Text = "Mostrar direcciones de entrega"
            Me.chkMostrarDirecciones.UseVisualStyleBackColor = True
            Me.chkMostrarDirecciones.Visible = False
            '
            'chkMostrarSaldoCero
            '
            Me.chkMostrarSaldoCero.AutoSize = True
            Me.chkMostrarSaldoCero.Enabled = False
            Me.chkMostrarSaldoCero.Location = New System.Drawing.Point(94, 222)
            Me.chkMostrarSaldoCero.Name = "chkMostrarSaldoCero"
            Me.chkMostrarSaldoCero.Size = New System.Drawing.Size(162, 17)
            Me.chkMostrarSaldoCero.TabIndex = 35
            Me.chkMostrarSaldoCero.Text = "Solo documentos con saldos"
            Me.chkMostrarSaldoCero.UseVisualStyleBackColor = True
            Me.chkMostrarSaldoCero.Visible = False
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.AllowUserToOrderColumns = True
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDatos.Location = New System.Drawing.Point(589, 124)
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.Size = New System.Drawing.Size(21, 16)
            Me.dgvDatos.TabIndex = 33
            Me.dgvDatos.Visible = False
            '
            'txtALM_DESCRIPCION_LLEGADA
            '
            Me.txtALM_DESCRIPCION_LLEGADA.Enabled = False
            Me.txtALM_DESCRIPCION_LLEGADA.Location = New System.Drawing.Point(147, 96)
            Me.txtALM_DESCRIPCION_LLEGADA.Name = "txtALM_DESCRIPCION_LLEGADA"
            Me.txtALM_DESCRIPCION_LLEGADA.ReadOnly = True
            Me.txtALM_DESCRIPCION_LLEGADA.Size = New System.Drawing.Size(463, 20)
            Me.txtALM_DESCRIPCION_LLEGADA.TabIndex = 31
            '
            'lblALM_ID_LLEGADA
            '
            Me.lblALM_ID_LLEGADA.AutoSize = True
            Me.lblALM_ID_LLEGADA.Location = New System.Drawing.Point(5, 96)
            Me.lblALM_ID_LLEGADA.Name = "lblALM_ID_LLEGADA"
            Me.lblALM_ID_LLEGADA.Size = New System.Drawing.Size(85, 13)
            Me.lblALM_ID_LLEGADA.TabIndex = 32
            Me.lblALM_ID_LLEGADA.Text = "Almacén llegada"
            '
            'txtALM_ID_LLEGADA
            '
            Me.txtALM_ID_LLEGADA.Location = New System.Drawing.Point(94, 96)
            Me.txtALM_ID_LLEGADA.Name = "txtALM_ID_LLEGADA"
            Me.txtALM_ID_LLEGADA.Size = New System.Drawing.Size(47, 20)
            Me.txtALM_ID_LLEGADA.TabIndex = 30
            '
            'txtALM_DESCRIPCION
            '
            Me.txtALM_DESCRIPCION.Enabled = False
            Me.txtALM_DESCRIPCION.Location = New System.Drawing.Point(147, 43)
            Me.txtALM_DESCRIPCION.Name = "txtALM_DESCRIPCION"
            Me.txtALM_DESCRIPCION.ReadOnly = True
            Me.txtALM_DESCRIPCION.Size = New System.Drawing.Size(463, 20)
            Me.txtALM_DESCRIPCION.TabIndex = 28
            '
            'lblALM_ID
            '
            Me.lblALM_ID.AutoSize = True
            Me.lblALM_ID.Location = New System.Drawing.Point(5, 43)
            Me.lblALM_ID.Name = "lblALM_ID"
            Me.lblALM_ID.Size = New System.Drawing.Size(78, 13)
            Me.lblALM_ID.TabIndex = 29
            Me.lblALM_ID.Text = "Almacén salida"
            '
            'txtALM_ID
            '
            Me.txtALM_ID.Location = New System.Drawing.Point(94, 43)
            Me.txtALM_ID.Name = "txtALM_ID"
            Me.txtALM_ID.Size = New System.Drawing.Size(47, 20)
            Me.txtALM_ID.TabIndex = 27
            '
            'chkResumenDetalle
            '
            Me.chkResumenDetalle.AutoSize = True
            Me.chkResumenDetalle.Checked = True
            Me.chkResumenDetalle.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkResumenDetalle.Location = New System.Drawing.Point(94, 123)
            Me.chkResumenDetalle.Name = "chkResumenDetalle"
            Me.chkResumenDetalle.Size = New System.Drawing.Size(71, 17)
            Me.chkResumenDetalle.TabIndex = 26
            Me.chkResumenDetalle.Text = "Resumen"
            Me.chkResumenDetalle.UseVisualStyleBackColor = True
            Me.chkResumenDetalle.Visible = False
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(168, 96)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(442, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 9
            '
            'txtPER_DESCRIPCION_CLI
            '
            Me.txtPER_DESCRIPCION_CLI.Enabled = False
            Me.txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(168, 96)
            Me.txtPER_DESCRIPCION_CLI.Name = "txtPER_DESCRIPCION_CLI"
            Me.txtPER_DESCRIPCION_CLI.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLI.Size = New System.Drawing.Size(442, 20)
            Me.txtPER_DESCRIPCION_CLI.TabIndex = 24
            '
            'chkTodosDocumentos
            '
            Me.chkTodosDocumentos.AutoSize = True
            Me.chkTodosDocumentos.Location = New System.Drawing.Point(322, 123)
            Me.chkTodosDocumentos.Name = "chkTodosDocumentos"
            Me.chkTodosDocumentos.Size = New System.Drawing.Size(133, 17)
            Me.chkTodosDocumentos.TabIndex = 12
            Me.chkTodosDocumentos.Text = "Todos los documentos"
            Me.chkTodosDocumentos.UseVisualStyleBackColor = True
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(94, 96)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID.TabIndex = 8
            '
            'txtPER_ID_CLI
            '
            Me.txtPER_ID_CLI.Location = New System.Drawing.Point(94, 96)
            Me.txtPER_ID_CLI.Name = "txtPER_ID_CLI"
            Me.txtPER_ID_CLI.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID_CLI.TabIndex = 23
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(147, 43)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(26, 20)
            Me.txtTDO_ID.TabIndex = 4
            Me.txtTDO_ID.Visible = False
            '
            'txtNumero
            '
            Me.txtNumero.Enabled = False
            Me.txtNumero.Location = New System.Drawing.Point(137, 123)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(179, 20)
            Me.txtNumero.TabIndex = 11
            Me.txtNumero.Text = "...................."
            '
            'lblDOCUMENTO
            '
            Me.lblDOCUMENTO.AutoSize = True
            Me.lblDOCUMENTO.Location = New System.Drawing.Point(5, 123)
            Me.lblDOCUMENTO.Name = "lblDOCUMENTO"
            Me.lblDOCUMENTO.Size = New System.Drawing.Size(62, 13)
            Me.lblDOCUMENTO.TabIndex = 20
            Me.lblDOCUMENTO.Text = "Documento"
            '
            'txtSerie
            '
            Me.txtSerie.Enabled = False
            Me.txtSerie.Location = New System.Drawing.Point(95, 123)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(36, 20)
            Me.txtSerie.TabIndex = 10
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(147, 43)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(463, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 5
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(6, 43)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(84, 13)
            Me.lblDTD_ID.TabIndex = 17
            Me.lblDTD_ID.Text = "Tipo documento"
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Location = New System.Drawing.Point(94, 43)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 3
            '
            'txtTIP_DESCRIPCION
            '
            Me.txtTIP_DESCRIPCION.Enabled = False
            Me.txtTIP_DESCRIPCION.Location = New System.Drawing.Point(147, 17)
            Me.txtTIP_DESCRIPCION.Name = "txtTIP_DESCRIPCION"
            Me.txtTIP_DESCRIPCION.ReadOnly = True
            Me.txtTIP_DESCRIPCION.Size = New System.Drawing.Size(463, 20)
            Me.txtTIP_DESCRIPCION.TabIndex = 2
            '
            'lblTIP_ID
            '
            Me.lblTIP_ID.AutoSize = True
            Me.lblTIP_ID.Location = New System.Drawing.Point(5, 17)
            Me.lblTIP_ID.Name = "lblTIP_ID"
            Me.lblTIP_ID.Size = New System.Drawing.Size(67, 13)
            Me.lblTIP_ID.TabIndex = 16
            Me.lblTIP_ID.Text = "Tipo artículo"
            '
            'txtTIP_ID
            '
            Me.txtTIP_ID.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtTIP_ID.Location = New System.Drawing.Point(94, 17)
            Me.txtTIP_ID.Name = "txtTIP_ID"
            Me.txtTIP_ID.Size = New System.Drawing.Size(47, 20)
            Me.txtTIP_ID.TabIndex = 1
            '
            'chkFiltrarXFechas
            '
            Me.chkFiltrarXFechas.AutoSize = True
            Me.chkFiltrarXFechas.Enabled = False
            Me.chkFiltrarXFechas.Location = New System.Drawing.Point(449, 150)
            Me.chkFiltrarXFechas.Name = "chkFiltrarXFechas"
            Me.chkFiltrarXFechas.Size = New System.Drawing.Size(104, 17)
            Me.chkFiltrarXFechas.TabIndex = 15
            Me.chkFiltrarXFechas.Text = "Filtrar por fechas"
            Me.chkFiltrarXFechas.UseVisualStyleBackColor = True
            Me.chkFiltrarXFechas.Visible = False
            '
            'dtpFechaFinal
            '
            Me.dtpFechaFinal.Enabled = False
            Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinal.Location = New System.Drawing.Point(322, 150)
            Me.dtpFechaFinal.Name = "dtpFechaFinal"
            Me.dtpFechaFinal.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinal.TabIndex = 14
            Me.dtpFechaFinal.Visible = False
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(94, 238)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(84, 35)
            Me.btnImprimir.TabIndex = 17
            Me.btnImprimir.Text = "Generar"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'lblFechaInicial
            '
            Me.lblFechaInicial.AutoSize = True
            Me.lblFechaInicial.Location = New System.Drawing.Point(5, 150)
            Me.lblFechaInicial.Name = "lblFechaInicial"
            Me.lblFechaInicial.Size = New System.Drawing.Size(66, 13)
            Me.lblFechaInicial.TabIndex = 21
            Me.lblFechaInicial.Text = "Fecha inicial"
            Me.lblFechaInicial.Visible = False
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(5, 69)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblCCT_ID.TabIndex = 18
            Me.lblCCT_ID.Text = "Cta. Cte."
            '
            'lblFechaFinal
            '
            Me.lblFechaFinal.AutoSize = True
            Me.lblFechaFinal.Location = New System.Drawing.Point(257, 150)
            Me.lblFechaFinal.Name = "lblFechaFinal"
            Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
            Me.lblFechaFinal.TabIndex = 22
            Me.lblFechaFinal.Text = "Fecha final"
            Me.lblFechaFinal.Visible = False
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(6, 96)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID.TabIndex = 19
            Me.lblPER_ID.Text = "Persona"
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(147, 69)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(463, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 7
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Location = New System.Drawing.Point(94, 69)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.Size = New System.Drawing.Size(47, 20)
            Me.txtCCT_ID.TabIndex = 6
            '
            'tsbAgregar
            '
            Me.tsbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAgregar.Image = Global.My.Resources.Resources.Agregar
            Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAgregar.Name = "tsbAgregar"
            Me.tsbAgregar.Size = New System.Drawing.Size(23, 22)
            Me.tsbAgregar.Text = "AgregarFilaGrid"
            Me.tsbAgregar.ToolTipText = "Agregar fila a la grilla"
            '
            'tsbQuitar
            '
            Me.tsbQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbQuitar.Image = Global.My.Resources.Resources.Quitar
            Me.tsbQuitar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbQuitar.Name = "tsbQuitar"
            Me.tsbQuitar.Size = New System.Drawing.Size(23, 22)
            Me.tsbQuitar.Text = "QuitarFilaGrid"
            Me.tsbQuitar.ToolTipText = "Quitar fila de la grilla"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'tsbSalir
            '
            Me.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalir.Image = Global.My.Resources.Resources.Salir
            Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalir.Name = "tsbSalir"
            Me.tsbSalir.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalir.Text = "Salir"
            Me.tsbSalir.ToolTipText = "Salir del formulario"
            '
            'ToolStripSeparator7
            '
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
            '
            'tscPosicion
            '
            Me.tscPosicion.AutoSize = False
            Me.tscPosicion.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.tscPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.tscPosicion.DropDownWidth = 60
            Me.tscPosicion.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tscPosicion.ForeColor = System.Drawing.SystemColors.WindowText
            Me.tscPosicion.Items.AddRange(New Object() {"^", "V", ">", "<"})
            Me.tscPosicion.Name = "tscPosicion"
            Me.tscPosicion.Size = New System.Drawing.Size(30, 18)
            Me.tscPosicion.ToolTipText = "Posición de la barra en la pantalla"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(613, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 23
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'BackgroundWorker1
            '
            Me.BackgroundWorker1.WorkerReportsProgress = True
            '
            'btnImprimirValorizadoSinComercializadora
            '
            Me.btnImprimirValorizadoSinComercializadora.Enabled = False
            Me.btnImprimirValorizadoSinComercializadora.Location = New System.Drawing.Point(294, 238)
            Me.btnImprimirValorizadoSinComercializadora.Name = "btnImprimirValorizadoSinComercializadora"
            Me.btnImprimirValorizadoSinComercializadora.Size = New System.Drawing.Size(96, 35)
            Me.btnImprimirValorizadoSinComercializadora.TabIndex = 57
            Me.btnImprimirValorizadoSinComercializadora.Text = "Valorizado sin comercializadora"
            Me.btnImprimirValorizadoSinComercializadora.UseVisualStyleBackColor = True
            Me.btnImprimirValorizadoSinComercializadora.Visible = False
            '
            'frmKardexDocumento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(687, 339)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmKardexDocumento"
            Me.Text = "Kardex de documento"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.pnFormato.ResumeLayout(False)
            Me.pnFormato.PerformLayout()
            Me.pnTipoResumenReporte.ResumeLayout(False)
            Me.pnTipoResumenReporte.PerformLayout()
            Me.pnTipoReporteGuias.ResumeLayout(False)
            Me.pnTipoReporteGuias.PerformLayout()
            CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblFechaInicial As System.Windows.Forms.Label
        Friend WithEvents lblCCT_ID As System.Windows.Forms.Label
        Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents txtCCT_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtCCT_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents chkFiltrarXFechas As System.Windows.Forms.CheckBox
        Friend WithEvents lblDOCUMENTO As System.Windows.Forms.Label
        Public WithEvents txtSerie As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTIP_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblTIP_ID As System.Windows.Forms.Label
        Public WithEvents txtTIP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtNumero As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_CLI As System.Windows.Forms.TextBox
        Friend WithEvents chkTodosDocumentos As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Friend WithEvents chkResumenDetalle As System.Windows.Forms.CheckBox
        Public WithEvents txtALM_DESCRIPCION_LLEGADA As System.Windows.Forms.TextBox
        Friend WithEvents lblALM_ID_LLEGADA As System.Windows.Forms.Label
        Public WithEvents txtALM_ID_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtALM_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblALM_ID As System.Windows.Forms.Label
        Public WithEvents txtALM_ID As System.Windows.Forms.TextBox
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents chkMostrarSaldoCero As System.Windows.Forms.CheckBox
        Friend WithEvents chkMostrarDirecciones As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents rbPendientesAtencionCliente As System.Windows.Forms.RadioButton
        Friend WithEvents rbPendientesAtencion As System.Windows.Forms.RadioButton
        Friend WithEvents rbPendientesAtencionVendedor As System.Windows.Forms.RadioButton
        Friend WithEvents txtprogreso As System.Windows.Forms.TextBox
        Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
        Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
        Friend WithEvents btnIniciar As System.Windows.Forms.Button
        Friend WithEvents lblEstado As System.Windows.Forms.Label
        Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
        Friend WithEvents chkMostrarValorizado As System.Windows.Forms.CheckBox
        Friend WithEvents chkFormato As System.Windows.Forms.CheckBox
        Friend WithEvents pnTipoReporteGuias As System.Windows.Forms.Panel
        Friend WithEvents rbGuias As System.Windows.Forms.RadioButton
        Friend WithEvents rbGuiasPorArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents pnTipoResumenReporte As System.Windows.Forms.Panel
        Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
        Friend WithEvents chkAnuladas As System.Windows.Forms.CheckBox
        Friend WithEvents pnFormato As System.Windows.Forms.Panel
        Friend WithEvents rbFormato3 As System.Windows.Forms.RadioButton
        Friend WithEvents rbFormato2 As System.Windows.Forms.RadioButton
        Friend WithEvents rbFormato1 As System.Windows.Forms.RadioButton
        Friend WithEvents rbPendientesAtencionVendedorXArtículo As System.Windows.Forms.RadioButton
        Friend WithEvents btnImprimirValorizado As System.Windows.Forms.Button
        Friend WithEvents btnImprimirValorizadoSinComercializadora As System.Windows.Forms.Button
    End Class
End Namespace