<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenDespacho
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.ALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ODD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANT_ORDENADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANT_DESPACHADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDO_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTD_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DDE_SERIE_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DDE_NUMERO_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DDE_ITEM_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ODD_PESO_LADRILLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ODD_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.txtTNDespachado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.txtTara = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(885, 28)
        Me.lblTitle.Text = "Orden de Despacho"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(528, 63)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(485, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Fecha"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(62, 63)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 62
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 67)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(40, 13)
        Me.label4.TabIndex = 61
        Me.label4.Text = "Codigo"
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(62, 92)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(100, 20)
        Me.txtTicket.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Pesaje"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(236, 92)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(206, 20)
        Me.txtPlaca.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Placa"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(528, 92)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(267, 20)
        Me.txtDestino.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(485, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Destino"
        '
        'txtTN
        '
        Me.txtTN.Location = New System.Drawing.Point(236, 123)
        Me.txtTN.Name = "txtTN"
        Me.txtTN.Size = New System.Drawing.Size(49, 20)
        Me.txtTN.TabIndex = 72
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(191, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "TN"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ALM_ID, Me.ODD_ID, Me.CANT_ORDENADA, Me.CANT_DESPACHADA, Me.TDO_ID_DOC, Me.DTD_ID_DOC, Me.DDE_SERIE_DOC, Me.DDE_NUMERO_DOC, Me.DDE_ITEM_DOC, Me.ART_ID, Me.ART_DESCRIPCION, Me.ODD_PESO_LADRILLO, Me.NUMERO_DOCUMENTO, Me.ODD_OBSERVACION, Me.Peso})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 166)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(858, 310)
        Me.dgvDetalle.TabIndex = 73
        '
        'ALM_ID
        '
        Me.ALM_ID.HeaderText = "Almacen"
        Me.ALM_ID.Name = "ALM_ID"
        '
        'ODD_ID
        '
        Me.ODD_ID.HeaderText = "ODD_ID"
        Me.ODD_ID.Name = "ODD_ID"
        Me.ODD_ID.Visible = False
        '
        'CANT_ORDENADA
        '
        Me.CANT_ORDENADA.HeaderText = "Cant.Ordenada"
        Me.CANT_ORDENADA.Name = "CANT_ORDENADA"
        '
        'CANT_DESPACHADA
        '
        Me.CANT_DESPACHADA.HeaderText = "Cant.Despachada"
        Me.CANT_DESPACHADA.Name = "CANT_DESPACHADA"
        '
        'TDO_ID_DOC
        '
        Me.TDO_ID_DOC.HeaderText = "TDO_ID_DOC"
        Me.TDO_ID_DOC.Name = "TDO_ID_DOC"
        Me.TDO_ID_DOC.Visible = False
        '
        'DTD_ID_DOC
        '
        Me.DTD_ID_DOC.HeaderText = "DTD_ID_DOC"
        Me.DTD_ID_DOC.Name = "DTD_ID_DOC"
        Me.DTD_ID_DOC.Visible = False
        '
        'DDE_SERIE_DOC
        '
        Me.DDE_SERIE_DOC.HeaderText = "DDE_SERIE_DOC"
        Me.DDE_SERIE_DOC.Name = "DDE_SERIE_DOC"
        Me.DDE_SERIE_DOC.Visible = False
        '
        'DDE_NUMERO_DOC
        '
        Me.DDE_NUMERO_DOC.HeaderText = "DDE_NUMERO_DOC"
        Me.DDE_NUMERO_DOC.Name = "DDE_NUMERO_DOC"
        Me.DDE_NUMERO_DOC.Visible = False
        '
        'DDE_ITEM_DOC
        '
        Me.DDE_ITEM_DOC.HeaderText = "DDE_ITEM_DOC"
        Me.DDE_ITEM_DOC.Name = "DDE_ITEM_DOC"
        Me.DDE_ITEM_DOC.Visible = False
        '
        'ART_ID
        '
        Me.ART_ID.HeaderText = "ART_ID"
        Me.ART_ID.Name = "ART_ID"
        Me.ART_ID.Visible = False
        '
        'ART_DESCRIPCION
        '
        Me.ART_DESCRIPCION.HeaderText = "Descripcion"
        Me.ART_DESCRIPCION.Name = "ART_DESCRIPCION"
        '
        'ODD_PESO_LADRILLO
        '
        Me.ODD_PESO_LADRILLO.HeaderText = "Peso Ladrillo"
        Me.ODD_PESO_LADRILLO.Name = "ODD_PESO_LADRILLO"
        '
        'NUMERO_DOCUMENTO
        '
        Me.NUMERO_DOCUMENTO.HeaderText = "Nro Doc."
        Me.NUMERO_DOCUMENTO.Name = "NUMERO_DOCUMENTO"
        '
        'ODD_OBSERVACION
        '
        Me.ODD_OBSERVACION.HeaderText = "Observacion"
        Me.ODD_OBSERVACION.Name = "ODD_OBSERVACION"
        '
        'Peso
        '
        Me.Peso.HeaderText = "Peso TN"
        Me.Peso.Name = "Peso"
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ODD_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cant.Ordenada"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cant.Despachada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "TDO_ID_DOC"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "DTD_ID_DOC"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "DDE_SERIE_DOC"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "DDE_NUMERO_DOC"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "DDE_ITEM_DOC"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "ART_ID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Peso Ladrillo"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Nro Doc."
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'txtTNDespachado
        '
        Me.txtTNDespachado.Location = New System.Drawing.Point(385, 123)
        Me.txtTNDespachado.Name = "txtTNDespachado"
        Me.txtTNDespachado.Size = New System.Drawing.Size(57, 20)
        Me.txtTNDespachado.TabIndex = 75
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(301, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "TN Despachado"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'txtTara
        '
        Me.txtTara.Location = New System.Drawing.Point(62, 123)
        Me.txtTara.Name = "txtTara"
        Me.txtTara.Size = New System.Drawing.Size(100, 20)
        Me.txtTara.TabIndex = 77
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "Tara"
        '
        'frmOrdenDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(885, 513)
        Me.Controls.Add(Me.txtTara)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTNDespachado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtTN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDestino)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPlaca)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTicket)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.label4)
        Me.Name = "frmOrdenDespacho"
        Me.Text = "ORDEN DE DESPACHO"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.label4, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtTicket, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtPlaca, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtDestino, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtTN, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtTNDespachado, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtTara, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents txtTicket As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
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
    Friend WithEvents txtTNDespachado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ODD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANT_ORDENADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANT_DESPACHADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDO_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTD_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DDE_SERIE_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DDE_NUMERO_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DDE_ITEM_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ODD_PESO_LADRILLO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ODD_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents txtTara As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
