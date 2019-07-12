Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesXAcumuladosXTrabajador
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
            Me.dgvPLanillas = New System.Windows.Forms.DataGridView()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnAgregarPorRango = New System.Windows.Forms.Button()
            Me.btnPeriodoHasta = New System.Windows.Forms.Button()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtPeriodoHasta = New System.Windows.Forms.TextBox()
            Me.btnPeriodoDesde = New System.Windows.Forms.Button()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtPeriodoDesde = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.btnQuitar = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnAgregar = New System.Windows.Forms.Button()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.btnBoleta = New System.Windows.Forms.Button()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dgvConceptos = New System.Windows.Forms.DataGridView()
            Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.btnReporte = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tic_TipoConcep_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.con_Conceptos_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.dgvPLanillas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(812, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(805, 485)
            Me.Panel1.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Location = New System.Drawing.Point(9, 61)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(790, 421)
            Me.TabControl1.TabIndex = 2
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.dgvPLanillas)
            Me.TabPage1.Controls.Add(Me.Panel4)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(782, 395)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Planillas"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'dgvPLanillas
            '
            Me.dgvPLanillas.AllowUserToAddRows = False
            Me.dgvPLanillas.AllowUserToDeleteRows = False
            Me.dgvPLanillas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPLanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPLanillas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
            Me.dgvPLanillas.Location = New System.Drawing.Point(7, 119)
            Me.dgvPLanillas.Name = "dgvPLanillas"
            Me.dgvPLanillas.ReadOnly = True
            Me.dgvPLanillas.Size = New System.Drawing.Size(762, 267)
            Me.dgvPLanillas.TabIndex = 7
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.GroupBox2)
            Me.Panel4.Controls.Add(Me.GroupBox1)
            Me.Panel4.Location = New System.Drawing.Point(7, 9)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(761, 107)
            Me.Panel4.TabIndex = 6
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.btnAgregarPorRango)
            Me.GroupBox2.Controls.Add(Me.btnPeriodoHasta)
            Me.GroupBox2.Controls.Add(Me.Label19)
            Me.GroupBox2.Controls.Add(Me.txtPeriodoHasta)
            Me.GroupBox2.Controls.Add(Me.btnPeriodoDesde)
            Me.GroupBox2.Controls.Add(Me.Label18)
            Me.GroupBox2.Controls.Add(Me.txtPeriodoDesde)
            Me.GroupBox2.Location = New System.Drawing.Point(4, 51)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(752, 45)
            Me.GroupBox2.TabIndex = 24
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Buscar por Rango de Periodo"
            '
            'btnAgregarPorRango
            '
            Me.btnAgregarPorRango.Location = New System.Drawing.Point(432, 17)
            Me.btnAgregarPorRango.Name = "btnAgregarPorRango"
            Me.btnAgregarPorRango.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregarPorRango.TabIndex = 29
            Me.btnAgregarPorRango.Text = "Agregar"
            Me.btnAgregarPorRango.UseVisualStyleBackColor = True
            '
            'btnPeriodoHasta
            '
            Me.btnPeriodoHasta.Location = New System.Drawing.Point(392, 17)
            Me.btnPeriodoHasta.Name = "btnPeriodoHasta"
            Me.btnPeriodoHasta.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoHasta.TabIndex = 28
            Me.btnPeriodoHasta.Text = ":::"
            Me.btnPeriodoHasta.UseVisualStyleBackColor = True
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(216, 23)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(85, 13)
            Me.Label19.TabIndex = 27
            Me.Label19.Text = "Hasta el Periodo"
            '
            'txtPeriodoHasta
            '
            Me.txtPeriodoHasta.Location = New System.Drawing.Point(304, 19)
            Me.txtPeriodoHasta.Name = "txtPeriodoHasta"
            Me.txtPeriodoHasta.ReadOnly = True
            Me.txtPeriodoHasta.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoHasta.TabIndex = 26
            '
            'btnPeriodoDesde
            '
            Me.btnPeriodoDesde.Location = New System.Drawing.Point(184, 17)
            Me.btnPeriodoDesde.Name = "btnPeriodoDesde"
            Me.btnPeriodoDesde.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoDesde.TabIndex = 25
            Me.btnPeriodoDesde.Text = ":::"
            Me.btnPeriodoDesde.UseVisualStyleBackColor = True
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(3, 22)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(88, 13)
            Me.Label18.TabIndex = 24
            Me.Label18.Text = "Desde el Periodo"
            '
            'txtPeriodoDesde
            '
            Me.txtPeriodoDesde.Location = New System.Drawing.Point(96, 19)
            Me.txtPeriodoDesde.Name = "txtPeriodoDesde"
            Me.txtPeriodoDesde.ReadOnly = True
            Me.txtPeriodoDesde.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoDesde.TabIndex = 23
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.txtNumero)
            Me.GroupBox1.Controls.Add(Me.btnQuitar)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.btnAgregar)
            Me.GroupBox1.Controls.Add(Me.txtSerie)
            Me.GroupBox1.Controls.Add(Me.txtDescripcion)
            Me.GroupBox1.Controls.Add(Me.btnBoleta)
            Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(753, 45)
            Me.GroupBox1.TabIndex = 23
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Buscar por Planilla"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(157, 16)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(132, 20)
            Me.txtNumero.TabIndex = 16
            '
            'btnQuitar
            '
            Me.btnQuitar.Location = New System.Drawing.Point(613, 14)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 22
            Me.btnQuitar.Text = "Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(20, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(76, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Serie /Numero"
            '
            'btnAgregar
            '
            Me.btnAgregar.Location = New System.Drawing.Point(535, 14)
            Me.btnAgregar.Name = "btnAgregar"
            Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregar.TabIndex = 21
            Me.btnAgregar.Text = "Agregar"
            Me.btnAgregar.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(102, 16)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.ReadOnly = True
            Me.txtSerie.Size = New System.Drawing.Size(49, 20)
            Me.txtSerie.TabIndex = 18
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(295, 16)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.ReadOnly = True
            Me.txtDescripcion.Size = New System.Drawing.Size(205, 20)
            Me.txtDescripcion.TabIndex = 20
            '
            'btnBoleta
            '
            Me.btnBoleta.Location = New System.Drawing.Point(506, 14)
            Me.btnBoleta.Name = "btnBoleta"
            Me.btnBoleta.Size = New System.Drawing.Size(22, 23)
            Me.btnBoleta.TabIndex = 19
            Me.btnBoleta.Text = ":::"
            Me.btnBoleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBoleta.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.Panel3)
            Me.TabPage2.Controls.Add(Me.dgvConceptos)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(782, 395)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Conceptos"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.chkSeleccionar)
            Me.Panel3.Controls.Add(Me.Label3)
            Me.Panel3.Location = New System.Drawing.Point(6, 6)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(761, 31)
            Me.Panel3.TabIndex = 1
            '
            'chkSeleccionar
            '
            Me.chkSeleccionar.AutoSize = True
            Me.chkSeleccionar.Location = New System.Drawing.Point(146, 4)
            Me.chkSeleccionar.Name = "chkSeleccionar"
            Me.chkSeleccionar.Size = New System.Drawing.Size(138, 17)
            Me.chkSeleccionar.TabIndex = 2
            Me.chkSeleccionar.Text = "Seleccionar/Desmarcar"
            Me.chkSeleccionar.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(13, 4)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(126, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Conceptos a Seleccionar"
            '
            'dgvConceptos
            '
            Me.dgvConceptos.AllowUserToAddRows = False
            Me.dgvConceptos.AllowUserToDeleteRows = False
            Me.dgvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ok, Me.tic_TipoConcep_Id, Me.con_Conceptos_Id, Me.Orden, Me.Concepto, Me.Descripcion})
            Me.dgvConceptos.Location = New System.Drawing.Point(6, 38)
            Me.dgvConceptos.Name = "dgvConceptos"
            Me.dgvConceptos.Size = New System.Drawing.Size(761, 351)
            Me.dgvConceptos.TabIndex = 1
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
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnExportarExcel)
            Me.Panel2.Controls.Add(Me.btnReporte)
            Me.Panel2.Controls.Add(Me.btnTrabajador)
            Me.Panel2.Controls.Add(Me.txtTrabajador)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Location = New System.Drawing.Point(9, 14)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(787, 43)
            Me.Panel2.TabIndex = 0
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Location = New System.Drawing.Point(585, 10)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(89, 23)
            Me.btnExportarExcel.TabIndex = 10
            Me.btnExportarExcel.Text = "Exportar Excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'btnReporte
            '
            Me.btnReporte.Location = New System.Drawing.Point(514, 9)
            Me.btnReporte.Name = "btnReporte"
            Me.btnReporte.Size = New System.Drawing.Size(65, 23)
            Me.btnReporte.TabIndex = 9
            Me.btnReporte.Text = "Reporte"
            Me.btnReporte.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(447, 6)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(32, 23)
            Me.btnTrabajador.TabIndex = 8
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(110, 7)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(334, 20)
            Me.txtTrabajador.TabIndex = 7
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(49, 10)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Trabajador"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Serie"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Numero"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "tic_TipoConcep_Id"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "con_Conceptos_Id"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "Concepto"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.Width = 110
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.Width = 200
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.Width = 200
            '
            'tic_TipoConcep_Id
            '
            Me.tic_TipoConcep_Id.HeaderText = "tic_TipoConcep_Id"
            Me.tic_TipoConcep_Id.Name = "tic_TipoConcep_Id"
            '
            'con_Conceptos_Id
            '
            Me.con_Conceptos_Id.HeaderText = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Name = "con_Conceptos_Id"
            '
            'Orden
            '
            Me.Orden.HeaderText = "Orden"
            Me.Orden.Name = "Orden"
            '
            'Concepto
            '
            Me.Concepto.HeaderText = "Concepto"
            Me.Concepto.Name = "Concepto"
            Me.Concepto.Width = 110
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.Width = 200
            '
            'Column1
            '
            Me.Column1.HeaderText = "Serie"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            '
            'Column2
            '
            Me.Column2.HeaderText = "Numero"
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            '
            'Column3
            '
            Me.Column3.HeaderText = "Descripcion"
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            Me.Column3.Width = 200
            '
            'frmReportesXAcumuladosXTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(812, 518)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesXAcumuladosXTrabajador"
            Me.Text = "frmReportesXAcumuladosXTrabajador"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.dgvPLanillas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents dgvConceptos As System.Windows.Forms.DataGridView
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnReporte As System.Windows.Forms.Button
        Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents dgvPLanillas As System.Windows.Forms.DataGridView
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnBoleta As System.Windows.Forms.Button
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents btnQuitar As System.Windows.Forms.Button
        Friend WithEvents btnAgregar As System.Windows.Forms.Button
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
        Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents tic_TipoConcep_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents con_Conceptos_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnPeriodoHasta As System.Windows.Forms.Button
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoHasta As System.Windows.Forms.TextBox
        Friend WithEvents btnPeriodoDesde As System.Windows.Forms.Button
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoDesde As System.Windows.Forms.TextBox
        Friend WithEvents btnAgregarPorRango As System.Windows.Forms.Button
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace