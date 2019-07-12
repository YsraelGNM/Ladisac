<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLadrillo
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numTabla = New System.Windows.Forms.NumericUpDown()
        Me.numTemperatura = New System.Windows.Forms.NumericUpDown()
        Me.numTiempo = New System.Windows.Forms.NumericUpDown()
        Me.numCorte = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.numVagon = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numParametroQuema = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.numTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTemperatura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTiempo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVagon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numParametroQuema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(475, 28)
        Me.lblTitle.Text = "Ladrillo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(109, 67)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(109, 93)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(333, 20)
        Me.txtDescripcion.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Temp. Coccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Tiempo Coccion"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Cant. Tabla"
        '
        'numTabla
        '
        Me.numTabla.Location = New System.Drawing.Point(109, 143)
        Me.numTabla.Name = "numTabla"
        Me.numTabla.Size = New System.Drawing.Size(90, 20)
        Me.numTabla.TabIndex = 27
        '
        'numTemperatura
        '
        Me.numTemperatura.DecimalPlaces = 2
        Me.numTemperatura.Location = New System.Drawing.Point(109, 193)
        Me.numTemperatura.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numTemperatura.Name = "numTemperatura"
        Me.numTemperatura.Size = New System.Drawing.Size(90, 20)
        Me.numTemperatura.TabIndex = 28
        '
        'numTiempo
        '
        Me.numTiempo.DecimalPlaces = 2
        Me.numTiempo.Location = New System.Drawing.Point(109, 168)
        Me.numTiempo.Name = "numTiempo"
        Me.numTiempo.Size = New System.Drawing.Size(90, 20)
        Me.numTiempo.TabIndex = 29
        '
        'numCorte
        '
        Me.numCorte.Location = New System.Drawing.Point(109, 118)
        Me.numCorte.Name = "numCorte"
        Me.numCorte.Size = New System.Drawing.Size(90, 20)
        Me.numCorte.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Cant. Corte"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'numVagon
        '
        Me.numVagon.Location = New System.Drawing.Point(109, 219)
        Me.numVagon.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numVagon.Name = "numVagon"
        Me.numVagon.Size = New System.Drawing.Size(90, 20)
        Me.numVagon.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Cant. Vagon"
        '
        'numParametroQuema
        '
        Me.numParametroQuema.Location = New System.Drawing.Point(109, 245)
        Me.numParametroQuema.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numParametroQuema.Name = "numParametroQuema"
        Me.numParametroQuema.Size = New System.Drawing.Size(90, 20)
        Me.numParametroQuema.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Parametro Quema"
        '
        'frmLadrillo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(475, 283)
        Me.Controls.Add(Me.numParametroQuema)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numVagon)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.numCorte)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numTiempo)
        Me.Controls.Add(Me.numTemperatura)
        Me.Controls.Add(Me.numTabla)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Name = "frmLadrillo"
        Me.Text = "Ladrillo"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.numTabla, 0)
        Me.Controls.SetChildIndex(Me.numTemperatura, 0)
        Me.Controls.SetChildIndex(Me.numTiempo, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numCorte, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.numVagon, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numParametroQuema, 0)
        CType(Me.numTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTemperatura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTiempo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCorte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVagon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numParametroQuema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numTabla As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTemperatura As System.Windows.Forms.NumericUpDown
    Friend WithEvents numTiempo As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCorte As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents numVagon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numParametroQuema As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
