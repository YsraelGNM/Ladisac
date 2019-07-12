<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptReporteFinalProduccion
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsReporteFinalProduccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsReporteFinalProduccionComparativoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ReportViewer5 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ReportViewer4 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExtrusora = New System.Windows.Forms.TextBox()
        Me.dgvTipoProduccion = New System.Windows.Forms.DataGridView()
        Me.TPR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPR_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mostrar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.rbtFinalizadas = New System.Windows.Forms.RadioButton()
        Me.rbtnoFinalizadas = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLadrillo = New System.Windows.Forms.TextBox()
        CType(Me.dsReporteFinalProduccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsReporteFinalProduccionComparativoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvTipoProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1155, 28)
        Me.lblTitle.Text = "Reporte Final"
        '
        'dsReporteFinalProduccionBindingSource
        '
        Me.dsReporteFinalProduccionBindingSource.DataMember = "ReporteFinalProduccion"
        Me.dsReporteFinalProduccionBindingSource.DataSource = GetType(dsReporteFinalProduccion)
        '
        'dsReporteFinalProduccionComparativoBindingSource
        '
        Me.dsReporteFinalProduccionComparativoBindingSource.DataMember = "ReporteFinalProduccionComparativo"
        Me.dsReporteFinalProduccionComparativoBindingSource.DataSource = GetType(dsReporteFinalProduccionComparativo)
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(215, 41)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(165, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(69, 41)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 70
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Desde el"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsReporteFinalProduccion"
        ReportDataSource1.Value = Me.dsReporteFinalProduccionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptReporteFinalProduccion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1109, 345)
        Me.ReportViewer1.TabIndex = 73
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(940, 41)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(99, 38)
        Me.btnVisualizar.TabIndex = 74
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(17, 135)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1123, 377)
        Me.TabControl1.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDetalle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(7, 7)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(1102, 338)
        Me.dgvDetalle.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ReportViewer5)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Imprimir Corto"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ReportViewer5
        '
        Me.ReportViewer5.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "dsReporteFinalProduccion"
        ReportDataSource2.Value = Me.dsReporteFinalProduccionBindingSource
        Me.ReportViewer5.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer5.LocalReport.ReportEmbeddedResource = "rptReporteFinalProduccionCorto.rdlc"
        Me.ReportViewer5.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer5.Name = "ReportViewer5"
        Me.ReportViewer5.Size = New System.Drawing.Size(1115, 351)
        Me.ReportViewer5.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Imprimir Ext."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ReportViewer2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Resumen"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource3.Name = "dsReporteFinalProduccion"
        ReportDataSource3.Value = Me.dsReporteFinalProduccionBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "rptReporteFinalProduccionResumen.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(7, 7)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(1102, 338)
        Me.ReportViewer2.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ReportViewer3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Final"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource4.Name = "dsReporteFinalProduccion"
        ReportDataSource4.Value = Me.dsReporteFinalProduccionBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "rptReporteFinalProduccionDetallado.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(1109, 345)
        Me.ReportViewer3.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.ReportViewer4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1115, 351)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Comparativo"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ReportViewer4
        '
        Me.ReportViewer4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource5.Name = "dsReporteFinalProduccionComparativo"
        ReportDataSource5.Value = Me.dsReporteFinalProduccionComparativoBindingSource
        Me.ReportViewer4.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer4.LocalReport.ReportEmbeddedResource = "rptReporteFinalProduccionComparativo.rdlc"
        Me.ReportViewer4.Location = New System.Drawing.Point(7, 7)
        Me.ReportViewer4.Name = "ReportViewer4"
        Me.ReportViewer4.Size = New System.Drawing.Size(1102, 338)
        Me.ReportViewer4.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(69, 71)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(231, 20)
        Me.txtPlanta.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Extrusora"
        '
        'txtExtrusora
        '
        Me.txtExtrusora.Location = New System.Drawing.Point(414, 71)
        Me.txtExtrusora.Name = "txtExtrusora"
        Me.txtExtrusora.Size = New System.Drawing.Size(261, 20)
        Me.txtExtrusora.TabIndex = 104
        '
        'dgvTipoProduccion
        '
        Me.dgvTipoProduccion.AllowUserToAddRows = False
        Me.dgvTipoProduccion.AllowUserToDeleteRows = False
        Me.dgvTipoProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TPR_ID, Me.TPR_DESCRIPCION, Me.Mostrar})
        Me.dgvTipoProduccion.Location = New System.Drawing.Point(690, 41)
        Me.dgvTipoProduccion.Name = "dgvTipoProduccion"
        Me.dgvTipoProduccion.RowHeadersVisible = False
        Me.dgvTipoProduccion.Size = New System.Drawing.Size(233, 88)
        Me.dgvTipoProduccion.TabIndex = 106
        '
        'TPR_ID
        '
        Me.TPR_ID.HeaderText = "TPR_ID"
        Me.TPR_ID.Name = "TPR_ID"
        Me.TPR_ID.ReadOnly = True
        Me.TPR_ID.Visible = False
        '
        'TPR_DESCRIPCION
        '
        Me.TPR_DESCRIPCION.HeaderText = "Tipo Produccion"
        Me.TPR_DESCRIPCION.Name = "TPR_DESCRIPCION"
        Me.TPR_DESCRIPCION.ReadOnly = True
        Me.TPR_DESCRIPCION.Width = 150
        '
        'Mostrar
        '
        Me.Mostrar.HeaderText = "Mostrar"
        Me.Mostrar.Name = "Mostrar"
        Me.Mostrar.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TPR_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Checked = True
        Me.rbtTodas.Location = New System.Drawing.Point(331, 41)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodas.TabIndex = 107
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'rbtFinalizadas
        '
        Me.rbtFinalizadas.AutoSize = True
        Me.rbtFinalizadas.Location = New System.Drawing.Point(427, 41)
        Me.rbtFinalizadas.Name = "rbtFinalizadas"
        Me.rbtFinalizadas.Size = New System.Drawing.Size(77, 17)
        Me.rbtFinalizadas.TabIndex = 108
        Me.rbtFinalizadas.Text = "Finalizadas"
        Me.rbtFinalizadas.UseVisualStyleBackColor = True
        '
        'rbtnoFinalizadas
        '
        Me.rbtnoFinalizadas.AutoSize = True
        Me.rbtnoFinalizadas.Location = New System.Drawing.Point(523, 41)
        Me.rbtnoFinalizadas.Name = "rbtnoFinalizadas"
        Me.rbtnoFinalizadas.Size = New System.Drawing.Size(94, 17)
        Me.rbtnoFinalizadas.TabIndex = 109
        Me.rbtnoFinalizadas.Text = "No Finalizadas"
        Me.rbtnoFinalizadas.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Ladrillo"
        '
        'txtLadrillo
        '
        Me.txtLadrillo.Location = New System.Drawing.Point(69, 100)
        Me.txtLadrillo.Name = "txtLadrillo"
        Me.txtLadrillo.Size = New System.Drawing.Size(231, 20)
        Me.txtLadrillo.TabIndex = 110
        '
        'frmRptReporteFinalProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1155, 524)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLadrillo)
        Me.Controls.Add(Me.rbtnoFinalizadas)
        Me.Controls.Add(Me.rbtFinalizadas)
        Me.Controls.Add(Me.rbtTodas)
        Me.Controls.Add(Me.dgvTipoProduccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtExtrusora)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlanta)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptReporteFinalProduccion"
        Me.Text = "Reporte Final"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.txtPlanta, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtExtrusora, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgvTipoProduccion, 0)
        Me.Controls.SetChildIndex(Me.rbtTodas, 0)
        Me.Controls.SetChildIndex(Me.rbtFinalizadas, 0)
        Me.Controls.SetChildIndex(Me.rbtnoFinalizadas, 0)
        Me.Controls.SetChildIndex(Me.txtLadrillo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.dsReporteFinalProduccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsReporteFinalProduccionComparativoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvTipoProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteFinalProduccionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtExtrusora As System.Windows.Forms.TextBox
    Friend WithEvents dgvTipoProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPR_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mostrar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer4 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteFinalProduccionComparativoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rbtTodas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFinalizadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnoFinalizadas As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLadrillo As System.Windows.Forms.TextBox
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer5 As Microsoft.Reporting.WinForms.ReportViewer

End Class
