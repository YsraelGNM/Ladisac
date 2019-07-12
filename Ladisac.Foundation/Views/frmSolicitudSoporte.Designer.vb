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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtU = New System.Windows.Forms.RadioButton()
        Me.rbtH = New System.Windows.Forms.RadioButton()
        Me.rbtS = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtNecesidad = New System.Windows.Forms.RadioButton()
        Me.rbtAjuste = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbtLadisac = New System.Windows.Forms.RadioButton()
        Me.rbtSpring = New System.Windows.Forms.RadioButton()
        Me.btnAtendido = New System.Windows.Forms.Button()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.Label3.Location = New System.Drawing.Point(12, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Autorizado"
        '
        'txtAutorizado
        '
        Me.txtAutorizado.Location = New System.Drawing.Point(89, 184)
        Me.txtAutorizado.Name = "txtAutorizado"
        Me.txtAutorizado.ReadOnly = True
        Me.txtAutorizado.Size = New System.Drawing.Size(441, 20)
        Me.txtAutorizado.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Solicitado"
        '
        'txtSolicitado
        '
        Me.txtSolicitado.Location = New System.Drawing.Point(89, 127)
        Me.txtSolicitado.Name = "txtSolicitado"
        Me.txtSolicitado.Size = New System.Drawing.Size(441, 20)
        Me.txtSolicitado.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Area"
        '
        'cboArea
        '
        Me.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Items.AddRange(New Object() {"G. Desarrollo Humano", "G. Logística ", "G. Comercial ", "G. Marketing y atención al cliente", "G. Mantenimiento y producción", "G. Seguridad y salud ocupacional", "G. Contabilidad y finanzas ", "G. Mejora continua", "G. Gerencias", "G. tecnología de la Información", "Otras Áreas"})
        Me.cboArea.Location = New System.Drawing.Point(89, 156)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(228, 21)
        Me.cboArea.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Asunto"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 211)
        Me.txtDescripcion.MaxLength = 255
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(441, 20)
        Me.txtDescripcion.TabIndex = 36
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SSD_MENSAJE, Me.SSD_FECHA})
        Me.dgvDetalle.Location = New System.Drawing.Point(89, 243)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(441, 230)
        Me.dgvDetalle.TabIndex = 37
        '
        'SSD_MENSAJE
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SSD_MENSAJE.DefaultCellStyle = DataGridViewCellStyle1
        Me.SSD_MENSAJE.FillWeight = 200.0!
        Me.SSD_MENSAJE.HeaderText = "MENSAJE"
        Me.SSD_MENSAJE.Name = "SSD_MENSAJE"
        Me.SSD_MENSAJE.Width = 260
        '
        'SSD_FECHA
        '
        Me.SSD_FECHA.HeaderText = "FECHA"
        Me.SSD_FECHA.Name = "SSD_FECHA"
        Me.SSD_FECHA.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Mensaje"
        '
        'txtConformidad
        '
        Me.txtConformidad.Location = New System.Drawing.Point(74, 19)
        Me.txtConformidad.MaxLength = 255
        Me.txtConformidad.Multiline = True
        Me.txtConformidad.Name = "txtConformidad"
        Me.txtConformidad.Size = New System.Drawing.Size(441, 41)
        Me.txtConformidad.TabIndex = 40
        '
        'rdbConforme
        '
        Me.rdbConforme.AutoSize = True
        Me.rdbConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbConforme.Location = New System.Drawing.Point(8, 19)
        Me.rdbConforme.Name = "rdbConforme"
        Me.rdbConforme.Size = New System.Drawing.Size(41, 17)
        Me.rdbConforme.TabIndex = 41
        Me.rdbConforme.TabStop = True
        Me.rdbConforme.Text = "SI  "
        Me.rdbConforme.UseVisualStyleBackColor = True
        '
        'rdbNoConforme
        '
        Me.rdbNoConforme.AutoSize = True
        Me.rdbNoConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbNoConforme.Location = New System.Drawing.Point(8, 42)
        Me.rdbNoConforme.Name = "rdbNoConforme"
        Me.rdbNoConforme.Size = New System.Drawing.Size(41, 17)
        Me.rdbNoConforme.TabIndex = 42
        Me.rdbNoConforme.TabStop = True
        Me.rdbNoConforme.Text = "NO"
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtConformidad)
        Me.GroupBox1.Controls.Add(Me.rdbConforme)
        Me.GroupBox1.Controls.Add(Me.rdbNoConforme)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 483)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 70)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conforme"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnAtendido)
        Me.GroupBox2.Controls.Add(Me.rbtU)
        Me.GroupBox2.Controls.Add(Me.rbtH)
        Me.GroupBox2.Controls.Add(Me.rbtS)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 559)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(515, 38)
        Me.GroupBox2.TabIndex = 133
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        Me.GroupBox2.Visible = False
        '
        'rbtU
        '
        Me.rbtU.AutoSize = True
        Me.rbtU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtU.Location = New System.Drawing.Point(261, 15)
        Me.rbtU.Name = "rbtU"
        Me.rbtU.Size = New System.Drawing.Size(61, 17)
        Me.rbtU.TabIndex = 43
        Me.rbtU.TabStop = True
        Me.rbtU.Text = "Usuario"
        Me.rbtU.UseVisualStyleBackColor = True
        '
        'rbtH
        '
        Me.rbtH.AutoSize = True
        Me.rbtH.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtH.Location = New System.Drawing.Point(72, 15)
        Me.rbtH.Name = "rbtH"
        Me.rbtH.Size = New System.Drawing.Size(71, 17)
        Me.rbtH.TabIndex = 41
        Me.rbtH.TabStop = True
        Me.rbtH.Text = "Hardware"
        Me.rbtH.UseVisualStyleBackColor = True
        '
        'rbtS
        '
        Me.rbtS.AutoSize = True
        Me.rbtS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtS.Location = New System.Drawing.Point(170, 15)
        Me.rbtS.Name = "rbtS"
        Me.rbtS.Size = New System.Drawing.Size(67, 17)
        Me.rbtS.TabIndex = 42
        Me.rbtS.TabStop = True
        Me.rbtS.Text = "Software"
        Me.rbtS.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbtNecesidad)
        Me.GroupBox3.Controls.Add(Me.rbtAjuste)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 604)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(515, 38)
        Me.GroupBox3.TabIndex = 134
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sub Tipo"
        Me.GroupBox3.Visible = False
        '
        'rbtNecesidad
        '
        Me.rbtNecesidad.AutoSize = True
        Me.rbtNecesidad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtNecesidad.Location = New System.Drawing.Point(72, 15)
        Me.rbtNecesidad.Name = "rbtNecesidad"
        Me.rbtNecesidad.Size = New System.Drawing.Size(93, 17)
        Me.rbtNecesidad.TabIndex = 41
        Me.rbtNecesidad.TabStop = True
        Me.rbtNecesidad.Text = "Requerimiento"
        Me.rbtNecesidad.UseVisualStyleBackColor = True
        '
        'rbtAjuste
        '
        Me.rbtAjuste.AutoSize = True
        Me.rbtAjuste.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtAjuste.Location = New System.Drawing.Point(170, 15)
        Me.rbtAjuste.Name = "rbtAjuste"
        Me.rbtAjuste.Size = New System.Drawing.Size(54, 17)
        Me.rbtAjuste.TabIndex = 42
        Me.rbtAjuste.TabStop = True
        Me.rbtAjuste.Text = "Ajuste"
        Me.rbtAjuste.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Sistema"
        '
        'rbtLadisac
        '
        Me.rbtLadisac.AutoSize = True
        Me.rbtLadisac.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtLadisac.Location = New System.Drawing.Point(89, 101)
        Me.rbtLadisac.Name = "rbtLadisac"
        Me.rbtLadisac.Size = New System.Drawing.Size(70, 17)
        Me.rbtLadisac.TabIndex = 136
        Me.rbtLadisac.TabStop = True
        Me.rbtLadisac.Text = "LADISAC"
        Me.rbtLadisac.UseVisualStyleBackColor = True
        '
        'rbtSpring
        '
        Me.rbtSpring.AutoSize = True
        Me.rbtSpring.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtSpring.Location = New System.Drawing.Point(187, 101)
        Me.rbtSpring.Name = "rbtSpring"
        Me.rbtSpring.Size = New System.Drawing.Size(66, 17)
        Me.rbtSpring.TabIndex = 137
        Me.rbtSpring.TabStop = True
        Me.rbtSpring.Text = "SPRING"
        Me.rbtSpring.UseVisualStyleBackColor = True
        '
        'btnAtendido
        '
        Me.btnAtendido.Location = New System.Drawing.Point(451, 12)
        Me.btnAtendido.Name = "btnAtendido"
        Me.btnAtendido.Size = New System.Drawing.Size(57, 20)
        Me.btnAtendido.TabIndex = 44
        Me.btnAtendido.Text = "Atendido"
        Me.btnAtendido.UseVisualStyleBackColor = True
        '
        'frmSolicitudSoporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(546, 661)
        Me.Controls.Add(Me.rbtLadisac)
        Me.Controls.Add(Me.rbtSpring)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCodigo)
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
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.rbtSpring, 0)
        Me.Controls.SetChildIndex(Me.rbtLadisac, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaCalendario1 As ColumnaCalendario
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtH As System.Windows.Forms.RadioButton
    Friend WithEvents rbtS As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtU As System.Windows.Forms.RadioButton
    Friend WithEvents SSD_MENSAJE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SSD_FECHA As ColumnaCalendario
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtNecesidad As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAjuste As System.Windows.Forms.RadioButton
    Friend WithEvents rbtLadisac As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSpring As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAtendido As System.Windows.Forms.Button

End Class
