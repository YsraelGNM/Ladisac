Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmProvincia
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
            Me.lblPRO_COD_SUNAT = New System.Windows.Forms.Label()
            Me.txtPRO_COD_SUNAT = New System.Windows.Forms.TextBox()
            Me.lblDEP_ESTADO = New System.Windows.Forms.Label()
            Me.chkDEP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDEP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtDEP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDEP_ID = New System.Windows.Forms.Label()
            Me.txtDEP_ID = New System.Windows.Forms.TextBox()
            Me.lblPAI_ESTADO = New System.Windows.Forms.Label()
            Me.chkPAI_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblPAI_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtPAI_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPAI_ID = New System.Windows.Forms.Label()
            Me.txtPAI_ID = New System.Windows.Forms.TextBox()
            Me.lblPRO_ID = New System.Windows.Forms.Label()
            Me.lblPRO_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblPRO_ESTADO = New System.Windows.Forms.Label()
            Me.txtPRO_ID = New System.Windows.Forms.TextBox()
            Me.txtPRO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkPRO_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(728, 28)
            Me.lblTitle.Text = "Provincia"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(648, 25)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(42, 28)
            Me.btnImagen.TabIndex = 4
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblPRO_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_COD_SUNAT)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkDEP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDEP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDEP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPAI_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPAI_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPRO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPRO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPRO_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPRO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkPRO_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(38, 59)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(652, 274)
            Me.pnCuerpo.TabIndex = 0
            '
            'lblPRO_COD_SUNAT
            '
            Me.lblPRO_COD_SUNAT.AutoSize = True
            Me.lblPRO_COD_SUNAT.Location = New System.Drawing.Point(13, 221)
            Me.lblPRO_COD_SUNAT.Name = "lblPRO_COD_SUNAT"
            Me.lblPRO_COD_SUNAT.Size = New System.Drawing.Size(60, 13)
            Me.lblPRO_COD_SUNAT.TabIndex = 24
            Me.lblPRO_COD_SUNAT.Text = "Cód. Sunat"
            '
            'txtPRO_COD_SUNAT
            '
            Me.txtPRO_COD_SUNAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPRO_COD_SUNAT.Location = New System.Drawing.Point(120, 221)
            Me.txtPRO_COD_SUNAT.Name = "txtPRO_COD_SUNAT"
            Me.txtPRO_COD_SUNAT.Size = New System.Drawing.Size(511, 20)
            Me.txtPRO_COD_SUNAT.TabIndex = 8
            '
            'lblDEP_ESTADO
            '
            Me.lblDEP_ESTADO.AutoSize = True
            Me.lblDEP_ESTADO.Location = New System.Drawing.Point(13, 119)
            Me.lblDEP_ESTADO.Name = "lblDEP_ESTADO"
            Me.lblDEP_ESTADO.Size = New System.Drawing.Size(95, 13)
            Me.lblDEP_ESTADO.TabIndex = 22
            Me.lblDEP_ESTADO.Text = "Est. Departamento"
            '
            'chkDEP_ESTADO
            '
            Me.chkDEP_ESTADO.AutoSize = True
            Me.chkDEP_ESTADO.Enabled = False
            Me.chkDEP_ESTADO.Location = New System.Drawing.Point(120, 119)
            Me.chkDEP_ESTADO.Name = "chkDEP_ESTADO"
            Me.chkDEP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDEP_ESTADO.TabIndex = 4
            Me.chkDEP_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDEP_DESCRIPCION
            '
            Me.lblDEP_DESCRIPCION.AutoSize = True
            Me.lblDEP_DESCRIPCION.Location = New System.Drawing.Point(13, 94)
            Me.lblDEP_DESCRIPCION.Name = "lblDEP_DESCRIPCION"
            Me.lblDEP_DESCRIPCION.Size = New System.Drawing.Size(105, 13)
            Me.lblDEP_DESCRIPCION.TabIndex = 21
            Me.lblDEP_DESCRIPCION.Text = "Desc. Departamento"
            '
            'txtDEP_DESCRIPCION
            '
            Me.txtDEP_DESCRIPCION.Enabled = False
            Me.txtDEP_DESCRIPCION.Location = New System.Drawing.Point(120, 94)
            Me.txtDEP_DESCRIPCION.Name = "txtDEP_DESCRIPCION"
            Me.txtDEP_DESCRIPCION.ReadOnly = True
            Me.txtDEP_DESCRIPCION.Size = New System.Drawing.Size(511, 20)
            Me.txtDEP_DESCRIPCION.TabIndex = 3
            '
            'lblDEP_ID
            '
            Me.lblDEP_ID.AutoSize = True
            Me.lblDEP_ID.Location = New System.Drawing.Point(13, 71)
            Me.lblDEP_ID.Name = "lblDEP_ID"
            Me.lblDEP_ID.Size = New System.Drawing.Size(99, 13)
            Me.lblDEP_ID.TabIndex = 20
            Me.lblDEP_ID.Text = "Cód. Departamento"
            '
            'txtDEP_ID
            '
            Me.txtDEP_ID.Location = New System.Drawing.Point(120, 71)
            Me.txtDEP_ID.Name = "txtDEP_ID"
            Me.txtDEP_ID.Size = New System.Drawing.Size(511, 20)
            Me.txtDEP_ID.TabIndex = 2
            '
            'lblPAI_ESTADO
            '
            Me.lblPAI_ESTADO.AutoSize = True
            Me.lblPAI_ESTADO.Location = New System.Drawing.Point(13, 195)
            Me.lblPAI_ESTADO.Name = "lblPAI_ESTADO"
            Me.lblPAI_ESTADO.Size = New System.Drawing.Size(50, 13)
            Me.lblPAI_ESTADO.TabIndex = 14
            Me.lblPAI_ESTADO.Text = "Est. País"
            '
            'chkPAI_ESTADO
            '
            Me.chkPAI_ESTADO.AutoSize = True
            Me.chkPAI_ESTADO.Enabled = False
            Me.chkPAI_ESTADO.Location = New System.Drawing.Point(120, 196)
            Me.chkPAI_ESTADO.Name = "chkPAI_ESTADO"
            Me.chkPAI_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPAI_ESTADO.TabIndex = 7
            Me.chkPAI_ESTADO.UseVisualStyleBackColor = True
            '
            'lblPAI_DESCRIPCION
            '
            Me.lblPAI_DESCRIPCION.AutoSize = True
            Me.lblPAI_DESCRIPCION.Location = New System.Drawing.Point(13, 171)
            Me.lblPAI_DESCRIPCION.Name = "lblPAI_DESCRIPCION"
            Me.lblPAI_DESCRIPCION.Size = New System.Drawing.Size(60, 13)
            Me.lblPAI_DESCRIPCION.TabIndex = 12
            Me.lblPAI_DESCRIPCION.Text = "Desc. País"
            '
            'txtPAI_DESCRIPCION
            '
            Me.txtPAI_DESCRIPCION.Enabled = False
            Me.txtPAI_DESCRIPCION.Location = New System.Drawing.Point(120, 171)
            Me.txtPAI_DESCRIPCION.Name = "txtPAI_DESCRIPCION"
            Me.txtPAI_DESCRIPCION.ReadOnly = True
            Me.txtPAI_DESCRIPCION.Size = New System.Drawing.Size(511, 20)
            Me.txtPAI_DESCRIPCION.TabIndex = 6
            '
            'lblPAI_ID
            '
            Me.lblPAI_ID.AutoSize = True
            Me.lblPAI_ID.Location = New System.Drawing.Point(13, 147)
            Me.lblPAI_ID.Name = "lblPAI_ID"
            Me.lblPAI_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblPAI_ID.TabIndex = 10
            Me.lblPAI_ID.Text = "Cód. País"
            '
            'txtPAI_ID
            '
            Me.txtPAI_ID.Enabled = False
            Me.txtPAI_ID.Location = New System.Drawing.Point(120, 147)
            Me.txtPAI_ID.Name = "txtPAI_ID"
            Me.txtPAI_ID.ReadOnly = True
            Me.txtPAI_ID.Size = New System.Drawing.Size(511, 20)
            Me.txtPAI_ID.TabIndex = 5
            '
            'lblPRO_ID
            '
            Me.lblPRO_ID.AutoSize = True
            Me.lblPRO_ID.Location = New System.Drawing.Point(13, 15)
            Me.lblPRO_ID.Name = "lblPRO_ID"
            Me.lblPRO_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblPRO_ID.TabIndex = 0
            Me.lblPRO_ID.Text = "Código"
            '
            'lblPRO_DESCRIPCION
            '
            Me.lblPRO_DESCRIPCION.AutoSize = True
            Me.lblPRO_DESCRIPCION.Location = New System.Drawing.Point(13, 39)
            Me.lblPRO_DESCRIPCION.Name = "lblPRO_DESCRIPCION"
            Me.lblPRO_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblPRO_DESCRIPCION.TabIndex = 1
            Me.lblPRO_DESCRIPCION.Text = "Descripción"
            '
            'lblPRO_ESTADO
            '
            Me.lblPRO_ESTADO.AutoSize = True
            Me.lblPRO_ESTADO.Location = New System.Drawing.Point(13, 249)
            Me.lblPRO_ESTADO.Name = "lblPRO_ESTADO"
            Me.lblPRO_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblPRO_ESTADO.TabIndex = 4
            Me.lblPRO_ESTADO.Text = "Estado"
            '
            'txtPRO_ID
            '
            Me.txtPRO_ID.Location = New System.Drawing.Point(120, 15)
            Me.txtPRO_ID.Name = "txtPRO_ID"
            Me.txtPRO_ID.Size = New System.Drawing.Size(511, 20)
            Me.txtPRO_ID.TabIndex = 0
            '
            'txtPRO_DESCRIPCION
            '
            Me.txtPRO_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPRO_DESCRIPCION.Location = New System.Drawing.Point(120, 39)
            Me.txtPRO_DESCRIPCION.Name = "txtPRO_DESCRIPCION"
            Me.txtPRO_DESCRIPCION.Size = New System.Drawing.Size(511, 20)
            Me.txtPRO_DESCRIPCION.TabIndex = 1
            '
            'chkPRO_ESTADO
            '
            Me.chkPRO_ESTADO.AutoSize = True
            Me.chkPRO_ESTADO.Location = New System.Drawing.Point(120, 250)
            Me.chkPRO_ESTADO.Name = "chkPRO_ESTADO"
            Me.chkPRO_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPRO_ESTADO.TabIndex = 9
            Me.chkPRO_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmProvincia
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(728, 365)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmProvincia"
            Me.Text = "Provincia"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblDEP_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkDEP_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblDEP_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtDEP_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDEP_ID As System.Windows.Forms.Label
        Public WithEvents txtDEP_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPAI_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPAI_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPAI_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtPAI_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPAI_ID As System.Windows.Forms.Label
        Public WithEvents txtPAI_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPRO_ID As System.Windows.Forms.Label
        Friend WithEvents lblPRO_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblPRO_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPRO_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPRO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents chkPRO_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblPRO_COD_SUNAT As System.Windows.Forms.Label
        Public WithEvents txtPRO_COD_SUNAT As System.Windows.Forms.TextBox
    End Class
End Namespace