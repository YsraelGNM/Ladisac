<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblConectarse = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnConectarseA = New System.Windows.Forms.Button()
        Me.btnDiamante = New System.Windows.Forms.Button()
        Me.btnAgencia = New System.Windows.Forms.Button()
        Me.UPDATE = New System.Windows.Forms.GroupBox()
        Me.UPDATE.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(120, 121)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Enabled = False
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Items.AddRange(New Object() {"Diamante en la principal.", "Diamante en la agencia.", "Comercial en la principal.", "Comercial en la agencia.", "Diamante copia.", "Comercial copia.", "Inka."})
        Me.cboEmpresa.Location = New System.Drawing.Point(120, 23)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(172, 21)
        Me.cboEmpresa.TabIndex = 2
        '
        'lblConectarse
        '
        Me.lblConectarse.AutoSize = True
        Me.lblConectarse.Location = New System.Drawing.Point(29, 23)
        Me.lblConectarse.Name = "lblConectarse"
        Me.lblConectarse.Size = New System.Drawing.Size(73, 13)
        Me.lblConectarse.TabIndex = 7
        Me.lblConectarse.Text = "Conectarse a:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(120, 55)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(172, 20)
        Me.txtUsuario.TabIndex = 4
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(120, 84)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(172, 20)
        Me.txtContraseña.TabIndex = 6
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(29, 55)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(49, 13)
        Me.lblUsuario.TabIndex = 3
        Me.lblUsuario.Text = "Usuario :"
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Location = New System.Drawing.Point(29, 84)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(67, 13)
        Me.lblContraseña.TabIndex = 5
        Me.lblContraseña.Text = "Contraseña :"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(217, 121)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnConectarseA
        '
        Me.btnConectarseA.Enabled = False
        Me.btnConectarseA.Location = New System.Drawing.Point(26, 23)
        Me.btnConectarseA.Name = "btnConectarseA"
        Me.btnConectarseA.Size = New System.Drawing.Size(83, 23)
        Me.btnConectarseA.TabIndex = 1
        Me.btnConectarseA.Text = "Conectarse a:"
        Me.btnConectarseA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConectarseA.UseVisualStyleBackColor = True
        '
        'btnDiamante
        '
        Me.btnDiamante.Location = New System.Drawing.Point(6, 19)
        Me.btnDiamante.Name = "btnDiamante"
        Me.btnDiamante.Size = New System.Drawing.Size(75, 23)
        Me.btnDiamante.TabIndex = 9
        Me.btnDiamante.Text = "Diamante"
        Me.btnDiamante.UseVisualStyleBackColor = True
        '
        'btnAgencia
        '
        Me.btnAgencia.Location = New System.Drawing.Point(107, 19)
        Me.btnAgencia.Name = "btnAgencia"
        Me.btnAgencia.Size = New System.Drawing.Size(75, 23)
        Me.btnAgencia.TabIndex = 10
        Me.btnAgencia.Text = "Agencia"
        Me.btnAgencia.UseVisualStyleBackColor = True
        Me.btnAgencia.Visible = False
        '
        'UPDATE
        '
        Me.UPDATE.Controls.Add(Me.btnDiamante)
        Me.UPDATE.Controls.Add(Me.btnAgencia)
        Me.UPDATE.Location = New System.Drawing.Point(12, 170)
        Me.UPDATE.Name = "UPDATE"
        Me.UPDATE.Size = New System.Drawing.Size(191, 55)
        Me.UPDATE.TabIndex = 11
        Me.UPDATE.TabStop = False
        Me.UPDATE.Text = "ACTUALIZAR SISTEMA"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 234)
        Me.Controls.Add(Me.UPDATE)
        Me.Controls.Add(Me.btnConectarseA)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblConectarse)
        Me.Controls.Add(Me.cboEmpresa)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso"
        Me.UPDATE.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblConectarse As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnConectarseA As System.Windows.Forms.Button
    Friend WithEvents btnDiamante As System.Windows.Forms.Button
    Friend WithEvents btnAgencia As System.Windows.Forms.Button
    Friend WithEvents UPDATE As System.Windows.Forms.GroupBox
End Class
