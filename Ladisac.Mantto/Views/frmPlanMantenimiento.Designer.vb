<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanMantenimiento
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoMantto = New System.Windows.Forms.ComboBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMantenimiento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numHora = New System.Windows.Forms.NumericUpDown()
        Me.numTn = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numDia = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numUso = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numUsoUtil = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numDiaUtil = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numTnUtil = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numHoraUtil = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numHrEstim = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtProcedimiento = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvSuministro = New System.Windows.Forms.DataGridView()
        Me.cboTipResponsable = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numKilometroUtil = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numKilometro = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.SPM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPM_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.numHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUsoUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDiaUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTnUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoraUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHrEstim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvSuministro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKilometroUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKilometro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(477, 28)
        Me.lblTitle.Text = "Plan Mantenimiento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Codigo"
        '
        'txtEntidad
        '
        Me.txtEntidad.Location = New System.Drawing.Point(100, 90)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(344, 20)
        Me.txtEntidad.TabIndex = 115
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Entidad"
        '
        'cboTipoMantto
        '
        Me.cboTipoMantto.FormattingEnabled = True
        Me.cboTipoMantto.Location = New System.Drawing.Point(100, 143)
        Me.cboTipoMantto.Name = "cboTipoMantto"
        Me.cboTipoMantto.Size = New System.Drawing.Size(230, 21)
        Me.cboTipoMantto.TabIndex = 124
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(100, 64)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 117
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Tipo Mantto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Mantenimiento"
        '
        'cboMantenimiento
        '
        Me.cboMantenimiento.FormattingEnabled = True
        Me.cboMantenimiento.Location = New System.Drawing.Point(100, 116)
        Me.cboMantenimiento.Name = "cboMantenimiento"
        Me.cboMantenimiento.Size = New System.Drawing.Size(230, 21)
        Me.cboMantenimiento.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Horas"
        '
        'numHora
        '
        Me.numHora.Location = New System.Drawing.Point(100, 173)
        Me.numHora.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numHora.Name = "numHora"
        Me.numHora.Size = New System.Drawing.Size(120, 20)
        Me.numHora.TabIndex = 126
        '
        'numTn
        '
        Me.numTn.Location = New System.Drawing.Point(100, 225)
        Me.numTn.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numTn.Name = "numTn"
        Me.numTn.Size = New System.Drawing.Size(120, 20)
        Me.numTn.TabIndex = 128
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Toneladas"
        '
        'numDia
        '
        Me.numDia.Location = New System.Drawing.Point(100, 251)
        Me.numDia.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDia.Name = "numDia"
        Me.numDia.Size = New System.Drawing.Size(120, 20)
        Me.numDia.TabIndex = 130
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Dias"
        '
        'numUso
        '
        Me.numUso.Location = New System.Drawing.Point(100, 277)
        Me.numUso.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numUso.Name = "numUso"
        Me.numUso.Size = New System.Drawing.Size(120, 20)
        Me.numUso.TabIndex = 132
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 279)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Usos"
        '
        'numUsoUtil
        '
        Me.numUsoUtil.Location = New System.Drawing.Point(345, 277)
        Me.numUsoUtil.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numUsoUtil.Name = "numUsoUtil"
        Me.numUsoUtil.Size = New System.Drawing.Size(99, 20)
        Me.numUsoUtil.TabIndex = 140
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(246, 279)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 139
        Me.Label9.Text = "Utilizado"
        '
        'numDiaUtil
        '
        Me.numDiaUtil.Location = New System.Drawing.Point(345, 251)
        Me.numDiaUtil.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDiaUtil.Name = "numDiaUtil"
        Me.numDiaUtil.Size = New System.Drawing.Size(99, 20)
        Me.numDiaUtil.TabIndex = 138
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(246, 253)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "Utilizado"
        '
        'numTnUtil
        '
        Me.numTnUtil.Location = New System.Drawing.Point(345, 225)
        Me.numTnUtil.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numTnUtil.Name = "numTnUtil"
        Me.numTnUtil.Size = New System.Drawing.Size(99, 20)
        Me.numTnUtil.TabIndex = 136
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(246, 227)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 135
        Me.Label11.Text = "Utilizado"
        '
        'numHoraUtil
        '
        Me.numHoraUtil.Location = New System.Drawing.Point(345, 173)
        Me.numHoraUtil.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numHoraUtil.Name = "numHoraUtil"
        Me.numHoraUtil.Size = New System.Drawing.Size(99, 20)
        Me.numHoraUtil.TabIndex = 134
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(246, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 133
        Me.Label12.Text = "Utilizado"
        '
        'numHrEstim
        '
        Me.numHrEstim.Location = New System.Drawing.Point(100, 305)
        Me.numHrEstim.Name = "numHrEstim"
        Me.numHrEstim.Size = New System.Drawing.Size(90, 20)
        Me.numHrEstim.TabIndex = 143
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 309)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 13)
        Me.Label20.TabIndex = 142
        Me.Label20.Text = "Dura.Estim.(Hr)"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(25, 336)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(419, 185)
        Me.TabControl1.TabIndex = 144
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtProcedimiento)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(411, 159)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Procedimiento"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtProcedimiento
        '
        Me.txtProcedimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcedimiento.Location = New System.Drawing.Point(6, 6)
        Me.txtProcedimiento.Multiline = True
        Me.txtProcedimiento.Name = "txtProcedimiento"
        Me.txtProcedimiento.Size = New System.Drawing.Size(399, 147)
        Me.txtProcedimiento.TabIndex = 116
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvSuministro)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(411, 159)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Suministros"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvSuministro
        '
        Me.dgvSuministro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSuministro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuministro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SPM_ID, Me.ART_CODIGO, Me.ART_DESCRIPCION, Me.SPM_CANTIDAD})
        Me.dgvSuministro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSuministro.Location = New System.Drawing.Point(3, 3)
        Me.dgvSuministro.Name = "dgvSuministro"
        Me.dgvSuministro.Size = New System.Drawing.Size(405, 153)
        Me.dgvSuministro.TabIndex = 0
        '
        'cboTipResponsable
        '
        Me.cboTipResponsable.FormattingEnabled = True
        Me.cboTipResponsable.Items.AddRange(New Object() {"Mecanico", "Electricista", "Soldador"})
        Me.cboTipResponsable.Location = New System.Drawing.Point(345, 305)
        Me.cboTipResponsable.Name = "cboTipResponsable"
        Me.cboTipResponsable.Size = New System.Drawing.Size(99, 21)
        Me.cboTipResponsable.TabIndex = 146
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(246, 309)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Tipo Responsable"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SMP_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'numKilometroUtil
        '
        Me.numKilometroUtil.Location = New System.Drawing.Point(345, 199)
        Me.numKilometroUtil.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numKilometroUtil.Name = "numKilometroUtil"
        Me.numKilometroUtil.Size = New System.Drawing.Size(99, 20)
        Me.numKilometroUtil.TabIndex = 150
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(246, 201)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "Utilizado"
        '
        'numKilometro
        '
        Me.numKilometro.Location = New System.Drawing.Point(100, 199)
        Me.numKilometro.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numKilometro.Name = "numKilometro"
        Me.numKilometro.Size = New System.Drawing.Size(120, 20)
        Me.numKilometro.TabIndex = 148
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 201)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 147
        Me.Label15.Text = "Kilometros"
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Location = New System.Drawing.Point(22, 529)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(422, 23)
        Me.lblRuta.TabIndex = 152
        Me.lblRuta.Text = "Label2"
        '
        'SPM_ID
        '
        Me.SPM_ID.HeaderText = "SPM_ID"
        Me.SPM_ID.Name = "SPM_ID"
        Me.SPM_ID.Visible = False
        '
        'ART_CODIGO
        '
        Me.ART_CODIGO.FillWeight = 50.0!
        Me.ART_CODIGO.HeaderText = "Codigo"
        Me.ART_CODIGO.Name = "ART_CODIGO"
        '
        'ART_DESCRIPCION
        '
        Me.ART_DESCRIPCION.HeaderText = "Descripcion"
        Me.ART_DESCRIPCION.Name = "ART_DESCRIPCION"
        '
        'SPM_CANTIDAD
        '
        Me.SPM_CANTIDAD.FillWeight = 50.0!
        Me.SPM_CANTIDAD.HeaderText = "Cantidad"
        Me.SPM_CANTIDAD.Name = "SPM_CANTIDAD"
        '
        'frmPlanMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(477, 561)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.numKilometroUtil)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.numKilometro)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboTipResponsable)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.numHrEstim)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.numUsoUtil)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.numDiaUtil)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.numTnUtil)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.numHoraUtil)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.numUso)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numDia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.numTn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numHora)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEntidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipoMantto)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboMantenimiento)
        Me.Name = "frmPlanMantenimiento"
        Me.Text = "Plan Mantenimiento"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.cboMantenimiento, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.cboTipoMantto, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtEntidad, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.numHora, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.numTn, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.numDia, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numUso, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.numHoraUtil, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.numTnUtil, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numDiaUtil, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.numUsoUtil, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.numHrEstim, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.cboTipResponsable, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.numKilometro, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.numKilometroUtil, 0)
        Me.Controls.SetChildIndex(Me.lblRuta, 0)
        CType(Me.numHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUsoUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDiaUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTnUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoraUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHrEstim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvSuministro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKilometroUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKilometro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoMantto As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMantenimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numHora As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numDia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numUso As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numUsoUtil As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numDiaUtil As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numTnUtil As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numHoraUtil As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numHrEstim As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtProcedimiento As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSuministro As System.Windows.Forms.DataGridView
    Friend WithEvents cboTipResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numKilometroUtil As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents numKilometro As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents SPM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPM_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
