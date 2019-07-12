Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesXPeriodoNuevo
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblLibros = New System.Windows.Forms.Label()
            Me.lblPeriodo = New System.Windows.Forms.Label()
            Me.dgvLibros = New System.Windows.Forms.DataGridView()
            Me.cCodigo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDescripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cSeleccion1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvPeriodos = New System.Windows.Forms.DataGridView()
            Me.cPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cSeleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvLibros, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(732, 28)
            Me.lblTitle.Text = "Reportes"
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.lblLibros)
            Me.Panel1.Controls.Add(Me.lblPeriodo)
            Me.Panel1.Controls.Add(Me.dgvLibros)
            Me.Panel1.Controls.Add(Me.dgvPeriodos)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(716, 193)
            Me.Panel1.TabIndex = 1
            '
            'lblLibros
            '
            Me.lblLibros.AutoSize = True
            Me.lblLibros.Location = New System.Drawing.Point(307, 18)
            Me.lblLibros.Name = "lblLibros"
            Me.lblLibros.Size = New System.Drawing.Size(35, 13)
            Me.lblLibros.TabIndex = 7
            Me.lblLibros.Text = "Libros"
            '
            'lblPeriodo
            '
            Me.lblPeriodo.AutoSize = True
            Me.lblPeriodo.Location = New System.Drawing.Point(8, 18)
            Me.lblPeriodo.Name = "lblPeriodo"
            Me.lblPeriodo.Size = New System.Drawing.Size(48, 13)
            Me.lblPeriodo.TabIndex = 6
            Me.lblPeriodo.Text = "Periodos"
            '
            'dgvLibros
            '
            Me.dgvLibros.AllowUserToAddRows = False
            Me.dgvLibros.AllowUserToDeleteRows = False
            Me.dgvLibros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLibros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodigo1, Me.cDescripcion1, Me.cSeleccion1})
            Me.dgvLibros.Location = New System.Drawing.Point(310, 37)
            Me.dgvLibros.Name = "dgvLibros"
            Me.dgvLibros.Size = New System.Drawing.Size(387, 129)
            Me.dgvLibros.TabIndex = 5
            '
            'cCodigo1
            '
            Me.cCodigo1.HeaderText = "Código"
            Me.cCodigo1.Name = "cCodigo1"
            Me.cCodigo1.ReadOnly = True
            '
            'cDescripcion1
            '
            Me.cDescripcion1.HeaderText = "Descripción"
            Me.cDescripcion1.Name = "cDescripcion1"
            Me.cDescripcion1.ReadOnly = True
            '
            'cSeleccion1
            '
            Me.cSeleccion1.HeaderText = "Selección"
            Me.cSeleccion1.Name = "cSeleccion1"
            '
            'dgvPeriodos
            '
            Me.dgvPeriodos.AllowUserToAddRows = False
            Me.dgvPeriodos.AllowUserToDeleteRows = False
            Me.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPeriodos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPeriodo, Me.cSeleccion})
            Me.dgvPeriodos.Location = New System.Drawing.Point(8, 37)
            Me.dgvPeriodos.Name = "dgvPeriodos"
            Me.dgvPeriodos.Size = New System.Drawing.Size(285, 129)
            Me.dgvPeriodos.TabIndex = 4
            '
            'cPeriodo
            '
            Me.cPeriodo.HeaderText = "Periodo"
            Me.cPeriodo.Name = "cPeriodo"
            Me.cPeriodo.ReadOnly = True
            '
            'cSeleccion
            '
            Me.cSeleccion.HeaderText = "Selección"
            Me.cSeleccion.Name = "cSeleccion"
            Me.cSeleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cSeleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'btnGenerar
            '
            Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnGenerar.Location = New System.Drawing.Point(622, 167)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 3
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmReportesXPeriodoNuevo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(732, 239)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesXPeriodoNuevo"
            Me.Text = "Reportes"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvLibros, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents dgvPeriodos As System.Windows.Forms.DataGridView
        Friend WithEvents lblLibros As System.Windows.Forms.Label
        Friend WithEvents lblPeriodo As System.Windows.Forms.Label
        Friend WithEvents dgvLibros As System.Windows.Forms.DataGridView
        Friend WithEvents cPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cSeleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents cCodigo1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDescripcion1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cSeleccion1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class

End Namespace