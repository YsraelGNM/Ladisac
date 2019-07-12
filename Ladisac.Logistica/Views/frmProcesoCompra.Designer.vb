<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesoCompra
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DsImpresionProcesoCompraResumenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.mMenuParaComprar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DevolverInicioParaComprar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.splitConsolidado = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConsolidar = New System.Windows.Forms.Button()
        Me.dgvDetalleConsolidar = New System.Windows.Forms.DataGridView()
        Me.Cotizacion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtBuscarConsolidado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExpoExcel = New System.Windows.Forms.Button()
        Me.txtBuscarAConsolidar = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnListaConserje = New System.Windows.Forms.Button()
        Me.dtpFechaConserje = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvConserje = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSolicitarCotizacion = New System.Windows.Forms.Button()
        Me.btnGenerarOC = New System.Windows.Forms.Button()
        Me.dgvCotizacion = New System.Windows.Forms.DataGridView()
        Me.cotizando2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HuboRespuesta = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RequiereVBsolicitante = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VBSolicitante = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RequiereVBGerencia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VBGerencia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gerente = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DevolverInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuscarResumen = New System.Windows.Forms.TextBox()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.Aprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rechazado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantSolicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalEstimado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResponsableSinCotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodArticulo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadSolicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Conserge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodArticulo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsCotizando = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsRespuesta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsRVBS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsVBS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsRVBG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObsVBG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OCO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DsImpresionProcesoCompraResumenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mMenuParaComprar.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.splitConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitConsolidado.Panel1.SuspendLayout()
        Me.splitConsolidado.Panel2.SuspendLayout()
        Me.splitConsolidado.SuspendLayout()
        CType(Me.dgvDetalleConsolidar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvConserje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mMenu.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1110, 28)
        Me.lblTitle.Text = "Proceso Compra"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.ContextMenuStrip = Me.mMenuParaComprar
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 29)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(1063, 168)
        Me.dgvDetalle.TabIndex = 99
        '
        'mMenuParaComprar
        '
        Me.mMenuParaComprar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevolverInicioParaComprar})
        Me.mMenuParaComprar.Name = "mMenu"
        Me.mMenuParaComprar.Size = New System.Drawing.Size(175, 26)
        '
        'DevolverInicioParaComprar
        '
        Me.DevolverInicioParaComprar.Name = "DevolverInicioParaComprar"
        Me.DevolverInicioParaComprar.Size = New System.Drawing.Size(174, 22)
        Me.DevolverInicioParaComprar.Text = "Devolverlo al Inicio"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1086, 532)
        Me.TabControl1.TabIndex = 100
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.splitConsolidado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1078, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Consolidar"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'splitConsolidado
        '
        Me.splitConsolidado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitConsolidado.Location = New System.Drawing.Point(3, 3)
        Me.splitConsolidado.Name = "splitConsolidado"
        Me.splitConsolidado.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitConsolidado.Panel1
        '
        Me.splitConsolidado.Panel1.Controls.Add(Me.Label2)
        Me.splitConsolidado.Panel1.Controls.Add(Me.btnConsolidar)
        Me.splitConsolidado.Panel1.Controls.Add(Me.dgvDetalleConsolidar)
        Me.splitConsolidado.Panel1.Controls.Add(Me.txtBuscarConsolidado)
        '
        'splitConsolidado.Panel2
        '
        Me.splitConsolidado.Panel2.Controls.Add(Me.Label1)
        Me.splitConsolidado.Panel2.Controls.Add(Me.dgvDetalle)
        Me.splitConsolidado.Panel2.Controls.Add(Me.btnExpoExcel)
        Me.splitConsolidado.Panel2.Controls.Add(Me.txtBuscarAConsolidar)
        Me.splitConsolidado.Size = New System.Drawing.Size(1072, 500)
        Me.splitConsolidado.SplitterDistance = 256
        Me.splitConsolidado.SplitterWidth = 12
        Me.splitConsolidado.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Buscar:"
        '
        'btnConsolidar
        '
        Me.btnConsolidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsolidar.Location = New System.Drawing.Point(3, 230)
        Me.btnConsolidar.Name = "btnConsolidar"
        Me.btnConsolidar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsolidar.TabIndex = 101
        Me.btnConsolidar.Text = "Consolidar"
        Me.btnConsolidar.UseVisualStyleBackColor = True
        '
        'dgvDetalleConsolidar
        '
        Me.dgvDetalleConsolidar.AllowUserToAddRows = False
        Me.dgvDetalleConsolidar.AllowUserToDeleteRows = False
        Me.dgvDetalleConsolidar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleConsolidar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleConsolidar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodArticulo, Me.Descripcion, Me.CantSolicitada, Me.Stock, Me.Cant, Me.TotalEstimado, Me.ResponsableSinCotizacion, Me.Cotizacion, Me.Responsable, Me.Observacion1, Me.ART_ID, Me.fecha})
        Me.dgvDetalleConsolidar.Location = New System.Drawing.Point(6, 34)
        Me.dgvDetalleConsolidar.Name = "dgvDetalleConsolidar"
        Me.dgvDetalleConsolidar.Size = New System.Drawing.Size(1066, 190)
        Me.dgvDetalleConsolidar.TabIndex = 100
        '
        'Cotizacion
        '
        Me.Cotizacion.HeaderText = "Cotizacion"
        Me.Cotizacion.Name = "Cotizacion"
        Me.Cotizacion.ReadOnly = True
        Me.Cotizacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cotizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'txtBuscarConsolidado
        '
        Me.txtBuscarConsolidado.Location = New System.Drawing.Point(52, 8)
        Me.txtBuscarConsolidado.Name = "txtBuscarConsolidado"
        Me.txtBuscarConsolidado.Size = New System.Drawing.Size(394, 20)
        Me.txtBuscarConsolidado.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Buscar:"
        '
        'btnExpoExcel
        '
        Me.btnExpoExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpoExcel.Location = New System.Drawing.Point(971, 4)
        Me.btnExpoExcel.Name = "btnExpoExcel"
        Me.btnExpoExcel.Size = New System.Drawing.Size(98, 23)
        Me.btnExpoExcel.TabIndex = 130
        Me.btnExpoExcel.Text = "Exportar"
        Me.btnExpoExcel.UseVisualStyleBackColor = True
        '
        'txtBuscarAConsolidar
        '
        Me.txtBuscarAConsolidar.Location = New System.Drawing.Point(52, 5)
        Me.txtBuscarAConsolidar.Name = "txtBuscarAConsolidar"
        Me.txtBuscarAConsolidar.Size = New System.Drawing.Size(394, 20)
        Me.txtBuscarAConsolidar.TabIndex = 103
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnListaConserje)
        Me.TabPage2.Controls.Add(Me.dtpFechaConserje)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1078, 506)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Responsable Sin Cotizacion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnListaConserje
        '
        Me.btnListaConserje.Location = New System.Drawing.Point(169, 11)
        Me.btnListaConserje.Name = "btnListaConserje"
        Me.btnListaConserje.Size = New System.Drawing.Size(75, 23)
        Me.btnListaConserje.TabIndex = 104
        Me.btnListaConserje.Text = "Visualizar"
        Me.btnListaConserje.UseVisualStyleBackColor = True
        '
        'dtpFechaConserje
        '
        Me.dtpFechaConserje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaConserje.Location = New System.Drawing.Point(65, 12)
        Me.dtpFechaConserje.Name = "dtpFechaConserje"
        Me.dtpFechaConserje.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaConserje.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Fecha"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Location = New System.Drawing.Point(6, 42)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1066, 458)
        Me.TabControl2.TabIndex = 101
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvConserje)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1058, 432)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Autorizar"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvConserje
        '
        Me.dgvConserje.AllowUserToAddRows = False
        Me.dgvConserje.AllowUserToDeleteRows = False
        Me.dgvConserje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConserje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvConserje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConserje.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodArticulo1, Me.Descripcion1, Me.UM, Me.CantidadSolicitada, Me.Conserge, Me.Aprobado, Me.Rechazado})
        Me.dgvConserje.Location = New System.Drawing.Point(6, 6)
        Me.dgvConserje.Name = "dgvConserje"
        Me.dgvConserje.Size = New System.Drawing.Size(1046, 420)
        Me.dgvConserje.TabIndex = 100
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ReportViewer1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1058, 432)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "Impresion"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnSolicitarCotizacion)
        Me.TabPage3.Controls.Add(Me.btnGenerarOC)
        Me.TabPage3.Controls.Add(Me.dgvCotizacion)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1078, 506)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cotizacion"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnSolicitarCotizacion
        '
        Me.btnSolicitarCotizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSolicitarCotizacion.Location = New System.Drawing.Point(844, 465)
        Me.btnSolicitarCotizacion.Name = "btnSolicitarCotizacion"
        Me.btnSolicitarCotizacion.Size = New System.Drawing.Size(115, 23)
        Me.btnSolicitarCotizacion.TabIndex = 105
        Me.btnSolicitarCotizacion.Text = "Solicitar Cotizacion"
        Me.btnSolicitarCotizacion.UseVisualStyleBackColor = True
        '
        'btnGenerarOC
        '
        Me.btnGenerarOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarOC.Location = New System.Drawing.Point(988, 465)
        Me.btnGenerarOC.Name = "btnGenerarOC"
        Me.btnGenerarOC.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerarOC.TabIndex = 104
        Me.btnGenerarOC.Text = "Generar OC"
        Me.btnGenerarOC.UseVisualStyleBackColor = True
        '
        'dgvCotizacion
        '
        Me.dgvCotizacion.AllowUserToAddRows = False
        Me.dgvCotizacion.AllowUserToDeleteRows = False
        Me.dgvCotizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCotizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodArticulo2, Me.Descripcion2, Me.Cant2, Me.Responsable2, Me.cotizando2, Me.ObsCotizando, Me.HuboRespuesta, Me.ObsRespuesta, Me.RequiereVBsolicitante, Me.ObsRVBS, Me.VBSolicitante, Me.ObsVBS, Me.RequiereVBGerencia, Me.ObsRVBG, Me.VBGerencia, Me.gerente, Me.ObsVBG, Me.OC, Me.OCO_ID})
        Me.dgvCotizacion.ContextMenuStrip = Me.mMenu
        Me.dgvCotizacion.Location = New System.Drawing.Point(3, 3)
        Me.dgvCotizacion.Name = "dgvCotizacion"
        Me.dgvCotizacion.Size = New System.Drawing.Size(1072, 444)
        Me.dgvCotizacion.TabIndex = 100
        '
        'cotizando2
        '
        Me.cotizando2.HeaderText = "Cotizando"
        Me.cotizando2.Name = "cotizando2"
        Me.cotizando2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cotizando2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'HuboRespuesta
        '
        Me.HuboRespuesta.HeaderText = "Hubo Respuesta"
        Me.HuboRespuesta.Name = "HuboRespuesta"
        Me.HuboRespuesta.Visible = False
        '
        'RequiereVBsolicitante
        '
        Me.RequiereVBsolicitante.HeaderText = "Requiere VB Solicitante"
        Me.RequiereVBsolicitante.Name = "RequiereVBsolicitante"
        Me.RequiereVBsolicitante.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RequiereVBsolicitante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RequiereVBsolicitante.Visible = False
        '
        'VBSolicitante
        '
        Me.VBSolicitante.HeaderText = "VB Solicitante"
        Me.VBSolicitante.Name = "VBSolicitante"
        Me.VBSolicitante.Visible = False
        '
        'RequiereVBGerencia
        '
        Me.RequiereVBGerencia.HeaderText = "Requiere VB Gerencia"
        Me.RequiereVBGerencia.Name = "RequiereVBGerencia"
        Me.RequiereVBGerencia.Visible = False
        '
        'VBGerencia
        '
        Me.VBGerencia.HeaderText = "Aprobo Gerencia"
        Me.VBGerencia.Name = "VBGerencia"
        Me.VBGerencia.Visible = False
        '
        'gerente
        '
        Me.gerente.HeaderText = "Gerente"
        Me.gerente.Items.AddRange(New Object() {"Angel Linares", "Irene Linares", "Maria Linares", "Libertad Linares"})
        Me.gerente.Name = "gerente"
        Me.gerente.Visible = False
        '
        'OC
        '
        Me.OC.HeaderText = "O.C."
        Me.OC.Name = "OC"
        Me.OC.Visible = False
        '
        'mMenu
        '
        Me.mMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevolverInicio})
        Me.mMenu.Name = "mMenu"
        Me.mMenu.Size = New System.Drawing.Size(175, 26)
        '
        'DevolverInicio
        '
        Me.DevolverInicio.Name = "DevolverInicio"
        Me.DevolverInicio.Size = New System.Drawing.Size(174, 22)
        Me.DevolverInicio.Text = "Devolverlo al Inicio"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnExportar)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.txtBuscarResumen)
        Me.TabPage4.Controls.Add(Me.dgvResumen)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1078, 506)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Resumen"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Location = New System.Drawing.Point(963, 480)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(98, 23)
        Me.btnExportar.TabIndex = 130
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Buscar:"
        '
        'txtBuscarResumen
        '
        Me.txtBuscarResumen.Location = New System.Drawing.Point(61, 7)
        Me.txtBuscarResumen.Name = "txtBuscarResumen"
        Me.txtBuscarResumen.Size = New System.Drawing.Size(394, 20)
        Me.txtBuscarResumen.TabIndex = 107
        '
        'dgvResumen
        '
        Me.dgvResumen.AllowUserToAddRows = False
        Me.dgvResumen.AllowUserToDeleteRows = False
        Me.dgvResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Location = New System.Drawing.Point(15, 36)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.ReadOnly = True
        Me.dgvResumen.Size = New System.Drawing.Size(1046, 442)
        Me.dgvResumen.TabIndex = 100
        '
        'Aprobado
        '
        Me.Aprobado.FillWeight = 50.0!
        Me.Aprobado.HeaderText = "Aprobado"
        Me.Aprobado.Name = "Aprobado"
        '
        'Rechazado
        '
        Me.Rechazado.FillWeight = 50.0!
        Me.Rechazado.HeaderText = "Rechazado"
        Me.Rechazado.Name = "Rechazado"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cod. Articulo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cant.Solicitada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Stock"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cant."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Total Estimado S/."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Responsable Compra Sin Cotizacion"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Responsable"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Observacion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "ART_ID"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.FillWeight = 60.0!
        Me.DataGridViewTextBoxColumn12.HeaderText = "Cod.Articulo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 128
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 213
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn14.HeaderText = "CantidadSolicitada"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 107
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.FillWeight = 60.0!
        Me.DataGridViewTextBoxColumn15.HeaderText = "Conserge"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 128
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Cod. Articulo"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 214
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Cant."
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Responsable"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "ObsCotizando"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Obs Respuesta"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "Obs RVB Solicitante"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "Obs Solicitante"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "Obs RVB Gerencia"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Obs Gerencia"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "NroO.C."
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.HeaderText = "NroO.C."
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'CodArticulo
        '
        Me.CodArticulo.HeaderText = "Cod. Articulo"
        Me.CodArticulo.Name = "CodArticulo"
        Me.CodArticulo.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'CantSolicitada
        '
        Me.CantSolicitada.HeaderText = "Cant.Solicitada"
        Me.CantSolicitada.Name = "CantSolicitada"
        Me.CantSolicitada.ReadOnly = True
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        '
        'Cant
        '
        Me.Cant.HeaderText = "Cant."
        Me.Cant.Name = "Cant"
        '
        'TotalEstimado
        '
        Me.TotalEstimado.HeaderText = "Total Estimado S/."
        Me.TotalEstimado.Name = "TotalEstimado"
        '
        'ResponsableSinCotizacion
        '
        Me.ResponsableSinCotizacion.HeaderText = "Responsable Compra Sin Cotizacion"
        Me.ResponsableSinCotizacion.Name = "ResponsableSinCotizacion"
        Me.ResponsableSinCotizacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        '
        'Observacion1
        '
        Me.Observacion1.HeaderText = "Observacion"
        Me.Observacion1.Name = "Observacion1"
        '
        'ART_ID
        '
        Me.ART_ID.HeaderText = "ART_ID"
        Me.ART_ID.Name = "ART_ID"
        Me.ART_ID.Visible = False
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.Visible = False
        '
        'CodArticulo1
        '
        Me.CodArticulo1.FillWeight = 60.0!
        Me.CodArticulo1.HeaderText = "Cod.Articulo"
        Me.CodArticulo1.Name = "CodArticulo1"
        Me.CodArticulo1.ReadOnly = True
        '
        'Descripcion1
        '
        Me.Descripcion1.HeaderText = "Descripcion"
        Me.Descripcion1.Name = "Descripcion1"
        Me.Descripcion1.ReadOnly = True
        '
        'UM
        '
        Me.UM.FillWeight = 50.0!
        Me.UM.HeaderText = "UM"
        Me.UM.Name = "UM"
        '
        'CantidadSolicitada
        '
        Me.CantidadSolicitada.FillWeight = 60.0!
        Me.CantidadSolicitada.HeaderText = "CantidadSolicitada"
        Me.CantidadSolicitada.Name = "CantidadSolicitada"
        Me.CantidadSolicitada.ReadOnly = True
        '
        'Conserge
        '
        Me.Conserge.HeaderText = "Conserge"
        Me.Conserge.Name = "Conserge"
        Me.Conserge.ReadOnly = True
        '
        'CodArticulo2
        '
        Me.CodArticulo2.HeaderText = "Cod. Articulo"
        Me.CodArticulo2.Name = "CodArticulo2"
        '
        'Descripcion2
        '
        Me.Descripcion2.HeaderText = "Descripcion"
        Me.Descripcion2.Name = "Descripcion2"
        '
        'Cant2
        '
        Me.Cant2.HeaderText = "Cant."
        Me.Cant2.Name = "Cant2"
        '
        'Responsable2
        '
        Me.Responsable2.HeaderText = "Responsable"
        Me.Responsable2.Name = "Responsable2"
        Me.Responsable2.Visible = False
        '
        'ObsCotizando
        '
        Me.ObsCotizando.HeaderText = "ObsCotizando"
        Me.ObsCotizando.Name = "ObsCotizando"
        '
        'ObsRespuesta
        '
        Me.ObsRespuesta.HeaderText = "Obs Respuesta"
        Me.ObsRespuesta.Name = "ObsRespuesta"
        Me.ObsRespuesta.Visible = False
        '
        'ObsRVBS
        '
        Me.ObsRVBS.HeaderText = "Obs RVB Solicitante"
        Me.ObsRVBS.Name = "ObsRVBS"
        Me.ObsRVBS.Visible = False
        '
        'ObsVBS
        '
        Me.ObsVBS.HeaderText = "Obs Solicitante"
        Me.ObsVBS.Name = "ObsVBS"
        Me.ObsVBS.Visible = False
        '
        'ObsRVBG
        '
        Me.ObsRVBG.HeaderText = "Obs RVB Gerencia"
        Me.ObsRVBG.Name = "ObsRVBG"
        Me.ObsRVBG.Visible = False
        '
        'ObsVBG
        '
        Me.ObsVBG.HeaderText = "Obs Gerencia"
        Me.ObsVBG.Name = "ObsVBG"
        Me.ObsVBG.Visible = False
        '
        'OCO_ID
        '
        Me.OCO_ID.HeaderText = "NroO.C."
        Me.OCO_ID.Name = "OCO_ID"
        Me.OCO_ID.ReadOnly = True
        Me.OCO_ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OCO_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OCO_ID.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsListaProcesoCompraSinCotizacionImpresion"
        ReportDataSource1.Value = Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaProcesoCompraSinCotizacionImpresion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1052, 426)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsListaProcesoCompraSinCotizacionImpresionBindingSource
        '
        Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource.DataMember = "ListaProcesoCompraSinCotizacionImpresion"
        Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource.DataSource = GetType(dsListaProcesoCompraSinCotizacionImpresion)
        '
        'frmProcesoCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 600)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmProcesoCompra"
        Me.Text = "Proceso Compra"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        CType(Me.DsImpresionProcesoCompraResumenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mMenuParaComprar.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.splitConsolidado.Panel1.ResumeLayout(False)
        Me.splitConsolidado.Panel1.PerformLayout()
        Me.splitConsolidado.Panel2.ResumeLayout(False)
        Me.splitConsolidado.Panel2.PerformLayout()
        CType(Me.splitConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitConsolidado.ResumeLayout(False)
        CType(Me.dgvDetalleConsolidar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvConserje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mMenu.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaProcesoCompraSinCotizacionImpresionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvDetalleConsolidar As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnConsolidar As System.Windows.Forms.Button
    Friend WithEvents dgvConserje As System.Windows.Forms.DataGridView
    Friend WithEvents dgvResumen As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerarOC As System.Windows.Forms.Button
    Friend WithEvents DsImpresionProcesoCompraResumenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarConsolidado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarAConsolidar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarResumen As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DevolverInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mMenuParaComprar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DevolverInicioParaComprar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantSolicitada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalEstimado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResponsableSinCotizacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cotizacion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnExpoExcel As System.Windows.Forms.Button
    Friend WithEvents btnSolicitarCotizacion As System.Windows.Forms.Button
    Friend WithEvents CodArticulo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotizando2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObsCotizando As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HuboRespuesta As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObsRespuesta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequiereVBsolicitante As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObsRVBS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VBSolicitante As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObsVBS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequiereVBGerencia As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObsRVBG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VBGerencia As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gerente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ObsVBG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OC As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OCO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents splitConsolidado As System.Windows.Forms.SplitContainer
    Friend WithEvents btnListaConserje As System.Windows.Forms.Button
    Friend WithEvents dtpFechaConserje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents CodArticulo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadSolicitada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Conserge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aprobado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Rechazado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaProcesoCompraSinCotizacionImpresionBindingSource As System.Windows.Forms.BindingSource
End Class
