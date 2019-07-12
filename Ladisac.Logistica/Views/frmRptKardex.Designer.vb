Namespace Ladisac.Logistica.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRptKardex
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
            Me.dsListaKardexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtAlmacen = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtArticulo = New System.Windows.Forms.TextBox()
            Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnVisualizar = New System.Windows.Forms.Button()
            Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
            CType(Me.dsListaKardexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(716, 28)
            Me.lblTitle.Text = "Reporte Kardex"
            '
            'dsListaKardexBindingSource
            '
            Me.dsListaKardexBindingSource.DataMember = "ListaKardex"
            Me.dsListaKardexBindingSource.DataSource = GetType(dsListaKardex)
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(12, 60)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 13)
            Me.Label2.TabIndex = 21
            Me.Label2.Text = "Almacen"
            '
            'txtAlmacen
            '
            Me.txtAlmacen.Location = New System.Drawing.Point(90, 56)
            Me.txtAlmacen.Name = "txtAlmacen"
            Me.txtAlmacen.Size = New System.Drawing.Size(294, 20)
            Me.txtAlmacen.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 90)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(42, 13)
            Me.Label1.TabIndex = 19
            Me.Label1.Text = "Articulo"
            '
            'txtArticulo
            '
            Me.txtArticulo.Location = New System.Drawing.Point(90, 86)
            Me.txtArticulo.Name = "txtArticulo"
            Me.txtArticulo.Size = New System.Drawing.Size(294, 20)
            Me.txtArticulo.TabIndex = 1
            '
            'dtpFecIni
            '
            Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecIni.Location = New System.Drawing.Point(462, 56)
            Me.dtpFecIni.Name = "dtpFecIni"
            Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
            Me.dtpFecIni.TabIndex = 61
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(407, 60)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(49, 13)
            Me.Label6.TabIndex = 60
            Me.Label6.Text = "Desde el"
            '
            'dtpFecFin
            '
            Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecFin.Location = New System.Drawing.Point(462, 86)
            Me.dtpFecFin.Name = "dtpFecFin"
            Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
            Me.dtpFecFin.TabIndex = 63
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(407, 90)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(46, 13)
            Me.Label3.TabIndex = 62
            Me.Label3.Text = "Hasta el"
            '
            'btnVisualizar
            '
            Me.btnVisualizar.Location = New System.Drawing.Point(578, 85)
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(105, 23)
            Me.btnVisualizar.TabIndex = 64
            Me.btnVisualizar.Text = "Visualizar"
            Me.btnVisualizar.UseVisualStyleBackColor = True
            '
            'ReportViewer1
            '
            Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            ReportDataSource1.Name = "dsListaKardex"
            ReportDataSource1.Value = Me.dsListaKardexBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaKardex.rdlc"
            Me.ReportViewer1.Location = New System.Drawing.Point(15, 125)
            Me.ReportViewer1.Name = "ReportViewer1"
            Me.ReportViewer1.Size = New System.Drawing.Size(685, 272)
            Me.ReportViewer1.TabIndex = 65
            '
            'frmRptKardex
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(716, 408)
            Me.Controls.Add(Me.ReportViewer1)
            Me.Controls.Add(Me.btnVisualizar)
            Me.Controls.Add(Me.dtpFecFin)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.dtpFecIni)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.txtAlmacen)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtArticulo)
            Me.Name = "frmRptKardex"
            Me.Text = "Reporte Kardex"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.txtArticulo, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtAlmacen, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.Label6, 0)
            Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
            Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
            Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
            CType(Me.dsListaKardexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
        Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnVisualizar As System.Windows.Forms.Button
        Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
        Friend WithEvents dsListaKardexBindingSource As System.Windows.Forms.BindingSource

    End Class
End Namespace