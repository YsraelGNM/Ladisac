<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptPlanillaConsolidadoSuma
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsReportePlanillaConsolidadoSumaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsReportePlanillaConsolidadoSumaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(971, 28)
        Me.lblTitle.Text = "Planilla Consolidado Suma"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsReportePlanillaConsolidadoSuma"
        ReportDataSource1.Value = Me.dsReportePlanillaConsolidadoSumaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptPlanillaConsolidadoSuma.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 31)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(947, 528)
        Me.ReportViewer1.TabIndex = 1
        '
        'dsReportePlanillaConsolidadoSumaBindingSource
        '
        Me.dsReportePlanillaConsolidadoSumaBindingSource.DataMember = "ReportePlanillaConsolidadoSuma"
        Me.dsReportePlanillaConsolidadoSumaBindingSource.DataSource = GetType(dsReportePlanillaConsolidadoSuma)
        '
        'frmRptPlanillaConsolidadoSuma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(971, 571)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptPlanillaConsolidadoSuma"
        Me.Text = "Planilla Consolidado Suma"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsReportePlanillaConsolidadoSumaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReportePlanillaConsolidadoSumaBindingSource As System.Windows.Forms.BindingSource

End Class
