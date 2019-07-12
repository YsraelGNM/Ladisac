Namespace Ladisac.Logistica.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmOrdenServicio
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
            Me.dsImpresionOrdenServicioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.cboTipoVenta = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtProveedor = New System.Windows.Forms.TextBox()
            Me.txtNroCotizacion = New System.Windows.Forms.TextBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.OSD_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PCD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ORD_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ART_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CantIngresada = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PU = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSD_OTROS1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cboMoneda = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtTipoCambio = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIGV = New System.Windows.Forms.TextBox()
            Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtEntregarEn = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.chkCerrada = New System.Windows.Forms.CheckBox()
            Me.chkConformidad = New System.Windows.Forms.CheckBox()
            Me.lblRuta = New System.Windows.Forms.Label()
            Me.lblHecho = New System.Windows.Forms.Label()
            Me.picPre = New System.Windows.Forms.PictureBox()
            Me.cmAdjPre = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.tooAdPreCargar = New System.Windows.Forms.ToolStripMenuItem()
            Me.tooAdPreDescargar = New System.Windows.Forms.ToolStripMenuItem()
            Me.tooAdPreEliminar = New System.Windows.Forms.ToolStripMenuItem()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.btnEnviarCorreo = New System.Windows.Forms.Button()
            Me.cboImportancia = New System.Windows.Forms.ComboBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.numAnticipo = New System.Windows.Forms.NumericUpDown()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtTotalIgv = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtSubTotal = New System.Windows.Forms.TextBox()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.dgvCuota = New System.Windows.Forms.DataGridView()
            Me.OSC_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSC_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSC_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSC_FECHA_VENCIMIENTO = New ColumnaCalendario()
            Me.OSC_MONTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.dgvDetalleGrupo = New System.Windows.Forms.DataGridView()
            Me.PER_ID_PROVEEDOR2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSE_FECHA2 = New ColumnaCalendario()
            Me.TipoCambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTR_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ENO_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ART_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DESCRIPCION2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSD_CANTIDAD2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSD_PRECIO_UNITARIO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SUBTOTAL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IGV2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TOTAL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OSD_OBSERVACIONES2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
            Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
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
            Me.ColumnaCalendario1 = New ColumnaCalendario()
            Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.dsImpresionOrdenServicioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.picPre, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cmAdjPre.SuspendLayout()
            CType(Me.numAnticipo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.dgvCuota, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            CType(Me.dgvDetalleGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(941, 28)
            Me.lblTitle.Text = "Orden de Servicio"
            '
            'dsImpresionOrdenServicioBindingSource
            '
            Me.dsImpresionOrdenServicioBindingSource.DataMember = "ImpresionOrdenServicio"
            Me.dsImpresionOrdenServicioBindingSource.DataSource = GetType(dsImpresionOrdenServicio)
            '
            'cboTipoVenta
            '
            Me.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoVenta.FormattingEnabled = True
            Me.cboTipoVenta.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
            Me.cboTipoVenta.Location = New System.Drawing.Point(456, 93)
            Me.cboTipoVenta.Name = "cboTipoVenta"
            Me.cboTipoVenta.Size = New System.Drawing.Size(137, 21)
            Me.cboTipoVenta.TabIndex = 52
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(378, 97)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(59, 13)
            Me.Label5.TabIndex = 51
            Me.Label5.Text = "Tipo Venta"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(16, 42)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(76, 13)
            Me.Label7.TabIndex = 48
            Me.Label7.Text = "Nro.Cotizacion"
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(456, 10)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
            Me.dtpFecha.TabIndex = 47
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(378, 14)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 46
            Me.Label6.Text = "Fecha"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(16, 14)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 13)
            Me.Label2.TabIndex = 43
            Me.Label2.Text = "Código"
            '
            'txtCodigo
            '
            Me.txtCodigo.BackColor = System.Drawing.Color.White
            Me.txtCodigo.Location = New System.Drawing.Point(94, 10)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
            Me.txtCodigo.TabIndex = 42
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(16, 70)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 13)
            Me.Label1.TabIndex = 41
            Me.Label1.Text = "Proveedor"
            '
            'txtProveedor
            '
            Me.txtProveedor.Location = New System.Drawing.Point(94, 66)
            Me.txtProveedor.Name = "txtProveedor"
            Me.txtProveedor.Size = New System.Drawing.Size(272, 20)
            Me.txtProveedor.TabIndex = 40
            '
            'txtNroCotizacion
            '
            Me.txtNroCotizacion.Location = New System.Drawing.Point(94, 38)
            Me.txtNroCotizacion.Name = "txtNroCotizacion"
            Me.txtNroCotizacion.Size = New System.Drawing.Size(137, 20)
            Me.txtNroCotizacion.TabIndex = 53
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OSD_Id, Me.PCD_ID, Me.ORD_Id, Me.OTR_ID, Me.ENO_ID, Me.ART_Id, Me.OSD_DESCRIPCION, Me.Cantidad, Me.CantIngresada, Me.UM, Me.PU, Me.Descuento, Me.OSD_OTROS1, Me.SubTotal, Me.IGV, Me.Total, Me.Observacion})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDetalle.Location = New System.Drawing.Point(19, 186)
            Me.dgvDetalle.Name = "dgvDetalle"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDetalle.Size = New System.Drawing.Size(874, 190)
            Me.dgvDetalle.TabIndex = 54
            '
            'OSD_Id
            '
            Me.OSD_Id.HeaderText = "OSD_Id"
            Me.OSD_Id.Name = "OSD_Id"
            Me.OSD_Id.Visible = False
            Me.OSD_Id.Width = 70
            '
            'PCD_ID
            '
            Me.PCD_ID.HeaderText = "PCD_ID"
            Me.PCD_ID.Name = "PCD_ID"
            Me.PCD_ID.Visible = False
            Me.PCD_ID.Width = 71
            '
            'ORD_Id
            '
            Me.ORD_Id.HeaderText = "Cod.Req."
            Me.ORD_Id.Name = "ORD_Id"
            Me.ORD_Id.Width = 77
            '
            'OTR_ID
            '
            Me.OTR_ID.HeaderText = "O.T."
            Me.OTR_ID.Name = "OTR_ID"
            '
            'ENO_ID
            '
            Me.ENO_ID.HeaderText = "Entidad"
            Me.ENO_ID.Name = "ENO_ID"
            Me.ENO_ID.Visible = False
            Me.ENO_ID.Width = 110
            '
            'ART_Id
            '
            Me.ART_Id.HeaderText = "Cod.Articulo"
            Me.ART_Id.Name = "ART_Id"
            Me.ART_Id.Width = 200
            '
            'OSD_DESCRIPCION
            '
            Me.OSD_DESCRIPCION.HeaderText = "Descripcion"
            Me.OSD_DESCRIPCION.Name = "OSD_DESCRIPCION"
            Me.OSD_DESCRIPCION.Width = 200
            '
            'Cantidad
            '
            Me.Cantidad.HeaderText = "Cantidad"
            Me.Cantidad.Name = "Cantidad"
            Me.Cantidad.Width = 74
            '
            'CantIngresada
            '
            Me.CantIngresada.HeaderText = "Cant.Ingresada"
            Me.CantIngresada.Name = "CantIngresada"
            Me.CantIngresada.ReadOnly = True
            Me.CantIngresada.Width = 104
            '
            'UM
            '
            Me.UM.HeaderText = "UM"
            Me.UM.Name = "UM"
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
            Me.Descuento.Width = 77
            '
            'OSD_OTROS1
            '
            Me.OSD_OTROS1.HeaderText = "Otro1"
            Me.OSD_OTROS1.Name = "OSD_OTROS1"
            Me.OSD_OTROS1.Width = 58
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
            Me.IGV.ReadOnly = True
            Me.IGV.Width = 50
            '
            'Total
            '
            Me.Total.HeaderText = "Total"
            Me.Total.Name = "Total"
            Me.Total.Width = 56
            '
            'Observacion
            '
            Me.Observacion.HeaderText = "Observaciones"
            Me.Observacion.Name = "Observacion"
            Me.Observacion.Width = 103
            '
            'cboMoneda
            '
            Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMoneda.FormattingEnabled = True
            Me.cboMoneda.Location = New System.Drawing.Point(456, 38)
            Me.cboMoneda.Name = "cboMoneda"
            Me.cboMoneda.Size = New System.Drawing.Size(85, 21)
            Me.cboMoneda.TabIndex = 78
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(378, 42)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(46, 13)
            Me.Label10.TabIndex = 77
            Me.Label10.Text = "Moneda"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(378, 70)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(66, 13)
            Me.Label13.TabIndex = 91
            Me.Label13.Text = "Tipo Cambio"
            '
            'txtTipoCambio
            '
            Me.txtTipoCambio.Location = New System.Drawing.Point(456, 66)
            Me.txtTipoCambio.Name = "txtTipoCambio"
            Me.txtTipoCambio.Size = New System.Drawing.Size(85, 20)
            Me.txtTipoCambio.TabIndex = 90
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(600, 42)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(28, 13)
            Me.Label3.TabIndex = 89
            Me.Label3.Text = "IGV."
            '
            'txtIGV
            '
            Me.txtIGV.Location = New System.Drawing.Point(646, 38)
            Me.txtIGV.Name = "txtIGV"
            Me.txtIGV.Size = New System.Drawing.Size(85, 20)
            Me.txtIGV.TabIndex = 88
            '
            'dtpFechaEntrega
            '
            Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaEntrega.Location = New System.Drawing.Point(94, 93)
            Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
            Me.dtpFechaEntrega.Size = New System.Drawing.Size(90, 20)
            Me.dtpFechaEntrega.TabIndex = 93
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(16, 97)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(77, 13)
            Me.Label4.TabIndex = 92
            Me.Label4.Text = "Fecha Entrega"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(16, 124)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(62, 13)
            Me.Label8.TabIndex = 95
            Me.Label8.Text = "Entregar en"
            '
            'txtEntregarEn
            '
            Me.txtEntregarEn.Location = New System.Drawing.Point(94, 120)
            Me.txtEntregarEn.Name = "txtEntregarEn"
            Me.txtEntregarEn.Size = New System.Drawing.Size(272, 20)
            Me.txtEntregarEn.TabIndex = 94
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(378, 124)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(78, 13)
            Me.Label9.TabIndex = 97
            Me.Label9.Text = "Observaciones"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(456, 120)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(441, 20)
            Me.txtObservaciones.TabIndex = 96
            '
            'Error_validacion
            '
            Me.Error_validacion.ContainerControl = Me
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Location = New System.Drawing.Point(4, 56)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(925, 502)
            Me.TabControl1.TabIndex = 98
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.chkCerrada)
            Me.TabPage1.Controls.Add(Me.chkConformidad)
            Me.TabPage1.Controls.Add(Me.lblRuta)
            Me.TabPage1.Controls.Add(Me.lblHecho)
            Me.TabPage1.Controls.Add(Me.picPre)
            Me.TabPage1.Controls.Add(Me.Label18)
            Me.TabPage1.Controls.Add(Me.cboTipoDocumento)
            Me.TabPage1.Controls.Add(Me.Label17)
            Me.TabPage1.Controls.Add(Me.btnEnviarCorreo)
            Me.TabPage1.Controls.Add(Me.cboImportancia)
            Me.TabPage1.Controls.Add(Me.Label16)
            Me.TabPage1.Controls.Add(Me.numAnticipo)
            Me.TabPage1.Controls.Add(Me.Label15)
            Me.TabPage1.Controls.Add(Me.Label14)
            Me.TabPage1.Controls.Add(Me.txtTotal)
            Me.TabPage1.Controls.Add(Me.Label12)
            Me.TabPage1.Controls.Add(Me.txtTotalIgv)
            Me.TabPage1.Controls.Add(Me.Label11)
            Me.TabPage1.Controls.Add(Me.txtSubTotal)
            Me.TabPage1.Controls.Add(Me.Label2)
            Me.TabPage1.Controls.Add(Me.Label9)
            Me.TabPage1.Controls.Add(Me.txtProveedor)
            Me.TabPage1.Controls.Add(Me.txtObservaciones)
            Me.TabPage1.Controls.Add(Me.Label1)
            Me.TabPage1.Controls.Add(Me.Label8)
            Me.TabPage1.Controls.Add(Me.txtCodigo)
            Me.TabPage1.Controls.Add(Me.txtEntregarEn)
            Me.TabPage1.Controls.Add(Me.Label6)
            Me.TabPage1.Controls.Add(Me.dtpFechaEntrega)
            Me.TabPage1.Controls.Add(Me.dtpFecha)
            Me.TabPage1.Controls.Add(Me.Label4)
            Me.TabPage1.Controls.Add(Me.Label7)
            Me.TabPage1.Controls.Add(Me.Label13)
            Me.TabPage1.Controls.Add(Me.Label5)
            Me.TabPage1.Controls.Add(Me.txtTipoCambio)
            Me.TabPage1.Controls.Add(Me.cboTipoVenta)
            Me.TabPage1.Controls.Add(Me.Label3)
            Me.TabPage1.Controls.Add(Me.txtNroCotizacion)
            Me.TabPage1.Controls.Add(Me.txtIGV)
            Me.TabPage1.Controls.Add(Me.dgvDetalle)
            Me.TabPage1.Controls.Add(Me.cboMoneda)
            Me.TabPage1.Controls.Add(Me.Label10)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(917, 476)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Registro"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'chkCerrada
            '
            Me.chkCerrada.AutoSize = True
            Me.chkCerrada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCerrada.Location = New System.Drawing.Point(603, 151)
            Me.chkCerrada.Name = "chkCerrada"
            Me.chkCerrada.Size = New System.Drawing.Size(63, 17)
            Me.chkCerrada.TabIndex = 142
            Me.chkCerrada.Text = "Cerrada"
            Me.chkCerrada.UseVisualStyleBackColor = True
            '
            'chkConformidad
            '
            Me.chkConformidad.AutoSize = True
            Me.chkConformidad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkConformidad.Location = New System.Drawing.Point(603, 96)
            Me.chkConformidad.Name = "chkConformidad"
            Me.chkConformidad.Size = New System.Drawing.Size(85, 17)
            Me.chkConformidad.TabIndex = 141
            Me.chkConformidad.Text = "Conformidad"
            Me.chkConformidad.UseVisualStyleBackColor = True
            '
            'lblRuta
            '
            Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblRuta.Location = New System.Drawing.Point(16, 386)
            Me.lblRuta.Name = "lblRuta"
            Me.lblRuta.Size = New System.Drawing.Size(715, 40)
            Me.lblRuta.TabIndex = 140
            '
            'lblHecho
            '
            Me.lblHecho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblHecho.AutoSize = True
            Me.lblHecho.Location = New System.Drawing.Point(16, 452)
            Me.lblHecho.Name = "lblHecho"
            Me.lblHecho.Size = New System.Drawing.Size(0, 13)
            Me.lblHecho.TabIndex = 139
            '
            'picPre
            '
            Me.picPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picPre.ContextMenuStrip = Me.cmAdjPre
            Me.picPre.Location = New System.Drawing.Point(456, 153)
            Me.picPre.Name = "picPre"
            Me.picPre.Size = New System.Drawing.Size(69, 13)
            Me.picPre.TabIndex = 138
            Me.picPre.TabStop = False
            '
            'cmAdjPre
            '
            Me.cmAdjPre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooAdPreCargar, Me.tooAdPreDescargar, Me.tooAdPreEliminar})
            Me.cmAdjPre.Name = "cmUsc"
            Me.cmAdjPre.Size = New System.Drawing.Size(241, 70)
            '
            'tooAdPreCargar
            '
            Me.tooAdPreCargar.Name = "tooAdPreCargar"
            Me.tooAdPreCargar.Size = New System.Drawing.Size(240, 22)
            Me.tooAdPreCargar.Text = "Cargar Adjunto Presupuesto"
            '
            'tooAdPreDescargar
            '
            Me.tooAdPreDescargar.Name = "tooAdPreDescargar"
            Me.tooAdPreDescargar.Size = New System.Drawing.Size(240, 22)
            Me.tooAdPreDescargar.Text = "Descargar Adjunto Presupuesto"
            '
            'tooAdPreEliminar
            '
            Me.tooAdPreEliminar.Name = "tooAdPreEliminar"
            Me.tooAdPreEliminar.Size = New System.Drawing.Size(240, 22)
            Me.tooAdPreEliminar.Text = "Eliminar Adjunto Presupuesto"
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(378, 153)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(43, 13)
            Me.Label18.TabIndex = 137
            Me.Label18.Text = "Adjunto"
            '
            'cboTipoDocumento
            '
            Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoDocumento.FormattingEnabled = True
            Me.cboTipoDocumento.Location = New System.Drawing.Point(94, 149)
            Me.cboTipoDocumento.MaxLength = 45
            Me.cboTipoDocumento.Name = "cboTipoDocumento"
            Me.cboTipoDocumento.Size = New System.Drawing.Size(272, 21)
            Me.cboTipoDocumento.TabIndex = 121
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(16, 153)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(62, 13)
            Me.Label17.TabIndex = 120
            Me.Label17.Text = "Documento"
            '
            'btnEnviarCorreo
            '
            Me.btnEnviarCorreo.Location = New System.Drawing.Point(806, 10)
            Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
            Me.btnEnviarCorreo.Size = New System.Drawing.Size(88, 49)
            Me.btnEnviarCorreo.TabIndex = 119
            Me.btnEnviarCorreo.Text = "Enviar Correo"
            Me.btnEnviarCorreo.UseVisualStyleBackColor = True
            '
            'cboImportancia
            '
            Me.cboImportancia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboImportancia.FormattingEnabled = True
            Me.cboImportancia.Items.AddRange(New Object() {"A", "B"})
            Me.cboImportancia.Location = New System.Drawing.Point(806, 66)
            Me.cboImportancia.Name = "cboImportancia"
            Me.cboImportancia.Size = New System.Drawing.Size(88, 21)
            Me.cboImportancia.TabIndex = 118
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(741, 70)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(62, 13)
            Me.Label16.TabIndex = 117
            Me.Label16.Text = "Importancia"
            '
            'numAnticipo
            '
            Me.numAnticipo.DecimalPlaces = 2
            Me.numAnticipo.Location = New System.Drawing.Point(646, 66)
            Me.numAnticipo.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
            Me.numAnticipo.Name = "numAnticipo"
            Me.numAnticipo.Size = New System.Drawing.Size(85, 20)
            Me.numAnticipo.TabIndex = 116
            Me.numAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(600, 70)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(45, 13)
            Me.Label15.TabIndex = 115
            Me.Label15.Text = "Anticipo"
            '
            'Label14
            '
            Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(737, 452)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(31, 13)
            Me.Label14.TabIndex = 103
            Me.Label14.Text = "Total"
            '
            'txtTotal
            '
            Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTotal.Location = New System.Drawing.Point(809, 448)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Size = New System.Drawing.Size(85, 20)
            Me.txtTotal.TabIndex = 102
            Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label12
            '
            Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(737, 426)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(25, 13)
            Me.Label12.TabIndex = 101
            Me.Label12.Text = "IGV"
            '
            'txtTotalIgv
            '
            Me.txtTotalIgv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTotalIgv.Location = New System.Drawing.Point(809, 422)
            Me.txtTotalIgv.Name = "txtTotalIgv"
            Me.txtTotalIgv.Size = New System.Drawing.Size(85, 20)
            Me.txtTotalIgv.TabIndex = 100
            Me.txtTotalIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label11
            '
            Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(737, 400)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(53, 13)
            Me.Label11.TabIndex = 99
            Me.Label11.Text = "Sub Total"
            '
            'txtSubTotal
            '
            Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSubTotal.Location = New System.Drawing.Point(809, 396)
            Me.txtSubTotal.Name = "txtSubTotal"
            Me.txtSubTotal.Size = New System.Drawing.Size(85, 20)
            Me.txtSubTotal.TabIndex = 98
            Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.ReportViewer1)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(917, 476)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Impresion"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'ReportViewer1
            '
            Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            ReportDataSource1.Name = "dsImpresionOrdenServicio"
            ReportDataSource1.Value = Me.dsImpresionOrdenServicioBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListadoOrdenServicio.rdlc"
            Me.ReportViewer1.Location = New System.Drawing.Point(3, 3)
            Me.ReportViewer1.Name = "ReportViewer1"
            Me.ReportViewer1.Size = New System.Drawing.Size(911, 470)
            Me.ReportViewer1.TabIndex = 0
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.dgvCuota)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(917, 476)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Cuotas"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'dgvCuota
            '
            Me.dgvCuota.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvCuota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvCuota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCuota.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OSC_ID, Me.OSC_NUMERO, Me.OSC_DESCRIPCION, Me.OSC_FECHA_VENCIMIENTO, Me.OSC_MONTO})
            Me.dgvCuota.Location = New System.Drawing.Point(14, 18)
            Me.dgvCuota.Name = "dgvCuota"
            Me.dgvCuota.Size = New System.Drawing.Size(887, 433)
            Me.dgvCuota.TabIndex = 1
            '
            'OSC_ID
            '
            Me.OSC_ID.HeaderText = "OSC_ID"
            Me.OSC_ID.Name = "OSC_ID"
            Me.OSC_ID.Visible = False
            '
            'OSC_NUMERO
            '
            Me.OSC_NUMERO.HeaderText = "NUMERO"
            Me.OSC_NUMERO.Name = "OSC_NUMERO"
            '
            'OSC_DESCRIPCION
            '
            Me.OSC_DESCRIPCION.HeaderText = "DESCRIPCION"
            Me.OSC_DESCRIPCION.Name = "OSC_DESCRIPCION"
            '
            'OSC_FECHA_VENCIMIENTO
            '
            Me.OSC_FECHA_VENCIMIENTO.HeaderText = "FECHA VENCIMIENTO"
            Me.OSC_FECHA_VENCIMIENTO.Name = "OSC_FECHA_VENCIMIENTO"
            '
            'OSC_MONTO
            '
            Me.OSC_MONTO.HeaderText = "MONTO"
            Me.OSC_MONTO.Name = "OSC_MONTO"
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.dgvDetalleGrupo)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Size = New System.Drawing.Size(917, 476)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Grupo"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'dgvDetalleGrupo
            '
            Me.dgvDetalleGrupo.AllowUserToAddRows = False
            Me.dgvDetalleGrupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalleGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvDetalleGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalleGrupo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PER_ID_PROVEEDOR2, Me.OSE_FECHA2, Me.TipoCambio, Me.OTR_ID2, Me.ENO_ID2, Me.ART_ID2, Me.DESCRIPCION2, Me.OSD_CANTIDAD2, Me.OSD_PRECIO_UNITARIO2, Me.SUBTOTAL2, Me.IGV2, Me.TOTAL2, Me.OSD_OBSERVACIONES2})
            Me.dgvDetalleGrupo.Location = New System.Drawing.Point(4, 3)
            Me.dgvDetalleGrupo.Name = "dgvDetalleGrupo"
            Me.dgvDetalleGrupo.Size = New System.Drawing.Size(910, 470)
            Me.dgvDetalleGrupo.TabIndex = 0
            '
            'PER_ID_PROVEEDOR2
            '
            Me.PER_ID_PROVEEDOR2.HeaderText = "Proveedor"
            Me.PER_ID_PROVEEDOR2.Name = "PER_ID_PROVEEDOR2"
            '
            'OSE_FECHA2
            '
            Me.OSE_FECHA2.HeaderText = "Fecha"
            Me.OSE_FECHA2.Name = "OSE_FECHA2"
            '
            'TipoCambio
            '
            Me.TipoCambio.HeaderText = "Tipo Cambio"
            Me.TipoCambio.Name = "TipoCambio"
            Me.TipoCambio.ReadOnly = True
            '
            'OTR_ID2
            '
            Me.OTR_ID2.HeaderText = "O.T."
            Me.OTR_ID2.Name = "OTR_ID2"
            '
            'ENO_ID2
            '
            Me.ENO_ID2.HeaderText = "Entidad"
            Me.ENO_ID2.Name = "ENO_ID2"
            '
            'ART_ID2
            '
            Me.ART_ID2.HeaderText = "Articulo"
            Me.ART_ID2.Name = "ART_ID2"
            '
            'DESCRIPCION2
            '
            Me.DESCRIPCION2.HeaderText = "Descripcion"
            Me.DESCRIPCION2.Name = "DESCRIPCION2"
            '
            'OSD_CANTIDAD2
            '
            Me.OSD_CANTIDAD2.HeaderText = "Cantidad"
            Me.OSD_CANTIDAD2.Name = "OSD_CANTIDAD2"
            '
            'OSD_PRECIO_UNITARIO2
            '
            Me.OSD_PRECIO_UNITARIO2.HeaderText = "P.U."
            Me.OSD_PRECIO_UNITARIO2.Name = "OSD_PRECIO_UNITARIO2"
            Me.OSD_PRECIO_UNITARIO2.ReadOnly = True
            '
            'SUBTOTAL2
            '
            Me.SUBTOTAL2.HeaderText = "Sub Total"
            Me.SUBTOTAL2.Name = "SUBTOTAL2"
            Me.SUBTOTAL2.ReadOnly = True
            '
            'IGV2
            '
            Me.IGV2.HeaderText = "Igv"
            Me.IGV2.Name = "IGV2"
            Me.IGV2.ReadOnly = True
            '
            'TOTAL2
            '
            Me.TOTAL2.HeaderText = "TOTAL"
            Me.TOTAL2.Name = "TOTAL2"
            '
            'OSD_OBSERVACIONES2
            '
            Me.OSD_OBSERVACIONES2.HeaderText = "Observacion"
            Me.OSD_OBSERVACIONES2.Name = "OSD_OBSERVACIONES2"
            '
            'sfdImagen
            '
            Me.sfdImagen.Filter = "All files (*.*)|*.*"
            '
            'ofdImagen
            '
            Me.ofdImagen.Filter = "All files (*.*)|*.*"
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "OSD_Id"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Visible = False
            Me.DataGridViewTextBoxColumn1.Width = 70
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Cod.Req."
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Visible = False
            Me.DataGridViewTextBoxColumn2.Width = 77
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Cod.Articulo"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            Me.DataGridViewTextBoxColumn3.Width = 89
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Width = 74
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Cant.Ingresada"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            Me.DataGridViewTextBoxColumn5.Visible = False
            Me.DataGridViewTextBoxColumn5.Width = 104
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "UM"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Width = 49
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "Prec.Unit."
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Width = 79
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Dscto.(%)"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Width = 77
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.HeaderText = "SubTotal"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 75
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.HeaderText = "IGV"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Width = 50
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.HeaderText = "Total"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Width = 56
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.ReadOnly = True
            Me.DataGridViewTextBoxColumn12.Width = 103
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            Me.DataGridViewTextBoxColumn13.Width = 103
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            Me.DataGridViewTextBoxColumn14.ReadOnly = True
            Me.DataGridViewTextBoxColumn14.Width = 103
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            Me.DataGridViewTextBoxColumn15.ReadOnly = True
            Me.DataGridViewTextBoxColumn15.Width = 103
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            Me.DataGridViewTextBoxColumn16.Width = 103
            '
            'DataGridViewTextBoxColumn17
            '
            Me.DataGridViewTextBoxColumn17.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
            Me.DataGridViewTextBoxColumn17.Width = 103
            '
            'DataGridViewTextBoxColumn18
            '
            Me.DataGridViewTextBoxColumn18.HeaderText = "OSC_ID"
            Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
            Me.DataGridViewTextBoxColumn18.Visible = False
            '
            'DataGridViewTextBoxColumn19
            '
            Me.DataGridViewTextBoxColumn19.HeaderText = "NUMERO"
            Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
            Me.DataGridViewTextBoxColumn19.Width = 211
            '
            'DataGridViewTextBoxColumn20
            '
            Me.DataGridViewTextBoxColumn20.HeaderText = "DESCRIPCION"
            Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
            Me.DataGridViewTextBoxColumn20.Width = 211
            '
            'ColumnaCalendario1
            '
            Me.ColumnaCalendario1.HeaderText = "FECHA VENCIMIENTO"
            Me.ColumnaCalendario1.Name = "ColumnaCalendario1"
            Me.ColumnaCalendario1.Width = 211
            '
            'DataGridViewTextBoxColumn21
            '
            Me.DataGridViewTextBoxColumn21.HeaderText = "MONTO"
            Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
            Me.DataGridViewTextBoxColumn21.Width = 211
            '
            'frmOrdenServicio
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(941, 570)
            Me.Controls.Add(Me.TabControl1)
            Me.Name = "frmOrdenServicio"
            Me.Text = "Orden de Servicio"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.TabControl1, 0)
            CType(Me.dsImpresionOrdenServicioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            CType(Me.picPre, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cmAdjPre.ResumeLayout(False)
            CType(Me.numAnticipo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage3.ResumeLayout(False)
            CType(Me.dgvCuota, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            CType(Me.dgvDetalleGrupo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents cboTipoVenta As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
        Friend WithEvents txtNroCotizacion As System.Windows.Forms.TextBox
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtIGV As System.Windows.Forms.TextBox
        Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtEntregarEn As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
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
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtTotalIgv As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents numAnticipo As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cboImportancia As System.Windows.Forms.ComboBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnEnviarCorreo As System.Windows.Forms.Button
        Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents cmAdjPre As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents tooAdPreCargar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tooAdPreDescargar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tooAdPreEliminar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sfdImagen As System.Windows.Forms.SaveFileDialog
        Friend WithEvents ofdImagen As System.Windows.Forms.OpenFileDialog
        Friend WithEvents picPre As System.Windows.Forms.PictureBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents lblHecho As System.Windows.Forms.Label
        Friend WithEvents lblRuta As System.Windows.Forms.Label
        Friend WithEvents chkConformidad As System.Windows.Forms.CheckBox
        Friend WithEvents chkCerrada As System.Windows.Forms.CheckBox
        Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents dgvCuota As System.Windows.Forms.DataGridView
        Friend WithEvents OSC_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSC_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSC_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSC_FECHA_VENCIMIENTO As ColumnaCalendario
        Friend WithEvents OSC_MONTO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
        Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ColumnaCalendario1 As ColumnaCalendario
        Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dsImpresionOrdenServicioBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents OSD_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PCD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ORD_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ART_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CantIngresada As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PU As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSD_OTROS1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IGV As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents dgvDetalleGrupo As System.Windows.Forms.DataGridView
        Friend WithEvents PER_ID_PROVEEDOR2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSE_FECHA2 As ColumnaCalendario
        Friend WithEvents TipoCambio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTR_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ENO_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ART_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DESCRIPCION2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSD_CANTIDAD2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSD_PRECIO_UNITARIO2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SUBTOTAL2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IGV2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TOTAL2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OSD_OBSERVACIONES2 As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class


End Namespace

