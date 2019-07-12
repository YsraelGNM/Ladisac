Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportePeriodo
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
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.lblPeriodo = New System.Windows.Forms.Label()
            Me.dgvPeriodos = New System.Windows.Forms.DataGridView()
            Me.cPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cSeleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(554, 28)
            Me.lblTitle.Text = "Retenciones"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPeriodo)
            Me.pnCuerpo.Controls.Add(Me.dgvPeriodos)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(498, 251)
            Me.pnCuerpo.TabIndex = 119
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(148, 13)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(330, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 2
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(19, 16)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(49, 13)
            Me.lblPER_ID.TabIndex = 25
            Me.lblPER_ID.Text = "Persona:"
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(74, 13)
            Me.txtPER_ID.MaxLength = 6
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID.TabIndex = 2
            '
            'lblPeriodo
            '
            Me.lblPeriodo.AutoSize = True
            Me.lblPeriodo.Location = New System.Drawing.Point(18, 45)
            Me.lblPeriodo.Name = "lblPeriodo"
            Me.lblPeriodo.Size = New System.Drawing.Size(51, 13)
            Me.lblPeriodo.TabIndex = 20
            Me.lblPeriodo.Text = "Periodos:"
            '
            'dgvPeriodos
            '
            Me.dgvPeriodos.AllowUserToAddRows = False
            Me.dgvPeriodos.AllowUserToDeleteRows = False
            Me.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPeriodos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cPeriodo, Me.cSeleccion})
            Me.dgvPeriodos.Location = New System.Drawing.Point(20, 61)
            Me.dgvPeriodos.Name = "dgvPeriodos"
            Me.dgvPeriodos.Size = New System.Drawing.Size(458, 135)
            Me.dgvPeriodos.TabIndex = 3
            '
            'cPeriodo
            '
            Me.cPeriodo.HeaderText = "Periodo"
            Me.cPeriodo.Name = "cPeriodo"
            Me.cPeriodo.ReadOnly = True
            '
            'cSeleccion
            '
            Me.cSeleccion.HeaderText = "Selección"
            Me.cSeleccion.Name = "cSeleccion"
            Me.cSeleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cSeleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(20, 202)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(108, 33)
            Me.btnImprimir.TabIndex = 4
            Me.btnImprimir.Text = "Generar Reporte"
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
            Me.btnImagen.Location = New System.Drawing.Point(397, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 120
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmReportePeriodo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(554, 310)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmReportePeriodo"
            Me.Text = "Retenciones"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents dgvPeriodos As System.Windows.Forms.DataGridView
        Friend WithEvents cPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cSeleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents lblPeriodo As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
    End Class
End Namespace