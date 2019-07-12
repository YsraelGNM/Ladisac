Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDocPersonas
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
            Me.lblTDP_ESTADO = New System.Windows.Forms.Label()
            Me.chkTDP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblTDP_ID = New System.Windows.Forms.Label()
            Me.lblTDP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtTDP_ID = New System.Windows.Forms.TextBox()
            Me.txtTDP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPER_ESTADO = New System.Windows.Forms.Label()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDOP_NUMERO = New System.Windows.Forms.Label()
            Me.txtDOP_NUMERO = New System.Windows.Forms.TextBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblPER_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblDOP_ESTADO = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkDOP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(556, 28)
            Me.lblTitle.Text = "Documentos de personas"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTDP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDOP_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.txtDOP_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDOP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkDOP_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(32, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(489, 220)
            Me.pnCuerpo.TabIndex = 13
            '
            'lblTDP_ESTADO
            '
            Me.lblTDP_ESTADO.AutoSize = True
            Me.lblTDP_ESTADO.Location = New System.Drawing.Point(11, 143)
            Me.lblTDP_ESTADO.Name = "lblTDP_ESTADO"
            Me.lblTDP_ESTADO.Size = New System.Drawing.Size(72, 13)
            Me.lblTDP_ESTADO.TabIndex = 20
            Me.lblTDP_ESTADO.Text = "Est. Tip. Doc."
            '
            'chkTDP_ESTADO
            '
            Me.chkTDP_ESTADO.AutoSize = True
            Me.chkTDP_ESTADO.Enabled = False
            Me.chkTDP_ESTADO.Location = New System.Drawing.Point(96, 143)
            Me.chkTDP_ESTADO.Name = "chkTDP_ESTADO"
            Me.chkTDP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTDP_ESTADO.TabIndex = 5
            Me.chkTDP_ESTADO.UseVisualStyleBackColor = True
            '
            'lblTDP_ID
            '
            Me.lblTDP_ID.AutoSize = True
            Me.lblTDP_ID.Location = New System.Drawing.Point(11, 91)
            Me.lblTDP_ID.Name = "lblTDP_ID"
            Me.lblTDP_ID.Size = New System.Drawing.Size(76, 13)
            Me.lblTDP_ID.TabIndex = 16
            Me.lblTDP_ID.Text = "Cód. Tip. Doc."
            '
            'lblTDP_DESCRIPCION
            '
            Me.lblTDP_DESCRIPCION.AutoSize = True
            Me.lblTDP_DESCRIPCION.Location = New System.Drawing.Point(11, 117)
            Me.lblTDP_DESCRIPCION.Name = "lblTDP_DESCRIPCION"
            Me.lblTDP_DESCRIPCION.Size = New System.Drawing.Size(82, 13)
            Me.lblTDP_DESCRIPCION.TabIndex = 17
            Me.lblTDP_DESCRIPCION.Text = "Desc. Tip. Doc."
            '
            'txtTDP_ID
            '
            Me.txtTDP_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_ID.Location = New System.Drawing.Point(96, 91)
            Me.txtTDP_ID.Name = "txtTDP_ID"
            Me.txtTDP_ID.Size = New System.Drawing.Size(61, 20)
            Me.txtTDP_ID.TabIndex = 3
            '
            'txtTDP_DESCRIPCION
            '
            Me.txtTDP_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_DESCRIPCION.Enabled = False
            Me.txtTDP_DESCRIPCION.Location = New System.Drawing.Point(96, 117)
            Me.txtTDP_DESCRIPCION.Name = "txtTDP_DESCRIPCION"
            Me.txtTDP_DESCRIPCION.ReadOnly = True
            Me.txtTDP_DESCRIPCION.Size = New System.Drawing.Size(376, 20)
            Me.txtTDP_DESCRIPCION.TabIndex = 4
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(11, 69)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(67, 13)
            Me.lblPER_ESTADO.TabIndex = 14
            Me.lblPER_ESTADO.Text = "Est. Persona"
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(96, 69)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 2
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDOP_NUMERO
            '
            Me.lblDOP_NUMERO.AutoSize = True
            Me.lblDOP_NUMERO.Location = New System.Drawing.Point(11, 166)
            Me.lblDOP_NUMERO.Name = "lblDOP_NUMERO"
            Me.lblDOP_NUMERO.Size = New System.Drawing.Size(44, 13)
            Me.lblDOP_NUMERO.TabIndex = 10
            Me.lblDOP_NUMERO.Text = "Número"
            '
            'txtDOP_NUMERO
            '
            Me.txtDOP_NUMERO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDOP_NUMERO.Location = New System.Drawing.Point(96, 166)
            Me.txtDOP_NUMERO.Name = "txtDOP_NUMERO"
            Me.txtDOP_NUMERO.Size = New System.Drawing.Size(61, 20)
            Me.txtDOP_NUMERO.TabIndex = 6
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(11, 17)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(71, 13)
            Me.lblPER_ID.TabIndex = 0
            Me.lblPER_ID.Text = "Cód. Persona"
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(11, 43)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(77, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 1
            Me.lblPER_DESCRIPCION.Text = "Desc. Persona"
            '
            'lblDOP_ESTADO
            '
            Me.lblDOP_ESTADO.AutoSize = True
            Me.lblDOP_ESTADO.Location = New System.Drawing.Point(11, 192)
            Me.lblDOP_ESTADO.Name = "lblDOP_ESTADO"
            Me.lblDOP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDOP_ESTADO.TabIndex = 4
            Me.lblDOP_ESTADO.Text = "Estado"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(96, 17)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(61, 20)
            Me.txtPER_ID.TabIndex = 0
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(96, 43)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(376, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 1
            '
            'chkDOP_ESTADO
            '
            Me.chkDOP_ESTADO.AutoSize = True
            Me.chkDOP_ESTADO.Location = New System.Drawing.Point(96, 192)
            Me.chkDOP_ESTADO.Name = "chkDOP_ESTADO"
            Me.chkDOP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDOP_ESTADO.TabIndex = 7
            Me.chkDOP_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(473, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(48, 28)
            Me.btnImagen.TabIndex = 13
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDocPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(556, 277)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmDocPersonas"
            Me.Text = "Documentos de personas"
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
        Friend WithEvents lblDOP_NUMERO As System.Windows.Forms.Label
        Public WithEvents txtDOP_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblDOP_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkDOP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblPER_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTDP_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkTDP_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTDP_ID As System.Windows.Forms.Label
        Friend WithEvents lblTDP_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtTDP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTDP_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace