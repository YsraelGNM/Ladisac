Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmKardexCtaCte
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
            Me.lblDatosPersona = New System.Windows.Forms.Label()
            Me.chkDatosPersona = New System.Windows.Forms.CheckBox()
            Me.chkPorPeriodo = New System.Windows.Forms.CheckBox()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.lblPeriodo = New System.Windows.Forms.Label()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.rbFormato5 = New System.Windows.Forms.RadioButton()
            Me.rbFormato4 = New System.Windows.Forms.RadioButton()
            Me.rbFormato1 = New System.Windows.Forms.RadioButton()
            Me.rbFormato3 = New System.Windows.Forms.RadioButton()
            Me.rbFormato2 = New System.Windows.Forms.RadioButton()
            Me.lblSoloTrabajadores = New System.Windows.Forms.Label()
            Me.lblMostrarAnticipos = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
            Me.lblFechaFinal = New System.Windows.Forms.Label()
            Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
            Me.chkFiltrarXFechas = New System.Windows.Forms.CheckBox()
            Me.lblTipoReporte = New System.Windows.Forms.Label()
            Me.lblTipoFormato = New System.Windows.Forms.Label()
            Me.pnTipoReporte = New System.Windows.Forms.Panel()
            Me.chkResumenDetalle = New System.Windows.Forms.CheckBox()
            Me.chkMostrarSaldoCero = New System.Windows.Forms.CheckBox()
            Me.chkFiltrarPorVendedor = New System.Windows.Forms.CheckBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.chkSoloTrabajadores = New System.Windows.Forms.CheckBox()
            Me.chkMostrarAnticipos = New System.Windows.Forms.CheckBox()
            Me.lblDocumento = New System.Windows.Forms.Label()
            Me.txtDocumento = New System.Windows.Forms.TextBox()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblFechaInicial = New System.Windows.Forms.Label()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtCCT_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtCCT_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.chkDetalleResCon = New System.Windows.Forms.CheckBox()
            Me.pnCuerpo.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.pnTipoReporte.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(773, 28)
            Me.lblTitle.Text = "Kardex de cta. cte. de la persona"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDatosPersona)
            Me.pnCuerpo.Controls.Add(Me.chkDatosPersona)
            Me.pnCuerpo.Controls.Add(Me.chkPorPeriodo)
            Me.pnCuerpo.Controls.Add(Me.txtPeriodo)
            Me.pnCuerpo.Controls.Add(Me.lblPeriodo)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.Panel2)
            Me.pnCuerpo.Controls.Add(Me.lblSoloTrabajadores)
            Me.pnCuerpo.Controls.Add(Me.lblMostrarAnticipos)
            Me.pnCuerpo.Controls.Add(Me.Panel1)
            Me.pnCuerpo.Controls.Add(Me.lblTipoReporte)
            Me.pnCuerpo.Controls.Add(Me.lblTipoFormato)
            Me.pnCuerpo.Controls.Add(Me.pnTipoReporte)
            Me.pnCuerpo.Controls.Add(Me.txtSerie)
            Me.pnCuerpo.Controls.Add(Me.chkSoloTrabajadores)
            Me.pnCuerpo.Controls.Add(Me.chkMostrarAnticipos)
            Me.pnCuerpo.Controls.Add(Me.lblDocumento)
            Me.pnCuerpo.Controls.Add(Me.txtDocumento)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(717, 291)
            Me.pnCuerpo.TabIndex = 119
            '
            'lblDatosPersona
            '
            Me.lblDatosPersona.AutoSize = True
            Me.lblDatosPersona.Location = New System.Drawing.Point(338, 101)
            Me.lblDatosPersona.Name = "lblDatosPersona"
            Me.lblDatosPersona.Size = New System.Drawing.Size(45, 13)
            Me.lblDatosPersona.TabIndex = 51
            Me.lblDatosPersona.Text = "Mostrar:"
            '
            'chkDatosPersona
            '
            Me.chkDatosPersona.AutoSize = True
            Me.chkDatosPersona.Location = New System.Drawing.Point(405, 101)
            Me.chkDatosPersona.Name = "chkDatosPersona"
            Me.chkDatosPersona.Size = New System.Drawing.Size(130, 17)
            Me.chkDatosPersona.TabIndex = 10
            Me.chkDatosPersona.Text = "Nombre de la persona"
            Me.chkDatosPersona.UseVisualStyleBackColor = True
            '
            'chkPorPeriodo
            '
            Me.chkPorPeriodo.AutoSize = True
            Me.chkPorPeriodo.Location = New System.Drawing.Point(177, 101)
            Me.chkPorPeriodo.Name = "chkPorPeriodo"
            Me.chkPorPeriodo.Size = New System.Drawing.Size(107, 17)
            Me.chkPorPeriodo.TabIndex = 9
            Me.chkPorPeriodo.Text = "Filtrar por periodo"
            Me.chkPorPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(103, 101)
            Me.txtPeriodo.MaxLength = 6
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.Size = New System.Drawing.Size(68, 20)
            Me.txtPeriodo.TabIndex = 8
            '
            'lblPeriodo
            '
            Me.lblPeriodo.AutoSize = True
            Me.lblPeriodo.Location = New System.Drawing.Point(7, 101)
            Me.lblPeriodo.Name = "lblPeriodo"
            Me.lblPeriodo.Size = New System.Drawing.Size(46, 13)
            Me.lblPeriodo.TabIndex = 47
            Me.lblPeriodo.Text = "Periodo:"
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(7, 52)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(64, 13)
            Me.lblDTD_ID.TabIndex = 45
            Me.lblDTD_ID.Text = "Movimiento:"
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(145, 52)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(552, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 5
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Location = New System.Drawing.Point(103, 52)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 4
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.Add(Me.chkDetalleResCon)
            Me.Panel2.Controls.Add(Me.rbFormato5)
            Me.Panel2.Controls.Add(Me.rbFormato4)
            Me.Panel2.Controls.Add(Me.rbFormato1)
            Me.Panel2.Controls.Add(Me.rbFormato3)
            Me.Panel2.Controls.Add(Me.rbFormato2)
            Me.Panel2.Location = New System.Drawing.Point(104, 160)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(593, 25)
            Me.Panel2.TabIndex = 42
            '
            'rbFormato5
            '
            Me.rbFormato5.AutoSize = True
            Me.rbFormato5.Location = New System.Drawing.Point(154, 3)
            Me.rbFormato5.Name = "rbFormato5"
            Me.rbFormato5.Size = New System.Drawing.Size(108, 17)
            Me.rbFormato5.TabIndex = 16
            Me.rbFormato5.TabStop = True
            Me.rbFormato5.Text = "Res. Contabilidad"
            Me.rbFormato5.UseVisualStyleBackColor = True
            '
            'rbFormato4
            '
            Me.rbFormato4.AutoSize = True
            Me.rbFormato4.Location = New System.Drawing.Point(474, 3)
            Me.rbFormato4.Name = "rbFormato4"
            Me.rbFormato4.Size = New System.Drawing.Size(109, 17)
            Me.rbFormato4.TabIndex = 18
            Me.rbFormato4.TabStop = True
            Me.rbFormato4.Text = "Resumen sin total"
            Me.rbFormato4.UseVisualStyleBackColor = True
            '
            'rbFormato1
            '
            Me.rbFormato1.AutoSize = True
            Me.rbFormato1.Checked = True
            Me.rbFormato1.Location = New System.Drawing.Point(3, 3)
            Me.rbFormato1.Name = "rbFormato1"
            Me.rbFormato1.Size = New System.Drawing.Size(59, 17)
            Me.rbFormato1.TabIndex = 14
            Me.rbFormato1.TabStop = True
            Me.rbFormato1.Text = "Listado"
            Me.rbFormato1.UseVisualStyleBackColor = True
            '
            'rbFormato3
            '
            Me.rbFormato3.AutoSize = True
            Me.rbFormato3.Location = New System.Drawing.Point(321, 3)
            Me.rbFormato3.Name = "rbFormato3"
            Me.rbFormato3.Size = New System.Drawing.Size(138, 17)
            Me.rbFormato3.TabIndex = 17
            Me.rbFormato3.TabStop = True
            Me.rbFormato3.Text = "Resumen moneda soles"
            Me.rbFormato3.UseVisualStyleBackColor = True
            '
            'rbFormato2
            '
            Me.rbFormato2.AutoSize = True
            Me.rbFormato2.Location = New System.Drawing.Point(71, 3)
            Me.rbFormato2.Name = "rbFormato2"
            Me.rbFormato2.Size = New System.Drawing.Size(70, 17)
            Me.rbFormato2.TabIndex = 15
            Me.rbFormato2.TabStop = True
            Me.rbFormato2.Text = "Resumen"
            Me.rbFormato2.UseVisualStyleBackColor = True
            '
            'lblSoloTrabajadores
            '
            Me.lblSoloTrabajadores.AutoSize = True
            Me.lblSoloTrabajadores.Location = New System.Drawing.Point(7, 221)
            Me.lblSoloTrabajadores.Name = "lblSoloTrabajadores"
            Me.lblSoloTrabajadores.Size = New System.Drawing.Size(49, 13)
            Me.lblSoloTrabajadores.TabIndex = 38
            Me.lblSoloTrabajadores.Text = "Persona:"
            '
            'lblMostrarAnticipos
            '
            Me.lblMostrarAnticipos.AutoSize = True
            Me.lblMostrarAnticipos.Location = New System.Drawing.Point(7, 191)
            Me.lblMostrarAnticipos.Name = "lblMostrarAnticipos"
            Me.lblMostrarAnticipos.Size = New System.Drawing.Size(76, 13)
            Me.lblMostrarAnticipos.TabIndex = 37
            Me.lblMostrarAnticipos.Text = "Solo anticipos:"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.Add(Me.dtpFechaFinal)
            Me.Panel1.Controls.Add(Me.lblFechaFinal)
            Me.Panel1.Controls.Add(Me.dtpFechaInicial)
            Me.Panel1.Controls.Add(Me.chkFiltrarXFechas)
            Me.Panel1.Location = New System.Drawing.Point(103, 125)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(594, 30)
            Me.Panel1.TabIndex = 36
            '
            'dtpFechaFinal
            '
            Me.dtpFechaFinal.Enabled = False
            Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinal.Location = New System.Drawing.Point(300, 5)
            Me.dtpFechaFinal.Name = "dtpFechaFinal"
            Me.dtpFechaFinal.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinal.TabIndex = 12
            '
            'lblFechaFinal
            '
            Me.lblFechaFinal.AutoSize = True
            Me.lblFechaFinal.Location = New System.Drawing.Point(233, 5)
            Me.lblFechaFinal.Name = "lblFechaFinal"
            Me.lblFechaFinal.Size = New System.Drawing.Size(62, 13)
            Me.lblFechaFinal.TabIndex = 23
            Me.lblFechaFinal.Text = "Fecha final:"
            '
            'dtpFechaInicial
            '
            Me.dtpFechaInicial.Enabled = False
            Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicial.Location = New System.Drawing.Point(6, 5)
            Me.dtpFechaInicial.Name = "dtpFechaInicial"
            Me.dtpFechaInicial.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicial.TabIndex = 11
            Me.dtpFechaInicial.Value = New Date(2015, 3, 27, 0, 0, 0, 0)
            '
            'chkFiltrarXFechas
            '
            Me.chkFiltrarXFechas.AutoSize = True
            Me.chkFiltrarXFechas.Location = New System.Drawing.Point(473, 5)
            Me.chkFiltrarXFechas.Name = "chkFiltrarXFechas"
            Me.chkFiltrarXFechas.Size = New System.Drawing.Size(104, 17)
            Me.chkFiltrarXFechas.TabIndex = 13
            Me.chkFiltrarXFechas.Text = "Filtrar por fechas"
            Me.chkFiltrarXFechas.UseVisualStyleBackColor = True
            '
            'lblTipoReporte
            '
            Me.lblTipoReporte.AutoSize = True
            Me.lblTipoReporte.Location = New System.Drawing.Point(338, 191)
            Me.lblTipoReporte.Name = "lblTipoReporte"
            Me.lblTipoReporte.Size = New System.Drawing.Size(67, 13)
            Me.lblTipoReporte.TabIndex = 35
            Me.lblTipoReporte.Text = "Tipo reporte:"
            '
            'lblTipoFormato
            '
            Me.lblTipoFormato.AutoSize = True
            Me.lblTipoFormato.Location = New System.Drawing.Point(7, 166)
            Me.lblTipoFormato.Name = "lblTipoFormato"
            Me.lblTipoFormato.Size = New System.Drawing.Size(93, 13)
            Me.lblTipoFormato.TabIndex = 34
            Me.lblTipoFormato.Text = "Form. Kardex rep.:"
            '
            'pnTipoReporte
            '
            Me.pnTipoReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnTipoReporte.Controls.Add(Me.chkResumenDetalle)
            Me.pnTipoReporte.Controls.Add(Me.chkMostrarSaldoCero)
            Me.pnTipoReporte.Controls.Add(Me.chkFiltrarPorVendedor)
            Me.pnTipoReporte.Location = New System.Drawing.Point(441, 191)
            Me.pnTipoReporte.Name = "pnTipoReporte"
            Me.pnTipoReporte.Size = New System.Drawing.Size(257, 72)
            Me.pnTipoReporte.TabIndex = 21
            '
            'chkResumenDetalle
            '
            Me.chkResumenDetalle.AutoSize = True
            Me.chkResumenDetalle.Location = New System.Drawing.Point(6, 10)
            Me.chkResumenDetalle.Name = "chkResumenDetalle"
            Me.chkResumenDetalle.Size = New System.Drawing.Size(153, 17)
            Me.chkResumenDetalle.TabIndex = 13
            Me.chkResumenDetalle.Text = "Mostrar resumen de detalle"
            Me.chkResumenDetalle.UseVisualStyleBackColor = True
            '
            'chkMostrarSaldoCero
            '
            Me.chkMostrarSaldoCero.AutoSize = True
            Me.chkMostrarSaldoCero.Location = New System.Drawing.Point(6, 28)
            Me.chkMostrarSaldoCero.Name = "chkMostrarSaldoCero"
            Me.chkMostrarSaldoCero.Size = New System.Drawing.Size(193, 17)
            Me.chkMostrarSaldoCero.TabIndex = 14
            Me.chkMostrarSaldoCero.Text = "Mostrar documentos solo con saldo"
            Me.chkMostrarSaldoCero.UseVisualStyleBackColor = True
            '
            'chkFiltrarPorVendedor
            '
            Me.chkFiltrarPorVendedor.AutoSize = True
            Me.chkFiltrarPorVendedor.Location = New System.Drawing.Point(6, 47)
            Me.chkFiltrarPorVendedor.Name = "chkFiltrarPorVendedor"
            Me.chkFiltrarPorVendedor.Size = New System.Drawing.Size(142, 17)
            Me.chkFiltrarPorVendedor.TabIndex = 15
            Me.chkFiltrarPorVendedor.Text = "Mostrar datos por cliente"
            Me.chkFiltrarPorVendedor.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(103, 76)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(36, 20)
            Me.txtSerie.TabIndex = 6
            '
            'chkSoloTrabajadores
            '
            Me.chkSoloTrabajadores.AutoSize = True
            Me.chkSoloTrabajadores.Location = New System.Drawing.Point(103, 221)
            Me.chkSoloTrabajadores.Name = "chkSoloTrabajadores"
            Me.chkSoloTrabajadores.Size = New System.Drawing.Size(108, 17)
            Me.chkSoloTrabajadores.TabIndex = 20
            Me.chkSoloTrabajadores.Text = "Solo trabajadores"
            Me.chkSoloTrabajadores.UseVisualStyleBackColor = True
            '
            'chkMostrarAnticipos
            '
            Me.chkMostrarAnticipos.AutoSize = True
            Me.chkMostrarAnticipos.Location = New System.Drawing.Point(103, 191)
            Me.chkMostrarAnticipos.Name = "chkMostrarAnticipos"
            Me.chkMostrarAnticipos.Size = New System.Drawing.Size(146, 17)
            Me.chkMostrarAnticipos.TabIndex = 19
            Me.chkMostrarAnticipos.Text = "Aplicaciones de anticipos"
            Me.chkMostrarAnticipos.UseVisualStyleBackColor = True
            '
            'lblDocumento
            '
            Me.lblDocumento.AutoSize = True
            Me.lblDocumento.Location = New System.Drawing.Point(7, 76)
            Me.lblDocumento.Name = "lblDocumento"
            Me.lblDocumento.Size = New System.Drawing.Size(62, 13)
            Me.lblDocumento.TabIndex = 32
            Me.lblDocumento.Text = "Serie/Doc.:"
            '
            'txtDocumento
            '
            Me.txtDocumento.Location = New System.Drawing.Point(145, 76)
            Me.txtDocumento.Name = "txtDocumento"
            Me.txtDocumento.Size = New System.Drawing.Size(68, 20)
            Me.txtDocumento.TabIndex = 7
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(103, 251)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(108, 33)
            Me.btnImprimir.TabIndex = 22
            Me.btnImprimir.Text = "Generar Reporte"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(177, 5)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(520, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 1
            '
            'lblFechaInicial
            '
            Me.lblFechaInicial.AutoSize = True
            Me.lblFechaInicial.Location = New System.Drawing.Point(7, 132)
            Me.lblFechaInicial.Name = "lblFechaInicial"
            Me.lblFechaInicial.Size = New System.Drawing.Size(69, 13)
            Me.lblFechaInicial.TabIndex = 30
            Me.lblFechaInicial.Text = "Fecha inicial:"
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(7, 28)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(51, 13)
            Me.lblCCT_ID.TabIndex = 25
            Me.lblCCT_ID.Text = "Cta. Cte.:"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(7, 5)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(49, 13)
            Me.lblPER_ID.TabIndex = 22
            Me.lblPER_ID.Text = "Persona:"
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(145, 28)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(552, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 3
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Location = New System.Drawing.Point(103, 28)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtCCT_ID.TabIndex = 2
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(103, 5)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID.TabIndex = 0
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
            Me.btnImagen.Location = New System.Drawing.Point(625, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 120
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'chkDetalleResCon
            '
            Me.chkDetalleResCon.AutoSize = True
            Me.chkDetalleResCon.Location = New System.Drawing.Point(260, 4)
            Me.chkDetalleResCon.Name = "chkDetalleResCon"
            Me.chkDetalleResCon.Size = New System.Drawing.Size(46, 17)
            Me.chkDetalleResCon.TabIndex = 52
            Me.chkDetalleResCon.Text = "Det."
            Me.chkDetalleResCon.UseVisualStyleBackColor = True
            '
            'frmKardexCtaCte
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(773, 350)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmKardexCtaCte"
            Me.Text = "Kardex de cta. cte. de la persona"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.pnTipoReporte.ResumeLayout(False)
            Me.pnTipoReporte.PerformLayout()
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
        Friend WithEvents chkResumenDetalle As System.Windows.Forms.CheckBox
        Friend WithEvents chkMostrarSaldoCero As System.Windows.Forms.CheckBox
        Friend WithEvents chkFiltrarPorVendedor As System.Windows.Forms.CheckBox
        Friend WithEvents lblDocumento As System.Windows.Forms.Label
        Public WithEvents txtDocumento As System.Windows.Forms.TextBox
        Friend WithEvents chkMostrarAnticipos As System.Windows.Forms.CheckBox
        Friend WithEvents chkSoloTrabajadores As System.Windows.Forms.CheckBox
        Public WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents pnTipoReporte As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblTipoReporte As System.Windows.Forms.Label
        Friend WithEvents lblTipoFormato As System.Windows.Forms.Label
        Friend WithEvents lblSoloTrabajadores As System.Windows.Forms.Label
        Friend WithEvents lblMostrarAnticipos As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents rbFormato1 As System.Windows.Forms.RadioButton
        Friend WithEvents rbFormato3 As System.Windows.Forms.RadioButton
        Friend WithEvents rbFormato2 As System.Windows.Forms.RadioButton
        Friend WithEvents rbFormato4 As System.Windows.Forms.RadioButton
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Friend WithEvents rbFormato5 As System.Windows.Forms.RadioButton
        Friend WithEvents chkPorPeriodo As System.Windows.Forms.CheckBox
        Public WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents lblPeriodo As System.Windows.Forms.Label
        Friend WithEvents lblDatosPersona As System.Windows.Forms.Label
        Friend WithEvents chkDatosPersona As System.Windows.Forms.CheckBox
        Friend WithEvents chkDetalleResCon As System.Windows.Forms.CheckBox
    End Class
End Namespace