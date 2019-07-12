<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptListatnQuemadas
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
        Me.dsListaTnQuemadasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.chkDetallado = New System.Windows.Forms.CheckBox()
        Me.dsListaTnProducidasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsListaTnQuemadasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaTnProducidasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(988, 28)
        Me.lblTitle.Text = "Reporte Tonelaje"
        '
        'dsListaTnQuemadasBindingSource
        '
        Me.dsListaTnQuemadasBindingSource.DataMember = "ListaTnQuemadas"
        Me.dsListaTnQuemadasBindingSource.DataSource = GetType(dsListaTnQuemadas)
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(213, 59)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(163, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(67, 59)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 74
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Desde el"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(431, 50)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(99, 38)
        Me.btnVisualizar.TabIndex = 77
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaTnQuemadas"
        ReportDataSource1.Value = Me.dsListaTnQuemadasBindingSource
        ReportDataSource2.Name = "dsListaTnProducidas"
        ReportDataSource2.Value = Me.dsListaTnProducidasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaTnQuemadas_Producidas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 112)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(961, 435)
        Me.ReportViewer1.TabIndex = 78
        '
        'chkDetallado
        '
        Me.chkDetallado.AutoSize = True
        Me.chkDetallado.Location = New System.Drawing.Point(330, 59)
        Me.chkDetallado.Name = "chkDetallado"
        Me.chkDetallado.Size = New System.Drawing.Size(71, 17)
        Me.chkDetallado.TabIndex = 79
        Me.chkDetallado.Text = "Detallado"
        Me.chkDetallado.UseVisualStyleBackColor = True
        '
        'dsListaTnProducidasBindingSource
        '
        Me.dsListaTnProducidasBindingSource.DataMember = "ListaTnProducidas"
        Me.dsListaTnProducidasBindingSource.DataSource = GetType(dsListaTnProducidas)
        '
        'frmRptListatnQuemadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(988, 559)
        Me.Controls.Add(Me.chkDetallado)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptListatnQuemadas"
        Me.Text = "Reporte Tonelaje"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.chkDetallado, 0)
        CType(Me.dsListaTnQuemadasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaTnProducidasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaTnQuemadasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkDetallado As System.Windows.Forms.CheckBox
    Friend WithEvents dsListaTnProducidasBindingSource As System.Windows.Forms.BindingSource

End Class
