Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMarcarSalidaGuia
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
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcarSalidaGuia))
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.tcoDirecciones = New System.Windows.Forms.TabControl()
            Me.tpaEntrega = New System.Windows.Forms.TabPage()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.txtDIR_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIR_REFERENCIA_ENT = New System.Windows.Forms.TextBox()
            Me.txtDES_SERIE = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ENT = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID_DOC = New System.Windows.Forms.TextBox()
            Me.txtDIS_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION_ALM = New System.Windows.Forms.TextBox()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.lblCERTIFICADO = New System.Windows.Forms.Label()
            Me.txtCertificado = New System.Windows.Forms.TextBox()
            Me.dtpDES_FEC_TRA = New System.Windows.Forms.DateTimePicker()
            Me.dtpDES_FEC_EMI = New System.Windows.Forms.DateTimePicker()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.cboSerieCorrelativo = New System.Windows.Forms.ComboBox()
            Me.txtDES_NUMERO = New System.Windows.Forms.TextBox()
            Me.cboDES_ESTADO = New System.Windows.Forms.ComboBox()
            Me.btnProcesarCronogramaDespacho = New System.Windows.Forms.Button()
            Me.txtDES_NUMERO_DOC = New System.Windows.Forms.TextBox()
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
            Me.txtPRO_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ALM = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ALM = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_CLI = New System.Windows.Forms.Label()
            Me.txtPER_ID_CLI = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID_DOC = New System.Windows.Forms.Label()
            Me.txtTDO_ID_DOC = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION_DOC = New System.Windows.Forms.TextBox()
            Me.lblDOC_SERIE_DOC = New System.Windows.Forms.Label()
            Me.txtDES_SERIE_DOC = New System.Windows.Forms.TextBox()
            Me.lblSeparador1 = New System.Windows.Forms.Label()
            Me.txtDOC_TIPO_LISTA = New System.Windows.Forms.TextBox()
            Me.txtDIR_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtDIS_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtPRO_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtDEP_ID_ENT = New System.Windows.Forms.TextBox()
            Me.txtPAI_ID_ENT = New System.Windows.Forms.TextBox()
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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtBuscarSerie = New System.Windows.Forms.TextBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.lbltxt = New System.Windows.Forms.Label()
            Me.txtUNT_ID = New System.Windows.Forms.TextBox()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.cChecked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.cTDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_CARGO_ABONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_SIGNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_SIGNO_D = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_FEC_EMI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_FEC_TRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_FEC_SAL_PLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_FEC_CAR_DES = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_FEC_PRO_CRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPVE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPVE_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPVE_DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ID_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ESTADO_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ID_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ESTADO_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ID_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ESTADO_PVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ID_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ESTADO_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ID_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ESTADO_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ID_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ESTADO_ALM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_ID_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_DESCRIPCION_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_DIRECCION_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ID_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ESTADO_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ID_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ESTADO_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ID_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ESTADO_ALM_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cALM_ESTADO_LLEGADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ID_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_ID_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_DESCRIPCION_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOP_NUMERO_CLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ID_VEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_VEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOC_ORDEN_COMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTIV_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTIV_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOC_TIPO_LISTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_SERIE_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_NUMERO_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ID_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_ID_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDP_DESCRIPCION_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDOP_NUMERO_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_ID_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_DESCRIPCION_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_TIPO_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_REFERENCIA_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ID_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ID_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ID_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_ESTADO_ENT_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_ID_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_DESCRIPCION_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_DESCRIPCION_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ID_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ESTADO_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ID_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ESTADO_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ID_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAIS_ESTADO_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIR_REFERENCIA_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cFLE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cFLE_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cFLE_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cFLE_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMON_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_MONTO_FLETE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_CONTRAVALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPLA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ID_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cRUC_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ESTADO_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cUNT_ID_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMAR_DESCRIPCION_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMOD_DESCRIPCION_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cUNT_NRO_INS_TRA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cUNT_ID_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMAR_DESCRIPCION_TRA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cMOD_DESCRIPCION_TRA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cUNT_NRO_INS_TRA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ID_CHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_DESCRIPCION_CHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_BREVETE_CHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPER_ESTADO_CHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDES_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
            Me.txtDES_NUMERO_X = New System.Windows.Forms.TextBox()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcoDirecciones.SuspendLayout()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ssDespachos.SuspendLayout()
            CType(Me.DataFormatoVenta141, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataFormatoVenta142, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.MinimumSize = New System.Drawing.Size(825, 28)
            Me.lblTitle.Size = New System.Drawing.Size(825, 28)
            Me.lblTitle.Text = "Marcar salida de guía"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'tcoDirecciones
            '
            Me.tcoDirecciones.Controls.Add(Me.tpaEntrega)
            Me.tcoDirecciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tcoDirecciones.Location = New System.Drawing.Point(11, 260)
            Me.tcoDirecciones.Name = "tcoDirecciones"
            Me.tcoDirecciones.SelectedIndex = 0
            Me.tcoDirecciones.Size = New System.Drawing.Size(79, 25)
            Me.tcoDirecciones.TabIndex = 135
            '
            'tpaEntrega
            '
            Me.tpaEntrega.Location = New System.Drawing.Point(4, 21)
            Me.tpaEntrega.Name = "tpaEntrega"
            Me.tpaEntrega.Padding = New System.Windows.Forms.Padding(3)
            Me.tpaEntrega.Size = New System.Drawing.Size(71, 0)
            Me.tpaEntrega.TabIndex = 3
            Me.tpaEntrega.Text = "Dir. entrega"
            Me.tpaEntrega.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtDIR_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_REFERENCIA_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDES_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION_ALM)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCERTIFICADO)
            Me.pnCuerpo.Controls.Add(Me.txtCertificado)
            Me.pnCuerpo.Controls.Add(Me.dtpDES_FEC_TRA)
            Me.pnCuerpo.Controls.Add(Me.dtpDES_FEC_EMI)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.cboSerieCorrelativo)
            Me.pnCuerpo.Controls.Add(Me.txtDES_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.cboDES_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.btnProcesarCronogramaDespacho)
            Me.pnCuerpo.Controls.Add(Me.txtDES_NUMERO_DOC)
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
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ALM)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblDOC_SERIE_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtDES_SERIE_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblSeparador1)
            Me.pnCuerpo.Controls.Add(Me.txtDOC_TIPO_LISTA)
            Me.pnCuerpo.Controls.Add(Me.tcoDirecciones)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID_ENT)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID_ENT)
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
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(760, 481)
            Me.pnCuerpo.TabIndex = 123
            '
            'txtDIR_DESCRIPCION_ENT
            '
            Me.txtDIR_DESCRIPCION_ENT.BackColor = System.Drawing.Color.White
            Me.txtDIR_DESCRIPCION_ENT.Enabled = False
            Me.txtDIR_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIR_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtDIR_DESCRIPCION_ENT.Location = New System.Drawing.Point(170, 260)
            Me.txtDIR_DESCRIPCION_ENT.Multiline = True
            Me.txtDIR_DESCRIPCION_ENT.Name = "txtDIR_DESCRIPCION_ENT"
            Me.txtDIR_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDIR_DESCRIPCION_ENT.Size = New System.Drawing.Size(267, 36)
            Me.txtDIR_DESCRIPCION_ENT.TabIndex = 43
            '
            'txtDIR_REFERENCIA_ENT
            '
            Me.txtDIR_REFERENCIA_ENT.BackColor = System.Drawing.Color.White
            Me.txtDIR_REFERENCIA_ENT.Enabled = False
            Me.txtDIR_REFERENCIA_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIR_REFERENCIA_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtDIR_REFERENCIA_ENT.Location = New System.Drawing.Point(462, 260)
            Me.txtDIR_REFERENCIA_ENT.Multiline = True
            Me.txtDIR_REFERENCIA_ENT.Name = "txtDIR_REFERENCIA_ENT"
            Me.txtDIR_REFERENCIA_ENT.ReadOnly = True
            Me.txtDIR_REFERENCIA_ENT.Size = New System.Drawing.Size(277, 36)
            Me.txtDIR_REFERENCIA_ENT.TabIndex = 149
            '
            'txtDES_SERIE
            '
            Me.txtDES_SERIE.Enabled = False
            Me.txtDES_SERIE.Location = New System.Drawing.Point(262, 173)
            Me.txtDES_SERIE.Name = "txtDES_SERIE"
            Me.txtDES_SERIE.Size = New System.Drawing.Size(45, 20)
            Me.txtDES_SERIE.TabIndex = 5
            '
            'txtDIS_DESCRIPCION_ENT
            '
            Me.txtDIS_DESCRIPCION_ENT.Enabled = False
            Me.txtDIS_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtDIS_DESCRIPCION_ENT.Location = New System.Drawing.Point(11, 279)
            Me.txtDIS_DESCRIPCION_ENT.Name = "txtDIS_DESCRIPCION_ENT"
            Me.txtDIS_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ENT.Size = New System.Drawing.Size(130, 17)
            Me.txtDIS_DESCRIPCION_ENT.TabIndex = 45
            '
            'txtPRO_DESCRIPCION_ENT
            '
            Me.txtPRO_DESCRIPCION_ENT.Enabled = False
            Me.txtPRO_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtPRO_DESCRIPCION_ENT.Location = New System.Drawing.Point(170, 279)
            Me.txtPRO_DESCRIPCION_ENT.Name = "txtPRO_DESCRIPCION_ENT"
            Me.txtPRO_DESCRIPCION_ENT.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ENT.Size = New System.Drawing.Size(170, 17)
            Me.txtPRO_DESCRIPCION_ENT.TabIndex = 47
            '
            'txtDEP_DESCRIPCION_ENT
            '
            Me.txtDEP_DESCRIPCION_ENT.Enabled = False
            Me.txtDEP_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtDEP_DESCRIPCION_ENT.Location = New System.Drawing.Point(379, 279)
            Me.txtDEP_DESCRIPCION_ENT.Name = "txtDEP_DESCRIPCION_ENT"
            Me.txtDEP_DESCRIPCION_ENT.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ENT.Size = New System.Drawing.Size(168, 17)
            Me.txtDEP_DESCRIPCION_ENT.TabIndex = 49
            Me.txtDEP_DESCRIPCION_ENT.Visible = False
            '
            'txtPAI_DESCRIPCION_ENT
            '
            Me.txtPAI_DESCRIPCION_ENT.BackColor = System.Drawing.SystemColors.Control
            Me.txtPAI_DESCRIPCION_ENT.Enabled = False
            Me.txtPAI_DESCRIPCION_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtPAI_DESCRIPCION_ENT.Location = New System.Drawing.Point(571, 279)
            Me.txtPAI_DESCRIPCION_ENT.Name = "txtPAI_DESCRIPCION_ENT"
            Me.txtPAI_DESCRIPCION_ENT.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ENT.Size = New System.Drawing.Size(168, 17)
            Me.txtPAI_DESCRIPCION_ENT.TabIndex = 51
            '
            'txtDTD_ID_DOC
            '
            Me.txtDTD_ID_DOC.BackColor = System.Drawing.SystemColors.Control
            Me.txtDTD_ID_DOC.Enabled = False
            Me.txtDTD_ID_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDTD_ID_DOC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.txtDTD_ID_DOC.Location = New System.Drawing.Point(362, 240)
            Me.txtDTD_ID_DOC.Name = "txtDTD_ID_DOC"
            Me.txtDTD_ID_DOC.ReadOnly = True
            Me.txtDTD_ID_DOC.Size = New System.Drawing.Size(26, 17)
            Me.txtDTD_ID_DOC.TabIndex = 134
            '
            'txtDIS_DESCRIPCION_ALM
            '
            Me.txtDIS_DESCRIPCION_ALM.Enabled = False
            Me.txtDIS_DESCRIPCION_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_DESCRIPCION_ALM.Location = New System.Drawing.Point(235, 216)
            Me.txtDIS_DESCRIPCION_ALM.Name = "txtDIS_DESCRIPCION_ALM"
            Me.txtDIS_DESCRIPCION_ALM.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ALM.Size = New System.Drawing.Size(117, 17)
            Me.txtDIS_DESCRIPCION_ALM.TabIndex = 25
            '
            'txtPRO_DESCRIPCION_ALM
            '
            Me.txtPRO_DESCRIPCION_ALM.Enabled = False
            Me.txtPRO_DESCRIPCION_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_DESCRIPCION_ALM.Location = New System.Drawing.Point(364, 216)
            Me.txtPRO_DESCRIPCION_ALM.Name = "txtPRO_DESCRIPCION_ALM"
            Me.txtPRO_DESCRIPCION_ALM.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ALM.Size = New System.Drawing.Size(117, 17)
            Me.txtPRO_DESCRIPCION_ALM.TabIndex = 27
            '
            'txtDEP_DESCRIPCION_ALM
            '
            Me.txtDEP_DESCRIPCION_ALM.Enabled = False
            Me.txtDEP_DESCRIPCION_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_DESCRIPCION_ALM.Location = New System.Drawing.Point(495, 216)
            Me.txtDEP_DESCRIPCION_ALM.Name = "txtDEP_DESCRIPCION_ALM"
            Me.txtDEP_DESCRIPCION_ALM.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ALM.Size = New System.Drawing.Size(116, 17)
            Me.txtDEP_DESCRIPCION_ALM.TabIndex = 19
            '
            'txtPAI_DESCRIPCION_ALM
            '
            Me.txtPAI_DESCRIPCION_ALM.Enabled = False
            Me.txtPAI_DESCRIPCION_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_DESCRIPCION_ALM.Location = New System.Drawing.Point(623, 216)
            Me.txtPAI_DESCRIPCION_ALM.Name = "txtPAI_DESCRIPCION_ALM"
            Me.txtPAI_DESCRIPCION_ALM.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ALM.Size = New System.Drawing.Size(117, 17)
            Me.txtPAI_DESCRIPCION_ALM.TabIndex = 21
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCCT_ID.Location = New System.Drawing.Point(334, 196)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(35, 9)
            Me.lblCCT_ID.TabIndex = 223
            Me.lblCCT_ID.Text = "Cta. Cte."
            '
            'lblCERTIFICADO
            '
            Me.lblCERTIFICADO.AutoSize = True
            Me.lblCERTIFICADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCERTIFICADO.Location = New System.Drawing.Point(382, 299)
            Me.lblCERTIFICADO.Name = "lblCERTIFICADO"
            Me.lblCERTIFICADO.Size = New System.Drawing.Size(40, 9)
            Me.lblCERTIFICADO.TabIndex = 251
            Me.lblCERTIFICADO.Text = "Cert. Insc."
            '
            'txtCertificado
            '
            Me.txtCertificado.Enabled = False
            Me.txtCertificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCertificado.ForeColor = System.Drawing.Color.Red
            Me.txtCertificado.Location = New System.Drawing.Point(454, 299)
            Me.txtCertificado.Name = "txtCertificado"
            Me.txtCertificado.ReadOnly = True
            Me.txtCertificado.Size = New System.Drawing.Size(208, 17)
            Me.txtCertificado.TabIndex = 250
            '
            'dtpDES_FEC_TRA
            '
            Me.dtpDES_FEC_TRA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDES_FEC_TRA.Location = New System.Drawing.Point(630, 173)
            Me.dtpDES_FEC_TRA.Name = "dtpDES_FEC_TRA"
            Me.dtpDES_FEC_TRA.Size = New System.Drawing.Size(110, 20)
            Me.dtpDES_FEC_TRA.TabIndex = 8
            '
            'dtpDES_FEC_EMI
            '
            Me.dtpDES_FEC_EMI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDES_FEC_EMI.Location = New System.Drawing.Point(462, 173)
            Me.dtpDES_FEC_EMI.Name = "dtpDES_FEC_EMI"
            Me.dtpDES_FEC_EMI.Size = New System.Drawing.Size(135, 20)
            Me.dtpDES_FEC_EMI.TabIndex = 7
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Enabled = False
            Me.txtDTD_ID.Location = New System.Drawing.Point(152, 173)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.ReadOnly = True
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 3
            '
            'cboSerieCorrelativo
            '
            Me.cboSerieCorrelativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSerieCorrelativo.FormattingEnabled = True
            Me.cboSerieCorrelativo.Location = New System.Drawing.Point(262, 173)
            Me.cboSerieCorrelativo.Name = "cboSerieCorrelativo"
            Me.cboSerieCorrelativo.Size = New System.Drawing.Size(45, 21)
            Me.cboSerieCorrelativo.TabIndex = 4
            '
            'txtDES_NUMERO
            '
            Me.txtDES_NUMERO.Location = New System.Drawing.Point(313, 173)
            Me.txtDES_NUMERO.Name = "txtDES_NUMERO"
            Me.txtDES_NUMERO.Size = New System.Drawing.Size(81, 20)
            Me.txtDES_NUMERO.TabIndex = 6
            '
            'cboDES_ESTADO
            '
            Me.cboDES_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDES_ESTADO.FormattingEnabled = True
            Me.cboDES_ESTADO.Location = New System.Drawing.Point(630, 195)
            Me.cboDES_ESTADO.Name = "cboDES_ESTADO"
            Me.cboDES_ESTADO.Size = New System.Drawing.Size(110, 17)
            Me.cboDES_ESTADO.TabIndex = 249
            '
            'btnProcesarCronogramaDespacho
            '
            Me.btnProcesarCronogramaDespacho.Location = New System.Drawing.Point(399, 173)
            Me.btnProcesarCronogramaDespacho.Name = "btnProcesarCronogramaDespacho"
            Me.btnProcesarCronogramaDespacho.Size = New System.Drawing.Size(21, 23)
            Me.btnProcesarCronogramaDespacho.TabIndex = 248
            Me.btnProcesarCronogramaDespacho.Text = ":"
            Me.btnProcesarCronogramaDespacho.UseVisualStyleBackColor = True
            '
            'txtDES_NUMERO_DOC
            '
            Me.txtDES_NUMERO_DOC.Enabled = False
            Me.txtDES_NUMERO_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDES_NUMERO_DOC.Location = New System.Drawing.Point(600, 240)
            Me.txtDES_NUMERO_DOC.Name = "txtDES_NUMERO_DOC"
            Me.txtDES_NUMERO_DOC.ReadOnly = True
            Me.txtDES_NUMERO_DOC.Size = New System.Drawing.Size(47, 17)
            Me.txtDES_NUMERO_DOC.TabIndex = 137
            '
            'txtPAI_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(650, 240)
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Name = "txtPAI_DESCRIPCION_ALM_LLEGADA"
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(90, 17)
            Me.txtPAI_DESCRIPCION_ALM_LLEGADA.TabIndex = 234
            '
            'txtPAI_ID_ALM_LLEGADA
            '
            Me.txtPAI_ID_ALM_LLEGADA.Enabled = False
            Me.txtPAI_ID_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_ID_ALM_LLEGADA.Location = New System.Drawing.Point(650, 240)
            Me.txtPAI_ID_ALM_LLEGADA.Name = "txtPAI_ID_ALM_LLEGADA"
            Me.txtPAI_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtPAI_ID_ALM_LLEGADA.Size = New System.Drawing.Size(25, 17)
            Me.txtPAI_ID_ALM_LLEGADA.TabIndex = 233
            '
            'txtDEP_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(553, 240)
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Name = "txtDEP_DESCRIPCION_ALM_LLEGADA"
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(90, 17)
            Me.txtDEP_DESCRIPCION_ALM_LLEGADA.TabIndex = 232
            '
            'txtDEP_ID_ALM_LLEGADA
            '
            Me.txtDEP_ID_ALM_LLEGADA.Enabled = False
            Me.txtDEP_ID_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_ID_ALM_LLEGADA.Location = New System.Drawing.Point(555, 240)
            Me.txtDEP_ID_ALM_LLEGADA.Name = "txtDEP_ID_ALM_LLEGADA"
            Me.txtDEP_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtDEP_ID_ALM_LLEGADA.Size = New System.Drawing.Size(25, 17)
            Me.txtDEP_ID_ALM_LLEGADA.TabIndex = 240
            '
            'txtPRO_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(457, 240)
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Name = "txtPRO_DESCRIPCION_ALM_LLEGADA"
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(90, 17)
            Me.txtPRO_DESCRIPCION_ALM_LLEGADA.TabIndex = 239
            '
            'txtPRO_ID_ALM_LLEGADA
            '
            Me.txtPRO_ID_ALM_LLEGADA.Enabled = False
            Me.txtPRO_ID_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_ID_ALM_LLEGADA.Location = New System.Drawing.Point(457, 240)
            Me.txtPRO_ID_ALM_LLEGADA.Name = "txtPRO_ID_ALM_LLEGADA"
            Me.txtPRO_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtPRO_ID_ALM_LLEGADA.Size = New System.Drawing.Size(25, 17)
            Me.txtPRO_ID_ALM_LLEGADA.TabIndex = 238
            '
            'txtDIS_DESCRIPCION_ALM_LLEGADA
            '
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Enabled = False
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Location = New System.Drawing.Point(361, 240)
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Name = "txtDIS_DESCRIPCION_ALM_LLEGADA"
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.Size = New System.Drawing.Size(90, 17)
            Me.txtDIS_DESCRIPCION_ALM_LLEGADA.TabIndex = 237
            '
            'txtDIS_ID_ALM_LLEGADA
            '
            Me.txtDIS_ID_ALM_LLEGADA.Enabled = False
            Me.txtDIS_ID_ALM_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_ID_ALM_LLEGADA.Location = New System.Drawing.Point(361, 240)
            Me.txtDIS_ID_ALM_LLEGADA.Name = "txtDIS_ID_ALM_LLEGADA"
            Me.txtDIS_ID_ALM_LLEGADA.ReadOnly = True
            Me.txtDIS_ID_ALM_LLEGADA.Size = New System.Drawing.Size(25, 17)
            Me.txtDIS_ID_ALM_LLEGADA.TabIndex = 236
            '
            'txtALM_DIRECCION_LLEGADA
            '
            Me.txtALM_DIRECCION_LLEGADA.Enabled = False
            Me.txtALM_DIRECCION_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DIRECCION_LLEGADA.Location = New System.Drawing.Point(235, 240)
            Me.txtALM_DIRECCION_LLEGADA.Name = "txtALM_DIRECCION_LLEGADA"
            Me.txtALM_DIRECCION_LLEGADA.ReadOnly = True
            Me.txtALM_DIRECCION_LLEGADA.Size = New System.Drawing.Size(117, 17)
            Me.txtALM_DIRECCION_LLEGADA.TabIndex = 235
            '
            'chkALM_ESTADO_LLEGADA
            '
            Me.chkALM_ESTADO_LLEGADA.AutoSize = True
            Me.chkALM_ESTADO_LLEGADA.Enabled = False
            Me.chkALM_ESTADO_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkALM_ESTADO_LLEGADA.Location = New System.Drawing.Point(202, 240)
            Me.chkALM_ESTADO_LLEGADA.Name = "chkALM_ESTADO_LLEGADA"
            Me.chkALM_ESTADO_LLEGADA.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO_LLEGADA.TabIndex = 242
            Me.chkALM_ESTADO_LLEGADA.UseVisualStyleBackColor = True
            '
            'txtALM_DESCRIPCION_LLEGADA
            '
            Me.txtALM_DESCRIPCION_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DESCRIPCION_LLEGADA.Location = New System.Drawing.Point(81, 240)
            Me.txtALM_DESCRIPCION_LLEGADA.Name = "txtALM_DESCRIPCION_LLEGADA"
            Me.txtALM_DESCRIPCION_LLEGADA.ReadOnly = True
            Me.txtALM_DESCRIPCION_LLEGADA.Size = New System.Drawing.Size(117, 17)
            Me.txtALM_DESCRIPCION_LLEGADA.TabIndex = 231
            '
            'txtALM_ID_LLEGADA
            '
            Me.txtALM_ID_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_ID_LLEGADA.Location = New System.Drawing.Point(44, 240)
            Me.txtALM_ID_LLEGADA.Name = "txtALM_ID_LLEGADA"
            Me.txtALM_ID_LLEGADA.Size = New System.Drawing.Size(36, 17)
            Me.txtALM_ID_LLEGADA.TabIndex = 230
            '
            'lblALM_ID_LLEGADA
            '
            Me.lblALM_ID_LLEGADA.AutoSize = True
            Me.lblALM_ID_LLEGADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblALM_ID_LLEGADA.Location = New System.Drawing.Point(7, 240)
            Me.lblALM_ID_LLEGADA.Name = "lblALM_ID_LLEGADA"
            Me.lblALM_ID_LLEGADA.Size = New System.Drawing.Size(35, 9)
            Me.lblALM_ID_LLEGADA.TabIndex = 241
            Me.lblALM_ID_LLEGADA.Text = "Almacén"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(7, 173)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPVE_ID.TabIndex = 61
            Me.lblPVE_ID.Text = "Agencia"
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(56, 173)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 1
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(91, 173)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.ReadOnly = True
            Me.txtTDO_ID.Size = New System.Drawing.Size(5, 20)
            Me.txtTDO_ID.TabIndex = 2
            Me.txtTDO_ID.Visible = False
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(101, 173)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblDTD_ID.TabIndex = 25
            Me.lblDTD_ID.Text = "Tipo.Doc."
            '
            'lblCorrelativo
            '
            Me.lblCorrelativo.AutoSize = True
            Me.lblCorrelativo.Location = New System.Drawing.Point(206, 173)
            Me.lblCorrelativo.Name = "lblCorrelativo"
            Me.lblCorrelativo.Size = New System.Drawing.Size(56, 13)
            Me.lblCorrelativo.TabIndex = 46
            Me.lblCorrelativo.Text = "Ser./Núm."
            '
            'lblSeparador
            '
            Me.lblSeparador.AutoSize = True
            Me.lblSeparador.Location = New System.Drawing.Point(304, 173)
            Me.lblSeparador.Name = "lblSeparador"
            Me.lblSeparador.Size = New System.Drawing.Size(10, 13)
            Me.lblSeparador.TabIndex = 131
            Me.lblSeparador.Text = "-"
            '
            'lblDES_FECHA_EMI
            '
            Me.lblDES_FECHA_EMI.AutoSize = True
            Me.lblDES_FECHA_EMI.Location = New System.Drawing.Point(419, 173)
            Me.lblDES_FECHA_EMI.Name = "lblDES_FECHA_EMI"
            Me.lblDES_FECHA_EMI.Size = New System.Drawing.Size(43, 13)
            Me.lblDES_FECHA_EMI.TabIndex = 79
            Me.lblDES_FECHA_EMI.Text = "Emisión"
            '
            'lblDES_FECHA_TRA
            '
            Me.lblDES_FECHA_TRA.AutoSize = True
            Me.lblDES_FECHA_TRA.Location = New System.Drawing.Point(599, 173)
            Me.lblDES_FECHA_TRA.Name = "lblDES_FECHA_TRA"
            Me.lblDES_FECHA_TRA.Size = New System.Drawing.Size(33, 13)
            Me.lblDES_FECHA_TRA.TabIndex = 78
            Me.lblDES_FECHA_TRA.Text = "Trasl."
            '
            'lblALM_ID
            '
            Me.lblALM_ID.AutoSize = True
            Me.lblALM_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblALM_ID.Location = New System.Drawing.Point(7, 196)
            Me.lblALM_ID.Name = "lblALM_ID"
            Me.lblALM_ID.Size = New System.Drawing.Size(35, 9)
            Me.lblALM_ID.TabIndex = 62
            Me.lblALM_ID.Text = "Almacén"
            '
            'txtALM_ID
            '
            Me.txtALM_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_ID.Location = New System.Drawing.Point(44, 196)
            Me.txtALM_ID.Name = "txtALM_ID"
            Me.txtALM_ID.Size = New System.Drawing.Size(36, 17)
            Me.txtALM_ID.TabIndex = 9
            '
            'txtALM_DESCRIPCION
            '
            Me.txtALM_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DESCRIPCION.Location = New System.Drawing.Point(81, 196)
            Me.txtALM_DESCRIPCION.Name = "txtALM_DESCRIPCION"
            Me.txtALM_DESCRIPCION.ReadOnly = True
            Me.txtALM_DESCRIPCION.Size = New System.Drawing.Size(168, 17)
            Me.txtALM_DESCRIPCION.TabIndex = 11
            '
            'chkALM_ESTADO
            '
            Me.chkALM_ESTADO.AutoSize = True
            Me.chkALM_ESTADO.Enabled = False
            Me.chkALM_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkALM_ESTADO.Location = New System.Drawing.Point(250, 196)
            Me.chkALM_ESTADO.Name = "chkALM_ESTADO"
            Me.chkALM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO.TabIndex = 219
            Me.chkALM_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Enabled = False
            Me.txtCCT_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCT_ID.Location = New System.Drawing.Point(385, 196)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.ReadOnly = True
            Me.txtCCT_ID.Size = New System.Drawing.Size(34, 17)
            Me.txtCCT_ID.TabIndex = 221
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(423, 196)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(174, 17)
            Me.txtCCT_DESCRIPCION.TabIndex = 222
            '
            'lblDES_ESTADO
            '
            Me.lblDES_ESTADO.AutoSize = True
            Me.lblDES_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDES_ESTADO.Location = New System.Drawing.Point(599, 196)
            Me.lblDES_ESTADO.Name = "lblDES_ESTADO"
            Me.lblDES_ESTADO.Size = New System.Drawing.Size(18, 9)
            Me.lblDES_ESTADO.TabIndex = 220
            Me.lblDES_ESTADO.Text = "Est."
            '
            'txtALM_DIRECCION
            '
            Me.txtALM_DIRECCION.Enabled = False
            Me.txtALM_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtALM_DIRECCION.Location = New System.Drawing.Point(7, 216)
            Me.txtALM_DIRECCION.Name = "txtALM_DIRECCION"
            Me.txtALM_DIRECCION.ReadOnly = True
            Me.txtALM_DIRECCION.Size = New System.Drawing.Size(222, 17)
            Me.txtALM_DIRECCION.TabIndex = 22
            '
            'txtDIS_ID_ALM
            '
            Me.txtDIS_ID_ALM.Enabled = False
            Me.txtDIS_ID_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_ID_ALM.Location = New System.Drawing.Point(235, 216)
            Me.txtDIS_ID_ALM.Name = "txtDIS_ID_ALM"
            Me.txtDIS_ID_ALM.ReadOnly = True
            Me.txtDIS_ID_ALM.Size = New System.Drawing.Size(25, 17)
            Me.txtDIS_ID_ALM.TabIndex = 24
            '
            'txtPRO_ID_ALM
            '
            Me.txtPRO_ID_ALM.Enabled = False
            Me.txtPRO_ID_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_ID_ALM.Location = New System.Drawing.Point(364, 216)
            Me.txtPRO_ID_ALM.Name = "txtPRO_ID_ALM"
            Me.txtPRO_ID_ALM.ReadOnly = True
            Me.txtPRO_ID_ALM.Size = New System.Drawing.Size(25, 17)
            Me.txtPRO_ID_ALM.TabIndex = 26
            '
            'txtDEP_ID_ALM
            '
            Me.txtDEP_ID_ALM.Enabled = False
            Me.txtDEP_ID_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_ID_ALM.Location = New System.Drawing.Point(495, 216)
            Me.txtDEP_ID_ALM.Name = "txtDEP_ID_ALM"
            Me.txtDEP_ID_ALM.ReadOnly = True
            Me.txtDEP_ID_ALM.Size = New System.Drawing.Size(25, 17)
            Me.txtDEP_ID_ALM.TabIndex = 28
            '
            'txtPAI_ID_ALM
            '
            Me.txtPAI_ID_ALM.Enabled = False
            Me.txtPAI_ID_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_ID_ALM.Location = New System.Drawing.Point(623, 216)
            Me.txtPAI_ID_ALM.Name = "txtPAI_ID_ALM"
            Me.txtPAI_ID_ALM.ReadOnly = True
            Me.txtPAI_ID_ALM.Size = New System.Drawing.Size(25, 17)
            Me.txtPAI_ID_ALM.TabIndex = 20
            '
            'lblPER_ID_CLI
            '
            Me.lblPER_ID_CLI.AutoSize = True
            Me.lblPER_ID_CLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_ID_CLI.Location = New System.Drawing.Point(7, 240)
            Me.lblPER_ID_CLI.Name = "lblPER_ID_CLI"
            Me.lblPER_ID_CLI.Size = New System.Drawing.Size(29, 9)
            Me.lblPER_ID_CLI.TabIndex = 71
            Me.lblPER_ID_CLI.Text = "Cliente"
            '
            'txtPER_ID_CLI
            '
            Me.txtPER_ID_CLI.Enabled = False
            Me.txtPER_ID_CLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_ID_CLI.ForeColor = System.Drawing.Color.Red
            Me.txtPER_ID_CLI.Location = New System.Drawing.Point(40, 240)
            Me.txtPER_ID_CLI.Name = "txtPER_ID_CLI"
            Me.txtPER_ID_CLI.ReadOnly = True
            Me.txtPER_ID_CLI.Size = New System.Drawing.Size(47, 20)
            Me.txtPER_ID_CLI.TabIndex = 15
            '
            'txtPER_DESCRIPCION_CLI
            '
            Me.txtPER_DESCRIPCION_CLI.Enabled = False
            Me.txtPER_DESCRIPCION_CLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_CLI.ForeColor = System.Drawing.Color.Red
            Me.txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(90, 240)
            Me.txtPER_DESCRIPCION_CLI.Name = "txtPER_DESCRIPCION_CLI"
            Me.txtPER_DESCRIPCION_CLI.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLI.Size = New System.Drawing.Size(224, 20)
            Me.txtPER_DESCRIPCION_CLI.TabIndex = 16
            '
            'lblDTD_ID_DOC
            '
            Me.lblDTD_ID_DOC.AutoSize = True
            Me.lblDTD_ID_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDTD_ID_DOC.Location = New System.Drawing.Point(338, 240)
            Me.lblDTD_ID_DOC.Name = "lblDTD_ID_DOC"
            Me.lblDTD_ID_DOC.Size = New System.Drawing.Size(21, 9)
            Me.lblDTD_ID_DOC.TabIndex = 138
            Me.lblDTD_ID_DOC.Text = "Doc."
            '
            'txtTDO_ID_DOC
            '
            Me.txtTDO_ID_DOC.Enabled = False
            Me.txtTDO_ID_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTDO_ID_DOC.ForeColor = System.Drawing.Color.Red
            Me.txtTDO_ID_DOC.Location = New System.Drawing.Point(364, 240)
            Me.txtTDO_ID_DOC.Name = "txtTDO_ID_DOC"
            Me.txtTDO_ID_DOC.ReadOnly = True
            Me.txtTDO_ID_DOC.Size = New System.Drawing.Size(10, 20)
            Me.txtTDO_ID_DOC.TabIndex = 133
            Me.txtTDO_ID_DOC.Visible = False
            '
            'txtDTD_DESCRIPCION_DOC
            '
            Me.txtDTD_DESCRIPCION_DOC.Enabled = False
            Me.txtDTD_DESCRIPCION_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDTD_DESCRIPCION_DOC.ForeColor = System.Drawing.Color.Red
            Me.txtDTD_DESCRIPCION_DOC.Location = New System.Drawing.Point(392, 240)
            Me.txtDTD_DESCRIPCION_DOC.Name = "txtDTD_DESCRIPCION_DOC"
            Me.txtDTD_DESCRIPCION_DOC.ReadOnly = True
            Me.txtDTD_DESCRIPCION_DOC.Size = New System.Drawing.Size(113, 20)
            Me.txtDTD_DESCRIPCION_DOC.TabIndex = 172
            '
            'lblDOC_SERIE_DOC
            '
            Me.lblDOC_SERIE_DOC.AutoSize = True
            Me.lblDOC_SERIE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDOC_SERIE_DOC.Location = New System.Drawing.Point(522, 240)
            Me.lblDOC_SERIE_DOC.Name = "lblDOC_SERIE_DOC"
            Me.lblDOC_SERIE_DOC.Size = New System.Drawing.Size(48, 9)
            Me.lblDOC_SERIE_DOC.TabIndex = 139
            Me.lblDOC_SERIE_DOC.Text = "Serie / Núm."
            '
            'txtDES_SERIE_DOC
            '
            Me.txtDES_SERIE_DOC.Enabled = False
            Me.txtDES_SERIE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDES_SERIE_DOC.ForeColor = System.Drawing.Color.Red
            Me.txtDES_SERIE_DOC.Location = New System.Drawing.Point(573, 240)
            Me.txtDES_SERIE_DOC.Name = "txtDES_SERIE_DOC"
            Me.txtDES_SERIE_DOC.ReadOnly = True
            Me.txtDES_SERIE_DOC.Size = New System.Drawing.Size(21, 20)
            Me.txtDES_SERIE_DOC.TabIndex = 136
            '
            'lblSeparador1
            '
            Me.lblSeparador1.AutoSize = True
            Me.lblSeparador1.Location = New System.Drawing.Point(593, 240)
            Me.lblSeparador1.Name = "lblSeparador1"
            Me.lblSeparador1.Size = New System.Drawing.Size(10, 13)
            Me.lblSeparador1.TabIndex = 141
            Me.lblSeparador1.Text = "-"
            '
            'txtDOC_TIPO_LISTA
            '
            Me.txtDOC_TIPO_LISTA.Enabled = False
            Me.txtDOC_TIPO_LISTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDOC_TIPO_LISTA.Location = New System.Drawing.Point(649, 240)
            Me.txtDOC_TIPO_LISTA.Name = "txtDOC_TIPO_LISTA"
            Me.txtDOC_TIPO_LISTA.ReadOnly = True
            Me.txtDOC_TIPO_LISTA.Size = New System.Drawing.Size(90, 17)
            Me.txtDOC_TIPO_LISTA.TabIndex = 228
            '
            'txtDIR_ID_ENT
            '
            Me.txtDIR_ID_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIR_ID_ENT.ForeColor = System.Drawing.Color.Red
            Me.txtDIR_ID_ENT.Location = New System.Drawing.Point(97, 260)
            Me.txtDIR_ID_ENT.Name = "txtDIR_ID_ENT"
            Me.txtDIR_ID_ENT.Size = New System.Drawing.Size(68, 17)
            Me.txtDIR_ID_ENT.TabIndex = 42
            '
            'txtDIS_ID_ENT
            '
            Me.txtDIS_ID_ENT.Enabled = False
            Me.txtDIS_ID_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDIS_ID_ENT.Location = New System.Drawing.Point(11, 279)
            Me.txtDIS_ID_ENT.Name = "txtDIS_ID_ENT"
            Me.txtDIS_ID_ENT.ReadOnly = True
            Me.txtDIS_ID_ENT.Size = New System.Drawing.Size(34, 17)
            Me.txtDIS_ID_ENT.TabIndex = 44
            '
            'txtPRO_ID_ENT
            '
            Me.txtPRO_ID_ENT.Enabled = False
            Me.txtPRO_ID_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPRO_ID_ENT.Location = New System.Drawing.Point(172, 279)
            Me.txtPRO_ID_ENT.Name = "txtPRO_ID_ENT"
            Me.txtPRO_ID_ENT.ReadOnly = True
            Me.txtPRO_ID_ENT.Size = New System.Drawing.Size(34, 17)
            Me.txtPRO_ID_ENT.TabIndex = 46
            '
            'txtDEP_ID_ENT
            '
            Me.txtDEP_ID_ENT.Enabled = False
            Me.txtDEP_ID_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDEP_ID_ENT.Location = New System.Drawing.Point(379, 279)
            Me.txtDEP_ID_ENT.Name = "txtDEP_ID_ENT"
            Me.txtDEP_ID_ENT.ReadOnly = True
            Me.txtDEP_ID_ENT.Size = New System.Drawing.Size(34, 17)
            Me.txtDEP_ID_ENT.TabIndex = 48
            '
            'txtPAI_ID_ENT
            '
            Me.txtPAI_ID_ENT.Enabled = False
            Me.txtPAI_ID_ENT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPAI_ID_ENT.Location = New System.Drawing.Point(572, 279)
            Me.txtPAI_ID_ENT.Name = "txtPAI_ID_ENT"
            Me.txtPAI_ID_ENT.ReadOnly = True
            Me.txtPAI_ID_ENT.Size = New System.Drawing.Size(34, 17)
            Me.txtPAI_ID_ENT.TabIndex = 50
            '
            'lblPLA_ID
            '
            Me.lblPLA_ID.AutoSize = True
            Me.lblPLA_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPLA_ID.Location = New System.Drawing.Point(11, 299)
            Me.lblPLA_ID.Name = "lblPLA_ID"
            Me.lblPLA_ID.Size = New System.Drawing.Size(42, 9)
            Me.lblPLA_ID.TabIndex = 209
            Me.lblPLA_ID.Text = "Cód. Placa"
            '
            'txtPLA_ID
            '
            Me.txtPLA_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPLA_ID.ForeColor = System.Drawing.Color.Red
            Me.txtPLA_ID.Location = New System.Drawing.Point(80, 299)
            Me.txtPLA_ID.Name = "txtPLA_ID"
            Me.txtPLA_ID.Size = New System.Drawing.Size(54, 17)
            Me.txtPLA_ID.TabIndex = 200
            '
            'txtUNT_ID_1
            '
            Me.txtUNT_ID_1.Enabled = False
            Me.txtUNT_ID_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtUNT_ID_1.ForeColor = System.Drawing.Color.Red
            Me.txtUNT_ID_1.Location = New System.Drawing.Point(135, 299)
            Me.txtUNT_ID_1.Name = "txtUNT_ID_1"
            Me.txtUNT_ID_1.ReadOnly = True
            Me.txtUNT_ID_1.Size = New System.Drawing.Size(109, 17)
            Me.txtUNT_ID_1.TabIndex = 201
            '
            'txtUNT_ID_2
            '
            Me.txtUNT_ID_2.Enabled = False
            Me.txtUNT_ID_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtUNT_ID_2.ForeColor = System.Drawing.Color.Red
            Me.txtUNT_ID_2.Location = New System.Drawing.Point(246, 299)
            Me.txtUNT_ID_2.Name = "txtUNT_ID_2"
            Me.txtUNT_ID_2.ReadOnly = True
            Me.txtUNT_ID_2.Size = New System.Drawing.Size(122, 17)
            Me.txtUNT_ID_2.TabIndex = 210
            '
            'lblPER_ID_TRA1
            '
            Me.lblPER_ID_TRA1.AutoSize = True
            Me.lblPER_ID_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_ID_TRA1.Location = New System.Drawing.Point(11, 318)
            Me.lblPER_ID_TRA1.Name = "lblPER_ID_TRA1"
            Me.lblPER_ID_TRA1.Size = New System.Drawing.Size(50, 9)
            Me.lblPER_ID_TRA1.TabIndex = 207
            Me.lblPER_ID_TRA1.Text = "Transportista"
            '
            'txtPER_ID_TRA1
            '
            Me.txtPER_ID_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_ID_TRA1.ForeColor = System.Drawing.Color.Red
            Me.txtPER_ID_TRA1.Location = New System.Drawing.Point(80, 318)
            Me.txtPER_ID_TRA1.Name = "txtPER_ID_TRA1"
            Me.txtPER_ID_TRA1.ReadOnly = True
            Me.txtPER_ID_TRA1.Size = New System.Drawing.Size(54, 17)
            Me.txtPER_ID_TRA1.TabIndex = 202
            '
            'txtPER_DESCRIPCION_TRA1
            '
            Me.txtPER_DESCRIPCION_TRA1.Enabled = False
            Me.txtPER_DESCRIPCION_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_TRA1.ForeColor = System.Drawing.Color.Red
            Me.txtPER_DESCRIPCION_TRA1.Location = New System.Drawing.Point(135, 318)
            Me.txtPER_DESCRIPCION_TRA1.Name = "txtPER_DESCRIPCION_TRA1"
            Me.txtPER_DESCRIPCION_TRA1.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA1.Size = New System.Drawing.Size(233, 17)
            Me.txtPER_DESCRIPCION_TRA1.TabIndex = 203
            '
            'lblRUC_TRA1
            '
            Me.lblRUC_TRA1.AutoSize = True
            Me.lblRUC_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRUC_TRA1.Location = New System.Drawing.Point(382, 318)
            Me.lblRUC_TRA1.Name = "lblRUC_TRA1"
            Me.lblRUC_TRA1.Size = New System.Drawing.Size(49, 9)
            Me.lblRUC_TRA1.TabIndex = 208
            Me.lblRUC_TRA1.Text = "Doc. Transp."
            '
            'txtRUC_TRA1
            '
            Me.txtRUC_TRA1.Enabled = False
            Me.txtRUC_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRUC_TRA1.ForeColor = System.Drawing.Color.Red
            Me.txtRUC_TRA1.Location = New System.Drawing.Point(454, 318)
            Me.txtRUC_TRA1.Name = "txtRUC_TRA1"
            Me.txtRUC_TRA1.ReadOnly = True
            Me.txtRUC_TRA1.Size = New System.Drawing.Size(208, 17)
            Me.txtRUC_TRA1.TabIndex = 204
            '
            'chkPER_ESTADO_TRA1
            '
            Me.chkPER_ESTADO_TRA1.AutoSize = True
            Me.chkPER_ESTADO_TRA1.Enabled = False
            Me.chkPER_ESTADO_TRA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPER_ESTADO_TRA1.Location = New System.Drawing.Point(664, 318)
            Me.chkPER_ESTADO_TRA1.Name = "chkPER_ESTADO_TRA1"
            Me.chkPER_ESTADO_TRA1.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_TRA1.TabIndex = 205
            Me.chkPER_ESTADO_TRA1.UseVisualStyleBackColor = True
            '
            'lblPER_ID_CHO
            '
            Me.lblPER_ID_CHO.AutoSize = True
            Me.lblPER_ID_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_ID_CHO.Location = New System.Drawing.Point(11, 338)
            Me.lblPER_ID_CHO.Name = "lblPER_ID_CHO"
            Me.lblPER_ID_CHO.Size = New System.Drawing.Size(28, 9)
            Me.lblPER_ID_CHO.TabIndex = 216
            Me.lblPER_ID_CHO.Text = "Chofer"
            '
            'txtPER_ID_CHO
            '
            Me.txtPER_ID_CHO.Enabled = False
            Me.txtPER_ID_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_ID_CHO.ForeColor = System.Drawing.Color.Red
            Me.txtPER_ID_CHO.Location = New System.Drawing.Point(80, 338)
            Me.txtPER_ID_CHO.Name = "txtPER_ID_CHO"
            Me.txtPER_ID_CHO.ReadOnly = True
            Me.txtPER_ID_CHO.Size = New System.Drawing.Size(54, 17)
            Me.txtPER_ID_CHO.TabIndex = 212
            '
            'txtPER_DESCRIPCION_CHO
            '
            Me.txtPER_DESCRIPCION_CHO.Enabled = False
            Me.txtPER_DESCRIPCION_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_CHO.ForeColor = System.Drawing.Color.Red
            Me.txtPER_DESCRIPCION_CHO.Location = New System.Drawing.Point(135, 338)
            Me.txtPER_DESCRIPCION_CHO.Name = "txtPER_DESCRIPCION_CHO"
            Me.txtPER_DESCRIPCION_CHO.ReadOnly = True
            Me.txtPER_DESCRIPCION_CHO.Size = New System.Drawing.Size(233, 17)
            Me.txtPER_DESCRIPCION_CHO.TabIndex = 213
            '
            'lblPER_BREVETE_CHO
            '
            Me.lblPER_BREVETE_CHO.AutoSize = True
            Me.lblPER_BREVETE_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPER_BREVETE_CHO.Location = New System.Drawing.Point(382, 338)
            Me.lblPER_BREVETE_CHO.Name = "lblPER_BREVETE_CHO"
            Me.lblPER_BREVETE_CHO.Size = New System.Drawing.Size(31, 9)
            Me.lblPER_BREVETE_CHO.TabIndex = 217
            Me.lblPER_BREVETE_CHO.Text = "Brevete"
            '
            'txtPER_BREVETE_CHO
            '
            Me.txtPER_BREVETE_CHO.Enabled = False
            Me.txtPER_BREVETE_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_BREVETE_CHO.ForeColor = System.Drawing.Color.Red
            Me.txtPER_BREVETE_CHO.Location = New System.Drawing.Point(454, 338)
            Me.txtPER_BREVETE_CHO.Name = "txtPER_BREVETE_CHO"
            Me.txtPER_BREVETE_CHO.ReadOnly = True
            Me.txtPER_BREVETE_CHO.Size = New System.Drawing.Size(208, 17)
            Me.txtPER_BREVETE_CHO.TabIndex = 214
            '
            'chkPER_ESTADO_CHO
            '
            Me.chkPER_ESTADO_CHO.AutoSize = True
            Me.chkPER_ESTADO_CHO.Enabled = False
            Me.chkPER_ESTADO_CHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPER_ESTADO_CHO.Location = New System.Drawing.Point(664, 338)
            Me.chkPER_ESTADO_CHO.Name = "chkPER_ESTADO_CHO"
            Me.chkPER_ESTADO_CHO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_CHO.TabIndex = 215
            Me.chkPER_ESTADO_CHO.UseVisualStyleBackColor = True
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cITEM, Me.cART_ID_IMP, Me.cART_DESCRIPCION_IMP, Me.cART_FACTOR_IMP, Me.cART_ESTADO_IMP, Me.cART_ID_KAR, Me.cART_DESCRIPCION_KAR, Me.cART_FACTOR_KAR, Me.cART_ESTADO_KAR, Me.cDDE_CANTIDAD, Me.cDDE_ESTADO, Me.cEstadoRegistro})
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDetalle.Location = New System.Drawing.Point(10, 357)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(729, 116)
            Me.dgvDetalle.TabIndex = 11
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
            Me.cART_ID_KAR.Width = 75
            '
            'cART_DESCRIPCION_KAR
            '
            Me.cART_DESCRIPCION_KAR.HeaderText = "Descripción artículo"
            Me.cART_DESCRIPCION_KAR.Name = "cART_DESCRIPCION_KAR"
            Me.cART_DESCRIPCION_KAR.ReadOnly = True
            Me.cART_DESCRIPCION_KAR.Width = 90
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
            DataGridViewCellStyle6.Format = "N4"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.cDDE_CANTIDAD.DefaultCellStyle = DataGridViewCellStyle6
            Me.cDDE_CANTIDAD.HeaderText = "Cantidad"
            Me.cDDE_CANTIDAD.Name = "cDDE_CANTIDAD"
            Me.cDDE_CANTIDAD.ReadOnly = True
            Me.cDDE_CANTIDAD.Width = 60
            '
            'cDDE_ESTADO
            '
            Me.cDDE_ESTADO.HeaderText = "Estado detalle"
            Me.cDDE_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDDE_ESTADO.Name = "cDDE_ESTADO"
            Me.cDDE_ESTADO.ReadOnly = True
            Me.cDDE_ESTADO.Width = 52
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
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(44, 35)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 13)
            Me.Label1.TabIndex = 253
            Me.Label1.Text = "Agencia"
            '
            'txtBuscarSerie
            '
            Me.txtBuscarSerie.Location = New System.Drawing.Point(101, 33)
            Me.txtBuscarSerie.Name = "txtBuscarSerie"
            Me.txtBuscarSerie.Size = New System.Drawing.Size(34, 20)
            Me.txtBuscarSerie.TabIndex = 252
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(408, 32)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 21)
            Me.btnBuscar.TabIndex = 256
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'lbltxt
            '
            Me.lbltxt.AutoSize = True
            Me.lbltxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbltxt.Location = New System.Drawing.Point(140, 37)
            Me.lbltxt.Name = "lbltxt"
            Me.lbltxt.Size = New System.Drawing.Size(143, 13)
            Me.lbltxt.TabIndex = 255
            Me.lbltxt.Text = "Unidad de transportista:"
            '
            'txtUNT_ID
            '
            Me.txtUNT_ID.Location = New System.Drawing.Point(288, 33)
            Me.txtUNT_ID.Name = "txtUNT_ID"
            Me.txtUNT_ID.Size = New System.Drawing.Size(109, 20)
            Me.txtUNT_ID.TabIndex = 254
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDatos.ColumnHeadersHeight = 15
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cChecked, Me.cTDO_ID, Me.cTDO_DESCRIPCION, Me.cDTD_ID, Me.cDTD_DESCRIPCION, Me.cCCT_ID, Me.cCCT_DESCRIPCION, Me.cDTD_CARGO_ABONO, Me.cDTD_SIGNO, Me.cDTD_SIGNO_D, Me.cDES_FEC_EMI, Me.cDES_FEC_TRA, Me.cDES_FEC_SAL_PLA, Me.cDES_FEC_CAR_DES, Me.cDES_FEC_PRO_CRO, Me.cPVE_ID, Me.cPVE_DESCRIPCION, Me.cPVE_DIRECCION, Me.cDIS_ID_PVE, Me.cDIS_DESCRIPCION_PVE, Me.cDIS_ESTADO_PVE, Me.cPRO_ID_PVE, Me.cPRO_DESCRIPCION_PVE, Me.cPRO_ESTADO_PVE, Me.cDEP_ID_PVE, Me.cDEP_DESCRIPCION_PVE, Me.cDEP_ESTADO_PVE, Me.cPAI_ID_PVE, Me.cPAI_DESCRIPCION_PVE, Me.cPAI_ESTADO_PVE, Me.cALM_ID, Me.cALM_DESCRIPCION, Me.cALM_DIRECCION, Me.cDIS_ID_ALM, Me.cDIS_DESCRIPCION_ALM, Me.cDIS_ESTADO_ALM, Me.cPRO_ID_ALM, Me.cPRO_DESCRIPCION_ALM, Me.cPRO_ESTADO_ALM, Me.cDEP_ID_ALM, Me.cDEP_DESCRIPCION_ALM, Me.cDEP_ESTADO_ALM, Me.cPAI_ID_ALM, Me.cPAI_DESCRIPCION_ALM, Me.cPAI_ESTADO_ALM, Me.cALM_ESTADO, Me.cALM_ID_LLEGADA, Me.cALM_DESCRIPCION_LLEGADA, Me.cALM_DIRECCION_LLEGADA, Me.cDIS_ID_ALM_LLEGADA, Me.cDIS_DESCRIPCION_ALM_LLEGADA, Me.cDIS_ESTADO_ALM_LLEGADA, Me.cPRO_ID_ALM_LLEGADA, Me.cPRO_DESCRIPCION_ALM_LLEGADA, Me.cPRO_ESTADO_ALM_LLEGADA, Me.cDEP_ID_ALM_LLEGADA, Me.cDEP_DESCRIPCION_ALM_LLEGADA, Me.cDEP_ESTADO_ALM_LLEGADA, Me.cPAI_ID_ALM_LLEGADA, Me.cPAI_DESCRIPCION_ALM_LLEGADA, Me.cPAI_ESTADO_ALM_LLEGADA, Me.cALM_ESTADO_LLEGADA, Me.cDES_SERIE, Me.cDES_NUMERO, Me.cPER_ID_CLI, Me.cPER_DESCRIPCION_CLI, Me.cTDP_ID_CLI, Me.cTDP_DESCRIPCION_CLI, Me.cDOP_NUMERO_CLI, Me.cPER_ID_VEN, Me.cPER_DESCRIPCION_VEN, Me.cTDO_ID_DOC, Me.cTDO_DESCRIPCION_DOC, Me.cDTD_ID_DOC, Me.cDTD_DESCRIPCION_DOC, Me.cCCT_ID_DOC, Me.cCCT_DESCRIPCION_DOC, Me.cDOC_ORDEN_COMPRA, Me.cTIV_ID_DOC, Me.cTIV_DESCRIPCION_DOC, Me.cMON_ID_DOC, Me.cMON_DESCRIPCION_DOC, Me.cDOC_TIPO_LISTA, Me.cDES_SERIE_DOC, Me.cDES_NUMERO_DOC, Me.cPER_ID_REC, Me.cPER_DESCRIPCION_REC, Me.cTDP_ID_REC, Me.cTDP_DESCRIPCION_REC, Me.cDOP_NUMERO_REC, Me.cDIR_ID_ENT_REC, Me.cDIR_DESCRIPCION_ENT_REC, Me.cDIR_TIPO_ENT_REC, Me.cDIR_REFERENCIA_ENT_REC, Me.cDIS_ID_ENT_REC, Me.cDIS_DESCRIPCION_ENT_REC, Me.cPRO_ID_ENT_REC, Me.cPRO_DESCRIPCION_ENT_REC, Me.cDEP_ID_ENT_REC, Me.cDEP_DESCRIPCION_ENT_REC, Me.cPAI_ID_ENT_REC, Me.cPAI_DESCRIPCION_ENT_REC, Me.cDIR_ESTADO_ENT_REC, Me.cDIR_ID_ENT, Me.cDIR_DESCRIPCION_ENT, Me.cDIS_ID_ENT, Me.cDIS_DESCRIPCION_ENT, Me.cDIS_ESTADO_ENT, Me.cPRO_ID_ENT, Me.cPRO_DESCRIPCION_ENT, Me.cPRO_ESTADO_ENT, Me.cDEP_ID_ENT, Me.cDEP_DESCRIPCION_ENT, Me.cDEP_ESTADO_ENT, Me.cPAI_ID_ENT, Me.cPAI_DESCRIPCION_ENT, Me.cPAIS_ESTADO_ENT, Me.cDIR_REFERENCIA_ENT, Me.cFLE_ID, Me.cFLE_DESCRIPCION, Me.cFLE_TIPO, Me.cFLE_ESTADO, Me.cMON_ID, Me.cMON_DESCRIPCION, Me.cDES_MONTO_FLETE, Me.cDES_CONTRAVALOR, Me.cPLA_ID, Me.cPER_ID_TRA1, Me.cPER_DESCRIPCION_TRA1, Me.cRUC_TRA1, Me.cPER_ESTADO_TRA1, Me.cUNT_ID_1, Me.cMAR_DESCRIPCION_TRA1, Me.cMOD_DESCRIPCION_TRA1, Me.cUNT_NRO_INS_TRA1, Me.cUNT_ID_2, Me.cMAR_DESCRIPCION_TRA2, Me.cMOD_DESCRIPCION_TRA2, Me.cUNT_NRO_INS_TRA2, Me.cPER_ID_CHO, Me.cPER_DESCRIPCION_CHO, Me.cPER_BREVETE_CHO, Me.cPER_ESTADO_CHO, Me.cDES_ESTADO})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDatos.Location = New System.Drawing.Point(45, 54)
            Me.dgvDatos.MultiSelect = False
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDatos.Size = New System.Drawing.Size(732, 147)
            Me.dgvDatos.TabIndex = 252
            '
            'cChecked
            '
            Me.cChecked.HeaderText = "Checked"
            Me.cChecked.Name = "cChecked"
            Me.cChecked.Width = 39
            '
            'cTDO_ID
            '
            Me.cTDO_ID.HeaderText = "TDO_ID"
            Me.cTDO_ID.Name = "cTDO_ID"
            Me.cTDO_ID.ReadOnly = True
            Me.cTDO_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cTDO_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.cTDO_ID.Width = 34
            '
            'cTDO_DESCRIPCION
            '
            Me.cTDO_DESCRIPCION.HeaderText = "TDO_DESCRIPCION"
            Me.cTDO_DESCRIPCION.Name = "cTDO_DESCRIPCION"
            Me.cTDO_DESCRIPCION.ReadOnly = True
            Me.cTDO_DESCRIPCION.Width = 95
            '
            'cDTD_ID
            '
            Me.cDTD_ID.HeaderText = "DTD_ID"
            Me.cDTD_ID.Name = "cDTD_ID"
            Me.cDTD_ID.ReadOnly = True
            Me.cDTD_ID.Width = 53
            '
            'cDTD_DESCRIPCION
            '
            Me.cDTD_DESCRIPCION.HeaderText = "DTD_DESCRIPCION"
            Me.cDTD_DESCRIPCION.Name = "cDTD_DESCRIPCION"
            Me.cDTD_DESCRIPCION.ReadOnly = True
            Me.cDTD_DESCRIPCION.Width = 95
            '
            'cCCT_ID
            '
            Me.cCCT_ID.HeaderText = "CCT_ID"
            Me.cCCT_ID.Name = "cCCT_ID"
            Me.cCCT_ID.ReadOnly = True
            Me.cCCT_ID.Width = 53
            '
            'cCCT_DESCRIPCION
            '
            Me.cCCT_DESCRIPCION.HeaderText = "CCT_DESCRIPCION"
            Me.cCCT_DESCRIPCION.Name = "cCCT_DESCRIPCION"
            Me.cCCT_DESCRIPCION.ReadOnly = True
            Me.cCCT_DESCRIPCION.Width = 95
            '
            'cDTD_CARGO_ABONO
            '
            Me.cDTD_CARGO_ABONO.HeaderText = "DTD_CARGO_ABONO"
            Me.cDTD_CARGO_ABONO.Name = "cDTD_CARGO_ABONO"
            Me.cDTD_CARGO_ABONO.ReadOnly = True
            '
            'cDTD_SIGNO
            '
            Me.cDTD_SIGNO.HeaderText = "DTD_SIGNO"
            Me.cDTD_SIGNO.Name = "cDTD_SIGNO"
            Me.cDTD_SIGNO.ReadOnly = True
            Me.cDTD_SIGNO.Width = 68
            '
            'cDTD_SIGNO_D
            '
            Me.cDTD_SIGNO_D.HeaderText = "DTD_SIGNO_D"
            Me.cDTD_SIGNO_D.Name = "cDTD_SIGNO_D"
            Me.cDTD_SIGNO_D.ReadOnly = True
            Me.cDTD_SIGNO_D.Width = 77
            '
            'cDES_FEC_EMI
            '
            Me.cDES_FEC_EMI.HeaderText = "DES_FEC_EMI"
            Me.cDES_FEC_EMI.Name = "cDES_FEC_EMI"
            Me.cDES_FEC_EMI.ReadOnly = True
            Me.cDES_FEC_EMI.Width = 78
            '
            'cDES_FEC_TRA
            '
            Me.cDES_FEC_TRA.HeaderText = "DES_FEC_TRA"
            Me.cDES_FEC_TRA.Name = "cDES_FEC_TRA"
            Me.cDES_FEC_TRA.ReadOnly = True
            Me.cDES_FEC_TRA.Width = 79
            '
            'cDES_FEC_SAL_PLA
            '
            Me.cDES_FEC_SAL_PLA.HeaderText = "DES_FEC_SAL_PLA"
            Me.cDES_FEC_SAL_PLA.Name = "cDES_FEC_SAL_PLA"
            Me.cDES_FEC_SAL_PLA.ReadOnly = True
            Me.cDES_FEC_SAL_PLA.Width = 98
            '
            'cDES_FEC_CAR_DES
            '
            Me.cDES_FEC_CAR_DES.HeaderText = "DES_FEC_CAR_DES"
            Me.cDES_FEC_CAR_DES.Name = "cDES_FEC_CAR_DES"
            Me.cDES_FEC_CAR_DES.ReadOnly = True
            '
            'cDES_FEC_PRO_CRO
            '
            Me.cDES_FEC_PRO_CRO.HeaderText = "DES_FEC_PRO_CRO"
            Me.cDES_FEC_PRO_CRO.Name = "cDES_FEC_PRO_CRO"
            Me.cDES_FEC_PRO_CRO.ReadOnly = True
            '
            'cPVE_ID
            '
            Me.cPVE_ID.HeaderText = "PVE_ID"
            Me.cPVE_ID.Name = "cPVE_ID"
            Me.cPVE_ID.ReadOnly = True
            Me.cPVE_ID.Width = 55
            '
            'cPVE_DESCRIPCION
            '
            Me.cPVE_DESCRIPCION.HeaderText = "PVE_DESCRIPCION"
            Me.cPVE_DESCRIPCION.Name = "cPVE_DESCRIPCION"
            Me.cPVE_DESCRIPCION.ReadOnly = True
            Me.cPVE_DESCRIPCION.Width = 97
            '
            'cPVE_DIRECCION
            '
            Me.cPVE_DIRECCION.HeaderText = "PVE_DIRECCION"
            Me.cPVE_DIRECCION.Name = "cPVE_DIRECCION"
            Me.cPVE_DIRECCION.ReadOnly = True
            Me.cPVE_DIRECCION.Width = 87
            '
            'cDIS_ID_PVE
            '
            Me.cDIS_ID_PVE.HeaderText = "DIS_ID_PVE"
            Me.cDIS_ID_PVE.Name = "cDIS_ID_PVE"
            Me.cDIS_ID_PVE.ReadOnly = True
            Me.cDIS_ID_PVE.Width = 71
            '
            'cDIS_DESCRIPCION_PVE
            '
            Me.cDIS_DESCRIPCION_PVE.HeaderText = "DIS_DESCRIPCION_PVE"
            Me.cDIS_DESCRIPCION_PVE.Name = "cDIS_DESCRIPCION_PVE"
            Me.cDIS_DESCRIPCION_PVE.ReadOnly = True
            Me.cDIS_DESCRIPCION_PVE.Width = 113
            '
            'cDIS_ESTADO_PVE
            '
            Me.cDIS_ESTADO_PVE.HeaderText = "DIS_ESTADO_PVE"
            Me.cDIS_ESTADO_PVE.Name = "cDIS_ESTADO_PVE"
            Me.cDIS_ESTADO_PVE.ReadOnly = True
            Me.cDIS_ESTADO_PVE.Width = 91
            '
            'cPRO_ID_PVE
            '
            Me.cPRO_ID_PVE.HeaderText = "PRO_ID_PVE"
            Me.cPRO_ID_PVE.Name = "cPRO_ID_PVE"
            Me.cPRO_ID_PVE.ReadOnly = True
            Me.cPRO_ID_PVE.Width = 74
            '
            'cPRO_DESCRIPCION_PVE
            '
            Me.cPRO_DESCRIPCION_PVE.HeaderText = "PRO_DESCRIPCION_PVE"
            Me.cPRO_DESCRIPCION_PVE.Name = "cPRO_DESCRIPCION_PVE"
            Me.cPRO_DESCRIPCION_PVE.ReadOnly = True
            Me.cPRO_DESCRIPCION_PVE.Width = 116
            '
            'cPRO_ESTADO_PVE
            '
            Me.cPRO_ESTADO_PVE.HeaderText = "PRO_ESTADO_PVE"
            Me.cPRO_ESTADO_PVE.Name = "cPRO_ESTADO_PVE"
            Me.cPRO_ESTADO_PVE.ReadOnly = True
            Me.cPRO_ESTADO_PVE.Width = 94
            '
            'cDEP_ID_PVE
            '
            Me.cDEP_ID_PVE.HeaderText = "DEP_ID_PVE"
            Me.cDEP_ID_PVE.Name = "cDEP_ID_PVE"
            Me.cDEP_ID_PVE.ReadOnly = True
            Me.cDEP_ID_PVE.Width = 74
            '
            'cDEP_DESCRIPCION_PVE
            '
            Me.cDEP_DESCRIPCION_PVE.HeaderText = "DEP_DESCRIPCION_PVE"
            Me.cDEP_DESCRIPCION_PVE.Name = "cDEP_DESCRIPCION_PVE"
            Me.cDEP_DESCRIPCION_PVE.ReadOnly = True
            Me.cDEP_DESCRIPCION_PVE.Width = 116
            '
            'cDEP_ESTADO_PVE
            '
            Me.cDEP_ESTADO_PVE.HeaderText = "DEP_ESTADO_PVE"
            Me.cDEP_ESTADO_PVE.Name = "cDEP_ESTADO_PVE"
            Me.cDEP_ESTADO_PVE.ReadOnly = True
            Me.cDEP_ESTADO_PVE.Width = 94
            '
            'cPAI_ID_PVE
            '
            Me.cPAI_ID_PVE.HeaderText = "PAI_ID_PVE"
            Me.cPAI_ID_PVE.Name = "cPAI_ID_PVE"
            Me.cPAI_ID_PVE.ReadOnly = True
            Me.cPAI_ID_PVE.Width = 70
            '
            'cPAI_DESCRIPCION_PVE
            '
            Me.cPAI_DESCRIPCION_PVE.HeaderText = "PAI_DESCRIPCION_PVE"
            Me.cPAI_DESCRIPCION_PVE.Name = "cPAI_DESCRIPCION_PVE"
            Me.cPAI_DESCRIPCION_PVE.ReadOnly = True
            Me.cPAI_DESCRIPCION_PVE.Width = 112
            '
            'cPAI_ESTADO_PVE
            '
            Me.cPAI_ESTADO_PVE.HeaderText = "PAI_ESTADO_PVE"
            Me.cPAI_ESTADO_PVE.Name = "cPAI_ESTADO_PVE"
            Me.cPAI_ESTADO_PVE.ReadOnly = True
            Me.cPAI_ESTADO_PVE.Width = 90
            '
            'cALM_ID
            '
            Me.cALM_ID.HeaderText = "ALM_ID"
            Me.cALM_ID.Name = "cALM_ID"
            Me.cALM_ID.ReadOnly = True
            Me.cALM_ID.Width = 54
            '
            'cALM_DESCRIPCION
            '
            Me.cALM_DESCRIPCION.HeaderText = "ALM_DESCRIPCION"
            Me.cALM_DESCRIPCION.Name = "cALM_DESCRIPCION"
            Me.cALM_DESCRIPCION.ReadOnly = True
            Me.cALM_DESCRIPCION.Width = 96
            '
            'cALM_DIRECCION
            '
            Me.cALM_DIRECCION.HeaderText = "ALM_DIRECCION"
            Me.cALM_DIRECCION.Name = "cALM_DIRECCION"
            Me.cALM_DIRECCION.ReadOnly = True
            Me.cALM_DIRECCION.Width = 86
            '
            'cDIS_ID_ALM
            '
            Me.cDIS_ID_ALM.HeaderText = "DIS_ID_ALM"
            Me.cDIS_ID_ALM.Name = "cDIS_ID_ALM"
            Me.cDIS_ID_ALM.ReadOnly = True
            Me.cDIS_ID_ALM.Width = 70
            '
            'cDIS_DESCRIPCION_ALM
            '
            Me.cDIS_DESCRIPCION_ALM.HeaderText = "DIS_DESCRIPCION_ALM"
            Me.cDIS_DESCRIPCION_ALM.Name = "cDIS_DESCRIPCION_ALM"
            Me.cDIS_DESCRIPCION_ALM.ReadOnly = True
            Me.cDIS_DESCRIPCION_ALM.Width = 112
            '
            'cDIS_ESTADO_ALM
            '
            Me.cDIS_ESTADO_ALM.HeaderText = "DIS_ESTADO_ALM"
            Me.cDIS_ESTADO_ALM.Name = "cDIS_ESTADO_ALM"
            Me.cDIS_ESTADO_ALM.ReadOnly = True
            Me.cDIS_ESTADO_ALM.Width = 90
            '
            'cPRO_ID_ALM
            '
            Me.cPRO_ID_ALM.HeaderText = "PRO_ID_ALM"
            Me.cPRO_ID_ALM.Name = "cPRO_ID_ALM"
            Me.cPRO_ID_ALM.ReadOnly = True
            Me.cPRO_ID_ALM.Width = 73
            '
            'cPRO_DESCRIPCION_ALM
            '
            Me.cPRO_DESCRIPCION_ALM.HeaderText = "PRO_DESCRIPCION_ALM"
            Me.cPRO_DESCRIPCION_ALM.Name = "cPRO_DESCRIPCION_ALM"
            Me.cPRO_DESCRIPCION_ALM.ReadOnly = True
            Me.cPRO_DESCRIPCION_ALM.Width = 115
            '
            'cPRO_ESTADO_ALM
            '
            Me.cPRO_ESTADO_ALM.HeaderText = "PRO_ESTADO_ALM"
            Me.cPRO_ESTADO_ALM.Name = "cPRO_ESTADO_ALM"
            Me.cPRO_ESTADO_ALM.ReadOnly = True
            Me.cPRO_ESTADO_ALM.Width = 93
            '
            'cDEP_ID_ALM
            '
            Me.cDEP_ID_ALM.HeaderText = "DEP_ID_ALM"
            Me.cDEP_ID_ALM.Name = "cDEP_ID_ALM"
            Me.cDEP_ID_ALM.ReadOnly = True
            Me.cDEP_ID_ALM.Width = 73
            '
            'cDEP_DESCRIPCION_ALM
            '
            Me.cDEP_DESCRIPCION_ALM.HeaderText = "DEP_DESCRIPCION_ALM"
            Me.cDEP_DESCRIPCION_ALM.Name = "cDEP_DESCRIPCION_ALM"
            Me.cDEP_DESCRIPCION_ALM.ReadOnly = True
            Me.cDEP_DESCRIPCION_ALM.Width = 115
            '
            'cDEP_ESTADO_ALM
            '
            Me.cDEP_ESTADO_ALM.HeaderText = "DEP_ESTADO_ALM"
            Me.cDEP_ESTADO_ALM.Name = "cDEP_ESTADO_ALM"
            Me.cDEP_ESTADO_ALM.ReadOnly = True
            Me.cDEP_ESTADO_ALM.Width = 93
            '
            'cPAI_ID_ALM
            '
            Me.cPAI_ID_ALM.HeaderText = "PAI_ID_ALM"
            Me.cPAI_ID_ALM.Name = "cPAI_ID_ALM"
            Me.cPAI_ID_ALM.ReadOnly = True
            Me.cPAI_ID_ALM.Width = 69
            '
            'cPAI_DESCRIPCION_ALM
            '
            Me.cPAI_DESCRIPCION_ALM.HeaderText = "PAI_DESCRIPCION_ALM"
            Me.cPAI_DESCRIPCION_ALM.Name = "cPAI_DESCRIPCION_ALM"
            Me.cPAI_DESCRIPCION_ALM.ReadOnly = True
            Me.cPAI_DESCRIPCION_ALM.Width = 111
            '
            'cPAI_ESTADO_ALM
            '
            Me.cPAI_ESTADO_ALM.HeaderText = "PAI_ESTADO_ALM"
            Me.cPAI_ESTADO_ALM.Name = "cPAI_ESTADO_ALM"
            Me.cPAI_ESTADO_ALM.ReadOnly = True
            Me.cPAI_ESTADO_ALM.Width = 89
            '
            'cALM_ESTADO
            '
            Me.cALM_ESTADO.HeaderText = "ALM_ESTADO"
            Me.cALM_ESTADO.Name = "cALM_ESTADO"
            Me.cALM_ESTADO.ReadOnly = True
            Me.cALM_ESTADO.Width = 74
            '
            'cALM_ID_LLEGADA
            '
            Me.cALM_ID_LLEGADA.HeaderText = "ALM_ID_LLEGADA"
            Me.cALM_ID_LLEGADA.Name = "cALM_ID_LLEGADA"
            Me.cALM_ID_LLEGADA.ReadOnly = True
            Me.cALM_ID_LLEGADA.Width = 91
            '
            'cALM_DESCRIPCION_LLEGADA
            '
            Me.cALM_DESCRIPCION_LLEGADA.HeaderText = "ALM_DESCRIPCION_LLEGADA"
            Me.cALM_DESCRIPCION_LLEGADA.Name = "cALM_DESCRIPCION_LLEGADA"
            Me.cALM_DESCRIPCION_LLEGADA.ReadOnly = True
            Me.cALM_DESCRIPCION_LLEGADA.Width = 133
            '
            'cALM_DIRECCION_LLEGADA
            '
            Me.cALM_DIRECCION_LLEGADA.HeaderText = "ALM_DIRECCION_LLEGADA"
            Me.cALM_DIRECCION_LLEGADA.Name = "cALM_DIRECCION_LLEGADA"
            Me.cALM_DIRECCION_LLEGADA.ReadOnly = True
            Me.cALM_DIRECCION_LLEGADA.Width = 123
            '
            'cDIS_ID_ALM_LLEGADA
            '
            Me.cDIS_ID_ALM_LLEGADA.HeaderText = "DIS_ID_ALM_LLEGADA"
            Me.cDIS_ID_ALM_LLEGADA.Name = "cDIS_ID_ALM_LLEGADA"
            Me.cDIS_ID_ALM_LLEGADA.ReadOnly = True
            Me.cDIS_ID_ALM_LLEGADA.Width = 107
            '
            'cDIS_DESCRIPCION_ALM_LLEGADA
            '
            Me.cDIS_DESCRIPCION_ALM_LLEGADA.HeaderText = "DIS_DESCRIPCION_ALM_LLEGADA"
            Me.cDIS_DESCRIPCION_ALM_LLEGADA.Name = "cDIS_DESCRIPCION_ALM_LLEGADA"
            Me.cDIS_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.cDIS_DESCRIPCION_ALM_LLEGADA.Width = 149
            '
            'cDIS_ESTADO_ALM_LLEGADA
            '
            Me.cDIS_ESTADO_ALM_LLEGADA.HeaderText = "DIS_ESTADO_ALM_LLEGADA"
            Me.cDIS_ESTADO_ALM_LLEGADA.Name = "cDIS_ESTADO_ALM_LLEGADA"
            Me.cDIS_ESTADO_ALM_LLEGADA.ReadOnly = True
            Me.cDIS_ESTADO_ALM_LLEGADA.Width = 127
            '
            'cPRO_ID_ALM_LLEGADA
            '
            Me.cPRO_ID_ALM_LLEGADA.HeaderText = "PRO_ID_ALM_LLEGADA"
            Me.cPRO_ID_ALM_LLEGADA.Name = "cPRO_ID_ALM_LLEGADA"
            Me.cPRO_ID_ALM_LLEGADA.ReadOnly = True
            Me.cPRO_ID_ALM_LLEGADA.Width = 110
            '
            'cPRO_DESCRIPCION_ALM_LLEGADA
            '
            Me.cPRO_DESCRIPCION_ALM_LLEGADA.HeaderText = "PRO_DESCRIPCION_ALM_LLEGADA"
            Me.cPRO_DESCRIPCION_ALM_LLEGADA.Name = "cPRO_DESCRIPCION_ALM_LLEGADA"
            Me.cPRO_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.cPRO_DESCRIPCION_ALM_LLEGADA.Width = 152
            '
            'cPRO_ESTADO_ALM_LLEGADA
            '
            Me.cPRO_ESTADO_ALM_LLEGADA.HeaderText = "PRO_ESTADO_ALM_LLEGADA"
            Me.cPRO_ESTADO_ALM_LLEGADA.Name = "cPRO_ESTADO_ALM_LLEGADA"
            Me.cPRO_ESTADO_ALM_LLEGADA.ReadOnly = True
            Me.cPRO_ESTADO_ALM_LLEGADA.Width = 130
            '
            'cDEP_ID_ALM_LLEGADA
            '
            Me.cDEP_ID_ALM_LLEGADA.HeaderText = "DEP_ID_ALM_LLEGADA"
            Me.cDEP_ID_ALM_LLEGADA.Name = "cDEP_ID_ALM_LLEGADA"
            Me.cDEP_ID_ALM_LLEGADA.ReadOnly = True
            Me.cDEP_ID_ALM_LLEGADA.Width = 110
            '
            'cDEP_DESCRIPCION_ALM_LLEGADA
            '
            Me.cDEP_DESCRIPCION_ALM_LLEGADA.HeaderText = "DEP_DESCRIPCION_ALM_LLEGADA"
            Me.cDEP_DESCRIPCION_ALM_LLEGADA.Name = "cDEP_DESCRIPCION_ALM_LLEGADA"
            Me.cDEP_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.cDEP_DESCRIPCION_ALM_LLEGADA.Width = 152
            '
            'cDEP_ESTADO_ALM_LLEGADA
            '
            Me.cDEP_ESTADO_ALM_LLEGADA.HeaderText = "DEP_ESTADO_ALM_LLEGADA"
            Me.cDEP_ESTADO_ALM_LLEGADA.Name = "cDEP_ESTADO_ALM_LLEGADA"
            Me.cDEP_ESTADO_ALM_LLEGADA.ReadOnly = True
            Me.cDEP_ESTADO_ALM_LLEGADA.Width = 130
            '
            'cPAI_ID_ALM_LLEGADA
            '
            Me.cPAI_ID_ALM_LLEGADA.HeaderText = "PAI_ID_ALM_LLEGADA"
            Me.cPAI_ID_ALM_LLEGADA.Name = "cPAI_ID_ALM_LLEGADA"
            Me.cPAI_ID_ALM_LLEGADA.ReadOnly = True
            Me.cPAI_ID_ALM_LLEGADA.Width = 106
            '
            'cPAI_DESCRIPCION_ALM_LLEGADA
            '
            Me.cPAI_DESCRIPCION_ALM_LLEGADA.HeaderText = "PAI_DESCRIPCION_ALM_LLEGADA"
            Me.cPAI_DESCRIPCION_ALM_LLEGADA.Name = "cPAI_DESCRIPCION_ALM_LLEGADA"
            Me.cPAI_DESCRIPCION_ALM_LLEGADA.ReadOnly = True
            Me.cPAI_DESCRIPCION_ALM_LLEGADA.Width = 148
            '
            'cPAI_ESTADO_ALM_LLEGADA
            '
            Me.cPAI_ESTADO_ALM_LLEGADA.HeaderText = "PAI_ESTADO_ALM_LLEGADA"
            Me.cPAI_ESTADO_ALM_LLEGADA.Name = "cPAI_ESTADO_ALM_LLEGADA"
            Me.cPAI_ESTADO_ALM_LLEGADA.ReadOnly = True
            Me.cPAI_ESTADO_ALM_LLEGADA.Width = 126
            '
            'cALM_ESTADO_LLEGADA
            '
            Me.cALM_ESTADO_LLEGADA.HeaderText = "ALM_ESTADO_LLEGADA"
            Me.cALM_ESTADO_LLEGADA.Name = "cALM_ESTADO_LLEGADA"
            Me.cALM_ESTADO_LLEGADA.ReadOnly = True
            Me.cALM_ESTADO_LLEGADA.Width = 111
            '
            'cDES_SERIE
            '
            Me.cDES_SERIE.HeaderText = "DES_SERIE"
            Me.cDES_SERIE.Name = "cDES_SERIE"
            Me.cDES_SERIE.ReadOnly = True
            Me.cDES_SERIE.Width = 70
            '
            'cDES_NUMERO
            '
            Me.cDES_NUMERO.HeaderText = "DES_NUMERO"
            Me.cDES_NUMERO.Name = "cDES_NUMERO"
            Me.cDES_NUMERO.ReadOnly = True
            Me.cDES_NUMERO.Width = 78
            '
            'cPER_ID_CLI
            '
            Me.cPER_ID_CLI.HeaderText = "PER_ID_CLI"
            Me.cPER_ID_CLI.Name = "cPER_ID_CLI"
            Me.cPER_ID_CLI.ReadOnly = True
            Me.cPER_ID_CLI.Width = 70
            '
            'cPER_DESCRIPCION_CLI
            '
            Me.cPER_DESCRIPCION_CLI.HeaderText = "PER_DESCRIPCION_CLI"
            Me.cPER_DESCRIPCION_CLI.Name = "cPER_DESCRIPCION_CLI"
            Me.cPER_DESCRIPCION_CLI.ReadOnly = True
            Me.cPER_DESCRIPCION_CLI.Width = 112
            '
            'cTDP_ID_CLI
            '
            Me.cTDP_ID_CLI.HeaderText = "TDP_ID_CLI"
            Me.cTDP_ID_CLI.Name = "cTDP_ID_CLI"
            Me.cTDP_ID_CLI.ReadOnly = True
            Me.cTDP_ID_CLI.Width = 68
            '
            'cTDP_DESCRIPCION_CLI
            '
            Me.cTDP_DESCRIPCION_CLI.HeaderText = "TDP_DESCRIPCION_CLI"
            Me.cTDP_DESCRIPCION_CLI.Name = "cTDP_DESCRIPCION_CLI"
            Me.cTDP_DESCRIPCION_CLI.ReadOnly = True
            Me.cTDP_DESCRIPCION_CLI.Width = 110
            '
            'cDOP_NUMERO_CLI
            '
            Me.cDOP_NUMERO_CLI.HeaderText = "DOP_NUMERO_CLI"
            Me.cDOP_NUMERO_CLI.Name = "cDOP_NUMERO_CLI"
            Me.cDOP_NUMERO_CLI.ReadOnly = True
            Me.cDOP_NUMERO_CLI.Width = 93
            '
            'cPER_ID_VEN
            '
            Me.cPER_ID_VEN.HeaderText = "PER_ID_VEN"
            Me.cPER_ID_VEN.Name = "cPER_ID_VEN"
            Me.cPER_ID_VEN.ReadOnly = True
            Me.cPER_ID_VEN.Width = 74
            '
            'cPER_DESCRIPCION_VEN
            '
            Me.cPER_DESCRIPCION_VEN.HeaderText = "PER_DESCRIPCION_VEN"
            Me.cPER_DESCRIPCION_VEN.Name = "cPER_DESCRIPCION_VEN"
            Me.cPER_DESCRIPCION_VEN.ReadOnly = True
            Me.cPER_DESCRIPCION_VEN.Width = 116
            '
            'cTDO_ID_DOC
            '
            Me.cTDO_ID_DOC.HeaderText = "TDO_ID_DOC"
            Me.cTDO_ID_DOC.Name = "cTDO_ID_DOC"
            Me.cTDO_ID_DOC.ReadOnly = True
            Me.cTDO_ID_DOC.Width = 72
            '
            'cTDO_DESCRIPCION_DOC
            '
            Me.cTDO_DESCRIPCION_DOC.HeaderText = "TDO_DESCRIPCION_DOC"
            Me.cTDO_DESCRIPCION_DOC.Name = "cTDO_DESCRIPCION_DOC"
            Me.cTDO_DESCRIPCION_DOC.ReadOnly = True
            Me.cTDO_DESCRIPCION_DOC.Width = 114
            '
            'cDTD_ID_DOC
            '
            Me.cDTD_ID_DOC.HeaderText = "DTD_ID_DOC"
            Me.cDTD_ID_DOC.Name = "cDTD_ID_DOC"
            Me.cDTD_ID_DOC.ReadOnly = True
            Me.cDTD_ID_DOC.Width = 72
            '
            'cDTD_DESCRIPCION_DOC
            '
            Me.cDTD_DESCRIPCION_DOC.HeaderText = "DTD_DESCRIPCION_DOC"
            Me.cDTD_DESCRIPCION_DOC.Name = "cDTD_DESCRIPCION_DOC"
            Me.cDTD_DESCRIPCION_DOC.ReadOnly = True
            Me.cDTD_DESCRIPCION_DOC.Width = 114
            '
            'cCCT_ID_DOC
            '
            Me.cCCT_ID_DOC.HeaderText = "CCT_ID_DOC"
            Me.cCCT_ID_DOC.Name = "cCCT_ID_DOC"
            Me.cCCT_ID_DOC.ReadOnly = True
            Me.cCCT_ID_DOC.Width = 72
            '
            'cCCT_DESCRIPCION_DOC
            '
            Me.cCCT_DESCRIPCION_DOC.HeaderText = "CCT_DESCRIPCION_DOC"
            Me.cCCT_DESCRIPCION_DOC.Name = "cCCT_DESCRIPCION_DOC"
            Me.cCCT_DESCRIPCION_DOC.ReadOnly = True
            Me.cCCT_DESCRIPCION_DOC.Width = 114
            '
            'cDOC_ORDEN_COMPRA
            '
            Me.cDOC_ORDEN_COMPRA.HeaderText = "DOC_ORDEN_COMPRA"
            Me.cDOC_ORDEN_COMPRA.Name = "cDOC_ORDEN_COMPRA"
            Me.cDOC_ORDEN_COMPRA.ReadOnly = True
            Me.cDOC_ORDEN_COMPRA.Width = 107
            '
            'cTIV_ID_DOC
            '
            Me.cTIV_ID_DOC.HeaderText = "TIV_ID_DOC"
            Me.cTIV_ID_DOC.Name = "cTIV_ID_DOC"
            Me.cTIV_ID_DOC.ReadOnly = True
            Me.cTIV_ID_DOC.Width = 69
            '
            'cTIV_DESCRIPCION_DOC
            '
            Me.cTIV_DESCRIPCION_DOC.HeaderText = "TIV_DESCRIPCION_DOC"
            Me.cTIV_DESCRIPCION_DOC.Name = "cTIV_DESCRIPCION_DOC"
            Me.cTIV_DESCRIPCION_DOC.ReadOnly = True
            Me.cTIV_DESCRIPCION_DOC.Width = 111
            '
            'cMON_ID_DOC
            '
            Me.cMON_ID_DOC.HeaderText = "MON_ID_DOC"
            Me.cMON_ID_DOC.Name = "cMON_ID_DOC"
            Me.cMON_ID_DOC.ReadOnly = True
            Me.cMON_ID_DOC.Width = 74
            '
            'cMON_DESCRIPCION_DOC
            '
            Me.cMON_DESCRIPCION_DOC.HeaderText = "MON_DESCRIPCION_DOC"
            Me.cMON_DESCRIPCION_DOC.Name = "cMON_DESCRIPCION_DOC"
            Me.cMON_DESCRIPCION_DOC.ReadOnly = True
            Me.cMON_DESCRIPCION_DOC.Width = 116
            '
            'cDOC_TIPO_LISTA
            '
            Me.cDOC_TIPO_LISTA.HeaderText = "DOC_TIPO_LISTA"
            Me.cDOC_TIPO_LISTA.Name = "cDOC_TIPO_LISTA"
            Me.cDOC_TIPO_LISTA.ReadOnly = True
            Me.cDOC_TIPO_LISTA.Width = 85
            '
            'cDES_SERIE_DOC
            '
            Me.cDES_SERIE_DOC.HeaderText = "DES_SERIE_DOC"
            Me.cDES_SERIE_DOC.Name = "cDES_SERIE_DOC"
            Me.cDES_SERIE_DOC.ReadOnly = True
            Me.cDES_SERIE_DOC.Width = 89
            '
            'cDES_NUMERO_DOC
            '
            Me.cDES_NUMERO_DOC.HeaderText = "DES_NUMERO_DOC"
            Me.cDES_NUMERO_DOC.Name = "cDES_NUMERO_DOC"
            Me.cDES_NUMERO_DOC.ReadOnly = True
            Me.cDES_NUMERO_DOC.Width = 97
            '
            'cPER_ID_REC
            '
            Me.cPER_ID_REC.HeaderText = "PER_ID_REC"
            Me.cPER_ID_REC.Name = "cPER_ID_REC"
            Me.cPER_ID_REC.ReadOnly = True
            Me.cPER_ID_REC.Width = 74
            '
            'cPER_DESCRIPCION_REC
            '
            Me.cPER_DESCRIPCION_REC.HeaderText = "PER_DESCRIPCION_REC"
            Me.cPER_DESCRIPCION_REC.Name = "cPER_DESCRIPCION_REC"
            Me.cPER_DESCRIPCION_REC.ReadOnly = True
            Me.cPER_DESCRIPCION_REC.Width = 116
            '
            'cTDP_ID_REC
            '
            Me.cTDP_ID_REC.HeaderText = "TDP_ID_REC"
            Me.cTDP_ID_REC.Name = "cTDP_ID_REC"
            Me.cTDP_ID_REC.ReadOnly = True
            Me.cTDP_ID_REC.Width = 72
            '
            'cTDP_DESCRIPCION_REC
            '
            Me.cTDP_DESCRIPCION_REC.HeaderText = "TDP_DESCRIPCION_REC"
            Me.cTDP_DESCRIPCION_REC.Name = "cTDP_DESCRIPCION_REC"
            Me.cTDP_DESCRIPCION_REC.ReadOnly = True
            Me.cTDP_DESCRIPCION_REC.Width = 114
            '
            'cDOP_NUMERO_REC
            '
            Me.cDOP_NUMERO_REC.HeaderText = "DOP_NUMERO_REC"
            Me.cDOP_NUMERO_REC.Name = "cDOP_NUMERO_REC"
            Me.cDOP_NUMERO_REC.ReadOnly = True
            Me.cDOP_NUMERO_REC.Width = 97
            '
            'cDIR_ID_ENT_REC
            '
            Me.cDIR_ID_ENT_REC.HeaderText = "DIR_ID_ENT_REC"
            Me.cDIR_ID_ENT_REC.Name = "cDIR_ID_ENT_REC"
            Me.cDIR_ID_ENT_REC.ReadOnly = True
            Me.cDIR_ID_ENT_REC.Width = 88
            '
            'cDIR_DESCRIPCION_ENT_REC
            '
            Me.cDIR_DESCRIPCION_ENT_REC.HeaderText = "DIR_DESCRIPCION_ENT_REC"
            Me.cDIR_DESCRIPCION_ENT_REC.Name = "cDIR_DESCRIPCION_ENT_REC"
            Me.cDIR_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.cDIR_DESCRIPCION_ENT_REC.Width = 130
            '
            'cDIR_TIPO_ENT_REC
            '
            Me.cDIR_TIPO_ENT_REC.HeaderText = "DIR_TIPO_ENT_REC"
            Me.cDIR_TIPO_ENT_REC.Name = "cDIR_TIPO_ENT_REC"
            Me.cDIR_TIPO_ENT_REC.ReadOnly = True
            Me.cDIR_TIPO_ENT_REC.Width = 96
            '
            'cDIR_REFERENCIA_ENT_REC
            '
            Me.cDIR_REFERENCIA_ENT_REC.HeaderText = "DIR_REFERENCIA_ENT_REC"
            Me.cDIR_REFERENCIA_ENT_REC.Name = "cDIR_REFERENCIA_ENT_REC"
            Me.cDIR_REFERENCIA_ENT_REC.ReadOnly = True
            Me.cDIR_REFERENCIA_ENT_REC.Width = 127
            '
            'cDIS_ID_ENT_REC
            '
            Me.cDIS_ID_ENT_REC.HeaderText = "DIS_ID_ENT_REC"
            Me.cDIS_ID_ENT_REC.Name = "cDIS_ID_ENT_REC"
            Me.cDIS_ID_ENT_REC.ReadOnly = True
            Me.cDIS_ID_ENT_REC.Width = 88
            '
            'cDIS_DESCRIPCION_ENT_REC
            '
            Me.cDIS_DESCRIPCION_ENT_REC.HeaderText = "DIS_DESCRIPCION_ENT_REC"
            Me.cDIS_DESCRIPCION_ENT_REC.Name = "cDIS_DESCRIPCION_ENT_REC"
            Me.cDIS_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.cDIS_DESCRIPCION_ENT_REC.Width = 130
            '
            'cPRO_ID_ENT_REC
            '
            Me.cPRO_ID_ENT_REC.HeaderText = "PRO_ID_ENT_REC"
            Me.cPRO_ID_ENT_REC.Name = "cPRO_ID_ENT_REC"
            Me.cPRO_ID_ENT_REC.ReadOnly = True
            Me.cPRO_ID_ENT_REC.Width = 91
            '
            'cPRO_DESCRIPCION_ENT_REC
            '
            Me.cPRO_DESCRIPCION_ENT_REC.HeaderText = "PRO_DESCRIPCION_ENT_REC"
            Me.cPRO_DESCRIPCION_ENT_REC.Name = "cPRO_DESCRIPCION_ENT_REC"
            Me.cPRO_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.cPRO_DESCRIPCION_ENT_REC.Width = 133
            '
            'cDEP_ID_ENT_REC
            '
            Me.cDEP_ID_ENT_REC.HeaderText = "DEP_ID_ENT_REC"
            Me.cDEP_ID_ENT_REC.Name = "cDEP_ID_ENT_REC"
            Me.cDEP_ID_ENT_REC.ReadOnly = True
            Me.cDEP_ID_ENT_REC.Width = 91
            '
            'cDEP_DESCRIPCION_ENT_REC
            '
            Me.cDEP_DESCRIPCION_ENT_REC.HeaderText = "DEP_DESCRIPCION_ENT_REC"
            Me.cDEP_DESCRIPCION_ENT_REC.Name = "cDEP_DESCRIPCION_ENT_REC"
            Me.cDEP_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.cDEP_DESCRIPCION_ENT_REC.Width = 133
            '
            'cPAI_ID_ENT_REC
            '
            Me.cPAI_ID_ENT_REC.HeaderText = "PAI_ID_ENT_REC"
            Me.cPAI_ID_ENT_REC.Name = "cPAI_ID_ENT_REC"
            Me.cPAI_ID_ENT_REC.ReadOnly = True
            Me.cPAI_ID_ENT_REC.Width = 87
            '
            'cPAI_DESCRIPCION_ENT_REC
            '
            Me.cPAI_DESCRIPCION_ENT_REC.HeaderText = "PAI_DESCRIPCION_ENT_REC"
            Me.cPAI_DESCRIPCION_ENT_REC.Name = "cPAI_DESCRIPCION_ENT_REC"
            Me.cPAI_DESCRIPCION_ENT_REC.ReadOnly = True
            Me.cPAI_DESCRIPCION_ENT_REC.Width = 129
            '
            'cDIR_ESTADO_ENT_REC
            '
            Me.cDIR_ESTADO_ENT_REC.HeaderText = "DIR_ESTADO_ENT_REC"
            Me.cDIR_ESTADO_ENT_REC.Name = "cDIR_ESTADO_ENT_REC"
            Me.cDIR_ESTADO_ENT_REC.ReadOnly = True
            Me.cDIR_ESTADO_ENT_REC.Width = 108
            '
            'cDIR_ID_ENT
            '
            Me.cDIR_ID_ENT.HeaderText = "DIR_ID_ENT"
            Me.cDIR_ID_ENT.Name = "cDIR_ID_ENT"
            Me.cDIR_ID_ENT.ReadOnly = True
            Me.cDIR_ID_ENT.Width = 69
            '
            'cDIR_DESCRIPCION_ENT
            '
            Me.cDIR_DESCRIPCION_ENT.HeaderText = "DIR_DESCRIPCION_ENT"
            Me.cDIR_DESCRIPCION_ENT.Name = "cDIR_DESCRIPCION_ENT"
            Me.cDIR_DESCRIPCION_ENT.ReadOnly = True
            Me.cDIR_DESCRIPCION_ENT.Width = 111
            '
            'cDIS_ID_ENT
            '
            Me.cDIS_ID_ENT.HeaderText = "DIS_ID_ENT"
            Me.cDIS_ID_ENT.Name = "cDIS_ID_ENT"
            Me.cDIS_ID_ENT.ReadOnly = True
            Me.cDIS_ID_ENT.Width = 69
            '
            'cDIS_DESCRIPCION_ENT
            '
            Me.cDIS_DESCRIPCION_ENT.HeaderText = "DIS_DESCRIPCION_ENT"
            Me.cDIS_DESCRIPCION_ENT.Name = "cDIS_DESCRIPCION_ENT"
            Me.cDIS_DESCRIPCION_ENT.ReadOnly = True
            Me.cDIS_DESCRIPCION_ENT.Width = 111
            '
            'cDIS_ESTADO_ENT
            '
            Me.cDIS_ESTADO_ENT.HeaderText = "DIS_ESTADO_ENT"
            Me.cDIS_ESTADO_ENT.Name = "cDIS_ESTADO_ENT"
            Me.cDIS_ESTADO_ENT.ReadOnly = True
            Me.cDIS_ESTADO_ENT.Width = 89
            '
            'cPRO_ID_ENT
            '
            Me.cPRO_ID_ENT.HeaderText = "PRO_ID_ENT"
            Me.cPRO_ID_ENT.Name = "cPRO_ID_ENT"
            Me.cPRO_ID_ENT.ReadOnly = True
            Me.cPRO_ID_ENT.Width = 72
            '
            'cPRO_DESCRIPCION_ENT
            '
            Me.cPRO_DESCRIPCION_ENT.HeaderText = "PRO_DESCRIPCION_ENT"
            Me.cPRO_DESCRIPCION_ENT.Name = "cPRO_DESCRIPCION_ENT"
            Me.cPRO_DESCRIPCION_ENT.ReadOnly = True
            Me.cPRO_DESCRIPCION_ENT.Width = 114
            '
            'cPRO_ESTADO_ENT
            '
            Me.cPRO_ESTADO_ENT.HeaderText = "PRO_ESTADO_ENT"
            Me.cPRO_ESTADO_ENT.Name = "cPRO_ESTADO_ENT"
            Me.cPRO_ESTADO_ENT.ReadOnly = True
            Me.cPRO_ESTADO_ENT.Width = 92
            '
            'cDEP_ID_ENT
            '
            Me.cDEP_ID_ENT.HeaderText = "DEP_ID_ENT"
            Me.cDEP_ID_ENT.Name = "cDEP_ID_ENT"
            Me.cDEP_ID_ENT.ReadOnly = True
            Me.cDEP_ID_ENT.Width = 72
            '
            'cDEP_DESCRIPCION_ENT
            '
            Me.cDEP_DESCRIPCION_ENT.HeaderText = "DEP_DESCRIPCION_ENT"
            Me.cDEP_DESCRIPCION_ENT.Name = "cDEP_DESCRIPCION_ENT"
            Me.cDEP_DESCRIPCION_ENT.ReadOnly = True
            Me.cDEP_DESCRIPCION_ENT.Width = 114
            '
            'cDEP_ESTADO_ENT
            '
            Me.cDEP_ESTADO_ENT.HeaderText = "DEP_ESTADO_ENT"
            Me.cDEP_ESTADO_ENT.Name = "cDEP_ESTADO_ENT"
            Me.cDEP_ESTADO_ENT.ReadOnly = True
            Me.cDEP_ESTADO_ENT.Width = 92
            '
            'cPAI_ID_ENT
            '
            Me.cPAI_ID_ENT.HeaderText = "PAI_ID_ENT"
            Me.cPAI_ID_ENT.Name = "cPAI_ID_ENT"
            Me.cPAI_ID_ENT.ReadOnly = True
            Me.cPAI_ID_ENT.Width = 68
            '
            'cPAI_DESCRIPCION_ENT
            '
            Me.cPAI_DESCRIPCION_ENT.HeaderText = "PAI_DESCRIPCION_ENT"
            Me.cPAI_DESCRIPCION_ENT.Name = "cPAI_DESCRIPCION_ENT"
            Me.cPAI_DESCRIPCION_ENT.ReadOnly = True
            Me.cPAI_DESCRIPCION_ENT.Width = 110
            '
            'cPAIS_ESTADO_ENT
            '
            Me.cPAIS_ESTADO_ENT.HeaderText = "PAIS_ESTADO_ENT"
            Me.cPAIS_ESTADO_ENT.Name = "cPAIS_ESTADO_ENT"
            Me.cPAIS_ESTADO_ENT.ReadOnly = True
            Me.cPAIS_ESTADO_ENT.Width = 93
            '
            'cDIR_REFERENCIA_ENT
            '
            Me.cDIR_REFERENCIA_ENT.HeaderText = "DIR_REFERENCIA_ENT"
            Me.cDIR_REFERENCIA_ENT.Name = "cDIR_REFERENCIA_ENT"
            Me.cDIR_REFERENCIA_ENT.ReadOnly = True
            Me.cDIR_REFERENCIA_ENT.Width = 108
            '
            'cFLE_ID
            '
            Me.cFLE_ID.HeaderText = "FLE_ID"
            Me.cFLE_ID.Name = "cFLE_ID"
            Me.cFLE_ID.ReadOnly = True
            Me.cFLE_ID.Width = 53
            '
            'cFLE_DESCRIPCION
            '
            Me.cFLE_DESCRIPCION.HeaderText = "FLE_DESCRIPCION"
            Me.cFLE_DESCRIPCION.Name = "cFLE_DESCRIPCION"
            Me.cFLE_DESCRIPCION.ReadOnly = True
            Me.cFLE_DESCRIPCION.Width = 95
            '
            'cFLE_TIPO
            '
            Me.cFLE_TIPO.HeaderText = "FLE_TIPO"
            Me.cFLE_TIPO.Name = "cFLE_TIPO"
            Me.cFLE_TIPO.ReadOnly = True
            Me.cFLE_TIPO.Width = 61
            '
            'cFLE_ESTADO
            '
            Me.cFLE_ESTADO.HeaderText = "FLE_ESTADO"
            Me.cFLE_ESTADO.Name = "cFLE_ESTADO"
            Me.cFLE_ESTADO.ReadOnly = True
            Me.cFLE_ESTADO.Width = 73
            '
            'cMON_ID
            '
            Me.cMON_ID.HeaderText = "MON_ID"
            Me.cMON_ID.Name = "cMON_ID"
            Me.cMON_ID.ReadOnly = True
            Me.cMON_ID.Width = 55
            '
            'cMON_DESCRIPCION
            '
            Me.cMON_DESCRIPCION.HeaderText = "MON_DESCRIPCION"
            Me.cMON_DESCRIPCION.Name = "cMON_DESCRIPCION"
            Me.cMON_DESCRIPCION.ReadOnly = True
            Me.cMON_DESCRIPCION.Width = 97
            '
            'cDES_MONTO_FLETE
            '
            Me.cDES_MONTO_FLETE.HeaderText = "DES_MONTO_FLETE"
            Me.cDES_MONTO_FLETE.Name = "cDES_MONTO_FLETE"
            Me.cDES_MONTO_FLETE.ReadOnly = True
            Me.cDES_MONTO_FLETE.Width = 96
            '
            'cDES_CONTRAVALOR
            '
            Me.cDES_CONTRAVALOR.HeaderText = "DES_CONTRAVALOR"
            Me.cDES_CONTRAVALOR.Name = "cDES_CONTRAVALOR"
            Me.cDES_CONTRAVALOR.ReadOnly = True
            Me.cDES_CONTRAVALOR.Width = 98
            '
            'cPLA_ID
            '
            Me.cPLA_ID.HeaderText = "PLA_ID"
            Me.cPLA_ID.Name = "cPLA_ID"
            Me.cPLA_ID.ReadOnly = True
            Me.cPLA_ID.Width = 54
            '
            'cPER_ID_TRA1
            '
            Me.cPER_ID_TRA1.HeaderText = "PER_ID_TRA1"
            Me.cPER_ID_TRA1.Name = "cPER_ID_TRA1"
            Me.cPER_ID_TRA1.ReadOnly = True
            Me.cPER_ID_TRA1.Width = 76
            '
            'cPER_DESCRIPCION_TRA1
            '
            Me.cPER_DESCRIPCION_TRA1.HeaderText = "PER_DESCRIPCION_TRA1"
            Me.cPER_DESCRIPCION_TRA1.Name = "cPER_DESCRIPCION_TRA1"
            Me.cPER_DESCRIPCION_TRA1.ReadOnly = True
            Me.cPER_DESCRIPCION_TRA1.Width = 118
            '
            'cRUC_TRA1
            '
            Me.cRUC_TRA1.HeaderText = "RUC_TRA1"
            Me.cRUC_TRA1.Name = "cRUC_TRA1"
            Me.cRUC_TRA1.ReadOnly = True
            Me.cRUC_TRA1.Width = 65
            '
            'cPER_ESTADO_TRA1
            '
            Me.cPER_ESTADO_TRA1.HeaderText = "PER_ESTADO_TRA1"
            Me.cPER_ESTADO_TRA1.Name = "cPER_ESTADO_TRA1"
            Me.cPER_ESTADO_TRA1.ReadOnly = True
            Me.cPER_ESTADO_TRA1.Width = 96
            '
            'cUNT_ID_1
            '
            Me.cUNT_ID_1.HeaderText = "UNT_ID_1"
            Me.cUNT_ID_1.Name = "cUNT_ID_1"
            Me.cUNT_ID_1.ReadOnly = True
            Me.cUNT_ID_1.Width = 61
            '
            'cMAR_DESCRIPCION_TRA1
            '
            Me.cMAR_DESCRIPCION_TRA1.HeaderText = "MAR_DESCRIPCION_TRA1"
            Me.cMAR_DESCRIPCION_TRA1.Name = "cMAR_DESCRIPCION_TRA1"
            Me.cMAR_DESCRIPCION_TRA1.ReadOnly = True
            Me.cMAR_DESCRIPCION_TRA1.Width = 118
            '
            'cMOD_DESCRIPCION_TRA1
            '
            Me.cMOD_DESCRIPCION_TRA1.HeaderText = "MOD_DESCRIPCION_TRA1"
            Me.cMOD_DESCRIPCION_TRA1.Name = "cMOD_DESCRIPCION_TRA1"
            Me.cMOD_DESCRIPCION_TRA1.ReadOnly = True
            Me.cMOD_DESCRIPCION_TRA1.Width = 118
            '
            'cUNT_NRO_INS_TRA1
            '
            Me.cUNT_NRO_INS_TRA1.HeaderText = "UNT_NRO_INS_TRA1"
            Me.cUNT_NRO_INS_TRA1.Name = "cUNT_NRO_INS_TRA1"
            Me.cUNT_NRO_INS_TRA1.ReadOnly = True
            Me.cUNT_NRO_INS_TRA1.Width = 98
            '
            'cUNT_ID_2
            '
            Me.cUNT_ID_2.HeaderText = "UNT_ID_2"
            Me.cUNT_ID_2.Name = "cUNT_ID_2"
            Me.cUNT_ID_2.ReadOnly = True
            Me.cUNT_ID_2.Width = 61
            '
            'cMAR_DESCRIPCION_TRA2
            '
            Me.cMAR_DESCRIPCION_TRA2.HeaderText = "MAR_DESCRIPCION_TRA2"
            Me.cMAR_DESCRIPCION_TRA2.Name = "cMAR_DESCRIPCION_TRA2"
            Me.cMAR_DESCRIPCION_TRA2.ReadOnly = True
            Me.cMAR_DESCRIPCION_TRA2.Width = 118
            '
            'cMOD_DESCRIPCION_TRA2
            '
            Me.cMOD_DESCRIPCION_TRA2.HeaderText = "MOD_DESCRIPCION_TRA2"
            Me.cMOD_DESCRIPCION_TRA2.Name = "cMOD_DESCRIPCION_TRA2"
            Me.cMOD_DESCRIPCION_TRA2.ReadOnly = True
            Me.cMOD_DESCRIPCION_TRA2.Width = 118
            '
            'cUNT_NRO_INS_TRA2
            '
            Me.cUNT_NRO_INS_TRA2.HeaderText = "UNT_NRO_INS_TRA2"
            Me.cUNT_NRO_INS_TRA2.Name = "cUNT_NRO_INS_TRA2"
            Me.cUNT_NRO_INS_TRA2.ReadOnly = True
            Me.cUNT_NRO_INS_TRA2.Width = 98
            '
            'cPER_ID_CHO
            '
            Me.cPER_ID_CHO.HeaderText = "PER_ID_CHO"
            Me.cPER_ID_CHO.Name = "cPER_ID_CHO"
            Me.cPER_ID_CHO.ReadOnly = True
            Me.cPER_ID_CHO.Width = 74
            '
            'cPER_DESCRIPCION_CHO
            '
            Me.cPER_DESCRIPCION_CHO.HeaderText = "PER_DESCRIPCION_CHO"
            Me.cPER_DESCRIPCION_CHO.Name = "cPER_DESCRIPCION_CHO"
            Me.cPER_DESCRIPCION_CHO.ReadOnly = True
            Me.cPER_DESCRIPCION_CHO.Width = 116
            '
            'cPER_BREVETE_CHO
            '
            Me.cPER_BREVETE_CHO.HeaderText = "PER_BREVETE_CHO"
            Me.cPER_BREVETE_CHO.Name = "cPER_BREVETE_CHO"
            Me.cPER_BREVETE_CHO.ReadOnly = True
            '
            'cPER_ESTADO_CHO
            '
            Me.cPER_ESTADO_CHO.HeaderText = "PER_ESTADO_CHO"
            Me.cPER_ESTADO_CHO.Name = "cPER_ESTADO_CHO"
            Me.cPER_ESTADO_CHO.ReadOnly = True
            Me.cPER_ESTADO_CHO.Width = 94
            '
            'cDES_ESTADO
            '
            Me.cDES_ESTADO.HeaderText = "DES_ESTADO"
            Me.cDES_ESTADO.Name = "cDES_ESTADO"
            Me.cDES_ESTADO.ReadOnly = True
            Me.cDES_ESTADO.Width = 75
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
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle8.Format = "N3"
            DataGridViewCellStyle8.NullValue = Nothing
            Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewTextBoxColumn7.HeaderText = "Cantidad vendida"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewTextBoxColumn8.HeaderText = "Cantidad movida"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle10.Format = "N4"
            DataGridViewCellStyle10.NullValue = Nothing
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle10
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
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle11
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
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle12.Format = "N4"
            DataGridViewCellStyle12.NullValue = Nothing
            Me.DataGridViewTextBoxColumn24.DefaultCellStyle = DataGridViewCellStyle12
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
            'txtDES_NUMERO_X
            '
            Me.txtDES_NUMERO_X.Location = New System.Drawing.Point(290, 33)
            Me.txtDES_NUMERO_X.Name = "txtDES_NUMERO_X"
            Me.txtDES_NUMERO_X.Size = New System.Drawing.Size(109, 20)
            Me.txtDES_NUMERO_X.TabIndex = 257
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.dtpFecha.Location = New System.Drawing.Point(225, 33)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(110, 20)
            Me.dtpFecha.TabIndex = 252
            '
            'frmMarcarSalidaGuia
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(825, 559)
            Me.Controls.Add(Me.dtpFecha)
            Me.Controls.Add(Me.txtDES_NUMERO_X)
            Me.Controls.Add(Me.btnBuscar)
            Me.Controls.Add(Me.txtUNT_ID)
            Me.Controls.Add(Me.lbltxt)
            Me.Controls.Add(Me.txtBuscarSerie)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.dgvDatos)
            Me.Controls.Add(Me.ssDespachos)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmMarcarSalidaGuia"
            Me.Text = "Marcar salida de guía"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.ssDespachos, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.dgvDatos, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtBuscarSerie, 0)
            Me.Controls.SetChildIndex(Me.lbltxt, 0)
            Me.Controls.SetChildIndex(Me.txtUNT_ID, 0)
            Me.Controls.SetChildIndex(Me.btnBuscar, 0)
            Me.Controls.SetChildIndex(Me.txtDES_NUMERO_X, 0)
            Me.Controls.SetChildIndex(Me.dtpFecha, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcoDirecciones.ResumeLayout(False)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents lblPER_ID_CLI As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CLI As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Friend WithEvents tcoDirecciones As System.Windows.Forms.TabControl
        Friend WithEvents tpaEntrega As System.Windows.Forms.TabPage
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
        Friend WithEvents ssDespachos As System.Windows.Forms.StatusStrip
        Friend WithEvents tslFechaServidor As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslSeparador1 As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslTipoCambioCompraMoneda As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslSeparador2 As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslTipoCambioVentaMoneda As System.Windows.Forms.ToolStripStatusLabel
        Public WithEvents txtDOC_TIPO_LISTA As System.Windows.Forms.TextBox
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
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
        Friend WithEvents lbltxt As System.Windows.Forms.Label
        Public WithEvents txtUNT_ID As System.Windows.Forms.TextBox
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Public WithEvents txtDES_NUMERO_X As System.Windows.Forms.TextBox
        Friend WithEvents cChecked As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents cTDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_CARGO_ABONO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_SIGNO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_SIGNO_D As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_FEC_EMI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_FEC_TRA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_FEC_SAL_PLA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_FEC_CAR_DES As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_FEC_PRO_CRO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPVE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPVE_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPVE_DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ID_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ESTADO_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ID_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ESTADO_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ID_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ESTADO_PVE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ID_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ESTADO_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ID_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ESTADO_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ID_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ESTADO_ALM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_ID_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_DESCRIPCION_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_DIRECCION_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ID_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ESTADO_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ID_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ESTADO_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ID_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ESTADO_ALM_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cALM_ESTADO_LLEGADA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ID_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_ID_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_DESCRIPCION_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOP_NUMERO_CLI As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ID_VEN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_VEN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOC_ORDEN_COMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTIV_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTIV_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOC_TIPO_LISTA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_SERIE_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_NUMERO_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ID_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_ID_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDP_DESCRIPCION_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDOP_NUMERO_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_ID_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_DESCRIPCION_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_TIPO_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_REFERENCIA_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ID_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ID_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ID_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_ESTADO_ENT_REC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_ID_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_DESCRIPCION_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_DESCRIPCION_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ID_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ESTADO_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ID_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ESTADO_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ID_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAIS_ESTADO_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIR_REFERENCIA_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cFLE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cFLE_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cFLE_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cFLE_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMON_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_MONTO_FLETE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_CONTRAVALOR As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPLA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ID_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cRUC_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ESTADO_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cUNT_ID_1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMAR_DESCRIPCION_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMOD_DESCRIPCION_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cUNT_NRO_INS_TRA1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cUNT_ID_2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMAR_DESCRIPCION_TRA2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cMOD_DESCRIPCION_TRA2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cUNT_NRO_INS_TRA2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ID_CHO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_DESCRIPCION_CHO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_BREVETE_CHO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPER_ESTADO_CHO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDES_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Public WithEvents txtBuscarSerie As System.Windows.Forms.TextBox
    End Class
End Namespace