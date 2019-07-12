<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentoGuias
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DGD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUI_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvPasar = New System.Windows.Forms.DataGridView()
        Me.TDO_ID_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTD_ID_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES_SERIE_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES_NUMERO_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUI_ID_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PASAR = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnPasar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numMonto = New System.Windows.Forms.NumericUpDown()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPasar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(627, 28)
        Me.lblTitle.Text = "Documento Guias"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Código"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(90, 96)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(272, 20)
        Me.txtProveedor.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Proveedor"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(90, 66)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 100
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Factura Nro."
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(90, 125)
        Me.txtSerie.MaxLength = 3
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(41, 20)
        Me.txtSerie.TabIndex = 107
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGD_ID, Me.TDO_ID, Me.DTD_ID, Me.DES_SERIE, Me.DES_NUMERO, Me.GUI_ID})
        Me.dgvDetalle.Location = New System.Drawing.Point(368, 186)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(249, 320)
        Me.dgvDetalle.TabIndex = 108
        '
        'DGD_ID
        '
        Me.DGD_ID.HeaderText = "DGD_ID"
        Me.DGD_ID.Name = "DGD_ID"
        Me.DGD_ID.ReadOnly = True
        Me.DGD_ID.Visible = False
        Me.DGD_ID.Width = 73
        '
        'TDO_ID
        '
        Me.TDO_ID.HeaderText = "TDO_ID"
        Me.TDO_ID.Name = "TDO_ID"
        Me.TDO_ID.ReadOnly = True
        Me.TDO_ID.Visible = False
        Me.TDO_ID.Width = 72
        '
        'DTD_ID
        '
        Me.DTD_ID.HeaderText = "DTD_ID"
        Me.DTD_ID.Name = "DTD_ID"
        Me.DTD_ID.ReadOnly = True
        Me.DTD_ID.Visible = False
        Me.DTD_ID.Width = 72
        '
        'DES_SERIE
        '
        Me.DES_SERIE.HeaderText = "SERIE"
        Me.DES_SERIE.Name = "DES_SERIE"
        Me.DES_SERIE.ReadOnly = True
        Me.DES_SERIE.Width = 64
        '
        'DES_NUMERO
        '
        Me.DES_NUMERO.HeaderText = "NUMERO"
        Me.DES_NUMERO.Name = "DES_NUMERO"
        Me.DES_NUMERO.ReadOnly = True
        Me.DES_NUMERO.Width = 120
        '
        'GUI_ID
        '
        Me.GUI_ID.HeaderText = "GUI_ID"
        Me.GUI_ID.Name = "GUI_ID"
        Me.GUI_ID.ReadOnly = True
        Me.GUI_ID.Visible = False
        Me.GUI_ID.Width = 68
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(137, 125)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(90, 20)
        Me.txtNumero.TabIndex = 121
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Fecha desde"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(90, 160)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 123
        '
        'dgvPasar
        '
        Me.dgvPasar.AllowUserToAddRows = False
        Me.dgvPasar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TDO_ID_REF, Me.DTD_ID_REF, Me.DES_SERIE_REF, Me.DES_NUMERO_REF, Me.GUI_ID_REF, Me.PASAR})
        Me.dgvPasar.Location = New System.Drawing.Point(15, 186)
        Me.dgvPasar.Name = "dgvPasar"
        Me.dgvPasar.Size = New System.Drawing.Size(301, 320)
        Me.dgvPasar.TabIndex = 124
        '
        'TDO_ID_REF
        '
        Me.TDO_ID_REF.HeaderText = "TDO_ID"
        Me.TDO_ID_REF.Name = "TDO_ID_REF"
        Me.TDO_ID_REF.Visible = False
        Me.TDO_ID_REF.Width = 72
        '
        'DTD_ID_REF
        '
        Me.DTD_ID_REF.HeaderText = "DTD_ID"
        Me.DTD_ID_REF.Name = "DTD_ID_REF"
        Me.DTD_ID_REF.Visible = False
        Me.DTD_ID_REF.Width = 72
        '
        'DES_SERIE_REF
        '
        Me.DES_SERIE_REF.HeaderText = "SERIE"
        Me.DES_SERIE_REF.Name = "DES_SERIE_REF"
        Me.DES_SERIE_REF.Width = 64
        '
        'DES_NUMERO_REF
        '
        Me.DES_NUMERO_REF.HeaderText = "NUMERO"
        Me.DES_NUMERO_REF.Name = "DES_NUMERO_REF"
        Me.DES_NUMERO_REF.Width = 120
        '
        'GUI_ID_REF
        '
        Me.GUI_ID_REF.HeaderText = "GUI_ID"
        Me.GUI_ID_REF.Name = "GUI_ID_REF"
        Me.GUI_ID_REF.Visible = False
        Me.GUI_ID_REF.Width = 68
        '
        'PASAR
        '
        Me.PASAR.HeaderText = "PASAR"
        Me.PASAR.Name = "PASAR"
        Me.PASAR.Width = 50
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'btnPasar
        '
        Me.btnPasar.Location = New System.Drawing.Point(318, 315)
        Me.btnPasar.Name = "btnPasar"
        Me.btnPasar.Size = New System.Drawing.Size(49, 49)
        Me.btnPasar.TabIndex = 125
        Me.btnPasar.Text = "Pasar >>>"
        Me.btnPasar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(205, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "al"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(229, 160)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaFin.TabIndex = 127
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Monto:"
        '
        'numMonto
        '
        Me.numMonto.DecimalPlaces = 2
        Me.numMonto.Location = New System.Drawing.Point(280, 125)
        Me.numMonto.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numMonto.Name = "numMonto"
        Me.numMonto.Size = New System.Drawing.Size(82, 20)
        Me.numMonto.TabIndex = 129
        Me.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmDocumentoGuias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(627, 518)
        Me.Controls.Add(Me.numMonto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.btnPasar)
        Me.Controls.Add(Me.dgvPasar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Name = "frmDocumentoGuias"
        Me.Text = "Documento Guias"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.txtSerie, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtProveedor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtNumero, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dgvPasar, 0)
        Me.Controls.SetChildIndex(Me.btnPasar, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.numMonto, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPasar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents DGD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES_NUMERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUI_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvPasar As System.Windows.Forms.DataGridView
    Friend WithEvents TDO_ID_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTD_ID_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES_SERIE_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES_NUMERO_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUI_ID_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PASAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnPasar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents numMonto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
