<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSancion
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombresFalta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPer_Id_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUNT_Id = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.SAD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FSA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAD_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(454, 28)
        Me.lblTitle.Text = "Sancion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Código"
        '
        'txtNombresFalta
        '
        Me.txtNombresFalta.Location = New System.Drawing.Point(98, 94)
        Me.txtNombresFalta.Name = "txtNombresFalta"
        Me.txtNombresFalta.Size = New System.Drawing.Size(344, 20)
        Me.txtNombresFalta.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Falta de"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(98, 65)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(296, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(357, 65)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 53
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(98, 120)
        Me.txtDNI.MaxLength = 8
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(90, 20)
        Me.txtDNI.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "DNI"
        '
        'txtPer_Id_Proveedor
        '
        Me.txtPer_Id_Proveedor.Location = New System.Drawing.Point(98, 172)
        Me.txtPer_Id_Proveedor.Name = "txtPer_Id_Proveedor"
        Me.txtPer_Id_Proveedor.Size = New System.Drawing.Size(344, 20)
        Me.txtPer_Id_Proveedor.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Empresa"
        '
        'txtUNT_Id
        '
        Me.txtUNT_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUNT_Id.Location = New System.Drawing.Point(98, 146)
        Me.txtUNT_Id.Name = "txtUNT_Id"
        Me.txtUNT_Id.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_Id.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Placa"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(98, 198)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(344, 20)
        Me.txtObservacion.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Observacion"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SAD_ID, Me.FSA_ID, Me.SAD_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 234)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(430, 216)
        Me.dgvDetalle.TabIndex = 62
        '
        'SAD_ID
        '
        Me.SAD_ID.HeaderText = "SAD_ID"
        Me.SAD_ID.Name = "SAD_ID"
        Me.SAD_ID.Visible = False
        '
        'FSA_ID
        '
        Me.FSA_ID.HeaderText = "Falta"
        Me.FSA_ID.Name = "FSA_ID"
        Me.FSA_ID.Width = 250
        '
        'SAD_OBSERVACION
        '
        Me.SAD_OBSERVACION.HeaderText = "Observacion"
        Me.SAD_OBSERVACION.Name = "SAD_OBSERVACION"
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'frmSancion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(454, 462)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPer_Id_Proveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUNT_Id)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDNI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombresFalta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFecha)
        Me.Name = "frmSancion"
        Me.Text = "Sancion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtNombresFalta, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtDNI, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtUNT_Id, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtPer_Id_Proveedor, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtObservacion, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombresFalta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPer_Id_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUNT_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents SAD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FSA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAD_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider

End Class
