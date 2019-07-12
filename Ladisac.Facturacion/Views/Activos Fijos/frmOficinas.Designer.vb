Namespace Ladisac.ActivosFijos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmOficinas
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
            Me.lblOFI_ESTADO = New System.Windows.Forms.Label()
            Me.lblEDI_ID = New System.Windows.Forms.Label()
            Me.lblOFI_ID = New System.Windows.Forms.Label()
            Me.chkEDI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkOFI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtEDI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtOFI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtEDI_ID = New System.Windows.Forms.TextBox()
            Me.txtOFI_ID = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(780, 28)
            Me.lblTitle.Text = "Oficinas"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblOFI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblEDI_ID)
            Me.pnCuerpo.Controls.Add(Me.lblOFI_ID)
            Me.pnCuerpo.Controls.Add(Me.chkEDI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkOFI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtEDI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtOFI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtEDI_ID)
            Me.pnCuerpo.Controls.Add(Me.txtOFI_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(714, 129)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblOFI_ESTADO
            '
            Me.lblOFI_ESTADO.AutoSize = True
            Me.lblOFI_ESTADO.Location = New System.Drawing.Point(28, 94)
            Me.lblOFI_ESTADO.Name = "lblOFI_ESTADO"
            Me.lblOFI_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblOFI_ESTADO.TabIndex = 36
            Me.lblOFI_ESTADO.Text = "Estado"
            '
            'lblEDI_ID
            '
            Me.lblEDI_ID.AutoSize = True
            Me.lblEDI_ID.Location = New System.Drawing.Point(27, 54)
            Me.lblEDI_ID.Name = "lblEDI_ID"
            Me.lblEDI_ID.Size = New System.Drawing.Size(41, 13)
            Me.lblEDI_ID.TabIndex = 26
            Me.lblEDI_ID.Text = "Edificio"
            '
            'lblOFI_ID
            '
            Me.lblOFI_ID.AutoSize = True
            Me.lblOFI_ID.Location = New System.Drawing.Point(27, 17)
            Me.lblOFI_ID.Name = "lblOFI_ID"
            Me.lblOFI_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblOFI_ID.TabIndex = 25
            Me.lblOFI_ID.Text = "Oficina"
            '
            'chkEDI_ESTADO
            '
            Me.chkEDI_ESTADO.AutoSize = True
            Me.chkEDI_ESTADO.Enabled = False
            Me.chkEDI_ESTADO.Location = New System.Drawing.Point(610, 53)
            Me.chkEDI_ESTADO.Name = "chkEDI_ESTADO"
            Me.chkEDI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkEDI_ESTADO.TabIndex = 8
            Me.chkEDI_ESTADO.UseVisualStyleBackColor = True
            '
            'chkOFI_ESTADO
            '
            Me.chkOFI_ESTADO.AutoSize = True
            Me.chkOFI_ESTADO.Location = New System.Drawing.Point(79, 94)
            Me.chkOFI_ESTADO.Name = "chkOFI_ESTADO"
            Me.chkOFI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkOFI_ESTADO.TabIndex = 7
            Me.chkOFI_ESTADO.UseVisualStyleBackColor = True
            '
            'txtEDI_DESCRIPCION
            '
            Me.txtEDI_DESCRIPCION.Enabled = False
            Me.txtEDI_DESCRIPCION.Location = New System.Drawing.Point(119, 54)
            Me.txtEDI_DESCRIPCION.Name = "txtEDI_DESCRIPCION"
            Me.txtEDI_DESCRIPCION.ReadOnly = True
            Me.txtEDI_DESCRIPCION.Size = New System.Drawing.Size(485, 20)
            Me.txtEDI_DESCRIPCION.TabIndex = 6
            '
            'txtOFI_DESCRIPCION
            '
            Me.txtOFI_DESCRIPCION.Location = New System.Drawing.Point(119, 17)
            Me.txtOFI_DESCRIPCION.Name = "txtOFI_DESCRIPCION"
            Me.txtOFI_DESCRIPCION.Size = New System.Drawing.Size(485, 20)
            Me.txtOFI_DESCRIPCION.TabIndex = 5
            '
            'txtEDI_ID
            '
            Me.txtEDI_ID.Location = New System.Drawing.Point(79, 54)
            Me.txtEDI_ID.Name = "txtEDI_ID"
            Me.txtEDI_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtEDI_ID.TabIndex = 4
            '
            'txtOFI_ID
            '
            Me.txtOFI_ID.Location = New System.Drawing.Point(79, 17)
            Me.txtOFI_ID.Name = "txtOFI_ID"
            Me.txtOFI_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtOFI_ID.TabIndex = 3
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(700, -2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmOficinas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(780, 187)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmOficinas"
            Me.Text = "Oficinas"
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
        Friend WithEvents lblOFI_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblEDI_ID As System.Windows.Forms.Label
        Friend WithEvents lblOFI_ID As System.Windows.Forms.Label
        Public WithEvents chkEDI_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkOFI_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtEDI_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtOFI_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtEDI_ID As System.Windows.Forms.TextBox
        Public WithEvents txtOFI_ID As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace