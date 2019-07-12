<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlPlanta
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DPL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DPL_HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DPL_HORA_FINAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DPL_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(807, 28)
        Me.lblTitle.Text = "Control Planta"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(56, 62)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 114
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(56, 92)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(231, 20)
        Me.txtPlanta.TabIndex = 111
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DPL_ID, Me.DPL_HORA, Me.DPL_HORA_FINAL, Me.PAR_ID, Me.DPL_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 130)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(771, 232)
        Me.dgvDetalle.TabIndex = 120
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'DPL_ID
        '
        Me.DPL_ID.HeaderText = "DPL_ID"
        Me.DPL_ID.Name = "DPL_ID"
        Me.DPL_ID.Visible = False
        '
        'DPL_HORA
        '
        Me.DPL_HORA.HeaderText = "Hora Ini."
        Me.DPL_HORA.Name = "DPL_HORA"
        '
        'DPL_HORA_FINAL
        '
        Me.DPL_HORA_FINAL.HeaderText = "Hora Fin."
        Me.DPL_HORA_FINAL.Name = "DPL_HORA_FINAL"
        '
        'PAR_ID
        '
        Me.PAR_ID.HeaderText = "Parada"
        Me.PAR_ID.Name = "PAR_ID"
        Me.PAR_ID.Width = 200
        '
        'DPL_OBSERVACION
        '
        Me.DPL_OBSERVACION.HeaderText = "Observacion"
        Me.DPL_OBSERVACION.Name = "DPL_OBSERVACION"
        Me.DPL_OBSERVACION.Width = 250
        '
        'frmControlPlanta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(807, 374)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPlanta)
        Me.Name = "frmControlPlanta"
        Me.Text = "Control Planta"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtPlanta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents DPL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPL_HORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPL_HORA_FINAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPL_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
