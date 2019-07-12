Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoPersonas
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
            Me.lblTPE_CONTACTO = New System.Windows.Forms.Label()
            Me.lblCOM_ESTADO = New System.Windows.Forms.Label()
            Me.lblTPE_PROVEEDOR = New System.Windows.Forms.Label()
            Me.chkCOM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblTPE_TRABAJADOR = New System.Windows.Forms.Label()
            Me.lblCOM_ID = New System.Windows.Forms.Label()
            Me.chkTPE_CONTACTO = New System.Windows.Forms.CheckBox()
            Me.lblCOM_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblTPE_TRANSPORTISTA = New System.Windows.Forms.Label()
            Me.lblTPE_GRUPO = New System.Windows.Forms.Label()
            Me.chkTPE_TRANSPORTISTA = New System.Windows.Forms.CheckBox()
            Me.txtCOM_ID = New System.Windows.Forms.TextBox()
            Me.lblTPE_BANCO = New System.Windows.Forms.Label()
            Me.chkTPE_GRUPO = New System.Windows.Forms.CheckBox()
            Me.chkTPE_TRABAJADOR = New System.Windows.Forms.CheckBox()
            Me.txtCOM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkTPE_PROVEEDOR = New System.Windows.Forms.CheckBox()
            Me.chkTPE_BANCO = New System.Windows.Forms.CheckBox()
            Me.lblTPE_CLIENTE = New System.Windows.Forms.Label()
            Me.chkTPE_CLIENTE = New System.Windows.Forms.CheckBox()
            Me.lblTPE_ESTADO = New System.Windows.Forms.Label()
            Me.chkTPE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblTPE_ID = New System.Windows.Forms.Label()
            Me.lblTPE_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtTPE_ID = New System.Windows.Forms.TextBox()
            Me.txtTPE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.gbDatosTipo = New System.Windows.Forms.GroupBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(771, 28)
            Me.lblTitle.Text = "Tipo personas"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTPE_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.chkCOM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_ID)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_BANCO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_BANCO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTPE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTPE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.gbDatosTipo)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(702, 193)
            Me.pnCuerpo.TabIndex = 20
            '
            'lblTPE_CONTACTO
            '
            Me.lblTPE_CONTACTO.AutoSize = True
            Me.lblTPE_CONTACTO.Location = New System.Drawing.Point(211, 123)
            Me.lblTPE_CONTACTO.Name = "lblTPE_CONTACTO"
            Me.lblTPE_CONTACTO.Size = New System.Drawing.Size(50, 13)
            Me.lblTPE_CONTACTO.TabIndex = 118
            Me.lblTPE_CONTACTO.Text = "Contacto"
            '
            'lblCOM_ESTADO
            '
            Me.lblCOM_ESTADO.AutoSize = True
            Me.lblCOM_ESTADO.Location = New System.Drawing.Point(541, 33)
            Me.lblCOM_ESTADO.Name = "lblCOM_ESTADO"
            Me.lblCOM_ESTADO.Size = New System.Drawing.Size(52, 13)
            Me.lblCOM_ESTADO.TabIndex = 126
            Me.lblCOM_ESTADO.Text = "Est. Com."
            '
            'lblTPE_PROVEEDOR
            '
            Me.lblTPE_PROVEEDOR.AutoSize = True
            Me.lblTPE_PROVEEDOR.Location = New System.Drawing.Point(211, 87)
            Me.lblTPE_PROVEEDOR.Name = "lblTPE_PROVEEDOR"
            Me.lblTPE_PROVEEDOR.Size = New System.Drawing.Size(56, 13)
            Me.lblTPE_PROVEEDOR.TabIndex = 111
            Me.lblTPE_PROVEEDOR.Text = "Proveedor"
            '
            'chkCOM_ESTADO
            '
            Me.chkCOM_ESTADO.AutoSize = True
            Me.chkCOM_ESTADO.Enabled = False
            Me.chkCOM_ESTADO.Location = New System.Drawing.Point(595, 33)
            Me.chkCOM_ESTADO.Name = "chkCOM_ESTADO"
            Me.chkCOM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCOM_ESTADO.TabIndex = 4
            Me.chkCOM_ESTADO.UseVisualStyleBackColor = True
            '
            'lblTPE_TRABAJADOR
            '
            Me.lblTPE_TRABAJADOR.AutoSize = True
            Me.lblTPE_TRABAJADOR.Location = New System.Drawing.Point(389, 87)
            Me.lblTPE_TRABAJADOR.Name = "lblTPE_TRABAJADOR"
            Me.lblTPE_TRABAJADOR.Size = New System.Drawing.Size(58, 13)
            Me.lblTPE_TRABAJADOR.TabIndex = 113
            Me.lblTPE_TRABAJADOR.Text = "Trabajador"
            '
            'lblCOM_ID
            '
            Me.lblCOM_ID.AutoSize = True
            Me.lblCOM_ID.Location = New System.Drawing.Point(10, 33)
            Me.lblCOM_ID.Name = "lblCOM_ID"
            Me.lblCOM_ID.Size = New System.Drawing.Size(56, 13)
            Me.lblCOM_ID.TabIndex = 124
            Me.lblCOM_ID.Text = "Cód. Com."
            '
            'chkTPE_CONTACTO
            '
            Me.chkTPE_CONTACTO.AutoSize = True
            Me.chkTPE_CONTACTO.Location = New System.Drawing.Point(273, 123)
            Me.chkTPE_CONTACTO.Name = "chkTPE_CONTACTO"
            Me.chkTPE_CONTACTO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_CONTACTO.TabIndex = 10
            Me.chkTPE_CONTACTO.UseVisualStyleBackColor = True
            '
            'lblCOM_DESCRIPCION
            '
            Me.lblCOM_DESCRIPCION.AutoSize = True
            Me.lblCOM_DESCRIPCION.Location = New System.Drawing.Point(121, 33)
            Me.lblCOM_DESCRIPCION.Name = "lblCOM_DESCRIPCION"
            Me.lblCOM_DESCRIPCION.Size = New System.Drawing.Size(62, 13)
            Me.lblCOM_DESCRIPCION.TabIndex = 125
            Me.lblCOM_DESCRIPCION.Text = "Desc. Com."
            '
            'lblTPE_TRANSPORTISTA
            '
            Me.lblTPE_TRANSPORTISTA.AutoSize = True
            Me.lblTPE_TRANSPORTISTA.Location = New System.Drawing.Point(389, 123)
            Me.lblTPE_TRANSPORTISTA.Name = "lblTPE_TRANSPORTISTA"
            Me.lblTPE_TRANSPORTISTA.Size = New System.Drawing.Size(68, 13)
            Me.lblTPE_TRANSPORTISTA.TabIndex = 112
            Me.lblTPE_TRANSPORTISTA.Text = "Transportista"
            '
            'lblTPE_GRUPO
            '
            Me.lblTPE_GRUPO.AutoSize = True
            Me.lblTPE_GRUPO.Location = New System.Drawing.Point(71, 123)
            Me.lblTPE_GRUPO.Name = "lblTPE_GRUPO"
            Me.lblTPE_GRUPO.Size = New System.Drawing.Size(36, 13)
            Me.lblTPE_GRUPO.TabIndex = 117
            Me.lblTPE_GRUPO.Text = "Grupo"
            '
            'chkTPE_TRANSPORTISTA
            '
            Me.chkTPE_TRANSPORTISTA.AutoSize = True
            Me.chkTPE_TRANSPORTISTA.Location = New System.Drawing.Point(460, 123)
            Me.chkTPE_TRANSPORTISTA.Name = "chkTPE_TRANSPORTISTA"
            Me.chkTPE_TRANSPORTISTA.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_TRANSPORTISTA.TabIndex = 11
            Me.chkTPE_TRANSPORTISTA.UseVisualStyleBackColor = True
            '
            'txtCOM_ID
            '
            Me.txtCOM_ID.Location = New System.Drawing.Point(71, 33)
            Me.txtCOM_ID.Name = "txtCOM_ID"
            Me.txtCOM_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtCOM_ID.TabIndex = 2
            '
            'lblTPE_BANCO
            '
            Me.lblTPE_BANCO.AutoSize = True
            Me.lblTPE_BANCO.Location = New System.Drawing.Point(541, 87)
            Me.lblTPE_BANCO.Name = "lblTPE_BANCO"
            Me.lblTPE_BANCO.Size = New System.Drawing.Size(38, 13)
            Me.lblTPE_BANCO.TabIndex = 116
            Me.lblTPE_BANCO.Text = "Banco"
            '
            'chkTPE_GRUPO
            '
            Me.chkTPE_GRUPO.AutoSize = True
            Me.chkTPE_GRUPO.Location = New System.Drawing.Point(121, 123)
            Me.chkTPE_GRUPO.Name = "chkTPE_GRUPO"
            Me.chkTPE_GRUPO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_GRUPO.TabIndex = 9
            Me.chkTPE_GRUPO.UseVisualStyleBackColor = True
            '
            'chkTPE_TRABAJADOR
            '
            Me.chkTPE_TRABAJADOR.AutoSize = True
            Me.chkTPE_TRABAJADOR.Location = New System.Drawing.Point(460, 87)
            Me.chkTPE_TRABAJADOR.Name = "chkTPE_TRABAJADOR"
            Me.chkTPE_TRABAJADOR.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_TRABAJADOR.TabIndex = 7
            Me.chkTPE_TRABAJADOR.UseVisualStyleBackColor = True
            '
            'txtCOM_DESCRIPCION
            '
            Me.txtCOM_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCOM_DESCRIPCION.Enabled = False
            Me.txtCOM_DESCRIPCION.Location = New System.Drawing.Point(188, 33)
            Me.txtCOM_DESCRIPCION.Name = "txtCOM_DESCRIPCION"
            Me.txtCOM_DESCRIPCION.ReadOnly = True
            Me.txtCOM_DESCRIPCION.Size = New System.Drawing.Size(331, 20)
            Me.txtCOM_DESCRIPCION.TabIndex = 3
            '
            'chkTPE_PROVEEDOR
            '
            Me.chkTPE_PROVEEDOR.AutoSize = True
            Me.chkTPE_PROVEEDOR.Location = New System.Drawing.Point(273, 87)
            Me.chkTPE_PROVEEDOR.Name = "chkTPE_PROVEEDOR"
            Me.chkTPE_PROVEEDOR.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_PROVEEDOR.TabIndex = 6
            Me.chkTPE_PROVEEDOR.UseVisualStyleBackColor = True
            '
            'chkTPE_BANCO
            '
            Me.chkTPE_BANCO.AutoSize = True
            Me.chkTPE_BANCO.Location = New System.Drawing.Point(595, 87)
            Me.chkTPE_BANCO.Name = "chkTPE_BANCO"
            Me.chkTPE_BANCO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_BANCO.TabIndex = 8
            Me.chkTPE_BANCO.UseVisualStyleBackColor = True
            '
            'lblTPE_CLIENTE
            '
            Me.lblTPE_CLIENTE.AutoSize = True
            Me.lblTPE_CLIENTE.Location = New System.Drawing.Point(71, 87)
            Me.lblTPE_CLIENTE.Name = "lblTPE_CLIENTE"
            Me.lblTPE_CLIENTE.Size = New System.Drawing.Size(39, 13)
            Me.lblTPE_CLIENTE.TabIndex = 110
            Me.lblTPE_CLIENTE.Text = "Cliente"
            '
            'chkTPE_CLIENTE
            '
            Me.chkTPE_CLIENTE.AutoSize = True
            Me.chkTPE_CLIENTE.Location = New System.Drawing.Point(121, 87)
            Me.chkTPE_CLIENTE.Name = "chkTPE_CLIENTE"
            Me.chkTPE_CLIENTE.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_CLIENTE.TabIndex = 5
            Me.chkTPE_CLIENTE.UseVisualStyleBackColor = True
            '
            'lblTPE_ESTADO
            '
            Me.lblTPE_ESTADO.AutoSize = True
            Me.lblTPE_ESTADO.Location = New System.Drawing.Point(10, 165)
            Me.lblTPE_ESTADO.Name = "lblTPE_ESTADO"
            Me.lblTPE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTPE_ESTADO.TabIndex = 102
            Me.lblTPE_ESTADO.Text = "Estado"
            '
            'chkTPE_ESTADO
            '
            Me.chkTPE_ESTADO.AutoSize = True
            Me.chkTPE_ESTADO.Location = New System.Drawing.Point(71, 165)
            Me.chkTPE_ESTADO.Name = "chkTPE_ESTADO"
            Me.chkTPE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_ESTADO.TabIndex = 12
            Me.chkTPE_ESTADO.UseVisualStyleBackColor = True
            '
            'lblTPE_ID
            '
            Me.lblTPE_ID.AutoSize = True
            Me.lblTPE_ID.Location = New System.Drawing.Point(10, 7)
            Me.lblTPE_ID.Name = "lblTPE_ID"
            Me.lblTPE_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblTPE_ID.TabIndex = 28
            Me.lblTPE_ID.Text = "Código"
            '
            'lblTPE_DESCRIPCION
            '
            Me.lblTPE_DESCRIPCION.AutoSize = True
            Me.lblTPE_DESCRIPCION.Location = New System.Drawing.Point(121, 7)
            Me.lblTPE_DESCRIPCION.Name = "lblTPE_DESCRIPCION"
            Me.lblTPE_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblTPE_DESCRIPCION.TabIndex = 30
            Me.lblTPE_DESCRIPCION.Text = "Descripción"
            '
            'txtTPE_ID
            '
            Me.txtTPE_ID.Location = New System.Drawing.Point(71, 7)
            Me.txtTPE_ID.Name = "txtTPE_ID"
            Me.txtTPE_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtTPE_ID.TabIndex = 0
            '
            'txtTPE_DESCRIPCION
            '
            Me.txtTPE_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTPE_DESCRIPCION.Location = New System.Drawing.Point(188, 7)
            Me.txtTPE_DESCRIPCION.Name = "txtTPE_DESCRIPCION"
            Me.txtTPE_DESCRIPCION.Size = New System.Drawing.Size(489, 20)
            Me.txtTPE_DESCRIPCION.TabIndex = 1
            '
            'gbDatosTipo
            '
            Me.gbDatosTipo.Location = New System.Drawing.Point(10, 72)
            Me.gbDatosTipo.Name = "gbDatosTipo"
            Me.gbDatosTipo.Size = New System.Drawing.Size(667, 77)
            Me.gbDatosTipo.TabIndex = 120
            Me.gbDatosTipo.TabStop = False
            Me.gbDatosTipo.Text = "Tipo"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(679, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(56, 28)
            Me.btnImagen.TabIndex = 34
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmTipoPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(771, 261)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmTipoPersonas"
            Me.Text = "Tipo personas"
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
        Friend WithEvents lblTPE_CLIENTE As System.Windows.Forms.Label
        Public WithEvents chkTPE_CLIENTE As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkTPE_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_ID As System.Windows.Forms.Label
        Friend WithEvents lblTPE_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtTPE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTPE_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblCOM_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkCOM_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblCOM_ID As System.Windows.Forms.Label
        Friend WithEvents lblCOM_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtCOM_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCOM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblTPE_CONTACTO As System.Windows.Forms.Label
        Friend WithEvents lblTPE_PROVEEDOR As System.Windows.Forms.Label
        Friend WithEvents lblTPE_TRABAJADOR As System.Windows.Forms.Label
        Public WithEvents chkTPE_CONTACTO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_TRANSPORTISTA As System.Windows.Forms.Label
        Friend WithEvents lblTPE_GRUPO As System.Windows.Forms.Label
        Public WithEvents chkTPE_TRANSPORTISTA As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_BANCO As System.Windows.Forms.Label
        Public WithEvents chkTPE_GRUPO As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_TRABAJADOR As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_PROVEEDOR As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_BANCO As System.Windows.Forms.CheckBox
        Friend WithEvents gbDatosTipo As System.Windows.Forms.GroupBox
    End Class
End Namespace