Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPlanilla
        Inherits ViewManMasterPlanillas
        ' Inherits System.Windows.Forms.Form

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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.pbarBarra = New System.Windows.Forms.ProgressBar()
            Me.chkCalculoDias = New System.Windows.Forms.CheckBox()
            Me.Panel8 = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtPeriodoHastaDias = New System.Windows.Forms.TextBox()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.txtPeriodoDesdeDias = New System.Windows.Forms.TextBox()
            Me.Panel7 = New System.Windows.Forms.Panel()
            Me.btnPeriodoHasta = New System.Windows.Forms.Button()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtPeriodoHasta = New System.Windows.Forms.TextBox()
            Me.btnPeriodoDesde = New System.Windows.Forms.Button()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtPeriodoDesde = New System.Windows.Forms.TextBox()
            Me.rdbPeriodoEspesifico = New System.Windows.Forms.RadioButton()
            Me.rdbPeriodoLiquidacion = New System.Windows.Forms.RadioButton()
            Me.rdbPeriodoActual = New System.Windows.Forms.RadioButton()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.TabPlanillas = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.dgvHoraPersonal = New System.Windows.Forms.DataGridView()
            Me.TipoTrabajador = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnQuitarHora = New System.Windows.Forms.Button()
            Me.btnAgregarHora = New System.Windows.Forms.Button()
            Me.txtObservacionesHora = New System.Windows.Forms.TextBox()
            Me.btnTrabajadorHora = New System.Windows.Forms.Button()
            Me.txtNumeroHora = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtTipotrabajadroHora = New System.Windows.Forms.TextBox()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.dgvComedor = New System.Windows.Forms.DataGridView()
            Me.Comedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Observaciones_Comedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnQuitarComedor = New System.Windows.Forms.Button()
            Me.btnAgregarComedor = New System.Windows.Forms.Button()
            Me.txtDescripcionComedor = New System.Windows.Forms.TextBox()
            Me.btnBuscarComedor = New System.Windows.Forms.Button()
            Me.txtNumeroComedor = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.dgvDescuentoJudicial = New System.Windows.Forms.DataGridView()
            Me.Marca = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.per_IdTrab = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CodigoTrabajador = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Trabajadro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Porcentaje = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Inicia = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Finaliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BHeneficiario = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.lblTrabajador = New System.Windows.Forms.Label()
            Me.btnPagosYPrestamos = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage7 = New System.Windows.Forms.TabPage()
            Me.dgvPagosPrestamos = New System.Windows.Forms.DataGridView()
            Me.TabPage8 = New System.Windows.Forms.TabPage()
            Me.dgvDatosPrestamos = New System.Windows.Forms.DataGridView()
            Me.dgvPrestamos = New System.Windows.Forms.DataGridView()
            Me.Marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tit_TipoTrab = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CCT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.chkLista = New System.Windows.Forms.CheckedListBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.chkMarcarPersonas = New System.Windows.Forms.CheckBox()
            Me.dgvSeleccionPersonas = New System.Windows.Forms.DataGridView()
            Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcionn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.prd_Periodo_idInicialIngresos = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.prd_Periodo_idFinalIngresos = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.prd_Periodo_idInicialDias = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.prd_Periodo_idFinalDias = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.cco_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tis_TipCargo_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_RegiPension_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.art_AreaTrab_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rel_RegLaboral_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.plt_NuemroDeCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ccc_IdCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.plt_CodigoTrabajador = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tit_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.TabPage6 = New System.Windows.Forms.TabPage()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.txtCodigoBuscar = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.lblSumar = New System.Windows.Forms.Label()
            Me.txtSumaPLL = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dgvResultadoCalculoPL = New System.Windows.Forms.DataGridView()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnInicio = New System.Windows.Forms.Button()
            Me.btnSiguiente = New System.Windows.Forms.Button()
            Me.txtTipoPlanilla = New System.Windows.Forms.TextBox()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.btnPlanilla = New System.Windows.Forms.Button()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtPlanilla = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
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
            Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            Me.Panel1.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.Panel8.SuspendLayout()
            Me.Panel7.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.TabPlanillas.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.dgvHoraPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.TabPage5.SuspendLayout()
            CType(Me.dgvComedor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.dgvDescuentoJudicial, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage7.SuspendLayout()
            CType(Me.dgvPagosPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage8.SuspendLayout()
            CType(Me.dgvDatosPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.dgvSeleccionPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage6.SuspendLayout()
            CType(Me.dgvResultadoCalculoPL, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(1069, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Panel6)
            Me.Panel1.Controls.Add(Me.Panel5)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1058, 490)
            Me.Panel1.TabIndex = 2
            '
            'Panel6
            '
            Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel6.Controls.Add(Me.pbarBarra)
            Me.Panel6.Controls.Add(Me.chkCalculoDias)
            Me.Panel6.Controls.Add(Me.Panel8)
            Me.Panel6.Controls.Add(Me.Panel7)
            Me.Panel6.Controls.Add(Me.rdbPeriodoEspesifico)
            Me.Panel6.Controls.Add(Me.rdbPeriodoLiquidacion)
            Me.Panel6.Controls.Add(Me.rdbPeriodoActual)
            Me.Panel6.Controls.Add(Me.Label17)
            Me.Panel6.Location = New System.Drawing.Point(4, 93)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(1049, 69)
            Me.Panel6.TabIndex = 3
            '
            'pbarBarra
            '
            Me.pbarBarra.Location = New System.Drawing.Point(7, 40)
            Me.pbarBarra.Name = "pbarBarra"
            Me.pbarBarra.Size = New System.Drawing.Size(264, 24)
            Me.pbarBarra.Step = 1
            Me.pbarBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pbarBarra.TabIndex = 2
            '
            'chkCalculoDias
            '
            Me.chkCalculoDias.AutoSize = True
            Me.chkCalculoDias.Location = New System.Drawing.Point(296, 43)
            Me.chkCalculoDias.Name = "chkCalculoDias"
            Me.chkCalculoDias.Size = New System.Drawing.Size(85, 17)
            Me.chkCalculoDias.TabIndex = 24
            Me.chkCalculoDias.Text = "Calculo Dias"
            Me.chkCalculoDias.UseVisualStyleBackColor = True
            '
            'Panel8
            '
            Me.Panel8.Controls.Add(Me.Button1)
            Me.Panel8.Controls.Add(Me.Label22)
            Me.Panel8.Controls.Add(Me.txtPeriodoHastaDias)
            Me.Panel8.Controls.Add(Me.Button2)
            Me.Panel8.Controls.Add(Me.Label23)
            Me.Panel8.Controls.Add(Me.txtPeriodoDesdeDias)
            Me.Panel8.Location = New System.Drawing.Point(481, 35)
            Me.Panel8.Name = "Panel8"
            Me.Panel8.Size = New System.Drawing.Size(447, 29)
            Me.Panel8.TabIndex = 23
            Me.Panel8.Visible = False
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(394, 3)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(26, 23)
            Me.Button1.TabIndex = 22
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(218, 9)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(85, 13)
            Me.Label22.TabIndex = 21
            Me.Label22.Text = "Hasta el Periodo"
            '
            'txtPeriodoHastaDias
            '
            Me.txtPeriodoHastaDias.Location = New System.Drawing.Point(306, 5)
            Me.txtPeriodoHastaDias.Name = "txtPeriodoHastaDias"
            Me.txtPeriodoHastaDias.ReadOnly = True
            Me.txtPeriodoHastaDias.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoHastaDias.TabIndex = 20
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(186, 3)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(26, 23)
            Me.Button2.TabIndex = 19
            Me.Button2.Text = ":::"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Location = New System.Drawing.Point(5, 8)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(88, 13)
            Me.Label23.TabIndex = 18
            Me.Label23.Text = "Desde el Periodo"
            '
            'txtPeriodoDesdeDias
            '
            Me.txtPeriodoDesdeDias.Location = New System.Drawing.Point(98, 5)
            Me.txtPeriodoDesdeDias.Name = "txtPeriodoDesdeDias"
            Me.txtPeriodoDesdeDias.ReadOnly = True
            Me.txtPeriodoDesdeDias.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoDesdeDias.TabIndex = 17
            '
            'Panel7
            '
            Me.Panel7.Controls.Add(Me.btnPeriodoHasta)
            Me.Panel7.Controls.Add(Me.Label19)
            Me.Panel7.Controls.Add(Me.txtPeriodoHasta)
            Me.Panel7.Controls.Add(Me.btnPeriodoDesde)
            Me.Panel7.Controls.Add(Me.Label18)
            Me.Panel7.Controls.Add(Me.txtPeriodoDesde)
            Me.Panel7.Location = New System.Drawing.Point(481, 3)
            Me.Panel7.Name = "Panel7"
            Me.Panel7.Size = New System.Drawing.Size(447, 29)
            Me.Panel7.TabIndex = 4
            Me.Panel7.Visible = False
            '
            'btnPeriodoHasta
            '
            Me.btnPeriodoHasta.Location = New System.Drawing.Point(394, 3)
            Me.btnPeriodoHasta.Name = "btnPeriodoHasta"
            Me.btnPeriodoHasta.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoHasta.TabIndex = 22
            Me.btnPeriodoHasta.Text = ":::"
            Me.btnPeriodoHasta.UseVisualStyleBackColor = True
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(218, 9)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(85, 13)
            Me.Label19.TabIndex = 21
            Me.Label19.Text = "Hasta el Periodo"
            '
            'txtPeriodoHasta
            '
            Me.txtPeriodoHasta.Location = New System.Drawing.Point(306, 5)
            Me.txtPeriodoHasta.Name = "txtPeriodoHasta"
            Me.txtPeriodoHasta.ReadOnly = True
            Me.txtPeriodoHasta.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoHasta.TabIndex = 20
            '
            'btnPeriodoDesde
            '
            Me.btnPeriodoDesde.Location = New System.Drawing.Point(186, 3)
            Me.btnPeriodoDesde.Name = "btnPeriodoDesde"
            Me.btnPeriodoDesde.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoDesde.TabIndex = 19
            Me.btnPeriodoDesde.Text = ":::"
            Me.btnPeriodoDesde.UseVisualStyleBackColor = True
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(5, 8)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(88, 13)
            Me.Label18.TabIndex = 18
            Me.Label18.Text = "Desde el Periodo"
            '
            'txtPeriodoDesde
            '
            Me.txtPeriodoDesde.Location = New System.Drawing.Point(98, 5)
            Me.txtPeriodoDesde.Name = "txtPeriodoDesde"
            Me.txtPeriodoDesde.ReadOnly = True
            Me.txtPeriodoDesde.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoDesde.TabIndex = 17
            '
            'rdbPeriodoEspesifico
            '
            Me.rdbPeriodoEspesifico.AutoSize = True
            Me.rdbPeriodoEspesifico.Location = New System.Drawing.Point(297, 20)
            Me.rdbPeriodoEspesifico.Name = "rdbPeriodoEspesifico"
            Me.rdbPeriodoEspesifico.Size = New System.Drawing.Size(177, 17)
            Me.rdbPeriodoEspesifico.TabIndex = 3
            Me.rdbPeriodoEspesifico.Text = "Un rango de periodos espesifico"
            Me.rdbPeriodoEspesifico.UseVisualStyleBackColor = True
            '
            'rdbPeriodoLiquidacion
            '
            Me.rdbPeriodoLiquidacion.AutoSize = True
            Me.rdbPeriodoLiquidacion.Location = New System.Drawing.Point(107, 20)
            Me.rdbPeriodoLiquidacion.Name = "rdbPeriodoLiquidacion"
            Me.rdbPeriodoLiquidacion.Size = New System.Drawing.Size(164, 17)
            Me.rdbPeriodoLiquidacion.TabIndex = 2
            Me.rdbPeriodoLiquidacion.Text = "Periodos laborales liquidacion"
            Me.rdbPeriodoLiquidacion.UseVisualStyleBackColor = True
            '
            'rdbPeriodoActual
            '
            Me.rdbPeriodoActual.AutoSize = True
            Me.rdbPeriodoActual.Checked = True
            Me.rdbPeriodoActual.Location = New System.Drawing.Point(7, 20)
            Me.rdbPeriodoActual.Name = "rdbPeriodoActual"
            Me.rdbPeriodoActual.Size = New System.Drawing.Size(94, 17)
            Me.rdbPeriodoActual.TabIndex = 1
            Me.rdbPeriodoActual.TabStop = True
            Me.rdbPeriodoActual.Text = "Periodo Actual"
            Me.rdbPeriodoActual.UseVisualStyleBackColor = True
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(6, 4)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(180, 13)
            Me.Label17.TabIndex = 0
            Me.Label17.Text = "Aplicar formulas de acumulados por :"
            '
            'Panel5
            '
            Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel5.Controls.Add(Me.TabPlanillas)
            Me.Panel5.Location = New System.Drawing.Point(4, 168)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(1049, 317)
            Me.Panel5.TabIndex = 2
            '
            'TabPlanillas
            '
            Me.TabPlanillas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabPlanillas.Controls.Add(Me.TabPage1)
            Me.TabPlanillas.Controls.Add(Me.TabPage5)
            Me.TabPlanillas.Controls.Add(Me.TabPage3)
            Me.TabPlanillas.Controls.Add(Me.TabPage4)
            Me.TabPlanillas.Controls.Add(Me.TabPage2)
            Me.TabPlanillas.Controls.Add(Me.TabPage6)
            Me.TabPlanillas.Location = New System.Drawing.Point(4, 4)
            Me.TabPlanillas.Name = "TabPlanillas"
            Me.TabPlanillas.SelectedIndex = 0
            Me.TabPlanillas.Size = New System.Drawing.Size(1040, 304)
            Me.TabPlanillas.TabIndex = 1
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.dgvHoraPersonal)
            Me.TabPage1.Controls.Add(Me.Panel3)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Horas del Personal"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'dgvHoraPersonal
            '
            Me.dgvHoraPersonal.AllowUserToAddRows = False
            Me.dgvHoraPersonal.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvHoraPersonal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvHoraPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvHoraPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvHoraPersonal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoTrabajador, Me.Numero, Me.Descripcion})
            Me.dgvHoraPersonal.Location = New System.Drawing.Point(7, 49)
            Me.dgvHoraPersonal.Name = "dgvHoraPersonal"
            Me.dgvHoraPersonal.ReadOnly = True
            Me.dgvHoraPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvHoraPersonal.Size = New System.Drawing.Size(1019, 224)
            Me.dgvHoraPersonal.TabIndex = 1
            '
            'TipoTrabajador
            '
            Me.TipoTrabajador.HeaderText = "TipoTrabajador"
            Me.TipoTrabajador.Name = "TipoTrabajador"
            Me.TipoTrabajador.ReadOnly = True
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            Me.Descripcion.Width = 250
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.btnQuitarHora)
            Me.Panel3.Controls.Add(Me.btnAgregarHora)
            Me.Panel3.Controls.Add(Me.txtObservacionesHora)
            Me.Panel3.Controls.Add(Me.btnTrabajadorHora)
            Me.Panel3.Controls.Add(Me.txtNumeroHora)
            Me.Panel3.Controls.Add(Me.Label2)
            Me.Panel3.Controls.Add(Me.txtTipotrabajadroHora)
            Me.Panel3.Location = New System.Drawing.Point(7, 7)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(1019, 35)
            Me.Panel3.TabIndex = 0
            '
            'btnQuitarHora
            '
            Me.btnQuitarHora.Location = New System.Drawing.Point(518, 8)
            Me.btnQuitarHora.Name = "btnQuitarHora"
            Me.btnQuitarHora.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitarHora.TabIndex = 7
            Me.btnQuitarHora.Text = "Quitar"
            Me.btnQuitarHora.UseVisualStyleBackColor = True
            '
            'btnAgregarHora
            '
            Me.btnAgregarHora.Location = New System.Drawing.Point(437, 8)
            Me.btnAgregarHora.Name = "btnAgregarHora"
            Me.btnAgregarHora.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregarHora.TabIndex = 6
            Me.btnAgregarHora.Text = "Agregar"
            Me.btnAgregarHora.UseVisualStyleBackColor = True
            '
            'txtObservacionesHora
            '
            Me.txtObservacionesHora.Location = New System.Drawing.Point(194, 10)
            Me.txtObservacionesHora.Name = "txtObservacionesHora"
            Me.txtObservacionesHora.ReadOnly = True
            Me.txtObservacionesHora.Size = New System.Drawing.Size(212, 20)
            Me.txtObservacionesHora.TabIndex = 5
            '
            'btnTrabajadorHora
            '
            Me.btnTrabajadorHora.Location = New System.Drawing.Point(170, 9)
            Me.btnTrabajadorHora.Name = "btnTrabajadorHora"
            Me.btnTrabajadorHora.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajadorHora.TabIndex = 4
            Me.btnTrabajadorHora.Text = ":::"
            Me.btnTrabajadorHora.UseVisualStyleBackColor = True
            '
            'txtNumeroHora
            '
            Me.txtNumeroHora.Location = New System.Drawing.Point(65, 10)
            Me.txtNumeroHora.Name = "txtNumeroHora"
            Me.txtNumeroHora.ReadOnly = True
            Me.txtNumeroHora.Size = New System.Drawing.Size(100, 20)
            Me.txtNumeroHora.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(14, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(44, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Numero"
            '
            'txtTipotrabajadroHora
            '
            Me.txtTipotrabajadroHora.Location = New System.Drawing.Point(2, 9)
            Me.txtTipotrabajadroHora.Name = "txtTipotrabajadroHora"
            Me.txtTipotrabajadroHora.Size = New System.Drawing.Size(10, 20)
            Me.txtTipotrabajadroHora.TabIndex = 1
            '
            'TabPage5
            '
            Me.TabPage5.Controls.Add(Me.dgvComedor)
            Me.TabPage5.Controls.Add(Me.Panel4)
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage5.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage5.TabIndex = 5
            Me.TabPage5.Text = "Importes x Concepto"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'dgvComedor
            '
            Me.dgvComedor.AllowUserToAddRows = False
            Me.dgvComedor.AllowUserToDeleteRows = False
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvComedor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvComedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvComedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvComedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Comedor, Me.Observaciones_Comedor})
            Me.dgvComedor.Location = New System.Drawing.Point(6, 41)
            Me.dgvComedor.Name = "dgvComedor"
            Me.dgvComedor.Size = New System.Drawing.Size(1025, 237)
            Me.dgvComedor.TabIndex = 1
            '
            'Comedor
            '
            Me.Comedor.HeaderText = "Numero"
            Me.Comedor.Name = "Comedor"
            '
            'Observaciones_Comedor
            '
            Me.Observaciones_Comedor.HeaderText = "Observaciones"
            Me.Observaciones_Comedor.Name = "Observaciones_Comedor"
            Me.Observaciones_Comedor.Width = 250
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.Controls.Add(Me.btnQuitarComedor)
            Me.Panel4.Controls.Add(Me.btnAgregarComedor)
            Me.Panel4.Controls.Add(Me.txtDescripcionComedor)
            Me.Panel4.Controls.Add(Me.btnBuscarComedor)
            Me.Panel4.Controls.Add(Me.txtNumeroComedor)
            Me.Panel4.Controls.Add(Me.Label16)
            Me.Panel4.Location = New System.Drawing.Point(6, 7)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(1025, 31)
            Me.Panel4.TabIndex = 0
            '
            'btnQuitarComedor
            '
            Me.btnQuitarComedor.Location = New System.Drawing.Point(687, 6)
            Me.btnQuitarComedor.Name = "btnQuitarComedor"
            Me.btnQuitarComedor.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitarComedor.TabIndex = 5
            Me.btnQuitarComedor.Text = "Quitar"
            Me.btnQuitarComedor.UseVisualStyleBackColor = True
            '
            'btnAgregarComedor
            '
            Me.btnAgregarComedor.Location = New System.Drawing.Point(605, 7)
            Me.btnAgregarComedor.Name = "btnAgregarComedor"
            Me.btnAgregarComedor.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregarComedor.TabIndex = 4
            Me.btnAgregarComedor.Text = "Agregar"
            Me.btnAgregarComedor.UseVisualStyleBackColor = True
            '
            'txtDescripcionComedor
            '
            Me.txtDescripcionComedor.Location = New System.Drawing.Point(213, 5)
            Me.txtDescripcionComedor.Name = "txtDescripcionComedor"
            Me.txtDescripcionComedor.ReadOnly = True
            Me.txtDescripcionComedor.Size = New System.Drawing.Size(359, 20)
            Me.txtDescripcionComedor.TabIndex = 3
            '
            'btnBuscarComedor
            '
            Me.btnBuscarComedor.Location = New System.Drawing.Point(186, 3)
            Me.btnBuscarComedor.Name = "btnBuscarComedor"
            Me.btnBuscarComedor.Size = New System.Drawing.Size(24, 23)
            Me.btnBuscarComedor.TabIndex = 2
            Me.btnBuscarComedor.Text = ":::"
            Me.btnBuscarComedor.UseVisualStyleBackColor = True
            '
            'txtNumeroComedor
            '
            Me.txtNumeroComedor.Location = New System.Drawing.Point(102, 6)
            Me.txtNumeroComedor.Name = "txtNumeroComedor"
            Me.txtNumeroComedor.ReadOnly = True
            Me.txtNumeroComedor.Size = New System.Drawing.Size(83, 20)
            Me.txtNumeroComedor.TabIndex = 1
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(17, 9)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(44, 13)
            Me.Label16.TabIndex = 0
            Me.Label16.Text = "Numero"
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.dgvDescuentoJudicial)
            Me.TabPage3.Controls.Add(Me.Label13)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Descuentos Judiciales"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'dgvDescuentoJudicial
            '
            Me.dgvDescuentoJudicial.AllowUserToAddRows = False
            Me.dgvDescuentoJudicial.AllowUserToDeleteRows = False
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvDescuentoJudicial.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDescuentoJudicial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDescuentoJudicial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDescuentoJudicial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Marca, Me.per_IdTrab, Me.CodigoTrabajador, Me.Trabajadro, Me.Porcentaje, Me.Importe, Me.Inicia, Me.Finaliza, Me.BHeneficiario})
            Me.dgvDescuentoJudicial.Location = New System.Drawing.Point(4, 39)
            Me.dgvDescuentoJudicial.Name = "dgvDescuentoJudicial"
            Me.dgvDescuentoJudicial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDescuentoJudicial.Size = New System.Drawing.Size(1024, 239)
            Me.dgvDescuentoJudicial.TabIndex = 1
            '
            'Marca
            '
            Me.Marca.HeaderText = "Marca"
            Me.Marca.Name = "Marca"
            '
            'per_IdTrab
            '
            Me.per_IdTrab.HeaderText = "per_IdTrab"
            Me.per_IdTrab.Name = "per_IdTrab"
            Me.per_IdTrab.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_IdTrab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'CodigoTrabajador
            '
            Me.CodigoTrabajador.HeaderText = "CodigoTrabajadro"
            Me.CodigoTrabajador.Name = "CodigoTrabajador"
            Me.CodigoTrabajador.ReadOnly = True
            '
            'Trabajadro
            '
            Me.Trabajadro.HeaderText = "Trabajador"
            Me.Trabajadro.Name = "Trabajadro"
            Me.Trabajadro.ReadOnly = True
            '
            'Porcentaje
            '
            Me.Porcentaje.HeaderText = "Porcentaje"
            Me.Porcentaje.Name = "Porcentaje"
            Me.Porcentaje.ReadOnly = True
            '
            'Importe
            '
            Me.Importe.HeaderText = "Importe"
            Me.Importe.Name = "Importe"
            Me.Importe.ReadOnly = True
            Me.Importe.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Inicia
            '
            Me.Inicia.HeaderText = "Inicia"
            Me.Inicia.Name = "Inicia"
            Me.Inicia.ReadOnly = True
            Me.Inicia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Inicia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Finaliza
            '
            Me.Finaliza.HeaderText = "Finaliza"
            Me.Finaliza.Name = "Finaliza"
            Me.Finaliza.ReadOnly = True
            '
            'BHeneficiario
            '
            Me.BHeneficiario.HeaderText = "Beneficiario"
            Me.BHeneficiario.Name = "BHeneficiario"
            Me.BHeneficiario.ReadOnly = True
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(10, 7)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(261, 13)
            Me.Label13.TabIndex = 0
            Me.Label13.Text = "Descuento Judicial, Segun Lista ""Horas del Personal"""
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.lblTrabajador)
            Me.TabPage4.Controls.Add(Me.btnPagosYPrestamos)
            Me.TabPage4.Controls.Add(Me.TabControl1)
            Me.TabPage4.Controls.Add(Me.dgvPrestamos)
            Me.TabPage4.Controls.Add(Me.Label15)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Prestamos al Personal"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'lblTrabajador
            '
            Me.lblTrabajador.AutoSize = True
            Me.lblTrabajador.Location = New System.Drawing.Point(816, 4)
            Me.lblTrabajador.Name = "lblTrabajador"
            Me.lblTrabajador.Size = New System.Drawing.Size(0, 13)
            Me.lblTrabajador.TabIndex = 4
            '
            'btnPagosYPrestamos
            '
            Me.btnPagosYPrestamos.Location = New System.Drawing.Point(650, 0)
            Me.btnPagosYPrestamos.Name = "btnPagosYPrestamos"
            Me.btnPagosYPrestamos.Size = New System.Drawing.Size(159, 23)
            Me.btnPagosYPrestamos.TabIndex = 3
            Me.btnPagosYPrestamos.Text = "Ver Pagos y datos  Prestamos"
            Me.btnPagosYPrestamos.UseVisualStyleBackColor = True
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl1.Controls.Add(Me.TabPage7)
            Me.TabControl1.Controls.Add(Me.TabPage8)
            Me.TabControl1.Location = New System.Drawing.Point(653, 24)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(375, 254)
            Me.TabControl1.TabIndex = 2
            '
            'TabPage7
            '
            Me.TabPage7.Controls.Add(Me.dgvPagosPrestamos)
            Me.TabPage7.Location = New System.Drawing.Point(4, 22)
            Me.TabPage7.Name = "TabPage7"
            Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage7.Size = New System.Drawing.Size(367, 228)
            Me.TabPage7.TabIndex = 0
            Me.TabPage7.Text = "Pagos"
            Me.TabPage7.UseVisualStyleBackColor = True
            '
            'dgvPagosPrestamos
            '
            Me.dgvPagosPrestamos.AllowUserToAddRows = False
            Me.dgvPagosPrestamos.AllowUserToDeleteRows = False
            Me.dgvPagosPrestamos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPagosPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPagosPrestamos.Location = New System.Drawing.Point(1, 6)
            Me.dgvPagosPrestamos.Name = "dgvPagosPrestamos"
            Me.dgvPagosPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPagosPrestamos.Size = New System.Drawing.Size(363, 216)
            Me.dgvPagosPrestamos.TabIndex = 0
            '
            'TabPage8
            '
            Me.TabPage8.Controls.Add(Me.dgvDatosPrestamos)
            Me.TabPage8.Location = New System.Drawing.Point(4, 22)
            Me.TabPage8.Name = "TabPage8"
            Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage8.Size = New System.Drawing.Size(367, 228)
            Me.TabPage8.TabIndex = 1
            Me.TabPage8.Text = "Prestamo"
            Me.TabPage8.UseVisualStyleBackColor = True
            '
            'dgvDatosPrestamos
            '
            Me.dgvDatosPrestamos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDatosPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDatosPrestamos.Location = New System.Drawing.Point(3, 9)
            Me.dgvDatosPrestamos.MultiSelect = False
            Me.dgvDatosPrestamos.Name = "dgvDatosPrestamos"
            Me.dgvDatosPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDatosPrestamos.Size = New System.Drawing.Size(358, 216)
            Me.dgvDatosPrestamos.TabIndex = 0
            '
            'dgvPrestamos
            '
            Me.dgvPrestamos.AllowUserToAddRows = False
            Me.dgvPrestamos.AllowUserToDeleteRows = False
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvPrestamos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
            Me.dgvPrestamos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPrestamos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Marcar, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.tit_TipoTrab, Me.CCT_ID})
            Me.dgvPrestamos.Location = New System.Drawing.Point(3, 24)
            Me.dgvPrestamos.MultiSelect = False
            Me.dgvPrestamos.Name = "dgvPrestamos"
            Me.dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPrestamos.Size = New System.Drawing.Size(646, 254)
            Me.dgvPrestamos.TabIndex = 1
            '
            'Marcar
            '
            Me.Marcar.HeaderText = "Marcar"
            Me.Marcar.Name = "Marcar"
            Me.Marcar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Marcar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Column1
            '
            Me.Column1.HeaderText = "per_IdTrab"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            '
            'Column2
            '
            Me.Column2.HeaderText = "Codigo"
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            '
            'Column3
            '
            Me.Column3.HeaderText = "persona"
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            '
            'Column4
            '
            Me.Column4.HeaderText = "Serie"
            Me.Column4.Name = "Column4"
            Me.Column4.ReadOnly = True
            '
            'Column5
            '
            Me.Column5.HeaderText = "Numero"
            Me.Column5.Name = "Column5"
            Me.Column5.ReadOnly = True
            '
            'Column6
            '
            Me.Column6.HeaderText = "ImportePrestamo"
            Me.Column6.Name = "Column6"
            Me.Column6.ReadOnly = True
            '
            'Column7
            '
            Me.Column7.HeaderText = "ImporteEntregado"
            Me.Column7.Name = "Column7"
            Me.Column7.ReadOnly = True
            '
            'Column8
            '
            Me.Column8.HeaderText = "ImportePagado"
            Me.Column8.Name = "Column8"
            Me.Column8.ReadOnly = True
            '
            'Column9
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.Column9.DefaultCellStyle = DataGridViewCellStyle5
            Me.Column9.HeaderText = "ImporteDescontar"
            Me.Column9.Name = "Column9"
            '
            'Column10
            '
            Me.Column10.HeaderText = "TDO_ID"
            Me.Column10.Name = "Column10"
            Me.Column10.ReadOnly = True
            '
            'Column11
            '
            Me.Column11.HeaderText = "DTD_ID"
            Me.Column11.Name = "Column11"
            Me.Column11.ReadOnly = True
            '
            'tit_TipoTrab
            '
            Me.tit_TipoTrab.HeaderText = "tit_TipoTrab"
            Me.tit_TipoTrab.Name = "tit_TipoTrab"
            '
            'CCT_ID
            '
            Me.CCT_ID.HeaderText = "CCT_ID"
            Me.CCT_ID.Name = "CCT_ID"
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(7, 7)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(262, 13)
            Me.Label15.TabIndex = 0
            Me.Label15.Text = "Prestamos a Personal ,segun lista ""Hora del Personal"""
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.chkLista)
            Me.TabPage2.Controls.Add(Me.Label24)
            Me.TabPage2.Controls.Add(Me.txtCodigo)
            Me.TabPage2.Controls.Add(Me.Label20)
            Me.TabPage2.Controls.Add(Me.chkMarcarPersonas)
            Me.TabPage2.Controls.Add(Me.dgvSeleccionPersonas)
            Me.TabPage2.Controls.Add(Me.Label12)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Seleccion de Personal"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'chkLista
            '
            Me.chkLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkLista.FormattingEnabled = True
            Me.chkLista.Location = New System.Drawing.Point(826, 36)
            Me.chkLista.Name = "chkLista"
            Me.chkLista.Size = New System.Drawing.Size(189, 214)
            Me.chkLista.TabIndex = 7
            '
            'Label24
            '
            Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(6, 253)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(631, 13)
            Me.Label24.TabIndex = 6
            Me.Label24.Text = "Doble clik para Ingresar a Datos Laborales , el listado que se observa correspond" & _
                "e a las personas cargadas en ""Horas del Personal"""
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(298, 10)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 5
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(216, 12)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(76, 13)
            Me.Label20.TabIndex = 4
            Me.Label20.Text = "Buscar Codigo"
            '
            'chkMarcarPersonas
            '
            Me.chkMarcarPersonas.AutoSize = True
            Me.chkMarcarPersonas.Location = New System.Drawing.Point(404, 13)
            Me.chkMarcarPersonas.Name = "chkMarcarPersonas"
            Me.chkMarcarPersonas.Size = New System.Drawing.Size(176, 17)
            Me.chkMarcarPersonas.TabIndex = 3
            Me.chkMarcarPersonas.Text = "Seleccionar  o Desmarcar Todo"
            Me.chkMarcarPersonas.UseVisualStyleBackColor = True
            '
            'dgvSeleccionPersonas
            '
            Me.dgvSeleccionPersonas.AllowUserToAddRows = False
            Me.dgvSeleccionPersonas.AllowUserToDeleteRows = False
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvSeleccionPersonas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.dgvSeleccionPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvSeleccionPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSeleccionPersonas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ok, Me.per_Id, Me.Codigo, Me.Descripcionn, Me.prd_Periodo_idInicialIngresos, Me.prd_Periodo_idFinalIngresos, Me.prd_Periodo_idInicialDias, Me.prd_Periodo_idFinalDias, Me.cco_Id, Me.tis_TipCargo_Id, Me.rep_RegiPension_id, Me.art_AreaTrab_Id, Me.rel_RegLaboral_Id, Me.plt_NuemroDeCuenta, Me.ccc_IdCuenta, Me.plt_CodigoTrabajador, Me.tit_Descripcion})
            Me.dgvSeleccionPersonas.Location = New System.Drawing.Point(7, 37)
            Me.dgvSeleccionPersonas.Name = "dgvSeleccionPersonas"
            Me.dgvSeleccionPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvSeleccionPersonas.Size = New System.Drawing.Size(813, 213)
            Me.dgvSeleccionPersonas.TabIndex = 1
            '
            'ok
            '
            Me.ok.HeaderText = "ok"
            Me.ok.Name = "ok"
            Me.ok.Width = 30
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.ReadOnly = True
            Me.per_Id.Width = 50
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.ReadOnly = True
            Me.Codigo.Width = 50
            '
            'Descripcionn
            '
            Me.Descripcionn.HeaderText = "Nombre"
            Me.Descripcionn.Name = "Descripcionn"
            Me.Descripcionn.ReadOnly = True
            Me.Descripcionn.Width = 170
            '
            'prd_Periodo_idInicialIngresos
            '
            Me.prd_Periodo_idInicialIngresos.HeaderText = "Periodo Ingresos Inicio"
            Me.prd_Periodo_idInicialIngresos.Name = "prd_Periodo_idInicialIngresos"
            Me.prd_Periodo_idInicialIngresos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.prd_Periodo_idInicialIngresos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'prd_Periodo_idFinalIngresos
            '
            Me.prd_Periodo_idFinalIngresos.HeaderText = "Periodo Ingresos Finaliza"
            Me.prd_Periodo_idFinalIngresos.Name = "prd_Periodo_idFinalIngresos"
            Me.prd_Periodo_idFinalIngresos.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.prd_Periodo_idFinalIngresos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.prd_Periodo_idFinalIngresos.Width = 110
            '
            'prd_Periodo_idInicialDias
            '
            Me.prd_Periodo_idInicialDias.HeaderText = "Periodo Dias-Inicia"
            Me.prd_Periodo_idInicialDias.Name = "prd_Periodo_idInicialDias"
            Me.prd_Periodo_idInicialDias.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.prd_Periodo_idInicialDias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'prd_Periodo_idFinalDias
            '
            Me.prd_Periodo_idFinalDias.HeaderText = "Periodo Dias-Finaliza"
            Me.prd_Periodo_idFinalDias.Name = "prd_Periodo_idFinalDias"
            Me.prd_Periodo_idFinalDias.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.prd_Periodo_idFinalDias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cco_Id
            '
            Me.cco_Id.HeaderText = "cco_Id"
            Me.cco_Id.Name = "cco_Id"
            Me.cco_Id.Visible = False
            '
            'tis_TipCargo_Id
            '
            Me.tis_TipCargo_Id.HeaderText = "tis_TipCargo_Id"
            Me.tis_TipCargo_Id.Name = "tis_TipCargo_Id"
            Me.tis_TipCargo_Id.Visible = False
            '
            'rep_RegiPension_id
            '
            Me.rep_RegiPension_id.HeaderText = "rep_RegiPension_id"
            Me.rep_RegiPension_id.Name = "rep_RegiPension_id"
            Me.rep_RegiPension_id.Visible = False
            '
            'art_AreaTrab_Id
            '
            Me.art_AreaTrab_Id.HeaderText = "art_AreaTrab_Id"
            Me.art_AreaTrab_Id.Name = "art_AreaTrab_Id"
            Me.art_AreaTrab_Id.Visible = False
            '
            'rel_RegLaboral_Id
            '
            Me.rel_RegLaboral_Id.HeaderText = "rel_RegLaboral_Id"
            Me.rel_RegLaboral_Id.Name = "rel_RegLaboral_Id"
            Me.rel_RegLaboral_Id.Visible = False
            '
            'plt_NuemroDeCuenta
            '
            Me.plt_NuemroDeCuenta.HeaderText = "plt_NuemroDeCuenta"
            Me.plt_NuemroDeCuenta.Name = "plt_NuemroDeCuenta"
            Me.plt_NuemroDeCuenta.Visible = False
            '
            'ccc_IdCuenta
            '
            Me.ccc_IdCuenta.HeaderText = "ccc_IdCuenta"
            Me.ccc_IdCuenta.Name = "ccc_IdCuenta"
            Me.ccc_IdCuenta.Visible = False
            '
            'plt_CodigoTrabajador
            '
            Me.plt_CodigoTrabajador.HeaderText = "plt_CodigoTrabajador"
            Me.plt_CodigoTrabajador.Name = "plt_CodigoTrabajador"
            Me.plt_CodigoTrabajador.Visible = False
            '
            'tit_Descripcion
            '
            Me.tit_Descripcion.HeaderText = "tit_Descripcion"
            Me.tit_Descripcion.Name = "tit_Descripcion"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(7, 11)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(195, 13)
            Me.Label12.TabIndex = 0
            Me.Label12.Text = "Seleccion el personal  a generar Planilla"
            '
            'TabPage6
            '
            Me.TabPage6.Controls.Add(Me.Label25)
            Me.TabPage6.Controls.Add(Me.btnExportarExcel)
            Me.TabPage6.Controls.Add(Me.txtCodigoBuscar)
            Me.TabPage6.Controls.Add(Me.Label21)
            Me.TabPage6.Controls.Add(Me.lblSumar)
            Me.TabPage6.Controls.Add(Me.txtSumaPLL)
            Me.TabPage6.Controls.Add(Me.Label1)
            Me.TabPage6.Controls.Add(Me.dgvResultadoCalculoPL)
            Me.TabPage6.Controls.Add(Me.Label14)
            Me.TabPage6.Location = New System.Drawing.Point(4, 22)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage6.Size = New System.Drawing.Size(1032, 278)
            Me.TabPage6.TabIndex = 4
            Me.TabPage6.Text = "Planilla"
            Me.TabPage6.UseVisualStyleBackColor = True
            '
            'Label25
            '
            Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label25.AutoSize = True
            Me.Label25.Location = New System.Drawing.Point(6, 262)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(498, 13)
            Me.Label25.TabIndex = 8
            Me.Label25.Text = "Los periodos los utilizamos, para realizar acumuladas de  conceptos, ver detalle " & _
                "de planillas SSConcepto"
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Location = New System.Drawing.Point(717, 2)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(83, 23)
            Me.btnExportarExcel.TabIndex = 7
            Me.btnExportarExcel.Text = "Exportar excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'txtCodigoBuscar
            '
            Me.txtCodigoBuscar.Location = New System.Drawing.Point(226, 4)
            Me.txtCodigoBuscar.Name = "txtCodigoBuscar"
            Me.txtCodigoBuscar.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoBuscar.TabIndex = 6
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(132, 8)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(76, 13)
            Me.Label21.TabIndex = 5
            Me.Label21.Text = "Buscar Codigo"
            '
            'lblSumar
            '
            Me.lblSumar.Location = New System.Drawing.Point(519, 7)
            Me.lblSumar.Name = "lblSumar"
            Me.lblSumar.Size = New System.Drawing.Size(120, 17)
            Me.lblSumar.TabIndex = 4
            Me.lblSumar.Text = "Label17"
            '
            'txtSumaPLL
            '
            Me.txtSumaPLL.Location = New System.Drawing.Point(641, 4)
            Me.txtSumaPLL.Name = "txtSumaPLL"
            Me.txtSumaPLL.ReadOnly = True
            Me.txtSumaPLL.Size = New System.Drawing.Size(70, 20)
            Me.txtSumaPLL.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(359, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(156, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Seleccione la columna a Sumar"
            '
            'dgvResultadoCalculoPL
            '
            Me.dgvResultadoCalculoPL.AllowUserToAddRows = False
            Me.dgvResultadoCalculoPL.AllowUserToDeleteRows = False
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvResultadoCalculoPL.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
            Me.dgvResultadoCalculoPL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvResultadoCalculoPL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvResultadoCalculoPL.Location = New System.Drawing.Point(7, 29)
            Me.dgvResultadoCalculoPL.Name = "dgvResultadoCalculoPL"
            Me.dgvResultadoCalculoPL.Size = New System.Drawing.Size(1021, 230)
            Me.dgvResultadoCalculoPL.TabIndex = 1
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(4, 7)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(88, 13)
            Me.Label14.TabIndex = 0
            Me.Label14.Text = "Planilla a generar"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnInicio)
            Me.Panel2.Controls.Add(Me.btnSiguiente)
            Me.Panel2.Controls.Add(Me.txtTipoPlanilla)
            Me.Panel2.Controls.Add(Me.txtTipoTrabajador)
            Me.Panel2.Controls.Add(Me.Button4)
            Me.Panel2.Controls.Add(Me.txtDescripcion)
            Me.Panel2.Controls.Add(Me.Label11)
            Me.Panel2.Controls.Add(Me.btnPlanilla)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.Label9)
            Me.Panel2.Controls.Add(Me.txtPlanilla)
            Me.Panel2.Controls.Add(Me.Label8)
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.dateHasta)
            Me.Panel2.Controls.Add(Me.dateDesde)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.txtSerie)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Location = New System.Drawing.Point(4, 6)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(1049, 83)
            Me.Panel2.TabIndex = 0
            '
            'btnInicio
            '
            Me.btnInicio.Location = New System.Drawing.Point(857, 53)
            Me.btnInicio.Name = "btnInicio"
            Me.btnInicio.Size = New System.Drawing.Size(59, 23)
            Me.btnInicio.TabIndex = 25
            Me.btnInicio.Text = "<=Inicio"
            Me.btnInicio.UseVisualStyleBackColor = True
            '
            'btnSiguiente
            '
            Me.btnSiguiente.Location = New System.Drawing.Point(922, 53)
            Me.btnSiguiente.Name = "btnSiguiente"
            Me.btnSiguiente.Size = New System.Drawing.Size(73, 23)
            Me.btnSiguiente.TabIndex = 2
            Me.btnSiguiente.Text = "Siguiente=>"
            Me.btnSiguiente.UseVisualStyleBackColor = True
            '
            'txtTipoPlanilla
            '
            Me.txtTipoPlanilla.Location = New System.Drawing.Point(281, 32)
            Me.txtTipoPlanilla.Name = "txtTipoPlanilla"
            Me.txtTipoPlanilla.ReadOnly = True
            Me.txtTipoPlanilla.Size = New System.Drawing.Size(239, 20)
            Me.txtTipoPlanilla.TabIndex = 24
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(89, 32)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(100, 20)
            Me.txtTipoTrabajador.TabIndex = 23
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(195, 9)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(24, 23)
            Me.Button4.TabIndex = 20
            Me.Button4.Text = ":::"
            Me.Button4.UseVisualStyleBackColor = True
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(89, 55)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Size = New System.Drawing.Size(697, 20)
            Me.txtDescripcion.TabIndex = 19
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(23, 58)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(63, 13)
            Me.Label11.TabIndex = 18
            Me.Label11.Text = "Descripcion"
            '
            'btnPlanilla
            '
            Me.btnPlanilla.Location = New System.Drawing.Point(762, 31)
            Me.btnPlanilla.Name = "btnPlanilla"
            Me.btnPlanilla.Size = New System.Drawing.Size(24, 23)
            Me.btnPlanilla.TabIndex = 17
            Me.btnPlanilla.Text = ":::"
            Me.btnPlanilla.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(956, 29)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodo.TabIndex = 16
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(790, 35)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(76, 13)
            Me.Label10.TabIndex = 15
            Me.Label10.Text = "Periodo Actual"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(868, 31)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodo.TabIndex = 14
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(519, 38)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(40, 13)
            Me.Label9.TabIndex = 13
            Me.Label9.Text = "Planilla"
            '
            'txtPlanilla
            '
            Me.txtPlanilla.Location = New System.Drawing.Point(565, 32)
            Me.txtPlanilla.Name = "txtPlanilla"
            Me.txtPlanilla.ReadOnly = True
            Me.txtPlanilla.Size = New System.Drawing.Size(196, 20)
            Me.txtPlanilla.TabIndex = 12
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(197, 36)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 13)
            Me.Label8.TabIndex = 10
            Me.Label8.Text = "Tipo Planilla"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(4, 36)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(82, 13)
            Me.Label7.TabIndex = 8
            Me.Label7.Text = "Tipo Trabajadro"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(688, 9)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(87, 20)
            Me.dateHasta.TabIndex = 7
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(557, 9)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(87, 20)
            Me.dateDesde.TabIndex = 6
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(649, 12)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(35, 13)
            Me.Label6.TabIndex = 5
            Me.Label6.Text = "Hasta"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(513, 13)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(38, 13)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "Desde"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(281, 9)
            Me.txtNumero.MaxLength = 10
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 3
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(231, 13)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(44, 13)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Numero"
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(89, 9)
            Me.txtSerie.MaxLength = 3
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(100, 20)
            Me.txtSerie.TabIndex = 1
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(55, 9)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(31, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Serie"
            '
            'OpenFileDialog1
            '
            Me.OpenFileDialog1.FileName = "OpenFileDialog1"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "TipoTrabajador"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Numero"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Comedor"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Observaciones_Comedor"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.Width = 150
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "per_IdTrab"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "CodigoTrabajadro"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Trabajador"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.HeaderText = "Importe"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.HeaderText = "Inicia"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.HeaderText = "Finaliza"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.HeaderText = "Beneficiario"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.ReadOnly = True
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.HeaderText = "per_IdTrab"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.HeaderText = "Codigo"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            Me.DataGridViewTextBoxColumn14.ReadOnly = True
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.HeaderText = "persona"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            Me.DataGridViewTextBoxColumn15.ReadOnly = True
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.HeaderText = "Serie"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            Me.DataGridViewTextBoxColumn16.ReadOnly = True
            '
            'DataGridViewTextBoxColumn17
            '
            Me.DataGridViewTextBoxColumn17.HeaderText = "Numero"
            Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
            Me.DataGridViewTextBoxColumn17.ReadOnly = True
            '
            'DataGridViewTextBoxColumn18
            '
            Me.DataGridViewTextBoxColumn18.HeaderText = "ImportePrestamo"
            Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
            Me.DataGridViewTextBoxColumn18.ReadOnly = True
            '
            'DataGridViewTextBoxColumn19
            '
            Me.DataGridViewTextBoxColumn19.HeaderText = "ImporteEntregado"
            Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
            Me.DataGridViewTextBoxColumn19.ReadOnly = True
            '
            'DataGridViewTextBoxColumn20
            '
            Me.DataGridViewTextBoxColumn20.HeaderText = "ImportePagado"
            Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
            Me.DataGridViewTextBoxColumn20.ReadOnly = True
            '
            'DataGridViewTextBoxColumn21
            '
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.DataGridViewTextBoxColumn21.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewTextBoxColumn21.HeaderText = "ImporteDescontar"
            Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
            '
            'DataGridViewTextBoxColumn22
            '
            Me.DataGridViewTextBoxColumn22.HeaderText = "TDO_ID"
            Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
            Me.DataGridViewTextBoxColumn22.ReadOnly = True
            '
            'DataGridViewTextBoxColumn23
            '
            Me.DataGridViewTextBoxColumn23.HeaderText = "DTD_ID"
            Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
            Me.DataGridViewTextBoxColumn23.ReadOnly = True
            '
            'DataGridViewTextBoxColumn24
            '
            Me.DataGridViewTextBoxColumn24.HeaderText = "tit_TipoTrab"
            Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
            '
            'DataGridViewTextBoxColumn25
            '
            Me.DataGridViewTextBoxColumn25.HeaderText = "CCT_ID"
            Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
            '
            'DataGridViewTextBoxColumn26
            '
            Me.DataGridViewTextBoxColumn26.HeaderText = "per_idCopia"
            Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
            '
            'DataGridViewTextBoxColumn27
            '
            Me.DataGridViewTextBoxColumn27.HeaderText = "per_Id"
            Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
            Me.DataGridViewTextBoxColumn27.ReadOnly = True
            '
            'DataGridViewTextBoxColumn28
            '
            Me.DataGridViewTextBoxColumn28.HeaderText = "Codigo"
            Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
            Me.DataGridViewTextBoxColumn28.ReadOnly = True
            '
            'DataGridViewTextBoxColumn29
            '
            Me.DataGridViewTextBoxColumn29.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
            Me.DataGridViewTextBoxColumn29.ReadOnly = True
            '
            'BackgroundWorker1
            '
            '
            'frmPlanilla
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1069, 551)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPlanilla"
            Me.Text = "frmPlanilla"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            Me.Panel6.PerformLayout()
            Me.Panel8.ResumeLayout(False)
            Me.Panel8.PerformLayout()
            Me.Panel7.ResumeLayout(False)
            Me.Panel7.PerformLayout()
            Me.Panel5.ResumeLayout(False)
            Me.TabPlanillas.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.dgvHoraPersonal, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.TabPage5.ResumeLayout(False)
            CType(Me.dgvComedor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout()
            CType(Me.dgvDescuentoJudicial, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            Me.TabPage4.PerformLayout()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage7.ResumeLayout(False)
            CType(Me.dgvPagosPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage8.ResumeLayout(False)
            CType(Me.dgvDatosPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage2.PerformLayout()
            CType(Me.dgvSeleccionPersonas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage6.ResumeLayout(False)
            Me.TabPage6.PerformLayout()
            CType(Me.dgvResultadoCalculoPL, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents TabPlanillas As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents dgvHoraPersonal As System.Windows.Forms.DataGridView
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnQuitarHora As System.Windows.Forms.Button
        Friend WithEvents btnAgregarHora As System.Windows.Forms.Button
        Friend WithEvents txtObservacionesHora As System.Windows.Forms.TextBox
        Friend WithEvents btnTrabajadorHora As System.Windows.Forms.Button
        Friend WithEvents txtNumeroHora As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtTipotrabajadroHora As System.Windows.Forms.TextBox
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents dgvComedor As System.Windows.Forms.DataGridView
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnQuitarComedor As System.Windows.Forms.Button
        Friend WithEvents btnAgregarComedor As System.Windows.Forms.Button
        Friend WithEvents txtDescripcionComedor As System.Windows.Forms.TextBox
        Friend WithEvents btnBuscarComedor As System.Windows.Forms.Button
        Friend WithEvents txtNumeroComedor As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents dgvDescuentoJudicial As System.Windows.Forms.DataGridView
        Friend WithEvents Marca As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents per_IdTrab As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CodigoTrabajador As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Trabajadro As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Porcentaje As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Inicia As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Finaliza As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BHeneficiario As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents dgvPrestamos As System.Windows.Forms.DataGridView
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents dgvSeleccionPersonas As System.Windows.Forms.DataGridView
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents dgvResultadoCalculoPL As System.Windows.Forms.DataGridView
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtTipoPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents btnPlanilla As System.Windows.Forms.Button
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents btnSiguiente As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
        Friend WithEvents btnPagosYPrestamos As System.Windows.Forms.Button
        Friend WithEvents dgvPagosPrestamos As System.Windows.Forms.DataGridView
        Friend WithEvents dgvDatosPrestamos As System.Windows.Forms.DataGridView
        Friend WithEvents lblTrabajador As System.Windows.Forms.Label
        Friend WithEvents btnInicio As System.Windows.Forms.Button
        Friend WithEvents txtSumaPLL As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblSumar As System.Windows.Forms.Label
        Friend WithEvents chkMarcarPersonas As System.Windows.Forms.CheckBox
        Friend WithEvents Marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tit_TipoTrab As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CCT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents rdbPeriodoEspesifico As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPeriodoLiquidacion As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPeriodoActual As System.Windows.Forms.RadioButton
        Friend WithEvents Panel7 As System.Windows.Forms.Panel
        Friend WithEvents btnPeriodoHasta As System.Windows.Forms.Button
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoHasta As System.Windows.Forms.TextBox
        Friend WithEvents btnPeriodoDesde As System.Windows.Forms.Button
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoDesde As System.Windows.Forms.TextBox
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents txtCodigoBuscar As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents TipoTrabajador As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Comedor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Observaciones_Comedor As System.Windows.Forms.DataGridViewTextBoxColumn
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
        Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents chkCalculoDias As System.Windows.Forms.CheckBox
        Friend WithEvents Panel8 As System.Windows.Forms.Panel
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoHastaDias As System.Windows.Forms.TextBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoDesdeDias As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
        Friend WithEvents chkLista As System.Windows.Forms.CheckedListBox
        Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcionn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents prd_Periodo_idInicialIngresos As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents prd_Periodo_idFinalIngresos As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents prd_Periodo_idInicialDias As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents prd_Periodo_idFinalDias As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents cco_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tis_TipCargo_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_RegiPension_id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents art_AreaTrab_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rel_RegLaboral_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents plt_NuemroDeCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ccc_IdCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents plt_CodigoTrabajador As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tit_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
        Friend WithEvents pbarBarra As System.Windows.Forms.ProgressBar
    End Class

End Namespace
