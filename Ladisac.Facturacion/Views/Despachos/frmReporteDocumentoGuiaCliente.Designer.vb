<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteDocumentoGuiaCliente
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
        Me.dsListaDocumentoGuiaClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.chkDetallado = New System.Windows.Forms.CheckBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.chkTransporte = New System.Windows.Forms.CheckBox()
        Me.rbtFFG = New System.Windows.Forms.RadioButton()
        Me.rbtFFD = New System.Windows.Forms.RadioButton()
        CType(Me.dsListaDocumentoGuiaClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(916, 28)
        Me.lblTitle.Text = "Reporte Guias Remision por Cliente"
        '
        'dsListaDocumentoGuiaClienteBindingSource
        '
        Me.dsListaDocumentoGuiaClienteBindingSource.DataMember = "ListaDocumentoGuiaCliente"
        Me.dsListaDocumentoGuiaClienteBindingSource.DataSource = GetType(dsListaDocumentoGuiaCliente)
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(752, 82)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(101, 23)
        Me.btnCargar.TabIndex = 69
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(272, 83)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaFin.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(82, 83)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaIni.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.Location = New System.Drawing.Point(82, 43)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(283, 20)
        Me.txtCliente.TabIndex = 60
        '
        'chkDetallado
        '
        Me.chkDetallado.AutoSize = True
        Me.chkDetallado.Checked = True
        Me.chkDetallado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetallado.Location = New System.Drawing.Point(407, 45)
        Me.chkDetallado.Name = "chkDetallado"
        Me.chkDetallado.Size = New System.Drawing.Size(101, 17)
        Me.chkDetallado.TabIndex = 68
        Me.chkDetallado.Text = "Detallado Guias"
        Me.chkDetallado.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaDocumentoGuiaCliente"
        ReportDataSource1.Value = Me.dsListaDocumentoGuiaClienteBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaDocumentoGuiaCliente.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(17, 127)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(887, 354)
        Me.ReportViewer1.TabIndex = 70
        '
        'chkTransporte
        '
        Me.chkTransporte.AutoSize = True
        Me.chkTransporte.Location = New System.Drawing.Point(407, 85)
        Me.chkTransporte.Name = "chkTransporte"
        Me.chkTransporte.Size = New System.Drawing.Size(125, 17)
        Me.chkTransporte.TabIndex = 71
        Me.chkTransporte.Text = "Detallado Transporte"
        Me.chkTransporte.UseVisualStyleBackColor = True
        '
        'rbtFFG
        '
        Me.rbtFFG.AutoSize = True
        Me.rbtFFG.Location = New System.Drawing.Point(557, 85)
        Me.rbtFFG.Name = "rbtFFG"
        Me.rbtFFG.Size = New System.Drawing.Size(108, 17)
        Me.rbtFFG.TabIndex = 169
        Me.rbtFFG.TabStop = True
        Me.rbtFFG.Text = "Filtrar Fecha Guia"
        Me.rbtFFG.UseVisualStyleBackColor = True
        '
        'rbtFFD
        '
        Me.rbtFFD.AutoSize = True
        Me.rbtFFD.Checked = True
        Me.rbtFFD.Location = New System.Drawing.Point(557, 45)
        Me.rbtFFD.Name = "rbtFFD"
        Me.rbtFFD.Size = New System.Drawing.Size(141, 17)
        Me.rbtFFD.TabIndex = 168
        Me.rbtFFD.TabStop = True
        Me.rbtFFD.Text = "Filtrar Fecha Documento"
        Me.rbtFFD.UseVisualStyleBackColor = True
        '
        'frmReporteDocumentoGuiaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(916, 493)
        Me.Controls.Add(Me.rbtFFG)
        Me.Controls.Add(Me.rbtFFD)
        Me.Controls.Add(Me.chkTransporte)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.chkDetallado)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCliente)
        Me.Name = "frmReporteDocumentoGuiaCliente"
        Me.Text = "Reporte Guias Remision por Cliente"
        Me.Controls.SetChildIndex(Me.txtCliente, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaIni, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
        Me.Controls.SetChildIndex(Me.chkDetallado, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.chkTransporte, 0)
        Me.Controls.SetChildIndex(Me.rbtFFD, 0)
        Me.Controls.SetChildIndex(Me.rbtFFG, 0)
        CType(Me.dsListaDocumentoGuiaClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents chkDetallado As System.Windows.Forms.CheckBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaDocumentoGuiaClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkTransporte As System.Windows.Forms.CheckBox
    Friend WithEvents rbtFFG As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFFD As System.Windows.Forms.RadioButton

End Class
