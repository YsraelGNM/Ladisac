Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBloqueosCodigoPersona
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
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.chkBCP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblDIR_ESTADO = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDOC_CONTRAENTREGA = New System.Windows.Forms.Label()
            Me.chkDOC_CONTRAENTREGA = New System.Windows.Forms.CheckBox()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblDOC_SOLO_CONTADO = New System.Windows.Forms.Label()
            Me.chkDOC_SOLO_CONTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.chkDIS_ESTADO = New System.Windows.Forms.CheckBox()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(867, 28)
            Me.lblTitle.Text = "Bloqueo de persona"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(120, 22)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(76, 20)
            Me.txtPER_ID.TabIndex = 1
            '
            'chkBCP_ESTADO
            '
            Me.chkBCP_ESTADO.AutoSize = True
            Me.chkBCP_ESTADO.Location = New System.Drawing.Point(121, 132)
            Me.chkBCP_ESTADO.Name = "chkBCP_ESTADO"
            Me.chkBCP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkBCP_ESTADO.TabIndex = 10
            Me.chkBCP_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(17, 22)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(84, 13)
            Me.lblPER_ID.TabIndex = 9
            Me.lblPER_ID.Text = "Código persona:"
            '
            'lblDIR_ESTADO
            '
            Me.lblDIR_ESTADO.AutoSize = True
            Me.lblDIR_ESTADO.Location = New System.Drawing.Point(17, 132)
            Me.lblDIR_ESTADO.Name = "lblDIR_ESTADO"
            Me.lblDIR_ESTADO.Size = New System.Drawing.Size(101, 13)
            Me.lblDIR_ESTADO.TabIndex = 15
            Me.lblDIR_ESTADO.Text = "Estado del bloqueo:"
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(202, 22)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(481, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 2
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(699, 22)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 3
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDOC_CONTRAENTREGA
            '
            Me.lblDOC_CONTRAENTREGA.AutoSize = True
            Me.lblDOC_CONTRAENTREGA.Location = New System.Drawing.Point(17, 63)
            Me.lblDOC_CONTRAENTREGA.Name = "lblDOC_CONTRAENTREGA"
            Me.lblDOC_CONTRAENTREGA.Size = New System.Drawing.Size(249, 13)
            Me.lblDOC_CONTRAENTREGA.TabIndex = 23
            Me.lblDOC_CONTRAENTREGA.Text = "Vendedor puede realizar ventas tipo contraentrega:"
            '
            'chkDOC_CONTRAENTREGA
            '
            Me.chkDOC_CONTRAENTREGA.AutoSize = True
            Me.chkDOC_CONTRAENTREGA.Location = New System.Drawing.Point(283, 63)
            Me.chkDOC_CONTRAENTREGA.Name = "chkDOC_CONTRAENTREGA"
            Me.chkDOC_CONTRAENTREGA.Size = New System.Drawing.Size(15, 14)
            Me.chkDOC_CONTRAENTREGA.TabIndex = 9
            Me.chkDOC_CONTRAENTREGA.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDOC_SOLO_CONTADO)
            Me.pnCuerpo.Controls.Add(Me.chkDOC_SOLO_CONTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDOC_CONTRAENTREGA)
            Me.pnCuerpo.Controls.Add(Me.chkDOC_CONTRAENTREGA)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.chkBCP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(37, 56)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(793, 169)
            Me.pnCuerpo.TabIndex = 35
            '
            'lblDOC_SOLO_CONTADO
            '
            Me.lblDOC_SOLO_CONTADO.AutoSize = True
            Me.lblDOC_SOLO_CONTADO.Location = New System.Drawing.Point(17, 97)
            Me.lblDOC_SOLO_CONTADO.Name = "lblDOC_SOLO_CONTADO"
            Me.lblDOC_SOLO_CONTADO.Size = New System.Drawing.Size(221, 13)
            Me.lblDOC_SOLO_CONTADO.TabIndex = 25
            Me.lblDOC_SOLO_CONTADO.Text = "Cliente solo puede realizar ventas al contado:"
            '
            'chkDOC_SOLO_CONTADO
            '
            Me.chkDOC_SOLO_CONTADO.AutoSize = True
            Me.chkDOC_SOLO_CONTADO.Location = New System.Drawing.Point(283, 97)
            Me.chkDOC_SOLO_CONTADO.Name = "chkDOC_SOLO_CONTADO"
            Me.chkDOC_SOLO_CONTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDOC_SOLO_CONTADO.TabIndex = 24
            Me.chkDOC_SOLO_CONTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(791, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(39, 25)
            Me.btnImagen.TabIndex = 36
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'chkDIS_ESTADO
            '
            Me.chkDIS_ESTADO.AutoSize = True
            Me.chkDIS_ESTADO.Enabled = False
            Me.chkDIS_ESTADO.Location = New System.Drawing.Point(77, 237)
            Me.chkDIS_ESTADO.Name = "chkDIS_ESTADO"
            Me.chkDIS_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDIS_ESTADO.TabIndex = 9
            Me.chkDIS_ESTADO.UseVisualStyleBackColor = True
            '
            'frmBloqueosCodigoPersona
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(867, 250)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmBloqueosCodigoPersona"
            Me.Text = "Bloqueo de persona"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblDOC_CONTRAENTREGA As System.Windows.Forms.Label
        Friend WithEvents lblDIR_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents chkDOC_CONTRAENTREGA As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkBCP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblDOC_SOLO_CONTADO As System.Windows.Forms.Label
        Public WithEvents chkDOC_SOLO_CONTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkDIS_ESTADO As System.Windows.Forms.CheckBox
    End Class
End Namespace