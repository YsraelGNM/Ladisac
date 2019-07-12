Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolArticulosTipoArticulos
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
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblTIP_ID = New System.Windows.Forms.Label()
            Me.lblART_ID = New System.Windows.Forms.Label()
            Me.chkRAR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkTIP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkART_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTIP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtART_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTIP_ID = New System.Windows.Forms.TextBox()
            Me.txtART_ID = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(696, 28)
            Me.lblTitle.Text = "Rol artículos - Tipo artículos"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(614, 4)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            Me.pnCuerpo.Controls.Add(Me.lblART_ID)
            Me.pnCuerpo.Controls.Add(Me.chkRAR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTIP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkART_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtART_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtART_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(30, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(629, 115)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(20, 73)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblTIP_ID
            '
            Me.lblTIP_ID.AutoSize = True
            Me.lblTIP_ID.Location = New System.Drawing.Point(20, 47)
            Me.lblTIP_ID.Name = "lblTIP_ID"
            Me.lblTIP_ID.Size = New System.Drawing.Size(67, 13)
            Me.lblTIP_ID.TabIndex = 26
            Me.lblTIP_ID.Text = "Tipo artículo"
            '
            'lblART_ID
            '
            Me.lblART_ID.AutoSize = True
            Me.lblART_ID.Location = New System.Drawing.Point(20, 23)
            Me.lblART_ID.Name = "lblART_ID"
            Me.lblART_ID.Size = New System.Drawing.Size(69, 13)
            Me.lblART_ID.TabIndex = 25
            Me.lblART_ID.Text = "Cód. Artículo"
            '
            'chkRAR_ESTADO
            '
            Me.chkRAR_ESTADO.AutoSize = True
            Me.chkRAR_ESTADO.Location = New System.Drawing.Point(92, 73)
            Me.chkRAR_ESTADO.Name = "chkRAR_ESTADO"
            Me.chkRAR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkRAR_ESTADO.TabIndex = 7
            Me.chkRAR_ESTADO.UseVisualStyleBackColor = True
            '
            'chkTIP_ESTADO
            '
            Me.chkTIP_ESTADO.AutoSize = True
            Me.chkTIP_ESTADO.Enabled = False
            Me.chkTIP_ESTADO.Location = New System.Drawing.Point(543, 47)
            Me.chkTIP_ESTADO.Name = "chkTIP_ESTADO"
            Me.chkTIP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTIP_ESTADO.TabIndex = 6
            Me.chkTIP_ESTADO.UseVisualStyleBackColor = True
            '
            'chkART_ESTADO
            '
            Me.chkART_ESTADO.AutoSize = True
            Me.chkART_ESTADO.Enabled = False
            Me.chkART_ESTADO.Location = New System.Drawing.Point(543, 23)
            Me.chkART_ESTADO.Name = "chkART_ESTADO"
            Me.chkART_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkART_ESTADO.TabIndex = 3
            Me.chkART_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTIP_DESCRIPCION
            '
            Me.txtTIP_DESCRIPCION.Enabled = False
            Me.txtTIP_DESCRIPCION.Location = New System.Drawing.Point(165, 47)
            Me.txtTIP_DESCRIPCION.Name = "txtTIP_DESCRIPCION"
            Me.txtTIP_DESCRIPCION.ReadOnly = True
            Me.txtTIP_DESCRIPCION.Size = New System.Drawing.Size(372, 20)
            Me.txtTIP_DESCRIPCION.TabIndex = 5
            '
            'txtART_DESCRIPCION
            '
            Me.txtART_DESCRIPCION.Enabled = False
            Me.txtART_DESCRIPCION.Location = New System.Drawing.Point(165, 23)
            Me.txtART_DESCRIPCION.Name = "txtART_DESCRIPCION"
            Me.txtART_DESCRIPCION.ReadOnly = True
            Me.txtART_DESCRIPCION.Size = New System.Drawing.Size(372, 20)
            Me.txtART_DESCRIPCION.TabIndex = 2
            '
            'txtTIP_ID
            '
            Me.txtTIP_ID.Location = New System.Drawing.Point(92, 47)
            Me.txtTIP_ID.Name = "txtTIP_ID"
            Me.txtTIP_ID.Size = New System.Drawing.Size(67, 20)
            Me.txtTIP_ID.TabIndex = 4
            '
            'txtART_ID
            '
            Me.txtART_ID.Location = New System.Drawing.Point(92, 23)
            Me.txtART_ID.Name = "txtART_ID"
            Me.txtART_ID.Size = New System.Drawing.Size(67, 20)
            Me.txtART_ID.TabIndex = 1
            '
            'frmRolArticulosTipoArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(696, 176)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmRolArticulosTipoArticulos"
            Me.Text = "Rol artículos - Tipo artículos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblTIP_ID As System.Windows.Forms.Label
        Friend WithEvents lblART_ID As System.Windows.Forms.Label
        Public WithEvents chkRAR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkTIP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkART_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTIP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtART_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTIP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtART_ID As System.Windows.Forms.TextBox
    End Class
End Namespace