Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMoneda
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
            Me.txtMON_SIMBOLO = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.lblMON_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblMON_SIMBOLO = New System.Windows.Forms.Label()
            Me.lblMON_ORIGEN = New System.Windows.Forms.Label()
            Me.lblMON_ESTADO = New System.Windows.Forms.Label()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkMON_ORIGEN = New System.Windows.Forms.CheckBox()
            Me.chkMON_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(651, 28)
            Me.lblTitle.Text = "Moneda"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ORIGEN)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ORIGEN)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(580, 198)
            Me.pnCuerpo.TabIndex = 2
            '
            'txtMON_SIMBOLO
            '
            Me.txtMON_SIMBOLO.Location = New System.Drawing.Point(79, 100)
            Me.txtMON_SIMBOLO.Name = "txtMON_SIMBOLO"
            Me.txtMON_SIMBOLO.Size = New System.Drawing.Size(488, 20)
            Me.txtMON_SIMBOLO.TabIndex = 7
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(13, 38)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblMON_ID.TabIndex = 0
            Me.lblMON_ID.Text = "Código"
            '
            'lblMON_DESCRIPCION
            '
            Me.lblMON_DESCRIPCION.AutoSize = True
            Me.lblMON_DESCRIPCION.Location = New System.Drawing.Point(13, 70)
            Me.lblMON_DESCRIPCION.Name = "lblMON_DESCRIPCION"
            Me.lblMON_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblMON_DESCRIPCION.TabIndex = 1
            Me.lblMON_DESCRIPCION.Text = "Descripción"
            '
            'lblMON_SIMBOLO
            '
            Me.lblMON_SIMBOLO.AutoSize = True
            Me.lblMON_SIMBOLO.Location = New System.Drawing.Point(13, 100)
            Me.lblMON_SIMBOLO.Name = "lblMON_SIMBOLO"
            Me.lblMON_SIMBOLO.Size = New System.Drawing.Size(44, 13)
            Me.lblMON_SIMBOLO.TabIndex = 2
            Me.lblMON_SIMBOLO.Text = "Simbolo"
            '
            'lblMON_ORIGEN
            '
            Me.lblMON_ORIGEN.AutoSize = True
            Me.lblMON_ORIGEN.Location = New System.Drawing.Point(13, 126)
            Me.lblMON_ORIGEN.Name = "lblMON_ORIGEN"
            Me.lblMON_ORIGEN.Size = New System.Drawing.Size(38, 13)
            Me.lblMON_ORIGEN.TabIndex = 3
            Me.lblMON_ORIGEN.Text = "Origen"
            '
            'lblMON_ESTADO
            '
            Me.lblMON_ESTADO.AutoSize = True
            Me.lblMON_ESTADO.Location = New System.Drawing.Point(13, 151)
            Me.lblMON_ESTADO.Name = "lblMON_ESTADO"
            Me.lblMON_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblMON_ESTADO.TabIndex = 4
            Me.lblMON_ESTADO.Text = "Estado"
            '
            'txtMON_ID
            '
            Me.txtMON_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_ID.Location = New System.Drawing.Point(79, 38)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(488, 20)
            Me.txtMON_ID.TabIndex = 5
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(79, 70)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(488, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 6
            '
            'chkMON_ORIGEN
            '
            Me.chkMON_ORIGEN.AutoSize = True
            Me.chkMON_ORIGEN.Location = New System.Drawing.Point(79, 126)
            Me.chkMON_ORIGEN.Name = "chkMON_ORIGEN"
            Me.chkMON_ORIGEN.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ORIGEN.TabIndex = 8
            Me.chkMON_ORIGEN.UseVisualStyleBackColor = True
            '
            'chkMON_ESTADO
            '
            Me.chkMON_ESTADO.AutoSize = True
            Me.chkMON_ESTADO.Location = New System.Drawing.Point(79, 151)
            Me.chkMON_ESTADO.Name = "chkMON_ESTADO"
            Me.chkMON_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO.TabIndex = 9
            Me.chkMON_ESTADO.UseVisualStyleBackColor = True
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
            'frmMoneda
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(651, 263)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmMoneda"
            Me.Text = "Moneda"
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
        Public WithEvents txtMON_SIMBOLO As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Friend WithEvents lblMON_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblMON_SIMBOLO As System.Windows.Forms.Label
        Friend WithEvents lblMON_ORIGEN As System.Windows.Forms.Label
        Friend WithEvents lblMON_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkMON_ORIGEN As System.Windows.Forms.CheckBox
        Public WithEvents chkMON_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button

    End Class
End Namespace