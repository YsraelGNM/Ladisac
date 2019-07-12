<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptConsumoCombustible
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
        Me.dsListaCombustibleHornoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsConsumoR500PorDiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboHorno = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsListaCombustibleXQuemadorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsListaCombustibleHornoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsConsumoR500PorDiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaCombustibleXQuemadorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(827, 28)
        Me.lblTitle.Text = "Reporte Consumo Combustible"
        '
        'dsListaCombustibleHornoBindingSource
        '
        Me.dsListaCombustibleHornoBindingSource.DataMember = "ListaCombustibleHorno"
        Me.dsListaCombustibleHornoBindingSource.DataSource = GetType(dsListaCombustibleHorno)
        '
        'dsConsumoR500PorDiaBindingSource
        '
        Me.dsConsumoR500PorDiaBindingSource.DataMember = "ConsumoR500PorDia"
        Me.dsConsumoR500PorDiaBindingSource.DataSource = GetType(dsConsumoR500PorDia)
        '
        'cboHorno
        '
        Me.cboHorno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHorno.FormattingEnabled = True
        Me.cboHorno.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboHorno.Location = New System.Drawing.Point(71, 76)
        Me.cboHorno.Name = "cboHorno"
        Me.cboHorno.Size = New System.Drawing.Size(223, 21)
        Me.cboHorno.TabIndex = 162
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 161
        Me.Label11.Text = "Horno"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(318, 74)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 160
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(71, 45)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 159
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Fecha"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaCombustibleXQuemador"
        ReportDataSource1.Value = Me.dsListaCombustibleXQuemadorBindingSource
        ReportDataSource2.Name = "dsListaCombustibleHorno"
        ReportDataSource2.Value = Me.dsListaCombustibleHornoBindingSource
        ReportDataSource3.Name = "dsConsumoR500PorDia"
        ReportDataSource3.Value = Me.dsConsumoR500PorDiaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaConsumoCombustible.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(20, 138)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(795, 331)
        Me.ReportViewer1.TabIndex = 163
        '
        'dsListaCombustibleXQuemadorBindingSource
        '
        Me.dsListaCombustibleXQuemadorBindingSource.DataMember = "ListaCombustibleXQuemador"
        Me.dsListaCombustibleXQuemadorBindingSource.DataSource = GetType(dsListaCombustibleXQuemador)
        '
        'frmRptConsumoCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(827, 481)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.cboHorno)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmRptConsumoCombustible"
        Me.Text = "Reporte Consumo Combustible"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.cboHorno, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsListaCombustibleHornoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsConsumoR500PorDiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaCombustibleXQuemadorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboHorno As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaCombustibleXQuemadorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsListaCombustibleHornoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsConsumoR500PorDiaBindingSource As System.Windows.Forms.BindingSource

End Class
