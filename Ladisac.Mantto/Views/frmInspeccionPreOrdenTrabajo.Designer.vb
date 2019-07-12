<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInspeccionPreOrdenTrabajo
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
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.OTR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IOT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IOT_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(857, 28)
        Me.lblTitle.Text = "Inspeccion Trabajos Mantenimiento"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OTR_ID, Me.IOT_ID, Me.ENO_ID, Me.IOT_DESCRIPCION})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 115)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(833, 358)
        Me.dgvDetalle.TabIndex = 2
        '
        'OTR_ID
        '
        Me.OTR_ID.HeaderText = "O.T."
        Me.OTR_ID.Name = "OTR_ID"
        '
        'IOT_ID
        '
        Me.IOT_ID.HeaderText = "IOT_ID"
        Me.IOT_ID.Name = "IOT_ID"
        Me.IOT_ID.Visible = False
        '
        'ENO_ID
        '
        Me.ENO_ID.HeaderText = "Entidad"
        Me.ENO_ID.Name = "ENO_ID"
        Me.ENO_ID.Width = 200
        '
        'IOT_DESCRIPCION
        '
        Me.IOT_DESCRIPCION.HeaderText = "Descripcion"
        Me.IOT_DESCRIPCION.Name = "IOT_DESCRIPCION"
        Me.IOT_DESCRIPCION.Width = 400
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "O.T."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "IOT_ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Entidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 400
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(58, 73)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(394, 20)
        Me.txtBuscar.TabIndex = 7
        '
        'frmInspeccionPreOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(857, 500)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Name = "frmInspeccionPreOrdenTrabajo"
        Me.Text = "Inspeccion Trabajos Mantenimiento"
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents OTR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IOT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IOT_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox

End Class
