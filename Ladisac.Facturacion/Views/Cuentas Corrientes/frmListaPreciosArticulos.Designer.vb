Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmListaPreciosArticulos
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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblDisponible = New System.Windows.Forms.Label()
            Me.lblDeuda = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblLPR_ID_ADJ = New System.Windows.Forms.Label()
            Me.lblLPR_DESCRIPCION_ADJ = New System.Windows.Forms.Label()
            Me.txtLPR_ID_ADJ = New System.Windows.Forms.TextBox()
            Me.txtLPR_DESCRIPCION_ADJ = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_ADJ = New System.Windows.Forms.Label()
            Me.lblPER_DESCRIPCION_ADJ = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION_ADJ = New System.Windows.Forms.TextBox()
            Me.btnEnlazar = New System.Windows.Forms.Button()
            Me.txtPER_ID_ADJ = New System.Windows.Forms.TextBox()
            Me.txtPER_LINEA_CREDITO = New System.Windows.Forms.TextBox()
            Me.txtDisponible = New System.Windows.Forms.TextBox()
            Me.txtDeuda = New System.Windows.Forms.TextBox()
            Me.dgvSaldos = New System.Windows.Forms.DataGridView()
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
            Me.lblLPR_PRINCIPAL = New System.Windows.Forms.Label()
            Me.cboLPR_PRINCIPAL = New System.Windows.Forms.ComboBox()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.lblLPR_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtLPR_ID = New System.Windows.Forms.TextBox()
            Me.txtLPR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblLPR_ESTADO = New System.Windows.Forms.Label()
            Me.chkLPR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(967, 28)
            Me.lblTitle.Text = "Lista precios artículos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDisponible)
            Me.pnCuerpo.Controls.Add(Me.lblDeuda)
            Me.pnCuerpo.Controls.Add(Me.Label1)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID_ADJ)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_DESCRIPCION_ADJ)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_ID_ADJ)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_DESCRIPCION_ADJ)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_ADJ)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION_ADJ)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_ADJ)
            Me.pnCuerpo.Controls.Add(Me.btnEnlazar)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_ADJ)
            Me.pnCuerpo.Controls.Add(Me.txtPER_LINEA_CREDITO)
            Me.pnCuerpo.Controls.Add(Me.txtDisponible)
            Me.pnCuerpo.Controls.Add(Me.txtDeuda)
            Me.pnCuerpo.Controls.Add(Me.dgvSaldos)
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
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
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
            Me.pnCuerpo.Size = New System.Drawing.Size(890, 424)
            Me.pnCuerpo.TabIndex = 19
            '
            'lblDisponible
            '
            Me.lblDisponible.AutoSize = True
            Me.lblDisponible.Location = New System.Drawing.Point(538, 158)
            Me.lblDisponible.Name = "lblDisponible"
            Me.lblDisponible.Size = New System.Drawing.Size(56, 13)
            Me.lblDisponible.TabIndex = 216
            Me.lblDisponible.Text = "Disponible"
            '
            'lblDeuda
            '
            Me.lblDeuda.AutoSize = True
            Me.lblDeuda.Location = New System.Drawing.Point(363, 158)
            Me.lblDeuda.Name = "lblDeuda"
            Me.lblDeuda.Size = New System.Drawing.Size(39, 13)
            Me.lblDeuda.TabIndex = 215
            Me.lblDeuda.Text = "Deuda"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(138, 158)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(70, 13)
            Me.Label1.TabIndex = 214
            Me.Label1.Text = "Línea crédito"
            '
            'lblLPR_ID_ADJ
            '
            Me.lblLPR_ID_ADJ.AutoSize = True
            Me.lblLPR_ID_ADJ.Location = New System.Drawing.Point(6, 107)
            Me.lblLPR_ID_ADJ.Name = "lblLPR_ID_ADJ"
            Me.lblLPR_ID_ADJ.Size = New System.Drawing.Size(42, 13)
            Me.lblLPR_ID_ADJ.TabIndex = 212
            Me.lblLPR_ID_ADJ.Text = "Modelo"
            '
            'lblLPR_DESCRIPCION_ADJ
            '
            Me.lblLPR_DESCRIPCION_ADJ.AutoSize = True
            Me.lblLPR_DESCRIPCION_ADJ.Location = New System.Drawing.Point(138, 107)
            Me.lblLPR_DESCRIPCION_ADJ.Name = "lblLPR_DESCRIPCION_ADJ"
            Me.lblLPR_DESCRIPCION_ADJ.Size = New System.Drawing.Size(73, 13)
            Me.lblLPR_DESCRIPCION_ADJ.TabIndex = 213
            Me.lblLPR_DESCRIPCION_ADJ.Text = "Desc. Modelo"
            '
            'txtLPR_ID_ADJ
            '
            Me.txtLPR_ID_ADJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_ID_ADJ.Location = New System.Drawing.Point(53, 107)
            Me.txtLPR_ID_ADJ.Name = "txtLPR_ID_ADJ"
            Me.txtLPR_ID_ADJ.Size = New System.Drawing.Size(55, 20)
            Me.txtLPR_ID_ADJ.TabIndex = 210
            '
            'txtLPR_DESCRIPCION_ADJ
            '
            Me.txtLPR_DESCRIPCION_ADJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_DESCRIPCION_ADJ.Enabled = False
            Me.txtLPR_DESCRIPCION_ADJ.Location = New System.Drawing.Point(217, 107)
            Me.txtLPR_DESCRIPCION_ADJ.Name = "txtLPR_DESCRIPCION_ADJ"
            Me.txtLPR_DESCRIPCION_ADJ.ReadOnly = True
            Me.txtLPR_DESCRIPCION_ADJ.Size = New System.Drawing.Size(483, 20)
            Me.txtLPR_DESCRIPCION_ADJ.TabIndex = 211
            '
            'lblPER_ID_ADJ
            '
            Me.lblPER_ID_ADJ.AutoSize = True
            Me.lblPER_ID_ADJ.Location = New System.Drawing.Point(6, 131)
            Me.lblPER_ID_ADJ.Name = "lblPER_ID_ADJ"
            Me.lblPER_ID_ADJ.Size = New System.Drawing.Size(43, 13)
            Me.lblPER_ID_ADJ.TabIndex = 208
            Me.lblPER_ID_ADJ.Text = "Adjunto"
            '
            'lblPER_DESCRIPCION_ADJ
            '
            Me.lblPER_DESCRIPCION_ADJ.AutoSize = True
            Me.lblPER_DESCRIPCION_ADJ.Location = New System.Drawing.Point(138, 131)
            Me.lblPER_DESCRIPCION_ADJ.Name = "lblPER_DESCRIPCION_ADJ"
            Me.lblPER_DESCRIPCION_ADJ.Size = New System.Drawing.Size(73, 13)
            Me.lblPER_DESCRIPCION_ADJ.TabIndex = 209
            Me.lblPER_DESCRIPCION_ADJ.Text = "Desc. adjunto"
            '
            'txtPER_DESCRIPCION_ADJ
            '
            Me.txtPER_DESCRIPCION_ADJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_ADJ.Enabled = False
            Me.txtPER_DESCRIPCION_ADJ.Location = New System.Drawing.Point(217, 131)
            Me.txtPER_DESCRIPCION_ADJ.Name = "txtPER_DESCRIPCION_ADJ"
            Me.txtPER_DESCRIPCION_ADJ.ReadOnly = True
            Me.txtPER_DESCRIPCION_ADJ.Size = New System.Drawing.Size(483, 20)
            Me.txtPER_DESCRIPCION_ADJ.TabIndex = 207
            '
            'btnEnlazar
            '
            Me.btnEnlazar.Location = New System.Drawing.Point(709, 131)
            Me.btnEnlazar.Name = "btnEnlazar"
            Me.btnEnlazar.Size = New System.Drawing.Size(75, 23)
            Me.btnEnlazar.TabIndex = 206
            Me.btnEnlazar.Text = "Enlazar"
            Me.btnEnlazar.UseVisualStyleBackColor = True
            '
            'txtPER_ID_ADJ
            '
            Me.txtPER_ID_ADJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_ADJ.Enabled = False
            Me.txtPER_ID_ADJ.Location = New System.Drawing.Point(53, 131)
            Me.txtPER_ID_ADJ.Name = "txtPER_ID_ADJ"
            Me.txtPER_ID_ADJ.ReadOnly = True
            Me.txtPER_ID_ADJ.Size = New System.Drawing.Size(55, 20)
            Me.txtPER_ID_ADJ.TabIndex = 205
            '
            'txtPER_LINEA_CREDITO
            '
            Me.txtPER_LINEA_CREDITO.Enabled = False
            Me.txtPER_LINEA_CREDITO.Location = New System.Drawing.Point(217, 158)
            Me.txtPER_LINEA_CREDITO.Name = "txtPER_LINEA_CREDITO"
            Me.txtPER_LINEA_CREDITO.ReadOnly = True
            Me.txtPER_LINEA_CREDITO.Size = New System.Drawing.Size(103, 20)
            Me.txtPER_LINEA_CREDITO.TabIndex = 204
            Me.txtPER_LINEA_CREDITO.Text = "0.00"
            Me.txtPER_LINEA_CREDITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDisponible
            '
            Me.txtDisponible.Location = New System.Drawing.Point(597, 158)
            Me.txtDisponible.Name = "txtDisponible"
            Me.txtDisponible.ReadOnly = True
            Me.txtDisponible.Size = New System.Drawing.Size(103, 20)
            Me.txtDisponible.TabIndex = 203
            Me.txtDisponible.Text = "0.00"
            Me.txtDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDeuda
            '
            Me.txtDeuda.BackColor = System.Drawing.SystemColors.Control
            Me.txtDeuda.ForeColor = System.Drawing.Color.Red
            Me.txtDeuda.Location = New System.Drawing.Point(405, 158)
            Me.txtDeuda.Name = "txtDeuda"
            Me.txtDeuda.ReadOnly = True
            Me.txtDeuda.Size = New System.Drawing.Size(103, 20)
            Me.txtDeuda.TabIndex = 202
            Me.txtDeuda.Text = "0.00"
            Me.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'dgvSaldos
            '
            Me.dgvSaldos.AllowUserToAddRows = False
            Me.dgvSaldos.AllowUserToDeleteRows = False
            Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSaldos.Enabled = False
            Me.dgvSaldos.Location = New System.Drawing.Point(141, 84)
            Me.dgvSaldos.Name = "dgvSaldos"
            Me.dgvSaldos.ReadOnly = True
            Me.dgvSaldos.Size = New System.Drawing.Size(20, 16)
            Me.dgvSaldos.TabIndex = 201
            Me.dgvSaldos.Visible = False
            '
            'TextBox1
            '
            Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TextBox1.Enabled = False
            Me.TextBox1.Location = New System.Drawing.Point(532, 35)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            Me.TextBox1.Size = New System.Drawing.Size(168, 20)
            Me.TextBox1.TabIndex = 45
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(706, 35)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(81, 13)
            Me.lblPER_ESTADO.TabIndex = 44
            Me.lblPER_ESTADO.Text = "Estado persona"
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(791, 35)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 5
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(6, 35)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID.TabIndex = 42
            Me.lblPER_ID.Text = "Persona"
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(138, 35)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(76, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 43
            Me.lblPER_DESCRIPCION.Text = "Desc. persona"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(53, 35)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtPER_ID.TabIndex = 3
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(217, 35)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(309, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 4
            '
            'lblMON_ESTADO
            '
            Me.lblMON_ESTADO.AutoSize = True
            Me.lblMON_ESTADO.Location = New System.Drawing.Point(706, 59)
            Me.lblMON_ESTADO.Name = "lblMON_ESTADO"
            Me.lblMON_ESTADO.Size = New System.Drawing.Size(81, 13)
            Me.lblMON_ESTADO.TabIndex = 38
            Me.lblMON_ESTADO.Text = "Estado moneda"
            '
            'chkMON_ESTADO
            '
            Me.chkMON_ESTADO.AutoSize = True
            Me.chkMON_ESTADO.Enabled = False
            Me.chkMON_ESTADO.Location = New System.Drawing.Point(791, 59)
            Me.chkMON_ESTADO.Name = "chkMON_ESTADO"
            Me.chkMON_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO.TabIndex = 8
            Me.chkMON_ESTADO.UseVisualStyleBackColor = True
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(6, 59)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 35
            Me.lblMON_ID.Text = "Moneda"
            '
            'lblMON_DESCRIPCION
            '
            Me.lblMON_DESCRIPCION.AutoSize = True
            Me.lblMON_DESCRIPCION.Location = New System.Drawing.Point(138, 59)
            Me.lblMON_DESCRIPCION.Name = "lblMON_DESCRIPCION"
            Me.lblMON_DESCRIPCION.Size = New System.Drawing.Size(76, 13)
            Me.lblMON_DESCRIPCION.TabIndex = 36
            Me.lblMON_DESCRIPCION.Text = "Desc. moneda"
            '
            'txtMON_ID
            '
            Me.txtMON_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_ID.Enabled = False
            Me.txtMON_ID.Location = New System.Drawing.Point(53, 59)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.ReadOnly = True
            Me.txtMON_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtMON_ID.TabIndex = 6
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(217, 59)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(483, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 7
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cLPR_ID, Me.cLPR_DESCRIPCION, Me.cLPR_PRINCIPAL, Me.cART_ID, Me.cART_DESCRIPCION, Me.cUM_DESCRIPCION, Me.cART_FACTOR, Me.cART_ESTADO, Me.cDLP_PRECIO_MINIMO, Me.cDLP_PRECIO_UNITARIO, Me.cDLP_RECARGO_ENVIO, Me.cDLP_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(6, 184)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(861, 228)
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
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.cART_FACTOR.DefaultCellStyle = DataGridViewCellStyle1
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
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N2"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.cDLP_PRECIO_MINIMO.DefaultCellStyle = DataGridViewCellStyle2
            Me.cDLP_PRECIO_MINIMO.HeaderText = "Precio mínimo"
            Me.cDLP_PRECIO_MINIMO.Name = "cDLP_PRECIO_MINIMO"
            Me.cDLP_PRECIO_MINIMO.Visible = False
            Me.cDLP_PRECIO_MINIMO.Width = 80
            '
            'cDLP_PRECIO_UNITARIO
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N2"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.cDLP_PRECIO_UNITARIO.DefaultCellStyle = DataGridViewCellStyle3
            Me.cDLP_PRECIO_UNITARIO.HeaderText = "Precio unitario"
            Me.cDLP_PRECIO_UNITARIO.Name = "cDLP_PRECIO_UNITARIO"
            Me.cDLP_PRECIO_UNITARIO.Width = 80
            '
            'cDLP_RECARGO_ENVIO
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "N2"
            DataGridViewCellStyle4.NullValue = Nothing
            Me.cDLP_RECARGO_ENVIO.DefaultCellStyle = DataGridViewCellStyle4
            Me.cDLP_RECARGO_ENVIO.HeaderText = "Recargo por envío"
            Me.cDLP_RECARGO_ENVIO.Name = "cDLP_RECARGO_ENVIO"
            Me.cDLP_RECARGO_ENVIO.Width = 80
            '
            'cDLP_ESTADO
            '
            Me.cDLP_ESTADO.HeaderText = "Estado de detalle"
            Me.cDLP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDLP_ESTADO.Name = "cDLP_ESTADO"
            Me.cDLP_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDLP_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDLP_ESTADO.Width = 86
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'lblLPR_PRINCIPAL
            '
            Me.lblLPR_PRINCIPAL.AutoSize = True
            Me.lblLPR_PRINCIPAL.Location = New System.Drawing.Point(706, 9)
            Me.lblLPR_PRINCIPAL.Name = "lblLPR_PRINCIPAL"
            Me.lblLPR_PRINCIPAL.Size = New System.Drawing.Size(28, 13)
            Me.lblLPR_PRINCIPAL.TabIndex = 32
            Me.lblLPR_PRINCIPAL.Text = "Tipo"
            '
            'cboLPR_PRINCIPAL
            '
            Me.cboLPR_PRINCIPAL.FormattingEnabled = True
            Me.cboLPR_PRINCIPAL.Location = New System.Drawing.Point(747, 9)
            Me.cboLPR_PRINCIPAL.Name = "cboLPR_PRINCIPAL"
            Me.cboLPR_PRINCIPAL.Size = New System.Drawing.Size(120, 21)
            Me.cboLPR_PRINCIPAL.TabIndex = 2
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(6, 9)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblLPR_ID.TabIndex = 28
            Me.lblLPR_ID.Text = "Código"
            '
            'lblLPR_DESCRIPCION
            '
            Me.lblLPR_DESCRIPCION.AutoSize = True
            Me.lblLPR_DESCRIPCION.Location = New System.Drawing.Point(138, 9)
            Me.lblLPR_DESCRIPCION.Name = "lblLPR_DESCRIPCION"
            Me.lblLPR_DESCRIPCION.Size = New System.Drawing.Size(56, 13)
            Me.lblLPR_DESCRIPCION.TabIndex = 30
            Me.lblLPR_DESCRIPCION.Text = "Desc. lista"
            '
            'txtLPR_ID
            '
            Me.txtLPR_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_ID.Location = New System.Drawing.Point(53, 9)
            Me.txtLPR_ID.Name = "txtLPR_ID"
            Me.txtLPR_ID.Size = New System.Drawing.Size(55, 20)
            Me.txtLPR_ID.TabIndex = 0
            '
            'txtLPR_DESCRIPCION
            '
            Me.txtLPR_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_DESCRIPCION.Location = New System.Drawing.Point(217, 9)
            Me.txtLPR_DESCRIPCION.Name = "txtLPR_DESCRIPCION"
            Me.txtLPR_DESCRIPCION.Size = New System.Drawing.Size(483, 20)
            Me.txtLPR_DESCRIPCION.TabIndex = 1
            '
            'lblLPR_ESTADO
            '
            Me.lblLPR_ESTADO.AutoSize = True
            Me.lblLPR_ESTADO.Location = New System.Drawing.Point(6, 84)
            Me.lblLPR_ESTADO.Name = "lblLPR_ESTADO"
            Me.lblLPR_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblLPR_ESTADO.TabIndex = 4
            Me.lblLPR_ESTADO.Text = "Estado"
            '
            'chkLPR_ESTADO
            '
            Me.chkLPR_ESTADO.AutoSize = True
            Me.chkLPR_ESTADO.Location = New System.Drawing.Point(53, 84)
            Me.chkLPR_ESTADO.Name = "chkLPR_ESTADO"
            Me.chkLPR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkLPR_ESTADO.TabIndex = 9
            Me.chkLPR_ESTADO.UseVisualStyleBackColor = True
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
            'frmListaPreciosArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(967, 484)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmListaPreciosArticulos"
            Me.Text = "Lista precios artículos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents dgvSaldos As System.Windows.Forms.DataGridView
        Public WithEvents txtDeuda As System.Windows.Forms.TextBox
        Public WithEvents txtDisponible As System.Windows.Forms.TextBox
        Public WithEvents txtPER_LINEA_CREDITO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_ADJ As System.Windows.Forms.TextBox
        Friend WithEvents btnEnlazar As System.Windows.Forms.Button
        Friend WithEvents lblPER_ID_ADJ As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION_ADJ As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION_ADJ As System.Windows.Forms.TextBox
        Friend WithEvents lblLPR_ID_ADJ As System.Windows.Forms.Label
        Friend WithEvents lblLPR_DESCRIPCION_ADJ As System.Windows.Forms.Label
        Public WithEvents txtLPR_ID_ADJ As System.Windows.Forms.TextBox
        Public WithEvents txtLPR_DESCRIPCION_ADJ As System.Windows.Forms.TextBox
        Friend WithEvents lblDisponible As System.Windows.Forms.Label
        Friend WithEvents lblDeuda As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace
