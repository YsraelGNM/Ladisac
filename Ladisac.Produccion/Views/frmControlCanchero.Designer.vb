<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlCanchero
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduccion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numTotalLadrillos = New System.Windows.Forms.NumericUpDown()
        Me.numCantTabla = New System.Windows.Forms.NumericUpDown()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DCA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAN_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_GOLPEADAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_RAJADAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_AGUADAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_CORTE_MAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_GOLPE_VEHICULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DCA_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.numTotalLadrillos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(741, 28)
        Me.lblTitle.Text = "Control Canchero"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(515, 66)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(472, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Produccion"
        '
        'txtProduccion
        '
        Me.txtProduccion.Location = New System.Drawing.Point(99, 66)
        Me.txtProduccion.Name = "txtProduccion"
        Me.txtProduccion.Size = New System.Drawing.Size(352, 20)
        Me.txtProduccion.TabIndex = 115
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "Total Ladrillos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "Cant. x Tabla"
        '
        'numTotalLadrillos
        '
        Me.numTotalLadrillos.Location = New System.Drawing.Point(99, 144)
        Me.numTotalLadrillos.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numTotalLadrillos.Name = "numTotalLadrillos"
        Me.numTotalLadrillos.ReadOnly = True
        Me.numTotalLadrillos.Size = New System.Drawing.Size(62, 20)
        Me.numTotalLadrillos.TabIndex = 129
        '
        'numCantTabla
        '
        Me.numCantTabla.Location = New System.Drawing.Point(99, 118)
        Me.numCantTabla.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numCantTabla.Name = "numCantTabla"
        Me.numCantTabla.Size = New System.Drawing.Size(62, 20)
        Me.numCantTabla.TabIndex = 128
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DCA_ID, Me.CAN_ID, Me.DCA_GOLPEADAS, Me.DCA_RAJADAS, Me.DCA_AGUADAS, Me.DCA_CORTE_MAL, Me.DCA_GOLPE_VEHICULO, Me.DCA_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 170)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(719, 204)
        Me.dgvDetalle.TabIndex = 132
        '
        'DCA_ID
        '
        Me.DCA_ID.HeaderText = "DCA_ID"
        Me.DCA_ID.Name = "DCA_ID"
        Me.DCA_ID.Visible = False
        '
        'CAN_ID
        '
        Me.CAN_ID.HeaderText = "Cancha"
        Me.CAN_ID.Name = "CAN_ID"
        '
        'DCA_GOLPEADAS
        '
        Me.DCA_GOLPEADAS.HeaderText = "Golpeadas"
        Me.DCA_GOLPEADAS.Name = "DCA_GOLPEADAS"
        '
        'DCA_RAJADAS
        '
        Me.DCA_RAJADAS.HeaderText = "Rajadas"
        Me.DCA_RAJADAS.Name = "DCA_RAJADAS"
        '
        'DCA_AGUADAS
        '
        Me.DCA_AGUADAS.HeaderText = "Aguadas"
        Me.DCA_AGUADAS.Name = "DCA_AGUADAS"
        '
        'DCA_CORTE_MAL
        '
        Me.DCA_CORTE_MAL.HeaderText = "Corte Mal"
        Me.DCA_CORTE_MAL.Name = "DCA_CORTE_MAL"
        '
        'DCA_GOLPE_VEHICULO
        '
        Me.DCA_GOLPE_VEHICULO.HeaderText = "Golpe Vehiculo"
        Me.DCA_GOLPE_VEHICULO.Name = "DCA_GOLPE_VEHICULO"
        '
        'DCA_OBSERVACION
        '
        Me.DCA_OBSERVACION.HeaderText = "Observacion"
        Me.DCA_OBSERVACION.Name = "DCA_OBSERVACION"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Operador"
        '
        'txtOperador
        '
        Me.txtOperador.Location = New System.Drawing.Point(99, 92)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(352, 20)
        Me.txtOperador.TabIndex = 133
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DCA_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cancha"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Golpeadas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Rajadas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Aguadas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Corte Mal"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Golpe Vehiculo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'frmControlCanchero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(741, 391)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOperador)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numTotalLadrillos)
        Me.Controls.Add(Me.numCantTabla)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProduccion)
        Me.Name = "frmControlCanchero"
        Me.Text = "Control Canchero"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtProduccion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.numCantTabla, 0)
        Me.Controls.SetChildIndex(Me.numTotalLadrillos, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.txtOperador, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.numTotalLadrillos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numTotalLadrillos As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCantTabla As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents DCA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAN_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_GOLPEADAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_RAJADAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_AGUADAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_CORTE_MAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_GOLPE_VEHICULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DCA_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
