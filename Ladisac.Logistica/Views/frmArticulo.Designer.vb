<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulo
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFichaTecnica = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigoFabricante = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescripcionFabricante = New System.Windows.Forms.TextBox()
        Me.rbNacional = New System.Windows.Forms.RadioButton()
        Me.rbInternacional = New System.Windows.Forms.RadioButton()
        Me.cboUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboModelo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbSi = New System.Windows.Forms.RadioButton()
        Me.picArticulo = New System.Windows.Forms.PictureBox()
        Me.chkAcpNegativo = New System.Windows.Forms.CheckBox()
        Me.chkAfeRetencion = New System.Windows.Forms.CheckBox()
        Me.chkAfePercepcion = New System.Windows.Forms.CheckBox()
        Me.cboIgv = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ofImagen = New System.Windows.Forms.OpenFileDialog()
        Me.numFactor = New System.Windows.Forms.NumericUpDown()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.numART_ORDEN_REPORTE = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDetraccion = New System.Windows.Forms.TextBox()
        Me.txtCUC_ID_1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCUC_ID_2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCUC_ID_4 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCUC_ID_3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.numLeadTime = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        CType(Me.picArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numART_ORDEN_REPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(634, 28)
        Me.lblTitle.Text = "Articulo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Observacion"
        '
        'txtFichaTecnica
        '
        Me.txtFichaTecnica.Location = New System.Drawing.Point(134, 413)
        Me.txtFichaTecnica.MaxLength = 255
        Me.txtFichaTecnica.Multiline = True
        Me.txtFichaTecnica.Name = "txtFichaTecnica"
        Me.txtFichaTecnica.Size = New System.Drawing.Size(265, 89)
        Me.txtFichaTecnica.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Color"
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(134, 320)
        Me.txtColor.MaxLength = 15
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(265, 20)
        Me.txtColor.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(134, 70)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(134, 122)
        Me.txtDescripcion.MaxLength = 160
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(265, 20)
        Me.txtDescripcion.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Código Articulo"
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.BackColor = System.Drawing.Color.White
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(134, 96)
        Me.txtCodigoArticulo.MaxLength = 11
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoArticulo.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Código Fabricante"
        '
        'txtCodigoFabricante
        '
        Me.txtCodigoFabricante.BackColor = System.Drawing.Color.White
        Me.txtCodigoFabricante.Location = New System.Drawing.Point(134, 148)
        Me.txtCodigoFabricante.MaxLength = 45
        Me.txtCodigoFabricante.Name = "txtCodigoFabricante"
        Me.txtCodigoFabricante.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoFabricante.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Descripción Fabricante"
        '
        'txtDescripcionFabricante
        '
        Me.txtDescripcionFabricante.Location = New System.Drawing.Point(134, 177)
        Me.txtDescripcionFabricante.MaxLength = 45
        Me.txtDescripcionFabricante.Name = "txtDescripcionFabricante"
        Me.txtDescripcionFabricante.Size = New System.Drawing.Size(265, 20)
        Me.txtDescripcionFabricante.TabIndex = 37
        '
        'rbNacional
        '
        Me.rbNacional.AutoSize = True
        Me.rbNacional.Location = New System.Drawing.Point(119, 8)
        Me.rbNacional.Name = "rbNacional"
        Me.rbNacional.Size = New System.Drawing.Size(67, 17)
        Me.rbNacional.TabIndex = 38
        Me.rbNacional.TabStop = True
        Me.rbNacional.Text = "Nacional"
        Me.rbNacional.UseVisualStyleBackColor = True
        '
        'rbInternacional
        '
        Me.rbInternacional.AutoSize = True
        Me.rbInternacional.Location = New System.Drawing.Point(251, 8)
        Me.rbInternacional.Name = "rbInternacional"
        Me.rbInternacional.Size = New System.Drawing.Size(86, 17)
        Me.rbInternacional.TabIndex = 39
        Me.rbInternacional.TabStop = True
        Me.rbInternacional.Text = "Internacional"
        Me.rbInternacional.UseVisualStyleBackColor = True
        '
        'cboUnidadMedida
        '
        Me.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadMedida.FormattingEnabled = True
        Me.cboUnidadMedida.Location = New System.Drawing.Point(134, 242)
        Me.cboUnidadMedida.MaxLength = 45
        Me.cboUnidadMedida.Name = "cboUnidadMedida"
        Me.cboUnidadMedida.Size = New System.Drawing.Size(265, 21)
        Me.cboUnidadMedida.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Unidad Medida"
        '
        'cboMarca
        '
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.Location = New System.Drawing.Point(134, 269)
        Me.cboMarca.MaxLength = 45
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(265, 21)
        Me.cboMarca.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Marca"
        '
        'cboModelo
        '
        Me.cboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModelo.FormattingEnabled = True
        Me.cboModelo.Location = New System.Drawing.Point(134, 295)
        Me.cboModelo.MaxLength = 45
        Me.cboModelo.Name = "cboModelo"
        Me.cboModelo.Size = New System.Drawing.Size(265, 21)
        Me.cboModelo.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Modelo"
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(134, 347)
        Me.cboGrupo.MaxLength = 45
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(265, 21)
        Me.cboGrupo.TabIndex = 48
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 351)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Grupo"
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(251, 8)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(39, 17)
        Me.rbNo.TabIndex = 51
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbSi
        '
        Me.rbSi.AutoSize = True
        Me.rbSi.Location = New System.Drawing.Point(119, 8)
        Me.rbSi.Name = "rbSi"
        Me.rbSi.Size = New System.Drawing.Size(34, 17)
        Me.rbSi.TabIndex = 50
        Me.rbSi.TabStop = True
        Me.rbSi.Text = "Si"
        Me.rbSi.UseVisualStyleBackColor = True
        '
        'picArticulo
        '
        Me.picArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picArticulo.Location = New System.Drawing.Point(440, 70)
        Me.picArticulo.Name = "picArticulo"
        Me.picArticulo.Size = New System.Drawing.Size(182, 127)
        Me.picArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picArticulo.TabIndex = 53
        Me.picArticulo.TabStop = False
        '
        'chkAcpNegativo
        '
        Me.chkAcpNegativo.AutoSize = True
        Me.chkAcpNegativo.Location = New System.Drawing.Point(440, 297)
        Me.chkAcpNegativo.Name = "chkAcpNegativo"
        Me.chkAcpNegativo.Size = New System.Drawing.Size(139, 17)
        Me.chkAcpNegativo.TabIndex = 55
        Me.chkAcpNegativo.Text = "Acepta Precio Negativo"
        Me.chkAcpNegativo.UseVisualStyleBackColor = True
        '
        'chkAfeRetencion
        '
        Me.chkAfeRetencion.AutoSize = True
        Me.chkAfeRetencion.Location = New System.Drawing.Point(440, 271)
        Me.chkAfeRetencion.Name = "chkAfeRetencion"
        Me.chkAfeRetencion.Size = New System.Drawing.Size(118, 17)
        Me.chkAfeRetencion.TabIndex = 56
        Me.chkAfeRetencion.Text = "Afecto a Retencion"
        Me.chkAfeRetencion.UseVisualStyleBackColor = True
        '
        'chkAfePercepcion
        '
        Me.chkAfePercepcion.AutoSize = True
        Me.chkAfePercepcion.Location = New System.Drawing.Point(440, 244)
        Me.chkAfePercepcion.Name = "chkAfePercepcion"
        Me.chkAfePercepcion.Size = New System.Drawing.Size(123, 17)
        Me.chkAfePercepcion.TabIndex = 57
        Me.chkAfePercepcion.Text = "Afecto a Percepcion"
        Me.chkAfePercepcion.UseVisualStyleBackColor = True
        '
        'cboIgv
        '
        Me.cboIgv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIgv.FormattingEnabled = True
        Me.cboIgv.Items.AddRange(New Object() {"No Incluye", "Si Incluye", "No Grabado con IGV"})
        Me.cboIgv.Location = New System.Drawing.Point(483, 208)
        Me.cboIgv.Name = "cboIgv"
        Me.cboIgv.Size = New System.Drawing.Size(139, 21)
        Me.cboIgv.TabIndex = 59
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(440, 212)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "I.G.V."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbInternacional)
        Me.GroupBox1.Controls.Add(Me.rbNacional)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 31)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNo)
        Me.GroupBox2.Controls.Add(Me.rbSi)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 31)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controla Stock"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(437, 351)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Factor"
        '
        'numFactor
        '
        Me.numFactor.DecimalPlaces = 2
        Me.numFactor.Location = New System.Drawing.Point(566, 347)
        Me.numFactor.Name = "numFactor"
        Me.numFactor.Size = New System.Drawing.Size(56, 20)
        Me.numFactor.TabIndex = 64
        Me.numFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Error_validacion
        '
        Me.Error_validacion.BlinkRate = 200
        Me.Error_validacion.ContainerControl = Me
        '
        'numART_ORDEN_REPORTE
        '
        Me.numART_ORDEN_REPORTE.Location = New System.Drawing.Point(566, 376)
        Me.numART_ORDEN_REPORTE.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numART_ORDEN_REPORTE.Name = "numART_ORDEN_REPORTE"
        Me.numART_ORDEN_REPORTE.Size = New System.Drawing.Size(56, 20)
        Me.numART_ORDEN_REPORTE.TabIndex = 66
        Me.numART_ORDEN_REPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numART_ORDEN_REPORTE.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(437, 380)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 13)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "Orden en Reportes "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(437, 324)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Detraccion"
        '
        'txtDetraccion
        '
        Me.txtDetraccion.Location = New System.Drawing.Point(502, 320)
        Me.txtDetraccion.MaxLength = 160
        Me.txtDetraccion.Name = "txtDetraccion"
        Me.txtDetraccion.Size = New System.Drawing.Size(120, 20)
        Me.txtDetraccion.TabIndex = 68
        '
        'txtCUC_ID_1
        '
        Me.txtCUC_ID_1.Location = New System.Drawing.Point(502, 409)
        Me.txtCUC_ID_1.MaxLength = 160
        Me.txtCUC_ID_1.Name = "txtCUC_ID_1"
        Me.txtCUC_ID_1.Size = New System.Drawing.Size(120, 20)
        Me.txtCUC_ID_1.TabIndex = 70
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(437, 413)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Cta.Cont.1"
        '
        'txtCUC_ID_2
        '
        Me.txtCUC_ID_2.Location = New System.Drawing.Point(502, 434)
        Me.txtCUC_ID_2.MaxLength = 160
        Me.txtCUC_ID_2.Name = "txtCUC_ID_2"
        Me.txtCUC_ID_2.Size = New System.Drawing.Size(120, 20)
        Me.txtCUC_ID_2.TabIndex = 72
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(437, 438)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Cta.Cont.2"
        '
        'txtCUC_ID_4
        '
        Me.txtCUC_ID_4.Location = New System.Drawing.Point(502, 484)
        Me.txtCUC_ID_4.MaxLength = 160
        Me.txtCUC_ID_4.Name = "txtCUC_ID_4"
        Me.txtCUC_ID_4.Size = New System.Drawing.Size(120, 20)
        Me.txtCUC_ID_4.TabIndex = 76
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(437, 488)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Cta.Cont.4"
        '
        'txtCUC_ID_3
        '
        Me.txtCUC_ID_3.Location = New System.Drawing.Point(502, 459)
        Me.txtCUC_ID_3.MaxLength = 160
        Me.txtCUC_ID_3.Name = "txtCUC_ID_3"
        Me.txtCUC_ID_3.Size = New System.Drawing.Size(120, 20)
        Me.txtCUC_ID_3.TabIndex = 74
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(437, 463)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "Cta.Cont.3"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(440, 512)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(73, 17)
        Me.chkActivo.TabIndex = 77
        Me.chkActivo.Text = "No Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'numLeadTime
        '
        Me.numLeadTime.DecimalPlaces = 2
        Me.numLeadTime.Location = New System.Drawing.Point(134, 508)
        Me.numLeadTime.Name = "numLeadTime"
        Me.numLeadTime.Size = New System.Drawing.Size(56, 20)
        Me.numLeadTime.TabIndex = 79
        Me.numLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 512)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 78
        Me.Label20.Text = "Lead Tme"
        '
        'frmArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(634, 541)
        Me.Controls.Add(Me.numLeadTime)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtCUC_ID_4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCUC_ID_3)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtCUC_ID_2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCUC_ID_1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtDetraccion)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.numART_ORDEN_REPORTE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.numFactor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboIgv)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.chkAfePercepcion)
        Me.Controls.Add(Me.chkAfeRetencion)
        Me.Controls.Add(Me.chkAcpNegativo)
        Me.Controls.Add(Me.picArticulo)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboModelo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMarca)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboUnidadMedida)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDescripcionFabricante)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCodigoFabricante)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCodigoArticulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFichaTecnica)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Name = "frmArticulo"
        Me.Text = "Articulo"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtFichaTecnica, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoArticulo, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoFabricante, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionFabricante, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboUnidadMedida, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cboMarca, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cboModelo, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.cboGrupo, 0)
        Me.Controls.SetChildIndex(Me.picArticulo, 0)
        Me.Controls.SetChildIndex(Me.chkAcpNegativo, 0)
        Me.Controls.SetChildIndex(Me.chkAfeRetencion, 0)
        Me.Controls.SetChildIndex(Me.chkAfePercepcion, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cboIgv, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.numFactor, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.numART_ORDEN_REPORTE, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txtDetraccion, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtCUC_ID_1, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtCUC_ID_2, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txtCUC_ID_3, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtCUC_ID_4, 0)
        Me.Controls.SetChildIndex(Me.chkActivo, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.numLeadTime, 0)
        CType(Me.picArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numART_ORDEN_REPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFichaTecnica As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoFabricante As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionFabricante As System.Windows.Forms.TextBox
    Friend WithEvents rbNacional As System.Windows.Forms.RadioButton
    Friend WithEvents rbInternacional As System.Windows.Forms.RadioButton
    Friend WithEvents cboUnidadMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboModelo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbSi As System.Windows.Forms.RadioButton
    Friend WithEvents picArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents chkAcpNegativo As System.Windows.Forms.CheckBox
    Friend WithEvents chkAfeRetencion As System.Windows.Forms.CheckBox
    Friend WithEvents chkAfePercepcion As System.Windows.Forms.CheckBox
    Friend WithEvents cboIgv As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ofImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents numFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents numART_ORDEN_REPORTE As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCUC_ID_4 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCUC_ID_3 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCUC_ID_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCUC_ID_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents numLeadTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
