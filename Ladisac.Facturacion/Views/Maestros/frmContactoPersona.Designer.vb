Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmContactoPersona
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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblCOP_EMAIL = New System.Windows.Forms.Label()
            Me.txtCOP_EMAIL = New System.Windows.Forms.TextBox()
            Me.lblCOP_DIRECCION = New System.Windows.Forms.Label()
            Me.txtCOP_DIRECCION = New System.Windows.Forms.TextBox()
            Me.lblCOP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.cboCOP_TIPO = New System.Windows.Forms.ComboBox()
            Me.lblCOP_TIPO = New System.Windows.Forms.Label()
            Me.lblCOP_ID = New System.Windows.Forms.Label()
            Me.txtCOP_ID = New System.Windows.Forms.TextBox()
            Me.txtCOP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblCOP_TELEFONO = New System.Windows.Forms.Label()
            Me.txtCOP_TELEFONO = New System.Windows.Forms.TextBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblCOP_ESTADO = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkCOP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(724, 28)
            Me.lblTitle.Text = "Contacto de persona"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCOP_EMAIL)
            Me.pnCuerpo.Controls.Add(Me.txtCOP_EMAIL)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.txtCOP_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.cboCOP_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCOP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCOP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_TELEFONO)
            Me.pnCuerpo.Controls.Add(Me.txtCOP_TELEFONO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCOP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkCOP_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(32, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(657, 260)
            Me.pnCuerpo.TabIndex = 13
            '
            'lblCOP_EMAIL
            '
            Me.lblCOP_EMAIL.AutoSize = True
            Me.lblCOP_EMAIL.Location = New System.Drawing.Point(11, 185)
            Me.lblCOP_EMAIL.Name = "lblCOP_EMAIL"
            Me.lblCOP_EMAIL.Size = New System.Drawing.Size(32, 13)
            Me.lblCOP_EMAIL.TabIndex = 26
            Me.lblCOP_EMAIL.Text = "Email"
            '
            'txtCOP_EMAIL
            '
            Me.txtCOP_EMAIL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOP_EMAIL.Location = New System.Drawing.Point(96, 185)
            Me.txtCOP_EMAIL.Name = "txtCOP_EMAIL"
            Me.txtCOP_EMAIL.Size = New System.Drawing.Size(543, 20)
            Me.txtCOP_EMAIL.TabIndex = 8
            '
            'lblCOP_DIRECCION
            '
            Me.lblCOP_DIRECCION.AutoSize = True
            Me.lblCOP_DIRECCION.Location = New System.Drawing.Point(11, 129)
            Me.lblCOP_DIRECCION.Name = "lblCOP_DIRECCION"
            Me.lblCOP_DIRECCION.Size = New System.Drawing.Size(68, 13)
            Me.lblCOP_DIRECCION.TabIndex = 24
            Me.lblCOP_DIRECCION.Text = "Dir. contacto"
            '
            'txtCOP_DIRECCION
            '
            Me.txtCOP_DIRECCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOP_DIRECCION.Location = New System.Drawing.Point(96, 129)
            Me.txtCOP_DIRECCION.Name = "txtCOP_DIRECCION"
            Me.txtCOP_DIRECCION.Size = New System.Drawing.Size(543, 20)
            Me.txtCOP_DIRECCION.TabIndex = 6
            '
            'lblCOP_DESCRIPCION
            '
            Me.lblCOP_DESCRIPCION.AutoSize = True
            Me.lblCOP_DESCRIPCION.Location = New System.Drawing.Point(11, 101)
            Me.lblCOP_DESCRIPCION.Name = "lblCOP_DESCRIPCION"
            Me.lblCOP_DESCRIPCION.Size = New System.Drawing.Size(77, 13)
            Me.lblCOP_DESCRIPCION.TabIndex = 22
            Me.lblCOP_DESCRIPCION.Text = "Nom. contacto"
            '
            'cboCOP_TIPO
            '
            Me.cboCOP_TIPO.FormattingEnabled = True
            Me.cboCOP_TIPO.Location = New System.Drawing.Point(96, 72)
            Me.cboCOP_TIPO.Name = "cboCOP_TIPO"
            Me.cboCOP_TIPO.Size = New System.Drawing.Size(138, 21)
            Me.cboCOP_TIPO.TabIndex = 4
            '
            'lblCOP_TIPO
            '
            Me.lblCOP_TIPO.AutoSize = True
            Me.lblCOP_TIPO.Location = New System.Drawing.Point(11, 72)
            Me.lblCOP_TIPO.Name = "lblCOP_TIPO"
            Me.lblCOP_TIPO.Size = New System.Drawing.Size(73, 13)
            Me.lblCOP_TIPO.TabIndex = 20
            Me.lblCOP_TIPO.Text = "Tipo contacto"
            '
            'lblCOP_ID
            '
            Me.lblCOP_ID.AutoSize = True
            Me.lblCOP_ID.Location = New System.Drawing.Point(11, 44)
            Me.lblCOP_ID.Name = "lblCOP_ID"
            Me.lblCOP_ID.Size = New System.Drawing.Size(74, 13)
            Me.lblCOP_ID.TabIndex = 16
            Me.lblCOP_ID.Text = "Cód. contacto"
            '
            'txtCOP_ID
            '
            Me.txtCOP_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOP_ID.Location = New System.Drawing.Point(96, 44)
            Me.txtCOP_ID.Name = "txtCOP_ID"
            Me.txtCOP_ID.Size = New System.Drawing.Size(61, 20)
            Me.txtCOP_ID.TabIndex = 3
            '
            'txtCOP_DESCRIPCION
            '
            Me.txtCOP_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOP_DESCRIPCION.Location = New System.Drawing.Point(96, 101)
            Me.txtCOP_DESCRIPCION.Name = "txtCOP_DESCRIPCION"
            Me.txtCOP_DESCRIPCION.Size = New System.Drawing.Size(543, 20)
            Me.txtCOP_DESCRIPCION.TabIndex = 5
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(556, 16)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 2
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblCOP_TELEFONO
            '
            Me.lblCOP_TELEFONO.AutoSize = True
            Me.lblCOP_TELEFONO.Location = New System.Drawing.Point(11, 157)
            Me.lblCOP_TELEFONO.Name = "lblCOP_TELEFONO"
            Me.lblCOP_TELEFONO.Size = New System.Drawing.Size(49, 13)
            Me.lblCOP_TELEFONO.TabIndex = 10
            Me.lblCOP_TELEFONO.Text = "Teléfono"
            '
            'txtCOP_TELEFONO
            '
            Me.txtCOP_TELEFONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOP_TELEFONO.Location = New System.Drawing.Point(96, 157)
            Me.txtCOP_TELEFONO.Name = "txtCOP_TELEFONO"
            Me.txtCOP_TELEFONO.Size = New System.Drawing.Size(543, 20)
            Me.txtCOP_TELEFONO.TabIndex = 7
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(11, 16)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(70, 13)
            Me.lblPER_ID.TabIndex = 0
            Me.lblPER_ID.Text = "Cód. persona"
            '
            'lblCOP_ESTADO
            '
            Me.lblCOP_ESTADO.AutoSize = True
            Me.lblCOP_ESTADO.Location = New System.Drawing.Point(11, 213)
            Me.lblCOP_ESTADO.Name = "lblCOP_ESTADO"
            Me.lblCOP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCOP_ESTADO.TabIndex = 4
            Me.lblCOP_ESTADO.Text = "Estado"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(96, 16)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(61, 20)
            Me.txtPER_ID.TabIndex = 0
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(174, 16)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(376, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 1
            '
            'chkCOP_ESTADO
            '
            Me.chkCOP_ESTADO.AutoSize = True
            Me.chkCOP_ESTADO.Location = New System.Drawing.Point(96, 213)
            Me.chkCOP_ESTADO.Name = "chkCOP_ESTADO"
            Me.chkCOP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCOP_ESTADO.TabIndex = 9
            Me.chkCOP_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(641, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(48, 28)
            Me.btnImagen.TabIndex = 13
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmContactoPersona
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(724, 317)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmContactoPersona"
            Me.Text = "Contacto de persona"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblCOP_TELEFONO As System.Windows.Forms.Label
        Public WithEvents txtCOP_TELEFONO As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblCOP_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkCOP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblCOP_TIPO As System.Windows.Forms.Label
        Friend WithEvents lblCOP_ID As System.Windows.Forms.Label
        Public WithEvents txtCOP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCOP_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblCOP_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblCOP_DIRECCION As System.Windows.Forms.Label
        Public WithEvents txtCOP_DIRECCION As System.Windows.Forms.TextBox
        Friend WithEvents lblCOP_EMAIL As System.Windows.Forms.Label
        Public WithEvents txtCOP_EMAIL As System.Windows.Forms.TextBox
        Public WithEvents cboCOP_TIPO As System.Windows.Forms.ComboBox
    End Class
End Namespace