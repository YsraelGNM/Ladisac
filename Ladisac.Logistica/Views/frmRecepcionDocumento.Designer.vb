<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecepcionDocumento
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsListaReporteSeguimientoDocumentoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.dgvRecibido = New System.Windows.Forms.DataGridView()
        Me.OCO_ID_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OSE_ID_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTD_ID_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_ID_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_SERIE_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_NUMERO_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PER_ID_PROVEEDOR_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_CONCEPTO_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_RECIBIDO_1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnRecibido = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaCalendario1 = New ColumnaCalendario()
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.RDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OCO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OSE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_FECHA_DOCUMENTO = New ColumnaCalendario()
        Me.PER_ID_PROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RDO_CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PER_ID_RECIBIDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dsListaReporteSeguimientoDocumentoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecibido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1083, 28)
        Me.lblTitle.Text = "Recepcion de Documentos"
        '
        'dsListaReporteSeguimientoDocumentoBindingSource
        '
        Me.dsListaReporteSeguimientoDocumentoBindingSource.DataMember = "ListaReporteSeguimientoDocumento"
        Me.dsListaReporteSeguimientoDocumentoBindingSource.DataSource = GetType(dsListaReporteSeguimientoDocumento)
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RDO_ID, Me.OCO_ID, Me.OSE_ID, Me.DTD_ID, Me.RDO_SERIE, Me.RDO_NUMERO, Me.RDO_FECHA_DOCUMENTO, Me.PER_ID_PROVEEDOR, Me.RDO_CONCEPTO, Me.PER_ID_RECIBIDO})
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(1047, 193)
        Me.dgvDetalle.TabIndex = 2
        '
        'dgvRecibido
        '
        Me.dgvRecibido.AllowUserToAddRows = False
        Me.dgvRecibido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecibido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecibido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecibido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OCO_ID_1, Me.OSE_ID_1, Me.DTD_ID_1, Me.RDO_ID_1, Me.RDO_SERIE_1, Me.RDO_NUMERO_1, Me.PER_ID_PROVEEDOR_1, Me.RDO_CONCEPTO_1, Me.RDO_RECIBIDO_1})
        Me.dgvRecibido.Location = New System.Drawing.Point(0, 0)
        Me.dgvRecibido.Name = "dgvRecibido"
        Me.dgvRecibido.Size = New System.Drawing.Size(1047, 159)
        Me.dgvRecibido.TabIndex = 3
        '
        'OCO_ID_1
        '
        Me.OCO_ID_1.FillWeight = 50.0!
        Me.OCO_ID_1.HeaderText = "OCO_ID"
        Me.OCO_ID_1.Name = "OCO_ID_1"
        '
        'OSE_ID_1
        '
        Me.OSE_ID_1.FillWeight = 50.0!
        Me.OSE_ID_1.HeaderText = "OSE_ID"
        Me.OSE_ID_1.Name = "OSE_ID_1"
        '
        'DTD_ID_1
        '
        Me.DTD_ID_1.HeaderText = "DOCUMENTO"
        Me.DTD_ID_1.Name = "DTD_ID_1"
        '
        'RDO_ID_1
        '
        Me.RDO_ID_1.HeaderText = "RDO_ID_1"
        Me.RDO_ID_1.Name = "RDO_ID_1"
        Me.RDO_ID_1.Visible = False
        '
        'RDO_SERIE_1
        '
        Me.RDO_SERIE_1.HeaderText = "SERIE"
        Me.RDO_SERIE_1.Name = "RDO_SERIE_1"
        '
        'RDO_NUMERO_1
        '
        Me.RDO_NUMERO_1.HeaderText = "NUMERO"
        Me.RDO_NUMERO_1.Name = "RDO_NUMERO_1"
        '
        'PER_ID_PROVEEDOR_1
        '
        Me.PER_ID_PROVEEDOR_1.HeaderText = "PROVEEDOR"
        Me.PER_ID_PROVEEDOR_1.Name = "PER_ID_PROVEEDOR_1"
        '
        'RDO_CONCEPTO_1
        '
        Me.RDO_CONCEPTO_1.HeaderText = "CONCEPTO"
        Me.RDO_CONCEPTO_1.Name = "RDO_CONCEPTO_1"
        '
        'RDO_RECIBIDO_1
        '
        Me.RDO_RECIBIDO_1.HeaderText = "RECIBIDO"
        Me.RDO_RECIBIDO_1.Name = "RDO_RECIBIDO_1"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'btnRecibido
        '
        Me.btnRecibido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecibido.Location = New System.Drawing.Point(978, 401)
        Me.btnRecibido.Name = "btnRecibido"
        Me.btnRecibido.Size = New System.Drawing.Size(75, 23)
        Me.btnRecibido.TabIndex = 4
        Me.btnRecibido.Text = "Recibido"
        Me.btnRecibido.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 6)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvDetalle)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvRecibido)
        Me.SplitContainer1.Size = New System.Drawing.Size(1047, 389)
        Me.SplitContainer1.SplitterDistance = 193
        Me.SplitContainer1.SplitterWidth = 15
        Me.SplitContainer1.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "RDO_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "DOCUMENTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 133
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "SERIE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 132
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "NUMERO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 133
        '
        'ColumnaCalendario1
        '
        Me.ColumnaCalendario1.HeaderText = "FECHA DOCUMENTO"
        Me.ColumnaCalendario1.Name = "ColumnaCalendario1"
        Me.ColumnaCalendario1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaCalendario1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnaCalendario1.Width = 133
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "FECHA DOCUMENTO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 133
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "PROVEEDOR"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 132
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 133
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "ENVIADO A"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 155
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "DOCUMENTO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "RDO_ID_1"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 155
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "SERIE"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 154
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "NUMERO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 155
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "PROVEEDOR"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 155
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 66)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1067, 456)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Controls.Add(Me.btnRecibido)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1059, 430)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Recepcion de Documentos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer1)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtNumero)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtSerie)
        Me.TabPage2.Controls.Add(Me.btnVisualizar)
        Me.TabPage2.Controls.Add(Me.dtpFechaFin)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.dtpFechaIni)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtProveedor)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1059, 430)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reporte"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaReporteSeguimientoDocumento"
        ReportDataSource1.Value = Me.dsListaReporteSeguimientoDocumentoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaReporteSeguimientoDocumento.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(18, 79)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1035, 325)
        Me.ReportViewer1.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(363, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.Location = New System.Drawing.Point(433, 16)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(148, 20)
        Me.txtNumero.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.Location = New System.Drawing.Point(260, 16)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(58, 20)
        Me.txtSerie.TabIndex = 70
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(590, 41)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(101, 23)
        Me.btnVisualizar.TabIndex = 69
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(83, 42)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaFin.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(83, 16)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaIni.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        Me.txtProveedor.Location = New System.Drawing.Point(260, 42)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(321, 20)
        Me.txtProveedor.TabIndex = 60
        '
        'RDO_ID
        '
        Me.RDO_ID.HeaderText = "RDO_ID"
        Me.RDO_ID.Name = "RDO_ID"
        Me.RDO_ID.Visible = False
        '
        'OCO_ID
        '
        Me.OCO_ID.FillWeight = 50.0!
        Me.OCO_ID.HeaderText = "OCO_ID"
        Me.OCO_ID.Name = "OCO_ID"
        '
        'OSE_ID
        '
        Me.OSE_ID.FillWeight = 50.0!
        Me.OSE_ID.HeaderText = "OSE_ID"
        Me.OSE_ID.Name = "OSE_ID"
        '
        'DTD_ID
        '
        Me.DTD_ID.HeaderText = "DOCUMENTO"
        Me.DTD_ID.Name = "DTD_ID"
        '
        'RDO_SERIE
        '
        Me.RDO_SERIE.HeaderText = "SERIE"
        Me.RDO_SERIE.Name = "RDO_SERIE"
        '
        'RDO_NUMERO
        '
        Me.RDO_NUMERO.HeaderText = "NUMERO"
        Me.RDO_NUMERO.Name = "RDO_NUMERO"
        '
        'RDO_FECHA_DOCUMENTO
        '
        Me.RDO_FECHA_DOCUMENTO.HeaderText = "FECHA DOCUMENTO"
        Me.RDO_FECHA_DOCUMENTO.Name = "RDO_FECHA_DOCUMENTO"
        Me.RDO_FECHA_DOCUMENTO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RDO_FECHA_DOCUMENTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PER_ID_PROVEEDOR
        '
        Me.PER_ID_PROVEEDOR.HeaderText = "PROVEEDOR/TRABAJADOR"
        Me.PER_ID_PROVEEDOR.Name = "PER_ID_PROVEEDOR"
        '
        'RDO_CONCEPTO
        '
        Me.RDO_CONCEPTO.HeaderText = "CONCEPTO"
        Me.RDO_CONCEPTO.Name = "RDO_CONCEPTO"
        '
        'PER_ID_RECIBIDO
        '
        Me.PER_ID_RECIBIDO.HeaderText = "ENVIADO A"
        Me.PER_ID_RECIBIDO.Name = "PER_ID_RECIBIDO"
        '
        'frmRecepcionDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1083, 534)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmRecepcionDocumento"
        Me.Text = "Recepcion de Documentos"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.dsListaReporteSeguimientoDocumentoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecibido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRecibido As System.Windows.Forms.DataGridView
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
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnRecibido As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ColumnaCalendario1 As ColumnaCalendario
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaReporteSeguimientoDocumentoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OCO_ID_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSE_ID_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTD_ID_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_ID_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_SERIE_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_NUMERO_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PER_ID_PROVEEDOR_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_CONCEPTO_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_RECIBIDO_1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OCO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_FECHA_DOCUMENTO As ColumnaCalendario
    Friend WithEvents PER_ID_PROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RDO_CONCEPTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PER_ID_RECIBIDO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
