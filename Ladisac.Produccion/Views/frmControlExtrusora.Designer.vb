<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlExtrusora
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtControlParada = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numHoroInicial = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numHoroFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numHoroDigital = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numMedidaCorte = New System.Windows.Forms.NumericUpDown()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHoraInicio = New System.Windows.Forms.TextBox()
        Me.txtHoraFinal = New System.Windows.Forms.TextBox()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_VACIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_AMPERAJE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_CORTES_MINUTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_CANTIDAD_CORTE_MAQUINA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEX_TOTAL_CORTES_HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorteMinuto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.numHoroInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoroDigital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMedidaCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(795, 28)
        Me.lblTitle.Text = "Control Extrusora"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Control Parada"
        '
        'txtControlParada
        '
        Me.txtControlParada.Location = New System.Drawing.Point(94, 66)
        Me.txtControlParada.Name = "txtControlParada"
        Me.txtControlParada.Size = New System.Drawing.Size(307, 20)
        Me.txtControlParada.TabIndex = 113
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(233, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Horo. Inicial"
        '
        'numHoroInicial
        '
        Me.numHoroInicial.DecimalPlaces = 2
        Me.numHoroInicial.Location = New System.Drawing.Point(311, 92)
        Me.numHoroInicial.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoroInicial.Name = "numHoroInicial"
        Me.numHoroInicial.Size = New System.Drawing.Size(90, 20)
        Me.numHoroInicial.TabIndex = 127
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "Horo. Final"
        '
        'numHoroFinal
        '
        Me.numHoroFinal.DecimalPlaces = 2
        Me.numHoroFinal.Location = New System.Drawing.Point(311, 118)
        Me.numHoroFinal.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoroFinal.Name = "numHoroFinal"
        Me.numHoroFinal.Size = New System.Drawing.Size(90, 20)
        Me.numHoroFinal.TabIndex = 129
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(417, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Horo. Digital"
        '
        'numHoroDigital
        '
        Me.numHoroDigital.DecimalPlaces = 1
        Me.numHoroDigital.Location = New System.Drawing.Point(496, 92)
        Me.numHoroDigital.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numHoroDigital.Name = "numHoroDigital"
        Me.numHoroDigital.Size = New System.Drawing.Size(79, 20)
        Me.numHoroDigital.TabIndex = 131
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(417, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Medida Corte"
        '
        'numMedidaCorte
        '
        Me.numMedidaCorte.DecimalPlaces = 2
        Me.numMedidaCorte.Location = New System.Drawing.Point(496, 118)
        Me.numMedidaCorte.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numMedidaCorte.Name = "numMedidaCorte"
        Me.numMedidaCorte.Size = New System.Drawing.Size(79, 20)
        Me.numMedidaCorte.TabIndex = 133
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DEX_ID, Me.DEX_HORA, Me.DEX_VACIO, Me.DEX_AMPERAJE, Me.DEX_CORTES_MINUTO, Me.DEX_CANTIDAD_CORTE_MAQUINA, Me.DEX_TOTAL_CORTES_HORA, Me.CorteMinuto})
        Me.dgvDetalle.Location = New System.Drawing.Point(19, 154)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(760, 265)
        Me.dgvDetalle.TabIndex = 135
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 139
        Me.Label9.Text = "Hora Final"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Hora Inicio"
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.BackColor = System.Drawing.Color.White
        Me.txtHoraInicio.Location = New System.Drawing.Point(94, 92)
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.ReadOnly = True
        Me.txtHoraInicio.Size = New System.Drawing.Size(59, 20)
        Me.txtHoraInicio.TabIndex = 140
        '
        'txtHoraFinal
        '
        Me.txtHoraFinal.BackColor = System.Drawing.Color.White
        Me.txtHoraFinal.Location = New System.Drawing.Point(94, 118)
        Me.txtHoraFinal.Name = "txtHoraFinal"
        Me.txtHoraFinal.ReadOnly = True
        Me.txtHoraFinal.Size = New System.Drawing.Size(59, 20)
        Me.txtHoraFinal.TabIndex = 141
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DEX_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Hora"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vacio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Amperaje"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cortes Min."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cant. Corte Maq."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cortes por Hora"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "CorteMinuto"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DEX_ID
        '
        Me.DEX_ID.HeaderText = "DEX_ID"
        Me.DEX_ID.Name = "DEX_ID"
        Me.DEX_ID.Visible = False
        '
        'DEX_HORA
        '
        Me.DEX_HORA.HeaderText = "Hora"
        Me.DEX_HORA.Name = "DEX_HORA"
        '
        'DEX_VACIO
        '
        Me.DEX_VACIO.HeaderText = "Vacio"
        Me.DEX_VACIO.Name = "DEX_VACIO"
        '
        'DEX_AMPERAJE
        '
        Me.DEX_AMPERAJE.HeaderText = "Amperaje"
        Me.DEX_AMPERAJE.Name = "DEX_AMPERAJE"
        '
        'DEX_CORTES_MINUTO
        '
        Me.DEX_CORTES_MINUTO.HeaderText = "Cortes Min."
        Me.DEX_CORTES_MINUTO.Name = "DEX_CORTES_MINUTO"
        '
        'DEX_CANTIDAD_CORTE_MAQUINA
        '
        Me.DEX_CANTIDAD_CORTE_MAQUINA.HeaderText = "Cant. Corte Maq."
        Me.DEX_CANTIDAD_CORTE_MAQUINA.Name = "DEX_CANTIDAD_CORTE_MAQUINA"
        '
        'DEX_TOTAL_CORTES_HORA
        '
        Me.DEX_TOTAL_CORTES_HORA.HeaderText = "Cortes por Hora"
        Me.DEX_TOTAL_CORTES_HORA.Name = "DEX_TOTAL_CORTES_HORA"
        '
        'CorteMinuto
        '
        Me.CorteMinuto.HeaderText = "CorteMinuto"
        Me.CorteMinuto.Name = "CorteMinuto"
        '
        'frmControlExtrusora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(795, 431)
        Me.Controls.Add(Me.txtHoraFinal)
        Me.Controls.Add(Me.txtHoraInicio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numMedidaCorte)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numHoroDigital)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numHoroFinal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numHoroInicial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtControlParada)
        Me.Name = "frmControlExtrusora"
        Me.Text = "Control Extrusora"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtControlParada, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.numHoroInicial, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numHoroFinal, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.numHoroDigital, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.numMedidaCorte, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtHoraInicio, 0)
        Me.Controls.SetChildIndex(Me.txtHoraFinal, 0)
        CType(Me.numHoroInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoroFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoroDigital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMedidaCorte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtControlParada As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numHoroInicial As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numHoroFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numHoroDigital As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numMedidaCorte As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtHoraInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraFinal As System.Windows.Forms.TextBox
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents DEX_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_HORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_VACIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_AMPERAJE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_CORTES_MINUTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_CANTIDAD_CORTE_MAQUINA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEX_TOTAL_CORTES_HORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorteMinuto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
