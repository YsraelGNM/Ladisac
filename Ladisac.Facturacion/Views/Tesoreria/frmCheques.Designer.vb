Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCheques
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
            Me.lblCHE_ESTADO = New System.Windows.Forms.Label()
            Me.lblCHE_CORRELATIVO = New System.Windows.Forms.Label()
            Me.lblCHE_FIN = New System.Windows.Forms.Label()
            Me.lblCHE_INICIO = New System.Windows.Forms.Label()
            Me.lblPER_ID_BAN = New System.Windows.Forms.Label()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.lblCHE_FORMA_GIRO = New System.Windows.Forms.Label()
            Me.lblCHE_TIPO = New System.Windows.Forms.Label()
            Me.lblCHE_ID = New System.Windows.Forms.Label()
            Me.chkCHE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCHE_CORRELATIVO = New System.Windows.Forms.TextBox()
            Me.txtCHE_FIN = New System.Windows.Forms.TextBox()
            Me.txtCHE_INICIO = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_BAN = New System.Windows.Forms.TextBox()
            Me.txtCCC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_BAN = New System.Windows.Forms.TextBox()
            Me.txtCCC_ID = New System.Windows.Forms.TextBox()
            Me.cboCHE_FORMA_GIRO = New System.Windows.Forms.ComboBox()
            Me.cboCHE_TIPO = New System.Windows.Forms.ComboBox()
            Me.txtCHE_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(700, 28)
            Me.lblTitle.Text = "Cheques"
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
            Me.pnCuerpo.Controls.Add(Me.lblCHE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_CORRELATIVO)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_FIN)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_INICIO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_FORMA_GIRO)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblCHE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCHE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCHE_CORRELATIVO)
            Me.pnCuerpo.Controls.Add(Me.txtCHE_FIN)
            Me.pnCuerpo.Controls.Add(Me.txtCHE_INICIO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_BAN)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.cboCHE_FORMA_GIRO)
            Me.pnCuerpo.Controls.Add(Me.cboCHE_TIPO)
            Me.pnCuerpo.Controls.Add(Me.txtCHE_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(30, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(631, 180)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblCHE_ESTADO
            '
            Me.lblCHE_ESTADO.AutoSize = True
            Me.lblCHE_ESTADO.Location = New System.Drawing.Point(6, 149)
            Me.lblCHE_ESTADO.Name = "lblCHE_ESTADO"
            Me.lblCHE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCHE_ESTADO.TabIndex = 36
            Me.lblCHE_ESTADO.Text = "Estado"
            '
            'lblCHE_CORRELATIVO
            '
            Me.lblCHE_CORRELATIVO.AutoSize = True
            Me.lblCHE_CORRELATIVO.Location = New System.Drawing.Point(436, 93)
            Me.lblCHE_CORRELATIVO.Name = "lblCHE_CORRELATIVO"
            Me.lblCHE_CORRELATIVO.Size = New System.Drawing.Size(57, 13)
            Me.lblCHE_CORRELATIVO.TabIndex = 34
            Me.lblCHE_CORRELATIVO.Text = "Correlativo"
            '
            'lblCHE_FIN
            '
            Me.lblCHE_FIN.AutoSize = True
            Me.lblCHE_FIN.Location = New System.Drawing.Point(233, 93)
            Me.lblCHE_FIN.Name = "lblCHE_FIN"
            Me.lblCHE_FIN.Size = New System.Drawing.Size(52, 13)
            Me.lblCHE_FIN.TabIndex = 31
            Me.lblCHE_FIN.Text = "Nro. Final"
            '
            'lblCHE_INICIO
            '
            Me.lblCHE_INICIO.AutoSize = True
            Me.lblCHE_INICIO.Location = New System.Drawing.Point(6, 93)
            Me.lblCHE_INICIO.Name = "lblCHE_INICIO"
            Me.lblCHE_INICIO.Size = New System.Drawing.Size(57, 13)
            Me.lblCHE_INICIO.TabIndex = 30
            Me.lblCHE_INICIO.Text = "Nro. Inicial"
            '
            'lblPER_ID_BAN
            '
            Me.lblPER_ID_BAN.AutoSize = True
            Me.lblPER_ID_BAN.Location = New System.Drawing.Point(6, 65)
            Me.lblPER_ID_BAN.Name = "lblPER_ID_BAN"
            Me.lblPER_ID_BAN.Size = New System.Drawing.Size(63, 13)
            Me.lblPER_ID_BAN.TabIndex = 26
            Me.lblPER_ID_BAN.Text = "Cód. Banco"
            '
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(6, 41)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(60, 13)
            Me.lblCCC_ID.TabIndex = 25
            Me.lblCCC_ID.Text = "Cta. Banco"
            '
            'lblCHE_FORMA_GIRO
            '
            Me.lblCHE_FORMA_GIRO.AutoSize = True
            Me.lblCHE_FORMA_GIRO.Location = New System.Drawing.Point(233, 120)
            Me.lblCHE_FORMA_GIRO.Name = "lblCHE_FORMA_GIRO"
            Me.lblCHE_FORMA_GIRO.Size = New System.Drawing.Size(56, 13)
            Me.lblCHE_FORMA_GIRO.TabIndex = 24
            Me.lblCHE_FORMA_GIRO.Text = "Forma giro"
            '
            'lblCHE_TIPO
            '
            Me.lblCHE_TIPO.AutoSize = True
            Me.lblCHE_TIPO.Location = New System.Drawing.Point(6, 120)
            Me.lblCHE_TIPO.Name = "lblCHE_TIPO"
            Me.lblCHE_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblCHE_TIPO.TabIndex = 23
            Me.lblCHE_TIPO.Text = "Tipo"
            '
            'lblCHE_ID
            '
            Me.lblCHE_ID.AutoSize = True
            Me.lblCHE_ID.Location = New System.Drawing.Point(6, 13)
            Me.lblCHE_ID.Name = "lblCHE_ID"
            Me.lblCHE_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCHE_ID.TabIndex = 22
            Me.lblCHE_ID.Text = "Código"
            '
            'chkCHE_ESTADO
            '
            Me.chkCHE_ESTADO.AutoSize = True
            Me.chkCHE_ESTADO.Location = New System.Drawing.Point(73, 149)
            Me.chkCHE_ESTADO.Name = "chkCHE_ESTADO"
            Me.chkCHE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCHE_ESTADO.TabIndex = 10
            Me.chkCHE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCHE_CORRELATIVO
            '
            Me.txtCHE_CORRELATIVO.Location = New System.Drawing.Point(498, 93)
            Me.txtCHE_CORRELATIVO.Name = "txtCHE_CORRELATIVO"
            Me.txtCHE_CORRELATIVO.Size = New System.Drawing.Size(100, 20)
            Me.txtCHE_CORRELATIVO.TabIndex = 7
            Me.txtCHE_CORRELATIVO.Text = "0"
            '
            'txtCHE_FIN
            '
            Me.txtCHE_FIN.Location = New System.Drawing.Point(295, 93)
            Me.txtCHE_FIN.Name = "txtCHE_FIN"
            Me.txtCHE_FIN.Size = New System.Drawing.Size(100, 20)
            Me.txtCHE_FIN.TabIndex = 6
            Me.txtCHE_FIN.Text = "0"
            '
            'txtCHE_INICIO
            '
            Me.txtCHE_INICIO.Location = New System.Drawing.Point(73, 93)
            Me.txtCHE_INICIO.Name = "txtCHE_INICIO"
            Me.txtCHE_INICIO.Size = New System.Drawing.Size(100, 20)
            Me.txtCHE_INICIO.TabIndex = 5
            Me.txtCHE_INICIO.Text = "0"
            '
            'txtPER_DESCRIPCION_BAN
            '
            Me.txtPER_DESCRIPCION_BAN.Enabled = False
            Me.txtPER_DESCRIPCION_BAN.Location = New System.Drawing.Point(148, 65)
            Me.txtPER_DESCRIPCION_BAN.Name = "txtPER_DESCRIPCION_BAN"
            Me.txtPER_DESCRIPCION_BAN.ReadOnly = True
            Me.txtPER_DESCRIPCION_BAN.Size = New System.Drawing.Size(463, 20)
            Me.txtPER_DESCRIPCION_BAN.TabIndex = 4
            '
            'txtCCC_DESCRIPCION
            '
            Me.txtCCC_DESCRIPCION.Enabled = False
            Me.txtCCC_DESCRIPCION.Location = New System.Drawing.Point(117, 41)
            Me.txtCCC_DESCRIPCION.Name = "txtCCC_DESCRIPCION"
            Me.txtCCC_DESCRIPCION.ReadOnly = True
            Me.txtCCC_DESCRIPCION.Size = New System.Drawing.Size(494, 20)
            Me.txtCCC_DESCRIPCION.TabIndex = 2
            '
            'txtPER_ID_BAN
            '
            Me.txtPER_ID_BAN.Enabled = False
            Me.txtPER_ID_BAN.Location = New System.Drawing.Point(73, 65)
            Me.txtPER_ID_BAN.Name = "txtPER_ID_BAN"
            Me.txtPER_ID_BAN.ReadOnly = True
            Me.txtPER_ID_BAN.Size = New System.Drawing.Size(69, 20)
            Me.txtPER_ID_BAN.TabIndex = 3
            '
            'txtCCC_ID
            '
            Me.txtCCC_ID.Location = New System.Drawing.Point(73, 41)
            Me.txtCCC_ID.Name = "txtCCC_ID"
            Me.txtCCC_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtCCC_ID.TabIndex = 1
            '
            'cboCHE_FORMA_GIRO
            '
            Me.cboCHE_FORMA_GIRO.FormattingEnabled = True
            Me.cboCHE_FORMA_GIRO.Location = New System.Drawing.Point(295, 120)
            Me.cboCHE_FORMA_GIRO.Name = "cboCHE_FORMA_GIRO"
            Me.cboCHE_FORMA_GIRO.Size = New System.Drawing.Size(114, 21)
            Me.cboCHE_FORMA_GIRO.TabIndex = 9
            '
            'cboCHE_TIPO
            '
            Me.cboCHE_TIPO.FormattingEnabled = True
            Me.cboCHE_TIPO.Location = New System.Drawing.Point(73, 120)
            Me.cboCHE_TIPO.Name = "cboCHE_TIPO"
            Me.cboCHE_TIPO.Size = New System.Drawing.Size(121, 21)
            Me.cboCHE_TIPO.TabIndex = 8
            '
            'txtCHE_ID
            '
            Me.txtCHE_ID.Location = New System.Drawing.Point(73, 13)
            Me.txtCHE_ID.Name = "txtCHE_ID"
            Me.txtCHE_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtCHE_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(616, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmCheques
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(700, 250)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmCheques"
            Me.Text = "Cheques"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblCHE_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCHE_CORRELATIVO As System.Windows.Forms.Label
        Friend WithEvents lblCHE_FIN As System.Windows.Forms.Label
        Friend WithEvents lblCHE_INICIO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_BAN As System.Windows.Forms.Label
        Friend WithEvents lblCCC_ID As System.Windows.Forms.Label
        Friend WithEvents lblCHE_FORMA_GIRO As System.Windows.Forms.Label
        Friend WithEvents lblCHE_TIPO As System.Windows.Forms.Label
        Friend WithEvents lblCHE_ID As System.Windows.Forms.Label
        Public WithEvents chkCHE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCHE_CORRELATIVO As System.Windows.Forms.TextBox
        Public WithEvents txtCHE_FIN As System.Windows.Forms.TextBox
        Public WithEvents txtCHE_INICIO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_BAN As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_BAN As System.Windows.Forms.TextBox
        Public WithEvents txtCCC_ID As System.Windows.Forms.TextBox
        Public WithEvents cboCHE_FORMA_GIRO As System.Windows.Forms.ComboBox
        Public WithEvents cboCHE_TIPO As System.Windows.Forms.ComboBox
        Public WithEvents txtCHE_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace