<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspecificacion
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
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.ESP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESP_VALOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRuta = New System.Windows.Forms.Label()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(542, 28)
        Me.lblTitle.Text = "Especificacion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Entidad"
        '
        'txtEntidad
        '
        Me.txtEntidad.Location = New System.Drawing.Point(99, 75)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(416, 20)
        Me.txtEntidad.TabIndex = 92
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ESP_ID, Me.CTT_ID, Me.UM, Me.ESP_VALOR})
        Me.dgvDetalle.Location = New System.Drawing.Point(24, 110)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(491, 178)
        Me.dgvDetalle.TabIndex = 94
        '
        'ESP_ID
        '
        Me.ESP_ID.HeaderText = "ESP_ID"
        Me.ESP_ID.Name = "ESP_ID"
        Me.ESP_ID.Visible = False
        '
        'CTT_ID
        '
        Me.CTT_ID.HeaderText = "Caracteristica"
        Me.CTT_ID.Name = "CTT_ID"
        '
        'UM
        '
        Me.UM.FillWeight = 30.0!
        Me.UM.HeaderText = "U.M."
        Me.UM.Name = "UM"
        '
        'ESP_VALOR
        '
        Me.ESP_VALOR.FillWeight = 30.0!
        Me.ESP_VALOR.HeaderText = "Valor"
        Me.ESP_VALOR.Name = "ESP_VALOR"
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Location = New System.Drawing.Point(21, 310)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(494, 23)
        Me.lblRuta.TabIndex = 153
        Me.lblRuta.Text = "Label2"
        '
        'frmEspecificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(542, 342)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEntidad)
        Me.Name = "frmEspecificacion"
        Me.Text = "Especificacion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtEntidad, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblRuta, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents ESP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESP_VALOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRuta As System.Windows.Forms.Label

End Class
