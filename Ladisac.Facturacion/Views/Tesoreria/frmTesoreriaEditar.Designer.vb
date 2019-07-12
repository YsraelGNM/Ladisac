Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTesoreriaEditar
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
            Me.txtUSU_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblUSU_ESTADO = New System.Windows.Forms.Label()
            Me.chkUSU_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblUSU_ID = New System.Windows.Forms.Label()
            Me.txtUSU_ID = New System.Windows.Forms.TextBox()
            Me.cboUSU_TIPO = New System.Windows.Forms.ComboBox()
            Me.lblTEE_NO_CAJERO = New System.Windows.Forms.Label()
            Me.chkTEE_NO_CAJERO = New System.Windows.Forms.CheckBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.lblTES_FECHA_EMI = New System.Windows.Forms.Label()
            Me.lblTEE_ESTADO = New System.Windows.Forms.Label()
            Me.txtTEE_USU_ID = New System.Windows.Forms.TextBox()
            Me.chkTES_FECHA_EMI = New System.Windows.Forms.CheckBox()
            Me.chkTEE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(643, 28)
            Me.lblTitle.Text = "Permiso tesorería"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtUSU_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblUSU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkUSU_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.txtUSU_ID)
            Me.pnCuerpo.Controls.Add(Me.cboUSU_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblTEE_NO_CAJERO)
            Me.pnCuerpo.Controls.Add(Me.chkTEE_NO_CAJERO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTES_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.lblTEE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTEE_USU_ID)
            Me.pnCuerpo.Controls.Add(Me.chkTES_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.chkTEE_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(572, 198)
            Me.pnCuerpo.TabIndex = 2
            '
            'txtUSU_DESCRIPCION
            '
            Me.txtUSU_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtUSU_DESCRIPCION.Enabled = False
            Me.txtUSU_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtUSU_DESCRIPCION.Location = New System.Drawing.Point(60, 57)
            Me.txtUSU_DESCRIPCION.Name = "txtUSU_DESCRIPCION"
            Me.txtUSU_DESCRIPCION.ReadOnly = True
            Me.txtUSU_DESCRIPCION.Size = New System.Drawing.Size(493, 20)
            Me.txtUSU_DESCRIPCION.TabIndex = 3
            '
            'lblUSU_ESTADO
            '
            Me.lblUSU_ESTADO.AutoSize = True
            Me.lblUSU_ESTADO.Location = New System.Drawing.Point(197, 83)
            Me.lblUSU_ESTADO.Name = "lblUSU_ESTADO"
            Me.lblUSU_ESTADO.Size = New System.Drawing.Size(64, 13)
            Me.lblUSU_ESTADO.TabIndex = 50
            Me.lblUSU_ESTADO.Text = "Est. Usuario"
            '
            'chkUSU_ESTADO
            '
            Me.chkUSU_ESTADO.AutoSize = True
            Me.chkUSU_ESTADO.Enabled = False
            Me.chkUSU_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUSU_ESTADO.Location = New System.Drawing.Point(261, 83)
            Me.chkUSU_ESTADO.Name = "chkUSU_ESTADO"
            Me.chkUSU_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkUSU_ESTADO.TabIndex = 5
            Me.chkUSU_ESTADO.UseVisualStyleBackColor = True
            '
            'lblUSU_ID
            '
            Me.lblUSU_ID.AutoSize = True
            Me.lblUSU_ID.Location = New System.Drawing.Point(13, 57)
            Me.lblUSU_ID.Name = "lblUSU_ID"
            Me.lblUSU_ID.Size = New System.Drawing.Size(43, 13)
            Me.lblUSU_ID.TabIndex = 49
            Me.lblUSU_ID.Text = "Usuario"
            '
            'txtUSU_ID
            '
            Me.txtUSU_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtUSU_ID.Location = New System.Drawing.Point(60, 57)
            Me.txtUSU_ID.Name = "txtUSU_ID"
            Me.txtUSU_ID.Size = New System.Drawing.Size(120, 20)
            Me.txtUSU_ID.TabIndex = 2
            '
            'cboUSU_TIPO
            '
            Me.cboUSU_TIPO.Enabled = False
            Me.cboUSU_TIPO.FormattingEnabled = True
            Me.cboUSU_TIPO.Location = New System.Drawing.Point(60, 83)
            Me.cboUSU_TIPO.Name = "cboUSU_TIPO"
            Me.cboUSU_TIPO.Size = New System.Drawing.Size(120, 21)
            Me.cboUSU_TIPO.TabIndex = 4
            '
            'lblTEE_NO_CAJERO
            '
            Me.lblTEE_NO_CAJERO.AutoSize = True
            Me.lblTEE_NO_CAJERO.Location = New System.Drawing.Point(306, 119)
            Me.lblTEE_NO_CAJERO.Name = "lblTEE_NO_CAJERO"
            Me.lblTEE_NO_CAJERO.Size = New System.Drawing.Size(151, 13)
            Me.lblTEE_NO_CAJERO.TabIndex = 12
            Me.lblTEE_NO_CAJERO.Text = "Editar sin ser cajero propietario"
            '
            'chkTEE_NO_CAJERO
            '
            Me.chkTEE_NO_CAJERO.AutoSize = True
            Me.chkTEE_NO_CAJERO.Location = New System.Drawing.Point(463, 119)
            Me.chkTEE_NO_CAJERO.Name = "chkTEE_NO_CAJERO"
            Me.chkTEE_NO_CAJERO.Size = New System.Drawing.Size(15, 14)
            Me.chkTEE_NO_CAJERO.TabIndex = 7
            Me.chkTEE_NO_CAJERO.UseVisualStyleBackColor = True
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(13, 20)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(106, 13)
            Me.lblMON_ID.TabIndex = 0
            Me.lblMON_ID.Text = "Cód. Permiso usuario"
            '
            'lblTES_FECHA_EMI
            '
            Me.lblTES_FECHA_EMI.AutoSize = True
            Me.lblTES_FECHA_EMI.Location = New System.Drawing.Point(13, 119)
            Me.lblTES_FECHA_EMI.Name = "lblTES_FECHA_EMI"
            Me.lblTES_FECHA_EMI.Size = New System.Drawing.Size(117, 13)
            Me.lblTES_FECHA_EMI.TabIndex = 3
            Me.lblTES_FECHA_EMI.Text = "Editar fecha de emisión"
            '
            'lblTEE_ESTADO
            '
            Me.lblTEE_ESTADO.AutoSize = True
            Me.lblTEE_ESTADO.Location = New System.Drawing.Point(13, 160)
            Me.lblTEE_ESTADO.Name = "lblTEE_ESTADO"
            Me.lblTEE_ESTADO.Size = New System.Drawing.Size(109, 13)
            Me.lblTEE_ESTADO.TabIndex = 4
            Me.lblTEE_ESTADO.Text = "Est. permiso tesorería"
            '
            'txtTEE_USU_ID
            '
            Me.txtTEE_USU_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTEE_USU_ID.Location = New System.Drawing.Point(129, 20)
            Me.txtTEE_USU_ID.Name = "txtTEE_USU_ID"
            Me.txtTEE_USU_ID.Size = New System.Drawing.Size(147, 20)
            Me.txtTEE_USU_ID.TabIndex = 1
            '
            'chkTES_FECHA_EMI
            '
            Me.chkTES_FECHA_EMI.AutoSize = True
            Me.chkTES_FECHA_EMI.Location = New System.Drawing.Point(136, 119)
            Me.chkTES_FECHA_EMI.Name = "chkTES_FECHA_EMI"
            Me.chkTES_FECHA_EMI.Size = New System.Drawing.Size(15, 14)
            Me.chkTES_FECHA_EMI.TabIndex = 6
            Me.chkTES_FECHA_EMI.UseVisualStyleBackColor = True
            '
            'chkTEE_ESTADO
            '
            Me.chkTEE_ESTADO.AutoSize = True
            Me.chkTEE_ESTADO.Location = New System.Drawing.Point(135, 160)
            Me.chkTEE_ESTADO.Name = "chkTEE_ESTADO"
            Me.chkTEE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTEE_ESTADO.TabIndex = 8
            Me.chkTEE_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(565, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(50, 28)
            Me.btnImagen.TabIndex = 3
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmTesoreriaEditar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(643, 263)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmTesoreriaEditar"
            Me.Text = "Permiso tesorería"
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
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Friend WithEvents lblTES_FECHA_EMI As System.Windows.Forms.Label
        Friend WithEvents lblTEE_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtTEE_USU_ID As System.Windows.Forms.TextBox
        Public WithEvents chkTES_FECHA_EMI As System.Windows.Forms.CheckBox
        Public WithEvents chkTEE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblTEE_NO_CAJERO As System.Windows.Forms.Label
        Public WithEvents chkTEE_NO_CAJERO As System.Windows.Forms.CheckBox
        Friend WithEvents lblUSU_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkUSU_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblUSU_ID As System.Windows.Forms.Label
        Public WithEvents txtUSU_ID As System.Windows.Forms.TextBox
        Public WithEvents txtUSU_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents cboUSU_TIPO As System.Windows.Forms.ComboBox

    End Class
End Namespace