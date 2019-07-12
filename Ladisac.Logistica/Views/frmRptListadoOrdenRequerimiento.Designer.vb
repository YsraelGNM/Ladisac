<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptListadoOrdenRequerimiento
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
        Me.dsListadoOrdenRequerimientoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.rbtAtendidas = New System.Windows.Forms.RadioButton()
        Me.rbtPendientes = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrdenTrabajo = New System.Windows.Forms.TextBox()
        Me.cboImportancia = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dsListadoOrdenRequerimientoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(916, 28)
        Me.lblTitle.Text = "Reporte Listado Orden Requerimiento"
        '
        'dsListadoOrdenRequerimientoBindingSource
        '
        Me.dsListadoOrdenRequerimientoBindingSource.DataMember = "ListadoOrdenRequerimiento"
        Me.dsListadoOrdenRequerimientoBindingSource.DataSource = GetType(dsListadoOrdenRequerimiento)
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(816, 68)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 69
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(67, 69)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(67, 43)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Desde el"
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Location = New System.Drawing.Point(6, 19)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodas.TabIndex = 70
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'rbtAtendidas
        '
        Me.rbtAtendidas.AutoSize = True
        Me.rbtAtendidas.Location = New System.Drawing.Point(155, 19)
        Me.rbtAtendidas.Name = "rbtAtendidas"
        Me.rbtAtendidas.Size = New System.Drawing.Size(72, 17)
        Me.rbtAtendidas.TabIndex = 71
        Me.rbtAtendidas.Text = "Atendidas"
        Me.rbtAtendidas.UseVisualStyleBackColor = True
        '
        'rbtPendientes
        '
        Me.rbtPendientes.AutoSize = True
        Me.rbtPendientes.Checked = True
        Me.rbtPendientes.Location = New System.Drawing.Point(71, 19)
        Me.rbtPendientes.Name = "rbtPendientes"
        Me.rbtPendientes.Size = New System.Drawing.Size(78, 17)
        Me.rbtPendientes.TabIndex = 72
        Me.rbtPendientes.TabStop = True
        Me.rbtPendientes.Text = "Pendientes"
        Me.rbtPendientes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtTodas)
        Me.GroupBox1.Controls.Add(Me.rbtAtendidas)
        Me.GroupBox1.Controls.Add(Me.rbtPendientes)
        Me.GroupBox1.Location = New System.Drawing.Point(171, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 46)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(419, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Orden Trabajo"
        '
        'txtOrdenTrabajo
        '
        Me.txtOrdenTrabajo.Location = New System.Drawing.Point(497, 46)
        Me.txtOrdenTrabajo.Name = "txtOrdenTrabajo"
        Me.txtOrdenTrabajo.Size = New System.Drawing.Size(302, 20)
        Me.txtOrdenTrabajo.TabIndex = 76
        '
        'cboImportancia
        '
        Me.cboImportancia.FormattingEnabled = True
        Me.cboImportancia.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboImportancia.Location = New System.Drawing.Point(497, 70)
        Me.cboImportancia.Name = "cboImportancia"
        Me.cboImportancia.Size = New System.Drawing.Size(58, 21)
        Me.cboImportancia.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(420, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Importancia"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListadoOrdenRequerimiento"
        ReportDataSource1.Value = Me.dsListadoOrdenRequerimientoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListadoOrdenRequerimiento.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 115)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(876, 386)
        Me.ReportViewer1.TabIndex = 80
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(611, 70)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(188, 21)
        Me.cboGrupo.TabIndex = 118
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(566, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "Grupo"
        '
        'frmRptListadoOrdenRequerimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(916, 522)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cboImportancia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOrdenTrabajo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptListadoOrdenRequerimiento"
        Me.Text = "Reporte Listado Orden Requerimiento"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.txtOrdenTrabajo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboImportancia, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboGrupo, 0)
        CType(Me.dsListadoOrdenRequerimientoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbtTodas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAtendidas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents cboImportancia As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListadoOrdenRequerimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
