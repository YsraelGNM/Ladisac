<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmpTrans = New System.Windows.Forms.TextBox()
        Me.txtMarcaVeh = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.GUD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUD_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNroRemision = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInicioT = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDestinatario = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPuntoPartida = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoMotivo = New System.Windows.Forms.ComboBox()
        Me.txtPlacaVeh = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTransportista = New System.Windows.Forms.TextBox()
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtCertificado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPuntoLlegada = New System.Windows.Forms.TextBox()
        Me.txtPlacaRemolque = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAtajo = New System.Windows.Forms.Button()
        Me.txtSerieRemision = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpFFProcesar = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFIProcesar = New System.Windows.Forms.DateTimePicker()
        Me.dgvProcesar = New System.Windows.Forms.DataGridView()
        Me.GUI_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUI_NRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUI_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PER_APE_PAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_DESCRIPCION_PROCESAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUD_CANTIDAD_PROCESAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROCESO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(865, 28)
        Me.lblTitle.Text = "Guia Remision"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(393, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Transportista"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Emp. Trans"
        '
        'txtEmpTrans
        '
        Me.txtEmpTrans.Location = New System.Drawing.Point(104, 161)
        Me.txtEmpTrans.Name = "txtEmpTrans"
        Me.txtEmpTrans.Size = New System.Drawing.Size(264, 20)
        Me.txtEmpTrans.TabIndex = 117
        '
        'txtMarcaVeh
        '
        Me.txtMarcaVeh.Location = New System.Drawing.Point(104, 214)
        Me.txtMarcaVeh.Name = "txtMarcaVeh"
        Me.txtMarcaVeh.Size = New System.Drawing.Size(77, 20)
        Me.txtMarcaVeh.TabIndex = 113
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(393, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Fec.Ini.Traslado"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUD_ID, Me.ART_Id, Me.GUD_CANTIDAD})
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 251)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(828, 205)
        Me.dgvDetalle.TabIndex = 108
        '
        'GUD_ID
        '
        Me.GUD_ID.HeaderText = "GUD_ID"
        Me.GUD_ID.Name = "GUD_ID"
        Me.GUD_ID.Visible = False
        '
        'ART_Id
        '
        Me.ART_Id.HeaderText = "Cod.Articulo"
        Me.ART_Id.Name = "ART_Id"
        Me.ART_Id.Width = 400
        '
        'GUD_CANTIDAD
        '
        Me.GUD_CANTIDAD.HeaderText = "Cantidad"
        Me.GUD_CANTIDAD.Name = "GUD_CANTIDAD"
        '
        'txtNroRemision
        '
        Me.txtNroRemision.BackColor = System.Drawing.Color.White
        Me.txtNroRemision.Location = New System.Drawing.Point(190, 53)
        Me.txtNroRemision.MaxLength = 25
        Me.txtNroRemision.Name = "txtNroRemision"
        Me.txtNroRemision.ReadOnly = True
        Me.txtNroRemision.Size = New System.Drawing.Size(178, 20)
        Me.txtNroRemision.TabIndex = 107
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Marca Veh."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Nro. Remision"
        '
        'dtpFechaInicioT
        '
        Me.dtpFechaInicioT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioT.Location = New System.Drawing.Point(482, 53)
        Me.dtpFechaInicioT.Name = "dtpFechaInicioT"
        Me.dtpFechaInicioT.Size = New System.Drawing.Size(85, 20)
        Me.dtpFechaInicioT.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(104, 24)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(77, 20)
        Me.txtCodigo.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Destinatario"
        '
        'txtDestinatario
        '
        Me.txtDestinatario.Location = New System.Drawing.Point(104, 106)
        Me.txtDestinatario.Name = "txtDestinatario"
        Me.txtDestinatario.Size = New System.Drawing.Size(264, 20)
        Me.txtDestinatario.TabIndex = 98
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(482, 24)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 121
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Punto Partida"
        '
        'txtPuntoPartida
        '
        Me.txtPuntoPartida.Location = New System.Drawing.Point(104, 79)
        Me.txtPuntoPartida.MaxLength = 150
        Me.txtPuntoPartida.Name = "txtPuntoPartida"
        Me.txtPuntoPartida.Size = New System.Drawing.Size(730, 20)
        Me.txtPuntoPartida.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 218)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Tipo Motivo"
        '
        'cboTipoMotivo
        '
        Me.cboTipoMotivo.FormattingEnabled = True
        Me.cboTipoMotivo.Items.AddRange(New Object() {"Venta", "Compra", "Consignacion", "Devolucion", "Venta sujeta a confirmacion del Comprador", "Traslado entre establecimientos", "Traslado de bienes para transformarlos", "Recojo de bienes transformados", "Traslado por emisor itinerante de comprobante", "Traslado zona primaria", "Importacion", "Exportacion", "Otros", "Transporte Materia Prima"})
        Me.cboTipoMotivo.Location = New System.Drawing.Point(482, 214)
        Me.cboTipoMotivo.Name = "cboTipoMotivo"
        Me.cboTipoMotivo.Size = New System.Drawing.Size(354, 21)
        Me.cboTipoMotivo.TabIndex = 126
        '
        'txtPlacaVeh
        '
        Me.txtPlacaVeh.Location = New System.Drawing.Point(104, 187)
        Me.txtPlacaVeh.Name = "txtPlacaVeh"
        Me.txtPlacaVeh.Size = New System.Drawing.Size(77, 20)
        Me.txtPlacaVeh.TabIndex = 128
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "Placa Veh."
        '
        'txtTransportista
        '
        Me.txtTransportista.Location = New System.Drawing.Point(482, 161)
        Me.txtTransportista.Name = "txtTransportista"
        Me.txtTransportista.Size = New System.Drawing.Size(244, 20)
        Me.txtTransportista.TabIndex = 129
        '
        'txtLicencia
        '
        Me.txtLicencia.Location = New System.Drawing.Point(482, 187)
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(85, 20)
        Me.txtLicencia.TabIndex = 131
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(393, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Licencia"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'txtCertificado
        '
        Me.txtCertificado.Location = New System.Drawing.Point(275, 214)
        Me.txtCertificado.Name = "txtCertificado"
        Me.txtCertificado.Size = New System.Drawing.Size(93, 20)
        Me.txtCertificado.TabIndex = 133
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(187, 218)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 132
        Me.Label13.Text = "Certificado Veh."
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(858, 488)
        Me.TabControl1.TabIndex = 134
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtPuntoLlegada)
        Me.TabPage1.Controls.Add(Me.txtPlacaRemolque)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.btnAtajo)
        Me.TabPage1.Controls.Add(Me.txtSerieRemision)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtCertificado)
        Me.TabPage1.Controls.Add(Me.txtDestinatario)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtLicencia)
        Me.TabPage1.Controls.Add(Me.txtCodigo)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtTransportista)
        Me.TabPage1.Controls.Add(Me.dtpFechaInicioT)
        Me.TabPage1.Controls.Add(Me.txtPlacaVeh)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cboTipoMotivo)
        Me.TabPage1.Controls.Add(Me.txtNroRemision)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.dgvDetalle)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtPuntoPartida)
        Me.TabPage1.Controls.Add(Me.txtMarcaVeh)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Controls.Add(Me.txtEmpTrans)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(850, 462)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "GUIA DE REMISION"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 138)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 139
        Me.Label17.Text = "Punto Llegada"
        '
        'txtPuntoLlegada
        '
        Me.txtPuntoLlegada.Location = New System.Drawing.Point(104, 133)
        Me.txtPuntoLlegada.MaxLength = 150
        Me.txtPuntoLlegada.Name = "txtPuntoLlegada"
        Me.txtPuntoLlegada.Size = New System.Drawing.Size(730, 20)
        Me.txtPuntoLlegada.TabIndex = 138
        '
        'txtPlacaRemolque
        '
        Me.txtPlacaRemolque.Location = New System.Drawing.Point(291, 188)
        Me.txtPlacaRemolque.Name = "txtPlacaRemolque"
        Me.txtPlacaRemolque.Size = New System.Drawing.Size(77, 20)
        Me.txtPlacaRemolque.TabIndex = 137
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(193, 192)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Placa Remolque"
        '
        'btnAtajo
        '
        Me.btnAtajo.Location = New System.Drawing.Point(590, 22)
        Me.btnAtajo.Name = "btnAtajo"
        Me.btnAtajo.Size = New System.Drawing.Size(136, 23)
        Me.btnAtajo.TabIndex = 135
        Me.btnAtajo.Text = "Atajo"
        Me.btnAtajo.UseVisualStyleBackColor = True
        '
        'txtSerieRemision
        '
        Me.txtSerieRemision.BackColor = System.Drawing.Color.White
        Me.txtSerieRemision.Location = New System.Drawing.Point(104, 53)
        Me.txtSerieRemision.MaxLength = 3
        Me.txtSerieRemision.Name = "txtSerieRemision"
        Me.txtSerieRemision.ReadOnly = True
        Me.txtSerieRemision.Size = New System.Drawing.Size(77, 20)
        Me.txtSerieRemision.TabIndex = 134
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnBuscar)
        Me.TabPage2.Controls.Add(Me.btnProcesar)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.dtpFFProcesar)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.dtpFIProcesar)
        Me.TabPage2.Controls.Add(Me.dgvProcesar)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(850, 462)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PROCESAR GUIA DE REMISION"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(401, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 127
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(516, 15)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 126
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "Fecha Inicio"
        '
        'dtpFFProcesar
        '
        Me.dtpFFProcesar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFProcesar.Location = New System.Drawing.Point(279, 18)
        Me.dtpFFProcesar.Name = "dtpFFProcesar"
        Me.dtpFFProcesar.Size = New System.Drawing.Size(85, 20)
        Me.dtpFFProcesar.TabIndex = 123
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(211, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 124
        Me.Label15.Text = "Fecha Final"
        '
        'dtpFIProcesar
        '
        Me.dtpFIProcesar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFIProcesar.Location = New System.Drawing.Point(84, 18)
        Me.dtpFIProcesar.Name = "dtpFIProcesar"
        Me.dtpFIProcesar.Size = New System.Drawing.Size(85, 20)
        Me.dtpFIProcesar.TabIndex = 125
        '
        'dgvProcesar
        '
        Me.dgvProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProcesar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcesar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUI_ID, Me.GUI_NRO, Me.GUI_FECHA, Me.PER_APE_PAT, Me.ART_DESCRIPCION_PROCESAR, Me.GUD_CANTIDAD_PROCESAR, Me.PROCESO})
        Me.dgvProcesar.Location = New System.Drawing.Point(3, 62)
        Me.dgvProcesar.Name = "dgvProcesar"
        Me.dgvProcesar.Size = New System.Drawing.Size(841, 333)
        Me.dgvProcesar.TabIndex = 109
        '
        'GUI_ID
        '
        Me.GUI_ID.HeaderText = "GUI_ID"
        Me.GUI_ID.Name = "GUI_ID"
        Me.GUI_ID.Width = 75
        '
        'GUI_NRO
        '
        Me.GUI_NRO.HeaderText = "NRO"
        Me.GUI_NRO.Name = "GUI_NRO"
        '
        'GUI_FECHA
        '
        Me.GUI_FECHA.HeaderText = "FECHA"
        Me.GUI_FECHA.Name = "GUI_FECHA"
        Me.GUI_FECHA.Width = 75
        '
        'PER_APE_PAT
        '
        Me.PER_APE_PAT.HeaderText = "EMPRESA TRANSPORTE"
        Me.PER_APE_PAT.Name = "PER_APE_PAT"
        Me.PER_APE_PAT.Width = 150
        '
        'ART_DESCRIPCION_PROCESAR
        '
        Me.ART_DESCRIPCION_PROCESAR.HeaderText = "ARTICULO"
        Me.ART_DESCRIPCION_PROCESAR.Name = "ART_DESCRIPCION_PROCESAR"
        Me.ART_DESCRIPCION_PROCESAR.Width = 150
        '
        'GUD_CANTIDAD_PROCESAR
        '
        Me.GUD_CANTIDAD_PROCESAR.HeaderText = "CANTIDAD"
        Me.GUD_CANTIDAD_PROCESAR.Name = "GUD_CANTIDAD_PROCESAR"
        Me.GUD_CANTIDAD_PROCESAR.Width = 75
        '
        'PROCESO
        '
        Me.PROCESO.HeaderText = "PROCESAR"
        Me.PROCESO.Name = "PROCESO"
        Me.PROCESO.Width = 50
        '
        'frmGuiaRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(865, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmGuiaRemision"
        Me.Text = "Guia Remision"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmpTrans As System.Windows.Forms.TextBox
    Friend WithEvents txtMarcaVeh As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtNroRemision As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicioT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPuntoPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents txtPlacaVeh As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTransportista As System.Windows.Forms.TextBox
    Friend WithEvents txtLicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtCertificado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpFFProcesar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpFIProcesar As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvProcesar As System.Windows.Forms.DataGridView
    Friend WithEvents GUI_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUI_NRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUI_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PER_APE_PAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_DESCRIPCION_PROCESAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUD_CANTIDAD_PROCESAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtSerieRemision As System.Windows.Forms.TextBox
    Friend WithEvents btnAtajo As System.Windows.Forms.Button
    Friend WithEvents GUD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUD_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPlacaRemolque As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPuntoLlegada As System.Windows.Forms.TextBox

End Class
