Namespace Ladisac.Produccion.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmControlConteo
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
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtResponsable = New System.Windows.Forms.TextBox()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtProduccion = New System.Windows.Forms.TextBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.DCC_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CPA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CAN_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DCC_FALTANTES = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DCC_MALOGRADOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DCC_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(606, 28)
            Me.lblTitle.Text = "Control Conteo"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(14, 121)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(51, 13)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Ingeniero"
            '
            'txtResponsable
            '
            Me.txtResponsable.Location = New System.Drawing.Point(92, 117)
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Size = New System.Drawing.Size(352, 20)
            Me.txtResponsable.TabIndex = 104
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(359, 65)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
            Me.dtpFecha.TabIndex = 103
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(316, 69)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 102
            Me.Label6.Text = "Fecha"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 95)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(61, 13)
            Me.Label1.TabIndex = 99
            Me.Label1.Text = "Produccion"
            '
            'txtProduccion
            '
            Me.txtProduccion.Location = New System.Drawing.Point(92, 91)
            Me.txtProduccion.Name = "txtProduccion"
            Me.txtProduccion.Size = New System.Drawing.Size(352, 20)
            Me.txtProduccion.TabIndex = 98
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DCC_ID, Me.CPA_ID, Me.CAN_ID, Me.DCC_FALTANTES, Me.DCC_MALOGRADOS, Me.DCC_CANTIDAD})
            Me.dgvDetalle.Location = New System.Drawing.Point(17, 158)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(573, 224)
            Me.dgvDetalle.TabIndex = 108
            '
            'DCC_ID
            '
            Me.DCC_ID.HeaderText = "DCC_ID"
            Me.DCC_ID.Name = "DCC_ID"
            Me.DCC_ID.Visible = False
            '
            'CPA_ID
            '
            Me.CPA_ID.HeaderText = "CPA_ID"
            Me.CPA_ID.Name = "CPA_ID"
            '
            'CAN_ID
            '
            Me.CAN_ID.HeaderText = "Cancha"
            Me.CAN_ID.Name = "CAN_ID"
            '
            'DCC_FALTANTES
            '
            Me.DCC_FALTANTES.HeaderText = "Faltantes"
            Me.DCC_FALTANTES.Name = "DCC_FALTANTES"
            '
            'DCC_MALOGRADOS
            '
            Me.DCC_MALOGRADOS.HeaderText = "Malogrados"
            Me.DCC_MALOGRADOS.Name = "DCC_MALOGRADOS"
            '
            'DCC_CANTIDAD
            '
            Me.DCC_CANTIDAD.HeaderText = "Cantidad"
            Me.DCC_CANTIDAD.Name = "DCC_CANTIDAD"
            '
            'DataGridView1
            '
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Location = New System.Drawing.Point(17, 189)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.Size = New System.Drawing.Size(427, 193)
            Me.DataGridView1.TabIndex = 108
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "DCC_ID"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "CPA_ID"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Cancha"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Secadero"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Cantidad"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            '
            'Error_validacion
            '
            Me.Error_validacion.ContainerControl = Me
            '
            'frmControlConteo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(606, 394)
            Me.Controls.Add(Me.dgvDetalle)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.txtResponsable)
            Me.Controls.Add(Me.dtpFecha)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtProduccion)
            Me.Name = "frmControlConteo"
            Me.Text = "Control Conteo"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.txtProduccion, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.Label6, 0)
            Me.Controls.SetChildIndex(Me.dtpFecha, 0)
            Me.Controls.SetChildIndex(Me.txtResponsable, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
        Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtProduccion As System.Windows.Forms.TextBox
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
        Friend WithEvents DCC_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CPA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CAN_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DCC_FALTANTES As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DCC_MALOGRADOS As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DCC_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace