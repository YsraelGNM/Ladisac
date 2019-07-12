<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocuIso
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDTD_ID = New System.Windows.Forms.TextBox()
        Me.txtARE_ID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDIS_VERSION = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPER_ID_APROBACION = New System.Windows.Forms.TextBox()
        Me.txtPER_ID_REVISION = New System.Windows.Forms.TextBox()
        Me.txtPER_ID_ELABORACION = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpDIS_FECHA_ELABORACION = New System.Windows.Forms.DateTimePicker()
        Me.dtpDIS_FECHA_REVISION = New System.Windows.Forms.DateTimePicker()
        Me.dtpDIS_FECHA_APROBACION = New System.Windows.Forms.DateTimePicker()
        Me.chkDIS_VIGENTE = New System.Windows.Forms.CheckBox()
        Me.picDIS_ADJUNTO = New System.Windows.Forms.PictureBox()
        Me.cmAdjunto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooAdDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarAdjuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarAdjuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
        Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPDI_ID = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DID_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Texto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDIS_ADJUNTO_DESCRI = New System.Windows.Forms.TextBox()
        Me.txtCodArea = New System.Windows.Forms.TextBox()
        Me.txtCodDoc = New System.Windows.Forms.TextBox()
        Me.txtDIS_CODIGO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtSi = New System.Windows.Forms.RadioButton()
        Me.rbtNo = New System.Windows.Forms.RadioButton()
        Me.rbtPublico = New System.Windows.Forms.RadioButton()
        Me.rbtArea = New System.Windows.Forms.RadioButton()
        Me.rbtPrivado = New System.Windows.Forms.RadioButton()
        CType(Me.picDIS_ADJUNTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdjunto.SuspendLayout()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(956, 28)
        Me.lblTitle.Text = "Documentos ISO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Tipo Documento"
        '
        'txtDTD_ID
        '
        Me.txtDTD_ID.Location = New System.Drawing.Point(101, 121)
        Me.txtDTD_ID.Name = "txtDTD_ID"
        Me.txtDTD_ID.Size = New System.Drawing.Size(240, 20)
        Me.txtDTD_ID.TabIndex = 29
        '
        'txtARE_ID
        '
        Me.txtARE_ID.Location = New System.Drawing.Point(101, 95)
        Me.txtARE_ID.Name = "txtARE_ID"
        Me.txtARE_ID.Size = New System.Drawing.Size(240, 20)
        Me.txtARE_ID.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(101, 66)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(429, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Aprobado"
        '
        'txtDIS_VERSION
        '
        Me.txtDIS_VERSION.Location = New System.Drawing.Point(501, 177)
        Me.txtDIS_VERSION.Name = "txtDIS_VERSION"
        Me.txtDIS_VERSION.Size = New System.Drawing.Size(28, 20)
        Me.txtDIS_VERSION.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Area"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(429, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Elaborado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(272, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Vigente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(429, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Version"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(429, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Revisado"
        '
        'txtPER_ID_APROBACION
        '
        Me.txtPER_ID_APROBACION.Location = New System.Drawing.Point(501, 150)
        Me.txtPER_ID_APROBACION.Name = "txtPER_ID_APROBACION"
        Me.txtPER_ID_APROBACION.Size = New System.Drawing.Size(237, 20)
        Me.txtPER_ID_APROBACION.TabIndex = 35
        '
        'txtPER_ID_REVISION
        '
        Me.txtPER_ID_REVISION.Location = New System.Drawing.Point(501, 124)
        Me.txtPER_ID_REVISION.Name = "txtPER_ID_REVISION"
        Me.txtPER_ID_REVISION.Size = New System.Drawing.Size(237, 20)
        Me.txtPER_ID_REVISION.TabIndex = 36
        '
        'txtPER_ID_ELABORACION
        '
        Me.txtPER_ID_ELABORACION.Location = New System.Drawing.Point(501, 98)
        Me.txtPER_ID_ELABORACION.Name = "txtPER_ID_ELABORACION"
        Me.txtPER_ID_ELABORACION.Size = New System.Drawing.Size(237, 20)
        Me.txtPER_ID_ELABORACION.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(748, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Fecha Revisado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(748, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Fecha Elaborado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(748, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Fecha Aprobado"
        '
        'dtpDIS_FECHA_ELABORACION
        '
        Me.dtpDIS_FECHA_ELABORACION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDIS_FECHA_ELABORACION.Location = New System.Drawing.Point(843, 98)
        Me.dtpDIS_FECHA_ELABORACION.Name = "dtpDIS_FECHA_ELABORACION"
        Me.dtpDIS_FECHA_ELABORACION.Size = New System.Drawing.Size(100, 20)
        Me.dtpDIS_FECHA_ELABORACION.TabIndex = 41
        '
        'dtpDIS_FECHA_REVISION
        '
        Me.dtpDIS_FECHA_REVISION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDIS_FECHA_REVISION.Location = New System.Drawing.Point(843, 124)
        Me.dtpDIS_FECHA_REVISION.Name = "dtpDIS_FECHA_REVISION"
        Me.dtpDIS_FECHA_REVISION.Size = New System.Drawing.Size(100, 20)
        Me.dtpDIS_FECHA_REVISION.TabIndex = 42
        '
        'dtpDIS_FECHA_APROBACION
        '
        Me.dtpDIS_FECHA_APROBACION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDIS_FECHA_APROBACION.Location = New System.Drawing.Point(843, 150)
        Me.dtpDIS_FECHA_APROBACION.Name = "dtpDIS_FECHA_APROBACION"
        Me.dtpDIS_FECHA_APROBACION.Size = New System.Drawing.Size(100, 20)
        Me.dtpDIS_FECHA_APROBACION.TabIndex = 43
        '
        'chkDIS_VIGENTE
        '
        Me.chkDIS_VIGENTE.AutoSize = True
        Me.chkDIS_VIGENTE.Location = New System.Drawing.Point(326, 153)
        Me.chkDIS_VIGENTE.Name = "chkDIS_VIGENTE"
        Me.chkDIS_VIGENTE.Size = New System.Drawing.Size(15, 14)
        Me.chkDIS_VIGENTE.TabIndex = 44
        Me.chkDIS_VIGENTE.UseVisualStyleBackColor = True
        '
        'picDIS_ADJUNTO
        '
        Me.picDIS_ADJUNTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDIS_ADJUNTO.ContextMenuStrip = Me.cmAdjunto
        Me.picDIS_ADJUNTO.Location = New System.Drawing.Point(101, 154)
        Me.picDIS_ADJUNTO.Name = "picDIS_ADJUNTO"
        Me.picDIS_ADJUNTO.Size = New System.Drawing.Size(69, 13)
        Me.picDIS_ADJUNTO.TabIndex = 138
        Me.picDIS_ADJUNTO.TabStop = False
        '
        'cmAdjunto
        '
        Me.cmAdjunto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooAdDescargar, Me.CargarAdjuntoToolStripMenuItem, Me.EliminarAdjuntoToolStripMenuItem})
        Me.cmAdjunto.Name = "cmUsc"
        Me.cmAdjunto.Size = New System.Drawing.Size(173, 70)
        '
        'tooAdDescargar
        '
        Me.tooAdDescargar.Name = "tooAdDescargar"
        Me.tooAdDescargar.Size = New System.Drawing.Size(172, 22)
        Me.tooAdDescargar.Text = "Descargar Adjunto"
        '
        'CargarAdjuntoToolStripMenuItem
        '
        Me.CargarAdjuntoToolStripMenuItem.Name = "CargarAdjuntoToolStripMenuItem"
        Me.CargarAdjuntoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CargarAdjuntoToolStripMenuItem.Text = "Cargar Adjunto"
        '
        'EliminarAdjuntoToolStripMenuItem
        '
        Me.EliminarAdjuntoToolStripMenuItem.Name = "EliminarAdjuntoToolStripMenuItem"
        Me.EliminarAdjuntoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.EliminarAdjuntoToolStripMenuItem.Text = "Eliminar Adjunto"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 154)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Adjunto"
        '
        'sfdImagen
        '
        Me.sfdImagen.Filter = "All files (*.*)|*.*"
        '
        'ofdImagen
        '
        Me.ofdImagen.Filter = "All files (*.*)|*.*"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(659, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Plantilla"
        Me.Label12.Visible = False
        '
        'txtPDI_ID
        '
        Me.txtPDI_ID.Location = New System.Drawing.Point(708, 309)
        Me.txtPDI_ID.Name = "txtPDI_ID"
        Me.txtPDI_ID.Size = New System.Drawing.Size(44, 20)
        Me.txtPDI_ID.TabIndex = 142
        Me.txtPDI_ID.Visible = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DID_ID, Me.Marca, Me.Texto})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 280)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(928, 23)
        Me.dgvDetalle.TabIndex = 143
        Me.dgvDetalle.Visible = False
        '
        'DID_ID
        '
        Me.DID_ID.HeaderText = "DID_ID"
        Me.DID_ID.Name = "DID_ID"
        Me.DID_ID.Visible = False
        '
        'Marca
        '
        Me.Marca.FillWeight = 30.0!
        Me.Marca.HeaderText = "MARCA"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        '
        'Texto
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Texto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Texto.HeaderText = "DESCRIPCION"
        Me.Texto.Name = "Texto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 144
        Me.Label13.Text = "Nombre Doc"
        '
        'txtDIS_ADJUNTO_DESCRI
        '
        Me.txtDIS_ADJUNTO_DESCRI.Location = New System.Drawing.Point(101, 177)
        Me.txtDIS_ADJUNTO_DESCRI.Name = "txtDIS_ADJUNTO_DESCRI"
        Me.txtDIS_ADJUNTO_DESCRI.ReadOnly = True
        Me.txtDIS_ADJUNTO_DESCRI.Size = New System.Drawing.Size(237, 20)
        Me.txtDIS_ADJUNTO_DESCRI.TabIndex = 145
        '
        'txtCodArea
        '
        Me.txtCodArea.Location = New System.Drawing.Point(347, 95)
        Me.txtCodArea.Name = "txtCodArea"
        Me.txtCodArea.ReadOnly = True
        Me.txtCodArea.Size = New System.Drawing.Size(62, 20)
        Me.txtCodArea.TabIndex = 146
        '
        'txtCodDoc
        '
        Me.txtCodDoc.Location = New System.Drawing.Point(347, 121)
        Me.txtCodDoc.Name = "txtCodDoc"
        Me.txtCodDoc.ReadOnly = True
        Me.txtCodDoc.Size = New System.Drawing.Size(62, 20)
        Me.txtCodDoc.TabIndex = 147
        '
        'txtDIS_CODIGO
        '
        Me.txtDIS_CODIGO.Location = New System.Drawing.Point(382, 306)
        Me.txtDIS_CODIGO.MaxLength = 2
        Me.txtDIS_CODIGO.Name = "txtDIS_CODIGO"
        Me.txtDIS_CODIGO.Size = New System.Drawing.Size(27, 20)
        Me.txtDIS_CODIGO.TabIndex = 148
        Me.txtDIS_CODIGO.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(349, 311)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "Item"
        Me.Label14.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DID_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 189
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "MARCA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 271
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 543
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtNo)
        Me.GroupBox1.Controls.Add(Me.rbtSi)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 45)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descargable"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtPrivado)
        Me.GroupBox2.Controls.Add(Me.rbtArea)
        Me.GroupBox2.Controls.Add(Me.rbtPublico)
        Me.GroupBox2.Location = New System.Drawing.Point(432, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 45)
        Me.GroupBox2.TabIndex = 151
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Visualizacion"
        '
        'rbtSi
        '
        Me.rbtSi.AutoSize = True
        Me.rbtSi.Location = New System.Drawing.Point(34, 17)
        Me.rbtSi.Name = "rbtSi"
        Me.rbtSi.Size = New System.Drawing.Size(34, 17)
        Me.rbtSi.TabIndex = 0
        Me.rbtSi.TabStop = True
        Me.rbtSi.Text = "Si"
        Me.rbtSi.UseVisualStyleBackColor = True
        '
        'rbtNo
        '
        Me.rbtNo.AutoSize = True
        Me.rbtNo.Checked = True
        Me.rbtNo.Location = New System.Drawing.Point(109, 17)
        Me.rbtNo.Name = "rbtNo"
        Me.rbtNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtNo.TabIndex = 1
        Me.rbtNo.TabStop = True
        Me.rbtNo.Text = "No"
        Me.rbtNo.UseVisualStyleBackColor = True
        '
        'rbtPublico
        '
        Me.rbtPublico.AutoSize = True
        Me.rbtPublico.Location = New System.Drawing.Point(5, 17)
        Me.rbtPublico.Name = "rbtPublico"
        Me.rbtPublico.Size = New System.Drawing.Size(60, 17)
        Me.rbtPublico.TabIndex = 1
        Me.rbtPublico.TabStop = True
        Me.rbtPublico.Text = "Publico"
        Me.rbtPublico.UseVisualStyleBackColor = True
        '
        'rbtArea
        '
        Me.rbtArea.AutoSize = True
        Me.rbtArea.Location = New System.Drawing.Point(77, 17)
        Me.rbtArea.Name = "rbtArea"
        Me.rbtArea.Size = New System.Drawing.Size(47, 17)
        Me.rbtArea.TabIndex = 2
        Me.rbtArea.TabStop = True
        Me.rbtArea.Text = "Area"
        Me.rbtArea.UseVisualStyleBackColor = True
        '
        'rbtPrivado
        '
        Me.rbtPrivado.AutoSize = True
        Me.rbtPrivado.Checked = True
        Me.rbtPrivado.Location = New System.Drawing.Point(134, 17)
        Me.rbtPrivado.Name = "rbtPrivado"
        Me.rbtPrivado.Size = New System.Drawing.Size(61, 17)
        Me.rbtPrivado.TabIndex = 3
        Me.rbtPrivado.TabStop = True
        Me.rbtPrivado.Text = "Privado"
        Me.rbtPrivado.UseVisualStyleBackColor = True
        '
        'frmDocuIso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(956, 263)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDIS_CODIGO)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCodDoc)
        Me.Controls.Add(Me.txtCodArea)
        Me.Controls.Add(Me.txtDIS_ADJUNTO_DESCRI)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtPDI_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picDIS_ADJUNTO)
        Me.Controls.Add(Me.txtDIS_VERSION)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtPER_ID_APROBACION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPER_ID_REVISION)
        Me.Controls.Add(Me.chkDIS_VIGENTE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtPER_ID_ELABORACION)
        Me.Controls.Add(Me.dtpDIS_FECHA_APROBACION)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtARE_ID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpDIS_FECHA_REVISION)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDTD_ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpDIS_FECHA_ELABORACION)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Name = "frmDocuIso"
        Me.Text = "Documentos ISO"
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dtpDIS_FECHA_ELABORACION, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtDTD_ID, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpDIS_FECHA_REVISION, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtARE_ID, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.dtpDIS_FECHA_APROBACION, 0)
        Me.Controls.SetChildIndex(Me.txtPER_ID_ELABORACION, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.chkDIS_VIGENTE, 0)
        Me.Controls.SetChildIndex(Me.txtPER_ID_REVISION, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtPER_ID_APROBACION, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtDIS_VERSION, 0)
        Me.Controls.SetChildIndex(Me.picDIS_ADJUNTO, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtPDI_ID, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtDIS_ADJUNTO_DESCRI, 0)
        Me.Controls.SetChildIndex(Me.txtCodArea, 0)
        Me.Controls.SetChildIndex(Me.txtCodDoc, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtDIS_CODIGO, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.picDIS_ADJUNTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdjunto.ResumeLayout(False)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDTD_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtARE_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDIS_VERSION As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPER_ID_APROBACION As System.Windows.Forms.TextBox
    Friend WithEvents txtPER_ID_REVISION As System.Windows.Forms.TextBox
    Friend WithEvents txtPER_ID_ELABORACION As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpDIS_FECHA_ELABORACION As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDIS_FECHA_REVISION As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDIS_FECHA_APROBACION As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDIS_VIGENTE As System.Windows.Forms.CheckBox
    Friend WithEvents picDIS_ADJUNTO As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmAdjunto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooAdDescargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ofdImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPDI_ID As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDIS_ADJUNTO_DESCRI As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DID_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Texto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodArea As System.Windows.Forms.TextBox
    Friend WithEvents txtDIS_CODIGO As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CargarAdjuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarAdjuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrivado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtArea As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPublico As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSi As System.Windows.Forms.RadioButton

End Class
