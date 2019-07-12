Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAnalisis
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
            Me.dtpMesFin1 = New System.Windows.Forms.DateTimePicker()
            Me.dtpMesInicio1 = New System.Windows.Forms.DateTimePicker()
            Me.dtpMesFin = New System.Windows.Forms.DateTimePicker()
            Me.dtpMesInicio = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaFinMes1 = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaInicioMes1 = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaFinMes = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaInicioMes = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaFinAño = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaInicioAño = New System.Windows.Forms.DateTimePicker()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.lblFecha = New System.Windows.Forms.Label()
            Me.lblReporte = New System.Windows.Forms.Label()
            Me.grbReporte = New System.Windows.Forms.GroupBox()
            Me.rbReporteVendedorOtros = New System.Windows.Forms.RadioButton()
            Me.rbReporteAgenciaSucursales = New System.Windows.Forms.RadioButton()
            Me.rbReportePlanta = New System.Windows.Forms.RadioButton()
            Me.rbReporteVentasArticulo = New System.Windows.Forms.RadioButton()
            Me.rbReporteTipoCliente = New System.Windows.Forms.RadioButton()
            Me.rbReporteVendedorCampo = New System.Windows.Forms.RadioButton()
            Me.rbReporteSucursal = New System.Windows.Forms.RadioButton()
            Me.rbReporteVentasCompartivo = New System.Windows.Forms.RadioButton()
            Me.rbReporteAgencia = New System.Windows.Forms.RadioButton()
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
            Me.grbReporte.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(596, 28)
            Me.lblTitle.Text = "Análisis"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.dtpMesFin1)
            Me.pnCuerpo.Controls.Add(Me.dtpMesInicio1)
            Me.pnCuerpo.Controls.Add(Me.dtpMesFin)
            Me.pnCuerpo.Controls.Add(Me.dtpMesInicio)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinMes1)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicioMes1)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinMes)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicioMes)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaFinAño)
            Me.pnCuerpo.Controls.Add(Me.dtpFechaInicioAño)
            Me.pnCuerpo.Controls.Add(Me.dtpFecha)
            Me.pnCuerpo.Controls.Add(Me.lblFecha)
            Me.pnCuerpo.Controls.Add(Me.lblReporte)
            Me.pnCuerpo.Controls.Add(Me.grbReporte)
            Me.pnCuerpo.Controls.Add(Me.btnImprimir)
            Me.pnCuerpo.Location = New System.Drawing.Point(27, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(540, 276)
            Me.pnCuerpo.TabIndex = 119
            '
            'dtpMesFin1
            '
            Me.dtpMesFin1.Enabled = False
            Me.dtpMesFin1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpMesFin1.Location = New System.Drawing.Point(413, 145)
            Me.dtpMesFin1.Name = "dtpMesFin1"
            Me.dtpMesFin1.Size = New System.Drawing.Size(84, 20)
            Me.dtpMesFin1.TabIndex = 47
            Me.dtpMesFin1.Visible = False
            '
            'dtpMesInicio1
            '
            Me.dtpMesInicio1.Enabled = False
            Me.dtpMesInicio1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpMesInicio1.Location = New System.Drawing.Point(319, 145)
            Me.dtpMesInicio1.Name = "dtpMesInicio1"
            Me.dtpMesInicio1.Size = New System.Drawing.Size(84, 20)
            Me.dtpMesInicio1.TabIndex = 46
            Me.dtpMesInicio1.Visible = False
            '
            'dtpMesFin
            '
            Me.dtpMesFin.Enabled = False
            Me.dtpMesFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpMesFin.Location = New System.Drawing.Point(413, 122)
            Me.dtpMesFin.Name = "dtpMesFin"
            Me.dtpMesFin.Size = New System.Drawing.Size(84, 20)
            Me.dtpMesFin.TabIndex = 45
            Me.dtpMesFin.Visible = False
            '
            'dtpMesInicio
            '
            Me.dtpMesInicio.Enabled = False
            Me.dtpMesInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpMesInicio.Location = New System.Drawing.Point(319, 122)
            Me.dtpMesInicio.Name = "dtpMesInicio"
            Me.dtpMesInicio.Size = New System.Drawing.Size(84, 20)
            Me.dtpMesInicio.TabIndex = 44
            Me.dtpMesInicio.Visible = False
            '
            'dtpFechaFinMes1
            '
            Me.dtpFechaFinMes1.Enabled = False
            Me.dtpFechaFinMes1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinMes1.Location = New System.Drawing.Point(413, 99)
            Me.dtpFechaFinMes1.Name = "dtpFechaFinMes1"
            Me.dtpFechaFinMes1.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinMes1.TabIndex = 43
            Me.dtpFechaFinMes1.Visible = False
            '
            'dtpFechaInicioMes1
            '
            Me.dtpFechaInicioMes1.Enabled = False
            Me.dtpFechaInicioMes1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicioMes1.Location = New System.Drawing.Point(319, 99)
            Me.dtpFechaInicioMes1.Name = "dtpFechaInicioMes1"
            Me.dtpFechaInicioMes1.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicioMes1.TabIndex = 42
            Me.dtpFechaInicioMes1.Visible = False
            '
            'dtpFechaFinMes
            '
            Me.dtpFechaFinMes.Enabled = False
            Me.dtpFechaFinMes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinMes.Location = New System.Drawing.Point(413, 77)
            Me.dtpFechaFinMes.Name = "dtpFechaFinMes"
            Me.dtpFechaFinMes.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinMes.TabIndex = 41
            Me.dtpFechaFinMes.Visible = False
            '
            'dtpFechaInicioMes
            '
            Me.dtpFechaInicioMes.Enabled = False
            Me.dtpFechaInicioMes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicioMes.Location = New System.Drawing.Point(319, 77)
            Me.dtpFechaInicioMes.Name = "dtpFechaInicioMes"
            Me.dtpFechaInicioMes.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicioMes.TabIndex = 40
            Me.dtpFechaInicioMes.Visible = False
            '
            'dtpFechaFinAño
            '
            Me.dtpFechaFinAño.Enabled = False
            Me.dtpFechaFinAño.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaFinAño.Location = New System.Drawing.Point(413, 55)
            Me.dtpFechaFinAño.Name = "dtpFechaFinAño"
            Me.dtpFechaFinAño.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaFinAño.TabIndex = 17
            Me.dtpFechaFinAño.Visible = False
            '
            'dtpFechaInicioAño
            '
            Me.dtpFechaInicioAño.Enabled = False
            Me.dtpFechaInicioAño.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFechaInicioAño.Location = New System.Drawing.Point(319, 55)
            Me.dtpFechaInicioAño.Name = "dtpFechaInicioAño"
            Me.dtpFechaInicioAño.Size = New System.Drawing.Size(84, 20)
            Me.dtpFechaInicioAño.TabIndex = 16
            Me.dtpFechaInicioAño.Visible = False
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(87, 13)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(84, 20)
            Me.dtpFecha.TabIndex = 48
            Me.dtpFecha.Value = New Date(2016, 2, 1, 0, 0, 0, 0)
            '
            'lblFecha
            '
            Me.lblFecha.AutoSize = True
            Me.lblFecha.Location = New System.Drawing.Point(14, 13)
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Size = New System.Drawing.Size(43, 13)
            Me.lblFecha.TabIndex = 37
            Me.lblFecha.Text = "Fecha :"
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
            Me.grbReporte.Controls.Add(Me.rbReporteVendedorOtros)
            Me.grbReporte.Controls.Add(Me.rbReporteAgenciaSucursales)
            Me.grbReporte.Controls.Add(Me.rbReportePlanta)
            Me.grbReporte.Controls.Add(Me.rbReporteVentasArticulo)
            Me.grbReporte.Controls.Add(Me.rbReporteTipoCliente)
            Me.grbReporte.Controls.Add(Me.rbReporteVendedorCampo)
            Me.grbReporte.Controls.Add(Me.rbReporteSucursal)
            Me.grbReporte.Controls.Add(Me.rbReporteVentasCompartivo)
            Me.grbReporte.Controls.Add(Me.rbReporteAgencia)
            Me.grbReporte.Location = New System.Drawing.Point(87, 39)
            Me.grbReporte.Name = "grbReporte"
            Me.grbReporte.Size = New System.Drawing.Size(416, 198)
            Me.grbReporte.TabIndex = 20
            Me.grbReporte.TabStop = False
            '
            'rbReporteVendedorOtros
            '
            Me.rbReporteVendedorOtros.AutoSize = True
            Me.rbReporteVendedorOtros.Location = New System.Drawing.Point(10, 172)
            Me.rbReporteVendedorOtros.Name = "rbReporteVendedorOtros"
            Me.rbReporteVendedorOtros.Size = New System.Drawing.Size(155, 17)
            Me.rbReporteVendedorOtros.TabIndex = 47
            Me.rbReporteVendedorOtros.Text = "Reporte por vendedor otros"
            Me.rbReporteVendedorOtros.UseVisualStyleBackColor = True
            '
            'rbReporteAgenciaSucursales
            '
            Me.rbReporteAgenciaSucursales.AutoSize = True
            Me.rbReporteAgenciaSucursales.Location = New System.Drawing.Point(10, 149)
            Me.rbReporteAgenciaSucursales.Name = "rbReporteAgenciaSucursales"
            Me.rbReporteAgenciaSucursales.Size = New System.Drawing.Size(338, 17)
            Me.rbReporteAgenciaSucursales.TabIndex = 46
            Me.rbReporteAgenciaSucursales.Text = "Reporte de ventas por artículo en agencias/sucursales en millares"
            Me.rbReporteAgenciaSucursales.UseVisualStyleBackColor = True
            '
            'rbReportePlanta
            '
            Me.rbReportePlanta.AutoSize = True
            Me.rbReportePlanta.Location = New System.Drawing.Point(10, 130)
            Me.rbReportePlanta.Name = "rbReportePlanta"
            Me.rbReportePlanta.Size = New System.Drawing.Size(269, 17)
            Me.rbReportePlanta.TabIndex = 45
            Me.rbReportePlanta.Text = "Reporte de ventas por artículo en planta en millares"
            Me.rbReportePlanta.UseVisualStyleBackColor = True
            '
            'rbReporteVentasArticulo
            '
            Me.rbReporteVentasArticulo.AutoSize = True
            Me.rbReporteVentasArticulo.Location = New System.Drawing.Point(10, 111)
            Me.rbReporteVentasArticulo.Name = "rbReporteVentasArticulo"
            Me.rbReporteVentasArticulo.Size = New System.Drawing.Size(222, 17)
            Me.rbReporteVentasArticulo.TabIndex = 44
            Me.rbReporteVentasArticulo.Text = "Reporte de ventas por artículo en millares"
            Me.rbReporteVentasArticulo.UseVisualStyleBackColor = True
            '
            'rbReporteTipoCliente
            '
            Me.rbReporteTipoCliente.AutoSize = True
            Me.rbReporteTipoCliente.Location = New System.Drawing.Point(10, 92)
            Me.rbReporteTipoCliente.Name = "rbReporteTipoCliente"
            Me.rbReporteTipoCliente.Size = New System.Drawing.Size(135, 17)
            Me.rbReporteTipoCliente.TabIndex = 43
            Me.rbReporteTipoCliente.Text = "Reporte por tipo cliente"
            Me.rbReporteTipoCliente.UseVisualStyleBackColor = True
            '
            'rbReporteVendedorCampo
            '
            Me.rbReporteVendedorCampo.AutoSize = True
            Me.rbReporteVendedorCampo.Location = New System.Drawing.Point(10, 73)
            Me.rbReporteVendedorCampo.Name = "rbReporteVendedorCampo"
            Me.rbReporteVendedorCampo.Size = New System.Drawing.Size(164, 17)
            Me.rbReporteVendedorCampo.TabIndex = 42
            Me.rbReporteVendedorCampo.Text = "Reporte por vendedor campo"
            Me.rbReporteVendedorCampo.UseVisualStyleBackColor = True
            '
            'rbReporteSucursal
            '
            Me.rbReporteSucursal.AutoSize = True
            Me.rbReporteSucursal.Location = New System.Drawing.Point(10, 54)
            Me.rbReporteSucursal.Name = "rbReporteSucursal"
            Me.rbReporteSucursal.Size = New System.Drawing.Size(126, 17)
            Me.rbReporteSucursal.TabIndex = 39
            Me.rbReporteSucursal.Text = "Reporte por sucursal "
            Me.rbReporteSucursal.UseVisualStyleBackColor = True
            '
            'rbReporteVentasCompartivo
            '
            Me.rbReporteVentasCompartivo.AutoSize = True
            Me.rbReporteVentasCompartivo.Checked = True
            Me.rbReporteVentasCompartivo.Location = New System.Drawing.Point(10, 16)
            Me.rbReporteVentasCompartivo.Name = "rbReporteVentasCompartivo"
            Me.rbReporteVentasCompartivo.Size = New System.Drawing.Size(174, 17)
            Me.rbReporteVentasCompartivo.TabIndex = 35
            Me.rbReporteVentasCompartivo.TabStop = True
            Me.rbReporteVentasCompartivo.Text = "Reporte de ventas comparativo"
            Me.rbReporteVentasCompartivo.UseVisualStyleBackColor = True
            '
            'rbReporteAgencia
            '
            Me.rbReporteAgencia.AutoSize = True
            Me.rbReporteAgencia.Location = New System.Drawing.Point(10, 35)
            Me.rbReporteAgencia.Name = "rbReporteAgencia"
            Me.rbReporteAgencia.Size = New System.Drawing.Size(122, 17)
            Me.rbReporteAgencia.TabIndex = 33
            Me.rbReporteAgencia.Text = "Reporte por agencia"
            Me.rbReporteAgencia.UseVisualStyleBackColor = True
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(87, 243)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
            Me.btnImprimir.TabIndex = 21
            Me.btnImprimir.Text = "Generar"
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
            'frmAnalisis
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(596, 335)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmAnalisis"
            Me.Text = "Análisis"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.grbReporte.ResumeLayout(False)
            Me.grbReporte.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Friend WithEvents dtpFechaFinAño As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaInicioAño As System.Windows.Forms.DateTimePicker
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents lblReporte As System.Windows.Forms.Label
        Friend WithEvents grbReporte As System.Windows.Forms.GroupBox
        Friend WithEvents rbReporteVentasCompartivo As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteAgencia As System.Windows.Forms.RadioButton
        Friend WithEvents lblFecha As System.Windows.Forms.Label
        Friend WithEvents dtpMesFin1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpMesInicio1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpMesFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpMesInicio As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaFinMes1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaInicioMes1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaFinMes As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaInicioMes As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents rbReporteSucursal As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteVendedorCampo As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteAgenciaSucursales As System.Windows.Forms.RadioButton
        Friend WithEvents rbReportePlanta As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteVentasArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteTipoCliente As System.Windows.Forms.RadioButton
        Friend WithEvents rbReporteVendedorOtros As System.Windows.Forms.RadioButton
    End Class
End Namespace