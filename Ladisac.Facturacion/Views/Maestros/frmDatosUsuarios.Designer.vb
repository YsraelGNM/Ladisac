Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDatosUsuarios
        Inherits Ladisac.Foundation.Views.ViewManMaster

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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cPVE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPVE_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPVE_DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPDU_TIPO_LISTA = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cPDU_ENTREGA_PLANTA = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cPDU_ENTREGA_PUNTO_VENTA = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cPDU_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.lblPER_ESTADO = New System.Windows.Forms.Label()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPER_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.lblDAU_ESTADO = New System.Windows.Forms.Label()
            Me.lblUSU_ID = New System.Windows.Forms.Label()
            Me.lblDAU_ID = New System.Windows.Forms.Label()
            Me.chkDAU_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtUSU_ID = New System.Windows.Forms.TextBox()
            Me.txtDAU_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(796, 28)
            Me.lblTitle.Text = "Puntos de venta asignados a usuario"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDAU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDAU_ID)
            Me.pnCuerpo.Controls.Add(Me.chkDAU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDAU_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(30, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(728, 450)
            Me.pnCuerpo.TabIndex = 119
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPVE_ID, Me.cPVE_DESCRIPCION, Me.cPVE_DIRECCION, Me.cPDU_TIPO_LISTA, Me.cPDU_ENTREGA_PLANTA, Me.cPDU_ENTREGA_PUNTO_VENTA, Me.cPDU_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(18, 163)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(686, 266)
            Me.dgvDetalle.TabIndex = 6
            '
            'cPVE_ID
            '
            Me.cPVE_ID.HeaderText = "Punto de venta"
            Me.cPVE_ID.Name = "cPVE_ID"
            Me.cPVE_ID.Width = 97
            '
            'cPVE_DESCRIPCION
            '
            Me.cPVE_DESCRIPCION.HeaderText = "Descripcion"
            Me.cPVE_DESCRIPCION.Name = "cPVE_DESCRIPCION"
            Me.cPVE_DESCRIPCION.ReadOnly = True
            Me.cPVE_DESCRIPCION.Width = 88
            '
            'cPVE_DIRECCION
            '
            Me.cPVE_DIRECCION.HeaderText = "Dirección"
            Me.cPVE_DIRECCION.Name = "cPVE_DIRECCION"
            Me.cPVE_DIRECCION.ReadOnly = True
            Me.cPVE_DIRECCION.Width = 77
            '
            'cPDU_TIPO_LISTA
            '
            Me.cPDU_TIPO_LISTA.HeaderText = "Tipo de lista"
            Me.cPDU_TIPO_LISTA.Items.AddRange(New Object() {"AMBOS", "SEGUN PUNTO DE VENTA"})
            Me.cPDU_TIPO_LISTA.Name = "cPDU_TIPO_LISTA"
            Me.cPDU_TIPO_LISTA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cPDU_TIPO_LISTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cPDU_TIPO_LISTA.Width = 66
            '
            'cPDU_ENTREGA_PLANTA
            '
            Me.cPDU_ENTREGA_PLANTA.HeaderText = "Despacho en planta"
            Me.cPDU_ENTREGA_PLANTA.Items.AddRange(New Object() {"AMBOS", "EN LOCAL", "EN OBRA"})
            Me.cPDU_ENTREGA_PLANTA.Name = "cPDU_ENTREGA_PLANTA"
            Me.cPDU_ENTREGA_PLANTA.Width = 72
            '
            'cPDU_ENTREGA_PUNTO_VENTA
            '
            Me.cPDU_ENTREGA_PUNTO_VENTA.HeaderText = "Despacho en punto de venta"
            Me.cPDU_ENTREGA_PUNTO_VENTA.Items.AddRange(New Object() {"AMBOS", "EN LOCAL", "EN OBRA"})
            Me.cPDU_ENTREGA_PUNTO_VENTA.Name = "cPDU_ENTREGA_PUNTO_VENTA"
            Me.cPDU_ENTREGA_PUNTO_VENTA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cPDU_ENTREGA_PUNTO_VENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cPDU_ENTREGA_PUNTO_VENTA.Width = 118
            '
            'cPDU_ESTADO
            '
            Me.cPDU_ESTADO.HeaderText = "Estado de detalle"
            Me.cPDU_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cPDU_ESTADO.Name = "cPDU_ESTADO"
            Me.cPDU_ESTADO.Width = 86
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(558, 102)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblPER_ESTADO.TabIndex = 42
            Me.lblPER_ESTADO.Text = "Estado"
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(608, 102)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 4
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(18, 102)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(100, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 40
            Me.lblPER_DESCRIPCION.Text = "Apellidos y nombres"
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(121, 102)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(419, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 3
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(18, 73)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(96, 13)
            Me.lblPER_ID.TabIndex = 38
            Me.lblPER_ID.Text = "Código de persona"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(121, 73)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(89, 20)
            Me.txtPER_ID.TabIndex = 2
            '
            'lblDAU_ESTADO
            '
            Me.lblDAU_ESTADO.AutoSize = True
            Me.lblDAU_ESTADO.Location = New System.Drawing.Point(18, 133)
            Me.lblDAU_ESTADO.Name = "lblDAU_ESTADO"
            Me.lblDAU_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDAU_ESTADO.TabIndex = 36
            Me.lblDAU_ESTADO.Text = "Estado"
            '
            'lblUSU_ID
            '
            Me.lblUSU_ID.AutoSize = True
            Me.lblUSU_ID.Location = New System.Drawing.Point(18, 42)
            Me.lblUSU_ID.Name = "lblUSU_ID"
            Me.lblUSU_ID.Size = New System.Drawing.Size(92, 13)
            Me.lblUSU_ID.TabIndex = 30
            Me.lblUSU_ID.Text = "Código de usuario"
            '
            'lblDAU_ID
            '
            Me.lblDAU_ID.AutoSize = True
            Me.lblDAU_ID.Location = New System.Drawing.Point(18, 14)
            Me.lblDAU_ID.Name = "lblDAU_ID"
            Me.lblDAU_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblDAU_ID.TabIndex = 25
            Me.lblDAU_ID.Text = "Código"
            '
            'chkDAU_ESTADO
            '
            Me.chkDAU_ESTADO.AutoSize = True
            Me.chkDAU_ESTADO.Location = New System.Drawing.Point(121, 132)
            Me.chkDAU_ESTADO.Name = "chkDAU_ESTADO"
            Me.chkDAU_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDAU_ESTADO.TabIndex = 5
            Me.chkDAU_ESTADO.UseVisualStyleBackColor = True
            '
            'txtUSU_ID
            '
            Me.txtUSU_ID.Location = New System.Drawing.Point(121, 42)
            Me.txtUSU_ID.Name = "txtUSU_ID"
            Me.txtUSU_ID.Size = New System.Drawing.Size(159, 20)
            Me.txtUSU_ID.TabIndex = 1
            '
            'txtDAU_ID
            '
            Me.txtDAU_ID.Location = New System.Drawing.Point(121, 14)
            Me.txtDAU_ID.Name = "txtDAU_ID"
            Me.txtDAU_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtDAU_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(713, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 120
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDatosUsuarios
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(796, 508)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDatosUsuarios"
            Me.Text = "Puntos de venta asignados a usuario"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblDAU_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblUSU_ID As System.Windows.Forms.Label
        Friend WithEvents lblDAU_ID As System.Windows.Forms.Label
        Public WithEvents chkDAU_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtUSU_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDAU_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents cPVE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPVE_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPVE_DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPDU_TIPO_LISTA As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cPDU_ENTREGA_PLANTA As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cPDU_ENTREGA_PUNTO_VENTA As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cPDU_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace