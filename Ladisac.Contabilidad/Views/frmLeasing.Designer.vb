Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLeasing
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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.txtSumaIGV = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtSUmaOtrosGastos = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtSumaInteres = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtSumaCapital = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtSumaActivo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.dgvActivos = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.dgvCuotas = New System.Windows.Forms.DataGridView()
            Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtNumeroContrato = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCentroCosto = New System.Windows.Forms.Button()
            Me.txtcentroCosto = New System.Windows.Forms.TextBox()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.btnMoneda = New System.Windows.Forms.Button()
            Me.txtMoneda = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.dgvActivos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(654, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Panel4)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(645, 414)
            Me.Panel1.TabIndex = 1
            '
            'Panel4
            '
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.txtSumaIGV)
            Me.Panel4.Controls.Add(Me.Label10)
            Me.Panel4.Controls.Add(Me.txtSUmaOtrosGastos)
            Me.Panel4.Controls.Add(Me.Label9)
            Me.Panel4.Controls.Add(Me.txtSumaInteres)
            Me.Panel4.Controls.Add(Me.Label8)
            Me.Panel4.Controls.Add(Me.txtSumaCapital)
            Me.Panel4.Controls.Add(Me.Label7)
            Me.Panel4.Controls.Add(Me.txtSumaActivo)
            Me.Panel4.Controls.Add(Me.Label6)
            Me.Panel4.Location = New System.Drawing.Point(4, 377)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(636, 34)
            Me.Panel4.TabIndex = 2
            '
            'txtSumaIGV
            '
            Me.txtSumaIGV.Location = New System.Drawing.Point(551, 3)
            Me.txtSumaIGV.Name = "txtSumaIGV"
            Me.txtSumaIGV.ReadOnly = True
            Me.txtSumaIGV.Size = New System.Drawing.Size(69, 20)
            Me.txtSumaIGV.TabIndex = 9
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(523, 8)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(22, 13)
            Me.Label10.TabIndex = 8
            Me.Label10.Text = "Igv"
            '
            'txtSUmaOtrosGastos
            '
            Me.txtSUmaOtrosGastos.Location = New System.Drawing.Point(429, 4)
            Me.txtSUmaOtrosGastos.Name = "txtSUmaOtrosGastos"
            Me.txtSUmaOtrosGastos.ReadOnly = True
            Me.txtSUmaOtrosGastos.Size = New System.Drawing.Size(69, 20)
            Me.txtSUmaOtrosGastos.TabIndex = 7
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(366, 9)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(63, 13)
            Me.Label9.TabIndex = 6
            Me.Label9.Text = "Otros Gatos"
            '
            'txtSumaInteres
            '
            Me.txtSumaInteres.Location = New System.Drawing.Point(296, 5)
            Me.txtSumaInteres.Name = "txtSumaInteres"
            Me.txtSumaInteres.ReadOnly = True
            Me.txtSumaInteres.Size = New System.Drawing.Size(69, 20)
            Me.txtSumaInteres.TabIndex = 5
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(251, 10)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(39, 13)
            Me.Label8.TabIndex = 4
            Me.Label8.Text = "Interes"
            '
            'txtSumaCapital
            '
            Me.txtSumaCapital.Location = New System.Drawing.Point(178, 5)
            Me.txtSumaCapital.Name = "txtSumaCapital"
            Me.txtSumaCapital.ReadOnly = True
            Me.txtSumaCapital.Size = New System.Drawing.Size(69, 20)
            Me.txtSumaCapital.TabIndex = 3
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(139, 10)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(39, 13)
            Me.Label7.TabIndex = 2
            Me.Label7.Text = "Capital"
            '
            'txtSumaActivo
            '
            Me.txtSumaActivo.Location = New System.Drawing.Point(65, 6)
            Me.txtSumaActivo.Name = "txtSumaActivo"
            Me.txtSumaActivo.ReadOnly = True
            Me.txtSumaActivo.Size = New System.Drawing.Size(69, 20)
            Me.txtSumaActivo.TabIndex = 1
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(2, 11)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(64, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Valor Activo"
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.TabControl1)
            Me.Panel3.Location = New System.Drawing.Point(4, 136)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(636, 238)
            Me.Panel3.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Location = New System.Drawing.Point(4, 3)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(627, 231)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.dgvActivos)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(619, 205)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Activos"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'dgvActivos
            '
            Me.dgvActivos.AllowUserToAddRows = False
            Me.dgvActivos.AllowUserToDeleteRows = False
            Me.dgvActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvActivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
            Me.dgvActivos.Location = New System.Drawing.Point(7, 7)
            Me.dgvActivos.Name = "dgvActivos"
            Me.dgvActivos.Size = New System.Drawing.Size(606, 192)
            Me.dgvActivos.TabIndex = 0
            '
            'Column1
            '
            Me.Column1.HeaderText = "Item"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            '
            'Column2
            '
            Me.Column2.HeaderText = "Codigo"
            Me.Column2.Name = "Column2"
            '
            'Column3
            '
            Me.Column3.HeaderText = "Descripcion"
            Me.Column3.Name = "Column3"
            '
            'Column4
            '
            Me.Column4.HeaderText = "Valor"
            Me.Column4.Name = "Column4"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.dgvCuotas)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(619, 205)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Cuotas de Financiamiento"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'dgvCuotas
            '
            Me.dgvCuotas.AllowUserToAddRows = False
            Me.dgvCuotas.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvCuotas.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvCuotas.Location = New System.Drawing.Point(7, 7)
            Me.dgvCuotas.Name = "dgvCuotas"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCuotas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvCuotas.Size = New System.Drawing.Size(606, 192)
            Me.dgvCuotas.TabIndex = 0
            '
            'Column5
            '
            Me.Column5.HeaderText = "Item"
            Me.Column5.Name = "Column5"
            Me.Column5.ReadOnly = True
            '
            'Column6
            '
            Me.Column6.HeaderText = "Vencimiento"
            Me.Column6.Name = "Column6"
            '
            'Column7
            '
            Me.Column7.HeaderText = "Capital"
            Me.Column7.Name = "Column7"
            '
            'Column8
            '
            Me.Column8.HeaderText = "Interes"
            Me.Column8.Name = "Column8"
            '
            'Column9
            '
            Me.Column9.HeaderText = "OtrosGastos"
            Me.Column9.Name = "Column9"
            '
            'Column10
            '
            Me.Column10.HeaderText = "Igv"
            Me.Column10.Name = "Column10"
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.txtNumeroContrato)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.btnCentroCosto)
            Me.Panel2.Controls.Add(Me.txtcentroCosto)
            Me.Panel2.Controls.Add(Me.Label29)
            Me.Panel2.Controls.Add(Me.btnMoneda)
            Me.Panel2.Controls.Add(Me.txtMoneda)
            Me.Panel2.Controls.Add(Me.Label18)
            Me.Panel2.Controls.Add(Me.btnPersona)
            Me.Panel2.Controls.Add(Me.txtPersona)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.txtSerie)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(636, 128)
            Me.Panel2.TabIndex = 0
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(109, 100)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(324, 20)
            Me.txtObservaciones.TabIndex = 69
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(27, 103)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(78, 13)
            Me.Label5.TabIndex = 68
            Me.Label5.Text = "Observaciones"
            '
            'txtNumeroContrato
            '
            Me.txtNumeroContrato.Location = New System.Drawing.Point(109, 53)
            Me.txtNumeroContrato.Name = "txtNumeroContrato"
            Me.txtNumeroContrato.Size = New System.Drawing.Size(100, 20)
            Me.txtNumeroContrato.TabIndex = 67
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 57)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(102, 13)
            Me.Label3.TabIndex = 66
            Me.Label3.Text = "Numero de Contrato"
            '
            'btnCentroCosto
            '
            Me.btnCentroCosto.Location = New System.Drawing.Point(407, 74)
            Me.btnCentroCosto.Name = "btnCentroCosto"
            Me.btnCentroCosto.Size = New System.Drawing.Size(24, 23)
            Me.btnCentroCosto.TabIndex = 63
            Me.btnCentroCosto.Text = ":::"
            Me.btnCentroCosto.UseVisualStyleBackColor = True
            '
            'txtcentroCosto
            '
            Me.txtcentroCosto.Location = New System.Drawing.Point(109, 76)
            Me.txtcentroCosto.Name = "txtcentroCosto"
            Me.txtcentroCosto.ReadOnly = True
            Me.txtcentroCosto.Size = New System.Drawing.Size(294, 20)
            Me.txtcentroCosto.TabIndex = 65
            '
            'Label29
            '
            Me.Label29.AutoSize = True
            Me.Label29.Location = New System.Drawing.Point(37, 80)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(68, 13)
            Me.Label29.TabIndex = 64
            Me.Label29.Text = "Centro Costo"
            '
            'btnMoneda
            '
            Me.btnMoneda.Location = New System.Drawing.Point(573, 73)
            Me.btnMoneda.Name = "btnMoneda"
            Me.btnMoneda.Size = New System.Drawing.Size(24, 23)
            Me.btnMoneda.TabIndex = 15
            Me.btnMoneda.Text = ":::"
            Me.btnMoneda.UseVisualStyleBackColor = True
            '
            'txtMoneda
            '
            Me.txtMoneda.Location = New System.Drawing.Point(495, 75)
            Me.txtMoneda.Name = "txtMoneda"
            Me.txtMoneda.ReadOnly = True
            Me.txtMoneda.Size = New System.Drawing.Size(76, 20)
            Me.txtMoneda.TabIndex = 16
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(443, 78)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(46, 13)
            Me.Label18.TabIndex = 14
            Me.Label18.Text = "Moneda"
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(407, 28)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(24, 23)
            Me.btnPersona.TabIndex = 11
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(109, 30)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(294, 20)
            Me.txtPersona.TabIndex = 13
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(59, 33)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(46, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Persona"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(452, 6)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Fecha"
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(495, 6)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(106, 20)
            Me.dateFecha.TabIndex = 4
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(167, 5)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(24, 23)
            Me.Button1.TabIndex = 3
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(197, 7)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 2
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(109, 7)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(57, 20)
            Me.txtSerie.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(74, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(31, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Serie"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmLeasing
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(654, 475)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmLeasing"
            Me.Text = "frmLeasing"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.dgvActivos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnMoneda As System.Windows.Forms.Button
        Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroContrato As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCentroCosto As System.Windows.Forms.Button
        Friend WithEvents txtcentroCosto As System.Windows.Forms.TextBox
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvActivos As System.Windows.Forms.DataGridView
        Friend WithEvents dgvCuotas As System.Windows.Forms.DataGridView
        Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents txtSumaActivo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtSumaIGV As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtSUmaOtrosGastos As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtSumaInteres As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtSumaCapital As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
    End Class

End Namespace