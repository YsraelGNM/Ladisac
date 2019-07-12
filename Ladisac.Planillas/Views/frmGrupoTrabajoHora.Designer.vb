
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGrupoTrabajoHora
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
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnAplicar = New System.Windows.Forms.Button()
            Me.ControlFiltroTrareaHoras1 = New Ladisac.Planillas.Views.ControlFiltroTrareaHoras()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.chkEsTareo = New System.Windows.Forms.CheckBox()
            Me.btnFiltros = New System.Windows.Forms.Button()
            Me.txtSuma = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnBorrarTodosLosFiltros = New System.Windows.Forms.Button()
            Me.btnVerColumnas = New System.Windows.Forms.Button()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.dateFechaInicio = New System.Windows.Forms.DateTimePicker()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.dgt_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pro_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Produccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Pla_id = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.art_AreaTrab_Id = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.tit_TipTarea_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ttr_TareaTrab_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Tarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_NumPersonas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_CantidadLadrillo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Mesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Alas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Fraccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Refrigerio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraTotales = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.CopiarPersonasSegunUnaFilaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.FiltrarPorCeldaActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.BorrarFiltrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.MostrarTodasLasColumnasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.MostrarColumnasPorFilaSeleccionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.dgvMarcacion = New System.Windows.Forms.DataGridView()
            Me.lblPersonas = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.dgvMarcacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(1284, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.btnAplicar)
            Me.Panel1.Controls.Add(Me.ControlFiltroTrareaHoras1)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Location = New System.Drawing.Point(3, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1279, 363)
            Me.Panel1.TabIndex = 121
            '
            'btnAplicar
            '
            Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnAplicar.Location = New System.Drawing.Point(47, 305)
            Me.btnAplicar.Name = "btnAplicar"
            Me.btnAplicar.Size = New System.Drawing.Size(75, 23)
            Me.btnAplicar.TabIndex = 125
            Me.btnAplicar.Text = "Aplicar"
            Me.btnAplicar.UseVisualStyleBackColor = True
            '
            'ControlFiltroTrareaHoras1
            '
            Me.ControlFiltroTrareaHoras1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ControlFiltroTrareaHoras1.Location = New System.Drawing.Point(23, 133)
            Me.ControlFiltroTrareaHoras1.Name = "ControlFiltroTrareaHoras1"
            Me.ControlFiltroTrareaHoras1.Size = New System.Drawing.Size(1237, 205)
            Me.ControlFiltroTrareaHoras1.TabIndex = 124
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.chkEsTareo)
            Me.Panel2.Controls.Add(Me.btnFiltros)
            Me.Panel2.Controls.Add(Me.txtSuma)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.btnBorrarTodosLosFiltros)
            Me.Panel2.Controls.Add(Me.btnVerColumnas)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.btnSerie)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.dateFechaInicio)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(1270, 85)
            Me.Panel2.TabIndex = 123
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(397, 51)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(135, 23)
            Me.Button1.TabIndex = 131
            Me.Button1.Text = "Copiar Datos Exsistentes"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'chkEsTareo
            '
            Me.chkEsTareo.AutoSize = True
            Me.chkEsTareo.Enabled = False
            Me.chkEsTareo.Location = New System.Drawing.Point(523, 4)
            Me.chkEsTareo.Name = "chkEsTareo"
            Me.chkEsTareo.Size = New System.Drawing.Size(125, 17)
            Me.chkEsTareo.TabIndex = 130
            Me.chkEsTareo.Text = "Es quema Secadero "
            Me.chkEsTareo.UseVisualStyleBackColor = True
            '
            'btnFiltros
            '
            Me.btnFiltros.Location = New System.Drawing.Point(251, 51)
            Me.btnFiltros.Name = "btnFiltros"
            Me.btnFiltros.Size = New System.Drawing.Size(63, 23)
            Me.btnFiltros.TabIndex = 129
            Me.btnFiltros.Text = "Filtros"
            Me.btnFiltros.UseVisualStyleBackColor = True
            '
            'txtSuma
            '
            Me.txtSuma.Location = New System.Drawing.Point(598, 53)
            Me.txtSuma.Name = "txtSuma"
            Me.txtSuma.ReadOnly = True
            Me.txtSuma.Size = New System.Drawing.Size(100, 20)
            Me.txtSuma.TabIndex = 128
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(538, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(54, 13)
            Me.Label3.TabIndex = 127
            Me.Label3.Text = "Sumatoria"
            '
            'btnBorrarTodosLosFiltros
            '
            Me.btnBorrarTodosLosFiltros.Location = New System.Drawing.Point(318, 51)
            Me.btnBorrarTodosLosFiltros.Name = "btnBorrarTodosLosFiltros"
            Me.btnBorrarTodosLosFiltros.Size = New System.Drawing.Size(75, 23)
            Me.btnBorrarTodosLosFiltros.TabIndex = 126
            Me.btnBorrarTodosLosFiltros.Text = "Borrar Filtros"
            Me.btnBorrarTodosLosFiltros.UseVisualStyleBackColor = True
            '
            'btnVerColumnas
            '
            Me.btnVerColumnas.Location = New System.Drawing.Point(101, 51)
            Me.btnVerColumnas.Name = "btnVerColumnas"
            Me.btnVerColumnas.Size = New System.Drawing.Size(144, 23)
            Me.btnVerColumnas.TabIndex = 125
            Me.btnVerColumnas.Text = "Mostrar todas las columnas"
            Me.btnVerColumnas.UseVisualStyleBackColor = True
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(101, 26)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(597, 20)
            Me.txtObservaciones.TabIndex = 124
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(21, 29)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 13)
            Me.Label2.TabIndex = 123
            Me.Label2.Text = "Observaciones"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 13)
            Me.Label1.TabIndex = 108
            Me.Label1.Text = "Periodo/Numero"
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(164, 3)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(27, 23)
            Me.btnSerie.TabIndex = 122
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(193, 5)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 110
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(345, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(32, 13)
            Me.Label6.TabIndex = 121
            Me.Label6.Text = "Inicia"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(101, 5)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
            Me.txtPeriodo.TabIndex = 109
            '
            'dateFechaInicio
            '
            Me.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaInicio.Location = New System.Drawing.Point(383, 5)
            Me.dateFechaInicio.Name = "dateFechaInicio"
            Me.dateFechaInicio.Size = New System.Drawing.Size(84, 20)
            Me.dateFechaInicio.TabIndex = 120
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgt_Item, Me.per_Id, Me.Codigo, Me.Persona, Me.pro_Id, Me.Produccion, Me.Descripcion, Me.Pla_id, Me.art_AreaTrab_Id, Me.tit_TipTarea_Id, Me.ttr_TareaTrab_Id, Me.Tarea, Me.dgt_Factor, Me.dgt_HoraDesde, Me.dgt_HoraHasta, Me.dgt_NumPersonas, Me.dgt_CantidadLadrillo, Me.dgt_Mesas, Me.dgt_Alas, Me.dgt_Fraccion, Me.dgt_Refrigerio, Me.dgt_Bonificacion, Me.dgt_Descuento, Me.dgt_HoraTotales, Me.dgt_Observaciones})
            Me.dgvDetalle.ContextMenuStrip = Me.ContextMenuStrip1
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 91)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.RowTemplate.Height = 20
            Me.dgvDetalle.Size = New System.Drawing.Size(1267, 265)
            Me.dgvDetalle.TabIndex = 107
            '
            'dgt_Item
            '
            Me.dgt_Item.HeaderText = "dgt_Item"
            Me.dgt_Item.Name = "dgt_Item"
            Me.dgt_Item.ReadOnly = True
            Me.dgt_Item.Width = 35
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Width = 20
            '
            'Codigo
            '
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            DataGridViewCellStyle3.NullValue = Nothing
            Me.Codigo.DefaultCellStyle = DataGridViewCellStyle3
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.Width = 45
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            Me.Persona.ReadOnly = True
            Me.Persona.Width = 150
            '
            'pro_Id
            '
            Me.pro_Id.HeaderText = "Prod"
            Me.pro_Id.Name = "pro_Id"
            Me.pro_Id.Width = 30
            '
            'Produccion
            '
            Me.Produccion.HeaderText = "Produccion"
            Me.Produccion.Name = "Produccion"
            Me.Produccion.ReadOnly = True
            Me.Produccion.Width = 50
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            Me.Descripcion.Width = 50
            '
            'Pla_id
            '
            Me.Pla_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
            Me.Pla_id.HeaderText = "Pla_id"
            Me.Pla_id.Name = "Pla_id"
            Me.Pla_id.Width = 30
            '
            'art_AreaTrab_Id
            '
            Me.art_AreaTrab_Id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
            Me.art_AreaTrab_Id.HeaderText = "AreaTrab"
            Me.art_AreaTrab_Id.Name = "art_AreaTrab_Id"
            Me.art_AreaTrab_Id.Width = 60
            '
            'tit_TipTarea_Id
            '
            Me.tit_TipTarea_Id.HeaderText = "TipTarea"
            Me.tit_TipTarea_Id.Name = "tit_TipTarea_Id"
            Me.tit_TipTarea_Id.Visible = False
            Me.tit_TipTarea_Id.Width = 50
            '
            'ttr_TareaTrab_Id
            '
            Me.ttr_TareaTrab_Id.HeaderText = "TareaTrab"
            Me.ttr_TareaTrab_Id.Name = "ttr_TareaTrab_Id"
            Me.ttr_TareaTrab_Id.Width = 30
            '
            'Tarea
            '
            Me.Tarea.HeaderText = "Tarea"
            Me.Tarea.Name = "Tarea"
            Me.Tarea.ReadOnly = True
            Me.Tarea.Width = 50
            '
            'dgt_Factor
            '
            Me.dgt_Factor.HeaderText = "Factor"
            Me.dgt_Factor.Name = "dgt_Factor"
            Me.dgt_Factor.ReadOnly = True
            Me.dgt_Factor.Width = 50
            '
            'dgt_HoraDesde
            '
            DataGridViewCellStyle4.NullValue = Nothing
            Me.dgt_HoraDesde.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgt_HoraDesde.HeaderText = "HoraDesde"
            Me.dgt_HoraDesde.Name = "dgt_HoraDesde"
            Me.dgt_HoraDesde.Width = 50
            '
            'dgt_HoraHasta
            '
            Me.dgt_HoraHasta.HeaderText = "HoraHasta"
            Me.dgt_HoraHasta.Name = "dgt_HoraHasta"
            Me.dgt_HoraHasta.Width = 50
            '
            'dgt_NumPersonas
            '
            Me.dgt_NumPersonas.HeaderText = "NumPersonas"
            Me.dgt_NumPersonas.Name = "dgt_NumPersonas"
            Me.dgt_NumPersonas.Width = 50
            '
            'dgt_CantidadLadrillo
            '
            Me.dgt_CantidadLadrillo.HeaderText = "Cant.Ladrillo"
            Me.dgt_CantidadLadrillo.Name = "dgt_CantidadLadrillo"
            Me.dgt_CantidadLadrillo.Width = 50
            '
            'dgt_Mesas
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.Lime
            Me.dgt_Mesas.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgt_Mesas.HeaderText = "Mesas"
            Me.dgt_Mesas.Name = "dgt_Mesas"
            Me.dgt_Mesas.Width = 50
            '
            'dgt_Alas
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.Lime
            Me.dgt_Alas.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgt_Alas.HeaderText = "Alas"
            Me.dgt_Alas.Name = "dgt_Alas"
            Me.dgt_Alas.Width = 50
            '
            'dgt_Fraccion
            '
            Me.dgt_Fraccion.HeaderText = "Fraccion"
            Me.dgt_Fraccion.Name = "dgt_Fraccion"
            Me.dgt_Fraccion.Width = 50
            '
            'dgt_Refrigerio
            '
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgt_Refrigerio.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgt_Refrigerio.HeaderText = "Refrigerio"
            Me.dgt_Refrigerio.Name = "dgt_Refrigerio"
            Me.dgt_Refrigerio.Width = 40
            '
            'dgt_Bonificacion
            '
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgt_Bonificacion.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgt_Bonificacion.HeaderText = "Bonificacion"
            Me.dgt_Bonificacion.Name = "dgt_Bonificacion"
            Me.dgt_Bonificacion.Width = 40
            '
            'dgt_Descuento
            '
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.Red
            Me.dgt_Descuento.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgt_Descuento.HeaderText = "Descuento"
            Me.dgt_Descuento.Name = "dgt_Descuento"
            Me.dgt_Descuento.Width = 40
            '
            'dgt_HoraTotales
            '
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.dgt_HoraTotales.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgt_HoraTotales.HeaderText = "HotaTotales"
            Me.dgt_HoraTotales.Name = "dgt_HoraTotales"
            Me.dgt_HoraTotales.ReadOnly = True
            Me.dgt_HoraTotales.Width = 50
            '
            'dgt_Observaciones
            '
            Me.dgt_Observaciones.HeaderText = "Observaciones"
            Me.dgt_Observaciones.Name = "dgt_Observaciones"
            Me.dgt_Observaciones.Width = 50
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.CopiarPersonasSegunUnaFilaToolStripMenuItem, Me.FiltrarPorCeldaActualToolStripMenuItem, Me.ToolStripSeparator1, Me.BorrarFiltrosToolStripMenuItem, Me.MostrarTodasLasColumnasToolStripMenuItem, Me.MostrarColumnasPorFilaSeleccionadaToolStripMenuItem, Me.ToolStripTextBox1})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(398, 167)
            '
            'ToolStripMenuItem
            '
            Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
            Me.ToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.ToolStripMenuItem.Text = "Clonar filas seleccionadas"
            '
            'CopiarPersonasSegunUnaFilaToolStripMenuItem
            '
            Me.CopiarPersonasSegunUnaFilaToolStripMenuItem.Name = "CopiarPersonasSegunUnaFilaToolStripMenuItem"
            Me.CopiarPersonasSegunUnaFilaToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.CopiarPersonasSegunUnaFilaToolStripMenuItem.Text = "Copiar personas con los datos de la primera fila seleccionada "
            '
            'FiltrarPorCeldaActualToolStripMenuItem
            '
            Me.FiltrarPorCeldaActualToolStripMenuItem.Name = "FiltrarPorCeldaActualToolStripMenuItem"
            Me.FiltrarPorCeldaActualToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.FiltrarPorCeldaActualToolStripMenuItem.Text = "Filtrar por celda actual"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(394, 6)
            '
            'BorrarFiltrosToolStripMenuItem
            '
            Me.BorrarFiltrosToolStripMenuItem.Name = "BorrarFiltrosToolStripMenuItem"
            Me.BorrarFiltrosToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.BorrarFiltrosToolStripMenuItem.Text = "Borrar Filtros"
            '
            'MostrarTodasLasColumnasToolStripMenuItem
            '
            Me.MostrarTodasLasColumnasToolStripMenuItem.Name = "MostrarTodasLasColumnasToolStripMenuItem"
            Me.MostrarTodasLasColumnasToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.MostrarTodasLasColumnasToolStripMenuItem.Text = "Mostrar todas las columnas"
            '
            'MostrarColumnasPorFilaSeleccionadaToolStripMenuItem
            '
            Me.MostrarColumnasPorFilaSeleccionadaToolStripMenuItem.Name = "MostrarColumnasPorFilaSeleccionadaToolStripMenuItem"
            Me.MostrarColumnasPorFilaSeleccionadaToolStripMenuItem.Size = New System.Drawing.Size(397, 22)
            Me.MostrarColumnasPorFilaSeleccionadaToolStripMenuItem.Text = "Mostrar columnas segun fila seleccionada"
            '
            'ToolStripTextBox1
            '
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
            Me.ToolStripTextBox1.Text = "N"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.dgvMarcacion)
            Me.Panel3.Location = New System.Drawing.Point(725, 28)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(557, 116)
            Me.Panel3.TabIndex = 122
            '
            'dgvMarcacion
            '
            Me.dgvMarcacion.AllowUserToAddRows = False
            Me.dgvMarcacion.AllowUserToDeleteRows = False
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvMarcacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
            Me.dgvMarcacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvMarcacion.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvMarcacion.Location = New System.Drawing.Point(4, 2)
            Me.dgvMarcacion.Name = "dgvMarcacion"
            Me.dgvMarcacion.ReadOnly = True
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvMarcacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
            Me.dgvMarcacion.RowHeadersWidth = 37
            Me.dgvMarcacion.RowTemplate.Height = 15
            Me.dgvMarcacion.Size = New System.Drawing.Size(546, 112)
            Me.dgvMarcacion.TabIndex = 0
            '
            'lblPersonas
            '
            Me.lblPersonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPersonas.Location = New System.Drawing.Point(446, 35)
            Me.lblPersonas.Name = "lblPersonas"
            Me.lblPersonas.Size = New System.Drawing.Size(277, 17)
            Me.lblPersonas.TabIndex = 1
            Me.lblPersonas.Text = "Nombre"
            '
            'frmGrupoTrabajoHora
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1284, 423)
            Me.Controls.Add(Me.lblPersonas)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmGrupoTrabajoHora"
            Me.Text = "frmGrupoTrabajoHora"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.Panel3, 0)
            Me.Controls.SetChildIndex(Me.lblPersonas, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ContextMenuStrip1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            CType(Me.dgvMarcacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dateFechaInicio As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CopiarPersonasSegunUnaFilaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnVerColumnas As System.Windows.Forms.Button
        Friend WithEvents btnBorrarTodosLosFiltros As System.Windows.Forms.Button
        Friend WithEvents FiltrarPorCeldaActualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents BorrarFiltrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents MostrarTodasLasColumnasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents MostrarColumnasPorFilaSeleccionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents dgvMarcacion As System.Windows.Forms.DataGridView
        Friend WithEvents lblPersonas As System.Windows.Forms.Label
        Friend WithEvents txtSuma As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnFiltros As System.Windows.Forms.Button
        Friend WithEvents chkEsTareo As System.Windows.Forms.CheckBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents ControlFiltroTrareaHoras1 As Ladisac.Planillas.Views.ControlFiltroTrareaHoras
        Friend WithEvents btnAplicar As System.Windows.Forms.Button
        Friend WithEvents dgt_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pro_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Produccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Pla_id As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents art_AreaTrab_Id As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents tit_TipTarea_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ttr_TareaTrab_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Tarea As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Factor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraDesde As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraHasta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_NumPersonas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_CantidadLadrillo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Mesas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Alas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Fraccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Refrigerio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Bonificacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraTotales As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace