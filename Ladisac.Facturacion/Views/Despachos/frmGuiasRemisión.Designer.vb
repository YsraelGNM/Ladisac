Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGuiasRemision
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
            Me.chkPropios = New System.Windows.Forms.CheckBox()
            Me.lblTipoReporte = New System.Windows.Forms.Label()
            Me.pnTipoReporte = New System.Windows.Forms.Panel()
            Me.rbGrafico = New System.Windows.Forms.RadioButton()
            Me.rbListado = New System.Windows.Forms.RadioButton()
            Me.txtPER_RUC_TRA = New System.Windows.Forms.TextBox()
            Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
            Me.dgvDatosImprimir = New System.Windows.Forms.DataGridView()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.txtPER_DESCRIPCION_TRA = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_TRA = New System.Windows.Forms.TextBox()
            Me.txtTDO_ID = New System.Windows.Forms.TextBox()
            Me.txtDTD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.lblDTD_ID = New System.Windows.Forms.Label()
            Me.txtDTD_ID = New System.Windows.Forms.TextBox()
            Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.lblFechaInicial = New System.Windows.Forms.Label()
            Me.lblFechaFinal = New System.Windows.Forms.Label()
            Me.lblPER_ID_TRA = New System.Windows.Forms.Label()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            Me.rbGrafico1 = New System.Windows.Forms.RadioButton()
            Me.pnCuerpo.SuspendLayout()
            Me.pnTipoReporte.SuspendLayout()
            CType(Me.dgvDatosImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(680, 28)
            Me.lblTitle.Text = "Guías de remisión"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.chkPropios)
            Me.pnCuerpo.Controls.Add(Me.lblTipoReporte)
            Me.pnCuerpo.Controls.Add(Me.pnTipoReporte)
            Me.pnCuerpo.Controls.Add(Me.txtPER_RUC_TRA)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.dgvDatosImprimir)
            Me.pnCuerpo.Controls.Add(Me.dgvDatos)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_TRA)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_TRA)
            Me.pnCuerpo.Controls.Add(Me.txtTDO_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTD_ID)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Controls.Add(Me.lblFechaInicial)
            Me.pnCuerpo.Controls.Add(Me.lblFechaFinal)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_TRA)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(624, 196)
            Me.pnCuerpo.TabIndex = 119
            '
            'chkPropios
            '
            Me.chkPropios.AutoSize = True
            Me.chkPropios.Location = New System.Drawing.Point(488, 97)
            Me.chkPropios.Name = "chkPropios"
            Me.chkPropios.Size = New System.Drawing.Size(129, 17)
            Me.chkPropios.TabIndex = 38
            Me.chkPropios.Text = "Transportistas propios"
            Me.chkPropios.UseVisualStyleBackColor = True
            '
            'lblTipoReporte
            '
            Me.lblTipoReporte.AutoSize = True
            Me.lblTipoReporte.Location = New System.Drawing.Point(9, 98)
            Me.lblTipoReporte.Name = "lblTipoReporte"
            Me.lblTipoReporte.Size = New System.Drawing.Size(66, 13)
            Me.lblTipoReporte.TabIndex = 37
            Me.lblTipoReporte.Text = "TipoReporte"
            '
            'pnTipoReporte
            '
            Me.pnTipoReporte.Controls.Add(Me.rbGrafico1)
            Me.pnTipoReporte.Controls.Add(Me.rbGrafico)
            Me.pnTipoReporte.Controls.Add(Me.rbListado)
            Me.pnTipoReporte.Location = New System.Drawing.Point(94, 98)
            Me.pnTipoReporte.Name = "pnTipoReporte"
            Me.pnTipoReporte.Size = New System.Drawing.Size(350, 27)
            Me.pnTipoReporte.TabIndex = 36
            '
            'rbGrafico
            '
            Me.rbGrafico.AutoSize = True
            Me.rbGrafico.Location = New System.Drawing.Point(67, 4)
            Me.rbGrafico.Name = "rbGrafico"
            Me.rbGrafico.Size = New System.Drawing.Size(111, 17)
            Me.rbGrafico.TabIndex = 9
            Me.rbGrafico.Text = "Gráfico para fletes"
            Me.rbGrafico.UseVisualStyleBackColor = True
            '
            'rbListado
            '
            Me.rbListado.AutoSize = True
            Me.rbListado.Checked = True
            Me.rbListado.Location = New System.Drawing.Point(4, 4)
            Me.rbListado.Name = "rbListado"
            Me.rbListado.Size = New System.Drawing.Size(59, 17)
            Me.rbListado.TabIndex = 8
            Me.rbListado.TabStop = True
            Me.rbListado.Text = "Listado"
            Me.rbListado.UseVisualStyleBackColor = True
            '
            'txtPER_RUC_TRA
            '
            Me.txtPER_RUC_TRA.Enabled = False
            Me.txtPER_RUC_TRA.Location = New System.Drawing.Point(606, 17)
            Me.txtPER_RUC_TRA.Name = "txtPER_RUC_TRA"
            Me.txtPER_RUC_TRA.ReadOnly = True
            Me.txtPER_RUC_TRA.Size = New System.Drawing.Size(11, 20)
            Me.txtPER_RUC_TRA.TabIndex = 35
            Me.txtPER_RUC_TRA.Visible = False
            '
            'dtpFechaInicial
            '
            Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicial.Location = New System.Drawing.Point(94, 43)
            Me.dtpFechaInicial.Name = "dtpFechaInicial"
            Me.dtpFechaInicial.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicial.TabIndex = 3
            '
            'dgvDatosImprimir
            '
            Me.dgvDatosImprimir.AllowUserToAddRows = False
            Me.dgvDatosImprimir.AllowUserToDeleteRows = False
            Me.dgvDatosImprimir.AllowUserToOrderColumns = True
            Me.dgvDatosImprimir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDatosImprimir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDatosImprimir.Location = New System.Drawing.Point(215, 142)
            Me.dgvDatosImprimir.Name = "dgvDatosImprimir"
            Me.dgvDatosImprimir.Size = New System.Drawing.Size(23, 20)
            Me.dgvDatosImprimir.TabIndex = 34
            Me.dgvDatosImprimir.Visible = False
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.AllowUserToOrderColumns = True
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDatos.Location = New System.Drawing.Point(184, 142)
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.Size = New System.Drawing.Size(25, 20)
            Me.dgvDatos.TabIndex = 33
            Me.dgvDatos.Visible = False
            '
            'txtPER_DESCRIPCION_TRA
            '
            Me.txtPER_DESCRIPCION_TRA.Enabled = False
            Me.txtPER_DESCRIPCION_TRA.Location = New System.Drawing.Point(168, 17)
            Me.txtPER_DESCRIPCION_TRA.Name = "txtPER_DESCRIPCION_TRA"
            Me.txtPER_DESCRIPCION_TRA.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA.Size = New System.Drawing.Size(442, 20)
            Me.txtPER_DESCRIPCION_TRA.TabIndex = 2
            '
            'txtPER_ID_TRA
            '
            Me.txtPER_ID_TRA.Location = New System.Drawing.Point(94, 17)
            Me.txtPER_ID_TRA.Name = "txtPER_ID_TRA"
            Me.txtPER_ID_TRA.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID_TRA.TabIndex = 1
            '
            'txtTDO_ID
            '
            Me.txtTDO_ID.Enabled = False
            Me.txtTDO_ID.Location = New System.Drawing.Point(136, 68)
            Me.txtTDO_ID.Name = "txtTDO_ID"
            Me.txtTDO_ID.Size = New System.Drawing.Size(26, 20)
            Me.txtTDO_ID.TabIndex = 6
            Me.txtTDO_ID.Visible = False
            '
            'txtDTD_DESCRIPCION
            '
            Me.txtDTD_DESCRIPCION.Enabled = False
            Me.txtDTD_DESCRIPCION.Location = New System.Drawing.Point(136, 68)
            Me.txtDTD_DESCRIPCION.Name = "txtDTD_DESCRIPCION"
            Me.txtDTD_DESCRIPCION.ReadOnly = True
            Me.txtDTD_DESCRIPCION.Size = New System.Drawing.Size(481, 20)
            Me.txtDTD_DESCRIPCION.TabIndex = 7
            '
            'lblDTD_ID
            '
            Me.lblDTD_ID.AutoSize = True
            Me.lblDTD_ID.Location = New System.Drawing.Point(9, 72)
            Me.lblDTD_ID.Name = "lblDTD_ID"
            Me.lblDTD_ID.Size = New System.Drawing.Size(84, 13)
            Me.lblDTD_ID.TabIndex = 17
            Me.lblDTD_ID.Text = "Tipo documento"
            '
            'txtDTD_ID
            '
            Me.txtDTD_ID.Location = New System.Drawing.Point(94, 68)
            Me.txtDTD_ID.Name = "txtDTD_ID"
            Me.txtDTD_ID.Size = New System.Drawing.Size(36, 20)
            Me.txtDTD_ID.TabIndex = 5
            '
            'dtpFechaFinal
            '
            Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinal.Location = New System.Drawing.Point(262, 43)
            Me.dtpFechaFinal.Name = "dtpFechaFinal"
            Me.dtpFechaFinal.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinal.TabIndex = 4
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(94, 142)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(84, 35)
            Me.btnImprimir.TabIndex = 10
            Me.btnImprimir.Text = "Generar"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'lblFechaInicial
            '
            Me.lblFechaInicial.AutoSize = True
            Me.lblFechaInicial.Location = New System.Drawing.Point(9, 43)
            Me.lblFechaInicial.Name = "lblFechaInicial"
            Me.lblFechaInicial.Size = New System.Drawing.Size(66, 13)
            Me.lblFechaInicial.TabIndex = 21
            Me.lblFechaInicial.Text = "Fecha inicial"
            '
            'lblFechaFinal
            '
            Me.lblFechaFinal.AutoSize = True
            Me.lblFechaFinal.Location = New System.Drawing.Point(197, 43)
            Me.lblFechaFinal.Name = "lblFechaFinal"
            Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
            Me.lblFechaFinal.TabIndex = 22
            Me.lblFechaFinal.Text = "Fecha final"
            '
            'lblPER_ID_TRA
            '
            Me.lblPER_ID_TRA.AutoSize = True
            Me.lblPER_ID_TRA.Location = New System.Drawing.Point(9, 17)
            Me.lblPER_ID_TRA.Name = "lblPER_ID_TRA"
            Me.lblPER_ID_TRA.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_ID_TRA.TabIndex = 19
            Me.lblPER_ID_TRA.Text = "Transportista"
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
            'rbGrafico1
            '
            Me.rbGrafico1.AutoSize = True
            Me.rbGrafico1.Location = New System.Drawing.Point(181, 4)
            Me.rbGrafico1.Name = "rbGrafico1"
            Me.rbGrafico1.Size = New System.Drawing.Size(138, 17)
            Me.rbGrafico1.TabIndex = 10
            Me.rbGrafico1.Text = "Gráfico para estadística"
            Me.rbGrafico1.UseVisualStyleBackColor = True
            '
            'frmGuiasRemision
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(680, 253)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmGuiasRemision"
            Me.Text = "Guias de remisión"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.pnTipoReporte.ResumeLayout(False)
            Me.pnTipoReporte.PerformLayout()
            CType(Me.dgvDatosImprimir, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblFechaInicial As System.Windows.Forms.Label
        Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_TRA As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_TRA As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents txtPER_DESCRIPCION_TRA As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Public WithEvents txtDTD_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents lblDTD_ID As System.Windows.Forms.Label
        Public WithEvents txtDTD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtTDO_ID As System.Windows.Forms.TextBox
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
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Public WithEvents txtPER_RUC_TRA As System.Windows.Forms.TextBox
        Friend WithEvents dgvDatosImprimir As System.Windows.Forms.DataGridView
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
        Friend WithEvents pnTipoReporte As System.Windows.Forms.Panel
        Friend WithEvents rbGrafico As System.Windows.Forms.RadioButton
        Friend WithEvents rbListado As System.Windows.Forms.RadioButton
        Friend WithEvents lblTipoReporte As System.Windows.Forms.Label
        Friend WithEvents chkPropios As System.Windows.Forms.CheckBox
        Friend WithEvents rbGrafico1 As System.Windows.Forms.RadioButton
    End Class
End Namespace