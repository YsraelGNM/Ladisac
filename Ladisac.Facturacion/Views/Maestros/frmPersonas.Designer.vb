Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPersonas
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.dgvDireccionPersona = New System.Windows.Forms.DataGridView()
            Me.cItem1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_TIPO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_DESCRIPCION1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_REFERENCIA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDIR_ESTADO1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtPER_EXCESO_LINEA = New System.Windows.Forms.TextBox()
            Me.lblPER_EXCESO_LINEA = New System.Windows.Forms.Label()
            Me.dgvDocIdentidad = New System.Windows.Forms.DataGridView()
            Me.cItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOP_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_LONGITUD = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_COD_SUNAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDOP_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvContactoPersona = New System.Windows.Forms.DataGridView()
            Me.cItem2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_TIPO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_DESCRIPCION2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_DIRECCION2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_TELEFONO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_EMAIL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCOP_ESTADO2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtPER_TELEFONOS = New System.Windows.Forms.TextBox()
            Me.chkPER_LINEA_CREDITO_ESTADO = New System.Windows.Forms.CheckBox()
            Me.dgvSaldos = New System.Windows.Forms.DataGridView()
            Me.txtDisponible = New System.Windows.Forms.TextBox()
            Me.lblDisponible = New System.Windows.Forms.Label()
            Me.txtDeuda = New System.Windows.Forms.TextBox()
            Me.lblDeuda = New System.Windows.Forms.Label()
            Me.cboPER_CONTACTO_OP_CON = New System.Windows.Forms.ComboBox()
            Me.chkPER_CONTACTO = New System.Windows.Forms.CheckBox()
            Me.lblPER_RAZON_SOCIAL = New System.Windows.Forms.Label()
            Me.lblTipoCliente = New System.Windows.Forms.Label()
            Me.cboTipoCliente = New System.Windows.Forms.ComboBox()
            Me.tcoDatos1 = New System.Windows.Forms.TabControl()
            Me.tpaEsCliente = New System.Windows.Forms.TabPage()
            Me.tpaEsVendedor = New System.Windows.Forms.TabPage()
            Me.tpaEsTransportista = New System.Windows.Forms.TabPage()
            Me.tpaEsBanco = New System.Windows.Forms.TabPage()
            Me.tpaFinanzas = New System.Windows.Forms.TabPage()
            Me.txtPER_EMAIL = New System.Windows.Forms.TextBox()
            Me.txtPER_PAGINA_WEB = New System.Windows.Forms.TextBox()
            Me.lblPER_TELEFONOS = New System.Windows.Forms.Label()
            Me.lblPER_EMAIL = New System.Windows.Forms.Label()
            Me.lblPER_PAGINA_WEB = New System.Windows.Forms.Label()
            Me.lblPER_FECHA_ALTA = New System.Windows.Forms.Label()
            Me.dtpPER_FECHA_ALTA = New System.Windows.Forms.DateTimePicker()
            Me.lblPER_FECHA_VENC = New System.Windows.Forms.Label()
            Me.dtpPER_FECHA_VENC = New System.Windows.Forms.DateTimePicker()
            Me.lblPER_GARANTIA = New System.Windows.Forms.Label()
            Me.txtPER_GARANTIA = New System.Windows.Forms.TextBox()
            Me.tcoDatos = New System.Windows.Forms.TabControl()
            Me.tpaMediosContacto = New System.Windows.Forms.TabPage()
            Me.tpaDocIdentidad = New System.Windows.Forms.TabPage()
            Me.tpaDirecciones = New System.Windows.Forms.TabPage()
            Me.tpaContactos = New System.Windows.Forms.TabPage()
            Me.tpaFormaVenta = New System.Windows.Forms.TabPage()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.lblPER_APE_PAT = New System.Windows.Forms.Label()
            Me.lblPER_CARGO = New System.Windows.Forms.Label()
            Me.txtPER_BONO = New System.Windows.Forms.TextBox()
            Me.lblPER_TRANSP_PROPIO = New System.Windows.Forms.Label()
            Me.lblPER_TRABAJADOR = New System.Windows.Forms.Label()
            Me.txtCCC_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.lblPER_GRUPO = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION_GRU = New System.Windows.Forms.TextBox()
            Me.chkPER_TRABAJADOR = New System.Windows.Forms.CheckBox()
            Me.txtPER_DIAS_CREDITO = New System.Windows.Forms.TextBox()
            Me.lblPER_BANCO = New System.Windows.Forms.Label()
            Me.lblPER_DIAS_CREDITO = New System.Windows.Forms.Label()
            Me.lblPER_TRANSPORTISTA = New System.Windows.Forms.Label()
            Me.chkPER_TRANSPORTISTA = New System.Windows.Forms.CheckBox()
            Me.lblPER_LINEA_CREDITO = New System.Windows.Forms.Label()
            Me.lblPER_PROVEEDOR = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION_BAN = New System.Windows.Forms.TextBox()
            Me.chkPER_PROVEEDOR = New System.Windows.Forms.CheckBox()
            Me.txtPER_LINEA_CREDITO = New System.Windows.Forms.TextBox()
            Me.lblPER_CLIENTE = New System.Windows.Forms.Label()
            Me.chkPER_CLIENTE = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_TRA = New System.Windows.Forms.TextBox()
            Me.chkPER_BANCO = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_COB = New System.Windows.Forms.TextBox()
            Me.chkPER_GRUPO = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_VEN = New System.Windows.Forms.TextBox()
            Me.cboPER_CLIENTE_OP_CON = New System.Windows.Forms.ComboBox()
            Me.lblPER_ESTADO = New System.Windows.Forms.Label()
            Me.cboPER_PROVEEDOR_OP_CON = New System.Windows.Forms.ComboBox()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.cboPER_TRANSPORTISTA_OP_CON = New System.Windows.Forms.ComboBox()
            Me.cboPER_TRABAJADOR_OP_CON = New System.Windows.Forms.ComboBox()
            Me.lblPER_FIRMA_AUT = New System.Windows.Forms.Label()
            Me.cboPER_BANCO_OP_CON = New System.Windows.Forms.ComboBox()
            Me.lblPER_REP_LEGAL = New System.Windows.Forms.Label()
            Me.cboPER_GRUPO_OP_CON = New System.Windows.Forms.ComboBox()
            Me.chkPER_FIRMA_AUT = New System.Windows.Forms.CheckBox()
            Me.chkPER_REP_LEGAL = New System.Windows.Forms.CheckBox()
            Me.cboPER_TRANSP_PROPIO = New System.Windows.Forms.ComboBox()
            Me.txtPER_CARGO = New System.Windows.Forms.TextBox()
            Me.txtCCC_ID_CLI = New System.Windows.Forms.TextBox()
            Me.lblPER_BONO = New System.Windows.Forms.Label()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.txtPER_CUOTA_OBJETIVO = New System.Windows.Forms.TextBox()
            Me.cboPER_CARTA_FIANZA = New System.Windows.Forms.ComboBox()
            Me.chkPER_PROMOCIONES = New System.Windows.Forms.CheckBox()
            Me.lblPER_CUOTA_OBJETIVO = New System.Windows.Forms.Label()
            Me.lblPER_CUOTA_MENSUAL = New System.Windows.Forms.Label()
            Me.lblPER_CARTA_FIANZA = New System.Windows.Forms.Label()
            Me.lblPER_PROMOCIONES = New System.Windows.Forms.Label()
            Me.lblPER_OBSERVACIONES = New System.Windows.Forms.Label()
            Me.cboPER_DOC_PAGO = New System.Windows.Forms.ComboBox()
            Me.cboPER_COND_DIASEM = New System.Windows.Forms.ComboBox()
            Me.cboPER_DIASEM_PAGO = New System.Windows.Forms.ComboBox()
            Me.lblPER_HORA_PAGO = New System.Windows.Forms.Label()
            Me.lblPER_DOC_PAGO = New System.Windows.Forms.Label()
            Me.lblPER_DIASEM_PAGO = New System.Windows.Forms.Label()
            Me.lblPER_ID_BAN = New System.Windows.Forms.Label()
            Me.lblPER_ID_TRA = New System.Windows.Forms.Label()
            Me.lblPER_ID_GRU = New System.Windows.Forms.Label()
            Me.txtPER_CUOTA_MENSUAL = New System.Windows.Forms.TextBox()
            Me.txtPER_OBSERVACIONES = New System.Windows.Forms.TextBox()
            Me.txtPER_HORA_PAGO = New System.Windows.Forms.TextBox()
            Me.txtPER_DIAMES_PAGO = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_GRU = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_BAN = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_TRA = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_COB = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_VEN = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_COB = New System.Windows.Forms.Label()
            Me.lblPER_DIAMES_PAGO = New System.Windows.Forms.Label()
            Me.lblPER_COND_DIASEM = New System.Windows.Forms.Label()
            Me.lblPER_ID_VEN = New System.Windows.Forms.Label()
            Me.cboPER_FORMA_VENTA = New System.Windows.Forms.ComboBox()
            Me.txtPER_BREVETE = New System.Windows.Forms.TextBox()
            Me.txtPER_APE_PAT = New System.Windows.Forms.TextBox()
            Me.lblPER_BREVETE = New System.Windows.Forms.Label()
            Me.lblPER_FORMA_VENTA = New System.Windows.Forms.Label()
            Me.lblPER_APE_MAT = New System.Windows.Forms.Label()
            Me.lblPER_NOMBRES = New System.Windows.Forms.Label()
            Me.txtPER_APE_MAT = New System.Windows.Forms.TextBox()
            Me.txtPER_NOMBRES = New System.Windows.Forms.TextBox()
            Me.gbDatosTipo = New System.Windows.Forms.GroupBox()
            Me.lblPER_CONTACTO = New System.Windows.Forms.Label()
            Me.gbDatosGenerales = New System.Windows.Forms.GroupBox()
            Me.gbDatosVendedores = New System.Windows.Forms.GroupBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.lblDIS_ID = New System.Windows.Forms.Label()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDireccionPersona, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDocIdentidad, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvContactoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcoDatos1.SuspendLayout()
            Me.tcoDatos.SuspendLayout()
            Me.gbDatosTipo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(909, 28)
            Me.lblTitle.Text = "Personas"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.dgvDireccionPersona)
            Me.pnCuerpo.Controls.Add(Me.txtPER_EXCESO_LINEA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_EXCESO_LINEA)
            Me.pnCuerpo.Controls.Add(Me.dgvDocIdentidad)
            Me.pnCuerpo.Controls.Add(Me.dgvContactoPersona)
            Me.pnCuerpo.Controls.Add(Me.txtPER_TELEFONOS)
            Me.pnCuerpo.Controls.Add(Me.chkPER_LINEA_CREDITO_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.dgvSaldos)
            Me.pnCuerpo.Controls.Add(Me.txtDisponible)
            Me.pnCuerpo.Controls.Add(Me.lblDisponible)
            Me.pnCuerpo.Controls.Add(Me.txtDeuda)
            Me.pnCuerpo.Controls.Add(Me.lblDeuda)
            Me.pnCuerpo.Controls.Add(Me.cboPER_CONTACTO_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.chkPER_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_RAZON_SOCIAL)
            Me.pnCuerpo.Controls.Add(Me.lblTipoCliente)
            Me.pnCuerpo.Controls.Add(Me.cboTipoCliente)
            Me.pnCuerpo.Controls.Add(Me.tcoDatos1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_EMAIL)
            Me.pnCuerpo.Controls.Add(Me.txtPER_PAGINA_WEB)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TELEFONOS)
            Me.pnCuerpo.Controls.Add(Me.lblPER_EMAIL)
            Me.pnCuerpo.Controls.Add(Me.lblPER_PAGINA_WEB)
            Me.pnCuerpo.Controls.Add(Me.lblPER_FECHA_ALTA)
            Me.pnCuerpo.Controls.Add(Me.dtpPER_FECHA_ALTA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_FECHA_VENC)
            Me.pnCuerpo.Controls.Add(Me.dtpPER_FECHA_VENC)
            Me.pnCuerpo.Controls.Add(Me.lblPER_GARANTIA)
            Me.pnCuerpo.Controls.Add(Me.txtPER_GARANTIA)
            Me.pnCuerpo.Controls.Add(Me.tcoDatos)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_APE_PAT)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CARGO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_BONO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TRANSP_PROPIO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblPER_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_GRU)
            Me.pnCuerpo.Controls.Add(Me.chkPER_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DIAS_CREDITO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BANCO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DIAS_CREDITO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.chkPER_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_LINEA_CREDITO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_BAN)
            Me.pnCuerpo.Controls.Add(Me.chkPER_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.txtPER_LINEA_CREDITO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkPER_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_TRA)
            Me.pnCuerpo.Controls.Add(Me.chkPER_BANCO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_COB)
            Me.pnCuerpo.Controls.Add(Me.chkPER_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_VEN)
            Me.pnCuerpo.Controls.Add(Me.cboPER_CLIENTE_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.cboPER_PROVEEDOR_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.cboPER_TRANSPORTISTA_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.cboPER_TRABAJADOR_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.lblPER_FIRMA_AUT)
            Me.pnCuerpo.Controls.Add(Me.cboPER_BANCO_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.lblPER_REP_LEGAL)
            Me.pnCuerpo.Controls.Add(Me.cboPER_GRUPO_OP_CON)
            Me.pnCuerpo.Controls.Add(Me.chkPER_FIRMA_AUT)
            Me.pnCuerpo.Controls.Add(Me.chkPER_REP_LEGAL)
            Me.pnCuerpo.Controls.Add(Me.cboPER_TRANSP_PROPIO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_CARGO)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BONO)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_CUOTA_OBJETIVO)
            Me.pnCuerpo.Controls.Add(Me.cboPER_CARTA_FIANZA)
            Me.pnCuerpo.Controls.Add(Me.chkPER_PROMOCIONES)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CUOTA_OBJETIVO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CUOTA_MENSUAL)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CARTA_FIANZA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_PROMOCIONES)
            Me.pnCuerpo.Controls.Add(Me.lblPER_OBSERVACIONES)
            Me.pnCuerpo.Controls.Add(Me.cboPER_DOC_PAGO)
            Me.pnCuerpo.Controls.Add(Me.cboPER_COND_DIASEM)
            Me.pnCuerpo.Controls.Add(Me.cboPER_DIASEM_PAGO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_HORA_PAGO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DOC_PAGO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DIASEM_PAGO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_TRA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_GRU)
            Me.pnCuerpo.Controls.Add(Me.txtPER_CUOTA_MENSUAL)
            Me.pnCuerpo.Controls.Add(Me.txtPER_OBSERVACIONES)
            Me.pnCuerpo.Controls.Add(Me.txtPER_HORA_PAGO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DIAMES_PAGO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_GRU)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_TRA)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_COB)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_COB)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DIAMES_PAGO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_COND_DIASEM)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.cboPER_FORMA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.txtPER_BREVETE)
            Me.pnCuerpo.Controls.Add(Me.txtPER_APE_PAT)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BREVETE)
            Me.pnCuerpo.Controls.Add(Me.lblPER_FORMA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_APE_MAT)
            Me.pnCuerpo.Controls.Add(Me.lblPER_NOMBRES)
            Me.pnCuerpo.Controls.Add(Me.txtPER_APE_MAT)
            Me.pnCuerpo.Controls.Add(Me.txtPER_NOMBRES)
            Me.pnCuerpo.Controls.Add(Me.gbDatosTipo)
            Me.pnCuerpo.Controls.Add(Me.gbDatosGenerales)
            Me.pnCuerpo.Controls.Add(Me.gbDatosVendedores)
            Me.pnCuerpo.Location = New System.Drawing.Point(32, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(838, 570)
            Me.pnCuerpo.TabIndex = 19
            '
            'dgvDireccionPersona
            '
            Me.dgvDireccionPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDireccionPersona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cItem1, Me.cDIR_ID1, Me.cDIR_TIPO1, Me.cDIR_DESCRIPCION1, Me.cDIR_REFERENCIA1, Me.cDIS_ID1, Me.cDIS_DESCRIPCION1, Me.cDIS_ESTADO1, Me.cDIR_ESTADO1, Me.cEstadoRegistro1})
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDireccionPersona.DefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDireccionPersona.Location = New System.Drawing.Point(16, 183)
            Me.dgvDireccionPersona.Name = "dgvDireccionPersona"
            Me.dgvDireccionPersona.Size = New System.Drawing.Size(806, 188)
            Me.dgvDireccionPersona.TabIndex = 131
            Me.dgvDireccionPersona.Visible = False
            '
            'cItem1
            '
            Me.cItem1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cItem1.HeaderText = "Item"
            Me.cItem1.Name = "cItem1"
            Me.cItem1.ReadOnly = True
            Me.cItem1.Width = 5
            '
            'cDIR_ID1
            '
            Me.cDIR_ID1.HeaderText = "Código"
            Me.cDIR_ID1.Name = "cDIR_ID1"
            Me.cDIR_ID1.ReadOnly = True
            Me.cDIR_ID1.Visible = False
            '
            'cDIR_TIPO1
            '
            Me.cDIR_TIPO1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cDIR_TIPO1.HeaderText = "Tipo"
            Me.cDIR_TIPO1.Name = "cDIR_TIPO1"
            Me.cDIR_TIPO1.ReadOnly = True
            '
            'cDIR_DESCRIPCION1
            '
            Me.cDIR_DESCRIPCION1.HeaderText = "Dirección"
            Me.cDIR_DESCRIPCION1.Name = "cDIR_DESCRIPCION1"
            '
            'cDIR_REFERENCIA1
            '
            Me.cDIR_REFERENCIA1.HeaderText = "Referencia"
            Me.cDIR_REFERENCIA1.Name = "cDIR_REFERENCIA1"
            '
            'cDIS_ID1
            '
            Me.cDIS_ID1.HeaderText = "Código distrito"
            Me.cDIS_ID1.Name = "cDIS_ID1"
            '
            'cDIS_DESCRIPCION1
            '
            Me.cDIS_DESCRIPCION1.HeaderText = "Descripción distrito"
            Me.cDIS_DESCRIPCION1.Name = "cDIS_DESCRIPCION1"
            Me.cDIS_DESCRIPCION1.ReadOnly = True
            '
            'cDIS_ESTADO1
            '
            Me.cDIS_ESTADO1.HeaderText = "Estado distrito"
            Me.cDIS_ESTADO1.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDIS_ESTADO1.Name = "cDIS_ESTADO1"
            Me.cDIS_ESTADO1.ReadOnly = True
            Me.cDIS_ESTADO1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDIS_ESTADO1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDIS_ESTADO1.Visible = False
            '
            'cDIR_ESTADO1
            '
            Me.cDIR_ESTADO1.HeaderText = "Estado dirección"
            Me.cDIR_ESTADO1.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDIR_ESTADO1.Name = "cDIR_ESTADO1"
            Me.cDIR_ESTADO1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDIR_ESTADO1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cEstadoRegistro1
            '
            Me.cEstadoRegistro1.HeaderText = "Estado de registro"
            Me.cEstadoRegistro1.Name = "cEstadoRegistro1"
            Me.cEstadoRegistro1.ReadOnly = True
            Me.cEstadoRegistro1.Visible = False
            '
            'txtPER_EXCESO_LINEA
            '
            Me.txtPER_EXCESO_LINEA.Location = New System.Drawing.Point(108, 305)
            Me.txtPER_EXCESO_LINEA.Name = "txtPER_EXCESO_LINEA"
            Me.txtPER_EXCESO_LINEA.Size = New System.Drawing.Size(62, 20)
            Me.txtPER_EXCESO_LINEA.TabIndex = 55
            Me.txtPER_EXCESO_LINEA.Text = "0.00"
            Me.txtPER_EXCESO_LINEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPER_EXCESO_LINEA
            '
            Me.lblPER_EXCESO_LINEA.AutoSize = True
            Me.lblPER_EXCESO_LINEA.Location = New System.Drawing.Point(19, 305)
            Me.lblPER_EXCESO_LINEA.Name = "lblPER_EXCESO_LINEA"
            Me.lblPER_EXCESO_LINEA.Size = New System.Drawing.Size(69, 13)
            Me.lblPER_EXCESO_LINEA.TabIndex = 56
            Me.lblPER_EXCESO_LINEA.Text = "Exceso línea"
            '
            'dgvDocIdentidad
            '
            Me.dgvDocIdentidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDocIdentidad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cItem, Me.cTDP_ID, Me.cTDP_DESCRIPCION, Me.cDOP_NUMERO, Me.cTDP_LONGITUD, Me.cTDP_COD_SUNAT, Me.cTDP_ESTADO, Me.cDOP_ESTADO, Me.cEstadoRegistro})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDocIdentidad.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDocIdentidad.Location = New System.Drawing.Point(17, 183)
            Me.dgvDocIdentidad.Name = "dgvDocIdentidad"
            Me.dgvDocIdentidad.Size = New System.Drawing.Size(805, 188)
            Me.dgvDocIdentidad.TabIndex = 129
            Me.dgvDocIdentidad.Visible = False
            '
            'cItem
            '
            Me.cItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cItem.HeaderText = "Item"
            Me.cItem.Name = "cItem"
            Me.cItem.ReadOnly = True
            Me.cItem.Width = 5
            '
            'cTDP_ID
            '
            Me.cTDP_ID.HeaderText = "Código"
            Me.cTDP_ID.Name = "cTDP_ID"
            Me.cTDP_ID.ReadOnly = True
            '
            'cTDP_DESCRIPCION
            '
            Me.cTDP_DESCRIPCION.HeaderText = "Descripción"
            Me.cTDP_DESCRIPCION.Name = "cTDP_DESCRIPCION"
            Me.cTDP_DESCRIPCION.ReadOnly = True
            '
            'cDOP_NUMERO
            '
            Me.cDOP_NUMERO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cDOP_NUMERO.HeaderText = "Número"
            Me.cDOP_NUMERO.Name = "cDOP_NUMERO"
            Me.cDOP_NUMERO.Width = 200
            '
            'cTDP_LONGITUD
            '
            Me.cTDP_LONGITUD.HeaderText = "Longitud"
            Me.cTDP_LONGITUD.Name = "cTDP_LONGITUD"
            Me.cTDP_LONGITUD.ReadOnly = True
            '
            'cTDP_COD_SUNAT
            '
            Me.cTDP_COD_SUNAT.HeaderText = "Sunat"
            Me.cTDP_COD_SUNAT.Name = "cTDP_COD_SUNAT"
            Me.cTDP_COD_SUNAT.ReadOnly = True
            Me.cTDP_COD_SUNAT.Visible = False
            '
            'cTDP_ESTADO
            '
            Me.cTDP_ESTADO.HeaderText = "Estado código"
            Me.cTDP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cTDP_ESTADO.Name = "cTDP_ESTADO"
            Me.cTDP_ESTADO.ReadOnly = True
            Me.cTDP_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cTDP_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cTDP_ESTADO.Visible = False
            '
            'cDOP_ESTADO
            '
            Me.cDOP_ESTADO.HeaderText = "Estado doc. identidad"
            Me.cDOP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDOP_ESTADO.Name = "cDOP_ESTADO"
            Me.cDOP_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDOP_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            Me.cEstadoRegistro.Visible = False
            '
            'dgvContactoPersona
            '
            Me.dgvContactoPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvContactoPersona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cItem2, Me.cCOP_ID2, Me.cCOP_TIPO2, Me.cCOP_DESCRIPCION2, Me.cCOP_DIRECCION2, Me.cCOP_TELEFONO2, Me.cCOP_EMAIL2, Me.cCOP_ESTADO2, Me.cEstadoRegistro2})
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvContactoPersona.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvContactoPersona.Location = New System.Drawing.Point(16, 183)
            Me.dgvContactoPersona.Name = "dgvContactoPersona"
            Me.dgvContactoPersona.Size = New System.Drawing.Size(806, 188)
            Me.dgvContactoPersona.TabIndex = 132
            Me.dgvContactoPersona.Visible = False
            '
            'cItem2
            '
            Me.cItem2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cItem2.HeaderText = "Item"
            Me.cItem2.Name = "cItem2"
            Me.cItem2.ReadOnly = True
            Me.cItem2.Width = 5
            '
            'cCOP_ID2
            '
            Me.cCOP_ID2.HeaderText = "Código"
            Me.cCOP_ID2.Name = "cCOP_ID2"
            Me.cCOP_ID2.ReadOnly = True
            Me.cCOP_ID2.Visible = False
            '
            'cCOP_TIPO2
            '
            Me.cCOP_TIPO2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cCOP_TIPO2.HeaderText = "Tipo"
            Me.cCOP_TIPO2.Name = "cCOP_TIPO2"
            Me.cCOP_TIPO2.ReadOnly = True
            '
            'cCOP_DESCRIPCION2
            '
            Me.cCOP_DESCRIPCION2.HeaderText = "Nombre y apellidos"
            Me.cCOP_DESCRIPCION2.Name = "cCOP_DESCRIPCION2"
            '
            'cCOP_DIRECCION2
            '
            Me.cCOP_DIRECCION2.HeaderText = "Dirección"
            Me.cCOP_DIRECCION2.Name = "cCOP_DIRECCION2"
            '
            'cCOP_TELEFONO2
            '
            Me.cCOP_TELEFONO2.HeaderText = "Teléfono"
            Me.cCOP_TELEFONO2.Name = "cCOP_TELEFONO2"
            '
            'cCOP_EMAIL2
            '
            Me.cCOP_EMAIL2.HeaderText = "Correo eléctronico"
            Me.cCOP_EMAIL2.Name = "cCOP_EMAIL2"
            '
            'cCOP_ESTADO2
            '
            Me.cCOP_ESTADO2.HeaderText = "Estado contacto"
            Me.cCOP_ESTADO2.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cCOP_ESTADO2.Name = "cCOP_ESTADO2"
            Me.cCOP_ESTADO2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cCOP_ESTADO2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cEstadoRegistro2
            '
            Me.cEstadoRegistro2.HeaderText = "Estado de registro"
            Me.cEstadoRegistro2.Name = "cEstadoRegistro2"
            Me.cEstadoRegistro2.ReadOnly = True
            '
            'txtPER_TELEFONOS
            '
            Me.txtPER_TELEFONOS.Location = New System.Drawing.Point(84, 186)
            Me.txtPER_TELEFONOS.Name = "txtPER_TELEFONOS"
            Me.txtPER_TELEFONOS.Size = New System.Drawing.Size(727, 20)
            Me.txtPER_TELEFONOS.TabIndex = 21
            '
            'chkPER_LINEA_CREDITO_ESTADO
            '
            Me.chkPER_LINEA_CREDITO_ESTADO.AutoSize = True
            Me.chkPER_LINEA_CREDITO_ESTADO.Location = New System.Drawing.Point(735, 186)
            Me.chkPER_LINEA_CREDITO_ESTADO.Name = "chkPER_LINEA_CREDITO_ESTADO"
            Me.chkPER_LINEA_CREDITO_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_LINEA_CREDITO_ESTADO.TabIndex = 5
            Me.chkPER_LINEA_CREDITO_ESTADO.UseVisualStyleBackColor = True
            '
            'dgvSaldos
            '
            Me.dgvSaldos.AllowUserToAddRows = False
            Me.dgvSaldos.AllowUserToDeleteRows = False
            Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSaldos.Enabled = False
            Me.dgvSaldos.Location = New System.Drawing.Point(43, 30)
            Me.dgvSaldos.Name = "dgvSaldos"
            Me.dgvSaldos.ReadOnly = True
            Me.dgvSaldos.Size = New System.Drawing.Size(20, 16)
            Me.dgvSaldos.TabIndex = 200
            Me.dgvSaldos.Visible = False
            '
            'txtDisponible
            '
            Me.txtDisponible.Location = New System.Drawing.Point(607, 257)
            Me.txtDisponible.Name = "txtDisponible"
            Me.txtDisponible.ReadOnly = True
            Me.txtDisponible.Size = New System.Drawing.Size(123, 20)
            Me.txtDisponible.TabIndex = 196
            Me.txtDisponible.Text = "0.00"
            Me.txtDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDisponible
            '
            Me.lblDisponible.AutoSize = True
            Me.lblDisponible.Location = New System.Drawing.Point(536, 257)
            Me.lblDisponible.Name = "lblDisponible"
            Me.lblDisponible.Size = New System.Drawing.Size(56, 13)
            Me.lblDisponible.TabIndex = 199
            Me.lblDisponible.Text = "Disponible"
            '
            'txtDeuda
            '
            Me.txtDeuda.BackColor = System.Drawing.SystemColors.Control
            Me.txtDeuda.ForeColor = System.Drawing.Color.Red
            Me.txtDeuda.Location = New System.Drawing.Point(464, 257)
            Me.txtDeuda.Name = "txtDeuda"
            Me.txtDeuda.ReadOnly = True
            Me.txtDeuda.Size = New System.Drawing.Size(62, 20)
            Me.txtDeuda.TabIndex = 195
            Me.txtDeuda.Text = "0.00"
            Me.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDeuda
            '
            Me.lblDeuda.AutoSize = True
            Me.lblDeuda.Location = New System.Drawing.Point(394, 257)
            Me.lblDeuda.Name = "lblDeuda"
            Me.lblDeuda.Size = New System.Drawing.Size(39, 13)
            Me.lblDeuda.TabIndex = 198
            Me.lblDeuda.Text = "Deuda"
            '
            'cboPER_CONTACTO_OP_CON
            '
            Me.cboPER_CONTACTO_OP_CON.Enabled = False
            Me.cboPER_CONTACTO_OP_CON.FormattingEnabled = True
            Me.cboPER_CONTACTO_OP_CON.Location = New System.Drawing.Point(715, 91)
            Me.cboPER_CONTACTO_OP_CON.Name = "cboPER_CONTACTO_OP_CON"
            Me.cboPER_CONTACTO_OP_CON.Size = New System.Drawing.Size(95, 21)
            Me.cboPER_CONTACTO_OP_CON.TabIndex = 16
            Me.cboPER_CONTACTO_OP_CON.Visible = False
            '
            'chkPER_CONTACTO
            '
            Me.chkPER_CONTACTO.AutoSize = True
            Me.chkPER_CONTACTO.Location = New System.Drawing.Point(664, 91)
            Me.chkPER_CONTACTO.Name = "chkPER_CONTACTO"
            Me.chkPER_CONTACTO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_CONTACTO.TabIndex = 15
            Me.chkPER_CONTACTO.UseVisualStyleBackColor = True
            '
            'lblPER_RAZON_SOCIAL
            '
            Me.lblPER_RAZON_SOCIAL.AutoSize = True
            Me.lblPER_RAZON_SOCIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_RAZON_SOCIAL.Location = New System.Drawing.Point(113, 13)
            Me.lblPER_RAZON_SOCIAL.Name = "lblPER_RAZON_SOCIAL"
            Me.lblPER_RAZON_SOCIAL.Size = New System.Drawing.Size(59, 12)
            Me.lblPER_RAZON_SOCIAL.TabIndex = 134
            Me.lblPER_RAZON_SOCIAL.Text = "Razón Social"
            '
            'lblTipoCliente
            '
            Me.lblTipoCliente.AutoSize = True
            Me.lblTipoCliente.Location = New System.Drawing.Point(19, 476)
            Me.lblTipoCliente.Name = "lblTipoCliente"
            Me.lblTipoCliente.Size = New System.Drawing.Size(62, 13)
            Me.lblTipoCliente.TabIndex = 133
            Me.lblTipoCliente.Text = "Tipo cliente"
            '
            'cboTipoCliente
            '
            Me.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoCliente.FormattingEnabled = True
            Me.cboTipoCliente.Location = New System.Drawing.Point(92, 476)
            Me.cboTipoCliente.Name = "cboTipoCliente"
            Me.cboTipoCliente.Size = New System.Drawing.Size(134, 21)
            Me.cboTipoCliente.TabIndex = 20
            '
            'tcoDatos1
            '
            Me.tcoDatos1.Controls.Add(Me.tpaEsCliente)
            Me.tcoDatos1.Controls.Add(Me.tpaEsVendedor)
            Me.tcoDatos1.Controls.Add(Me.tpaEsTransportista)
            Me.tcoDatos1.Controls.Add(Me.tpaEsBanco)
            Me.tcoDatos1.Controls.Add(Me.tpaFinanzas)
            Me.tcoDatos1.Location = New System.Drawing.Point(13, 390)
            Me.tcoDatos1.Name = "tcoDatos1"
            Me.tcoDatos1.SelectedIndex = 0
            Me.tcoDatos1.Size = New System.Drawing.Size(809, 29)
            Me.tcoDatos1.TabIndex = 130
            '
            'tpaEsCliente
            '
            Me.tpaEsCliente.Location = New System.Drawing.Point(4, 22)
            Me.tpaEsCliente.Name = "tpaEsCliente"
            Me.tpaEsCliente.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEsCliente.Size = New System.Drawing.Size(801, 3)
            Me.tpaEsCliente.TabIndex = 1
            Me.tpaEsCliente.Text = "Es cliente"
            Me.tpaEsCliente.UseVisualStyleBackColor = True
            '
            'tpaEsVendedor
            '
            Me.tpaEsVendedor.Location = New System.Drawing.Point(4, 22)
            Me.tpaEsVendedor.Name = "tpaEsVendedor"
            Me.tpaEsVendedor.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEsVendedor.Size = New System.Drawing.Size(801, 3)
            Me.tpaEsVendedor.TabIndex = 0
            Me.tpaEsVendedor.Text = "Es vendedor"
            Me.tpaEsVendedor.UseVisualStyleBackColor = True
            '
            'tpaEsTransportista
            '
            Me.tpaEsTransportista.Location = New System.Drawing.Point(4, 22)
            Me.tpaEsTransportista.Name = "tpaEsTransportista"
            Me.tpaEsTransportista.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEsTransportista.Size = New System.Drawing.Size(801, 3)
            Me.tpaEsTransportista.TabIndex = 2
            Me.tpaEsTransportista.Text = "Es transportista"
            Me.tpaEsTransportista.UseVisualStyleBackColor = True
            '
            'tpaEsBanco
            '
            Me.tpaEsBanco.Location = New System.Drawing.Point(4, 22)
            Me.tpaEsBanco.Name = "tpaEsBanco"
            Me.tpaEsBanco.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEsBanco.Size = New System.Drawing.Size(801, 3)
            Me.tpaEsBanco.TabIndex = 3
            Me.tpaEsBanco.Text = "Es banco"
            Me.tpaEsBanco.UseVisualStyleBackColor = True
            '
            'tpaFinanzas
            '
            Me.tpaFinanzas.Location = New System.Drawing.Point(4, 22)
            Me.tpaFinanzas.Name = "tpaFinanzas"
            Me.tpaFinanzas.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaFinanzas.Size = New System.Drawing.Size(801, 3)
            Me.tpaFinanzas.TabIndex = 4
            Me.tpaFinanzas.Text = "Finanzas"
            Me.tpaFinanzas.UseVisualStyleBackColor = True
            '
            'txtPER_EMAIL
            '
            Me.txtPER_EMAIL.Location = New System.Drawing.Point(84, 211)
            Me.txtPER_EMAIL.Name = "txtPER_EMAIL"
            Me.txtPER_EMAIL.Size = New System.Drawing.Size(727, 20)
            Me.txtPER_EMAIL.TabIndex = 22
            '
            'txtPER_PAGINA_WEB
            '
            Me.txtPER_PAGINA_WEB.Location = New System.Drawing.Point(84, 234)
            Me.txtPER_PAGINA_WEB.Name = "txtPER_PAGINA_WEB"
            Me.txtPER_PAGINA_WEB.Size = New System.Drawing.Size(727, 20)
            Me.txtPER_PAGINA_WEB.TabIndex = 23
            '
            'lblPER_TELEFONOS
            '
            Me.lblPER_TELEFONOS.AutoSize = True
            Me.lblPER_TELEFONOS.Location = New System.Drawing.Point(13, 186)
            Me.lblPER_TELEFONOS.Name = "lblPER_TELEFONOS"
            Me.lblPER_TELEFONOS.Size = New System.Drawing.Size(54, 13)
            Me.lblPER_TELEFONOS.TabIndex = 53
            Me.lblPER_TELEFONOS.Text = "Teléfonos"
            '
            'lblPER_EMAIL
            '
            Me.lblPER_EMAIL.AutoSize = True
            Me.lblPER_EMAIL.Location = New System.Drawing.Point(13, 211)
            Me.lblPER_EMAIL.Name = "lblPER_EMAIL"
            Me.lblPER_EMAIL.Size = New System.Drawing.Size(32, 13)
            Me.lblPER_EMAIL.TabIndex = 47
            Me.lblPER_EMAIL.Text = "Email"
            '
            'lblPER_PAGINA_WEB
            '
            Me.lblPER_PAGINA_WEB.AutoSize = True
            Me.lblPER_PAGINA_WEB.Location = New System.Drawing.Point(13, 234)
            Me.lblPER_PAGINA_WEB.Name = "lblPER_PAGINA_WEB"
            Me.lblPER_PAGINA_WEB.Size = New System.Drawing.Size(30, 13)
            Me.lblPER_PAGINA_WEB.TabIndex = 48
            Me.lblPER_PAGINA_WEB.Text = "Web"
            '
            'lblPER_FECHA_ALTA
            '
            Me.lblPER_FECHA_ALTA.AutoSize = True
            Me.lblPER_FECHA_ALTA.Location = New System.Drawing.Point(19, 257)
            Me.lblPER_FECHA_ALTA.Name = "lblPER_FECHA_ALTA"
            Me.lblPER_FECHA_ALTA.Size = New System.Drawing.Size(25, 13)
            Me.lblPER_FECHA_ALTA.TabIndex = 201
            Me.lblPER_FECHA_ALTA.Text = "Alta"
            '
            'dtpPER_FECHA_ALTA
            '
            Me.dtpPER_FECHA_ALTA.Enabled = False
            Me.dtpPER_FECHA_ALTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpPER_FECHA_ALTA.Location = New System.Drawing.Point(54, 257)
            Me.dtpPER_FECHA_ALTA.Name = "dtpPER_FECHA_ALTA"
            Me.dtpPER_FECHA_ALTA.Size = New System.Drawing.Size(97, 20)
            Me.dtpPER_FECHA_ALTA.TabIndex = 203
            '
            'lblPER_FECHA_VENC
            '
            Me.lblPER_FECHA_VENC.AutoSize = True
            Me.lblPER_FECHA_VENC.Location = New System.Drawing.Point(172, 257)
            Me.lblPER_FECHA_VENC.Name = "lblPER_FECHA_VENC"
            Me.lblPER_FECHA_VENC.Size = New System.Drawing.Size(35, 13)
            Me.lblPER_FECHA_VENC.TabIndex = 202
            Me.lblPER_FECHA_VENC.Text = "Venc."
            '
            'dtpPER_FECHA_VENC
            '
            Me.dtpPER_FECHA_VENC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpPER_FECHA_VENC.Location = New System.Drawing.Point(229, 257)
            Me.dtpPER_FECHA_VENC.Name = "dtpPER_FECHA_VENC"
            Me.dtpPER_FECHA_VENC.Size = New System.Drawing.Size(95, 20)
            Me.dtpPER_FECHA_VENC.TabIndex = 204
            '
            'lblPER_GARANTIA
            '
            Me.lblPER_GARANTIA.AutoSize = True
            Me.lblPER_GARANTIA.Location = New System.Drawing.Point(19, 280)
            Me.lblPER_GARANTIA.Name = "lblPER_GARANTIA"
            Me.lblPER_GARANTIA.Size = New System.Drawing.Size(49, 13)
            Me.lblPER_GARANTIA.TabIndex = 205
            Me.lblPER_GARANTIA.Text = "Garantía"
            '
            'txtPER_GARANTIA
            '
            Me.txtPER_GARANTIA.Location = New System.Drawing.Point(108, 280)
            Me.txtPER_GARANTIA.Name = "txtPER_GARANTIA"
            Me.txtPER_GARANTIA.Size = New System.Drawing.Size(216, 20)
            Me.txtPER_GARANTIA.TabIndex = 206
            '
            'tcoDatos
            '
            Me.tcoDatos.Controls.Add(Me.tpaMediosContacto)
            Me.tcoDatos.Controls.Add(Me.tpaDocIdentidad)
            Me.tcoDatos.Controls.Add(Me.tpaDirecciones)
            Me.tcoDatos.Controls.Add(Me.tpaContactos)
            Me.tcoDatos.Controls.Add(Me.tpaFormaVenta)
            Me.tcoDatos.Location = New System.Drawing.Point(10, 148)
            Me.tcoDatos.Name = "tcoDatos"
            Me.tcoDatos.SelectedIndex = 0
            Me.tcoDatos.Size = New System.Drawing.Size(809, 29)
            Me.tcoDatos.TabIndex = 125
            '
            'tpaMediosContacto
            '
            Me.tpaMediosContacto.Location = New System.Drawing.Point(4, 22)
            Me.tpaMediosContacto.Name = "tpaMediosContacto"
            Me.tpaMediosContacto.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaMediosContacto.Size = New System.Drawing.Size(801, 3)
            Me.tpaMediosContacto.TabIndex = 0
            Me.tpaMediosContacto.Text = "Medios de contacto"
            Me.tpaMediosContacto.UseVisualStyleBackColor = True
            '
            'tpaDocIdentidad
            '
            Me.tpaDocIdentidad.Location = New System.Drawing.Point(4, 22)
            Me.tpaDocIdentidad.Name = "tpaDocIdentidad"
            Me.tpaDocIdentidad.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaDocIdentidad.Size = New System.Drawing.Size(801, 3)
            Me.tpaDocIdentidad.TabIndex = 1
            Me.tpaDocIdentidad.Text = "Doc. de identidad"
            Me.tpaDocIdentidad.UseVisualStyleBackColor = True
            '
            'tpaDirecciones
            '
            Me.tpaDirecciones.Location = New System.Drawing.Point(4, 22)
            Me.tpaDirecciones.Name = "tpaDirecciones"
            Me.tpaDirecciones.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaDirecciones.Size = New System.Drawing.Size(801, 3)
            Me.tpaDirecciones.TabIndex = 2
            Me.tpaDirecciones.Text = "Direcciones"
            Me.tpaDirecciones.UseVisualStyleBackColor = True
            '
            'tpaContactos
            '
            Me.tpaContactos.Location = New System.Drawing.Point(4, 22)
            Me.tpaContactos.Name = "tpaContactos"
            Me.tpaContactos.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaContactos.Size = New System.Drawing.Size(801, 3)
            Me.tpaContactos.TabIndex = 5
            Me.tpaContactos.Text = "Contactos"
            Me.tpaContactos.UseVisualStyleBackColor = True
            '
            'tpaFormaVenta
            '
            Me.tpaFormaVenta.Location = New System.Drawing.Point(4, 22)
            Me.tpaFormaVenta.Name = "tpaFormaVenta"
            Me.tpaFormaVenta.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaFormaVenta.Size = New System.Drawing.Size(801, 3)
            Me.tpaFormaVenta.TabIndex = 4
            Me.tpaFormaVenta.Text = "Forma de venta"
            Me.tpaFormaVenta.UseVisualStyleBackColor = True
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(10, 7)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(29, 13)
            Me.lblPER_ID.TabIndex = 28
            Me.lblPER_ID.Text = "Cód."
            '
            'txtPER_ID
            '
            Me.txtPER_ID.BackColor = System.Drawing.SystemColors.Window
            Me.txtPER_ID.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtPER_ID.Location = New System.Drawing.Point(43, 7)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(57, 20)
            Me.txtPER_ID.TabIndex = 0
            '
            'lblPER_APE_PAT
            '
            Me.lblPER_APE_PAT.AutoSize = True
            Me.lblPER_APE_PAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_APE_PAT.Location = New System.Drawing.Point(113, 0)
            Me.lblPER_APE_PAT.Name = "lblPER_APE_PAT"
            Me.lblPER_APE_PAT.Size = New System.Drawing.Size(49, 12)
            Me.lblPER_APE_PAT.TabIndex = 30
            Me.lblPER_APE_PAT.Text = "Ape. Pat. /"
            '
            'lblPER_CARGO
            '
            Me.lblPER_CARGO.AutoSize = True
            Me.lblPER_CARGO.Location = New System.Drawing.Point(394, 451)
            Me.lblPER_CARGO.Name = "lblPER_CARGO"
            Me.lblPER_CARGO.Size = New System.Drawing.Size(35, 13)
            Me.lblPER_CARGO.TabIndex = 85
            Me.lblPER_CARGO.Text = "Cargo"
            '
            'txtPER_BONO
            '
            Me.txtPER_BONO.Location = New System.Drawing.Point(685, 426)
            Me.txtPER_BONO.Name = "txtPER_BONO"
            Me.txtPER_BONO.Size = New System.Drawing.Size(123, 20)
            Me.txtPER_BONO.TabIndex = 35
            Me.txtPER_BONO.Text = "0.00"
            Me.txtPER_BONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPER_TRANSP_PROPIO
            '
            Me.lblPER_TRANSP_PROPIO.AutoSize = True
            Me.lblPER_TRANSP_PROPIO.Location = New System.Drawing.Point(305, 119)
            Me.lblPER_TRANSP_PROPIO.Name = "lblPER_TRANSP_PROPIO"
            Me.lblPER_TRANSP_PROPIO.Size = New System.Drawing.Size(67, 13)
            Me.lblPER_TRANSP_PROPIO.TabIndex = 119
            Me.lblPER_TRANSP_PROPIO.Text = "Tipo Transp."
            '
            'lblPER_TRABAJADOR
            '
            Me.lblPER_TRABAJADOR.AutoSize = True
            Me.lblPER_TRABAJADOR.Location = New System.Drawing.Point(604, 65)
            Me.lblPER_TRABAJADOR.Name = "lblPER_TRABAJADOR"
            Me.lblPER_TRABAJADOR.Size = New System.Drawing.Size(58, 13)
            Me.lblPER_TRABAJADOR.TabIndex = 113
            Me.lblPER_TRABAJADOR.Text = "Trabajador"
            '
            'txtCCC_DESCRIPCION_CLI
            '
            Me.txtCCC_DESCRIPCION_CLI.Location = New System.Drawing.Point(108, 451)
            Me.txtCCC_DESCRIPCION_CLI.Name = "txtCCC_DESCRIPCION_CLI"
            Me.txtCCC_DESCRIPCION_CLI.Size = New System.Drawing.Size(264, 20)
            Me.txtCCC_DESCRIPCION_CLI.TabIndex = 40
            '
            'lblPER_GRUPO
            '
            Me.lblPER_GRUPO.AutoSize = True
            Me.lblPER_GRUPO.Location = New System.Drawing.Point(305, 91)
            Me.lblPER_GRUPO.Name = "lblPER_GRUPO"
            Me.lblPER_GRUPO.Size = New System.Drawing.Size(36, 13)
            Me.lblPER_GRUPO.TabIndex = 117
            Me.lblPER_GRUPO.Text = "Grupo"
            '
            'txtPER_DESCRIPCION_GRU
            '
            Me.txtPER_DESCRIPCION_GRU.Enabled = False
            Me.txtPER_DESCRIPCION_GRU.Location = New System.Drawing.Point(173, 451)
            Me.txtPER_DESCRIPCION_GRU.Name = "txtPER_DESCRIPCION_GRU"
            Me.txtPER_DESCRIPCION_GRU.ReadOnly = True
            Me.txtPER_DESCRIPCION_GRU.Size = New System.Drawing.Size(635, 20)
            Me.txtPER_DESCRIPCION_GRU.TabIndex = 54
            '
            'chkPER_TRABAJADOR
            '
            Me.chkPER_TRABAJADOR.AutoSize = True
            Me.chkPER_TRABAJADOR.Location = New System.Drawing.Point(664, 65)
            Me.chkPER_TRABAJADOR.Name = "chkPER_TRABAJADOR"
            Me.chkPER_TRABAJADOR.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_TRABAJADOR.TabIndex = 9
            Me.chkPER_TRABAJADOR.UseVisualStyleBackColor = True
            '
            'txtPER_DIAS_CREDITO
            '
            Me.txtPER_DIAS_CREDITO.Location = New System.Drawing.Point(607, 186)
            Me.txtPER_DIAS_CREDITO.Name = "txtPER_DIAS_CREDITO"
            Me.txtPER_DIAS_CREDITO.Size = New System.Drawing.Size(123, 20)
            Me.txtPER_DIAS_CREDITO.TabIndex = 26
            Me.txtPER_DIAS_CREDITO.Text = "0"
            Me.txtPER_DIAS_CREDITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPER_BANCO
            '
            Me.lblPER_BANCO.AutoSize = True
            Me.lblPER_BANCO.Location = New System.Drawing.Point(13, 91)
            Me.lblPER_BANCO.Name = "lblPER_BANCO"
            Me.lblPER_BANCO.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_BANCO.TabIndex = 116
            Me.lblPER_BANCO.Text = "Banco"
            '
            'lblPER_DIAS_CREDITO
            '
            Me.lblPER_DIAS_CREDITO.AutoSize = True
            Me.lblPER_DIAS_CREDITO.Location = New System.Drawing.Point(536, 186)
            Me.lblPER_DIAS_CREDITO.Name = "lblPER_DIAS_CREDITO"
            Me.lblPER_DIAS_CREDITO.Size = New System.Drawing.Size(65, 13)
            Me.lblPER_DIAS_CREDITO.TabIndex = 49
            Me.lblPER_DIAS_CREDITO.Text = "Días credito"
            '
            'lblPER_TRANSPORTISTA
            '
            Me.lblPER_TRANSPORTISTA.AutoSize = True
            Me.lblPER_TRANSPORTISTA.Location = New System.Drawing.Point(13, 119)
            Me.lblPER_TRANSPORTISTA.Name = "lblPER_TRANSPORTISTA"
            Me.lblPER_TRANSPORTISTA.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_TRANSPORTISTA.TabIndex = 112
            Me.lblPER_TRANSPORTISTA.Text = "Transportista"
            '
            'chkPER_TRANSPORTISTA
            '
            Me.chkPER_TRANSPORTISTA.AutoSize = True
            Me.chkPER_TRANSPORTISTA.Location = New System.Drawing.Point(84, 119)
            Me.chkPER_TRANSPORTISTA.Name = "chkPER_TRANSPORTISTA"
            Me.chkPER_TRANSPORTISTA.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_TRANSPORTISTA.TabIndex = 17
            Me.chkPER_TRANSPORTISTA.UseVisualStyleBackColor = True
            '
            'lblPER_LINEA_CREDITO
            '
            Me.lblPER_LINEA_CREDITO.AutoSize = True
            Me.lblPER_LINEA_CREDITO.Location = New System.Drawing.Point(394, 186)
            Me.lblPER_LINEA_CREDITO.Name = "lblPER_LINEA_CREDITO"
            Me.lblPER_LINEA_CREDITO.Size = New System.Drawing.Size(40, 13)
            Me.lblPER_LINEA_CREDITO.TabIndex = 54
            Me.lblPER_LINEA_CREDITO.Text = "Crédito"
            '
            'lblPER_PROVEEDOR
            '
            Me.lblPER_PROVEEDOR.AutoSize = True
            Me.lblPER_PROVEEDOR.Location = New System.Drawing.Point(305, 65)
            Me.lblPER_PROVEEDOR.Name = "lblPER_PROVEEDOR"
            Me.lblPER_PROVEEDOR.Size = New System.Drawing.Size(56, 13)
            Me.lblPER_PROVEEDOR.TabIndex = 111
            Me.lblPER_PROVEEDOR.Text = "Proveedor"
            '
            'txtPER_DESCRIPCION_BAN
            '
            Me.txtPER_DESCRIPCION_BAN.Enabled = False
            Me.txtPER_DESCRIPCION_BAN.Location = New System.Drawing.Point(173, 426)
            Me.txtPER_DESCRIPCION_BAN.Name = "txtPER_DESCRIPCION_BAN"
            Me.txtPER_DESCRIPCION_BAN.ReadOnly = True
            Me.txtPER_DESCRIPCION_BAN.Size = New System.Drawing.Size(635, 20)
            Me.txtPER_DESCRIPCION_BAN.TabIndex = 52
            '
            'chkPER_PROVEEDOR
            '
            Me.chkPER_PROVEEDOR.AutoSize = True
            Me.chkPER_PROVEEDOR.Location = New System.Drawing.Point(375, 65)
            Me.chkPER_PROVEEDOR.Name = "chkPER_PROVEEDOR"
            Me.chkPER_PROVEEDOR.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_PROVEEDOR.TabIndex = 7
            Me.chkPER_PROVEEDOR.UseVisualStyleBackColor = True
            '
            'txtPER_LINEA_CREDITO
            '
            Me.txtPER_LINEA_CREDITO.Location = New System.Drawing.Point(464, 186)
            Me.txtPER_LINEA_CREDITO.Name = "txtPER_LINEA_CREDITO"
            Me.txtPER_LINEA_CREDITO.Size = New System.Drawing.Size(62, 20)
            Me.txtPER_LINEA_CREDITO.TabIndex = 25
            Me.txtPER_LINEA_CREDITO.Text = "0.00"
            Me.txtPER_LINEA_CREDITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPER_CLIENTE
            '
            Me.lblPER_CLIENTE.AutoSize = True
            Me.lblPER_CLIENTE.Location = New System.Drawing.Point(13, 65)
            Me.lblPER_CLIENTE.Name = "lblPER_CLIENTE"
            Me.lblPER_CLIENTE.Size = New System.Drawing.Size(39, 13)
            Me.lblPER_CLIENTE.TabIndex = 110
            Me.lblPER_CLIENTE.Text = "Cliente"
            '
            'chkPER_CLIENTE
            '
            Me.chkPER_CLIENTE.AutoSize = True
            Me.chkPER_CLIENTE.Location = New System.Drawing.Point(84, 65)
            Me.chkPER_CLIENTE.Name = "chkPER_CLIENTE"
            Me.chkPER_CLIENTE.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_CLIENTE.TabIndex = 5
            Me.chkPER_CLIENTE.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_TRA
            '
            Me.txtPER_DESCRIPCION_TRA.Enabled = False
            Me.txtPER_DESCRIPCION_TRA.Location = New System.Drawing.Point(173, 426)
            Me.txtPER_DESCRIPCION_TRA.Name = "txtPER_DESCRIPCION_TRA"
            Me.txtPER_DESCRIPCION_TRA.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA.Size = New System.Drawing.Size(635, 20)
            Me.txtPER_DESCRIPCION_TRA.TabIndex = 50
            '
            'chkPER_BANCO
            '
            Me.chkPER_BANCO.AutoSize = True
            Me.chkPER_BANCO.Location = New System.Drawing.Point(84, 91)
            Me.chkPER_BANCO.Name = "chkPER_BANCO"
            Me.chkPER_BANCO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_BANCO.TabIndex = 11
            Me.chkPER_BANCO.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_COB
            '
            Me.txtPER_DESCRIPCION_COB.Enabled = False
            Me.txtPER_DESCRIPCION_COB.Location = New System.Drawing.Point(163, 476)
            Me.txtPER_DESCRIPCION_COB.Name = "txtPER_DESCRIPCION_COB"
            Me.txtPER_DESCRIPCION_COB.ReadOnly = True
            Me.txtPER_DESCRIPCION_COB.Size = New System.Drawing.Size(645, 20)
            Me.txtPER_DESCRIPCION_COB.TabIndex = 48
            '
            'chkPER_GRUPO
            '
            Me.chkPER_GRUPO.AutoSize = True
            Me.chkPER_GRUPO.Location = New System.Drawing.Point(375, 91)
            Me.chkPER_GRUPO.Name = "chkPER_GRUPO"
            Me.chkPER_GRUPO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_GRUPO.TabIndex = 13
            Me.chkPER_GRUPO.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_VEN
            '
            Me.txtPER_DESCRIPCION_VEN.Enabled = False
            Me.txtPER_DESCRIPCION_VEN.Location = New System.Drawing.Point(173, 426)
            Me.txtPER_DESCRIPCION_VEN.Name = "txtPER_DESCRIPCION_VEN"
            Me.txtPER_DESCRIPCION_VEN.ReadOnly = True
            Me.txtPER_DESCRIPCION_VEN.Size = New System.Drawing.Size(635, 20)
            Me.txtPER_DESCRIPCION_VEN.TabIndex = 46
            '
            'cboPER_CLIENTE_OP_CON
            '
            Me.cboPER_CLIENTE_OP_CON.FormattingEnabled = True
            Me.cboPER_CLIENTE_OP_CON.Location = New System.Drawing.Point(129, 65)
            Me.cboPER_CLIENTE_OP_CON.Name = "cboPER_CLIENTE_OP_CON"
            Me.cboPER_CLIENTE_OP_CON.Size = New System.Drawing.Size(123, 21)
            Me.cboPER_CLIENTE_OP_CON.TabIndex = 6
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(477, 30)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(34, 12)
            Me.lblPER_ESTADO.TabIndex = 102
            Me.lblPER_ESTADO.Text = "Estado"
            '
            'cboPER_PROVEEDOR_OP_CON
            '
            Me.cboPER_PROVEEDOR_OP_CON.FormattingEnabled = True
            Me.cboPER_PROVEEDOR_OP_CON.Location = New System.Drawing.Point(419, 65)
            Me.cboPER_PROVEEDOR_OP_CON.Name = "cboPER_PROVEEDOR_OP_CON"
            Me.cboPER_PROVEEDOR_OP_CON.Size = New System.Drawing.Size(123, 21)
            Me.cboPER_PROVEEDOR_OP_CON.TabIndex = 8
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(531, 30)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 4
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'cboPER_TRANSPORTISTA_OP_CON
            '
            Me.cboPER_TRANSPORTISTA_OP_CON.FormattingEnabled = True
            Me.cboPER_TRANSPORTISTA_OP_CON.Location = New System.Drawing.Point(129, 119)
            Me.cboPER_TRANSPORTISTA_OP_CON.Name = "cboPER_TRANSPORTISTA_OP_CON"
            Me.cboPER_TRANSPORTISTA_OP_CON.Size = New System.Drawing.Size(123, 21)
            Me.cboPER_TRANSPORTISTA_OP_CON.TabIndex = 18
            '
            'cboPER_TRABAJADOR_OP_CON
            '
            Me.cboPER_TRABAJADOR_OP_CON.FormattingEnabled = True
            Me.cboPER_TRABAJADOR_OP_CON.Location = New System.Drawing.Point(715, 65)
            Me.cboPER_TRABAJADOR_OP_CON.Name = "cboPER_TRABAJADOR_OP_CON"
            Me.cboPER_TRABAJADOR_OP_CON.Size = New System.Drawing.Size(95, 21)
            Me.cboPER_TRABAJADOR_OP_CON.TabIndex = 10
            '
            'lblPER_FIRMA_AUT
            '
            Me.lblPER_FIRMA_AUT.AutoSize = True
            Me.lblPER_FIRMA_AUT.Location = New System.Drawing.Point(299, 426)
            Me.lblPER_FIRMA_AUT.Name = "lblPER_FIRMA_AUT"
            Me.lblPER_FIRMA_AUT.Size = New System.Drawing.Size(54, 13)
            Me.lblPER_FIRMA_AUT.TabIndex = 100
            Me.lblPER_FIRMA_AUT.Text = "Firma Aut."
            '
            'cboPER_BANCO_OP_CON
            '
            Me.cboPER_BANCO_OP_CON.FormattingEnabled = True
            Me.cboPER_BANCO_OP_CON.Location = New System.Drawing.Point(129, 91)
            Me.cboPER_BANCO_OP_CON.Name = "cboPER_BANCO_OP_CON"
            Me.cboPER_BANCO_OP_CON.Size = New System.Drawing.Size(123, 21)
            Me.cboPER_BANCO_OP_CON.TabIndex = 12
            '
            'lblPER_REP_LEGAL
            '
            Me.lblPER_REP_LEGAL.AutoSize = True
            Me.lblPER_REP_LEGAL.Location = New System.Drawing.Point(19, 426)
            Me.lblPER_REP_LEGAL.Name = "lblPER_REP_LEGAL"
            Me.lblPER_REP_LEGAL.Size = New System.Drawing.Size(59, 13)
            Me.lblPER_REP_LEGAL.TabIndex = 99
            Me.lblPER_REP_LEGAL.Text = "Rep. Legal"
            '
            'cboPER_GRUPO_OP_CON
            '
            Me.cboPER_GRUPO_OP_CON.FormattingEnabled = True
            Me.cboPER_GRUPO_OP_CON.Location = New System.Drawing.Point(419, 91)
            Me.cboPER_GRUPO_OP_CON.Name = "cboPER_GRUPO_OP_CON"
            Me.cboPER_GRUPO_OP_CON.Size = New System.Drawing.Size(123, 21)
            Me.cboPER_GRUPO_OP_CON.TabIndex = 14
            '
            'chkPER_FIRMA_AUT
            '
            Me.chkPER_FIRMA_AUT.AutoSize = True
            Me.chkPER_FIRMA_AUT.Location = New System.Drawing.Point(357, 426)
            Me.chkPER_FIRMA_AUT.Name = "chkPER_FIRMA_AUT"
            Me.chkPER_FIRMA_AUT.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_FIRMA_AUT.TabIndex = 37
            Me.chkPER_FIRMA_AUT.UseVisualStyleBackColor = True
            '
            'chkPER_REP_LEGAL
            '
            Me.chkPER_REP_LEGAL.AutoSize = True
            Me.chkPER_REP_LEGAL.Location = New System.Drawing.Point(82, 426)
            Me.chkPER_REP_LEGAL.Name = "chkPER_REP_LEGAL"
            Me.chkPER_REP_LEGAL.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_REP_LEGAL.TabIndex = 36
            Me.chkPER_REP_LEGAL.UseVisualStyleBackColor = True
            '
            'cboPER_TRANSP_PROPIO
            '
            Me.cboPER_TRANSP_PROPIO.FormattingEnabled = True
            Me.cboPER_TRANSP_PROPIO.Location = New System.Drawing.Point(375, 119)
            Me.cboPER_TRANSP_PROPIO.Name = "cboPER_TRANSP_PROPIO"
            Me.cboPER_TRANSP_PROPIO.Size = New System.Drawing.Size(167, 21)
            Me.cboPER_TRANSP_PROPIO.TabIndex = 19
            '
            'txtPER_CARGO
            '
            Me.txtPER_CARGO.Location = New System.Drawing.Point(467, 451)
            Me.txtPER_CARGO.Name = "txtPER_CARGO"
            Me.txtPER_CARGO.Size = New System.Drawing.Size(341, 20)
            Me.txtPER_CARGO.TabIndex = 41
            '
            'txtCCC_ID_CLI
            '
            Me.txtCCC_ID_CLI.Location = New System.Drawing.Point(69, 451)
            Me.txtCCC_ID_CLI.Name = "txtCCC_ID_CLI"
            Me.txtCCC_ID_CLI.Size = New System.Drawing.Size(37, 20)
            Me.txtCCC_ID_CLI.TabIndex = 39
            '
            'lblPER_BONO
            '
            Me.lblPER_BONO.AutoSize = True
            Me.lblPER_BONO.Location = New System.Drawing.Point(650, 426)
            Me.lblPER_BONO.Name = "lblPER_BONO"
            Me.lblPER_BONO.Size = New System.Drawing.Size(32, 13)
            Me.lblPER_BONO.TabIndex = 90
            Me.lblPER_BONO.Text = "Bono"
            '
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(19, 451)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblCCC_ID.TabIndex = 89
            Me.lblCCC_ID.Text = "Cta. Cte."
            '
            'txtPER_CUOTA_OBJETIVO
            '
            Me.txtPER_CUOTA_OBJETIVO.Location = New System.Drawing.Point(409, 426)
            Me.txtPER_CUOTA_OBJETIVO.Name = "txtPER_CUOTA_OBJETIVO"
            Me.txtPER_CUOTA_OBJETIVO.Size = New System.Drawing.Size(123, 20)
            Me.txtPER_CUOTA_OBJETIVO.TabIndex = 34
            Me.txtPER_CUOTA_OBJETIVO.Text = "0.00"
            Me.txtPER_CUOTA_OBJETIVO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'cboPER_CARTA_FIANZA
            '
            Me.cboPER_CARTA_FIANZA.FormattingEnabled = True
            Me.cboPER_CARTA_FIANZA.Location = New System.Drawing.Point(464, 234)
            Me.cboPER_CARTA_FIANZA.Name = "cboPER_CARTA_FIANZA"
            Me.cboPER_CARTA_FIANZA.Size = New System.Drawing.Size(347, 21)
            Me.cboPER_CARTA_FIANZA.TabIndex = 32
            '
            'chkPER_PROMOCIONES
            '
            Me.chkPER_PROMOCIONES.AutoSize = True
            Me.chkPER_PROMOCIONES.Location = New System.Drawing.Point(638, 426)
            Me.chkPER_PROMOCIONES.Name = "chkPER_PROMOCIONES"
            Me.chkPER_PROMOCIONES.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_PROMOCIONES.TabIndex = 38
            Me.chkPER_PROMOCIONES.UseVisualStyleBackColor = True
            '
            'lblPER_CUOTA_OBJETIVO
            '
            Me.lblPER_CUOTA_OBJETIVO.AutoSize = True
            Me.lblPER_CUOTA_OBJETIVO.Location = New System.Drawing.Point(327, 426)
            Me.lblPER_CUOTA_OBJETIVO.Name = "lblPER_CUOTA_OBJETIVO"
            Me.lblPER_CUOTA_OBJETIVO.Size = New System.Drawing.Size(75, 13)
            Me.lblPER_CUOTA_OBJETIVO.TabIndex = 84
            Me.lblPER_CUOTA_OBJETIVO.Text = "Cuota objetivo"
            '
            'lblPER_CUOTA_MENSUAL
            '
            Me.lblPER_CUOTA_MENSUAL.AutoSize = True
            Me.lblPER_CUOTA_MENSUAL.Location = New System.Drawing.Point(19, 426)
            Me.lblPER_CUOTA_MENSUAL.Name = "lblPER_CUOTA_MENSUAL"
            Me.lblPER_CUOTA_MENSUAL.Size = New System.Drawing.Size(77, 13)
            Me.lblPER_CUOTA_MENSUAL.TabIndex = 83
            Me.lblPER_CUOTA_MENSUAL.Text = "Cuota mensual"
            '
            'lblPER_CARTA_FIANZA
            '
            Me.lblPER_CARTA_FIANZA.AutoSize = True
            Me.lblPER_CARTA_FIANZA.Location = New System.Drawing.Point(394, 234)
            Me.lblPER_CARTA_FIANZA.Name = "lblPER_CARTA_FIANZA"
            Me.lblPER_CARTA_FIANZA.Size = New System.Drawing.Size(63, 13)
            Me.lblPER_CARTA_FIANZA.TabIndex = 82
            Me.lblPER_CARTA_FIANZA.Text = "Carta fianza"
            '
            'lblPER_PROMOCIONES
            '
            Me.lblPER_PROMOCIONES.AutoSize = True
            Me.lblPER_PROMOCIONES.Location = New System.Drawing.Point(563, 426)
            Me.lblPER_PROMOCIONES.Name = "lblPER_PROMOCIONES"
            Me.lblPER_PROMOCIONES.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_PROMOCIONES.TabIndex = 81
            Me.lblPER_PROMOCIONES.Text = "Promociones"
            '
            'lblPER_OBSERVACIONES
            '
            Me.lblPER_OBSERVACIONES.AutoSize = True
            Me.lblPER_OBSERVACIONES.Location = New System.Drawing.Point(11, 513)
            Me.lblPER_OBSERVACIONES.Name = "lblPER_OBSERVACIONES"
            Me.lblPER_OBSERVACIONES.Size = New System.Drawing.Size(78, 13)
            Me.lblPER_OBSERVACIONES.TabIndex = 80
            Me.lblPER_OBSERVACIONES.Text = "Observaciones"
            '
            'cboPER_DOC_PAGO
            '
            Me.cboPER_DOC_PAGO.FormattingEnabled = True
            Me.cboPER_DOC_PAGO.Location = New System.Drawing.Point(576, 211)
            Me.cboPER_DOC_PAGO.Name = "cboPER_DOC_PAGO"
            Me.cboPER_DOC_PAGO.Size = New System.Drawing.Size(235, 21)
            Me.cboPER_DOC_PAGO.TabIndex = 30
            '
            'cboPER_COND_DIASEM
            '
            Me.cboPER_COND_DIASEM.FormattingEnabled = True
            Me.cboPER_COND_DIASEM.Location = New System.Drawing.Point(229, 211)
            Me.cboPER_COND_DIASEM.Name = "cboPER_COND_DIASEM"
            Me.cboPER_COND_DIASEM.Size = New System.Drawing.Size(149, 21)
            Me.cboPER_COND_DIASEM.TabIndex = 28
            '
            'cboPER_DIASEM_PAGO
            '
            Me.cboPER_DIASEM_PAGO.FormattingEnabled = True
            Me.cboPER_DIASEM_PAGO.Location = New System.Drawing.Point(54, 211)
            Me.cboPER_DIASEM_PAGO.Name = "cboPER_DIASEM_PAGO"
            Me.cboPER_DIASEM_PAGO.Size = New System.Drawing.Size(97, 21)
            Me.cboPER_DIASEM_PAGO.TabIndex = 27
            '
            'lblPER_HORA_PAGO
            '
            Me.lblPER_HORA_PAGO.AutoSize = True
            Me.lblPER_HORA_PAGO.Location = New System.Drawing.Point(19, 234)
            Me.lblPER_HORA_PAGO.Name = "lblPER_HORA_PAGO"
            Me.lblPER_HORA_PAGO.Size = New System.Drawing.Size(30, 13)
            Me.lblPER_HORA_PAGO.TabIndex = 76
            Me.lblPER_HORA_PAGO.Text = "Hora"
            '
            'lblPER_DOC_PAGO
            '
            Me.lblPER_DOC_PAGO.AutoSize = True
            Me.lblPER_DOC_PAGO.Location = New System.Drawing.Point(536, 211)
            Me.lblPER_DOC_PAGO.Name = "lblPER_DOC_PAGO"
            Me.lblPER_DOC_PAGO.Size = New System.Drawing.Size(30, 13)
            Me.lblPER_DOC_PAGO.TabIndex = 75
            Me.lblPER_DOC_PAGO.Text = "Doc."
            '
            'lblPER_DIASEM_PAGO
            '
            Me.lblPER_DIASEM_PAGO.AutoSize = True
            Me.lblPER_DIASEM_PAGO.Location = New System.Drawing.Point(19, 211)
            Me.lblPER_DIASEM_PAGO.Name = "lblPER_DIASEM_PAGO"
            Me.lblPER_DIASEM_PAGO.Size = New System.Drawing.Size(25, 13)
            Me.lblPER_DIASEM_PAGO.TabIndex = 74
            Me.lblPER_DIASEM_PAGO.Text = "Día"
            '
            'lblPER_ID_BAN
            '
            Me.lblPER_ID_BAN.AutoSize = True
            Me.lblPER_ID_BAN.Location = New System.Drawing.Point(19, 426)
            Me.lblPER_ID_BAN.Name = "lblPER_ID_BAN"
            Me.lblPER_ID_BAN.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_ID_BAN.TabIndex = 73
            Me.lblPER_ID_BAN.Text = "Banco"
            '
            'lblPER_ID_TRA
            '
            Me.lblPER_ID_TRA.AutoSize = True
            Me.lblPER_ID_TRA.Location = New System.Drawing.Point(19, 426)
            Me.lblPER_ID_TRA.Name = "lblPER_ID_TRA"
            Me.lblPER_ID_TRA.Size = New System.Drawing.Size(73, 13)
            Me.lblPER_ID_TRA.TabIndex = 72
            Me.lblPER_ID_TRA.Text = "Transporstista"
            '
            'lblPER_ID_GRU
            '
            Me.lblPER_ID_GRU.AutoSize = True
            Me.lblPER_ID_GRU.Location = New System.Drawing.Point(19, 451)
            Me.lblPER_ID_GRU.Name = "lblPER_ID_GRU"
            Me.lblPER_ID_GRU.Size = New System.Drawing.Size(36, 13)
            Me.lblPER_ID_GRU.TabIndex = 71
            Me.lblPER_ID_GRU.Text = "Grupo"
            '
            'txtPER_CUOTA_MENSUAL
            '
            Me.txtPER_CUOTA_MENSUAL.Location = New System.Drawing.Point(103, 426)
            Me.txtPER_CUOTA_MENSUAL.Name = "txtPER_CUOTA_MENSUAL"
            Me.txtPER_CUOTA_MENSUAL.Size = New System.Drawing.Size(123, 20)
            Me.txtPER_CUOTA_MENSUAL.TabIndex = 33
            Me.txtPER_CUOTA_MENSUAL.Text = "0.00"
            Me.txtPER_CUOTA_MENSUAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtPER_OBSERVACIONES
            '
            Me.txtPER_OBSERVACIONES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_OBSERVACIONES.ForeColor = System.Drawing.Color.Red
            Me.txtPER_OBSERVACIONES.Location = New System.Drawing.Point(93, 513)
            Me.txtPER_OBSERVACIONES.Multiline = True
            Me.txtPER_OBSERVACIONES.Name = "txtPER_OBSERVACIONES"
            Me.txtPER_OBSERVACIONES.Size = New System.Drawing.Size(731, 48)
            Me.txtPER_OBSERVACIONES.TabIndex = 55
            '
            'txtPER_HORA_PAGO
            '
            Me.txtPER_HORA_PAGO.Location = New System.Drawing.Point(54, 234)
            Me.txtPER_HORA_PAGO.Name = "txtPER_HORA_PAGO"
            Me.txtPER_HORA_PAGO.Size = New System.Drawing.Size(324, 20)
            Me.txtPER_HORA_PAGO.TabIndex = 31
            '
            'txtPER_DIAMES_PAGO
            '
            Me.txtPER_DIAMES_PAGO.Location = New System.Drawing.Point(464, 211)
            Me.txtPER_DIAMES_PAGO.Name = "txtPER_DIAMES_PAGO"
            Me.txtPER_DIAMES_PAGO.Size = New System.Drawing.Size(29, 20)
            Me.txtPER_DIAMES_PAGO.TabIndex = 29
            Me.txtPER_DIAMES_PAGO.Text = "1"
            Me.txtPER_DIAMES_PAGO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtPER_ID_GRU
            '
            Me.txtPER_ID_GRU.Location = New System.Drawing.Point(92, 451)
            Me.txtPER_ID_GRU.Name = "txtPER_ID_GRU"
            Me.txtPER_ID_GRU.Size = New System.Drawing.Size(70, 20)
            Me.txtPER_ID_GRU.TabIndex = 53
            '
            'txtPER_ID_BAN
            '
            Me.txtPER_ID_BAN.Location = New System.Drawing.Point(92, 426)
            Me.txtPER_ID_BAN.Name = "txtPER_ID_BAN"
            Me.txtPER_ID_BAN.Size = New System.Drawing.Size(78, 20)
            Me.txtPER_ID_BAN.TabIndex = 51
            '
            'txtPER_ID_TRA
            '
            Me.txtPER_ID_TRA.Location = New System.Drawing.Point(92, 426)
            Me.txtPER_ID_TRA.Name = "txtPER_ID_TRA"
            Me.txtPER_ID_TRA.Size = New System.Drawing.Size(78, 20)
            Me.txtPER_ID_TRA.TabIndex = 49
            '
            'txtPER_ID_COB
            '
            Me.txtPER_ID_COB.Location = New System.Drawing.Point(82, 476)
            Me.txtPER_ID_COB.Name = "txtPER_ID_COB"
            Me.txtPER_ID_COB.Size = New System.Drawing.Size(70, 20)
            Me.txtPER_ID_COB.TabIndex = 47
            '
            'txtPER_ID_VEN
            '
            Me.txtPER_ID_VEN.Location = New System.Drawing.Point(92, 426)
            Me.txtPER_ID_VEN.Name = "txtPER_ID_VEN"
            Me.txtPER_ID_VEN.Size = New System.Drawing.Size(70, 20)
            Me.txtPER_ID_VEN.TabIndex = 45
            '
            'lblPER_ID_COB
            '
            Me.lblPER_ID_COB.AutoSize = True
            Me.lblPER_ID_COB.Location = New System.Drawing.Point(19, 476)
            Me.lblPER_ID_COB.Name = "lblPER_ID_COB"
            Me.lblPER_ID_COB.Size = New System.Drawing.Size(50, 13)
            Me.lblPER_ID_COB.TabIndex = 55
            Me.lblPER_ID_COB.Text = "Cobrador"
            '
            'lblPER_DIAMES_PAGO
            '
            Me.lblPER_DIAMES_PAGO.AutoSize = True
            Me.lblPER_DIAMES_PAGO.Location = New System.Drawing.Point(394, 211)
            Me.lblPER_DIAMES_PAGO.Name = "lblPER_DIAMES_PAGO"
            Me.lblPER_DIAMES_PAGO.Size = New System.Drawing.Size(47, 13)
            Me.lblPER_DIAMES_PAGO.TabIndex = 52
            Me.lblPER_DIAMES_PAGO.Text = "Día mes"
            '
            'lblPER_COND_DIASEM
            '
            Me.lblPER_COND_DIASEM.AutoSize = True
            Me.lblPER_COND_DIASEM.Location = New System.Drawing.Point(172, 211)
            Me.lblPER_COND_DIASEM.Name = "lblPER_COND_DIASEM"
            Me.lblPER_COND_DIASEM.Size = New System.Drawing.Size(54, 13)
            Me.lblPER_COND_DIASEM.TabIndex = 51
            Me.lblPER_COND_DIASEM.Text = "Condición"
            '
            'lblPER_ID_VEN
            '
            Me.lblPER_ID_VEN.AutoSize = True
            Me.lblPER_ID_VEN.Location = New System.Drawing.Point(19, 426)
            Me.lblPER_ID_VEN.Name = "lblPER_ID_VEN"
            Me.lblPER_ID_VEN.Size = New System.Drawing.Size(53, 13)
            Me.lblPER_ID_VEN.TabIndex = 50
            Me.lblPER_ID_VEN.Text = "Vendedor"
            '
            'cboPER_FORMA_VENTA
            '
            Me.cboPER_FORMA_VENTA.FormattingEnabled = True
            Me.cboPER_FORMA_VENTA.Location = New System.Drawing.Point(111, 186)
            Me.cboPER_FORMA_VENTA.Name = "cboPER_FORMA_VENTA"
            Me.cboPER_FORMA_VENTA.Size = New System.Drawing.Size(267, 21)
            Me.cboPER_FORMA_VENTA.TabIndex = 24
            '
            'txtPER_BREVETE
            '
            Me.txtPER_BREVETE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_BREVETE.Location = New System.Drawing.Point(92, 451)
            Me.txtPER_BREVETE.Name = "txtPER_BREVETE"
            Me.txtPER_BREVETE.Size = New System.Drawing.Size(100, 20)
            Me.txtPER_BREVETE.TabIndex = 20
            '
            'txtPER_APE_PAT
            '
            Me.txtPER_APE_PAT.BackColor = System.Drawing.SystemColors.Window
            Me.txtPER_APE_PAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_APE_PAT.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtPER_APE_PAT.Location = New System.Drawing.Point(173, 7)
            Me.txtPER_APE_PAT.Name = "txtPER_APE_PAT"
            Me.txtPER_APE_PAT.Size = New System.Drawing.Size(289, 20)
            Me.txtPER_APE_PAT.TabIndex = 1
            '
            'lblPER_BREVETE
            '
            Me.lblPER_BREVETE.AutoSize = True
            Me.lblPER_BREVETE.Location = New System.Drawing.Point(19, 451)
            Me.lblPER_BREVETE.Name = "lblPER_BREVETE"
            Me.lblPER_BREVETE.Size = New System.Drawing.Size(44, 13)
            Me.lblPER_BREVETE.TabIndex = 26
            Me.lblPER_BREVETE.Text = "Brevete"
            '
            'lblPER_FORMA_VENTA
            '
            Me.lblPER_FORMA_VENTA.AutoSize = True
            Me.lblPER_FORMA_VENTA.Location = New System.Drawing.Point(19, 186)
            Me.lblPER_FORMA_VENTA.Name = "lblPER_FORMA_VENTA"
            Me.lblPER_FORMA_VENTA.Size = New System.Drawing.Size(81, 13)
            Me.lblPER_FORMA_VENTA.TabIndex = 20
            Me.lblPER_FORMA_VENTA.Text = "Forma de venta"
            '
            'lblPER_APE_MAT
            '
            Me.lblPER_APE_MAT.AutoSize = True
            Me.lblPER_APE_MAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_APE_MAT.Location = New System.Drawing.Point(477, 7)
            Me.lblPER_APE_MAT.Name = "lblPER_APE_MAT"
            Me.lblPER_APE_MAT.Size = New System.Drawing.Size(47, 12)
            Me.lblPER_APE_MAT.TabIndex = 0
            Me.lblPER_APE_MAT.Text = "Ape. Mat."
            '
            'lblPER_NOMBRES
            '
            Me.lblPER_NOMBRES.AutoSize = True
            Me.lblPER_NOMBRES.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_NOMBRES.Location = New System.Drawing.Point(113, 30)
            Me.lblPER_NOMBRES.Name = "lblPER_NOMBRES"
            Me.lblPER_NOMBRES.Size = New System.Drawing.Size(43, 12)
            Me.lblPER_NOMBRES.TabIndex = 1
            Me.lblPER_NOMBRES.Text = "Nombres"
            '
            'txtPER_APE_MAT
            '
            Me.txtPER_APE_MAT.BackColor = System.Drawing.SystemColors.Window
            Me.txtPER_APE_MAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_APE_MAT.Location = New System.Drawing.Point(531, 7)
            Me.txtPER_APE_MAT.Name = "txtPER_APE_MAT"
            Me.txtPER_APE_MAT.Size = New System.Drawing.Size(289, 20)
            Me.txtPER_APE_MAT.TabIndex = 2
            '
            'txtPER_NOMBRES
            '
            Me.txtPER_NOMBRES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_NOMBRES.Location = New System.Drawing.Point(173, 30)
            Me.txtPER_NOMBRES.Name = "txtPER_NOMBRES"
            Me.txtPER_NOMBRES.Size = New System.Drawing.Size(289, 20)
            Me.txtPER_NOMBRES.TabIndex = 3
            '
            'gbDatosTipo
            '
            Me.gbDatosTipo.Controls.Add(Me.lblPER_CONTACTO)
            Me.gbDatosTipo.Location = New System.Drawing.Point(10, 50)
            Me.gbDatosTipo.Name = "gbDatosTipo"
            Me.gbDatosTipo.Size = New System.Drawing.Size(814, 94)
            Me.gbDatosTipo.TabIndex = 120
            Me.gbDatosTipo.TabStop = False
            Me.gbDatosTipo.Text = "Tipo"
            '
            'lblPER_CONTACTO
            '
            Me.lblPER_CONTACTO.Location = New System.Drawing.Point(594, 41)
            Me.lblPER_CONTACTO.Name = "lblPER_CONTACTO"
            Me.lblPER_CONTACTO.Size = New System.Drawing.Size(60, 41)
            Me.lblPER_CONTACTO.TabIndex = 118
            Me.lblPER_CONTACTO.Text = "Promotor"
            '
            'gbDatosGenerales
            '
            Me.gbDatosGenerales.Location = New System.Drawing.Point(10, 172)
            Me.gbDatosGenerales.Name = "gbDatosGenerales"
            Me.gbDatosGenerales.Size = New System.Drawing.Size(814, 210)
            Me.gbDatosGenerales.TabIndex = 121
            Me.gbDatosGenerales.TabStop = False
            Me.gbDatosGenerales.Text = "-"
            '
            'gbDatosVendedores
            '
            Me.gbDatosVendedores.Location = New System.Drawing.Point(10, 414)
            Me.gbDatosVendedores.Name = "gbDatosVendedores"
            Me.gbDatosVendedores.Size = New System.Drawing.Size(814, 90)
            Me.gbDatosVendedores.TabIndex = 124
            Me.gbDatosVendedores.TabStop = False
            Me.gbDatosVendedores.Text = "-"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(814, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(56, 28)
            Me.btnImagen.TabIndex = 33
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'lblDIS_ID
            '
            Me.lblDIS_ID.AutoSize = True
            Me.lblDIS_ID.Location = New System.Drawing.Point(13, 14)
            Me.lblDIS_ID.Name = "lblDIS_ID"
            Me.lblDIS_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblDIS_ID.TabIndex = 28
            Me.lblDIS_ID.Text = "Código"
            '
            'frmPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(909, 628)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmPersonas"
            Me.Text = "Personas"
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDireccionPersona, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDocIdentidad, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvContactoPersona, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcoDatos1.ResumeLayout(False)
            Me.tcoDatos.ResumeLayout(False)
            Me.gbDatosTipo.ResumeLayout(False)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_APE_PAT As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_APE_PAT As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_BREVETE As System.Windows.Forms.Label
        Friend WithEvents lblPER_FORMA_VENTA As System.Windows.Forms.Label
        Friend WithEvents lblPER_APE_MAT As System.Windows.Forms.Label
        Friend WithEvents lblPER_NOMBRES As System.Windows.Forms.Label
        Public WithEvents txtPER_APE_MAT As System.Windows.Forms.TextBox
        Public WithEvents txtPER_NOMBRES As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblDIS_ID As System.Windows.Forms.Label
        Public WithEvents txtPER_BREVETE As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_COB As System.Windows.Forms.Label
        Friend WithEvents lblPER_LINEA_CREDITO As System.Windows.Forms.Label
        Friend WithEvents lblPER_TELEFONOS As System.Windows.Forms.Label
        Friend WithEvents lblPER_DIAMES_PAGO As System.Windows.Forms.Label
        Friend WithEvents lblPER_COND_DIASEM As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_VEN As System.Windows.Forms.Label
        Friend WithEvents lblPER_DIAS_CREDITO As System.Windows.Forms.Label
        Friend WithEvents lblPER_PAGINA_WEB As System.Windows.Forms.Label
        Friend WithEvents lblPER_EMAIL As System.Windows.Forms.Label
        Friend WithEvents lblPER_HORA_PAGO As System.Windows.Forms.Label
        Friend WithEvents lblPER_DOC_PAGO As System.Windows.Forms.Label
        Friend WithEvents lblPER_DIASEM_PAGO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_BAN As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_TRA As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_GRU As System.Windows.Forms.Label
        Friend WithEvents lblPER_CARGO As System.Windows.Forms.Label
        Friend WithEvents lblPER_CUOTA_OBJETIVO As System.Windows.Forms.Label
        Friend WithEvents lblPER_CUOTA_MENSUAL As System.Windows.Forms.Label
        Friend WithEvents lblPER_CARTA_FIANZA As System.Windows.Forms.Label
        Friend WithEvents lblPER_PROMOCIONES As System.Windows.Forms.Label
        Friend WithEvents lblPER_OBSERVACIONES As System.Windows.Forms.Label
        Friend WithEvents lblPER_BONO As System.Windows.Forms.Label
        Friend WithEvents lblCCC_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPER_FIRMA_AUT As System.Windows.Forms.Label
        Friend WithEvents lblPER_REP_LEGAL As System.Windows.Forms.Label
        Public WithEvents cboPER_FORMA_VENTA As System.Windows.Forms.ComboBox
        Public WithEvents txtPER_CUOTA_MENSUAL As System.Windows.Forms.TextBox
        Public WithEvents txtPER_OBSERVACIONES As System.Windows.Forms.TextBox
        Public WithEvents txtPER_HORA_PAGO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DIAMES_PAGO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_GRU As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_BAN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_TRA As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_COB As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_EMAIL As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DIAS_CREDITO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_LINEA_CREDITO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_PAGINA_WEB As System.Windows.Forms.TextBox
        Public WithEvents txtPER_TELEFONOS As System.Windows.Forms.TextBox
        Public WithEvents cboPER_DOC_PAGO As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_COND_DIASEM As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_DIASEM_PAGO As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_CARTA_FIANZA As System.Windows.Forms.ComboBox
        Public WithEvents chkPER_PROMOCIONES As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_CUOTA_OBJETIVO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_CARGO As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_ID_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtPER_BONO As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_FIRMA_AUT As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_REP_LEGAL As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_COB As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_TRA As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_BAN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_GRU As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_TRANSP_PROPIO As System.Windows.Forms.Label
        Friend WithEvents lblPER_CONTACTO As System.Windows.Forms.Label
        Friend WithEvents lblPER_TRABAJADOR As System.Windows.Forms.Label
        Friend WithEvents lblPER_GRUPO As System.Windows.Forms.Label
        Public WithEvents chkPER_TRABAJADOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_BANCO As System.Windows.Forms.Label
        Friend WithEvents lblPER_TRANSPORTISTA As System.Windows.Forms.Label
        Public WithEvents chkPER_TRANSPORTISTA As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_PROVEEDOR As System.Windows.Forms.Label
        Public WithEvents chkPER_PROVEEDOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_CLIENTE As System.Windows.Forms.Label
        Public WithEvents chkPER_CLIENTE As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_BANCO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_GRUPO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_CONTACTO As System.Windows.Forms.CheckBox
        Public WithEvents cboPER_CLIENTE_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_PROVEEDOR_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_TRANSPORTISTA_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_TRABAJADOR_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_BANCO_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_GRUPO_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_CONTACTO_OP_CON As System.Windows.Forms.ComboBox
        Public WithEvents cboPER_TRANSP_PROPIO As System.Windows.Forms.ComboBox
        Friend WithEvents gbDatosTipo As System.Windows.Forms.GroupBox
        Friend WithEvents gbDatosGenerales As System.Windows.Forms.GroupBox
        Friend WithEvents gbDatosVendedores As System.Windows.Forms.GroupBox
        Friend WithEvents tcoDatos As System.Windows.Forms.TabControl
        Friend WithEvents tpaMediosContacto As System.Windows.Forms.TabPage
        Friend WithEvents tpaDocIdentidad As System.Windows.Forms.TabPage
        Friend WithEvents tpaDirecciones As System.Windows.Forms.TabPage
        Friend WithEvents dgvDocIdentidad As System.Windows.Forms.DataGridView
        Friend WithEvents tpaFormaVenta As System.Windows.Forms.TabPage
        Friend WithEvents tcoDatos1 As System.Windows.Forms.TabControl
        Friend WithEvents tpaEsVendedor As System.Windows.Forms.TabPage
        Friend WithEvents tpaEsCliente As System.Windows.Forms.TabPage
        Friend WithEvents tpaEsTransportista As System.Windows.Forms.TabPage
        Friend WithEvents tpaEsBanco As System.Windows.Forms.TabPage
        Friend WithEvents tpaFinanzas As System.Windows.Forms.TabPage
        Friend WithEvents cItem As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOP_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_LONGITUD As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_COD_SUNAT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDOP_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents dgvDireccionPersona As System.Windows.Forms.DataGridView
        Friend WithEvents cItem1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_TIPO1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_DESCRIPCION1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_REFERENCIA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDIR_ESTADO1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tpaContactos As System.Windows.Forms.TabPage
        Public WithEvents dgvContactoPersona As System.Windows.Forms.DataGridView
        Public WithEvents cboTipoCliente As System.Windows.Forms.ComboBox
        Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
        Friend WithEvents cItem2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_TIPO2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_DESCRIPCION2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_DIRECCION2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_TELEFONO2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_EMAIL2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCOP_ESTADO2 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lblPER_RAZON_SOCIAL As System.Windows.Forms.Label
        Friend WithEvents lblDeuda As System.Windows.Forms.Label
        Public WithEvents txtDeuda As System.Windows.Forms.TextBox
        Friend WithEvents lblDisponible As System.Windows.Forms.Label
        Public WithEvents txtDisponible As System.Windows.Forms.TextBox
        Friend WithEvents dgvSaldos As System.Windows.Forms.DataGridView
        Public WithEvents chkPER_LINEA_CREDITO_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_GARANTIA As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_GARANTIA As System.Windows.Forms.Label
        Friend WithEvents lblPER_FECHA_VENC As System.Windows.Forms.Label
        Friend WithEvents lblPER_FECHA_ALTA As System.Windows.Forms.Label
        Public WithEvents dtpPER_FECHA_VENC As System.Windows.Forms.DateTimePicker
        Public WithEvents dtpPER_FECHA_ALTA As System.Windows.Forms.DateTimePicker
        Public WithEvents txtPER_EXCESO_LINEA As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_EXCESO_LINEA As System.Windows.Forms.Label
    End Class
End Namespace