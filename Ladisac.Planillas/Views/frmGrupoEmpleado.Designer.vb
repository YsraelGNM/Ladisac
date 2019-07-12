
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGrupoEmpleado
        'Inherits System.Windows.Forms.Form
        Inherits ViewManMasterPlanillas
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
            Me.txtDiasMarcados = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnObtenerDatos = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.txtHoraDoble = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtHoraSimple = New System.Windows.Forms.TextBox()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtCodigoBusca = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.gre_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_fecha = New ColumnaCalendario()
            Me.Dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraDesdePLL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraHastaPLL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_Refrigerio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_HoraExtraSimple = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.gre_Esdoble = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ClonarFilaSeleccionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
            Me.AgregarUnaFilaEnEsteLugarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnResponsable = New System.Windows.Forms.Button()
            Me.txtResponsable = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.dgvMarcacion = New System.Windows.Forms.DataGridView()
            Me.lblPersona = New System.Windows.Forms.Label()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.dgvMarcacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(1011, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.btnExportarExcel)
            Me.Panel1.Controls.Add(Me.txtDiasMarcados)
            Me.Panel1.Controls.Add(Me.Label12)
            Me.Panel1.Controls.Add(Me.btnObtenerDatos)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.txtHoraDoble)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label11)
            Me.Panel1.Controls.Add(Me.txtHoraSimple)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label10)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label9)
            Me.Panel1.Controls.Add(Me.txtCodigoBusca)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(1, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1003, 431)
            Me.Panel1.TabIndex = 2
            '
            'txtDiasMarcados
            '
            Me.txtDiasMarcados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtDiasMarcados.Location = New System.Drawing.Point(708, 407)
            Me.txtDiasMarcados.Name = "txtDiasMarcados"
            Me.txtDiasMarcados.ReadOnly = True
            Me.txtDiasMarcados.Size = New System.Drawing.Size(69, 20)
            Me.txtDiasMarcados.TabIndex = 144
            '
            'Label12
            '
            Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(633, 411)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(78, 13)
            Me.Label12.TabIndex = 143
            Me.Label12.Text = "Dias Marcados"
            '
            'btnObtenerDatos
            '
            Me.btnObtenerDatos.Location = New System.Drawing.Point(632, 112)
            Me.btnObtenerDatos.Name = "btnObtenerDatos"
            Me.btnObtenerDatos.Size = New System.Drawing.Size(101, 23)
            Me.btnObtenerDatos.TabIndex = 142
            Me.btnObtenerDatos.Text = "Obtener Datos"
            Me.btnObtenerDatos.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(414, 117)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(105, 13)
            Me.Label7.TabIndex = 141
            Me.Label7.Text = "Obtener Horas hasta"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(525, 115)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(101, 20)
            Me.dateHasta.TabIndex = 139
            '
            'txtHoraDoble
            '
            Me.txtHoraDoble.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtHoraDoble.Location = New System.Drawing.Point(559, 407)
            Me.txtHoraDoble.Name = "txtHoraDoble"
            Me.txtHoraDoble.ReadOnly = True
            Me.txtHoraDoble.Size = New System.Drawing.Size(69, 20)
            Me.txtHoraDoble.TabIndex = 9
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(183, 118)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(108, 13)
            Me.Label4.TabIndex = 140
            Me.Label4.Text = "Obtener Horas desde"
            '
            'Label11
            '
            Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(495, 410)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(61, 13)
            Me.Label11.TabIndex = 8
            Me.Label11.Text = "Hora Doble"
            '
            'txtHoraSimple
            '
            Me.txtHoraSimple.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtHoraSimple.Location = New System.Drawing.Point(423, 407)
            Me.txtHoraSimple.Name = "txtHoraSimple"
            Me.txtHoraSimple.ReadOnly = True
            Me.txtHoraSimple.Size = New System.Drawing.Size(69, 20)
            Me.txtHoraSimple.TabIndex = 7
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(297, 114)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(101, 20)
            Me.dateDesde.TabIndex = 138
            '
            'Label10
            '
            Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(349, 410)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(70, 13)
            Me.Label10.TabIndex = 6
            Me.Label10.Text = "Hora Siemple"
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtTrabajador.Location = New System.Drawing.Point(60, 407)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(282, 20)
            Me.txtTrabajador.TabIndex = 5
            '
            'Label9
            '
            Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(8, 410)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(44, 13)
            Me.Label9.TabIndex = 4
            Me.Label9.Text = "Nombre"
            '
            'txtCodigoBusca
            '
            Me.txtCodigoBusca.Location = New System.Drawing.Point(74, 114)
            Me.txtCodigoBusca.Name = "txtCodigoBusca"
            Me.txtCodigoBusca.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoBusca.TabIndex = 3
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(29, 116)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(40, 13)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "Codigo"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gre_Item, Me.gre_fecha, Me.Dia, Me.per_id, Me.Codigo, Me.Nombre, Me.gre_HoraDesde, Me.gre_HoraHasta, Me.gre_HoraDesdePLL, Me.gre_HoraHastaPLL, Me.gre_Refrigerio, Me.gre_HoraTotal, Me.gre_HoraExtraSimple, Me.gre_observaciones, Me.gre_Esdoble})
            Me.dgvDetalle.ContextMenuStrip = Me.ContextMenuStrip1
            Me.dgvDetalle.Location = New System.Drawing.Point(5, 136)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(993, 266)
            Me.dgvDetalle.TabIndex = 1
            '
            'gre_Item
            '
            Me.gre_Item.HeaderText = "Item"
            Me.gre_Item.Name = "gre_Item"
            Me.gre_Item.ReadOnly = True
            Me.gre_Item.Width = 10
            '
            'gre_fecha
            '
            Me.gre_fecha.HeaderText = "Fecha"
            Me.gre_fecha.Name = "gre_fecha"
            Me.gre_fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.gre_fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Dia
            '
            Me.Dia.HeaderText = "Dia"
            Me.Dia.Name = "Dia"
            '
            'per_id
            '
            Me.per_id.HeaderText = "per_id"
            Me.per_id.Name = "per_id"
            Me.per_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.per_id.Width = 30
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.ReadOnly = True
            Me.Codigo.Width = 70
            '
            'Nombre
            '
            Me.Nombre.HeaderText = "Nombre"
            Me.Nombre.Name = "Nombre"
            Me.Nombre.ReadOnly = True
            '
            'gre_HoraDesde
            '
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.gre_HoraDesde.DefaultCellStyle = DataGridViewCellStyle2
            Me.gre_HoraDesde.HeaderText = "Hora Desde"
            Me.gre_HoraDesde.Name = "gre_HoraDesde"
            Me.gre_HoraDesde.ReadOnly = True
            Me.gre_HoraDesde.Width = 70
            '
            'gre_HoraHasta
            '
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.gre_HoraHasta.DefaultCellStyle = DataGridViewCellStyle3
            Me.gre_HoraHasta.HeaderText = "Hora Hasta"
            Me.gre_HoraHasta.Name = "gre_HoraHasta"
            Me.gre_HoraHasta.ReadOnly = True
            Me.gre_HoraHasta.Width = 70
            '
            'gre_HoraDesdePLL
            '
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.gre_HoraDesdePLL.DefaultCellStyle = DataGridViewCellStyle4
            Me.gre_HoraDesdePLL.HeaderText = "Hora Desde Planilla"
            Me.gre_HoraDesdePLL.Name = "gre_HoraDesdePLL"
            Me.gre_HoraDesdePLL.Width = 90
            '
            'gre_HoraHastaPLL
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.gre_HoraHastaPLL.DefaultCellStyle = DataGridViewCellStyle5
            Me.gre_HoraHastaPLL.HeaderText = "Hora Hasta Planilla"
            Me.gre_HoraHastaPLL.Name = "gre_HoraHastaPLL"
            Me.gre_HoraHastaPLL.Width = 90
            '
            'gre_Refrigerio
            '
            Me.gre_Refrigerio.HeaderText = "Refrigerio"
            Me.gre_Refrigerio.Name = "gre_Refrigerio"
            Me.gre_Refrigerio.Width = 70
            '
            'gre_HoraTotal
            '
            Me.gre_HoraTotal.HeaderText = "Total"
            Me.gre_HoraTotal.Name = "gre_HoraTotal"
            Me.gre_HoraTotal.ReadOnly = True
            Me.gre_HoraTotal.Width = 50
            '
            'gre_HoraExtraSimple
            '
            Me.gre_HoraExtraSimple.HeaderText = "Hora Extra Simple"
            Me.gre_HoraExtraSimple.Name = "gre_HoraExtraSimple"
            '
            'gre_observaciones
            '
            Me.gre_observaciones.HeaderText = "Observaciones"
            Me.gre_observaciones.Name = "gre_observaciones"
            '
            'gre_Esdoble
            '
            Me.gre_Esdoble.HeaderText = "ES Doble"
            Me.gre_Esdoble.Name = "gre_Esdoble"
            Me.gre_Esdoble.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.gre_Esdoble.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClonarFilaSeleccionadaToolStripMenuItem, Me.ToolStripTextBox1, Me.AgregarUnaFilaEnEsteLugarToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(235, 73)
            '
            'ClonarFilaSeleccionadaToolStripMenuItem
            '
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Name = "ClonarFilaSeleccionadaToolStripMenuItem"
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Text = "Clonar Fila Seleccionada"
            '
            'ToolStripTextBox1
            '
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
            Me.ToolStripTextBox1.Text = "N"
            '
            'AgregarUnaFilaEnEsteLugarToolStripMenuItem
            '
            Me.AgregarUnaFilaEnEsteLugarToolStripMenuItem.Name = "AgregarUnaFilaEnEsteLugarToolStripMenuItem"
            Me.AgregarUnaFilaEnEsteLugarToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
            Me.AgregarUnaFilaEnEsteLugarToolStripMenuItem.Text = "Agregar Una Fila en este Lugar"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.btnResponsable)
            Me.Panel2.Controls.Add(Me.txtResponsable)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.btnSerie)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Location = New System.Drawing.Point(5, 6)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(993, 84)
            Me.Panel2.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(511, 36)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(0, 13)
            Me.Label3.TabIndex = 136
            '
            'btnResponsable
            '
            Me.btnResponsable.Location = New System.Drawing.Point(462, 27)
            Me.btnResponsable.Name = "btnResponsable"
            Me.btnResponsable.Size = New System.Drawing.Size(24, 23)
            Me.btnResponsable.TabIndex = 135
            Me.btnResponsable.Text = ":::"
            Me.btnResponsable.UseVisualStyleBackColor = True
            '
            'txtResponsable
            '
            Me.txtResponsable.Location = New System.Drawing.Point(111, 30)
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.ReadOnly = True
            Me.txtResponsable.Size = New System.Drawing.Size(347, 20)
            Me.txtResponsable.TabIndex = 134
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(37, 33)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(69, 13)
            Me.Label5.TabIndex = 133
            Me.Label5.Text = "Responsable"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(111, 53)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(347, 20)
            Me.txtObservaciones.TabIndex = 132
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(28, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 13)
            Me.Label2.TabIndex = 131
            Me.Label2.Text = "Observaciones"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(21, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 13)
            Me.Label1.TabIndex = 125
            Me.Label1.Text = "Periodo/Numero"
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(174, 5)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(27, 23)
            Me.btnSerie.TabIndex = 130
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(203, 7)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 127
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(335, 10)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 129
            Me.Label6.Text = "Fecha"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(111, 7)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
            Me.txtPeriodo.TabIndex = 126
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(373, 7)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(84, 20)
            Me.dateFecha.TabIndex = 128
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.dgvMarcacion)
            Me.Panel3.Location = New System.Drawing.Point(549, 51)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(457, 116)
            Me.Panel3.TabIndex = 123
            '
            'dgvMarcacion
            '
            Me.dgvMarcacion.AllowUserToAddRows = False
            Me.dgvMarcacion.AllowUserToDeleteRows = False
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvMarcacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.dgvMarcacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvMarcacion.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvMarcacion.Location = New System.Drawing.Point(4, 2)
            Me.dgvMarcacion.Name = "dgvMarcacion"
            Me.dgvMarcacion.ReadOnly = True
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvMarcacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
            Me.dgvMarcacion.RowHeadersWidth = 37
            Me.dgvMarcacion.RowTemplate.Height = 15
            Me.dgvMarcacion.Size = New System.Drawing.Size(546, 112)
            Me.dgvMarcacion.TabIndex = 0
            '
            'lblPersona
            '
            Me.lblPersona.AutoSize = True
            Me.lblPersona.Location = New System.Drawing.Point(505, 32)
            Me.lblPersona.Name = "lblPersona"
            Me.lblPersona.Size = New System.Drawing.Size(0, 13)
            Me.lblPersona.TabIndex = 124
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Location = New System.Drawing.Point(748, 113)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(101, 23)
            Me.btnExportarExcel.TabIndex = 145
            Me.btnExportarExcel.Text = "Exportar Excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'frmGrupoEmpleado
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1011, 492)
            Me.Controls.Add(Me.lblPersona)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmGrupoEmpleado"
            Me.Text = "frmGrupoMantenimiento"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel3, 0)
            Me.Controls.SetChildIndex(Me.lblPersona, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ContextMenuStrip1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            CType(Me.dgvMarcacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnResponsable As System.Windows.Forms.Button
        Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ClonarFilaSeleccionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnObtenerDatos As System.Windows.Forms.Button
        Friend WithEvents txtCodigoBusca As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtHoraDoble As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtHoraSimple As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents dgvMarcacion As System.Windows.Forms.DataGridView
        Friend WithEvents lblPersona As System.Windows.Forms.Label
        Friend WithEvents AgregarUnaFilaEnEsteLugarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents txtDiasMarcados As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents gre_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_fecha As ColumnaCalendario
        Friend WithEvents Dia As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraDesde As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraHasta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraDesdePLL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraHastaPLL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_Refrigerio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_HoraExtraSimple As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents gre_Esdoble As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    End Class

End Namespace