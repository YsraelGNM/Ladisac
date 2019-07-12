Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCorrelativoTipoDocumento
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
            Me.lblPVE_DIRECCION = New System.Windows.Forms.Label()
            Me.txtPVE_DIRECCION = New System.Windows.Forms.TextBox()
            Me.lblCTD_ESTADO = New System.Windows.Forms.Label()
            Me.lblCTD_USAR_COR = New System.Windows.Forms.Label()
            Me.lblCTD_COR_SERIE = New System.Windows.Forms.Label()
            Me.lblCTD_COR_NUMERO = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblTDO_ID = New System.Windows.Forms.Label()
            Me.chkCTD_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkCTD_USAR_COR = New System.Windows.Forms.CheckBox()
            Me.txtCTD_COR_SERIE = New System.Windows.Forms.TextBox()
            Me.txtCTD_COR_NUMERO = New System.Windows.Forms.TextBox()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkTDO_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTDO_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(712, 28)
            Me.lblTitle.Text = "Correlativo tipo documento"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(628, -2)
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
            Me.pnCuerpo.Controls.Add(Me.lblPVE_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DIRECCION)
            Me.pnCuerpo.Controls.Add(Me.lblCTD_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCTD_USAR_COR)
            Me.pnCuerpo.Controls.Add(Me.lblCTD_COR_SERIE)
            Me.pnCuerpo.Controls.Add(Me.lblCTD_COR_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.chkCTD_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkCTD_USAR_COR)
            Me.pnCuerpo.Controls.Add(Me.txtCTD_COR_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtCTD_COR_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkTDO_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(31, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(642, 160)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblPVE_DIRECCION
            '
            Me.lblPVE_DIRECCION.AutoSize = True
            Me.lblPVE_DIRECCION.Location = New System.Drawing.Point(6, 100)
            Me.lblPVE_DIRECCION.Name = "lblPVE_DIRECCION"
            Me.lblPVE_DIRECCION.Size = New System.Drawing.Size(52, 13)
            Me.lblPVE_DIRECCION.TabIndex = 38
            Me.lblPVE_DIRECCION.Text = "Dirección"
            '
            'txtPVE_DIRECCION
            '
            Me.txtPVE_DIRECCION.Enabled = False
            Me.txtPVE_DIRECCION.Location = New System.Drawing.Point(77, 100)
            Me.txtPVE_DIRECCION.Name = "txtPVE_DIRECCION"
            Me.txtPVE_DIRECCION.ReadOnly = True
            Me.txtPVE_DIRECCION.Size = New System.Drawing.Size(464, 20)
            Me.txtPVE_DIRECCION.TabIndex = 10
            '
            'lblCTD_ESTADO
            '
            Me.lblCTD_ESTADO.AutoSize = True
            Me.lblCTD_ESTADO.Location = New System.Drawing.Point(6, 130)
            Me.lblCTD_ESTADO.Name = "lblCTD_ESTADO"
            Me.lblCTD_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCTD_ESTADO.TabIndex = 36
            Me.lblCTD_ESTADO.Text = "Estado"
            '
            'lblCTD_USAR_COR
            '
            Me.lblCTD_USAR_COR.AutoSize = True
            Me.lblCTD_USAR_COR.Location = New System.Drawing.Point(484, 45)
            Me.lblCTD_USAR_COR.Name = "lblCTD_USAR_COR"
            Me.lblCTD_USAR_COR.Size = New System.Drawing.Size(57, 13)
            Me.lblCTD_USAR_COR.TabIndex = 29
            Me.lblCTD_USAR_COR.Text = "Correlativo"
            '
            'lblCTD_COR_SERIE
            '
            Me.lblCTD_COR_SERIE.AutoSize = True
            Me.lblCTD_COR_SERIE.Location = New System.Drawing.Point(6, 45)
            Me.lblCTD_COR_SERIE.Name = "lblCTD_COR_SERIE"
            Me.lblCTD_COR_SERIE.Size = New System.Drawing.Size(31, 13)
            Me.lblCTD_COR_SERIE.TabIndex = 28
            Me.lblCTD_COR_SERIE.Text = "Serie"
            '
            'lblCTD_COR_NUMERO
            '
            Me.lblCTD_COR_NUMERO.AutoSize = True
            Me.lblCTD_COR_NUMERO.Location = New System.Drawing.Point(236, 45)
            Me.lblCTD_COR_NUMERO.Name = "lblCTD_COR_NUMERO"
            Me.lblCTD_COR_NUMERO.Size = New System.Drawing.Size(44, 13)
            Me.lblCTD_COR_NUMERO.TabIndex = 27
            Me.lblCTD_COR_NUMERO.Text = "Número"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(6, 72)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(65, 13)
            Me.lblPVE_ID.TabIndex = 26
            Me.lblPVE_ID.Text = "Punto venta"
            '
            'lblTDO_ID
            '
            Me.lblTDO_ID.AutoSize = True
            Me.lblTDO_ID.Location = New System.Drawing.Point(6, 14)
            Me.lblTDO_ID.Name = "lblTDO_ID"
            Me.lblTDO_ID.Size = New System.Drawing.Size(54, 13)
            Me.lblTDO_ID.TabIndex = 25
            Me.lblTDO_ID.Text = "Tipo Doc."
            '
            'chkCTD_ESTADO
            '
            Me.chkCTD_ESTADO.AutoSize = True
            Me.chkCTD_ESTADO.Location = New System.Drawing.Point(76, 130)
            Me.chkCTD_ESTADO.Name = "chkCTD_ESTADO"
            Me.chkCTD_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCTD_ESTADO.TabIndex = 11
            Me.chkCTD_ESTADO.UseVisualStyleBackColor = True
            '
            'chkCTD_USAR_COR
            '
            Me.chkCTD_USAR_COR.AutoSize = True
            Me.chkCTD_USAR_COR.Location = New System.Drawing.Point(547, 45)
            Me.chkCTD_USAR_COR.Name = "chkCTD_USAR_COR"
            Me.chkCTD_USAR_COR.Size = New System.Drawing.Size(15, 14)
            Me.chkCTD_USAR_COR.TabIndex = 6
            Me.chkCTD_USAR_COR.UseVisualStyleBackColor = True
            '
            'txtCTD_COR_SERIE
            '
            Me.txtCTD_COR_SERIE.Location = New System.Drawing.Point(76, 45)
            Me.txtCTD_COR_SERIE.Name = "txtCTD_COR_SERIE"
            Me.txtCTD_COR_SERIE.Size = New System.Drawing.Size(68, 20)
            Me.txtCTD_COR_SERIE.TabIndex = 4
            '
            'txtCTD_COR_NUMERO
            '
            Me.txtCTD_COR_NUMERO.Location = New System.Drawing.Point(288, 45)
            Me.txtCTD_COR_NUMERO.Name = "txtCTD_COR_NUMERO"
            Me.txtCTD_COR_NUMERO.Size = New System.Drawing.Size(100, 20)
            Me.txtCTD_COR_NUMERO.TabIndex = 5
            Me.txtCTD_COR_NUMERO.Text = "0"
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(547, 72)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 9
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'chkTDO_ESTADO
            '
            Me.chkTDO_ESTADO.AutoSize = True
            Me.chkTDO_ESTADO.Enabled = False
            Me.chkTDO_ESTADO.Location = New System.Drawing.Point(547, 14)
            Me.chkTDO_ESTADO.Name = "chkTDO_ESTADO"
            Me.chkTDO_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTDO_ESTADO.TabIndex = 3
            Me.chkTDO_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(116, 72)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 8
            '
            'txtTDO_DESCRIPCION
            '
            Me.txtTDO_DESCRIPCION.Enabled = False
            Me.txtTDO_DESCRIPCION.Location = New System.Drawing.Point(116, 14)
            Me.txtTDO_DESCRIPCION.Name = "txtTDO_DESCRIPCION"
            Me.txtTDO_DESCRIPCION.ReadOnly = True
            Me.txtTDO_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtTDO_DESCRIPCION.TabIndex = 2
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(76, 72)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtPVE_ID.TabIndex = 7
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Location = New System.Drawing.Point(76, 14)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTDO_ID.TabIndex = 1
            '
            'frmCorrelativoTipoDocumento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(712, 215)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmCorrelativoTipoDocumento"
            Me.Text = "Correlativo tipo documento"
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
        Friend WithEvents lblCTD_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCTD_USAR_COR As System.Windows.Forms.Label
        Friend WithEvents lblCTD_COR_SERIE As System.Windows.Forms.Label
        Friend WithEvents lblCTD_COR_NUMERO As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblTDO_ID As System.Windows.Forms.Label
        Public WithEvents chkCTD_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkCTD_USAR_COR As System.Windows.Forms.CheckBox
        Public WithEvents txtCTD_COR_SERIE As System.Windows.Forms.TextBox
        Public WithEvents txtCTD_COR_NUMERO As System.Windows.Forms.TextBox
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkTDO_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPVE_DIRECCION As System.Windows.Forms.Label
        Public WithEvents txtPVE_DIRECCION As System.Windows.Forms.TextBox
    End Class
End Namespace