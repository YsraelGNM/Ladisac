Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmFletesTransportes
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
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.lblFLE_MONTO_PAG = New System.Windows.Forms.Label()
            Me.lblFLE_MONTO_COB = New System.Windows.Forms.Label()
            Me.txtFLE_MONTO_PAG = New System.Windows.Forms.TextBox()
            Me.txtFLE_MONTO_COB = New System.Windows.Forms.TextBox()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.lblFLE_ESTADO = New System.Windows.Forms.Label()
            Me.lblFLE_ID = New System.Windows.Forms.Label()
            Me.lblFLE_TIPO = New System.Windows.Forms.Label()
            Me.chkFLE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtFLE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtFLE_ID = New System.Windows.Forms.TextBox()
            Me.cboFLE_TIPO = New System.Windows.Forms.ComboBox()
            Me.cFLE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDFL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDFL_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDIS_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cPRO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPRO_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDEP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDEP_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cPAI_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cPAI_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cFDE_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(831, 28)
            Me.lblTitle.Text = "Fletes transportes"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(743, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 28)
            Me.btnImagen.TabIndex = 118
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_MONTO_PAG)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_MONTO_COB)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_MONTO_PAG)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_MONTO_COB)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblFLE_TIPO)
            Me.pnCuerpo.Controls.Add(Me.chkFLE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtFLE_ID)
            Me.pnCuerpo.Controls.Add(Me.cboFLE_TIPO)
            Me.pnCuerpo.Location = New System.Drawing.Point(29, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(759, 377)
            Me.pnCuerpo.TabIndex = 119
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(9, 69)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 46
            Me.lblMON_ID.Text = "Moneda"
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(135, 69)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(583, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 6
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Location = New System.Drawing.Point(94, 69)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtMON_ID.TabIndex = 5
            '
            'lblFLE_MONTO_PAG
            '
            Me.lblFLE_MONTO_PAG.AutoSize = True
            Me.lblFLE_MONTO_PAG.Location = New System.Drawing.Point(381, 95)
            Me.lblFLE_MONTO_PAG.Name = "lblFLE_MONTO_PAG"
            Me.lblFLE_MONTO_PAG.Size = New System.Drawing.Size(67, 13)
            Me.lblFLE_MONTO_PAG.TabIndex = 43
            Me.lblFLE_MONTO_PAG.Text = "Monto pagar"
            '
            'lblFLE_MONTO_COB
            '
            Me.lblFLE_MONTO_COB.AutoSize = True
            Me.lblFLE_MONTO_COB.Location = New System.Drawing.Point(9, 95)
            Me.lblFLE_MONTO_COB.Name = "lblFLE_MONTO_COB"
            Me.lblFLE_MONTO_COB.Size = New System.Drawing.Size(70, 13)
            Me.lblFLE_MONTO_COB.TabIndex = 42
            Me.lblFLE_MONTO_COB.Text = "Monto cobrar"
            '
            'txtFLE_MONTO_PAG
            '
            Me.txtFLE_MONTO_PAG.Location = New System.Drawing.Point(452, 95)
            Me.txtFLE_MONTO_PAG.Name = "txtFLE_MONTO_PAG"
            Me.txtFLE_MONTO_PAG.Size = New System.Drawing.Size(93, 20)
            Me.txtFLE_MONTO_PAG.TabIndex = 8
            Me.txtFLE_MONTO_PAG.Text = "0"
            '
            'txtFLE_MONTO_COB
            '
            Me.txtFLE_MONTO_COB.Location = New System.Drawing.Point(94, 95)
            Me.txtFLE_MONTO_COB.Name = "txtFLE_MONTO_COB"
            Me.txtFLE_MONTO_COB.Size = New System.Drawing.Size(100, 20)
            Me.txtFLE_MONTO_COB.TabIndex = 7
            Me.txtFLE_MONTO_COB.Text = "0"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(9, 38)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(80, 13)
            Me.lblPVE_ID.TabIndex = 39
            Me.lblPVE_ID.Text = "Punto de venta"
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(135, 38)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(583, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 4
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(94, 38)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 3
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cFLE_ID, Me.cDFL_ID, Me.cDFL_DESCRIPCION, Me.cDIS_ID, Me.cDTD_DESCRIPCION, Me.cDIS_ESTADO, Me.cPRO_ID, Me.cPRO_DESCRIPCION, Me.cPRO_ESTADO, Me.cDEP_ID, Me.cDEP_DESCRIPCION, Me.cDEP_ESTADO, Me.cPAI_ID, Me.cPAI_DESCRIPCION, Me.cPAI_ESTADO, Me.cFDE_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 162)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(727, 194)
            Me.dgvDetalle.TabIndex = 11
            '
            'lblFLE_ESTADO
            '
            Me.lblFLE_ESTADO.AutoSize = True
            Me.lblFLE_ESTADO.Location = New System.Drawing.Point(381, 123)
            Me.lblFLE_ESTADO.Name = "lblFLE_ESTADO"
            Me.lblFLE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblFLE_ESTADO.TabIndex = 36
            Me.lblFLE_ESTADO.Text = "Estado"
            '
            'lblFLE_ID
            '
            Me.lblFLE_ID.AutoSize = True
            Me.lblFLE_ID.Location = New System.Drawing.Point(9, 12)
            Me.lblFLE_ID.Name = "lblFLE_ID"
            Me.lblFLE_ID.Size = New System.Drawing.Size(30, 13)
            Me.lblFLE_ID.TabIndex = 25
            Me.lblFLE_ID.Text = "Flete"
            '
            'lblFLE_TIPO
            '
            Me.lblFLE_TIPO.AutoSize = True
            Me.lblFLE_TIPO.Location = New System.Drawing.Point(9, 123)
            Me.lblFLE_TIPO.Name = "lblFLE_TIPO"
            Me.lblFLE_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblFLE_TIPO.TabIndex = 24
            Me.lblFLE_TIPO.Text = "Tipo"
            '
            'chkFLE_ESTADO
            '
            Me.chkFLE_ESTADO.AutoSize = True
            Me.chkFLE_ESTADO.Location = New System.Drawing.Point(452, 123)
            Me.chkFLE_ESTADO.Name = "chkFLE_ESTADO"
            Me.chkFLE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkFLE_ESTADO.TabIndex = 10
            Me.chkFLE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtFLE_DESCRIPCION
            '
            Me.txtFLE_DESCRIPCION.Location = New System.Drawing.Point(135, 12)
            Me.txtFLE_DESCRIPCION.Name = "txtFLE_DESCRIPCION"
            Me.txtFLE_DESCRIPCION.Size = New System.Drawing.Size(583, 20)
            Me.txtFLE_DESCRIPCION.TabIndex = 2
            '
            'txtFLE_ID
            '
            Me.txtFLE_ID.Location = New System.Drawing.Point(94, 12)
            Me.txtFLE_ID.Name = "txtFLE_ID"
            Me.txtFLE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtFLE_ID.TabIndex = 1
            '
            'cboFLE_TIPO
            '
            Me.cboFLE_TIPO.FormattingEnabled = True
            Me.cboFLE_TIPO.Location = New System.Drawing.Point(94, 123)
            Me.cboFLE_TIPO.Name = "cboFLE_TIPO"
            Me.cboFLE_TIPO.Size = New System.Drawing.Size(213, 21)
            Me.cboFLE_TIPO.TabIndex = 9
            '
            'cFLE_ID
            '
            Me.cFLE_ID.HeaderText = "Código"
            Me.cFLE_ID.Name = "cFLE_ID"
            Me.cFLE_ID.ReadOnly = True
            Me.cFLE_ID.Width = 65
            '
            'cDFL_ID
            '
            Me.cDFL_ID.HeaderText = "Cod. Sub zona"
            Me.cDFL_ID.Name = "cDFL_ID"
            Me.cDFL_ID.ReadOnly = True
            Me.cDFL_ID.Width = 102
            '
            'cDFL_DESCRIPCION
            '
            Me.cDFL_DESCRIPCION.HeaderText = "Descripción_zona"
            Me.cDFL_DESCRIPCION.Name = "cDFL_DESCRIPCION"
            Me.cDFL_DESCRIPCION.Width = 117
            '
            'cDIS_ID
            '
            Me.cDIS_ID.HeaderText = "Cod. Distrito"
            Me.cDIS_ID.Name = "cDIS_ID"
            Me.cDIS_ID.Width = 89
            '
            'cDTD_DESCRIPCION
            '
            Me.cDTD_DESCRIPCION.HeaderText = "Descripción distrito"
            Me.cDTD_DESCRIPCION.Name = "cDTD_DESCRIPCION"
            Me.cDTD_DESCRIPCION.ReadOnly = True
            Me.cDTD_DESCRIPCION.Width = 111
            '
            'cDIS_ESTADO
            '
            Me.cDIS_ESTADO.HeaderText = "Estado Dist."
            Me.cDIS_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDIS_ESTADO.Name = "cDIS_ESTADO"
            Me.cDIS_ESTADO.ReadOnly = True
            Me.cDIS_ESTADO.Width = 63
            '
            'cPRO_ID
            '
            Me.cPRO_ID.HeaderText = "Cod. Provincia"
            Me.cPRO_ID.Name = "cPRO_ID"
            Me.cPRO_ID.ReadOnly = True
            Me.cPRO_ID.Width = 93
            '
            'cPRO_DESCRIPCION
            '
            Me.cPRO_DESCRIPCION.HeaderText = "Descripción provincia"
            Me.cPRO_DESCRIPCION.Name = "cPRO_DESCRIPCION"
            Me.cPRO_DESCRIPCION.ReadOnly = True
            Me.cPRO_DESCRIPCION.Width = 123
            '
            'cPRO_ESTADO
            '
            Me.cPRO_ESTADO.HeaderText = "Estado Prov."
            Me.cPRO_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cPRO_ESTADO.Name = "cPRO_ESTADO"
            Me.cPRO_ESTADO.ReadOnly = True
            Me.cPRO_ESTADO.Width = 67
            '
            'cDEP_ID
            '
            Me.cDEP_ID.HeaderText = "Cod. Departamento"
            Me.cDEP_ID.Name = "cDEP_ID"
            Me.cDEP_ID.ReadOnly = True
            Me.cDEP_ID.Width = 114
            '
            'cDEP_DESCRIPCION
            '
            Me.cDEP_DESCRIPCION.HeaderText = "Descripción departamento"
            Me.cDEP_DESCRIPCION.Name = "cDEP_DESCRIPCION"
            Me.cDEP_DESCRIPCION.ReadOnly = True
            Me.cDEP_DESCRIPCION.Width = 142
            '
            'cDEP_ESTADO
            '
            Me.cDEP_ESTADO.HeaderText = "Estado Dpto."
            Me.cDEP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDEP_ESTADO.Name = "cDEP_ESTADO"
            Me.cDEP_ESTADO.ReadOnly = True
            Me.cDEP_ESTADO.Width = 68
            '
            'cPAI_ID
            '
            Me.cPAI_ID.HeaderText = "Cod. País"
            Me.cPAI_ID.Name = "cPAI_ID"
            Me.cPAI_ID.ReadOnly = True
            Me.cPAI_ID.Width = 73
            '
            'cPAI_DESCRIPCION
            '
            Me.cPAI_DESCRIPCION.HeaderText = "Descripción país"
            Me.cPAI_DESCRIPCION.Name = "cPAI_DESCRIPCION"
            Me.cPAI_DESCRIPCION.ReadOnly = True
            Me.cPAI_DESCRIPCION.Width = 103
            '
            'cPAI_ESTADO
            '
            Me.cPAI_ESTADO.HeaderText = "Estado país"
            Me.cPAI_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cPAI_ESTADO.Name = "cPAI_ESTADO"
            Me.cPAI_ESTADO.ReadOnly = True
            Me.cPAI_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cPAI_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cPAI_ESTADO.Width = 82
            '
            'cFDE_ESTADO
            '
            Me.cFDE_ESTADO.HeaderText = "Estado detalle"
            Me.cFDE_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cFDE_ESTADO.Name = "cFDE_ESTADO"
            Me.cFDE_ESTADO.Width = 72
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'frmFletesTransportes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(831, 442)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmFletesTransportes"
            Me.Text = "Fletes transportes"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblFLE_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblFLE_ID As System.Windows.Forms.Label
        Friend WithEvents lblFLE_TIPO As System.Windows.Forms.Label
        Public WithEvents chkFLE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtFLE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtFLE_ID As System.Windows.Forms.TextBox
        Public WithEvents cboFLE_TIPO As System.Windows.Forms.ComboBox
        Friend WithEvents lblFLE_MONTO_PAG As System.Windows.Forms.Label
        Friend WithEvents lblFLE_MONTO_COB As System.Windows.Forms.Label
        Public WithEvents txtFLE_MONTO_PAG As System.Windows.Forms.TextBox
        Public WithEvents txtFLE_MONTO_COB As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents cFLE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDFL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDFL_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDIS_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cPRO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPRO_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDEP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDEP_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cPAI_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cPAI_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cFDE_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace