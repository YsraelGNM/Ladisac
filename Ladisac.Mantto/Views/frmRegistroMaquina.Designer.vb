<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroMaquina
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
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.lblEntidad = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.numTn = New System.Windows.Forms.NumericUpDown()
        Me.lblToneladas = New System.Windows.Forms.Label()
        Me.numDia = New System.Windows.Forms.NumericUpDown()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.numUso = New System.Windows.Forms.NumericUpDown()
        Me.lblUsos = New System.Windows.Forms.Label()
        Me.numHorometro = New System.Windows.Forms.NumericUpDown()
        Me.lblHorometro = New System.Windows.Forms.Label()
        Me.numKilometraje = New System.Windows.Forms.NumericUpDown()
        Me.lblKilometraje = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtpFechaGrupo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvGrupo = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilometraje_Ant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horometro_Ant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilometraje_Nue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horometro_Nue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilometro_Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horometro_Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.numTn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHorometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKilometraje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(720, 28)
        Me.lblTitle.Text = "Registro de Máquina"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(6, 14)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 118
        Me.lblCodigo.Text = "Codigo"
        '
        'txtEntidad
        '
        Me.txtEntidad.Location = New System.Drawing.Point(84, 36)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(200, 20)
        Me.txtEntidad.TabIndex = 115
        '
        'lblEntidad
        '
        Me.lblEntidad.AutoSize = True
        Me.lblEntidad.Location = New System.Drawing.Point(6, 40)
        Me.lblEntidad.Name = "lblEntidad"
        Me.lblEntidad.Size = New System.Drawing.Size(43, 13)
        Me.lblEntidad.TabIndex = 116
        Me.lblEntidad.Text = "Entidad"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(84, 10)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 117
        '
        'numTn
        '
        Me.numTn.DecimalPlaces = 4
        Me.numTn.Location = New System.Drawing.Point(84, 140)
        Me.numTn.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numTn.Name = "numTn"
        Me.numTn.Size = New System.Drawing.Size(120, 20)
        Me.numTn.TabIndex = 128
        '
        'lblToneladas
        '
        Me.lblToneladas.AutoSize = True
        Me.lblToneladas.Location = New System.Drawing.Point(6, 142)
        Me.lblToneladas.Name = "lblToneladas"
        Me.lblToneladas.Size = New System.Drawing.Size(57, 13)
        Me.lblToneladas.TabIndex = 127
        Me.lblToneladas.Text = "Toneladas"
        '
        'numDia
        '
        Me.numDia.Location = New System.Drawing.Point(84, 166)
        Me.numDia.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDia.Name = "numDia"
        Me.numDia.Size = New System.Drawing.Size(120, 20)
        Me.numDia.TabIndex = 130
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Location = New System.Drawing.Point(6, 168)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(28, 13)
        Me.lblDias.TabIndex = 129
        Me.lblDias.Text = "Dias"
        '
        'numUso
        '
        Me.numUso.DecimalPlaces = 4
        Me.numUso.Location = New System.Drawing.Point(84, 192)
        Me.numUso.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numUso.Name = "numUso"
        Me.numUso.Size = New System.Drawing.Size(120, 20)
        Me.numUso.TabIndex = 132
        '
        'lblUsos
        '
        Me.lblUsos.AutoSize = True
        Me.lblUsos.Location = New System.Drawing.Point(6, 194)
        Me.lblUsos.Name = "lblUsos"
        Me.lblUsos.Size = New System.Drawing.Size(31, 13)
        Me.lblUsos.TabIndex = 131
        Me.lblUsos.Text = "Usos"
        '
        'numHorometro
        '
        Me.numHorometro.DecimalPlaces = 4
        Me.numHorometro.Location = New System.Drawing.Point(84, 114)
        Me.numHorometro.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHorometro.Name = "numHorometro"
        Me.numHorometro.Size = New System.Drawing.Size(120, 20)
        Me.numHorometro.TabIndex = 138
        '
        'lblHorometro
        '
        Me.lblHorometro.AutoSize = True
        Me.lblHorometro.Location = New System.Drawing.Point(6, 116)
        Me.lblHorometro.Name = "lblHorometro"
        Me.lblHorometro.Size = New System.Drawing.Size(56, 13)
        Me.lblHorometro.TabIndex = 137
        Me.lblHorometro.Text = "Horómetro"
        '
        'numKilometraje
        '
        Me.numKilometraje.DecimalPlaces = 4
        Me.numKilometraje.Location = New System.Drawing.Point(84, 88)
        Me.numKilometraje.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numKilometraje.Name = "numKilometraje"
        Me.numKilometraje.Size = New System.Drawing.Size(120, 20)
        Me.numKilometraje.TabIndex = 136
        '
        'lblKilometraje
        '
        Me.lblKilometraje.AutoSize = True
        Me.lblKilometraje.Location = New System.Drawing.Point(6, 90)
        Me.lblKilometraje.Name = "lblKilometraje"
        Me.lblKilometraje.Size = New System.Drawing.Size(58, 13)
        Me.lblKilometraje.TabIndex = 135
        Me.lblKilometraje.Text = "Kilometraje"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(6, 64)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 133
        Me.lblFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(84, 62)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(120, 20)
        Me.dtpFecha.TabIndex = 139
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Chofer"
        '
        'txtChofer
        '
        Me.txtChofer.Location = New System.Drawing.Point(334, 37)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(354, 20)
        Me.txtChofer.TabIndex = 141
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 226)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Observacion"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(84, 222)
        Me.txtObservacion.MaxLength = 255
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(604, 20)
        Me.txtObservacion.TabIndex = 143
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(712, 305)
        Me.TabControl1.TabIndex = 145
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtpFechaGrupo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dgvGrupo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(704, 279)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Grupo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtpFechaGrupo
        '
        Me.dtpFechaGrupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaGrupo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaGrupo.Location = New System.Drawing.Point(578, 6)
        Me.dtpFechaGrupo.Name = "dtpFechaGrupo"
        Me.dtpFechaGrupo.Size = New System.Drawing.Size(120, 20)
        Me.dtpFechaGrupo.TabIndex = 141
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(535, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Fecha"
        '
        'dgvGrupo
        '
        Me.dgvGrupo.AllowUserToAddRows = False
        Me.dgvGrupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrupo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ENO_ID, Me.Kilometraje_Ant, Me.Horometro_Ant, Me.Kilometraje_Nue, Me.Horometro_Nue, Me.Kilometro_Total, Me.Horometro_Total})
        Me.dgvGrupo.Location = New System.Drawing.Point(5, 32)
        Me.dgvGrupo.Name = "dgvGrupo"
        Me.dgvGrupo.Size = New System.Drawing.Size(693, 241)
        Me.dgvGrupo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblCodigo)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtCodigo)
        Me.TabPage2.Controls.Add(Me.txtObservacion)
        Me.TabPage2.Controls.Add(Me.lblEntidad)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtEntidad)
        Me.TabPage2.Controls.Add(Me.txtChofer)
        Me.TabPage2.Controls.Add(Me.lblToneladas)
        Me.TabPage2.Controls.Add(Me.numTn)
        Me.TabPage2.Controls.Add(Me.dtpFecha)
        Me.TabPage2.Controls.Add(Me.lblDias)
        Me.TabPage2.Controls.Add(Me.numHorometro)
        Me.TabPage2.Controls.Add(Me.numDia)
        Me.TabPage2.Controls.Add(Me.lblHorometro)
        Me.TabPage2.Controls.Add(Me.lblUsos)
        Me.TabPage2.Controls.Add(Me.numKilometraje)
        Me.TabPage2.Controls.Add(Me.numUso)
        Me.TabPage2.Controls.Add(Me.lblKilometraje)
        Me.TabPage2.Controls.Add(Me.lblFecha)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(704, 279)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Individual"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Placa"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 93
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Kilometraje"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 93
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Horometro"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 93
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "RMD_ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 92
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "NRO GUIA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 93
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "O.R."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 93
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "ORDEN SERVICIO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 93
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "OBSERVACION"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "NRO GUIA"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "O.R."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "ORDEN SERVICIO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "OBSERVACION"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'ENO_ID
        '
        Me.ENO_ID.HeaderText = "Entidad"
        Me.ENO_ID.Name = "ENO_ID"
        '
        'Kilometraje_Ant
        '
        Me.Kilometraje_Ant.HeaderText = "Kilometraje Ant"
        Me.Kilometraje_Ant.Name = "Kilometraje_Ant"
        '
        'Horometro_Ant
        '
        Me.Horometro_Ant.HeaderText = "Horometro Ant"
        Me.Horometro_Ant.Name = "Horometro_Ant"
        '
        'Kilometraje_Nue
        '
        Me.Kilometraje_Nue.HeaderText = "Kilometraje Nue"
        Me.Kilometraje_Nue.Name = "Kilometraje_Nue"
        '
        'Horometro_Nue
        '
        Me.Horometro_Nue.HeaderText = "Horometro Nue"
        Me.Horometro_Nue.Name = "Horometro_Nue"
        '
        'Kilometro_Total
        '
        Me.Kilometro_Total.HeaderText = "Kilometro"
        Me.Kilometro_Total.Name = "Kilometro_Total"
        '
        'Horometro_Total
        '
        Me.Horometro_Total.HeaderText = "Horometro"
        Me.Horometro_Total.Name = "Horometro_Total"
        '
        'frmRegistroMaquina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(720, 368)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmRegistroMaquina"
        Me.Text = "Registro Maquina"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.numTn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHorometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKilometraje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
    Friend WithEvents lblEntidad As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents numTn As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblToneladas As System.Windows.Forms.Label
    Friend WithEvents numDia As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents numUso As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblUsos As System.Windows.Forms.Label
    Friend WithEvents numHorometro As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHorometro As System.Windows.Forms.Label
    Friend WithEvents numKilometraje As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblKilometraje As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dtpFechaGrupo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvGrupo As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
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
    Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilometraje_Ant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horometro_Ant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilometraje_Nue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horometro_Nue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilometro_Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horometro_Total As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
