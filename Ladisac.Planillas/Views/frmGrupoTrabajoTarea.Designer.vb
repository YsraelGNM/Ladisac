
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGrupoTrabajoTarea
        Inherits ViewManMasterPlanillas
        'Inherits System.Windows.Forms.Form

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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvProduccion = New System.Windows.Forms.DataGridView()
            Me.por_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Produccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pla_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Conteo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Carga = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.dgt_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Fraccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Refrigerio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraTotales = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.txtgrt_ResponsableSecaderoQuemas = New System.Windows.Forms.TextBox()
            Me.txtgrt_EsSecaderoQuema = New System.Windows.Forms.TextBox()
            Me.txtHoraInicio = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtHoraFin = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.chkEsTareo = New System.Windows.Forms.CheckBox()
            Me.rdbPorProduccion = New System.Windows.Forms.RadioButton()
            Me.rdbPorCarga = New System.Windows.Forms.RadioButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.cboArea = New System.Windows.Forms.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTarifa = New System.Windows.Forms.TextBox()
            Me.btnTarea = New System.Windows.Forms.Button()
            Me.txtTarea = New System.Windows.Forms.TextBox()
            Me.lblTipoArea = New System.Windows.Forms.Label()
            Me.dateFechaInicio = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(994, 28)
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.dgvProduccion)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 58)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(986, 428)
            Me.Panel1.TabIndex = 2
            '
            'dgvProduccion
            '
            Me.dgvProduccion.AllowUserToAddRows = False
            Me.dgvProduccion.AllowUserToDeleteRows = False
            Me.dgvProduccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.por_Id, Me.Produccion, Me.Descripcion, Me.pla_id, Me.Conteo, Me.Carga})
            Me.dgvProduccion.Location = New System.Drawing.Point(510, 113)
            Me.dgvProduccion.Name = "dgvProduccion"
            Me.dgvProduccion.Size = New System.Drawing.Size(472, 309)
            Me.dgvProduccion.TabIndex = 2
            '
            'por_Id
            '
            Me.por_Id.HeaderText = "por_Id"
            Me.por_Id.Name = "por_Id"
            Me.por_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.por_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.por_Id.Width = 40
            '
            'Produccion
            '
            Me.Produccion.HeaderText = "Produccion"
            Me.Produccion.Name = "Produccion"
            Me.Produccion.Width = 150
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.Visible = False
            '
            'pla_id
            '
            Me.pla_id.HeaderText = "pla_id"
            Me.pla_id.Name = "pla_id"
            Me.pla_id.Visible = False
            '
            'Conteo
            '
            Me.Conteo.HeaderText = "Conteo"
            Me.Conteo.Name = "Conteo"
            '
            'Carga
            '
            Me.Carga.HeaderText = "Carga"
            Me.Carga.Name = "Carga"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgt_Item, Me.per_Id, Me.Codigo, Me.Persona, Me.dgt_Fraccion, Me.dgt_Refrigerio, Me.dgt_Bonificacion, Me.dgt_Descuento, Me.dgt_Factor, Me.dgt_HoraTotales, Me.dgt_Observaciones})
            Me.dgvDetalle.Location = New System.Drawing.Point(10, 113)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(494, 309)
            Me.dgvDetalle.TabIndex = 1
            '
            'dgt_Item
            '
            Me.dgt_Item.HeaderText = "Item"
            Me.dgt_Item.Name = "dgt_Item"
            Me.dgt_Item.ReadOnly = True
            Me.dgt_Item.Width = 20
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Width = 40
            '
            'Codigo
            '
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.Codigo.DefaultCellStyle = DataGridViewCellStyle4
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.Width = 50
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            Me.Persona.Width = 150
            '
            'dgt_Fraccion
            '
            Me.dgt_Fraccion.HeaderText = "Fraccion"
            Me.dgt_Fraccion.Name = "dgt_Fraccion"
            Me.dgt_Fraccion.Width = 50
            '
            'dgt_Refrigerio
            '
            Me.dgt_Refrigerio.HeaderText = "Refrigerio"
            Me.dgt_Refrigerio.Name = "dgt_Refrigerio"
            Me.dgt_Refrigerio.Width = 50
            '
            'dgt_Bonificacion
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgt_Bonificacion.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgt_Bonificacion.HeaderText = "Bonificacion"
            Me.dgt_Bonificacion.Name = "dgt_Bonificacion"
            Me.dgt_Bonificacion.Width = 50
            '
            'dgt_Descuento
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.Red
            Me.dgt_Descuento.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgt_Descuento.HeaderText = "Descuento"
            Me.dgt_Descuento.Name = "dgt_Descuento"
            Me.dgt_Descuento.Width = 50
            '
            'dgt_Factor
            '
            Me.dgt_Factor.HeaderText = "Factor"
            Me.dgt_Factor.Name = "dgt_Factor"
            Me.dgt_Factor.Visible = False
            '
            'dgt_HoraTotales
            '
            Me.dgt_HoraTotales.HeaderText = "Total Factor"
            Me.dgt_HoraTotales.Name = "dgt_HoraTotales"
            Me.dgt_HoraTotales.Width = 70
            '
            'dgt_Observaciones
            '
            Me.dgt_Observaciones.HeaderText = "Observaciones"
            Me.dgt_Observaciones.Name = "dgt_Observaciones"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.Panel4)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Panel3)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.btnSerie)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.cboArea)
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.txtTarifa)
            Me.Panel2.Controls.Add(Me.btnTarea)
            Me.Panel2.Controls.Add(Me.txtTarea)
            Me.Panel2.Controls.Add(Me.lblTipoArea)
            Me.Panel2.Controls.Add(Me.dateFechaInicio)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Location = New System.Drawing.Point(10, 8)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(972, 100)
            Me.Panel2.TabIndex = 0
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.txtgrt_ResponsableSecaderoQuemas)
            Me.Panel4.Controls.Add(Me.txtgrt_EsSecaderoQuema)
            Me.Panel4.Controls.Add(Me.txtHoraInicio)
            Me.Panel4.Controls.Add(Me.Label4)
            Me.Panel4.Controls.Add(Me.txtHoraFin)
            Me.Panel4.Controls.Add(Me.Label5)
            Me.Panel4.Location = New System.Drawing.Point(593, 46)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(377, 53)
            Me.Panel4.TabIndex = 149
            '
            'txtgrt_ResponsableSecaderoQuemas
            '
            Me.txtgrt_ResponsableSecaderoQuemas.Location = New System.Drawing.Point(275, 28)
            Me.txtgrt_ResponsableSecaderoQuemas.Name = "txtgrt_ResponsableSecaderoQuemas"
            Me.txtgrt_ResponsableSecaderoQuemas.Size = New System.Drawing.Size(59, 20)
            Me.txtgrt_ResponsableSecaderoQuemas.TabIndex = 139
            Me.txtgrt_ResponsableSecaderoQuemas.Visible = False
            '
            'txtgrt_EsSecaderoQuema
            '
            Me.txtgrt_EsSecaderoQuema.Location = New System.Drawing.Point(275, 4)
            Me.txtgrt_EsSecaderoQuema.Name = "txtgrt_EsSecaderoQuema"
            Me.txtgrt_EsSecaderoQuema.Size = New System.Drawing.Size(59, 20)
            Me.txtgrt_EsSecaderoQuema.TabIndex = 138
            Me.txtgrt_EsSecaderoQuema.Visible = False
            '
            'txtHoraInicio
            '
            Me.txtHoraInicio.Location = New System.Drawing.Point(97, 5)
            Me.txtHoraInicio.Name = "txtHoraInicio"
            Me.txtHoraInicio.Size = New System.Drawing.Size(100, 20)
            Me.txtHoraInicio.TabIndex = 135
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(19, 6)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(73, 13)
            Me.Label4.TabIndex = 134
            Me.Label4.Text = "Hora de Inicio"
            '
            'txtHoraFin
            '
            Me.txtHoraFin.Location = New System.Drawing.Point(97, 28)
            Me.txtHoraFin.Name = "txtHoraFin"
            Me.txtHoraFin.Size = New System.Drawing.Size(100, 20)
            Me.txtHoraFin.TabIndex = 136
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(30, 31)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(62, 13)
            Me.Label5.TabIndex = 137
            Me.Label5.Text = "Hora de Fin"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(96, 76)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(361, 20)
            Me.txtObservaciones.TabIndex = 148
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(13, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 13)
            Me.Label2.TabIndex = 147
            Me.Label2.Text = "Observaciones"
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.chkEsTareo)
            Me.Panel3.Controls.Add(Me.rdbPorProduccion)
            Me.Panel3.Controls.Add(Me.rdbPorCarga)
            Me.Panel3.Location = New System.Drawing.Point(593, -1)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(379, 48)
            Me.Panel3.TabIndex = 146
            '
            'chkEsTareo
            '
            Me.chkEsTareo.AutoSize = True
            Me.chkEsTareo.Enabled = False
            Me.chkEsTareo.Location = New System.Drawing.Point(234, 16)
            Me.chkEsTareo.Name = "chkEsTareo"
            Me.chkEsTareo.Size = New System.Drawing.Size(125, 17)
            Me.chkEsTareo.TabIndex = 131
            Me.chkEsTareo.Text = "Es quema Secadero "
            Me.chkEsTareo.UseVisualStyleBackColor = True
            '
            'rdbPorProduccion
            '
            Me.rdbPorProduccion.AutoSize = True
            Me.rdbPorProduccion.Location = New System.Drawing.Point(114, 15)
            Me.rdbPorProduccion.Name = "rdbPorProduccion"
            Me.rdbPorProduccion.Size = New System.Drawing.Size(98, 17)
            Me.rdbPorProduccion.TabIndex = 141
            Me.rdbPorProduccion.TabStop = True
            Me.rdbPorProduccion.Text = "Por Produccion"
            Me.rdbPorProduccion.UseVisualStyleBackColor = True
            '
            'rdbPorCarga
            '
            Me.rdbPorCarga.AutoSize = True
            Me.rdbPorCarga.Checked = True
            Me.rdbPorCarga.Location = New System.Drawing.Point(13, 15)
            Me.rdbPorCarga.Name = "rdbPorCarga"
            Me.rdbPorCarga.Size = New System.Drawing.Size(71, 17)
            Me.rdbPorCarga.TabIndex = 140
            Me.rdbPorCarga.TabStop = True
            Me.rdbPorCarga.Text = "Por carga"
            Me.rdbPorCarga.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 13)
            Me.Label1.TabIndex = 142
            Me.Label1.Text = "Periodo/Numero"
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(156, 4)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(27, 23)
            Me.btnSerie.TabIndex = 145
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(185, 6)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 144
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(96, 6)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
            Me.txtPeriodo.TabIndex = 143
            '
            'cboArea
            '
            Me.cboArea.FormattingEnabled = True
            Me.cboArea.Location = New System.Drawing.Point(96, 52)
            Me.cboArea.Name = "cboArea"
            Me.cboArea.Size = New System.Drawing.Size(121, 21)
            Me.cboArea.TabIndex = 139
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(62, 57)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(29, 13)
            Me.Label7.TabIndex = 138
            Me.Label7.Text = "Area"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(231, 55)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(91, 13)
            Me.Label3.TabIndex = 133
            Me.Label3.Text = "Tarifa por Trabajo"
            '
            'txtTarifa
            '
            Me.txtTarifa.Location = New System.Drawing.Point(327, 52)
            Me.txtTarifa.Name = "txtTarifa"
            Me.txtTarifa.ReadOnly = True
            Me.txtTarifa.Size = New System.Drawing.Size(100, 20)
            Me.txtTarifa.TabIndex = 132
            '
            'btnTarea
            '
            Me.btnTarea.Location = New System.Drawing.Point(461, 27)
            Me.btnTarea.Name = "btnTarea"
            Me.btnTarea.Size = New System.Drawing.Size(29, 23)
            Me.btnTarea.TabIndex = 131
            Me.btnTarea.Text = ":::"
            Me.btnTarea.UseVisualStyleBackColor = True
            '
            'txtTarea
            '
            Me.txtTarea.Location = New System.Drawing.Point(96, 29)
            Me.txtTarea.Name = "txtTarea"
            Me.txtTarea.ReadOnly = True
            Me.txtTarea.Size = New System.Drawing.Size(361, 20)
            Me.txtTarea.TabIndex = 130
            '
            'lblTipoArea
            '
            Me.lblTipoArea.AutoSize = True
            Me.lblTipoArea.Location = New System.Drawing.Point(56, 34)
            Me.lblTipoArea.Name = "lblTipoArea"
            Me.lblTipoArea.Size = New System.Drawing.Size(35, 13)
            Me.lblTipoArea.TabIndex = 129
            Me.lblTipoArea.Text = "Tarea"
            '
            'dateFechaInicio
            '
            Me.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaInicio.Location = New System.Drawing.Point(343, 7)
            Me.dateFechaInicio.Name = "dateFechaInicio"
            Me.dateFechaInicio.Size = New System.Drawing.Size(84, 20)
            Me.dateFechaInicio.TabIndex = 126
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(302, 10)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 127
            Me.Label6.Text = "Fecha"
            '
            'frmGrupoTrabajoTarea
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(994, 494)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmGrupoTrabajoTarea"
            Me.Text = "frmGrupoTrabajoTarea"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvProduccion, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents dgvProduccion As System.Windows.Forms.DataGridView
        Friend WithEvents dateFechaInicio As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cboArea As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtHoraFin As System.Windows.Forms.TextBox
        Friend WithEvents txtHoraInicio As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTarifa As System.Windows.Forms.TextBox
        Friend WithEvents btnTarea As System.Windows.Forms.Button
        Friend WithEvents txtTarea As System.Windows.Forms.TextBox
        Friend WithEvents lblTipoArea As System.Windows.Forms.Label
        Friend WithEvents rdbPorProduccion As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPorCarga As System.Windows.Forms.RadioButton
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents txtgrt_ResponsableSecaderoQuemas As System.Windows.Forms.TextBox
        Friend WithEvents txtgrt_EsSecaderoQuema As System.Windows.Forms.TextBox
        Friend WithEvents chkEsTareo As System.Windows.Forms.CheckBox
        Friend WithEvents por_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Produccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pla_id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Conteo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Carga As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Fraccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Refrigerio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Bonificacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Factor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraTotales As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        'Friend WithEvents per_id As System.Windows.Forms.DataGridViewButtonColumn
    End Class

End Namespace