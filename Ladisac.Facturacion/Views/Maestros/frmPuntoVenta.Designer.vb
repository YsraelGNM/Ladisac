Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPuntoVenta
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
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_TELEFONOS = New System.Windows.Forms.TextBox()
            Me.txtPVE_DIRECCION = New System.Windows.Forms.TextBox()
            Me.lblPVE_ESTADO = New System.Windows.Forms.Label()
            Me.lblPVE_TELEFONOS = New System.Windows.Forms.Label()
            Me.lblPVE_DIRECCION = New System.Windows.Forms.Label()
            Me.txtLPR_ID = New System.Windows.Forms.TextBox()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.txtLPR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblLPR_DESCRIPCION = New System.Windows.Forms.Label()
            Me.chkLPR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblLPR_ESTADO = New System.Windows.Forms.Label()
            Me.txtDIS_ID = New System.Windows.Forms.TextBox()
            Me.lblDIS_ID = New System.Windows.Forms.Label()
            Me.txtDIS_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDIS_DESCRIPCION = New System.Windows.Forms.Label()
            Me.chkDIS_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDIS_ESTADO = New System.Windows.Forms.Label()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.lblPVE_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblPVE_TIPO = New System.Windows.Forms.Label()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.cboPVE_TIPO = New System.Windows.Forms.ComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(902, 28)
            Me.lblTitle.Text = "Punto de venta"
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(105, 277)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 11
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_TELEFONOS
            '
            Me.txtPVE_TELEFONOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_TELEFONOS.Location = New System.Drawing.Point(105, 77)
            Me.txtPVE_TELEFONOS.Name = "txtPVE_TELEFONOS"
            Me.txtPVE_TELEFONOS.Size = New System.Drawing.Size(708, 20)
            Me.txtPVE_TELEFONOS.TabIndex = 3
            '
            'txtPVE_DIRECCION
            '
            Me.txtPVE_DIRECCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_DIRECCION.Location = New System.Drawing.Point(105, 55)
            Me.txtPVE_DIRECCION.Name = "txtPVE_DIRECCION"
            Me.txtPVE_DIRECCION.Size = New System.Drawing.Size(708, 20)
            Me.txtPVE_DIRECCION.TabIndex = 2
            '
            'lblPVE_ESTADO
            '
            Me.lblPVE_ESTADO.AutoSize = True
            Me.lblPVE_ESTADO.Location = New System.Drawing.Point(9, 276)
            Me.lblPVE_ESTADO.Name = "lblPVE_ESTADO"
            Me.lblPVE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblPVE_ESTADO.TabIndex = 4
            Me.lblPVE_ESTADO.Text = "Estado"
            '
            'lblPVE_TELEFONOS
            '
            Me.lblPVE_TELEFONOS.AutoSize = True
            Me.lblPVE_TELEFONOS.Location = New System.Drawing.Point(9, 77)
            Me.lblPVE_TELEFONOS.Name = "lblPVE_TELEFONOS"
            Me.lblPVE_TELEFONOS.Size = New System.Drawing.Size(54, 13)
            Me.lblPVE_TELEFONOS.TabIndex = 1
            Me.lblPVE_TELEFONOS.Text = "Teléfonos"
            '
            'lblPVE_DIRECCION
            '
            Me.lblPVE_DIRECCION.AutoSize = True
            Me.lblPVE_DIRECCION.Location = New System.Drawing.Point(9, 55)
            Me.lblPVE_DIRECCION.Name = "lblPVE_DIRECCION"
            Me.lblPVE_DIRECCION.Size = New System.Drawing.Size(52, 13)
            Me.lblPVE_DIRECCION.TabIndex = 0
            Me.lblPVE_DIRECCION.Text = "Dirección"
            '
            'txtLPR_ID
            '
            Me.txtLPR_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_ID.Location = New System.Drawing.Point(105, 182)
            Me.txtLPR_ID.Name = "txtLPR_ID"
            Me.txtLPR_ID.Size = New System.Drawing.Size(708, 20)
            Me.txtLPR_ID.TabIndex = 7
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(9, 182)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(86, 13)
            Me.lblLPR_ID.TabIndex = 10
            Me.lblLPR_ID.Text = "Cód. Lista precio"
            '
            'txtLPR_DESCRIPCION
            '
            Me.txtLPR_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtLPR_DESCRIPCION.Enabled = False
            Me.txtLPR_DESCRIPCION.Location = New System.Drawing.Point(105, 206)
            Me.txtLPR_DESCRIPCION.Name = "txtLPR_DESCRIPCION"
            Me.txtLPR_DESCRIPCION.ReadOnly = True
            Me.txtLPR_DESCRIPCION.Size = New System.Drawing.Size(708, 20)
            Me.txtLPR_DESCRIPCION.TabIndex = 8
            '
            'lblLPR_DESCRIPCION
            '
            Me.lblLPR_DESCRIPCION.AutoSize = True
            Me.lblLPR_DESCRIPCION.Location = New System.Drawing.Point(9, 206)
            Me.lblLPR_DESCRIPCION.Name = "lblLPR_DESCRIPCION"
            Me.lblLPR_DESCRIPCION.Size = New System.Drawing.Size(92, 13)
            Me.lblLPR_DESCRIPCION.TabIndex = 12
            Me.lblLPR_DESCRIPCION.Text = "Desc. Lista precio"
            '
            'chkLPR_ESTADO
            '
            Me.chkLPR_ESTADO.AutoSize = True
            Me.chkLPR_ESTADO.Enabled = False
            Me.chkLPR_ESTADO.Location = New System.Drawing.Point(105, 230)
            Me.chkLPR_ESTADO.Name = "chkLPR_ESTADO"
            Me.chkLPR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkLPR_ESTADO.TabIndex = 9
            Me.chkLPR_ESTADO.UseVisualStyleBackColor = True
            '
            'lblLPR_ESTADO
            '
            Me.lblLPR_ESTADO.AutoSize = True
            Me.lblLPR_ESTADO.Location = New System.Drawing.Point(9, 230)
            Me.lblLPR_ESTADO.Name = "lblLPR_ESTADO"
            Me.lblLPR_ESTADO.Size = New System.Drawing.Size(82, 13)
            Me.lblLPR_ESTADO.TabIndex = 14
            Me.lblLPR_ESTADO.Text = "Est. Lista precio"
            '
            'txtDIS_ID
            '
            Me.txtDIS_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIS_ID.Location = New System.Drawing.Point(105, 109)
            Me.txtDIS_ID.Name = "txtDIS_ID"
            Me.txtDIS_ID.Size = New System.Drawing.Size(708, 20)
            Me.txtDIS_ID.TabIndex = 4
            '
            'lblDIS_ID
            '
            Me.lblDIS_ID.AutoSize = True
            Me.lblDIS_ID.Location = New System.Drawing.Point(9, 109)
            Me.lblDIS_ID.Name = "lblDIS_ID"
            Me.lblDIS_ID.Size = New System.Drawing.Size(64, 13)
            Me.lblDIS_ID.TabIndex = 20
            Me.lblDIS_ID.Text = "Cód. Distrito"
            '
            'txtDIS_DESCRIPCION
            '
            Me.txtDIS_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIS_DESCRIPCION.Enabled = False
            Me.txtDIS_DESCRIPCION.Location = New System.Drawing.Point(105, 133)
            Me.txtDIS_DESCRIPCION.Name = "txtDIS_DESCRIPCION"
            Me.txtDIS_DESCRIPCION.ReadOnly = True
            Me.txtDIS_DESCRIPCION.Size = New System.Drawing.Size(708, 20)
            Me.txtDIS_DESCRIPCION.TabIndex = 5
            '
            'lblDIS_DESCRIPCION
            '
            Me.lblDIS_DESCRIPCION.AutoSize = True
            Me.lblDIS_DESCRIPCION.Location = New System.Drawing.Point(9, 133)
            Me.lblDIS_DESCRIPCION.Name = "lblDIS_DESCRIPCION"
            Me.lblDIS_DESCRIPCION.Size = New System.Drawing.Size(70, 13)
            Me.lblDIS_DESCRIPCION.TabIndex = 21
            Me.lblDIS_DESCRIPCION.Text = "Desc. Distrito"
            '
            'chkDIS_ESTADO
            '
            Me.chkDIS_ESTADO.AutoSize = True
            Me.chkDIS_ESTADO.Enabled = False
            Me.chkDIS_ESTADO.Location = New System.Drawing.Point(105, 156)
            Me.chkDIS_ESTADO.Name = "chkDIS_ESTADO"
            Me.chkDIS_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDIS_ESTADO.TabIndex = 6
            Me.chkDIS_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDIS_ESTADO
            '
            Me.lblDIS_ESTADO.AutoSize = True
            Me.lblDIS_ESTADO.Location = New System.Drawing.Point(9, 156)
            Me.lblDIS_ESTADO.Name = "lblDIS_ESTADO"
            Me.lblDIS_ESTADO.Size = New System.Drawing.Size(60, 13)
            Me.lblDIS_ESTADO.TabIndex = 22
            Me.lblDIS_ESTADO.Text = "Est. Distrito"
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(105, 32)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(708, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 1
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_ID.Location = New System.Drawing.Point(105, 9)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(708, 20)
            Me.txtPVE_ID.TabIndex = 0
            '
            'lblPVE_DESCRIPCION
            '
            Me.lblPVE_DESCRIPCION.AutoSize = True
            Me.lblPVE_DESCRIPCION.Location = New System.Drawing.Point(9, 32)
            Me.lblPVE_DESCRIPCION.Name = "lblPVE_DESCRIPCION"
            Me.lblPVE_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblPVE_DESCRIPCION.TabIndex = 30
            Me.lblPVE_DESCRIPCION.Text = "Descripcion"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(9, 9)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblPVE_ID.TabIndex = 28
            Me.lblPVE_ID.Text = "Código"
            '
            'lblPVE_TIPO
            '
            Me.lblPVE_TIPO.AutoSize = True
            Me.lblPVE_TIPO.Location = New System.Drawing.Point(9, 253)
            Me.lblPVE_TIPO.Name = "lblPVE_TIPO"
            Me.lblPVE_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblPVE_TIPO.TabIndex = 32
            Me.lblPVE_TIPO.Text = "Tipo"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.cboPVE_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDIS_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkDIS_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDIS_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDIS_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkLPR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_TELEFONOS)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_TELEFONOS)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(36, 56)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(824, 295)
            Me.pnCuerpo.TabIndex = 0
            '
            'cboPVE_TIPO
            '
            Me.cboPVE_TIPO.FormattingEnabled = True
            Me.cboPVE_TIPO.Location = New System.Drawing.Point(105, 253)
            Me.cboPVE_TIPO.Name = "cboPVE_TIPO"
            Me.cboPVE_TIPO.Size = New System.Drawing.Size(121, 21)
            Me.cboPVE_TIPO.TabIndex = 10
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(785, 8)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(75, 45)
            Me.btnImagen.TabIndex = 34
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmPuntoVenta
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(902, 377)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPuntoVenta"
            Me.Text = "Punto de venta"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_TELEFONOS As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_DIRECCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPVE_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPVE_TELEFONOS As System.Windows.Forms.Label
        Friend WithEvents lblPVE_DIRECCION As System.Windows.Forms.Label
        Public WithEvents txtLPR_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblLPR_ID As System.Windows.Forms.Label
        Public WithEvents txtLPR_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblLPR_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents chkLPR_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblLPR_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtDIS_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblDIS_ID As System.Windows.Forms.Label
        Public WithEvents txtDIS_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDIS_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents chkDIS_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblDIS_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPVE_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblPVE_TIPO As System.Windows.Forms.Label
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents cboPVE_TIPO As System.Windows.Forms.ComboBox
    End Class
End Namespace