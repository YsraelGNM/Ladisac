<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptContabilidad
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAnio = New System.Windows.Forms.ComboBox()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsListaTNQuemadaXAnioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsListaCantidadQuemadaXAnioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsListaTNQuemadaXAnioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaCantidadQuemadaXAnioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(886, 28)
        Me.lblTitle.Text = "Reportes Contabilidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Año:"
        '
        'cboAnio
        '
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.FormattingEnabled = True
        Me.cboAnio.Items.AddRange(New Object() {"2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cboAnio.Location = New System.Drawing.Point(47, 40)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(107, 21)
        Me.cboAnio.TabIndex = 2
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(185, 39)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 3
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaTNQuemadaXAnio"
        ReportDataSource1.Value = Me.dsListaTNQuemadaXAnioBindingSource
        ReportDataSource2.Name = "dsListaCantidadQuemadaXAnio"
        ReportDataSource2.Value = Me.dsListaCantidadQuemadaXAnioBindingSource
        ReportDataSource3.Name = "dsListaReciclajeVentaLadrilloXAnioSeparado"
        ReportDataSource3.Value = Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptContabilidad.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 82)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(859, 445)
        Me.ReportViewer1.TabIndex = 4
        '
        'dsListaTNQuemadaXAnioBindingSource
        '
        Me.dsListaTNQuemadaXAnioBindingSource.DataMember = "ListaTNQuemadaXAnio"
        Me.dsListaTNQuemadaXAnioBindingSource.DataSource = GetType(dsListaTNQuemadaXAnio)
        '
        'dsListaCantidadQuemadaXAnioBindingSource
        '
        Me.dsListaCantidadQuemadaXAnioBindingSource.DataMember = "ListaCantidadQuemadaXAnio"
        Me.dsListaCantidadQuemadaXAnioBindingSource.DataSource = GetType(dsListaCantidadQuemadaXAnio)
        '
        'dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource
        '
        Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource.DataMember = "ListaReciclajeVentaLadrilloXAnioSeparado"
        Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource.DataSource = GetType(dsListaReciclajeVentaLadrilloXAnioSeparado)
        '
        'frmRptContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(886, 539)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.cboAnio)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRptContabilidad"
        Me.Text = "Reportes Contabilidad"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboAnio, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsListaTNQuemadaXAnioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaCantidadQuemadaXAnioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAnio As System.Windows.Forms.ComboBox
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaTNQuemadaXAnioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsListaCantidadQuemadaXAnioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsListaReciclajeVentaLadrilloXAnioSeparadoBindingSource As System.Windows.Forms.BindingSource

End Class
