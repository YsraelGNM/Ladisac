Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoDocumentos
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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.lblTDO_ESTADO = New System.Windows.Forms.Label()
            Me.lblTDO_ID = New System.Windows.Forms.Label()
            Me.lblTDO_UBICACION = New System.Windows.Forms.Label()
            Me.chkTDO_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTDO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.cboTDO_UBICACION = New System.Windows.Forms.ComboBox()
            Me.cTDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_CARGO_ABONO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_SIGNO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_SIGNO_D = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_SIGNO_D_1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_MOVIMIENTO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_PROCESO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDTD_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(795, 28)
            Me.lblTitle.Text = "Tipo documentos"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(714, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_UBICACION)
            Me.pnCuerpo.Controls.Add(Me.chkTDO_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.cboTDO_UBICACION)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(725, 270)
            Me.pnCuerpo.TabIndex = 118
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cTDO_ID, Me.cDTD_ID, Me.cDTD_DESCRIPCION, Me.cDTD_CARGO_ABONO, Me.cDTD_SIGNO, Me.cDTD_SIGNO_D, Me.cDTD_SIGNO_D_1, Me.cDTD_MOVIMIENTO, Me.cDTD_PROCESO, Me.cDTD_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 85)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(686, 164)
            Me.dgvDetalle.TabIndex = 5
            '
            'lblTDO_ESTADO
            '
            Me.lblTDO_ESTADO.AutoSize = True
            Me.lblTDO_ESTADO.Location = New System.Drawing.Point(220, 48)
            Me.lblTDO_ESTADO.Name = "lblTDO_ESTADO"
            Me.lblTDO_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTDO_ESTADO.TabIndex = 36
            Me.lblTDO_ESTADO.Text = "Estado"
            '
            'lblTDO_ID
            '
            Me.lblTDO_ID.AutoSize = True
            Me.lblTDO_ID.Location = New System.Drawing.Point(6, 12)
            Me.lblTDO_ID.Name = "lblTDO_ID"
            Me.lblTDO_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblTDO_ID.TabIndex = 25
            Me.lblTDO_ID.Text = "Tipo Doc."
            '
            'lblTDO_UBICACION
            '
            Me.lblTDO_UBICACION.AutoSize = True
            Me.lblTDO_UBICACION.Location = New System.Drawing.Point(6, 48)
            Me.lblTDO_UBICACION.Name = "lblTDO_UBICACION"
            Me.lblTDO_UBICACION.Size = New System.Drawing.Size(55, 13)
            Me.lblTDO_UBICACION.TabIndex = 24
            Me.lblTDO_UBICACION.Text = "Ubicación"
            '
            'chkTDO_ESTADO
            '
            Me.chkTDO_ESTADO.AutoSize = True
            Me.chkTDO_ESTADO.Location = New System.Drawing.Point(272, 48)
            Me.chkTDO_ESTADO.Name = "chkTDO_ESTADO"
            Me.chkTDO_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTDO_ESTADO.TabIndex = 4
            Me.chkTDO_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTDO_DESCRIPCION
            '
            Me.txtTDO_DESCRIPCION.Location = New System.Drawing.Point(112, 12)
            Me.txtTDO_DESCRIPCION.Name = "txtTDO_DESCRIPCION"
            Me.txtTDO_DESCRIPCION.Size = New System.Drawing.Size(583, 20)
            Me.txtTDO_DESCRIPCION.TabIndex = 2
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Location = New System.Drawing.Point(71, 12)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTDO_ID.TabIndex = 1
            '
            'cboTDO_UBICACION
            '
            Me.cboTDO_UBICACION.FormattingEnabled = True
            Me.cboTDO_UBICACION.Location = New System.Drawing.Point(71, 48)
            Me.cboTDO_UBICACION.Name = "cboTDO_UBICACION"
            Me.cboTDO_UBICACION.Size = New System.Drawing.Size(126, 21)
            Me.cboTDO_UBICACION.TabIndex = 3
            '
            'cTDO_ID
            '
            Me.cTDO_ID.HeaderText = "Código"
            Me.cTDO_ID.Name = "cTDO_ID"
            Me.cTDO_ID.ReadOnly = True
            Me.cTDO_ID.Visible = False
            Me.cTDO_ID.Width = 65
            '
            'cDTD_ID
            '
            Me.cDTD_ID.HeaderText = "Sub Código"
            Me.cDTD_ID.Name = "cDTD_ID"
            Me.cDTD_ID.ReadOnly = True
            Me.cDTD_ID.Width = 87
            '
            'cDTD_DESCRIPCION
            '
            Me.cDTD_DESCRIPCION.HeaderText = "Descripción Sub Código"
            Me.cDTD_DESCRIPCION.Name = "cDTD_DESCRIPCION"
            Me.cDTD_DESCRIPCION.Width = 104
            '
            'cDTD_CARGO_ABONO
            '
            Me.cDTD_CARGO_ABONO.HeaderText = "Cargo Abono"
            Me.cDTD_CARGO_ABONO.Items.AddRange(New Object() {"NINGUNO", "CARGO", "ABONO", "AMBOS"})
            Me.cDTD_CARGO_ABONO.Name = "cDTD_CARGO_ABONO"
            Me.cDTD_CARGO_ABONO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDTD_CARGO_ABONO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDTD_CARGO_ABONO.Width = 87
            '
            'cDTD_SIGNO
            '
            Me.cDTD_SIGNO.HeaderText = "Signo"
            Me.cDTD_SIGNO.Items.AddRange(New Object() {"+", "-"})
            Me.cDTD_SIGNO.Name = "cDTD_SIGNO"
            Me.cDTD_SIGNO.Width = 40
            '
            'cDTD_SIGNO_D
            '
            Me.cDTD_SIGNO_D.HeaderText = "Signo Detalle"
            Me.cDTD_SIGNO_D.Items.AddRange(New Object() {"+", "-"})
            Me.cDTD_SIGNO_D.Name = "cDTD_SIGNO_D"
            Me.cDTD_SIGNO_D.Width = 69
            '
            'cDTD_SIGNO_D_1
            '
            Me.cDTD_SIGNO_D_1.HeaderText = "Signo Detalle 1"
            Me.cDTD_SIGNO_D_1.Items.AddRange(New Object() {"+", "-"})
            Me.cDTD_SIGNO_D_1.Name = "cDTD_SIGNO_D_1"
            Me.cDTD_SIGNO_D_1.Width = 69
            '
            'cDTD_MOVIMIENTO
            '
            Me.cDTD_MOVIMIENTO.HeaderText = "Movimiento"
            Me.cDTD_MOVIMIENTO.Items.AddRange(New Object() {"NINGUNO", "ANTICIPO RECIBIDO", "LIQUIDACION DE DOCUMENTOS", "PLANILLA DE RENDICION DE CUENTAS", "SOLO RETIRO - DEPOSITO", "PRESTAMO POR COBRAR", "NINGUNO CON CARGO A DOCUMENTO", "VENTA POR DESPACHAR"})
            Me.cDTD_MOVIMIENTO.Name = "cDTD_MOVIMIENTO"
            Me.cDTD_MOVIMIENTO.Width = 67
            '
            'cDTD_PROCESO
            '
            Me.cDTD_PROCESO.HeaderText = "Proceso"
            Me.cDTD_PROCESO.Items.AddRange(New Object() {"NINGUNO", "DOCUMENTOS"})
            Me.cDTD_PROCESO.Name = "cDTD_PROCESO"
            Me.cDTD_PROCESO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDTD_PROCESO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDTD_PROCESO.Width = 71
            '
            'cDTD_ESTADO
            '
            Me.cDTD_ESTADO.HeaderText = "Estado detalle"
            Me.cDTD_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDTD_ESTADO.Name = "cDTD_ESTADO"
            Me.cDTD_ESTADO.Width = 72
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'frmTipoDocumentos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(795, 335)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmTipoDocumentos"
            Me.Text = "Tipo documentos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
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
        Friend WithEvents lblTDO_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblTDO_ID As System.Windows.Forms.Label
        Friend WithEvents lblTDO_UBICACION As System.Windows.Forms.Label
        Public WithEvents chkTDO_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTDO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents cboTDO_UBICACION As System.Windows.Forms.ComboBox
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents cTDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_CARGO_ABONO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_SIGNO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_SIGNO_D As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_SIGNO_D_1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_MOVIMIENTO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_PROCESO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDTD_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace