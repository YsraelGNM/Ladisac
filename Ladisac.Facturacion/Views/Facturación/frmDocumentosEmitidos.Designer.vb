Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDocumentosEmitidos
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
            Me.lblDPR_TIPO_PROMOCION = New System.Windows.Forms.Label()
            Me.cboDPR_TIPO_PROMOCION = New System.Windows.Forms.ComboBox()
            Me.lblFiltroPuntos = New System.Windows.Forms.Label()
            Me.txtFiltroPuntos = New System.Windows.Forms.TextBox()
            Me.grbPersona = New System.Windows.Forms.GroupBox()
            Me.rbtCliente = New System.Windows.Forms.RadioButton()
            Me.rbtVendedor = New System.Windows.Forms.RadioButton()
            Me.grbDatos = New System.Windows.Forms.GroupBox()
            Me.rbtResumen = New System.Windows.Forms.RadioButton()
            Me.rbtDetalle = New System.Windows.Forms.RadioButton()
            Me.lblDatos = New System.Windows.Forms.Label()
            Me.lblFormato = New System.Windows.Forms.Label()
            Me.grbFormato = New System.Windows.Forms.GroupBox()
            Me.rbtFormato4 = New System.Windows.Forms.RadioButton()
            Me.rbtFormato3 = New System.Windows.Forms.RadioButton()
            Me.rbtFormato1 = New System.Windows.Forms.RadioButton()
            Me.rbtFormato2 = New System.Windows.Forms.RadioButton()
            Me.grbEstadoDoc = New System.Windows.Forms.GroupBox()
            Me.rbtProcesado = New System.Windows.Forms.RadioButton()
            Me.rbtTodos = New System.Windows.Forms.RadioButton()
            Me.rbtActivo = New System.Windows.Forms.RadioButton()
            Me.rbtNoActivo = New System.Windows.Forms.RadioButton()
            Me.lblEstadoDoc = New System.Windows.Forms.Label()
            Me.lblPER_ID_CLI = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_CLI = New System.Windows.Forms.TextBox()
            Me.lblCTD_COR_SERIE = New System.Windows.Forms.Label()
            Me.txtCTD_COR_SERIE = New System.Windows.Forms.TextBox()
            Me.chkProcesar = New System.Windows.Forms.CheckBox()
            Me.txtMON_SIMBOLO = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.lblTDO_ID = New System.Windows.Forms.Label()
            Me.txtTDO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.txtTIV_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblFechaInicial = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblFechaFinal = New System.Windows.Forms.Label()
            Me.lblTIV_ID = New System.Windows.Forms.Label()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtTIV_ID = New System.Windows.Forms.TextBox()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.rbtGrupo = New System.Windows.Forms.RadioButton()
            Me.pnCuerpo.SuspendLayout()
            Me.grbPersona.SuspendLayout()
            Me.grbDatos.SuspendLayout()
            Me.grbFormato.SuspendLayout()
            Me.grbEstadoDoc.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(684, 28)
            Me.lblTitle.Text = "Documentos emitidos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDPR_TIPO_PROMOCION)
            Me.pnCuerpo.Controls.Add(Me.cboDPR_TIPO_PROMOCION)
            Me.pnCuerpo.Controls.Add(Me.lblFiltroPuntos)
            Me.pnCuerpo.Controls.Add(Me.txtFiltroPuntos)
            Me.pnCuerpo.Controls.Add(Me.grbPersona)
            Me.pnCuerpo.Controls.Add(Me.grbDatos)
            Me.pnCuerpo.Controls.Add(Me.lblDatos)
            Me.pnCuerpo.Controls.Add(Me.lblFormato)
            Me.pnCuerpo.Controls.Add(Me.grbFormato)
            Me.pnCuerpo.Controls.Add(Me.grbEstadoDoc)
            Me.pnCuerpo.Controls.Add(Me.lblEstadoDoc)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblCTD_COR_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtCTD_COR_SERIE)
            Me.pnCuerpo.Controls.Add(Me.chkProcesar)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(628, 447)
            Me.pnCuerpo.TabIndex = 119
            '
            'lblDPR_TIPO_PROMOCION
            '
            Me.lblDPR_TIPO_PROMOCION.AutoSize = True
            Me.lblDPR_TIPO_PROMOCION.Enabled = False
            Me.lblDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(332, 413)
            Me.lblDPR_TIPO_PROMOCION.Name = "lblDPR_TIPO_PROMOCION"
            Me.lblDPR_TIPO_PROMOCION.Size = New System.Drawing.Size(57, 13)
            Me.lblDPR_TIPO_PROMOCION.TabIndex = 41
            Me.lblDPR_TIPO_PROMOCION.Text = "Promoción"
            Me.lblDPR_TIPO_PROMOCION.Visible = False
            '
            'cboDPR_TIPO_PROMOCION
            '
            Me.cboDPR_TIPO_PROMOCION.Enabled = False
            Me.cboDPR_TIPO_PROMOCION.FormattingEnabled = True
            Me.cboDPR_TIPO_PROMOCION.Items.AddRange(New Object() {"MAESTRO CONSTRUCTOR", "PROMOCION ECO DIAMANTE"})
            Me.cboDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(391, 412)
            Me.cboDPR_TIPO_PROMOCION.Name = "cboDPR_TIPO_PROMOCION"
            Me.cboDPR_TIPO_PROMOCION.Size = New System.Drawing.Size(226, 21)
            Me.cboDPR_TIPO_PROMOCION.TabIndex = 40
            Me.cboDPR_TIPO_PROMOCION.Visible = False
            '
            'lblFiltroPuntos
            '
            Me.lblFiltroPuntos.AutoSize = True
            Me.lblFiltroPuntos.Enabled = False
            Me.lblFiltroPuntos.Location = New System.Drawing.Point(204, 413)
            Me.lblFiltroPuntos.Name = "lblFiltroPuntos"
            Me.lblFiltroPuntos.Size = New System.Drawing.Size(55, 13)
            Me.lblFiltroPuntos.TabIndex = 39
            Me.lblFiltroPuntos.Text = "Puntos >="
            Me.lblFiltroPuntos.Visible = False
            '
            'txtFiltroPuntos
            '
            Me.txtFiltroPuntos.Enabled = False
            Me.txtFiltroPuntos.Location = New System.Drawing.Point(271, 413)
            Me.txtFiltroPuntos.Name = "txtFiltroPuntos"
            Me.txtFiltroPuntos.Size = New System.Drawing.Size(36, 20)
            Me.txtFiltroPuntos.TabIndex = 38
            Me.txtFiltroPuntos.Text = "0"
            Me.txtFiltroPuntos.Visible = False
            '
            'grbPersona
            '
            Me.grbPersona.Controls.Add(Me.rbtGrupo)
            Me.grbPersona.Controls.Add(Me.rbtCliente)
            Me.grbPersona.Controls.Add(Me.rbtVendedor)
            Me.grbPersona.Location = New System.Drawing.Point(260, 216)
            Me.grbPersona.Name = "grbPersona"
            Me.grbPersona.Size = New System.Drawing.Size(254, 35)
            Me.grbPersona.TabIndex = 36
            Me.grbPersona.TabStop = False
            Me.grbPersona.Text = " Persona"
            '
            'rbtCliente
            '
            Me.rbtCliente.AutoSize = True
            Me.rbtCliente.Checked = True
            Me.rbtCliente.Location = New System.Drawing.Point(10, 13)
            Me.rbtCliente.Name = "rbtCliente"
            Me.rbtCliente.Size = New System.Drawing.Size(57, 17)
            Me.rbtCliente.TabIndex = 35
            Me.rbtCliente.TabStop = True
            Me.rbtCliente.Text = "Cliente"
            Me.rbtCliente.UseVisualStyleBackColor = True
            '
            'rbtVendedor
            '
            Me.rbtVendedor.AutoSize = True
            Me.rbtVendedor.Location = New System.Drawing.Point(89, 13)
            Me.rbtVendedor.Name = "rbtVendedor"
            Me.rbtVendedor.Size = New System.Drawing.Size(71, 17)
            Me.rbtVendedor.TabIndex = 33
            Me.rbtVendedor.Text = "Vendedor"
            Me.rbtVendedor.UseVisualStyleBackColor = True
            '
            'grbDatos
            '
            Me.grbDatos.Controls.Add(Me.rbtResumen)
            Me.grbDatos.Controls.Add(Me.rbtDetalle)
            Me.grbDatos.Location = New System.Drawing.Point(91, 216)
            Me.grbDatos.Name = "grbDatos"
            Me.grbDatos.Size = New System.Drawing.Size(157, 35)
            Me.grbDatos.TabIndex = 18
            Me.grbDatos.TabStop = False
            Me.grbDatos.Text = " Registros"
            '
            'rbtResumen
            '
            Me.rbtResumen.AutoSize = True
            Me.rbtResumen.Checked = True
            Me.rbtResumen.Location = New System.Drawing.Point(10, 13)
            Me.rbtResumen.Name = "rbtResumen"
            Me.rbtResumen.Size = New System.Drawing.Size(70, 17)
            Me.rbtResumen.TabIndex = 35
            Me.rbtResumen.TabStop = True
            Me.rbtResumen.Text = "Resumen"
            Me.rbtResumen.UseVisualStyleBackColor = True
            '
            'rbtDetalle
            '
            Me.rbtDetalle.AutoSize = True
            Me.rbtDetalle.Location = New System.Drawing.Point(89, 13)
            Me.rbtDetalle.Name = "rbtDetalle"
            Me.rbtDetalle.Size = New System.Drawing.Size(58, 17)
            Me.rbtDetalle.TabIndex = 33
            Me.rbtDetalle.Text = "Detalle"
            Me.rbtDetalle.UseVisualStyleBackColor = True
            '
            'lblDatos
            '
            Me.lblDatos.AutoSize = True
            Me.lblDatos.Location = New System.Drawing.Point(4, 228)
            Me.lblDatos.Name = "lblDatos"
            Me.lblDatos.Size = New System.Drawing.Size(35, 13)
            Me.lblDatos.TabIndex = 37
            Me.lblDatos.Text = "Datos"
            '
            'lblFormato
            '
            Me.lblFormato.AutoSize = True
            Me.lblFormato.Location = New System.Drawing.Point(4, 311)
            Me.lblFormato.Name = "lblFormato"
            Me.lblFormato.Size = New System.Drawing.Size(45, 13)
            Me.lblFormato.TabIndex = 37
            Me.lblFormato.Text = "Formato"
            '
            'grbFormato
            '
            Me.grbFormato.Controls.Add(Me.rbtFormato4)
            Me.grbFormato.Controls.Add(Me.rbtFormato3)
            Me.grbFormato.Controls.Add(Me.rbtFormato1)
            Me.grbFormato.Controls.Add(Me.rbtFormato2)
            Me.grbFormato.Location = New System.Drawing.Point(91, 296)
            Me.grbFormato.Name = "grbFormato"
            Me.grbFormato.Size = New System.Drawing.Size(437, 111)
            Me.grbFormato.TabIndex = 20
            Me.grbFormato.TabStop = False
            Me.grbFormato.Text = " "
            '
            'rbtFormato4
            '
            Me.rbtFormato4.AutoSize = True
            Me.rbtFormato4.Location = New System.Drawing.Point(10, 83)
            Me.rbtFormato4.Name = "rbtFormato4"
            Me.rbtFormato4.Size = New System.Drawing.Size(383, 17)
            Me.rbtFormato4.TabIndex = 37
            Me.rbtFormato4.Text = "Ordenado por estado, moneda, punto de venta, documento, serie y número."
            Me.rbtFormato4.UseVisualStyleBackColor = True
            '
            'rbtFormato3
            '
            Me.rbtFormato3.AutoSize = True
            Me.rbtFormato3.Location = New System.Drawing.Point(10, 59)
            Me.rbtFormato3.Name = "rbtFormato3"
            Me.rbtFormato3.Size = New System.Drawing.Size(389, 17)
            Me.rbtFormato3.TabIndex = 36
            Me.rbtFormato3.Text = "Ordenado por persona, moneda, punto de venta, documento, serie y número."
            Me.rbtFormato3.UseVisualStyleBackColor = True
            '
            'rbtFormato1
            '
            Me.rbtFormato1.AutoSize = True
            Me.rbtFormato1.Checked = True
            Me.rbtFormato1.Location = New System.Drawing.Point(10, 16)
            Me.rbtFormato1.Name = "rbtFormato1"
            Me.rbtFormato1.Size = New System.Drawing.Size(413, 17)
            Me.rbtFormato1.TabIndex = 35
            Me.rbtFormato1.TabStop = True
            Me.rbtFormato1.Text = "Ordenado por moneda, punto de venta, documento, tipo de venta, serie y número."
            Me.rbtFormato1.UseVisualStyleBackColor = True
            '
            'rbtFormato2
            '
            Me.rbtFormato2.AutoSize = True
            Me.rbtFormato2.Location = New System.Drawing.Point(10, 36)
            Me.rbtFormato2.Name = "rbtFormato2"
            Me.rbtFormato2.Size = New System.Drawing.Size(345, 17)
            Me.rbtFormato2.TabIndex = 33
            Me.rbtFormato2.Text = "Ordenado por moneda, punto de venta, documento, serie y número."
            Me.rbtFormato2.UseVisualStyleBackColor = True
            '
            'grbEstadoDoc
            '
            Me.grbEstadoDoc.Controls.Add(Me.rbtProcesado)
            Me.grbEstadoDoc.Controls.Add(Me.rbtTodos)
            Me.grbEstadoDoc.Controls.Add(Me.rbtActivo)
            Me.grbEstadoDoc.Controls.Add(Me.rbtNoActivo)
            Me.grbEstadoDoc.Location = New System.Drawing.Point(91, 257)
            Me.grbEstadoDoc.Name = "grbEstadoDoc"
            Me.grbEstadoDoc.Size = New System.Drawing.Size(339, 35)
            Me.grbEstadoDoc.TabIndex = 19
            Me.grbEstadoDoc.TabStop = False
            Me.grbEstadoDoc.Text = " "
            '
            'rbtProcesado
            '
            Me.rbtProcesado.AutoSize = True
            Me.rbtProcesado.Location = New System.Drawing.Point(258, 13)
            Me.rbtProcesado.Name = "rbtProcesado"
            Me.rbtProcesado.Size = New System.Drawing.Size(76, 17)
            Me.rbtProcesado.TabIndex = 36
            Me.rbtProcesado.Text = "Procesado"
            Me.rbtProcesado.UseVisualStyleBackColor = True
            '
            'rbtTodos
            '
            Me.rbtTodos.AutoSize = True
            Me.rbtTodos.Checked = True
            Me.rbtTodos.Location = New System.Drawing.Point(10, 13)
            Me.rbtTodos.Name = "rbtTodos"
            Me.rbtTodos.Size = New System.Drawing.Size(55, 17)
            Me.rbtTodos.TabIndex = 35
            Me.rbtTodos.TabStop = True
            Me.rbtTodos.Text = "Todos"
            Me.rbtTodos.UseVisualStyleBackColor = True
            '
            'rbtActivo
            '
            Me.rbtActivo.AutoSize = True
            Me.rbtActivo.Location = New System.Drawing.Point(89, 13)
            Me.rbtActivo.Name = "rbtActivo"
            Me.rbtActivo.Size = New System.Drawing.Size(55, 17)
            Me.rbtActivo.TabIndex = 33
            Me.rbtActivo.Text = "Activo"
            Me.rbtActivo.UseVisualStyleBackColor = True
            '
            'rbtNoActivo
            '
            Me.rbtNoActivo.AutoSize = True
            Me.rbtNoActivo.Location = New System.Drawing.Point(177, 13)
            Me.rbtNoActivo.Name = "rbtNoActivo"
            Me.rbtNoActivo.Size = New System.Drawing.Size(74, 17)
            Me.rbtNoActivo.TabIndex = 34
            Me.rbtNoActivo.Text = " No activo"
            Me.rbtNoActivo.UseVisualStyleBackColor = True
            '
            'lblEstadoDoc
            '
            Me.lblEstadoDoc.AutoSize = True
            Me.lblEstadoDoc.Location = New System.Drawing.Point(4, 269)
            Me.lblEstadoDoc.Name = "lblEstadoDoc"
            Me.lblEstadoDoc.Size = New System.Drawing.Size(66, 13)
            Me.lblEstadoDoc.TabIndex = 32
            Me.lblEstadoDoc.Text = "Estado Doc."
            '
            'lblPER_ID_CLI
            '
            Me.lblPER_ID_CLI.AutoSize = True
            Me.lblPER_ID_CLI.Location = New System.Drawing.Point(4, 60)
            Me.lblPER_ID_CLI.Name = "lblPER_ID_CLI"
            Me.lblPER_ID_CLI.Size = New System.Drawing.Size(39, 13)
            Me.lblPER_ID_CLI.TabIndex = 31
            Me.lblPER_ID_CLI.Text = "Cliente"
            '
            'txtPER_DESCRIPCION_CLI
            '
            Me.txtPER_DESCRIPCION_CLI.Enabled = False
            Me.txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(172, 60)
            Me.txtPER_DESCRIPCION_CLI.Name = "txtPER_DESCRIPCION_CLI"
            Me.txtPER_DESCRIPCION_CLI.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLI.Size = New System.Drawing.Size(445, 20)
            Me.txtPER_DESCRIPCION_CLI.TabIndex = 7
            '
            'txtPER_ID_CLI
            '
            Me.txtPER_ID_CLI.Location = New System.Drawing.Point(91, 60)
            Me.txtPER_ID_CLI.Name = "txtPER_ID_CLI"
            Me.txtPER_ID_CLI.Size = New System.Drawing.Size(75, 20)
            Me.txtPER_ID_CLI.TabIndex = 6
            '
            'lblCTD_COR_SERIE
            '
            Me.lblCTD_COR_SERIE.AutoSize = True
            Me.lblCTD_COR_SERIE.Location = New System.Drawing.Point(4, 136)
            Me.lblCTD_COR_SERIE.Name = "lblCTD_COR_SERIE"
            Me.lblCTD_COR_SERIE.Size = New System.Drawing.Size(31, 13)
            Me.lblCTD_COR_SERIE.TabIndex = 28
            Me.lblCTD_COR_SERIE.Text = "Serie"
            '
            'txtCTD_COR_SERIE
            '
            Me.txtCTD_COR_SERIE.Location = New System.Drawing.Point(91, 136)
            Me.txtCTD_COR_SERIE.Name = "txtCTD_COR_SERIE"
            Me.txtCTD_COR_SERIE.Size = New System.Drawing.Size(36, 20)
            Me.txtCTD_COR_SERIE.TabIndex = 13
            '
            'chkProcesar
            '
            Me.chkProcesar.AutoSize = True
            Me.chkProcesar.Checked = True
            Me.chkProcesar.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkProcesar.Location = New System.Drawing.Point(7, 111)
            Me.chkProcesar.Name = "chkProcesar"
            Me.chkProcesar.Size = New System.Drawing.Size(68, 17)
            Me.chkProcesar.TabIndex = 10
            Me.chkProcesar.Text = "Procesar"
            Me.chkProcesar.UseVisualStyleBackColor = True
            '
            'txtMON_SIMBOLO
            '
            Me.txtMON_SIMBOLO.Enabled = False
            Me.txtMON_SIMBOLO.Location = New System.Drawing.Point(133, 10)
            Me.txtMON_SIMBOLO.Name = "txtMON_SIMBOLO"
            Me.txtMON_SIMBOLO.ReadOnly = True
            Me.txtMON_SIMBOLO.Size = New System.Drawing.Size(33, 20)
            Me.txtMON_SIMBOLO.TabIndex = 2
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(4, 10)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 26
            Me.lblMON_ID.Text = "Moneda"
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(172, 10)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(445, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 3
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Location = New System.Drawing.Point(91, 10)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtMON_ID.TabIndex = 1
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(133, 111)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 12
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Enabled = False
            Me.txtDTD_ID.Location = New System.Drawing.Point(91, 111)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.ReadOnly = True
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 11
            '
            'lblTDO_ID
            '
            Me.lblTDO_ID.AutoSize = True
            Me.lblTDO_ID.Location = New System.Drawing.Point(4, 86)
            Me.lblTDO_ID.Name = "lblTDO_ID"
            Me.lblTDO_ID.Size = New System.Drawing.Size(62, 13)
            Me.lblTDO_ID.TabIndex = 14
            Me.lblTDO_ID.Text = "Documento"
            '
            'txtTDO_DESCRIPCION
            '
            Me.txtTDO_DESCRIPCION.Enabled = False
            Me.txtTDO_DESCRIPCION.Location = New System.Drawing.Point(133, 86)
            Me.txtTDO_DESCRIPCION.Name = "txtTDO_DESCRIPCION"
            Me.txtTDO_DESCRIPCION.ReadOnly = True
            Me.txtTDO_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtTDO_DESCRIPCION.TabIndex = 9
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Location = New System.Drawing.Point(91, 86)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtTDO_ID.TabIndex = 8
            '
            'dtpFechaFinal
            '
            Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinal.Location = New System.Drawing.Point(333, 187)
            Me.dtpFechaFinal.Name = "dtpFechaFinal"
            Me.dtpFechaFinal.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinal.TabIndex = 17
            '
            'dtpFechaInicial
            '
            Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicial.Location = New System.Drawing.Point(91, 187)
            Me.dtpFechaInicial.Name = "dtpFechaInicial"
            Me.dtpFechaInicial.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicial.TabIndex = 16
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(91, 413)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
            Me.btnImprimir.TabIndex = 21
            Me.btnImprimir.Text = "Generar"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'txtTIV_DESCRIPCION
            '
            Me.txtTIV_DESCRIPCION.Enabled = False
            Me.txtTIV_DESCRIPCION.Location = New System.Drawing.Point(133, 162)
            Me.txtTIV_DESCRIPCION.Name = "txtTIV_DESCRIPCION"
            Me.txtTIV_DESCRIPCION.ReadOnly = True
            Me.txtTIV_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtTIV_DESCRIPCION.TabIndex = 15
            '
            'lblFechaInicial
            '
            Me.lblFechaInicial.AutoSize = True
            Me.lblFechaInicial.Location = New System.Drawing.Point(4, 187)
            Me.lblFechaInicial.Name = "lblFechaInicial"
            Me.lblFechaInicial.Size = New System.Drawing.Size(66, 13)
            Me.lblFechaInicial.TabIndex = 17
            Me.lblFechaInicial.Text = "Fecha inicial"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(4, 34)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ID.TabIndex = 15
            Me.lblPVE_ID.Text = "Punto venta"
            '
            'lblFechaFinal
            '
            Me.lblFechaFinal.AutoSize = True
            Me.lblFechaFinal.Location = New System.Drawing.Point(268, 187)
            Me.lblFechaFinal.Name = "lblFechaFinal"
            Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
            Me.lblFechaFinal.TabIndex = 23
            Me.lblFechaFinal.Text = "Fecha final"
            '
            'lblTIV_ID
            '
            Me.lblTIV_ID.AutoSize = True
            Me.lblTIV_ID.Location = New System.Drawing.Point(4, 162)
            Me.lblTIV_ID.Name = "lblTIV_ID"
            Me.lblTIV_ID.Size = New System.Drawing.Size(58, 13)
            Me.lblTIV_ID.TabIndex = 16
            Me.lblTIV_ID.Text = "Tipo venta"
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(133, 34)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 5
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(91, 34)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtPVE_ID.TabIndex = 4
            '
            'txtTIV_ID
            '
            Me.txtTIV_ID.Location = New System.Drawing.Point(91, 162)
            Me.txtTIV_ID.Name = "txtTIV_ID"
            Me.txtTIV_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtTIV_ID.TabIndex = 14
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
            Me.btnImagen.Location = New System.Drawing.Point(610, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 13
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'rbtGrupo
            '
            Me.rbtGrupo.AutoSize = True
            Me.rbtGrupo.Location = New System.Drawing.Point(182, 13)
            Me.rbtGrupo.Name = "rbtGrupo"
            Me.rbtGrupo.Size = New System.Drawing.Size(54, 17)
            Me.rbtGrupo.TabIndex = 36
            Me.rbtGrupo.Text = "Grupo"
            Me.rbtGrupo.UseVisualStyleBackColor = True
            '
            'frmDocumentosEmitidos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(684, 506)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDocumentosEmitidos"
            Me.Text = "Documentos emitidos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.grbPersona.ResumeLayout(False)
            Me.grbPersona.PerformLayout()
            Me.grbDatos.ResumeLayout(False)
            Me.grbDatos.PerformLayout()
            Me.grbFormato.ResumeLayout(False)
            Me.grbFormato.PerformLayout()
            Me.grbEstadoDoc.ResumeLayout(False)
            Me.grbEstadoDoc.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblFechaInicial As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
        Friend WithEvents lblTIV_ID As System.Windows.Forms.Label
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTIV_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents txtTIV_DESCRIPCION As System.Windows.Forms.TextBox
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
        Friend WithEvents lblTDO_ID As System.Windows.Forms.Label
        Public WithEvents txtTDO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents chkProcesar As System.Windows.Forms.CheckBox
        Friend WithEvents lblCTD_COR_SERIE As System.Windows.Forms.Label
        Public WithEvents txtCTD_COR_SERIE As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_CLI As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_CLI As System.Windows.Forms.TextBox
        Friend WithEvents grbEstadoDoc As System.Windows.Forms.GroupBox
        Friend WithEvents rbtActivo As System.Windows.Forms.RadioButton
        Friend WithEvents rbtNoActivo As System.Windows.Forms.RadioButton
        Friend WithEvents lblEstadoDoc As System.Windows.Forms.Label
        Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
        Friend WithEvents lblFormato As System.Windows.Forms.Label
        Friend WithEvents grbFormato As System.Windows.Forms.GroupBox
        Friend WithEvents rbtFormato1 As System.Windows.Forms.RadioButton
        Friend WithEvents rbtFormato2 As System.Windows.Forms.RadioButton
        Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
        Friend WithEvents rbtResumen As System.Windows.Forms.RadioButton
        Friend WithEvents rbtDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents lblDatos As System.Windows.Forms.Label
        Friend WithEvents rbtProcesado As System.Windows.Forms.RadioButton
        Friend WithEvents grbPersona As System.Windows.Forms.GroupBox
        Friend WithEvents rbtCliente As System.Windows.Forms.RadioButton
        Friend WithEvents rbtVendedor As System.Windows.Forms.RadioButton
        Friend WithEvents rbtFormato3 As System.Windows.Forms.RadioButton
        Friend WithEvents rbtFormato4 As System.Windows.Forms.RadioButton
        Friend WithEvents lblFiltroPuntos As System.Windows.Forms.Label
        Public WithEvents txtFiltroPuntos As System.Windows.Forms.TextBox
        Friend WithEvents lblDPR_TIPO_PROMOCION As System.Windows.Forms.Label
        Friend WithEvents cboDPR_TIPO_PROMOCION As System.Windows.Forms.ComboBox
        Friend WithEvents rbtGrupo As System.Windows.Forms.RadioButton
    End Class
End Namespace