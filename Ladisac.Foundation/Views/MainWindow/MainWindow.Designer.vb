Namespace Ladisac.Foundation
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MainWindow
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
            Me.menuPrincipal = New System.Windows.Forms.MenuStrip()
            Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.statusprincipal = New System.Windows.Forms.StatusStrip()
            Me.tssMensajeGeneral = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tsSubMenu = New System.Windows.Forms.ToolStrip()
            Me.tssMensajeUsuario = New System.Windows.Forms.ToolStripStatusLabel()
            Me.StatusMensaje = New System.Windows.Forms.StatusStrip()
            Me.menuPrincipal.SuspendLayout()
            Me.statusprincipal.SuspendLayout()
            Me.StatusMensaje.SuspendLayout()
            Me.SuspendLayout()
            '
            'menuPrincipal
            '
            Me.menuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.SalirToolStripMenuItem})
            Me.menuPrincipal.Location = New System.Drawing.Point(0, 0)
            Me.menuPrincipal.Name = "menuPrincipal"
            Me.menuPrincipal.Size = New System.Drawing.Size(848, 24)
            Me.menuPrincipal.TabIndex = 1
            Me.menuPrincipal.Text = "MenuStrip1"
            '
            'ArchivoToolStripMenuItem
            '
            Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem})
            Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
            Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
            Me.ArchivoToolStripMenuItem.Text = "Archivo"
            '
            'LoginToolStripMenuItem
            '
            Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
            Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
            Me.LoginToolStripMenuItem.Text = "Login"
            '
            'SalirToolStripMenuItem
            '
            Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
            Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
            Me.SalirToolStripMenuItem.Text = "Salir"
            '
            'statusprincipal
            '
            Me.statusprincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.statusprincipal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.statusprincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssMensajeGeneral})
            Me.statusprincipal.Location = New System.Drawing.Point(0, 491)
            Me.statusprincipal.Name = "statusprincipal"
            Me.statusprincipal.Size = New System.Drawing.Size(848, 30)
            Me.statusprincipal.TabIndex = 3
            '
            'tssMensajeGeneral
            '
            Me.tssMensajeGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.tssMensajeGeneral.Name = "tssMensajeGeneral"
            Me.tssMensajeGeneral.Size = New System.Drawing.Size(152, 25)
            Me.tssMensajeGeneral.Text = "Mensaje general"
            '
            'tsSubMenu
            '
            Me.tsSubMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tsSubMenu.AutoSize = False
            Me.tsSubMenu.Dock = System.Windows.Forms.DockStyle.None
            Me.tsSubMenu.Enabled = False
            Me.tsSubMenu.ImageScalingSize = New System.Drawing.Size(63, 62)
            Me.tsSubMenu.Location = New System.Drawing.Point(0, 24)
            Me.tsSubMenu.Name = "tsSubMenu"
            Me.tsSubMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
            Me.tsSubMenu.Size = New System.Drawing.Size(848, 57)
            Me.tsSubMenu.Stretch = True
            Me.tsSubMenu.TabIndex = 5
            Me.tsSubMenu.Visible = False
            '
            'tssMensajeUsuario
            '
            Me.tssMensajeUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.tssMensajeUsuario.ForeColor = System.Drawing.Color.Red
            Me.tssMensajeUsuario.Name = "tssMensajeUsuario"
            Me.tssMensajeUsuario.Size = New System.Drawing.Size(102, 17)
            Me.tssMensajeUsuario.Text = "Mensaje a usuario"
            '
            'StatusMensaje
            '
            Me.StatusMensaje.BackColor = System.Drawing.Color.Transparent
            Me.StatusMensaje.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssMensajeUsuario})
            Me.StatusMensaje.Location = New System.Drawing.Point(0, 477)
            Me.StatusMensaje.Name = "StatusMensaje"
            Me.StatusMensaje.Size = New System.Drawing.Size(848, 22)
            Me.StatusMensaje.TabIndex = 7
            Me.StatusMensaje.Visible = False
            '
            'MainWindow
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.BackgroundImage = Global.My.Resources.Resources.iso
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.ClientSize = New System.Drawing.Size(848, 521)
            Me.Controls.Add(Me.tsSubMenu)
            Me.Controls.Add(Me.StatusMensaje)
            Me.Controls.Add(Me.statusprincipal)
            Me.Controls.Add(Me.menuPrincipal)
            Me.DoubleBuffered = True
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me.menuPrincipal
            Me.Name = "MainWindow"
            Me.Text = "Ladisac"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.menuPrincipal.ResumeLayout(False)
            Me.menuPrincipal.PerformLayout()
            Me.statusprincipal.ResumeLayout(False)
            Me.statusprincipal.PerformLayout()
            Me.StatusMensaje.ResumeLayout(False)
            Me.StatusMensaje.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Public WithEvents menuPrincipal As System.Windows.Forms.MenuStrip
        Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Public WithEvents statusprincipal As System.Windows.Forms.StatusStrip
        Friend WithEvents tssMensajeGeneral As System.Windows.Forms.ToolStripStatusLabel
        Public WithEvents tsSubMenu As System.Windows.Forms.ToolStrip
        Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tssMensajeUsuario As System.Windows.Forms.ToolStripStatusLabel
        Public WithEvents StatusMensaje As System.Windows.Forms.StatusStrip
    End Class

End Namespace
