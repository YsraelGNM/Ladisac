Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmComision
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
            Me.lblCOM_VENTA_CAN = New System.Windows.Forms.Label()
            Me.cboCOM_VENTA_CAN = New System.Windows.Forms.ComboBox()
            Me.lblCOM_ESTADO = New System.Windows.Forms.Label()
            Me.chkCOM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCOM_POR_OBJ_MEN = New System.Windows.Forms.TextBox()
            Me.lblCOM_POR_OBJ_MEN = New System.Windows.Forms.Label()
            Me.lblCOM_POR_CUO_MEN = New System.Windows.Forms.Label()
            Me.lblCOM_FORMULA = New System.Windows.Forms.Label()
            Me.txtCOM_POR_CUO_MEN = New System.Windows.Forms.TextBox()
            Me.txtCOM_FORMULA = New System.Windows.Forms.TextBox()
            Me.lblCOM_ID = New System.Windows.Forms.Label()
            Me.lblCOM_DESCRIPCION = New System.Windows.Forms.Label()
            Me.txtCOM_ID = New System.Windows.Forms.TextBox()
            Me.txtCOM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(779, 28)
            Me.lblTitle.Text = "Comisión"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCOM_VENTA_CAN)
            Me.pnCuerpo.Controls.Add(Me.cboCOM_VENTA_CAN)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkCOM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_POR_OBJ_MEN)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_POR_OBJ_MEN)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_POR_CUO_MEN)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_FORMULA)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_POR_CUO_MEN)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_FORMULA)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_ID)
            Me.pnCuerpo.Controls.Add(Me.lblCOM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_ID)
            Me.pnCuerpo.Controls.Add(Me.txtCOM_DESCRIPCION)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(713, 191)
            Me.pnCuerpo.TabIndex = 20
            '
            'lblCOM_VENTA_CAN
            '
            Me.lblCOM_VENTA_CAN.AutoSize = True
            Me.lblCOM_VENTA_CAN.Location = New System.Drawing.Point(16, 77)
            Me.lblCOM_VENTA_CAN.Name = "lblCOM_VENTA_CAN"
            Me.lblCOM_VENTA_CAN.Size = New System.Drawing.Size(98, 13)
            Me.lblCOM_VENTA_CAN.TabIndex = 110
            Me.lblCOM_VENTA_CAN.Text = "Criterio de comisión"
            '
            'cboCOM_VENTA_CAN
            '
            Me.cboCOM_VENTA_CAN.FormattingEnabled = True
            Me.cboCOM_VENTA_CAN.Location = New System.Drawing.Point(125, 77)
            Me.cboCOM_VENTA_CAN.Name = "cboCOM_VENTA_CAN"
            Me.cboCOM_VENTA_CAN.Size = New System.Drawing.Size(561, 21)
            Me.cboCOM_VENTA_CAN.TabIndex = 4
            '
            'lblCOM_ESTADO
            '
            Me.lblCOM_ESTADO.AutoSize = True
            Me.lblCOM_ESTADO.Location = New System.Drawing.Point(16, 160)
            Me.lblCOM_ESTADO.Name = "lblCOM_ESTADO"
            Me.lblCOM_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCOM_ESTADO.TabIndex = 102
            Me.lblCOM_ESTADO.Text = "Estado"
            '
            'chkCOM_ESTADO
            '
            Me.chkCOM_ESTADO.AutoSize = True
            Me.chkCOM_ESTADO.Location = New System.Drawing.Point(125, 160)
            Me.chkCOM_ESTADO.Name = "chkCOM_ESTADO"
            Me.chkCOM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCOM_ESTADO.TabIndex = 6
            Me.chkCOM_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCOM_POR_OBJ_MEN
            '
            Me.txtCOM_POR_OBJ_MEN.Location = New System.Drawing.Point(526, 45)
            Me.txtCOM_POR_OBJ_MEN.Name = "txtCOM_POR_OBJ_MEN"
            Me.txtCOM_POR_OBJ_MEN.Size = New System.Drawing.Size(160, 20)
            Me.txtCOM_POR_OBJ_MEN.TabIndex = 3
            Me.txtCOM_POR_OBJ_MEN.Text = "0.00"
            '
            'lblCOM_POR_OBJ_MEN
            '
            Me.lblCOM_POR_OBJ_MEN.AutoSize = True
            Me.lblCOM_POR_OBJ_MEN.Location = New System.Drawing.Point(368, 45)
            Me.lblCOM_POR_OBJ_MEN.Name = "lblCOM_POR_OBJ_MEN"
            Me.lblCOM_POR_OBJ_MEN.Size = New System.Drawing.Size(149, 13)
            Me.lblCOM_POR_OBJ_MEN.TabIndex = 84
            Me.lblCOM_POR_OBJ_MEN.Text = "Comisión por objetivo mensual"
            '
            'lblCOM_POR_CUO_MEN
            '
            Me.lblCOM_POR_CUO_MEN.AutoSize = True
            Me.lblCOM_POR_CUO_MEN.Location = New System.Drawing.Point(16, 45)
            Me.lblCOM_POR_CUO_MEN.Name = "lblCOM_POR_CUO_MEN"
            Me.lblCOM_POR_CUO_MEN.Size = New System.Drawing.Size(139, 13)
            Me.lblCOM_POR_CUO_MEN.TabIndex = 83
            Me.lblCOM_POR_CUO_MEN.Text = "Comisión por cuota mensual"
            '
            'lblCOM_FORMULA
            '
            Me.lblCOM_FORMULA.AutoSize = True
            Me.lblCOM_FORMULA.Location = New System.Drawing.Point(16, 108)
            Me.lblCOM_FORMULA.Name = "lblCOM_FORMULA"
            Me.lblCOM_FORMULA.Size = New System.Drawing.Size(44, 13)
            Me.lblCOM_FORMULA.TabIndex = 80
            Me.lblCOM_FORMULA.Text = "Formula"
            '
            'txtCOM_POR_CUO_MEN
            '
            Me.txtCOM_POR_CUO_MEN.Location = New System.Drawing.Point(158, 45)
            Me.txtCOM_POR_CUO_MEN.Name = "txtCOM_POR_CUO_MEN"
            Me.txtCOM_POR_CUO_MEN.Size = New System.Drawing.Size(155, 20)
            Me.txtCOM_POR_CUO_MEN.TabIndex = 2
            Me.txtCOM_POR_CUO_MEN.Text = "0.00"
            '
            'txtCOM_FORMULA
            '
            Me.txtCOM_FORMULA.Location = New System.Drawing.Point(125, 108)
            Me.txtCOM_FORMULA.Multiline = True
            Me.txtCOM_FORMULA.Name = "txtCOM_FORMULA"
            Me.txtCOM_FORMULA.Size = New System.Drawing.Size(561, 40)
            Me.txtCOM_FORMULA.TabIndex = 5
            Me.txtCOM_FORMULA.Text = "*"
            '
            'lblCOM_ID
            '
            Me.lblCOM_ID.AutoSize = True
            Me.lblCOM_ID.Location = New System.Drawing.Point(16, 12)
            Me.lblCOM_ID.Name = "lblCOM_ID"
            Me.lblCOM_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCOM_ID.TabIndex = 28
            Me.lblCOM_ID.Text = "Código"
            '
            'lblCOM_DESCRIPCION
            '
            Me.lblCOM_DESCRIPCION.AutoSize = True
            Me.lblCOM_DESCRIPCION.Location = New System.Drawing.Point(125, 12)
            Me.lblCOM_DESCRIPCION.Name = "lblCOM_DESCRIPCION"
            Me.lblCOM_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblCOM_DESCRIPCION.TabIndex = 30
            Me.lblCOM_DESCRIPCION.Text = "Descripción"
            '
            'txtCOM_ID
            '
            Me.txtCOM_ID.Location = New System.Drawing.Point(64, 12)
            Me.txtCOM_ID.Name = "txtCOM_ID"
            Me.txtCOM_ID.Size = New System.Drawing.Size(57, 20)
            Me.txtCOM_ID.TabIndex = 0
            '
            'txtCOM_DESCRIPCION
            '
            Me.txtCOM_DESCRIPCION.Location = New System.Drawing.Point(202, 12)
            Me.txtCOM_DESCRIPCION.Name = "txtCOM_DESCRIPCION"
            Me.txtCOM_DESCRIPCION.Size = New System.Drawing.Size(484, 20)
            Me.txtCOM_DESCRIPCION.TabIndex = 1
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(702, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 27)
            Me.btnImagen.TabIndex = 111
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmComision
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(779, 251)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmComision"
            Me.Text = "Comisión"
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
        Friend WithEvents lblCOM_VENTA_CAN As System.Windows.Forms.Label
        Public WithEvents cboCOM_VENTA_CAN As System.Windows.Forms.ComboBox
        Friend WithEvents lblCOM_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkCOM_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCOM_POR_OBJ_MEN As System.Windows.Forms.TextBox
        Friend WithEvents lblCOM_POR_OBJ_MEN As System.Windows.Forms.Label
        Friend WithEvents lblCOM_POR_CUO_MEN As System.Windows.Forms.Label
        Friend WithEvents lblCOM_FORMULA As System.Windows.Forms.Label
        Public WithEvents txtCOM_POR_CUO_MEN As System.Windows.Forms.TextBox
        Public WithEvents txtCOM_FORMULA As System.Windows.Forms.TextBox
        Friend WithEvents lblCOM_ID As System.Windows.Forms.Label
        Friend WithEvents lblCOM_DESCRIPCION As System.Windows.Forms.Label
        Public WithEvents txtCOM_ID As System.Windows.Forms.TextBox
        Public WithEvents txtCOM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace