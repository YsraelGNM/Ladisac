<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteGuiaSaleTarde
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
        Me.dsListaGuiaSaleTardeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtPedido = New System.Windows.Forms.RadioButton()
        Me.rbtDocumento = New System.Windows.Forms.RadioButton()
        Me.rbtGuia = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkTraza = New System.Windows.Forms.CheckBox()
        CType(Me.dsListaGuiaSaleTardeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(871, 28)
        Me.lblTitle.Text = "Reporte Fecha Hora Salida de Guias"
        '
        'dsListaGuiaSaleTardeBindingSource
        '
        Me.dsListaGuiaSaleTardeBindingSource.DataMember = "ListaGuiaSaleTarde"
        Me.dsListaGuiaSaleTardeBindingSource.DataSource = GetType(dsListaGuiaSaleTarde)
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(624, 50)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(122, 44)
        Me.btnCargar.TabIndex = 76
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(248, 42)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaFin.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(57, 42)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaIni.TabIndex = 73
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Desde"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaGuiaSaleTarde"
        ReportDataSource1.Value = Me.dsListaGuiaSaleTardeBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaGuiaSaleTarde.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 124)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(844, 383)
        Me.ReportViewer1.TabIndex = 77
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(288, 13)
        Me.txtSerie.MaxLength = 3
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(39, 20)
        Me.txtSerie.TabIndex = 78
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(386, 13)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(93, 20)
        Me.txtNumero.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Serie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(338, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Numero"
        '
        'rbtPedido
        '
        Me.rbtPedido.AutoSize = True
        Me.rbtPedido.Location = New System.Drawing.Point(6, 15)
        Me.rbtPedido.Name = "rbtPedido"
        Me.rbtPedido.Size = New System.Drawing.Size(58, 17)
        Me.rbtPedido.TabIndex = 82
        Me.rbtPedido.TabStop = True
        Me.rbtPedido.Text = "Pedido"
        Me.rbtPedido.UseVisualStyleBackColor = True
        '
        'rbtDocumento
        '
        Me.rbtDocumento.AutoSize = True
        Me.rbtDocumento.Location = New System.Drawing.Point(75, 15)
        Me.rbtDocumento.Name = "rbtDocumento"
        Me.rbtDocumento.Size = New System.Drawing.Size(80, 17)
        Me.rbtDocumento.TabIndex = 83
        Me.rbtDocumento.TabStop = True
        Me.rbtDocumento.Text = "Documento"
        Me.rbtDocumento.UseVisualStyleBackColor = True
        '
        'rbtGuia
        '
        Me.rbtGuia.AutoSize = True
        Me.rbtGuia.Location = New System.Drawing.Point(167, 15)
        Me.rbtGuia.Name = "rbtGuia"
        Me.rbtGuia.Size = New System.Drawing.Size(47, 17)
        Me.rbtGuia.TabIndex = 84
        Me.rbtGuia.TabStop = True
        Me.rbtGuia.Text = "Guia"
        Me.rbtGuia.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbtGuia)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.rbtDocumento)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.rbtPedido)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(111, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 39)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        '
        'chkTraza
        '
        Me.chkTraza.AutoSize = True
        Me.chkTraza.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTraza.Location = New System.Drawing.Point(10, 79)
        Me.chkTraza.Name = "chkTraza"
        Me.chkTraza.Size = New System.Drawing.Size(83, 17)
        Me.chkTraza.TabIndex = 86
        Me.chkTraza.Text = "Trazabilidad"
        Me.chkTraza.UseVisualStyleBackColor = True
        '
        'frmReporteGuiaSaleTarde
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(871, 519)
        Me.Controls.Add(Me.chkTraza)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmReporteGuiaSaleTarde"
        Me.Text = "Reporte Fecha Hora Salida de Guias"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaIni, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.chkTraza, 0)
        CType(Me.dsListaGuiaSaleTardeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaGuiaSaleTardeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtPedido As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGuia As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTraza As System.Windows.Forms.CheckBox

End Class
