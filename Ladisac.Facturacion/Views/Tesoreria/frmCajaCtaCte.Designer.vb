Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCajaCtaCte
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
            Me.lblCUC_ID = New System.Windows.Forms.Label()
            Me.txtCUC_ID = New System.Windows.Forms.TextBox()
            Me.chkCUC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCUC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.chkMON_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblCCC_FECHA_SAL_INI = New System.Windows.Forms.Label()
            Me.dtpCCC_FECHA_SAL_INI = New System.Windows.Forms.DateTimePicker()
            Me.lblPVE_ESTADO = New System.Windows.Forms.Label()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_CAJ = New System.Windows.Forms.Label()
            Me.txtPER_ID_CAJ = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO_CAJ = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_CAJ = New System.Windows.Forms.TextBox()
            Me.lblCCC_CUENTA_BANCARIA = New System.Windows.Forms.Label()
            Me.txtCCC_CUENTA_BANCARIA = New System.Windows.Forms.TextBox()
            Me.lblCCC_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtCCC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPER_ID_BAN = New System.Windows.Forms.Label()
            Me.txtPER_ID_BAN = New System.Windows.Forms.TextBox()
            Me.lblCCC_TIPO = New System.Windows.Forms.Label()
            Me.cboCCC_TIPO = New System.Windows.Forms.ComboBox()
            Me.chkPER_ESTADO_BAN = New System.Windows.Forms.CheckBox()
            Me.lblCCC_MONTO_SAL_INI = New System.Windows.Forms.Label()
            Me.txtCCC_MONTO_SAL_INI = New System.Windows.Forms.TextBox()
            Me.lblCCC_ID = New System.Windows.Forms.Label()
            Me.lblCCC_ESTADO = New System.Windows.Forms.Label()
            Me.txtCCC_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_BAN = New System.Windows.Forms.TextBox()
            Me.chkCCC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(901, 28)
            Me.lblTitle.Text = "Caja - Cuenta corriente"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(813, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(48, 28)
            Me.btnImagen.TabIndex = 14
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCUC_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCUC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_FECHA_SAL_INI)
            Me.pnCuerpo.Controls.Add(Me.dtpCCC_FECHA_SAL_INI)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CAJ)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CAJ)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_CAJ)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CAJ)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_CUENTA_BANCARIA)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_CUENTA_BANCARIA)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_BAN)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.cboCCC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_BAN)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_MONTO_SAL_INI)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_MONTO_SAL_INI)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCCC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCCC_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_BAN)
            Me.pnCuerpo.Controls.Add(Me.chkCCC_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(827, 281)
            Me.pnCuerpo.TabIndex = 15
            '
            'lblCUC_ID
            '
            Me.lblCUC_ID.AutoSize = True
            Me.lblCUC_ID.Location = New System.Drawing.Point(7, 241)
            Me.lblCUC_ID.Name = "lblCUC_ID"
            Me.lblCUC_ID.Size = New System.Drawing.Size(96, 13)
            Me.lblCUC_ID.TabIndex = 46
            Me.lblCUC_ID.Text = "Cód. Cta. Contable"
            '
            'txtCUC_ID
            '
            Me.txtCUC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCUC_ID.Location = New System.Drawing.Point(108, 241)
            Me.txtCUC_ID.Name = "txtCUC_ID"
            Me.txtCUC_ID.Size = New System.Drawing.Size(166, 20)
            Me.txtCUC_ID.TabIndex = 43
            '
            'chkCUC_ESTADO
            '
            Me.chkCUC_ESTADO.AutoSize = True
            Me.chkCUC_ESTADO.Enabled = False
            Me.chkCUC_ESTADO.Location = New System.Drawing.Point(714, 241)
            Me.chkCUC_ESTADO.Name = "chkCUC_ESTADO"
            Me.chkCUC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCUC_ESTADO.TabIndex = 45
            Me.chkCUC_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCUC_DESCRIPCION
            '
            Me.txtCUC_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCUC_DESCRIPCION.Enabled = False
            Me.txtCUC_DESCRIPCION.Location = New System.Drawing.Point(280, 241)
            Me.txtCUC_DESCRIPCION.Name = "txtCUC_DESCRIPCION"
            Me.txtCUC_DESCRIPCION.ReadOnly = True
            Me.txtCUC_DESCRIPCION.Size = New System.Drawing.Size(416, 20)
            Me.txtCUC_DESCRIPCION.TabIndex = 44
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(7, 206)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(82, 13)
            Me.lblMON_ID.TabIndex = 42
            Me.lblMON_ID.Text = "Código Moneda"
            '
            'txtMON_ID
            '
            Me.txtMON_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_ID.Location = New System.Drawing.Point(108, 206)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtMON_ID.TabIndex = 16
            '
            'chkMON_ESTADO
            '
            Me.chkMON_ESTADO.AutoSize = True
            Me.chkMON_ESTADO.Enabled = False
            Me.chkMON_ESTADO.Location = New System.Drawing.Point(714, 206)
            Me.chkMON_ESTADO.Name = "chkMON_ESTADO"
            Me.chkMON_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO.TabIndex = 18
            Me.chkMON_ESTADO.UseVisualStyleBackColor = True
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(151, 206)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(545, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 17
            '
            'lblCCC_FECHA_SAL_INI
            '
            Me.lblCCC_FECHA_SAL_INI.AutoSize = True
            Me.lblCCC_FECHA_SAL_INI.Location = New System.Drawing.Point(7, 176)
            Me.lblCCC_FECHA_SAL_INI.Name = "lblCCC_FECHA_SAL_INI"
            Me.lblCCC_FECHA_SAL_INI.Size = New System.Drawing.Size(64, 13)
            Me.lblCCC_FECHA_SAL_INI.TabIndex = 38
            Me.lblCCC_FECHA_SAL_INI.Text = "Fecha inicio"
            '
            'dtpCCC_FECHA_SAL_INI
            '
            Me.dtpCCC_FECHA_SAL_INI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpCCC_FECHA_SAL_INI.Location = New System.Drawing.Point(108, 176)
            Me.dtpCCC_FECHA_SAL_INI.Name = "dtpCCC_FECHA_SAL_INI"
            Me.dtpCCC_FECHA_SAL_INI.Size = New System.Drawing.Size(87, 20)
            Me.dtpCCC_FECHA_SAL_INI.TabIndex = 14
            '
            'lblPVE_ESTADO
            '
            Me.lblPVE_ESTADO.AutoSize = True
            Me.lblPVE_ESTADO.Location = New System.Drawing.Point(7, 149)
            Me.lblPVE_ESTADO.Name = "lblPVE_ESTADO"
            Me.lblPVE_ESTADO.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ESTADO.TabIndex = 36
            Me.lblPVE_ESTADO.Text = "Punto venta"
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_ID.Location = New System.Drawing.Point(108, 149)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtPVE_ID.TabIndex = 11
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(714, 152)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 13
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(151, 149)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(545, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 12
            '
            'lblPER_ID_CAJ
            '
            Me.lblPER_ID_CAJ.AutoSize = True
            Me.lblPER_ID_CAJ.Location = New System.Drawing.Point(7, 123)
            Me.lblPER_ID_CAJ.Name = "lblPER_ID_CAJ"
            Me.lblPER_ID_CAJ.Size = New System.Drawing.Size(73, 13)
            Me.lblPER_ID_CAJ.TabIndex = 32
            Me.lblPER_ID_CAJ.Text = "Código Cajero"
            '
            'txtPER_ID_CAJ
            '
            Me.txtPER_ID_CAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_CAJ.Location = New System.Drawing.Point(108, 123)
            Me.txtPER_ID_CAJ.Name = "txtPER_ID_CAJ"
            Me.txtPER_ID_CAJ.Size = New System.Drawing.Size(72, 20)
            Me.txtPER_ID_CAJ.TabIndex = 8
            '
            'chkPER_ESTADO_CAJ
            '
            Me.chkPER_ESTADO_CAJ.AutoSize = True
            Me.chkPER_ESTADO_CAJ.Enabled = False
            Me.chkPER_ESTADO_CAJ.Location = New System.Drawing.Point(714, 129)
            Me.chkPER_ESTADO_CAJ.Name = "chkPER_ESTADO_CAJ"
            Me.chkPER_ESTADO_CAJ.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_CAJ.TabIndex = 10
            Me.chkPER_ESTADO_CAJ.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_CAJ
            '
            Me.txtPER_DESCRIPCION_CAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_CAJ.Enabled = False
            Me.txtPER_DESCRIPCION_CAJ.Location = New System.Drawing.Point(186, 123)
            Me.txtPER_DESCRIPCION_CAJ.Name = "txtPER_DESCRIPCION_CAJ"
            Me.txtPER_DESCRIPCION_CAJ.ReadOnly = True
            Me.txtPER_DESCRIPCION_CAJ.Size = New System.Drawing.Size(510, 20)
            Me.txtPER_DESCRIPCION_CAJ.TabIndex = 9
            '
            'lblCCC_CUENTA_BANCARIA
            '
            Me.lblCCC_CUENTA_BANCARIA.AutoSize = True
            Me.lblCCC_CUENTA_BANCARIA.Location = New System.Drawing.Point(7, 97)
            Me.lblCCC_CUENTA_BANCARIA.Name = "lblCCC_CUENTA_BANCARIA"
            Me.lblCCC_CUENTA_BANCARIA.Size = New System.Drawing.Size(94, 13)
            Me.lblCCC_CUENTA_BANCARIA.TabIndex = 28
            Me.lblCCC_CUENTA_BANCARIA.Text = "Nro. Cta. Bancaria"
            '
            'txtCCC_CUENTA_BANCARIA
            '
            Me.txtCCC_CUENTA_BANCARIA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_CUENTA_BANCARIA.Location = New System.Drawing.Point(108, 97)
            Me.txtCCC_CUENTA_BANCARIA.Name = "txtCCC_CUENTA_BANCARIA"
            Me.txtCCC_CUENTA_BANCARIA.Size = New System.Drawing.Size(694, 20)
            Me.txtCCC_CUENTA_BANCARIA.TabIndex = 7
            '
            'lblCCC_DESCRIPCION
            '
            Me.lblCCC_DESCRIPCION.AutoSize = True
            Me.lblCCC_DESCRIPCION.Location = New System.Drawing.Point(7, 71)
            Me.lblCCC_DESCRIPCION.Name = "lblCCC_DESCRIPCION"
            Me.lblCCC_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblCCC_DESCRIPCION.TabIndex = 26
            Me.lblCCC_DESCRIPCION.Text = "Descripción"
            '
            'txtCCC_DESCRIPCION
            '
            Me.txtCCC_DESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_DESCRIPCION.Location = New System.Drawing.Point(108, 71)
            Me.txtCCC_DESCRIPCION.Name = "txtCCC_DESCRIPCION"
            Me.txtCCC_DESCRIPCION.Size = New System.Drawing.Size(694, 20)
            Me.txtCCC_DESCRIPCION.TabIndex = 6
            '
            'lblPER_ID_BAN
            '
            Me.lblPER_ID_BAN.AutoSize = True
            Me.lblPER_ID_BAN.Location = New System.Drawing.Point(7, 45)
            Me.lblPER_ID_BAN.Name = "lblPER_ID_BAN"
            Me.lblPER_ID_BAN.Size = New System.Drawing.Size(74, 13)
            Me.lblPER_ID_BAN.TabIndex = 24
            Me.lblPER_ID_BAN.Text = "Código Banco"
            '
            'txtPER_ID_BAN
            '
            Me.txtPER_ID_BAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_BAN.Location = New System.Drawing.Point(108, 45)
            Me.txtPER_ID_BAN.Name = "txtPER_ID_BAN"
            Me.txtPER_ID_BAN.Size = New System.Drawing.Size(72, 20)
            Me.txtPER_ID_BAN.TabIndex = 3
            '
            'lblCCC_TIPO
            '
            Me.lblCCC_TIPO.AutoSize = True
            Me.lblCCC_TIPO.Location = New System.Drawing.Point(213, 21)
            Me.lblCCC_TIPO.Name = "lblCCC_TIPO"
            Me.lblCCC_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblCCC_TIPO.TabIndex = 22
            Me.lblCCC_TIPO.Text = "Tipo"
            '
            'cboCCC_TIPO
            '
            Me.cboCCC_TIPO.FormattingEnabled = True
            Me.cboCCC_TIPO.Location = New System.Drawing.Point(280, 18)
            Me.cboCCC_TIPO.Name = "cboCCC_TIPO"
            Me.cboCCC_TIPO.Size = New System.Drawing.Size(262, 21)
            Me.cboCCC_TIPO.TabIndex = 1
            '
            'chkPER_ESTADO_BAN
            '
            Me.chkPER_ESTADO_BAN.AutoSize = True
            Me.chkPER_ESTADO_BAN.Enabled = False
            Me.chkPER_ESTADO_BAN.Location = New System.Drawing.Point(714, 51)
            Me.chkPER_ESTADO_BAN.Name = "chkPER_ESTADO_BAN"
            Me.chkPER_ESTADO_BAN.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_BAN.TabIndex = 5
            Me.chkPER_ESTADO_BAN.UseVisualStyleBackColor = True
            '
            'lblCCC_MONTO_SAL_INI
            '
            Me.lblCCC_MONTO_SAL_INI.AutoSize = True
            Me.lblCCC_MONTO_SAL_INI.Location = New System.Drawing.Point(213, 177)
            Me.lblCCC_MONTO_SAL_INI.Name = "lblCCC_MONTO_SAL_INI"
            Me.lblCCC_MONTO_SAL_INI.Size = New System.Drawing.Size(63, 13)
            Me.lblCCC_MONTO_SAL_INI.TabIndex = 10
            Me.lblCCC_MONTO_SAL_INI.Text = "Saldo inicial"
            '
            'txtCCC_MONTO_SAL_INI
            '
            Me.txtCCC_MONTO_SAL_INI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_MONTO_SAL_INI.Location = New System.Drawing.Point(280, 176)
            Me.txtCCC_MONTO_SAL_INI.Name = "txtCCC_MONTO_SAL_INI"
            Me.txtCCC_MONTO_SAL_INI.Size = New System.Drawing.Size(89, 20)
            Me.txtCCC_MONTO_SAL_INI.TabIndex = 15
            Me.txtCCC_MONTO_SAL_INI.Text = "0.00"
            '
            'lblCCC_ID
            '
            Me.lblCCC_ID.AutoSize = True
            Me.lblCCC_ID.Location = New System.Drawing.Point(7, 17)
            Me.lblCCC_ID.Name = "lblCCC_ID"
            Me.lblCCC_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCCC_ID.TabIndex = 0
            Me.lblCCC_ID.Text = "Código"
            '
            'lblCCC_ESTADO
            '
            Me.lblCCC_ESTADO.AutoSize = True
            Me.lblCCC_ESTADO.Location = New System.Drawing.Point(656, 25)
            Me.lblCCC_ESTADO.Name = "lblCCC_ESTADO"
            Me.lblCCC_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCCC_ESTADO.TabIndex = 4
            Me.lblCCC_ESTADO.Text = "Estado"
            '
            'txtCCC_ID
            '
            Me.txtCCC_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtCCC_ID.Location = New System.Drawing.Point(108, 17)
            Me.txtCCC_ID.Name = "txtCCC_ID"
            Me.txtCCC_ID.Size = New System.Drawing.Size(37, 20)
            Me.txtCCC_ID.TabIndex = 0
            '
            'txtPER_DESCRIPCION_BAN
            '
            Me.txtPER_DESCRIPCION_BAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_BAN.Enabled = False
            Me.txtPER_DESCRIPCION_BAN.Location = New System.Drawing.Point(186, 45)
            Me.txtPER_DESCRIPCION_BAN.Name = "txtPER_DESCRIPCION_BAN"
            Me.txtPER_DESCRIPCION_BAN.ReadOnly = True
            Me.txtPER_DESCRIPCION_BAN.Size = New System.Drawing.Size(510, 20)
            Me.txtPER_DESCRIPCION_BAN.TabIndex = 4
            '
            'chkCCC_ESTADO
            '
            Me.chkCCC_ESTADO.AutoSize = True
            Me.chkCCC_ESTADO.Location = New System.Drawing.Point(714, 24)
            Me.chkCCC_ESTADO.Name = "chkCCC_ESTADO"
            Me.chkCCC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCCC_ESTADO.TabIndex = 2
            Me.chkCCC_ESTADO.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmCajaCtaCte
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(901, 349)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmCajaCtaCte"
            Me.Text = "Caja - Cuenta corriente"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents chkPER_ESTADO_BAN As System.Windows.Forms.CheckBox
        Friend WithEvents lblCCC_MONTO_SAL_INI As System.Windows.Forms.Label
        Public WithEvents txtCCC_MONTO_SAL_INI As System.Windows.Forms.TextBox
        Friend WithEvents lblCCC_ID As System.Windows.Forms.Label
        Friend WithEvents lblCCC_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtCCC_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_BAN As System.Windows.Forms.TextBox
        Public WithEvents chkCCC_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblCCC_TIPO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_BAN As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_BAN As System.Windows.Forms.TextBox
        Friend WithEvents lblCCC_FECHA_SAL_INI As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ESTADO As System.Windows.Forms.Label
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID_CAJ As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_CAJ As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO_CAJ As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_CAJ As System.Windows.Forms.TextBox
        Friend WithEvents lblCCC_CUENTA_BANCARIA As System.Windows.Forms.Label
        Public WithEvents txtCCC_CUENTA_BANCARIA As System.Windows.Forms.TextBox
        Friend WithEvents lblCCC_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtCCC_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents chkMON_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblCUC_ID As System.Windows.Forms.Label
        Public WithEvents txtCUC_ID As System.Windows.Forms.TextBox
        Public WithEvents chkCUC_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCUC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents dtpCCC_FECHA_SAL_INI As System.Windows.Forms.DateTimePicker
        Public WithEvents cboCCC_TIPO As System.Windows.Forms.ComboBox
    End Class
End Namespace