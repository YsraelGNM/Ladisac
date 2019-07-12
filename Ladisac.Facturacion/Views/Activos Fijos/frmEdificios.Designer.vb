Namespace Ladisac.ActivosFijos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEdificios
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
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblEDI_ID = New System.Windows.Forms.Label()
            Me.chkEDI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtEDI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtEDI_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(764, 28)
            Me.lblTitle.Text = "Edificios"
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
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblEDI_ID)
            Me.pnCuerpo.Controls.Add(Me.chkEDI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtEDI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtEDI_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(697, 95)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(9, 39)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ID.TabIndex = 40
            Me.lblPVE_ID.Text = "Punto venta"
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(607, 38)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 4
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(117, 39)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(479, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 3
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(77, 39)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 2
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(9, 69)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblEDI_ID
            '
            Me.lblEDI_ID.AutoSize = True
            Me.lblEDI_ID.Location = New System.Drawing.Point(9, 12)
            Me.lblEDI_ID.Name = "lblEDI_ID"
            Me.lblEDI_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblEDI_ID.TabIndex = 25
            Me.lblEDI_ID.Text = "Código"
            '
            'chkEDI_ESTADO
            '
            Me.chkEDI_ESTADO.AutoSize = True
            Me.chkEDI_ESTADO.Location = New System.Drawing.Point(77, 69)
            Me.chkEDI_ESTADO.Name = "chkEDI_ESTADO"
            Me.chkEDI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkEDI_ESTADO.TabIndex = 5
            Me.chkEDI_ESTADO.UseVisualStyleBackColor = True
            '
            'txtEDI_DESCRIPCION
            '
            Me.txtEDI_DESCRIPCION.Location = New System.Drawing.Point(117, 12)
            Me.txtEDI_DESCRIPCION.Name = "txtEDI_DESCRIPCION"
            Me.txtEDI_DESCRIPCION.Size = New System.Drawing.Size(479, 20)
            Me.txtEDI_DESCRIPCION.TabIndex = 1
            '
            'txtEDI_ID
            '
            Me.txtEDI_ID.Location = New System.Drawing.Point(77, 12)
            Me.txtEDI_ID.Name = "txtEDI_ID"
            Me.txtEDI_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtEDI_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(686, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmEdificios
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(764, 154)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmEdificios"
            Me.Text = "Edificios"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblEDI_ID As System.Windows.Forms.Label
        Public WithEvents chkEDI_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtEDI_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtEDI_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
    End Class
End Namespace