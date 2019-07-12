Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasComprobantesLogistica
        '  Inherits System.Windows.Forms.Form
        Inherits ViewManMasterContabilidad
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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.alm_id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.CodigoAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.almacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CUC_ID = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(771, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(767, 259)
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
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.alm_id, Me.CodigoAlmacen, Me.almacen, Me.CUC_ID, Me.cuenta, Me.descripcion})
            Me.dgvDetalle.Location = New System.Drawing.Point(6, 5)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(752, 248)
            Me.dgvDetalle.TabIndex = 3
            '
            'alm_id
            '
            Me.alm_id.HeaderText = "alm_id"
            Me.alm_id.Name = "alm_id"
            Me.alm_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.alm_id.Width = 40
            '
            'CodigoAlmacen
            '
            Me.CodigoAlmacen.HeaderText = "CodigoAlmacen"
            Me.CodigoAlmacen.Name = "CodigoAlmacen"
            Me.CodigoAlmacen.ReadOnly = True
            '
            'almacen
            '
            Me.almacen.HeaderText = "Almacen"
            Me.almacen.Name = "almacen"
            Me.almacen.ReadOnly = True
            Me.almacen.Width = 200
            '
            'CUC_ID
            '
            Me.CUC_ID.HeaderText = "CUC_ID"
            Me.CUC_ID.Name = "CUC_ID"
            Me.CUC_ID.Width = 30
            '
            'cuenta
            '
            Me.cuenta.HeaderText = "Cuenta"
            Me.cuenta.Name = "cuenta"
            Me.cuenta.ReadOnly = True
            Me.cuenta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'descripcion
            '
            Me.descripcion.HeaderText = "Descripcion"
            Me.descripcion.Name = "descripcion"
            Me.descripcion.ReadOnly = True
            Me.descripcion.Width = 200
            '
            'frmCuentasComprobantesLogistica
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(771, 314)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCuentasComprobantesLogistica"
            Me.Text = "frmCuentasComprobantesLogistica"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents alm_id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents CodigoAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents almacen As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CUC_ID As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class

End Namespace

