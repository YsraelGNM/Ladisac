Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTesoreriaCobranza
        Inherits Ladisac.Foundation.Views.ViewManMaster

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.txtPER_DESCRIPCION_CLI = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_CLI = New System.Windows.Forms.Label()
            Me.txtPER_ID_CLI = New System.Windows.Forms.TextBox()
            Me.lblTEC_MONTO = New System.Windows.Forms.Label()
            Me.txtTEC_MONTO = New System.Windows.Forms.TextBox()
            Me.txtMON_SIMBOLO = New System.Windows.Forms.TextBox()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_CLIx = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_CLIx = New System.Windows.Forms.Label()
            Me.txtPER_ID_CLIx = New System.Windows.Forms.TextBox()
            Me.lblTEX_FECHA_EMI = New System.Windows.Forms.Label()
            Me.dtpTEC_FECHA_EMI = New System.Windows.Forms.DateTimePicker()
            Me.lblCorrelativox = New System.Windows.Forms.Label()
            Me.txtTEC_SERIE = New System.Windows.Forms.TextBox()
            Me.txtTEC_NUMERO = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.lblDTD_IDx = New System.Windows.Forms.Label()
            Me.txtDTD_IDx = New System.Windows.Forms.TextBox()
            Me.txtCCT_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.lblTEX_ESTADO = New System.Windows.Forms.Label()
            Me.txtCCT_ID = New System.Windows.Forms.TextBox()
            Me.chkTEC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(798, 28)
            Me.lblTitle.Text = "Cobranza dudosa"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTEX_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTEC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLI)
            Me.pnCuerpo.Controls.Add(Me.lblTEC_MONTO)
            Me.pnCuerpo.Controls.Add(Me.txtTEC_MONTO)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CLIx)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CLIx)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CLIx)
            Me.pnCuerpo.Controls.Add(Me.lblTEX_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.dtpTEC_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.lblCorrelativox)
            Me.pnCuerpo.Controls.Add(Me.txtTEC_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtTEC_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.Label2)
            Me.pnCuerpo.Controls.Add(Me.Label1)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_IDx)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_IDx)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(727, 289)
            Me.pnCuerpo.TabIndex = 2
            '
            'txtPER_DESCRIPCION_CLI
            '
            Me.txtPER_DESCRIPCION_CLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_CLI.Enabled = False
            Me.txtPER_DESCRIPCION_CLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(176, 174)
            Me.txtPER_DESCRIPCION_CLI.Name = "txtPER_DESCRIPCION_CLI"
            Me.txtPER_DESCRIPCION_CLI.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLI.Size = New System.Drawing.Size(544, 20)
            Me.txtPER_DESCRIPCION_CLI.TabIndex = 102
            '
            'lblPER_ID_CLI
            '
            Me.lblPER_ID_CLI.AutoSize = True
            Me.lblPER_ID_CLI.Location = New System.Drawing.Point(18, 174)
            Me.lblPER_ID_CLI.Name = "lblPER_ID_CLI"
            Me.lblPER_ID_CLI.Size = New System.Drawing.Size(64, 13)
            Me.lblPER_ID_CLI.TabIndex = 101
            Me.lblPER_ID_CLI.Text = "Cod. Cliente"
            '
            'txtPER_ID_CLI
            '
            Me.txtPER_ID_CLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_CLI.Enabled = False
            Me.txtPER_ID_CLI.Location = New System.Drawing.Point(119, 174)
            Me.txtPER_ID_CLI.MaxLength = 6
            Me.txtPER_ID_CLI.Name = "txtPER_ID_CLI"
            Me.txtPER_ID_CLI.ReadOnly = True
            Me.txtPER_ID_CLI.Size = New System.Drawing.Size(51, 20)
            Me.txtPER_ID_CLI.TabIndex = 100
            '
            'lblTEC_MONTO
            '
            Me.lblTEC_MONTO.AutoSize = True
            Me.lblTEC_MONTO.Location = New System.Drawing.Point(18, 148)
            Me.lblTEC_MONTO.Name = "lblTEC_MONTO"
            Me.lblTEC_MONTO.Size = New System.Drawing.Size(37, 13)
            Me.lblTEC_MONTO.TabIndex = 98
            Me.lblTEC_MONTO.Text = "Monto"
            '
            'txtTEC_MONTO
            '
            Me.txtTEC_MONTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTEC_MONTO.Enabled = False
            Me.txtTEC_MONTO.Location = New System.Drawing.Point(119, 148)
            Me.txtTEC_MONTO.Name = "txtTEC_MONTO"
            Me.txtTEC_MONTO.ReadOnly = True
            Me.txtTEC_MONTO.Size = New System.Drawing.Size(160, 20)
            Me.txtTEC_MONTO.TabIndex = 99
            '
            'txtMON_SIMBOLO
            '
            Me.txtMON_SIMBOLO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_SIMBOLO.Enabled = False
            Me.txtMON_SIMBOLO.Location = New System.Drawing.Point(669, 122)
            Me.txtMON_SIMBOLO.Name = "txtMON_SIMBOLO"
            Me.txtMON_SIMBOLO.ReadOnly = True
            Me.txtMON_SIMBOLO.Size = New System.Drawing.Size(51, 20)
            Me.txtMON_SIMBOLO.TabIndex = 97
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(176, 122)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(487, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 96
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(18, 122)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 94
            Me.lblMON_ID.Text = "Moneda"
            '
            'txtMON_ID
            '
            Me.txtMON_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_ID.Enabled = False
            Me.txtMON_ID.Location = New System.Drawing.Point(119, 122)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.ReadOnly = True
            Me.txtMON_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtMON_ID.TabIndex = 95
            '
            'txtPER_DESCRIPCION_CLIx
            '
            Me.txtPER_DESCRIPCION_CLIx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_CLIx.Enabled = False
            Me.txtPER_DESCRIPCION_CLIx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_CLIx.Location = New System.Drawing.Point(176, 216)
            Me.txtPER_DESCRIPCION_CLIx.Name = "txtPER_DESCRIPCION_CLIx"
            Me.txtPER_DESCRIPCION_CLIx.ReadOnly = True
            Me.txtPER_DESCRIPCION_CLIx.Size = New System.Drawing.Size(544, 20)
            Me.txtPER_DESCRIPCION_CLIx.TabIndex = 93
            Me.txtPER_DESCRIPCION_CLIx.Visible = False
            '
            'lblPER_ID_CLIx
            '
            Me.lblPER_ID_CLIx.AutoSize = True
            Me.lblPER_ID_CLIx.Location = New System.Drawing.Point(18, 216)
            Me.lblPER_ID_CLIx.Name = "lblPER_ID_CLIx"
            Me.lblPER_ID_CLIx.Size = New System.Drawing.Size(64, 13)
            Me.lblPER_ID_CLIx.TabIndex = 92
            Me.lblPER_ID_CLIx.Text = "Cod. Cliente"
            Me.lblPER_ID_CLIx.Visible = False
            '
            'txtPER_ID_CLIx
            '
            Me.txtPER_ID_CLIx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_CLIx.Location = New System.Drawing.Point(119, 216)
            Me.txtPER_ID_CLIx.MaxLength = 6
            Me.txtPER_ID_CLIx.Name = "txtPER_ID_CLIx"
            Me.txtPER_ID_CLIx.Size = New System.Drawing.Size(51, 20)
            Me.txtPER_ID_CLIx.TabIndex = 91
            Me.txtPER_ID_CLIx.Visible = False
            '
            'lblTEX_FECHA_EMI
            '
            Me.lblTEX_FECHA_EMI.AutoSize = True
            Me.lblTEX_FECHA_EMI.Location = New System.Drawing.Point(18, 14)
            Me.lblTEX_FECHA_EMI.Name = "lblTEX_FECHA_EMI"
            Me.lblTEX_FECHA_EMI.Size = New System.Drawing.Size(43, 13)
            Me.lblTEX_FECHA_EMI.TabIndex = 81
            Me.lblTEX_FECHA_EMI.Text = "Emisión"
            '
            'dtpTEC_FECHA_EMI
            '
            Me.dtpTEC_FECHA_EMI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpTEC_FECHA_EMI.Location = New System.Drawing.Point(119, 14)
            Me.dtpTEC_FECHA_EMI.Name = "dtpTEC_FECHA_EMI"
            Me.dtpTEC_FECHA_EMI.Size = New System.Drawing.Size(85, 20)
            Me.dtpTEC_FECHA_EMI.TabIndex = 80
            '
            'lblCorrelativox
            '
            Me.lblCorrelativox.AutoSize = True
            Me.lblCorrelativox.Location = New System.Drawing.Point(18, 96)
            Me.lblCorrelativox.Name = "lblCorrelativox"
            Me.lblCorrelativox.Size = New System.Drawing.Size(73, 13)
            Me.lblCorrelativox.TabIndex = 87
            Me.lblCorrelativox.Text = "Serie/Número"
            '
            'txtTEC_SERIE
            '
            Me.txtTEC_SERIE.Enabled = False
            Me.txtTEC_SERIE.Location = New System.Drawing.Point(119, 96)
            Me.txtTEC_SERIE.Name = "txtTEC_SERIE"
            Me.txtTEC_SERIE.ReadOnly = True
            Me.txtTEC_SERIE.Size = New System.Drawing.Size(51, 20)
            Me.txtTEC_SERIE.TabIndex = 88
            '
            'txtTEC_NUMERO
            '
            Me.txtTEC_NUMERO.Enabled = False
            Me.txtTEC_NUMERO.Location = New System.Drawing.Point(176, 96)
            Me.txtTEC_NUMERO.Name = "txtTEC_NUMERO"
            Me.txtTEC_NUMERO.ReadOnly = True
            Me.txtTEC_NUMERO.Size = New System.Drawing.Size(103, 20)
            Me.txtTEC_NUMERO.TabIndex = 86
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(18, 190)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(703, 13)
            Me.Label2.TabIndex = 90
            Me.Label2.Text = "_________________________________________________________________________________" & _
                "___________________________________"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(18, 27)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(703, 13)
            Me.Label1.TabIndex = 89
            Me.Label1.Text = "_________________________________________________________________________________" & _
                "___________________________________"
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(669, 46)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtTDO_ID.TabIndex = 61
            Me.txtTDO_ID.Visible = False
            '
            'lblDTD_IDx
            '
            Me.lblDTD_IDx.AutoSize = True
            Me.lblDTD_IDx.Location = New System.Drawing.Point(18, 252)
            Me.lblDTD_IDx.Name = "lblDTD_IDx"
            Me.lblDTD_IDx.Size = New System.Drawing.Size(79, 13)
            Me.lblDTD_IDx.TabIndex = 56
            Me.lblDTD_IDx.Text = "Doc. a Dudosa"
            Me.lblDTD_IDx.Visible = False
            '
            'txtDTD_IDx
            '
            Me.txtDTD_IDx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDTD_IDx.Location = New System.Drawing.Point(119, 252)
            Me.txtDTD_IDx.Name = "txtDTD_IDx"
            Me.txtDTD_IDx.ReadOnly = True
            Me.txtDTD_IDx.Size = New System.Drawing.Size(51, 20)
            Me.txtDTD_IDx.TabIndex = 53
            Me.txtDTD_IDx.Visible = False
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(176, 70)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(544, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 51
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(176, 46)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(544, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 3
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(18, 46)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblDTD_ID.TabIndex = 49
            Me.lblDTD_ID.Text = "Tipo Doc."
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDTD_ID.Enabled = False
            Me.txtDTD_ID.Location = New System.Drawing.Point(119, 46)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.ReadOnly = True
            Me.txtDTD_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtDTD_ID.TabIndex = 2
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(18, 70)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(85, 13)
            Me.lblCCT_ID.TabIndex = 0
            Me.lblCCT_ID.Text = "Cuenta corriente"
            '
            'lblTEX_ESTADO
            '
            Me.lblTEX_ESTADO.AutoSize = True
            Me.lblTEX_ESTADO.Location = New System.Drawing.Point(239, 14)
            Me.lblTEX_ESTADO.Name = "lblTEX_ESTADO"
            Me.lblTEX_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTEX_ESTADO.TabIndex = 4
            Me.lblTEX_ESTADO.Text = "Estado"
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCT_ID.Enabled = False
            Me.txtCCT_ID.Location = New System.Drawing.Point(119, 70)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.ReadOnly = True
            Me.txtCCT_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtCCT_ID.TabIndex = 1
            '
            'chkTEC_ESTADO
            '
            Me.chkTEC_ESTADO.AutoSize = True
            Me.chkTEC_ESTADO.Location = New System.Drawing.Point(340, 14)
            Me.chkTEC_ESTADO.Name = "chkTEC_ESTADO"
            Me.chkTEC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTEC_ESTADO.TabIndex = 8
            Me.chkTEC_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(712, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(50, 28)
            Me.btnImagen.TabIndex = 3
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmTesoreriaCobranza
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(798, 344)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmTesoreriaCobranza"
            Me.Text = "Cobranza dudosa"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblCCT_ID As System.Windows.Forms.Label
        Friend WithEvents lblTEX_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtCCT_ID As System.Windows.Forms.TextBox
        Public WithEvents chkTEC_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_IDx As System.Windows.Forms.Label
        Public WithEvents txtDTD_IDx As System.Windows.Forms.TextBox
        Public WithEvents txtCCT_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents dtpTEC_FECHA_EMI As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblTEX_FECHA_EMI As System.Windows.Forms.Label
        Public WithEvents txtTEC_SERIE As System.Windows.Forms.TextBox
        Friend WithEvents lblCorrelativox As System.Windows.Forms.Label
        Public WithEvents txtTEC_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION_CLIx As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_CLIx As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CLIx As System.Windows.Forms.TextBox
        Friend WithEvents lblTEC_MONTO As System.Windows.Forms.Label
        Public WithEvents txtTEC_MONTO As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_CLI As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_CLI As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CLI As System.Windows.Forms.TextBox

    End Class
End Namespace