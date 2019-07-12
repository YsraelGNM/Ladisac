<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventario
    Inherits Ladisac.Foundation.Views.ViewManMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Almacenes")
        Me.dsInventarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvUbicacion = New System.Windows.Forms.DataGridView()
        Me.MostrarU = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.treeAlmacen = New System.Windows.Forms.TreeView()
        Me.chkUbicaciones = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkSaldo = New System.Windows.Forms.CheckBox()
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
        Me.INV_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UM_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INV_STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INV_CONTEO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INV_PU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UBI_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UBI_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkPositivo = New System.Windows.Forms.CheckBox()
        Me.chkNegativo = New System.Windows.Forms.CheckBox()
        CType(Me.dsInventarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(897, 28)
        Me.lblTitle.Text = "Inventario"
        '
        'dsInventarioBindingSource
        '
        Me.dsInventarioBindingSource.DataMember = "Inventario"
        Me.dsInventarioBindingSource.DataSource = GetType(dsInventario)
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INV_ID, Me.Codigo, Me.ART_ID, Me.UM_Descripcion, Me.ALM_ID, Me.Ubicacion, Me.INV_STOCK, Me.INV_CONTEO, Me.INV_PU})
        Me.dgvDetalle.Location = New System.Drawing.Point(25, 181)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(824, 233)
        Me.dgvDetalle.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(69, 6)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(101, 20)
        Me.dtpFecha.TabIndex = 4
        '
        'dgvUbicacion
        '
        Me.dgvUbicacion.AllowUserToAddRows = False
        Me.dgvUbicacion.AllowUserToDeleteRows = False
        Me.dgvUbicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUbicacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UBI_ID, Me.UBI_DESCRIPCION, Me.MostrarU})
        Me.dgvUbicacion.Location = New System.Drawing.Point(481, 60)
        Me.dgvUbicacion.Name = "dgvUbicacion"
        Me.dgvUbicacion.RowHeadersVisible = False
        Me.dgvUbicacion.Size = New System.Drawing.Size(255, 115)
        Me.dgvUbicacion.TabIndex = 108
        '
        'MostrarU
        '
        Me.MostrarU.HeaderText = "Mostrar"
        Me.MostrarU.Name = "MostrarU"
        Me.MostrarU.Width = 60
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(764, 143)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(85, 32)
        Me.btnCargar.TabIndex = 109
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsInventario"
        ReportDataSource1.Value = Me.dsInventarioBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptInventario.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(17, 58)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(826, 343)
        Me.ReportViewer1.TabIndex = 110
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 69)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(873, 446)
        Me.TabControl1.TabIndex = 111
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtBuscar)
        Me.TabPage1.Controls.Add(Me.treeAlmacen)
        Me.TabPage1.Controls.Add(Me.chkUbicaciones)
        Me.TabPage1.Controls.Add(Me.dgvDetalle)
        Me.TabPage1.Controls.Add(Me.btnCargar)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dgvUbicacion)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(865, 420)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inventario"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(481, 32)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(255, 20)
        Me.txtBuscar.TabIndex = 111
        '
        'treeAlmacen
        '
        Me.treeAlmacen.CheckBoxes = True
        Me.treeAlmacen.Location = New System.Drawing.Point(25, 32)
        Me.treeAlmacen.Name = "treeAlmacen"
        TreeNode1.Name = "Node0"
        TreeNode1.Tag = "-1"
        TreeNode1.Text = "Almacenes"
        Me.treeAlmacen.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.treeAlmacen.Size = New System.Drawing.Size(404, 143)
        Me.treeAlmacen.TabIndex = 0
        '
        'chkUbicaciones
        '
        Me.chkUbicaciones.AutoSize = True
        Me.chkUbicaciones.Checked = True
        Me.chkUbicaciones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUbicaciones.Location = New System.Drawing.Point(764, 32)
        Me.chkUbicaciones.Name = "chkUbicaciones"
        Me.chkUbicaciones.Size = New System.Drawing.Size(85, 17)
        Me.chkUbicaciones.TabIndex = 110
        Me.chkUbicaciones.Text = "Ubicaciones"
        Me.chkUbicaciones.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkNegativo)
        Me.TabPage2.Controls.Add(Me.chkPositivo)
        Me.TabPage2.Controls.Add(Me.chkSaldo)
        Me.TabPage2.Controls.Add(Me.ReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(865, 420)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reporte"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkSaldo
        '
        Me.chkSaldo.AutoSize = True
        Me.chkSaldo.Location = New System.Drawing.Point(17, 23)
        Me.chkSaldo.Name = "chkSaldo"
        Me.chkSaldo.Size = New System.Drawing.Size(107, 17)
        Me.chkSaldo.TabIndex = 111
        Me.chkSaldo.Text = "Con Saldo y P.U."
        Me.chkSaldo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "INV_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Articulo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "UM"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Almacen"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Ubicacion"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Stock"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Conteo"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "PU"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "UBI_ID"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Ubicacion"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 170
        '
        'INV_ID
        '
        Me.INV_ID.HeaderText = "INV_ID"
        Me.INV_ID.Name = "INV_ID"
        Me.INV_ID.Visible = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        '
        'ART_ID
        '
        Me.ART_ID.HeaderText = "Articulo"
        Me.ART_ID.Name = "ART_ID"
        '
        'UM_Descripcion
        '
        Me.UM_Descripcion.HeaderText = "UM"
        Me.UM_Descripcion.Name = "UM_Descripcion"
        '
        'ALM_ID
        '
        Me.ALM_ID.HeaderText = "Almacen"
        Me.ALM_ID.Name = "ALM_ID"
        '
        'Ubicacion
        '
        Me.Ubicacion.HeaderText = "Ubicacion"
        Me.Ubicacion.Name = "Ubicacion"
        '
        'INV_STOCK
        '
        Me.INV_STOCK.HeaderText = "Stock"
        Me.INV_STOCK.Name = "INV_STOCK"
        '
        'INV_CONTEO
        '
        Me.INV_CONTEO.HeaderText = "Conteo"
        Me.INV_CONTEO.Name = "INV_CONTEO"
        '
        'INV_PU
        '
        Me.INV_PU.HeaderText = "PU"
        Me.INV_PU.Name = "INV_PU"
        '
        'UBI_ID
        '
        Me.UBI_ID.HeaderText = "UBI_ID"
        Me.UBI_ID.Name = "UBI_ID"
        Me.UBI_ID.ReadOnly = True
        Me.UBI_ID.Visible = False
        '
        'UBI_DESCRIPCION
        '
        Me.UBI_DESCRIPCION.HeaderText = "Ubicacion"
        Me.UBI_DESCRIPCION.Name = "UBI_DESCRIPCION"
        Me.UBI_DESCRIPCION.ReadOnly = True
        Me.UBI_DESCRIPCION.Width = 170
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "ALM_ID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Almacen"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 300
        '
        'chkPositivo
        '
        Me.chkPositivo.AutoSize = True
        Me.chkPositivo.Location = New System.Drawing.Point(159, 23)
        Me.chkPositivo.Name = "chkPositivo"
        Me.chkPositivo.Size = New System.Drawing.Size(63, 17)
        Me.chkPositivo.TabIndex = 112
        Me.chkPositivo.Text = "Positivo"
        Me.chkPositivo.UseVisualStyleBackColor = True
        '
        'chkNegativo
        '
        Me.chkNegativo.AutoSize = True
        Me.chkNegativo.Location = New System.Drawing.Point(285, 23)
        Me.chkNegativo.Name = "chkNegativo"
        Me.chkNegativo.Size = New System.Drawing.Size(69, 17)
        Me.chkNegativo.TabIndex = 113
        Me.chkNegativo.Text = "Negativo"
        Me.chkNegativo.UseVisualStyleBackColor = True
        '
        'frmInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(897, 527)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmInventario"
        Me.Text = "Inventario"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.dsInventarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvUbicacion As System.Windows.Forms.DataGridView
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsInventarioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents UBI_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UBI_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MostrarU As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents INV_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UM_Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INV_STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INV_CONTEO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INV_PU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents chkUbicaciones As System.Windows.Forms.CheckBox
    Friend WithEvents treeAlmacen As System.Windows.Forms.TreeView
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
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents chkNegativo As System.Windows.Forms.CheckBox
    Friend WithEvents chkPositivo As System.Windows.Forms.CheckBox

End Class
