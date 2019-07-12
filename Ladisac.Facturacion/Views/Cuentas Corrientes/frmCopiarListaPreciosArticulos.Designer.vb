Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCopiarListaPreciosArticulos
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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.lblPER_ESTADO = New System.Windows.Forms.Label()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblPER_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblMON_ESTADO = New System.Windows.Forms.Label()
            Me.chkMON_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.lblMON_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblLPR_PRINCIPAL = New System.Windows.Forms.Label()
            Me.cboLPR_PRINCIPAL = New System.Windows.Forms.ComboBox()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.lblLPR_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtLPR_ID = New System.Windows.Forms.TextBox()
            Me.txtLPR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblLPR_ESTADO = New System.Windows.Forms.Label()
            Me.chkLPR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.dgvListas = New System.Windows.Forms.DataGridView()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cLPR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cLPR_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cLPR_PRINCIPAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cUM_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_FACTOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDLP_PRECIO_MINIMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDLP_PRECIO_UNITARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDLP_RECARGO_ENVIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDLP_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btnJalarListas = New System.Windows.Forms.Button()
            Me.lblTipoCliente = New System.Windows.Forms.Label()
            Me.cboTipoCliente = New System.Windows.Forms.ComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnActualizarListas = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvListas, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(967, 28)
            Me.lblTitle.Text = "Copiar lista precios artículos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.TextBox1)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_PRINCIPAL)
            Me.pnCuerpo.Controls.Add(Me.cboLPR_PRINCIPAL)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkLPR_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(39, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(890, 471)
            Me.pnCuerpo.TabIndex = 19
            '
            'TextBox1
            '
            Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TextBox1.Enabled = False
            Me.TextBox1.Location = New System.Drawing.Point(532, 57)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            Me.TextBox1.Size = New System.Drawing.Size(168, 20)
            Me.TextBox1.TabIndex = 45
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(706, 57)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(81, 13)
            Me.lblPER_ESTADO.TabIndex = 44
            Me.lblPER_ESTADO.Text = "Estado persona"
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(791, 57)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 5
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(6, 57)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID.TabIndex = 42
            Me.lblPER_ID.Text = "Persona"
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(138, 57)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(76, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 43
            Me.lblPER_DESCRIPCION.Text = "Desc. persona"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(72, 57)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtPER_ID.TabIndex = 3
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(217, 57)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(309, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 4
            '
            'lblMON_ESTADO
            '
            Me.lblMON_ESTADO.AutoSize = True
            Me.lblMON_ESTADO.Location = New System.Drawing.Point(706, 85)
            Me.lblMON_ESTADO.Name = "lblMON_ESTADO"
            Me.lblMON_ESTADO.Size = New System.Drawing.Size(81, 13)
            Me.lblMON_ESTADO.TabIndex = 38
            Me.lblMON_ESTADO.Text = "Estado moneda"
            '
            'chkMON_ESTADO
            '
            Me.chkMON_ESTADO.AutoSize = True
            Me.chkMON_ESTADO.Enabled = False
            Me.chkMON_ESTADO.Location = New System.Drawing.Point(791, 85)
            Me.chkMON_ESTADO.Name = "chkMON_ESTADO"
            Me.chkMON_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO.TabIndex = 8
            Me.chkMON_ESTADO.UseVisualStyleBackColor = True
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(6, 85)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 35
            Me.lblMON_ID.Text = "Moneda"
            '
            'lblMON_DESCRIPCION
            '
            Me.lblMON_DESCRIPCION.AutoSize = True
            Me.lblMON_DESCRIPCION.Location = New System.Drawing.Point(138, 85)
            Me.lblMON_DESCRIPCION.Name = "lblMON_DESCRIPCION"
            Me.lblMON_DESCRIPCION.Size = New System.Drawing.Size(76, 13)
            Me.lblMON_DESCRIPCION.TabIndex = 36
            Me.lblMON_DESCRIPCION.Text = "Desc. moneda"
            '
            'txtMON_ID
            '
            Me.txtMON_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_ID.Enabled = False
            Me.txtMON_ID.Location = New System.Drawing.Point(72, 85)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.ReadOnly = True
            Me.txtMON_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtMON_ID.TabIndex = 6
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(217, 85)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(483, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 7
            '
            'lblLPR_PRINCIPAL
            '
            Me.lblLPR_PRINCIPAL.AutoSize = True
            Me.lblLPR_PRINCIPAL.Location = New System.Drawing.Point(532, 30)
            Me.lblLPR_PRINCIPAL.Name = "lblLPR_PRINCIPAL"
            Me.lblLPR_PRINCIPAL.Size = New System.Drawing.Size(28, 13)
            Me.lblLPR_PRINCIPAL.TabIndex = 32
            Me.lblLPR_PRINCIPAL.Text = "Tipo"
            '
            'cboLPR_PRINCIPAL
            '
            Me.cboLPR_PRINCIPAL.FormattingEnabled = True
            Me.cboLPR_PRINCIPAL.Location = New System.Drawing.Point(566, 30)
            Me.cboLPR_PRINCIPAL.Name = "cboLPR_PRINCIPAL"
            Me.cboLPR_PRINCIPAL.Size = New System.Drawing.Size(134, 21)
            Me.cboLPR_PRINCIPAL.TabIndex = 2
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(6, 30)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblLPR_ID.TabIndex = 28
            Me.lblLPR_ID.Text = "Código"
            '
            'lblLPR_DESCRIPCION
            '
            Me.lblLPR_DESCRIPCION.AutoSize = True
            Me.lblLPR_DESCRIPCION.Location = New System.Drawing.Point(138, 30)
            Me.lblLPR_DESCRIPCION.Name = "lblLPR_DESCRIPCION"
            Me.lblLPR_DESCRIPCION.Size = New System.Drawing.Size(56, 13)
            Me.lblLPR_DESCRIPCION.TabIndex = 30
            Me.lblLPR_DESCRIPCION.Text = "Desc. lista"
            '
            'txtLPR_ID
            '
            Me.txtLPR_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_ID.Location = New System.Drawing.Point(72, 30)
            Me.txtLPR_ID.Name = "txtLPR_ID"
            Me.txtLPR_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtLPR_ID.TabIndex = 0
            '
            'txtLPR_DESCRIPCION
            '
            Me.txtLPR_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_DESCRIPCION.Location = New System.Drawing.Point(217, 30)
            Me.txtLPR_DESCRIPCION.Name = "txtLPR_DESCRIPCION"
            Me.txtLPR_DESCRIPCION.Size = New System.Drawing.Size(309, 20)
            Me.txtLPR_DESCRIPCION.TabIndex = 1
            '
            'lblLPR_ESTADO
            '
            Me.lblLPR_ESTADO.AutoSize = True
            Me.lblLPR_ESTADO.Location = New System.Drawing.Point(706, 30)
            Me.lblLPR_ESTADO.Name = "lblLPR_ESTADO"
            Me.lblLPR_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblLPR_ESTADO.TabIndex = 4
            Me.lblLPR_ESTADO.Text = "Estado"
            '
            'chkLPR_ESTADO
            '
            Me.chkLPR_ESTADO.AutoSize = True
            Me.chkLPR_ESTADO.Location = New System.Drawing.Point(791, 30)
            Me.chkLPR_ESTADO.Name = "chkLPR_ESTADO"
            Me.chkLPR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkLPR_ESTADO.TabIndex = 9
            Me.chkLPR_ESTADO.UseVisualStyleBackColor = True
            '
            'dgvListas
            '
            Me.dgvListas.AllowUserToAddRows = False
            Me.dgvListas.AllowUserToDeleteRows = False
            Me.dgvListas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvListas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvListas.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvListas.Location = New System.Drawing.Point(47, 326)
            Me.dgvListas.Name = "dgvListas"
            Me.dgvListas.ReadOnly = True
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvListas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvListas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            Me.dgvListas.Size = New System.Drawing.Size(864, 169)
            Me.dgvListas.TabIndex = 46
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cLPR_ID, Me.cLPR_DESCRIPCION, Me.cLPR_PRINCIPAL, Me.cART_ID, Me.cART_DESCRIPCION, Me.cUM_DESCRIPCION, Me.cART_FACTOR, Me.cART_ESTADO, Me.cDLP_PRECIO_MINIMO, Me.cDLP_PRECIO_UNITARIO, Me.cDLP_RECARGO_ENVIO, Me.cDLP_ESTADO, Me.cEstadoRegistro})
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDetalle.Location = New System.Drawing.Point(47, 145)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.ReadOnly = True
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
            Me.dgvDetalle.Size = New System.Drawing.Size(864, 175)
            Me.dgvDetalle.TabIndex = 10
            '
            'cLPR_ID
            '
            Me.cLPR_ID.HeaderText = "Código"
            Me.cLPR_ID.Name = "cLPR_ID"
            Me.cLPR_ID.ReadOnly = True
            Me.cLPR_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'cLPR_DESCRIPCION
            '
            Me.cLPR_DESCRIPCION.HeaderText = "Descripción"
            Me.cLPR_DESCRIPCION.Name = "cLPR_DESCRIPCION"
            Me.cLPR_DESCRIPCION.ReadOnly = True
            Me.cLPR_DESCRIPCION.Visible = False
            Me.cLPR_DESCRIPCION.Width = 88
            '
            'cLPR_PRINCIPAL
            '
            Me.cLPR_PRINCIPAL.HeaderText = "Tipo"
            Me.cLPR_PRINCIPAL.Name = "cLPR_PRINCIPAL"
            Me.cLPR_PRINCIPAL.ReadOnly = True
            Me.cLPR_PRINCIPAL.Visible = False
            Me.cLPR_PRINCIPAL.Width = 53
            '
            'cART_ID
            '
            Me.cART_ID.HeaderText = "Código de artículo"
            Me.cART_ID.Name = "cART_ID"
            Me.cART_ID.ReadOnly = True
            Me.cART_ID.Width = 90
            '
            'cART_DESCRIPCION
            '
            Me.cART_DESCRIPCION.HeaderText = "Descripción de artículo"
            Me.cART_DESCRIPCION.Name = "cART_DESCRIPCION"
            Me.cART_DESCRIPCION.ReadOnly = True
            Me.cART_DESCRIPCION.Width = 97
            '
            'cUM_DESCRIPCION
            '
            Me.cUM_DESCRIPCION.HeaderText = "Unidad medida de artículo"
            Me.cUM_DESCRIPCION.Name = "cUM_DESCRIPCION"
            Me.cUM_DESCRIPCION.ReadOnly = True
            Me.cUM_DESCRIPCION.Width = 111
            '
            'cART_FACTOR
            '
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.cART_FACTOR.DefaultCellStyle = DataGridViewCellStyle5
            Me.cART_FACTOR.HeaderText = "Factor de artículo"
            Me.cART_FACTOR.Name = "cART_FACTOR"
            Me.cART_FACTOR.ReadOnly = True
            Me.cART_FACTOR.Width = 55
            '
            'cART_ESTADO
            '
            Me.cART_ESTADO.HeaderText = "Estado de artículo"
            Me.cART_ESTADO.Name = "cART_ESTADO"
            Me.cART_ESTADO.ReadOnly = True
            Me.cART_ESTADO.Width = 90
            '
            'cDLP_PRECIO_MINIMO
            '
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.Format = "N2"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.cDLP_PRECIO_MINIMO.DefaultCellStyle = DataGridViewCellStyle6
            Me.cDLP_PRECIO_MINIMO.HeaderText = "Precio mínimo"
            Me.cDLP_PRECIO_MINIMO.Name = "cDLP_PRECIO_MINIMO"
            Me.cDLP_PRECIO_MINIMO.ReadOnly = True
            Me.cDLP_PRECIO_MINIMO.Visible = False
            Me.cDLP_PRECIO_MINIMO.Width = 80
            '
            'cDLP_PRECIO_UNITARIO
            '
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.Format = "N2"
            DataGridViewCellStyle7.NullValue = Nothing
            Me.cDLP_PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle7
            Me.cDLP_PRECIO_UNITARIO.HeaderText = "Precio unitario"
            Me.cDLP_PRECIO_UNITARIO.Name = "cDLP_PRECIO_UNITARIO"
            Me.cDLP_PRECIO_UNITARIO.ReadOnly = True
            Me.cDLP_PRECIO_UNITARIO.Width = 80
            '
            'cDLP_RECARGO_ENVIO
            '
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.Format = "N2"
            DataGridViewCellStyle8.NullValue = Nothing
            Me.cDLP_RECARGO_ENVIO.DefaultCellStyle = DataGridViewCellStyle8
            Me.cDLP_RECARGO_ENVIO.HeaderText = "Recargo por envío"
            Me.cDLP_RECARGO_ENVIO.Name = "cDLP_RECARGO_ENVIO"
            Me.cDLP_RECARGO_ENVIO.ReadOnly = True
            Me.cDLP_RECARGO_ENVIO.Width = 80
            '
            'cDLP_ESTADO
            '
            Me.cDLP_ESTADO.HeaderText = "Estado de detalle"
            Me.cDLP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDLP_ESTADO.Name = "cDLP_ESTADO"
            Me.cDLP_ESTADO.ReadOnly = True
            Me.cDLP_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDLP_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDLP_ESTADO.Width = 86
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            Me.cEstadoRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'btnJalarListas
            '
            Me.btnJalarListas.Location = New System.Drawing.Point(258, 38)
            Me.btnJalarListas.Name = "btnJalarListas"
            Me.btnJalarListas.Size = New System.Drawing.Size(124, 23)
            Me.btnJalarListas.TabIndex = 136
            Me.btnJalarListas.Text = "Jalar listas"
            Me.btnJalarListas.UseVisualStyleBackColor = True
            '
            'lblTipoCliente
            '
            Me.lblTipoCliente.AutoSize = True
            Me.lblTipoCliente.Location = New System.Drawing.Point(46, 38)
            Me.lblTipoCliente.Name = "lblTipoCliente"
            Me.lblTipoCliente.Size = New System.Drawing.Size(62, 13)
            Me.lblTipoCliente.TabIndex = 135
            Me.lblTipoCliente.Text = "Tipo cliente"
            '
            'cboTipoCliente
            '
            Me.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoCliente.FormattingEnabled = True
            Me.cboTipoCliente.Location = New System.Drawing.Point(112, 38)
            Me.cboTipoCliente.Name = "cboTipoCliente"
            Me.cboTipoCliente.Size = New System.Drawing.Size(134, 21)
            Me.cboTipoCliente.TabIndex = 134
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
            'btnActualizarListas
            '
            Me.btnActualizarListas.Location = New System.Drawing.Point(388, 38)
            Me.btnActualizarListas.Name = "btnActualizarListas"
            Me.btnActualizarListas.Size = New System.Drawing.Size(124, 23)
            Me.btnActualizarListas.TabIndex = 137
            Me.btnActualizarListas.Text = "Actualizar listas"
            Me.btnActualizarListas.UseVisualStyleBackColor = True
            '
            'frmCopiarListaPreciosArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(967, 531)
            Me.Controls.Add(Me.dgvDetalle)
            Me.Controls.Add(Me.btnActualizarListas)
            Me.Controls.Add(Me.btnJalarListas)
            Me.Controls.Add(Me.cboTipoCliente)
            Me.Controls.Add(Me.lblTipoCliente)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.dgvListas)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmCopiarListaPreciosArticulos"
            Me.Text = "Copiar lista precios artículos"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.dgvListas, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.lblTipoCliente, 0)
            Me.Controls.SetChildIndex(Me.cboTipoCliente, 0)
            Me.Controls.SetChildIndex(Me.btnJalarListas, 0)
            Me.Controls.SetChildIndex(Me.btnActualizarListas, 0)
            Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvListas, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblLPR_ID As System.Windows.Forms.Label
        Friend WithEvents lblLPR_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtLPR_ID As System.Windows.Forms.TextBox
        Public WithEvents txtLPR_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblLPR_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkLPR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblLPR_PRINCIPAL As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents cboLPR_PRINCIPAL As System.Windows.Forms.ComboBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblMON_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkMON_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Friend WithEvents lblMON_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents cLPR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cLPR_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cLPR_PRINCIPAL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cUM_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_FACTOR As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDLP_PRECIO_MINIMO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDLP_PRECIO_UNITARIO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDLP_RECARGO_ENVIO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDLP_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
        Public WithEvents cboTipoCliente As System.Windows.Forms.ComboBox
        Friend WithEvents btnJalarListas As System.Windows.Forms.Button
        Friend WithEvents btnActualizarListas As System.Windows.Forms.Button
        Public WithEvents dgvListas As System.Windows.Forms.DataGridView
    End Class
End Namespace
