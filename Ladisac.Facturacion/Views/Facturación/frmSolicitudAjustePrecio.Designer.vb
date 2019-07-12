<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudAjustePrecio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.SSD_MENSAJE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPuntoVenta = New System.Windows.Forms.TextBox()
        Me.txtPuntoVentaDescripcion = New System.Windows.Forms.TextBox()
        Me.APD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIO_NORMAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APD_TIPO_PRECIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APD_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(713, 28)
        Me.lblTitle.Text = "Solicitud Ajuste Precio"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(433, 71)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(97, 20)
        Me.dtpfecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(388, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(89, 136)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(441, 20)
        Me.txtCliente.TabIndex = 29
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.APD_ID, Me.ART_ID, Me.Descripcion, Me.LPR_ID, Me.PRECIO_NORMAL, Me.APD_TIPO_PRECIO, Me.APD_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 166)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(684, 185)
        Me.dgvDetalle.TabIndex = 37
        '
        'SSD_MENSAJE
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SSD_MENSAJE.DefaultCellStyle = DataGridViewCellStyle1
        Me.SSD_MENSAJE.FillWeight = 200.0!
        Me.SSD_MENSAJE.HeaderText = "MENSAJE"
        Me.SSD_MENSAJE.Name = "SSD_MENSAJE"
        Me.SSD_MENSAJE.Width = 260
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MENSAJE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(89, 71)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(73, 20)
        Me.txtCodigo.TabIndex = 130
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Punto Venta"
        '
        'txtPuntoVenta
        '
        Me.txtPuntoVenta.Location = New System.Drawing.Point(89, 104)
        Me.txtPuntoVenta.Name = "txtPuntoVenta"
        Me.txtPuntoVenta.Size = New System.Drawing.Size(73, 20)
        Me.txtPuntoVenta.TabIndex = 132
        '
        'txtPuntoVentaDescripcion
        '
        Me.txtPuntoVentaDescripcion.Location = New System.Drawing.Point(168, 104)
        Me.txtPuntoVentaDescripcion.Name = "txtPuntoVentaDescripcion"
        Me.txtPuntoVentaDescripcion.Size = New System.Drawing.Size(362, 20)
        Me.txtPuntoVentaDescripcion.TabIndex = 134
        '
        'APD_ID
        '
        Me.APD_ID.HeaderText = "APD_ID"
        Me.APD_ID.Name = "APD_ID"
        Me.APD_ID.Visible = False
        '
        'ART_ID
        '
        Me.ART_ID.FillWeight = 50.0!
        Me.ART_ID.HeaderText = "Codigo"
        Me.ART_ID.Name = "ART_ID"
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'LPR_ID
        '
        Me.LPR_ID.FillWeight = 30.0!
        Me.LPR_ID.HeaderText = "LPR_ID"
        Me.LPR_ID.Name = "LPR_ID"
        Me.LPR_ID.ReadOnly = True
        '
        'PRECIO_NORMAL
        '
        Me.PRECIO_NORMAL.FillWeight = 50.0!
        Me.PRECIO_NORMAL.HeaderText = "PRECIO NORMAL"
        Me.PRECIO_NORMAL.Name = "PRECIO_NORMAL"
        Me.PRECIO_NORMAL.ReadOnly = True
        '
        'APD_TIPO_PRECIO
        '
        Me.APD_TIPO_PRECIO.FillWeight = 20.0!
        Me.APD_TIPO_PRECIO.HeaderText = "TIPO"
        Me.APD_TIPO_PRECIO.Name = "APD_TIPO_PRECIO"
        Me.APD_TIPO_PRECIO.ReadOnly = True
        '
        'APD_OBSERVACION
        '
        Me.APD_OBSERVACION.FillWeight = 50.0!
        Me.APD_OBSERVACION.HeaderText = "Observacion"
        Me.APD_OBSERVACION.Name = "APD_OBSERVACION"
        '
        'frmSolicitudAjustePrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(713, 363)
        Me.Controls.Add(Me.txtPuntoVentaDescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPuntoVenta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpfecha)
        Me.Name = "frmSolicitudAjustePrecio"
        Me.Text = "Solicitud Ajuste Precio"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dtpfecha, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCliente, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtPuntoVenta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtPuntoVentaDescripcion, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents SSD_MENSAJE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_ORIGINAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPuntoVentaDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPuntoVenta As System.Windows.Forms.TextBox
    Friend WithEvents APD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LPR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIO_NORMAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APD_TIPO_PRECIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APD_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
