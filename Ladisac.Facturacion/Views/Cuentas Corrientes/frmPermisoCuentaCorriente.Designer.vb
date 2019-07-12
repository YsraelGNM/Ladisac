Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPermisoCuentaCorriente
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
            Me.lblUSU_ESTADO = New System.Windows.Forms.Label()
            Me.chkUSU_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblUSU_ID = New System.Windows.Forms.Label()
            Me.txtUSU_ID = New System.Windows.Forms.TextBox()
            Me.txtUSU_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPEU_ESTADO = New System.Windows.Forms.Label()
            Me.chkPEU_ESTADO = New System.Windows.Forms.CheckBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cDPC_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cboUSU_TIPO = New System.Windows.Forms.ComboBox()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.txtPEU_ID = New System.Windows.Forms.TextBox()
            Me.lblPCC_ESTADO = New System.Windows.Forms.Label()
            Me.chkPCC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPEU_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(967, 28)
            Me.lblTitle.Text = "Permiso cuenta corriente"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblUSU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkUSU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.txtUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.txtUSU_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPEU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPEU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.cboUSU_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPEU_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPCC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPCC_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(39, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(890, 312)
            Me.pnCuerpo.TabIndex = 19
            '
            'lblUSU_ESTADO
            '
            Me.lblUSU_ESTADO.AutoSize = True
            Me.lblUSU_ESTADO.Location = New System.Drawing.Point(514, 41)
            Me.lblUSU_ESTADO.Name = "lblUSU_ESTADO"
            Me.lblUSU_ESTADO.Size = New System.Drawing.Size(64, 13)
            Me.lblUSU_ESTADO.TabIndex = 44
            Me.lblUSU_ESTADO.Text = "Est. Usuario"
            '
            'chkUSU_ESTADO
            '
            Me.chkUSU_ESTADO.AutoSize = True
            Me.chkUSU_ESTADO.Enabled = False
            Me.chkUSU_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUSU_ESTADO.Location = New System.Drawing.Point(581, 41)
            Me.chkUSU_ESTADO.Name = "chkUSU_ESTADO"
            Me.chkUSU_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkUSU_ESTADO.TabIndex = 4
            Me.chkUSU_ESTADO.UseVisualStyleBackColor = True
            '
            'lblUSU_ID
            '
            Me.lblUSU_ID.AutoSize = True
            Me.lblUSU_ID.Location = New System.Drawing.Point(6, 41)
            Me.lblUSU_ID.Name = "lblUSU_ID"
            Me.lblUSU_ID.Size = New System.Drawing.Size(43, 13)
            Me.lblUSU_ID.TabIndex = 42
            Me.lblUSU_ID.Text = "Usuario"
            '
            'txtUSU_ID
            '
            Me.txtUSU_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtUSU_ID.Enabled = False
            Me.txtUSU_ID.Location = New System.Drawing.Point(53, 41)
            Me.txtUSU_ID.Name = "txtUSU_ID"
            Me.txtUSU_ID.Size = New System.Drawing.Size(99, 20)
            Me.txtUSU_ID.TabIndex = 1
            '
            'txtUSU_DESCRIPCION
            '
            Me.txtUSU_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtUSU_DESCRIPCION.Enabled = False
            Me.txtUSU_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtUSU_DESCRIPCION.Location = New System.Drawing.Point(158, 41)
            Me.txtUSU_DESCRIPCION.Name = "txtUSU_DESCRIPCION"
            Me.txtUSU_DESCRIPCION.ReadOnly = True
            Me.txtUSU_DESCRIPCION.Size = New System.Drawing.Size(219, 17)
            Me.txtUSU_DESCRIPCION.TabIndex = 2
            '
            'lblPEU_ESTADO
            '
            Me.lblPEU_ESTADO.AutoSize = True
            Me.lblPEU_ESTADO.Location = New System.Drawing.Point(680, 41)
            Me.lblPEU_ESTADO.Name = "lblPEU_ESTADO"
            Me.lblPEU_ESTADO.Size = New System.Drawing.Size(102, 13)
            Me.lblPEU_ESTADO.TabIndex = 38
            Me.lblPEU_ESTADO.Text = "Est. Permiso usuario"
            '
            'chkPEU_ESTADO
            '
            Me.chkPEU_ESTADO.AutoSize = True
            Me.chkPEU_ESTADO.Enabled = False
            Me.chkPEU_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPEU_ESTADO.Location = New System.Drawing.Point(785, 41)
            Me.chkPEU_ESTADO.Name = "chkPEU_ESTADO"
            Me.chkPEU_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPEU_ESTADO.TabIndex = 5
            Me.chkPEU_ESTADO.UseVisualStyleBackColor = True
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPEU_ID, Me.cCCT_ID, Me.cCCT_DESCRIPCION, Me.cCCT_ESTADO, Me.cDPC_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(6, 89)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(861, 213)
            Me.dgvDetalle.TabIndex = 7
            '
            'cDPC_ESTADO
            '
            Me.cDPC_ESTADO.HeaderText = "Estado de detalle"
            Me.cDPC_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDPC_ESTADO.Name = "cDPC_ESTADO"
            Me.cDPC_ESTADO.ReadOnly = True
            Me.cDPC_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDPC_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDPC_ESTADO.Width = 86
            '
            'cboUSU_TIPO
            '
            Me.cboUSU_TIPO.Enabled = False
            Me.cboUSU_TIPO.FormattingEnabled = True
            Me.cboUSU_TIPO.Location = New System.Drawing.Point(380, 41)
            Me.cboUSU_TIPO.Name = "cboUSU_TIPO"
            Me.cboUSU_TIPO.Size = New System.Drawing.Size(120, 21)
            Me.cboUSU_TIPO.TabIndex = 3
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(6, 14)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(106, 13)
            Me.lblLPR_ID.TabIndex = 28
            Me.lblLPR_ID.Text = "Cód. Permiso usuario"
            '
            'txtPEU_ID
            '
            Me.txtPEU_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPEU_ID.Location = New System.Drawing.Point(158, 14)
            Me.txtPEU_ID.MaxLength = 6
            Me.txtPEU_ID.Name = "txtPEU_ID"
            Me.txtPEU_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtPEU_ID.TabIndex = 0
            '
            'lblPCC_ESTADO
            '
            Me.lblPCC_ESTADO.AutoSize = True
            Me.lblPCC_ESTADO.Location = New System.Drawing.Point(6, 69)
            Me.lblPCC_ESTADO.Name = "lblPCC_ESTADO"
            Me.lblPCC_ESTADO.Size = New System.Drawing.Size(109, 13)
            Me.lblPCC_ESTADO.TabIndex = 4
            Me.lblPCC_ESTADO.Text = "Est. Permiso Cta. Cte."
            '
            'chkPCC_ESTADO
            '
            Me.chkPCC_ESTADO.AutoSize = True
            Me.chkPCC_ESTADO.Location = New System.Drawing.Point(158, 69)
            Me.chkPCC_ESTADO.Name = "chkPCC_ESTADO"
            Me.chkPCC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPCC_ESTADO.TabIndex = 6
            Me.chkPCC_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(875, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(54, 28)
            Me.btnImagen.TabIndex = 20
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Código cta. cte."
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Width = 90
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Descripción cta. cte."
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Width = 97
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Estado cta. cte."
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Width = 90
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Estado de registro"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn5.Visible = False
            Me.DataGridViewTextBoxColumn5.Width = 88
            '
            'cPEU_ID
            '
            Me.cPEU_ID.HeaderText = "Código"
            Me.cPEU_ID.Name = "cPEU_ID"
            Me.cPEU_ID.ReadOnly = True
            Me.cPEU_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'cCCT_ID
            '
            Me.cCCT_ID.HeaderText = "Código cta. cte."
            Me.cCCT_ID.Name = "cCCT_ID"
            Me.cCCT_ID.Width = 90
            '
            'cCCT_DESCRIPCION
            '
            Me.cCCT_DESCRIPCION.HeaderText = "Descripción cta. cte."
            Me.cCCT_DESCRIPCION.Name = "cCCT_DESCRIPCION"
            Me.cCCT_DESCRIPCION.ReadOnly = True
            Me.cCCT_DESCRIPCION.Width = 97
            '
            'cCCT_ESTADO
            '
            Me.cCCT_ESTADO.HeaderText = "Estado cta. cte."
            Me.cCCT_ESTADO.Name = "cCCT_ESTADO"
            Me.cCCT_ESTADO.ReadOnly = True
            Me.cCCT_ESTADO.Width = 90
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'frmPermisoCuentaCorriente
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(967, 372)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPermisoCuentaCorriente"
            Me.Text = "Permiso cuenta corriente"
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
        Friend WithEvents lblLPR_ID As System.Windows.Forms.Label
        Public WithEvents txtPEU_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPCC_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPCC_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents cboUSU_TIPO As System.Windows.Forms.ComboBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblPEU_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPEU_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblUSU_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkUSU_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblUSU_ID As System.Windows.Forms.Label
        Public WithEvents txtUSU_ID As System.Windows.Forms.TextBox
        Public WithEvents txtUSU_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents cPEU_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDPC_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
