Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDireccionesPersonas
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
            Me.txtDIR_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtDIR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.cboDIR_TIPO = New System.Windows.Forms.ComboBox()
            Me.txtDIS_ID = New System.Windows.Forms.TextBox()
            Me.txtDIR_REFERENCIA = New System.Windows.Forms.TextBox()
            Me.chkDIR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDIR_ID = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblDIR_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblDIR_TIPO = New System.Windows.Forms.Label()
            Me.lblDIS_ID = New System.Windows.Forms.Label()
            Me.lblDIR_REFERENCIA = New System.Windows.Forms.Label()
            Me.lblDIR_ESTADO = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPER_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblPER_ESTADO = New System.Windows.Forms.Label()
            Me.lblDIS_ESTADO = New System.Windows.Forms.Label()
            Me.lblDIS_DESCRIPCION = New System.Windows.Forms.Label()
            Me.chkDIS_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtDIS_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(867, 28)
            Me.lblTitle.Text = "Dirección personas"
            '
            'txtDIR_ID
            '
            Me.txtDIR_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIR_ID.Location = New System.Drawing.Point(77, 11)
            Me.txtDIR_ID.Name = "txtDIR_ID"
            Me.txtDIR_ID.Size = New System.Drawing.Size(121, 20)
            Me.txtDIR_ID.TabIndex = 0
            '
            'txtPER_ID
            '
            Me.txtPER_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID.Location = New System.Drawing.Point(77, 38)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(121, 20)
            Me.txtPER_ID.TabIndex = 1
            '
            'txtDIR_DESCRIPCION
            '
            Me.txtDIR_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIR_DESCRIPCION.Location = New System.Drawing.Point(77, 110)
            Me.txtDIR_DESCRIPCION.Name = "txtDIR_DESCRIPCION"
            Me.txtDIR_DESCRIPCION.Size = New System.Drawing.Size(698, 20)
            Me.txtDIR_DESCRIPCION.TabIndex = 4
            '
            'cboDIR_TIPO
            '
            Me.cboDIR_TIPO.FormattingEnabled = True
            Me.cboDIR_TIPO.Location = New System.Drawing.Point(77, 135)
            Me.cboDIR_TIPO.Name = "cboDIR_TIPO"
            Me.cboDIR_TIPO.Size = New System.Drawing.Size(121, 21)
            Me.cboDIR_TIPO.TabIndex = 5
            '
            'txtDIS_ID
            '
            Me.txtDIS_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIS_ID.Location = New System.Drawing.Point(77, 188)
            Me.txtDIS_ID.Name = "txtDIS_ID"
            Me.txtDIS_ID.Size = New System.Drawing.Size(53, 20)
            Me.txtDIS_ID.TabIndex = 7
            '
            'txtDIR_REFERENCIA
            '
            Me.txtDIR_REFERENCIA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIR_REFERENCIA.Location = New System.Drawing.Point(77, 160)
            Me.txtDIR_REFERENCIA.Name = "txtDIR_REFERENCIA"
            Me.txtDIR_REFERENCIA.Size = New System.Drawing.Size(698, 20)
            Me.txtDIR_REFERENCIA.TabIndex = 6
            '
            'chkDIR_ESTADO
            '
            Me.chkDIR_ESTADO.AutoSize = True
            Me.chkDIR_ESTADO.Location = New System.Drawing.Point(77, 261)
            Me.chkDIR_ESTADO.Name = "chkDIR_ESTADO"
            Me.chkDIR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDIR_ESTADO.TabIndex = 10
            Me.chkDIR_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDIR_ID
            '
            Me.lblDIR_ID.AutoSize = True
            Me.lblDIR_ID.Location = New System.Drawing.Point(8, 11)
            Me.lblDIR_ID.Name = "lblDIR_ID"
            Me.lblDIR_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblDIR_ID.TabIndex = 8
            Me.lblDIR_ID.Text = "Código"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(8, 38)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(51, 13)
            Me.lblPER_ID.TabIndex = 9
            Me.lblPER_ID.Text = "Cód. Per."
            '
            'lblDIR_DESCRIPCION
            '
            Me.lblDIR_DESCRIPCION.AutoSize = True
            Me.lblDIR_DESCRIPCION.Location = New System.Drawing.Point(8, 110)
            Me.lblDIR_DESCRIPCION.Name = "lblDIR_DESCRIPCION"
            Me.lblDIR_DESCRIPCION.Size = New System.Drawing.Size(52, 13)
            Me.lblDIR_DESCRIPCION.TabIndex = 10
            Me.lblDIR_DESCRIPCION.Text = "Dirección"
            '
            'lblDIR_TIPO
            '
            Me.lblDIR_TIPO.AutoSize = True
            Me.lblDIR_TIPO.Location = New System.Drawing.Point(8, 135)
            Me.lblDIR_TIPO.Name = "lblDIR_TIPO"
            Me.lblDIR_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblDIR_TIPO.TabIndex = 11
            Me.lblDIR_TIPO.Text = "Tipo"
            '
            'lblDIS_ID
            '
            Me.lblDIS_ID.AutoSize = True
            Me.lblDIS_ID.Location = New System.Drawing.Point(8, 188)
            Me.lblDIS_ID.Name = "lblDIS_ID"
            Me.lblDIS_ID.Size = New System.Drawing.Size(50, 13)
            Me.lblDIS_ID.TabIndex = 12
            Me.lblDIS_ID.Text = "Cód. Dis."
            '
            'lblDIR_REFERENCIA
            '
            Me.lblDIR_REFERENCIA.AutoSize = True
            Me.lblDIR_REFERENCIA.Location = New System.Drawing.Point(8, 160)
            Me.lblDIR_REFERENCIA.Name = "lblDIR_REFERENCIA"
            Me.lblDIR_REFERENCIA.Size = New System.Drawing.Size(59, 13)
            Me.lblDIR_REFERENCIA.TabIndex = 13
            Me.lblDIR_REFERENCIA.Text = "Referencia"
            '
            'lblDIR_ESTADO
            '
            Me.lblDIR_ESTADO.AutoSize = True
            Me.lblDIR_ESTADO.Location = New System.Drawing.Point(8, 261)
            Me.lblDIR_ESTADO.Name = "lblDIR_ESTADO"
            Me.lblDIR_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDIR_ESTADO.TabIndex = 15
            Me.lblDIR_ESTADO.Text = "Estado"
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(77, 62)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(698, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 2
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(77, 87)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 3
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(8, 62)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(65, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 18
            Me.lblPER_DESCRIPCION.Text = "Ape. y Nom."
            '
            'lblPER_ESTADO
            '
            Me.lblPER_ESTADO.AutoSize = True
            Me.lblPER_ESTADO.Location = New System.Drawing.Point(8, 87)
            Me.lblPER_ESTADO.Name = "lblPER_ESTADO"
            Me.lblPER_ESTADO.Size = New System.Drawing.Size(47, 13)
            Me.lblPER_ESTADO.TabIndex = 19
            Me.lblPER_ESTADO.Text = "Est. Per."
            '
            'lblDIS_ESTADO
            '
            Me.lblDIS_ESTADO.AutoSize = True
            Me.lblDIS_ESTADO.Location = New System.Drawing.Point(8, 237)
            Me.lblDIS_ESTADO.Name = "lblDIS_ESTADO"
            Me.lblDIS_ESTADO.Size = New System.Drawing.Size(46, 13)
            Me.lblDIS_ESTADO.TabIndex = 23
            Me.lblDIS_ESTADO.Text = "Est. Dis."
            '
            'lblDIS_DESCRIPCION
            '
            Me.lblDIS_DESCRIPCION.AutoSize = True
            Me.lblDIS_DESCRIPCION.Location = New System.Drawing.Point(8, 212)
            Me.lblDIS_DESCRIPCION.Name = "lblDIS_DESCRIPCION"
            Me.lblDIS_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblDIS_DESCRIPCION.TabIndex = 22
            Me.lblDIS_DESCRIPCION.Text = "Descripción"
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
            'txtDIS_DESCRIPCION
            '
            Me.txtDIS_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDIS_DESCRIPCION.Enabled = False
            Me.txtDIS_DESCRIPCION.Location = New System.Drawing.Point(77, 212)
            Me.txtDIS_DESCRIPCION.Name = "txtDIS_DESCRIPCION"
            Me.txtDIS_DESCRIPCION.ReadOnly = True
            Me.txtDIS_DESCRIPCION.Size = New System.Drawing.Size(698, 20)
            Me.txtDIS_DESCRIPCION.TabIndex = 8
            '
            'pnCuerpo
            '
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblDIS_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDIS_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkDIS_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_REFERENCIA)
            Me.pnCuerpo.Controls.Add(Me.lblDIS_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDIR_ID)
            Me.pnCuerpo.Controls.Add(Me.chkDIR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_REFERENCIA)
            Me.pnCuerpo.Controls.Add(Me.txtDIS_ID)
            Me.pnCuerpo.Controls.Add(Me.cboDIR_TIPO)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDIR_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(37, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(793, 292)
            Me.pnCuerpo.TabIndex = 35
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
            'frmDireccionesPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(867, 351)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmDireccionesPersonas"
            Me.Text = "Dirección personas"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblDIS_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblDIS_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblPER_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblDIR_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblDIR_REFERENCIA As System.Windows.Forms.Label
        Friend WithEvents lblDIS_ID As System.Windows.Forms.Label
        Friend WithEvents lblDIR_TIPO As System.Windows.Forms.Label
        Friend WithEvents lblDIR_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblDIR_ID As System.Windows.Forms.Label
        Public WithEvents chkDIS_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtDIS_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkDIR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtDIR_REFERENCIA As System.Windows.Forms.TextBox
        Public WithEvents txtDIS_ID As System.Windows.Forms.TextBox
        Public WithEvents cboDIR_TIPO As System.Windows.Forms.ComboBox
        Public WithEvents txtDIR_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDIR_ID As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
    End Class
End Namespace