Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDatosLaborales
        Inherits ViewManMasterPlanillas
        ' System.Windows.Forms.Form

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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.chkTareoPll = New System.Windows.Forms.CheckBox()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.dateFechaCese = New System.Windows.Forms.MaskedTextBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.dateFechaIngreso = New System.Windows.Forms.DateTimePicker()
            Me.cboEstadoCivil = New System.Windows.Forms.ComboBox()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.chkRentaQuinta = New System.Windows.Forms.CheckBox()
            Me.chkestaEnPLanillas = New System.Windows.Forms.CheckBox()
            Me.chkEsPDT = New System.Windows.Forms.CheckBox()
            Me.chkAsignacionFaniliar = New System.Windows.Forms.CheckBox()
            Me.txtCussp = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtRegimenLaboral = New System.Windows.Forms.TextBox()
            Me.btnRegimenLaboral = New System.Windows.Forms.Button()
            Me.txtAutoGeneradoEssalud = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.dateFechaInscripReg = New System.Windows.Forms.DateTimePicker()
            Me.btnRegimenPensionario = New System.Windows.Forms.Button()
            Me.txtRegimenPensionario = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnCentroCosto = New System.Windows.Forms.Button()
            Me.txtCentroCosto = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnNivelEducacion = New System.Windows.Forms.Button()
            Me.txtNivelEducacion = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboSexo = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dateFechaNacimiento = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.txtCentroRiesgo = New System.Windows.Forms.TextBox()
            Me.btnCentroRiesgo = New System.Windows.Forms.Button()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.txtNumeroCuentaCTS = New System.Windows.Forms.TextBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtNumeroCuentaRenumeraciones = New System.Windows.Forms.TextBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.txtTipoContrato = New System.Windows.Forms.TextBox()
            Me.btnTipoContrato = New System.Windows.Forms.Button()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtDobleTributacion = New System.Windows.Forms.TextBox()
            Me.btnDobleTributacion = New System.Windows.Forms.Button()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtPeriodisidad = New System.Windows.Forms.TextBox()
            Me.btnPeriodisidad = New System.Windows.Forms.Button()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtAreaTrabajo = New System.Windows.Forms.TextBox()
            Me.btnAreaTrabajo = New System.Windows.Forms.Button()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtSituacionEspecial = New System.Windows.Forms.TextBox()
            Me.txtSituacionTrabajador = New System.Windows.Forms.TextBox()
            Me.btnSituacionEspecial = New System.Windows.Forms.Button()
            Me.btnSituacionTrabajador = New System.Windows.Forms.Button()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtBancoCTS = New System.Windows.Forms.TextBox()
            Me.btnCuentaCTS = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtBancoRenumeracion = New System.Windows.Forms.TextBox()
            Me.btnBancoRenumeracio = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCargo = New System.Windows.Forms.Button()
            Me.txtCargo = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.btnTipoTrabajador = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.dataCronograma = New System.Windows.Forms.DataGridView()
            Me.crv_ItemCroVaca = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.crv_FechaInicio = New ColumnaCalendario()
            Me.crv_FechaFin = New ColumnaCalendario()
            Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Domingo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.crv_periodoAsignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.crv_Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.crv_Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.crv_Estado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.tdo_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.pla_SeriePlani = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pla_Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.dataPeriodoLaboral = New System.Windows.Forms.DataGridView()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New ColumnaCalendario()
            Me.DataGridViewTextBoxColumn3 = New ColumnaCalendario()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.TipoContrato = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TabPage6 = New System.Windows.Forms.TabPage()
            Me.dgvHorarioTrabajo = New System.Windows.Forms.DataGridView()
            Me.dah_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dah_Ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dah_Salida = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dah_Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dah_estado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.txtHorasFijas = New System.Windows.Forms.TextBox()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.txtHoraRefregerio = New System.Windows.Forms.TextBox()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.txtHorasMes = New System.Windows.Forms.TextBox()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.TabPage7 = New System.Windows.Forms.TabPage()
            Me.TabControl2 = New System.Windows.Forms.TabControl()
            Me.TabPage8 = New System.Windows.Forms.TabPage()
            Me.txtAlergias = New System.Windows.Forms.TextBox()
            Me.Label43 = New System.Windows.Forms.Label()
            Me.txtEnfermedad = New System.Windows.Forms.TextBox()
            Me.Label42 = New System.Windows.Forms.Label()
            Me.txtDetalleAntecedentesPolic = New System.Windows.Forms.TextBox()
            Me.txtEncasoEmergencia = New System.Windows.Forms.TextBox()
            Me.Label38 = New System.Windows.Forms.Label()
            Me.chkAntecedentesPoliciales = New System.Windows.Forms.CheckBox()
            Me.txtCelular = New System.Windows.Forms.TextBox()
            Me.Label37 = New System.Windows.Forms.Label()
            Me.txtTelefonoFijo = New System.Windows.Forms.TextBox()
            Me.Label36 = New System.Windows.Forms.Label()
            Me.txtLugarNacimiento = New System.Windows.Forms.TextBox()
            Me.Label33 = New System.Windows.Forms.Label()
            Me.TabPage9 = New System.Windows.Forms.TabPage()
            Me.txtNumeroHijos = New System.Windows.Forms.NumericUpDown()
            Me.Label41 = New System.Windows.Forms.Label()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.Label39 = New System.Windows.Forms.Label()
            Me.TabPage10 = New System.Windows.Forms.TabPage()
            Me.DataGridView2 = New System.Windows.Forms.DataGridView()
            Me.Label40 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtDistrito = New System.Windows.Forms.TextBox()
            Me.Label35 = New System.Windows.Forms.Label()
            Me.txtDireccion = New System.Windows.Forms.TextBox()
            Me.Label34 = New System.Windows.Forms.Label()
            Me.btnBorrarImagen = New System.Windows.Forms.Button()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.PictureImagen = New System.Windows.Forms.PictureBox()
            Me.txtDni = New System.Windows.Forms.TextBox()
            Me.Label32 = New System.Windows.Forms.Label()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            Me.TabPage4.SuspendLayout()
            CType(Me.dataCronograma, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage5.SuspendLayout()
            CType(Me.dataPeriodoLaboral, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage6.SuspendLayout()
            CType(Me.dgvHorarioTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.TabPage7.SuspendLayout()
            Me.TabControl2.SuspendLayout()
            Me.TabPage8.SuspendLayout()
            Me.TabPage9.SuspendLayout()
            CType(Me.txtNumeroHijos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage10.SuspendLayout()
            CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.PictureImagen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(655, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 66)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(639, 522)
            Me.Panel1.TabIndex = 4
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.TabControl1)
            Me.Panel3.Location = New System.Drawing.Point(9, 150)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(625, 365)
            Me.Panel3.TabIndex = 2
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Controls.Add(Me.TabPage5)
            Me.TabControl1.Controls.Add(Me.TabPage6)
            Me.TabControl1.Controls.Add(Me.TabPage7)
            Me.TabControl1.Location = New System.Drawing.Point(3, 5)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(617, 352)
            Me.TabControl1.TabIndex = 1
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.chkTareoPll)
            Me.TabPage1.Controls.Add(Me.Label28)
            Me.TabPage1.Controls.Add(Me.dateFechaCese)
            Me.TabPage1.Controls.Add(Me.Label27)
            Me.TabPage1.Controls.Add(Me.dateFechaIngreso)
            Me.TabPage1.Controls.Add(Me.cboEstadoCivil)
            Me.TabPage1.Controls.Add(Me.Label26)
            Me.TabPage1.Controls.Add(Me.chkRentaQuinta)
            Me.TabPage1.Controls.Add(Me.chkestaEnPLanillas)
            Me.TabPage1.Controls.Add(Me.chkEsPDT)
            Me.TabPage1.Controls.Add(Me.chkAsignacionFaniliar)
            Me.TabPage1.Controls.Add(Me.txtCussp)
            Me.TabPage1.Controls.Add(Me.Label20)
            Me.TabPage1.Controls.Add(Me.Label19)
            Me.TabPage1.Controls.Add(Me.txtRegimenLaboral)
            Me.TabPage1.Controls.Add(Me.btnRegimenLaboral)
            Me.TabPage1.Controls.Add(Me.txtAutoGeneradoEssalud)
            Me.TabPage1.Controls.Add(Me.Label7)
            Me.TabPage1.Controls.Add(Me.Label6)
            Me.TabPage1.Controls.Add(Me.txtCodigo)
            Me.TabPage1.Controls.Add(Me.Label12)
            Me.TabPage1.Controls.Add(Me.dateFechaInscripReg)
            Me.TabPage1.Controls.Add(Me.btnRegimenPensionario)
            Me.TabPage1.Controls.Add(Me.txtRegimenPensionario)
            Me.TabPage1.Controls.Add(Me.Label5)
            Me.TabPage1.Controls.Add(Me.btnCentroCosto)
            Me.TabPage1.Controls.Add(Me.txtCentroCosto)
            Me.TabPage1.Controls.Add(Me.Label4)
            Me.TabPage1.Controls.Add(Me.btnNivelEducacion)
            Me.TabPage1.Controls.Add(Me.txtNivelEducacion)
            Me.TabPage1.Controls.Add(Me.Label3)
            Me.TabPage1.Controls.Add(Me.cboSexo)
            Me.TabPage1.Controls.Add(Me.Label2)
            Me.TabPage1.Controls.Add(Me.dateFechaNacimiento)
            Me.TabPage1.Controls.Add(Me.Label1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(609, 326)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Datos Primarios"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'chkTareoPll
            '
            Me.chkTareoPll.AutoSize = True
            Me.chkTareoPll.Location = New System.Drawing.Point(141, 273)
            Me.chkTareoPll.Name = "chkTareoPll"
            Me.chkTareoPll.Size = New System.Drawing.Size(216, 17)
            Me.chkTareoPll.TabIndex = 41
            Me.chkTareoPll.Text = "Se Aplica para Destajo / Planillas Pagos"
            Me.chkTareoPll.UseVisualStyleBackColor = True
            '
            'Label28
            '
            Me.Label28.AutoSize = True
            Me.Label28.Location = New System.Drawing.Point(302, 244)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(64, 13)
            Me.Label28.TabIndex = 40
            Me.Label28.Text = "Fecha Cese"
            '
            'dateFechaCese
            '
            Me.dateFechaCese.Location = New System.Drawing.Point(372, 241)
            Me.dateFechaCese.Mask = "00/00/0000"
            Me.dateFechaCese.Name = "dateFechaCese"
            Me.dateFechaCese.Size = New System.Drawing.Size(69, 20)
            Me.dateFechaCese.TabIndex = 39
            Me.dateFechaCese.ValidatingType = GetType(Date)
            '
            'Label27
            '
            Me.Label27.AutoSize = True
            Me.Label27.Location = New System.Drawing.Point(63, 244)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(75, 13)
            Me.Label27.TabIndex = 38
            Me.Label27.Text = "Fecha Ingreso"
            '
            'dateFechaIngreso
            '
            Me.dateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaIngreso.Location = New System.Drawing.Point(141, 240)
            Me.dateFechaIngreso.Name = "dateFechaIngreso"
            Me.dateFechaIngreso.Size = New System.Drawing.Size(121, 20)
            Me.dateFechaIngreso.TabIndex = 37
            '
            'cboEstadoCivil
            '
            Me.cboEstadoCivil.FormattingEnabled = True
            Me.cboEstadoCivil.Items.AddRange(New Object() {"Masculino", "Femenino"})
            Me.cboEstadoCivil.Location = New System.Drawing.Point(141, 29)
            Me.cboEstadoCivil.Name = "cboEstadoCivil"
            Me.cboEstadoCivil.Size = New System.Drawing.Size(121, 21)
            Me.cboEstadoCivil.TabIndex = 36
            Me.cboEstadoCivil.Text = "Masculino"
            '
            'Label26
            '
            Me.Label26.AutoSize = True
            Me.Label26.Location = New System.Drawing.Point(73, 32)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(62, 13)
            Me.Label26.TabIndex = 35
            Me.Label26.Text = "Estado Civil"
            '
            'chkRentaQuinta
            '
            Me.chkRentaQuinta.AutoSize = True
            Me.chkRentaQuinta.Location = New System.Drawing.Point(137, 300)
            Me.chkRentaQuinta.Name = "chkRentaQuinta"
            Me.chkRentaQuinta.Size = New System.Drawing.Size(104, 17)
            Me.chkRentaQuinta.TabIndex = 34
            Me.chkRentaQuinta.Text = "Renta de Quinta"
            Me.chkRentaQuinta.UseVisualStyleBackColor = True
            '
            'chkestaEnPLanillas
            '
            Me.chkestaEnPLanillas.AutoSize = True
            Me.chkestaEnPLanillas.Location = New System.Drawing.Point(351, 300)
            Me.chkestaEnPLanillas.Name = "chkestaEnPLanillas"
            Me.chkestaEnPLanillas.Size = New System.Drawing.Size(103, 17)
            Me.chkestaEnPLanillas.TabIndex = 30
            Me.chkestaEnPLanillas.Text = "Esta en Planillas"
            Me.chkestaEnPLanillas.UseVisualStyleBackColor = True
            '
            'chkEsPDT
            '
            Me.chkEsPDT.AutoSize = True
            Me.chkEsPDT.Location = New System.Drawing.Point(242, 300)
            Me.chkEsPDT.Name = "chkEsPDT"
            Me.chkEsPDT.Size = New System.Drawing.Size(103, 17)
            Me.chkEsPDT.TabIndex = 29
            Me.chkEsPDT.Text = "Se Exporta PDT"
            Me.chkEsPDT.UseVisualStyleBackColor = True
            '
            'chkAsignacionFaniliar
            '
            Me.chkAsignacionFaniliar.AutoSize = True
            Me.chkAsignacionFaniliar.Location = New System.Drawing.Point(18, 300)
            Me.chkAsignacionFaniliar.Name = "chkAsignacionFaniliar"
            Me.chkAsignacionFaniliar.Size = New System.Drawing.Size(116, 17)
            Me.chkAsignacionFaniliar.TabIndex = 28
            Me.chkAsignacionFaniliar.Text = "Asignacion Familiar"
            Me.chkAsignacionFaniliar.UseVisualStyleBackColor = True
            '
            'txtCussp
            '
            Me.txtCussp.Location = New System.Drawing.Point(141, 169)
            Me.txtCussp.MaxLength = 25
            Me.txtCussp.Name = "txtCussp"
            Me.txtCussp.Size = New System.Drawing.Size(121, 20)
            Me.txtCussp.TabIndex = 22
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(101, 171)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(37, 13)
            Me.Label20.TabIndex = 21
            Me.Label20.Text = "Cuspp"
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(51, 103)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(87, 13)
            Me.Label19.TabIndex = 20
            Me.Label19.Text = "Regimen Laboral"
            '
            'txtRegimenLaboral
            '
            Me.txtRegimenLaboral.Location = New System.Drawing.Point(141, 100)
            Me.txtRegimenLaboral.Name = "txtRegimenLaboral"
            Me.txtRegimenLaboral.ReadOnly = True
            Me.txtRegimenLaboral.Size = New System.Drawing.Size(268, 20)
            Me.txtRegimenLaboral.TabIndex = 19
            '
            'btnRegimenLaboral
            '
            Me.btnRegimenLaboral.Location = New System.Drawing.Point(412, 98)
            Me.btnRegimenLaboral.Name = "btnRegimenLaboral"
            Me.btnRegimenLaboral.Size = New System.Drawing.Size(29, 23)
            Me.btnRegimenLaboral.TabIndex = 18
            Me.btnRegimenLaboral.Text = ":::"
            Me.btnRegimenLaboral.UseVisualStyleBackColor = True
            '
            'txtAutoGeneradoEssalud
            '
            Me.txtAutoGeneradoEssalud.Location = New System.Drawing.Point(141, 192)
            Me.txtAutoGeneradoEssalud.MaxLength = 25
            Me.txtAutoGeneradoEssalud.Name = "txtAutoGeneradoEssalud"
            Me.txtAutoGeneradoEssalud.Size = New System.Drawing.Size(121, 20)
            Me.txtAutoGeneradoEssalud.TabIndex = 16
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(22, 195)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(116, 13)
            Me.Label7.TabIndex = 15
            Me.Label7.Text = "AutoGenerado Essalud"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(13, 127)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(125, 13)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "Fecha Inscrip. Reg. Pen."
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(141, 6)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(69, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(98, 9)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(40, 13)
            Me.Label12.TabIndex = 6
            Me.Label12.Text = "Codigo"
            '
            'dateFechaInscripReg
            '
            Me.dateFechaInscripReg.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaInscripReg.Location = New System.Drawing.Point(141, 123)
            Me.dateFechaInscripReg.Name = "dateFechaInscripReg"
            Me.dateFechaInscripReg.Size = New System.Drawing.Size(87, 20)
            Me.dateFechaInscripReg.TabIndex = 13
            '
            'btnRegimenPensionario
            '
            Me.btnRegimenPensionario.Location = New System.Drawing.Point(412, 142)
            Me.btnRegimenPensionario.Name = "btnRegimenPensionario"
            Me.btnRegimenPensionario.Size = New System.Drawing.Size(29, 24)
            Me.btnRegimenPensionario.TabIndex = 12
            Me.btnRegimenPensionario.Text = ":::"
            Me.btnRegimenPensionario.UseVisualStyleBackColor = True
            '
            'txtRegimenPensionario
            '
            Me.txtRegimenPensionario.Location = New System.Drawing.Point(141, 146)
            Me.txtRegimenPensionario.Name = "txtRegimenPensionario"
            Me.txtRegimenPensionario.ReadOnly = True
            Me.txtRegimenPensionario.Size = New System.Drawing.Size(268, 20)
            Me.txtRegimenPensionario.TabIndex = 11
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(31, 149)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(107, 13)
            Me.Label5.TabIndex = 10
            Me.Label5.Text = "Regimen Pensionario"
            '
            'btnCentroCosto
            '
            Me.btnCentroCosto.Location = New System.Drawing.Point(412, 74)
            Me.btnCentroCosto.Name = "btnCentroCosto"
            Me.btnCentroCosto.Size = New System.Drawing.Size(29, 23)
            Me.btnCentroCosto.TabIndex = 9
            Me.btnCentroCosto.Text = ":::"
            Me.btnCentroCosto.UseVisualStyleBackColor = True
            '
            'txtCentroCosto
            '
            Me.txtCentroCosto.Location = New System.Drawing.Point(141, 77)
            Me.txtCentroCosto.Name = "txtCentroCosto"
            Me.txtCentroCosto.ReadOnly = True
            Me.txtCentroCosto.Size = New System.Drawing.Size(268, 20)
            Me.txtCentroCosto.TabIndex = 8
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(52, 79)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(83, 13)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "Centro de Costo"
            '
            'btnNivelEducacion
            '
            Me.btnNivelEducacion.Location = New System.Drawing.Point(412, 52)
            Me.btnNivelEducacion.Name = "btnNivelEducacion"
            Me.btnNivelEducacion.Size = New System.Drawing.Size(29, 23)
            Me.btnNivelEducacion.TabIndex = 6
            Me.btnNivelEducacion.Text = ":::"
            Me.btnNivelEducacion.UseVisualStyleBackColor = True
            '
            'txtNivelEducacion
            '
            Me.txtNivelEducacion.Location = New System.Drawing.Point(141, 54)
            Me.txtNivelEducacion.Name = "txtNivelEducacion"
            Me.txtNivelEducacion.ReadOnly = True
            Me.txtNivelEducacion.Size = New System.Drawing.Size(268, 20)
            Me.txtNivelEducacion.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(38, 59)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(100, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Nivel de Educacion"
            '
            'cboSexo
            '
            Me.cboSexo.FormattingEnabled = True
            Me.cboSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
            Me.cboSexo.Location = New System.Drawing.Point(312, 29)
            Me.cboSexo.Name = "cboSexo"
            Me.cboSexo.Size = New System.Drawing.Size(96, 21)
            Me.cboSexo.TabIndex = 3
            Me.cboSexo.Text = "Masculino"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(275, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(31, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Sexo"
            '
            'dateFechaNacimiento
            '
            Me.dateFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaNacimiento.Location = New System.Drawing.Point(141, 215)
            Me.dateFechaNacimiento.Name = "dateFechaNacimiento"
            Me.dateFechaNacimiento.Size = New System.Drawing.Size(89, 20)
            Me.dateFechaNacimiento.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(45, 218)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(93, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Fecha Nacimiento"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.txtCentroRiesgo)
            Me.TabPage2.Controls.Add(Me.btnCentroRiesgo)
            Me.TabPage2.Controls.Add(Me.Label25)
            Me.TabPage2.Controls.Add(Me.txtNumeroCuentaCTS)
            Me.TabPage2.Controls.Add(Me.Label24)
            Me.TabPage2.Controls.Add(Me.txtNumeroCuentaRenumeraciones)
            Me.TabPage2.Controls.Add(Me.Label23)
            Me.TabPage2.Controls.Add(Me.Label21)
            Me.TabPage2.Controls.Add(Me.txtTipoContrato)
            Me.TabPage2.Controls.Add(Me.btnTipoContrato)
            Me.TabPage2.Controls.Add(Me.Label18)
            Me.TabPage2.Controls.Add(Me.txtDobleTributacion)
            Me.TabPage2.Controls.Add(Me.btnDobleTributacion)
            Me.TabPage2.Controls.Add(Me.Label17)
            Me.TabPage2.Controls.Add(Me.txtPeriodisidad)
            Me.TabPage2.Controls.Add(Me.btnPeriodisidad)
            Me.TabPage2.Controls.Add(Me.Label16)
            Me.TabPage2.Controls.Add(Me.txtAreaTrabajo)
            Me.TabPage2.Controls.Add(Me.btnAreaTrabajo)
            Me.TabPage2.Controls.Add(Me.Label15)
            Me.TabPage2.Controls.Add(Me.txtSituacionEspecial)
            Me.TabPage2.Controls.Add(Me.txtSituacionTrabajador)
            Me.TabPage2.Controls.Add(Me.btnSituacionEspecial)
            Me.TabPage2.Controls.Add(Me.btnSituacionTrabajador)
            Me.TabPage2.Controls.Add(Me.Label14)
            Me.TabPage2.Controls.Add(Me.txtBancoCTS)
            Me.TabPage2.Controls.Add(Me.btnCuentaCTS)
            Me.TabPage2.Controls.Add(Me.Label11)
            Me.TabPage2.Controls.Add(Me.txtBancoRenumeracion)
            Me.TabPage2.Controls.Add(Me.btnBancoRenumeracio)
            Me.TabPage2.Controls.Add(Me.Label10)
            Me.TabPage2.Controls.Add(Me.btnCargo)
            Me.TabPage2.Controls.Add(Me.txtCargo)
            Me.TabPage2.Controls.Add(Me.Label9)
            Me.TabPage2.Controls.Add(Me.txtTipoTrabajador)
            Me.TabPage2.Controls.Add(Me.btnTipoTrabajador)
            Me.TabPage2.Controls.Add(Me.Label8)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(609, 326)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Datos Laborales"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'txtCentroRiesgo
            '
            Me.txtCentroRiesgo.Location = New System.Drawing.Point(146, 281)
            Me.txtCentroRiesgo.Name = "txtCentroRiesgo"
            Me.txtCentroRiesgo.ReadOnly = True
            Me.txtCentroRiesgo.Size = New System.Drawing.Size(226, 20)
            Me.txtCentroRiesgo.TabIndex = 36
            '
            'btnCentroRiesgo
            '
            Me.btnCentroRiesgo.Location = New System.Drawing.Point(378, 280)
            Me.btnCentroRiesgo.Name = "btnCentroRiesgo"
            Me.btnCentroRiesgo.Size = New System.Drawing.Size(26, 23)
            Me.btnCentroRiesgo.TabIndex = 35
            Me.btnCentroRiesgo.Text = ":::"
            Me.btnCentroRiesgo.UseVisualStyleBackColor = True
            '
            'Label25
            '
            Me.Label25.AutoSize = True
            Me.Label25.Location = New System.Drawing.Point(54, 284)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(89, 13)
            Me.Label25.TabIndex = 34
            Me.Label25.Text = "Centro de Riesgo"
            '
            'txtNumeroCuentaCTS
            '
            Me.txtNumeroCuentaCTS.Location = New System.Drawing.Point(146, 148)
            Me.txtNumeroCuentaCTS.MaxLength = 50
            Me.txtNumeroCuentaCTS.Name = "txtNumeroCuentaCTS"
            Me.txtNumeroCuentaCTS.Size = New System.Drawing.Size(226, 20)
            Me.txtNumeroCuentaCTS.TabIndex = 33
            '
            'Label24
            '
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(78, 152)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(65, 13)
            Me.Label24.TabIndex = 32
            Me.Label24.Text = "Cuenta CTS"
            '
            'txtNumeroCuentaRenumeraciones
            '
            Me.txtNumeroCuentaRenumeraciones.Location = New System.Drawing.Point(146, 104)
            Me.txtNumeroCuentaRenumeraciones.MaxLength = 50
            Me.txtNumeroCuentaRenumeraciones.Name = "txtNumeroCuentaRenumeraciones"
            Me.txtNumeroCuentaRenumeraciones.Size = New System.Drawing.Size(226, 20)
            Me.txtNumeroCuentaRenumeraciones.TabIndex = 31
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Location = New System.Drawing.Point(19, 108)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(124, 13)
            Me.Label23.TabIndex = 30
            Me.Label23.Text = "Cuenta Renumeraciones"
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(72, 64)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(71, 13)
            Me.Label21.TabIndex = 29
            Me.Label21.Text = "Tipo Contrato"
            '
            'txtTipoContrato
            '
            Me.txtTipoContrato.Location = New System.Drawing.Point(146, 60)
            Me.txtTipoContrato.Name = "txtTipoContrato"
            Me.txtTipoContrato.ReadOnly = True
            Me.txtTipoContrato.Size = New System.Drawing.Size(226, 20)
            Me.txtTipoContrato.TabIndex = 28
            '
            'btnTipoContrato
            '
            Me.btnTipoContrato.Location = New System.Drawing.Point(378, 59)
            Me.btnTipoContrato.Name = "btnTipoContrato"
            Me.btnTipoContrato.Size = New System.Drawing.Size(26, 23)
            Me.btnTipoContrato.TabIndex = 27
            Me.btnTipoContrato.Text = ":::"
            Me.btnTipoContrato.UseVisualStyleBackColor = True
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(52, 262)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(91, 13)
            Me.Label18.TabIndex = 26
            Me.Label18.Text = "Doble Tributacion"
            '
            'txtDobleTributacion
            '
            Me.txtDobleTributacion.Location = New System.Drawing.Point(146, 258)
            Me.txtDobleTributacion.Name = "txtDobleTributacion"
            Me.txtDobleTributacion.ReadOnly = True
            Me.txtDobleTributacion.Size = New System.Drawing.Size(226, 20)
            Me.txtDobleTributacion.TabIndex = 25
            '
            'btnDobleTributacion
            '
            Me.btnDobleTributacion.Location = New System.Drawing.Point(378, 257)
            Me.btnDobleTributacion.Name = "btnDobleTributacion"
            Me.btnDobleTributacion.Size = New System.Drawing.Size(26, 23)
            Me.btnDobleTributacion.TabIndex = 24
            Me.btnDobleTributacion.Text = ":::"
            Me.btnDobleTributacion.UseVisualStyleBackColor = True
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(79, 240)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(64, 13)
            Me.Label17.TabIndex = 23
            Me.Label17.Text = "Periodisidad"
            '
            'txtPeriodisidad
            '
            Me.txtPeriodisidad.Location = New System.Drawing.Point(146, 236)
            Me.txtPeriodisidad.Name = "txtPeriodisidad"
            Me.txtPeriodisidad.ReadOnly = True
            Me.txtPeriodisidad.Size = New System.Drawing.Size(226, 20)
            Me.txtPeriodisidad.TabIndex = 22
            '
            'btnPeriodisidad
            '
            Me.btnPeriodisidad.Location = New System.Drawing.Point(378, 234)
            Me.btnPeriodisidad.Name = "btnPeriodisidad"
            Me.btnPeriodisidad.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodisidad.TabIndex = 21
            Me.btnPeriodisidad.Text = ":::"
            Me.btnPeriodisidad.UseVisualStyleBackColor = True
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(60, 218)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(83, 13)
            Me.Label16.TabIndex = 20
            Me.Label16.Text = "Area de Trabajo"
            '
            'txtAreaTrabajo
            '
            Me.txtAreaTrabajo.Location = New System.Drawing.Point(146, 214)
            Me.txtAreaTrabajo.Name = "txtAreaTrabajo"
            Me.txtAreaTrabajo.ReadOnly = True
            Me.txtAreaTrabajo.Size = New System.Drawing.Size(226, 20)
            Me.txtAreaTrabajo.TabIndex = 19
            '
            'btnAreaTrabajo
            '
            Me.btnAreaTrabajo.Location = New System.Drawing.Point(378, 211)
            Me.btnAreaTrabajo.Name = "btnAreaTrabajo"
            Me.btnAreaTrabajo.Size = New System.Drawing.Size(26, 23)
            Me.btnAreaTrabajo.TabIndex = 18
            Me.btnAreaTrabajo.Text = ":::"
            Me.btnAreaTrabajo.UseVisualStyleBackColor = True
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(49, 196)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(94, 13)
            Me.Label15.TabIndex = 17
            Me.Label15.Text = "Situacion Especial"
            '
            'txtSituacionEspecial
            '
            Me.txtSituacionEspecial.Location = New System.Drawing.Point(146, 192)
            Me.txtSituacionEspecial.Name = "txtSituacionEspecial"
            Me.txtSituacionEspecial.ReadOnly = True
            Me.txtSituacionEspecial.Size = New System.Drawing.Size(226, 20)
            Me.txtSituacionEspecial.TabIndex = 16
            '
            'txtSituacionTrabajador
            '
            Me.txtSituacionTrabajador.Location = New System.Drawing.Point(146, 170)
            Me.txtSituacionTrabajador.Name = "txtSituacionTrabajador"
            Me.txtSituacionTrabajador.ReadOnly = True
            Me.txtSituacionTrabajador.Size = New System.Drawing.Size(226, 20)
            Me.txtSituacionTrabajador.TabIndex = 15
            '
            'btnSituacionEspecial
            '
            Me.btnSituacionEspecial.Location = New System.Drawing.Point(378, 188)
            Me.btnSituacionEspecial.Name = "btnSituacionEspecial"
            Me.btnSituacionEspecial.Size = New System.Drawing.Size(26, 23)
            Me.btnSituacionEspecial.TabIndex = 14
            Me.btnSituacionEspecial.Text = ":::"
            Me.btnSituacionEspecial.UseVisualStyleBackColor = True
            '
            'btnSituacionTrabajador
            '
            Me.btnSituacionTrabajador.Location = New System.Drawing.Point(378, 165)
            Me.btnSituacionTrabajador.Name = "btnSituacionTrabajador"
            Me.btnSituacionTrabajador.Size = New System.Drawing.Size(26, 23)
            Me.btnSituacionTrabajador.TabIndex = 13
            Me.btnSituacionTrabajador.Text = ":::"
            Me.btnSituacionTrabajador.UseVisualStyleBackColor = True
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(38, 174)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(105, 13)
            Me.Label14.TabIndex = 12
            Me.Label14.Text = "Situacion Trabajador"
            '
            'txtBancoCTS
            '
            Me.txtBancoCTS.Location = New System.Drawing.Point(146, 126)
            Me.txtBancoCTS.Name = "txtBancoCTS"
            Me.txtBancoCTS.ReadOnly = True
            Me.txtBancoCTS.Size = New System.Drawing.Size(226, 20)
            Me.txtBancoCTS.TabIndex = 11
            '
            'btnCuentaCTS
            '
            Me.btnCuentaCTS.Location = New System.Drawing.Point(378, 127)
            Me.btnCuentaCTS.Name = "btnCuentaCTS"
            Me.btnCuentaCTS.Size = New System.Drawing.Size(26, 23)
            Me.btnCuentaCTS.TabIndex = 10
            Me.btnCuentaCTS.Text = ":::"
            Me.btnCuentaCTS.UseVisualStyleBackColor = True
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(81, 130)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(62, 13)
            Me.Label11.TabIndex = 9
            Me.Label11.Text = "Banco CTS"
            '
            'txtBancoRenumeracion
            '
            Me.txtBancoRenumeracion.Location = New System.Drawing.Point(146, 82)
            Me.txtBancoRenumeracion.Name = "txtBancoRenumeracion"
            Me.txtBancoRenumeracion.ReadOnly = True
            Me.txtBancoRenumeracion.Size = New System.Drawing.Size(226, 20)
            Me.txtBancoRenumeracion.TabIndex = 8
            '
            'btnBancoRenumeracio
            '
            Me.btnBancoRenumeracio.Location = New System.Drawing.Point(378, 81)
            Me.btnBancoRenumeracio.Name = "btnBancoRenumeracio"
            Me.btnBancoRenumeracio.Size = New System.Drawing.Size(26, 23)
            Me.btnBancoRenumeracio.TabIndex = 7
            Me.btnBancoRenumeracio.Text = ":::"
            Me.btnBancoRenumeracio.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(22, 86)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(121, 13)
            Me.Label10.TabIndex = 6
            Me.Label10.Text = "Banco Renumeraciones"
            '
            'btnCargo
            '
            Me.btnCargo.Location = New System.Drawing.Point(378, 37)
            Me.btnCargo.Name = "btnCargo"
            Me.btnCargo.Size = New System.Drawing.Size(26, 23)
            Me.btnCargo.TabIndex = 5
            Me.btnCargo.Text = ":::"
            Me.btnCargo.UseVisualStyleBackColor = True
            '
            'txtCargo
            '
            Me.txtCargo.Location = New System.Drawing.Point(146, 38)
            Me.txtCargo.Name = "txtCargo"
            Me.txtCargo.ReadOnly = True
            Me.txtCargo.Size = New System.Drawing.Size(226, 20)
            Me.txtCargo.TabIndex = 4
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(108, 42)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(35, 13)
            Me.Label9.TabIndex = 3
            Me.Label9.Text = "Cargo"
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(146, 16)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(226, 20)
            Me.txtTipoTrabajador.TabIndex = 2
            '
            'btnTipoTrabajador
            '
            Me.btnTipoTrabajador.Location = New System.Drawing.Point(378, 14)
            Me.btnTipoTrabajador.Name = "btnTipoTrabajador"
            Me.btnTipoTrabajador.Size = New System.Drawing.Size(26, 23)
            Me.btnTipoTrabajador.TabIndex = 1
            Me.btnTipoTrabajador.Text = ":::"
            Me.btnTipoTrabajador.UseVisualStyleBackColor = True
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(61, 20)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(82, 13)
            Me.Label8.TabIndex = 0
            Me.Label8.Text = "Tipo Trabajador"
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.txtObservaciones)
            Me.TabPage3.Controls.Add(Me.Label22)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(609, 326)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Apuntes"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(31, 40)
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(560, 235)
            Me.txtObservaciones.TabIndex = 1
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(28, 24)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(46, 13)
            Me.Label22.TabIndex = 0
            Me.Label22.Text = "Apuntes"
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.dataCronograma)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(609, 326)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Cronograma Vacaciones"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'dataCronograma
            '
            Me.dataCronograma.AllowUserToAddRows = False
            Me.dataCronograma.AllowUserToDeleteRows = False
            Me.dataCronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataCronograma.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.crv_ItemCroVaca, Me.crv_FechaInicio, Me.crv_FechaFin, Me.Dias, Me.Domingo, Me.crv_periodoAsignado, Me.crv_Periodo, Me.crv_Observaciones, Me.crv_Estado, Me.tdo_Id, Me.pla_SeriePlani, Me.pla_Numero})
            Me.dataCronograma.Location = New System.Drawing.Point(6, 6)
            Me.dataCronograma.Name = "dataCronograma"
            Me.dataCronograma.Size = New System.Drawing.Size(586, 314)
            Me.dataCronograma.TabIndex = 0
            '
            'crv_ItemCroVaca
            '
            Me.crv_ItemCroVaca.HeaderText = "crv_ItemCroVaca"
            Me.crv_ItemCroVaca.Name = "crv_ItemCroVaca"
            Me.crv_ItemCroVaca.Visible = False
            '
            'crv_FechaInicio
            '
            Me.crv_FechaInicio.HeaderText = "Fecha Inicio"
            Me.crv_FechaInicio.Name = "crv_FechaInicio"
            Me.crv_FechaInicio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.crv_FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'crv_FechaFin
            '
            Me.crv_FechaFin.HeaderText = "Fecha Fin"
            Me.crv_FechaFin.Name = "crv_FechaFin"
            Me.crv_FechaFin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.crv_FechaFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Dias
            '
            Me.Dias.HeaderText = "Dias"
            Me.Dias.Name = "Dias"
            Me.Dias.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.Dias.Width = 50
            '
            'Domingo
            '
            Me.Domingo.HeaderText = "Domingo"
            Me.Domingo.Name = "Domingo"
            Me.Domingo.Width = 50
            '
            'crv_periodoAsignado
            '
            Me.crv_periodoAsignado.HeaderText = "Mes"
            Me.crv_periodoAsignado.Name = "crv_periodoAsignado"
            Me.crv_periodoAsignado.Width = 50
            '
            'crv_Periodo
            '
            Me.crv_Periodo.HeaderText = "Periodo Vac."
            Me.crv_Periodo.Name = "crv_Periodo"
            '
            'crv_Observaciones
            '
            Me.crv_Observaciones.HeaderText = "Observaciones"
            Me.crv_Observaciones.Name = "crv_Observaciones"
            '
            'crv_Estado
            '
            Me.crv_Estado.HeaderText = "Estado"
            Me.crv_Estado.Name = "crv_Estado"
            '
            'tdo_Id
            '
            Me.tdo_Id.HeaderText = "tdo"
            Me.tdo_Id.Name = "tdo_Id"
            Me.tdo_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.tdo_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'pla_SeriePlani
            '
            Me.pla_SeriePlani.HeaderText = "Serie"
            Me.pla_SeriePlani.Name = "pla_SeriePlani"
            Me.pla_SeriePlani.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'pla_Numero
            '
            Me.pla_Numero.HeaderText = "Numero"
            Me.pla_Numero.Name = "pla_Numero"
            Me.pla_Numero.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'TabPage5
            '
            Me.TabPage5.Controls.Add(Me.dataPeriodoLaboral)
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage5.Size = New System.Drawing.Size(609, 326)
            Me.TabPage5.TabIndex = 4
            Me.TabPage5.Text = "Periodos Laboral"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'dataPeriodoLaboral
            '
            Me.dataPeriodoLaboral.AllowUserToAddRows = False
            Me.dataPeriodoLaboral.AllowUserToDeleteRows = False
            Me.dataPeriodoLaboral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataPeriodoLaboral.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn1, Me.Column1, Me.TipoContrato, Me.Contrato})
            Me.dataPeriodoLaboral.Location = New System.Drawing.Point(6, 6)
            Me.dataPeriodoLaboral.Name = "dataPeriodoLaboral"
            Me.dataPeriodoLaboral.Size = New System.Drawing.Size(586, 314)
            Me.dataPeriodoLaboral.TabIndex = 1
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha Inicio"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha Fin"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Observaciones"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewCheckBoxColumn1
            '
            Me.DataGridViewCheckBoxColumn1.HeaderText = "Periodo Activo"
            Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
            '
            'Column1
            '
            Me.Column1.HeaderText = "Es Liquidacion"
            Me.Column1.Name = "Column1"
            Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'TipoContrato
            '
            Me.TipoContrato.HeaderText = "Tipo Contrato"
            Me.TipoContrato.Name = "TipoContrato"
            '
            'Contrato
            '
            Me.Contrato.HeaderText = "Contrato"
            Me.Contrato.Name = "Contrato"
            Me.Contrato.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Contrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'TabPage6
            '
            Me.TabPage6.Controls.Add(Me.dgvHorarioTrabajo)
            Me.TabPage6.Controls.Add(Me.Panel4)
            Me.TabPage6.Location = New System.Drawing.Point(4, 22)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage6.Size = New System.Drawing.Size(609, 326)
            Me.TabPage6.TabIndex = 5
            Me.TabPage6.Text = "Horario"
            Me.TabPage6.UseVisualStyleBackColor = True
            '
            'dgvHorarioTrabajo
            '
            Me.dgvHorarioTrabajo.AllowUserToAddRows = False
            Me.dgvHorarioTrabajo.AllowUserToDeleteRows = False
            Me.dgvHorarioTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvHorarioTrabajo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dah_item, Me.Dia, Me.dah_Ingreso, Me.dah_Salida, Me.dah_Observaciones, Me.dah_estado})
            Me.dgvHorarioTrabajo.Location = New System.Drawing.Point(10, 49)
            Me.dgvHorarioTrabajo.Name = "dgvHorarioTrabajo"
            Me.dgvHorarioTrabajo.Size = New System.Drawing.Size(581, 271)
            Me.dgvHorarioTrabajo.TabIndex = 1
            '
            'dah_item
            '
            Me.dah_item.HeaderText = "Item"
            Me.dah_item.Name = "dah_item"
            Me.dah_item.Width = 40
            '
            'Dia
            '
            Me.Dia.HeaderText = "Dia"
            Me.Dia.Name = "Dia"
            '
            'dah_Ingreso
            '
            Me.dah_Ingreso.HeaderText = "Hora Ingreso"
            Me.dah_Ingreso.Name = "dah_Ingreso"
            '
            'dah_Salida
            '
            Me.dah_Salida.HeaderText = "Hora Salida"
            Me.dah_Salida.Name = "dah_Salida"
            '
            'dah_Observaciones
            '
            Me.dah_Observaciones.HeaderText = "Observaciones"
            Me.dah_Observaciones.Name = "dah_Observaciones"
            '
            'dah_estado
            '
            Me.dah_estado.HeaderText = "Estado"
            Me.dah_estado.Name = "dah_estado"
            Me.dah_estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dah_estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Panel4
            '
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.txtHorasFijas)
            Me.Panel4.Controls.Add(Me.Label31)
            Me.Panel4.Controls.Add(Me.txtHoraRefregerio)
            Me.Panel4.Controls.Add(Me.Label30)
            Me.Panel4.Controls.Add(Me.txtHorasMes)
            Me.Panel4.Controls.Add(Me.Label29)
            Me.Panel4.Location = New System.Drawing.Point(10, 6)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(581, 39)
            Me.Panel4.TabIndex = 0
            '
            'txtHorasFijas
            '
            Me.txtHorasFijas.Location = New System.Drawing.Point(257, 8)
            Me.txtHorasFijas.Name = "txtHorasFijas"
            Me.txtHorasFijas.Size = New System.Drawing.Size(49, 20)
            Me.txtHorasFijas.TabIndex = 5
            Me.txtHorasFijas.Text = "0.0"
            '
            'Label31
            '
            Me.Label31.AutoSize = True
            Me.Label31.Location = New System.Drawing.Point(142, 11)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(59, 13)
            Me.Label31.TabIndex = 4
            Me.Label31.Text = "Horas Fijas"
            '
            'txtHoraRefregerio
            '
            Me.txtHoraRefregerio.Location = New System.Drawing.Point(445, 8)
            Me.txtHoraRefregerio.Name = "txtHoraRefregerio"
            Me.txtHoraRefregerio.Size = New System.Drawing.Size(39, 20)
            Me.txtHoraRefregerio.TabIndex = 3
            Me.txtHoraRefregerio.Text = "0.00"
            '
            'Label30
            '
            Me.Label30.AutoSize = True
            Me.Label30.Location = New System.Drawing.Point(361, 11)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(78, 13)
            Me.Label30.TabIndex = 2
            Me.Label30.Text = "Hora Refrigerio"
            '
            'txtHorasMes
            '
            Me.txtHorasMes.Location = New System.Drawing.Point(80, 9)
            Me.txtHorasMes.Name = "txtHorasMes"
            Me.txtHorasMes.Size = New System.Drawing.Size(49, 20)
            Me.txtHorasMes.TabIndex = 1
            Me.txtHorasMes.Text = "0.0"
            '
            'Label29
            '
            Me.Label29.AutoSize = True
            Me.Label29.Location = New System.Drawing.Point(3, 12)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(71, 13)
            Me.Label29.TabIndex = 0
            Me.Label29.Text = "Horas  al mes"
            '
            'TabPage7
            '
            Me.TabPage7.Controls.Add(Me.TabControl2)
            Me.TabPage7.Location = New System.Drawing.Point(4, 22)
            Me.TabPage7.Name = "TabPage7"
            Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage7.Size = New System.Drawing.Size(609, 326)
            Me.TabPage7.TabIndex = 6
            Me.TabPage7.Text = "Otros Datos"
            Me.TabPage7.UseVisualStyleBackColor = True
            '
            'TabControl2
            '
            Me.TabControl2.Controls.Add(Me.TabPage8)
            Me.TabControl2.Controls.Add(Me.TabPage9)
            Me.TabControl2.Controls.Add(Me.TabPage10)
            Me.TabControl2.Location = New System.Drawing.Point(7, 8)
            Me.TabControl2.Name = "TabControl2"
            Me.TabControl2.SelectedIndex = 0
            Me.TabControl2.Size = New System.Drawing.Size(596, 312)
            Me.TabControl2.TabIndex = 0
            '
            'TabPage8
            '
            Me.TabPage8.Controls.Add(Me.txtAlergias)
            Me.TabPage8.Controls.Add(Me.Label43)
            Me.TabPage8.Controls.Add(Me.txtEnfermedad)
            Me.TabPage8.Controls.Add(Me.Label42)
            Me.TabPage8.Controls.Add(Me.txtDetalleAntecedentesPolic)
            Me.TabPage8.Controls.Add(Me.txtEncasoEmergencia)
            Me.TabPage8.Controls.Add(Me.Label38)
            Me.TabPage8.Controls.Add(Me.chkAntecedentesPoliciales)
            Me.TabPage8.Controls.Add(Me.txtCelular)
            Me.TabPage8.Controls.Add(Me.Label37)
            Me.TabPage8.Controls.Add(Me.txtTelefonoFijo)
            Me.TabPage8.Controls.Add(Me.Label36)
            Me.TabPage8.Controls.Add(Me.txtLugarNacimiento)
            Me.TabPage8.Controls.Add(Me.Label33)
            Me.TabPage8.Location = New System.Drawing.Point(4, 22)
            Me.TabPage8.Name = "TabPage8"
            Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage8.Size = New System.Drawing.Size(588, 286)
            Me.TabPage8.TabIndex = 0
            Me.TabPage8.Text = "Otros Datos"
            Me.TabPage8.UseVisualStyleBackColor = True
            '
            'txtAlergias
            '
            Me.txtAlergias.Location = New System.Drawing.Point(126, 224)
            Me.txtAlergias.Multiline = True
            Me.txtAlergias.Name = "txtAlergias"
            Me.txtAlergias.Size = New System.Drawing.Size(305, 43)
            Me.txtAlergias.TabIndex = 27
            '
            'Label43
            '
            Me.Label43.AutoSize = True
            Me.Label43.Location = New System.Drawing.Point(76, 224)
            Me.Label43.Name = "Label43"
            Me.Label43.Size = New System.Drawing.Size(44, 13)
            Me.Label43.TabIndex = 26
            Me.Label43.Text = "Alergias"
            '
            'txtEnfermedad
            '
            Me.txtEnfermedad.Location = New System.Drawing.Point(126, 175)
            Me.txtEnfermedad.Multiline = True
            Me.txtEnfermedad.Name = "txtEnfermedad"
            Me.txtEnfermedad.Size = New System.Drawing.Size(305, 43)
            Me.txtEnfermedad.TabIndex = 25
            '
            'Label42
            '
            Me.Label42.AutoSize = True
            Me.Label42.Location = New System.Drawing.Point(1, 179)
            Me.Label42.Name = "Label42"
            Me.Label42.Size = New System.Drawing.Size(127, 13)
            Me.Label42.TabIndex = 24
            Me.Label42.Text = "Enfermedad/Tratamienos"
            '
            'txtDetalleAntecedentesPolic
            '
            Me.txtDetalleAntecedentesPolic.Location = New System.Drawing.Point(126, 124)
            Me.txtDetalleAntecedentesPolic.Multiline = True
            Me.txtDetalleAntecedentesPolic.Name = "txtDetalleAntecedentesPolic"
            Me.txtDetalleAntecedentesPolic.Size = New System.Drawing.Size(447, 48)
            Me.txtDetalleAntecedentesPolic.TabIndex = 23
            '
            'txtEncasoEmergencia
            '
            Me.txtEncasoEmergencia.Location = New System.Drawing.Point(126, 59)
            Me.txtEncasoEmergencia.Multiline = True
            Me.txtEncasoEmergencia.Name = "txtEncasoEmergencia"
            Me.txtEncasoEmergencia.Size = New System.Drawing.Size(447, 39)
            Me.txtEncasoEmergencia.TabIndex = 21
            '
            'Label38
            '
            Me.Label38.AutoSize = True
            Me.Label38.Location = New System.Drawing.Point(6, 61)
            Me.Label38.Name = "Label38"
            Me.Label38.Size = New System.Drawing.Size(122, 13)
            Me.Label38.TabIndex = 20
            Me.Label38.Text = "En caso de emergencia "
            '
            'chkAntecedentesPoliciales
            '
            Me.chkAntecedentesPoliciales.AutoSize = True
            Me.chkAntecedentesPoliciales.Location = New System.Drawing.Point(126, 105)
            Me.chkAntecedentesPoliciales.Name = "chkAntecedentesPoliciales"
            Me.chkAntecedentesPoliciales.Size = New System.Drawing.Size(189, 17)
            Me.chkAntecedentesPoliciales.TabIndex = 22
            Me.chkAntecedentesPoliciales.Text = "Antecedentes Panales o Policiales"
            Me.chkAntecedentesPoliciales.UseVisualStyleBackColor = True
            '
            'txtCelular
            '
            Me.txtCelular.Location = New System.Drawing.Point(402, 34)
            Me.txtCelular.Name = "txtCelular"
            Me.txtCelular.Size = New System.Drawing.Size(171, 20)
            Me.txtCelular.TabIndex = 19
            '
            'Label37
            '
            Me.Label37.AutoSize = True
            Me.Label37.Location = New System.Drawing.Point(337, 37)
            Me.Label37.Name = "Label37"
            Me.Label37.Size = New System.Drawing.Size(39, 13)
            Me.Label37.TabIndex = 18
            Me.Label37.Text = "Celular"
            '
            'txtTelefonoFijo
            '
            Me.txtTelefonoFijo.Location = New System.Drawing.Point(126, 34)
            Me.txtTelefonoFijo.Name = "txtTelefonoFijo"
            Me.txtTelefonoFijo.Size = New System.Drawing.Size(173, 20)
            Me.txtTelefonoFijo.TabIndex = 17
            '
            'Label36
            '
            Me.Label36.AutoSize = True
            Me.Label36.Location = New System.Drawing.Point(55, 37)
            Me.Label36.Name = "Label36"
            Me.Label36.Size = New System.Drawing.Size(65, 13)
            Me.Label36.TabIndex = 16
            Me.Label36.Text = "Telefono fijo"
            '
            'txtLugarNacimiento
            '
            Me.txtLugarNacimiento.Location = New System.Drawing.Point(126, 11)
            Me.txtLugarNacimiento.Name = "txtLugarNacimiento"
            Me.txtLugarNacimiento.Size = New System.Drawing.Size(447, 20)
            Me.txtLugarNacimiento.TabIndex = 15
            '
            'Label33
            '
            Me.Label33.AutoSize = True
            Me.Label33.Location = New System.Drawing.Point(20, 14)
            Me.Label33.Name = "Label33"
            Me.Label33.Size = New System.Drawing.Size(105, 13)
            Me.Label33.TabIndex = 14
            Me.Label33.Text = "Lugar de Nacimiento"
            '
            'TabPage9
            '
            Me.TabPage9.Controls.Add(Me.txtNumeroHijos)
            Me.TabPage9.Controls.Add(Me.Label41)
            Me.TabPage9.Controls.Add(Me.DataGridView1)
            Me.TabPage9.Controls.Add(Me.Label39)
            Me.TabPage9.Location = New System.Drawing.Point(4, 22)
            Me.TabPage9.Name = "TabPage9"
            Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage9.Size = New System.Drawing.Size(588, 286)
            Me.TabPage9.TabIndex = 1
            Me.TabPage9.Text = "Datos de la Familia"
            Me.TabPage9.UseVisualStyleBackColor = True
            '
            'txtNumeroHijos
            '
            Me.txtNumeroHijos.Location = New System.Drawing.Point(93, 10)
            Me.txtNumeroHijos.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.txtNumeroHijos.Name = "txtNumeroHijos"
            Me.txtNumeroHijos.Size = New System.Drawing.Size(45, 20)
            Me.txtNumeroHijos.TabIndex = 29
            '
            'Label41
            '
            Me.Label41.AutoSize = True
            Me.Label41.Location = New System.Drawing.Point(6, 13)
            Me.Label41.Name = "Label41"
            Me.Label41.Size = New System.Drawing.Size(85, 13)
            Me.Label41.TabIndex = 28
            Me.Label41.Text = "Numero de Hijos"
            '
            'DataGridView1
            '
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Location = New System.Drawing.Point(6, 55)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.Size = New System.Drawing.Size(571, 224)
            Me.DataGridView1.TabIndex = 27
            '
            'Label39
            '
            Me.Label39.AutoSize = True
            Me.Label39.Location = New System.Drawing.Point(8, 37)
            Me.Label39.Name = "Label39"
            Me.Label39.Size = New System.Drawing.Size(84, 13)
            Me.Label39.TabIndex = 26
            Me.Label39.Text = "Datos Familiares"
            '
            'TabPage10
            '
            Me.TabPage10.Controls.Add(Me.DataGridView2)
            Me.TabPage10.Controls.Add(Me.Label40)
            Me.TabPage10.Location = New System.Drawing.Point(4, 22)
            Me.TabPage10.Name = "TabPage10"
            Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage10.Size = New System.Drawing.Size(588, 286)
            Me.TabPage10.TabIndex = 2
            Me.TabPage10.Text = "Empleos Anteriores"
            Me.TabPage10.UseVisualStyleBackColor = True
            '
            'DataGridView2
            '
            Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView2.Location = New System.Drawing.Point(6, 27)
            Me.DataGridView2.Name = "DataGridView2"
            Me.DataGridView2.Size = New System.Drawing.Size(571, 233)
            Me.DataGridView2.TabIndex = 29
            '
            'Label40
            '
            Me.Label40.AutoSize = True
            Me.Label40.Location = New System.Drawing.Point(3, 11)
            Me.Label40.Name = "Label40"
            Me.Label40.Size = New System.Drawing.Size(97, 13)
            Me.Label40.TabIndex = 28
            Me.Label40.Text = "Empleos Anteriores"
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.txtDistrito)
            Me.Panel2.Controls.Add(Me.Label35)
            Me.Panel2.Controls.Add(Me.txtDireccion)
            Me.Panel2.Controls.Add(Me.Label34)
            Me.Panel2.Controls.Add(Me.btnBorrarImagen)
            Me.Panel2.Controls.Add(Me.btnImagen)
            Me.Panel2.Controls.Add(Me.PictureImagen)
            Me.Panel2.Controls.Add(Me.txtDni)
            Me.Panel2.Controls.Add(Me.Label32)
            Me.Panel2.Controls.Add(Me.txtPersona)
            Me.Panel2.Controls.Add(Me.Label13)
            Me.Panel2.Controls.Add(Me.btnPersona)
            Me.Panel2.Location = New System.Drawing.Point(8, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(626, 144)
            Me.Panel2.TabIndex = 1
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(229, 71)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(24, 23)
            Me.Button1.TabIndex = 50
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'txtDistrito
            '
            Me.txtDistrito.Enabled = False
            Me.txtDistrito.Location = New System.Drawing.Point(65, 72)
            Me.txtDistrito.Name = "txtDistrito"
            Me.txtDistrito.Size = New System.Drawing.Size(160, 20)
            Me.txtDistrito.TabIndex = 49
            '
            'Label35
            '
            Me.Label35.AutoSize = True
            Me.Label35.Location = New System.Drawing.Point(20, 75)
            Me.Label35.Name = "Label35"
            Me.Label35.Size = New System.Drawing.Size(39, 13)
            Me.Label35.TabIndex = 48
            Me.Label35.Text = "Distrito"
            '
            'txtDireccion
            '
            Me.txtDireccion.Enabled = False
            Me.txtDireccion.Location = New System.Drawing.Point(65, 49)
            Me.txtDireccion.Name = "txtDireccion"
            Me.txtDireccion.Size = New System.Drawing.Size(315, 20)
            Me.txtDireccion.TabIndex = 47
            '
            'Label34
            '
            Me.Label34.AutoSize = True
            Me.Label34.Location = New System.Drawing.Point(10, 52)
            Me.Label34.Name = "Label34"
            Me.Label34.Size = New System.Drawing.Size(52, 13)
            Me.Label34.TabIndex = 46
            Me.Label34.Text = "Direccion"
            '
            'btnBorrarImagen
            '
            Me.btnBorrarImagen.Location = New System.Drawing.Point(359, 116)
            Me.btnBorrarImagen.Name = "btnBorrarImagen"
            Me.btnBorrarImagen.Size = New System.Drawing.Size(107, 23)
            Me.btnBorrarImagen.TabIndex = 45
            Me.btnBorrarImagen.Text = "Borrar Imagen"
            Me.btnBorrarImagen.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Location = New System.Drawing.Point(359, 94)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(107, 23)
            Me.btnImagen.TabIndex = 44
            Me.btnImagen.Text = "Obtener Imagen"
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'PictureImagen
            '
            Me.PictureImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureImagen.Location = New System.Drawing.Point(472, 3)
            Me.PictureImagen.Name = "PictureImagen"
            Me.PictureImagen.Size = New System.Drawing.Size(145, 136)
            Me.PictureImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureImagen.TabIndex = 43
            Me.PictureImagen.TabStop = False
            '
            'txtDni
            '
            Me.txtDni.Location = New System.Drawing.Point(65, 27)
            Me.txtDni.Name = "txtDni"
            Me.txtDni.ReadOnly = True
            Me.txtDni.Size = New System.Drawing.Size(100, 20)
            Me.txtDni.TabIndex = 42
            '
            'Label32
            '
            Me.Label32.AutoSize = True
            Me.Label32.Location = New System.Drawing.Point(36, 30)
            Me.Label32.Name = "Label32"
            Me.Label32.Size = New System.Drawing.Size(26, 13)
            Me.Label32.TabIndex = 41
            Me.Label32.Text = "DNI"
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(65, 4)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(277, 20)
            Me.txtPersona.TabIndex = 10
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(15, 7)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(44, 13)
            Me.Label13.TabIndex = 9
            Me.Label13.Text = "Nombre"
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(348, 2)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(32, 23)
            Me.btnPersona.TabIndex = 8
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDatosLaborales
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(655, 598)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmDatosLaborales"
            Me.Text = "frmDatosLaborales"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage2.PerformLayout()
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout()
            Me.TabPage4.ResumeLayout(False)
            CType(Me.dataCronograma, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage5.ResumeLayout(False)
            CType(Me.dataPeriodoLaboral, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage6.ResumeLayout(False)
            CType(Me.dgvHorarioTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.TabPage7.ResumeLayout(False)
            Me.TabControl2.ResumeLayout(False)
            Me.TabPage8.ResumeLayout(False)
            Me.TabPage8.PerformLayout()
            Me.TabPage9.ResumeLayout(False)
            Me.TabPage9.PerformLayout()
            CType(Me.txtNumeroHijos, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage10.ResumeLayout(False)
            Me.TabPage10.PerformLayout()
            CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.PictureImagen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents txtAutoGeneradoEssalud As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dateFechaInscripReg As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnRegimenPensionario As System.Windows.Forms.Button
        Friend WithEvents txtRegimenPensionario As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnCentroCosto As System.Windows.Forms.Button
        Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnNivelEducacion As System.Windows.Forms.Button
        Friend WithEvents txtNivelEducacion As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateFechaNacimiento As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtBancoCTS As System.Windows.Forms.TextBox
        Friend WithEvents btnCuentaCTS As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtBancoRenumeracion As System.Windows.Forms.TextBox
        Friend WithEvents btnBancoRenumeracio As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCargo As System.Windows.Forms.Button
        Friend WithEvents txtCargo As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents btnTipoTrabajador As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtCussp As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents txtRegimenLaboral As System.Windows.Forms.TextBox
        Friend WithEvents btnRegimenLaboral As System.Windows.Forms.Button
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtDobleTributacion As System.Windows.Forms.TextBox
        Friend WithEvents btnDobleTributacion As System.Windows.Forms.Button
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodisidad As System.Windows.Forms.TextBox
        Friend WithEvents btnPeriodisidad As System.Windows.Forms.Button
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtAreaTrabajo As System.Windows.Forms.TextBox
        Friend WithEvents btnAreaTrabajo As System.Windows.Forms.Button
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtSituacionEspecial As System.Windows.Forms.TextBox
        Friend WithEvents txtSituacionTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents btnSituacionEspecial As System.Windows.Forms.Button
        Friend WithEvents btnSituacionTrabajador As System.Windows.Forms.Button
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents chkestaEnPLanillas As System.Windows.Forms.CheckBox
        Friend WithEvents chkEsPDT As System.Windows.Forms.CheckBox
        Friend WithEvents chkAsignacionFaniliar As System.Windows.Forms.CheckBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents txtTipoContrato As System.Windows.Forms.TextBox
        Friend WithEvents btnTipoContrato As System.Windows.Forms.Button
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroCuentaCTS As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroCuentaRenumeraciones As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents dataCronograma As System.Windows.Forms.DataGridView
        Friend WithEvents chkRentaQuinta As System.Windows.Forms.CheckBox
        Friend WithEvents txtCentroRiesgo As System.Windows.Forms.TextBox
        Friend WithEvents btnCentroRiesgo As System.Windows.Forms.Button
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents dateFechaIngreso As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboEstadoCivil As System.Windows.Forms.ComboBox
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents dateFechaCese As System.Windows.Forms.MaskedTextBox
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents dataPeriodoLaboral As System.Windows.Forms.DataGridView
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As ColumnaCalendario
        Friend WithEvents DataGridViewTextBoxColumn3 As ColumnaCalendario
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents TipoContrato As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Contrato As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents dgvHorarioTrabajo As System.Windows.Forms.DataGridView
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents txtHoraRefregerio As System.Windows.Forms.TextBox
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents txtHorasMes As System.Windows.Forms.TextBox
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents txtHorasFijas As System.Windows.Forms.TextBox
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents dah_item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Dia As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dah_Ingreso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dah_Salida As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dah_Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dah_estado As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents txtDni As System.Windows.Forms.TextBox
        Friend WithEvents Label32 As System.Windows.Forms.Label
        Friend WithEvents PictureImagen As System.Windows.Forms.PictureBox
        Friend WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents btnBorrarImagen As System.Windows.Forms.Button
        Friend WithEvents chkTareoPll As System.Windows.Forms.CheckBox
        Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtDistrito As System.Windows.Forms.TextBox
        Friend WithEvents Label35 As System.Windows.Forms.Label
        Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
        Friend WithEvents Label34 As System.Windows.Forms.Label
        Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
        Friend WithEvents txtDetalleAntecedentesPolic As System.Windows.Forms.TextBox
        Friend WithEvents chkAntecedentesPoliciales As System.Windows.Forms.CheckBox
        Friend WithEvents txtEncasoEmergencia As System.Windows.Forms.TextBox
        Friend WithEvents Label38 As System.Windows.Forms.Label
        Friend WithEvents txtCelular As System.Windows.Forms.TextBox
        Friend WithEvents Label37 As System.Windows.Forms.Label
        Friend WithEvents txtTelefonoFijo As System.Windows.Forms.TextBox
        Friend WithEvents Label36 As System.Windows.Forms.Label
        Friend WithEvents txtLugarNacimiento As System.Windows.Forms.TextBox
        Friend WithEvents Label33 As System.Windows.Forms.Label
        Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents Label39 As System.Windows.Forms.Label
        Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
        Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
        Friend WithEvents Label40 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroHijos As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label41 As System.Windows.Forms.Label
        Friend WithEvents txtAlergias As System.Windows.Forms.TextBox
        Friend WithEvents Label43 As System.Windows.Forms.Label
        Friend WithEvents txtEnfermedad As System.Windows.Forms.TextBox
        Friend WithEvents Label42 As System.Windows.Forms.Label
        Friend WithEvents crv_ItemCroVaca As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents crv_FechaInicio As ColumnaCalendario
        Friend WithEvents crv_FechaFin As ColumnaCalendario
        Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Domingo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents crv_periodoAsignado As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents crv_Periodo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents crv_Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents crv_Estado As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents tdo_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents pla_SeriePlani As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pla_Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
