Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConfiguracionVehicular
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
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblCVE_ESTADO = New System.Windows.Forms.Label()
            Me.lblCVE_PESO = New System.Windows.Forms.Label()
            Me.lblTUN_ID_CARRETA = New System.Windows.Forms.Label()
            Me.lblTUN_ID_TRACTO = New System.Windows.Forms.Label()
            Me.lblCVE_ID = New System.Windows.Forms.Label()
            Me.chkCVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCVE_PESO = New System.Windows.Forms.TextBox()
            Me.txtTUN_DESCRIPCION_CARRETA = New System.Windows.Forms.TextBox()
            Me.txtTUN_DESCRIPCION_TRACTO = New System.Windows.Forms.TextBox()
            Me.txtTUN_ID_CARRETA = New System.Windows.Forms.TextBox()
            Me.txtTUN_ID_TRACTO = New System.Windows.Forms.TextBox()
            Me.txtCVE_ID = New System.Windows.Forms.TextBox()
            Me.txtUNT_ID = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(606, 28)
            Me.lblTitle.Text = "Configuración vehícular"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(526, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCVE_PESO)
            Me.pnCuerpo.Controls.Add(Me.lblTUN_ID_CARRETA)
            Me.pnCuerpo.Controls.Add(Me.lblTUN_ID_TRACTO)
            Me.pnCuerpo.Controls.Add(Me.lblCVE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCVE_PESO)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_DESCRIPCION_CARRETA)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_DESCRIPCION_TRACTO)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_ID_CARRETA)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_ID_TRACTO)
            Me.pnCuerpo.Controls.Add(Me.txtCVE_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(28, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(543, 151)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblCVE_ESTADO
            '
            Me.lblCVE_ESTADO.AutoSize = True
            Me.lblCVE_ESTADO.Location = New System.Drawing.Point(6, 123)
            Me.lblCVE_ESTADO.Name = "lblCVE_ESTADO"
            Me.lblCVE_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCVE_ESTADO.TabIndex = 36
            Me.lblCVE_ESTADO.Text = "Estado"
            '
            'lblCVE_PESO
            '
            Me.lblCVE_PESO.AutoSize = True
            Me.lblCVE_PESO.Location = New System.Drawing.Point(6, 91)
            Me.lblCVE_PESO.Name = "lblCVE_PESO"
            Me.lblCVE_PESO.Size = New System.Drawing.Size(31, 13)
            Me.lblCVE_PESO.TabIndex = 27
            Me.lblCVE_PESO.Text = "Peso"
            '
            'lblTUN_ID_CARRETA
            '
            Me.lblTUN_ID_CARRETA.AutoSize = True
            Me.lblTUN_ID_CARRETA.Location = New System.Drawing.Point(6, 65)
            Me.lblTUN_ID_CARRETA.Name = "lblTUN_ID_CARRETA"
            Me.lblTUN_ID_CARRETA.Size = New System.Drawing.Size(41, 13)
            Me.lblTUN_ID_CARRETA.TabIndex = 26
            Me.lblTUN_ID_CARRETA.Text = "Carreta"
            '
            'lblTUN_ID_TRACTO
            '
            Me.lblTUN_ID_TRACTO.AutoSize = True
            Me.lblTUN_ID_TRACTO.Location = New System.Drawing.Point(6, 41)
            Me.lblTUN_ID_TRACTO.Name = "lblTUN_ID_TRACTO"
            Me.lblTUN_ID_TRACTO.Size = New System.Drawing.Size(38, 13)
            Me.lblTUN_ID_TRACTO.TabIndex = 25
            Me.lblTUN_ID_TRACTO.Text = "Tracto"
            '
            'lblCVE_ID
            '
            Me.lblCVE_ID.AutoSize = True
            Me.lblCVE_ID.Location = New System.Drawing.Point(6, 13)
            Me.lblCVE_ID.Name = "lblCVE_ID"
            Me.lblCVE_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCVE_ID.TabIndex = 22
            Me.lblCVE_ID.Text = "Código"
            '
            'chkCVE_ESTADO
            '
            Me.chkCVE_ESTADO.AutoSize = True
            Me.chkCVE_ESTADO.Location = New System.Drawing.Point(58, 123)
            Me.chkCVE_ESTADO.Name = "chkCVE_ESTADO"
            Me.chkCVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCVE_ESTADO.TabIndex = 6
            Me.chkCVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCVE_PESO
            '
            Me.txtCVE_PESO.Location = New System.Drawing.Point(58, 91)
            Me.txtCVE_PESO.Name = "txtCVE_PESO"
            Me.txtCVE_PESO.Size = New System.Drawing.Size(100, 20)
            Me.txtCVE_PESO.TabIndex = 5
            Me.txtCVE_PESO.Text = "0"
            '
            'txtTUN_DESCRIPCION_CARRETA
            '
            Me.txtTUN_DESCRIPCION_CARRETA.Enabled = False
            Me.txtTUN_DESCRIPCION_CARRETA.Location = New System.Drawing.Point(98, 65)
            Me.txtTUN_DESCRIPCION_CARRETA.Name = "txtTUN_DESCRIPCION_CARRETA"
            Me.txtTUN_DESCRIPCION_CARRETA.ReadOnly = True
            Me.txtTUN_DESCRIPCION_CARRETA.Size = New System.Drawing.Size(425, 20)
            Me.txtTUN_DESCRIPCION_CARRETA.TabIndex = 5
            '
            'txtTUN_DESCRIPCION_TRACTO
            '
            Me.txtTUN_DESCRIPCION_TRACTO.Enabled = False
            Me.txtTUN_DESCRIPCION_TRACTO.Location = New System.Drawing.Point(98, 41)
            Me.txtTUN_DESCRIPCION_TRACTO.Name = "txtTUN_DESCRIPCION_TRACTO"
            Me.txtTUN_DESCRIPCION_TRACTO.ReadOnly = True
            Me.txtTUN_DESCRIPCION_TRACTO.Size = New System.Drawing.Size(425, 20)
            Me.txtTUN_DESCRIPCION_TRACTO.TabIndex = 2
            '
            'txtTUN_ID_CARRETA
            '
            Me.txtTUN_ID_CARRETA.Location = New System.Drawing.Point(58, 65)
            Me.txtTUN_ID_CARRETA.Name = "txtTUN_ID_CARRETA"
            Me.txtTUN_ID_CARRETA.Size = New System.Drawing.Size(34, 20)
            Me.txtTUN_ID_CARRETA.TabIndex = 3
            '
            'txtTUN_ID_TRACTO
            '
            Me.txtTUN_ID_TRACTO.Location = New System.Drawing.Point(58, 41)
            Me.txtTUN_ID_TRACTO.Name = "txtTUN_ID_TRACTO"
            Me.txtTUN_ID_TRACTO.Size = New System.Drawing.Size(34, 20)
            Me.txtTUN_ID_TRACTO.TabIndex = 1
            '
            'txtCVE_ID
            '
            Me.txtCVE_ID.Location = New System.Drawing.Point(58, 13)
            Me.txtCVE_ID.Name = "txtCVE_ID"
            Me.txtCVE_ID.Size = New System.Drawing.Size(100, 20)
            Me.txtCVE_ID.TabIndex = 0
            '
            'txtUNT_ID
            '
            Me.txtUNT_ID.Location = New System.Drawing.Point(58, 13)
            Me.txtUNT_ID.Name = "txtUNT_ID"
            Me.txtUNT_ID.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_ID.TabIndex = 0
            '
            'frmConfiguracionVehicular
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(606, 206)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmConfiguracionVehicular"
            Me.Text = "Configuración vehícular"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblCVE_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCVE_PESO As System.Windows.Forms.Label
        Friend WithEvents lblTUN_ID_CARRETA As System.Windows.Forms.Label
        Friend WithEvents lblTUN_ID_TRACTO As System.Windows.Forms.Label
        Friend WithEvents lblCVE_ID As System.Windows.Forms.Label
        Public WithEvents chkCVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCVE_PESO As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_DESCRIPCION_CARRETA As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_DESCRIPCION_TRACTO As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_ID_CARRETA As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_ID_TRACTO As System.Windows.Forms.TextBox
        Public WithEvents txtCVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_ID As System.Windows.Forms.TextBox
    End Class
End Namespace