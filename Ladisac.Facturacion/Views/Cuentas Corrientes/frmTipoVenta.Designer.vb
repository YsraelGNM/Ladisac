Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoVenta
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
            Me.lblTIV_ID = New System.Windows.Forms.Label()
            Me.txtTIV_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTIV_ID = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.lblTIV_COMPORTAMIENTO = New System.Windows.Forms.Label()
            Me.cboTIV_COMPORTAMIENTO = New System.Windows.Forms.ComboBox()
            Me.lblTIV_DIAS = New System.Windows.Forms.Label()
            Me.txtTIV_DIAS = New System.Windows.Forms.TextBox()
            Me.lblTIV_ESTADO = New System.Windows.Forms.Label()
            Me.chkTIV_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblTIV_DESCRIPCION = New System.Windows.Forms.Label()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.lblTIV_FORMA_VENTA = New System.Windows.Forms.Label()
            Me.cboTIV_FORMA_VENTA = New System.Windows.Forms.ComboBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(686, 28)
            Me.lblTitle.Text = "Tipo venta"
            '
            'lblTIV_ID
            '
            Me.lblTIV_ID.AutoSize = True
            Me.lblTIV_ID.Location = New System.Drawing.Point(19, 10)
            Me.lblTIV_ID.Name = "lblTIV_ID"
            Me.lblTIV_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblTIV_ID.TabIndex = 28
            Me.lblTIV_ID.Text = "Código"
            '
            'txtTIV_DESCRIPCION
            '
            Me.txtTIV_DESCRIPCION.Location = New System.Drawing.Point(111, 35)
            Me.txtTIV_DESCRIPCION.Name = "txtTIV_DESCRIPCION"
            Me.txtTIV_DESCRIPCION.Size = New System.Drawing.Size(495, 20)
            Me.txtTIV_DESCRIPCION.TabIndex = 1
            '
            'txtTIV_ID
            '
            Me.txtTIV_ID.Location = New System.Drawing.Point(111, 10)
            Me.txtTIV_ID.Name = "txtTIV_ID"
            Me.txtTIV_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTIV_ID.TabIndex = 0
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'lblTIV_COMPORTAMIENTO
            '
            Me.lblTIV_COMPORTAMIENTO.AutoSize = True
            Me.lblTIV_COMPORTAMIENTO.Location = New System.Drawing.Point(19, 88)
            Me.lblTIV_COMPORTAMIENTO.Name = "lblTIV_COMPORTAMIENTO"
            Me.lblTIV_COMPORTAMIENTO.Size = New System.Drawing.Size(83, 13)
            Me.lblTIV_COMPORTAMIENTO.TabIndex = 30
            Me.lblTIV_COMPORTAMIENTO.Text = "Comportamiento"
            '
            'cboTIV_COMPORTAMIENTO
            '
            Me.cboTIV_COMPORTAMIENTO.FormattingEnabled = True
            Me.cboTIV_COMPORTAMIENTO.Location = New System.Drawing.Point(111, 88)
            Me.cboTIV_COMPORTAMIENTO.Name = "cboTIV_COMPORTAMIENTO"
            Me.cboTIV_COMPORTAMIENTO.Size = New System.Drawing.Size(114, 21)
            Me.cboTIV_COMPORTAMIENTO.TabIndex = 3
            '
            'lblTIV_DIAS
            '
            Me.lblTIV_DIAS.AutoSize = True
            Me.lblTIV_DIAS.Location = New System.Drawing.Point(19, 62)
            Me.lblTIV_DIAS.Name = "lblTIV_DIAS"
            Me.lblTIV_DIAS.Size = New System.Drawing.Size(30, 13)
            Me.lblTIV_DIAS.TabIndex = 32
            Me.lblTIV_DIAS.Text = "Días"
            '
            'txtTIV_DIAS
            '
            Me.txtTIV_DIAS.Location = New System.Drawing.Point(111, 62)
            Me.txtTIV_DIAS.Name = "txtTIV_DIAS"
            Me.txtTIV_DIAS.Size = New System.Drawing.Size(114, 20)
            Me.txtTIV_DIAS.TabIndex = 2
            Me.txtTIV_DIAS.Text = "0"
            '
            'lblTIV_ESTADO
            '
            Me.lblTIV_ESTADO.AutoSize = True
            Me.lblTIV_ESTADO.Location = New System.Drawing.Point(19, 142)
            Me.lblTIV_ESTADO.Name = "lblTIV_ESTADO"
            Me.lblTIV_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTIV_ESTADO.TabIndex = 38
            Me.lblTIV_ESTADO.Text = "Estado"
            '
            'chkTIV_ESTADO
            '
            Me.chkTIV_ESTADO.AutoSize = True
            Me.chkTIV_ESTADO.Location = New System.Drawing.Point(111, 142)
            Me.chkTIV_ESTADO.Name = "chkTIV_ESTADO"
            Me.chkTIV_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTIV_ESTADO.TabIndex = 5
            Me.chkTIV_ESTADO.UseVisualStyleBackColor = True
            '
            'lblTIV_DESCRIPCION
            '
            Me.lblTIV_DESCRIPCION.AutoSize = True
            Me.lblTIV_DESCRIPCION.Location = New System.Drawing.Point(19, 35)
            Me.lblTIV_DESCRIPCION.Name = "lblTIV_DESCRIPCION"
            Me.lblTIV_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblTIV_DESCRIPCION.TabIndex = 39
            Me.lblTIV_DESCRIPCION.Text = "Descripción"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblTIV_FORMA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.cboTIV_FORMA_VENTA)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkTIV_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_DIAS)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DIAS)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_COMPORTAMIENTO)
            Me.pnCuerpo.Controls.Add(Me.cboTIV_COMPORTAMIENTO)
            Me.pnCuerpo.Location = New System.Drawing.Point(28, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(623, 172)
            Me.pnCuerpo.TabIndex = 118
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(606, 1)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'lblTIV_FORMA_VENTA
            '
            Me.lblTIV_FORMA_VENTA.AutoSize = True
            Me.lblTIV_FORMA_VENTA.Location = New System.Drawing.Point(19, 115)
            Me.lblTIV_FORMA_VENTA.Name = "lblTIV_FORMA_VENTA"
            Me.lblTIV_FORMA_VENTA.Size = New System.Drawing.Size(81, 13)
            Me.lblTIV_FORMA_VENTA.TabIndex = 41
            Me.lblTIV_FORMA_VENTA.Text = "Forma de venta"
            '
            'cboTIV_FORMA_VENTA
            '
            Me.cboTIV_FORMA_VENTA.FormattingEnabled = True
            Me.cboTIV_FORMA_VENTA.Location = New System.Drawing.Point(111, 115)
            Me.cboTIV_FORMA_VENTA.Name = "cboTIV_FORMA_VENTA"
            Me.cboTIV_FORMA_VENTA.Size = New System.Drawing.Size(114, 21)
            Me.cboTIV_FORMA_VENTA.TabIndex = 4
            '
            'frmTipoVenta
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(686, 232)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmTipoVenta"
            Me.Text = "Tipo venta"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblTIV_ID As System.Windows.Forms.Label
        Public WithEvents txtTIV_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTIV_ID As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblTIV_COMPORTAMIENTO As System.Windows.Forms.Label
        Public WithEvents cboTIV_COMPORTAMIENTO As System.Windows.Forms.ComboBox
        Friend WithEvents lblTIV_DIAS As System.Windows.Forms.Label
        Public WithEvents txtTIV_DIAS As System.Windows.Forms.TextBox
        Friend WithEvents lblTIV_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkTIV_ESTADO As System.Windows.Forms.CheckBox
        Friend WithEvents lblTIV_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblTIV_FORMA_VENTA As System.Windows.Forms.Label
        Public WithEvents cboTIV_FORMA_VENTA As System.Windows.Forms.ComboBox
    End Class
End Namespace