<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteBrutoNetoMateriaPrima
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
        Me.dsReporteBrutoNetoMateriaPrimaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLadrillo = New System.Windows.Forms.TextBox()
        Me.rbtnoFinalizadas = New System.Windows.Forms.RadioButton()
        Me.rbtFinalizadas = New System.Windows.Forms.RadioButton()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.dgvTipoProduccion = New System.Windows.Forms.DataGridView()
        Me.TPR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPR_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mostrar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExtrusora = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkBruto = New System.Windows.Forms.CheckBox()
        Me.chkReciclaje = New System.Windows.Forms.CheckBox()
        Me.chkNeto = New System.Windows.Forms.CheckBox()
        Me.chkPorcentaje = New System.Windows.Forms.CheckBox()
        Me.chkCP = New System.Windows.Forms.CheckBox()
        CType(Me.dsReporteBrutoNetoMateriaPrimaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1243, 28)
        Me.lblTitle.Text = "Reporte Bruto Neto Materia Prima"
        '
        'dsReporteBrutoNetoMateriaPrimaBindingSource
        '
        Me.dsReporteBrutoNetoMateriaPrimaBindingSource.DataMember = "ReporteBrutoNetoMateriaPrima"
        Me.dsReporteBrutoNetoMateriaPrimaBindingSource.DataSource = GetType(dsReporteBrutoNetoMateriaPrima)
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsReporteBrutoNetoMateriaPrima"
        ReportDataSource1.Value = Me.dsReporteBrutoNetoMateriaPrimaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptReporteBrutoNetoMateriPrima.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(24, 162)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1207, 368)
        Me.ReportViewer1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Ladrillo"
        '
        'txtLadrillo
        '
        Me.txtLadrillo.Location = New System.Drawing.Point(76, 106)
        Me.txtLadrillo.Name = "txtLadrillo"
        Me.txtLadrillo.Size = New System.Drawing.Size(231, 20)
        Me.txtLadrillo.TabIndex = 125
        '
        'rbtnoFinalizadas
        '
        Me.rbtnoFinalizadas.AutoSize = True
        Me.rbtnoFinalizadas.Location = New System.Drawing.Point(530, 47)
        Me.rbtnoFinalizadas.Name = "rbtnoFinalizadas"
        Me.rbtnoFinalizadas.Size = New System.Drawing.Size(94, 17)
        Me.rbtnoFinalizadas.TabIndex = 124
        Me.rbtnoFinalizadas.Text = "No Finalizadas"
        Me.rbtnoFinalizadas.UseVisualStyleBackColor = True
        '
        'rbtFinalizadas
        '
        Me.rbtFinalizadas.AutoSize = True
        Me.rbtFinalizadas.Location = New System.Drawing.Point(434, 47)
        Me.rbtFinalizadas.Name = "rbtFinalizadas"
        Me.rbtFinalizadas.Size = New System.Drawing.Size(77, 17)
        Me.rbtFinalizadas.TabIndex = 123
        Me.rbtFinalizadas.Text = "Finalizadas"
        Me.rbtFinalizadas.UseVisualStyleBackColor = True
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Checked = True
        Me.rbtTodas.Location = New System.Drawing.Point(338, 47)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodas.TabIndex = 122
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'dgvTipoProduccion
        '
        Me.dgvTipoProduccion.AllowUserToAddRows = False
        Me.dgvTipoProduccion.AllowUserToDeleteRows = False
        Me.dgvTipoProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TPR_ID, Me.TPR_DESCRIPCION, Me.Mostrar})
        Me.dgvTipoProduccion.Location = New System.Drawing.Point(712, 47)
        Me.dgvTipoProduccion.Name = "dgvTipoProduccion"
        Me.dgvTipoProduccion.RowHeadersVisible = False
        Me.dgvTipoProduccion.Size = New System.Drawing.Size(233, 88)
        Me.dgvTipoProduccion.TabIndex = 121
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(335, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Extrusora"
        '
        'txtExtrusora
        '
        Me.txtExtrusora.Location = New System.Drawing.Point(421, 77)
        Me.txtExtrusora.Name = "txtExtrusora"
        Me.txtExtrusora.Size = New System.Drawing.Size(261, 20)
        Me.txtExtrusora.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(76, 77)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(231, 20)
        Me.txtPlanta.TabIndex = 117
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(957, 47)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(99, 38)
        Me.btnVisualizar.TabIndex = 116
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(222, 47)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Hasta el"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(76, 47)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Desde el"
        '
        'chkBruto
        '
        Me.chkBruto.AutoSize = True
        Me.chkBruto.Checked = True
        Me.chkBruto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBruto.Location = New System.Drawing.Point(338, 109)
        Me.chkBruto.Name = "chkBruto"
        Me.chkBruto.Size = New System.Drawing.Size(51, 17)
        Me.chkBruto.TabIndex = 127
        Me.chkBruto.Text = "Bruto"
        Me.chkBruto.UseVisualStyleBackColor = True
        '
        'chkReciclaje
        '
        Me.chkReciclaje.AutoSize = True
        Me.chkReciclaje.Checked = True
        Me.chkReciclaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReciclaje.Location = New System.Drawing.Point(395, 108)
        Me.chkReciclaje.Name = "chkReciclaje"
        Me.chkReciclaje.Size = New System.Drawing.Size(70, 17)
        Me.chkReciclaje.TabIndex = 128
        Me.chkReciclaje.Text = "Reciclaje"
        Me.chkReciclaje.UseVisualStyleBackColor = True
        '
        'chkNeto
        '
        Me.chkNeto.AutoSize = True
        Me.chkNeto.Checked = True
        Me.chkNeto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNeto.Location = New System.Drawing.Point(471, 109)
        Me.chkNeto.Name = "chkNeto"
        Me.chkNeto.Size = New System.Drawing.Size(49, 17)
        Me.chkNeto.TabIndex = 129
        Me.chkNeto.Text = "Neto"
        Me.chkNeto.UseVisualStyleBackColor = True
        '
        'chkPorcentaje
        '
        Me.chkPorcentaje.AutoSize = True
        Me.chkPorcentaje.Checked = True
        Me.chkPorcentaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPorcentaje.Location = New System.Drawing.Point(526, 109)
        Me.chkPorcentaje.Name = "chkPorcentaje"
        Me.chkPorcentaje.Size = New System.Drawing.Size(77, 17)
        Me.chkPorcentaje.TabIndex = 130
        Me.chkPorcentaje.Text = "Porcentaje"
        Me.chkPorcentaje.UseVisualStyleBackColor = True
        '
        'chkCP
        '
        Me.chkCP.AutoSize = True
        Me.chkCP.Location = New System.Drawing.Point(609, 108)
        Me.chkCP.Name = "chkCP"
        Me.chkCP.Size = New System.Drawing.Size(100, 17)
        Me.chkCP.TabIndex = 131
        Me.chkCP.Text = "Costo Promedio"
        Me.chkCP.UseVisualStyleBackColor = True
        '
        'frmReporteBrutoNetoMateriaPrima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1243, 542)
        Me.Controls.Add(Me.chkCP)
        Me.Controls.Add(Me.chkPorcentaje)
        Me.Controls.Add(Me.chkNeto)
        Me.Controls.Add(Me.chkReciclaje)
        Me.Controls.Add(Me.chkBruto)
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
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmReporteBrutoNetoMateriaPrima"
        Me.Text = "Reporte Bruto Neto Materia Prima"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
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
        Me.Controls.SetChildIndex(Me.chkBruto, 0)
        Me.Controls.SetChildIndex(Me.chkReciclaje, 0)
        Me.Controls.SetChildIndex(Me.chkNeto, 0)
        Me.Controls.SetChildIndex(Me.chkPorcentaje, 0)
        Me.Controls.SetChildIndex(Me.chkCP, 0)
        CType(Me.dsReporteBrutoNetoMateriaPrimaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipoProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReporteBrutoNetoMateriaPrimaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLadrillo As System.Windows.Forms.TextBox
    Friend WithEvents rbtnoFinalizadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFinalizadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodas As System.Windows.Forms.RadioButton
    Friend WithEvents dgvTipoProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents TPR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPR_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mostrar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtExtrusora As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkBruto As System.Windows.Forms.CheckBox
    Friend WithEvents chkReciclaje As System.Windows.Forms.CheckBox
    Friend WithEvents chkNeto As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorcentaje As System.Windows.Forms.CheckBox
    Friend WithEvents chkCP As System.Windows.Forms.CheckBox

End Class
