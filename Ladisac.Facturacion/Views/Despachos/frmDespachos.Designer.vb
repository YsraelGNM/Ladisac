Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDespachos
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDespachos))
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImpresion = New System.Windows.Forms.Button()
            Me.tcoDirecciones = New System.Windows.Forms.TabControl()
            Me.tpaDocumento = New System.Windows.Forms.TabPage()
            Me.tpaEntrega = New System.Windows.Forms.TabPage()
            Me.tpaRecepciona = New System.Windows.Forms.TabPage()
            Me.tpaSaldo = New System.Windows.Forms.TabPage()
            Me.txtFLE_ID = New System.Windows.Forms.TextBox()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.dtpDES_FEC_SAL_PLA = New System.Windows.Forms.DateTimePicker()
            Me.btnOrdenDespacho = New System.Windows.Forms.Button()
            Me.cboDes_Tipo_Guia = New System.Windows.Forms.ComboBox()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.tcoDetalle = New System.Windows.Forms.TabControl()
            Me.tpaArticulosGuia = New System.Windows.Forms.TabPage()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.lblTipoGuia = New System.Windows.Forms.Label()
            Me.lblCERTIFICADO = New System.Windows.Forms.Label()
            Me.txtCertificado = New System.Windows.Forms.TextBox()
            Me.dtpDES_FEC_TRA = New System.Windows.Forms.DateTimePicker()
            Me.dtpDES_FEC_EMI = New System.Windows.Forms.DateTimePicker()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.cboSerieCorrelativo = New System.Windows.Forms.ComboBox()
            Me.txtDES_NUMERO = New System.Windows.Forms.TextBox()
            Me.cboDES_ESTADO = New System.Windows.Forms.ComboBox()
            Me.btnProcesarCronogramaDespacho = New System.Windows.Forms.Button()
            Me.lblPER_ID_VEN1 = New System.Windows.Forms.Label()
            Me.txtPER_ID_VEN1 = New System.Windows.Forms.TextBox()
            Me.txtDES_NUMERO_DOC = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_VEN = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtPRO_ID_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtDIS_ID_ALM_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtALM_DIRECCION_LLEGADA = New System.Windows.Forms.TextBox()
            Me.chkALM_ESTADO_LLEGADA = New System.Windows.Forms.CheckBox()
            Me.txtALM_DESCRIPCION_LLEGADA = New System.Windows.Forms.TextBox()
            Me.txtALM_ID_LLEGADA = New System.Windows.Forms.TextBox()
            Me.lblALM_ID_LLEGADA = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.lblCorrelativo = New System.Windows.Forms.Label()
            Me.txtDES_SERIE = New System.Windows.Forms.TextBox()
            Me.lblSeparador = New System.Windows.Forms.Label()
            Me.lblDES_FECHA_EMI = New System.Windows.Forms.Label()
            Me.lblDES_FECHA_TRA = New System.Windows.Forms.Label()
            Me.lblALM_ID = New System.Windows.Forms.Label()
            Me.txtALM_ID = New System.Windows.Forms.TextBox()
            Me.txtALM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkALM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCCT_ID = New System.Windows.Forms.TextBox()
            Me.txtCCT_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDES_ESTADO = New System.Windows.Forms.Label()
            Me.txtALM_DIRECCION = New System.Windows.Forms.TextBox()
            Me.txtDIS_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtPRO_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_CLI = New System.Windows.Forms.Label()
            Me.txtPER_ID_CLI = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_VEN1 = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID_DOC = New System.Windows.Forms.Label()
            Me.txtTDO_ID_DOC = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID_DOC = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION_DOC = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID_CLI = New System.Windows.Forms.Label()
            Me.txtTDP_ID_CLI = New System.Windows.Forms.TextBox()
            Me.txtTDP_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.txtDOP_NUMERO_CLI = New System.Windows.Forms.TextBox()
            Me.lblDOC_SERIE_DOC = New System.Windows.Forms.Label()
            Me.txtDES_SERIE_DOC = New System.Windows.Forms.TextBox()
            Me.lblSeparador1 = New System.Windows.Forms.Label()
            Me.txtDOC_TIPO_LISTA = New System.Windows.Forms.TextBox()
            Me.lblTIV_ID = New System.Windows.Forms.Label()
            Me.txtTIV_ID_DOC = New System.Windows.Forms.TextBox()
            Me.txtTIV_DESCRIPCION_DOC = New System.Windows.Forms.TextBox()
            Me.lblFLE_ID = New System.Windows.Forms.Label()
            Me.txtFLE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDES_MONTO_FLETE = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDIR_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIR_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIR_REFERENCIA_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIS_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtPRO_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_REC = New System.Windows.Forms.Label()
            Me.txtPER_ID_REC = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_REC = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID_REC = New System.Windows.Forms.Label()
            Me.txtTDP_ID_REC = New System.Windows.Forms.TextBox()
            Me.txtTDP_DESCRIPCION_REC = New System.Windows.Forms.TextBox()
            Me.txtDOP_NUMERO_REC = New System.Windows.Forms.TextBox()
            Me.lblDIR_ID_ENT_REC = New System.Windows.Forms.Label()
            Me.txtDIR_ID_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDIR_DESCRIPCION_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDIR_REFERENCIA_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDIS_ID_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtPRO_ID_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ENT_REC = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ENT_REC = New System.Windows.Forms.TextBox()
            Me.lblPLA_ID = New System.Windows.Forms.Label()
            Me.txtPLA_ID = New System.Windows.Forms.TextBox()
            Me.txtUNT_ID_1 = New System.Windows.Forms.TextBox()
            Me.txtUNT_ID_2 = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_TRA1 = New System.Windows.Forms.Label()
            Me.txtPER_ID_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_TRA1 = New System.Windows.Forms.TextBox()
            Me.lblRUC_TRA1 = New System.Windows.Forms.Label()
            Me.txtRUC_TRA1 = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO_TRA1 = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID_CHO = New System.Windows.Forms.Label()
            Me.txtPER_ID_CHO = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_CHO = New System.Windows.Forms.TextBox()
            Me.lblPER_BREVETE_CHO = New System.Windows.Forms.Label()
            Me.txtPER_BREVETE_CHO = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO_CHO = New System.Windows.Forms.CheckBox()
            Me.dgvArticulosDocumento = New System.Windows.Forms.DataGridView()
            Me.cTDO_ID_DOC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID_DOC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOC_SERIE_DOC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOC_NUMERO_DOC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ID_KAR1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION_KAR1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDO_CANTIDAD_VENDIDA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDO_CANTIDAD_MOVIDA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDO_CANTIDAD_SALDO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMover1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cEstadoRegistro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvSaldosMontoDocumento = New System.Windows.Forms.DataGridView()
            Me.cPER_ID_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ssDespachos = New System.Windows.Forms.StatusStrip()
            Me.tslFechaServidor = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tslSeparador1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tslTipoCambioCompraMoneda = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tslSeparador2 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tslTipoCambioVentaMoneda = New System.Windows.Forms.ToolStripStatusLabel()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataFormatoVenta141 = New DataFormatoVenta14()
            Me.DataFormatoVenta142 = New DataFormatoVenta14()
            Me.cITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ID_IMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION_IMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_FACTOR_IMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ESTADO_IMP = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cART_ID_KAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION_KAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_FACTOR_KAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ESTADO_KAR = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDDE_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDE_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcoDirecciones.SuspendLayout()
            Me.pnCuerpo.SuspendLayout()
            Me.tcoDetalle.SuspendLayout()
            CType(Me.dgvArticulosDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvSaldosMontoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ssDespachos.SuspendLayout()
            CType(Me.DataFormatoVenta141, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataFormatoVenta142, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.MinimumSize = New System.Drawing.Size(825, 28)
            Me.lblTitle.Size = New System.Drawing.Size(825, 28)
            Me.lblTitle.Text = "Despachos"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImpresion
            '
            Me.btnImpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnImpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ErrorProvider1.SetIconAlignment(Me.btnImpresion, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.btnImpresion.Location = New System.Drawing.Point(11, 454)
            Me.btnImpresion.Name = "btnImpresion"
            Me.btnImpresion.Size = New System.Drawing.Size(70, 20)
            Me.btnImpresion.TabIndex = 243
            Me.btnImpresion.Text = "Imprimir guía"
            Me.btnImpresion.UseVisualStyleBackColor = True
            '
            'tcoDirecciones
            '
            Me.tcoDirecciones.Controls.Add(Me.tpaDocumento)
            Me.tcoDirecciones.Controls.Add(Me.tpaEntrega)
            Me.tcoDirecciones.Controls.Add(Me.tpaRecepciona)
            Me.tcoDirecciones.Controls.Add(Me.tpaSaldo)
            Me.ErrorProvider1.SetIconAlignment(Me.tcoDirecciones, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.tcoDirecciones.Location = New System.Drawing.Point(11, 172)
            Me.tcoDirecciones.Name = "tcoDirecciones"
            Me.tcoDirecciones.SelectedIndex = 0
            Me.tcoDirecciones.Size = New System.Drawing.Size(729, 25)
            Me.tcoDirecciones.TabIndex = 135
            '
            'tpaDocumento
            '
            Me.tpaDocumento.Location = New System.Drawing.Point(4, 22)
            Me.tpaDocumento.Name = "tpaDocumento"
            Me.tpaDocumento.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaDocumento.Size = New System.Drawing.Size(721, 0)
            Me.tpaDocumento.TabIndex = 5
            Me.tpaDocumento.Text = "Artículos de la factura/boleta"
            Me.tpaDocumento.UseVisualStyleBackColor = True
            '
            'tpaEntrega
            '
            Me.tpaEntrega.Location = New System.Drawing.Point(4, 22)
            Me.tpaEntrega.Name = "tpaEntrega"
            Me.tpaEntrega.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEntrega.Size = New System.Drawing.Size(721, 0)
            Me.tpaEntrega.TabIndex = 3
            Me.tpaEntrega.Text = "Dir. entrega"
            Me.tpaEntrega.UseVisualStyleBackColor = True
            '
            'tpaRecepciona
            '
            Me.tpaRecepciona.Location = New System.Drawing.Point(4, 22)
            Me.tpaRecepciona.Name = "tpaRecepciona"
            Me.tpaRecepciona.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaRecepciona.Size = New System.Drawing.Size(721, 0)
            Me.tpaRecepciona.TabIndex = 4
            Me.tpaRecepciona.Text = "Persona que recepciona"
            Me.tpaRecepciona.UseVisualStyleBackColor = True
            '
            'tpaSaldo
            '
            Me.tpaSaldo.Location = New System.Drawing.Point(4, 22)
            Me.tpaSaldo.Name = "tpaSaldo"
            Me.tpaSaldo.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaSaldo.Size = New System.Drawing.Size(721, 0)
            Me.tpaSaldo.TabIndex = 6
            Me.tpaSaldo.Text = "Saldo Doc."
            Me.tpaSaldo.UseVisualStyleBackColor = True
            '
            'txtFLE_ID
            '
            Me.txtFLE_ID.Location = New System.Drawing.Point(451, 148)
            Me.txtFLE_ID.Name = "txtFLE_ID"
            Me.txtFLE_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtFLE_ID.TabIndex = 198
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.dtpDES_FEC_SAL_PLA)
            Me.pnCuerpo.Controls.Add(Me.btnOrdenDespacho)
            Me.pnCuerpo.Controls.Add(Me.cboDes_Tipo_Guia)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.tcoDetalle)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTipoGuia)
            Me.pnCuerpo.Controls.Add(Me.lblCERTIFICADO)
            Me.pnCuerpo.Controls.Add(Me.txtCertificado)
            Me.pnCuerpo.Controls.Add(Me.dtpDES_FEC_TRA)
            Me.pnCuerpo.Controls.Add(Me.dtpDES_FEC_EMI)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.cboSerieCorrelativo)
            Me.pnCuerpo.Controls.Add(Me.txtDES_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.cboDES_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.btnProcesarCronogramaDespacho)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_VEN1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_VEN1)
            Me.pnCuerpo.Controls.Add(Me.txtDES_NUMERO_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_VEN)
            Me.pnCuerpo.Controls.Add(Me.btnImpresion)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID_ALM_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DIRECCION_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.chkALM_ESTADO_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID_LLEGADA)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCorrelativo)
            Me.pnCuerpo.Controls.Add(Me.txtDES_SERIE)
            Me.pnCuerpo.Controls.Add(Me.lblSeparador)
            Me.pnCuerpo.Controls.Add(Me.lblDES_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.lblDES_FECHA_TRA)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkALM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDES_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_VEN1)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtDOP_NUMERO_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblDOC_SERIE_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDES_SERIE_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblSeparador1)
            Me.pnCuerpo.Controls.Add(Me.txtDOC_TIPO_LISTA)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DESCRIPCION_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDES_MONTO_FLETE)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.tcoDirecciones)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_REFERENCIA_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_REC)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID_REC)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_ID_REC)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_DESCRIPCION_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDOP_NUMERO_REC)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_DESCRIPCION_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_REFERENCIA_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ENT_REC)
            Me.pnCuerpo.Controls.Add(Me.lblPLA_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPLA_ID)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ID_1)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ID_2)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_TRA1)
            Me.pnCuerpo.Controls.Add(Me.lblRUC_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtRUC_TRA1)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_TRA1)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CHO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CHO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CHO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BREVETE_CHO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_BREVETE_CHO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_CHO)
            Me.pnCuerpo.Controls.Add(Me.dgvArticulosDocumento)
            Me.pnCuerpo.Controls.Add(Me.dgvSaldosMontoDocumento)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(760, 481)
            Me.pnCuerpo.TabIndex = 123
            '
            'dtpDES_FEC_SAL_PLA
            '
            Me.dtpDES_FEC_SAL_PLA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDES_FEC_SAL_PLA.Location = New System.Drawing.Point(630, 451)
            Me.dtpDES_FEC_SAL_PLA.Name = "dtpDES_FEC_SAL_PLA"
            Me.dtpDES_FEC_SAL_PLA.Size = New System.Drawing.Size(110, 20)
            Me.dtpDES_FEC_SAL_PLA.TabIndex = 257
            Me.dtpDES_FEC_SAL_PLA.Visible = False
            '
            'btnOrdenDespacho
            '
            Me.btnOrdenDespacho.Location = New System.Drawing.Point(382, 8)
            Me.btnOrdenDespacho.Name = "btnOrdenDespacho"
            Me.btnOrdenDespacho.Size = New System.Drawing.Size(21, 23)
            Me.btnOrdenDespacho.TabIndex = 256
            Me.btnOrdenDespacho.Text = "D"
            Me.btnOrdenDespacho.UseVisualStyleBackColor = True
            '
            'cboDes_Tipo_Guia
            '
            Me.cboDes_Tipo_Guia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDes_Tipo_Guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDes_Tipo_Guia.FormattingEnabled = True
            Me.cboDes_Tipo_Guia.Location = New System.Drawing.Point(514, 171)
            Me.cboDes_Tipo_Guia.Name = "cboDes_Tipo_Guia"
            Me.cboDes_Tipo_Guia.Size = New System.Drawing.Size(226, 17)
            Me.cboDes_Tipo_Guia.TabIndex = 255
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(334, 31)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblCCT_ID.TabIndex = 223
            Me.lblCCT_ID.Text = "Cta. Cte."
            '
            'tcoDetalle
            '
            Me.tcoDetalle.Controls.Add(Me.tpaArticulosGuia)
            Me.tcoDetalle.Location = New System.Drawing.Point(11, 317)
            Me.tcoDetalle.Name = "tcoDetalle"
            Me.tcoDetalle.SelectedIndex = 0
            Me.tcoDetalle.Size = New System.Drawing.Size(729, 25)
            Me.tcoDetalle.TabIndex = 254
            '
            'tpaArticulosGuia
            '
            Me.tpaArticulosGuia.Location = New System.Drawing.Point(4, 22)
            Me.tpaArticulosGuia.Name = "tpaArticulosGuia"
            Me.tpaArticulosGuia.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaArticulosGuia.Size = New System.Drawing.Size(721, 0)
            Me.tpaArticulosGuia.TabIndex = 5
            Me.tpaArticulosGuia.Text = "Artículos en la guía"
            Me.tpaArticulosGuia.UseVisualStyleBackColor = True
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Enabled = False
            Me.txtMON_ID.Location = New System.Drawing.Point(673, 171)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.ReadOnly = True
            Me.txtMON_ID.Size = New System.Drawing.Size(24, 20)
            Me.txtMON_ID.TabIndex = 226
            Me.txtMON_ID.Visible = False
            '
            'lblTipoGuia
            '
            Me.lblTipoGuia.AutoSize = True
            Me.lblTipoGuia.Enabled = False
            Me.lblTipoGuia.Location = New System.Drawing.Point(451, 171)
            Me.lblTipoGuia.Name = "lblTipoGuia"
            Me.lblTipoGuia.Size = New System.Drawing.Size(56, 13)
            Me.lblTipoGuia.TabIndex = 253
            Me.lblTipoGuia.Text = "Tipo guía:"
            '
            'lblCERTIFICADO
            '
            Me.lblCERTIFICADO.AutoSize = True
            Me.lblCERTIFICADO.Location = New System.Drawing.Point(382, 245)
            Me.lblCERTIFICADO.Name = "lblCERTIFICADO"
            Me.lblCERTIFICADO.Size = New System.Drawing.Size(55, 13)
            Me.lblCERTIFICADO.TabIndex = 251
            Me.lblCERTIFICADO.Text = "Cert. Insc."
            '
            'txtCertificado
            '
            Me.txtCertificado.Enabled = False
            Me.txtCertificado.Location = New System.Drawing.Point(454, 245)
            Me.txtCertificado.Name = "txtCertificado"
            Me.txtCertificado.ReadOnly = True
            Me.txtCertificado.Size = New System.Drawing.Size(208, 20)
            Me.txtCertificado.TabIndex = 250
            '
            'dtpDES_FEC_TRA
            '
            Me.dtpDES_FEC_TRA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDES_FEC_TRA.Location = New System.Drawing.Point(630, 8)
            Me.dtpDES_FEC_TRA.Name = "dtpDES_FEC_TRA"
            Me.dtpDES_FEC_TRA.Size = New System.Drawing.Size(110, 20)
            Me.dtpDES_FEC_TRA.TabIndex = 8
            '
            'dtpDES_FEC_EMI
            '
            Me.dtpDES_FEC_EMI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDES_FEC_EMI.Location = New System.Drawing.Point(462, 8)
            Me.dtpDES_FEC_EMI.Name = "dtpDES_FEC_EMI"
            Me.dtpDES_FEC_EMI.Size = New System.Drawing.Size(135, 20)
            Me.dtpDES_FEC_EMI.TabIndex = 7
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Enabled = False
            Me.txtDTD_ID.Location = New System.Drawing.Point(152, 8)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.ReadOnly = True
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 3
            '
            'cboSerieCorrelativo
            '
            Me.cboSerieCorrelativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSerieCorrelativo.FormattingEnabled = True
            Me.cboSerieCorrelativo.Location = New System.Drawing.Point(262, 8)
            Me.cboSerieCorrelativo.Name = "cboSerieCorrelativo"
            Me.cboSerieCorrelativo.Size = New System.Drawing.Size(44, 21)
            Me.cboSerieCorrelativo.TabIndex = 4
            '
            'txtDES_NUMERO
            '
            Me.txtDES_NUMERO.Location = New System.Drawing.Point(313, 8)
            Me.txtDES_NUMERO.Name = "txtDES_NUMERO"
            Me.txtDES_NUMERO.Size = New System.Drawing.Size(69, 20)
            Me.txtDES_NUMERO.TabIndex = 6
            '
            'cboDES_ESTADO
            '
            Me.cboDES_ESTADO.FormattingEnabled = True
            Me.cboDES_ESTADO.Location = New System.Drawing.Point(630, 30)
            Me.cboDES_ESTADO.Name = "cboDES_ESTADO"
            Me.cboDES_ESTADO.Size = New System.Drawing.Size(110, 21)
            Me.cboDES_ESTADO.TabIndex = 249
            '
            'btnProcesarCronogramaDespacho
            '
            Me.btnProcesarCronogramaDespacho.Location = New System.Drawing.Point(402, 8)
            Me.btnProcesarCronogramaDespacho.Name = "btnProcesarCronogramaDespacho"
            Me.btnProcesarCronogramaDespacho.Size = New System.Drawing.Size(21, 23)
            Me.btnProcesarCronogramaDespacho.TabIndex = 248
            Me.btnProcesarCronogramaDespacho.Text = ":"
            Me.btnProcesarCronogramaDespacho.UseVisualStyleBackColor = True
            '
            'lblPER_ID_VEN1
            '
            Me.lblPER_ID_VEN1.AutoSize = True
            Me.lblPER_ID_VEN1.Enabled = False
            Me.lblPER_ID_VEN1.Location = New System.Drawing.Point(383, 75)
            Me.lblPER_ID_VEN1.Name = "lblPER_ID_VEN1"
            Me.lblPER_ID_VEN1.Size = New System.Drawing.Size(60, 13)
            Me.lblPER_ID_VEN1.TabIndex = 247
            Me.lblPER_ID_VEN1.Text = "Cod. Vend."
            Me.lblPER_ID_VEN1.Visible = False
            '
            'txtPER_ID_VEN1
            '
            Me.txtPER_ID_VEN1.Enabled = False
            Me.txtPER_ID_VEN1.Location = New System.Drawing.Point(451, 75)
            Me.txtPER_ID_VEN1.Name = "txtPER_ID_VEN1"
            Me.txtPER_ID_VEN1.Size = New System.Drawing.Size(56, 20)
            Me.txtPER_ID_VEN1.TabIndex = 245
            Me.txtPER_ID_VEN1.Visible = False
            '
            'txtDES_NUMERO_DOC
            '
            Me.txtDES_NUMERO_DOC.Enabled = False
            Me.txtDES_NUMERO_DOC.Location = New System.Drawing.Point(495, 127)
            Me.txtDES_NUMERO_DOC.Name = "txtDES_NUMERO_DOC"
            Me.txtDES_NUMERO_DOC.ReadOnly = True
            Me.txtDES_NUMERO_DOC.Size = New System.Drawing.Size(71, 20)
            Me.txtDES_NUMERO_DOC.TabIndex = 137
            '
            'txtPER_DESCRIPCION_VEN
            '
            Me.txtPER_DESCRIPCION_VEN.Enabled = False
            Me.txtPER_DESCRIPCION_VEN.Location = New System.Drawing.Point(742, 104)
            Me.txtPER_DESCRIPCION_VEN.Name = "txtPER_DESCRIPCION_VEN"
            Me.txtPER_DESCRIPCION_VEN.ReadOnly = True
            Me.txtPER_DESCRIPCION_VEN.Size = New System.Drawing.Size(10, 20)
            Me.txtPER_DESCRIPCION_VEN.TabIndex = 244
            Me.txtPER_DESCRIPCION_VEN.Visible = False
            '
            'txtPAI_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(610, 148)
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Name = "txtPAI_DESCRIPCION_ALM_LLEGADA"
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(130, 20)
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.TabIndex = 234
            '
            'txtPAI_ID_ALM_LLEGADA
            '
            Me.txtPAI_ID_ALM_LLEGADA.Enabled = False
            Me.txtPAI_ID_ALM_LLEGADA.Location = New System.Drawing.Point(572, 148)
            Me.txtPAI_ID_ALM_LLEGADA.Name = "txtPAI_ID_ALM_LLEGADA"
            Me.txtPAI_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtPAI_ID_ALM_LLEGADA.Size = New System.Drawing.Size(34, 20)
            Me.txtPAI_ID_ALM_LLEGADA.TabIndex = 233
            '
            'txtDEP_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(423, 148)
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Name = "txtDEP_DESCRIPCION_ALM_LLEGADA"
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(130, 20)
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.TabIndex = 232
            '
            'txtDEP_ID_ALM_LLEGADA
            '
            Me.txtDEP_ID_ALM_LLEGADA.Enabled = False
            Me.txtDEP_ID_ALM_LLEGADA.Location = New System.Drawing.Point(385, 148)
            Me.txtDEP_ID_ALM_LLEGADA.Name = "txtDEP_ID_ALM_LLEGADA"
            Me.txtDEP_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtDEP_ID_ALM_LLEGADA.Size = New System.Drawing.Size(34, 20)
            Me.txtDEP_ID_ALM_LLEGADA.TabIndex = 240
            '
            'txtPRO_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(231, 148)
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Name = "txtPRO_DESCRIPCION_ALM_LLEGADA"
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(130, 20)
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.TabIndex = 239
            '
            'txtPRO_ID_ALM_LLEGADA
            '
            Me.txtPRO_ID_ALM_LLEGADA.Enabled = False
            Me.txtPRO_ID_ALM_LLEGADA.Location = New System.Drawing.Point(193, 148)
            Me.txtPRO_ID_ALM_LLEGADA.Name = "txtPRO_ID_ALM_LLEGADA"
            Me.txtPRO_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtPRO_ID_ALM_LLEGADA.Size = New System.Drawing.Size(34, 20)
            Me.txtPRO_ID_ALM_LLEGADA.TabIndex = 238
            '
            'txtDIS_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(45, 148)
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Name = "txtDIS_DESCRIPCION_ALM_LLEGADA"
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(130, 20)
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.TabIndex = 237
            '
            'txtDIS_ID_ALM_LLEGADA
            '
            Me.txtDIS_ID_ALM_LLEGADA.Enabled = False
            Me.txtDIS_ID_ALM_LLEGADA.Location = New System.Drawing.Point(7, 148)
            Me.txtDIS_ID_ALM_LLEGADA.Name = "txtDIS_ID_ALM_LLEGADA"
            Me.txtDIS_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtDIS_ID_ALM_LLEGADA.Size = New System.Drawing.Size(34, 20)
            Me.txtDIS_ID_ALM_LLEGADA.TabIndex = 236
            '
            'txtALM_DIRECCION_LLEGADA
            '
            Me.txtALM_DIRECCION_LLEGADA.Enabled = False
            Me.txtALM_DIRECCION_LLEGADA.Location = New System.Drawing.Point(7, 127)
            Me.txtALM_DIRECCION_LLEGADA.Name = "txtALM_DIRECCION_LLEGADA"
            Me.txtALM_DIRECCION_LLEGADA.ReadOnly = True
            Me.txtALM_DIRECCION_LLEGADA.Size = New System.Drawing.Size(732, 20)
            Me.txtALM_DIRECCION_LLEGADA.TabIndex = 235
            '
            'chkALM_ESTADO_LLEGADA
            '
            Me.chkALM_ESTADO_LLEGADA.AutoSize = True
            Me.chkALM_ESTADO_LLEGADA.Enabled = False
            Me.chkALM_ESTADO_LLEGADA.Location = New System.Drawing.Point(262, 104)
            Me.chkALM_ESTADO_LLEGADA.Name = "chkALM_ESTADO_LLEGADA"
            Me.chkALM_ESTADO_LLEGADA.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO_LLEGADA.TabIndex = 242
            Me.chkALM_ESTADO_LLEGADA.UseVisualStyleBackColor = True
            '
            'txtALM_DESCRIPCION_LLEGADA
            '
            Me.txtALM_DESCRIPCION_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DESCRIPCION_LLEGADA.Location = New System.Drawing.Point(93, 104)
            Me.txtALM_DESCRIPCION_LLEGADA.Name = "txtALM_DESCRIPCION_LLEGADA"
            Me.txtALM_DESCRIPCION_LLEGADA.ReadOnly = True
            Me.txtALM_DESCRIPCION_LLEGADA.Size = New System.Drawing.Size(168, 20)
            Me.txtALM_DESCRIPCION_LLEGADA.TabIndex = 231
            '
            'txtALM_ID_LLEGADA
            '
            Me.txtALM_ID_LLEGADA.Location = New System.Drawing.Point(56, 104)
            Me.txtALM_ID_LLEGADA.Name = "txtALM_ID_LLEGADA"
            Me.txtALM_ID_LLEGADA.Size = New System.Drawing.Size(36, 20)
            Me.txtALM_ID_LLEGADA.TabIndex = 230
            '
            'lblALM_ID_LLEGADA
            '
            Me.lblALM_ID_LLEGADA.AutoSize = True
            Me.lblALM_ID_LLEGADA.Location = New System.Drawing.Point(7, 104)
            Me.lblALM_ID_LLEGADA.Name = "lblALM_ID_LLEGADA"
            Me.lblALM_ID_LLEGADA.Size = New System.Drawing.Size(48, 13)
            Me.lblALM_ID_LLEGADA.TabIndex = 241
            Me.lblALM_ID_LLEGADA.Text = "Almacén"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(7, 8)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPVE_ID.TabIndex = 61
            Me.lblPVE_ID.Text = "Agencia"
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(56, 8)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 1
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(91, 8)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.ReadOnly = True
            Me.txtTDO_ID.Size = New System.Drawing.Size(5, 20)
            Me.txtTDO_ID.TabIndex = 2
            Me.txtTDO_ID.Visible = False
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(101, 8)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblDTD_ID.TabIndex = 25
            Me.lblDTD_ID.Text = "Tipo.Doc."
            '
            'lblCorrelativo
            '
            Me.lblCorrelativo.AutoSize = True
            Me.lblCorrelativo.Location = New System.Drawing.Point(206, 8)
            Me.lblCorrelativo.Name = "lblCorrelativo"
            Me.lblCorrelativo.Size = New System.Drawing.Size(56, 13)
            Me.lblCorrelativo.TabIndex = 46
            Me.lblCorrelativo.Text = "Ser./Núm."
            '
            'txtDES_SERIE
            '
            Me.txtDES_SERIE.Enabled = False
            Me.txtDES_SERIE.Location = New System.Drawing.Point(262, 8)
            Me.txtDES_SERIE.Name = "txtDES_SERIE"
            Me.txtDES_SERIE.Size = New System.Drawing.Size(44, 20)
            Me.txtDES_SERIE.TabIndex = 5
            '
            'lblSeparador
            '
            Me.lblSeparador.AutoSize = True
            Me.lblSeparador.Location = New System.Drawing.Point(304, 8)
            Me.lblSeparador.Name = "lblSeparador"
            Me.lblSeparador.Size = New System.Drawing.Size(10, 13)
            Me.lblSeparador.TabIndex = 131
            Me.lblSeparador.Text = "-"
            '
            'lblDES_FECHA_EMI
            '
            Me.lblDES_FECHA_EMI.AutoSize = True
            Me.lblDES_FECHA_EMI.Location = New System.Drawing.Point(419, 8)
            Me.lblDES_FECHA_EMI.Name = "lblDES_FECHA_EMI"
            Me.lblDES_FECHA_EMI.Size = New System.Drawing.Size(43, 13)
            Me.lblDES_FECHA_EMI.TabIndex = 79
            Me.lblDES_FECHA_EMI.Text = "Emisión"
            '
            'lblDES_FECHA_TRA
            '
            Me.lblDES_FECHA_TRA.AutoSize = True
            Me.lblDES_FECHA_TRA.Location = New System.Drawing.Point(599, 8)
            Me.lblDES_FECHA_TRA.Name = "lblDES_FECHA_TRA"
            Me.lblDES_FECHA_TRA.Size = New System.Drawing.Size(33, 13)
            Me.lblDES_FECHA_TRA.TabIndex = 78
            Me.lblDES_FECHA_TRA.Text = "Trasl."
            '
            'lblALM_ID
            '
            Me.lblALM_ID.AutoSize = True
            Me.lblALM_ID.Location = New System.Drawing.Point(7, 31)
            Me.lblALM_ID.Name = "lblALM_ID"
            Me.lblALM_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblALM_ID.TabIndex = 62
            Me.lblALM_ID.Text = "Almacén"
            '
            'txtALM_ID
            '
            Me.txtALM_ID.Location = New System.Drawing.Point(56, 31)
            Me.txtALM_ID.Name = "txtALM_ID"
            Me.txtALM_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtALM_ID.TabIndex = 9
            '
            'txtALM_DESCRIPCION
            '
            Me.txtALM_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DESCRIPCION.Location = New System.Drawing.Point(93, 31)
            Me.txtALM_DESCRIPCION.Name = "txtALM_DESCRIPCION"
            Me.txtALM_DESCRIPCION.ReadOnly = True
            Me.txtALM_DESCRIPCION.Size = New System.Drawing.Size(168, 20)
            Me.txtALM_DESCRIPCION.TabIndex = 11
            '
            'chkALM_ESTADO
            '
            Me.chkALM_ESTADO.AutoSize = True
            Me.chkALM_ESTADO.Enabled = False
            Me.chkALM_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkALM_ESTADO.Location = New System.Drawing.Point(262, 31)
            Me.chkALM_ESTADO.Name = "chkALM_ESTADO"
            Me.chkALM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO.TabIndex = 219
            Me.chkALM_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Enabled = False
            Me.txtCCT_ID.Location = New System.Drawing.Point(385, 31)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.ReadOnly = True
            Me.txtCCT_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtCCT_ID.TabIndex = 221
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(423, 31)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(174, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 222
            '
            'lblDES_ESTADO
            '
            Me.lblDES_ESTADO.AutoSize = True
            Me.lblDES_ESTADO.Location = New System.Drawing.Point(599, 31)
            Me.lblDES_ESTADO.Name = "lblDES_ESTADO"
            Me.lblDES_ESTADO.Size = New System.Drawing.Size(25, 13)
            Me.lblDES_ESTADO.TabIndex = 220
            Me.lblDES_ESTADO.Text = "Est."
            '
            'txtALM_DIRECCION
            '
            Me.txtALM_DIRECCION.Enabled = False
            Me.txtALM_DIRECCION.Location = New System.Drawing.Point(7, 53)
            Me.txtALM_DIRECCION.Name = "txtALM_DIRECCION"
            Me.txtALM_DIRECCION.ReadOnly = True
            Me.txtALM_DIRECCION.Size = New System.Drawing.Size(733, 20)
            Me.txtALM_DIRECCION.TabIndex = 22
            '
            'txtDIS_ID_ALM
            '
            Me.txtDIS_ID_ALM.Enabled = False
            Me.txtDIS_ID_ALM.Location = New System.Drawing.Point(7, 75)
            Me.txtDIS_ID_ALM.Name = "txtDIS_ID_ALM"
            Me.txtDIS_ID_ALM.ReadOnly = True
            Me.txtDIS_ID_ALM.Size = New System.Drawing.Size(34, 20)
            Me.txtDIS_ID_ALM.TabIndex = 24
            '
            'txtDIS_DESCRIPCION_ALM
            '
            Me.txtDIS_DESCRIPCION_ALM.Enabled = False
            Me.txtDIS_DESCRIPCION_ALM.Location = New System.Drawing.Point(45, 75)
            Me.txtDIS_DESCRIPCION_ALM.Name = "txtDIS_DESCRIPCION_ALM"
            Me.txtDIS_DESCRIPCION_ALM.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ALM.Size = New System.Drawing.Size(130, 20)
            Me.txtDIS_DESCRIPCION_ALM.TabIndex = 25
            '
            'txtPRO_ID_ALM
            '
            Me.txtPRO_ID_ALM.Enabled = False
            Me.txtPRO_ID_ALM.Location = New System.Drawing.Point(193, 75)
            Me.txtPRO_ID_ALM.Name = "txtPRO_ID_ALM"
            Me.txtPRO_ID_ALM.ReadOnly = True
            Me.txtPRO_ID_ALM.Size = New System.Drawing.Size(34, 20)
            Me.txtPRO_ID_ALM.TabIndex = 26
            '
            'txtPRO_DESCRIPCION_ALM
            '
            Me.txtPRO_DESCRIPCION_ALM.Enabled = False
            Me.txtPRO_DESCRIPCION_ALM.Location = New System.Drawing.Point(231, 75)
            Me.txtPRO_DESCRIPCION_ALM.Name = "txtPRO_DESCRIPCION_ALM"
            Me.txtPRO_DESCRIPCION_ALM.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ALM.Size = New System.Drawing.Size(130, 20)
            Me.txtPRO_DESCRIPCION_ALM.TabIndex = 27
            '
            'txtDEP_ID_ALM
            '
            Me.txtDEP_ID_ALM.Enabled = False
            Me.txtDEP_ID_ALM.Location = New System.Drawing.Point(385, 75)
            Me.txtDEP_ID_ALM.Name = "txtDEP_ID_ALM"
            Me.txtDEP_ID_ALM.ReadOnly = True
            Me.txtDEP_ID_ALM.Size = New System.Drawing.Size(34, 20)
            Me.txtDEP_ID_ALM.TabIndex = 28
            '
            'txtDEP_DESCRIPCION_ALM
            '
            Me.txtDEP_DESCRIPCION_ALM.Enabled = False
            Me.txtDEP_DESCRIPCION_ALM.Location = New System.Drawing.Point(423, 75)
            Me.txtDEP_DESCRIPCION_ALM.Name = "txtDEP_DESCRIPCION_ALM"
            Me.txtDEP_DESCRIPCION_ALM.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ALM.Size = New System.Drawing.Size(130, 20)
            Me.txtDEP_DESCRIPCION_ALM.TabIndex = 19
            '
            'txtPAI_ID_ALM
            '
            Me.txtPAI_ID_ALM.Enabled = False
            Me.txtPAI_ID_ALM.Location = New System.Drawing.Point(572, 75)
            Me.txtPAI_ID_ALM.Name = "txtPAI_ID_ALM"
            Me.txtPAI_ID_ALM.ReadOnly = True
            Me.txtPAI_ID_ALM.Size = New System.Drawing.Size(34, 20)
            Me.txtPAI_ID_ALM.TabIndex = 20
            '
            'txtPAI_DESCRIPCION_ALM
            '
            Me.txtPAI_DESCRIPCION_ALM.Enabled = False
            Me.txtPAI_DESCRIPCION_ALM.Location = New System.Drawing.Point(610, 75)
            Me.txtPAI_DESCRIPCION_ALM.Name = "txtPAI_DESCRIPCION_ALM"
            Me.txtPAI_DESCRIPCION_ALM.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ALM.Size = New System.Drawing.Size(130, 20)
            Me.txtPAI_DESCRIPCION_ALM.TabIndex = 21
            '
            'lblPER_ID_CLI
            '
            Me.lblPER_ID_CLI.AutoSize = True
            Me.lblPER_ID_CLI.Location = New System.Drawing.Point(7, 104)
            Me.lblPER_ID_CLI.Name = "lblPER_ID_CLI"
            Me.lblPER_ID_CLI.Size = New System.Drawing.Size(64, 13)
            Me.lblPER_ID_CLI.TabIndex = 71
            Me.lblPER_ID_CLI.Text = "Cod. Cliente"
            '
            'txtPER_ID_CLI
            '
            Me.txtPER_ID_CLI.Enabled = False
            Me.txtPER_ID_CLI.Location = New System.Drawing.Point(78, 104)
            Me.txtPER_ID_CLI.Name = "txtPER_ID_CLI"
            Me.txtPER_ID_CLI.ReadOnly = True
            Me.txtPER_ID_CLI.Size = New System.Drawing.Size(56, 20)
            Me.txtPER_ID_CLI.TabIndex = 15
            '
            'txtPER_DESCRIPCION_CLI
            '
            Me.txtPER_DESCRIPCION_CLI.Enabled = False
            Me.txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(135, 104)
            Me.txtPER_DESCRIPCION_CLI.Name = "txtPER_DESCRIPCION_CLI"
            Me.txtPER_DESCRIPCION_CLI.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLI.Size = New System.Drawing.Size(226, 20)
            Me.txtPER_DESCRIPCION_CLI.TabIndex = 16
            '
            'txtPER_DESCRIPCION_VEN1
            '
            Me.txtPER_DESCRIPCION_VEN1.Enabled = False
            Me.txtPER_DESCRIPCION_VEN1.Location = New System.Drawing.Point(514, 75)
            Me.txtPER_DESCRIPCION_VEN1.Name = "txtPER_DESCRIPCION_VEN1"
            Me.txtPER_DESCRIPCION_VEN1.ReadOnly = True
            Me.txtPER_DESCRIPCION_VEN1.Size = New System.Drawing.Size(226, 20)
            Me.txtPER_DESCRIPCION_VEN1.TabIndex = 246
            Me.txtPER_DESCRIPCION_VEN1.Visible = False
            '
            'lblDTD_ID_DOC
            '
            Me.lblDTD_ID_DOC.AutoSize = True
            Me.lblDTD_ID_DOC.Location = New System.Drawing.Point(383, 104)
            Me.lblDTD_ID_DOC.Name = "lblDTD_ID_DOC"
            Me.lblDTD_ID_DOC.Size = New System.Drawing.Size(62, 13)
            Me.lblDTD_ID_DOC.TabIndex = 138
            Me.lblDTD_ID_DOC.Text = "Documento"
            '
            'txtTDO_ID_DOC
            '
            Me.txtTDO_ID_DOC.Enabled = False
            Me.txtTDO_ID_DOC.Location = New System.Drawing.Point(440, 104)
            Me.txtTDO_ID_DOC.Name = "txtTDO_ID_DOC"
            Me.txtTDO_ID_DOC.ReadOnly = True
            Me.txtTDO_ID_DOC.Size = New System.Drawing.Size(10, 20)
            Me.txtTDO_ID_DOC.TabIndex = 133
            Me.txtTDO_ID_DOC.Visible = False
            '
            'txtDTD_ID_DOC
            '
            Me.txtDTD_ID_DOC.BackColor = System.Drawing.SystemColors.Control
            Me.txtDTD_ID_DOC.Enabled = False
            Me.txtDTD_ID_DOC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtDTD_ID_DOC.Location = New System.Drawing.Point(451, 104)
            Me.txtDTD_ID_DOC.Name = "txtDTD_ID_DOC"
            Me.txtDTD_ID_DOC.ReadOnly = True
            Me.txtDTD_ID_DOC.Size = New System.Drawing.Size(37, 20)
            Me.txtDTD_ID_DOC.TabIndex = 134
            '
            'txtDTD_DESCRIPCION_DOC
            '
            Me.txtDTD_DESCRIPCION_DOC.Enabled = False
            Me.txtDTD_DESCRIPCION_DOC.Location = New System.Drawing.Point(495, 104)
            Me.txtDTD_DESCRIPCION_DOC.Name = "txtDTD_DESCRIPCION_DOC"
            Me.txtDTD_DESCRIPCION_DOC.ReadOnly = True
            Me.txtDTD_DESCRIPCION_DOC.Size = New System.Drawing.Size(245, 20)
            Me.txtDTD_DESCRIPCION_DOC.TabIndex = 172
            '
            'lblTDP_ID_CLI
            '
            Me.lblTDP_ID_CLI.AutoSize = True
            Me.lblTDP_ID_CLI.Location = New System.Drawing.Point(7, 127)
            Me.lblTDP_ID_CLI.Name = "lblTDP_ID_CLI"
            Me.lblTDP_ID_CLI.Size = New System.Drawing.Size(30, 13)
            Me.lblTDP_ID_CLI.TabIndex = 72
            Me.lblTDP_ID_CLI.Text = "Doc."
            '
            'txtTDP_ID_CLI
            '
            Me.txtTDP_ID_CLI.Enabled = False
            Me.txtTDP_ID_CLI.Location = New System.Drawing.Point(78, 127)
            Me.txtTDP_ID_CLI.Name = "txtTDP_ID_CLI"
            Me.txtTDP_ID_CLI.ReadOnly = True
            Me.txtTDP_ID_CLI.Size = New System.Drawing.Size(37, 20)
            Me.txtTDP_ID_CLI.TabIndex = 17
            '
            'txtTDP_DESCRIPCION_CLI
            '
            Me.txtTDP_DESCRIPCION_CLI.BackColor = System.Drawing.SystemColors.Control
            Me.txtTDP_DESCRIPCION_CLI.Enabled = False
            Me.txtTDP_DESCRIPCION_CLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTDP_DESCRIPCION_CLI.ForeColor = System.Drawing.SystemColors.MenuText
            Me.txtTDP_DESCRIPCION_CLI.Location = New System.Drawing.Point(118, 127)
            Me.txtTDP_DESCRIPCION_CLI.Name = "txtTDP_DESCRIPCION_CLI"
            Me.txtTDP_DESCRIPCION_CLI.ReadOnly = True
            Me.txtTDP_DESCRIPCION_CLI.Size = New System.Drawing.Size(159, 20)
            Me.txtTDP_DESCRIPCION_CLI.TabIndex = 18
            '
            'txtDOP_NUMERO_CLI
            '
            Me.txtDOP_NUMERO_CLI.Enabled = False
            Me.txtDOP_NUMERO_CLI.Location = New System.Drawing.Point(283, 127)
            Me.txtDOP_NUMERO_CLI.Name = "txtDOP_NUMERO_CLI"
            Me.txtDOP_NUMERO_CLI.ReadOnly = True
            Me.txtDOP_NUMERO_CLI.Size = New System.Drawing.Size(78, 20)
            Me.txtDOP_NUMERO_CLI.TabIndex = 19
            '
            'lblDOC_SERIE_DOC
            '
            Me.lblDOC_SERIE_DOC.AutoSize = True
            Me.lblDOC_SERIE_DOC.Location = New System.Drawing.Point(382, 127)
            Me.lblDOC_SERIE_DOC.Name = "lblDOC_SERIE_DOC"
            Me.lblDOC_SERIE_DOC.Size = New System.Drawing.Size(67, 13)
            Me.lblDOC_SERIE_DOC.TabIndex = 139
            Me.lblDOC_SERIE_DOC.Text = "Serie / Núm."
            '
            'txtDES_SERIE_DOC
            '
            Me.txtDES_SERIE_DOC.Enabled = False
            Me.txtDES_SERIE_DOC.Location = New System.Drawing.Point(451, 127)
            Me.txtDES_SERIE_DOC.Name = "txtDES_SERIE_DOC"
            Me.txtDES_SERIE_DOC.ReadOnly = True
            Me.txtDES_SERIE_DOC.Size = New System.Drawing.Size(37, 20)
            Me.txtDES_SERIE_DOC.TabIndex = 136
            '
            'lblSeparador1
            '
            Me.lblSeparador1.AutoSize = True
            Me.lblSeparador1.Location = New System.Drawing.Point(485, 129)
            Me.lblSeparador1.Name = "lblSeparador1"
            Me.lblSeparador1.Size = New System.Drawing.Size(10, 13)
            Me.lblSeparador1.TabIndex = 141
            Me.lblSeparador1.Text = "-"
            '
            'txtDOC_TIPO_LISTA
            '
            Me.txtDOC_TIPO_LISTA.Enabled = False
            Me.txtDOC_TIPO_LISTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDOC_TIPO_LISTA.Location = New System.Drawing.Point(572, 127)
            Me.txtDOC_TIPO_LISTA.Name = "txtDOC_TIPO_LISTA"
            Me.txtDOC_TIPO_LISTA.ReadOnly = True
            Me.txtDOC_TIPO_LISTA.Size = New System.Drawing.Size(168, 20)
            Me.txtDOC_TIPO_LISTA.TabIndex = 228
            '
            'lblTIV_ID
            '
            Me.lblTIV_ID.AutoSize = True
            Me.lblTIV_ID.Location = New System.Drawing.Point(7, 148)
            Me.lblTIV_ID.Name = "lblTIV_ID"
            Me.lblTIV_ID.Size = New System.Drawing.Size(58, 13)
            Me.lblTIV_ID.TabIndex = 65
            Me.lblTIV_ID.Text = "Tipo venta"
            '
            'txtTIV_ID_DOC
            '
            Me.txtTIV_ID_DOC.Enabled = False
            Me.txtTIV_ID_DOC.Location = New System.Drawing.Point(78, 148)
            Me.txtTIV_ID_DOC.Name = "txtTIV_ID_DOC"
            Me.txtTIV_ID_DOC.ReadOnly = True
            Me.txtTIV_ID_DOC.Size = New System.Drawing.Size(37, 20)
            Me.txtTIV_ID_DOC.TabIndex = 12
            '
            'txtTIV_DESCRIPCION_DOC
            '
            Me.txtTIV_DESCRIPCION_DOC.Enabled = False
            Me.txtTIV_DESCRIPCION_DOC.Location = New System.Drawing.Point(118, 148)
            Me.txtTIV_DESCRIPCION_DOC.Name = "txtTIV_DESCRIPCION_DOC"
            Me.txtTIV_DESCRIPCION_DOC.ReadOnly = True
            Me.txtTIV_DESCRIPCION_DOC.Size = New System.Drawing.Size(243, 20)
            Me.txtTIV_DESCRIPCION_DOC.TabIndex = 13
            '
            'lblFLE_ID
            '
            Me.lblFLE_ID.AutoSize = True
            Me.lblFLE_ID.Location = New System.Drawing.Point(382, 148)
            Me.lblFLE_ID.Name = "lblFLE_ID"
            Me.lblFLE_ID.Size = New System.Drawing.Size(32, 13)
            Me.lblFLE_ID.TabIndex = 199
            Me.lblFLE_ID.Text = "Zona"
            '
            'txtFLE_DESCRIPCION
            '
            Me.txtFLE_DESCRIPCION.Enabled = False
            Me.txtFLE_DESCRIPCION.Location = New System.Drawing.Point(495, 148)
            Me.txtFLE_DESCRIPCION.Name = "txtFLE_DESCRIPCION"
            Me.txtFLE_DESCRIPCION.ReadOnly = True
            Me.txtFLE_DESCRIPCION.Size = New System.Drawing.Size(157, 20)
            Me.txtFLE_DESCRIPCION.TabIndex = 197
            '
            'txtDES_MONTO_FLETE
            '
            Me.txtDES_MONTO_FLETE.Enabled = False
            Me.txtDES_MONTO_FLETE.Location = New System.Drawing.Point(655, 148)
            Me.txtDES_MONTO_FLETE.Name = "txtDES_MONTO_FLETE"
            Me.txtDES_MONTO_FLETE.ReadOnly = True
            Me.txtDES_MONTO_FLETE.Size = New System.Drawing.Size(84, 20)
            Me.txtDES_MONTO_FLETE.TabIndex = 195
            Me.txtDES_MONTO_FLETE.Text = "0"
            Me.txtDES_MONTO_FLETE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Enabled = False
            Me.lblMON_ID.Location = New System.Drawing.Point(639, 171)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(31, 13)
            Me.lblMON_ID.TabIndex = 227
            Me.lblMON_ID.Text = "Mon."
            Me.lblMON_ID.Visible = False
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(699, 171)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(41, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 225
            Me.txtMON_DESCRIPCION.Visible = False
            '
            'txtDIR_ID_ENT
            '
            Me.txtDIR_ID_ENT.Location = New System.Drawing.Point(11, 199)
            Me.txtDIR_ID_ENT.Name = "txtDIR_ID_ENT"
            Me.txtDIR_ID_ENT.Size = New System.Drawing.Size(68, 20)
            Me.txtDIR_ID_ENT.TabIndex = 42
            '
            'txtDIR_DESCRIPCION_ENT
            '
            Me.txtDIR_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIR_DESCRIPCION_ENT.Location = New System.Drawing.Point(80, 199)
            Me.txtDIR_DESCRIPCION_ENT.Multiline = True
            Me.txtDIR_DESCRIPCION_ENT.Name = "txtDIR_DESCRIPCION_ENT"
            Me.txtDIR_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDIR_DESCRIPCION_ENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtDIR_DESCRIPCION_ENT.Size = New System.Drawing.Size(339, 44)
            Me.txtDIR_DESCRIPCION_ENT.TabIndex = 43
            '
            'txtDIR_REFERENCIA_ENT
            '
            Me.txtDIR_REFERENCIA_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIR_REFERENCIA_ENT.Location = New System.Drawing.Point(423, 199)
            Me.txtDIR_REFERENCIA_ENT.Multiline = True
            Me.txtDIR_REFERENCIA_ENT.Name = "txtDIR_REFERENCIA_ENT"
            Me.txtDIR_REFERENCIA_ENT.ReadOnly = True
            Me.txtDIR_REFERENCIA_ENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtDIR_REFERENCIA_ENT.Size = New System.Drawing.Size(316, 44)
            Me.txtDIR_REFERENCIA_ENT.TabIndex = 149
            '
            'txtDIS_ID_ENT
            '
            Me.txtDIS_ID_ENT.Enabled = False
            Me.txtDIS_ID_ENT.Location = New System.Drawing.Point(7, 223)
            Me.txtDIS_ID_ENT.Name = "txtDIS_ID_ENT"
            Me.txtDIS_ID_ENT.ReadOnly = True
            Me.txtDIS_ID_ENT.Size = New System.Drawing.Size(34, 20)
            Me.txtDIS_ID_ENT.TabIndex = 44
            '
            'txtDIS_DESCRIPCION_ENT
            '
            Me.txtDIS_DESCRIPCION_ENT.Enabled = False
            Me.txtDIS_DESCRIPCION_ENT.Location = New System.Drawing.Point(45, 223)
            Me.txtDIS_DESCRIPCION_ENT.Name = "txtDIS_DESCRIPCION_ENT"
            Me.txtDIS_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ENT.Size = New System.Drawing.Size(130, 20)
            Me.txtDIS_DESCRIPCION_ENT.TabIndex = 45
            '
            'txtPRO_ID_ENT
            '
            Me.txtPRO_ID_ENT.Enabled = False
            Me.txtPRO_ID_ENT.Location = New System.Drawing.Point(193, 223)
            Me.txtPRO_ID_ENT.Name = "txtPRO_ID_ENT"
            Me.txtPRO_ID_ENT.ReadOnly = True
            Me.txtPRO_ID_ENT.Size = New System.Drawing.Size(34, 20)
            Me.txtPRO_ID_ENT.TabIndex = 46
            '
            'txtPRO_DESCRIPCION_ENT
            '
            Me.txtPRO_DESCRIPCION_ENT.Enabled = False
            Me.txtPRO_DESCRIPCION_ENT.Location = New System.Drawing.Point(231, 223)
            Me.txtPRO_DESCRIPCION_ENT.Name = "txtPRO_DESCRIPCION_ENT"
            Me.txtPRO_DESCRIPCION_ENT.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ENT.Size = New System.Drawing.Size(130, 20)
            Me.txtPRO_DESCRIPCION_ENT.TabIndex = 47
            '
            'txtDEP_ID_ENT
            '
            Me.txtDEP_ID_ENT.Enabled = False
            Me.txtDEP_ID_ENT.Location = New System.Drawing.Point(385, 223)
            Me.txtDEP_ID_ENT.Name = "txtDEP_ID_ENT"
            Me.txtDEP_ID_ENT.ReadOnly = True
            Me.txtDEP_ID_ENT.Size = New System.Drawing.Size(34, 20)
            Me.txtDEP_ID_ENT.TabIndex = 48
            '
            'txtDEP_DESCRIPCION_ENT
            '
            Me.txtDEP_DESCRIPCION_ENT.Enabled = False
            Me.txtDEP_DESCRIPCION_ENT.Location = New System.Drawing.Point(423, 223)
            Me.txtDEP_DESCRIPCION_ENT.Name = "txtDEP_DESCRIPCION_ENT"
            Me.txtDEP_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ENT.Size = New System.Drawing.Size(130, 20)
            Me.txtDEP_DESCRIPCION_ENT.TabIndex = 49
            '
            'txtPAI_ID_ENT
            '
            Me.txtPAI_ID_ENT.Enabled = False
            Me.txtPAI_ID_ENT.Location = New System.Drawing.Point(572, 223)
            Me.txtPAI_ID_ENT.Name = "txtPAI_ID_ENT"
            Me.txtPAI_ID_ENT.ReadOnly = True
            Me.txtPAI_ID_ENT.Size = New System.Drawing.Size(34, 20)
            Me.txtPAI_ID_ENT.TabIndex = 50
            '
            'txtPAI_DESCRIPCION_ENT
            '
            Me.txtPAI_DESCRIPCION_ENT.Enabled = False
            Me.txtPAI_DESCRIPCION_ENT.Location = New System.Drawing.Point(610, 223)
            Me.txtPAI_DESCRIPCION_ENT.Name = "txtPAI_DESCRIPCION_ENT"
            Me.txtPAI_DESCRIPCION_ENT.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ENT.Size = New System.Drawing.Size(130, 20)
            Me.txtPAI_DESCRIPCION_ENT.TabIndex = 51
            '
            'lblPER_ID_REC
            '
            Me.lblPER_ID_REC.AutoSize = True
            Me.lblPER_ID_REC.Location = New System.Drawing.Point(11, 203)
            Me.lblPER_ID_REC.Name = "lblPER_ID_REC"
            Me.lblPER_ID_REC.Size = New System.Drawing.Size(64, 13)
            Me.lblPER_ID_REC.TabIndex = 58
            Me.lblPER_ID_REC.Text = "Per. Recep."
            '
            'txtPER_ID_REC
            '
            Me.txtPER_ID_REC.Location = New System.Drawing.Point(78, 200)
            Me.txtPER_ID_REC.Name = "txtPER_ID_REC"
            Me.txtPER_ID_REC.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID_REC.TabIndex = 47
            '
            'txtPER_DESCRIPCION_REC
            '
            Me.txtPER_DESCRIPCION_REC.Enabled = False
            Me.txtPER_DESCRIPCION_REC.Location = New System.Drawing.Point(149, 201)
            Me.txtPER_DESCRIPCION_REC.Name = "txtPER_DESCRIPCION_REC"
            Me.txtPER_DESCRIPCION_REC.ReadOnly = True
            Me.txtPER_DESCRIPCION_REC.Size = New System.Drawing.Size(295, 20)
            Me.txtPER_DESCRIPCION_REC.TabIndex = 6
            '
            'lblTDP_ID_REC
            '
            Me.lblTDP_ID_REC.AutoSize = True
            Me.lblTDP_ID_REC.Location = New System.Drawing.Point(454, 202)
            Me.lblTDP_ID_REC.Name = "lblTDP_ID_REC"
            Me.lblTDP_ID_REC.Size = New System.Drawing.Size(30, 13)
            Me.lblTDP_ID_REC.TabIndex = 59
            Me.lblTDP_ID_REC.Text = "Doc."
            '
            'txtTDP_ID_REC
            '
            Me.txtTDP_ID_REC.Location = New System.Drawing.Point(487, 201)
            Me.txtTDP_ID_REC.Name = "txtTDP_ID_REC"
            Me.txtTDP_ID_REC.Size = New System.Drawing.Size(24, 20)
            Me.txtTDP_ID_REC.TabIndex = 50
            '
            'txtTDP_DESCRIPCION_REC
            '
            Me.txtTDP_DESCRIPCION_REC.Enabled = False
            Me.txtTDP_DESCRIPCION_REC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTDP_DESCRIPCION_REC.Location = New System.Drawing.Point(519, 201)
            Me.txtTDP_DESCRIPCION_REC.Name = "txtTDP_DESCRIPCION_REC"
            Me.txtTDP_DESCRIPCION_REC.ReadOnly = True
            Me.txtTDP_DESCRIPCION_REC.Size = New System.Drawing.Size(85, 17)
            Me.txtTDP_DESCRIPCION_REC.TabIndex = 49
            '
            'txtDOP_NUMERO_REC
            '
            Me.txtDOP_NUMERO_REC.Enabled = False
            Me.txtDOP_NUMERO_REC.Location = New System.Drawing.Point(609, 201)
            Me.txtDOP_NUMERO_REC.Name = "txtDOP_NUMERO_REC"
            Me.txtDOP_NUMERO_REC.ReadOnly = True
            Me.txtDOP_NUMERO_REC.Size = New System.Drawing.Size(130, 20)
            Me.txtDOP_NUMERO_REC.TabIndex = 51
            '
            'lblDIR_ID_ENT_REC
            '
            Me.lblDIR_ID_ENT_REC.AutoSize = True
            Me.lblDIR_ID_ENT_REC.Location = New System.Drawing.Point(11, 223)
            Me.lblDIR_ID_ENT_REC.Name = "lblDIR_ID_ENT_REC"
            Me.lblDIR_ID_ENT_REC.Size = New System.Drawing.Size(23, 13)
            Me.lblDIR_ID_ENT_REC.TabIndex = 60
            Me.lblDIR_ID_ENT_REC.Text = "Dir."
            '
            'txtDIR_ID_ENT_REC
            '
            Me.txtDIR_ID_ENT_REC.Location = New System.Drawing.Point(40, 223)
            Me.txtDIR_ID_ENT_REC.Name = "txtDIR_ID_ENT_REC"
            Me.txtDIR_ID_ENT_REC.Size = New System.Drawing.Size(68, 20)
            Me.txtDIR_ID_ENT_REC.TabIndex = 53
            '
            'txtDIR_DESCRIPCION_ENT_REC
            '
            Me.txtDIR_DESCRIPCION_ENT_REC.Enabled = False
            Me.txtDIR_DESCRIPCION_ENT_REC.Location = New System.Drawing.Point(114, 223)
            Me.txtDIR_DESCRIPCION_ENT_REC.Name = "txtDIR_DESCRIPCION_ENT_REC"
            Me.txtDIR_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.txtDIR_DESCRIPCION_ENT_REC.Size = New System.Drawing.Size(330, 20)
            Me.txtDIR_DESCRIPCION_ENT_REC.TabIndex = 52
            '
            'txtDIR_REFERENCIA_ENT_REC
            '
            Me.txtDIR_REFERENCIA_ENT_REC.Enabled = False
            Me.txtDIR_REFERENCIA_ENT_REC.Location = New System.Drawing.Point(454, 223)
            Me.txtDIR_REFERENCIA_ENT_REC.Name = "txtDIR_REFERENCIA_ENT_REC"
            Me.txtDIR_REFERENCIA_ENT_REC.ReadOnly = True
            Me.txtDIR_REFERENCIA_ENT_REC.Size = New System.Drawing.Size(284, 20)
            Me.txtDIR_REFERENCIA_ENT_REC.TabIndex = 151
            '
            'txtDIS_ID_ENT_REC
            '
            Me.txtDIS_ID_ENT_REC.Enabled = False
            Me.txtDIS_ID_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtDIS_ID_ENT_REC.Name = "txtDIS_ID_ENT_REC"
            Me.txtDIS_ID_ENT_REC.ReadOnly = True
            Me.txtDIS_ID_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtDIS_ID_ENT_REC.TabIndex = 138
            Me.txtDIS_ID_ENT_REC.Visible = False
            '
            'txtDIS_DESCRIPCION_ENT_REC
            '
            Me.txtDIS_DESCRIPCION_ENT_REC.Enabled = False
            Me.txtDIS_DESCRIPCION_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtDIS_DESCRIPCION_ENT_REC.Name = "txtDIS_DESCRIPCION_ENT_REC"
            Me.txtDIS_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtDIS_DESCRIPCION_ENT_REC.TabIndex = 139
            Me.txtDIS_DESCRIPCION_ENT_REC.Visible = False
            '
            'txtPRO_ID_ENT_REC
            '
            Me.txtPRO_ID_ENT_REC.Enabled = False
            Me.txtPRO_ID_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtPRO_ID_ENT_REC.Name = "txtPRO_ID_ENT_REC"
            Me.txtPRO_ID_ENT_REC.ReadOnly = True
            Me.txtPRO_ID_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtPRO_ID_ENT_REC.TabIndex = 140
            Me.txtPRO_ID_ENT_REC.Visible = False
            '
            'txtPRO_DESCRIPCION_ENT_REC
            '
            Me.txtPRO_DESCRIPCION_ENT_REC.Enabled = False
            Me.txtPRO_DESCRIPCION_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtPRO_DESCRIPCION_ENT_REC.Name = "txtPRO_DESCRIPCION_ENT_REC"
            Me.txtPRO_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtPRO_DESCRIPCION_ENT_REC.TabIndex = 141
            Me.txtPRO_DESCRIPCION_ENT_REC.Visible = False
            '
            'txtDEP_ID_ENT_REC
            '
            Me.txtDEP_ID_ENT_REC.Enabled = False
            Me.txtDEP_ID_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtDEP_ID_ENT_REC.Name = "txtDEP_ID_ENT_REC"
            Me.txtDEP_ID_ENT_REC.ReadOnly = True
            Me.txtDEP_ID_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtDEP_ID_ENT_REC.TabIndex = 142
            Me.txtDEP_ID_ENT_REC.Visible = False
            '
            'txtDEP_DESCRIPCION_ENT_REC
            '
            Me.txtDEP_DESCRIPCION_ENT_REC.Enabled = False
            Me.txtDEP_DESCRIPCION_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtDEP_DESCRIPCION_ENT_REC.Name = "txtDEP_DESCRIPCION_ENT_REC"
            Me.txtDEP_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtDEP_DESCRIPCION_ENT_REC.TabIndex = 143
            Me.txtDEP_DESCRIPCION_ENT_REC.Visible = False
            '
            'txtPAI_ID_ENT_REC
            '
            Me.txtPAI_ID_ENT_REC.Enabled = False
            Me.txtPAI_ID_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtPAI_ID_ENT_REC.Name = "txtPAI_ID_ENT_REC"
            Me.txtPAI_ID_ENT_REC.ReadOnly = True
            Me.txtPAI_ID_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtPAI_ID_ENT_REC.TabIndex = 144
            Me.txtPAI_ID_ENT_REC.Visible = False
            '
            'txtPAI_DESCRIPCION_ENT_REC
            '
            Me.txtPAI_DESCRIPCION_ENT_REC.Enabled = False
            Me.txtPAI_DESCRIPCION_ENT_REC.Location = New System.Drawing.Point(742, 223)
            Me.txtPAI_DESCRIPCION_ENT_REC.Name = "txtPAI_DESCRIPCION_ENT_REC"
            Me.txtPAI_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ENT_REC.Size = New System.Drawing.Size(6, 20)
            Me.txtPAI_DESCRIPCION_ENT_REC.TabIndex = 145
            Me.txtPAI_DESCRIPCION_ENT_REC.Visible = False
            '
            'lblPLA_ID
            '
            Me.lblPLA_ID.AutoSize = True
            Me.lblPLA_ID.Location = New System.Drawing.Point(11, 245)
            Me.lblPLA_ID.Name = "lblPLA_ID"
            Me.lblPLA_ID.Size = New System.Drawing.Size(59, 13)
            Me.lblPLA_ID.TabIndex = 209
            Me.lblPLA_ID.Text = "Cód. Placa"
            '
            'txtPLA_ID
            '
            Me.txtPLA_ID.Location = New System.Drawing.Point(80, 245)
            Me.txtPLA_ID.Name = "txtPLA_ID"
            Me.txtPLA_ID.Size = New System.Drawing.Size(35, 20)
            Me.txtPLA_ID.TabIndex = 200
            '
            'txtUNT_ID_1
            '
            Me.txtUNT_ID_1.Enabled = False
            Me.txtUNT_ID_1.Location = New System.Drawing.Point(135, 245)
            Me.txtUNT_ID_1.Name = "txtUNT_ID_1"
            Me.txtUNT_ID_1.ReadOnly = True
            Me.txtUNT_ID_1.Size = New System.Drawing.Size(109, 20)
            Me.txtUNT_ID_1.TabIndex = 201
            '
            'txtUNT_ID_2
            '
            Me.txtUNT_ID_2.Enabled = False
            Me.txtUNT_ID_2.Location = New System.Drawing.Point(246, 245)
            Me.txtUNT_ID_2.Name = "txtUNT_ID_2"
            Me.txtUNT_ID_2.ReadOnly = True
            Me.txtUNT_ID_2.Size = New System.Drawing.Size(122, 20)
            Me.txtUNT_ID_2.TabIndex = 210
            '
            'lblPER_ID_TRA1
            '
            Me.lblPER_ID_TRA1.AutoSize = True
            Me.lblPER_ID_TRA1.Location = New System.Drawing.Point(11, 266)
            Me.lblPER_ID_TRA1.Name = "lblPER_ID_TRA1"
            Me.lblPER_ID_TRA1.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_ID_TRA1.TabIndex = 207
            Me.lblPER_ID_TRA1.Text = "Transportista"
            '
            'txtPER_ID_TRA1
            '
            Me.txtPER_ID_TRA1.Location = New System.Drawing.Point(80, 266)
            Me.txtPER_ID_TRA1.Name = "txtPER_ID_TRA1"
            Me.txtPER_ID_TRA1.ReadOnly = True
            Me.txtPER_ID_TRA1.Size = New System.Drawing.Size(54, 20)
            Me.txtPER_ID_TRA1.TabIndex = 202
            '
            'txtPER_DESCRIPCION_TRA1
            '
            Me.txtPER_DESCRIPCION_TRA1.Enabled = False
            Me.txtPER_DESCRIPCION_TRA1.Location = New System.Drawing.Point(135, 266)
            Me.txtPER_DESCRIPCION_TRA1.Name = "txtPER_DESCRIPCION_TRA1"
            Me.txtPER_DESCRIPCION_TRA1.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA1.Size = New System.Drawing.Size(233, 20)
            Me.txtPER_DESCRIPCION_TRA1.TabIndex = 203
            '
            'lblRUC_TRA1
            '
            Me.lblRUC_TRA1.AutoSize = True
            Me.lblRUC_TRA1.Location = New System.Drawing.Point(382, 266)
            Me.lblRUC_TRA1.Name = "lblRUC_TRA1"
            Me.lblRUC_TRA1.Size = New System.Drawing.Size(69, 13)
            Me.lblRUC_TRA1.TabIndex = 208
            Me.lblRUC_TRA1.Text = "Doc. Transp."
            '
            'txtRUC_TRA1
            '
            Me.txtRUC_TRA1.Enabled = False
            Me.txtRUC_TRA1.Location = New System.Drawing.Point(454, 266)
            Me.txtRUC_TRA1.Name = "txtRUC_TRA1"
            Me.txtRUC_TRA1.ReadOnly = True
            Me.txtRUC_TRA1.Size = New System.Drawing.Size(208, 20)
            Me.txtRUC_TRA1.TabIndex = 204
            '
            'chkPER_ESTADO_TRA1
            '
            Me.chkPER_ESTADO_TRA1.AutoSize = True
            Me.chkPER_ESTADO_TRA1.Enabled = False
            Me.chkPER_ESTADO_TRA1.Location = New System.Drawing.Point(664, 266)
            Me.chkPER_ESTADO_TRA1.Name = "chkPER_ESTADO_TRA1"
            Me.chkPER_ESTADO_TRA1.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_TRA1.TabIndex = 205
            Me.chkPER_ESTADO_TRA1.UseVisualStyleBackColor = True
            '
            'lblPER_ID_CHO
            '
            Me.lblPER_ID_CHO.AutoSize = True
            Me.lblPER_ID_CHO.Location = New System.Drawing.Point(11, 288)
            Me.lblPER_ID_CHO.Name = "lblPER_ID_CHO"
            Me.lblPER_ID_CHO.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_ID_CHO.TabIndex = 216
            Me.lblPER_ID_CHO.Text = "Chofer"
            '
            'txtPER_ID_CHO
            '
            Me.txtPER_ID_CHO.Enabled = False
            Me.txtPER_ID_CHO.Location = New System.Drawing.Point(80, 288)
            Me.txtPER_ID_CHO.Name = "txtPER_ID_CHO"
            Me.txtPER_ID_CHO.ReadOnly = True
            Me.txtPER_ID_CHO.Size = New System.Drawing.Size(54, 20)
            Me.txtPER_ID_CHO.TabIndex = 212
            '
            'txtPER_DESCRIPCION_CHO
            '
            Me.txtPER_DESCRIPCION_CHO.Enabled = False
            Me.txtPER_DESCRIPCION_CHO.Location = New System.Drawing.Point(135, 288)
            Me.txtPER_DESCRIPCION_CHO.Name = "txtPER_DESCRIPCION_CHO"
            Me.txtPER_DESCRIPCION_CHO.ReadOnly = True
            Me.txtPER_DESCRIPCION_CHO.Size = New System.Drawing.Size(233, 20)
            Me.txtPER_DESCRIPCION_CHO.TabIndex = 213
            '
            'lblPER_BREVETE_CHO
            '
            Me.lblPER_BREVETE_CHO.AutoSize = True
            Me.lblPER_BREVETE_CHO.Location = New System.Drawing.Point(382, 288)
            Me.lblPER_BREVETE_CHO.Name = "lblPER_BREVETE_CHO"
            Me.lblPER_BREVETE_CHO.Size = New System.Drawing.Size(44, 13)
            Me.lblPER_BREVETE_CHO.TabIndex = 217
            Me.lblPER_BREVETE_CHO.Text = "Brevete"
            '
            'txtPER_BREVETE_CHO
            '
            Me.txtPER_BREVETE_CHO.Enabled = False
            Me.txtPER_BREVETE_CHO.Location = New System.Drawing.Point(454, 288)
            Me.txtPER_BREVETE_CHO.Name = "txtPER_BREVETE_CHO"
            Me.txtPER_BREVETE_CHO.ReadOnly = True
            Me.txtPER_BREVETE_CHO.Size = New System.Drawing.Size(208, 20)
            Me.txtPER_BREVETE_CHO.TabIndex = 214
            '
            'chkPER_ESTADO_CHO
            '
            Me.chkPER_ESTADO_CHO.AutoSize = True
            Me.chkPER_ESTADO_CHO.Enabled = False
            Me.chkPER_ESTADO_CHO.Location = New System.Drawing.Point(664, 288)
            Me.chkPER_ESTADO_CHO.Name = "chkPER_ESTADO_CHO"
            Me.chkPER_ESTADO_CHO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_CHO.TabIndex = 215
            Me.chkPER_ESTADO_CHO.UseVisualStyleBackColor = True
            '
            'dgvArticulosDocumento
            '
            Me.dgvArticulosDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvArticulosDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvArticulosDocumento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cTDO_ID_DOC1, Me.cDTD_ID_DOC1, Me.cDOC_SERIE_DOC1, Me.cDOC_NUMERO_DOC1, Me.cART_ID_KAR1, Me.cART_DESCRIPCION_KAR1, Me.cDDO_CANTIDAD_VENDIDA1, Me.cDDO_CANTIDAD_MOVIDA1, Me.cDDO_CANTIDAD_SALDO1, Me.cMover1, Me.cEstadoRegistro1})
            Me.dgvArticulosDocumento.Location = New System.Drawing.Point(11, 193)
            Me.dgvArticulosDocumento.Name = "dgvArticulosDocumento"
            Me.dgvArticulosDocumento.Size = New System.Drawing.Size(729, 121)
            Me.dgvArticulosDocumento.TabIndex = 224
            '
            'cTDO_ID_DOC1
            '
            Me.cTDO_ID_DOC1.HeaderText = "TDO_ID"
            Me.cTDO_ID_DOC1.Name = "cTDO_ID_DOC1"
            Me.cTDO_ID_DOC1.ReadOnly = True
            Me.cTDO_ID_DOC1.Visible = False
            Me.cTDO_ID_DOC1.Width = 72
            '
            'cDTD_ID_DOC1
            '
            Me.cDTD_ID_DOC1.HeaderText = "DTD_ID"
            Me.cDTD_ID_DOC1.Name = "cDTD_ID_DOC1"
            Me.cDTD_ID_DOC1.ReadOnly = True
            Me.cDTD_ID_DOC1.Visible = False
            Me.cDTD_ID_DOC1.Width = 72
            '
            'cDOC_SERIE_DOC1
            '
            Me.cDOC_SERIE_DOC1.HeaderText = "DOC_SERIE"
            Me.cDOC_SERIE_DOC1.Name = "cDOC_SERIE_DOC1"
            Me.cDOC_SERIE_DOC1.ReadOnly = True
            Me.cDOC_SERIE_DOC1.Visible = False
            Me.cDOC_SERIE_DOC1.Width = 93
            '
            'cDOC_NUMERO_DOC1
            '
            Me.cDOC_NUMERO_DOC1.HeaderText = "DOC_NUMERO"
            Me.cDOC_NUMERO_DOC1.Name = "cDOC_NUMERO_DOC1"
            Me.cDOC_NUMERO_DOC1.ReadOnly = True
            Me.cDOC_NUMERO_DOC1.Visible = False
            Me.cDOC_NUMERO_DOC1.Width = 109
            '
            'cART_ID_KAR1
            '
            Me.cART_ID_KAR1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.cART_ID_KAR1.HeaderText = "Código artículo"
            Me.cART_ID_KAR1.Name = "cART_ID_KAR1"
            Me.cART_ID_KAR1.ReadOnly = True
            Me.cART_ID_KAR1.Width = 96
            '
            'cART_DESCRIPCION_KAR1
            '
            Me.cART_DESCRIPCION_KAR1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.cART_DESCRIPCION_KAR1.HeaderText = "Descripción"
            Me.cART_DESCRIPCION_KAR1.Name = "cART_DESCRIPCION_KAR1"
            Me.cART_DESCRIPCION_KAR1.ReadOnly = True
            Me.cART_DESCRIPCION_KAR1.Width = 88
            '
            'cDDO_CANTIDAD_VENDIDA1
            '
            Me.cDDO_CANTIDAD_VENDIDA1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle1.Format = "N3"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.cDDO_CANTIDAD_VENDIDA1.DefaultCellStyle = DataGridViewCellStyle1
            Me.cDDO_CANTIDAD_VENDIDA1.HeaderText = "Cantidad vendida"
            Me.cDDO_CANTIDAD_VENDIDA1.Name = "cDDO_CANTIDAD_VENDIDA1"
            Me.cDDO_CANTIDAD_VENDIDA1.ReadOnly = True
            Me.cDDO_CANTIDAD_VENDIDA1.Width = 105
            '
            'cDDO_CANTIDAD_MOVIDA1
            '
            Me.cDDO_CANTIDAD_MOVIDA1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.cDDO_CANTIDAD_MOVIDA1.DefaultCellStyle = DataGridViewCellStyle2
            Me.cDDO_CANTIDAD_MOVIDA1.HeaderText = "Cantidad movida"
            Me.cDDO_CANTIDAD_MOVIDA1.Name = "cDDO_CANTIDAD_MOVIDA1"
            Me.cDDO_CANTIDAD_MOVIDA1.ReadOnly = True
            Me.cDDO_CANTIDAD_MOVIDA1.Width = 102
            '
            'cDDO_CANTIDAD_SALDO1
            '
            Me.cDDO_CANTIDAD_SALDO1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle3.Format = "N4"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.cDDO_CANTIDAD_SALDO1.DefaultCellStyle = DataGridViewCellStyle3
            Me.cDDO_CANTIDAD_SALDO1.HeaderText = "Saldo"
            Me.cDDO_CANTIDAD_SALDO1.Name = "cDDO_CANTIDAD_SALDO1"
            Me.cDDO_CANTIDAD_SALDO1.ReadOnly = True
            Me.cDDO_CANTIDAD_SALDO1.Width = 59
            '
            'cMover1
            '
            Me.cMover1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.cMover1.HeaderText = "Cantidad a despachar"
            Me.cMover1.Name = "cMover1"
            Me.cMover1.Width = 124
            '
            'cEstadoRegistro1
            '
            Me.cEstadoRegistro1.HeaderText = "Estado de registro"
            Me.cEstadoRegistro1.Name = "cEstadoRegistro1"
            Me.cEstadoRegistro1.ReadOnly = True
            Me.cEstadoRegistro1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.cEstadoRegistro1.Visible = False
            Me.cEstadoRegistro1.Width = 88
            '
            'dgvSaldosMontoDocumento
            '
            Me.dgvSaldosMontoDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvSaldosMontoDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvSaldosMontoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSaldosMontoDocumento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPER_ID_CLI, Me.cPER_DESCRIPCION_CLI, Me.cSaldo, Me.cMON_ID, Me.cMON_DESCRIPCION})
            Me.dgvSaldosMontoDocumento.Location = New System.Drawing.Point(11, 193)
            Me.dgvSaldosMontoDocumento.Name = "dgvSaldosMontoDocumento"
            Me.dgvSaldosMontoDocumento.Size = New System.Drawing.Size(729, 121)
            Me.dgvSaldosMontoDocumento.TabIndex = 229
            '
            'cPER_ID_CLI
            '
            Me.cPER_ID_CLI.HeaderText = "PER_ID_CLI"
            Me.cPER_ID_CLI.Name = "cPER_ID_CLI"
            Me.cPER_ID_CLI.ReadOnly = True
            Me.cPER_ID_CLI.Visible = False
            Me.cPER_ID_CLI.Width = 93
            '
            'cPER_DESCRIPCION_CLI
            '
            Me.cPER_DESCRIPCION_CLI.HeaderText = "PER_DESCRIPCION_CLI"
            Me.cPER_DESCRIPCION_CLI.Name = "cPER_DESCRIPCION_CLI"
            Me.cPER_DESCRIPCION_CLI.ReadOnly = True
            Me.cPER_DESCRIPCION_CLI.Visible = False
            Me.cPER_DESCRIPCION_CLI.Width = 155
            '
            'cSaldo
            '
            Me.cSaldo.HeaderText = "Saldo"
            Me.cSaldo.Name = "cSaldo"
            Me.cSaldo.ReadOnly = True
            Me.cSaldo.Width = 59
            '
            'cMON_ID
            '
            Me.cMON_ID.HeaderText = "Código moneda"
            Me.cMON_ID.Name = "cMON_ID"
            Me.cMON_ID.ReadOnly = True
            Me.cMON_ID.Width = 97
            '
            'cMON_DESCRIPCION
            '
            Me.cMON_DESCRIPCION.HeaderText = "Descripción moneda"
            Me.cMON_DESCRIPCION.Name = "cMON_DESCRIPCION"
            Me.cMON_DESCRIPCION.ReadOnly = True
            Me.cMON_DESCRIPCION.Width = 118
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cITEM, Me.cART_ID_IMP, Me.cART_DESCRIPCION_IMP, Me.cART_FACTOR_IMP, Me.cART_ESTADO_IMP, Me.cART_ID_KAR, Me.cART_DESCRIPCION_KAR, Me.cART_FACTOR_KAR, Me.cART_ESTADO_KAR, Me.cDDE_CANTIDAD, Me.cDDE_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(11, 342)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(729, 107)
            Me.dgvDetalle.TabIndex = 11
            '
            'btnImagen
            '
            Me.btnImagen.Image = CType(resources.GetObject("btnImagen.Image"), System.Drawing.Image)
            Me.btnImagen.Location = New System.Drawing.Point(745, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(49, 28)
            Me.btnImagen.TabIndex = 194
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ssDespachos
            '
            Me.ssDespachos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslFechaServidor, Me.tslSeparador1, Me.tslTipoCambioCompraMoneda, Me.tslSeparador2, Me.tslTipoCambioVentaMoneda})
            Me.ssDespachos.Location = New System.Drawing.Point(0, 537)
            Me.ssDespachos.Name = "ssDespachos"
            Me.ssDespachos.Size = New System.Drawing.Size(825, 22)
            Me.ssDespachos.TabIndex = 195
            '
            'tslFechaServidor
            '
            Me.tslFechaServidor.Name = "tslFechaServidor"
            Me.tslFechaServidor.Size = New System.Drawing.Size(41, 17)
            Me.tslFechaServidor.Text = "    /  /  "
            '
            'tslSeparador1
            '
            Me.tslSeparador1.Name = "tslSeparador1"
            Me.tslSeparador1.Size = New System.Drawing.Size(12, 17)
            Me.tslSeparador1.Text = "-"
            '
            'tslTipoCambioCompraMoneda
            '
            Me.tslTipoCambioCompraMoneda.Name = "tslTipoCambioCompraMoneda"
            Me.tslTipoCambioCompraMoneda.Size = New System.Drawing.Size(40, 17)
            Me.tslTipoCambioCompraMoneda.Text = "0.0000"
            '
            'tslSeparador2
            '
            Me.tslSeparador2.Name = "tslSeparador2"
            Me.tslSeparador2.Size = New System.Drawing.Size(12, 17)
            Me.tslSeparador2.Text = "-"
            '
            'tslTipoCambioVentaMoneda
            '
            Me.tslTipoCambioVentaMoneda.Name = "tslTipoCambioVentaMoneda"
            Me.tslTipoCambioVentaMoneda.Size = New System.Drawing.Size(40, 17)
            Me.tslTipoCambioVentaMoneda.Text = "0.0000"
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "TDO_ID"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            Me.DataGridViewTextBoxColumn1.Width = 72
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "DTD_ID"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            Me.DataGridViewTextBoxColumn2.Width = 72
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "DOC_SERIE"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            Me.DataGridViewTextBoxColumn3.Width = 93
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "DOC_NUMERO"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Visible = False
            Me.DataGridViewTextBoxColumn4.Width = 109
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn5.HeaderText = "Código artículo"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn6.HeaderText = "Descripción"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle7.Format = "N3"
            DataGridViewCellStyle7.NullValue = Nothing
            Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewTextBoxColumn7.HeaderText = "Cantidad vendida"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewTextBoxColumn8.HeaderText = "Cantidad movida"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle9.Format = "N4"
            DataGridViewCellStyle9.NullValue = Nothing
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewTextBoxColumn9.HeaderText = "Saldo"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn10.HeaderText = "Cantidad a despachar"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.HeaderText = "Estado de registro"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.DataGridViewTextBoxColumn11.Visible = False
            Me.DataGridViewTextBoxColumn11.Width = 88
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.HeaderText = "PER_ID_CLI"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.ReadOnly = True
            Me.DataGridViewTextBoxColumn12.Visible = False
            Me.DataGridViewTextBoxColumn12.Width = 93
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.HeaderText = "PER_DESCRIPCION_CLI"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            Me.DataGridViewTextBoxColumn13.Visible = False
            Me.DataGridViewTextBoxColumn13.Width = 155
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.HeaderText = "Saldo"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            Me.DataGridViewTextBoxColumn14.ReadOnly = True
            Me.DataGridViewTextBoxColumn14.Width = 59
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.HeaderText = "Código moneda"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            Me.DataGridViewTextBoxColumn15.ReadOnly = True
            Me.DataGridViewTextBoxColumn15.Width = 97
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.HeaderText = "Descripción moneda"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            Me.DataGridViewTextBoxColumn16.ReadOnly = True
            Me.DataGridViewTextBoxColumn16.Width = 118
            '
            'DataGridViewTextBoxColumn17
            '
            Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DataGridViewTextBoxColumn17.HeaderText = "Item"
            Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
            Me.DataGridViewTextBoxColumn17.ReadOnly = True
            Me.DataGridViewTextBoxColumn17.Width = 5
            '
            'DataGridViewTextBoxColumn18
            '
            Me.DataGridViewTextBoxColumn18.HeaderText = "Cód. Art."
            Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
            Me.DataGridViewTextBoxColumn18.ReadOnly = True
            Me.DataGridViewTextBoxColumn18.Visible = False
            Me.DataGridViewTextBoxColumn18.Width = 73
            '
            'DataGridViewTextBoxColumn19
            '
            Me.DataGridViewTextBoxColumn19.HeaderText = "Desc. Art."
            Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
            Me.DataGridViewTextBoxColumn19.ReadOnly = True
            Me.DataGridViewTextBoxColumn19.Visible = False
            Me.DataGridViewTextBoxColumn19.Width = 79
            '
            'DataGridViewTextBoxColumn20
            '
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewTextBoxColumn20.HeaderText = "Factor Conversión Art."
            Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
            Me.DataGridViewTextBoxColumn20.ReadOnly = True
            Me.DataGridViewTextBoxColumn20.Visible = False
            Me.DataGridViewTextBoxColumn20.Width = 137
            '
            'DataGridViewTextBoxColumn21
            '
            Me.DataGridViewTextBoxColumn21.HeaderText = "Código artículo"
            Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
            Me.DataGridViewTextBoxColumn21.ReadOnly = True
            Me.DataGridViewTextBoxColumn21.Width = 96
            '
            'DataGridViewTextBoxColumn22
            '
            Me.DataGridViewTextBoxColumn22.HeaderText = "Descripción artículo"
            Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
            Me.DataGridViewTextBoxColumn22.ReadOnly = True
            Me.DataGridViewTextBoxColumn22.Width = 116
            '
            'DataGridViewTextBoxColumn23
            '
            Me.DataGridViewTextBoxColumn23.HeaderText = "Factor Conversión"
            Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
            Me.DataGridViewTextBoxColumn23.ReadOnly = True
            Me.DataGridViewTextBoxColumn23.Visible = False
            Me.DataGridViewTextBoxColumn23.Width = 108
            '
            'DataGridViewTextBoxColumn24
            '
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle11.Format = "N4"
            DataGridViewCellStyle11.NullValue = Nothing
            Me.DataGridViewTextBoxColumn24.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewTextBoxColumn24.HeaderText = "Cantidad"
            Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
            Me.DataGridViewTextBoxColumn24.ReadOnly = True
            Me.DataGridViewTextBoxColumn24.Width = 74
            '
            'DataGridViewTextBoxColumn25
            '
            Me.DataGridViewTextBoxColumn25.HeaderText = "Estado de registro"
            Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
            Me.DataGridViewTextBoxColumn25.ReadOnly = True
            Me.DataGridViewTextBoxColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.DataGridViewTextBoxColumn25.Visible = False
            Me.DataGridViewTextBoxColumn25.Width = 88
            '
            'DataFormatoVenta141
            '
            Me.DataFormatoVenta141.DataSetName = "DataFormatoVenta14"
            Me.DataFormatoVenta141.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'DataFormatoVenta142
            '
            Me.DataFormatoVenta142.DataSetName = "DataFormatoVenta14"
            Me.DataFormatoVenta142.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'cITEM
            '
            Me.cITEM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.cITEM.HeaderText = "Item"
            Me.cITEM.Name = "cITEM"
            Me.cITEM.ReadOnly = True
            Me.cITEM.Width = 5
            '
            'cART_ID_IMP
            '
            Me.cART_ID_IMP.HeaderText = "Cód. Art."
            Me.cART_ID_IMP.Name = "cART_ID_IMP"
            Me.cART_ID_IMP.ReadOnly = True
            Me.cART_ID_IMP.Visible = False
            Me.cART_ID_IMP.Width = 73
            '
            'cART_DESCRIPCION_IMP
            '
            Me.cART_DESCRIPCION_IMP.HeaderText = "Desc. Art."
            Me.cART_DESCRIPCION_IMP.Name = "cART_DESCRIPCION_IMP"
            Me.cART_DESCRIPCION_IMP.ReadOnly = True
            Me.cART_DESCRIPCION_IMP.Visible = False
            Me.cART_DESCRIPCION_IMP.Width = 79
            '
            'cART_FACTOR_IMP
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.cART_FACTOR_IMP.DefaultCellStyle = DataGridViewCellStyle4
            Me.cART_FACTOR_IMP.HeaderText = "Factor Conversión Art."
            Me.cART_FACTOR_IMP.Name = "cART_FACTOR_IMP"
            Me.cART_FACTOR_IMP.ReadOnly = True
            Me.cART_FACTOR_IMP.Visible = False
            Me.cART_FACTOR_IMP.Width = 137
            '
            'cART_ESTADO_IMP
            '
            Me.cART_ESTADO_IMP.HeaderText = "Est. Art."
            Me.cART_ESTADO_IMP.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cART_ESTADO_IMP.Name = "cART_ESTADO_IMP"
            Me.cART_ESTADO_IMP.ReadOnly = True
            Me.cART_ESTADO_IMP.Visible = False
            Me.cART_ESTADO_IMP.Width = 50
            '
            'cART_ID_KAR
            '
            Me.cART_ID_KAR.HeaderText = "Código artículo"
            Me.cART_ID_KAR.Name = "cART_ID_KAR"
            Me.cART_ID_KAR.ReadOnly = True
            Me.cART_ID_KAR.Width = 96
            '
            'cART_DESCRIPCION_KAR
            '
            Me.cART_DESCRIPCION_KAR.HeaderText = "Descripción artículo"
            Me.cART_DESCRIPCION_KAR.Name = "cART_DESCRIPCION_KAR"
            Me.cART_DESCRIPCION_KAR.ReadOnly = True
            Me.cART_DESCRIPCION_KAR.Width = 116
            '
            'cART_FACTOR_KAR
            '
            Me.cART_FACTOR_KAR.HeaderText = "Factor Conversión"
            Me.cART_FACTOR_KAR.Name = "cART_FACTOR_KAR"
            Me.cART_FACTOR_KAR.ReadOnly = True
            Me.cART_FACTOR_KAR.Visible = False
            Me.cART_FACTOR_KAR.Width = 108
            '
            'cART_ESTADO_KAR
            '
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle5.Format = "N3"
            Me.cART_ESTADO_KAR.DefaultCellStyle = DataGridViewCellStyle5
            Me.cART_ESTADO_KAR.HeaderText = "Estado"
            Me.cART_ESTADO_KAR.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cART_ESTADO_KAR.Name = "cART_ESTADO_KAR"
            Me.cART_ESTADO_KAR.ReadOnly = True
            Me.cART_ESTADO_KAR.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cART_ESTADO_KAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cART_ESTADO_KAR.Visible = False
            Me.cART_ESTADO_KAR.Width = 65
            '
            'cDDE_CANTIDAD
            '
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle6.Format = "N3"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.cDDE_CANTIDAD.DefaultCellStyle = DataGridViewCellStyle6
            Me.cDDE_CANTIDAD.HeaderText = "Cantidad"
            Me.cDDE_CANTIDAD.Name = "cDDE_CANTIDAD"
            Me.cDDE_CANTIDAD.ReadOnly = True
            Me.cDDE_CANTIDAD.Width = 74
            '
            'cDDE_ESTADO
            '
            Me.cDDE_ESTADO.HeaderText = "Estado detalle"
            Me.cDDE_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDDE_ESTADO.Name = "cDDE_ESTADO"
            Me.cDDE_ESTADO.ReadOnly = True
            Me.cDDE_ESTADO.Width = 72
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            Me.cEstadoRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'frmDespachos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(825, 559)
            Me.Controls.Add(Me.ssDespachos)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDespachos"
            Me.Text = "Despachos"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.ssDespachos, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcoDirecciones.ResumeLayout(False)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.tcoDetalle.ResumeLayout(False)
            CType(Me.dgvArticulosDocumento, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvSaldosMontoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ssDespachos.ResumeLayout(False)
            Me.ssDespachos.PerformLayout()
            CType(Me.DataFormatoVenta141, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataFormatoVenta142, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
        Public WithEvents cboSerieCorrelativo As System.Windows.Forms.ComboBox
        Public WithEvents txtDES_SERIE As System.Windows.Forms.TextBox
        Friend WithEvents lblSeparador As System.Windows.Forms.Label
        Public WithEvents txtDES_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents lblDES_FECHA_EMI As System.Windows.Forms.Label
        Public WithEvents dtpDES_FEC_EMI As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDES_FECHA_TRA As System.Windows.Forms.Label
        Public WithEvents dtpDES_FEC_TRA As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblALM_ID As System.Windows.Forms.Label
        Public WithEvents txtALM_ID As System.Windows.Forms.TextBox
        Public WithEvents txtALM_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblTIV_ID As System.Windows.Forms.Label
        Public WithEvents txtTIV_ID_DOC As System.Windows.Forms.TextBox
        Public WithEvents txtTIV_DESCRIPCION_DOC As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_CLI As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Friend WithEvents lblTDP_ID_CLI As System.Windows.Forms.Label
        Public WithEvents txtTDP_ID_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtTDP_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtDOP_NUMERO_CLI As System.Windows.Forms.TextBox
        Friend WithEvents tcoDirecciones As System.Windows.Forms.TabControl
        Friend WithEvents tpaEntrega As System.Windows.Forms.TabPage
        Friend WithEvents tpaRecepciona As System.Windows.Forms.TabPage
        Public WithEvents txtALM_DIRECCION As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_ID_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_DESCRIPCION_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_ID_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_DESCRIPCION_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_ID_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_DESCRIPCION_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_ID_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_DESCRIPCION_ALM As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_ID_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_DESCRIPCION_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_REFERENCIA_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_ID_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_DESCRIPCION_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_ID_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_DESCRIPCION_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_ID_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_DESCRIPCION_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_ID_ENT As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_DESCRIPCION_ENT As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_REC As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_REC As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_REC As System.Windows.Forms.TextBox
        Friend WithEvents lblTDP_ID_REC As System.Windows.Forms.Label
        Public WithEvents txtTDP_ID_REC As System.Windows.Forms.TextBox
        Public WithEvents txtTDP_DESCRIPCION_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDOP_NUMERO_REC As System.Windows.Forms.TextBox
        Friend WithEvents lblDIR_ID_ENT_REC As System.Windows.Forms.Label
        Public WithEvents txtDIR_ID_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_DESCRIPCION_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_REFERENCIA_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_ID_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_DESCRIPCION_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_ID_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_DESCRIPCION_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_ID_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_DESCRIPCION_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_ID_ENT_REC As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_DESCRIPCION_ENT_REC As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_ID_DOC As System.Windows.Forms.Label
        Public WithEvents txtTDO_ID_DOC As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_ID_DOC As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_DESCRIPCION_DOC As System.Windows.Forms.TextBox
        Friend WithEvents lblDOC_SERIE_DOC As System.Windows.Forms.Label
        Public WithEvents txtDES_SERIE_DOC As System.Windows.Forms.TextBox
        Friend WithEvents lblSeparador1 As System.Windows.Forms.Label
        Public WithEvents txtDES_NUMERO_DOC As System.Windows.Forms.TextBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblFLE_ID As System.Windows.Forms.Label
        Public WithEvents txtFLE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtFLE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDES_MONTO_FLETE As System.Windows.Forms.TextBox
        Friend WithEvents lblPLA_ID As System.Windows.Forms.Label
        Public WithEvents txtPLA_ID As System.Windows.Forms.TextBox
        Public WithEvents txtRUC_TRA1 As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_TRA1 As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO_TRA1 As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_ID_1 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_ID_2 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_BREVETE_CHO As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_BREVETE_CHO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_CHO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO_CHO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_CHO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_CHO As System.Windows.Forms.TextBox
        Public WithEvents chkALM_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblRUC_TRA1 As System.Windows.Forms.Label
        Friend WithEvents lblDES_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCCT_ID As System.Windows.Forms.Label
        Public WithEvents txtCCT_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCCT_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents tpaDocumento As System.Windows.Forms.TabPage
        Public WithEvents dgvArticulosDocumento As System.Windows.Forms.DataGridView
        Friend WithEvents ssDespachos As System.Windows.Forms.StatusStrip
        Friend WithEvents tslFechaServidor As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslSeparador1 As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslTipoCambioCompraMoneda As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslSeparador2 As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslTipoCambioVentaMoneda As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDOC_TIPO_LISTA As System.Windows.Forms.TextBox
        Public WithEvents dgvSaldosMontoDocumento As System.Windows.Forms.DataGridView
        Friend WithEvents cPER_ID_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tpaSaldo As System.Windows.Forms.TabPage
        Friend WithEvents cTDO_ID_DOC1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID_DOC1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOC_SERIE_DOC1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOC_NUMERO_DOC1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ID_KAR1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION_KAR1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDO_CANTIDAD_VENDIDA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDO_CANTIDAD_MOVIDA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDO_CANTIDAD_SALDO1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMover1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cEstadoRegistro1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents txtPAI_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_ID_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_ID_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_ID_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_ID_ALM_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtALM_DIRECCION_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents chkALM_ESTADO_LLEGADA As System.Windows.Forms.CheckBox
        Public WithEvents txtALM_DESCRIPCION_LLEGADA As System.Windows.Forms.TextBox
        Public WithEvents txtALM_ID_LLEGADA As System.Windows.Forms.TextBox
        Friend WithEvents lblALM_ID_LLEGADA As System.Windows.Forms.Label
        Friend WithEvents btnImpresion As System.Windows.Forms.Button
        Public WithEvents txtPER_DESCRIPCION_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_VEN1 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_VEN1 As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_VEN1 As System.Windows.Forms.Label
        Friend WithEvents btnProcesarCronogramaDespacho As System.Windows.Forms.Button
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents cboDES_ESTADO As System.Windows.Forms.ComboBox
        Friend WithEvents DataFormatoVenta141 As DataFormatoVenta14
        Friend WithEvents DataFormatoVenta142 As DataFormatoVenta14
        Friend WithEvents lblCERTIFICADO As System.Windows.Forms.Label
        Public WithEvents txtCertificado As System.Windows.Forms.TextBox
        Friend WithEvents lblTipoGuia As System.Windows.Forms.Label
        Friend WithEvents tcoDetalle As System.Windows.Forms.TabControl
        Friend WithEvents tpaArticulosGuia As System.Windows.Forms.TabPage
        Public WithEvents cboDes_Tipo_Guia As System.Windows.Forms.ComboBox
        Friend WithEvents btnOrdenDespacho As System.Windows.Forms.Button
        Public WithEvents dtpDES_FEC_SAL_PLA As System.Windows.Forms.DateTimePicker
        Friend WithEvents cITEM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ID_IMP As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION_IMP As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_FACTOR_IMP As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ESTADO_IMP As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cART_ID_KAR As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION_KAR As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_FACTOR_KAR As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ESTADO_KAR As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDDE_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDE_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace