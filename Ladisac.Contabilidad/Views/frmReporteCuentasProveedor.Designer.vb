Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteCuentasProveedor
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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnQuitarProveedor = New System.Windows.Forms.Button()
            Me.btnBuscarProveedor = New System.Windows.Forms.Button()
            Me.dgvProveedor = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnQuitarCuenta = New System.Windows.Forms.Button()
            Me.btnBuscarCuenta = New System.Windows.Forms.Button()
            Me.dgvCuentas = New System.Windows.Forms.DataGridView()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.chkcuentas = New System.Windows.Forms.CheckBox()
            Me.chkTodosProveedores = New System.Windows.Forms.CheckBox()
            Me.btnCancelar = New System.Windows.Forms.Button()
            Me.brnGenerar = New System.Windows.Forms.Button()
            Me.btnExcel = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(747, 28)
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.btnQuitarProveedor)
            Me.GroupBox1.Controls.Add(Me.btnBuscarProveedor)
            Me.GroupBox1.Controls.Add(Me.dgvProveedor)
            Me.GroupBox1.Location = New System.Drawing.Point(13, 85)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(398, 261)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(14, 9)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(67, 13)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Proveedores"
            '
            'btnQuitarProveedor
            '
            Me.btnQuitarProveedor.Location = New System.Drawing.Point(317, 19)
            Me.btnQuitarProveedor.Name = "btnQuitarProveedor"
            Me.btnQuitarProveedor.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitarProveedor.TabIndex = 2
            Me.btnQuitarProveedor.Text = "Quitar"
            Me.btnQuitarProveedor.UseVisualStyleBackColor = True
            '
            'btnBuscarProveedor
            '
            Me.btnBuscarProveedor.Location = New System.Drawing.Point(236, 19)
            Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
            Me.btnBuscarProveedor.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscarProveedor.TabIndex = 1
            Me.btnBuscarProveedor.Text = "Buscar"
            Me.btnBuscarProveedor.UseVisualStyleBackColor = True
            '
            'dgvProveedor
            '
            Me.dgvProveedor.AllowUserToAddRows = False
            Me.dgvProveedor.AllowUserToDeleteRows = False
            Me.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
            Me.dgvProveedor.Location = New System.Drawing.Point(11, 48)
            Me.dgvProveedor.Name = "dgvProveedor"
            Me.dgvProveedor.ReadOnly = True
            Me.dgvProveedor.Size = New System.Drawing.Size(381, 207)
            Me.dgvProveedor.TabIndex = 0
            '
            'Column1
            '
            Me.Column1.HeaderText = "Codigo"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            Me.Column1.Width = 50
            '
            'Column2
            '
            Me.Column2.HeaderText = "Nombre"
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            Me.Column2.Width = 250
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.btnQuitarCuenta)
            Me.GroupBox2.Controls.Add(Me.btnBuscarCuenta)
            Me.GroupBox2.Controls.Add(Me.dgvCuentas)
            Me.GroupBox2.Location = New System.Drawing.Point(417, 85)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(318, 261)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(7, 10)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(46, 13)
            Me.Label4.TabIndex = 5
            Me.Label4.Text = "Cuentas"
            '
            'btnQuitarCuenta
            '
            Me.btnQuitarCuenta.Location = New System.Drawing.Point(226, 19)
            Me.btnQuitarCuenta.Name = "btnQuitarCuenta"
            Me.btnQuitarCuenta.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitarCuenta.TabIndex = 4
            Me.btnQuitarCuenta.Text = "Quitar"
            Me.btnQuitarCuenta.UseVisualStyleBackColor = True
            '
            'btnBuscarCuenta
            '
            Me.btnBuscarCuenta.Location = New System.Drawing.Point(145, 19)
            Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
            Me.btnBuscarCuenta.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscarCuenta.TabIndex = 3
            Me.btnBuscarCuenta.Text = "Buscar"
            Me.btnBuscarCuenta.UseVisualStyleBackColor = True
            '
            'dgvCuentas
            '
            Me.dgvCuentas.AllowUserToAddRows = False
            Me.dgvCuentas.AllowUserToDeleteRows = False
            Me.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
            Me.dgvCuentas.Location = New System.Drawing.Point(6, 49)
            Me.dgvCuentas.Name = "dgvCuentas"
            Me.dgvCuentas.ReadOnly = True
            Me.dgvCuentas.Size = New System.Drawing.Size(295, 206)
            Me.dgvCuentas.TabIndex = 1
            '
            'Column3
            '
            Me.Column3.HeaderText = "Cuenta"
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            '
            'Column4
            '
            Me.Column4.HeaderText = "Descripcion"
            Me.Column4.Name = "Column4"
            Me.Column4.ReadOnly = True
            Me.Column4.Width = 200
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Desde"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(153, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Hasta"
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(54, 44)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(85, 20)
            Me.dateDesde.TabIndex = 5
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(191, 45)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(85, 20)
            Me.dateHasta.TabIndex = 6
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.chkcuentas)
            Me.GroupBox3.Controls.Add(Me.chkTodosProveedores)
            Me.GroupBox3.Location = New System.Drawing.Point(417, 33)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(318, 47)
            Me.GroupBox3.TabIndex = 7
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Filtros"
            '
            'chkcuentas
            '
            Me.chkcuentas.AutoSize = True
            Me.chkcuentas.Location = New System.Drawing.Point(154, 19)
            Me.chkcuentas.Name = "chkcuentas"
            Me.chkcuentas.Size = New System.Drawing.Size(114, 17)
            Me.chkcuentas.TabIndex = 1
            Me.chkcuentas.Text = "Todas las Cuentas"
            Me.chkcuentas.UseVisualStyleBackColor = True
            '
            'chkTodosProveedores
            '
            Me.chkTodosProveedores.AutoSize = True
            Me.chkTodosProveedores.Location = New System.Drawing.Point(7, 20)
            Me.chkTodosProveedores.Name = "chkTodosProveedores"
            Me.chkTodosProveedores.Size = New System.Drawing.Size(135, 17)
            Me.chkTodosProveedores.TabIndex = 0
            Me.chkTodosProveedores.Text = "Todos los Proveedores"
            Me.chkTodosProveedores.UseVisualStyleBackColor = True
            '
            'btnCancelar
            '
            Me.btnCancelar.Location = New System.Drawing.Point(660, 360)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.btnCancelar.TabIndex = 5
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'brnGenerar
            '
            Me.brnGenerar.Location = New System.Drawing.Point(579, 360)
            Me.brnGenerar.Name = "brnGenerar"
            Me.brnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.brnGenerar.TabIndex = 4
            Me.brnGenerar.Text = "Generar"
            Me.brnGenerar.UseVisualStyleBackColor = True
            '
            'btnExcel
            '
            Me.btnExcel.Location = New System.Drawing.Point(466, 360)
            Me.btnExcel.Name = "btnExcel"
            Me.btnExcel.Size = New System.Drawing.Size(93, 23)
            Me.btnExcel.TabIndex = 8
            Me.btnExcel.Text = "Exportar Excel"
            Me.btnExcel.UseVisualStyleBackColor = True
            '
            'frmReporteCuentasProveedor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(747, 395)
            Me.Controls.Add(Me.btnExcel)
            Me.Controls.Add(Me.btnCancelar)
            Me.Controls.Add(Me.brnGenerar)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.dateHasta)
            Me.Controls.Add(Me.dateDesde)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "frmReporteCuentasProveedor"
            Me.Text = "frmReporteCuentasProveedor"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.GroupBox1, 0)
            Me.Controls.SetChildIndex(Me.GroupBox2, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.dateDesde, 0)
            Me.Controls.SetChildIndex(Me.dateHasta, 0)
            Me.Controls.SetChildIndex(Me.GroupBox3, 0)
            Me.Controls.SetChildIndex(Me.brnGenerar, 0)
            Me.Controls.SetChildIndex(Me.btnCancelar, 0)
            Me.Controls.SetChildIndex(Me.btnExcel, 0)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dgvProveedor As System.Windows.Forms.DataGridView
        Friend WithEvents dgvCuentas As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chkcuentas As System.Windows.Forms.CheckBox
        Friend WithEvents chkTodosProveedores As System.Windows.Forms.CheckBox
        Friend WithEvents btnQuitarProveedor As System.Windows.Forms.Button
        Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
        Friend WithEvents btnQuitarCuenta As System.Windows.Forms.Button
        Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnCancelar As System.Windows.Forms.Button
        Friend WithEvents brnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnExcel As System.Windows.Forms.Button
    End Class

End Namespace
