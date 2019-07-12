<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptAnalisisCuentasCorrientes
    Inherits Ladisac.Foundation.Views.ViewMaster

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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsAnalisisCuentasCorrientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPeriodoInicial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPeriodoFinal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCtaFinal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCtaInicial = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.chk1 = New System.Windows.Forms.RadioButton()
        Me.chk2 = New System.Windows.Forms.RadioButton()
        Me.chk3 = New System.Windows.Forms.RadioButton()
        Me.chk4 = New System.Windows.Forms.RadioButton()
        Me.chk5 = New System.Windows.Forms.RadioButton()
        Me.chk6 = New System.Windows.Forms.RadioButton()
        Me.chk7 = New System.Windows.Forms.RadioButton()
        Me.chk8 = New System.Windows.Forms.RadioButton()
        Me.chk0 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLibro = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.chkCuenta = New System.Windows.Forms.CheckBox()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.chkDocumento = New System.Windows.Forms.CheckBox()
        Me.chkDetalle = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtAmbos = New System.Windows.Forms.RadioButton()
        Me.rbtConSaldo = New System.Windows.Forms.RadioButton()
        Me.rbtSinSaldo = New System.Windows.Forms.RadioButton()
        CType(Me.dsAnalisisCuentasCorrientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1076, 28)
        Me.lblTitle.Text = "Reporte Analisis Cuentas Corrientes"
        '
        'dsAnalisisCuentasCorrientesBindingSource
        '
        Me.dsAnalisisCuentasCorrientesBindingSource.DataMember = "AnalisisCuentasCorrientes"
        Me.dsAnalisisCuentasCorrientesBindingSource.DataSource = GetType(dsAnalisisCuentasCorrientes)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Periodo Inicial"
        '
        'txtPeriodoInicial
        '
        Me.txtPeriodoInicial.BackColor = System.Drawing.Color.White
        Me.txtPeriodoInicial.Location = New System.Drawing.Point(90, 38)
        Me.txtPeriodoInicial.MaxLength = 6
        Me.txtPeriodoInicial.Name = "txtPeriodoInicial"
        Me.txtPeriodoInicial.ReadOnly = True
        Me.txtPeriodoInicial.Size = New System.Drawing.Size(79, 20)
        Me.txtPeriodoInicial.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Periodo Final"
        '
        'txtPeriodoFinal
        '
        Me.txtPeriodoFinal.BackColor = System.Drawing.Color.White
        Me.txtPeriodoFinal.Location = New System.Drawing.Point(90, 65)
        Me.txtPeriodoFinal.MaxLength = 6
        Me.txtPeriodoFinal.Name = "txtPeriodoFinal"
        Me.txtPeriodoFinal.ReadOnly = True
        Me.txtPeriodoFinal.Size = New System.Drawing.Size(79, 20)
        Me.txtPeriodoFinal.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Cuenta Final"
        '
        'txtCtaFinal
        '
        Me.txtCtaFinal.Location = New System.Drawing.Point(273, 65)
        Me.txtCtaFinal.MaxLength = 14
        Me.txtCtaFinal.Name = "txtCtaFinal"
        Me.txtCtaFinal.Size = New System.Drawing.Size(168, 20)
        Me.txtCtaFinal.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(195, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Cuenta Inicial"
        '
        'txtCtaInicial
        '
        Me.txtCtaInicial.Location = New System.Drawing.Point(273, 38)
        Me.txtCtaInicial.MaxLength = 14
        Me.txtCtaInicial.Name = "txtCtaInicial"
        Me.txtCtaInicial.Size = New System.Drawing.Size(168, 20)
        Me.txtCtaInicial.TabIndex = 73
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(468, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Persona"
        '
        'txtPersona
        '
        Me.txtPersona.BackColor = System.Drawing.Color.White
        Me.txtPersona.Location = New System.Drawing.Point(520, 38)
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(360, 20)
        Me.txtPersona.TabIndex = 78
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.Location = New System.Drawing.Point(6, 31)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(57, 17)
        Me.chk1.TabIndex = 79
        Me.chk1.Text = "Cliente"
        Me.chk1.UseVisualStyleBackColor = True
        '
        'chk2
        '
        Me.chk2.AutoSize = True
        Me.chk2.Location = New System.Drawing.Point(102, 31)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(74, 17)
        Me.chk2.TabIndex = 80
        Me.chk2.Text = "Proveedor"
        Me.chk2.UseVisualStyleBackColor = True
        '
        'chk3
        '
        Me.chk3.AutoSize = True
        Me.chk3.Location = New System.Drawing.Point(198, 30)
        Me.chk3.Name = "chk3"
        Me.chk3.Size = New System.Drawing.Size(86, 17)
        Me.chk3.TabIndex = 81
        Me.chk3.Text = "Transportista"
        Me.chk3.UseVisualStyleBackColor = True
        '
        'chk4
        '
        Me.chk4.AutoSize = True
        Me.chk4.Location = New System.Drawing.Point(294, 31)
        Me.chk4.Name = "chk4"
        Me.chk4.Size = New System.Drawing.Size(76, 17)
        Me.chk4.TabIndex = 82
        Me.chk4.Text = "Trabajador"
        Me.chk4.UseVisualStyleBackColor = True
        '
        'chk5
        '
        Me.chk5.AutoSize = True
        Me.chk5.Location = New System.Drawing.Point(6, 63)
        Me.chk5.Name = "chk5"
        Me.chk5.Size = New System.Drawing.Size(56, 17)
        Me.chk5.TabIndex = 83
        Me.chk5.Text = "Banco"
        Me.chk5.UseVisualStyleBackColor = True
        '
        'chk6
        '
        Me.chk6.AutoSize = True
        Me.chk6.Location = New System.Drawing.Point(102, 63)
        Me.chk6.Name = "chk6"
        Me.chk6.Size = New System.Drawing.Size(54, 17)
        Me.chk6.TabIndex = 84
        Me.chk6.Text = "Grupo"
        Me.chk6.UseVisualStyleBackColor = True
        '
        'chk7
        '
        Me.chk7.AutoSize = True
        Me.chk7.Location = New System.Drawing.Point(198, 63)
        Me.chk7.Name = "chk7"
        Me.chk7.Size = New System.Drawing.Size(68, 17)
        Me.chk7.TabIndex = 85
        Me.chk7.Text = "Contacto"
        Me.chk7.UseVisualStyleBackColor = True
        '
        'chk8
        '
        Me.chk8.AutoSize = True
        Me.chk8.Location = New System.Drawing.Point(294, 63)
        Me.chk8.Name = "chk8"
        Me.chk8.Size = New System.Drawing.Size(112, 17)
        Me.chk8.TabIndex = 86
        Me.chk8.Text = "Transporte Interno"
        Me.chk8.UseVisualStyleBackColor = True
        '
        'chk0
        '
        Me.chk0.AutoSize = True
        Me.chk0.Checked = True
        Me.chk0.Location = New System.Drawing.Point(6, 95)
        Me.chk0.Name = "chk0"
        Me.chk0.Size = New System.Drawing.Size(65, 17)
        Me.chk0.TabIndex = 87
        Me.chk0.TabStop = True
        Me.chk0.Text = "Ninguno"
        Me.chk0.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(195, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Libro"
        '
        'txtLibro
        '
        Me.txtLibro.Location = New System.Drawing.Point(273, 92)
        Me.txtLibro.MaxLength = 4
        Me.txtLibro.Name = "txtLibro"
        Me.txtLibro.Size = New System.Drawing.Size(168, 20)
        Me.txtLibro.TabIndex = 88
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsAnalisisCuentasCorrientes"
        ReportDataSource1.Value = Me.dsAnalisisCuentasCorrientesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptAnalisisCuentasCorrientes.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 202)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1049, 320)
        Me.ReportViewer1.TabIndex = 90
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(901, 38)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(163, 61)
        Me.btnVisualizar.TabIndex = 91
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Checked = True
        Me.chkPeriodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPeriodo.Location = New System.Drawing.Point(15, 128)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(62, 17)
        Me.chkPeriodo.TabIndex = 92
        Me.chkPeriodo.Text = "Periodo"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'chkCuenta
        '
        Me.chkCuenta.AutoSize = True
        Me.chkCuenta.Checked = True
        Me.chkCuenta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCuenta.Location = New System.Drawing.Point(83, 128)
        Me.chkCuenta.Name = "chkCuenta"
        Me.chkCuenta.Size = New System.Drawing.Size(60, 17)
        Me.chkCuenta.TabIndex = 93
        Me.chkCuenta.Text = "Cuenta"
        Me.chkCuenta.UseVisualStyleBackColor = True
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Location = New System.Drawing.Point(151, 128)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(65, 17)
        Me.chkPersona.TabIndex = 94
        Me.chkPersona.Text = "Persona"
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'chkDocumento
        '
        Me.chkDocumento.AutoSize = True
        Me.chkDocumento.Location = New System.Drawing.Point(222, 128)
        Me.chkDocumento.Name = "chkDocumento"
        Me.chkDocumento.Size = New System.Drawing.Size(81, 17)
        Me.chkDocumento.TabIndex = 95
        Me.chkDocumento.Text = "Documento"
        Me.chkDocumento.UseVisualStyleBackColor = True
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Location = New System.Drawing.Point(304, 128)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(59, 17)
        Me.chkDetalle.TabIndex = 96
        Me.chkDetalle.Text = "Detalle"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk1)
        Me.GroupBox1.Controls.Add(Me.chk2)
        Me.GroupBox1.Controls.Add(Me.chk3)
        Me.GroupBox1.Controls.Add(Me.chk4)
        Me.GroupBox1.Controls.Add(Me.chk5)
        Me.GroupBox1.Controls.Add(Me.chk6)
        Me.GroupBox1.Controls.Add(Me.chk7)
        Me.GroupBox1.Controls.Add(Me.chk8)
        Me.GroupBox1.Controls.Add(Me.chk0)
        Me.GroupBox1.Location = New System.Drawing.Point(471, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 131)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Persona o Anexo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtAmbos)
        Me.GroupBox2.Controls.Add(Me.rbtConSaldo)
        Me.GroupBox2.Controls.Add(Me.rbtSinSaldo)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(348, 45)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Saldos"
        '
        'rbtAmbos
        '
        Me.rbtAmbos.AutoSize = True
        Me.rbtAmbos.Checked = True
        Me.rbtAmbos.Location = New System.Drawing.Point(10, 19)
        Me.rbtAmbos.Name = "rbtAmbos"
        Me.rbtAmbos.Size = New System.Drawing.Size(57, 17)
        Me.rbtAmbos.TabIndex = 86
        Me.rbtAmbos.TabStop = True
        Me.rbtAmbos.Text = "Ambos"
        Me.rbtAmbos.UseVisualStyleBackColor = True
        '
        'rbtConSaldo
        '
        Me.rbtConSaldo.AutoSize = True
        Me.rbtConSaldo.Location = New System.Drawing.Point(98, 19)
        Me.rbtConSaldo.Name = "rbtConSaldo"
        Me.rbtConSaldo.Size = New System.Drawing.Size(79, 17)
        Me.rbtConSaldo.TabIndex = 87
        Me.rbtConSaldo.Text = "Con Saldos"
        Me.rbtConSaldo.UseVisualStyleBackColor = True
        '
        'rbtSinSaldo
        '
        Me.rbtSinSaldo.AutoSize = True
        Me.rbtSinSaldo.Location = New System.Drawing.Point(202, 19)
        Me.rbtSinSaldo.Name = "rbtSinSaldo"
        Me.rbtSinSaldo.Size = New System.Drawing.Size(70, 17)
        Me.rbtSinSaldo.TabIndex = 88
        Me.rbtSinSaldo.Text = "Sin Saldo"
        Me.rbtSinSaldo.UseVisualStyleBackColor = True
        '
        'frmRptAnalisisCuentasCorrientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1076, 534)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkDetalle)
        Me.Controls.Add(Me.chkDocumento)
        Me.Controls.Add(Me.chkPersona)
        Me.Controls.Add(Me.chkCuenta)
        Me.Controls.Add(Me.chkPeriodo)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtLibro)
        Me.Controls.Add(Me.txtPersona)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCtaFinal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCtaInicial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPeriodoFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPeriodoInicial)
        Me.Name = "frmRptAnalisisCuentasCorrientes"
        Me.Text = "Reporte Analisis Cuentas Corrientes"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtPeriodoInicial, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtPeriodoFinal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCtaInicial, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtCtaFinal, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtPersona, 0)
        Me.Controls.SetChildIndex(Me.txtLibro, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.chkPeriodo, 0)
        Me.Controls.SetChildIndex(Me.chkCuenta, 0)
        Me.Controls.SetChildIndex(Me.chkPersona, 0)
        Me.Controls.SetChildIndex(Me.chkDocumento, 0)
        Me.Controls.SetChildIndex(Me.chkDetalle, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.dsAnalisisCuentasCorrientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodoInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCtaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCtaInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents chk1 As System.Windows.Forms.RadioButton
    Friend WithEvents chk2 As System.Windows.Forms.RadioButton
    Friend WithEvents chk3 As System.Windows.Forms.RadioButton
    Friend WithEvents chk4 As System.Windows.Forms.RadioButton
    Friend WithEvents chk5 As System.Windows.Forms.RadioButton
    Friend WithEvents chk6 As System.Windows.Forms.RadioButton
    Friend WithEvents chk7 As System.Windows.Forms.RadioButton
    Friend WithEvents chk8 As System.Windows.Forms.RadioButton
    Friend WithEvents chk0 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLibro As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dsAnalisisCuentasCorrientesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents chkCuenta As System.Windows.Forms.CheckBox
    Friend WithEvents chkPersona As System.Windows.Forms.CheckBox
    Friend WithEvents chkDocumento As System.Windows.Forms.CheckBox
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConSaldo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSinSaldo As System.Windows.Forms.RadioButton

End Class
