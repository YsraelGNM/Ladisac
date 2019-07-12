<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametroEntidad
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEntidadInspeccion = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.PAE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_AMAINFERIOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_VERDE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_VERDE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_AMASUPERIOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(675, 28)
        Me.lblTitle.Text = "Parametro por Entidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(122, 73)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Entidad Inspeccion"
        '
        'txtEntidadInspeccion
        '
        Me.txtEntidadInspeccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEntidadInspeccion.Location = New System.Drawing.Point(122, 106)
        Me.txtEntidadInspeccion.Name = "txtEntidadInspeccion"
        Me.txtEntidadInspeccion.Size = New System.Drawing.Size(526, 20)
        Me.txtEntidadInspeccion.TabIndex = 103
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 168)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(341, 20)
        Me.TextBox1.TabIndex = 109
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PAE_ID, Me.COM_ID, Me.PAE_DESCRIPCION, Me.PAE_AMAINFERIOR, Me.PAE_VERDE1, Me.PAE_VERDE2, Me.PAE_AMASUPERIOR})
        Me.dgvDetalle.Location = New System.Drawing.Point(21, 147)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(627, 218)
        Me.dgvDetalle.TabIndex = 109
        '
        'PAE_ID
        '
        Me.PAE_ID.HeaderText = "PAE_ID"
        Me.PAE_ID.Name = "PAE_ID"
        Me.PAE_ID.Visible = False
        '
        'COM_ID
        '
        Me.COM_ID.HeaderText = "COMPONENTE"
        Me.COM_ID.Name = "COM_ID"
        '
        'PAE_DESCRIPCION
        '
        Me.PAE_DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.PAE_DESCRIPCION.Name = "PAE_DESCRIPCION"
        '
        'PAE_AMAINFERIOR
        '
        Me.PAE_AMAINFERIOR.HeaderText = "AMA-INFERIOR"
        Me.PAE_AMAINFERIOR.Name = "PAE_AMAINFERIOR"
        '
        'PAE_VERDE1
        '
        Me.PAE_VERDE1.HeaderText = "VERDE-1"
        Me.PAE_VERDE1.Name = "PAE_VERDE1"
        '
        'PAE_VERDE2
        '
        Me.PAE_VERDE2.HeaderText = "VERDE-2"
        Me.PAE_VERDE2.Name = "PAE_VERDE2"
        '
        'PAE_AMASUPERIOR
        '
        Me.PAE_AMASUPERIOR.HeaderText = "AMA-SUPERIOR"
        Me.PAE_AMASUPERIOR.Name = "PAE_AMASUPERIOR"
        '
        'frmParametroEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(675, 383)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEntidadInspeccion)
        Me.Name = "frmParametroEntidad"
        Me.Text = "Parametro por Entidad"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtEntidadInspeccion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEntidadInspeccion As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents PAE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAE_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAE_AMAINFERIOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAE_VERDE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAE_VERDE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAE_AMASUPERIOR As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
