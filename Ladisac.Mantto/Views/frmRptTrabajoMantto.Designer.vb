<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptTrabajoMantto
    Inherits Ladisac.Foundation.Views.ViewMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.dsTrabajoManttoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CFA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDetalle2 = New System.Windows.Forms.DataGridView()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpCompFF = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpCompFI = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkDetallado = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkComparativo = New System.Windows.Forms.CheckBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAgregarFila = New System.Windows.Forms.Button()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.cboFase = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        CType(Me.dsTrabajoManttoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1014, 28)
        Me.lblTitle.Text = "Reporte Estadistica Trabajos de Mantenimiento"
        '
        'dsTrabajoManttoBindingSource
        '
        Me.dsTrabajoManttoBindingSource.DataMember = "TrabajoMantto"
        Me.dsTrabajoManttoBindingSource.DataSource = GetType(dsTrabajoMantto)
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ENO_ID, Me.CPA, Me.CPC, Me.CFA, Me.CFC, Me.CEA, Me.CEC})
        Me.dgvDetalle.Location = New System.Drawing.Point(213, 41)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(784, 236)
        Me.dgvDetalle.TabIndex = 1
        '
        'ENO_ID
        '
        Me.ENO_ID.HeaderText = "Entidad"
        Me.ENO_ID.Name = "ENO_ID"
        '
        'CPA
        '
        Me.CPA.HeaderText = "Cant.Pend.Actual"
        Me.CPA.Name = "CPA"
        '
        'CPC
        '
        Me.CPC.HeaderText = "Cant.Pend.Comparativo"
        Me.CPC.Name = "CPC"
        '
        'CFA
        '
        Me.CFA.HeaderText = "Cant.Realizado.Actual"
        Me.CFA.Name = "CFA"
        '
        'CFC
        '
        Me.CFC.HeaderText = "Cant.Realizado.Comparativo"
        Me.CFC.Name = "CFC"
        '
        'CEA
        '
        Me.CEA.HeaderText = "Cant.Proceso.Actual"
        Me.CEA.Name = "CEA"
        '
        'CEC
        '
        Me.CEC.HeaderText = "Cant.Proceso.Comparativo"
        Me.CEC.Name = "CEC"
        '
        'dgvDetalle2
        '
        Me.dgvDetalle2.AllowUserToAddRows = False
        Me.dgvDetalle2.AllowUserToDeleteRows = False
        Me.dgvDetalle2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle2.Location = New System.Drawing.Point(6, 14)
        Me.dgvDetalle2.Name = "dgvDetalle2"
        Me.dgvDetalle2.ReadOnly = True
        Me.dgvDetalle2.Size = New System.Drawing.Size(959, 157)
        Me.dgvDetalle2.TabIndex = 2
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(62, 50)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 83
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(62, 22)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Desde el"
        '
        'dtpCompFF
        '
        Me.dtpCompFF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompFF.Location = New System.Drawing.Point(61, 54)
        Me.dtpCompFF.Name = "dtpCompFF"
        Me.dtpCompFF.Size = New System.Drawing.Size(85, 20)
        Me.dtpCompFF.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Hasta el"
        '
        'dtpCompFI
        '
        Me.dtpCompFI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompFI.Location = New System.Drawing.Point(61, 26)
        Me.dtpCompFI.Name = "dtpCompFI"
        Me.dtpCompFI.Size = New System.Drawing.Size(85, 20)
        Me.dtpCompFI.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Desde el"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsTrabajoMantto"
        ReportDataSource1.Value = Me.dsTrabajoManttoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptTrabajoMantto.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(6, 6)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(959, 165)
        Me.ReportViewer1.TabIndex = 88
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpFecIni)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFecFin)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 83)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo de Evaluacion"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpCompFI)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpCompFF)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(18, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(170, 90)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo Comparativo"
        '
        'chkDetallado
        '
        Me.chkDetallado.AutoSize = True
        Me.chkDetallado.Location = New System.Drawing.Point(20, 297)
        Me.chkDetallado.Name = "chkDetallado"
        Me.chkDetallado.Size = New System.Drawing.Size(112, 17)
        Me.chkDetallado.TabIndex = 91
        Me.chkDetallado.Text = "Reporte Detallado"
        Me.chkDetallado.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(18, 333)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(979, 203)
        Me.TabControl1.TabIndex = 92
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(971, 177)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reporte"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvDetalle2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(971, 177)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkComparativo
        '
        Me.chkComparativo.AutoSize = True
        Me.chkComparativo.Location = New System.Drawing.Point(18, 130)
        Me.chkComparativo.Name = "chkComparativo"
        Me.chkComparativo.Size = New System.Drawing.Size(85, 17)
        Me.chkComparativo.TabIndex = 93
        Me.chkComparativo.Text = "Comparativo"
        Me.chkComparativo.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(386, 295)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(128, 21)
        Me.cboGrupo.TabIndex = 120
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(344, 299)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Grupo"
        '
        'btnAgregarFila
        '
        Me.btnAgregarFila.Location = New System.Drawing.Point(213, 294)
        Me.btnAgregarFila.Name = "btnAgregarFila"
        Me.btnAgregarFila.Size = New System.Drawing.Size(98, 23)
        Me.btnAgregarFila.TabIndex = 121
        Me.btnAgregarFila.Text = "Agregar Fila"
        Me.btnAgregarFila.UseVisualStyleBackColor = True
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(871, 294)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(98, 23)
        Me.btnVisualizar.TabIndex = 122
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'cboFase
        '
        Me.cboFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFase.FormattingEnabled = True
        Me.cboFase.Items.AddRange(New Object() {"Pendiente", "En Proceso", "Finalizado"})
        Me.cboFase.Location = New System.Drawing.Point(585, 295)
        Me.cboFase.Name = "cboFase"
        Me.cboFase.Size = New System.Drawing.Size(111, 21)
        Me.cboFase.TabIndex = 127
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(549, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 126
        Me.Label14.Text = "Fase"
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(745, 294)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(98, 23)
        Me.btnExportar.TabIndex = 128
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmRptTrabajoMantto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 548)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.cboFase)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.btnAgregarFila)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkComparativo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.chkDetallado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Name = "frmRptTrabajoMantto"
        Me.Text = "Reporte Estadistica Trabajos de Mantenimiento"
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.chkDetallado, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.chkComparativo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboGrupo, 0)
        Me.Controls.SetChildIndex(Me.btnAgregarFila, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cboFase, 0)
        Me.Controls.SetChildIndex(Me.btnExportar, 0)
        CType(Me.dsTrabajoManttoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetalle2 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpCompFF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpCompFI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsTrabajoManttoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CFA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkDetallado As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkComparativo As System.Windows.Forms.CheckBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarFila As System.Windows.Forms.Button
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents cboFase As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
End Class
