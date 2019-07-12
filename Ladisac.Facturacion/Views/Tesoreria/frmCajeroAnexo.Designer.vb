Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCajeroAnexo
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
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.lblCAN_ESTADO = New System.Windows.Forms.Label()
            Me.txtCCC_ID = New System.Windows.Forms.TextBox()
            Me.chkCAN_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.txtCCC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkCCC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_CAJ = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO_CAJ = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID_CAJ = New System.Windows.Forms.Label()
            Me.txtPER_ID_CAJ = New System.Windows.Forms.TextBox()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(798, 28)
            Me.lblTitle.Text = "Caja - Cta. Banco asignada"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CAJ)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_CAJ)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CAJ)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CAJ)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkCCC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCAN_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCAN_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(727, 198)
            Me.pnCuerpo.TabIndex = 2
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(176, 26)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(429, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 3
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(611, 26)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 5
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(18, 26)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ID.TabIndex = 49
            Me.lblPVE_ID.Text = "Punto venta"
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_ID.Location = New System.Drawing.Point(119, 26)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtPVE_ID.TabIndex = 2
            '
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(18, 68)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(90, 13)
            Me.lblCCC_ID.TabIndex = 0
            Me.lblCCC_ID.Text = "Caja - Cta. Banco"
            '
            'lblCAN_ESTADO
            '
            Me.lblCAN_ESTADO.AutoSize = True
            Me.lblCAN_ESTADO.Location = New System.Drawing.Point(18, 150)
            Me.lblCAN_ESTADO.Name = "lblCAN_ESTADO"
            Me.lblCAN_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCAN_ESTADO.TabIndex = 4
            Me.lblCAN_ESTADO.Text = "Estado"
            '
            'txtCCC_ID
            '
            Me.txtCCC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_ID.Location = New System.Drawing.Point(119, 68)
            Me.txtCCC_ID.Name = "txtCCC_ID"
            Me.txtCCC_ID.Size = New System.Drawing.Size(51, 20)
            Me.txtCCC_ID.TabIndex = 1
            '
            'chkCAN_ESTADO
            '
            Me.chkCAN_ESTADO.AutoSize = True
            Me.chkCAN_ESTADO.Location = New System.Drawing.Point(119, 150)
            Me.chkCAN_ESTADO.Name = "chkCAN_ESTADO"
            Me.chkCAN_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCAN_ESTADO.TabIndex = 8
            Me.chkCAN_ESTADO.UseVisualStyleBackColor = True
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
            'txtCCC_DESCRIPCION
            '
            Me.txtCCC_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_DESCRIPCION.Enabled = False
            Me.txtCCC_DESCRIPCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCCC_DESCRIPCION.Location = New System.Drawing.Point(176, 68)
            Me.txtCCC_DESCRIPCION.Name = "txtCCC_DESCRIPCION"
            Me.txtCCC_DESCRIPCION.ReadOnly = True
            Me.txtCCC_DESCRIPCION.Size = New System.Drawing.Size(429, 20)
            Me.txtCCC_DESCRIPCION.TabIndex = 51
            '
            'chkCCC_ESTADO
            '
            Me.chkCCC_ESTADO.AutoSize = True
            Me.chkCCC_ESTADO.Enabled = False
            Me.chkCCC_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCCC_ESTADO.Location = New System.Drawing.Point(611, 68)
            Me.chkCCC_ESTADO.Name = "chkCCC_ESTADO"
            Me.chkCCC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCCC_ESTADO.TabIndex = 52
            Me.chkCCC_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_CAJ
            '
            Me.txtPER_DESCRIPCION_CAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_CAJ.Enabled = False
            Me.txtPER_DESCRIPCION_CAJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_CAJ.Location = New System.Drawing.Point(206, 110)
            Me.txtPER_DESCRIPCION_CAJ.Name = "txtPER_DESCRIPCION_CAJ"
            Me.txtPER_DESCRIPCION_CAJ.ReadOnly = True
            Me.txtPER_DESCRIPCION_CAJ.Size = New System.Drawing.Size(399, 20)
            Me.txtPER_DESCRIPCION_CAJ.TabIndex = 54
            '
            'chkPER_ESTADO_CAJ
            '
            Me.chkPER_ESTADO_CAJ.AutoSize = True
            Me.chkPER_ESTADO_CAJ.Enabled = False
            Me.chkPER_ESTADO_CAJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPER_ESTADO_CAJ.Location = New System.Drawing.Point(611, 110)
            Me.chkPER_ESTADO_CAJ.Name = "chkPER_ESTADO_CAJ"
            Me.chkPER_ESTADO_CAJ.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_CAJ.TabIndex = 55
            Me.chkPER_ESTADO_CAJ.UseVisualStyleBackColor = True
            '
            'lblPER_ID_CAJ
            '
            Me.lblPER_ID_CAJ.AutoSize = True
            Me.lblPER_ID_CAJ.Location = New System.Drawing.Point(18, 110)
            Me.lblPER_ID_CAJ.Name = "lblPER_ID_CAJ"
            Me.lblPER_ID_CAJ.Size = New System.Drawing.Size(37, 13)
            Me.lblPER_ID_CAJ.TabIndex = 56
            Me.lblPER_ID_CAJ.Text = "Cajero"
            '
            'txtPER_ID_CAJ
            '
            Me.txtPER_ID_CAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_CAJ.Location = New System.Drawing.Point(119, 110)
            Me.txtPER_ID_CAJ.Name = "txtPER_ID_CAJ"
            Me.txtPER_ID_CAJ.Size = New System.Drawing.Size(79, 20)
            Me.txtPER_ID_CAJ.TabIndex = 53
            '
            'frmCajeroAnexo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(798, 263)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.MinimumSize = New System.Drawing.Size(659, 297)
            Me.Name = "frmCajeroAnexo"
            Me.Text = "Caja - Cta. Banco asignada"
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
        Friend WithEvents lblCAN_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtCCC_ID As System.Windows.Forms.TextBox
        Public WithEvents chkCAN_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_CAJ As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO_CAJ As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_ID_CAJ As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CAJ As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkCCC_ESTADO As System.Windows.Forms.CheckBox

    End Class
End Namespace