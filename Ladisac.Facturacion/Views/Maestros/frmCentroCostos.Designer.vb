Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCentroCostos
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
            Me.txtCCO_CUC_ID = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.lblMON_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblCCO_CUC_ID = New System.Windows.Forms.Label()
            Me.lblCCO_NIVEL = New System.Windows.Forms.Label()
            Me.lblMON_ESTADO = New System.Windows.Forms.Label()
            Me.txtCCO_ID = New System.Windows.Forms.TextBox()
            Me.txtCCO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkCCO_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.txtCCO_NIVEL = New System.Windows.Forms.TextBox()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(749, 28)
            Me.lblTitle.Text = "Centro de costos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtCCO_NIVEL)
            Me.pnCuerpo.Controls.Add(Me.txtCCO_CUC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblCCO_CUC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCO_NIVEL)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCCO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkCCO_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(678, 198)
            Me.pnCuerpo.TabIndex = 2
            '
            'txtCCO_CUC_ID
            '
            Me.txtCCO_CUC_ID.Location = New System.Drawing.Point(104, 90)
            Me.txtCCO_CUC_ID.Name = "txtCCO_CUC_ID"
            Me.txtCCO_CUC_ID.Size = New System.Drawing.Size(555, 20)
            Me.txtCCO_CUC_ID.TabIndex = 7
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(13, 23)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblMON_ID.TabIndex = 0
            Me.lblMON_ID.Text = "Código"
            '
            'lblMON_DESCRIPCION
            '
            Me.lblMON_DESCRIPCION.AutoSize = True
            Me.lblMON_DESCRIPCION.Location = New System.Drawing.Point(13, 57)
            Me.lblMON_DESCRIPCION.Name = "lblMON_DESCRIPCION"
            Me.lblMON_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblMON_DESCRIPCION.TabIndex = 1
            Me.lblMON_DESCRIPCION.Text = "Descripción"
            '
            'lblCCO_CUC_ID
            '
            Me.lblCCO_CUC_ID.AutoSize = True
            Me.lblCCO_CUC_ID.Location = New System.Drawing.Point(13, 90)
            Me.lblCCO_CUC_ID.Name = "lblCCO_CUC_ID"
            Me.lblCCO_CUC_ID.Size = New System.Drawing.Size(85, 13)
            Me.lblCCO_CUC_ID.TabIndex = 2
            Me.lblCCO_CUC_ID.Text = "Cuenta contable"
            '
            'lblCCO_NIVEL
            '
            Me.lblCCO_NIVEL.AutoSize = True
            Me.lblCCO_NIVEL.Location = New System.Drawing.Point(13, 124)
            Me.lblCCO_NIVEL.Name = "lblCCO_NIVEL"
            Me.lblCCO_NIVEL.Size = New System.Drawing.Size(31, 13)
            Me.lblCCO_NIVEL.TabIndex = 3
            Me.lblCCO_NIVEL.Text = "Nivel"
            '
            'lblMON_ESTADO
            '
            Me.lblMON_ESTADO.AutoSize = True
            Me.lblMON_ESTADO.Location = New System.Drawing.Point(13, 158)
            Me.lblMON_ESTADO.Name = "lblMON_ESTADO"
            Me.lblMON_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblMON_ESTADO.TabIndex = 4
            Me.lblMON_ESTADO.Text = "Estado"
            '
            'txtCCO_ID
            '
            Me.txtCCO_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCO_ID.Location = New System.Drawing.Point(104, 23)
            Me.txtCCO_ID.Name = "txtCCO_ID"
            Me.txtCCO_ID.Size = New System.Drawing.Size(555, 20)
            Me.txtCCO_ID.TabIndex = 5
            '
            'txtCCO_DESCRIPCION
            '
            Me.txtCCO_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCO_DESCRIPCION.Location = New System.Drawing.Point(104, 57)
            Me.txtCCO_DESCRIPCION.Name = "txtCCO_DESCRIPCION"
            Me.txtCCO_DESCRIPCION.Size = New System.Drawing.Size(555, 20)
            Me.txtCCO_DESCRIPCION.TabIndex = 6
            '
            'chkCCO_ESTADO
            '
            Me.chkCCO_ESTADO.AutoSize = True
            Me.chkCCO_ESTADO.Location = New System.Drawing.Point(104, 158)
            Me.chkCCO_ESTADO.Name = "chkCCO_ESTADO"
            Me.chkCCO_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCCO_ESTADO.TabIndex = 9
            Me.chkCCO_ESTADO.UseVisualStyleBackColor = True
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
            'txtCCO_NIVEL
            '
            Me.txtCCO_NIVEL.Location = New System.Drawing.Point(104, 124)
            Me.txtCCO_NIVEL.Name = "txtCCO_NIVEL"
            Me.txtCCO_NIVEL.Size = New System.Drawing.Size(555, 20)
            Me.txtCCO_NIVEL.TabIndex = 10
            '
            'frmCentroCostos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(749, 263)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmCentroCostos"
            Me.Text = "Centro de costos"
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
        Public WithEvents txtCCO_CUC_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Friend WithEvents lblMON_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblCCO_CUC_ID As System.Windows.Forms.Label
        Friend WithEvents lblCCO_NIVEL As System.Windows.Forms.Label
        Friend WithEvents lblMON_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtCCO_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCCO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkCCO_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents txtCCO_NIVEL As System.Windows.Forms.TextBox

    End Class
End Namespace