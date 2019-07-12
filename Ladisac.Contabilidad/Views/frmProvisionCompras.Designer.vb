Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmProvisionCompras
        Inherits Views.ViewManMasterContabilidad

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
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label33 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Label37 = New System.Windows.Forms.Label()
            Me.Label36 = New System.Windows.Forms.Label()
            Me.Label34 = New System.Windows.Forms.Label()
            Me.txtPorDistribuir = New System.Windows.Forms.TextBox()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.Label35 = New System.Windows.Forms.Label()
            Me.txtSaldoXDistribuir = New System.Windows.Forms.TextBox()
            Me.txtTotalADistribuir = New System.Windows.Forms.TextBox()
            Me.txtDistribucionGuias = New System.Windows.Forms.TextBox()
            Me.Label32 = New System.Windows.Forms.Label()
            Me.txtDistribucionAfectacion = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtTotalDocumento = New System.Windows.Forms.TextBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.txtOtrosTributos = New System.Windows.Forms.TextBox()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.txtImporteISC = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtAdvalore = New System.Windows.Forms.TextBox()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.txtValorCIF = New System.Windows.Forms.TextBox()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.txtPercepcion = New System.Windows.Forms.TextBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtDescuento = New System.Windows.Forms.TextBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.txtIGV = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtNoGrvado = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.txtBaseImponible = New System.Windows.Forms.TextBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.btnMoneda = New System.Windows.Forms.Button()
            Me.txtMoneda = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.prd_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cls_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cuc_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cta = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.prd_Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cco_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.CentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Glosa = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Almacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.CambiarCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.dgvguias = New System.Windows.Forms.DataGridView()
            Me.cct_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tdo_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dtd_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_ContraValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.rep_EsLogistica = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.dgvNotaCredito = New System.Windows.Forms.DataGridView()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.ItemDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblDocuMovimiento = New System.Windows.Forms.Label()
            Me.lblOrdenServicio = New System.Windows.Forms.Label()
            Me.lblCuentaRendirDetalle = New System.Windows.Forms.Label()
            Me.lblRendicionGastos = New System.Windows.Forms.Label()
            Me.lblOrdenTrabajo = New System.Windows.Forms.Label()
            Me.Label40 = New System.Windows.Forms.Label()
            Me.txtAnioDua = New System.Windows.Forms.TextBox()
            Me.txtSerieSunat = New System.Windows.Forms.TextBox()
            Me.btnBorarReparable = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtReparable = New System.Windows.Forms.TextBox()
            Me.Label39 = New System.Windows.Forms.Label()
            Me.btnResponsable = New System.Windows.Forms.Button()
            Me.txtResponsable = New System.Windows.Forms.TextBox()
            Me.Label38 = New System.Windows.Forms.Label()
            Me.txtFechaVencimiento = New System.Windows.Forms.MaskedTextBox()
            Me.dateFechaVoucher = New System.Windows.Forms.MaskedTextBox()
            Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
            Me.chkRetenerTercera = New System.Windows.Forms.CheckBox()
            Me.btnTipoVenta = New System.Windows.Forms.Button()
            Me.txtTipoVenta = New System.Windows.Forms.TextBox()
            Me.chkRetencion4ta = New System.Windows.Forms.CheckBox()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.btnCentroCosto = New System.Windows.Forms.Button()
            Me.txtcentroCosto = New System.Windows.Forms.TextBox()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.btnAgencia = New System.Windows.Forms.Button()
            Me.txtPuntoVenta = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnCompras = New System.Windows.Forms.Button()
            Me.txtCompras = New System.Windows.Forms.TextBox()
            Me.txtTipoDocumento = New System.Windows.Forms.TextBox()
            Me.txtCuentaCorriente = New System.Windows.Forms.TextBox()
            Me.txtglosa = New System.Windows.Forms.TextBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.btnTipoDetraccion = New System.Windows.Forms.Button()
            Me.btnOperacion = New System.Windows.Forms.Button()
            Me.txtTipoDetraccion = New System.Windows.Forms.TextBox()
            Me.txtOperacionDetraccion = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtFechaSPOT = New System.Windows.Forms.MaskedTextBox()
            Me.txtNumeroSPOT = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.chkAfectoSPOT = New System.Windows.Forms.CheckBox()
            Me.btnCPOriginal = New System.Windows.Forms.Button()
            Me.txtCPNumero = New System.Windows.Forms.TextBox()
            Me.txtCPSerie = New System.Windows.Forms.TextBox()
            Me.txtCPOriginal = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtDua = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtRuc = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.btnComprobante = New System.Windows.Forms.Button()
            Me.txtCombrobante = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtVoucher = New System.Windows.Forms.TextBox()
            Me.btnLibro = New System.Windows.Forms.Button()
            Me.txtLibro = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.dgvguias, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            CType(Me.dgvNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(817, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label33)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(808, 488)
            Me.Panel1.TabIndex = 2
            '
            'Label33
            '
            Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label33.Location = New System.Drawing.Point(10, 467)
            Me.Label33.Name = "Label33"
            Me.Label33.Size = New System.Drawing.Size(791, 17)
            Me.Label33.TabIndex = 3
            Me.Label33.Text = "Teclas Rapidas : F2 Buscar     F3 Nuevo    F4  Editar    F5 Eliminar    F6 Guarda" & _
                "r    F7 Deshacer"
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.Panel4)
            Me.Panel3.Controls.Add(Me.txtDistribucionGuias)
            Me.Panel3.Controls.Add(Me.Label32)
            Me.Panel3.Controls.Add(Me.txtDistribucionAfectacion)
            Me.Panel3.Controls.Add(Me.Label12)
            Me.Panel3.Controls.Add(Me.txtTotalDocumento)
            Me.Panel3.Controls.Add(Me.Label27)
            Me.Panel3.Location = New System.Drawing.Point(9, 423)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(792, 41)
            Me.Panel3.TabIndex = 2
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.SystemColors.Control
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.Add(Me.Label37)
            Me.Panel4.Controls.Add(Me.Label36)
            Me.Panel4.Controls.Add(Me.Label34)
            Me.Panel4.Controls.Add(Me.txtPorDistribuir)
            Me.Panel4.Controls.Add(Me.Label28)
            Me.Panel4.Controls.Add(Me.Label35)
            Me.Panel4.Controls.Add(Me.txtSaldoXDistribuir)
            Me.Panel4.Controls.Add(Me.txtTotalADistribuir)
            Me.Panel4.Location = New System.Drawing.Point(176, -1)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(353, 40)
            Me.Panel4.TabIndex = 12
            '
            'Label37
            '
            Me.Label37.AutoSize = True
            Me.Label37.Location = New System.Drawing.Point(235, 17)
            Me.Label37.Name = "Label37"
            Me.Label37.Size = New System.Drawing.Size(19, 13)
            Me.Label37.TabIndex = 13
            Me.Label37.Text = "=>"
            Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label36
            '
            Me.Label36.AutoSize = True
            Me.Label36.Location = New System.Drawing.Point(114, 17)
            Me.Label36.Name = "Label36"
            Me.Label36.Size = New System.Drawing.Size(13, 13)
            Me.Label36.TabIndex = 12
            Me.Label36.Text = "--"
            '
            'Label34
            '
            Me.Label34.AutoSize = True
            Me.Label34.Location = New System.Drawing.Point(23, 1)
            Me.Label34.Name = "Label34"
            Me.Label34.Size = New System.Drawing.Size(74, 13)
            Me.Label34.TabIndex = 8
            Me.Label34.Text = "Total Distribuir"
            '
            'txtPorDistribuir
            '
            Me.txtPorDistribuir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPorDistribuir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.txtPorDistribuir.Location = New System.Drawing.Point(254, 14)
            Me.txtPorDistribuir.Name = "txtPorDistribuir"
            Me.txtPorDistribuir.ReadOnly = True
            Me.txtPorDistribuir.Size = New System.Drawing.Size(89, 20)
            Me.txtPorDistribuir.TabIndex = 11
            '
            'Label28
            '
            Me.Label28.AutoSize = True
            Me.Label28.Location = New System.Drawing.Point(129, 1)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(107, 13)
            Me.Label28.TabIndex = 2
            Me.Label28.Text = "Distribucion Contable"
            '
            'Label35
            '
            Me.Label35.AutoSize = True
            Me.Label35.Location = New System.Drawing.Point(261, 0)
            Me.Label35.Name = "Label35"
            Me.Label35.Size = New System.Drawing.Size(66, 13)
            Me.Label35.TabIndex = 10
            Me.Label35.Text = "Por Distribuir"
            '
            'txtSaldoXDistribuir
            '
            Me.txtSaldoXDistribuir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSaldoXDistribuir.Location = New System.Drawing.Point(129, 14)
            Me.txtSaldoXDistribuir.Name = "txtSaldoXDistribuir"
            Me.txtSaldoXDistribuir.ReadOnly = True
            Me.txtSaldoXDistribuir.Size = New System.Drawing.Size(104, 20)
            Me.txtSaldoXDistribuir.TabIndex = 3
            '
            'txtTotalADistribuir
            '
            Me.txtTotalADistribuir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTotalADistribuir.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.txtTotalADistribuir.Location = New System.Drawing.Point(10, 14)
            Me.txtTotalADistribuir.Name = "txtTotalADistribuir"
            Me.txtTotalADistribuir.ReadOnly = True
            Me.txtTotalADistribuir.Size = New System.Drawing.Size(98, 20)
            Me.txtTotalADistribuir.TabIndex = 9
            '
            'txtDistribucionGuias
            '
            Me.txtDistribucionGuias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDistribucionGuias.Location = New System.Drawing.Point(583, 16)
            Me.txtDistribucionGuias.Name = "txtDistribucionGuias"
            Me.txtDistribucionGuias.ReadOnly = True
            Me.txtDistribucionGuias.Size = New System.Drawing.Size(89, 20)
            Me.txtDistribucionGuias.TabIndex = 7
            '
            'Label32
            '
            Me.Label32.AutoSize = True
            Me.Label32.Location = New System.Drawing.Point(580, 2)
            Me.Label32.Name = "Label32"
            Me.Label32.Size = New System.Drawing.Size(92, 13)
            Me.Label32.TabIndex = 6
            Me.Label32.Text = "Distribucion Guias"
            '
            'txtDistribucionAfectacion
            '
            Me.txtDistribucionAfectacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDistribucionAfectacion.Location = New System.Drawing.Point(690, 16)
            Me.txtDistribucionAfectacion.Name = "txtDistribucionAfectacion"
            Me.txtDistribucionAfectacion.ReadOnly = True
            Me.txtDistribucionAfectacion.Size = New System.Drawing.Size(92, 20)
            Me.txtDistribucionAfectacion.TabIndex = 5
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(697, 1)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(69, 13)
            Me.Label12.TabIndex = 4
            Me.Label12.Text = "Afectaciones"
            '
            'txtTotalDocumento
            '
            Me.txtTotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTotalDocumento.Location = New System.Drawing.Point(22, 16)
            Me.txtTotalDocumento.Name = "txtTotalDocumento"
            Me.txtTotalDocumento.ReadOnly = True
            Me.txtTotalDocumento.Size = New System.Drawing.Size(95, 20)
            Me.txtTotalDocumento.TabIndex = 1
            '
            'Label27
            '
            Me.Label27.AutoSize = True
            Me.Label27.Location = New System.Drawing.Point(23, 2)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(89, 13)
            Me.Label27.TabIndex = 0
            Me.Label27.Text = "Total Documento"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Location = New System.Drawing.Point(9, 218)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(792, 201)
            Me.TabControl1.TabIndex = 2
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.txtOtrosTributos)
            Me.TabPage1.Controls.Add(Me.Label31)
            Me.TabPage1.Controls.Add(Me.txtImporteISC)
            Me.TabPage1.Controls.Add(Me.Label14)
            Me.TabPage1.Controls.Add(Me.txtAdvalore)
            Me.TabPage1.Controls.Add(Me.Label26)
            Me.TabPage1.Controls.Add(Me.txtValorCIF)
            Me.TabPage1.Controls.Add(Me.Label25)
            Me.TabPage1.Controls.Add(Me.txtPercepcion)
            Me.TabPage1.Controls.Add(Me.Label24)
            Me.TabPage1.Controls.Add(Me.txtDescuento)
            Me.TabPage1.Controls.Add(Me.Label23)
            Me.TabPage1.Controls.Add(Me.txtIGV)
            Me.TabPage1.Controls.Add(Me.Label22)
            Me.TabPage1.Controls.Add(Me.txtNoGrvado)
            Me.TabPage1.Controls.Add(Me.Label21)
            Me.TabPage1.Controls.Add(Me.Label20)
            Me.TabPage1.Controls.Add(Me.txtBaseImponible)
            Me.TabPage1.Controls.Add(Me.Label19)
            Me.TabPage1.Controls.Add(Me.txtTotal)
            Me.TabPage1.Controls.Add(Me.btnMoneda)
            Me.TabPage1.Controls.Add(Me.txtMoneda)
            Me.TabPage1.Controls.Add(Me.Label18)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(784, 175)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "General"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'txtOtrosTributos
            '
            Me.txtOtrosTributos.Location = New System.Drawing.Point(255, 54)
            Me.txtOtrosTributos.Name = "txtOtrosTributos"
            Me.txtOtrosTributos.Size = New System.Drawing.Size(100, 20)
            Me.txtOtrosTributos.TabIndex = 22
            Me.txtOtrosTributos.Text = "0.00"
            '
            'Label31
            '
            Me.Label31.AutoSize = True
            Me.Label31.Location = New System.Drawing.Point(178, 57)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(73, 13)
            Me.Label31.TabIndex = 23
            Me.Label31.Text = "Otros Tributos"
            '
            'txtImporteISC
            '
            Me.txtImporteISC.Location = New System.Drawing.Point(462, 54)
            Me.txtImporteISC.Name = "txtImporteISC"
            Me.txtImporteISC.Size = New System.Drawing.Size(100, 20)
            Me.txtImporteISC.TabIndex = 21
            Me.txtImporteISC.Text = "0.00"
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(396, 57)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(62, 13)
            Me.Label14.TabIndex = 20
            Me.Label14.Text = "Importe ISC"
            '
            'txtAdvalore
            '
            Me.txtAdvalore.Location = New System.Drawing.Point(67, 77)
            Me.txtAdvalore.Name = "txtAdvalore"
            Me.txtAdvalore.Size = New System.Drawing.Size(100, 20)
            Me.txtAdvalore.TabIndex = 19
            Me.txtAdvalore.Text = "0.00"
            '
            'Label26
            '
            Me.Label26.AutoSize = True
            Me.Label26.Location = New System.Drawing.Point(4, 80)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(57, 13)
            Me.Label26.TabIndex = 18
            Me.Label26.Text = "Advalorem"
            '
            'txtValorCIF
            '
            Me.txtValorCIF.Location = New System.Drawing.Point(67, 54)
            Me.txtValorCIF.Name = "txtValorCIF"
            Me.txtValorCIF.Size = New System.Drawing.Size(100, 20)
            Me.txtValorCIF.TabIndex = 17
            Me.txtValorCIF.Text = "0.00"
            '
            'Label25
            '
            Me.Label25.AutoSize = True
            Me.Label25.Location = New System.Drawing.Point(11, 57)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(50, 13)
            Me.Label25.TabIndex = 16
            Me.Label25.Text = "Valor CIF"
            '
            'txtPercepcion
            '
            Me.txtPercepcion.Location = New System.Drawing.Point(671, 8)
            Me.txtPercepcion.Name = "txtPercepcion"
            Me.txtPercepcion.Size = New System.Drawing.Size(100, 20)
            Me.txtPercepcion.TabIndex = 4
            Me.txtPercepcion.Text = "0.00"
            '
            'Label24
            '
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(594, 11)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(61, 13)
            Me.Label24.TabIndex = 13
            Me.Label24.Text = "Percepcion"
            '
            'txtDescuento
            '
            Me.txtDescuento.Location = New System.Drawing.Point(462, 31)
            Me.txtDescuento.Name = "txtDescuento"
            Me.txtDescuento.Size = New System.Drawing.Size(100, 20)
            Me.txtDescuento.TabIndex = 12
            Me.txtDescuento.Text = "0.00"
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Location = New System.Drawing.Point(376, 34)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(82, 13)
            Me.Label23.TabIndex = 11
            Me.Label23.Text = "Descuento Obt."
            '
            'txtIGV
            '
            Me.txtIGV.Location = New System.Drawing.Point(462, 8)
            Me.txtIGV.Name = "txtIGV"
            Me.txtIGV.Size = New System.Drawing.Size(100, 20)
            Me.txtIGV.TabIndex = 2
            Me.txtIGV.Text = "0.00"
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(394, 11)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(64, 13)
            Me.Label22.TabIndex = 9
            Me.Label22.Text = "          I.G.V."
            '
            'txtNoGrvado
            '
            Me.txtNoGrvado.Location = New System.Drawing.Point(255, 31)
            Me.txtNoGrvado.Name = "txtNoGrvado"
            Me.txtNoGrvado.Size = New System.Drawing.Size(100, 20)
            Me.txtNoGrvado.TabIndex = 3
            Me.txtNoGrvado.Text = "0.00"
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(186, 34)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(65, 13)
            Me.Label21.TabIndex = 7
            Me.Label21.Text = "No Gravado"
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(211, 11)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(40, 13)
            Me.Label20.TabIndex = 6
            Me.Label20.Text = "Base I."
            '
            'txtBaseImponible
            '
            Me.txtBaseImponible.Location = New System.Drawing.Point(255, 8)
            Me.txtBaseImponible.Name = "txtBaseImponible"
            Me.txtBaseImponible.Size = New System.Drawing.Size(100, 20)
            Me.txtBaseImponible.TabIndex = 3
            Me.txtBaseImponible.Text = "0.00"
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(30, 34)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(31, 13)
            Me.Label19.TabIndex = 4
            Me.Label19.Text = "Total"
            '
            'txtTotal
            '
            Me.txtTotal.Enabled = False
            Me.txtTotal.Location = New System.Drawing.Point(67, 31)
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.ReadOnly = True
            Me.txtTotal.Size = New System.Drawing.Size(76, 20)
            Me.txtTotal.TabIndex = 3
            Me.txtTotal.Text = "0.00"
            '
            'btnMoneda
            '
            Me.btnMoneda.Location = New System.Drawing.Point(149, 6)
            Me.btnMoneda.Name = "btnMoneda"
            Me.btnMoneda.Size = New System.Drawing.Size(28, 23)
            Me.btnMoneda.TabIndex = 0
            Me.btnMoneda.Text = ":::"
            Me.btnMoneda.UseVisualStyleBackColor = True
            '
            'txtMoneda
            '
            Me.txtMoneda.Enabled = False
            Me.txtMoneda.Location = New System.Drawing.Point(67, 8)
            Me.txtMoneda.Name = "txtMoneda"
            Me.txtMoneda.ReadOnly = True
            Me.txtMoneda.Size = New System.Drawing.Size(76, 20)
            Me.txtMoneda.TabIndex = 9
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(15, 11)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(46, 13)
            Me.Label18.TabIndex = 10
            Me.Label18.Text = "Moneda"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.dgvDetalle)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(784, 175)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Contabilidad"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prd_Item, Me.cls_Id, Me.cuc_Id, Me.cta, Me.Cuenta, Me.prd_Importe, Me.cco_Id, Me.CentroCosto, Me.Glosa, Me.ALM_ID, Me.Almacen})
            Me.dgvDetalle.ContextMenuStrip = Me.ContextMenuStrip1
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDetalle.Location = New System.Drawing.Point(7, 7)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(771, 165)
            Me.dgvDetalle.TabIndex = 0
            '
            'prd_Item
            '
            Me.prd_Item.HeaderText = "prd_Item"
            Me.prd_Item.Name = "prd_Item"
            Me.prd_Item.Visible = False
            '
            'cls_Id
            '
            Me.cls_Id.HeaderText = "cls_Id"
            Me.cls_Id.Name = "cls_Id"
            Me.cls_Id.Visible = False
            '
            'cuc_Id
            '
            Me.cuc_Id.HeaderText = "Cta.Contable"
            Me.cuc_Id.Name = "cuc_Id"
            '
            'cta
            '
            Me.cta.HeaderText = "cta"
            Me.cta.Name = "cta"
            Me.cta.Width = 30
            '
            'Cuenta
            '
            Me.Cuenta.HeaderText = "Cuenta"
            Me.Cuenta.Name = "Cuenta"
            Me.Cuenta.ReadOnly = True
            '
            'prd_Importe
            '
            Me.prd_Importe.HeaderText = "Importe"
            Me.prd_Importe.Name = "prd_Importe"
            '
            'cco_Id
            '
            Me.cco_Id.HeaderText = "cco_Id"
            Me.cco_Id.Name = "cco_Id"
            Me.cco_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cco_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cco_Id.Width = 20
            '
            'CentroCosto
            '
            Me.CentroCosto.HeaderText = "CentroCosto"
            Me.CentroCosto.Name = "CentroCosto"
            Me.CentroCosto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'Glosa
            '
            Me.Glosa.HeaderText = "Glosa"
            Me.Glosa.Name = "Glosa"
            Me.Glosa.Width = 120
            '
            'ALM_ID
            '
            Me.ALM_ID.HeaderText = "ALM_ID"
            Me.ALM_ID.Name = "ALM_ID"
            Me.ALM_ID.Visible = False
            '
            'Almacen
            '
            Me.Almacen.HeaderText = "Almacen"
            Me.Almacen.Name = "Almacen"
            Me.Almacen.ReadOnly = True
            Me.Almacen.Width = 160
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiarCuentaToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 26)
            '
            'CambiarCuentaToolStripMenuItem
            '
            Me.CambiarCuentaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1})
            Me.CambiarCuentaToolStripMenuItem.Name = "CambiarCuentaToolStripMenuItem"
            Me.CambiarCuentaToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
            Me.CambiarCuentaToolStripMenuItem.Text = "Cambiar Cuenta"
            '
            'ToolStripTextBox1
            '
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
            Me.ToolStripTextBox1.Text = "9999"
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.dgvguias)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(784, 175)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Guias"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'dgvguias
            '
            Me.dgvguias.AllowUserToAddRows = False
            Me.dgvguias.AllowUserToDeleteRows = False
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvguias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dgvguias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvguias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cct_Id, Me.tdo_Id, Me.dtd_Id, Me.rep_Item, Me.rep_Serie, Me.rep_Numero, Me.rep_Importe, Me.rep_ContraValor, Me.rep_EsLogistica})
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvguias.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvguias.Location = New System.Drawing.Point(7, 7)
            Me.dgvguias.Name = "dgvguias"
            Me.dgvguias.ReadOnly = True
            Me.dgvguias.Size = New System.Drawing.Size(771, 170)
            Me.dgvguias.TabIndex = 0
            '
            'cct_Id
            '
            Me.cct_Id.HeaderText = "cct_Id"
            Me.cct_Id.Name = "cct_Id"
            Me.cct_Id.ReadOnly = True
            Me.cct_Id.Visible = False
            '
            'tdo_Id
            '
            Me.tdo_Id.HeaderText = "tdo_Id"
            Me.tdo_Id.Name = "tdo_Id"
            Me.tdo_Id.ReadOnly = True
            Me.tdo_Id.Visible = False
            '
            'dtd_Id
            '
            Me.dtd_Id.HeaderText = "dtd_Id"
            Me.dtd_Id.Name = "dtd_Id"
            Me.dtd_Id.ReadOnly = True
            Me.dtd_Id.Visible = False
            '
            'rep_Item
            '
            Me.rep_Item.HeaderText = "Item"
            Me.rep_Item.Name = "rep_Item"
            Me.rep_Item.ReadOnly = True
            '
            'rep_Serie
            '
            Me.rep_Serie.HeaderText = "Serie"
            Me.rep_Serie.Name = "rep_Serie"
            Me.rep_Serie.ReadOnly = True
            '
            'rep_Numero
            '
            Me.rep_Numero.HeaderText = "Numero"
            Me.rep_Numero.Name = "rep_Numero"
            Me.rep_Numero.ReadOnly = True
            '
            'rep_Importe
            '
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.rep_Importe.DefaultCellStyle = DataGridViewCellStyle4
            Me.rep_Importe.HeaderText = "Importe"
            Me.rep_Importe.Name = "rep_Importe"
            Me.rep_Importe.ReadOnly = True
            '
            'rep_ContraValor
            '
            Me.rep_ContraValor.HeaderText = "Contra Valor"
            Me.rep_ContraValor.Name = "rep_ContraValor"
            Me.rep_ContraValor.ReadOnly = True
            Me.rep_ContraValor.Visible = False
            '
            'rep_EsLogistica
            '
            Me.rep_EsLogistica.HeaderText = "rep_EsLogistica"
            Me.rep_EsLogistica.Name = "rep_EsLogistica"
            Me.rep_EsLogistica.ReadOnly = True
            Me.rep_EsLogistica.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.rep_EsLogistica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.rep_EsLogistica.Visible = False
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.dgvNotaCredito)
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(784, 175)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Notas de Credito/Leasing"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'dgvNotaCredito
            '
            Me.dgvNotaCredito.AllowUserToAddRows = False
            Me.dgvNotaCredito.AllowUserToDeleteRows = False
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotaCredito.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
            Me.dgvNotaCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvNotaCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewCheckBoxColumn1, Me.ItemDoc})
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvNotaCredito.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvNotaCredito.Location = New System.Drawing.Point(7, 7)
            Me.dgvNotaCredito.Name = "dgvNotaCredito"
            Me.dgvNotaCredito.Size = New System.Drawing.Size(771, 170)
            Me.dgvNotaCredito.TabIndex = 2
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "cct_Id"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "tdo_Id"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "dtd_Id"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "rep_Item"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'Column1
            '
            Me.Column1.HeaderText = "Descripcion"
            Me.Column1.Name = "Column1"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "rep_Serie"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "rep_Numero"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn7
            '
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewTextBoxColumn7.HeaderText = "rep_Importe"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "rep_ContraValor"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            '
            'DataGridViewCheckBoxColumn1
            '
            Me.DataGridViewCheckBoxColumn1.HeaderText = "rep_EsLogistica"
            Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
            Me.DataGridViewCheckBoxColumn1.ReadOnly = True
            Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.DataGridViewCheckBoxColumn1.Visible = False
            '
            'ItemDoc
            '
            Me.ItemDoc.HeaderText = "ItemDoc"
            Me.ItemDoc.Name = "ItemDoc"
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.lblDocuMovimiento)
            Me.Panel2.Controls.Add(Me.lblOrdenServicio)
            Me.Panel2.Controls.Add(Me.lblCuentaRendirDetalle)
            Me.Panel2.Controls.Add(Me.lblRendicionGastos)
            Me.Panel2.Controls.Add(Me.lblOrdenTrabajo)
            Me.Panel2.Controls.Add(Me.Label40)
            Me.Panel2.Controls.Add(Me.txtAnioDua)
            Me.Panel2.Controls.Add(Me.txtSerieSunat)
            Me.Panel2.Controls.Add(Me.btnBorarReparable)
            Me.Panel2.Controls.Add(Me.Button1)
            Me.Panel2.Controls.Add(Me.txtReparable)
            Me.Panel2.Controls.Add(Me.Label39)
            Me.Panel2.Controls.Add(Me.btnResponsable)
            Me.Panel2.Controls.Add(Me.txtResponsable)
            Me.Panel2.Controls.Add(Me.Label38)
            Me.Panel2.Controls.Add(Me.txtFechaVencimiento)
            Me.Panel2.Controls.Add(Me.dateFechaVoucher)
            Me.Panel2.Controls.Add(Me.txtFecha)
            Me.Panel2.Controls.Add(Me.chkRetenerTercera)
            Me.Panel2.Controls.Add(Me.btnTipoVenta)
            Me.Panel2.Controls.Add(Me.txtTipoVenta)
            Me.Panel2.Controls.Add(Me.chkRetencion4ta)
            Me.Panel2.Controls.Add(Me.Label30)
            Me.Panel2.Controls.Add(Me.btnCentroCosto)
            Me.Panel2.Controls.Add(Me.txtcentroCosto)
            Me.Panel2.Controls.Add(Me.Label29)
            Me.Panel2.Controls.Add(Me.btnAgencia)
            Me.Panel2.Controls.Add(Me.txtPuntoVenta)
            Me.Panel2.Controls.Add(Me.Label8)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.btnCompras)
            Me.Panel2.Controls.Add(Me.txtCompras)
            Me.Panel2.Controls.Add(Me.txtTipoDocumento)
            Me.Panel2.Controls.Add(Me.txtCuentaCorriente)
            Me.Panel2.Controls.Add(Me.txtglosa)
            Me.Panel2.Controls.Add(Me.Label17)
            Me.Panel2.Controls.Add(Me.btnTipoDetraccion)
            Me.Panel2.Controls.Add(Me.btnOperacion)
            Me.Panel2.Controls.Add(Me.txtTipoDetraccion)
            Me.Panel2.Controls.Add(Me.txtOperacionDetraccion)
            Me.Panel2.Controls.Add(Me.Label16)
            Me.Panel2.Controls.Add(Me.txtFechaSPOT)
            Me.Panel2.Controls.Add(Me.txtNumeroSPOT)
            Me.Panel2.Controls.Add(Me.Label15)
            Me.Panel2.Controls.Add(Me.chkAfectoSPOT)
            Me.Panel2.Controls.Add(Me.btnCPOriginal)
            Me.Panel2.Controls.Add(Me.txtCPNumero)
            Me.Panel2.Controls.Add(Me.txtCPSerie)
            Me.Panel2.Controls.Add(Me.txtCPOriginal)
            Me.Panel2.Controls.Add(Me.Label13)
            Me.Panel2.Controls.Add(Me.Label11)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.txtDua)
            Me.Panel2.Controls.Add(Me.Label9)
            Me.Panel2.Controls.Add(Me.txtRuc)
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.txtSerie)
            Me.Panel2.Controls.Add(Me.btnComprobante)
            Me.Panel2.Controls.Add(Me.txtCombrobante)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.btnPersona)
            Me.Panel2.Controls.Add(Me.txtPersona)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.txtVoucher)
            Me.Panel2.Controls.Add(Me.btnLibro)
            Me.Panel2.Controls.Add(Me.txtLibro)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Location = New System.Drawing.Point(9, 5)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(792, 210)
            Me.Panel2.TabIndex = 0
            '
            'lblDocuMovimiento
            '
            Me.lblDocuMovimiento.AutoSize = True
            Me.lblDocuMovimiento.Location = New System.Drawing.Point(731, 18)
            Me.lblDocuMovimiento.Name = "lblDocuMovimiento"
            Me.lblDocuMovimiento.Size = New System.Drawing.Size(25, 13)
            Me.lblDocuMovimiento.TabIndex = 83
            Me.lblDocuMovimiento.Text = "......"
            '
            'lblOrdenServicio
            '
            Me.lblOrdenServicio.AutoSize = True
            Me.lblOrdenServicio.Location = New System.Drawing.Point(731, 4)
            Me.lblOrdenServicio.Name = "lblOrdenServicio"
            Me.lblOrdenServicio.Size = New System.Drawing.Size(25, 13)
            Me.lblOrdenServicio.TabIndex = 82
            Me.lblOrdenServicio.Text = "......"
            '
            'lblCuentaRendirDetalle
            '
            Me.lblCuentaRendirDetalle.AutoSize = True
            Me.lblCuentaRendirDetalle.Location = New System.Drawing.Point(695, 4)
            Me.lblCuentaRendirDetalle.Name = "lblCuentaRendirDetalle"
            Me.lblCuentaRendirDetalle.Size = New System.Drawing.Size(25, 13)
            Me.lblCuentaRendirDetalle.TabIndex = 81
            Me.lblCuentaRendirDetalle.Text = "......"
            '
            'lblRendicionGastos
            '
            Me.lblRendicionGastos.AutoSize = True
            Me.lblRendicionGastos.Location = New System.Drawing.Point(695, 18)
            Me.lblRendicionGastos.Name = "lblRendicionGastos"
            Me.lblRendicionGastos.Size = New System.Drawing.Size(25, 13)
            Me.lblRendicionGastos.TabIndex = 80
            Me.lblRendicionGastos.Text = "......"
            '
            'lblOrdenTrabajo
            '
            Me.lblOrdenTrabajo.AutoSize = True
            Me.lblOrdenTrabajo.Location = New System.Drawing.Point(695, 31)
            Me.lblOrdenTrabajo.Name = "lblOrdenTrabajo"
            Me.lblOrdenTrabajo.Size = New System.Drawing.Size(25, 13)
            Me.lblOrdenTrabajo.TabIndex = 79
            Me.lblOrdenTrabajo.Text = "......"
            '
            'Label40
            '
            Me.Label40.AutoSize = True
            Me.Label40.Location = New System.Drawing.Point(691, 51)
            Me.Label40.Name = "Label40"
            Me.Label40.Size = New System.Drawing.Size(52, 13)
            Me.Label40.TabIndex = 78
            Me.Label40.Text = "Año DUA"
            '
            'txtAnioDua
            '
            Me.txtAnioDua.Location = New System.Drawing.Point(743, 48)
            Me.txtAnioDua.MaxLength = 4
            Me.txtAnioDua.Name = "txtAnioDua"
            Me.txtAnioDua.Size = New System.Drawing.Size(55, 20)
            Me.txtAnioDua.TabIndex = 77
            '
            'txtSerieSunat
            '
            Me.txtSerieSunat.Location = New System.Drawing.Point(356, 48)
            Me.txtSerieSunat.MaxLength = 4
            Me.txtSerieSunat.Name = "txtSerieSunat"
            Me.txtSerieSunat.Size = New System.Drawing.Size(57, 20)
            Me.txtSerieSunat.TabIndex = 76
            '
            'btnBorarReparable
            '
            Me.btnBorarReparable.Location = New System.Drawing.Point(501, 183)
            Me.btnBorarReparable.Name = "btnBorarReparable"
            Me.btnBorarReparable.Size = New System.Drawing.Size(28, 23)
            Me.btnBorarReparable.TabIndex = 75
            Me.btnBorarReparable.Text = "cls"
            Me.ToolTip1.SetToolTip(Me.btnBorarReparable, "Borrar Reparable")
            Me.btnBorarReparable.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(473, 182)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(28, 23)
            Me.Button1.TabIndex = 72
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'txtReparable
            '
            Me.txtReparable.Enabled = False
            Me.txtReparable.Location = New System.Drawing.Point(338, 183)
            Me.txtReparable.Name = "txtReparable"
            Me.txtReparable.ReadOnly = True
            Me.txtReparable.Size = New System.Drawing.Size(130, 20)
            Me.txtReparable.TabIndex = 74
            '
            'Label39
            '
            Me.Label39.AutoSize = True
            Me.Label39.Location = New System.Drawing.Point(283, 185)
            Me.Label39.Name = "Label39"
            Me.Label39.Size = New System.Drawing.Size(56, 13)
            Me.Label39.TabIndex = 73
            Me.Label39.Text = "Reparable"
            '
            'btnResponsable
            '
            Me.btnResponsable.Location = New System.Drawing.Point(760, 158)
            Me.btnResponsable.Name = "btnResponsable"
            Me.btnResponsable.Size = New System.Drawing.Size(28, 23)
            Me.btnResponsable.TabIndex = 69
            Me.btnResponsable.Text = ":::"
            Me.btnResponsable.UseVisualStyleBackColor = True
            '
            'txtResponsable
            '
            Me.txtResponsable.Enabled = False
            Me.txtResponsable.Location = New System.Drawing.Point(591, 159)
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.ReadOnly = True
            Me.txtResponsable.Size = New System.Drawing.Size(165, 20)
            Me.txtResponsable.TabIndex = 71
            '
            'Label38
            '
            Me.Label38.AutoSize = True
            Me.Label38.Location = New System.Drawing.Point(513, 163)
            Me.Label38.Name = "Label38"
            Me.Label38.Size = New System.Drawing.Size(72, 13)
            Me.Label38.TabIndex = 70
            Me.Label38.Text = "Responsable "
            '
            'txtFechaVencimiento
            '
            Me.txtFechaVencimiento.Location = New System.Drawing.Point(417, 90)
            Me.txtFechaVencimiento.Mask = "00/00/0000"
            Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
            Me.txtFechaVencimiento.Size = New System.Drawing.Size(83, 20)
            Me.txtFechaVencimiento.TabIndex = 68
            Me.txtFechaVencimiento.ValidatingType = GetType(Date)
            '
            'dateFechaVoucher
            '
            Me.dateFechaVoucher.Location = New System.Drawing.Point(591, 3)
            Me.dateFechaVoucher.Mask = "00/00/0000"
            Me.dateFechaVoucher.Name = "dateFechaVoucher"
            Me.dateFechaVoucher.Size = New System.Drawing.Size(100, 20)
            Me.dateFechaVoucher.TabIndex = 67
            Me.dateFechaVoucher.ValidatingType = GetType(Date)
            '
            'txtFecha
            '
            Me.txtFecha.Location = New System.Drawing.Point(103, 91)
            Me.txtFecha.Mask = "00/00/0000"
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Size = New System.Drawing.Size(82, 20)
            Me.txtFecha.TabIndex = 66
            Me.txtFecha.ValidatingType = GetType(Date)
            '
            'chkRetenerTercera
            '
            Me.chkRetenerTercera.AutoSize = True
            Me.chkRetenerTercera.Location = New System.Drawing.Point(671, 187)
            Me.chkRetenerTercera.Name = "chkRetenerTercera"
            Me.chkRetenerTercera.Size = New System.Drawing.Size(114, 17)
            Me.chkRetenerTercera.TabIndex = 2
            Me.chkRetenerTercera.Text = "Retener Renta 3ra"
            Me.chkRetenerTercera.UseVisualStyleBackColor = True
            '
            'btnTipoVenta
            '
            Me.btnTipoVenta.Location = New System.Drawing.Point(761, 113)
            Me.btnTipoVenta.Name = "btnTipoVenta"
            Me.btnTipoVenta.Size = New System.Drawing.Size(28, 23)
            Me.btnTipoVenta.TabIndex = 20
            Me.btnTipoVenta.Text = ":::"
            Me.btnTipoVenta.UseVisualStyleBackColor = True
            '
            'txtTipoVenta
            '
            Me.txtTipoVenta.Enabled = False
            Me.txtTipoVenta.Location = New System.Drawing.Point(591, 114)
            Me.txtTipoVenta.Name = "txtTipoVenta"
            Me.txtTipoVenta.ReadOnly = True
            Me.txtTipoVenta.Size = New System.Drawing.Size(164, 20)
            Me.txtTipoVenta.TabIndex = 65
            '
            'chkRetencion4ta
            '
            Me.chkRetencion4ta.AutoSize = True
            Me.chkRetencion4ta.Location = New System.Drawing.Point(553, 186)
            Me.chkRetencion4ta.Name = "chkRetencion4ta"
            Me.chkRetencion4ta.Size = New System.Drawing.Size(114, 17)
            Me.chkRetencion4ta.TabIndex = 22
            Me.chkRetencion4ta.Text = "Retener Renta 4ta"
            Me.chkRetencion4ta.UseVisualStyleBackColor = True
            '
            'Label30
            '
            Me.Label30.AutoSize = True
            Me.Label30.Location = New System.Drawing.Point(505, 119)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(87, 13)
            Me.Label30.TabIndex = 64
            Me.Label30.Text = "Condicion Comp."
            '
            'btnCentroCosto
            '
            Me.btnCentroCosto.Location = New System.Drawing.Point(760, 66)
            Me.btnCentroCosto.Name = "btnCentroCosto"
            Me.btnCentroCosto.Size = New System.Drawing.Size(29, 23)
            Me.btnCentroCosto.TabIndex = 18
            Me.btnCentroCosto.Text = ":::"
            Me.btnCentroCosto.UseVisualStyleBackColor = True
            '
            'txtcentroCosto
            '
            Me.txtcentroCosto.Enabled = False
            Me.txtcentroCosto.Location = New System.Drawing.Point(591, 70)
            Me.txtcentroCosto.Name = "txtcentroCosto"
            Me.txtcentroCosto.ReadOnly = True
            Me.txtcentroCosto.Size = New System.Drawing.Size(164, 20)
            Me.txtcentroCosto.TabIndex = 62
            '
            'Label29
            '
            Me.Label29.AutoSize = True
            Me.Label29.Location = New System.Drawing.Point(517, 73)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(68, 13)
            Me.Label29.TabIndex = 61
            Me.Label29.Text = "Centro Costo"
            '
            'btnAgencia
            '
            Me.btnAgencia.Location = New System.Drawing.Point(255, 178)
            Me.btnAgencia.Name = "btnAgencia"
            Me.btnAgencia.Size = New System.Drawing.Size(28, 23)
            Me.btnAgencia.TabIndex = 17
            Me.btnAgencia.Text = ":::"
            Me.btnAgencia.UseVisualStyleBackColor = True
            '
            'txtPuntoVenta
            '
            Me.txtPuntoVenta.Enabled = False
            Me.txtPuntoVenta.Location = New System.Drawing.Point(100, 179)
            Me.txtPuntoVenta.Name = "txtPuntoVenta"
            Me.txtPuntoVenta.ReadOnly = True
            Me.txtPuntoVenta.Size = New System.Drawing.Size(150, 20)
            Me.txtPuntoVenta.TabIndex = 59
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(22, 181)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(71, 13)
            Me.Label8.TabIndex = 58
            Me.Label8.Text = "Dependencia"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(537, 96)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(48, 13)
            Me.Label5.TabIndex = 57
            Me.Label5.Text = "Compras"
            '
            'btnCompras
            '
            Me.btnCompras.Location = New System.Drawing.Point(761, 90)
            Me.btnCompras.Name = "btnCompras"
            Me.btnCompras.Size = New System.Drawing.Size(28, 23)
            Me.btnCompras.TabIndex = 19
            Me.btnCompras.Text = ":::"
            Me.btnCompras.UseVisualStyleBackColor = True
            '
            'txtCompras
            '
            Me.txtCompras.Enabled = False
            Me.txtCompras.Location = New System.Drawing.Point(591, 92)
            Me.txtCompras.Name = "txtCompras"
            Me.txtCompras.ReadOnly = True
            Me.txtCompras.Size = New System.Drawing.Size(165, 20)
            Me.txtCompras.TabIndex = 55
            '
            'txtTipoDocumento
            '
            Me.txtTipoDocumento.Location = New System.Drawing.Point(220, 91)
            Me.txtTipoDocumento.Name = "txtTipoDocumento"
            Me.txtTipoDocumento.Size = New System.Drawing.Size(25, 20)
            Me.txtTipoDocumento.TabIndex = 54
            Me.txtTipoDocumento.Visible = False
            '
            'txtCuentaCorriente
            '
            Me.txtCuentaCorriente.Location = New System.Drawing.Point(191, 91)
            Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
            Me.txtCuentaCorriente.Size = New System.Drawing.Size(22, 20)
            Me.txtCuentaCorriente.TabIndex = 53
            Me.txtCuentaCorriente.Visible = False
            '
            'txtglosa
            '
            Me.txtglosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtglosa.Location = New System.Drawing.Point(591, 137)
            Me.txtglosa.MaxLength = 100
            Me.txtglosa.Name = "txtglosa"
            Me.txtglosa.Size = New System.Drawing.Size(196, 20)
            Me.txtglosa.TabIndex = 21
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(551, 139)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(34, 13)
            Me.Label17.TabIndex = 50
            Me.Label17.Text = "Glosa"
            '
            'btnTipoDetraccion
            '
            Me.btnTipoDetraccion.Location = New System.Drawing.Point(474, 157)
            Me.btnTipoDetraccion.Name = "btnTipoDetraccion"
            Me.btnTipoDetraccion.Size = New System.Drawing.Size(28, 23)
            Me.btnTipoDetraccion.TabIndex = 16
            Me.btnTipoDetraccion.Text = ":::"
            Me.btnTipoDetraccion.UseVisualStyleBackColor = True
            '
            'btnOperacion
            '
            Me.btnOperacion.Location = New System.Drawing.Point(255, 155)
            Me.btnOperacion.Name = "btnOperacion"
            Me.btnOperacion.Size = New System.Drawing.Size(28, 23)
            Me.btnOperacion.TabIndex = 15
            Me.btnOperacion.Text = ":::"
            Me.btnOperacion.UseVisualStyleBackColor = True
            '
            'txtTipoDetraccion
            '
            Me.txtTipoDetraccion.Enabled = False
            Me.txtTipoDetraccion.Location = New System.Drawing.Point(286, 157)
            Me.txtTipoDetraccion.Name = "txtTipoDetraccion"
            Me.txtTipoDetraccion.ReadOnly = True
            Me.txtTipoDetraccion.Size = New System.Drawing.Size(182, 20)
            Me.txtTipoDetraccion.TabIndex = 47
            '
            'txtOperacionDetraccion
            '
            Me.txtOperacionDetraccion.Enabled = False
            Me.txtOperacionDetraccion.Location = New System.Drawing.Point(100, 157)
            Me.txtOperacionDetraccion.Name = "txtOperacionDetraccion"
            Me.txtOperacionDetraccion.ReadOnly = True
            Me.txtOperacionDetraccion.Size = New System.Drawing.Size(150, 20)
            Me.txtOperacionDetraccion.TabIndex = 46
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(7, 160)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(86, 13)
            Me.Label16.TabIndex = 45
            Me.Label16.Text = "OP./Tipo Detrac"
            '
            'txtFechaSPOT
            '
            Me.txtFechaSPOT.Location = New System.Drawing.Point(417, 136)
            Me.txtFechaSPOT.Mask = "00/00/0000"
            Me.txtFechaSPOT.Name = "txtFechaSPOT"
            Me.txtFechaSPOT.Size = New System.Drawing.Size(85, 20)
            Me.txtFechaSPOT.TabIndex = 14
            Me.txtFechaSPOT.ValidatingType = GetType(Date)
            '
            'txtNumeroSPOT
            '
            Me.txtNumeroSPOT.Location = New System.Drawing.Point(286, 135)
            Me.txtNumeroSPOT.Name = "txtNumeroSPOT"
            Me.txtNumeroSPOT.Size = New System.Drawing.Size(125, 20)
            Me.txtNumeroSPOT.TabIndex = 13
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(196, 138)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(92, 13)
            Me.Label15.TabIndex = 41
            Me.Label15.Text = "Nº y Fecha SPOT"
            '
            'chkAfectoSPOT
            '
            Me.chkAfectoSPOT.AutoSize = True
            Me.chkAfectoSPOT.Location = New System.Drawing.Point(103, 136)
            Me.chkAfectoSPOT.Name = "chkAfectoSPOT"
            Me.chkAfectoSPOT.Size = New System.Drawing.Size(98, 17)
            Me.chkAfectoSPOT.TabIndex = 12
            Me.chkAfectoSPOT.Text = "Afecto a SPOT"
            Me.chkAfectoSPOT.UseVisualStyleBackColor = True
            '
            'btnCPOriginal
            '
            Me.btnCPOriginal.Location = New System.Drawing.Point(474, 112)
            Me.btnCPOriginal.Name = "btnCPOriginal"
            Me.btnCPOriginal.Size = New System.Drawing.Size(28, 23)
            Me.btnCPOriginal.TabIndex = 11
            Me.btnCPOriginal.Text = ":::"
            Me.btnCPOriginal.UseVisualStyleBackColor = True
            '
            'txtCPNumero
            '
            Me.txtCPNumero.Enabled = False
            Me.txtCPNumero.Location = New System.Drawing.Point(357, 113)
            Me.txtCPNumero.Name = "txtCPNumero"
            Me.txtCPNumero.ReadOnly = True
            Me.txtCPNumero.Size = New System.Drawing.Size(111, 20)
            Me.txtCPNumero.TabIndex = 36
            '
            'txtCPSerie
            '
            Me.txtCPSerie.Enabled = False
            Me.txtCPSerie.Location = New System.Drawing.Point(286, 113)
            Me.txtCPSerie.Name = "txtCPSerie"
            Me.txtCPSerie.ReadOnly = True
            Me.txtCPSerie.Size = New System.Drawing.Size(65, 20)
            Me.txtCPSerie.TabIndex = 35
            '
            'txtCPOriginal
            '
            Me.txtCPOriginal.Enabled = False
            Me.txtCPOriginal.Location = New System.Drawing.Point(103, 113)
            Me.txtCPOriginal.Name = "txtCPOriginal"
            Me.txtCPOriginal.ReadOnly = True
            Me.txtCPOriginal.Size = New System.Drawing.Size(177, 20)
            Me.txtCPOriginal.TabIndex = 34
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(23, 117)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(68, 13)
            Me.Label13.TabIndex = 33
            Me.Label13.Text = "C. P. Original"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(346, 94)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(65, 13)
            Me.Label11.TabIndex = 28
            Me.Label11.Text = "Vencimiento"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(56, 95)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(37, 13)
            Me.Label10.TabIndex = 25
            Me.Label10.Text = "Fecha"
            '
            'txtDua
            '
            Me.txtDua.Location = New System.Drawing.Point(591, 48)
            Me.txtDua.Name = "txtDua"
            Me.txtDua.Size = New System.Drawing.Size(100, 20)
            Me.txtDua.TabIndex = 24
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(530, 51)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(53, 13)
            Me.Label9.TabIndex = 23
            Me.Label9.Text = "Nro. DUA"
            '
            'txtRuc
            '
            Me.txtRuc.Location = New System.Drawing.Point(591, 27)
            Me.txtRuc.MaxLength = 11
            Me.txtRuc.Name = "txtRuc"
            Me.txtRuc.Size = New System.Drawing.Size(100, 20)
            Me.txtRuc.TabIndex = 5
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(558, 30)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(27, 13)
            Me.Label7.TabIndex = 19
            Me.Label7.Text = "Ruc"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(417, 69)
            Me.txtNumero.MaxLength = 10
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(83, 20)
            Me.txtNumero.TabIndex = 8
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(356, 68)
            Me.txtSerie.MaxLength = 3
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(39, 20)
            Me.txtSerie.TabIndex = 7
            '
            'btnComprobante
            '
            Me.btnComprobante.Location = New System.Drawing.Point(286, 67)
            Me.btnComprobante.Name = "btnComprobante"
            Me.btnComprobante.Size = New System.Drawing.Size(29, 23)
            Me.btnComprobante.TabIndex = 6
            Me.btnComprobante.Text = ":::"
            Me.btnComprobante.UseVisualStyleBackColor = True
            '
            'txtCombrobante
            '
            Me.txtCombrobante.Enabled = False
            Me.txtCombrobante.Location = New System.Drawing.Point(103, 69)
            Me.txtCombrobante.Name = "txtCombrobante"
            Me.txtCombrobante.ReadOnly = True
            Me.txtCombrobante.Size = New System.Drawing.Size(177, 20)
            Me.txtCombrobante.TabIndex = 15
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(23, 71)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(70, 13)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "Comprobante"
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(473, 26)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(28, 23)
            Me.btnPersona.TabIndex = 4
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Enabled = False
            Me.txtPersona.Location = New System.Drawing.Point(103, 28)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(365, 20)
            Me.txtPersona.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(47, 31)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(46, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Persona"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(505, 9)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 13)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "Fecha Voucher"
            '
            'txtVoucher
            '
            Me.txtVoucher.Location = New System.Drawing.Point(400, 5)
            Me.txtVoucher.Name = "txtVoucher"
            Me.txtVoucher.Size = New System.Drawing.Size(100, 20)
            Me.txtVoucher.TabIndex = 2
            '
            'btnLibro
            '
            Me.btnLibro.Location = New System.Drawing.Point(367, 4)
            Me.btnLibro.Name = "btnLibro"
            Me.btnLibro.Size = New System.Drawing.Size(28, 23)
            Me.btnLibro.TabIndex = 1
            Me.btnLibro.Text = ":::"
            Me.btnLibro.UseVisualStyleBackColor = True
            '
            'txtLibro
            '
            Me.txtLibro.Enabled = False
            Me.txtLibro.Location = New System.Drawing.Point(263, 6)
            Me.txtLibro.Name = "txtLibro"
            Me.txtLibro.ReadOnly = True
            Me.txtLibro.Size = New System.Drawing.Size(100, 20)
            Me.txtLibro.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(184, 9)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(75, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Libro/Voucher"
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(152, 4)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 0
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(50, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Periodo"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Enabled = False
            Me.txtPeriodo.Location = New System.Drawing.Point(103, 6)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(47, 20)
            Me.txtPeriodo.TabIndex = 8
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmProvisionCompras
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(817, 550)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmProvisionCompras"
            Me.Text = " "
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.TabPage3.ResumeLayout(False)
            CType(Me.dgvguias, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            CType(Me.dgvNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtVoucher As System.Windows.Forms.TextBox
        Friend WithEvents btnLibro As System.Windows.Forms.Button
        Friend WithEvents txtLibro As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents btnCPOriginal As System.Windows.Forms.Button
        Friend WithEvents txtCPNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtCPSerie As System.Windows.Forms.TextBox
        Friend WithEvents txtCPOriginal As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtDua As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtRuc As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents btnComprobante As System.Windows.Forms.Button
        Friend WithEvents txtCombrobante As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtFechaSPOT As System.Windows.Forms.MaskedTextBox
        Friend WithEvents txtNumeroSPOT As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents chkAfectoSPOT As System.Windows.Forms.CheckBox
        Friend WithEvents btnTipoDetraccion As System.Windows.Forms.Button
        Friend WithEvents btnOperacion As System.Windows.Forms.Button
        Friend WithEvents txtTipoDetraccion As System.Windows.Forms.TextBox
        Friend WithEvents txtOperacionDetraccion As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtglosa As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents btnMoneda As System.Windows.Forms.Button
        Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents txtIGV As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtNoGrvado As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents txtBaseImponible As System.Windows.Forms.TextBox
        Friend WithEvents txtPercepcion As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents chkRetencion4ta As System.Windows.Forms.CheckBox
        Friend WithEvents txtValorCIF As System.Windows.Forms.TextBox
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents txtAdvalore As System.Windows.Forms.TextBox
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents txtTipoDocumento As System.Windows.Forms.TextBox
        Friend WithEvents txtCuentaCorriente As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnCompras As System.Windows.Forms.Button
        Friend WithEvents txtCompras As System.Windows.Forms.TextBox
        Friend WithEvents btnAgencia As System.Windows.Forms.Button
        Friend WithEvents txtPuntoVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents txtTotalDocumento As System.Windows.Forms.TextBox
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents btnCentroCosto As System.Windows.Forms.Button
        Friend WithEvents txtcentroCosto As System.Windows.Forms.TextBox
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents txtTipoVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents btnTipoVenta As System.Windows.Forms.Button
        Friend WithEvents txtSaldoXDistribuir As System.Windows.Forms.TextBox
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents dgvguias As System.Windows.Forms.DataGridView
        Friend WithEvents chkRetenerTercera As System.Windows.Forms.CheckBox
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents dgvNotaCredito As System.Windows.Forms.DataGridView
        Friend WithEvents txtDistribucionAfectacion As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtImporteISC As System.Windows.Forms.TextBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtOtrosTributos As System.Windows.Forms.TextBox
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents cct_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tdo_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dtd_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_ContraValor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents rep_EsLogistica As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents txtDistribucionGuias As System.Windows.Forms.TextBox
        Friend WithEvents Label32 As System.Windows.Forms.Label
        Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
        Friend WithEvents txtFechaVencimiento As System.Windows.Forms.MaskedTextBox
        Friend WithEvents dateFechaVoucher As System.Windows.Forms.MaskedTextBox
        Friend WithEvents prd_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cls_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cuc_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cta As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents prd_Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cco_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents CentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Glosa As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Almacen As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Label33 As System.Windows.Forms.Label
        Friend WithEvents txtTotalADistribuir As System.Windows.Forms.TextBox
        Friend WithEvents Label34 As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents ItemDoc As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents txtPorDistribuir As System.Windows.Forms.TextBox
        Friend WithEvents Label35 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Label37 As System.Windows.Forms.Label
        Friend WithEvents Label36 As System.Windows.Forms.Label
        Friend WithEvents btnResponsable As System.Windows.Forms.Button
        Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
        Friend WithEvents Label38 As System.Windows.Forms.Label
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents CambiarCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtReparable As System.Windows.Forms.TextBox
        Friend WithEvents Label39 As System.Windows.Forms.Label
        Friend WithEvents btnBorarReparable As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents txtSerieSunat As System.Windows.Forms.TextBox
        Friend WithEvents Label40 As System.Windows.Forms.Label
        Friend WithEvents txtAnioDua As System.Windows.Forms.TextBox
        Friend WithEvents lblOrdenTrabajo As System.Windows.Forms.Label
        Friend WithEvents lblDocuMovimiento As System.Windows.Forms.Label
        Friend WithEvents lblOrdenServicio As System.Windows.Forms.Label
        Friend WithEvents lblCuentaRendirDetalle As System.Windows.Forms.Label
        Friend WithEvents lblRendicionGastos As System.Windows.Forms.Label
    End Class

End Namespace
