Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteCronogramaDespacho
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
            Me.Label5 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbGuias = New System.Windows.Forms.RadioButton()
            Me.rdbPorArticulo = New System.Windows.Forms.RadioButton()
            Me.rdbGeneral = New System.Windows.Forms.RadioButton()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.cboEstado = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblPER_ID_VEN = New System.Windows.Forms.Label()
            Me.txtPER_ID_VEN = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_VEN = New System.Windows.Forms.TextBox()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            Me.pnCuerpo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(686, 28)
            Me.lblTitle.Text = "Reporte cronograma despacho"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.Label5)
            Me.pnCuerpo.Controls.Add(Me.GroupBox1)
            Me.pnCuerpo.Controls.Add(Me.btnGenerar)
            Me.pnCuerpo.Controls.Add(Me.cboEstado)
            Me.pnCuerpo.Controls.Add(Me.Label4)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_VEN)
            Me.pnCuerpo.Controls.Add(Me.dateHasta)
            Me.pnCuerpo.Controls.Add(Me.dateDesde)
            Me.pnCuerpo.Controls.Add(Me.Label2)
            Me.pnCuerpo.Controls.Add(Me.Label1)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(630, 191)
            Me.pnCuerpo.TabIndex = 119
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(18, 113)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(67, 13)
            Me.Label5.TabIndex = 118
            Me.Label5.Text = "Tipo reporte:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rdbGuias)
            Me.GroupBox1.Controls.Add(Me.rdbPorArticulo)
            Me.GroupBox1.Controls.Add(Me.rdbGeneral)
            Me.GroupBox1.Location = New System.Drawing.Point(84, 97)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(334, 39)
            Me.GroupBox1.TabIndex = 117
            Me.GroupBox1.TabStop = False
            '
            'rdbGuias
            '
            Me.rdbGuias.AutoSize = True
            Me.rdbGuias.Location = New System.Drawing.Point(185, 14)
            Me.rdbGuias.Name = "rdbGuias"
            Me.rdbGuias.Size = New System.Drawing.Size(139, 17)
            Me.rdbGuias.TabIndex = 8
            Me.rdbGuias.TabStop = True
            Me.rdbGuias.Text = "Guías por programación"
            Me.rdbGuias.UseVisualStyleBackColor = True
            '
            'rdbPorArticulo
            '
            Me.rdbPorArticulo.AutoSize = True
            Me.rdbPorArticulo.Location = New System.Drawing.Point(86, 14)
            Me.rdbPorArticulo.Name = "rdbPorArticulo"
            Me.rdbPorArticulo.Size = New System.Drawing.Size(78, 17)
            Me.rdbPorArticulo.TabIndex = 7
            Me.rdbPorArticulo.TabStop = True
            Me.rdbPorArticulo.Text = "Por articulo"
            Me.rdbPorArticulo.UseVisualStyleBackColor = True
            '
            'rdbGeneral
            '
            Me.rdbGeneral.AutoSize = True
            Me.rdbGeneral.Checked = True
            Me.rdbGeneral.Location = New System.Drawing.Point(7, 14)
            Me.rdbGeneral.Name = "rdbGeneral"
            Me.rdbGeneral.Size = New System.Drawing.Size(62, 17)
            Me.rdbGeneral.TabIndex = 6
            Me.rdbGeneral.TabStop = True
            Me.rdbGeneral.Text = "General"
            Me.rdbGeneral.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(84, 142)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(76, 41)
            Me.btnGenerar.TabIndex = 114
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'cboEstado
            '
            Me.cboEstado.FormattingEnabled = True
            Me.cboEstado.Items.AddRange(New Object() {"Se genero guía / Se anulo programación 0", "Activas 1", "Programado por vendedor 2", "Habilitado para generar guía 3"})
            Me.cboEstado.Location = New System.Drawing.Point(84, 72)
            Me.cboEstado.Name = "cboEstado"
            Me.cboEstado.Size = New System.Drawing.Size(334, 21)
            Me.cboEstado.TabIndex = 113
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(18, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(43, 13)
            Me.Label4.TabIndex = 116
            Me.Label4.Text = "Estado:"
            '
            'lblPER_ID_VEN
            '
            Me.lblPER_ID_VEN.AutoSize = True
            Me.lblPER_ID_VEN.Location = New System.Drawing.Point(18, 42)
            Me.lblPER_ID_VEN.Name = "lblPER_ID_VEN"
            Me.lblPER_ID_VEN.Size = New System.Drawing.Size(56, 13)
            Me.lblPER_ID_VEN.TabIndex = 115
            Me.lblPER_ID_VEN.Text = "Vendedor:"
            '
            'txtPER_ID_VEN
            '
            Me.txtPER_ID_VEN.Location = New System.Drawing.Point(84, 42)
            Me.txtPER_ID_VEN.Name = "txtPER_ID_VEN"
            Me.txtPER_ID_VEN.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID_VEN.TabIndex = 111
            '
            'txtPER_DESCRIPCION_VEN
            '
            Me.txtPER_DESCRIPCION_VEN.Enabled = False
            Me.txtPER_DESCRIPCION_VEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_VEN.Location = New System.Drawing.Point(154, 42)
            Me.txtPER_DESCRIPCION_VEN.Name = "txtPER_DESCRIPCION_VEN"
            Me.txtPER_DESCRIPCION_VEN.ReadOnly = True
            Me.txtPER_DESCRIPCION_VEN.Size = New System.Drawing.Size(448, 20)
            Me.txtPER_DESCRIPCION_VEN.TabIndex = 112
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateHasta.Location = New System.Drawing.Point(243, 13)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(92, 20)
            Me.dateHasta.TabIndex = 110
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateDesde.Location = New System.Drawing.Point(85, 13)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(92, 20)
            Me.dateDesde.TabIndex = 108
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(202, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 109
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(18, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 13)
            Me.Label1.TabIndex = 107
            Me.Label1.Text = "Desde:"
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
            Me.btnImagen.Location = New System.Drawing.Point(613, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 23
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'BackgroundWorker1
            '
            Me.BackgroundWorker1.WorkerReportsProgress = True
            '
            'frmReporteCronogramaDespacho
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(686, 250)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmReporteCronogramaDespacho"
            Me.Text = "Reporte cronograma despacho"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbGuias As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPorArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_VEN As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_VEN As System.Windows.Forms.TextBox
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace