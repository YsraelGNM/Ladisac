Namespace Ladisac.ActivosFijos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasActivos
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
            Me.lblCUC_ID_RES = New System.Windows.Forms.Label()
            Me.chkCUC_ESTADO_RES = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION_RES = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_RES = New System.Windows.Forms.TextBox()
            Me.lblCUC_ID_DEP_ACU = New System.Windows.Forms.Label()
            Me.chkCUC_ESTADO_DEP_ACU = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION_DEP_ACU = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_DEP_ACU = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkCUC_ESTADO_ACT_ACU = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION_ACT_ACU = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_ACT_ACU = New System.Windows.Forms.TextBox()
            Me.lblCUC_ID_PRO = New System.Windows.Forms.Label()
            Me.chkCUC_ESTADO_PRO = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION_PRO = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_PRO = New System.Windows.Forms.TextBox()
            Me.lblCUA_ESTADO = New System.Windows.Forms.Label()
            Me.lblCUA_MESES = New System.Windows.Forms.Label()
            Me.lblCUA_TASA_ANUAL = New System.Windows.Forms.Label()
            Me.lblCUC_ID_DEP = New System.Windows.Forms.Label()
            Me.lblCUC_ID_ACT = New System.Windows.Forms.Label()
            Me.lblCUA_ID = New System.Windows.Forms.Label()
            Me.chkCUA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCUA_MESES = New System.Windows.Forms.TextBox()
            Me.txtCUA_TASA_ANUAL = New System.Windows.Forms.TextBox()
            Me.chkCUC_ESTADO_DEP = New System.Windows.Forms.CheckBox()
            Me.chkCUC_ESTADO_ACT = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION_DEP = New System.Windows.Forms.TextBox()
            Me.txtCUC_DESCRIPCION_ACT = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_DEP = New System.Windows.Forms.TextBox()
            Me.txtCUC_ID_ACT = New System.Windows.Forms.TextBox()
            Me.txtCUA_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txt_CUC_DESCRIPCION_PRO = New System.Windows.Forms.TextBox()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(798, 28)
            Me.lblTitle.Text = "Cuentas de activos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID_RES)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_RES)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_RES)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_RES)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID_DEP_ACU)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_DEP_ACU)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_DEP_ACU)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_DEP_ACU)
            Me.pnCuerpo.Controls.Add(Me.Label2)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_ACT_ACU)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_ACT_ACU)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_ACT_ACU)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID_PRO)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_PRO)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_PRO)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_PRO)
            Me.pnCuerpo.Controls.Add(Me.lblCUA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCUA_MESES)
            Me.pnCuerpo.Controls.Add(Me.lblCUA_TASA_ANUAL)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID_DEP)
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID_ACT)
            Me.pnCuerpo.Controls.Add(Me.lblCUA_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCUA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCUA_MESES)
            Me.pnCuerpo.Controls.Add(Me.txtCUA_TASA_ANUAL)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_DEP)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO_ACT)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_DEP)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION_ACT)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_DEP)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID_ACT)
            Me.pnCuerpo.Controls.Add(Me.txtCUA_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(32, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(725, 248)
            Me.pnCuerpo.TabIndex = 14
            '
            'lblCUC_ID_RES
            '
            Me.lblCUC_ID_RES.AutoSize = True
            Me.lblCUC_ID_RES.Location = New System.Drawing.Point(6, 169)
            Me.lblCUC_ID_RES.Name = "lblCUC_ID_RES"
            Me.lblCUC_ID_RES.Size = New System.Drawing.Size(105, 13)
            Me.lblCUC_ID_RES.TabIndex = 52
            Me.lblCUC_ID_RES.Text = "Cta. Cont. Resultado"
            '
            'chkCUC_ESTADO_RES
            '
            Me.chkCUC_ESTADO_RES.AutoSize = True
            Me.chkCUC_ESTADO_RES.Enabled = False
            Me.chkCUC_ESTADO_RES.Location = New System.Drawing.Point(636, 171)
            Me.chkCUC_ESTADO_RES.Name = "chkCUC_ESTADO_RES"
            Me.chkCUC_ESTADO_RES.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_RES.TabIndex = 19
            Me.chkCUC_ESTADO_RES.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION_RES
            '
            Me.txtCUC_DESCRIPCION_RES.Enabled = False
            Me.txtCUC_DESCRIPCION_RES.Location = New System.Drawing.Point(307, 171)
            Me.txtCUC_DESCRIPCION_RES.Name = "txtCUC_DESCRIPCION_RES"
            Me.txtCUC_DESCRIPCION_RES.ReadOnly = True
            Me.txtCUC_DESCRIPCION_RES.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_RES.TabIndex = 18
            '
            'txtCUC_ID_RES
            '
            Me.txtCUC_ID_RES.Location = New System.Drawing.Point(142, 171)
            Me.txtCUC_ID_RES.Name = "txtCUC_ID_RES"
            Me.txtCUC_ID_RES.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_RES.TabIndex = 17
            '
            'lblCUC_ID_DEP_ACU
            '
            Me.lblCUC_ID_DEP_ACU.AutoSize = True
            Me.lblCUC_ID_DEP_ACU.Location = New System.Drawing.Point(6, 143)
            Me.lblCUC_ID_DEP_ACU.Name = "lblCUC_ID_DEP_ACU"
            Me.lblCUC_ID_DEP_ACU.Size = New System.Drawing.Size(136, 13)
            Me.lblCUC_ID_DEP_ACU.TabIndex = 48
            Me.lblCUC_ID_DEP_ACU.Text = "Cta. Cont. Dep. Acumulado"
            '
            'chkCUC_ESTADO_DEP_ACU
            '
            Me.chkCUC_ESTADO_DEP_ACU.AutoSize = True
            Me.chkCUC_ESTADO_DEP_ACU.Enabled = False
            Me.chkCUC_ESTADO_DEP_ACU.Location = New System.Drawing.Point(636, 145)
            Me.chkCUC_ESTADO_DEP_ACU.Name = "chkCUC_ESTADO_DEP_ACU"
            Me.chkCUC_ESTADO_DEP_ACU.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_DEP_ACU.TabIndex = 16
            Me.chkCUC_ESTADO_DEP_ACU.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION_DEP_ACU
            '
            Me.txtCUC_DESCRIPCION_DEP_ACU.Enabled = False
            Me.txtCUC_DESCRIPCION_DEP_ACU.Location = New System.Drawing.Point(307, 145)
            Me.txtCUC_DESCRIPCION_DEP_ACU.Name = "txtCUC_DESCRIPCION_DEP_ACU"
            Me.txtCUC_DESCRIPCION_DEP_ACU.ReadOnly = True
            Me.txtCUC_DESCRIPCION_DEP_ACU.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_DEP_ACU.TabIndex = 15
            '
            'txtCUC_ID_DEP_ACU
            '
            Me.txtCUC_ID_DEP_ACU.Location = New System.Drawing.Point(142, 145)
            Me.txtCUC_ID_DEP_ACU.Name = "txtCUC_ID_DEP_ACU"
            Me.txtCUC_ID_DEP_ACU.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_DEP_ACU.TabIndex = 14
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 117)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(132, 13)
            Me.Label2.TabIndex = 11
            Me.Label2.Text = "Cta. Cont. Act. Acumulado"
            '
            'chkCUC_ESTADO_ACT_ACU
            '
            Me.chkCUC_ESTADO_ACT_ACU.AutoSize = True
            Me.chkCUC_ESTADO_ACT_ACU.Enabled = False
            Me.chkCUC_ESTADO_ACT_ACU.Location = New System.Drawing.Point(636, 119)
            Me.chkCUC_ESTADO_ACT_ACU.Name = "chkCUC_ESTADO_ACT_ACU"
            Me.chkCUC_ESTADO_ACT_ACU.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_ACT_ACU.TabIndex = 13
            Me.chkCUC_ESTADO_ACT_ACU.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION_ACT_ACU
            '
            Me.txtCUC_DESCRIPCION_ACT_ACU.Enabled = False
            Me.txtCUC_DESCRIPCION_ACT_ACU.Location = New System.Drawing.Point(307, 119)
            Me.txtCUC_DESCRIPCION_ACT_ACU.Name = "txtCUC_DESCRIPCION_ACT_ACU"
            Me.txtCUC_DESCRIPCION_ACT_ACU.ReadOnly = True
            Me.txtCUC_DESCRIPCION_ACT_ACU.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_ACT_ACU.TabIndex = 12
            '
            'txtCUC_ID_ACT_ACU
            '
            Me.txtCUC_ID_ACT_ACU.Location = New System.Drawing.Point(142, 119)
            Me.txtCUC_ID_ACT_ACU.Name = "txtCUC_ID_ACT_ACU"
            Me.txtCUC_ID_ACT_ACU.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_ACT_ACU.TabIndex = 11
            '
            'lblCUC_ID_PRO
            '
            Me.lblCUC_ID_PRO.AutoSize = True
            Me.lblCUC_ID_PRO.Location = New System.Drawing.Point(6, 91)
            Me.lblCUC_ID_PRO.Name = "lblCUC_ID_PRO"
            Me.lblCUC_ID_PRO.Size = New System.Drawing.Size(100, 13)
            Me.lblCUC_ID_PRO.TabIndex = 40
            Me.lblCUC_ID_PRO.Text = "Cta. Cont. Provisión"
            '
            'chkCUC_ESTADO_PRO
            '
            Me.chkCUC_ESTADO_PRO.AutoSize = True
            Me.chkCUC_ESTADO_PRO.Enabled = False
            Me.chkCUC_ESTADO_PRO.Location = New System.Drawing.Point(636, 93)
            Me.chkCUC_ESTADO_PRO.Name = "chkCUC_ESTADO_PRO"
            Me.chkCUC_ESTADO_PRO.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_PRO.TabIndex = 10
            Me.chkCUC_ESTADO_PRO.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION_PRO
            '
            Me.txtCUC_DESCRIPCION_PRO.Enabled = False
            Me.txtCUC_DESCRIPCION_PRO.Location = New System.Drawing.Point(307, 93)
            Me.txtCUC_DESCRIPCION_PRO.Name = "txtCUC_DESCRIPCION_PRO"
            Me.txtCUC_DESCRIPCION_PRO.ReadOnly = True
            Me.txtCUC_DESCRIPCION_PRO.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_PRO.TabIndex = 9
            '
            'txtCUC_ID_PRO
            '
            Me.txtCUC_ID_PRO.Location = New System.Drawing.Point(142, 93)
            Me.txtCUC_ID_PRO.Name = "txtCUC_ID_PRO"
            Me.txtCUC_ID_PRO.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_PRO.TabIndex = 8
            '
            'lblCUA_ESTADO
            '
            Me.lblCUA_ESTADO.AutoSize = True
            Me.lblCUA_ESTADO.Location = New System.Drawing.Point(6, 225)
            Me.lblCUA_ESTADO.Name = "lblCUA_ESTADO"
            Me.lblCUA_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCUA_ESTADO.TabIndex = 36
            Me.lblCUA_ESTADO.Text = "Estado"
            '
            'lblCUA_MESES
            '
            Me.lblCUA_MESES.AutoSize = True
            Me.lblCUA_MESES.Location = New System.Drawing.Point(307, 200)
            Me.lblCUA_MESES.Name = "lblCUA_MESES"
            Me.lblCUA_MESES.Size = New System.Drawing.Size(38, 13)
            Me.lblCUA_MESES.TabIndex = 28
            Me.lblCUA_MESES.Text = "Meses"
            '
            'lblCUA_TASA_ANUAL
            '
            Me.lblCUA_TASA_ANUAL.AutoSize = True
            Me.lblCUA_TASA_ANUAL.Location = New System.Drawing.Point(6, 196)
            Me.lblCUA_TASA_ANUAL.Name = "lblCUA_TASA_ANUAL"
            Me.lblCUA_TASA_ANUAL.Size = New System.Drawing.Size(60, 13)
            Me.lblCUA_TASA_ANUAL.TabIndex = 27
            Me.lblCUA_TASA_ANUAL.Text = "Tasa anual"
            '
            'lblCUC_ID_DEP
            '
            Me.lblCUC_ID_DEP.AutoSize = True
            Me.lblCUC_ID_DEP.Location = New System.Drawing.Point(6, 65)
            Me.lblCUC_ID_DEP.Name = "lblCUC_ID_DEP"
            Me.lblCUC_ID_DEP.Size = New System.Drawing.Size(120, 13)
            Me.lblCUC_ID_DEP.TabIndex = 4
            Me.lblCUC_ID_DEP.Text = "Cta. Cont. Depreciación"
            '
            'lblCUC_ID_ACT
            '
            Me.lblCUC_ID_ACT.AutoSize = True
            Me.lblCUC_ID_ACT.Location = New System.Drawing.Point(6, 41)
            Me.lblCUC_ID_ACT.Name = "lblCUC_ID_ACT"
            Me.lblCUC_ID_ACT.Size = New System.Drawing.Size(103, 13)
            Me.lblCUC_ID_ACT.TabIndex = 25
            Me.lblCUC_ID_ACT.Text = "Cta. Cont. Activo fijo"
            '
            'lblCUA_ID
            '
            Me.lblCUA_ID.AutoSize = True
            Me.lblCUA_ID.Location = New System.Drawing.Point(6, 13)
            Me.lblCUA_ID.Name = "lblCUA_ID"
            Me.lblCUA_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCUA_ID.TabIndex = 22
            Me.lblCUA_ID.Text = "Código"
            '
            'chkCUA_ESTADO
            '
            Me.chkCUA_ESTADO.AutoSize = True
            Me.chkCUA_ESTADO.Location = New System.Drawing.Point(58, 224)
            Me.chkCUA_ESTADO.Name = "chkCUA_ESTADO"
            Me.chkCUA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCUA_ESTADO.TabIndex = 22
            Me.chkCUA_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCUA_MESES
            '
            Me.txtCUA_MESES.Location = New System.Drawing.Point(359, 197)
            Me.txtCUA_MESES.Name = "txtCUA_MESES"
            Me.txtCUA_MESES.Size = New System.Drawing.Size(100, 20)
            Me.txtCUA_MESES.TabIndex = 21
            Me.txtCUA_MESES.Text = "0"
            '
            'txtCUA_TASA_ANUAL
            '
            Me.txtCUA_TASA_ANUAL.Location = New System.Drawing.Point(70, 195)
            Me.txtCUA_TASA_ANUAL.Name = "txtCUA_TASA_ANUAL"
            Me.txtCUA_TASA_ANUAL.Size = New System.Drawing.Size(100, 20)
            Me.txtCUA_TASA_ANUAL.TabIndex = 20
            Me.txtCUA_TASA_ANUAL.Text = "1"
            '
            'chkCUC_ESTADO_DEP
            '
            Me.chkCUC_ESTADO_DEP.AutoSize = True
            Me.chkCUC_ESTADO_DEP.Enabled = False
            Me.chkCUC_ESTADO_DEP.Location = New System.Drawing.Point(636, 67)
            Me.chkCUC_ESTADO_DEP.Name = "chkCUC_ESTADO_DEP"
            Me.chkCUC_ESTADO_DEP.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_DEP.TabIndex = 7
            Me.chkCUC_ESTADO_DEP.UseVisualStyleBackColor = True
            '
            'chkCUC_ESTADO_ACT
            '
            Me.chkCUC_ESTADO_ACT.AutoSize = True
            Me.chkCUC_ESTADO_ACT.Location = New System.Drawing.Point(636, 41)
            Me.chkCUC_ESTADO_ACT.Name = "chkCUC_ESTADO_ACT"
            Me.chkCUC_ESTADO_ACT.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO_ACT.TabIndex = 3
            Me.chkCUC_ESTADO_ACT.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION_DEP
            '
            Me.txtCUC_DESCRIPCION_DEP.Enabled = False
            Me.txtCUC_DESCRIPCION_DEP.Location = New System.Drawing.Point(307, 67)
            Me.txtCUC_DESCRIPCION_DEP.Name = "txtCUC_DESCRIPCION_DEP"
            Me.txtCUC_DESCRIPCION_DEP.ReadOnly = True
            Me.txtCUC_DESCRIPCION_DEP.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_DEP.TabIndex = 6
            '
            'txtCUC_DESCRIPCION_ACT
            '
            Me.txtCUC_DESCRIPCION_ACT.Enabled = False
            Me.txtCUC_DESCRIPCION_ACT.Location = New System.Drawing.Point(307, 41)
            Me.txtCUC_DESCRIPCION_ACT.Name = "txtCUC_DESCRIPCION_ACT"
            Me.txtCUC_DESCRIPCION_ACT.ReadOnly = True
            Me.txtCUC_DESCRIPCION_ACT.Size = New System.Drawing.Size(323, 20)
            Me.txtCUC_DESCRIPCION_ACT.TabIndex = 2
            '
            'txtCUC_ID_DEP
            '
            Me.txtCUC_ID_DEP.Location = New System.Drawing.Point(142, 67)
            Me.txtCUC_ID_DEP.Name = "txtCUC_ID_DEP"
            Me.txtCUC_ID_DEP.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_DEP.TabIndex = 5
            '
            'txtCUC_ID_ACT
            '
            Me.txtCUC_ID_ACT.Location = New System.Drawing.Point(142, 41)
            Me.txtCUC_ID_ACT.Name = "txtCUC_ID_ACT"
            Me.txtCUC_ID_ACT.Size = New System.Drawing.Size(159, 20)
            Me.txtCUC_ID_ACT.TabIndex = 1
            '
            'txtCUA_ID
            '
            Me.txtCUA_ID.Location = New System.Drawing.Point(70, 13)
            Me.txtCUA_ID.Name = "txtCUA_ID"
            Me.txtCUA_ID.Size = New System.Drawing.Size(100, 20)
            Me.txtCUA_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(712, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txt_CUC_DESCRIPCION_PRO
            '
            Me.txt_CUC_DESCRIPCION_PRO.Enabled = False
            Me.txt_CUC_DESCRIPCION_PRO.Location = New System.Drawing.Point(247, 93)
            Me.txt_CUC_DESCRIPCION_PRO.Name = "txt_CUC_DESCRIPCION_PRO"
            Me.txt_CUC_DESCRIPCION_PRO.ReadOnly = True
            Me.txt_CUC_DESCRIPCION_PRO.Size = New System.Drawing.Size(376, 20)
            Me.txt_CUC_DESCRIPCION_PRO.TabIndex = 9
            '
            'frmCuentasActivos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(798, 307)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmCuentasActivos"
            Me.Text = "Cuentas de activos"
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
        Friend WithEvents lblCUC_ID_RES As System.Windows.Forms.Label
        Public WithEvents chkCUC_ESTADO_RES As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION_RES As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_RES As System.Windows.Forms.TextBox
        Friend WithEvents lblCUC_ID_DEP_ACU As System.Windows.Forms.Label
        Public WithEvents chkCUC_ESTADO_DEP_ACU As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION_DEP_ACU As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_DEP_ACU As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Public WithEvents chkCUC_ESTADO_ACT_ACU As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION_ACT_ACU As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_ACT_ACU As System.Windows.Forms.TextBox
        Friend WithEvents lblCUC_ID_PRO As System.Windows.Forms.Label
        Public WithEvents chkCUC_ESTADO_PRO As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION_PRO As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_PRO As System.Windows.Forms.TextBox
        Friend WithEvents lblCUA_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCUA_MESES As System.Windows.Forms.Label
        Friend WithEvents lblCUA_TASA_ANUAL As System.Windows.Forms.Label
        Friend WithEvents lblCUC_ID_DEP As System.Windows.Forms.Label
        Friend WithEvents lblCUC_ID_ACT As System.Windows.Forms.Label
        Friend WithEvents lblCUA_ID As System.Windows.Forms.Label
        Public WithEvents chkCUA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCUA_MESES As System.Windows.Forms.TextBox
        Public WithEvents txtCUA_TASA_ANUAL As System.Windows.Forms.TextBox
        Public WithEvents chkCUC_ESTADO_DEP As System.Windows.Forms.CheckBox
        Public WithEvents chkCUC_ESTADO_ACT As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION_DEP As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_DESCRIPCION_ACT As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_DEP As System.Windows.Forms.TextBox
        Public WithEvents txtCUC_ID_ACT As System.Windows.Forms.TextBox
        Public WithEvents txtCUA_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents txt_CUC_DESCRIPCION_PRO As System.Windows.Forms.TextBox
    End Class
End Namespace