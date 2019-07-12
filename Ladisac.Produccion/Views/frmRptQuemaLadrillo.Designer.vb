<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptQuemaLadrillo
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsListaQuemaLadrilloBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboHorno = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsListaVueltasHornoXAnioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsListaQuemaLadrilloBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaVueltasHornoXAnioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(809, 28)
        Me.lblTitle.Text = "Reporte Quema de Ladrillo"
        '
        'dsListaQuemaLadrilloBindingSource
        '
        Me.dsListaQuemaLadrilloBindingSource.DataMember = "ListaQuemaLadrillo"
        Me.dsListaQuemaLadrilloBindingSource.DataSource = GetType(dsListaQuemaLadrillo)
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(315, 78)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 70
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(68, 49)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Fecha"
        '
        'cboHorno
        '
        Me.cboHorno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHorno.FormattingEnabled = True
        Me.cboHorno.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboHorno.Location = New System.Drawing.Point(68, 80)
        Me.cboHorno.Name = "cboHorno"
        Me.cboHorno.Size = New System.Drawing.Size(223, 21)
        Me.cboHorno.TabIndex = 157
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Horno"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource3.Name = "dsListaQuemaLadrillo"
        ReportDataSource3.Value = Me.dsListaQuemaLadrilloBindingSource
        ReportDataSource4.Name = "dsListaVueltasHornoXAnio"
        ReportDataSource4.Value = Me.dsListaVueltasHornoXAnioBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaQuemaLadrillo.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(16, 127)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(781, 246)
        Me.ReportViewer1.TabIndex = 158
        '
        'dsListaVueltasHornoXAnioBindingSource
        '
        Me.dsListaVueltasHornoXAnioBindingSource.DataMember = "ListaVueltasHornoXAnio"
        Me.dsListaVueltasHornoXAnioBindingSource.DataSource = GetType(dsListaVueltasHornoXAnio)
        '
        'frmRptQuemaLadrillo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(809, 408)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cboHorno)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmRptQuemaLadrillo"
        Me.Text = "Reporte Quema de Ladrillo"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.cboHorno, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsListaQuemaLadrilloBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaVueltasHornoXAnioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboHorno As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaQuemaLadrilloBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsListaVueltasHornoXAnioBindingSource As System.Windows.Forms.BindingSource

End Class
