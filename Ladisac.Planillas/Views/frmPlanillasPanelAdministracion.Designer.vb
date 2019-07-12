Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPlanillasPanelAdministracion
        Inherits Ladisac.Foundation.Views.ViewMaster

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.Panel7 = New System.Windows.Forms.Panel()
            Me.btnLibPlaSum = New System.Windows.Forms.Button()
            Me.btnLibroPlanilla = New System.Windows.Forms.Button()
            Me.btnCerrar = New System.Windows.Forms.Button()
            Me.btnReporteDetalle = New System.Windows.Forms.Button()
            Me.btnImprimirBoletas = New System.Windows.Forms.Button()
            Me.dgvBoletas = New System.Windows.Forms.DataGridView()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnCerrarPanel = New System.Windows.Forms.Button()
            Me.txtPersonaSelec = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dgvConceptosTrabajador = New System.Windows.Forms.DataGridView()
            Me.dgvPersonas = New System.Windows.Forms.DataGridView()
            Me.dgvPersonas2 = New System.Windows.Forms.DataGridView()
            Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.totalEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Neto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.txtBuscarCodigo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.btnQuitarTodo = New System.Windows.Forms.Button()
            Me.btnQuitar = New System.Windows.Forms.Button()
            Me.btnPasar = New System.Windows.Forms.Button()
            Me.txtTotalRegistros2 = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtTotalNeto2 = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtTotalEgreso2 = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtTotalINgreso2 = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.txtTotalRegistros = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtTotalNeto = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTotalEgreso = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtTotalINgreso = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.chkMarcarPersonas = New System.Windows.Forms.CheckBox()
            Me.btnCargarBoletas = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtPeriodoHasta = New System.Windows.Forms.TextBox()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPeriodoDesde = New System.Windows.Forms.TextBox()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btnAjusteEsSalud = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.Panel7.SuspendLayout()
            CType(Me.dgvBoletas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            CType(Me.dgvConceptosTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvPersonas2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel5.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(952, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.SplitContainer1)
            Me.Panel1.Controls.Add(Me.Panel6)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(945, 580)
            Me.Panel1.TabIndex = 1
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SplitContainer1.Location = New System.Drawing.Point(4, 44)
            Me.SplitContainer1.Name = "SplitContainer1"
            Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.Panel7)
            Me.SplitContainer1.Panel1.Controls.Add(Me.dgvBoletas)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
            Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPersonas)
            Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPersonas2)
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
            Me.SplitContainer1.Size = New System.Drawing.Size(929, 453)
            Me.SplitContainer1.SplitterDistance = 182
            Me.SplitContainer1.SplitterWidth = 8
            Me.SplitContainer1.TabIndex = 9
            '
            'Panel7
            '
            Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel7.Controls.Add(Me.btnAjusteEsSalud)
            Me.Panel7.Controls.Add(Me.btnLibPlaSum)
            Me.Panel7.Controls.Add(Me.btnLibroPlanilla)
            Me.Panel7.Controls.Add(Me.btnCerrar)
            Me.Panel7.Controls.Add(Me.btnReporteDetalle)
            Me.Panel7.Controls.Add(Me.btnImprimirBoletas)
            Me.Panel7.Location = New System.Drawing.Point(782, 3)
            Me.Panel7.Name = "Panel7"
            Me.Panel7.Size = New System.Drawing.Size(144, 170)
            Me.Panel7.TabIndex = 8
            '
            'btnLibPlaSum
            '
            Me.btnLibPlaSum.Location = New System.Drawing.Point(14, 86)
            Me.btnLibPlaSum.Name = "btnLibPlaSum"
            Me.btnLibPlaSum.Size = New System.Drawing.Size(114, 23)
            Me.btnLibPlaSum.TabIndex = 4
            Me.btnLibPlaSum.Text = "Lib.Planilla Suma"
            Me.btnLibPlaSum.UseVisualStyleBackColor = True
            '
            'btnLibroPlanilla
            '
            Me.btnLibroPlanilla.Location = New System.Drawing.Point(14, 59)
            Me.btnLibroPlanilla.Name = "btnLibroPlanilla"
            Me.btnLibroPlanilla.Size = New System.Drawing.Size(114, 23)
            Me.btnLibroPlanilla.TabIndex = 3
            Me.btnLibroPlanilla.Text = "Libro de Planilla"
            Me.btnLibroPlanilla.UseVisualStyleBackColor = True
            '
            'btnCerrar
            '
            Me.btnCerrar.Location = New System.Drawing.Point(14, 140)
            Me.btnCerrar.Name = "btnCerrar"
            Me.btnCerrar.Size = New System.Drawing.Size(114, 23)
            Me.btnCerrar.TabIndex = 2
            Me.btnCerrar.Text = "Cerrar"
            Me.btnCerrar.UseVisualStyleBackColor = True
            '
            'btnReporteDetalle
            '
            Me.btnReporteDetalle.Location = New System.Drawing.Point(14, 32)
            Me.btnReporteDetalle.Name = "btnReporteDetalle"
            Me.btnReporteDetalle.Size = New System.Drawing.Size(114, 23)
            Me.btnReporteDetalle.TabIndex = 1
            Me.btnReporteDetalle.Text = "Reporte Detalle"
            Me.btnReporteDetalle.UseVisualStyleBackColor = True
            '
            'btnImprimirBoletas
            '
            Me.btnImprimirBoletas.Location = New System.Drawing.Point(14, 5)
            Me.btnImprimirBoletas.Name = "btnImprimirBoletas"
            Me.btnImprimirBoletas.Size = New System.Drawing.Size(114, 23)
            Me.btnImprimirBoletas.TabIndex = 0
            Me.btnImprimirBoletas.Text = "Imprimir"
            Me.btnImprimirBoletas.UseVisualStyleBackColor = True
            '
            'dgvBoletas
            '
            Me.dgvBoletas.AllowUserToAddRows = False
            Me.dgvBoletas.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvBoletas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvBoletas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvBoletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvBoletas.Location = New System.Drawing.Point(3, 3)
            Me.dgvBoletas.Name = "dgvBoletas"
            Me.dgvBoletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvBoletas.Size = New System.Drawing.Size(773, 170)
            Me.dgvBoletas.TabIndex = 1
            '
            'Panel4
            '
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.btnCerrarPanel)
            Me.Panel4.Controls.Add(Me.txtPersonaSelec)
            Me.Panel4.Controls.Add(Me.Label5)
            Me.Panel4.Controls.Add(Me.dgvConceptosTrabajador)
            Me.Panel4.Location = New System.Drawing.Point(204, 12)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(535, 206)
            Me.Panel4.TabIndex = 5
            Me.Panel4.Visible = False
            '
            'btnCerrarPanel
            '
            Me.btnCerrarPanel.Location = New System.Drawing.Point(449, 6)
            Me.btnCerrarPanel.Name = "btnCerrarPanel"
            Me.btnCerrarPanel.Size = New System.Drawing.Size(75, 23)
            Me.btnCerrarPanel.TabIndex = 3
            Me.btnCerrarPanel.Text = "Cerrar"
            Me.btnCerrarPanel.UseVisualStyleBackColor = True
            '
            'txtPersonaSelec
            '
            Me.txtPersonaSelec.Location = New System.Drawing.Point(60, 9)
            Me.txtPersonaSelec.Name = "txtPersonaSelec"
            Me.txtPersonaSelec.ReadOnly = True
            Me.txtPersonaSelec.Size = New System.Drawing.Size(383, 20)
            Me.txtPersonaSelec.TabIndex = 2
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(10, 14)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(44, 13)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "Nombre"
            '
            'dgvConceptosTrabajador
            '
            Me.dgvConceptosTrabajador.AllowUserToAddRows = False
            Me.dgvConceptosTrabajador.AllowUserToDeleteRows = False
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvConceptosTrabajador.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvConceptosTrabajador.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvConceptosTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvConceptosTrabajador.Location = New System.Drawing.Point(13, 37)
            Me.dgvConceptosTrabajador.Name = "dgvConceptosTrabajador"
            Me.dgvConceptosTrabajador.ReadOnly = True
            Me.dgvConceptosTrabajador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvConceptosTrabajador.Size = New System.Drawing.Size(505, 164)
            Me.dgvConceptosTrabajador.TabIndex = 0
            '
            'dgvPersonas
            '
            Me.dgvPersonas.AllowUserToAddRows = False
            Me.dgvPersonas.AllowUserToDeleteRows = False
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvPersonas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPersonas.Location = New System.Drawing.Point(3, 39)
            Me.dgvPersonas.Name = "dgvPersonas"
            Me.dgvPersonas.ReadOnly = True
            Me.dgvPersonas.Size = New System.Drawing.Size(467, 216)
            Me.dgvPersonas.TabIndex = 2
            '
            'dgvPersonas2
            '
            Me.dgvPersonas2.AllowUserToAddRows = False
            Me.dgvPersonas2.AllowUserToDeleteRows = False
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvPersonas2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
            Me.dgvPersonas2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPersonas2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPersonas2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serie, Me.Numero, Me.per_Id, Me.Codigo, Me.Nombre, Me.TotalIngreso, Me.totalEgreso, Me.Neto})
            Me.dgvPersonas2.Location = New System.Drawing.Point(476, 39)
            Me.dgvPersonas2.Name = "dgvPersonas2"
            Me.dgvPersonas2.ReadOnly = True
            Me.dgvPersonas2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPersonas2.Size = New System.Drawing.Size(450, 216)
            Me.dgvPersonas2.TabIndex = 6
            '
            'Serie
            '
            Me.Serie.HeaderText = "Serie"
            Me.Serie.Name = "Serie"
            Me.Serie.ReadOnly = True
            Me.Serie.Visible = False
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            Me.Numero.Visible = False
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.ReadOnly = True
            Me.per_Id.Visible = False
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.ReadOnly = True
            '
            'Nombre
            '
            Me.Nombre.HeaderText = "Nombre"
            Me.Nombre.Name = "Nombre"
            Me.Nombre.ReadOnly = True
            '
            'TotalIngreso
            '
            Me.TotalIngreso.HeaderText = "TotalIngreso"
            Me.TotalIngreso.Name = "TotalIngreso"
            Me.TotalIngreso.ReadOnly = True
            '
            'totalEgreso
            '
            Me.totalEgreso.HeaderText = "totalEgreso"
            Me.totalEgreso.Name = "totalEgreso"
            Me.totalEgreso.ReadOnly = True
            '
            'Neto
            '
            Me.Neto.HeaderText = "Neto"
            Me.Neto.Name = "Neto"
            Me.Neto.ReadOnly = True
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.txtBuscarCodigo)
            Me.Panel5.Controls.Add(Me.Label6)
            Me.Panel5.Location = New System.Drawing.Point(4, 3)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(466, 30)
            Me.Panel5.TabIndex = 5
            '
            'txtBuscarCodigo
            '
            Me.txtBuscarCodigo.Location = New System.Drawing.Point(76, 6)
            Me.txtBuscarCodigo.Name = "txtBuscarCodigo"
            Me.txtBuscarCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtBuscarCodigo.TabIndex = 1
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(12, 9)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(40, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Codigo"
            '
            'Panel6
            '
            Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel6.Controls.Add(Me.btnQuitarTodo)
            Me.Panel6.Controls.Add(Me.btnQuitar)
            Me.Panel6.Controls.Add(Me.btnPasar)
            Me.Panel6.Controls.Add(Me.txtTotalRegistros2)
            Me.Panel6.Controls.Add(Me.Label7)
            Me.Panel6.Controls.Add(Me.txtTotalNeto2)
            Me.Panel6.Controls.Add(Me.Label8)
            Me.Panel6.Controls.Add(Me.txtTotalEgreso2)
            Me.Panel6.Controls.Add(Me.Label9)
            Me.Panel6.Controls.Add(Me.txtTotalINgreso2)
            Me.Panel6.Controls.Add(Me.Label11)
            Me.Panel6.Location = New System.Drawing.Point(469, 503)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(463, 71)
            Me.Panel6.TabIndex = 7
            '
            'btnQuitarTodo
            '
            Me.btnQuitarTodo.Location = New System.Drawing.Point(85, 45)
            Me.btnQuitarTodo.Name = "btnQuitarTodo"
            Me.btnQuitarTodo.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitarTodo.TabIndex = 10
            Me.btnQuitarTodo.Text = "Quitar Todo"
            Me.btnQuitarTodo.UseVisualStyleBackColor = True
            '
            'btnQuitar
            '
            Me.btnQuitar.Location = New System.Drawing.Point(4, 47)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 9
            Me.btnQuitar.Text = "Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'btnPasar
            '
            Me.btnPasar.Location = New System.Drawing.Point(4, 25)
            Me.btnPasar.Name = "btnPasar"
            Me.btnPasar.Size = New System.Drawing.Size(75, 23)
            Me.btnPasar.TabIndex = 8
            Me.btnPasar.Text = "Pasar >>"
            Me.btnPasar.UseVisualStyleBackColor = True
            '
            'txtTotalRegistros2
            '
            Me.txtTotalRegistros2.Location = New System.Drawing.Point(126, 7)
            Me.txtTotalRegistros2.Name = "txtTotalRegistros2"
            Me.txtTotalRegistros2.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalRegistros2.TabIndex = 7
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(17, 10)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(103, 13)
            Me.Label7.TabIndex = 6
            Me.Label7.Text = "Numero de Registos"
            '
            'txtTotalNeto2
            '
            Me.txtTotalNeto2.Location = New System.Drawing.Point(324, 48)
            Me.txtTotalNeto2.Name = "txtTotalNeto2"
            Me.txtTotalNeto2.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalNeto2.TabIndex = 5
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(262, 51)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(57, 13)
            Me.Label8.TabIndex = 4
            Me.Label8.Text = "Total Neto"
            '
            'txtTotalEgreso2
            '
            Me.txtTotalEgreso2.Location = New System.Drawing.Point(324, 26)
            Me.txtTotalEgreso2.Name = "txtTotalEgreso2"
            Me.txtTotalEgreso2.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalEgreso2.TabIndex = 3
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(252, 29)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(67, 13)
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "Total Egreso"
            '
            'txtTotalINgreso2
            '
            Me.txtTotalINgreso2.Location = New System.Drawing.Point(324, 4)
            Me.txtTotalINgreso2.Name = "txtTotalINgreso2"
            Me.txtTotalINgreso2.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalINgreso2.TabIndex = 1
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(250, 7)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(69, 13)
            Me.Label11.TabIndex = 0
            Me.Label11.Text = "Total Ingreso"
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.txtTotalRegistros)
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Controls.Add(Me.txtTotalNeto)
            Me.Panel3.Controls.Add(Me.Label3)
            Me.Panel3.Controls.Add(Me.txtTotalEgreso)
            Me.Panel3.Controls.Add(Me.Label2)
            Me.Panel3.Controls.Add(Me.txtTotalINgreso)
            Me.Panel3.Controls.Add(Me.Label1)
            Me.Panel3.Location = New System.Drawing.Point(4, 504)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(463, 71)
            Me.Panel3.TabIndex = 4
            '
            'txtTotalRegistros
            '
            Me.txtTotalRegistros.Location = New System.Drawing.Point(126, 7)
            Me.txtTotalRegistros.Name = "txtTotalRegistros"
            Me.txtTotalRegistros.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalRegistros.TabIndex = 7
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(17, 10)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(103, 13)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Numero de Registos"
            '
            'txtTotalNeto
            '
            Me.txtTotalNeto.Location = New System.Drawing.Point(324, 48)
            Me.txtTotalNeto.Name = "txtTotalNeto"
            Me.txtTotalNeto.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalNeto.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(262, 51)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(57, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Total Neto"
            '
            'txtTotalEgreso
            '
            Me.txtTotalEgreso.Location = New System.Drawing.Point(324, 26)
            Me.txtTotalEgreso.Name = "txtTotalEgreso"
            Me.txtTotalEgreso.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalEgreso.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(252, 29)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(67, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Total Egreso"
            '
            'txtTotalINgreso
            '
            Me.txtTotalINgreso.Location = New System.Drawing.Point(324, 4)
            Me.txtTotalINgreso.Name = "txtTotalINgreso"
            Me.txtTotalINgreso.Size = New System.Drawing.Size(100, 20)
            Me.txtTotalINgreso.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(250, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(69, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Total Ingreso"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.chkMarcarPersonas)
            Me.Panel2.Controls.Add(Me.btnCargarBoletas)
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.Label12)
            Me.Panel2.Controls.Add(Me.txtPeriodoHasta)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.txtPeriodoDesde)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(932, 34)
            Me.Panel2.TabIndex = 0
            '
            'chkMarcarPersonas
            '
            Me.chkMarcarPersonas.AutoSize = True
            Me.chkMarcarPersonas.Location = New System.Drawing.Point(792, 10)
            Me.chkMarcarPersonas.Name = "chkMarcarPersonas"
            Me.chkMarcarPersonas.Size = New System.Drawing.Size(59, 17)
            Me.chkMarcarPersonas.TabIndex = 33
            Me.chkMarcarPersonas.Text = "Marcar"
            Me.chkMarcarPersonas.UseVisualStyleBackColor = True
            '
            'btnCargarBoletas
            '
            Me.btnCargarBoletas.Location = New System.Drawing.Point(485, 7)
            Me.btnCargarBoletas.Name = "btnCargarBoletas"
            Me.btnCargarBoletas.Size = New System.Drawing.Size(112, 23)
            Me.btnCargarBoletas.TabIndex = 32
            Me.btnCargarBoletas.Text = "Cargar Boletas"
            Me.btnCargarBoletas.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(443, 7)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(26, 23)
            Me.Button1.TabIndex = 31
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(264, 12)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(85, 13)
            Me.Label12.TabIndex = 30
            Me.Label12.Text = "Hasta el Periodo"
            '
            'txtPeriodoHasta
            '
            Me.txtPeriodoHasta.Location = New System.Drawing.Point(355, 8)
            Me.txtPeriodoHasta.Name = "txtPeriodoHasta"
            Me.txtPeriodoHasta.ReadOnly = True
            Me.txtPeriodoHasta.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoHasta.TabIndex = 29
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(204, 7)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodo.TabIndex = 28
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(22, 12)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(88, 13)
            Me.Label10.TabIndex = 27
            Me.Label10.Text = "Desde el Periodo"
            '
            'txtPeriodoDesde
            '
            Me.txtPeriodoDesde.Location = New System.Drawing.Point(116, 8)
            Me.txtPeriodoDesde.Name = "txtPeriodoDesde"
            Me.txtPeriodoDesde.ReadOnly = True
            Me.txtPeriodoDesde.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoDesde.TabIndex = 26
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Serie"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Numero"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "per_Id"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Codigo"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Nombre"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "TotalIngres"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "totalEgreso"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Neto"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'btnAjusteEsSalud
            '
            Me.btnAjusteEsSalud.Location = New System.Drawing.Point(14, 113)
            Me.btnAjusteEsSalud.Name = "btnAjusteEsSalud"
            Me.btnAjusteEsSalud.Size = New System.Drawing.Size(114, 23)
            Me.btnAjusteEsSalud.TabIndex = 5
            Me.btnAjusteEsSalud.Text = "Ajuste Essalud"
            Me.btnAjusteEsSalud.UseVisualStyleBackColor = True
            '
            'frmPlanillasPanelAdministracion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(952, 615)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPlanillasPanelAdministracion"
            Me.Text = "frmPlanillasPanelAdministracion"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.Panel7.ResumeLayout(False)
            CType(Me.dgvBoletas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            CType(Me.dgvConceptosTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvPersonas2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
            Me.Panel6.ResumeLayout(False)
            Me.Panel6.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoDesde As System.Windows.Forms.TextBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents txtTotalINgreso As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dgvPersonas As System.Windows.Forms.DataGridView
        Friend WithEvents dgvBoletas As System.Windows.Forms.DataGridView
        Friend WithEvents txtTotalNeto As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTotalEgreso As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtTotalRegistros As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnCerrarPanel As System.Windows.Forms.Button
        Friend WithEvents txtPersonaSelec As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvConceptosTrabajador As System.Windows.Forms.DataGridView
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents txtBuscarCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents btnQuitar As System.Windows.Forms.Button
        Friend WithEvents btnPasar As System.Windows.Forms.Button
        Friend WithEvents txtTotalRegistros2 As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtTotalNeto2 As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtTotalEgreso2 As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtTotalINgreso2 As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents dgvPersonas2 As System.Windows.Forms.DataGridView
        Friend WithEvents btnQuitarTodo As System.Windows.Forms.Button
        Friend WithEvents Panel7 As System.Windows.Forms.Panel
        Friend WithEvents btnImprimirBoletas As System.Windows.Forms.Button
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents totalEgreso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Neto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoHasta As System.Windows.Forms.TextBox
        Friend WithEvents btnCargarBoletas As System.Windows.Forms.Button
        Friend WithEvents btnReporteDetalle As System.Windows.Forms.Button
        Friend WithEvents btnCerrar As System.Windows.Forms.Button
        Friend WithEvents btnLibroPlanilla As System.Windows.Forms.Button
        Friend WithEvents chkMarcarPersonas As System.Windows.Forms.CheckBox
        Friend WithEvents btnLibPlaSum As System.Windows.Forms.Button
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents btnAjusteEsSalud As System.Windows.Forms.Button
    End Class

End Namespace
