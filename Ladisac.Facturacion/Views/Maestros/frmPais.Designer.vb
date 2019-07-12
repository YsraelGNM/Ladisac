Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPais
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
            Me.lblPAI_ID = New System.Windows.Forms.Label()
            Me.lblPAI_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblPAI_ESTADO = New System.Windows.Forms.Label()
            Me.txtPAI_ID = New System.Windows.Forms.TextBox()
            Me.txtPAI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPAI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(659, 28)
            Me.lblTitle.Text = "País"
            Me.lblTitle.Visible = False
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkPAI_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(38, 58)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(580, 122)
            Me.pnCuerpo.TabIndex = 3
            '
            'lblPAI_ID
            '
            Me.lblPAI_ID.AutoSize = True
            Me.lblPAI_ID.Location = New System.Drawing.Point(11, 23)
            Me.lblPAI_ID.Name = "lblPAI_ID"
            Me.lblPAI_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblPAI_ID.TabIndex = 0
            Me.lblPAI_ID.Text = "Código"
            '
            'lblPAI_DESCRIPCION
            '
            Me.lblPAI_DESCRIPCION.AutoSize = True
            Me.lblPAI_DESCRIPCION.Location = New System.Drawing.Point(11, 55)
            Me.lblPAI_DESCRIPCION.Name = "lblPAI_DESCRIPCION"
            Me.lblPAI_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblPAI_DESCRIPCION.TabIndex = 1
            Me.lblPAI_DESCRIPCION.Text = "Descripción"
            '
            'lblPAI_ESTADO
            '
            Me.lblPAI_ESTADO.AutoSize = True
            Me.lblPAI_ESTADO.Location = New System.Drawing.Point(11, 92)
            Me.lblPAI_ESTADO.Name = "lblPAI_ESTADO"
            Me.lblPAI_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblPAI_ESTADO.TabIndex = 4
            Me.lblPAI_ESTADO.Text = "Estado"
            '
            'txtPAI_ID
            '
            Me.txtPAI_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPAI_ID.Location = New System.Drawing.Point(79, 23)
            Me.txtPAI_ID.Name = "txtPAI_ID"
            Me.txtPAI_ID.Size = New System.Drawing.Size(484, 20)
            Me.txtPAI_ID.TabIndex = 5
            '
            'txtPAI_DESCRIPCION
            '
            Me.txtPAI_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPAI_DESCRIPCION.Location = New System.Drawing.Point(79, 55)
            Me.txtPAI_DESCRIPCION.Name = "txtPAI_DESCRIPCION"
            Me.txtPAI_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtPAI_DESCRIPCION.TabIndex = 6
            '
            'chkPAI_ESTADO
            '
            Me.chkPAI_ESTADO.AutoSize = True
            Me.chkPAI_ESTADO.Location = New System.Drawing.Point(79, 92)
            Me.chkPAI_ESTADO.Name = "chkPAI_ESTADO"
            Me.chkPAI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPAI_ESTADO.TabIndex = 9
            Me.chkPAI_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(543, 7)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(75, 45)
            Me.btnImagen.TabIndex = 10
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmPais
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(659, 216)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPais"
            Me.Text = "País"
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
        Friend WithEvents lblPAI_ID As System.Windows.Forms.Label
        Friend WithEvents lblPAI_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblPAI_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPAI_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPAI_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkPAI_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace