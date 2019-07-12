<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptReporteTickets
    Inherits Ladisac.Foundation.Views.ViewMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsReporteTicketsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.rbuTodos = New System.Windows.Forms.RadioButton()
        Me.rbuTickets = New System.Windows.Forms.RadioButton()
        Me.rbuVales = New System.Windows.Forms.RadioButton()
        CType(Me.dsReporteTicketsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(809, 28)
        Me.lblTitle.Text = "Reporte Tickets"
        '
        'dsReporteTicketsBindingSource
        '
        Me.dsReporteTicketsBindingSource.DataMember = "ReporteTickets"
        Me.dsReporteTicketsBindingSource.DataSource = GetType(dsReporteTickets)
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(488, 70)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(488, 41)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 84
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(433, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Desde el"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(5, 44)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 86
        Me.lblEmpresa.Text = "Empresa"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(83, 41)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(294, 20)
        Me.txtEmpresa.TabIndex = 82
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(621, 69)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(109, 23)
        Me.btnVisualizar.TabIndex = 90
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsReporteTickets"
        ReportDataSource1.Value = Me.dsReporteTicketsBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptReporteTickets.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(8, 105)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(796, 330)
        Me.ReportViewer1.TabIndex = 91
        '
        'rbuTodos
        '
        Me.rbuTodos.AutoSize = True
        Me.rbuTodos.Checked = True
        Me.rbuTodos.Location = New System.Drawing.Point(8, 72)
        Me.rbuTodos.Name = "rbuTodos"
        Me.rbuTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbuTodos.TabIndex = 92
        Me.rbuTodos.TabStop = True
        Me.rbuTodos.Text = "Todos"
        Me.rbuTodos.UseVisualStyleBackColor = True
        '
        'rbuTickets
        '
        Me.rbuTickets.AutoSize = True
        Me.rbuTickets.Location = New System.Drawing.Point(144, 72)
        Me.rbuTickets.Name = "rbuTickets"
        Me.rbuTickets.Size = New System.Drawing.Size(60, 17)
        Me.rbuTickets.TabIndex = 93
        Me.rbuTickets.Text = "Tickets"
        Me.rbuTickets.UseVisualStyleBackColor = True
        '
        'rbuVales
        '
        Me.rbuVales.AutoSize = True
        Me.rbuVales.Location = New System.Drawing.Point(287, 72)
        Me.rbuVales.Name = "rbuVales"
        Me.rbuVales.Size = New System.Drawing.Size(51, 17)
        Me.rbuVales.TabIndex = 94
        Me.rbuVales.Text = "Vales"
        Me.rbuVales.UseVisualStyleBackColor = True
        '
        'frmRptReporteTickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 474)
        Me.Controls.Add(Me.rbuVales)
        Me.Controls.Add(Me.rbuTickets)
        Me.Controls.Add(Me.rbuTodos)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Name = "frmRptReporteTickets"
        Me.Text = "Reporte Tickets"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtEmpresa, 0)
        Me.Controls.SetChildIndex(Me.lblEmpresa, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.rbuTodos, 0)
        Me.Controls.SetChildIndex(Me.rbuTickets, 0)
        Me.Controls.SetChildIndex(Me.rbuVales, 0)
        CType(Me.dsReporteTicketsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteTicketsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rbuTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbuTickets As System.Windows.Forms.RadioButton
    Friend WithEvents rbuVales As System.Windows.Forms.RadioButton
End Class
