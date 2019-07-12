<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptDistribucionCombustibleProduccion
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsListaDistribucionCombustibleProduccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.rbtFFQ = New System.Windows.Forms.RadioButton()
        Me.rbtFFP = New System.Windows.Forms.RadioButton()
        CType(Me.dsListaDistribucionCombustibleProduccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(926, 28)
        Me.lblTitle.Text = "Distribucion de Combustible"
        '
        'dsListaDistribucionCombustibleProduccionBindingSource
        '
        Me.dsListaDistribucionCombustibleProduccionBindingSource.DataMember = "ListaDistribucionCombustibleProduccion"
        Me.dsListaDistribucionCombustibleProduccionBindingSource.DataSource = GetType(dsListaDistribucionCombustibleProduccion)
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(378, 62)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 23)
        Me.btnVisualizar.TabIndex = 164
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(92, 63)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Fecha Final"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(92, 40)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 161
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 160
        Me.Label6.Text = "Fecha Inicio"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource2.Name = "dsListaDistribucionCombustibleProduccion"
        ReportDataSource2.Value = Me.dsListaDistribucionCombustibleProduccionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptDistribucionCombustibleProduccion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 108)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(899, 404)
        Me.ReportViewer1.TabIndex = 165
        '
        'rbtFFQ
        '
        Me.rbtFFQ.AutoSize = True
        Me.rbtFFQ.Checked = True
        Me.rbtFFQ.Location = New System.Drawing.Point(215, 39)
        Me.rbtFFQ.Name = "rbtFFQ"
        Me.rbtFFQ.Size = New System.Drawing.Size(120, 17)
        Me.rbtFFQ.TabIndex = 166
        Me.rbtFFQ.TabStop = True
        Me.rbtFFQ.Text = "Filtrar Fecha Quema"
        Me.rbtFFQ.UseVisualStyleBackColor = True
        '
        'rbtFFP
        '
        Me.rbtFFP.AutoSize = True
        Me.rbtFFP.Location = New System.Drawing.Point(215, 67)
        Me.rbtFFP.Name = "rbtFFP"
        Me.rbtFFP.Size = New System.Drawing.Size(140, 17)
        Me.rbtFFP.TabIndex = 167
        Me.rbtFFP.TabStop = True
        Me.rbtFFP.Text = "Filtrar Fecha Produccion"
        Me.rbtFFP.UseVisualStyleBackColor = True
        '
        'frmRptDistribucionCombustibleProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(926, 524)
        Me.Controls.Add(Me.rbtFFP)
        Me.Controls.Add(Me.rbtFFQ)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptDistribucionCombustibleProduccion"
        Me.Text = "Distribucion de Combustible"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.rbtFFQ, 0)
        Me.Controls.SetChildIndex(Me.rbtFFP, 0)
        CType(Me.dsListaDistribucionCombustibleProduccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaDistribucionCombustibleProduccionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rbtFFQ As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFFP As System.Windows.Forms.RadioButton

End Class
