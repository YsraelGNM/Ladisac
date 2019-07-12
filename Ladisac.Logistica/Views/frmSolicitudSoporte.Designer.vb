<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudSoporte
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
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAutorizado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSolicitado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.SSD_MENSAJE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SSD_FECHA = New ColumnaCalendario()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConformidad = New System.Windows.Forms.TextBox()
        Me.rdbConforme = New System.Windows.Forms.RadioButton()
        Me.rdbNoConforme = New System.Windows.Forms.RadioButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaCalendario1 = New ColumnaCalendario()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(546, 28)
        Me.lblTitle.Text = "Solicitud de Soporte"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(433, 71)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(97, 20)
        Me.dtpfecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(388, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Autorizado"
        '
        'txtAutorizado
        '
        Me.txtAutorizado.Location = New System.Drawing.Point(89, 150)
        Me.txtAutorizado.Name = "txtAutorizado"
        Me.txtAutorizado.Size = New System.Drawing.Size(441, 20)
        Me.txtAutorizado.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Solicitado"
        '
        'txtSolicitado
        '
        Me.txtSolicitado.Location = New System.Drawing.Point(89, 97)
        Me.txtSolicitado.Name = "txtSolicitado"
        Me.txtSolicitado.Size = New System.Drawing.Size(441, 20)
        Me.txtSolicitado.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Area"
        '
        'cboArea
        '
        Me.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Items.AddRange(New Object() {"GCO", "GMK", "GDH", "GLO-COM", "GLO-AL", "GLO-APTD", "GMP-PR", "GMP-MT", "GSSO", "GCT", "GMC"})
        Me.cboArea.Location = New System.Drawing.Point(89, 123)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(228, 21)
        Me.cboArea.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 176)
        Me.txtDescripcion.MaxLength = 255
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(441, 74)
        Me.txtDescripcion.TabIndex = 36
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SSD_MENSAJE, Me.SSD_FECHA})
        Me.dgvDetalle.Location = New System.Drawing.Point(89, 256)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(441, 150)
        Me.dgvDetalle.TabIndex = 37
        '
        'SSD_MENSAJE
        '
        Me.SSD_MENSAJE.HeaderText = "MENSAJE"
        Me.SSD_MENSAJE.Name = "SSD_MENSAJE"
        Me.SSD_MENSAJE.Width = 250
        '
        'SSD_FECHA
        '
        Me.SSD_FECHA.HeaderText = "FECHA"
        Me.SSD_FECHA.Name = "SSD_FECHA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Mensaje"
        '
        'txtConformidad
        '
        Me.txtConformidad.Location = New System.Drawing.Point(107, 441)
        Me.txtConformidad.MaxLength = 255
        Me.txtConformidad.Multiline = True
        Me.txtConformidad.Name = "txtConformidad"
        Me.txtConformidad.Size = New System.Drawing.Size(423, 41)
        Me.txtConformidad.TabIndex = 40
        '
        'rdbConforme
        '
        Me.rdbConforme.AutoSize = True
        Me.rdbConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbConforme.Location = New System.Drawing.Point(12, 441)
        Me.rdbConforme.Name = "rdbConforme"
        Me.rdbConforme.Size = New System.Drawing.Size(70, 17)
        Me.rdbConforme.TabIndex = 41
        Me.rdbConforme.TabStop = True
        Me.rdbConforme.Text = "Conforme"
        Me.rdbConforme.UseVisualStyleBackColor = True
        '
        'rdbNoConforme
        '
        Me.rdbNoConforme.AutoSize = True
        Me.rdbNoConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbNoConforme.Location = New System.Drawing.Point(12, 464)
        Me.rdbNoConforme.Name = "rdbNoConforme"
        Me.rdbNoConforme.Size = New System.Drawing.Size(89, 17)
        Me.rdbNoConforme.TabIndex = 42
        Me.rdbNoConforme.TabStop = True
        Me.rdbNoConforme.Text = "NO Conforme"
        Me.rdbNoConforme.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MENSAJE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'ColumnaCalendario1
        '
        Me.ColumnaCalendario1.HeaderText = "FECHA"
        Me.ColumnaCalendario1.Name = "ColumnaCalendario1"
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(89, 71)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(73, 20)
        Me.txtCodigo.TabIndex = 130
        '
        'frmSolicitudSoporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(546, 488)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.rdbNoConforme)
        Me.Controls.Add(Me.rdbConforme)
        Me.Controls.Add(Me.txtConformidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboArea)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAutorizado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSolicitado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpfecha)
        Me.Name = "frmSolicitudSoporte"
        Me.Text = "Solicitud de Soporte"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dtpfecha, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtSolicitado, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtAutorizado, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboArea, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtConformidad, 0)
        Me.Controls.SetChildIndex(Me.rdbConforme, 0)
        Me.Controls.SetChildIndex(Me.rdbNoConforme, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAutorizado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConformidad As System.Windows.Forms.TextBox
    Friend WithEvents rdbConforme As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNoConforme As System.Windows.Forms.RadioButton
    Friend WithEvents SSD_MENSAJE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SSD_FECHA As ColumnaCalendario
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaCalendario1 As ColumnaCalendario
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox

End Class
