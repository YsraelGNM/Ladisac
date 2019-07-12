Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAsientoAutomatico
        Inherits Foundation.Views.ViewMaster
        '--Inherits System.Windows.Forms.Form

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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.btnProcesar = New System.Windows.Forms.Button()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Proceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(531, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.btnProcesar)
            Me.Panel1.Controls.Add(Me.btnPeriodo)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(6, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(517, 213)
            Me.Panel1.TabIndex = 1
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Proceso})
            Me.dgvDetalle.Location = New System.Drawing.Point(25, 51)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDetalle.Size = New System.Drawing.Size(479, 130)
            Me.dgvDetalle.TabIndex = 4
            '
            'btnProcesar
            '
            Me.btnProcesar.Location = New System.Drawing.Point(417, 15)
            Me.btnProcesar.Name = "btnProcesar"
            Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
            Me.btnProcesar.TabIndex = 3
            Me.btnProcesar.Text = "Procesar"
            Me.btnProcesar.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(192, 15)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(25, 23)
            Me.btnPeriodo.TabIndex = 2
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(85, 15)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(100, 20)
            Me.txtPeriodo.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(22, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Periodo"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(25, 188)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(0, 13)
            Me.Label2.TabIndex = 5
            '
            'Proceso
            '
            Me.Proceso.HeaderText = "Proceso"
            Me.Proceso.Name = "Proceso"
            Me.Proceso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Proceso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.Proceso.Width = 200
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(25, 192)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(135, 13)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Seleccionar  para Procesar"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmAsientoAutomatico
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(531, 248)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmAsientoAutomatico"
            Me.Text = "frmAsientoAutomatico"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents btnProcesar As System.Windows.Forms.Button
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Proceso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class

End Namespace