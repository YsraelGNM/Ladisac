Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReparoTrabajador
        Inherits ViewManMasterPlanillas
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
            Me.components = New System.ComponentModel.Container()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.dret_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dret_AplicaDia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dret_AplicaDoble = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dret_fecha = New ColumnaCalendario()
            Me.dret_HoraProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dret_HoraPll = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dret_Observaciones1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dret_Observaciones2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtCodigoBusca = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(764, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(756, 335)
            Me.Panel1.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dret_Item, Me.per_Id, Me.Codigo, Me.Persona, Me.dret_AplicaDia, Me.dret_AplicaDoble, Me.dret_fecha, Me.dret_HoraProd, Me.dret_HoraPll, Me.dret_Observaciones1, Me.dret_Observaciones2})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 118)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(747, 211)
            Me.dgvDetalle.TabIndex = 1
            '
            'dret_Item
            '
            Me.dret_Item.HeaderText = "dret_Item"
            Me.dret_Item.Name = "dret_Item"
            Me.dret_Item.Visible = False
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Width = 30
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            '
            'dret_AplicaDia
            '
            Me.dret_AplicaDia.HeaderText = "Dia"
            Me.dret_AplicaDia.Name = "dret_AplicaDia"
            Me.dret_AplicaDia.Width = 50
            '
            'dret_AplicaDoble
            '
            Me.dret_AplicaDoble.HeaderText = "Es Doble"
            Me.dret_AplicaDoble.Name = "dret_AplicaDoble"
            Me.dret_AplicaDoble.Width = 70
            '
            'dret_fecha
            '
            Me.dret_fecha.HeaderText = "Fecha"
            Me.dret_fecha.Name = "dret_fecha"
            Me.dret_fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dret_fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dret_HoraProd
            '
            Me.dret_HoraProd.HeaderText = "HoraProd"
            Me.dret_HoraProd.Name = "dret_HoraProd"
            Me.dret_HoraProd.Width = 50
            '
            'dret_HoraPll
            '
            Me.dret_HoraPll.HeaderText = "Hora PLL"
            Me.dret_HoraPll.Name = "dret_HoraPll"
            '
            'dret_Observaciones1
            '
            Me.dret_Observaciones1.HeaderText = "Observaciones1"
            Me.dret_Observaciones1.Name = "dret_Observaciones1"
            '
            'dret_Observaciones2
            '
            Me.dret_Observaciones2.HeaderText = "Observaciones2"
            Me.dret_Observaciones2.Name = "dret_Observaciones2"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.txtCodigoBusca)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.btnTrabajador)
            Me.Panel2.Controls.Add(Me.txtTrabajador)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(744, 108)
            Me.Panel2.TabIndex = 0
            '
            'txtCodigoBusca
            '
            Me.txtCodigoBusca.Location = New System.Drawing.Point(127, 84)
            Me.txtCodigoBusca.Name = "txtCodigoBusca"
            Me.txtCodigoBusca.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoBusca.TabIndex = 10
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(45, 88)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(76, 13)
            Me.Label6.TabIndex = 9
            Me.Label6.Text = "Buscar Codigo"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(404, 12)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(37, 13)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Fecha"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(127, 55)
            Me.txtObservaciones.MaxLength = 100
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(403, 20)
            Me.txtObservaciones.TabIndex = 7
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(43, 58)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(78, 13)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Observaciones"
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(506, 31)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 5
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(127, 33)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(373, 20)
            Me.txtTrabajador.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(9, 36)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(112, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Responsable/Autoriza"
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(447, 8)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(83, 20)
            Me.dateFecha.TabIndex = 2
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(127, 11)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(77, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(44, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Numero"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmReparoTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(764, 397)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReparoTrabajador"
            Me.Text = "frmReparoTrabajador"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents dret_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dret_AplicaDia As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents dret_AplicaDoble As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents dret_fecha As ColumnaCalendario
        Friend WithEvents dret_HoraProd As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dret_HoraPll As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dret_Observaciones1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dret_Observaciones2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents txtCodigoBusca As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
    End Class

End Namespace