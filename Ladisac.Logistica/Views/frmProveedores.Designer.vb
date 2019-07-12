<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedores
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombreComercial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRUC = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDireccionFiscal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboCalificacion = New System.Windows.Forms.ComboBox()
        Me.dgvRubro = New System.Windows.Forms.DataGridView()
        Me.RUP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUB_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvContactos = New System.Windows.Forms.DataGridView()
        Me.COP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COP_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COP_DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COP_TELEFONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COP_EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDireccionDomicilio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtWeb = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCalificacion2 = New System.Windows.Forms.ComboBox()
        Me.dgvRubro2 = New System.Windows.Forms.DataGridView()
        Me.dsListaProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RUP_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUB_ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUB_DESCRIPCION2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccion2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvRubro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(964, 28)
        Me.lblTitle.Text = "Proveedores"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(117, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigo.TabIndex = 3
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.Location = New System.Drawing.Point(117, 41)
        Me.txtNombreComercial.MaxLength = 255
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Size = New System.Drawing.Size(432, 20)
        Me.txtNombreComercial.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre Comercial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "RUC"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(117, 105)
        Me.txtRazonSocial.MaxLength = 160
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(432, 20)
        Me.txtRazonSocial.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Razon Social"
        '
        'txtRUC
        '
        Me.txtRUC.Location = New System.Drawing.Point(117, 75)
        Me.txtRUC.Mask = "99999999999"
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(94, 20)
        Me.txtRUC.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Telefonos"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(117, 203)
        Me.txtCorreo.MaxLength = 50
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(432, 20)
        Me.txtCorreo.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Correo"
        '
        'txtDireccionFiscal
        '
        Me.txtDireccionFiscal.Location = New System.Drawing.Point(117, 141)
        Me.txtDireccionFiscal.MaxLength = 160
        Me.txtDireccionFiscal.Name = "txtDireccionFiscal"
        Me.txtDireccionFiscal.Size = New System.Drawing.Size(432, 20)
        Me.txtDireccionFiscal.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Direccion Fiscal"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(117, 233)
        Me.txtTelefono.MaxLength = 90
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(264, 20)
        Me.txtTelefono.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(579, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Rubro"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(579, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Calificacion"
        '
        'cboCalificacion
        '
        Me.cboCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalificacion.FormattingEnabled = True
        Me.cboCalificacion.Items.AddRange(New Object() {"", "5 *****", "4 ****", "3 ***", "2 **", "1 *"})
        Me.cboCalificacion.Location = New System.Drawing.Point(646, 40)
        Me.cboCalificacion.Name = "cboCalificacion"
        Me.cboCalificacion.Size = New System.Drawing.Size(149, 21)
        Me.cboCalificacion.TabIndex = 26
        '
        'dgvRubro
        '
        Me.dgvRubro.AllowUserToAddRows = False
        Me.dgvRubro.AllowUserToDeleteRows = False
        Me.dgvRubro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRubro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RUP_ID, Me.RUB_ID, Me.RUB_DESCRIPCION, Me.Seleccion})
        Me.dgvRubro.Location = New System.Drawing.Point(646, 76)
        Me.dgvRubro.Name = "dgvRubro"
        Me.dgvRubro.Size = New System.Drawing.Size(271, 206)
        Me.dgvRubro.TabIndex = 27
        '
        'RUP_ID
        '
        Me.RUP_ID.HeaderText = "RUP_ID"
        Me.RUP_ID.Name = "RUP_ID"
        Me.RUP_ID.Visible = False
        '
        'RUB_ID
        '
        Me.RUB_ID.HeaderText = "RUB_ID"
        Me.RUB_ID.Name = "RUB_ID"
        Me.RUB_ID.Visible = False
        '
        'RUB_DESCRIPCION
        '
        Me.RUB_DESCRIPCION.HeaderText = "Descripcion"
        Me.RUB_DESCRIPCION.Name = "RUB_DESCRIPCION"
        Me.RUB_DESCRIPCION.Width = 150
        '
        'Seleccion
        '
        Me.Seleccion.HeaderText = "Seleccion"
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Width = 70
        '
        'dgvContactos
        '
        Me.dgvContactos.AllowUserToAddRows = False
        Me.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContactos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COP_ID, Me.COP_DESCRIPCION, Me.COP_DIRECCION, Me.COP_TELEFONO, Me.COP_EMAIL})
        Me.dgvContactos.Location = New System.Drawing.Point(117, 328)
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.Size = New System.Drawing.Size(800, 148)
        Me.dgvContactos.TabIndex = 29
        '
        'COP_ID
        '
        Me.COP_ID.HeaderText = "COP_ID"
        Me.COP_ID.Name = "COP_ID"
        Me.COP_ID.Visible = False
        '
        'COP_DESCRIPCION
        '
        Me.COP_DESCRIPCION.HeaderText = "Nombre"
        Me.COP_DESCRIPCION.Name = "COP_DESCRIPCION"
        '
        'COP_DIRECCION
        '
        Me.COP_DIRECCION.HeaderText = "Direccion"
        Me.COP_DIRECCION.Name = "COP_DIRECCION"
        '
        'COP_TELEFONO
        '
        Me.COP_TELEFONO.HeaderText = "Telefonos"
        Me.COP_TELEFONO.Name = "COP_TELEFONO"
        '
        'COP_EMAIL
        '
        Me.COP_EMAIL.HeaderText = "Correo"
        Me.COP_EMAIL.Name = "COP_EMAIL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 328)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Contactos"
        '
        'txtDireccionDomicilio
        '
        Me.txtDireccionDomicilio.Location = New System.Drawing.Point(117, 173)
        Me.txtDireccionDomicilio.MaxLength = 160
        Me.txtDireccionDomicilio.Name = "txtDireccionDomicilio"
        Me.txtDireccionDomicilio.Size = New System.Drawing.Size(432, 20)
        Me.txtDireccionDomicilio.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Direccion "
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'txtWeb
        '
        Me.txtWeb.Location = New System.Drawing.Point(117, 262)
        Me.txtWeb.MaxLength = 50
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(432, 20)
        Me.txtWeb.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Pagina Web"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(117, 292)
        Me.txtObservaciones.MaxLength = 255
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(800, 20)
        Me.txtObservaciones.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Observaciones"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "RUP_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "RUB_ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "COP_ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Direccion"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Telefonos"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Correo"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(941, 512)
        Me.TabControl1.TabIndex = 37
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtCodigo)
        Me.TabPage1.Controls.Add(Me.txtObservaciones)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtRazonSocial)
        Me.TabPage1.Controls.Add(Me.txtNombreComercial)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtDireccionFiscal)
        Me.TabPage1.Controls.Add(Me.txtWeb)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtRUC)
        Me.TabPage1.Controls.Add(Me.txtCorreo)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtDireccionDomicilio)
        Me.TabPage1.Controls.Add(Me.txtTelefono)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.dgvContactos)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.cboCalificacion)
        Me.TabPage1.Controls.Add(Me.dgvRubro)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(933, 486)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ReportViewer1)
        Me.TabPage2.Controls.Add(Me.btnVisualizar)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtProveedor)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.cboCalificacion2)
        Me.TabPage2.Controls.Add(Me.dgvRubro2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(933, 486)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reporte"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource2.Name = "dsListaProveedor"
        ReportDataSource2.Value = Me.dsListaProveedorBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaProveedor.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(297, 17)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(630, 463)
        Me.ReportViewer1.TabIndex = 75
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(206, 403)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(74, 23)
        Me.btnVisualizar.TabIndex = 74
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 73
        Me.Label16.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(9, 33)
        Me.txtProveedor.MaxLength = 160
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(271, 20)
        Me.txtProveedor.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Calificacion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Rubro"
        '
        'cboCalificacion2
        '
        Me.cboCalificacion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalificacion2.FormattingEnabled = True
        Me.cboCalificacion2.Items.AddRange(New Object() {"", "5 *****", "4 ****", "3 ***", "2 **", "1 *"})
        Me.cboCalificacion2.Location = New System.Drawing.Point(9, 96)
        Me.cboCalificacion2.Name = "cboCalificacion2"
        Me.cboCalificacion2.Size = New System.Drawing.Size(149, 21)
        Me.cboCalificacion2.TabIndex = 30
        '
        'dgvRubro2
        '
        Me.dgvRubro2.AllowUserToAddRows = False
        Me.dgvRubro2.AllowUserToDeleteRows = False
        Me.dgvRubro2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRubro2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RUP_ID2, Me.RUB_ID2, Me.RUB_DESCRIPCION2, Me.Seleccion2})
        Me.dgvRubro2.Location = New System.Drawing.Point(9, 164)
        Me.dgvRubro2.Name = "dgvRubro2"
        Me.dgvRubro2.Size = New System.Drawing.Size(271, 206)
        Me.dgvRubro2.TabIndex = 31
        '
        'dsListaProveedorBindingSource
        '
        Me.dsListaProveedorBindingSource.DataMember = "ListaProveedor"
        Me.dsListaProveedorBindingSource.DataSource = GetType(dsListaProveedor)
        '
        'RUP_ID2
        '
        Me.RUP_ID2.HeaderText = "RUP_ID"
        Me.RUP_ID2.Name = "RUP_ID2"
        Me.RUP_ID2.Visible = False
        '
        'RUB_ID2
        '
        Me.RUB_ID2.HeaderText = "RUB_ID"
        Me.RUB_ID2.Name = "RUB_ID2"
        Me.RUB_ID2.Visible = False
        '
        'RUB_DESCRIPCION2
        '
        Me.RUB_DESCRIPCION2.HeaderText = "Descripcion"
        Me.RUB_DESCRIPCION2.Name = "RUB_DESCRIPCION2"
        Me.RUB_DESCRIPCION2.Width = 150
        '
        'Seleccion2
        '
        Me.Seleccion2.HeaderText = "Seleccion"
        Me.Seleccion2.Name = "Seleccion2"
        Me.Seleccion2.Width = 70
        '
        'frmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(964, 570)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmProveedores"
        Me.Text = "Proveedores"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvRubro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRUC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboCalificacion As System.Windows.Forms.ComboBox
    Friend WithEvents dgvRubro As System.Windows.Forms.DataGridView
    Friend WithEvents dgvContactos As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RUP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUB_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents COP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COP_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COP_DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COP_TELEFONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COP_EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCalificacion2 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvRubro2 As System.Windows.Forms.DataGridView
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents dsListaProveedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUP_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUB_ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUB_DESCRIPCION2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccion2 As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
