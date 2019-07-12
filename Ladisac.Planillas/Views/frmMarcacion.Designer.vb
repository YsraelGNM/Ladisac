Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMarcacion
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
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnPlantillaExcel = New System.Windows.Forms.Button()
            Me.btnImportar = New System.Windows.Forms.Button()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.PER_ID = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mar_marcacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mar_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mar_Movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mar_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mar_observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(704, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(695, 332)
            Me.Panel1.TabIndex = 2
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.txtCodigo)
            Me.Panel2.Controls.Add(Me.Label20)
            Me.Panel2.Controls.Add(Me.btnPlantillaExcel)
            Me.Panel2.Controls.Add(Me.btnImportar)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(688, 32)
            Me.Panel2.TabIndex = 1
            '
            'btnPlantillaExcel
            '
            Me.btnPlantillaExcel.Location = New System.Drawing.Point(589, 4)
            Me.btnPlantillaExcel.Name = "btnPlantillaExcel"
            Me.btnPlantillaExcel.Size = New System.Drawing.Size(83, 23)
            Me.btnPlantillaExcel.TabIndex = 1
            Me.btnPlantillaExcel.Text = "Plantilla Excel"
            Me.btnPlantillaExcel.UseVisualStyleBackColor = True
            '
            'btnImportar
            '
            Me.btnImportar.Location = New System.Drawing.Point(503, 4)
            Me.btnImportar.Name = "btnImportar"
            Me.btnImportar.Size = New System.Drawing.Size(83, 23)
            Me.btnImportar.TabIndex = 0
            Me.btnImportar.Text = "Importar Excel"
            Me.btnImportar.UseVisualStyleBackColor = True
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PER_ID, Me.Codigo, Me.Nombre, Me.mar_marcacion, Me.mar_estado, Me.mar_Movimiento, Me.mar_tipo, Me.mar_observaciones})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 42)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(688, 283)
            Me.dgvDetalle.TabIndex = 0
            '
            'PER_ID
            '
            Me.PER_ID.HeaderText = "PER_ID"
            Me.PER_ID.Name = "PER_ID"
            Me.PER_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.PER_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.PER_ID.Width = 40
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            '
            'Nombre
            '
            Me.Nombre.HeaderText = "Nombre"
            Me.Nombre.Name = "Nombre"
            '
            'mar_marcacion
            '
            Me.mar_marcacion.HeaderText = "Marcacion"
            Me.mar_marcacion.Name = "mar_marcacion"
            '
            'mar_estado
            '
            Me.mar_estado.HeaderText = "Estado"
            Me.mar_estado.Name = "mar_estado"
            '
            'mar_Movimiento
            '
            Me.mar_Movimiento.HeaderText = "Movimiento"
            Me.mar_Movimiento.Name = "mar_Movimiento"
            '
            'mar_tipo
            '
            Me.mar_tipo.HeaderText = "Tipo"
            Me.mar_tipo.Name = "mar_tipo"
            '
            'mar_observaciones
            '
            Me.mar_observaciones.HeaderText = "observaciones"
            Me.mar_observaciones.Name = "mar_observaciones"
            '
            'OpenFileDialog1
            '
            Me.OpenFileDialog1.FileName = "OpenFileDialog1"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(90, 9)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(8, 11)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(76, 13)
            Me.Label20.TabIndex = 6
            Me.Label20.Text = "Buscar Codigo"
            '
            'frmMarcacion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(704, 394)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmMarcacion"
            Me.Text = "frmMarcacion"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnPlantillaExcel As System.Windows.Forms.Button
        Friend WithEvents btnImportar As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents PER_ID As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mar_marcacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mar_estado As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mar_Movimiento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mar_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mar_observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
    End Class

End Namespace
