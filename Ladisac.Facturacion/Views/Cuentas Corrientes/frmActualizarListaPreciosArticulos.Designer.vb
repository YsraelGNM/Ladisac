Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmActualizarListaPreciosArticulos
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
            Me.btnModificar = New System.Windows.Forms.Button()
            Me.chkMarcar = New System.Windows.Forms.CheckBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.txtPrecio = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtArticulo = New System.Windows.Forms.TextBox()
            Me.btnArticulo = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblTipoCliente = New System.Windows.Forms.Label()
            Me.cboTipoCliente = New System.Windows.Forms.ComboBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.LPR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnModificarRecarga = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(680, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnModificarRecarga)
            Me.Panel1.Controls.Add(Me.btnModificar)
            Me.Panel1.Controls.Add(Me.chkMarcar)
            Me.Panel1.Controls.Add(Me.btnBuscar)
            Me.Panel1.Controls.Add(Me.txtPrecio)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.txtArticulo)
            Me.Panel1.Controls.Add(Me.btnArticulo)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.lblTipoCliente)
            Me.Panel1.Controls.Add(Me.cboTipoCliente)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(671, 100)
            Me.Panel1.TabIndex = 1
            '
            'btnModificar
            '
            Me.btnModificar.Location = New System.Drawing.Point(207, 67)
            Me.btnModificar.Name = "btnModificar"
            Me.btnModificar.Size = New System.Drawing.Size(132, 23)
            Me.btnModificar.TabIndex = 145
            Me.btnModificar.Text = "Modificar a Precios"
            Me.btnModificar.UseVisualStyleBackColor = True
            '
            'chkMarcar
            '
            Me.chkMarcar.AutoSize = True
            Me.chkMarcar.Location = New System.Drawing.Point(589, 80)
            Me.chkMarcar.Name = "chkMarcar"
            Me.chkMarcar.Size = New System.Drawing.Size(59, 17)
            Me.chkMarcar.TabIndex = 144
            Me.chkMarcar.Text = "Marcar"
            Me.chkMarcar.UseVisualStyleBackColor = True
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(489, 37)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 143
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'txtPrecio
            '
            Me.txtPrecio.Location = New System.Drawing.Point(136, 69)
            Me.txtPrecio.Name = "txtPrecio"
            Me.txtPrecio.Size = New System.Drawing.Size(65, 20)
            Me.txtPrecio.TabIndex = 142
            Me.txtPrecio.Text = "0.00"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(8, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(122, 13)
            Me.Label1.TabIndex = 141
            Me.Label1.Text = "Cifra a aumentar o quitra"
            '
            'txtArticulo
            '
            Me.txtArticulo.Location = New System.Drawing.Point(136, 37)
            Me.txtArticulo.Name = "txtArticulo"
            Me.txtArticulo.ReadOnly = True
            Me.txtArticulo.Size = New System.Drawing.Size(313, 20)
            Me.txtArticulo.TabIndex = 139
            '
            'btnArticulo
            '
            Me.btnArticulo.Location = New System.Drawing.Point(455, 37)
            Me.btnArticulo.Name = "btnArticulo"
            Me.btnArticulo.Size = New System.Drawing.Size(28, 23)
            Me.btnArticulo.TabIndex = 140
            Me.btnArticulo.Text = ":::"
            Me.btnArticulo.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(36, 40)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(47, 13)
            Me.Label5.TabIndex = 138
            Me.Label5.Text = "Articulos"
            '
            'lblTipoCliente
            '
            Me.lblTipoCliente.AutoSize = True
            Me.lblTipoCliente.Location = New System.Drawing.Point(15, 12)
            Me.lblTipoCliente.Name = "lblTipoCliente"
            Me.lblTipoCliente.Size = New System.Drawing.Size(62, 13)
            Me.lblTipoCliente.TabIndex = 137
            Me.lblTipoCliente.Text = "Tipo cliente"
            '
            'cboTipoCliente
            '
            Me.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoCliente.FormattingEnabled = True
            Me.cboTipoCliente.Location = New System.Drawing.Point(136, 12)
            Me.cboTipoCliente.Name = "cboTipoCliente"
            Me.cboTipoCliente.Size = New System.Drawing.Size(244, 21)
            Me.cboTipoCliente.TabIndex = 136
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.LPR_ID, Me.Column3, Me.Column2})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 139)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(671, 244)
            Me.dgvDetalle.TabIndex = 2
            '
            'Column1
            '
            Me.Column1.HeaderText = "ok"
            Me.Column1.Name = "Column1"
            Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'LPR_ID
            '
            Me.LPR_ID.HeaderText = "ID"
            Me.LPR_ID.Name = "LPR_ID"
            Me.LPR_ID.ReadOnly = True
            '
            'Column3
            '
            Me.Column3.HeaderText = "Nombre"
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            Me.Column3.Width = 150
            '
            'Column2
            '
            Me.Column2.HeaderText = "descripcion"
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            Me.Column2.Width = 150
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnModificarRecarga
            '
            Me.btnModificarRecarga.Location = New System.Drawing.Point(345, 67)
            Me.btnModificarRecarga.Name = "btnModificarRecarga"
            Me.btnModificarRecarga.Size = New System.Drawing.Size(132, 23)
            Me.btnModificarRecarga.TabIndex = 146
            Me.btnModificarRecarga.Text = "Modificar la Recarga"
            Me.btnModificarRecarga.UseVisualStyleBackColor = True
            '
            'frmActualizarListaPreciosArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(680, 395)
            Me.Controls.Add(Me.dgvDetalle)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmActualizarListaPreciosArticulos"
            Me.Text = "frmActualizarListaPreciosArticulos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
        Public WithEvents cboTipoCliente As System.Windows.Forms.ComboBox
        Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
        Friend WithEvents btnArticulo As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkMarcar As System.Windows.Forms.CheckBox
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents btnModificar As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents LPR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnModificarRecarga As System.Windows.Forms.Button
    End Class

End Namespace
