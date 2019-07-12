<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenSalida
    Inherits Ladisac.Foundation.Views.ViewManMaster

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
        Me.DsImpresionOrdenDeSalidaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsImpresionOrdenDeSalida = New dsImpresionOrdenDeSalida()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDMO_ID = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.OSD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALM_ID_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OSD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vuelve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Regreso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DsImpresionOrdenDeSalidaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsImpresionOrdenDeSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1021, 28)
        Me.lblTitle.Text = "Orden de Salida"
        '
        'DsImpresionOrdenDeSalidaBindingSource
        '
        Me.DsImpresionOrdenDeSalidaBindingSource.DataSource = Me.DsImpresionOrdenDeSalida
        Me.DsImpresionOrdenDeSalidaBindingSource.Position = 0
        '
        'DsImpresionOrdenDeSalida
        '
        Me.DsImpresionOrdenDeSalida.DataSetName = "dsImpresionOrdenDeSalida"
        Me.DsImpresionOrdenDeSalida.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(362, 23)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(319, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(95, 23)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(95, 49)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(352, 20)
        Me.txtProveedor.TabIndex = 90
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Responsable"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(95, 75)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(352, 20)
        Me.txtResponsable.TabIndex = 96
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OSD_ID, Me.TRD_ID, Me.ENO_ID, Me.ALM_ID_SALIDA, Me.ART_ID, Me.OSD_DESCRIPCION, Me.Cantidad, Me.Observacion, Me.Vuelve, Me.Regreso})
        Me.dgvDetalle.Location = New System.Drawing.Point(20, 127)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(946, 219)
        Me.dgvDetalle.TabIndex = 98
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(997, 378)
        Me.TabControl1.TabIndex = 99
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtDMO_ID)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dgvDetalle)
        Me.TabPage1.Controls.Add(Me.txtProveedor)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtResponsable)
        Me.TabPage1.Controls.Add(Me.txtCodigo)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(989, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "OrdenDeSalida"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Código Tran."
        Me.Label4.Visible = False
        '
        'txtDMO_ID
        '
        Me.txtDMO_ID.BackColor = System.Drawing.SystemColors.Window
        Me.txtDMO_ID.Location = New System.Drawing.Point(95, 101)
        Me.txtDMO_ID.Name = "txtDMO_ID"
        Me.txtDMO_ID.Size = New System.Drawing.Size(90, 20)
        Me.txtDMO_ID.TabIndex = 99
        Me.txtDMO_ID.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(989, 352)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Impresion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsImpresionOrdenDeSalida"
        ReportDataSource1.Value = Me.DsImpresionOrdenDeSalidaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaOrdenDeSalida.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(6, 16)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(965, 330)
        Me.ReportViewer1.TabIndex = 0
        '
        'OSD_ID
        '
        Me.OSD_ID.HeaderText = "OSD_ID"
        Me.OSD_ID.Name = "OSD_ID"
        Me.OSD_ID.Visible = False
        '
        'TRD_ID
        '
        Me.TRD_ID.HeaderText = "TRD_ID"
        Me.TRD_ID.Name = "TRD_ID"
        Me.TRD_ID.Visible = False
        '
        'ENO_ID
        '
        Me.ENO_ID.HeaderText = "Entidad"
        Me.ENO_ID.Name = "ENO_ID"
        Me.ENO_ID.Visible = False
        '
        'ALM_ID_SALIDA
        '
        Me.ALM_ID_SALIDA.HeaderText = "Alm. Salida"
        Me.ALM_ID_SALIDA.Name = "ALM_ID_SALIDA"
        Me.ALM_ID_SALIDA.ReadOnly = True
        '
        'ART_ID
        '
        Me.ART_ID.FillWeight = 200.0!
        Me.ART_ID.HeaderText = "Articulo"
        Me.ART_ID.Name = "ART_ID"
        '
        'OSD_DESCRIPCION
        '
        Me.OSD_DESCRIPCION.HeaderText = "Descripcion"
        Me.OSD_DESCRIPCION.Name = "OSD_DESCRIPCION"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        '
        'Vuelve
        '
        Me.Vuelve.HeaderText = "Vuelve"
        Me.Vuelve.Name = "Vuelve"
        Me.Vuelve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Vuelve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Regreso
        '
        Me.Regreso.HeaderText = "Regreso"
        Me.Regreso.Name = "Regreso"
        Me.Regreso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Regreso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmOrdenSalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1021, 446)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmOrdenSalida"
        Me.Text = "Orden de Salida"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.DsImpresionOrdenDeSalidaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsImpresionOrdenDeSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DsImpresionOrdenDeSalidaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsImpresionOrdenDeSalida As dsImpresionOrdenDeSalida
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDMO_ID As System.Windows.Forms.TextBox
    Friend WithEvents OSD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALM_ID_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vuelve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Regreso As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
