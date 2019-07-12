Namespace Ladisac.Mantto.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmOrdenTrabajo
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
            Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Principal")
            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtEntidad = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboMantenimiento = New System.Windows.Forms.ComboBox()
            Me.cboTipoFalla = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboClaseMantto = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboGrupo = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.tabOT = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.txtObservacion = New System.Windows.Forms.TextBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtAutorizado = New System.Windows.Forms.TextBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.txtSolicitado = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtEmitido = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.numHrReal = New System.Windows.Forms.NumericUpDown()
            Me.numHrEstim = New System.Windows.Forms.NumericUpDown()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.dtpFecMax = New System.Windows.Forms.DateTimePicker()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.dtpFecTer = New System.Windows.Forms.DateTimePicker()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.dtpFecEmi = New System.Windows.Forms.DateTimePicker()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.numToneladas = New System.Windows.Forms.NumericUpDown()
            Me.numHoras = New System.Windows.Forms.NumericUpDown()
            Me.NumHoroInicial = New System.Windows.Forms.NumericUpDown()
            Me.numHoroFinal = New System.Windows.Forms.NumericUpDown()
            Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
            Me.cboFase = New System.Windows.Forms.ComboBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.numCriticidad = New System.Windows.Forms.NumericUpDown()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.treHijosEntidad = New System.Windows.Forms.TreeView()
            Me.dgvEntidad = New System.Windows.Forms.DataGridView()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.btnCrearOR = New System.Windows.Forms.Button()
            Me.dgvSuministro = New System.Windows.Forms.DataGridView()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
            Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.lblHecho = New System.Windows.Forms.Label()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MTO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvPersonal = New System.Windows.Forms.DataGridView()
            Me.OTP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTP_FECHA = New ColumnaCalendario()
            Me.PER_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTP_HORA_NORMAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTP_HORA_EXTRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTP_HORA_ESPECIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dsImprimirOrdenTrabajoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.tabOT.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.numHrReal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numHrEstim, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numToneladas, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numHoras, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumHoroInicial, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numCriticidad, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            CType(Me.dgvEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.dgvSuministro, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage5.SuspendLayout()
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dsImprimirOrdenTrabajoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(832, 28)
            Me.lblTitle.Text = "Orden de Trabajo"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(23, 25)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 13)
            Me.Label3.TabIndex = 108
            Me.Label3.Text = "Codigo"
            '
            'txtCodigo
            '
            Me.txtCodigo.BackColor = System.Drawing.Color.White
            Me.txtCodigo.Location = New System.Drawing.Point(101, 21)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
            Me.txtCodigo.TabIndex = 107
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(23, 51)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 104
            Me.Label1.Text = "Entidad"
            '
            'txtEntidad
            '
            Me.txtEntidad.Location = New System.Drawing.Point(101, 47)
            Me.txtEntidad.Name = "txtEntidad"
            Me.txtEntidad.Size = New System.Drawing.Size(344, 20)
            Me.txtEntidad.TabIndex = 103
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(23, 77)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(76, 13)
            Me.Label4.TabIndex = 109
            Me.Label4.Text = "Mantenimiento"
            '
            'cboMantenimiento
            '
            Me.cboMantenimiento.FormattingEnabled = True
            Me.cboMantenimiento.Location = New System.Drawing.Point(101, 73)
            Me.cboMantenimiento.Name = "cboMantenimiento"
            Me.cboMantenimiento.Size = New System.Drawing.Size(230, 21)
            Me.cboMantenimiento.TabIndex = 110
            '
            'cboTipoFalla
            '
            Me.cboTipoFalla.FormattingEnabled = True
            Me.cboTipoFalla.Location = New System.Drawing.Point(101, 99)
            Me.cboTipoFalla.Name = "cboTipoFalla"
            Me.cboTipoFalla.Size = New System.Drawing.Size(230, 21)
            Me.cboTipoFalla.TabIndex = 112
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(23, 103)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(53, 13)
            Me.Label5.TabIndex = 111
            Me.Label5.Text = "Tipo Falla"
            '
            'cboClaseMantto
            '
            Me.cboClaseMantto.FormattingEnabled = True
            Me.cboClaseMantto.Location = New System.Drawing.Point(101, 125)
            Me.cboClaseMantto.Name = "cboClaseMantto"
            Me.cboClaseMantto.Size = New System.Drawing.Size(230, 21)
            Me.cboClaseMantto.TabIndex = 114
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(23, 129)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(69, 13)
            Me.Label6.TabIndex = 113
            Me.Label6.Text = "Clase Mantto"
            '
            'cboGrupo
            '
            Me.cboGrupo.FormattingEnabled = True
            Me.cboGrupo.Location = New System.Drawing.Point(101, 154)
            Me.cboGrupo.Name = "cboGrupo"
            Me.cboGrupo.Size = New System.Drawing.Size(230, 21)
            Me.cboGrupo.TabIndex = 116
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(23, 158)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(36, 13)
            Me.Label7.TabIndex = 115
            Me.Label7.Text = "Grupo"
            '
            'tabOT
            '
            Me.tabOT.Controls.Add(Me.TabPage1)
            Me.tabOT.Controls.Add(Me.TabPage4)
            Me.tabOT.Controls.Add(Me.TabPage2)
            Me.tabOT.Controls.Add(Me.TabPage3)
            Me.tabOT.Controls.Add(Me.TabPage5)
            Me.tabOT.Location = New System.Drawing.Point(13, 74)
            Me.tabOT.Name = "tabOT"
            Me.tabOT.SelectedIndex = 0
            Me.tabOT.Size = New System.Drawing.Size(807, 414)
            Me.tabOT.TabIndex = 117
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.txtObservacion)
            Me.TabPage1.Controls.Add(Me.Label24)
            Me.TabPage1.Controls.Add(Me.txtAutorizado)
            Me.TabPage1.Controls.Add(Me.Label23)
            Me.TabPage1.Controls.Add(Me.txtSolicitado)
            Me.TabPage1.Controls.Add(Me.Label22)
            Me.TabPage1.Controls.Add(Me.txtEmitido)
            Me.TabPage1.Controls.Add(Me.Label21)
            Me.TabPage1.Controls.Add(Me.numHrReal)
            Me.TabPage1.Controls.Add(Me.numHrEstim)
            Me.TabPage1.Controls.Add(Me.Label19)
            Me.TabPage1.Controls.Add(Me.Label20)
            Me.TabPage1.Controls.Add(Me.dtpFecMax)
            Me.TabPage1.Controls.Add(Me.Label18)
            Me.TabPage1.Controls.Add(Me.dtpFecTer)
            Me.TabPage1.Controls.Add(Me.Label17)
            Me.TabPage1.Controls.Add(Me.dtpFecIni)
            Me.TabPage1.Controls.Add(Me.Label16)
            Me.TabPage1.Controls.Add(Me.dtpFecEmi)
            Me.TabPage1.Controls.Add(Me.Label15)
            Me.TabPage1.Controls.Add(Me.numToneladas)
            Me.TabPage1.Controls.Add(Me.numHoras)
            Me.TabPage1.Controls.Add(Me.NumHoroInicial)
            Me.TabPage1.Controls.Add(Me.numHoroFinal)
            Me.TabPage1.Controls.Add(Me.dtpFechaIngreso)
            Me.TabPage1.Controls.Add(Me.cboFase)
            Me.TabPage1.Controls.Add(Me.Label14)
            Me.TabPage1.Controls.Add(Me.numCriticidad)
            Me.TabPage1.Controls.Add(Me.Label13)
            Me.TabPage1.Controls.Add(Me.Label12)
            Me.TabPage1.Controls.Add(Me.Label11)
            Me.TabPage1.Controls.Add(Me.Label10)
            Me.TabPage1.Controls.Add(Me.Label9)
            Me.TabPage1.Controls.Add(Me.Label8)
            Me.TabPage1.Controls.Add(Me.Label3)
            Me.TabPage1.Controls.Add(Me.cboGrupo)
            Me.TabPage1.Controls.Add(Me.txtEntidad)
            Me.TabPage1.Controls.Add(Me.Label7)
            Me.TabPage1.Controls.Add(Me.Label1)
            Me.TabPage1.Controls.Add(Me.cboClaseMantto)
            Me.TabPage1.Controls.Add(Me.txtCodigo)
            Me.TabPage1.Controls.Add(Me.Label6)
            Me.TabPage1.Controls.Add(Me.Label4)
            Me.TabPage1.Controls.Add(Me.cboTipoFalla)
            Me.TabPage1.Controls.Add(Me.cboMantenimiento)
            Me.TabPage1.Controls.Add(Me.Label5)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(799, 388)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Datos"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'txtObservacion
            '
            Me.txtObservacion.Location = New System.Drawing.Point(444, 263)
            Me.txtObservacion.Multiline = True
            Me.txtObservacion.Name = "txtObservacion"
            Me.txtObservacion.Size = New System.Drawing.Size(341, 98)
            Me.txtObservacion.TabIndex = 150
            '
            'Label24
            '
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(368, 266)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(63, 13)
            Me.Label24.TabIndex = 149
            Me.Label24.Text = "Descripcion"
            '
            'txtAutorizado
            '
            Me.txtAutorizado.Location = New System.Drawing.Point(444, 237)
            Me.txtAutorizado.Name = "txtAutorizado"
            Me.txtAutorizado.Size = New System.Drawing.Size(341, 20)
            Me.txtAutorizado.TabIndex = 147
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Location = New System.Drawing.Point(366, 214)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(53, 13)
            Me.Label23.TabIndex = 148
            Me.Label23.Text = "Solicitado"
            '
            'txtSolicitado
            '
            Me.txtSolicitado.Location = New System.Drawing.Point(444, 211)
            Me.txtSolicitado.Name = "txtSolicitado"
            Me.txtSolicitado.Size = New System.Drawing.Size(341, 20)
            Me.txtSolicitado.TabIndex = 145
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(368, 240)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(57, 13)
            Me.Label22.TabIndex = 146
            Me.Label22.Text = "Autorizado"
            '
            'txtEmitido
            '
            Me.txtEmitido.Location = New System.Drawing.Point(444, 185)
            Me.txtEmitido.Name = "txtEmitido"
            Me.txtEmitido.Size = New System.Drawing.Size(341, 20)
            Me.txtEmitido.TabIndex = 143
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(366, 189)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(59, 13)
            Me.Label21.TabIndex = 144
            Me.Label21.Text = "Emitido por"
            '
            'numHrReal
            '
            Me.numHrReal.Location = New System.Drawing.Point(101, 338)
            Me.numHrReal.Name = "numHrReal"
            Me.numHrReal.Size = New System.Drawing.Size(90, 20)
            Me.numHrReal.TabIndex = 142
            '
            'numHrEstim
            '
            Me.numHrEstim.Location = New System.Drawing.Point(101, 312)
            Me.numHrEstim.Name = "numHrEstim"
            Me.numHrEstim.Size = New System.Drawing.Size(90, 20)
            Me.numHrEstim.TabIndex = 141
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(23, 340)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(75, 13)
            Me.Label19.TabIndex = 140
            Me.Label19.Text = "Dura.Real.(Hr)"
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(23, 314)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(78, 13)
            Me.Label20.TabIndex = 139
            Me.Label20.Text = "Dura.Estim.(Hr)"
            '
            'dtpFecMax
            '
            Me.dtpFecMax.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dtpFecMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFecMax.Location = New System.Drawing.Point(101, 286)
            Me.dtpFecMax.Name = "dtpFecMax"
            Me.dtpFecMax.Size = New System.Drawing.Size(125, 20)
            Me.dtpFecMax.TabIndex = 138
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(23, 292)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(63, 13)
            Me.Label18.TabIndex = 137
            Me.Label18.Text = "Fecha Max."
            '
            'dtpFecTer
            '
            Me.dtpFecTer.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dtpFecTer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFecTer.Location = New System.Drawing.Point(101, 260)
            Me.dtpFecTer.Name = "dtpFecTer"
            Me.dtpFecTer.Size = New System.Drawing.Size(125, 20)
            Me.dtpFecTer.TabIndex = 136
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(23, 266)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(78, 13)
            Me.Label17.TabIndex = 135
            Me.Label17.Text = "Fecha Termino"
            '
            'dtpFecIni
            '
            Me.dtpFecIni.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFecIni.Location = New System.Drawing.Point(101, 234)
            Me.dtpFecIni.Name = "dtpFecIni"
            Me.dtpFecIni.Size = New System.Drawing.Size(125, 20)
            Me.dtpFecIni.TabIndex = 134
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(23, 240)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(65, 13)
            Me.Label16.TabIndex = 133
            Me.Label16.Text = "Fecha Inicio"
            '
            'dtpFecEmi
            '
            Me.dtpFecEmi.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dtpFecEmi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFecEmi.Location = New System.Drawing.Point(101, 207)
            Me.dtpFecEmi.Name = "dtpFecEmi"
            Me.dtpFecEmi.Size = New System.Drawing.Size(125, 20)
            Me.dtpFecEmi.TabIndex = 132
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(23, 213)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(76, 13)
            Me.Label15.TabIndex = 131
            Me.Label15.Text = "Fecha Emision"
            '
            'numToneladas
            '
            Me.numToneladas.DecimalPlaces = 2
            Me.numToneladas.Location = New System.Drawing.Point(576, 99)
            Me.numToneladas.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
            Me.numToneladas.Name = "numToneladas"
            Me.numToneladas.Size = New System.Drawing.Size(90, 20)
            Me.numToneladas.TabIndex = 130
            '
            'numHoras
            '
            Me.numHoras.Location = New System.Drawing.Point(576, 73)
            Me.numHoras.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
            Me.numHoras.Name = "numHoras"
            Me.numHoras.Size = New System.Drawing.Size(90, 20)
            Me.numHoras.TabIndex = 129
            '
            'NumHoroInicial
            '
            Me.NumHoroInicial.DecimalPlaces = 2
            Me.NumHoroInicial.Location = New System.Drawing.Point(576, 151)
            Me.NumHoroInicial.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
            Me.NumHoroInicial.Name = "NumHoroInicial"
            Me.NumHoroInicial.Size = New System.Drawing.Size(90, 20)
            Me.NumHoroInicial.TabIndex = 128
            '
            'numHoroFinal
            '
            Me.numHoroFinal.DecimalPlaces = 2
            Me.numHoroFinal.Location = New System.Drawing.Point(576, 47)
            Me.numHoroFinal.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
            Me.numHoroFinal.Name = "numHoroFinal"
            Me.numHoroFinal.Size = New System.Drawing.Size(90, 20)
            Me.numHoroFinal.TabIndex = 127
            '
            'dtpFechaIngreso
            '
            Me.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFechaIngreso.Location = New System.Drawing.Point(576, 125)
            Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
            Me.dtpFechaIngreso.Size = New System.Drawing.Size(125, 20)
            Me.dtpFechaIngreso.TabIndex = 126
            '
            'cboFase
            '
            Me.cboFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFase.FormattingEnabled = True
            Me.cboFase.Items.AddRange(New Object() {"Pendiente", "En Proceso", "Finalizado"})
            Me.cboFase.Location = New System.Drawing.Point(576, 21)
            Me.cboFase.Name = "cboFase"
            Me.cboFase.Size = New System.Drawing.Size(90, 21)
            Me.cboFase.TabIndex = 125
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(488, 25)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(30, 13)
            Me.Label14.TabIndex = 124
            Me.Label14.Text = "Fase"
            '
            'numCriticidad
            '
            Me.numCriticidad.Location = New System.Drawing.Point(101, 181)
            Me.numCriticidad.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
            Me.numCriticidad.Name = "numCriticidad"
            Me.numCriticidad.Size = New System.Drawing.Size(90, 20)
            Me.numCriticidad.TabIndex = 123
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(488, 104)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(57, 13)
            Me.Label13.TabIndex = 122
            Me.Label13.Text = "Toneladas"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(488, 78)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(35, 13)
            Me.Label12.TabIndex = 121
            Me.Label12.Text = "Horas"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(488, 158)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(60, 13)
            Me.Label11.TabIndex = 120
            Me.Label11.Text = "Horo.Inicial"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(488, 52)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(55, 13)
            Me.Label10.TabIndex = 119
            Me.Label10.Text = "Horo.Final"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(488, 132)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(75, 13)
            Me.Label9.TabIndex = 118
            Me.Label9.Text = "Fecha Ingreso"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(23, 189)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(50, 13)
            Me.Label8.TabIndex = 117
            Me.Label8.Text = "Criticidad"
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.treHijosEntidad)
            Me.TabPage4.Controls.Add(Me.dgvEntidad)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(799, 388)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Sub-Entidades"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'treHijosEntidad
            '
            Me.treHijosEntidad.Location = New System.Drawing.Point(29, 33)
            Me.treHijosEntidad.Name = "treHijosEntidad"
            TreeNode1.Name = "Node0"
            TreeNode1.Text = "Principal"
            Me.treHijosEntidad.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
            Me.treHijosEntidad.Size = New System.Drawing.Size(299, 322)
            Me.treHijosEntidad.TabIndex = 2
            '
            'dgvEntidad
            '
            Me.dgvEntidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvEntidad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OTE_ID, Me.ENO_ID, Me.MTO_ID})
            Me.dgvEntidad.Location = New System.Drawing.Point(376, 33)
            Me.dgvEntidad.Name = "dgvEntidad"
            Me.dgvEntidad.Size = New System.Drawing.Size(399, 322)
            Me.dgvEntidad.TabIndex = 1
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.dgvPersonal)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(799, 388)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Personal"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.btnCrearOR)
            Me.TabPage3.Controls.Add(Me.dgvSuministro)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(799, 388)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Suministros"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'btnCrearOR
            '
            Me.btnCrearOR.Location = New System.Drawing.Point(23, 16)
            Me.btnCrearOR.Name = "btnCrearOR"
            Me.btnCrearOR.Size = New System.Drawing.Size(75, 23)
            Me.btnCrearOR.TabIndex = 1
            Me.btnCrearOR.Text = "Crear O.R."
            Me.btnCrearOR.UseVisualStyleBackColor = True
            '
            'dgvSuministro
            '
            Me.dgvSuministro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSuministro.Location = New System.Drawing.Point(23, 45)
            Me.dgvSuministro.Name = "dgvSuministro"
            Me.dgvSuministro.Size = New System.Drawing.Size(751, 315)
            Me.dgvSuministro.TabIndex = 0
            '
            'TabPage5
            '
            Me.TabPage5.Controls.Add(Me.ReportViewer1)
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Size = New System.Drawing.Size(799, 388)
            Me.TabPage5.TabIndex = 4
            Me.TabPage5.Text = "Impresión"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'ReportViewer1
            '
            Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            ReportDataSource1.Name = "dsImprimirOrdenTrabajo"
            ReportDataSource1.Value = Me.dsImprimirOrdenTrabajoBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptImprimirOrdenTrabajo.rdlc"
            Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
            Me.ReportViewer1.Name = "ReportViewer1"
            Me.ReportViewer1.Size = New System.Drawing.Size(799, 388)
            Me.ReportViewer1.TabIndex = 0
            '
            'Error_Validacion
            '
            Me.Error_Validacion.ContainerControl = Me
            '
            'lblHecho
            '
            Me.lblHecho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblHecho.AutoSize = True
            Me.lblHecho.Location = New System.Drawing.Point(14, 502)
            Me.lblHecho.Name = "lblHecho"
            Me.lblHecho.Size = New System.Drawing.Size(0, 13)
            Me.lblHecho.TabIndex = 118
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "OTE_ID"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Entidad"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Width = 200
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Mantenimiento"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'OTE_ID
            '
            Me.OTE_ID.HeaderText = "OTE_ID"
            Me.OTE_ID.Name = "OTE_ID"
            '
            'ENO_ID
            '
            Me.ENO_ID.HeaderText = "Entidad"
            Me.ENO_ID.Name = "ENO_ID"
            Me.ENO_ID.Width = 200
            '
            'MTO_ID
            '
            Me.MTO_ID.HeaderText = "Mantenimiento"
            Me.MTO_ID.Name = "MTO_ID"
            '
            'dgvPersonal
            '
            Me.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPersonal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OTP_ID, Me.OTP_FECHA, Me.PER_ID, Me.OTP_HORA_NORMAL, Me.OTP_HORA_EXTRA, Me.OTP_HORA_ESPECIAL})
            Me.dgvPersonal.Location = New System.Drawing.Point(23, 40)
            Me.dgvPersonal.Name = "dgvPersonal"
            Me.dgvPersonal.Size = New System.Drawing.Size(751, 322)
            Me.dgvPersonal.TabIndex = 0
            '
            'OTP_ID
            '
            Me.OTP_ID.HeaderText = "OTP_ID"
            Me.OTP_ID.Name = "OTP_ID"
            Me.OTP_ID.Visible = False
            '
            'OTP_FECHA
            '
            Me.OTP_FECHA.HeaderText = "Fecha"
            Me.OTP_FECHA.Name = "OTP_FECHA"
            '
            'PER_ID
            '
            Me.PER_ID.HeaderText = "PER_ID"
            Me.PER_ID.Name = "PER_ID"
            Me.PER_ID.Width = 300
            '
            'OTP_HORA_NORMAL
            '
            Me.OTP_HORA_NORMAL.HeaderText = "Horas"
            Me.OTP_HORA_NORMAL.Name = "OTP_HORA_NORMAL"
            '
            'OTP_HORA_EXTRA
            '
            Me.OTP_HORA_EXTRA.HeaderText = "Hora Extra"
            Me.OTP_HORA_EXTRA.Name = "OTP_HORA_EXTRA"
            Me.OTP_HORA_EXTRA.Visible = False
            '
            'OTP_HORA_ESPECIAL
            '
            Me.OTP_HORA_ESPECIAL.HeaderText = "Hora Especial"
            Me.OTP_HORA_ESPECIAL.Name = "OTP_HORA_ESPECIAL"
            Me.OTP_HORA_ESPECIAL.Visible = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "OTP_ID"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.Visible = False
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "PER_ID"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.Width = 200
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "Hora Normal"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "Hora Extra"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.Visible = False
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Hora Especial"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.Visible = False
            '
            'dsImprimirOrdenTrabajoBindingSource
            '
            Me.dsImprimirOrdenTrabajoBindingSource.DataMember = "spImprimirOrdenTrabajo"
            Me.dsImprimirOrdenTrabajoBindingSource.DataSource = GetType(dsImprimirOrdenTrabajo)
            '
            'frmOrdenTrabajo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(832, 532)
            Me.Controls.Add(Me.lblHecho)
            Me.Controls.Add(Me.tabOT)
            Me.Name = "frmOrdenTrabajo"
            Me.Text = "Orden de Trabajo"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.tabOT, 0)
            Me.Controls.SetChildIndex(Me.lblHecho, 0)
            Me.tabOT.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            CType(Me.numHrReal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numHrEstim, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numToneladas, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numHoras, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumHoroInicial, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numCriticidad, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            CType(Me.dgvEntidad, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage3.ResumeLayout(False)
            CType(Me.dgvSuministro, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage5.ResumeLayout(False)
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dsImprimirOrdenTrabajoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboMantenimiento As System.Windows.Forms.ComboBox
        Friend WithEvents cboTipoFalla As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboClaseMantto As System.Windows.Forms.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents tabOT As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents txtAutorizado As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents txtSolicitado As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtEmitido As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents numHrReal As System.Windows.Forms.NumericUpDown
        Friend WithEvents numHrEstim As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents dtpFecMax As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents dtpFecTer As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents dtpFecEmi As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents numToneladas As System.Windows.Forms.NumericUpDown
        Friend WithEvents numHoras As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumHoroInicial As System.Windows.Forms.NumericUpDown
        Friend WithEvents numHoroFinal As System.Windows.Forms.NumericUpDown
        Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboFase As System.Windows.Forms.ComboBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents numCriticidad As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents dgvSuministro As System.Windows.Forms.DataGridView
        Friend WithEvents btnCrearOR As System.Windows.Forms.Button
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents dgvEntidad As System.Windows.Forms.DataGridView
        Friend WithEvents treHijosEntidad As System.Windows.Forms.TreeView
        Friend WithEvents OTE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MTO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblHecho As System.Windows.Forms.Label
        Friend WithEvents OTP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTP_FECHA As ColumnaCalendario
        Friend WithEvents PER_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTP_HORA_NORMAL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTP_HORA_EXTRA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTP_HORA_ESPECIAL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
        Friend WithEvents dsImprimirOrdenTrabajoBindingSource As System.Windows.Forms.BindingSource

    End Class
End Namespace
