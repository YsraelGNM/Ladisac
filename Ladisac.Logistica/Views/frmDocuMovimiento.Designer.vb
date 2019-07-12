<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocuMovimiento
    Inherits Ladisac.Foundation.Views.ViewManMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Comprar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.EsDevolucion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaDoc = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOR = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.chkAfectaKardex = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtIGV = New System.Windows.Forms.MaskedTextBox()
        Me.numTipoCambio = New System.Windows.Forms.NumericUpDown()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTFO = New System.Windows.Forms.TextBox()
        Me.txtNroServ = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotalIgv = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.lblHecho = New System.Windows.Forms.Label()
        Me.cboTipoDocumentoREF = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNumeroREF = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSerieREF = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
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
        Me.DMD_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Glosa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OCD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMD_ID_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALM_ID_DESTINO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1035, 28)
        Me.lblTitle.Text = "Documentacion"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DMD_Id, Me.ART_Id, Me.Stock, Me.Cantidad, Me.UM, Me.PU, Me.Descuento, Me.SubTotal, Me.IGV, Me.Total, Me.Glosa, Me.ALM_ID, Me.ORD_ID, Me.OCD_ID, Me.DMD_ID_REF, Me.TRD_ID, Me.Comprar, Me.ALM_ID_DESTINO, Me.EsDevolucion})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 245)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(1011, 262)
        Me.dgvDetalle.TabIndex = 65
        '
        'Comprar
        '
        Me.Comprar.HeaderText = "Comprar"
        Me.Comprar.Name = "Comprar"
        Me.Comprar.Width = 52
        '
        'EsDevolucion
        '
        Me.EsDevolucion.HeaderText = "EsDevolucion"
        Me.EsDevolucion.Name = "EsDevolucion"
        Me.EsDevolucion.Visible = False
        Me.EsDevolucion.Width = 79
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(90, 120)
        Me.txtSerie.MaxLength = 4
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(89, 20)
        Me.txtSerie.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Serie"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(574, 62)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 60
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(484, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(90, 64)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(79, 20)
        Me.txtCodigo.TabIndex = 57
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(289, 120)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(153, 20)
        Me.txtNumero.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(215, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Numero"
        '
        'dtpFechaDoc
        '
        Me.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDoc.Location = New System.Drawing.Point(90, 149)
        Me.dtpFechaDoc.Name = "dtpFechaDoc"
        Me.dtpFechaDoc.Size = New System.Drawing.Size(89, 20)
        Me.dtpFechaDoc.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Fecha Doc."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(484, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(574, 91)
        Me.txtProveedor.MaxLength = 160
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(332, 20)
        Me.txtProveedor.TabIndex = 70
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(484, 182)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Orden Req."
        '
        'txtOR
        '
        Me.txtOR.Location = New System.Drawing.Point(574, 178)
        Me.txtOR.Name = "txtOR"
        Me.txtOR.Size = New System.Drawing.Size(85, 20)
        Me.txtOR.TabIndex = 72
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(484, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(574, 120)
        Me.cboMoneda.MaxLength = 10
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(85, 21)
        Me.cboMoneda.TabIndex = 76
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(484, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "Orden Compra"
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(574, 207)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(85, 20)
        Me.txtOC.TabIndex = 77
        '
        'chkAfectaKardex
        '
        Me.chkAfectaKardex.AutoSize = True
        Me.chkAfectaKardex.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAfectaKardex.Checked = True
        Me.chkAfectaKardex.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAfectaKardex.Location = New System.Drawing.Point(484, 151)
        Me.chkAfectaKardex.Name = "chkAfectaKardex"
        Me.chkAfectaKardex.Size = New System.Drawing.Size(105, 17)
        Me.chkAfectaKardex.TabIndex = 79
        Me.chkAfectaKardex.Text = "Afecta Kardex    "
        Me.chkAfectaKardex.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkAfectaKardex.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(721, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Salida Diesel"
        '
        'txtSC
        '
        Me.txtSC.Location = New System.Drawing.Point(805, 207)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.Size = New System.Drawing.Size(101, 20)
        Me.txtSC.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(721, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "IGV."
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(90, 91)
        Me.cboTipoDocumento.MaxLength = 45
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(352, 21)
        Me.cboTipoDocumento.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Documento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(721, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Tipo Cambio"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'txtIGV
        '
        Me.txtIGV.Location = New System.Drawing.Point(805, 120)
        Me.txtIGV.Name = "txtIGV"
        Me.txtIGV.Size = New System.Drawing.Size(51, 20)
        Me.txtIGV.TabIndex = 91
        Me.txtIGV.Text = "0"
        '
        'numTipoCambio
        '
        Me.numTipoCambio.DecimalPlaces = 3
        Me.numTipoCambio.Location = New System.Drawing.Point(805, 149)
        Me.numTipoCambio.Name = "numTipoCambio"
        Me.numTipoCambio.Size = New System.Drawing.Size(67, 20)
        Me.numTipoCambio.TabIndex = 92
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(721, 182)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 94
        Me.Label15.Text = "Transformacion"
        '
        'txtTFO
        '
        Me.txtTFO.Location = New System.Drawing.Point(805, 178)
        Me.txtTFO.MaxLength = 160
        Me.txtTFO.Name = "txtTFO"
        Me.txtTFO.Size = New System.Drawing.Size(101, 20)
        Me.txtTFO.TabIndex = 93
        '
        'txtNroServ
        '
        Me.txtNroServ.Location = New System.Drawing.Point(289, 149)
        Me.txtNroServ.MaxLength = 25
        Me.txtNroServ.Name = "txtNroServ"
        Me.txtNroServ.Size = New System.Drawing.Size(153, 20)
        Me.txtNroServ.TabIndex = 96
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(215, 153)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Nro.Servicio"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(854, 524)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 109
        Me.Label17.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Location = New System.Drawing.Point(890, 520)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(85, 20)
        Me.txtTotal.TabIndex = 108
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(703, 524)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 107
        Me.Label18.Text = "IGV"
        '
        'txtTotalIgv
        '
        Me.txtTotalIgv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalIgv.BackColor = System.Drawing.Color.White
        Me.txtTotalIgv.Location = New System.Drawing.Point(734, 520)
        Me.txtTotalIgv.Name = "txtTotalIgv"
        Me.txtTotalIgv.Size = New System.Drawing.Size(85, 20)
        Me.txtTotalIgv.TabIndex = 106
        Me.txtTotalIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(527, 524)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Sub Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BackColor = System.Drawing.Color.White
        Me.txtSubTotal.Location = New System.Drawing.Point(587, 520)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(85, 20)
        Me.txtSubTotal.TabIndex = 104
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHecho
        '
        Me.lblHecho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHecho.AutoSize = True
        Me.lblHecho.Location = New System.Drawing.Point(13, 510)
        Me.lblHecho.Name = "lblHecho"
        Me.lblHecho.Size = New System.Drawing.Size(0, 13)
        Me.lblHecho.TabIndex = 110
        '
        'cboTipoDocumentoREF
        '
        Me.cboTipoDocumentoREF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumentoREF.FormattingEnabled = True
        Me.cboTipoDocumentoREF.Location = New System.Drawing.Point(104, 178)
        Me.cboTipoDocumentoREF.MaxLength = 45
        Me.cboTipoDocumentoREF.Name = "cboTipoDocumentoREF"
        Me.cboTipoDocumentoREF.Size = New System.Drawing.Size(339, 21)
        Me.cboTipoDocumentoREF.TabIndex = 116
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 182)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Documento Ref."
        '
        'txtNumeroREF
        '
        Me.txtNumeroREF.Location = New System.Drawing.Point(289, 207)
        Me.txtNumeroREF.MaxLength = 10
        Me.txtNumeroREF.Name = "txtNumeroREF"
        Me.txtNumeroREF.Size = New System.Drawing.Size(154, 20)
        Me.txtNumeroREF.TabIndex = 114
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(216, 211)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 113
        Me.Label20.Text = "Numero Ref."
        '
        'txtSerieREF
        '
        Me.txtSerieREF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieREF.Location = New System.Drawing.Point(91, 207)
        Me.txtSerieREF.MaxLength = 4
        Me.txtSerieREF.Name = "txtSerieREF"
        Me.txtSerieREF.Size = New System.Drawing.Size(89, 20)
        Me.txtSerieREF.TabIndex = 112
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 211)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "Serie Ref."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DMD_Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 72
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cod.Articulo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 89
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Stock"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 74
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "UM"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 49
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Prec.Unit."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 79
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Dscto.(%)"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 77
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "SubTotal"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 75
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "IGV"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 50
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 56
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Glosa"
        Me.DataGridViewTextBoxColumn11.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 59
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Almacen"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 73
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "ORD_ID"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 73
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "OCD_ID"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 72
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Ref.Dev."
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 104
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "TRD_ID"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 72
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Almacen Destino"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 103
        '
        'DMD_Id
        '
        Me.DMD_Id.HeaderText = "DMD_Id"
        Me.DMD_Id.Name = "DMD_Id"
        Me.DMD_Id.Visible = False
        Me.DMD_Id.Width = 72
        '
        'ART_Id
        '
        Me.ART_Id.HeaderText = "Cod.Articulo"
        Me.ART_Id.Name = "ART_Id"
        Me.ART_Id.Width = 89
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 60
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 74
        '
        'UM
        '
        Me.UM.HeaderText = "UM"
        Me.UM.Name = "UM"
        Me.UM.ReadOnly = True
        Me.UM.Width = 49
        '
        'PU
        '
        Me.PU.HeaderText = "Prec.Unit."
        Me.PU.Name = "PU"
        Me.PU.Width = 79
        '
        'Descuento
        '
        Me.Descuento.HeaderText = "Dscto.(%)"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Width = 77
        '
        'SubTotal
        '
        Me.SubTotal.HeaderText = "SubTotal"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.Width = 75
        '
        'IGV
        '
        Me.IGV.HeaderText = "IGV"
        Me.IGV.Name = "IGV"
        Me.IGV.Width = 50
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 56
        '
        'Glosa
        '
        Me.Glosa.HeaderText = "Glosa"
        Me.Glosa.MaxInputLength = 255
        Me.Glosa.Name = "Glosa"
        Me.Glosa.Width = 59
        '
        'ALM_ID
        '
        Me.ALM_ID.HeaderText = "Almacen"
        Me.ALM_ID.Name = "ALM_ID"
        Me.ALM_ID.Width = 73
        '
        'ORD_ID
        '
        Me.ORD_ID.HeaderText = "ORD_ID"
        Me.ORD_ID.Name = "ORD_ID"
        Me.ORD_ID.Visible = False
        Me.ORD_ID.Width = 73
        '
        'OCD_ID
        '
        Me.OCD_ID.HeaderText = "OCD_ID"
        Me.OCD_ID.Name = "OCD_ID"
        Me.OCD_ID.Visible = False
        Me.OCD_ID.Width = 72
        '
        'DMD_ID_REF
        '
        Me.DMD_ID_REF.HeaderText = "Ref.:Dev./Fac."
        Me.DMD_ID_REF.Name = "DMD_ID_REF"
        Me.DMD_ID_REF.Width = 104
        '
        'TRD_ID
        '
        Me.TRD_ID.HeaderText = "TRD_ID"
        Me.TRD_ID.Name = "TRD_ID"
        Me.TRD_ID.Visible = False
        Me.TRD_ID.Width = 72
        '
        'ALM_ID_DESTINO
        '
        Me.ALM_ID_DESTINO.HeaderText = "Almacen Destino"
        Me.ALM_ID_DESTINO.Name = "ALM_ID_DESTINO"
        Me.ALM_ID_DESTINO.ReadOnly = True
        Me.ALM_ID_DESTINO.Width = 103
        '
        'frmDocuMovimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1035, 549)
        Me.Controls.Add(Me.cboTipoDocumentoREF)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNumeroREF)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtSerieREF)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblHecho)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtTotalIgv)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.txtNroServ)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTFO)
        Me.Controls.Add(Me.numTipoCambio)
        Me.Controls.Add(Me.txtIGV)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboTipoDocumento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSC)
        Me.Controls.Add(Me.chkAfectaKardex)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtOC)
        Me.Controls.Add(Me.cboMoneda)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtOR)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.dtpFechaDoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Name = "frmDocuMovimiento"
        Me.Text = "Documentacion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtSerie, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNumero, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaDoc, 0)
        Me.Controls.SetChildIndex(Me.txtProveedor, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtOR, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cboMoneda, 0)
        Me.Controls.SetChildIndex(Me.txtOC, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.chkAfectaKardex, 0)
        Me.Controls.SetChildIndex(Me.txtSC, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboTipoDocumento, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtIGV, 0)
        Me.Controls.SetChildIndex(Me.numTipoCambio, 0)
        Me.Controls.SetChildIndex(Me.txtTFO, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtNroServ, 0)
        Me.Controls.SetChildIndex(Me.txtSubTotal, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txtTotalIgv, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtTotal, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.lblHecho, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.txtSerieREF, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroREF, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cboTipoDocumentoREF, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDoc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOR As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents chkAfectaKardex As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtIGV As System.Windows.Forms.MaskedTextBox
    Friend WithEvents numTipoCambio As System.Windows.Forms.NumericUpDown
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTFO As System.Windows.Forms.TextBox
    Friend WithEvents txtNroServ As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
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
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIgv As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblHecho As System.Windows.Forms.Label
    Friend WithEvents DMD_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IGV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Glosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OCD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMD_ID_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comprar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ALM_ID_DESTINO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EsDevolucion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboTipoDocumentoREF As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroREF As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSerieREF As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
