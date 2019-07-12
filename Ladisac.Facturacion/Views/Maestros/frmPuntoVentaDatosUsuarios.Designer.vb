Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPuntoVentaDatosUsuarios
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
            Me.cboPDU_ENTREGA_PUNTO_VENTA = New System.Windows.Forms.ComboBox()
            Me.lblPDU_ENTREGA_PUNTO_VENTA = New System.Windows.Forms.Label()
            Me.cboPDU_ENTREGA_PLANTA = New System.Windows.Forms.ComboBox()
            Me.lblPDU_ENTREGA_PLANTA = New System.Windows.Forms.Label()
            Me.cboPDU_TIPO_LISTA = New System.Windows.Forms.ComboBox()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.lblPDU_TIPO_LISTA = New System.Windows.Forms.Label()
            Me.lblDAU_ESTADO = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblDAU_ID = New System.Windows.Forms.Label()
            Me.chkPDU_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtDAU_ID = New System.Windows.Forms.TextBox()
            Me.cTDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cCTD_COR_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cSDU_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(787, 28)
            Me.lblTitle.Text = "Series asignados a puntos de venta"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(711, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 122
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.cboPDU_ENTREGA_PUNTO_VENTA)
            Me.pnCuerpo.Controls.Add(Me.lblPDU_ENTREGA_PUNTO_VENTA)
            Me.pnCuerpo.Controls.Add(Me.cboPDU_ENTREGA_PLANTA)
            Me.pnCuerpo.Controls.Add(Me.lblPDU_ENTREGA_PLANTA)
            Me.pnCuerpo.Controls.Add(Me.cboPDU_TIPO_LISTA)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblPDU_TIPO_LISTA)
            Me.pnCuerpo.Controls.Add(Me.lblDAU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDAU_ID)
            Me.pnCuerpo.Controls.Add(Me.chkPDU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDAU_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(28, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(728, 386)
            Me.pnCuerpo.TabIndex = 121
            '
            'cboPDU_ENTREGA_PUNTO_VENTA
            '
            Me.cboPDU_ENTREGA_PUNTO_VENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPDU_ENTREGA_PUNTO_VENTA.Enabled = False
            Me.cboPDU_ENTREGA_PUNTO_VENTA.FormattingEnabled = True
            Me.cboPDU_ENTREGA_PUNTO_VENTA.Location = New System.Drawing.Point(164, 102)
            Me.cboPDU_ENTREGA_PUNTO_VENTA.Name = "cboPDU_ENTREGA_PUNTO_VENTA"
            Me.cboPDU_ENTREGA_PUNTO_VENTA.Size = New System.Drawing.Size(105, 21)
            Me.cboPDU_ENTREGA_PUNTO_VENTA.TabIndex = 5
            '
            'lblPDU_ENTREGA_PUNTO_VENTA
            '
            Me.lblPDU_ENTREGA_PUNTO_VENTA.AutoSize = True
            Me.lblPDU_ENTREGA_PUNTO_VENTA.Location = New System.Drawing.Point(9, 102)
            Me.lblPDU_ENTREGA_PUNTO_VENTA.Name = "lblPDU_ENTREGA_PUNTO_VENTA"
            Me.lblPDU_ENTREGA_PUNTO_VENTA.Size = New System.Drawing.Size(131, 13)
            Me.lblPDU_ENTREGA_PUNTO_VENTA.TabIndex = 48
            Me.lblPDU_ENTREGA_PUNTO_VENTA.Text = "Despacho en punto venta"
            '
            'cboPDU_ENTREGA_PLANTA
            '
            Me.cboPDU_ENTREGA_PLANTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPDU_ENTREGA_PLANTA.Enabled = False
            Me.cboPDU_ENTREGA_PLANTA.FormattingEnabled = True
            Me.cboPDU_ENTREGA_PLANTA.Location = New System.Drawing.Point(493, 102)
            Me.cboPDU_ENTREGA_PLANTA.Name = "cboPDU_ENTREGA_PLANTA"
            Me.cboPDU_ENTREGA_PLANTA.Size = New System.Drawing.Size(105, 21)
            Me.cboPDU_ENTREGA_PLANTA.TabIndex = 6
            '
            'lblPDU_ENTREGA_PLANTA
            '
            Me.lblPDU_ENTREGA_PLANTA.AutoSize = True
            Me.lblPDU_ENTREGA_PLANTA.Location = New System.Drawing.Point(365, 102)
            Me.lblPDU_ENTREGA_PLANTA.Name = "lblPDU_ENTREGA_PLANTA"
            Me.lblPDU_ENTREGA_PLANTA.Size = New System.Drawing.Size(103, 13)
            Me.lblPDU_ENTREGA_PLANTA.TabIndex = 46
            Me.lblPDU_ENTREGA_PLANTA.Text = "Despacho en planta"
            '
            'cboPDU_TIPO_LISTA
            '
            Me.cboPDU_TIPO_LISTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPDU_TIPO_LISTA.Enabled = False
            Me.cboPDU_TIPO_LISTA.FormattingEnabled = True
            Me.cboPDU_TIPO_LISTA.Location = New System.Drawing.Point(121, 71)
            Me.cboPDU_TIPO_LISTA.Name = "cboPDU_TIPO_LISTA"
            Me.cboPDU_TIPO_LISTA.Size = New System.Drawing.Size(191, 21)
            Me.cboPDU_TIPO_LISTA.TabIndex = 4
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(616, 42)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 3
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(164, 42)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(434, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cTDO_ID, Me.cTDO_DESCRIPCION, Me.cTDO_ESTADO, Me.cCTD_COR_SERIE, Me.cSDU_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 163)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(686, 202)
            Me.dgvDetalle.TabIndex = 8
            '
            'lblPDU_TIPO_LISTA
            '
            Me.lblPDU_TIPO_LISTA.AutoSize = True
            Me.lblPDU_TIPO_LISTA.Location = New System.Drawing.Point(9, 71)
            Me.lblPDU_TIPO_LISTA.Name = "lblPDU_TIPO_LISTA"
            Me.lblPDU_TIPO_LISTA.Size = New System.Drawing.Size(64, 13)
            Me.lblPDU_TIPO_LISTA.TabIndex = 38
            Me.lblPDU_TIPO_LISTA.Text = "Tipo de lista"
            '
            'lblDAU_ESTADO
            '
            Me.lblDAU_ESTADO.AutoSize = True
            Me.lblDAU_ESTADO.Location = New System.Drawing.Point(9, 134)
            Me.lblDAU_ESTADO.Name = "lblDAU_ESTADO"
            Me.lblDAU_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDAU_ESTADO.TabIndex = 36
            Me.lblDAU_ESTADO.Text = "Estado"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(9, 42)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(80, 13)
            Me.lblPVE_ID.TabIndex = 30
            Me.lblPVE_ID.Text = "Punto de venta"
            '
            'lblDAU_ID
            '
            Me.lblDAU_ID.AutoSize = True
            Me.lblDAU_ID.Location = New System.Drawing.Point(9, 14)
            Me.lblDAU_ID.Name = "lblDAU_ID"
            Me.lblDAU_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblDAU_ID.TabIndex = 25
            Me.lblDAU_ID.Text = "Código"
            '
            'chkPDU_ESTADO
            '
            Me.chkPDU_ESTADO.AutoSize = True
            Me.chkPDU_ESTADO.Location = New System.Drawing.Point(121, 133)
            Me.chkPDU_ESTADO.Name = "chkPDU_ESTADO"
            Me.chkPDU_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPDU_ESTADO.TabIndex = 7
            Me.chkPDU_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Enabled = False
            Me.txtPVE_ID.Location = New System.Drawing.Point(121, 42)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.ReadOnly = True
            Me.txtPVE_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtPVE_ID.TabIndex = 1
            '
            'txtDAU_ID
            '
            Me.txtDAU_ID.Location = New System.Drawing.Point(121, 14)
            Me.txtDAU_ID.Name = "txtDAU_ID"
            Me.txtDAU_ID.ReadOnly = True
            Me.txtDAU_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtDAU_ID.TabIndex = 0
            '
            'cTDO_ID
            '
            Me.cTDO_ID.HeaderText = "Tipo documento"
            Me.cTDO_ID.Name = "cTDO_ID"
            '
            'cTDO_DESCRIPCION
            '
            Me.cTDO_DESCRIPCION.HeaderText = "Descripción tipo documento"
            Me.cTDO_DESCRIPCION.Name = "cTDO_DESCRIPCION"
            Me.cTDO_DESCRIPCION.ReadOnly = True
            Me.cTDO_DESCRIPCION.Width = 150
            '
            'cTDO_ESTADO
            '
            Me.cTDO_ESTADO.HeaderText = "Estado tipo documento"
            Me.cTDO_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cTDO_ESTADO.Name = "cTDO_ESTADO"
            Me.cTDO_ESTADO.ReadOnly = True
            Me.cTDO_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cTDO_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cTDO_ESTADO.Width = 129
            '
            'cCTD_COR_SERIE
            '
            Me.cCTD_COR_SERIE.HeaderText = "Serie"
            Me.cCTD_COR_SERIE.Name = "cCTD_COR_SERIE"
            Me.cCTD_COR_SERIE.ReadOnly = True
            Me.cCTD_COR_SERIE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cCTD_COR_SERIE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.cCTD_COR_SERIE.Width = 37
            '
            'cSDU_ESTADO
            '
            Me.cSDU_ESTADO.HeaderText = "Estado de detalle"
            Me.cSDU_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cSDU_ESTADO.Name = "cSDU_ESTADO"
            Me.cSDU_ESTADO.Width = 86
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'frmPuntoVentaDatosUsuarios
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(787, 446)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPuntoVentaDatosUsuarios"
            Me.Text = "Series asignados a puntos de venta"
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
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblPDU_TIPO_LISTA As System.Windows.Forms.Label
        Friend WithEvents lblDAU_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblDAU_ID As System.Windows.Forms.Label
        Public WithEvents chkPDU_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDAU_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPDU_ENTREGA_PUNTO_VENTA As System.Windows.Forms.Label
        Friend WithEvents lblPDU_ENTREGA_PLANTA As System.Windows.Forms.Label
        Public WithEvents cboPDU_TIPO_LISTA As System.Windows.Forms.ComboBox
        Public WithEvents cboPDU_ENTREGA_PUNTO_VENTA As System.Windows.Forms.ComboBox
        Public WithEvents cboPDU_ENTREGA_PLANTA As System.Windows.Forms.ComboBox
        Friend WithEvents cTDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cCTD_COR_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cSDU_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace