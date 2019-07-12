<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptFichaInspeccion
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
        Me.dsReporteFichaInspeccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        CType(Me.dsReporteFichaInspeccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(958, 28)
        Me.lblTitle.Text = "Reporte Ficha de Inspecciones"
        '
        'dsReporteFichaInspeccionBindingSource
        '
        Me.dsReporteFichaInspeccionBindingSource.DataMember = "ReporteFichaInspeccion"
        Me.dsReporteFichaInspeccionBindingSource.DataSource = GetType(dsReporteFichaInspeccion)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsReporteFichaInspeccion"
        ReportDataSource1.Value = Me.dsReporteFichaInspeccionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptFichaInspeccion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 72)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(934, 379)
        Me.ReportViewer1.TabIndex = 1
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(13, 43)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 2
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'frmRptFichaInspeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(958, 463)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptFichaInspeccion"
        Me.Text = "Reporte Ficha de Inspecciones"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        CType(Me.dsReporteFichaInspeccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dsReporteFichaInspeccionBindingSource As System.Windows.Forms.BindingSource

End Class
