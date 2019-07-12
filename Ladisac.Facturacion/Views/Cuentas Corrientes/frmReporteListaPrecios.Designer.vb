Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteListaPrecios
        'Inherits System.Windows.Forms.Form
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
            Me.chkFiltrarXEstado = New System.Windows.Forms.CheckBox()
            Me.lblTIP_ID = New System.Windows.Forms.Label()
            Me.txtTIP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTIP_ID = New System.Windows.Forms.TextBox()
            Me.txtMON_SIMBOLO = New System.Windows.Forms.TextBox()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.txtLPR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtLPR_ID = New System.Windows.Forms.TextBox()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(681, 28)
            Me.lblTitle.Text = "Reporte lista de precios"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.chkFiltrarXEstado)
            Me.pnCuerpo.Controls.Add(Me.lblTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTIP_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_SIMBOLO)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(625, 221)
            Me.pnCuerpo.TabIndex = 119
            '
            'chkFiltrarXEstado
            '
            Me.chkFiltrarXEstado.AutoSize = True
            Me.chkFiltrarXEstado.Checked = True
            Me.chkFiltrarXEstado.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkFiltrarXEstado.Location = New System.Drawing.Point(91, 147)
            Me.chkFiltrarXEstado.Name = "chkFiltrarXEstado"
            Me.chkFiltrarXEstado.Size = New System.Drawing.Size(144, 17)
            Me.chkFiltrarXEstado.TabIndex = 12
            Me.chkFiltrarXEstado.Text = "Sólo los artículos activos"
            Me.chkFiltrarXEstado.UseVisualStyleBackColor = True
            '
            'lblTIP_ID
            '
            Me.lblTIP_ID.AutoSize = True
            Me.lblTIP_ID.Location = New System.Drawing.Point(7, 116)
            Me.lblTIP_ID.Name = "lblTIP_ID"
            Me.lblTIP_ID.Size = New System.Drawing.Size(67, 13)
            Me.lblTIP_ID.TabIndex = 18
            Me.lblTIP_ID.Text = "Tipo artículo"
            '
            'txtTIP_DESCRIPCION
            '
            Me.txtTIP_DESCRIPCION.Enabled = False
            Me.txtTIP_DESCRIPCION.Location = New System.Drawing.Point(136, 116)
            Me.txtTIP_DESCRIPCION.Name = "txtTIP_DESCRIPCION"
            Me.txtTIP_DESCRIPCION.ReadOnly = True
            Me.txtTIP_DESCRIPCION.Size = New System.Drawing.Size(470, 20)
            Me.txtTIP_DESCRIPCION.TabIndex = 11
            '
            'txtTIP_ID
            '
            Me.txtTIP_ID.Location = New System.Drawing.Point(91, 116)
            Me.txtTIP_ID.Name = "txtTIP_ID"
            Me.txtTIP_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtTIP_ID.TabIndex = 10
            '
            'txtMON_SIMBOLO
            '
            Me.txtMON_SIMBOLO.Enabled = False
            Me.txtMON_SIMBOLO.Location = New System.Drawing.Point(136, 64)
            Me.txtMON_SIMBOLO.Name = "txtMON_SIMBOLO"
            Me.txtMON_SIMBOLO.ReadOnly = True
            Me.txtMON_SIMBOLO.Size = New System.Drawing.Size(33, 20)
            Me.txtMON_SIMBOLO.TabIndex = 6
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(7, 64)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 16
            Me.lblMON_ID.Text = "Moneda"
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(172, 64)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(434, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 7
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Location = New System.Drawing.Point(91, 64)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtMON_ID.TabIndex = 5
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(7, 12)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(81, 13)
            Me.lblLPR_ID.TabIndex = 14
            Me.lblLPR_ID.Text = "Lista de precios"
            '
            'txtLPR_DESCRIPCION
            '
            Me.txtLPR_DESCRIPCION.Enabled = False
            Me.txtLPR_DESCRIPCION.Location = New System.Drawing.Point(136, 12)
            Me.txtLPR_DESCRIPCION.Name = "txtLPR_DESCRIPCION"
            Me.txtLPR_DESCRIPCION.ReadOnly = True
            Me.txtLPR_DESCRIPCION.Size = New System.Drawing.Size(470, 20)
            Me.txtLPR_DESCRIPCION.TabIndex = 2
            '
            'txtLPR_ID
            '
            Me.txtLPR_ID.Location = New System.Drawing.Point(91, 12)
            Me.txtLPR_ID.Name = "txtLPR_ID"
            Me.txtLPR_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtLPR_ID.TabIndex = 1
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(91, 175)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
            Me.btnImprimir.TabIndex = 13
            Me.btnImprimir.Text = "Generar"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(172, 90)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(434, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 9
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(7, 38)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(80, 13)
            Me.lblPVE_ID.TabIndex = 15
            Me.lblPVE_ID.Text = "Punto de venta"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(7, 90)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID.TabIndex = 17
            Me.lblPER_ID.Text = "Persona"
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(136, 38)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(470, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 4
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(91, 38)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtPVE_ID.TabIndex = 3
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(91, 90)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(78, 20)
            Me.txtPER_ID.TabIndex = 8
            '
            'tsbAgregar
            '
            Me.tsbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAgregar.Image = Global.My.Resources.Resources.Agregar
            Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAgregar.Name = "tsbAgregar"
            Me.tsbAgregar.Size = New System.Drawing.Size(23, 22)
            Me.tsbAgregar.Text = "AgregarFilaGrid"
            Me.tsbAgregar.ToolTipText = "Agregar fila a la grilla"
            '
            'tsbQuitar
            '
            Me.tsbQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbQuitar.Image = Global.My.Resources.Resources.Quitar
            Me.tsbQuitar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbQuitar.Name = "tsbQuitar"
            Me.tsbQuitar.Size = New System.Drawing.Size(23, 22)
            Me.tsbQuitar.Text = "QuitarFilaGrid"
            Me.tsbQuitar.ToolTipText = "Quitar fila de la grilla"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'tsbSalir
            '
            Me.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalir.Image = Global.My.Resources.Resources.Salir
            Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalir.Name = "tsbSalir"
            Me.tsbSalir.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalir.Text = "Salir"
            Me.tsbSalir.ToolTipText = "Salir del formulario"
            '
            'ToolStripSeparator7
            '
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
            '
            'tscPosicion
            '
            Me.tscPosicion.AutoSize = False
            Me.tscPosicion.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.tscPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.tscPosicion.DropDownWidth = 60
            Me.tscPosicion.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tscPosicion.ForeColor = System.Drawing.SystemColors.WindowText
            Me.tscPosicion.Items.AddRange(New Object() {"^", "V", ">", "<"})
            Me.tscPosicion.Name = "tscPosicion"
            Me.tscPosicion.Size = New System.Drawing.Size(30, 18)
            Me.tscPosicion.ToolTipText = "Posición de la barra en la pantalla"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(605, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 14
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmReporteListaPrecios
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(681, 280)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmReporteListaPrecios"
            Me.Text = "Reporte lista de precios"
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
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents lblLPR_ID As System.Windows.Forms.Label
        Public WithEvents txtLPR_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtLPR_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_SIMBOLO As System.Windows.Forms.TextBox
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblTIP_ID As System.Windows.Forms.Label
        Public WithEvents txtTIP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTIP_ID As System.Windows.Forms.TextBox
        Friend WithEvents chkFiltrarXEstado As System.Windows.Forms.CheckBox
    End Class
End Namespace