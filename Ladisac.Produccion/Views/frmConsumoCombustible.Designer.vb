<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsumoCombustible
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numCantidadTK1 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtArticuloTK1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAlmacenTK1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGlosaTK1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSecadero = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuemaHorno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtArticuloAlmacenTK1 = New System.Windows.Forms.TextBox()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numStockTK1 = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numSaldoTK1 = New System.Windows.Forms.NumericUpDown()
        Me.numSaldoTK2 = New System.Windows.Forms.NumericUpDown()
        Me.numStockTK2 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloAlmacenTK2 = New System.Windows.Forms.TextBox()
        Me.numCantidadTK2 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloTK2 = New System.Windows.Forms.TextBox()
        Me.txtAlmacenTK2 = New System.Windows.Forms.TextBox()
        Me.txtGlosaTK2 = New System.Windows.Forms.TextBox()
        Me.numSaldoTK3 = New System.Windows.Forms.NumericUpDown()
        Me.numStockTK3 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloAlmacenTK3 = New System.Windows.Forms.TextBox()
        Me.numCantidadTK3 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloTK3 = New System.Windows.Forms.TextBox()
        Me.txtAlmacenTK3 = New System.Windows.Forms.TextBox()
        Me.txtGlosaTK3 = New System.Windows.Forms.TextBox()
        Me.numSaldoTK4 = New System.Windows.Forms.NumericUpDown()
        Me.numStockTK4 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloAlmacenTK4 = New System.Windows.Forms.TextBox()
        Me.numCantidadTK4 = New System.Windows.Forms.NumericUpDown()
        Me.txtArticuloTK4 = New System.Windows.Forms.TextBox()
        Me.txtAlmacenTK4 = New System.Windows.Forms.TextBox()
        Me.txtGlosaTK4 = New System.Windows.Forms.TextBox()
        Me.rbtIngreso = New System.Windows.Forms.RadioButton()
        Me.rbtSalida = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtR500 = New System.Windows.Forms.RadioButton()
        Me.rbtGAS = New System.Windows.Forms.RadioButton()
        CType(Me.numCantidadTK1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStockTK1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSaldoTK1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSaldoTK2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStockTK2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidadTK2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSaldoTK3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStockTK3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidadTK3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSaldoTK4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStockTK4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidadTK4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(852, 28)
        Me.lblTitle.Text = "Consumo Combustible"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(471, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "Cantidad"
        '
        'numCantidadTK1
        '
        Me.numCantidadTK1.DecimalPlaces = 2
        Me.numCantidadTK1.Location = New System.Drawing.Point(474, 175)
        Me.numCantidadTK1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numCantidadTK1.Name = "numCantidadTK1"
        Me.numCantidadTK1.Size = New System.Drawing.Size(90, 20)
        Me.numCantidadTK1.TabIndex = 142
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(241, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "Articulo"
        '
        'txtArticuloTK1
        '
        Me.txtArticuloTK1.Location = New System.Drawing.Point(244, 175)
        Me.txtArticuloTK1.Name = "txtArticuloTK1"
        Me.txtArticuloTK1.Size = New System.Drawing.Size(107, 20)
        Me.txtArticuloTK1.TabIndex = 140
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(121, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Almacen"
        '
        'txtAlmacenTK1
        '
        Me.txtAlmacenTK1.Location = New System.Drawing.Point(124, 175)
        Me.txtAlmacenTK1.Name = "txtAlmacenTK1"
        Me.txtAlmacenTK1.Size = New System.Drawing.Size(101, 20)
        Me.txtAlmacenTK1.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(680, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Glosa"
        '
        'txtGlosaTK1
        '
        Me.txtGlosaTK1.Location = New System.Drawing.Point(683, 175)
        Me.txtGlosaTK1.MaxLength = 255
        Me.txtGlosaTK1.Multiline = True
        Me.txtGlosaTK1.Name = "txtGlosaTK1"
        Me.txtGlosaTK1.Size = New System.Drawing.Size(157, 20)
        Me.txtGlosaTK1.TabIndex = 136
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Secadero"
        '
        'txtSecadero
        '
        Me.txtSecadero.Location = New System.Drawing.Point(90, 123)
        Me.txtSecadero.MaxLength = 6
        Me.txtSecadero.Name = "txtSecadero"
        Me.txtSecadero.Size = New System.Drawing.Size(352, 20)
        Me.txtSecadero.TabIndex = 134
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(357, 71)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 133
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(314, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(90, 71)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Quema Horno"
        '
        'txtQuemaHorno
        '
        Me.txtQuemaHorno.Location = New System.Drawing.Point(90, 97)
        Me.txtQuemaHorno.Name = "txtQuemaHorno"
        Me.txtQuemaHorno.Size = New System.Drawing.Size(352, 20)
        Me.txtQuemaHorno.TabIndex = 128
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "Art. Alm."
        '
        'txtArticuloAlmacenTK1
        '
        Me.txtArticuloAlmacenTK1.Location = New System.Drawing.Point(15, 175)
        Me.txtArticuloAlmacenTK1.Name = "txtArticuloAlmacenTK1"
        Me.txtArticuloAlmacenTK1.Size = New System.Drawing.Size(91, 20)
        Me.txtArticuloAlmacenTK1.TabIndex = 145
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(365, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 148
        Me.Label10.Text = "Stock"
        '
        'numStockTK1
        '
        Me.numStockTK1.DecimalPlaces = 2
        Me.numStockTK1.Location = New System.Drawing.Point(368, 175)
        Me.numStockTK1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numStockTK1.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numStockTK1.Name = "numStockTK1"
        Me.numStockTK1.Size = New System.Drawing.Size(90, 20)
        Me.numStockTK1.TabIndex = 147
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(572, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 150
        Me.Label11.Text = "Saldo"
        '
        'numSaldoTK1
        '
        Me.numSaldoTK1.DecimalPlaces = 2
        Me.numSaldoTK1.Location = New System.Drawing.Point(575, 175)
        Me.numSaldoTK1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numSaldoTK1.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numSaldoTK1.Name = "numSaldoTK1"
        Me.numSaldoTK1.Size = New System.Drawing.Size(90, 20)
        Me.numSaldoTK1.TabIndex = 149
        '
        'numSaldoTK2
        '
        Me.numSaldoTK2.DecimalPlaces = 2
        Me.numSaldoTK2.Location = New System.Drawing.Point(575, 201)
        Me.numSaldoTK2.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numSaldoTK2.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numSaldoTK2.Name = "numSaldoTK2"
        Me.numSaldoTK2.Size = New System.Drawing.Size(90, 20)
        Me.numSaldoTK2.TabIndex = 157
        '
        'numStockTK2
        '
        Me.numStockTK2.DecimalPlaces = 2
        Me.numStockTK2.Location = New System.Drawing.Point(368, 201)
        Me.numStockTK2.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numStockTK2.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numStockTK2.Name = "numStockTK2"
        Me.numStockTK2.Size = New System.Drawing.Size(90, 20)
        Me.numStockTK2.TabIndex = 156
        '
        'txtArticuloAlmacenTK2
        '
        Me.txtArticuloAlmacenTK2.Location = New System.Drawing.Point(15, 201)
        Me.txtArticuloAlmacenTK2.Name = "txtArticuloAlmacenTK2"
        Me.txtArticuloAlmacenTK2.Size = New System.Drawing.Size(91, 20)
        Me.txtArticuloAlmacenTK2.TabIndex = 155
        '
        'numCantidadTK2
        '
        Me.numCantidadTK2.DecimalPlaces = 2
        Me.numCantidadTK2.Location = New System.Drawing.Point(474, 201)
        Me.numCantidadTK2.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numCantidadTK2.Name = "numCantidadTK2"
        Me.numCantidadTK2.Size = New System.Drawing.Size(90, 20)
        Me.numCantidadTK2.TabIndex = 154
        '
        'txtArticuloTK2
        '
        Me.txtArticuloTK2.Location = New System.Drawing.Point(244, 201)
        Me.txtArticuloTK2.Name = "txtArticuloTK2"
        Me.txtArticuloTK2.Size = New System.Drawing.Size(107, 20)
        Me.txtArticuloTK2.TabIndex = 153
        '
        'txtAlmacenTK2
        '
        Me.txtAlmacenTK2.Location = New System.Drawing.Point(124, 201)
        Me.txtAlmacenTK2.Name = "txtAlmacenTK2"
        Me.txtAlmacenTK2.Size = New System.Drawing.Size(101, 20)
        Me.txtAlmacenTK2.TabIndex = 152
        '
        'txtGlosaTK2
        '
        Me.txtGlosaTK2.Location = New System.Drawing.Point(683, 201)
        Me.txtGlosaTK2.MaxLength = 255
        Me.txtGlosaTK2.Multiline = True
        Me.txtGlosaTK2.Name = "txtGlosaTK2"
        Me.txtGlosaTK2.Size = New System.Drawing.Size(157, 20)
        Me.txtGlosaTK2.TabIndex = 151
        '
        'numSaldoTK3
        '
        Me.numSaldoTK3.DecimalPlaces = 2
        Me.numSaldoTK3.Location = New System.Drawing.Point(575, 227)
        Me.numSaldoTK3.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numSaldoTK3.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numSaldoTK3.Name = "numSaldoTK3"
        Me.numSaldoTK3.Size = New System.Drawing.Size(90, 20)
        Me.numSaldoTK3.TabIndex = 164
        '
        'numStockTK3
        '
        Me.numStockTK3.DecimalPlaces = 2
        Me.numStockTK3.Location = New System.Drawing.Point(368, 227)
        Me.numStockTK3.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numStockTK3.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numStockTK3.Name = "numStockTK3"
        Me.numStockTK3.Size = New System.Drawing.Size(90, 20)
        Me.numStockTK3.TabIndex = 163
        '
        'txtArticuloAlmacenTK3
        '
        Me.txtArticuloAlmacenTK3.Location = New System.Drawing.Point(15, 227)
        Me.txtArticuloAlmacenTK3.Name = "txtArticuloAlmacenTK3"
        Me.txtArticuloAlmacenTK3.Size = New System.Drawing.Size(91, 20)
        Me.txtArticuloAlmacenTK3.TabIndex = 162
        '
        'numCantidadTK3
        '
        Me.numCantidadTK3.DecimalPlaces = 2
        Me.numCantidadTK3.Location = New System.Drawing.Point(474, 227)
        Me.numCantidadTK3.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numCantidadTK3.Name = "numCantidadTK3"
        Me.numCantidadTK3.Size = New System.Drawing.Size(90, 20)
        Me.numCantidadTK3.TabIndex = 161
        '
        'txtArticuloTK3
        '
        Me.txtArticuloTK3.Location = New System.Drawing.Point(244, 227)
        Me.txtArticuloTK3.Name = "txtArticuloTK3"
        Me.txtArticuloTK3.Size = New System.Drawing.Size(107, 20)
        Me.txtArticuloTK3.TabIndex = 160
        '
        'txtAlmacenTK3
        '
        Me.txtAlmacenTK3.Location = New System.Drawing.Point(124, 227)
        Me.txtAlmacenTK3.Name = "txtAlmacenTK3"
        Me.txtAlmacenTK3.Size = New System.Drawing.Size(101, 20)
        Me.txtAlmacenTK3.TabIndex = 159
        '
        'txtGlosaTK3
        '
        Me.txtGlosaTK3.Location = New System.Drawing.Point(683, 227)
        Me.txtGlosaTK3.MaxLength = 255
        Me.txtGlosaTK3.Multiline = True
        Me.txtGlosaTK3.Name = "txtGlosaTK3"
        Me.txtGlosaTK3.Size = New System.Drawing.Size(157, 20)
        Me.txtGlosaTK3.TabIndex = 158
        '
        'numSaldoTK4
        '
        Me.numSaldoTK4.DecimalPlaces = 2
        Me.numSaldoTK4.Location = New System.Drawing.Point(575, 253)
        Me.numSaldoTK4.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numSaldoTK4.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numSaldoTK4.Name = "numSaldoTK4"
        Me.numSaldoTK4.Size = New System.Drawing.Size(90, 20)
        Me.numSaldoTK4.TabIndex = 171
        '
        'numStockTK4
        '
        Me.numStockTK4.DecimalPlaces = 2
        Me.numStockTK4.Location = New System.Drawing.Point(368, 253)
        Me.numStockTK4.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numStockTK4.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.numStockTK4.Name = "numStockTK4"
        Me.numStockTK4.Size = New System.Drawing.Size(90, 20)
        Me.numStockTK4.TabIndex = 170
        '
        'txtArticuloAlmacenTK4
        '
        Me.txtArticuloAlmacenTK4.Location = New System.Drawing.Point(15, 253)
        Me.txtArticuloAlmacenTK4.Name = "txtArticuloAlmacenTK4"
        Me.txtArticuloAlmacenTK4.Size = New System.Drawing.Size(91, 20)
        Me.txtArticuloAlmacenTK4.TabIndex = 169
        '
        'numCantidadTK4
        '
        Me.numCantidadTK4.DecimalPlaces = 2
        Me.numCantidadTK4.Location = New System.Drawing.Point(474, 253)
        Me.numCantidadTK4.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numCantidadTK4.Name = "numCantidadTK4"
        Me.numCantidadTK4.Size = New System.Drawing.Size(90, 20)
        Me.numCantidadTK4.TabIndex = 168
        '
        'txtArticuloTK4
        '
        Me.txtArticuloTK4.Location = New System.Drawing.Point(244, 253)
        Me.txtArticuloTK4.Name = "txtArticuloTK4"
        Me.txtArticuloTK4.Size = New System.Drawing.Size(107, 20)
        Me.txtArticuloTK4.TabIndex = 167
        '
        'txtAlmacenTK4
        '
        Me.txtAlmacenTK4.Location = New System.Drawing.Point(124, 253)
        Me.txtAlmacenTK4.Name = "txtAlmacenTK4"
        Me.txtAlmacenTK4.Size = New System.Drawing.Size(101, 20)
        Me.txtAlmacenTK4.TabIndex = 166
        '
        'txtGlosaTK4
        '
        Me.txtGlosaTK4.Location = New System.Drawing.Point(683, 253)
        Me.txtGlosaTK4.MaxLength = 255
        Me.txtGlosaTK4.Multiline = True
        Me.txtGlosaTK4.Name = "txtGlosaTK4"
        Me.txtGlosaTK4.Size = New System.Drawing.Size(157, 20)
        Me.txtGlosaTK4.TabIndex = 165
        '
        'rbtIngreso
        '
        Me.rbtIngreso.AutoSize = True
        Me.rbtIngreso.Location = New System.Drawing.Point(12, 19)
        Me.rbtIngreso.Name = "rbtIngreso"
        Me.rbtIngreso.Size = New System.Drawing.Size(92, 17)
        Me.rbtIngreso.TabIndex = 172
        Me.rbtIngreso.TabStop = True
        Me.rbtIngreso.Text = "Calentamiento"
        Me.rbtIngreso.UseVisualStyleBackColor = True
        '
        'rbtSalida
        '
        Me.rbtSalida.AutoSize = True
        Me.rbtSalida.Location = New System.Drawing.Point(12, 45)
        Me.rbtSalida.Name = "rbtSalida"
        Me.rbtSalida.Size = New System.Drawing.Size(83, 17)
        Me.rbtSalida.TabIndex = 173
        Me.rbtSalida.TabStop = True
        Me.rbtSalida.Text = "Enfriamiento"
        Me.rbtSalida.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtIngreso)
        Me.GroupBox1.Controls.Add(Me.rbtSalida)
        Me.GroupBox1.Location = New System.Drawing.Point(474, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(132, 72)
        Me.GroupBox1.TabIndex = 174
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "I/S Combustible"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtR500)
        Me.GroupBox2.Controls.Add(Me.rbtGAS)
        Me.GroupBox2.Location = New System.Drawing.Point(683, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 72)
        Me.GroupBox2.TabIndex = 175
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Combustible"
        '
        'rbtR500
        '
        Me.rbtR500.AutoSize = True
        Me.rbtR500.Checked = True
        Me.rbtR500.Location = New System.Drawing.Point(12, 19)
        Me.rbtR500.Name = "rbtR500"
        Me.rbtR500.Size = New System.Drawing.Size(51, 17)
        Me.rbtR500.TabIndex = 172
        Me.rbtR500.TabStop = True
        Me.rbtR500.Text = "R500"
        Me.rbtR500.UseVisualStyleBackColor = True
        '
        'rbtGAS
        '
        Me.rbtGAS.AutoSize = True
        Me.rbtGAS.Location = New System.Drawing.Point(12, 45)
        Me.rbtGAS.Name = "rbtGAS"
        Me.rbtGAS.Size = New System.Drawing.Size(47, 17)
        Me.rbtGAS.TabIndex = 173
        Me.rbtGAS.TabStop = True
        Me.rbtGAS.Text = "GAS"
        Me.rbtGAS.UseVisualStyleBackColor = True
        '
        'frmConsumoCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(852, 290)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.numSaldoTK4)
        Me.Controls.Add(Me.numStockTK4)
        Me.Controls.Add(Me.txtArticuloAlmacenTK4)
        Me.Controls.Add(Me.numCantidadTK4)
        Me.Controls.Add(Me.txtArticuloTK4)
        Me.Controls.Add(Me.txtAlmacenTK4)
        Me.Controls.Add(Me.txtGlosaTK4)
        Me.Controls.Add(Me.numSaldoTK3)
        Me.Controls.Add(Me.numStockTK3)
        Me.Controls.Add(Me.txtArticuloAlmacenTK3)
        Me.Controls.Add(Me.numCantidadTK3)
        Me.Controls.Add(Me.txtArticuloTK3)
        Me.Controls.Add(Me.txtAlmacenTK3)
        Me.Controls.Add(Me.txtGlosaTK3)
        Me.Controls.Add(Me.numSaldoTK2)
        Me.Controls.Add(Me.numStockTK2)
        Me.Controls.Add(Me.txtArticuloAlmacenTK2)
        Me.Controls.Add(Me.numCantidadTK2)
        Me.Controls.Add(Me.txtArticuloTK2)
        Me.Controls.Add(Me.txtAlmacenTK2)
        Me.Controls.Add(Me.txtGlosaTK2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.numSaldoTK1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.numStockTK1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtArticuloAlmacenTK1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numCantidadTK1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtArticuloTK1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAlmacenTK1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGlosaTK1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSecadero)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQuemaHorno)
        Me.Name = "frmConsumoCombustible"
        Me.Text = "Consumo Combustible"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtQuemaHorno, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.txtSecadero, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtGlosaTK1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacenTK1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloTK1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.numCantidadTK1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloAlmacenTK1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.numStockTK1, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numSaldoTK1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtGlosaTK2, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacenTK2, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloTK2, 0)
        Me.Controls.SetChildIndex(Me.numCantidadTK2, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloAlmacenTK2, 0)
        Me.Controls.SetChildIndex(Me.numStockTK2, 0)
        Me.Controls.SetChildIndex(Me.numSaldoTK2, 0)
        Me.Controls.SetChildIndex(Me.txtGlosaTK3, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacenTK3, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloTK3, 0)
        Me.Controls.SetChildIndex(Me.numCantidadTK3, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloAlmacenTK3, 0)
        Me.Controls.SetChildIndex(Me.numStockTK3, 0)
        Me.Controls.SetChildIndex(Me.numSaldoTK3, 0)
        Me.Controls.SetChildIndex(Me.txtGlosaTK4, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacenTK4, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloTK4, 0)
        Me.Controls.SetChildIndex(Me.numCantidadTK4, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloAlmacenTK4, 0)
        Me.Controls.SetChildIndex(Me.numStockTK4, 0)
        Me.Controls.SetChildIndex(Me.numSaldoTK4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.numCantidadTK1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStockTK1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSaldoTK1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSaldoTK2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStockTK2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidadTK2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSaldoTK3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStockTK3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidadTK3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSaldoTK4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStockTK4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidadTK4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numCantidadTK1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtArticuloTK1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacenTK1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGlosaTK1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSecadero As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuemaHorno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtArticuloAlmacenTK1 As System.Windows.Forms.TextBox
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numSaldoTK1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numStockTK1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSaldoTK3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStockTK3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloAlmacenTK3 As System.Windows.Forms.TextBox
    Friend WithEvents numCantidadTK3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloTK3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAlmacenTK3 As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosaTK3 As System.Windows.Forms.TextBox
    Friend WithEvents numSaldoTK2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStockTK2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloAlmacenTK2 As System.Windows.Forms.TextBox
    Friend WithEvents numCantidadTK2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloTK2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAlmacenTK2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosaTK2 As System.Windows.Forms.TextBox
    Friend WithEvents numSaldoTK4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStockTK4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloAlmacenTK4 As System.Windows.Forms.TextBox
    Friend WithEvents numCantidadTK4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArticuloTK4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAlmacenTK4 As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosaTK4 As System.Windows.Forms.TextBox
    Friend WithEvents rbtSalida As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtR500 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGAS As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
