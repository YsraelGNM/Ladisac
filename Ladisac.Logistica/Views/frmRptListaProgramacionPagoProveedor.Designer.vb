<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptListaProgramacionPagoProveedor
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
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsListaProgramacionPagoProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsListaProgramacionPagoProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(892, 28)
        Me.lblTitle.Text = "Reporte de Programacion de Pago de Proveedores a Credito"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(431, 44)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(109, 23)
        Me.btnVisualizar.TabIndex = 101
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(298, 45)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(89, 45)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Desde el"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(18, 76)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(56, 13)
        Me.lblEmpresa.TabIndex = 98
        Me.lblEmpresa.Text = "Proveedor"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(89, 72)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(294, 20)
        Me.txtEmpresa.TabIndex = 95
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaProgramacionPagoProveedor"
        ReportDataSource1.Value = Me.dsListaProgramacionPagoProveedorBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaProgramacionPagoProveedor.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(21, 124)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(859, 387)
        Me.ReportViewer1.TabIndex = 102
        '
        'dsListaProgramacionPagoProveedorBindingSource
        '
        Me.dsListaProgramacionPagoProveedorBindingSource.DataMember = "ListaProgramacionPagoProveedor"
        Me.dsListaProgramacionPagoProveedorBindingSource.DataSource = GetType(dsListaProgramacionPagoProveedor)
        '
        'frmRptListaProgramacionPagoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(892, 523)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Name = "frmRptListaProgramacionPagoProveedor"
        Me.Text = "Reporte de Programacion de Pago de Proveedores a Credito"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtEmpresa, 0)
        Me.Controls.SetChildIndex(Me.lblEmpresa, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsListaProgramacionPagoProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaProgramacionPagoProveedorBindingSource As System.Windows.Forms.BindingSource

End Class
