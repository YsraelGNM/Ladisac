Namespace Ladisac.ActivosFijos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDepartamentosAdministrativos
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
            Me.lblDEA_ESTADO = New System.Windows.Forms.Label()
            Me.lblOFI_ID = New System.Windows.Forms.Label()
            Me.lblDEA_ID = New System.Windows.Forms.Label()
            Me.chkOFI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkDEA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtOFI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDEA_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtOFI_ID = New System.Windows.Forms.TextBox()
            Me.txtDEA_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(781, 28)
            Me.lblTitle.Text = "Departamentos administrativos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDEA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblOFI_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDEA_ID)
            Me.pnCuerpo.Controls.Add(Me.chkOFI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkDEA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtOFI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDEA_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtOFI_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDEA_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(35, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(713, 121)
            Me.pnCuerpo.TabIndex = 119
            '
            'lblDEA_ESTADO
            '
            Me.lblDEA_ESTADO.AutoSize = True
            Me.lblDEA_ESTADO.Location = New System.Drawing.Point(21, 92)
            Me.lblDEA_ESTADO.Name = "lblDEA_ESTADO"
            Me.lblDEA_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDEA_ESTADO.TabIndex = 36
            Me.lblDEA_ESTADO.Text = "Estado"
            '
            'lblOFI_ID
            '
            Me.lblOFI_ID.AutoSize = True
            Me.lblOFI_ID.Location = New System.Drawing.Point(20, 54)
            Me.lblOFI_ID.Name = "lblOFI_ID"
            Me.lblOFI_ID.Size = New System.Drawing.Size(45, 13)
            Me.lblOFI_ID.TabIndex = 26
            Me.lblOFI_ID.Text = "Oficinas"
            '
            'lblDEA_ID
            '
            Me.lblDEA_ID.AutoSize = True
            Me.lblDEA_ID.Location = New System.Drawing.Point(20, 17)
            Me.lblDEA_ID.Name = "lblDEA_ID"
            Me.lblDEA_ID.Size = New System.Drawing.Size(57, 13)
            Me.lblDEA_ID.TabIndex = 25
            Me.lblDEA_ID.Text = "Dep. Adm."
            '
            'chkOFI_ESTADO
            '
            Me.chkOFI_ESTADO.AutoSize = True
            Me.chkOFI_ESTADO.Enabled = False
            Me.chkOFI_ESTADO.Location = New System.Drawing.Point(610, 53)
            Me.chkOFI_ESTADO.Name = "chkOFI_ESTADO"
            Me.chkOFI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkOFI_ESTADO.TabIndex = 8
            Me.chkOFI_ESTADO.UseVisualStyleBackColor = True
            '
            'chkDEA_ESTADO
            '
            Me.chkDEA_ESTADO.AutoSize = True
            Me.chkDEA_ESTADO.Location = New System.Drawing.Point(79, 92)
            Me.chkDEA_ESTADO.Name = "chkDEA_ESTADO"
            Me.chkDEA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDEA_ESTADO.TabIndex = 7
            Me.chkDEA_ESTADO.UseVisualStyleBackColor = True
            '
            'txtOFI_DESCRIPCION
            '
            Me.txtOFI_DESCRIPCION.Enabled = False
            Me.txtOFI_DESCRIPCION.Location = New System.Drawing.Point(119, 54)
            Me.txtOFI_DESCRIPCION.Name = "txtOFI_DESCRIPCION"
            Me.txtOFI_DESCRIPCION.ReadOnly = True
            Me.txtOFI_DESCRIPCION.Size = New System.Drawing.Size(485, 20)
            Me.txtOFI_DESCRIPCION.TabIndex = 6
            '
            'txtDEA_DESCRIPCION
            '
            Me.txtDEA_DESCRIPCION.Location = New System.Drawing.Point(119, 17)
            Me.txtDEA_DESCRIPCION.Name = "txtDEA_DESCRIPCION"
            Me.txtDEA_DESCRIPCION.Size = New System.Drawing.Size(485, 20)
            Me.txtDEA_DESCRIPCION.TabIndex = 5
            '
            'txtOFI_ID
            '
            Me.txtOFI_ID.Location = New System.Drawing.Point(79, 54)
            Me.txtOFI_ID.Name = "txtOFI_ID"
            Me.txtOFI_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtOFI_ID.TabIndex = 4
            '
            'txtDEA_ID
            '
            Me.txtDEA_ID.Location = New System.Drawing.Point(79, 17)
            Me.txtDEA_ID.Name = "txtDEA_ID"
            Me.txtDEA_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtDEA_ID.TabIndex = 3
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(703, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 120
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDepartamentosAdministrativos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(781, 186)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDepartamentosAdministrativos"
            Me.Text = "Departamentos administrativos"
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
        Friend WithEvents lblDEA_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblOFI_ID As System.Windows.Forms.Label
        Friend WithEvents lblDEA_ID As System.Windows.Forms.Label
        Public WithEvents chkOFI_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkDEA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtOFI_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDEA_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtOFI_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDEA_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace