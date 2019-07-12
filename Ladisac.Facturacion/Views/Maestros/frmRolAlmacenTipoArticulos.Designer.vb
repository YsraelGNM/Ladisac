Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolAlmacenTipoArticulos
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
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblTIP_ID = New System.Windows.Forms.Label()
            Me.lblALM_ID = New System.Windows.Forms.Label()
            Me.chkRAT_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkTIP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkALM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTIP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtALM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTIP_ID = New System.Windows.Forms.TextBox()
            Me.txtALM_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(707, 28)
            Me.lblTitle.Text = "Rol almacén - Tipo artículos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID)
            Me.pnCuerpo.Controls.Add(Me.chkRAT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTIP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkALM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(637, 107)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(7, 80)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblTIP_ID
            '
            Me.lblTIP_ID.AutoSize = True
            Me.lblTIP_ID.Location = New System.Drawing.Point(7, 47)
            Me.lblTIP_ID.Name = "lblTIP_ID"
            Me.lblTIP_ID.Size = New System.Drawing.Size(47, 13)
            Me.lblTIP_ID.TabIndex = 26
            Me.lblTIP_ID.Text = "Tipo Art."
            '
            'lblALM_ID
            '
            Me.lblALM_ID.AutoSize = True
            Me.lblALM_ID.Location = New System.Drawing.Point(7, 17)
            Me.lblALM_ID.Name = "lblALM_ID"
            Me.lblALM_ID.Size = New System.Drawing.Size(73, 13)
            Me.lblALM_ID.TabIndex = 25
            Me.lblALM_ID.Text = "Cód. Almacén"
            '
            'chkRAT_ESTADO
            '
            Me.chkRAT_ESTADO.AutoSize = True
            Me.chkRAT_ESTADO.Location = New System.Drawing.Point(86, 80)
            Me.chkRAT_ESTADO.Name = "chkRAT_ESTADO"
            Me.chkRAT_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkRAT_ESTADO.TabIndex = 20
            Me.chkRAT_ESTADO.UseVisualStyleBackColor = True
            '
            'chkTIP_ESTADO
            '
            Me.chkTIP_ESTADO.AutoSize = True
            Me.chkTIP_ESTADO.Enabled = False
            Me.chkTIP_ESTADO.Location = New System.Drawing.Point(550, 47)
            Me.chkTIP_ESTADO.Name = "chkTIP_ESTADO"
            Me.chkTIP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTIP_ESTADO.TabIndex = 8
            Me.chkTIP_ESTADO.UseVisualStyleBackColor = True
            '
            'chkALM_ESTADO
            '
            Me.chkALM_ESTADO.AutoSize = True
            Me.chkALM_ESTADO.Enabled = False
            Me.chkALM_ESTADO.Location = New System.Drawing.Point(550, 17)
            Me.chkALM_ESTADO.Name = "chkALM_ESTADO"
            Me.chkALM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO.TabIndex = 7
            Me.chkALM_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTIP_DESCRIPCION
            '
            Me.txtTIP_DESCRIPCION.Enabled = False
            Me.txtTIP_DESCRIPCION.Location = New System.Drawing.Point(126, 47)
            Me.txtTIP_DESCRIPCION.Name = "txtTIP_DESCRIPCION"
            Me.txtTIP_DESCRIPCION.ReadOnly = True
            Me.txtTIP_DESCRIPCION.Size = New System.Drawing.Size(418, 20)
            Me.txtTIP_DESCRIPCION.TabIndex = 6
            '
            'txtALM_DESCRIPCION
            '
            Me.txtALM_DESCRIPCION.Enabled = False
            Me.txtALM_DESCRIPCION.Location = New System.Drawing.Point(126, 17)
            Me.txtALM_DESCRIPCION.Name = "txtALM_DESCRIPCION"
            Me.txtALM_DESCRIPCION.ReadOnly = True
            Me.txtALM_DESCRIPCION.Size = New System.Drawing.Size(418, 20)
            Me.txtALM_DESCRIPCION.TabIndex = 5
            '
            'txtTIP_ID
            '
            Me.txtTIP_ID.Location = New System.Drawing.Point(86, 47)
            Me.txtTIP_ID.Name = "txtTIP_ID"
            Me.txtTIP_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTIP_ID.TabIndex = 4
            '
            'txtALM_ID
            '
            Me.txtALM_ID.Location = New System.Drawing.Point(86, 17)
            Me.txtALM_ID.Name = "txtALM_ID"
            Me.txtALM_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtALM_ID.TabIndex = 3
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(625, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmRolAlmacenTipoArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(707, 173)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmRolAlmacenTipoArticulos"
            Me.Text = "Rol almacén - Tipo artículos"
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
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblTIP_ID As System.Windows.Forms.Label
        Friend WithEvents lblALM_ID As System.Windows.Forms.Label
        Public WithEvents chkRAT_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkTIP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkALM_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTIP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtALM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTIP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtALM_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace