<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptReciclajeVentaLadrillox12Mes
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
        Me.dsReciclajeVentaLadrillox12MesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numMes = New System.Windows.Forms.NumericUpDown()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dsReciclajeVentaLadrillox12MesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(985, 28)
        Me.lblTitle.Text = "Reciclaje Venta Ladrillo por Meses"
        '
        'dsReciclajeVentaLadrillox12MesBindingSource
        '
        Me.dsReciclajeVentaLadrillox12MesBindingSource.DataMember = "ReciclajeVentaLadrillox12Mes"
        Me.dsReciclajeVentaLadrillox12MesBindingSource.DataSource = GetType(dsReciclajeVentaLadrillox12Mes)
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(215, 72)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 23)
        Me.btnVisualizar.TabIndex = 169
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Del año"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 165
        Me.Label6.Text = "Desde el mes"
        '
        'numMes
        '
        Me.numMes.Location = New System.Drawing.Point(100, 47)
        Me.numMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numMes.Name = "numMes"
        Me.numMes.Size = New System.Drawing.Size(90, 20)
        Me.numMes.TabIndex = 170
        Me.numMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(100, 73)
        Me.numAnio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(90, 20)
        Me.numAnio.TabIndex = 171
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsReciclajeVentaLadrillox12Mes"
        ReportDataSource1.Value = Me.dsReciclajeVentaLadrillox12MesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptReciclajeVentaLadrillox12Mes.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 120)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(958, 419)
        Me.ReportViewer1.TabIndex = 172
        '
        'frmRptReciclajeVentaLadrillox12Mes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(985, 551)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.numAnio)
        Me.Controls.Add(Me.numMes)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRptReciclajeVentaLadrillox12Mes"
        Me.Text = "Reciclaje Venta Ladrillo por Meses"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.numMes, 0)
        Me.Controls.SetChildIndex(Me.numAnio, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        CType(Me.dsReciclajeVentaLadrillox12MesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numMes As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReciclajeVentaLadrillox12MesBindingSource As System.Windows.Forms.BindingSource

End Class
