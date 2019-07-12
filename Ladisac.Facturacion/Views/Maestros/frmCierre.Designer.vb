Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCierre
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.lblFecha = New System.Windows.Forms.Label()
            Me.dgvDocumentoCerrar = New System.Windows.Forms.DataGridView()
            Me.btnCerrarCaja = New System.Windows.Forms.Button()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cCIE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDCI_COMPORTAMIENTO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cDCI_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.lblCIE_ESTADO = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblCIE_ID = New System.Windows.Forms.Label()
            Me.chkCIE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtCIE_ID = New System.Windows.Forms.TextBox()
            Me.lblErrorFecha = New System.Windows.Forms.Label()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDocumentoCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(709, 28)
            Me.lblTitle.Text = "Cierre"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(617, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblErrorFecha)
            Me.pnCuerpo.Controls.Add(Me.dtpFecha)
            Me.pnCuerpo.Controls.Add(Me.lblFecha)
            Me.pnCuerpo.Controls.Add(Me.dgvDocumentoCerrar)
            Me.pnCuerpo.Controls.Add(Me.btnCerrarCaja)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblCIE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCIE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCIE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCIE_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(30, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(638, 351)
            Me.pnCuerpo.TabIndex = 118
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(191, 13)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
            Me.dtpFecha.TabIndex = 39
            '
            'lblFecha
            '
            Me.lblFecha.AutoSize = True
            Me.lblFecha.Location = New System.Drawing.Point(133, 13)
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Size = New System.Drawing.Size(37, 13)
            Me.lblFecha.TabIndex = 38
            Me.lblFecha.Text = "Fecha"
            '
            'dgvDocumentoCerrar
            '
            Me.dgvDocumentoCerrar.AllowUserToAddRows = False
            Me.dgvDocumentoCerrar.AllowUserToDeleteRows = False
            Me.dgvDocumentoCerrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDocumentoCerrar.Enabled = False
            Me.dgvDocumentoCerrar.Location = New System.Drawing.Point(542, 67)
            Me.dgvDocumentoCerrar.Name = "dgvDocumentoCerrar"
            Me.dgvDocumentoCerrar.Size = New System.Drawing.Size(66, 23)
            Me.dgvDocumentoCerrar.TabIndex = 37
            Me.dgvDocumentoCerrar.Visible = False
            '
            'btnCerrarCaja
            '
            Me.btnCerrarCaja.Location = New System.Drawing.Point(11, 307)
            Me.btnCerrarCaja.Name = "btnCerrarCaja"
            Me.btnCerrarCaja.Size = New System.Drawing.Size(75, 37)
            Me.btnCerrarCaja.TabIndex = 7
            Me.btnCerrarCaja.Text = "Procesar caja"
            Me.btnCerrarCaja.UseVisualStyleBackColor = True
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCIE_ID, Me.cDTD_ID, Me.cDTD_DESCRIPCION, Me.cDCI_COMPORTAMIENTO, Me.cDCI_ESTADO, Me.cEstadoRegistro})
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 95)
            Me.dgvDetalle.Name = "dgvDetalle"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDetalle.Size = New System.Drawing.Size(599, 206)
            Me.dgvDetalle.TabIndex = 6
            '
            'cCIE_ID
            '
            Me.cCIE_ID.HeaderText = "Código"
            Me.cCIE_ID.Name = "cCIE_ID"
            Me.cCIE_ID.ReadOnly = True
            Me.cCIE_ID.Width = 59
            '
            'cDTD_ID
            '
            Me.cDTD_ID.HeaderText = "Cód. Documento"
            Me.cDTD_ID.Name = "cDTD_ID"
            Me.cDTD_ID.ReadOnly = True
            Me.cDTD_ID.Width = 92
            '
            'cDTD_DESCRIPCION
            '
            Me.cDTD_DESCRIPCION.HeaderText = "Desc. Documento"
            Me.cDTD_DESCRIPCION.Name = "cDTD_DESCRIPCION"
            Me.cDTD_DESCRIPCION.ReadOnly = True
            Me.cDTD_DESCRIPCION.Width = 97
            '
            'cDCI_COMPORTAMIENTO
            '
            Me.cDCI_COMPORTAMIENTO.HeaderText = "Comportamiento"
            Me.cDCI_COMPORTAMIENTO.Items.AddRange(New Object() {"ABIERTO", "CERRADO", "ATENDER"})
            Me.cDCI_COMPORTAMIENTO.Name = "cDCI_COMPORTAMIENTO"
            Me.cDCI_COMPORTAMIENTO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDCI_COMPORTAMIENTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDCI_COMPORTAMIENTO.Width = 99
            '
            'cDCI_ESTADO
            '
            Me.cDCI_ESTADO.HeaderText = "Estado detalle"
            Me.cDCI_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDCI_ESTADO.Name = "cDCI_ESTADO"
            Me.cDCI_ESTADO.Width = 62
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'lblCIE_ESTADO
            '
            Me.lblCIE_ESTADO.AutoSize = True
            Me.lblCIE_ESTADO.Location = New System.Drawing.Point(6, 67)
            Me.lblCIE_ESTADO.Name = "lblCIE_ESTADO"
            Me.lblCIE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCIE_ESTADO.TabIndex = 36
            Me.lblCIE_ESTADO.Text = "Estado"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(6, 41)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(80, 13)
            Me.lblPVE_ID.TabIndex = 25
            Me.lblPVE_ID.Text = "Punto de venta"
            '
            'lblCIE_ID
            '
            Me.lblCIE_ID.AutoSize = True
            Me.lblCIE_ID.Location = New System.Drawing.Point(6, 13)
            Me.lblCIE_ID.Name = "lblCIE_ID"
            Me.lblCIE_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCIE_ID.TabIndex = 22
            Me.lblCIE_ID.Text = "Código"
            '
            'chkCIE_ESTADO
            '
            Me.chkCIE_ESTADO.AutoSize = True
            Me.chkCIE_ESTADO.Location = New System.Drawing.Point(58, 66)
            Me.chkCIE_ESTADO.Name = "chkCIE_ESTADO"
            Me.chkCIE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCIE_ESTADO.TabIndex = 5
            Me.chkCIE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(133, 39)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(475, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 4
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(93, 39)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 3
            '
            'txtCIE_ID
            '
            Me.txtCIE_ID.Location = New System.Drawing.Point(58, 13)
            Me.txtCIE_ID.Name = "txtCIE_ID"
            Me.txtCIE_ID.Size = New System.Drawing.Size(69, 20)
            Me.txtCIE_ID.TabIndex = 0
            '
            'lblErrorFecha
            '
            Me.lblErrorFecha.AutoSize = True
            Me.lblErrorFecha.Location = New System.Drawing.Point(292, 13)
            Me.lblErrorFecha.Name = "lblErrorFecha"
            Me.lblErrorFecha.Size = New System.Drawing.Size(10, 13)
            Me.lblErrorFecha.TabIndex = 40
            Me.lblErrorFecha.Text = "."
            '
            'frmCierre
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 420)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmCierre"
            Me.Text = "Cierre"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDocumentoCerrar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblCIE_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblCIE_ID As System.Windows.Forms.Label
        Public WithEvents chkCIE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCIE_ID As System.Windows.Forms.TextBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents cCIE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDCI_COMPORTAMIENTO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cDCI_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents btnCerrarCaja As System.Windows.Forms.Button
        Friend WithEvents dgvDocumentoCerrar As System.Windows.Forms.DataGridView
        Friend WithEvents lblFecha As System.Windows.Forms.Label
        Public WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblErrorFecha As System.Windows.Forms.Label
    End Class
End Namespace