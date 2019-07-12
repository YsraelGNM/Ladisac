Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRevisarAsiento
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.lblPeriodo = New System.Windows.Forms.Label()
            Me.lblReporte = New System.Windows.Forms.Label()
            Me.grbReporte = New System.Windows.Forms.GroupBox()
            Me.rbAmbos = New System.Windows.Forms.RadioButton()
            Me.rbLeft = New System.Windows.Forms.RadioButton()
            Me.rbRight = New System.Windows.Forms.RadioButton()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtCUC_ID = New System.Windows.Forms.TextBox()
            Me.lblcuc_id = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rbLeft1 = New System.Windows.Forms.RadioButton()
            Me.rbRight1 = New System.Windows.Forms.RadioButton()
            Me.btnImprimir1 = New System.Windows.Forms.Button()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbReporte.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(603, 28)
            Me.lblTitle.Text = "Revisar asientos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.btnImprimir1)
            Me.pnCuerpo.Controls.Add(Me.GroupBox1)
            Me.pnCuerpo.Controls.Add(Me.txtCUC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblcuc_id)
            Me.pnCuerpo.Controls.Add(Me.txtPeriodo)
            Me.pnCuerpo.Controls.Add(Me.dgvDatos)
            Me.pnCuerpo.Controls.Add(Me.lblPeriodo)
            Me.pnCuerpo.Controls.Add(Me.lblReporte)
            Me.pnCuerpo.Controls.Add(Me.grbReporte)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(547, 177)
            Me.pnCuerpo.TabIndex = 119
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(87, 13)
            Me.txtPeriodo.MaxLength = 6
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.Size = New System.Drawing.Size(100, 20)
            Me.txtPeriodo.TabIndex = 1
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDatos.ColumnHeadersHeight = 15
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDatos.Enabled = False
            Me.dgvDatos.Location = New System.Drawing.Point(211, 12)
            Me.dgvDatos.MultiSelect = False
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.ReadOnly = True
            Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDatos.Size = New System.Drawing.Size(130, 0)
            Me.dgvDatos.TabIndex = 36
            Me.dgvDatos.Visible = False
            '
            'lblPeriodo
            '
            Me.lblPeriodo.AutoSize = True
            Me.lblPeriodo.Location = New System.Drawing.Point(14, 13)
            Me.lblPeriodo.Name = "lblPeriodo"
            Me.lblPeriodo.Size = New System.Drawing.Size(49, 13)
            Me.lblPeriodo.TabIndex = 37
            Me.lblPeriodo.Text = "Periodo :"
            '
            'lblReporte
            '
            Me.lblReporte.AutoSize = True
            Me.lblReporte.Location = New System.Drawing.Point(14, 39)
            Me.lblReporte.Name = "lblReporte"
            Me.lblReporte.Size = New System.Drawing.Size(45, 13)
            Me.lblReporte.TabIndex = 37
            Me.lblReporte.Text = "Formato"
            '
            'grbReporte
            '
            Me.grbReporte.Controls.Add(Me.rbAmbos)
            Me.grbReporte.Controls.Add(Me.rbLeft)
            Me.grbReporte.Controls.Add(Me.rbRight)
            Me.grbReporte.Location = New System.Drawing.Point(87, 39)
            Me.grbReporte.Name = "grbReporte"
            Me.grbReporte.Size = New System.Drawing.Size(210, 87)
            Me.grbReporte.TabIndex = 3
            Me.grbReporte.TabStop = False
            '
            'rbAmbos
            '
            Me.rbAmbos.AutoSize = True
            Me.rbAmbos.Location = New System.Drawing.Point(10, 58)
            Me.rbAmbos.Name = "rbAmbos"
            Me.rbAmbos.Size = New System.Drawing.Size(116, 17)
            Me.rbAmbos.TabIndex = 37
            Me.rbAmbos.Text = "Asientos enlazados"
            Me.rbAmbos.UseVisualStyleBackColor = True
            '
            'rbLeft
            '
            Me.rbLeft.AutoSize = True
            Me.rbLeft.Checked = True
            Me.rbLeft.Location = New System.Drawing.Point(10, 16)
            Me.rbLeft.Name = "rbLeft"
            Me.rbLeft.Size = New System.Drawing.Size(189, 17)
            Me.rbLeft.TabIndex = 35
            Me.rbLeft.TabStop = True
            Me.rbLeft.Text = "Asientos que debio generar ventas"
            Me.rbLeft.UseVisualStyleBackColor = True
            '
            'rbRight
            '
            Me.rbRight.AutoSize = True
            Me.rbRight.Location = New System.Drawing.Point(10, 38)
            Me.rbRight.Name = "rbRight"
            Me.rbRight.Size = New System.Drawing.Size(193, 17)
            Me.rbRight.TabIndex = 36
            Me.rbRight.Text = "Asientos generados en contabilidad"
            Me.rbRight.UseVisualStyleBackColor = True
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(87, 138)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(143, 23)
            Me.btnImprimir.TabIndex = 4
            Me.btnImprimir.Text = "Generar ventas"
            Me.btnImprimir.UseVisualStyleBackColor = True
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
            Me.btnImagen.Location = New System.Drawing.Point(522, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 13
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtCUC_ID
            '
            Me.txtCUC_ID.Location = New System.Drawing.Point(411, 13)
            Me.txtCUC_ID.MaxLength = 6
            Me.txtCUC_ID.Name = "txtCUC_ID"
            Me.txtCUC_ID.Size = New System.Drawing.Size(127, 20)
            Me.txtCUC_ID.TabIndex = 2
            '
            'lblcuc_id
            '
            Me.lblcuc_id.AutoSize = True
            Me.lblcuc_id.Location = New System.Drawing.Point(328, 13)
            Me.lblcuc_id.Name = "lblcuc_id"
            Me.lblcuc_id.Size = New System.Drawing.Size(77, 13)
            Me.lblcuc_id.TabIndex = 39
            Me.lblcuc_id.Text = "Cta. Contable :"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rbLeft1)
            Me.GroupBox1.Controls.Add(Me.rbRight1)
            Me.GroupBox1.Location = New System.Drawing.Point(328, 39)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(210, 87)
            Me.GroupBox1.TabIndex = 5
            Me.GroupBox1.TabStop = False
            '
            'rbLeft1
            '
            Me.rbLeft1.AutoSize = True
            Me.rbLeft1.Checked = True
            Me.rbLeft1.Location = New System.Drawing.Point(10, 16)
            Me.rbLeft1.Name = "rbLeft1"
            Me.rbLeft1.Size = New System.Drawing.Size(109, 17)
            Me.rbLeft1.TabIndex = 35
            Me.rbLeft1.TabStop = True
            Me.rbLeft1.Text = "Lado contabilidad"
            Me.rbLeft1.UseVisualStyleBackColor = True
            '
            'rbRight1
            '
            Me.rbRight1.AutoSize = True
            Me.rbRight1.Location = New System.Drawing.Point(10, 38)
            Me.rbRight1.Name = "rbRight1"
            Me.rbRight1.Size = New System.Drawing.Size(93, 17)
            Me.rbRight1.TabIndex = 36
            Me.rbRight1.Text = "Lado Cta. Cte."
            Me.rbRight1.UseVisualStyleBackColor = True
            '
            'btnImprimir1
            '
            Me.btnImprimir1.Location = New System.Drawing.Point(328, 138)
            Me.btnImprimir1.Name = "btnImprimir1"
            Me.btnImprimir1.Size = New System.Drawing.Size(143, 23)
            Me.btnImprimir1.TabIndex = 6
            Me.btnImprimir1.Text = "Generar contabilidad"
            Me.btnImprimir1.UseVisualStyleBackColor = True
            '
            'frmRevisarAsiento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(603, 236)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmRevisarAsiento"
            Me.Text = "Revisar asientos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbReporte.ResumeLayout(False)
            Me.grbReporte.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents lblReporte As System.Windows.Forms.Label
        Friend WithEvents grbReporte As System.Windows.Forms.GroupBox
        Friend WithEvents rbLeft As System.Windows.Forms.RadioButton
        Friend WithEvents rbRight As System.Windows.Forms.RadioButton
        Friend WithEvents lblPeriodo As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
        Friend WithEvents rbAmbos As System.Windows.Forms.RadioButton
        Friend WithEvents btnImprimir1 As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbLeft1 As System.Windows.Forms.RadioButton
        Friend WithEvents rbRight1 As System.Windows.Forms.RadioButton
        Friend WithEvents txtCUC_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblcuc_id As System.Windows.Forms.Label
    End Class
End Namespace