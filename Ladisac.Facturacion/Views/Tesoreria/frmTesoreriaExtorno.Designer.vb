Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTesoreriaExtorno
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
            Me.lblTEX_FECHA_EMI = New System.Windows.Forms.Label()
            Me.dtpTEX_FECHA_EMI = New System.Windows.Forms.DateTimePicker()
            Me.lblCorrelativox = New System.Windows.Forms.Label()
            Me.txtTEX_SERIE = New System.Windows.Forms.TextBox()
            Me.txtTEX_NUMERO = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.lblDTD_IDx = New System.Windows.Forms.Label()
            Me.txtDTD_IDx = New System.Windows.Forms.TextBox()
            Me.txtCCC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.lblTEX_ESTADO = New System.Windows.Forms.Label()
            Me.txtCCC_ID = New System.Windows.Forms.TextBox()
            Me.chkTEX_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(798, 28)
            Me.lblTitle.Text = "Extorno de cheque"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTEX_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.dtpTEX_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.lblCorrelativox)
            Me.pnCuerpo.Controls.Add(Me.txtTEX_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtTEX_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.Label2)
            Me.pnCuerpo.Controls.Add(Me.Label1)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_IDx)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_IDx)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTEX_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.chkTEX_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(727, 203)
            Me.pnCuerpo.TabIndex = 2
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
            'dtpTEX_FECHA_EMI
            '
            Me.dtpTEX_FECHA_EMI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpTEX_FECHA_EMI.Location = New System.Drawing.Point(119, 13)
            Me.dtpTEX_FECHA_EMI.Name = "dtpTEX_FECHA_EMI"
            Me.dtpTEX_FECHA_EMI.Size = New System.Drawing.Size(85, 20)
            Me.dtpTEX_FECHA_EMI.TabIndex = 80
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
            'txtTEX_SERIE
            '
            Me.txtTEX_SERIE.Enabled = False
            Me.txtTEX_SERIE.Location = New System.Drawing.Point(119, 96)
            Me.txtTEX_SERIE.Name = "txtTEX_SERIE"
            Me.txtTEX_SERIE.ReadOnly = True
            Me.txtTEX_SERIE.Size = New System.Drawing.Size(51, 20)
            Me.txtTEX_SERIE.TabIndex = 88
            '
            'txtTEX_NUMERO
            '
            Me.txtTEX_NUMERO.Enabled = False
            Me.txtTEX_NUMERO.Location = New System.Drawing.Point(176, 96)
            Me.txtTEX_NUMERO.Name = "txtTEX_NUMERO"
            Me.txtTEX_NUMERO.ReadOnly = True
            Me.txtTEX_NUMERO.Size = New System.Drawing.Size(103, 20)
            Me.txtTEX_NUMERO.TabIndex = 86
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(18, 109)
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
            Me.lblDTD_IDx.Location = New System.Drawing.Point(18, 159)
            Me.lblDTD_IDx.Name = "lblDTD_IDx"
            Me.lblDTD_IDx.Size = New System.Drawing.Size(81, 13)
            Me.lblDTD_IDx.TabIndex = 56
            Me.lblDTD_IDx.Text = "Doc. a Extornar"
            Me.lblDTD_IDx.Visible = False
            '
            'txtDTD_IDx
            '
            Me.txtDTD_IDx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDTD_IDx.Location = New System.Drawing.Point(119, 159)
            Me.txtDTD_IDx.Name = "txtDTD_IDx"
            Me.txtDTD_IDx.ReadOnly = True
            Me.txtDTD_IDx.Size = New System.Drawing.Size(51, 20)
            Me.txtDTD_IDx.TabIndex = 53
            Me.txtDTD_IDx.Visible = False
            '
            'txtCCC_DESCRIPCION
            '
            Me.txtCCC_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_DESCRIPCION.Enabled = False
            Me.txtCCC_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCC_DESCRIPCION.Location = New System.Drawing.Point(176, 70)
            Me.txtCCC_DESCRIPCION.Name = "txtCCC_DESCRIPCION"
            Me.txtCCC_DESCRIPCION.ReadOnly = True
            Me.txtCCC_DESCRIPCION.Size = New System.Drawing.Size(544, 20)
            Me.txtCCC_DESCRIPCION.TabIndex = 51
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
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(18, 70)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(90, 13)
            Me.lblCCC_ID.TabIndex = 0
            Me.lblCCC_ID.Text = "Caja - Cta. Banco"
            '
            'lblTEX_ESTADO
            '
            Me.lblTEX_ESTADO.AutoSize = True
            Me.lblTEX_ESTADO.Location = New System.Drawing.Point(18, 131)
            Me.lblTEX_ESTADO.Name = "lblTEX_ESTADO"
            Me.lblTEX_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTEX_ESTADO.TabIndex = 4
            Me.lblTEX_ESTADO.Text = "Estado"
            '
            'txtCCC_ID
            '
            Me.txtCCC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_ID.Enabled = False
            Me.txtCCC_ID.Location = New System.Drawing.Point(119, 70)
            Me.txtCCC_ID.Name = "txtCCC_ID"
            Me.txtCCC_ID.ReadOnly = True
            Me.txtCCC_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtCCC_ID.TabIndex = 1
            '
            'chkTEX_ESTADO
            '
            Me.chkTEX_ESTADO.AutoSize = True
            Me.chkTEX_ESTADO.Location = New System.Drawing.Point(119, 131)
            Me.chkTEX_ESTADO.Name = "chkTEX_ESTADO"
            Me.chkTEX_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTEX_ESTADO.TabIndex = 8
            Me.chkTEX_ESTADO.UseVisualStyleBackColor = True
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
            'frmTesoreriaExtorno
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(798, 258)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmTesoreriaExtorno"
            Me.Text = "Extorno de cheque"
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
        Friend WithEvents lblCCC_ID As System.Windows.Forms.Label
        Friend WithEvents lblTEX_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtCCC_ID As System.Windows.Forms.TextBox
        Public WithEvents chkTEX_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_IDx As System.Windows.Forms.Label
        Public WithEvents txtDTD_IDx As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents dtpTEX_FECHA_EMI As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblTEX_FECHA_EMI As System.Windows.Forms.Label
        Public WithEvents txtTEX_SERIE As System.Windows.Forms.TextBox
        Friend WithEvents lblCorrelativox As System.Windows.Forms.Label
        Public WithEvents txtTEX_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class
End Namespace