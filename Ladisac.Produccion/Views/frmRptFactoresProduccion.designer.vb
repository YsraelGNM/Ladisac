<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptFactoresProduccion
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
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DsFactoresProduccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFactoresProduccion = New dsFactoresProduccion()
        Me.dsFactoresProduccionSecaderoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsFactoresProduccionResumenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsReporteSalidaVagonXDiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DsFactoresProduccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFactoresProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsFactoresProduccionSecaderoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsFactoresProduccionResumenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dsReporteSalidaVagonXDiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(850, 28)
        Me.lblTitle.Text = "Factores Produccion"
        '
        'DsFactoresProduccionBindingSource
        '
        Me.DsFactoresProduccionBindingSource.DataSource = Me.DsFactoresProduccion
        Me.DsFactoresProduccionBindingSource.Position = 0
        '
        'DsFactoresProduccion
        '
        Me.DsFactoresProduccion.DataSetName = "dsFactoresProduccion"
        Me.DsFactoresProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dsFactoresProduccionSecaderoBindingSource
        '
        Me.dsFactoresProduccionSecaderoBindingSource.DataMember = "FactoresProduccionSecadero"
        Me.dsFactoresProduccionSecaderoBindingSource.DataSource = GetType(dsFactoresProduccionSecadero)
        '
        'dsFactoresProduccionResumenBindingSource
        '
        Me.dsFactoresProduccionResumenBindingSource.DataMember = "FactoresProduccionResumen"
        Me.dsFactoresProduccionResumenBindingSource.DataSource = GetType(dsFactoresProduccionResumen)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource5.Name = "dsFactoresProduccion"
        ReportDataSource5.Value = Me.DsFactoresProduccionBindingSource
        ReportDataSource6.Name = "dsFactoresProduccionSecadero"
        ReportDataSource6.Value = Me.dsFactoresProduccionSecaderoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptFactoresProduccion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(6, 6)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(805, 347)
        Me.ReportViewer1.TabIndex = 0
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(406, 49)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 23)
        Me.btnVisualizar.TabIndex = 79
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(100, 50)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Fecha Inicio"
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(287, 50)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Fecha Final"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 100)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(825, 385)
        Me.TabControl1.TabIndex = 82
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(817, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Diario"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer2)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtPlanta)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(817, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acumulado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource7.Name = "dsFactoresProduccionResumen"
        ReportDataSource7.Value = Me.dsFactoresProduccionResumenBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "rptFactoresProduccionResumen.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(10, 56)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(801, 297)
        Me.ReportViewer2.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(50, 18)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(204, 20)
        Me.txtPlanta.TabIndex = 103
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ReportViewer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(817, 359)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Salida Vagones"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource8.Name = "dsReporteSalidaVagonXDia"
        ReportDataSource8.Value = Me.dsReporteSalidaVagonXDiaBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource8)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "rptReporteSalidaVagonXDia.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(7, 7)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(804, 346)
        Me.ReportViewer3.TabIndex = 0
        '
        'dsReporteSalidaVagonXDiaBindingSource
        '
        Me.dsReporteSalidaVagonXDiaBindingSource.DataMember = "dsReporteSalidaVagonXDia"
        '
        'frmRptFactoresProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptFactoresProduccion"
        Me.Text = "Factores Produccion"
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.DsFactoresProduccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFactoresProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsFactoresProduccionSecaderoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsFactoresProduccionResumenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dsReporteSalidaVagonXDiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DsFactoresProduccionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsFactoresProduccion As dsFactoresProduccion
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dsFactoresProduccionSecaderoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsFactoresProduccionResumenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteSalidaVagonXDiaBindingSource As System.Windows.Forms.BindingSource
End Class
