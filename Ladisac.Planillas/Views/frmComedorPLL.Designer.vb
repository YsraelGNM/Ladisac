
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmComedorPLL
        Inherits ViewManMasterPlanillas

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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtTotalRegistro = New System.Windows.Forms.TextBox()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtCodigoBusca = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnImportarBase = New System.Windows.Forms.Button()
            Me.btnImprimirComedor = New System.Windows.Forms.Button()
            Me.btnDescuentoComedor = New System.Windows.Forms.Button()
            Me.btnConceptoBuscar = New System.Windows.Forms.Button()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.btnPlantillaExcel = New System.Windows.Forms.Button()
            Me.btnImportar = New System.Windows.Forms.Button()
            Me.btnComedor = New System.Windows.Forms.Button()
            Me.btnResponsable = New System.Windows.Forms.Button()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.txtComedor = New System.Windows.Forms.TextBox()
            Me.txtResponsable = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tdo_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dtd_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ccc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dpr_serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dpr_numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dpr_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_id_cli = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(757, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(753, 386)
            Me.Panel1.TabIndex = 2
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.Label9)
            Me.Panel3.Controls.Add(Me.txtTotalRegistro)
            Me.Panel3.Controls.Add(Me.txtTotal)
            Me.Panel3.Controls.Add(Me.Label8)
            Me.Panel3.Controls.Add(Me.txtCodigoBusca)
            Me.Panel3.Controls.Add(Me.Label6)
            Me.Panel3.Location = New System.Drawing.Point(4, 154)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(745, 24)
            Me.Panel3.TabIndex = 2
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(362, 6)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(66, 13)
            Me.Label9.TabIndex = 5
            Me.Label9.Text = "Nº Registros"
            '
            'txtTotalRegistro
            '
            Me.txtTotalRegistro.Location = New System.Drawing.Point(431, 3)
            Me.txtTotalRegistro.Name = "txtTotalRegistro"
            Me.txtTotalRegistro.ReadOnly = True
            Me.txtTotalRegistro.Size = New System.Drawing.Size(52, 20)
            Me.txtTotalRegistro.TabIndex = 4
            '
            'txtTotal
            '
            Me.txtTotal.Location = New System.Drawing.Point(610, 2)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.ReadOnly = True
            Me.txtTotal.Size = New System.Drawing.Size(100, 20)
            Me.txtTotal.TabIndex = 3
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(522, 4)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(81, 13)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "Total Importado"
            '
            'txtCodigoBusca
            '
            Me.txtCodigoBusca.Location = New System.Drawing.Point(52, 2)
            Me.txtCodigoBusca.Name = "txtCodigoBusca"
            Me.txtCodigoBusca.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoBusca.TabIndex = 1
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(7, 4)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(40, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Codigo"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.Item, Me.per_id, Me.Codigo, Me.Persona, Me.Importe, Me.Observaciones, Me.tdo_id, Me.dtd_id, Me.ccc_id, Me.dpr_serie, Me.dpr_numero, Me.dpr_item, Me.per_id_cli})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 181)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(745, 201)
            Me.dgvDetalle.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnImportarBase)
            Me.Panel2.Controls.Add(Me.btnImprimirComedor)
            Me.Panel2.Controls.Add(Me.btnDescuentoComedor)
            Me.Panel2.Controls.Add(Me.btnConceptoBuscar)
            Me.Panel2.Controls.Add(Me.txtTipoConcepto)
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.txtConcepto)
            Me.Panel2.Controls.Add(Me.btnPlantillaExcel)
            Me.Panel2.Controls.Add(Me.btnImportar)
            Me.Panel2.Controls.Add(Me.btnComedor)
            Me.Panel2.Controls.Add(Me.btnResponsable)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.txtComedor)
            Me.Panel2.Controls.Add(Me.txtResponsable)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(745, 148)
            Me.Panel2.TabIndex = 0
            '
            'btnImportarBase
            '
            Me.btnImportarBase.Location = New System.Drawing.Point(645, 122)
            Me.btnImportarBase.Name = "btnImportarBase"
            Me.btnImportarBase.Size = New System.Drawing.Size(91, 23)
            Me.btnImportarBase.TabIndex = 21
            Me.btnImportarBase.Text = "Importar Base"
            Me.btnImportarBase.UseVisualStyleBackColor = True
            '
            'btnImprimirComedor
            '
            Me.btnImprimirComedor.Location = New System.Drawing.Point(634, 70)
            Me.btnImprimirComedor.Name = "btnImprimirComedor"
            Me.btnImprimirComedor.Size = New System.Drawing.Size(75, 45)
            Me.btnImprimirComedor.TabIndex = 20
            Me.btnImprimirComedor.Text = "Imprimir Comedor"
            Me.btnImprimirComedor.UseVisualStyleBackColor = True
            '
            'btnDescuentoComedor
            '
            Me.btnDescuentoComedor.Location = New System.Drawing.Point(634, 26)
            Me.btnDescuentoComedor.Name = "btnDescuentoComedor"
            Me.btnDescuentoComedor.Size = New System.Drawing.Size(75, 45)
            Me.btnDescuentoComedor.TabIndex = 19
            Me.btnDescuentoComedor.Text = "Descuento Comedor"
            Me.btnDescuentoComedor.UseVisualStyleBackColor = True
            '
            'btnConceptoBuscar
            '
            Me.btnConceptoBuscar.Location = New System.Drawing.Point(430, 120)
            Me.btnConceptoBuscar.Name = "btnConceptoBuscar"
            Me.btnConceptoBuscar.Size = New System.Drawing.Size(24, 23)
            Me.btnConceptoBuscar.TabIndex = 18
            Me.btnConceptoBuscar.Text = ":::"
            Me.btnConceptoBuscar.UseVisualStyleBackColor = True
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(116, 121)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(110, 20)
            Me.txtTipoConcepto.TabIndex = 15
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(59, 124)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(53, 13)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(230, 121)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(197, 20)
            Me.txtConcepto.TabIndex = 17
            '
            'btnPlantillaExcel
            '
            Me.btnPlantillaExcel.Location = New System.Drawing.Point(470, 121)
            Me.btnPlantillaExcel.Name = "btnPlantillaExcel"
            Me.btnPlantillaExcel.Size = New System.Drawing.Size(84, 23)
            Me.btnPlantillaExcel.TabIndex = 13
            Me.btnPlantillaExcel.Text = "Plantilla Excel"
            Me.btnPlantillaExcel.UseVisualStyleBackColor = True
            '
            'btnImportar
            '
            Me.btnImportar.Location = New System.Drawing.Point(555, 121)
            Me.btnImportar.Name = "btnImportar"
            Me.btnImportar.Size = New System.Drawing.Size(84, 23)
            Me.btnImportar.TabIndex = 12
            Me.btnImportar.Text = "Importar Excel"
            Me.btnImportar.UseVisualStyleBackColor = True
            '
            'btnComedor
            '
            Me.btnComedor.Location = New System.Drawing.Point(557, 48)
            Me.btnComedor.Name = "btnComedor"
            Me.btnComedor.Size = New System.Drawing.Size(24, 23)
            Me.btnComedor.TabIndex = 11
            Me.btnComedor.Text = ":::"
            Me.btnComedor.UseVisualStyleBackColor = True
            '
            'btnResponsable
            '
            Me.btnResponsable.Location = New System.Drawing.Point(557, 26)
            Me.btnResponsable.Name = "btnResponsable"
            Me.btnResponsable.Size = New System.Drawing.Size(24, 23)
            Me.btnResponsable.TabIndex = 10
            Me.btnResponsable.Text = ":::"
            Me.btnResponsable.UseVisualStyleBackColor = True
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(116, 72)
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(438, 47)
            Me.txtObservaciones.TabIndex = 9
            '
            'txtComedor
            '
            Me.txtComedor.Location = New System.Drawing.Point(116, 50)
            Me.txtComedor.Name = "txtComedor"
            Me.txtComedor.ReadOnly = True
            Me.txtComedor.Size = New System.Drawing.Size(438, 20)
            Me.txtComedor.TabIndex = 8
            '
            'txtResponsable
            '
            Me.txtResponsable.Location = New System.Drawing.Point(116, 28)
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.ReadOnly = True
            Me.txtResponsable.Size = New System.Drawing.Size(438, 20)
            Me.txtResponsable.TabIndex = 7
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(9, 50)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(103, 13)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Envia la Informacion"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 29)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(109, 13)
            Me.Label4.TabIndex = 5
            Me.Label4.Text = "Recibe la informacion"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(34, 72)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(78, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Observaciones"
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(435, 5)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(89, 20)
            Me.dateFecha.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(399, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Fecha"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(116, 6)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(110, 20)
            Me.txtNumero.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(68, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(44, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Numero"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'OpenFileDialog1
            '
            Me.OpenFileDialog1.FileName = "OpenFileDialog1"
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            Me.Numero.Visible = False
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            Me.Item.Visible = False
            '
            'per_id
            '
            Me.per_id.HeaderText = "per_id"
            Me.per_id.Name = "per_id"
            Me.per_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            '
            'Importe
            '
            Me.Importe.HeaderText = "Importe"
            Me.Importe.Name = "Importe"
            '
            'Observaciones
            '
            Me.Observaciones.HeaderText = "Observaciones"
            Me.Observaciones.Name = "Observaciones"
            '
            'tdo_id
            '
            Me.tdo_id.HeaderText = "tdo_id"
            Me.tdo_id.Name = "tdo_id"
            '
            'dtd_id
            '
            Me.dtd_id.HeaderText = "dtd_id"
            Me.dtd_id.Name = "dtd_id"
            '
            'ccc_id
            '
            Me.ccc_id.HeaderText = "ccc_id"
            Me.ccc_id.Name = "ccc_id"
            '
            'dpr_serie
            '
            Me.dpr_serie.HeaderText = "dpr_serie"
            Me.dpr_serie.Name = "dpr_serie"
            '
            'dpr_numero
            '
            Me.dpr_numero.HeaderText = "dpr_numero"
            Me.dpr_numero.Name = "dpr_numero"
            '
            'dpr_item
            '
            Me.dpr_item.HeaderText = "dpr_item"
            Me.dpr_item.Name = "dpr_item"
            '
            'per_id_cli
            '
            Me.per_id_cli.HeaderText = "per_id_cli"
            Me.per_id_cli.Name = "per_id_cli"
            '
            'frmComedorPLL
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(757, 447)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmComedorPLL"
            Me.Text = " "
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnComedor As System.Windows.Forms.Button
        Friend WithEvents btnResponsable As System.Windows.Forms.Button
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents txtComedor As System.Windows.Forms.TextBox
        Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnImportar As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnPlantillaExcel As System.Windows.Forms.Button
        Friend WithEvents btnConceptoBuscar As System.Windows.Forms.Button
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents txtCodigoBusca As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtTotalRegistro As System.Windows.Forms.TextBox
        Friend WithEvents btnDescuentoComedor As System.Windows.Forms.Button
        Friend WithEvents btnImprimirComedor As System.Windows.Forms.Button
        Friend WithEvents btnImportarBase As System.Windows.Forms.Button
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tdo_id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dtd_id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ccc_id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dpr_serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dpr_numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dpr_item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_id_cli As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace