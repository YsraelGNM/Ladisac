<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptListasGuiasFacturadas
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DsListaGuiasFacturadasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsListaGuiasFacturadas = New dsListaGuiasFacturadas()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DsListaGuiasFacturadasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsListaGuiasFacturadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(836, 28)
        Me.lblTitle.Text = "Reporte Guias Facturadas"
        '
        'DsListaGuiasFacturadasBindingSource
        '
        Me.DsListaGuiasFacturadasBindingSource.DataSource = Me.DsListaGuiasFacturadas
        Me.DsListaGuiasFacturadasBindingSource.Position = 0
        '
        'DsListaGuiasFacturadas
        '
        Me.DsListaGuiasFacturadas.DataSetName = "dsListaGuiasFacturadas"
        Me.DsListaGuiasFacturadas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaGuiasFacturadas"
        ReportDataSource1.Value = Me.DsListaGuiasFacturadasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaGuiasFacturadas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 114)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(812, 342)
        Me.ReportViewer1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Almacen"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(100, 41)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(290, 20)
        Me.txtAlmacen.TabIndex = 69
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(441, 71)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 23)
        Me.btnVisualizar.TabIndex = 76
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(102, 74)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Fecha Inicio"
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(305, 74)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(215, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Fecha Fin"
        '
        'frmRptListasGuiasFacturadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 468)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptListasGuiasFacturadas"
        Me.Text = "Reporte Guias Facturadas"
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacen, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        CType(Me.DsListaGuiasFacturadasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsListaGuiasFacturadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DsListaGuiasFacturadasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsListaGuiasFacturadas As dsListaGuiasFacturadas
End Class
