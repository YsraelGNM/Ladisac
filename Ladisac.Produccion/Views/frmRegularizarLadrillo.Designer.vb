<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegularizarLadrillo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Secado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANT_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID_INGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANT_INGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1085, 28)
        Me.lblTitle.Text = "Regularizar Ladrillo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(59, 74)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(101, 20)
        Me.dtpFecha.TabIndex = 6
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ART_ID_SALIDA, Me.Horno, Me.Secado, Me.Despacho, Me.Transporte, Me.CANT_SALIDA, Me.ART_ID_INGRESO, Me.CANT_INGRESO})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 131)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(1055, 283)
        Me.dgvDetalle.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Articulo Salida"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cantidad Salida"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Articulo Ingreso"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad Ingreso"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'ART_ID_SALIDA
        '
        Me.ART_ID_SALIDA.HeaderText = "Articulo Salida"
        Me.ART_ID_SALIDA.Name = "ART_ID_SALIDA"
        Me.ART_ID_SALIDA.Width = 200
        '
        'Horno
        '
        Me.Horno.HeaderText = "Horno"
        Me.Horno.Name = "Horno"
        '
        'Secado
        '
        Me.Secado.HeaderText = "Secado"
        Me.Secado.Name = "Secado"
        '
        'Despacho
        '
        Me.Despacho.HeaderText = "Despacho"
        Me.Despacho.Name = "Despacho"
        '
        'Transporte
        '
        Me.Transporte.HeaderText = "Transporte"
        Me.Transporte.Name = "Transporte"
        '
        'CANT_SALIDA
        '
        Me.CANT_SALIDA.HeaderText = "Cantidad Salida"
        Me.CANT_SALIDA.Name = "CANT_SALIDA"
        Me.CANT_SALIDA.ReadOnly = True
        '
        'ART_ID_INGRESO
        '
        Me.ART_ID_INGRESO.HeaderText = "Articulo Ingreso"
        Me.ART_ID_INGRESO.Name = "ART_ID_INGRESO"
        Me.ART_ID_INGRESO.Width = 200
        '
        'CANT_INGRESO
        '
        Me.CANT_INGRESO.HeaderText = "Cantidad Ingreso"
        Me.CANT_INGRESO.Name = "CANT_INGRESO"
        Me.CANT_INGRESO.ReadOnly = True
        '
        'frmRegularizarLadrillo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1085, 430)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Name = "frmRegularizarLadrillo"
        Me.Text = "Regularizar Ladrillo"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Secado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despacho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANT_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID_INGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANT_INGRESO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
