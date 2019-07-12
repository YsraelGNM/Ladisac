<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaRendir
    Inherits Ladisac.Foundation.Views.ViewManMaster



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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.TipoCambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New ColumnaCalendario()
        Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodArt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RGA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DevolverInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.Copiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaCalendario1 = New ColumnaCalendario()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDTD_ID_TES = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerieTes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreTes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtImporteTes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAreaTes = New System.Windows.Forms.TextBox()
        Me.dtpFechaRegularizacion = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecFinViaje = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFecIniViaje = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumeroTes = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOT = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mMenu.SuspendLayout()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1000, 28)
        Me.lblTitle.Text = "Cuentas a Rendir"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(622, 71)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(503, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Fecha Emision"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(93, 71)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigo.TabIndex = 96
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoCambio, Me.Fecha, Me.Serie, Me.Numero, Me.Proveedor, Me.CodArt, Me.Articulo, Me.Unid, Me.Cantidad, Me.PrecioUnitario, Me.SubTotal, Me.IGV, Me.Total, Me.Observacion, Me.CRD_ID, Me.RGA_ID})
        Me.dgvDetalle.ContextMenuStrip = Me.mMenu
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 312)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(976, 173)
        Me.dgvDetalle.TabIndex = 100
        '
        'TipoCambio
        '
        Me.TipoCambio.HeaderText = "TipoCambio"
        Me.TipoCambio.Name = "TipoCambio"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Serie
        '
        Me.Serie.HeaderText = "Serie"
        Me.Serie.MaxInputLength = 4
        Me.Serie.Name = "Serie"
        '
        'Numero
        '
        Me.Numero.HeaderText = "Numero"
        Me.Numero.MaxInputLength = 25
        Me.Numero.Name = "Numero"
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        '
        'CodArt
        '
        Me.CodArt.HeaderText = "Cod.Art."
        Me.CodArt.Name = "CodArt"
        Me.CodArt.ReadOnly = True
        '
        'Articulo
        '
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        '
        'Unid
        '
        Me.Unid.HeaderText = "Unidad"
        Me.Unid.Name = "Unid"
        Me.Unid.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "PrecioUnitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        '
        'SubTotal
        '
        Me.SubTotal.HeaderText = "SubTotal"
        Me.SubTotal.Name = "SubTotal"
        '
        'IGV
        '
        Me.IGV.HeaderText = "IGV"
        Me.IGV.Name = "IGV"
        Me.IGV.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle1
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        '
        'CRD_ID
        '
        Me.CRD_ID.HeaderText = "CRD_ID"
        Me.CRD_ID.Name = "CRD_ID"
        Me.CRD_ID.Visible = False
        '
        'RGA_ID
        '
        Me.RGA_ID.HeaderText = "RGA_ID"
        Me.RGA_ID.Name = "RGA_ID"
        Me.RGA_ID.Visible = False
        '
        'mMenu
        '
        Me.mMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevolverInicio, Me.Copiar, Me.Pegar})
        Me.mMenu.Name = "mMenu"
        Me.mMenu.Size = New System.Drawing.Size(175, 70)
        '
        'DevolverInicio
        '
        Me.DevolverInicio.Name = "DevolverInicio"
        Me.DevolverInicio.Size = New System.Drawing.Size(174, 22)
        Me.DevolverInicio.Text = "Devolverlo al Inicio"
        '
        'Copiar
        '
        Me.Copiar.Name = "Copiar"
        Me.Copiar.Size = New System.Drawing.Size(174, 22)
        Me.Copiar.Text = "Copiar"
        '
        'Pegar
        '
        Me.Pegar.Name = "Pegar"
        Me.Pegar.Size = New System.Drawing.Size(174, 22)
        Me.Pegar.Text = "Pegar"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(93, 257)
        Me.txtObservaciones.MaxLength = 255
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(895, 49)
        Me.txtObservaciones.TabIndex = 102
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 261)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 45)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Concepto/ Destino/ Observaciones"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TipoMoneda"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "TipoCambio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ProcesoCompraDet"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 4
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "NumeroDocumento"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 25
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'ColumnaCalendario1
        '
        Me.ColumnaCalendario1.HeaderText = "Fecha"
        Me.ColumnaCalendario1.Name = "ColumnaCalendario1"
        Me.ColumnaCalendario1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaCalendario1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Proveedor"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Articulo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Almacen"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "PrecioUnitario"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "SubTotal"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "IGV"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Tesoreria"
        '
        'txtDTD_ID_TES
        '
        Me.txtDTD_ID_TES.BackColor = System.Drawing.Color.White
        Me.txtDTD_ID_TES.Location = New System.Drawing.Point(93, 100)
        Me.txtDTD_ID_TES.Name = "txtDTD_ID_TES"
        Me.txtDTD_ID_TES.ReadOnly = True
        Me.txtDTD_ID_TES.Size = New System.Drawing.Size(371, 20)
        Me.txtDTD_ID_TES.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Serie/Numero"
        '
        'txtSerieTes
        '
        Me.txtSerieTes.BackColor = System.Drawing.Color.White
        Me.txtSerieTes.Location = New System.Drawing.Point(93, 130)
        Me.txtSerieTes.Name = "txtSerieTes"
        Me.txtSerieTes.ReadOnly = True
        Me.txtSerieTes.Size = New System.Drawing.Size(83, 20)
        Me.txtSerieTes.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Nombre"
        '
        'txtNombreTes
        '
        Me.txtNombreTes.BackColor = System.Drawing.Color.White
        Me.txtNombreTes.Location = New System.Drawing.Point(93, 161)
        Me.txtNombreTes.Name = "txtNombreTes"
        Me.txtNombreTes.ReadOnly = True
        Me.txtNombreTes.Size = New System.Drawing.Size(371, 20)
        Me.txtNombreTes.TabIndex = 107
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Importe"
        '
        'txtImporteTes
        '
        Me.txtImporteTes.BackColor = System.Drawing.Color.White
        Me.txtImporteTes.Location = New System.Drawing.Point(93, 193)
        Me.txtImporteTes.Name = "txtImporteTes"
        Me.txtImporteTes.ReadOnly = True
        Me.txtImporteTes.Size = New System.Drawing.Size(83, 20)
        Me.txtImporteTes.TabIndex = 109
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Area"
        '
        'txtAreaTes
        '
        Me.txtAreaTes.BackColor = System.Drawing.Color.White
        Me.txtAreaTes.Location = New System.Drawing.Point(93, 224)
        Me.txtAreaTes.Name = "txtAreaTes"
        Me.txtAreaTes.ReadOnly = True
        Me.txtAreaTes.Size = New System.Drawing.Size(371, 20)
        Me.txtAreaTes.TabIndex = 111
        '
        'dtpFechaRegularizacion
        '
        Me.dtpFechaRegularizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegularizacion.Location = New System.Drawing.Point(622, 100)
        Me.dtpFechaRegularizacion.Name = "dtpFechaRegularizacion"
        Me.dtpFechaRegularizacion.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaRegularizacion.TabIndex = 114
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(503, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Fecha Regularizacion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFecFinViaje)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFecIniViaje)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(485, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 84)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Solo para Viajes"
        '
        'dtpFecFinViaje
        '
        Me.dtpFecFinViaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFinViaje.Location = New System.Drawing.Point(137, 55)
        Me.dtpFecFinViaje.Name = "dtpFecFinViaje"
        Me.dtpFecFinViaje.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFinViaje.TabIndex = 118
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Fecha Fin Viaje"
        '
        'dtpFecIniViaje
        '
        Me.dtpFecIniViaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIniViaje.Location = New System.Drawing.Point(137, 26)
        Me.dtpFecIniViaje.Name = "dtpFecIniViaje"
        Me.dtpFecIniViaje.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIniViaje.TabIndex = 116
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Fecha Inicio Viaje"
        '
        'txtNumeroTes
        '
        Me.txtNumeroTes.BackColor = System.Drawing.Color.White
        Me.txtNumeroTes.Location = New System.Drawing.Point(182, 130)
        Me.txtNumeroTes.Name = "txtNumeroTes"
        Me.txtNumeroTes.ReadOnly = True
        Me.txtNumeroTes.Size = New System.Drawing.Size(155, 20)
        Me.txtNumeroTes.TabIndex = 116
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(858, 495)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Location = New System.Drawing.Point(903, 491)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(85, 20)
        Me.txtTotal.TabIndex = 117
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(503, 228)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 120
        Me.Label12.Text = "O.T."
        '
        'txtOT
        '
        Me.txtOT.Location = New System.Drawing.Point(622, 224)
        Me.txtOT.Name = "txtOT"
        Me.txtOT.Size = New System.Drawing.Size(85, 20)
        Me.txtOT.TabIndex = 119
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmCuentaRendir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 520)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtOT)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtNumeroTes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpFechaRegularizacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAreaTes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtImporteTes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombreTes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSerieTes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDTD_ID_TES)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Name = "frmCuentaRendir"
        Me.Text = "Cuentas a Rendir"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtObservaciones, 0)
        Me.Controls.SetChildIndex(Me.txtDTD_ID_TES, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtSerieTes, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTes, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtImporteTes, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtAreaTes, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaRegularizacion, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroTes, 0)
        Me.Controls.SetChildIndex(Me.txtTotal, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtOT, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mMenu.ResumeLayout(False)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaCalendario1 As ColumnaCalendario
    Friend WithEvents mMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DevolverInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Copiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pegar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerieTes As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDTD_ID_TES As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaRegularizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAreaTes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtImporteTes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombreTes As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecFinViaje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIniViaje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTes As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOT As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TipoCambio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As ColumnaCalendario
    Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodArt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IGV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CRD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RGA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
