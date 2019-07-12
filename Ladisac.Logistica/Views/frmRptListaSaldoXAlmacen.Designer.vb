Namespace Ladisac.Logistica.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRptListaSaldoXAlmacen
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
            Me.dsListaSaldoXAlmacenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.btnVisualizar = New System.Windows.Forms.Button()
            Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtAlmacen = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtArticulo = New System.Windows.Forms.TextBox()
            Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
            CType(Me.dsListaSaldoXAlmacenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(719, 28)
            Me.lblTitle.Text = "Reporte Lista Saldo por Almacen"
            '
            'dsListaSaldoXAlmacenBindingSource
            '
            Me.dsListaSaldoXAlmacenBindingSource.DataMember = "ListaSaldoXAlmacen"
            Me.dsListaSaldoXAlmacenBindingSource.DataSource = GetType(dsListaSaldoXAlmacen)
            '
            'btnVisualizar
            '
            Me.btnVisualizar.Location = New System.Drawing.Point(604, 72)
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
            Me.btnVisualizar.TabIndex = 73
            Me.btnVisualizar.Text = "Visualizar"
            Me.btnVisualizar.UseVisualStyleBackColor = True
            '
            'dtpFecIni
            '
            Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecIni.Location = New System.Drawing.Point(496, 73)
            Me.dtpFecIni.Name = "dtpFecIni"
            Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
            Me.dtpFecIni.TabIndex = 70
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(441, 77)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 69
            Me.Label6.Text = "Fecha"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(14, 49)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 13)
            Me.Label2.TabIndex = 68
            Me.Label2.Text = "Almacen"
            '
            'txtAlmacen
            '
            Me.txtAlmacen.Location = New System.Drawing.Point(92, 46)
            Me.txtAlmacen.Name = "txtAlmacen"
            Me.txtAlmacen.Size = New System.Drawing.Size(294, 20)
            Me.txtAlmacen.TabIndex = 67
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 77)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(42, 13)
            Me.Label1.TabIndex = 66
            Me.Label1.Text = "Articulo"
            '
            'txtArticulo
            '
            Me.txtArticulo.Location = New System.Drawing.Point(92, 73)
            Me.txtArticulo.Name = "txtArticulo"
            Me.txtArticulo.Size = New System.Drawing.Size(294, 20)
            Me.txtArticulo.TabIndex = 65
            '
            'ReportViewer1
            '
            Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            ReportDataSource1.Name = "dsListaSaldoXAlmacen"
            ReportDataSource1.Value = Me.dsListaSaldoXAlmacenBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaSaldoXAlmacen.rdlc"
            Me.ReportViewer1.Location = New System.Drawing.Point(19, 111)
            Me.ReportViewer1.Name = "ReportViewer1"
            Me.ReportViewer1.Size = New System.Drawing.Size(688, 396)
            Me.ReportViewer1.TabIndex = 74
            '
            'frmRptListaSaldoXAlmacen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(719, 519)
            Me.Controls.Add(Me.ReportViewer1)
            Me.Controls.Add(Me.btnVisualizar)
            Me.Controls.Add(Me.dtpFecIni)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.txtAlmacen)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtArticulo)
            Me.Name = "frmRptListaSaldoXAlmacen"
            Me.Text = "Reporte Lista Saldo por Almacen"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.txtArticulo, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtAlmacen, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.Label6, 0)
            Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
            Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
            Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
            CType(Me.dsListaSaldoXAlmacenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnVisualizar As System.Windows.Forms.Button
        Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
        Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
        Friend WithEvents dsListaSaldoXAlmacenBindingSource As System.Windows.Forms.BindingSource

    End Class
End Namespace