Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmComprobantes
        Inherits Views.ViewManMasterContabilidad

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
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tdo_IdRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dtd_IdRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MontoOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ContraValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_IdRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mon_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.panel5 = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
            Me.txtSerieComprobante = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dateComprobante = New System.Windows.Forms.DateTimePicker()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnMoneda = New System.Windows.Forms.Button()
            Me.txtMoneda = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnPersonas = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel5.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(760, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.panel5)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(751, 300)
            Me.Panel1.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.tdo_IdRef, Me.dtd_IdRef, Me.Documento, Me.Serie, Me.Numero, Me.MontoOriginal, Me.Importe, Me.ContraValor, Me.per_IdRef, Me.mon_Id, Me.Moneda})
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDetalle.Location = New System.Drawing.Point(6, 126)
            Me.dgvDetalle.Name = "dgvDetalle"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
            Me.dgvDetalle.Size = New System.Drawing.Size(740, 168)
            Me.dgvDetalle.TabIndex = 1
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            Me.Item.ReadOnly = True
            Me.Item.Width = 50
            '
            'tdo_IdRef
            '
            Me.tdo_IdRef.HeaderText = "tdo_IdRef"
            Me.tdo_IdRef.Name = "tdo_IdRef"
            Me.tdo_IdRef.Visible = False
            Me.tdo_IdRef.Width = 50
            '
            'dtd_IdRef
            '
            Me.dtd_IdRef.HeaderText = "dtd_IdRef"
            Me.dtd_IdRef.Name = "dtd_IdRef"
            Me.dtd_IdRef.Visible = False
            Me.dtd_IdRef.Width = 50
            '
            'Documento
            '
            Me.Documento.HeaderText = "Documento"
            Me.Documento.Name = "Documento"
            Me.Documento.ReadOnly = True
            '
            'Serie
            '
            Me.Serie.HeaderText = "Serie"
            Me.Serie.Name = "Serie"
            Me.Serie.ReadOnly = True
            Me.Serie.Width = 60
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            '
            'MontoOriginal
            '
            Me.MontoOriginal.HeaderText = "MontoOriginal"
            Me.MontoOriginal.Name = "MontoOriginal"
            '
            'Importe
            '
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.Importe.DefaultCellStyle = DataGridViewCellStyle2
            Me.Importe.HeaderText = "Retener"
            Me.Importe.Name = "Importe"
            '
            'ContraValor
            '
            Me.ContraValor.HeaderText = "ContraValor"
            Me.ContraValor.Name = "ContraValor"
            '
            'per_IdRef
            '
            Me.per_IdRef.HeaderText = "per_IdRef"
            Me.per_IdRef.Name = "per_IdRef"
            Me.per_IdRef.Visible = False
            '
            'mon_Id
            '
            Me.mon_Id.HeaderText = "mon_Id"
            Me.mon_Id.Name = "mon_Id"
            Me.mon_Id.Visible = False
            '
            'Moneda
            '
            Me.Moneda.HeaderText = "Moneda"
            Me.Moneda.Name = "Moneda"
            '
            'panel5
            '
            Me.panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.panel5.Controls.Add(Me.Button1)
            Me.panel5.Controls.Add(Me.txtNumeroComprobante)
            Me.panel5.Controls.Add(Me.txtSerieComprobante)
            Me.panel5.Controls.Add(Me.Label8)
            Me.panel5.Controls.Add(Me.dateComprobante)
            Me.panel5.Controls.Add(Me.Label7)
            Me.panel5.Controls.Add(Me.chkActivo)
            Me.panel5.Controls.Add(Me.txtTotal)
            Me.panel5.Controls.Add(Me.Label6)
            Me.panel5.Controls.Add(Me.btnMoneda)
            Me.panel5.Controls.Add(Me.txtMoneda)
            Me.panel5.Controls.Add(Me.Label5)
            Me.panel5.Controls.Add(Me.txtObservaciones)
            Me.panel5.Controls.Add(Me.Label4)
            Me.panel5.Controls.Add(Me.btnPersonas)
            Me.panel5.Controls.Add(Me.txtPersona)
            Me.panel5.Controls.Add(Me.Label3)
            Me.panel5.Controls.Add(Me.dateFecha)
            Me.panel5.Controls.Add(Me.Label2)
            Me.panel5.Controls.Add(Me.txtNumero)
            Me.panel5.Controls.Add(Me.btnSerie)
            Me.panel5.Controls.Add(Me.txtSerie)
            Me.panel5.Controls.Add(Me.Label1)
            Me.panel5.Location = New System.Drawing.Point(6, 8)
            Me.panel5.Name = "panel5"
            Me.panel5.Size = New System.Drawing.Size(740, 113)
            Me.panel5.TabIndex = 0
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(552, 30)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(62, 23)
            Me.Button1.TabIndex = 22
            Me.Button1.Text = "Imprimir"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'txtNumeroComprobante
            '
            Me.txtNumeroComprobante.Location = New System.Drawing.Point(235, 79)
            Me.txtNumeroComprobante.MaxLength = 10
            Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
            Me.txtNumeroComprobante.Size = New System.Drawing.Size(100, 20)
            Me.txtNumeroComprobante.TabIndex = 21
            '
            'txtSerieComprobante
            '
            Me.txtSerieComprobante.Location = New System.Drawing.Point(162, 79)
            Me.txtSerieComprobante.MaxLength = 4
            Me.txtSerieComprobante.Name = "txtSerieComprobante"
            Me.txtSerieComprobante.Size = New System.Drawing.Size(67, 20)
            Me.txtSerieComprobante.TabIndex = 20
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(3, 82)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(156, 13)
            Me.Label8.TabIndex = 19
            Me.Label8.Text = "Serie/Numero del Comprobante"
            '
            'dateComprobante
            '
            Me.dateComprobante.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateComprobante.Location = New System.Drawing.Point(637, 54)
            Me.dateComprobante.Name = "dateComprobante"
            Me.dateComprobante.Size = New System.Drawing.Size(91, 20)
            Me.dateComprobante.TabIndex = 18
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(532, 58)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(103, 13)
            Me.Label7.TabIndex = 17
            Me.Label7.Text = "Fecha Comprobante"
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(434, 7)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(56, 17)
            Me.chkActivo.TabIndex = 16
            Me.chkActivo.Text = "Activo"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'txtTotal
            '
            Me.txtTotal.Location = New System.Drawing.Point(637, 84)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.ReadOnly = True
            Me.txtTotal.Size = New System.Drawing.Size(91, 20)
            Me.txtTotal.TabIndex = 15
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(606, 86)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(31, 13)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "Total"
            '
            'btnMoneda
            '
            Me.btnMoneda.Location = New System.Drawing.Point(518, 77)
            Me.btnMoneda.Name = "btnMoneda"
            Me.btnMoneda.Size = New System.Drawing.Size(29, 23)
            Me.btnMoneda.TabIndex = 13
            Me.btnMoneda.Text = ":::"
            Me.btnMoneda.UseVisualStyleBackColor = True
            '
            'txtMoneda
            '
            Me.txtMoneda.Location = New System.Drawing.Point(428, 79)
            Me.txtMoneda.Name = "txtMoneda"
            Me.txtMoneda.ReadOnly = True
            Me.txtMoneda.Size = New System.Drawing.Size(83, 20)
            Me.txtMoneda.TabIndex = 12
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(380, 82)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(46, 13)
            Me.Label5.TabIndex = 11
            Me.Label5.Text = "Moneda"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(162, 55)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(349, 20)
            Me.txtObservaciones.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(81, 58)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(78, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Observaciones"
            '
            'btnPersonas
            '
            Me.btnPersonas.Location = New System.Drawing.Point(518, 30)
            Me.btnPersonas.Name = "btnPersonas"
            Me.btnPersonas.Size = New System.Drawing.Size(28, 23)
            Me.btnPersonas.TabIndex = 8
            Me.btnPersonas.Text = ":::"
            Me.btnPersonas.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(162, 31)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(349, 20)
            Me.txtPersona.TabIndex = 7
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(113, 35)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(46, 13)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Persona"
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(637, 6)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(91, 20)
            Me.dateFecha.TabIndex = 5
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(600, 10)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Fecha"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(273, 8)
            Me.txtNumero.MaxLength = 10
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 3
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(236, 6)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(30, 23)
            Me.btnSerie.TabIndex = 2
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(162, 8)
            Me.txtSerie.MaxLength = 3
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(67, 20)
            Me.txtSerie.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(86, 11)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(73, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Serie/Numero"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmComprobantes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(760, 360)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmComprobantes"
            Me.Text = " "
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel5.ResumeLayout(False)
            Me.panel5.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents panel5 As System.Windows.Forms.Panel
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnPersonas As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnMoneda As System.Windows.Forms.Button
        Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents dateComprobante As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tdo_IdRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dtd_IdRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MontoOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ContraValor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_IdRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mon_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
        Friend WithEvents txtSerieComprobante As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class

End Namespace