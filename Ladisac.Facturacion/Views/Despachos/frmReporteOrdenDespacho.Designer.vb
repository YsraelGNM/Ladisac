<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteOrdenDespacho
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsReporteOrdenDespachoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.rbtPendientes = New System.Windows.Forms.RadioButton()
        Me.rbtAtendidas = New System.Windows.Forms.RadioButton()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dsReporteOrdenDespachoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(902, 28)
        Me.lblTitle.Text = "Reporte Orden Despacho"
        '
        'dsReporteOrdenDespachoBindingSource
        '
        Me.dsReporteOrdenDespachoBindingSource.DataMember = "ReporteOrdenDespacho"
        Me.dsReporteOrdenDespachoBindingSource.DataSource = GetType(dsReporteOrdenDespacho)
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(670, 46)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(101, 23)
        Me.btnCargar.TabIndex = 81
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(238, 47)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaFin.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(62, 47)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaIni.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Desde"
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Checked = True
        Me.rbtTodas.Location = New System.Drawing.Point(370, 49)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodas.TabIndex = 82
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'rbtPendientes
        '
        Me.rbtPendientes.AutoSize = True
        Me.rbtPendientes.Location = New System.Drawing.Point(466, 49)
        Me.rbtPendientes.Name = "rbtPendientes"
        Me.rbtPendientes.Size = New System.Drawing.Size(78, 17)
        Me.rbtPendientes.TabIndex = 83
        Me.rbtPendientes.Text = "Pendientes"
        Me.rbtPendientes.UseVisualStyleBackColor = True
        '
        'rbtAtendidas
        '
        Me.rbtAtendidas.AutoSize = True
        Me.rbtAtendidas.Location = New System.Drawing.Point(562, 49)
        Me.rbtAtendidas.Name = "rbtAtendidas"
        Me.rbtAtendidas.Size = New System.Drawing.Size(72, 17)
        Me.rbtAtendidas.TabIndex = 84
        Me.rbtAtendidas.Text = "Atendidas"
        Me.rbtAtendidas.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource2.Name = "dsReporteOrdenDespacho"
        ReportDataSource2.Value = Me.dsReporteOrdenDespachoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptReporteOrdenDespacho.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 101)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(875, 412)
        Me.ReportViewer1.TabIndex = 85
        '
        'frmReporteOrdenDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(902, 525)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.rbtAtendidas)
        Me.Controls.Add(Me.rbtPendientes)
        Me.Controls.Add(Me.rbtTodas)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmReporteOrdenDespacho"
        Me.Text = "Reporte Orden Despacho"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaIni, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.rbtTodas, 0)
        Me.Controls.SetChildIndex(Me.rbtPendientes, 0)
        Me.Controls.SetChildIndex(Me.rbtAtendidas, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsReporteOrdenDespachoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbtTodas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAtendidas As System.Windows.Forms.RadioButton
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteOrdenDespachoBindingSource As System.Windows.Forms.BindingSource

End Class
