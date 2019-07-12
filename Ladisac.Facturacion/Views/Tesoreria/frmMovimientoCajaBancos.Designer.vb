Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMovimientoCajaBancos
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
            Me.chkFechaHora = New System.Windows.Forms.CheckBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtCCC_TIPO = New System.Windows.Forms.TextBox()
            Me.lblCCC_TIPO = New System.Windows.Forms.Label()
            Me.cboCCC_TIPO = New System.Windows.Forms.ComboBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.pnMovimientos = New System.Windows.Forms.Panel()
            Me.rbSoloIngresos = New System.Windows.Forms.RadioButton()
            Me.rbTodosMovimientos = New System.Windows.Forms.RadioButton()
            Me.pnTipoReporte = New System.Windows.Forms.Panel()
            Me.rbDetallado = New System.Windows.Forms.RadioButton()
            Me.rbResumen = New System.Windows.Forms.RadioButton()
            Me.txtMON_SIMBOLO = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.txtCCC_CUENTA_BANCARIA = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_BAN = New System.Windows.Forms.TextBox()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.txtCCC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtCCC_ID = New System.Windows.Forms.TextBox()
            Me.chkFiltrarXFechas = New System.Windows.Forms.CheckBox()
            Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblFechaInicial = New System.Windows.Forms.Label()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.lblFechaFinal = New System.Windows.Forms.Label()
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
            Me.rbSoloEgresos = New System.Windows.Forms.RadioButton()
            Me.pnCuerpo.SuspendLayout()
            Me.pnMovimientos.SuspendLayout()
            Me.pnTipoReporte.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblTitle.Size = New System.Drawing.Size(680, 28)
            Me.lblTitle.Text = "Movimiento caja/bancos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.chkFechaHora)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.cboCCC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.pnMovimientos)
            Me.pnCuerpo.Controls.Add(Me.pnTipoReporte)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_CUENTA_BANCARIA)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_BAN)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.chkFiltrarXFechas)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.lblFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(26, 28)
            Me.pnCuerpo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(624, 284)
            Me.pnCuerpo.TabIndex = 119
            '
            'chkFechaHora
            '
            Me.chkFechaHora.AutoSize = True
            Me.chkFechaHora.Checked = True
            Me.chkFechaHora.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkFechaHora.Enabled = False
            Me.chkFechaHora.Location = New System.Drawing.Point(80, 223)
            Me.chkFechaHora.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.chkFechaHora.Name = "chkFechaHora"
            Me.chkFechaHora.Size = New System.Drawing.Size(188, 17)
            Me.chkFechaHora.TabIndex = 39
            Me.chkFechaHora.Text = "Mostrar fecha y hora de grabación"
            Me.chkFechaHora.UseVisualStyleBackColor = True
            Me.chkFechaHora.Visible = False
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Enabled = False
            Me.txtPVE_ID.Location = New System.Drawing.Point(536, 32)
            Me.txtPVE_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.ReadOnly = True
            Me.txtPVE_ID.Size = New System.Drawing.Size(70, 20)
            Me.txtPVE_ID.TabIndex = 38
            Me.txtPVE_ID.Visible = False
            '
            'txtCCC_TIPO
            '
            Me.txtCCC_TIPO.Enabled = False
            Me.txtCCC_TIPO.Location = New System.Drawing.Point(442, 32)
            Me.txtCCC_TIPO.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCC_TIPO.Name = "txtCCC_TIPO"
            Me.txtCCC_TIPO.ReadOnly = True
            Me.txtCCC_TIPO.Size = New System.Drawing.Size(164, 20)
            Me.txtCCC_TIPO.TabIndex = 5
            '
            'lblCCC_TIPO
            '
            Me.lblCCC_TIPO.AutoSize = True
            Me.lblCCC_TIPO.Location = New System.Drawing.Point(7, 32)
            Me.lblCCC_TIPO.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblCCC_TIPO.Name = "lblCCC_TIPO"
            Me.lblCCC_TIPO.Size = New System.Drawing.Size(52, 13)
            Me.lblCCC_TIPO.TabIndex = 37
            Me.lblCCC_TIPO.Text = "Tipo Caja"
            '
            'cboCCC_TIPO
            '
            Me.cboCCC_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCCC_TIPO.FormattingEnabled = True
            Me.cboCCC_TIPO.Items.AddRange(New Object() {"CUENTA DE BANCO", "CAJA", "TODAS"})
            Me.cboCCC_TIPO.Location = New System.Drawing.Point(80, 32)
            Me.cboCCC_TIPO.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.cboCCC_TIPO.Name = "cboCCC_TIPO"
            Me.cboCCC_TIPO.Size = New System.Drawing.Size(138, 21)
            Me.cboCCC_TIPO.TabIndex = 6
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(7, 110)
            Me.lblDTD_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblDTD_ID.TabIndex = 35
            Me.lblDTD_ID.Text = "Tipo Doc."
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(122, 110)
            Me.txtDTD_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 13
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Location = New System.Drawing.Point(80, 110)
            Me.txtDTD_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 12
            '
            'pnMovimientos
            '
            Me.pnMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnMovimientos.Controls.Add(Me.rbSoloEgresos)
            Me.pnMovimientos.Controls.Add(Me.rbSoloIngresos)
            Me.pnMovimientos.Controls.Add(Me.rbTodosMovimientos)
            Me.pnMovimientos.Location = New System.Drawing.Point(260, 185)
            Me.pnMovimientos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.pnMovimientos.Name = "pnMovimientos"
            Me.pnMovimientos.Size = New System.Drawing.Size(345, 35)
            Me.pnMovimientos.TabIndex = 18
            '
            'rbSoloIngresos
            '
            Me.rbSoloIngresos.AutoSize = True
            Me.rbSoloIngresos.Location = New System.Drawing.Point(143, 8)
            Me.rbSoloIngresos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.rbSoloIngresos.Name = "rbSoloIngresos"
            Me.rbSoloIngresos.Size = New System.Drawing.Size(88, 17)
            Me.rbSoloIngresos.TabIndex = 22
            Me.rbSoloIngresos.Text = "Solo ingresos"
            Me.rbSoloIngresos.UseVisualStyleBackColor = True
            '
            'rbTodosMovimientos
            '
            Me.rbTodosMovimientos.AutoSize = True
            Me.rbTodosMovimientos.Checked = True
            Me.rbTodosMovimientos.Location = New System.Drawing.Point(8, 8)
            Me.rbTodosMovimientos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.rbTodosMovimientos.Name = "rbTodosMovimientos"
            Me.rbTodosMovimientos.Size = New System.Drawing.Size(132, 17)
            Me.rbTodosMovimientos.TabIndex = 21
            Me.rbTodosMovimientos.TabStop = True
            Me.rbTodosMovimientos.Text = "Todos los movimientos"
            Me.rbTodosMovimientos.UseVisualStyleBackColor = True
            '
            'pnTipoReporte
            '
            Me.pnTipoReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnTipoReporte.Controls.Add(Me.rbDetallado)
            Me.pnTipoReporte.Controls.Add(Me.rbResumen)
            Me.pnTipoReporte.Location = New System.Drawing.Point(80, 185)
            Me.pnTipoReporte.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.pnTipoReporte.Name = "pnTipoReporte"
            Me.pnTipoReporte.Size = New System.Drawing.Size(164, 35)
            Me.pnTipoReporte.TabIndex = 17
            '
            'rbDetallado
            '
            Me.rbDetallado.AutoSize = True
            Me.rbDetallado.Checked = True
            Me.rbDetallado.Location = New System.Drawing.Point(8, 8)
            Me.rbDetallado.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.rbDetallado.Name = "rbDetallado"
            Me.rbDetallado.Size = New System.Drawing.Size(70, 17)
            Me.rbDetallado.TabIndex = 19
            Me.rbDetallado.TabStop = True
            Me.rbDetallado.Text = "Detallado"
            Me.rbDetallado.UseVisualStyleBackColor = True
            '
            'rbResumen
            '
            Me.rbResumen.AutoSize = True
            Me.rbResumen.Location = New System.Drawing.Point(86, 8)
            Me.rbResumen.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.rbResumen.Name = "rbResumen"
            Me.rbResumen.Size = New System.Drawing.Size(70, 17)
            Me.rbResumen.TabIndex = 20
            Me.rbResumen.Text = "Resumen"
            Me.rbResumen.UseVisualStyleBackColor = True
            '
            'txtMON_SIMBOLO
            '
            Me.txtMON_SIMBOLO.Enabled = False
            Me.txtMON_SIMBOLO.Location = New System.Drawing.Point(122, 58)
            Me.txtMON_SIMBOLO.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtMON_SIMBOLO.Name = "txtMON_SIMBOLO"
            Me.txtMON_SIMBOLO.ReadOnly = True
            Me.txtMON_SIMBOLO.Size = New System.Drawing.Size(33, 20)
            Me.txtMON_SIMBOLO.TabIndex = 8
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(7, 58)
            Me.lblMON_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 26
            Me.lblMON_ID.Text = "Moneda"
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(161, 58)
            Me.txtMON_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(444, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 9
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Location = New System.Drawing.Point(80, 58)
            Me.txtMON_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtMON_ID.TabIndex = 7
            '
            'txtCCC_CUENTA_BANCARIA
            '
            Me.txtCCC_CUENTA_BANCARIA.Enabled = False
            Me.txtCCC_CUENTA_BANCARIA.Location = New System.Drawing.Point(224, 32)
            Me.txtCCC_CUENTA_BANCARIA.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCC_CUENTA_BANCARIA.Name = "txtCCC_CUENTA_BANCARIA"
            Me.txtCCC_CUENTA_BANCARIA.ReadOnly = True
            Me.txtCCC_CUENTA_BANCARIA.Size = New System.Drawing.Size(212, 20)
            Me.txtCCC_CUENTA_BANCARIA.TabIndex = 4
            '
            'txtPER_DESCRIPCION_BAN
            '
            Me.txtPER_DESCRIPCION_BAN.Enabled = False
            Me.txtPER_DESCRIPCION_BAN.Location = New System.Drawing.Point(10, 32)
            Me.txtPER_DESCRIPCION_BAN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtPER_DESCRIPCION_BAN.Name = "txtPER_DESCRIPCION_BAN"
            Me.txtPER_DESCRIPCION_BAN.ReadOnly = True
            Me.txtPER_DESCRIPCION_BAN.Size = New System.Drawing.Size(208, 20)
            Me.txtPER_DESCRIPCION_BAN.TabIndex = 3
            '
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(7, 6)
            Me.lblCCC_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(72, 13)
            Me.lblCCC_ID.TabIndex = 14
            Me.lblCCC_ID.Text = "Caja Cta. Cte."
            '
            'txtCCC_DESCRIPCION
            '
            Me.txtCCC_DESCRIPCION.Enabled = False
            Me.txtCCC_DESCRIPCION.Location = New System.Drawing.Point(122, 6)
            Me.txtCCC_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCC_DESCRIPCION.Name = "txtCCC_DESCRIPCION"
            Me.txtCCC_DESCRIPCION.ReadOnly = True
            Me.txtCCC_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtCCC_DESCRIPCION.TabIndex = 2
            '
            'txtCCC_ID
            '
            Me.txtCCC_ID.Location = New System.Drawing.Point(80, 6)
            Me.txtCCC_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCC_ID.Name = "txtCCC_ID"
            Me.txtCCC_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtCCC_ID.TabIndex = 1
            '
            'chkFiltrarXFechas
            '
            Me.chkFiltrarXFechas.AutoSize = True
            Me.chkFiltrarXFechas.Enabled = False
            Me.chkFiltrarXFechas.Location = New System.Drawing.Point(449, 159)
            Me.chkFiltrarXFechas.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.chkFiltrarXFechas.Name = "chkFiltrarXFechas"
            Me.chkFiltrarXFechas.Size = New System.Drawing.Size(104, 17)
            Me.chkFiltrarXFechas.TabIndex = 18
            Me.chkFiltrarXFechas.Text = "Filtrar por fechas"
            Me.chkFiltrarXFechas.UseVisualStyleBackColor = True
            Me.chkFiltrarXFechas.Visible = False
            '
            'dtpFechaFinal
            '
            Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinal.Location = New System.Drawing.Point(322, 159)
            Me.dtpFechaFinal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.dtpFechaFinal.Name = "dtpFechaFinal"
            Me.dtpFechaFinal.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinal.TabIndex = 17
            '
            'dtpFechaInicial
            '
            Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicial.Location = New System.Drawing.Point(80, 159)
            Me.dtpFechaInicial.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.dtpFechaInicial.Name = "dtpFechaInicial"
            Me.dtpFechaInicial.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicial.TabIndex = 16
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(80, 245)
            Me.btnImprimir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(74, 31)
            Me.btnImprimir.TabIndex = 23
            Me.btnImprimir.Text = "Generar"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(161, 133)
            Me.txtPER_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(445, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 15
            '
            'lblFechaInicial
            '
            Me.lblFechaInicial.AutoSize = True
            Me.lblFechaInicial.Location = New System.Drawing.Point(7, 159)
            Me.lblFechaInicial.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblFechaInicial.Name = "lblFechaInicial"
            Me.lblFechaInicial.Size = New System.Drawing.Size(66, 13)
            Me.lblFechaInicial.TabIndex = 17
            Me.lblFechaInicial.Text = "Fecha inicial"
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(7, 85)
            Me.lblCCT_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblCCT_ID.TabIndex = 15
            Me.lblCCT_ID.Text = "Cta. Cte."
            '
            'lblFechaFinal
            '
            Me.lblFechaFinal.AutoSize = True
            Me.lblFechaFinal.Location = New System.Drawing.Point(257, 159)
            Me.lblFechaFinal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblFechaFinal.Name = "lblFechaFinal"
            Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
            Me.lblFechaFinal.TabIndex = 23
            Me.lblFechaFinal.Text = "Fecha final"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(7, 133)
            Me.lblPER_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(37, 13)
            Me.lblPER_ID.TabIndex = 16
            Me.lblPER_ID.Text = "Cajero"
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(122, 85)
            Me.txtCCT_DESCRIPCION.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 11
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Location = New System.Drawing.Point(80, 85)
            Me.txtCCT_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtCCT_ID.TabIndex = 10
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(80, 133)
            Me.txtPER_ID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(75, 20)
            Me.txtPER_ID.TabIndex = 14
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
            Me.btnImagen.Location = New System.Drawing.Point(605, 2)
            Me.btnImagen.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(44, 24)
            Me.btnImagen.TabIndex = 13
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'rbSoloEgresos
            '
            Me.rbSoloEgresos.AutoSize = True
            Me.rbSoloEgresos.Location = New System.Drawing.Point(235, 8)
            Me.rbSoloEgresos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.rbSoloEgresos.Name = "rbSoloEgresos"
            Me.rbSoloEgresos.Size = New System.Drawing.Size(86, 17)
            Me.rbSoloEgresos.TabIndex = 23
            Me.rbSoloEgresos.Text = "Solo egresos"
            Me.rbSoloEgresos.UseVisualStyleBackColor = True
            '
            'frmMovimientoCajaBancos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(680, 343)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.Name = "frmMovimientoCajaBancos"
            Me.Text = "Movimiento caja/bancos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.pnMovimientos.ResumeLayout(False)
            Me.pnMovimientos.PerformLayout()
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
        Friend WithEvents lblCCC_ID As System.Windows.Forms.Label
        Public WithEvents txtCCC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_CUENTA_BANCARIA As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_BAN As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Friend WithEvents pnMovimientos As System.Windows.Forms.Panel
        Friend WithEvents rbSoloIngresos As System.Windows.Forms.RadioButton
        Friend WithEvents rbTodosMovimientos As System.Windows.Forms.RadioButton
        Friend WithEvents pnTipoReporte As System.Windows.Forms.Panel
        Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
        Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Friend WithEvents cboCCC_TIPO As System.Windows.Forms.ComboBox
        Friend WithEvents lblCCC_TIPO As System.Windows.Forms.Label
        Public WithEvents txtCCC_TIPO As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Friend WithEvents chkFechaHora As System.Windows.Forms.CheckBox
        Friend WithEvents rbSoloEgresos As System.Windows.Forms.RadioButton
    End Class
End Namespace