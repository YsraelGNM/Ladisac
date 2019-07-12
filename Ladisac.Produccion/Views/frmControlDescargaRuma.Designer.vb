<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlDescargaRuma
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
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DRD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LMA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUERTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MALECON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LADRILLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CARGADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_ROTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_RAJADOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_RECOCHADOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_DOBLADOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_BLANCOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_MALOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_CANT_NETA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DRD_OBSERVACIONES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numHoroFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numHoroInicial = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtControlDescarga = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        ' Me.DataFormatoVenta141 = New DataFormatoVenta14()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoroInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        ' CType(Me.DataFormatoVenta141, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(591, 28)
        Me.lblTitle.Text = "Control Descarga Ruma"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DRD_ID, Me.CAR_ID, Me.LMA_ID, Me.PUERTA, Me.MALECON, Me.PRO_ID, Me.LADRILLO, Me.DRD_TIPO, Me.CARGADO, Me.DRD_ROTOS, Me.DRD_RAJADOS, Me.DRD_RECOCHADOS, Me.DRD_DOBLADOS, Me.DRD_BLANCOS, Me.DRD_MALOS, Me.DRD_CANT_NETA, Me.DRD_OBSERVACIONES})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 169)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(558, 181)
        Me.dgvDetalle.TabIndex = 148
        '
        'DRD_ID
        '
        Me.DRD_ID.HeaderText = "DRD_ID"
        Me.DRD_ID.Name = "DRD_ID"
        Me.DRD_ID.Visible = False
        '
        'CAR_ID
        '
        Me.CAR_ID.HeaderText = "CAR_ID"
        Me.CAR_ID.Name = "CAR_ID"
        Me.CAR_ID.Visible = False
        '
        'LMA_ID
        '
        Me.LMA_ID.HeaderText = "LMA_ID"
        Me.LMA_ID.Name = "LMA_ID"
        Me.LMA_ID.Visible = False
        '
        'PUERTA
        '
        Me.PUERTA.HeaderText = "PUERTA"
        Me.PUERTA.Name = "PUERTA"
        '
        'MALECON
        '
        Me.MALECON.HeaderText = "MALECON"
        Me.MALECON.Name = "MALECON"
        '
        'PRO_ID
        '
        Me.PRO_ID.HeaderText = "PRO_ID"
        Me.PRO_ID.Name = "PRO_ID"
        '
        'LADRILLO
        '
        Me.LADRILLO.HeaderText = "LADRILLO"
        Me.LADRILLO.Name = "LADRILLO"
        '
        'DRD_TIPO
        '
        Me.DRD_TIPO.HeaderText = "TIPO"
        Me.DRD_TIPO.Name = "DRD_TIPO"
        '
        'CARGADO
        '
        Me.CARGADO.HeaderText = "CARGADO"
        Me.CARGADO.Name = "CARGADO"
        '
        'DRD_ROTOS
        '
        Me.DRD_ROTOS.HeaderText = "ROTOS"
        Me.DRD_ROTOS.Name = "DRD_ROTOS"
        '
        'DRD_RAJADOS
        '
        Me.DRD_RAJADOS.HeaderText = "RAJADOS"
        Me.DRD_RAJADOS.Name = "DRD_RAJADOS"
        '
        'DRD_RECOCHADOS
        '
        Me.DRD_RECOCHADOS.HeaderText = "RECOCHADOS"
        Me.DRD_RECOCHADOS.Name = "DRD_RECOCHADOS"
        '
        'DRD_DOBLADOS
        '
        Me.DRD_DOBLADOS.HeaderText = "DOBLADOS"
        Me.DRD_DOBLADOS.Name = "DRD_DOBLADOS"
        '
        'DRD_BLANCOS
        '
        Me.DRD_BLANCOS.HeaderText = "BLANCOS"
        Me.DRD_BLANCOS.Name = "DRD_BLANCOS"
        '
        'DRD_MALOS
        '
        Me.DRD_MALOS.HeaderText = "DRD_MALOS"
        Me.DRD_MALOS.Name = "DRD_MALOS"
        '
        'DRD_CANT_NETA
        '
        Me.DRD_CANT_NETA.HeaderText = "CANT_NETA"
        Me.DRD_CANT_NETA.Name = "DRD_CANT_NETA"
        '
        'DRD_OBSERVACIONES
        '
        Me.DRD_OBSERVACIONES.HeaderText = "OBSERVACION"
        Me.DRD_OBSERVACIONES.Name = "DRD_OBSERVACIONES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Hora Final"
        '
        'numHoroFinal
        '
        Me.numHoroFinal.Location = New System.Drawing.Point(298, 116)
        Me.numHoroFinal.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoroFinal.Name = "numHoroFinal"
        Me.numHoroFinal.Size = New System.Drawing.Size(85, 20)
        Me.numHoroFinal.TabIndex = 144
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "Hora Inicial"
        '
        'numHoroInicial
        '
        Me.numHoroInicial.Location = New System.Drawing.Point(102, 116)
        Me.numHoroInicial.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoroInicial.Name = "numHoroInicial"
        Me.numHoroInicial.Size = New System.Drawing.Size(90, 20)
        Me.numHoroInicial.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(102, 61)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Descarga Horno"
        '
        'txtControlDescarga
        '
        Me.txtControlDescarga.Location = New System.Drawing.Point(102, 88)
        Me.txtControlDescarga.Name = "txtControlDescarga"
        Me.txtControlDescarga.Size = New System.Drawing.Size(90, 20)
        Me.txtControlDescarga.TabIndex = 136
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(298, 61)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 150
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(241, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Fecha"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DRD_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "CAR_ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "LMA_ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "NRO_PRODUC."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "FEC.PRODUCC."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "LADRILLO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "TIPO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "CARGADO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "CANT_NETA"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "DRD_MALOS"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "ROTOS"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "RAJADOS"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "RECOCHADOS"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "DOBLADOS"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "BLANCOS"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "OBSERVACION"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(345, 88)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(97, 20)
        Me.txtNumero.TabIndex = 154
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Numero"
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(298, 88)
        Me.txtSerie.MaxLength = 4
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(41, 20)
        Me.txtSerie.TabIndex = 152
        '
        'DataFormatoVenta141
        '
        ' Me.DataFormatoVenta141.DataSetName = "DataFormatoVenta14"
        ' Me.DataFormatoVenta141.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmControlDescargaRuma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(591, 368)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numHoroFinal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numHoroInicial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtControlDescarga)
        Me.Name = "frmControlDescargaRuma"
        Me.Text = "Control Descarga Ruma"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtControlDescarga, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.numHoroInicial, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numHoroFinal, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.txtSerie, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNumero, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoroInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        ' CType(Me.DataFormatoVenta141, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numHoroFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numHoroInicial As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtControlDescarga As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
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
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents DRD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LMA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PUERTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MALECON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LADRILLO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CARGADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_ROTOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_RAJADOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_RECOCHADOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_DOBLADOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_BLANCOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_MALOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_CANT_NETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DRD_OBSERVACIONES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    ' Friend WithEvents DataFormatoVenta141 As DataFormatoVenta14

End Class
