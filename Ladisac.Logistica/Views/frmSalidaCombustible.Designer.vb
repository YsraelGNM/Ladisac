<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidaCombustible
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
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.numCantidad = New System.Windows.Forms.NumericUpDown()
        Me.numKilometraje = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numHorometro = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOR = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPU = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnSurtidor = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnLimpiarLectura = New System.Windows.Forms.Button()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKilometraje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHorometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(557, 28)
        Me.lblTitle.Text = "Salida de Combustible"
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(104, 97)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(170, 21)
        Me.cboTipoDocumento.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Tipo Documento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Cantidad"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(385, 69)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(146, 20)
        Me.dtpFecha.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(278, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(105, 71)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Placa"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(105, 124)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(90, 20)
        Me.txtPlaca.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Empresa"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(104, 150)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(427, 20)
        Me.txtEmpresa.TabIndex = 64
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Chofer"
        '
        'txtChofer
        '
        Me.txtChofer.Location = New System.Drawing.Point(105, 176)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(426, 20)
        Me.txtChofer.TabIndex = 66
        '
        'numCantidad
        '
        Me.numCantidad.DecimalPlaces = 3
        Me.numCantidad.Location = New System.Drawing.Point(104, 201)
        Me.numCantidad.Name = "numCantidad"
        Me.numCantidad.Size = New System.Drawing.Size(91, 20)
        Me.numCantidad.TabIndex = 68
        '
        'numKilometraje
        '
        Me.numKilometraje.DecimalPlaces = 3
        Me.numKilometraje.Location = New System.Drawing.Point(104, 227)
        Me.numKilometraje.Name = "numKilometraje"
        Me.numKilometraje.Size = New System.Drawing.Size(91, 20)
        Me.numKilometraje.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Kilometraje"
        '
        'numHorometro
        '
        Me.numHorometro.DecimalPlaces = 3
        Me.numHorometro.Location = New System.Drawing.Point(104, 254)
        Me.numHorometro.Name = "numHorometro"
        Me.numHorometro.Size = New System.Drawing.Size(91, 20)
        Me.numHorometro.TabIndex = 72
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Horometro"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(278, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 13)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Orden Requerimiento"
        '
        'txtOR
        '
        Me.txtOR.Location = New System.Drawing.Point(385, 124)
        Me.txtOR.Name = "txtOR"
        Me.txtOR.Size = New System.Drawing.Size(146, 20)
        Me.txtOR.TabIndex = 73
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(278, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Almacen"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(385, 98)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(146, 20)
        Me.txtAlmacen.TabIndex = 75
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(278, 205)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Stock"
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.White
        Me.txtStock.Location = New System.Drawing.Point(385, 201)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(146, 20)
        Me.txtStock.TabIndex = 77
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(278, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Precio Unitario"
        '
        'txtPU
        '
        Me.txtPU.BackColor = System.Drawing.Color.White
        Me.txtPU.Location = New System.Drawing.Point(385, 227)
        Me.txtPU.Name = "txtPU"
        Me.txtPU.Size = New System.Drawing.Size(146, 20)
        Me.txtPU.TabIndex = 79
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 284)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Observacion"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(104, 280)
        Me.txtObservacion.MaxLength = 255
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(426, 20)
        Me.txtObservacion.TabIndex = 81
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnSurtidor
        '
        Me.btnSurtidor.Location = New System.Drawing.Point(395, 307)
        Me.btnSurtidor.Name = "btnSurtidor"
        Me.btnSurtidor.Size = New System.Drawing.Size(135, 64)
        Me.btnSurtidor.TabIndex = 83
        Me.btnSurtidor.Text = "SURTIDOR"
        Me.btnSurtidor.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'btnLimpiarLectura
        '
        Me.btnLimpiarLectura.Location = New System.Drawing.Point(12, 321)
        Me.btnLimpiarLectura.Name = "btnLimpiarLectura"
        Me.btnLimpiarLectura.Size = New System.Drawing.Size(104, 37)
        Me.btnLimpiarLectura.TabIndex = 84
        Me.btnLimpiarLectura.Text = "LIMPIAR LECTURA"
        Me.btnLimpiarLectura.UseVisualStyleBackColor = True
        '
        'frmSalidaCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(557, 383)
        Me.Controls.Add(Me.btnLimpiarLectura)
        Me.Controls.Add(Me.btnSurtidor)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPU)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtOR)
        Me.Controls.Add(Me.numHorometro)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.numKilometraje)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numCantidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtChofer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Controls.Add(Me.cboTipoDocumento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlaca)
        Me.Name = "frmSalidaCombustible"
        Me.Text = "Salida de Combustible"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtPlaca, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboTipoDocumento, 0)
        Me.Controls.SetChildIndex(Me.txtEmpresa, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtChofer, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.numCantidad, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numKilometraje, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.numHorometro, 0)
        Me.Controls.SetChildIndex(Me.txtOR, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacen, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtStock, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtPU, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtObservacion, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.btnSurtidor, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarLectura, 0)
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKilometraje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHorometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents numCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents numKilometraje As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numHorometro As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOR As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPU As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents btnSurtidor As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnLimpiarLectura As System.Windows.Forms.Button

End Class
