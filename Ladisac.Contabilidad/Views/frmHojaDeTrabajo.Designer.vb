
Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmHojaDeTrabajo
        Inherits Foundation.Views.ViewMaster
        'Inherits System.Windows.Forms.Form

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgbRegistro = New System.Windows.Forms.DataGridView()
            Me.Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdAnoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Abono = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DeudorAA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AcreedorAA = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Deudor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Acreedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Pasivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PerdidaNat = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.GananciaNat = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PerdidaFun = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.GananciaFun = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnExcel = New System.Windows.Forms.Button()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.cboVerPor = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnLibro = New System.Windows.Forms.Button()
            Me.txtLibro = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboNiveles = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.btnRecibosHonorarios = New System.Windows.Forms.Button()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.Panel1.SuspendLayout()
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(864, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.dgbRegistro)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(853, 395)
            Me.Panel1.TabIndex = 1
            '
            'dgbRegistro
            '
            Me.dgbRegistro.AllowUserToAddRows = False
            Me.dgbRegistro.AllowUserToDeleteRows = False
            Me.dgbRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgbRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgbRegistro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Periodo, Me.Cuenta, Me.Descripcion, Me.IdAnoMes, Me.Mes, Me.Año, Me.Cargo, Me.Abono, Me.DeudorAA, Me.AcreedorAA, Me.Deudor, Me.Acreedor, Me.Activo, Me.Pasivo, Me.PerdidaNat, Me.GananciaNat, Me.PerdidaFun, Me.GananciaFun})
            Me.dgbRegistro.Location = New System.Drawing.Point(4, 47)
            Me.dgbRegistro.Name = "dgbRegistro"
            Me.dgbRegistro.ReadOnly = True
            Me.dgbRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgbRegistro.Size = New System.Drawing.Size(844, 341)
            Me.dgbRegistro.TabIndex = 1
            '
            'Periodo
            '
            Me.Periodo.HeaderText = "Periodo"
            Me.Periodo.Name = "Periodo"
            Me.Periodo.ReadOnly = True
            '
            'Cuenta
            '
            Me.Cuenta.HeaderText = "Cuenta"
            Me.Cuenta.Name = "Cuenta"
            Me.Cuenta.ReadOnly = True
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            '
            'IdAnoMes
            '
            Me.IdAnoMes.HeaderText = "IdAnoMes"
            Me.IdAnoMes.Name = "IdAnoMes"
            Me.IdAnoMes.ReadOnly = True
            '
            'Mes
            '
            Me.Mes.HeaderText = "Mes"
            Me.Mes.Name = "Mes"
            Me.Mes.ReadOnly = True
            '
            'Año
            '
            Me.Año.HeaderText = "Año"
            Me.Año.Name = "Año"
            Me.Año.ReadOnly = True
            '
            'Cargo
            '
            Me.Cargo.HeaderText = "Cargo"
            Me.Cargo.Name = "Cargo"
            Me.Cargo.ReadOnly = True
            '
            'Abono
            '
            Me.Abono.HeaderText = "Abono"
            Me.Abono.Name = "Abono"
            Me.Abono.ReadOnly = True
            '
            'DeudorAA
            '
            Me.DeudorAA.HeaderText = "DeudorAA"
            Me.DeudorAA.Name = "DeudorAA"
            Me.DeudorAA.ReadOnly = True
            '
            'AcreedorAA
            '
            Me.AcreedorAA.HeaderText = "AcreedorAA"
            Me.AcreedorAA.Name = "AcreedorAA"
            Me.AcreedorAA.ReadOnly = True
            '
            'Deudor
            '
            Me.Deudor.HeaderText = "Deudor"
            Me.Deudor.Name = "Deudor"
            Me.Deudor.ReadOnly = True
            '
            'Acreedor
            '
            Me.Acreedor.HeaderText = "Acreedor"
            Me.Acreedor.Name = "Acreedor"
            Me.Acreedor.ReadOnly = True
            '
            'Activo
            '
            Me.Activo.HeaderText = "Activo"
            Me.Activo.Name = "Activo"
            Me.Activo.ReadOnly = True
            '
            'Pasivo
            '
            Me.Pasivo.HeaderText = "Pasivo"
            Me.Pasivo.Name = "Pasivo"
            Me.Pasivo.ReadOnly = True
            '
            'PerdidaNat
            '
            Me.PerdidaNat.HeaderText = "PerdidaNat"
            Me.PerdidaNat.Name = "PerdidaNat"
            Me.PerdidaNat.ReadOnly = True
            '
            'GananciaNat
            '
            Me.GananciaNat.HeaderText = "GananciaNat"
            Me.GananciaNat.Name = "GananciaNat"
            Me.GananciaNat.ReadOnly = True
            '
            'PerdidaFun
            '
            Me.PerdidaFun.HeaderText = "PerdidaFun"
            Me.PerdidaFun.Name = "PerdidaFun"
            Me.PerdidaFun.ReadOnly = True
            '
            'GananciaFun
            '
            Me.GananciaFun.HeaderText = "GananciaFun"
            Me.GananciaFun.Name = "GananciaFun"
            Me.GananciaFun.ReadOnly = True
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.Add(Me.dgvDatos)
            Me.Panel2.Controls.Add(Me.btnRecibosHonorarios)
            Me.Panel2.Controls.Add(Me.btnExcel)
            Me.Panel2.Controls.Add(Me.btnGenerar)
            Me.Panel2.Controls.Add(Me.cboVerPor)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.btnLibro)
            Me.Panel2.Controls.Add(Me.txtLibro)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.cboNiveles)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Location = New System.Drawing.Point(4, 5)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(844, 39)
            Me.Panel2.TabIndex = 0
            '
            'btnExcel
            '
            Me.btnExcel.Location = New System.Drawing.Point(750, 8)
            Me.btnExcel.Name = "btnExcel"
            Me.btnExcel.Size = New System.Drawing.Size(87, 23)
            Me.btnExcel.TabIndex = 11
            Me.btnExcel.Text = "Exportar Excel"
            Me.btnExcel.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(686, 7)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(57, 23)
            Me.btnGenerar.TabIndex = 10
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'cboVerPor
            '
            Me.cboVerPor.FormattingEnabled = True
            Me.cboVerPor.Items.AddRange(New Object() {"Acumulado", "Mensual"})
            Me.cboVerPor.Location = New System.Drawing.Point(359, 11)
            Me.cboVerPor.Name = "cboVerPor"
            Me.cboVerPor.Size = New System.Drawing.Size(86, 21)
            Me.cboVerPor.TabIndex = 9
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(314, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(41, 13)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Ver por"
            '
            'btnLibro
            '
            Me.btnLibro.Location = New System.Drawing.Point(652, 8)
            Me.btnLibro.Name = "btnLibro"
            Me.btnLibro.Size = New System.Drawing.Size(29, 23)
            Me.btnLibro.TabIndex = 7
            Me.btnLibro.Text = ":::"
            Me.btnLibro.UseVisualStyleBackColor = True
            '
            'txtLibro
            '
            Me.txtLibro.Location = New System.Drawing.Point(503, 10)
            Me.txtLibro.Name = "txtLibro"
            Me.txtLibro.ReadOnly = True
            Me.txtLibro.Size = New System.Drawing.Size(145, 20)
            Me.txtLibro.TabIndex = 6
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(471, 15)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(30, 13)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "Libro"
            '
            'cboNiveles
            '
            Me.cboNiveles.FormattingEnabled = True
            Me.cboNiveles.Items.AddRange(New Object() {"Nivel 1  9", "Nivel 2  99", "Nivel 3  999 ", "Nivel 4  9999", "Nivel 5  99999", "Nivel 6  999999", "Nivel 7  9999999", "Nivel 8  99999999", "Nivel 9  999999999", "Nivel 10 9999999999", "Nivel 11 99999999999", "Nivel 12 999999999999", "Nivel 13 9999999999999", "Nivel 14 99999999999999"})
            Me.cboNiveles.Location = New System.Drawing.Point(186, 11)
            Me.cboNiveles.Name = "cboNiveles"
            Me.cboNiveles.Size = New System.Drawing.Size(121, 21)
            Me.cboNiveles.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(153, 14)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(31, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Nivel"
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(104, 10)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 2
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(-1, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Periodo"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(42, 12)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(60, 20)
            Me.txtPeriodo.TabIndex = 0
            '
            'btnRecibosHonorarios
            '
            Me.btnRecibosHonorarios.Location = New System.Drawing.Point(135, 10)
            Me.btnRecibosHonorarios.Name = "btnRecibosHonorarios"
            Me.btnRecibosHonorarios.Size = New System.Drawing.Size(21, 23)
            Me.btnRecibosHonorarios.TabIndex = 12
            Me.btnRecibosHonorarios.Text = "Button1"
            Me.btnRecibosHonorarios.UseVisualStyleBackColor = True
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDatos.ColumnHeadersHeight = 15
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDatos.Enabled = False
            Me.dgvDatos.Location = New System.Drawing.Point(3, 2)
            Me.dgvDatos.MultiSelect = False
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.ReadOnly = True
            Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDatos.Size = New System.Drawing.Size(28, 10)
            Me.dgvDatos.TabIndex = 13
            Me.dgvDatos.Visible = False
            '
            'frmHojaDeTrabajo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(864, 431)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmHojaDeTrabajo"
            Me.Text = "frmHojaDeTrabajo"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgbRegistro As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents cboNiveles As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents btnLibro As System.Windows.Forms.Button
        Friend WithEvents txtLibro As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboVerPor As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Periodo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdAnoMes As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Mes As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Año As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Abono As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DeudorAA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents AcreedorAA As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Deudor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Acreedor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Activo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Pasivo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PerdidaNat As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents GananciaNat As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PerdidaFun As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents GananciaFun As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnExcel As System.Windows.Forms.Button
        Friend WithEvents btnRecibosHonorarios As System.Windows.Forms.Button
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    End Class

End Namespace