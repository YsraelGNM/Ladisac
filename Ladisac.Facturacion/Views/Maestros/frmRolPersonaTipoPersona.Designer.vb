Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolPersonaTipoPersona
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
            Me.lblTPE_TRABAJADOR = New System.Windows.Forms.Label()
            Me.lblTPE_GRUPO = New System.Windows.Forms.Label()
            Me.chkTPE_TRABAJADOR = New System.Windows.Forms.CheckBox()
            Me.lblTPE_BANCO = New System.Windows.Forms.Label()
            Me.lblTPE_TRANSPORTISTA = New System.Windows.Forms.Label()
            Me.chkTPE_TRANSPORTISTA = New System.Windows.Forms.CheckBox()
            Me.lblTPE_PROVEEDOR = New System.Windows.Forms.Label()
            Me.chkTPE_PROVEEDOR = New System.Windows.Forms.CheckBox()
            Me.lblTPE_CLIENTE = New System.Windows.Forms.Label()
            Me.chkTPE_CLIENTE = New System.Windows.Forms.CheckBox()
            Me.chkTPE_BANCO = New System.Windows.Forms.CheckBox()
            Me.chkTPE_GRUPO = New System.Windows.Forms.CheckBox()
            Me.chkTPE_CONTACTO = New System.Windows.Forms.CheckBox()
            Me.lblPER_CONTACTO = New System.Windows.Forms.Label()
            Me.lblPER_TRABAJADOR = New System.Windows.Forms.Label()
            Me.lblPER_GRUPO = New System.Windows.Forms.Label()
            Me.chkPER_TRABAJADOR = New System.Windows.Forms.CheckBox()
            Me.lblPER_BANCO = New System.Windows.Forms.Label()
            Me.lblPER_TRANSPORTISTA = New System.Windows.Forms.Label()
            Me.chkPER_TRANSPORTISTA = New System.Windows.Forms.CheckBox()
            Me.lblPER_PROVEEDOR = New System.Windows.Forms.Label()
            Me.chkPER_PROVEEDOR = New System.Windows.Forms.CheckBox()
            Me.lblPER_CLIENTE = New System.Windows.Forms.Label()
            Me.chkPER_CLIENTE = New System.Windows.Forms.CheckBox()
            Me.chkPER_BANCO = New System.Windows.Forms.CheckBox()
            Me.chkPER_GRUPO = New System.Windows.Forms.CheckBox()
            Me.chkPER_CONTACTO = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblPER_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblTPE_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtTPE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblTPE_ID = New System.Windows.Forms.Label()
            Me.txtTPE_ID = New System.Windows.Forms.TextBox()
            Me.lblRTP_ESTADO = New System.Windows.Forms.Label()
            Me.chkRTP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(734, 28)
            Me.lblTitle.Text = "Rol persona tipo persona"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTPE_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_BANCO)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_BANCO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkTPE_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.lblPER_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_TRABAJADOR)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BANCO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.chkPER_TRANSPORTISTA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.chkPER_PROVEEDOR)
            Me.pnCuerpo.Controls.Add(Me.lblPER_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkPER_CLIENTE)
            Me.pnCuerpo.Controls.Add(Me.chkPER_BANCO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_GRUPO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_CONTACTO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTPE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTPE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTPE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblRTP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkRTP_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(668, 257)
            Me.pnCuerpo.TabIndex = 2
            '
            'lblTPE_CONTACTO
            '
            Me.lblTPE_CONTACTO.AutoSize = True
            Me.lblTPE_CONTACTO.Location = New System.Drawing.Point(219, 197)
            Me.lblTPE_CONTACTO.Name = "lblTPE_CONTACTO"
            Me.lblTPE_CONTACTO.Size = New System.Drawing.Size(50, 13)
            Me.lblTPE_CONTACTO.TabIndex = 146
            Me.lblTPE_CONTACTO.Text = "Contacto"
            '
            'lblTPE_TRABAJADOR
            '
            Me.lblTPE_TRABAJADOR.AutoSize = True
            Me.lblTPE_TRABAJADOR.Location = New System.Drawing.Point(374, 177)
            Me.lblTPE_TRABAJADOR.Name = "lblTPE_TRABAJADOR"
            Me.lblTPE_TRABAJADOR.Size = New System.Drawing.Size(58, 13)
            Me.lblTPE_TRABAJADOR.TabIndex = 143
            Me.lblTPE_TRABAJADOR.Text = "Trabajador"
            '
            'lblTPE_GRUPO
            '
            Me.lblTPE_GRUPO.AutoSize = True
            Me.lblTPE_GRUPO.Location = New System.Drawing.Point(35, 197)
            Me.lblTPE_GRUPO.Name = "lblTPE_GRUPO"
            Me.lblTPE_GRUPO.Size = New System.Drawing.Size(36, 13)
            Me.lblTPE_GRUPO.TabIndex = 145
            Me.lblTPE_GRUPO.Text = "Grupo"
            '
            'chkTPE_TRABAJADOR
            '
            Me.chkTPE_TRABAJADOR.AutoSize = True
            Me.chkTPE_TRABAJADOR.Enabled = False
            Me.chkTPE_TRABAJADOR.Location = New System.Drawing.Point(449, 177)
            Me.chkTPE_TRABAJADOR.Name = "chkTPE_TRABAJADOR"
            Me.chkTPE_TRABAJADOR.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_TRABAJADOR.TabIndex = 13
            Me.chkTPE_TRABAJADOR.UseVisualStyleBackColor = True
            '
            'lblTPE_BANCO
            '
            Me.lblTPE_BANCO.AutoSize = True
            Me.lblTPE_BANCO.Location = New System.Drawing.Point(516, 177)
            Me.lblTPE_BANCO.Name = "lblTPE_BANCO"
            Me.lblTPE_BANCO.Size = New System.Drawing.Size(38, 13)
            Me.lblTPE_BANCO.TabIndex = 144
            Me.lblTPE_BANCO.Text = "Banco"
            '
            'lblTPE_TRANSPORTISTA
            '
            Me.lblTPE_TRANSPORTISTA.AutoSize = True
            Me.lblTPE_TRANSPORTISTA.Location = New System.Drawing.Point(374, 197)
            Me.lblTPE_TRANSPORTISTA.Name = "lblTPE_TRANSPORTISTA"
            Me.lblTPE_TRANSPORTISTA.Size = New System.Drawing.Size(68, 13)
            Me.lblTPE_TRANSPORTISTA.TabIndex = 142
            Me.lblTPE_TRANSPORTISTA.Text = "Transportista"
            '
            'chkTPE_TRANSPORTISTA
            '
            Me.chkTPE_TRANSPORTISTA.AutoSize = True
            Me.chkTPE_TRANSPORTISTA.Enabled = False
            Me.chkTPE_TRANSPORTISTA.Location = New System.Drawing.Point(449, 197)
            Me.chkTPE_TRANSPORTISTA.Name = "chkTPE_TRANSPORTISTA"
            Me.chkTPE_TRANSPORTISTA.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_TRANSPORTISTA.TabIndex = 17
            Me.chkTPE_TRANSPORTISTA.UseVisualStyleBackColor = True
            '
            'lblTPE_PROVEEDOR
            '
            Me.lblTPE_PROVEEDOR.AutoSize = True
            Me.lblTPE_PROVEEDOR.Location = New System.Drawing.Point(219, 177)
            Me.lblTPE_PROVEEDOR.Name = "lblTPE_PROVEEDOR"
            Me.lblTPE_PROVEEDOR.Size = New System.Drawing.Size(56, 13)
            Me.lblTPE_PROVEEDOR.TabIndex = 141
            Me.lblTPE_PROVEEDOR.Text = "Proveedor"
            '
            'chkTPE_PROVEEDOR
            '
            Me.chkTPE_PROVEEDOR.AutoSize = True
            Me.chkTPE_PROVEEDOR.Enabled = False
            Me.chkTPE_PROVEEDOR.Location = New System.Drawing.Point(289, 177)
            Me.chkTPE_PROVEEDOR.Name = "chkTPE_PROVEEDOR"
            Me.chkTPE_PROVEEDOR.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_PROVEEDOR.TabIndex = 12
            Me.chkTPE_PROVEEDOR.UseVisualStyleBackColor = True
            '
            'lblTPE_CLIENTE
            '
            Me.lblTPE_CLIENTE.AutoSize = True
            Me.lblTPE_CLIENTE.Location = New System.Drawing.Point(35, 177)
            Me.lblTPE_CLIENTE.Name = "lblTPE_CLIENTE"
            Me.lblTPE_CLIENTE.Size = New System.Drawing.Size(39, 13)
            Me.lblTPE_CLIENTE.TabIndex = 140
            Me.lblTPE_CLIENTE.Text = "Cliente"
            '
            'chkTPE_CLIENTE
            '
            Me.chkTPE_CLIENTE.AutoSize = True
            Me.chkTPE_CLIENTE.Enabled = False
            Me.chkTPE_CLIENTE.Location = New System.Drawing.Point(118, 177)
            Me.chkTPE_CLIENTE.Name = "chkTPE_CLIENTE"
            Me.chkTPE_CLIENTE.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_CLIENTE.TabIndex = 11
            Me.chkTPE_CLIENTE.UseVisualStyleBackColor = True
            '
            'chkTPE_BANCO
            '
            Me.chkTPE_BANCO.AutoSize = True
            Me.chkTPE_BANCO.Enabled = False
            Me.chkTPE_BANCO.Location = New System.Drawing.Point(564, 177)
            Me.chkTPE_BANCO.Name = "chkTPE_BANCO"
            Me.chkTPE_BANCO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_BANCO.TabIndex = 14
            Me.chkTPE_BANCO.UseVisualStyleBackColor = True
            '
            'chkTPE_GRUPO
            '
            Me.chkTPE_GRUPO.AutoSize = True
            Me.chkTPE_GRUPO.Enabled = False
            Me.chkTPE_GRUPO.Location = New System.Drawing.Point(118, 197)
            Me.chkTPE_GRUPO.Name = "chkTPE_GRUPO"
            Me.chkTPE_GRUPO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_GRUPO.TabIndex = 15
            Me.chkTPE_GRUPO.UseVisualStyleBackColor = True
            '
            'chkTPE_CONTACTO
            '
            Me.chkTPE_CONTACTO.AutoSize = True
            Me.chkTPE_CONTACTO.Enabled = False
            Me.chkTPE_CONTACTO.Location = New System.Drawing.Point(289, 197)
            Me.chkTPE_CONTACTO.Name = "chkTPE_CONTACTO"
            Me.chkTPE_CONTACTO.Size = New System.Drawing.Size(15, 14)
            Me.chkTPE_CONTACTO.TabIndex = 16
            Me.chkTPE_CONTACTO.UseVisualStyleBackColor = True
            '
            'lblPER_CONTACTO
            '
            Me.lblPER_CONTACTO.AutoSize = True
            Me.lblPER_CONTACTO.Location = New System.Drawing.Point(219, 87)
            Me.lblPER_CONTACTO.Name = "lblPER_CONTACTO"
            Me.lblPER_CONTACTO.Size = New System.Drawing.Size(50, 13)
            Me.lblPER_CONTACTO.TabIndex = 132
            Me.lblPER_CONTACTO.Text = "Contacto"
            '
            'lblPER_TRABAJADOR
            '
            Me.lblPER_TRABAJADOR.AutoSize = True
            Me.lblPER_TRABAJADOR.Location = New System.Drawing.Point(374, 64)
            Me.lblPER_TRABAJADOR.Name = "lblPER_TRABAJADOR"
            Me.lblPER_TRABAJADOR.Size = New System.Drawing.Size(58, 13)
            Me.lblPER_TRABAJADOR.TabIndex = 129
            Me.lblPER_TRABAJADOR.Text = "Trabajador"
            '
            'lblPER_GRUPO
            '
            Me.lblPER_GRUPO.AutoSize = True
            Me.lblPER_GRUPO.Location = New System.Drawing.Point(35, 87)
            Me.lblPER_GRUPO.Name = "lblPER_GRUPO"
            Me.lblPER_GRUPO.Size = New System.Drawing.Size(36, 13)
            Me.lblPER_GRUPO.TabIndex = 131
            Me.lblPER_GRUPO.Text = "Grupo"
            '
            'chkPER_TRABAJADOR
            '
            Me.chkPER_TRABAJADOR.AutoSize = True
            Me.chkPER_TRABAJADOR.Enabled = False
            Me.chkPER_TRABAJADOR.Location = New System.Drawing.Point(449, 64)
            Me.chkPER_TRABAJADOR.Name = "chkPER_TRABAJADOR"
            Me.chkPER_TRABAJADOR.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_TRABAJADOR.TabIndex = 4
            Me.chkPER_TRABAJADOR.UseVisualStyleBackColor = True
            '
            'lblPER_BANCO
            '
            Me.lblPER_BANCO.AutoSize = True
            Me.lblPER_BANCO.Location = New System.Drawing.Point(516, 64)
            Me.lblPER_BANCO.Name = "lblPER_BANCO"
            Me.lblPER_BANCO.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_BANCO.TabIndex = 130
            Me.lblPER_BANCO.Text = "Banco"
            '
            'lblPER_TRANSPORTISTA
            '
            Me.lblPER_TRANSPORTISTA.AutoSize = True
            Me.lblPER_TRANSPORTISTA.Location = New System.Drawing.Point(374, 87)
            Me.lblPER_TRANSPORTISTA.Name = "lblPER_TRANSPORTISTA"
            Me.lblPER_TRANSPORTISTA.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_TRANSPORTISTA.TabIndex = 128
            Me.lblPER_TRANSPORTISTA.Text = "Transportista"
            '
            'chkPER_TRANSPORTISTA
            '
            Me.chkPER_TRANSPORTISTA.AutoSize = True
            Me.chkPER_TRANSPORTISTA.Enabled = False
            Me.chkPER_TRANSPORTISTA.Location = New System.Drawing.Point(449, 87)
            Me.chkPER_TRANSPORTISTA.Name = "chkPER_TRANSPORTISTA"
            Me.chkPER_TRANSPORTISTA.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_TRANSPORTISTA.TabIndex = 8
            Me.chkPER_TRANSPORTISTA.UseVisualStyleBackColor = True
            '
            'lblPER_PROVEEDOR
            '
            Me.lblPER_PROVEEDOR.AutoSize = True
            Me.lblPER_PROVEEDOR.Location = New System.Drawing.Point(219, 64)
            Me.lblPER_PROVEEDOR.Name = "lblPER_PROVEEDOR"
            Me.lblPER_PROVEEDOR.Size = New System.Drawing.Size(56, 13)
            Me.lblPER_PROVEEDOR.TabIndex = 127
            Me.lblPER_PROVEEDOR.Text = "Proveedor"
            '
            'chkPER_PROVEEDOR
            '
            Me.chkPER_PROVEEDOR.AutoSize = True
            Me.chkPER_PROVEEDOR.Enabled = False
            Me.chkPER_PROVEEDOR.Location = New System.Drawing.Point(289, 64)
            Me.chkPER_PROVEEDOR.Name = "chkPER_PROVEEDOR"
            Me.chkPER_PROVEEDOR.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_PROVEEDOR.TabIndex = 3
            Me.chkPER_PROVEEDOR.UseVisualStyleBackColor = True
            '
            'lblPER_CLIENTE
            '
            Me.lblPER_CLIENTE.AutoSize = True
            Me.lblPER_CLIENTE.Location = New System.Drawing.Point(35, 64)
            Me.lblPER_CLIENTE.Name = "lblPER_CLIENTE"
            Me.lblPER_CLIENTE.Size = New System.Drawing.Size(39, 13)
            Me.lblPER_CLIENTE.TabIndex = 126
            Me.lblPER_CLIENTE.Text = "Cliente"
            '
            'chkPER_CLIENTE
            '
            Me.chkPER_CLIENTE.AutoSize = True
            Me.chkPER_CLIENTE.Enabled = False
            Me.chkPER_CLIENTE.Location = New System.Drawing.Point(118, 64)
            Me.chkPER_CLIENTE.Name = "chkPER_CLIENTE"
            Me.chkPER_CLIENTE.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_CLIENTE.TabIndex = 2
            Me.chkPER_CLIENTE.UseVisualStyleBackColor = True
            '
            'chkPER_BANCO
            '
            Me.chkPER_BANCO.AutoSize = True
            Me.chkPER_BANCO.Enabled = False
            Me.chkPER_BANCO.Location = New System.Drawing.Point(564, 64)
            Me.chkPER_BANCO.Name = "chkPER_BANCO"
            Me.chkPER_BANCO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_BANCO.TabIndex = 5
            Me.chkPER_BANCO.UseVisualStyleBackColor = True
            '
            'chkPER_GRUPO
            '
            Me.chkPER_GRUPO.AutoSize = True
            Me.chkPER_GRUPO.Enabled = False
            Me.chkPER_GRUPO.Location = New System.Drawing.Point(118, 87)
            Me.chkPER_GRUPO.Name = "chkPER_GRUPO"
            Me.chkPER_GRUPO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_GRUPO.TabIndex = 6
            Me.chkPER_GRUPO.UseVisualStyleBackColor = True
            '
            'chkPER_CONTACTO
            '
            Me.chkPER_CONTACTO.AutoSize = True
            Me.chkPER_CONTACTO.Enabled = False
            Me.chkPER_CONTACTO.Location = New System.Drawing.Point(289, 87)
            Me.chkPER_CONTACTO.Name = "chkPER_CONTACTO"
            Me.chkPER_CONTACTO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_CONTACTO.TabIndex = 7
            Me.chkPER_CONTACTO.UseVisualStyleBackColor = True
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(15, 14)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(71, 13)
            Me.lblPER_ID.TabIndex = 28
            Me.lblPER_ID.Text = "Cód. Persona"
            '
            'lblPER_DESCRIPCION
            '
            Me.lblPER_DESCRIPCION.AutoSize = True
            Me.lblPER_DESCRIPCION.Location = New System.Drawing.Point(15, 37)
            Me.lblPER_DESCRIPCION.Name = "lblPER_DESCRIPCION"
            Me.lblPER_DESCRIPCION.Size = New System.Drawing.Size(77, 13)
            Me.lblPER_DESCRIPCION.TabIndex = 30
            Me.lblPER_DESCRIPCION.Text = "Desc. Persona"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(118, 14)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.ReadOnly = True
            Me.txtPER_ID.Size = New System.Drawing.Size(121, 20)
            Me.txtPER_ID.TabIndex = 0
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(118, 37)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(526, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 1
            '
            'lblTPE_DESCRIPCION
            '
            Me.lblTPE_DESCRIPCION.AutoSize = True
            Me.lblTPE_DESCRIPCION.Location = New System.Drawing.Point(15, 146)
            Me.lblTPE_DESCRIPCION.Name = "lblTPE_DESCRIPCION"
            Me.lblTPE_DESCRIPCION.Size = New System.Drawing.Size(100, 13)
            Me.lblTPE_DESCRIPCION.TabIndex = 21
            Me.lblTPE_DESCRIPCION.Text = "Desc. Tipo persona"
            '
            'txtTPE_DESCRIPCION
            '
            Me.txtTPE_DESCRIPCION.Enabled = False
            Me.txtTPE_DESCRIPCION.Location = New System.Drawing.Point(118, 146)
            Me.txtTPE_DESCRIPCION.Name = "txtTPE_DESCRIPCION"
            Me.txtTPE_DESCRIPCION.ReadOnly = True
            Me.txtTPE_DESCRIPCION.Size = New System.Drawing.Size(526, 20)
            Me.txtTPE_DESCRIPCION.TabIndex = 10
            '
            'lblTPE_ID
            '
            Me.lblTPE_ID.AutoSize = True
            Me.lblTPE_ID.Location = New System.Drawing.Point(15, 122)
            Me.lblTPE_ID.Name = "lblTPE_ID"
            Me.lblTPE_ID.Size = New System.Drawing.Size(94, 13)
            Me.lblTPE_ID.TabIndex = 20
            Me.lblTPE_ID.Text = "Cód. Tipo persona"
            '
            'txtTPE_ID
            '
            Me.txtTPE_ID.Location = New System.Drawing.Point(118, 122)
            Me.txtTPE_ID.Name = "txtTPE_ID"
            Me.txtTPE_ID.ReadOnly = True
            Me.txtTPE_ID.Size = New System.Drawing.Size(121, 20)
            Me.txtTPE_ID.TabIndex = 9
            '
            'lblRTP_ESTADO
            '
            Me.lblRTP_ESTADO.AutoSize = True
            Me.lblRTP_ESTADO.Location = New System.Drawing.Point(15, 228)
            Me.lblRTP_ESTADO.Name = "lblRTP_ESTADO"
            Me.lblRTP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblRTP_ESTADO.TabIndex = 4
            Me.lblRTP_ESTADO.Text = "Estado"
            '
            'chkRTP_ESTADO
            '
            Me.chkRTP_ESTADO.AutoSize = True
            Me.chkRTP_ESTADO.Location = New System.Drawing.Point(118, 229)
            Me.chkRTP_ESTADO.Name = "chkRTP_ESTADO"
            Me.chkRTP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkRTP_ESTADO.TabIndex = 18
            Me.chkRTP_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(645, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(56, 28)
            Me.btnImagen.TabIndex = 34
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmRolPersonaTipoPersona
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(734, 313)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmRolPersonaTipoPersona"
            Me.Text = "Rol persona tipo persona"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblTPE_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtTPE_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblTPE_ID As System.Windows.Forms.Label
        Public WithEvents txtTPE_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblRTP_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkRTP_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_CONTACTO As System.Windows.Forms.Label
        Friend WithEvents lblPER_TRABAJADOR As System.Windows.Forms.Label
        Friend WithEvents lblPER_GRUPO As System.Windows.Forms.Label
        Public WithEvents chkPER_TRABAJADOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_BANCO As System.Windows.Forms.Label
        Friend WithEvents lblPER_TRANSPORTISTA As System.Windows.Forms.Label
        Public WithEvents chkPER_TRANSPORTISTA As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_PROVEEDOR As System.Windows.Forms.Label
        Public WithEvents chkPER_PROVEEDOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_CLIENTE As System.Windows.Forms.Label
        Public WithEvents chkPER_CLIENTE As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_BANCO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_GRUPO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_CONTACTO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_CONTACTO As System.Windows.Forms.Label
        Friend WithEvents lblTPE_TRABAJADOR As System.Windows.Forms.Label
        Friend WithEvents lblTPE_GRUPO As System.Windows.Forms.Label
        Public WithEvents chkTPE_TRABAJADOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_BANCO As System.Windows.Forms.Label
        Friend WithEvents lblTPE_TRANSPORTISTA As System.Windows.Forms.Label
        Public WithEvents chkTPE_TRANSPORTISTA As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_PROVEEDOR As System.Windows.Forms.Label
        Public WithEvents chkTPE_PROVEEDOR As System.Windows.Forms.CheckBox
        Friend WithEvents lblTPE_CLIENTE As System.Windows.Forms.Label
        Public WithEvents chkTPE_CLIENTE As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_BANCO As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_GRUPO As System.Windows.Forms.CheckBox
        Public WithEvents chkTPE_CONTACTO As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace