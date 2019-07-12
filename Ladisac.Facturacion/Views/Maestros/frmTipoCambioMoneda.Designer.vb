Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoCambioMoneda
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
            Me.lblTCA_VENTA = New System.Windows.Forms.Label()
            Me.txtTCA_VENTA = New System.Windows.Forms.TextBox()
            Me.txtMON_ORIGEN_0 = New System.Windows.Forms.TextBox()
            Me.txtMON_SIMBOLO_0 = New System.Windows.Forms.TextBox()
            Me.txtMON_ORIGEN_1 = New System.Windows.Forms.TextBox()
            Me.txtMON_SIMBOLO_1 = New System.Windows.Forms.TextBox()
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblTCA_FECHA = New System.Windows.Forms.Label()
            Me.lblTCA_COMPRA = New System.Windows.Forms.Label()
            Me.lblMON_ID_0 = New System.Windows.Forms.Label()
            Me.lblMON_ID_1 = New System.Windows.Forms.Label()
            Me.dtpTCA_FECHA = New System.Windows.Forms.DateTimePicker()
            Me.chkTCA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTCA_COMPRA = New System.Windows.Forms.TextBox()
            Me.chkMON_ESTADO_0 = New System.Windows.Forms.CheckBox()
            Me.chkMON_ESTADO_1 = New System.Windows.Forms.CheckBox()
            Me.txtMON_DESCRIPCION_0 = New System.Windows.Forms.TextBox()
            Me.txtMON_DESCRIPCION_1 = New System.Windows.Forms.TextBox()
            Me.txtMON_ID_0 = New System.Windows.Forms.TextBox()
            Me.txtMON_ID_1 = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(645, 28)
            Me.lblTitle.Text = "Tipo cambio moneda"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTCA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.txtTCA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ORIGEN_0)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO_0)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ORIGEN_1)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO_1)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTCA_FECHA)
            Me.pnCuerpo.Controls.Add(Me.lblTCA_COMPRA)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID_0)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID_1)
            Me.pnCuerpo.Controls.Add(Me.dtpTCA_FECHA)
            Me.pnCuerpo.Controls.Add(Me.chkTCA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTCA_COMPRA)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ESTADO_0)
            Me.pnCuerpo.Controls.Add(Me.chkMON_ESTADO_1)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION_0)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION_1)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID_0)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID_1)
            Me.pnCuerpo.Location = New System.Drawing.Point(31, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(572, 202)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblTCA_VENTA
            '
            Me.lblTCA_VENTA.AutoSize = True
            Me.lblTCA_VENTA.Location = New System.Drawing.Point(415, 130)
            Me.lblTCA_VENTA.Name = "lblTCA_VENTA"
            Me.lblTCA_VENTA.Size = New System.Drawing.Size(35, 13)
            Me.lblTCA_VENTA.TabIndex = 45
            Me.lblTCA_VENTA.Text = "Venta"
            '
            'txtTCA_VENTA
            '
            Me.txtTCA_VENTA.Location = New System.Drawing.Point(462, 130)
            Me.txtTCA_VENTA.Name = "txtTCA_VENTA"
            Me.txtTCA_VENTA.Size = New System.Drawing.Size(91, 20)
            Me.txtTCA_VENTA.TabIndex = 12
            Me.txtTCA_VENTA.Text = "0"
            Me.txtTCA_VENTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtMON_ORIGEN_0
            '
            Me.txtMON_ORIGEN_0.Enabled = False
            Me.txtMON_ORIGEN_0.Location = New System.Drawing.Point(289, 104)
            Me.txtMON_ORIGEN_0.Name = "txtMON_ORIGEN_0"
            Me.txtMON_ORIGEN_0.ReadOnly = True
            Me.txtMON_ORIGEN_0.Size = New System.Drawing.Size(163, 20)
            Me.txtMON_ORIGEN_0.TabIndex = 8
            '
            'txtMON_SIMBOLO_0
            '
            Me.txtMON_SIMBOLO_0.Enabled = False
            Me.txtMON_SIMBOLO_0.Location = New System.Drawing.Point(120, 104)
            Me.txtMON_SIMBOLO_0.Name = "txtMON_SIMBOLO_0"
            Me.txtMON_SIMBOLO_0.ReadOnly = True
            Me.txtMON_SIMBOLO_0.Size = New System.Drawing.Size(163, 20)
            Me.txtMON_SIMBOLO_0.TabIndex = 7
            '
            'txtMON_ORIGEN_1
            '
            Me.txtMON_ORIGEN_1.Enabled = False
            Me.txtMON_ORIGEN_1.Location = New System.Drawing.Point(289, 47)
            Me.txtMON_ORIGEN_1.Name = "txtMON_ORIGEN_1"
            Me.txtMON_ORIGEN_1.ReadOnly = True
            Me.txtMON_ORIGEN_1.Size = New System.Drawing.Size(163, 20)
            Me.txtMON_ORIGEN_1.TabIndex = 3
            '
            'txtMON_SIMBOLO_1
            '
            Me.txtMON_SIMBOLO_1.Enabled = False
            Me.txtMON_SIMBOLO_1.Location = New System.Drawing.Point(120, 47)
            Me.txtMON_SIMBOLO_1.Name = "txtMON_SIMBOLO_1"
            Me.txtMON_SIMBOLO_1.ReadOnly = True
            Me.txtMON_SIMBOLO_1.Size = New System.Drawing.Size(163, 20)
            Me.txtMON_SIMBOLO_1.TabIndex = 2
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(15, 162)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblTCA_FECHA
            '
            Me.lblTCA_FECHA.AutoSize = True
            Me.lblTCA_FECHA.Location = New System.Drawing.Point(15, 130)
            Me.lblTCA_FECHA.Name = "lblTCA_FECHA"
            Me.lblTCA_FECHA.Size = New System.Drawing.Size(89, 13)
            Me.lblTCA_FECHA.TabIndex = 35
            Me.lblTCA_FECHA.Text = "Fecha de cambio"
            '
            'lblTCA_COMPRA
            '
            Me.lblTCA_COMPRA.AutoSize = True
            Me.lblTCA_COMPRA.Location = New System.Drawing.Point(238, 130)
            Me.lblTCA_COMPRA.Name = "lblTCA_COMPRA"
            Me.lblTCA_COMPRA.Size = New System.Drawing.Size(43, 13)
            Me.lblTCA_COMPRA.TabIndex = 27
            Me.lblTCA_COMPRA.Text = "Compra"
            '
            'lblMON_ID_0
            '
            Me.lblMON_ID_0.AutoSize = True
            Me.lblMON_ID_0.Location = New System.Drawing.Point(15, 75)
            Me.lblMON_ID_0.Name = "lblMON_ID_0"
            Me.lblMON_ID_0.Size = New System.Drawing.Size(95, 13)
            Me.lblMON_ID_0.TabIndex = 26
            Me.lblMON_ID_0.Text = "Moneda a cambiar"
            '
            'lblMON_ID_1
            '
            Me.lblMON_ID_1.AutoSize = True
            Me.lblMON_ID_1.Location = New System.Drawing.Point(15, 21)
            Me.lblMON_ID_1.Name = "lblMON_ID_1"
            Me.lblMON_ID_1.Size = New System.Drawing.Size(101, 13)
            Me.lblMON_ID_1.TabIndex = 25
            Me.lblMON_ID_1.Text = "Moneda del sistema"
            '
            'dtpTCA_FECHA
            '
            Me.dtpTCA_FECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpTCA_FECHA.Location = New System.Drawing.Point(120, 130)
            Me.dtpTCA_FECHA.Name = "dtpTCA_FECHA"
            Me.dtpTCA_FECHA.Size = New System.Drawing.Size(103, 20)
            Me.dtpTCA_FECHA.TabIndex = 10
            '
            'chkTCA_ESTADO
            '
            Me.chkTCA_ESTADO.AutoSize = True
            Me.chkTCA_ESTADO.Location = New System.Drawing.Point(120, 162)
            Me.chkTCA_ESTADO.Name = "chkTCA_ESTADO"
            Me.chkTCA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTCA_ESTADO.TabIndex = 13
            Me.chkTCA_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTCA_COMPRA
            '
            Me.txtTCA_COMPRA.Location = New System.Drawing.Point(289, 130)
            Me.txtTCA_COMPRA.Name = "txtTCA_COMPRA"
            Me.txtTCA_COMPRA.Size = New System.Drawing.Size(91, 20)
            Me.txtTCA_COMPRA.TabIndex = 11
            Me.txtTCA_COMPRA.Text = "0"
            Me.txtTCA_COMPRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'chkMON_ESTADO_0
            '
            Me.chkMON_ESTADO_0.AutoSize = True
            Me.chkMON_ESTADO_0.Enabled = False
            Me.chkMON_ESTADO_0.Location = New System.Drawing.Point(462, 104)
            Me.chkMON_ESTADO_0.Name = "chkMON_ESTADO_0"
            Me.chkMON_ESTADO_0.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO_0.TabIndex = 9
            Me.chkMON_ESTADO_0.UseVisualStyleBackColor = True
            '
            'chkMON_ESTADO_1
            '
            Me.chkMON_ESTADO_1.AutoSize = True
            Me.chkMON_ESTADO_1.Enabled = False
            Me.chkMON_ESTADO_1.Location = New System.Drawing.Point(462, 50)
            Me.chkMON_ESTADO_1.Name = "chkMON_ESTADO_1"
            Me.chkMON_ESTADO_1.Size = New System.Drawing.Size(15, 14)
            Me.chkMON_ESTADO_1.TabIndex = 4
            Me.chkMON_ESTADO_1.UseVisualStyleBackColor = True
            '
            'txtMON_DESCRIPCION_0
            '
            Me.txtMON_DESCRIPCION_0.Enabled = False
            Me.txtMON_DESCRIPCION_0.Location = New System.Drawing.Point(160, 75)
            Me.txtMON_DESCRIPCION_0.Name = "txtMON_DESCRIPCION_0"
            Me.txtMON_DESCRIPCION_0.ReadOnly = True
            Me.txtMON_DESCRIPCION_0.Size = New System.Drawing.Size(393, 20)
            Me.txtMON_DESCRIPCION_0.TabIndex = 6
            '
            'txtMON_DESCRIPCION_1
            '
            Me.txtMON_DESCRIPCION_1.Enabled = False
            Me.txtMON_DESCRIPCION_1.Location = New System.Drawing.Point(160, 21)
            Me.txtMON_DESCRIPCION_1.Name = "txtMON_DESCRIPCION_1"
            Me.txtMON_DESCRIPCION_1.ReadOnly = True
            Me.txtMON_DESCRIPCION_1.Size = New System.Drawing.Size(393, 20)
            Me.txtMON_DESCRIPCION_1.TabIndex = 1
            '
            'txtMON_ID_0
            '
            Me.txtMON_ID_0.Location = New System.Drawing.Point(120, 75)
            Me.txtMON_ID_0.Name = "txtMON_ID_0"
            Me.txtMON_ID_0.Size = New System.Drawing.Size(34, 20)
            Me.txtMON_ID_0.TabIndex = 5
            '
            'txtMON_ID_1
            '
            Me.txtMON_ID_1.Enabled = False
            Me.txtMON_ID_1.Location = New System.Drawing.Point(120, 21)
            Me.txtMON_ID_1.Name = "txtMON_ID_1"
            Me.txtMON_ID_1.ReadOnly = True
            Me.txtMON_ID_1.Size = New System.Drawing.Size(34, 20)
            Me.txtMON_ID_1.TabIndex = 0
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(558, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 120
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmTipoCambioMoneda
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(645, 280)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmTipoCambioMoneda"
            Me.Text = "Tipo cambio moneda"
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
        Public WithEvents txtMON_ORIGEN_1 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO_1 As System.Windows.Forms.TextBox
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblTCA_FECHA As System.Windows.Forms.Label
        Friend WithEvents lblTCA_COMPRA As System.Windows.Forms.Label
        Friend WithEvents lblMON_ID_0 As System.Windows.Forms.Label
        Friend WithEvents lblMON_ID_1 As System.Windows.Forms.Label
        Public WithEvents dtpTCA_FECHA As System.Windows.Forms.DateTimePicker
        Public WithEvents chkTCA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTCA_COMPRA As System.Windows.Forms.TextBox
        Public WithEvents chkMON_ESTADO_0 As System.Windows.Forms.CheckBox
        Public WithEvents chkMON_ESTADO_1 As System.Windows.Forms.CheckBox
        Public WithEvents txtMON_DESCRIPCION_0 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION_1 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID_0 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID_1 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ORIGEN_0 As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO_0 As System.Windows.Forms.TextBox
        Friend WithEvents lblTCA_VENTA As System.Windows.Forms.Label
        Public WithEvents txtTCA_VENTA As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace