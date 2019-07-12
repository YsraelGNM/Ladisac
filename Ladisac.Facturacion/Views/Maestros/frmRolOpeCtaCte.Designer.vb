Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolOpeCtaCte
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
            Me.lblROC_ESCONTABLE = New System.Windows.Forms.Label()
            Me.chkROC_ESCONTABLE = New System.Windows.Forms.CheckBox()
            Me.lblCUC_IDME = New System.Windows.Forms.Label()
            Me.txtCUC_DESCRIPCION_ME = New System.Windows.Forms.TextBox()
            Me.txtCUC_IDME = New System.Windows.Forms.TextBox()
            Me.lblCUC_IDMN = New System.Windows.Forms.Label()
            Me.txtCUC_DESCRIPCION_MN = New System.Windows.Forms.TextBox()
            Me.txtCUC_IDMN = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.lblROC_ESTADO = New System.Windows.Forms.Label()
            Me.lblDTD_CARGO_ABONO = New System.Windows.Forms.Label()
            Me.lblTDO_ID = New System.Windows.Forms.Label()
            Me.lblCCT_ID = New System.Windows.Forms.Label()
            Me.chkROC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtDTD_CARGO_ABONO = New System.Windows.Forms.TextBox()
            Me.txtTDO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtCCT_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.txtCCT_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(799, 28)
            Me.lblTitle.Text = "Rol operaciones cuentas corrientes"
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
            Me.pnCuerpo.Controls.Add(Me.lblROC_ESCONTABLE)
            Me.pnCuerpo.Controls.Add(Me.chkROC_ESCONTABLE)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_IDME)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_ME)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_IDME)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_IDMN)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_MN)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_IDMN)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblROC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_CARGO_ABONO)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCT_ID)
            Me.pnCuerpo.Controls.Add(Me.chkROC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_CARGO_ABONO)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCCT_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(725, 228)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblROC_ESCONTABLE
            '
            Me.lblROC_ESCONTABLE.AutoSize = True
            Me.lblROC_ESCONTABLE.Location = New System.Drawing.Point(11, 175)
            Me.lblROC_ESCONTABLE.Name = "lblROC_ESCONTABLE"
            Me.lblROC_ESCONTABLE.Size = New System.Drawing.Size(63, 13)
            Me.lblROC_ESCONTABLE.TabIndex = 52
            Me.lblROC_ESCONTABLE.Text = "Es contable"
            '
            'chkROC_ESCONTABLE
            '
            Me.chkROC_ESCONTABLE.AutoSize = True
            Me.chkROC_ESCONTABLE.Location = New System.Drawing.Point(101, 175)
            Me.chkROC_ESCONTABLE.Name = "chkROC_ESCONTABLE"
            Me.chkROC_ESCONTABLE.Size = New System.Drawing.Size(15, 14)
            Me.chkROC_ESCONTABLE.TabIndex = 51
            Me.chkROC_ESCONTABLE.UseVisualStyleBackColor = True
            '
            'lblCUC_IDME
            '
            Me.lblCUC_IDME.AutoSize = True
            Me.lblCUC_IDME.Location = New System.Drawing.Point(11, 144)
            Me.lblCUC_IDME.Name = "lblCUC_IDME"
            Me.lblCUC_IDME.Size = New System.Drawing.Size(76, 13)
            Me.lblCUC_IDME.TabIndex = 50
            Me.lblCUC_IDME.Text = "Cta. Cont. ME."
            '
            'txtCUC_DESCRIPCION_ME
            '
            Me.txtCUC_DESCRIPCION_ME.Enabled = False
            Me.txtCUC_DESCRIPCION_ME.Location = New System.Drawing.Point(263, 144)
            Me.txtCUC_DESCRIPCION_ME.Name = "txtCUC_DESCRIPCION_ME"
            Me.txtCUC_DESCRIPCION_ME.ReadOnly = True
            Me.txtCUC_DESCRIPCION_ME.Size = New System.Drawing.Size(440, 20)
            Me.txtCUC_DESCRIPCION_ME.TabIndex = 49
            '
            'txtCUC_IDME
            '
            Me.txtCUC_IDME.Location = New System.Drawing.Point(101, 144)
            Me.txtCUC_IDME.Name = "txtCUC_IDME"
            Me.txtCUC_IDME.Size = New System.Drawing.Size(156, 20)
            Me.txtCUC_IDME.TabIndex = 48
            '
            'lblCUC_IDMN
            '
            Me.lblCUC_IDMN.AutoSize = True
            Me.lblCUC_IDMN.Location = New System.Drawing.Point(11, 118)
            Me.lblCUC_IDMN.Name = "lblCUC_IDMN"
            Me.lblCUC_IDMN.Size = New System.Drawing.Size(77, 13)
            Me.lblCUC_IDMN.TabIndex = 47
            Me.lblCUC_IDMN.Text = "Cta. Cont. MN."
            '
            'txtCUC_DESCRIPCION_MN
            '
            Me.txtCUC_DESCRIPCION_MN.Enabled = False
            Me.txtCUC_DESCRIPCION_MN.Location = New System.Drawing.Point(263, 118)
            Me.txtCUC_DESCRIPCION_MN.Name = "txtCUC_DESCRIPCION_MN"
            Me.txtCUC_DESCRIPCION_MN.ReadOnly = True
            Me.txtCUC_DESCRIPCION_MN.Size = New System.Drawing.Size(440, 20)
            Me.txtCUC_DESCRIPCION_MN.TabIndex = 46
            '
            'txtCUC_IDMN
            '
            Me.txtCUC_IDMN.Location = New System.Drawing.Point(101, 118)
            Me.txtCUC_IDMN.Name = "txtCUC_IDMN"
            Me.txtCUC_IDMN.Size = New System.Drawing.Size(156, 20)
            Me.txtCUC_IDMN.TabIndex = 45
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(11, 64)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblDTD_ID.TabIndex = 44
            Me.lblDTD_ID.Text = "Tipo Doc."
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(145, 64)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(558, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 43
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Location = New System.Drawing.Point(101, 64)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtDTD_ID.TabIndex = 42
            '
            'lblROC_ESTADO
            '
            Me.lblROC_ESTADO.AutoSize = True
            Me.lblROC_ESTADO.Location = New System.Drawing.Point(11, 200)
            Me.lblROC_ESTADO.Name = "lblROC_ESTADO"
            Me.lblROC_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblROC_ESTADO.TabIndex = 36
            Me.lblROC_ESTADO.Text = "Estado"
            '
            'lblDTD_CARGO_ABONO
            '
            Me.lblDTD_CARGO_ABONO.AutoSize = True
            Me.lblDTD_CARGO_ABONO.Location = New System.Drawing.Point(11, 90)
            Me.lblDTD_CARGO_ABONO.Name = "lblDTD_CARGO_ABONO"
            Me.lblDTD_CARGO_ABONO.Size = New System.Drawing.Size(77, 13)
            Me.lblDTD_CARGO_ABONO.TabIndex = 29
            Me.lblDTD_CARGO_ABONO.Text = "Cargo / Abono"
            '
            'lblTDO_ID
            '
            Me.lblTDO_ID.AutoSize = True
            Me.lblTDO_ID.Location = New System.Drawing.Point(11, 38)
            Me.lblTDO_ID.Name = "lblTDO_ID"
            Me.lblTDO_ID.Size = New System.Drawing.Size(30, 13)
            Me.lblTDO_ID.TabIndex = 26
            Me.lblTDO_ID.Text = "Doc."
            '
            'lblCCT_ID
            '
            Me.lblCCT_ID.AutoSize = True
            Me.lblCCT_ID.Location = New System.Drawing.Point(11, 14)
            Me.lblCCT_ID.Name = "lblCCT_ID"
            Me.lblCCT_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblCCT_ID.TabIndex = 25
            Me.lblCCT_ID.Text = "Cta. Cte."
            '
            'chkROC_ESTADO
            '
            Me.chkROC_ESTADO.AutoSize = True
            Me.chkROC_ESTADO.Location = New System.Drawing.Point(101, 200)
            Me.chkROC_ESTADO.Name = "chkROC_ESTADO"
            Me.chkROC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkROC_ESTADO.TabIndex = 20
            Me.chkROC_ESTADO.UseVisualStyleBackColor = True
            '
            'txtDTD_CARGO_ABONO
            '
            Me.txtDTD_CARGO_ABONO.Enabled = False
            Me.txtDTD_CARGO_ABONO.Location = New System.Drawing.Point(101, 90)
            Me.txtDTD_CARGO_ABONO.Name = "txtDTD_CARGO_ABONO"
            Me.txtDTD_CARGO_ABONO.ReadOnly = True
            Me.txtDTD_CARGO_ABONO.Size = New System.Drawing.Size(602, 20)
            Me.txtDTD_CARGO_ABONO.TabIndex = 12
            '
            'txtTDO_DESCRIPCION
            '
            Me.txtTDO_DESCRIPCION.Enabled = False
            Me.txtTDO_DESCRIPCION.Location = New System.Drawing.Point(145, 38)
            Me.txtTDO_DESCRIPCION.Name = "txtTDO_DESCRIPCION"
            Me.txtTDO_DESCRIPCION.ReadOnly = True
            Me.txtTDO_DESCRIPCION.Size = New System.Drawing.Size(558, 20)
            Me.txtTDO_DESCRIPCION.TabIndex = 6
            '
            'txtCCT_DESCRIPCION
            '
            Me.txtCCT_DESCRIPCION.Enabled = False
            Me.txtCCT_DESCRIPCION.Location = New System.Drawing.Point(145, 14)
            Me.txtCCT_DESCRIPCION.Name = "txtCCT_DESCRIPCION"
            Me.txtCCT_DESCRIPCION.ReadOnly = True
            Me.txtCCT_DESCRIPCION.Size = New System.Drawing.Size(558, 20)
            Me.txtCCT_DESCRIPCION.TabIndex = 5
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(101, 38)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.ReadOnly = True
            Me.txtTDO_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtTDO_ID.TabIndex = 4
            '
            'txtCCT_ID
            '
            Me.txtCCT_ID.Location = New System.Drawing.Point(101, 14)
            Me.txtCCT_ID.Name = "txtCCT_ID"
            Me.txtCCT_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtCCT_ID.TabIndex = 3
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(714, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmRolOpeCtaCte
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 292)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmRolOpeCtaCte"
            Me.Text = "Rol operaciones cuentas corrientes"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblROC_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblDTD_CARGO_ABONO As System.Windows.Forms.Label
        Friend WithEvents lblTDO_ID As System.Windows.Forms.Label
        Friend WithEvents lblCCT_ID As System.Windows.Forms.Label
        Public WithEvents chkROC_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtDTD_CARGO_ABONO As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtCCT_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCCT_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblCUC_IDMN As System.Windows.Forms.Label
        Public WithEvents txtCUC_DESCRIPCION_MN As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_IDMN As System.Windows.Forms.TextBox
        Friend WithEvents lblCUC_IDME As System.Windows.Forms.Label
        Public WithEvents txtCUC_DESCRIPCION_ME As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_IDME As System.Windows.Forms.TextBox
        Friend WithEvents lblROC_ESCONTABLE As System.Windows.Forms.Label
        Public WithEvents chkROC_ESCONTABLE As System.Windows.Forms.CheckBox
    End Class
End Namespace