<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccion
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
        Me.txtLadrillo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExtrusora = New System.Windows.Forms.TextBox()
        Me.cboTipoProduccion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.numCorte = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numTabla = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numReciclaje = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIng1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCortadora = New System.Windows.Forms.TextBox()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numHoraFinal = New System.Windows.Forms.NumericUpDown()
        Me.numHoraInicio = New System.Windows.Forms.NumericUpDown()
        Me.numVagon = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkFinalizada = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtConteo = New System.Windows.Forms.MaskedTextBox()
        Me.txtCarga = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDiferencia = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtIng2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtOpe2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtOpe1 = New System.Windows.Forms.TextBox()
        Me.dtpFechaFinalizada = New System.Windows.Forms.DateTimePicker()
        CType(Me.numCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numReciclaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoraFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoraInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVagon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(457, 28)
        Me.lblTitle.Text = "Produccion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(121, 72)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Ladrillo"
        '
        'txtLadrillo
        '
        Me.txtLadrillo.Location = New System.Drawing.Point(121, 98)
        Me.txtLadrillo.Name = "txtLadrillo"
        Me.txtLadrillo.Size = New System.Drawing.Size(294, 20)
        Me.txtLadrillo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(121, 124)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(294, 20)
        Me.txtPlanta.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Extrusora"
        '
        'txtExtrusora
        '
        Me.txtExtrusora.Location = New System.Drawing.Point(121, 150)
        Me.txtExtrusora.Name = "txtExtrusora"
        Me.txtExtrusora.Size = New System.Drawing.Size(294, 20)
        Me.txtExtrusora.TabIndex = 4
        '
        'cboTipoProduccion
        '
        Me.cboTipoProduccion.FormattingEnabled = True
        Me.cboTipoProduccion.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboTipoProduccion.Location = New System.Drawing.Point(121, 308)
        Me.cboTipoProduccion.Name = "cboTipoProduccion"
        Me.cboTipoProduccion.Size = New System.Drawing.Size(90, 21)
        Me.cboTipoProduccion.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Tipo Produccion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 337)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Observacion"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(121, 334)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(294, 20)
        Me.txtObservacion.TabIndex = 8
        '
        'numCorte
        '
        Me.numCorte.Location = New System.Drawing.Point(121, 360)
        Me.numCorte.Name = "numCorte"
        Me.numCorte.Size = New System.Drawing.Size(79, 20)
        Me.numCorte.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Cant. Lad. X Corte"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(330, 72)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 110
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(287, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Fecha"
        '
        'numTabla
        '
        Me.numTabla.Location = New System.Drawing.Point(121, 386)
        Me.numTabla.Name = "numTabla"
        Me.numTabla.Size = New System.Drawing.Size(79, 20)
        Me.numTabla.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 390)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 13)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "Cant. Lad. X Tabla"
        '
        'numReciclaje
        '
        Me.numReciclaje.DecimalPlaces = 2
        Me.numReciclaje.Location = New System.Drawing.Point(360, 414)
        Me.numReciclaje.Name = "numReciclaje"
        Me.numReciclaje.Size = New System.Drawing.Size(56, 20)
        Me.numReciclaje.TabIndex = 14
        Me.numReciclaje.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(287, 416)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Est. Reciclaje"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Ing."
        '
        'txtIng1
        '
        Me.txtIng1.Location = New System.Drawing.Point(121, 202)
        Me.txtIng1.Name = "txtIng1"
        Me.txtIng1.Size = New System.Drawing.Size(294, 20)
        Me.txtIng1.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "Cortadora"
        '
        'txtCortadora
        '
        Me.txtCortadora.Location = New System.Drawing.Point(121, 176)
        Me.txtCortadora.Name = "txtCortadora"
        Me.txtCortadora.Size = New System.Drawing.Size(294, 20)
        Me.txtCortadora.TabIndex = 5
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(287, 390)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Hora Final"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(287, 364)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = "Hora Inicio"
        '
        'numHoraFinal
        '
        Me.numHoraFinal.DecimalPlaces = 2
        Me.numHoraFinal.Location = New System.Drawing.Point(360, 386)
        Me.numHoraFinal.Name = "numHoraFinal"
        Me.numHoraFinal.Size = New System.Drawing.Size(55, 20)
        Me.numHoraFinal.TabIndex = 13
        '
        'numHoraInicio
        '
        Me.numHoraInicio.DecimalPlaces = 2
        Me.numHoraInicio.Location = New System.Drawing.Point(360, 360)
        Me.numHoraInicio.Name = "numHoraInicio"
        Me.numHoraInicio.Size = New System.Drawing.Size(55, 20)
        Me.numHoraInicio.TabIndex = 12
        '
        'numVagon
        '
        Me.numVagon.Location = New System.Drawing.Point(121, 412)
        Me.numVagon.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numVagon.Name = "numVagon"
        Me.numVagon.Size = New System.Drawing.Size(79, 20)
        Me.numVagon.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 416)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Cant. Lad. X Vagon"
        '
        'chkFinalizada
        '
        Me.chkFinalizada.AutoSize = True
        Me.chkFinalizada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFinalizada.Location = New System.Drawing.Point(18, 452)
        Me.chkFinalizada.Name = "chkFinalizada"
        Me.chkFinalizada.Size = New System.Drawing.Size(73, 17)
        Me.chkFinalizada.TabIndex = 15
        Me.chkFinalizada.Text = "Finalizada"
        Me.chkFinalizada.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 485)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 135
        Me.Label16.Text = "Conteo"
        '
        'txtConteo
        '
        Me.txtConteo.Location = New System.Drawing.Point(121, 481)
        Me.txtConteo.Name = "txtConteo"
        Me.txtConteo.Size = New System.Drawing.Size(79, 20)
        Me.txtConteo.TabIndex = 16
        '
        'txtCarga
        '
        Me.txtCarga.Location = New System.Drawing.Point(343, 481)
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.Size = New System.Drawing.Size(72, 20)
        Me.txtCarga.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(237, 485)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Carga"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(343, 507)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(72, 20)
        Me.txtPorcentaje.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(237, 511)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 13)
        Me.Label18.TabIndex = 141
        Me.Label18.Text = "Porcentaje Reciclaje"
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Location = New System.Drawing.Point(121, 507)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Size = New System.Drawing.Size(79, 20)
        Me.txtDiferencia.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 511)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 139
        Me.Label19.Text = "Diferencia"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 231)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 143
        Me.Label20.Text = "Ing.2"
        '
        'txtIng2
        '
        Me.txtIng2.Location = New System.Drawing.Point(121, 228)
        Me.txtIng2.Name = "txtIng2"
        Me.txtIng2.Size = New System.Drawing.Size(294, 20)
        Me.txtIng2.TabIndex = 142
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 283)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 13)
        Me.Label21.TabIndex = 147
        Me.Label21.Text = "Ope.2"
        '
        'txtOpe2
        '
        Me.txtOpe2.Location = New System.Drawing.Point(121, 280)
        Me.txtOpe2.Name = "txtOpe2"
        Me.txtOpe2.Size = New System.Drawing.Size(294, 20)
        Me.txtOpe2.TabIndex = 146
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(15, 257)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 145
        Me.Label22.Text = "Ope."
        '
        'txtOpe1
        '
        Me.txtOpe1.Location = New System.Drawing.Point(121, 254)
        Me.txtOpe1.Name = "txtOpe1"
        Me.txtOpe1.Size = New System.Drawing.Size(294, 20)
        Me.txtOpe1.TabIndex = 144
        '
        'dtpFechaFinalizada
        '
        Me.dtpFechaFinalizada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinalizada.Location = New System.Drawing.Point(121, 450)
        Me.dtpFechaFinalizada.Name = "dtpFechaFinalizada"
        Me.dtpFechaFinalizada.Size = New System.Drawing.Size(79, 20)
        Me.dtpFechaFinalizada.TabIndex = 148
        '
        'frmProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(457, 534)
        Me.Controls.Add(Me.dtpFechaFinalizada)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtOpe2)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtOpe1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtIng2)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDiferencia)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtCarga)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtConteo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.chkFinalizada)
        Me.Controls.Add(Me.numVagon)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.numHoraFinal)
        Me.Controls.Add(Me.numHoraInicio)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCortadora)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtIng1)
        Me.Controls.Add(Me.numReciclaje)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.numTabla)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.numCorte)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.cboTipoProduccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtExtrusora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPlanta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLadrillo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Name = "frmProduccion"
        Me.Text = "Produccion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLadrillo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtPlanta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtExtrusora, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboTipoProduccion, 0)
        Me.Controls.SetChildIndex(Me.txtObservacion, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numCorte, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.numTabla, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numReciclaje, 0)
        Me.Controls.SetChildIndex(Me.txtIng1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtCortadora, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.numHoraInicio, 0)
        Me.Controls.SetChildIndex(Me.numHoraFinal, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.numVagon, 0)
        Me.Controls.SetChildIndex(Me.chkFinalizada, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtConteo, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtCarga, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txtDiferencia, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtPorcentaje, 0)
        Me.Controls.SetChildIndex(Me.txtIng2, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.txtOpe1, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.txtOpe2, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFinalizada, 0)
        CType(Me.numCorte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numReciclaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoraFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoraInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVagon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLadrillo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtExtrusora As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoProduccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents numCorte As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numTabla As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numReciclaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIng1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCortadora As System.Windows.Forms.TextBox
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents numHoraFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHoraInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVagon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDiferencia As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCarga As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtConteo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkFinalizada As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtOpe2 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtOpe1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtIng2 As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaFinalizada As System.Windows.Forms.DateTimePicker

End Class
