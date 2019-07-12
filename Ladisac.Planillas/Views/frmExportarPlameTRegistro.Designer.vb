Namespace Ladisac.Planillas.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmExportarPlameTRegistro
       Inherits Foundation.Views.ViewMaster

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
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.chkConceptoEspesifico = New System.Windows.Forms.CheckBox()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.btnConceptoBuscar = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.chkDatosJornadaLaboral = New System.Windows.Forms.CheckBox()
            Me.chkIngresosEgresosAportaciones = New System.Windows.Forms.CheckBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.chkDatosTrabajador = New System.Windows.Forms.CheckBox()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.dgvPlanillas = New System.Windows.Forms.DataGridView()
            Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnBuscarPLL = New System.Windows.Forms.Button()
            Me.chkMarcarPlanillas = New System.Windows.Forms.CheckBox()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnCancelar = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TipoPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.dgvPlanillas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(693, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Location = New System.Drawing.Point(3, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(686, 438)
            Me.Panel1.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Location = New System.Drawing.Point(10, 4)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(671, 431)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.chkConceptoEspesifico)
            Me.TabPage1.Controls.Add(Me.GroupBox3)
            Me.TabPage1.Controls.Add(Me.GroupBox2)
            Me.TabPage1.Controls.Add(Me.GroupBox1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(663, 405)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Plame T-Registro"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'chkConceptoEspesifico
            '
            Me.chkConceptoEspesifico.Location = New System.Drawing.Point(15, 172)
            Me.chkConceptoEspesifico.Name = "chkConceptoEspesifico"
            Me.chkConceptoEspesifico.Size = New System.Drawing.Size(471, 19)
            Me.chkConceptoEspesifico.TabIndex = 4
            Me.chkConceptoEspesifico.Text = "Un Concepto en Especifico de (Ingresos,Egresos y Aportaciones)"
            Me.chkConceptoEspesifico.UseVisualStyleBackColor = True
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.btnConceptoBuscar)
            Me.GroupBox3.Controls.Add(Me.Label1)
            Me.GroupBox3.Controls.Add(Me.txtTipoConcepto)
            Me.GroupBox3.Controls.Add(Me.Label2)
            Me.GroupBox3.Controls.Add(Me.txtConcepto)
            Me.GroupBox3.Location = New System.Drawing.Point(15, 208)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(492, 100)
            Me.GroupBox3.TabIndex = 2
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Concepto en Particular para el Plame"
            '
            'btnConceptoBuscar
            '
            Me.btnConceptoBuscar.Location = New System.Drawing.Point(259, 50)
            Me.btnConceptoBuscar.Name = "btnConceptoBuscar"
            Me.btnConceptoBuscar.Size = New System.Drawing.Size(24, 23)
            Me.btnConceptoBuscar.TabIndex = 18
            Me.btnConceptoBuscar.Text = ":::"
            Me.btnConceptoBuscar.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(39, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(28, 13)
            Me.Label1.TabIndex = 14
            Me.Label1.Text = "Tipo"
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(73, 29)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(61, 20)
            Me.txtTipoConcepto.TabIndex = 15
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(14, 54)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(53, 13)
            Me.Label2.TabIndex = 16
            Me.Label2.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(73, 51)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(185, 20)
            Me.txtConcepto.TabIndex = 17
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.chkDatosJornadaLaboral)
            Me.GroupBox2.Controls.Add(Me.chkIngresosEgresosAportaciones)
            Me.GroupBox2.Location = New System.Drawing.Point(268, 11)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(239, 144)
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Datos para el Plame"
            '
            'chkDatosJornadaLaboral
            '
            Me.chkDatosJornadaLaboral.AutoSize = True
            Me.chkDatosJornadaLaboral.Location = New System.Drawing.Point(19, 55)
            Me.chkDatosJornadaLaboral.Name = "chkDatosJornadaLaboral"
            Me.chkDatosJornadaLaboral.Size = New System.Drawing.Size(159, 17)
            Me.chkDatosJornadaLaboral.TabIndex = 2
            Me.chkDatosJornadaLaboral.Text = "Datos de la Jornada Laboral"
            Me.chkDatosJornadaLaboral.UseVisualStyleBackColor = True
            '
            'chkIngresosEgresosAportaciones
            '
            Me.chkIngresosEgresosAportaciones.AutoSize = True
            Me.chkIngresosEgresosAportaciones.Location = New System.Drawing.Point(19, 22)
            Me.chkIngresosEgresosAportaciones.Name = "chkIngresosEgresosAportaciones"
            Me.chkIngresosEgresosAportaciones.Size = New System.Drawing.Size(183, 17)
            Me.chkIngresosEgresosAportaciones.TabIndex = 1
            Me.chkIngresosEgresosAportaciones.Text = "Ingresos ,Egresos y Aportaciones"
            Me.chkIngresosEgresosAportaciones.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.chkDatosTrabajador)
            Me.GroupBox1.Location = New System.Drawing.Point(15, 11)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(237, 144)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Datos para el T-Registro"
            '
            'chkDatosTrabajador
            '
            Me.chkDatosTrabajador.AutoSize = True
            Me.chkDatosTrabajador.Enabled = False
            Me.chkDatosTrabajador.Location = New System.Drawing.Point(17, 21)
            Me.chkDatosTrabajador.Name = "chkDatosTrabajador"
            Me.chkDatosTrabajador.Size = New System.Drawing.Size(125, 17)
            Me.chkDatosTrabajador.TabIndex = 0
            Me.chkDatosTrabajador.Text = "Datos del Trabajador"
            Me.chkDatosTrabajador.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.dgvPlanillas)
            Me.TabPage2.Controls.Add(Me.Panel2)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(663, 405)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Planillas "
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'dgvPlanillas
            '
            Me.dgvPlanillas.AllowUserToAddRows = False
            Me.dgvPlanillas.AllowUserToDeleteRows = False
            Me.dgvPlanillas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPlanillas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ok, Me.Serie, Me.Numero, Me.TipoPlanilla, Me.Descripcion, Me.Inicio, Me.Fin})
            Me.dgvPlanillas.Location = New System.Drawing.Point(7, 51)
            Me.dgvPlanillas.Name = "dgvPlanillas"
            Me.dgvPlanillas.Size = New System.Drawing.Size(651, 348)
            Me.dgvPlanillas.TabIndex = 1
            '
            'ok
            '
            Me.ok.HeaderText = "ok"
            Me.ok.Name = "ok"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.btnBuscarPLL)
            Me.Panel2.Controls.Add(Me.chkMarcarPlanillas)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Location = New System.Drawing.Point(7, 7)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(650, 40)
            Me.Panel2.TabIndex = 0
            '
            'btnBuscarPLL
            '
            Me.btnBuscarPLL.Location = New System.Drawing.Point(211, 9)
            Me.btnBuscarPLL.Name = "btnBuscarPLL"
            Me.btnBuscarPLL.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscarPLL.TabIndex = 21
            Me.btnBuscarPLL.Text = "Buscar"
            Me.btnBuscarPLL.UseVisualStyleBackColor = True
            '
            'chkMarcarPlanillas
            '
            Me.chkMarcarPlanillas.AutoSize = True
            Me.chkMarcarPlanillas.Location = New System.Drawing.Point(303, 13)
            Me.chkMarcarPlanillas.Name = "chkMarcarPlanillas"
            Me.chkMarcarPlanillas.Size = New System.Drawing.Size(59, 17)
            Me.chkMarcarPlanillas.TabIndex = 20
            Me.chkMarcarPlanillas.Text = "Marcar"
            Me.chkMarcarPlanillas.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(179, 8)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodo.TabIndex = 19
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(13, 14)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(76, 13)
            Me.Label10.TabIndex = 18
            Me.Label10.Text = "Periodo Actual"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(91, 10)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodo.TabIndex = 17
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.btnGenerar)
            Me.Panel3.Controls.Add(Me.btnCancelar)
            Me.Panel3.Location = New System.Drawing.Point(3, 477)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(687, 37)
            Me.Panel3.TabIndex = 2
            '
            'btnGenerar
            '
            Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnGenerar.Location = New System.Drawing.Point(474, 6)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 3
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnCancelar
            '
            Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancelar.Location = New System.Drawing.Point(597, 6)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.btnCancelar.TabIndex = 2
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Serie"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Numero"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "TipoPlanilla"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Inicio"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "Fin"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'Serie
            '
            Me.Serie.HeaderText = "Serie"
            Me.Serie.Name = "Serie"
            Me.Serie.ReadOnly = True
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            '
            'TipoPlanilla
            '
            Me.TipoPlanilla.HeaderText = "TipoPlanilla"
            Me.TipoPlanilla.Name = "TipoPlanilla"
            Me.TipoPlanilla.ReadOnly = True
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            '
            'Inicio
            '
            Me.Inicio.HeaderText = "Inicio"
            Me.Inicio.Name = "Inicio"
            Me.Inicio.ReadOnly = True
            '
            'Fin
            '
            Me.Fin.HeaderText = "Fin"
            Me.Fin.Name = "Fin"
            Me.Fin.ReadOnly = True
            '
            'frmExportarPlameTRegistro
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(693, 521)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Panel3)
            Me.Name = "frmExportarPlameTRegistro"
            Me.Text = ""
            Me.Controls.SetChildIndex(Me.Panel3, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.dgvPlanillas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents dgvPlanillas As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnCancelar As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents chkIngresosEgresosAportaciones As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents chkDatosTrabajador As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents btnConceptoBuscar As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents chkConceptoEspesifico As System.Windows.Forms.CheckBox
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents chkMarcarPlanillas As System.Windows.Forms.CheckBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnBuscarPLL As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TipoPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Fin As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents chkDatosJornadaLaboral As System.Windows.Forms.CheckBox
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class

End Namespace
