
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGrupoMantenimiento
        'Inherits System.Windows.Forms.Form
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.grm_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OTR_ID = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Entidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.grm_HoraDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.grm_HoraHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.grm_HoraTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.grm_observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ClonarFilaSeleccionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnResponsable = New System.Windows.Forms.Button()
            Me.txtResponsable = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(854, 28)
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
            Me.Panel1.Size = New System.Drawing.Size(846, 333)
            Me.Panel1.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.grm_Item, Me.OTR_ID, Me.Orden, Me.Entidad, Me.per_id, Me.Nombre, Me.grm_HoraDesde, Me.grm_HoraHasta, Me.grm_HoraTotal, Me.Descripcion, Me.grm_observaciones})
            Me.dgvDetalle.ContextMenuStrip = Me.ContextMenuStrip1
            Me.dgvDetalle.Location = New System.Drawing.Point(5, 94)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(836, 234)
            Me.dgvDetalle.TabIndex = 1
            '
            'grm_Item
            '
            Me.grm_Item.HeaderText = "Item"
            Me.grm_Item.Name = "grm_Item"
            Me.grm_Item.ReadOnly = True
            '
            'OTR_ID
            '
            Me.OTR_ID.HeaderText = "OTR_ID"
            Me.OTR_ID.Name = "OTR_ID"
            Me.OTR_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.OTR_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.OTR_ID.Width = 50
            '
            'Orden
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.Orden.DefaultCellStyle = DataGridViewCellStyle1
            Me.Orden.HeaderText = "O.T"
            Me.Orden.Name = "Orden"
            '
            'Entidad
            '
            Me.Entidad.HeaderText = "Entidad"
            Me.Entidad.Name = "Entidad"
            Me.Entidad.ReadOnly = True
            '
            'per_id
            '
            Me.per_id.HeaderText = "per_id"
            Me.per_id.Name = "per_id"
            Me.per_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.per_id.Width = 50
            '
            'Nombre
            '
            Me.Nombre.HeaderText = "Nombre"
            Me.Nombre.Name = "Nombre"
            Me.Nombre.ReadOnly = True
            '
            'grm_HoraDesde
            '
            Me.grm_HoraDesde.HeaderText = "Hora Desde"
            Me.grm_HoraDesde.Name = "grm_HoraDesde"
            '
            'grm_HoraHasta
            '
            Me.grm_HoraHasta.HeaderText = "Hora Hasta"
            Me.grm_HoraHasta.Name = "grm_HoraHasta"
            '
            'grm_HoraTotal
            '
            Me.grm_HoraTotal.HeaderText = "Total"
            Me.grm_HoraTotal.Name = "grm_HoraTotal"
            Me.grm_HoraTotal.ReadOnly = True
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            '
            'grm_observaciones
            '
            Me.grm_observaciones.HeaderText = "Observaciones"
            Me.grm_observaciones.Name = "grm_observaciones"
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClonarFilaSeleccionadaToolStripMenuItem, Me.ToolStripTextBox1})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(201, 49)
            '
            'ClonarFilaSeleccionadaToolStripMenuItem
            '
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Name = "ClonarFilaSeleccionadaToolStripMenuItem"
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
            Me.ClonarFilaSeleccionadaToolStripMenuItem.Text = "Clonar Fila Seleccionada"
            '
            'ToolStripTextBox1
            '
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 21)
            Me.ToolStripTextBox1.Text = "N"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.btnResponsable)
            Me.Panel2.Controls.Add(Me.txtResponsable)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.btnSerie)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Location = New System.Drawing.Point(5, 6)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(836, 84)
            Me.Panel2.TabIndex = 0
            '
            'btnResponsable
            '
            Me.btnResponsable.Location = New System.Drawing.Point(462, 27)
            Me.btnResponsable.Name = "btnResponsable"
            Me.btnResponsable.Size = New System.Drawing.Size(24, 23)
            Me.btnResponsable.TabIndex = 135
            Me.btnResponsable.Text = ":::"
            Me.btnResponsable.UseVisualStyleBackColor = True
            '
            'txtResponsable
            '
            Me.txtResponsable.Location = New System.Drawing.Point(111, 30)
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.ReadOnly = True
            Me.txtResponsable.Size = New System.Drawing.Size(347, 20)
            Me.txtResponsable.TabIndex = 134
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(37, 33)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(69, 13)
            Me.Label5.TabIndex = 133
            Me.Label5.Text = "Responsable"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(111, 53)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(347, 20)
            Me.txtObservaciones.TabIndex = 132
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(28, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 13)
            Me.Label2.TabIndex = 131
            Me.Label2.Text = "Observaciones"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(21, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 13)
            Me.Label1.TabIndex = 125
            Me.Label1.Text = "Periodo/Numero"
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(174, 5)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(27, 23)
            Me.btnSerie.TabIndex = 130
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(203, 7)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 127
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(335, 10)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 129
            Me.Label6.Text = "Fecha"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(111, 7)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
            Me.txtPeriodo.TabIndex = 126
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(373, 7)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(84, 20)
            Me.dateFecha.TabIndex = 128
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmGrupoMantenimiento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(854, 394)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmGrupoMantenimiento"
            Me.Text = "frmGrupoMantenimiento"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ContextMenuStrip1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnResponsable As System.Windows.Forms.Button
        Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grm_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OTR_ID As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Entidad As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents grm_HoraDesde As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents grm_HoraHasta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents grm_HoraTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents grm_observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ClonarFilaSeleccionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    End Class

End Namespace