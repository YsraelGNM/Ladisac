Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDepartamento
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
            Me.lblDEP_COD_SUNAT = New System.Windows.Forms.Label()
            Me.txtDEP_COD_SUNAT = New System.Windows.Forms.TextBox()
            Me.lblPAI_ESTADO = New System.Windows.Forms.Label()
            Me.chkPAI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPAI_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtPAI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPAI_ID = New System.Windows.Forms.Label()
            Me.txtPAI_ID = New System.Windows.Forms.TextBox()
            Me.lblDEP_ID = New System.Windows.Forms.Label()
            Me.lblDEP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblDEP_ESTADO = New System.Windows.Forms.Label()
            Me.txtDEP_ID = New System.Windows.Forms.TextBox()
            Me.txtDEP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkDEP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(668, 28)
            Me.lblTitle.Text = "Departamento"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDEP_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPAI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkDEP_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(36, 56)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(594, 227)
            Me.pnCuerpo.TabIndex = 3
            '
            'lblDEP_COD_SUNAT
            '
            Me.lblDEP_COD_SUNAT.AutoSize = True
            Me.lblDEP_COD_SUNAT.Location = New System.Drawing.Point(13, 166)
            Me.lblDEP_COD_SUNAT.Name = "lblDEP_COD_SUNAT"
            Me.lblDEP_COD_SUNAT.Size = New System.Drawing.Size(60, 13)
            Me.lblDEP_COD_SUNAT.TabIndex = 16
            Me.lblDEP_COD_SUNAT.Text = "Cód. Sunat"
            '
            'txtDEP_COD_SUNAT
            '
            Me.txtDEP_COD_SUNAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDEP_COD_SUNAT.Location = New System.Drawing.Point(82, 166)
            Me.txtDEP_COD_SUNAT.Name = "txtDEP_COD_SUNAT"
            Me.txtDEP_COD_SUNAT.Size = New System.Drawing.Size(488, 20)
            Me.txtDEP_COD_SUNAT.TabIndex = 5
            '
            'lblPAI_ESTADO
            '
            Me.lblPAI_ESTADO.AutoSize = True
            Me.lblPAI_ESTADO.Location = New System.Drawing.Point(13, 139)
            Me.lblPAI_ESTADO.Name = "lblPAI_ESTADO"
            Me.lblPAI_ESTADO.Size = New System.Drawing.Size(50, 13)
            Me.lblPAI_ESTADO.TabIndex = 14
            Me.lblPAI_ESTADO.Text = "Est. País"
            '
            'chkPAI_ESTADO
            '
            Me.chkPAI_ESTADO.AutoSize = True
            Me.chkPAI_ESTADO.Enabled = False
            Me.chkPAI_ESTADO.Location = New System.Drawing.Point(82, 139)
            Me.chkPAI_ESTADO.Name = "chkPAI_ESTADO"
            Me.chkPAI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPAI_ESTADO.TabIndex = 4
            Me.chkPAI_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPAI_DESCRIPCION
            '
            Me.lblPAI_DESCRIPCION.AutoSize = True
            Me.lblPAI_DESCRIPCION.Location = New System.Drawing.Point(13, 112)
            Me.lblPAI_DESCRIPCION.Name = "lblPAI_DESCRIPCION"
            Me.lblPAI_DESCRIPCION.Size = New System.Drawing.Size(60, 13)
            Me.lblPAI_DESCRIPCION.TabIndex = 12
            Me.lblPAI_DESCRIPCION.Text = "Desc. País"
            '
            'txtPAI_DESCRIPCION
            '
            Me.txtPAI_DESCRIPCION.Location = New System.Drawing.Point(82, 112)
            Me.txtPAI_DESCRIPCION.Name = "txtPAI_DESCRIPCION"
            Me.txtPAI_DESCRIPCION.ReadOnly = True
            Me.txtPAI_DESCRIPCION.Size = New System.Drawing.Size(488, 20)
            Me.txtPAI_DESCRIPCION.TabIndex = 3
            '
            'lblPAI_ID
            '
            Me.lblPAI_ID.AutoSize = True
            Me.lblPAI_ID.Location = New System.Drawing.Point(13, 86)
            Me.lblPAI_ID.Name = "lblPAI_ID"
            Me.lblPAI_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblPAI_ID.TabIndex = 10
            Me.lblPAI_ID.Text = "Cód. País"
            '
            'txtPAI_ID
            '
            Me.txtPAI_ID.Location = New System.Drawing.Point(82, 86)
            Me.txtPAI_ID.Name = "txtPAI_ID"
            Me.txtPAI_ID.Size = New System.Drawing.Size(488, 20)
            Me.txtPAI_ID.TabIndex = 2
            '
            'lblDEP_ID
            '
            Me.lblDEP_ID.AutoSize = True
            Me.lblDEP_ID.Location = New System.Drawing.Point(13, 22)
            Me.lblDEP_ID.Name = "lblDEP_ID"
            Me.lblDEP_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblDEP_ID.TabIndex = 0
            Me.lblDEP_ID.Text = "Código"
            '
            'lblDEP_DESCRIPCION
            '
            Me.lblDEP_DESCRIPCION.AutoSize = True
            Me.lblDEP_DESCRIPCION.Location = New System.Drawing.Point(13, 54)
            Me.lblDEP_DESCRIPCION.Name = "lblDEP_DESCRIPCION"
            Me.lblDEP_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblDEP_DESCRIPCION.TabIndex = 1
            Me.lblDEP_DESCRIPCION.Text = "Descripción"
            '
            'lblDEP_ESTADO
            '
            Me.lblDEP_ESTADO.AutoSize = True
            Me.lblDEP_ESTADO.Location = New System.Drawing.Point(13, 200)
            Me.lblDEP_ESTADO.Name = "lblDEP_ESTADO"
            Me.lblDEP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDEP_ESTADO.TabIndex = 4
            Me.lblDEP_ESTADO.Text = "Estado"
            '
            'txtDEP_ID
            '
            Me.txtDEP_ID.Location = New System.Drawing.Point(82, 22)
            Me.txtDEP_ID.Name = "txtDEP_ID"
            Me.txtDEP_ID.Size = New System.Drawing.Size(488, 20)
            Me.txtDEP_ID.TabIndex = 0
            '
            'txtDEP_DESCRIPCION
            '
            Me.txtDEP_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDEP_DESCRIPCION.Location = New System.Drawing.Point(82, 54)
            Me.txtDEP_DESCRIPCION.Name = "txtDEP_DESCRIPCION"
            Me.txtDEP_DESCRIPCION.Size = New System.Drawing.Size(488, 20)
            Me.txtDEP_DESCRIPCION.TabIndex = 1
            '
            'chkDEP_ESTADO
            '
            Me.chkDEP_ESTADO.AutoSize = True
            Me.chkDEP_ESTADO.Location = New System.Drawing.Point(82, 200)
            Me.chkDEP_ESTADO.Name = "chkDEP_ESTADO"
            Me.chkDEP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDEP_ESTADO.TabIndex = 6
            Me.chkDEP_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(555, 5)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(75, 45)
            Me.btnImagen.TabIndex = 0
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDepartamento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(668, 314)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDepartamento"
            Me.Text = "Departamento"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblPAI_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPAI_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPAI_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtPAI_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPAI_ID As System.Windows.Forms.Label
        Public WithEvents txtPAI_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblDEP_ID As System.Windows.Forms.Label
        Friend WithEvents lblDEP_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblDEP_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtDEP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDEP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkDEP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblDEP_COD_SUNAT As System.Windows.Forms.Label
        Public WithEvents txtDEP_COD_SUNAT As System.Windows.Forms.TextBox
    End Class
End Namespace