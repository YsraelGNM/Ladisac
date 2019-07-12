Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPermisosTrabajador
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FechaInicio = New ColumnaCalendario()
            Me.FechaFin = New ColumnaCalendario()
            Me.Horas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.chkEsRenumeracion = New System.Windows.Forms.CheckBox()
            Me.btnAutoriza = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.txtMotivo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtAutoriza = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(526, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(518, 325)
            Me.Panel1.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.FechaInicio, Me.FechaFin, Me.Horas})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 160)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(509, 160)
            Me.dgvDetalle.TabIndex = 1
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            Me.Item.Visible = False
            '
            'FechaInicio
            '
            Me.FechaInicio.HeaderText = "FechaInicio"
            Me.FechaInicio.Name = "FechaInicio"
            Me.FechaInicio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'FechaFin
            '
            Me.FechaFin.HeaderText = "FechaFin"
            Me.FechaFin.Name = "FechaFin"
            Me.FechaFin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.FechaFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Horas
            '
            Me.Horas.HeaderText = "Horas"
            Me.Horas.Name = "Horas"
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.chkEsRenumeracion)
            Me.Panel2.Controls.Add(Me.btnAutoriza)
            Me.Panel2.Controls.Add(Me.btnTrabajador)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.txtMotivo)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.txtAutoriza)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.txtTrabajador)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 7)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(509, 151)
            Me.Panel2.TabIndex = 0
            '
            'chkEsRenumeracion
            '
            Me.chkEsRenumeracion.AutoSize = True
            Me.chkEsRenumeracion.Location = New System.Drawing.Point(336, 132)
            Me.chkEsRenumeracion.Name = "chkEsRenumeracion"
            Me.chkEsRenumeracion.Size = New System.Drawing.Size(97, 17)
            Me.chkEsRenumeracion.TabIndex = 14
            Me.chkEsRenumeracion.Text = "Es renumerado"
            Me.chkEsRenumeracion.UseVisualStyleBackColor = True
            '
            'btnAutoriza
            '
            Me.btnAutoriza.Location = New System.Drawing.Point(440, 53)
            Me.btnAutoriza.Name = "btnAutoriza"
            Me.btnAutoriza.Size = New System.Drawing.Size(24, 23)
            Me.btnAutoriza.TabIndex = 13
            Me.btnAutoriza.Text = ":::"
            Me.btnAutoriza.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(440, 30)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 12
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(92, 95)
            Me.txtObservaciones.MaxLength = 225
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(342, 34)
            Me.txtObservaciones.TabIndex = 11
            '
            'txtMotivo
            '
            Me.txtMotivo.Location = New System.Drawing.Point(92, 74)
            Me.txtMotivo.MaxLength = 100
            Me.txtMotivo.Name = "txtMotivo"
            Me.txtMotivo.Size = New System.Drawing.Size(342, 20)
            Me.txtMotivo.TabIndex = 10
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(12, 93)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(76, 13)
            Me.Label6.TabIndex = 9
            Me.Label6.Text = "observaciones"
            '
            'txtAutoriza
            '
            Me.txtAutoriza.Location = New System.Drawing.Point(92, 53)
            Me.txtAutoriza.Name = "txtAutoriza"
            Me.txtAutoriza.ReadOnly = True
            Me.txtAutoriza.Size = New System.Drawing.Size(342, 20)
            Me.txtAutoriza.TabIndex = 8
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(49, 77)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(39, 13)
            Me.Label5.TabIndex = 7
            Me.Label5.Text = "Motivo"
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(92, 31)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(342, 20)
            Me.txtTrabajador.TabIndex = 6
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(92, 9)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(91, 20)
            Me.txtNumero.TabIndex = 5
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(344, 9)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(90, 20)
            Me.dateFecha.TabIndex = 4
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(301, 12)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(37, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Fecha"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(43, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(45, 13)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Autoriza"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(30, 34)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(58, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Trabajador"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(44, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(44, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Numero"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Item"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "FechaInicio"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "FechaFin"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Horas"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'frmPermisosTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(526, 386)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPermisosTrabajador"
            Me.Text = "Permisos Trabajador"
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
        Friend WithEvents btnAutoriza As System.Windows.Forms.Button
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtAutoriza As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents chkEsRenumeracion As System.Windows.Forms.CheckBox
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FechaInicio As ColumnaCalendario
        Friend WithEvents FechaFin As ColumnaCalendario
        Friend WithEvents Horas As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class

End Namespace
