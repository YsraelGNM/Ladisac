<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidaSecadero
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
        Me.DSE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_CANTIDAD_VAGON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_LADRILLOS_X_VAGON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_CANTIDAD_FALTANTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalBruto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_CANTIDAD_RECICLADO_SECADERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_CANTIDAD_RECICLADO_CARGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalidaNeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_PESO_PROMEDIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DSE_FIN_DESCARGA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DSE_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSecadero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numHoraFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numHoraInicial = New System.Windows.Forms.NumericUpDown()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
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
        Me.chkSinSecadero = New System.Windows.Forms.CheckBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoraFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHoraInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(781, 28)
        Me.lblTitle.Text = "Salida Secadero"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DSE_ID, Me.Codigo, Me.PRO_ID, Me.Fecha, Me.DSE_CANTIDAD_VAGON, Me.DSE_LADRILLOS_X_VAGON, Me.DSE_CANTIDAD_FALTANTE, Me.TotalBruto, Me.DSE_CANTIDAD_RECICLADO_SECADERO, Me.DSE_CANTIDAD_RECICLADO_CARGA, Me.SalidaNeta, Me.DSE_PESO_PROMEDIO, Me.DSE_FIN_DESCARGA, Me.DSE_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(24, 204)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(733, 193)
        Me.dgvDetalle.TabIndex = 119
        '
        'DSE_ID
        '
        Me.DSE_ID.HeaderText = "DSE_ID"
        Me.DSE_ID.Name = "DSE_ID"
        Me.DSE_ID.Visible = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "PRO_ID"
        Me.Codigo.Name = "Codigo"
        '
        'PRO_ID
        '
        Me.PRO_ID.HeaderText = "Produccion"
        Me.PRO_ID.Name = "PRO_ID"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'DSE_CANTIDAD_VAGON
        '
        Me.DSE_CANTIDAD_VAGON.HeaderText = "Cant.Vagon"
        Me.DSE_CANTIDAD_VAGON.Name = "DSE_CANTIDAD_VAGON"
        '
        'DSE_LADRILLOS_X_VAGON
        '
        Me.DSE_LADRILLOS_X_VAGON.HeaderText = "Lad.xVagon"
        Me.DSE_LADRILLOS_X_VAGON.Name = "DSE_LADRILLOS_X_VAGON"
        '
        'DSE_CANTIDAD_FALTANTE
        '
        Me.DSE_CANTIDAD_FALTANTE.HeaderText = "Cant.Faltante"
        Me.DSE_CANTIDAD_FALTANTE.Name = "DSE_CANTIDAD_FALTANTE"
        '
        'TotalBruto
        '
        Me.TotalBruto.HeaderText = "Total Bruto"
        Me.TotalBruto.Name = "TotalBruto"
        '
        'DSE_CANTIDAD_RECICLADO_SECADERO
        '
        Me.DSE_CANTIDAD_RECICLADO_SECADERO.HeaderText = "Cant.Reciclado Secadero"
        Me.DSE_CANTIDAD_RECICLADO_SECADERO.Name = "DSE_CANTIDAD_RECICLADO_SECADERO"
        '
        'DSE_CANTIDAD_RECICLADO_CARGA
        '
        Me.DSE_CANTIDAD_RECICLADO_CARGA.HeaderText = "Cant.Reciclado Carga"
        Me.DSE_CANTIDAD_RECICLADO_CARGA.Name = "DSE_CANTIDAD_RECICLADO_CARGA"
        '
        'SalidaNeta
        '
        Me.SalidaNeta.HeaderText = "Salida Neta"
        Me.SalidaNeta.Name = "SalidaNeta"
        Me.SalidaNeta.ReadOnly = True
        '
        'DSE_PESO_PROMEDIO
        '
        Me.DSE_PESO_PROMEDIO.HeaderText = "Peso Promedio"
        Me.DSE_PESO_PROMEDIO.Name = "DSE_PESO_PROMEDIO"
        '
        'DSE_FIN_DESCARGA
        '
        Me.DSE_FIN_DESCARGA.HeaderText = "Fin"
        Me.DSE_FIN_DESCARGA.Name = "DSE_FIN_DESCARGA"
        '
        'DSE_OBSERVACION
        '
        Me.DSE_OBSERVACION.HeaderText = "Observacion"
        Me.DSE_OBSERVACION.Name = "DSE_OBSERVACION"
        Me.DSE_OBSERVACION.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DSE_OBSERVACION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Operador"
        '
        'txtOperador
        '
        Me.txtOperador.Location = New System.Drawing.Point(99, 117)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(352, 20)
        Me.txtOperador.TabIndex = 115
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(366, 65)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 114
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(323, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(99, 65)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Secadero"
        '
        'txtSecadero
        '
        Me.txtSecadero.Location = New System.Drawing.Point(99, 91)
        Me.txtSecadero.Name = "txtSecadero"
        Me.txtSecadero.Size = New System.Drawing.Size(352, 20)
        Me.txtSecadero.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Hora Final"
        '
        'numHoraFinal
        '
        Me.numHoraFinal.Location = New System.Drawing.Point(99, 169)
        Me.numHoraFinal.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoraFinal.Name = "numHoraFinal"
        Me.numHoraFinal.Size = New System.Drawing.Size(90, 20)
        Me.numHoraFinal.TabIndex = 133
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Hora Inicial"
        '
        'numHoraInicial
        '
        Me.numHoraInicial.Location = New System.Drawing.Point(99, 143)
        Me.numHoraInicial.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numHoraInicial.Name = "numHoraInicial"
        Me.numHoraInicial.Size = New System.Drawing.Size(90, 20)
        Me.numHoraInicial.TabIndex = 131
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DSE_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Produccion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cant.Vagon"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Lad.xVagon"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cant.Faltante"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cant.Reciclado Secadero"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cant.Reciclado Carga"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Salida Neta"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Peso Promedio"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Salida Neta"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Peso Promedio"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'chkSinSecadero
        '
        Me.chkSinSecadero.AutoSize = True
        Me.chkSinSecadero.Location = New System.Drawing.Point(481, 69)
        Me.chkSinSecadero.Name = "chkSinSecadero"
        Me.chkSinSecadero.Size = New System.Drawing.Size(90, 17)
        Me.chkSinSecadero.TabIndex = 135
        Me.chkSinSecadero.Text = "Sin Secadero"
        Me.chkSinSecadero.UseVisualStyleBackColor = True
        '
        'frmSalidaSecadero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(781, 414)
        Me.Controls.Add(Me.chkSinSecadero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numHoraFinal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numHoraInicial)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOperador)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSecadero)
        Me.Name = "frmSalidaSecadero"
        Me.Text = "Salida Secadero"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtSecadero, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.txtOperador, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.numHoraInicial, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numHoraFinal, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.chkSinSecadero, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoraFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHoraInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSecadero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numHoraFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numHoraInicial As System.Windows.Forms.NumericUpDown
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
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
    Friend WithEvents DSE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_CANTIDAD_VAGON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_LADRILLOS_X_VAGON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_CANTIDAD_FALTANTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalBruto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_CANTIDAD_RECICLADO_SECADERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_CANTIDAD_RECICLADO_CARGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalidaNeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_PESO_PROMEDIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DSE_FIN_DESCARGA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DSE_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSinSecadero As System.Windows.Forms.CheckBox

End Class
