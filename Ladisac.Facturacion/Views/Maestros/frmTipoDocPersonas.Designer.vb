Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoDocPersonas
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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblTDP_COD_SUNAT = New System.Windows.Forms.Label()
            Me.txtTDP_COD_SUNAT = New System.Windows.Forms.TextBox()
            Me.lblTDP_LONGITUD = New System.Windows.Forms.Label()
            Me.txtTDP_LONGITUD = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID = New System.Windows.Forms.Label()
            Me.lblTDP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblTDP_ESTADO = New System.Windows.Forms.Label()
            Me.txtTDP_ID = New System.Windows.Forms.TextBox()
            Me.txtTDP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkTDP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(638, 28)
            Me.lblTitle.Text = "Tipo documentos de personas"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(557, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(48, 28)
            Me.btnImagen.TabIndex = 11
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTDP_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_LONGITUD)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_LONGITUD)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkTDP_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 29)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(572, 169)
            Me.pnCuerpo.TabIndex = 12
            '
            'lblTDP_COD_SUNAT
            '
            Me.lblTDP_COD_SUNAT.AutoSize = True
            Me.lblTDP_COD_SUNAT.Location = New System.Drawing.Point(11, 105)
            Me.lblTDP_COD_SUNAT.Name = "lblTDP_COD_SUNAT"
            Me.lblTDP_COD_SUNAT.Size = New System.Drawing.Size(60, 13)
            Me.lblTDP_COD_SUNAT.TabIndex = 12
            Me.lblTDP_COD_SUNAT.Text = "Cód. Sunat"
            '
            'txtTDP_COD_SUNAT
            '
            Me.txtTDP_COD_SUNAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_COD_SUNAT.Location = New System.Drawing.Point(79, 105)
            Me.txtTDP_COD_SUNAT.Name = "txtTDP_COD_SUNAT"
            Me.txtTDP_COD_SUNAT.Size = New System.Drawing.Size(61, 20)
            Me.txtTDP_COD_SUNAT.TabIndex = 3
            '
            'lblTDP_LONGITUD
            '
            Me.lblTDP_LONGITUD.AutoSize = True
            Me.lblTDP_LONGITUD.Location = New System.Drawing.Point(11, 75)
            Me.lblTDP_LONGITUD.Name = "lblTDP_LONGITUD"
            Me.lblTDP_LONGITUD.Size = New System.Drawing.Size(48, 13)
            Me.lblTDP_LONGITUD.TabIndex = 10
            Me.lblTDP_LONGITUD.Text = "Longitud"
            '
            'txtTDP_LONGITUD
            '
            Me.txtTDP_LONGITUD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_LONGITUD.Location = New System.Drawing.Point(79, 75)
            Me.txtTDP_LONGITUD.Name = "txtTDP_LONGITUD"
            Me.txtTDP_LONGITUD.Size = New System.Drawing.Size(61, 20)
            Me.txtTDP_LONGITUD.TabIndex = 2
            '
            'lblTDP_ID
            '
            Me.lblTDP_ID.AutoSize = True
            Me.lblTDP_ID.Location = New System.Drawing.Point(11, 17)
            Me.lblTDP_ID.Name = "lblTDP_ID"
            Me.lblTDP_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblTDP_ID.TabIndex = 0
            Me.lblTDP_ID.Text = "Código"
            '
            'lblTDP_DESCRIPCION
            '
            Me.lblTDP_DESCRIPCION.AutoSize = True
            Me.lblTDP_DESCRIPCION.Location = New System.Drawing.Point(11, 45)
            Me.lblTDP_DESCRIPCION.Name = "lblTDP_DESCRIPCION"
            Me.lblTDP_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblTDP_DESCRIPCION.TabIndex = 1
            Me.lblTDP_DESCRIPCION.Text = "Descripción"
            '
            'lblTDP_ESTADO
            '
            Me.lblTDP_ESTADO.AutoSize = True
            Me.lblTDP_ESTADO.Location = New System.Drawing.Point(11, 139)
            Me.lblTDP_ESTADO.Name = "lblTDP_ESTADO"
            Me.lblTDP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTDP_ESTADO.TabIndex = 4
            Me.lblTDP_ESTADO.Text = "Estado"
            '
            'txtTDP_ID
            '
            Me.txtTDP_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_ID.Location = New System.Drawing.Point(79, 17)
            Me.txtTDP_ID.Name = "txtTDP_ID"
            Me.txtTDP_ID.Size = New System.Drawing.Size(61, 20)
            Me.txtTDP_ID.TabIndex = 0
            '
            'txtTDP_DESCRIPCION
            '
            Me.txtTDP_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTDP_DESCRIPCION.Location = New System.Drawing.Point(79, 45)
            Me.txtTDP_DESCRIPCION.Name = "txtTDP_DESCRIPCION"
            Me.txtTDP_DESCRIPCION.Size = New System.Drawing.Size(476, 20)
            Me.txtTDP_DESCRIPCION.TabIndex = 1
            '
            'chkTDP_ESTADO
            '
            Me.chkTDP_ESTADO.AutoSize = True
            Me.chkTDP_ESTADO.Location = New System.Drawing.Point(79, 139)
            Me.chkTDP_ESTADO.Name = "chkTDP_ESTADO"
            Me.chkTDP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTDP_ESTADO.TabIndex = 4
            Me.chkTDP_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmTipoDocPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(638, 225)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmTipoDocPersonas"
            Me.Text = "Tipo documentos de personas"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblTDP_ID As System.Windows.Forms.Label
        Friend WithEvents lblTDP_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblTDP_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtTDP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTDP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkTDP_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTDP_COD_SUNAT As System.Windows.Forms.Label
        Public WithEvents txtTDP_COD_SUNAT As System.Windows.Forms.TextBox
        Friend WithEvents lblTDP_LONGITUD As System.Windows.Forms.Label
        Public WithEvents txtTDP_LONGITUD As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace