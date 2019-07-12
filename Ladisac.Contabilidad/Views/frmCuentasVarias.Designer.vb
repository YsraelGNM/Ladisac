
Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasVarias
        Inherits ViewManMasterContabilidad

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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.txtRentaCuartaDescripcion = New System.Windows.Forms.TextBox()
            Me.btnRentaCuarta = New System.Windows.Forms.Button()
            Me.txtIgvRetencionDescripcionVenta = New System.Windows.Forms.TextBox()
            Me.btnIgvRetencion = New System.Windows.Forms.Button()
            Me.txtIgvPercepcionDescripcionVenta = New System.Windows.Forms.TextBox()
            Me.btnIgvPercepcion = New System.Windows.Forms.Button()
            Me.txtIGVVentasDescripcion = New System.Windows.Forms.TextBox()
            Me.btnIGVVentas = New System.Windows.Forms.Button()
            Me.txtIgvComprasDescripcion = New System.Windows.Forms.TextBox()
            Me.btnIgvCompras = New System.Windows.Forms.Button()
            Me.txtRentaCuarta = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtIgvRetencionVenta = New System.Windows.Forms.TextBox()
            Me.txtIgvPercepcionVenta = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtIGVVentas = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIgvCompras = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.txtComprasExistenDescripcion = New System.Windows.Forms.TextBox()
            Me.btnComprasExisten = New System.Windows.Forms.Button()
            Me.txtComprasExisten = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.txtPRDDescripcion = New System.Windows.Forms.TextBox()
            Me.btnPRD = New System.Windows.Forms.Button()
            Me.txtGRDDescripcion = New System.Windows.Forms.TextBox()
            Me.btnGRD = New System.Windows.Forms.Button()
            Me.txtPDCDescripcion = New System.Windows.Forms.TextBox()
            Me.btnPDC = New System.Windows.Forms.Button()
            Me.txtGDCDescripcion = New System.Windows.Forms.TextBox()
            Me.btnGDC = New System.Windows.Forms.Button()
            Me.txtPRD = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtGRD = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPDC = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtGDC = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtIgvRetencionDescripcionCompra = New System.Windows.Forms.TextBox()
            Me.btnRetCompra = New System.Windows.Forms.Button()
            Me.txtIgvPercepcionDescripcionCompra = New System.Windows.Forms.TextBox()
            Me.btnPercCompra = New System.Windows.Forms.Button()
            Me.txtIgvRetencionCompra = New System.Windows.Forms.TextBox()
            Me.txtIgvPercepcionCompra = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(592, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(581, 246)
            Me.Panel1.TabIndex = 2
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Location = New System.Drawing.Point(9, 10)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(569, 223)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.txtIgvRetencionDescripcionCompra)
            Me.TabPage1.Controls.Add(Me.btnRetCompra)
            Me.TabPage1.Controls.Add(Me.txtIgvPercepcionDescripcionCompra)
            Me.TabPage1.Controls.Add(Me.btnPercCompra)
            Me.TabPage1.Controls.Add(Me.txtIgvRetencionCompra)
            Me.TabPage1.Controls.Add(Me.txtIgvPercepcionCompra)
            Me.TabPage1.Controls.Add(Me.Label12)
            Me.TabPage1.Controls.Add(Me.Label13)
            Me.TabPage1.Controls.Add(Me.txtRentaCuartaDescripcion)
            Me.TabPage1.Controls.Add(Me.btnRentaCuarta)
            Me.TabPage1.Controls.Add(Me.txtIgvRetencionDescripcionVenta)
            Me.TabPage1.Controls.Add(Me.btnIgvRetencion)
            Me.TabPage1.Controls.Add(Me.txtIgvPercepcionDescripcionVenta)
            Me.TabPage1.Controls.Add(Me.btnIgvPercepcion)
            Me.TabPage1.Controls.Add(Me.txtIGVVentasDescripcion)
            Me.TabPage1.Controls.Add(Me.btnIGVVentas)
            Me.TabPage1.Controls.Add(Me.txtIgvComprasDescripcion)
            Me.TabPage1.Controls.Add(Me.btnIgvCompras)
            Me.TabPage1.Controls.Add(Me.txtRentaCuarta)
            Me.TabPage1.Controls.Add(Me.Label6)
            Me.TabPage1.Controls.Add(Me.txtIgvRetencionVenta)
            Me.TabPage1.Controls.Add(Me.txtIgvPercepcionVenta)
            Me.TabPage1.Controls.Add(Me.Label5)
            Me.TabPage1.Controls.Add(Me.Label4)
            Me.TabPage1.Controls.Add(Me.txtIGVVentas)
            Me.TabPage1.Controls.Add(Me.Label3)
            Me.TabPage1.Controls.Add(Me.txtIgvCompras)
            Me.TabPage1.Controls.Add(Me.Label2)
            Me.TabPage1.Controls.Add(Me.txtCodigo)
            Me.TabPage1.Controls.Add(Me.Label1)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(561, 197)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Cuentas de impuesto"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'txtRentaCuartaDescripcion
            '
            Me.txtRentaCuartaDescripcion.Location = New System.Drawing.Point(301, 165)
            Me.txtRentaCuartaDescripcion.Name = "txtRentaCuartaDescripcion"
            Me.txtRentaCuartaDescripcion.ReadOnly = True
            Me.txtRentaCuartaDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtRentaCuartaDescripcion.TabIndex = 31
            '
            'btnRentaCuarta
            '
            Me.btnRentaCuarta.Location = New System.Drawing.Point(274, 165)
            Me.btnRentaCuarta.Name = "btnRentaCuarta"
            Me.btnRentaCuarta.Size = New System.Drawing.Size(24, 23)
            Me.btnRentaCuarta.TabIndex = 30
            Me.btnRentaCuarta.Text = ":::"
            Me.btnRentaCuarta.UseVisualStyleBackColor = True
            '
            'txtIgvRetencionDescripcionVenta
            '
            Me.txtIgvRetencionDescripcionVenta.Location = New System.Drawing.Point(301, 85)
            Me.txtIgvRetencionDescripcionVenta.Name = "txtIgvRetencionDescripcionVenta"
            Me.txtIgvRetencionDescripcionVenta.ReadOnly = True
            Me.txtIgvRetencionDescripcionVenta.Size = New System.Drawing.Size(254, 20)
            Me.txtIgvRetencionDescripcionVenta.TabIndex = 29
            '
            'btnIgvRetencion
            '
            Me.btnIgvRetencion.Location = New System.Drawing.Point(274, 85)
            Me.btnIgvRetencion.Name = "btnIgvRetencion"
            Me.btnIgvRetencion.Size = New System.Drawing.Size(24, 23)
            Me.btnIgvRetencion.TabIndex = 28
            Me.btnIgvRetencion.Text = ":::"
            Me.btnIgvRetencion.UseVisualStyleBackColor = True
            '
            'txtIgvPercepcionDescripcionVenta
            '
            Me.txtIgvPercepcionDescripcionVenta.Location = New System.Drawing.Point(301, 64)
            Me.txtIgvPercepcionDescripcionVenta.Name = "txtIgvPercepcionDescripcionVenta"
            Me.txtIgvPercepcionDescripcionVenta.ReadOnly = True
            Me.txtIgvPercepcionDescripcionVenta.Size = New System.Drawing.Size(254, 20)
            Me.txtIgvPercepcionDescripcionVenta.TabIndex = 27
            '
            'btnIgvPercepcion
            '
            Me.btnIgvPercepcion.Location = New System.Drawing.Point(274, 62)
            Me.btnIgvPercepcion.Name = "btnIgvPercepcion"
            Me.btnIgvPercepcion.Size = New System.Drawing.Size(24, 23)
            Me.btnIgvPercepcion.TabIndex = 26
            Me.btnIgvPercepcion.Text = ":::"
            Me.btnIgvPercepcion.UseVisualStyleBackColor = True
            '
            'txtIGVVentasDescripcion
            '
            Me.txtIGVVentasDescripcion.Location = New System.Drawing.Point(301, 34)
            Me.txtIGVVentasDescripcion.Name = "txtIGVVentasDescripcion"
            Me.txtIGVVentasDescripcion.ReadOnly = True
            Me.txtIGVVentasDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtIGVVentasDescripcion.TabIndex = 25
            '
            'btnIGVVentas
            '
            Me.btnIGVVentas.Location = New System.Drawing.Point(274, 32)
            Me.btnIGVVentas.Name = "btnIGVVentas"
            Me.btnIGVVentas.Size = New System.Drawing.Size(24, 23)
            Me.btnIGVVentas.TabIndex = 24
            Me.btnIGVVentas.Text = ":::"
            Me.btnIGVVentas.UseVisualStyleBackColor = True
            '
            'txtIgvComprasDescripcion
            '
            Me.txtIgvComprasDescripcion.Location = New System.Drawing.Point(301, 12)
            Me.txtIgvComprasDescripcion.Name = "txtIgvComprasDescripcion"
            Me.txtIgvComprasDescripcion.ReadOnly = True
            Me.txtIgvComprasDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtIgvComprasDescripcion.TabIndex = 23
            '
            'btnIgvCompras
            '
            Me.btnIgvCompras.Location = New System.Drawing.Point(274, 9)
            Me.btnIgvCompras.Name = "btnIgvCompras"
            Me.btnIgvCompras.Size = New System.Drawing.Size(24, 23)
            Me.btnIgvCompras.TabIndex = 22
            Me.btnIgvCompras.Text = ":::"
            Me.btnIgvCompras.UseVisualStyleBackColor = True
            '
            'txtRentaCuarta
            '
            Me.txtRentaCuarta.Location = New System.Drawing.Point(207, 164)
            Me.txtRentaCuarta.Name = "txtRentaCuarta"
            Me.txtRentaCuarta.ReadOnly = True
            Me.txtRentaCuarta.Size = New System.Drawing.Size(66, 20)
            Me.txtRentaCuarta.TabIndex = 21
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(132, 168)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(70, 13)
            Me.Label6.TabIndex = 20
            Me.Label6.Text = "Renta Cuarta"
            '
            'txtIgvRetencionVenta
            '
            Me.txtIgvRetencionVenta.Location = New System.Drawing.Point(207, 84)
            Me.txtIgvRetencionVenta.Name = "txtIgvRetencionVenta"
            Me.txtIgvRetencionVenta.ReadOnly = True
            Me.txtIgvRetencionVenta.Size = New System.Drawing.Size(66, 20)
            Me.txtIgvRetencionVenta.TabIndex = 19
            '
            'txtIgvPercepcionVenta
            '
            Me.txtIgvPercepcionVenta.Location = New System.Drawing.Point(207, 63)
            Me.txtIgvPercepcionVenta.Name = "txtIgvPercepcionVenta"
            Me.txtIgvPercepcionVenta.ReadOnly = True
            Me.txtIgvPercepcionVenta.Size = New System.Drawing.Size(66, 20)
            Me.txtIgvPercepcionVenta.TabIndex = 18
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(84, 88)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(105, 13)
            Me.Label5.TabIndex = 17
            Me.Label5.Text = "Igv Retencion Venta"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(87, 67)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(115, 13)
            Me.Label4.TabIndex = 16
            Me.Label4.Text = "Igv Percepcion Ventas"
            '
            'txtIGVVentas
            '
            Me.txtIGVVentas.Location = New System.Drawing.Point(207, 34)
            Me.txtIGVVentas.Name = "txtIGVVentas"
            Me.txtIGVVentas.ReadOnly = True
            Me.txtIGVVentas.Size = New System.Drawing.Size(66, 20)
            Me.txtIGVVentas.TabIndex = 15
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(142, 37)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(60, 13)
            Me.Label3.TabIndex = 14
            Me.Label3.Text = "IGV ventas"
            '
            'txtIgvCompras
            '
            Me.txtIgvCompras.Location = New System.Drawing.Point(207, 12)
            Me.txtIgvCompras.Name = "txtIgvCompras"
            Me.txtIgvCompras.ReadOnly = True
            Me.txtIgvCompras.Size = New System.Drawing.Size(66, 20)
            Me.txtIgvCompras.TabIndex = 13
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(134, 15)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(68, 13)
            Me.Label2.TabIndex = 12
            Me.Label2.Text = "IGV compras"
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(52, 14)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
            Me.txtCodigo.TabIndex = 11
            Me.txtCodigo.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(7, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Codigo"
            Me.Label1.Visible = False
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.txtComprasExistenDescripcion)
            Me.TabPage2.Controls.Add(Me.btnComprasExisten)
            Me.TabPage2.Controls.Add(Me.txtComprasExisten)
            Me.TabPage2.Controls.Add(Me.Label7)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(561, 164)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Compras"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'txtComprasExistenDescripcion
            '
            Me.txtComprasExistenDescripcion.Location = New System.Drawing.Point(300, 32)
            Me.txtComprasExistenDescripcion.Name = "txtComprasExistenDescripcion"
            Me.txtComprasExistenDescripcion.ReadOnly = True
            Me.txtComprasExistenDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtComprasExistenDescripcion.TabIndex = 25
            '
            'btnComprasExisten
            '
            Me.btnComprasExisten.Location = New System.Drawing.Point(273, 31)
            Me.btnComprasExisten.Name = "btnComprasExisten"
            Me.btnComprasExisten.Size = New System.Drawing.Size(24, 23)
            Me.btnComprasExisten.TabIndex = 24
            Me.btnComprasExisten.Text = ":::"
            Me.btnComprasExisten.UseVisualStyleBackColor = True
            '
            'txtComprasExisten
            '
            Me.txtComprasExisten.Location = New System.Drawing.Point(206, 32)
            Me.txtComprasExisten.Name = "txtComprasExisten"
            Me.txtComprasExisten.ReadOnly = True
            Me.txtComprasExisten.Size = New System.Drawing.Size(66, 20)
            Me.txtComprasExisten.TabIndex = 1
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(114, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(85, 13)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Compras Existen"
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.txtPRDDescripcion)
            Me.TabPage3.Controls.Add(Me.btnPRD)
            Me.TabPage3.Controls.Add(Me.txtGRDDescripcion)
            Me.TabPage3.Controls.Add(Me.btnGRD)
            Me.TabPage3.Controls.Add(Me.txtPDCDescripcion)
            Me.TabPage3.Controls.Add(Me.btnPDC)
            Me.TabPage3.Controls.Add(Me.txtGDCDescripcion)
            Me.TabPage3.Controls.Add(Me.btnGDC)
            Me.TabPage3.Controls.Add(Me.txtPRD)
            Me.TabPage3.Controls.Add(Me.Label11)
            Me.TabPage3.Controls.Add(Me.txtGRD)
            Me.TabPage3.Controls.Add(Me.Label10)
            Me.TabPage3.Controls.Add(Me.txtPDC)
            Me.TabPage3.Controls.Add(Me.Label9)
            Me.TabPage3.Controls.Add(Me.txtGDC)
            Me.TabPage3.Controls.Add(Me.Label8)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(561, 164)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Cuentas de Ganacia y Perdida"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'txtPRDDescripcion
            '
            Me.txtPRDDescripcion.Location = New System.Drawing.Point(300, 95)
            Me.txtPRDDescripcion.Name = "txtPRDDescripcion"
            Me.txtPRDDescripcion.ReadOnly = True
            Me.txtPRDDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtPRDDescripcion.TabIndex = 29
            '
            'btnPRD
            '
            Me.btnPRD.Location = New System.Drawing.Point(273, 94)
            Me.btnPRD.Name = "btnPRD"
            Me.btnPRD.Size = New System.Drawing.Size(24, 23)
            Me.btnPRD.TabIndex = 28
            Me.btnPRD.Text = ":::"
            Me.btnPRD.UseVisualStyleBackColor = True
            '
            'txtGRDDescripcion
            '
            Me.txtGRDDescripcion.Location = New System.Drawing.Point(300, 73)
            Me.txtGRDDescripcion.Name = "txtGRDDescripcion"
            Me.txtGRDDescripcion.ReadOnly = True
            Me.txtGRDDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtGRDDescripcion.TabIndex = 27
            '
            'btnGRD
            '
            Me.btnGRD.Location = New System.Drawing.Point(273, 71)
            Me.btnGRD.Name = "btnGRD"
            Me.btnGRD.Size = New System.Drawing.Size(24, 23)
            Me.btnGRD.TabIndex = 26
            Me.btnGRD.Text = ":::"
            Me.btnGRD.UseVisualStyleBackColor = True
            '
            'txtPDCDescripcion
            '
            Me.txtPDCDescripcion.Location = New System.Drawing.Point(300, 50)
            Me.txtPDCDescripcion.Name = "txtPDCDescripcion"
            Me.txtPDCDescripcion.ReadOnly = True
            Me.txtPDCDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtPDCDescripcion.TabIndex = 25
            '
            'btnPDC
            '
            Me.btnPDC.Location = New System.Drawing.Point(273, 49)
            Me.btnPDC.Name = "btnPDC"
            Me.btnPDC.Size = New System.Drawing.Size(24, 23)
            Me.btnPDC.TabIndex = 24
            Me.btnPDC.Text = ":::"
            Me.btnPDC.UseVisualStyleBackColor = True
            '
            'txtGDCDescripcion
            '
            Me.txtGDCDescripcion.Location = New System.Drawing.Point(300, 27)
            Me.txtGDCDescripcion.Name = "txtGDCDescripcion"
            Me.txtGDCDescripcion.ReadOnly = True
            Me.txtGDCDescripcion.Size = New System.Drawing.Size(254, 20)
            Me.txtGDCDescripcion.TabIndex = 25
            '
            'btnGDC
            '
            Me.btnGDC.Location = New System.Drawing.Point(273, 26)
            Me.btnGDC.Name = "btnGDC"
            Me.btnGDC.Size = New System.Drawing.Size(24, 23)
            Me.btnGDC.TabIndex = 24
            Me.btnGDC.Text = ":::"
            Me.btnGDC.UseVisualStyleBackColor = True
            '
            'txtPRD
            '
            Me.txtPRD.Location = New System.Drawing.Point(205, 94)
            Me.txtPRD.Name = "txtPRD"
            Me.txtPRD.ReadOnly = True
            Me.txtPRD.Size = New System.Drawing.Size(66, 20)
            Me.txtPRD.TabIndex = 7
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(51, 96)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(148, 13)
            Me.Label11.TabIndex = 6
            Me.Label11.Text = "Perdida Redondeo Decimales"
            '
            'txtGRD
            '
            Me.txtGRD.Location = New System.Drawing.Point(205, 72)
            Me.txtGRD.Name = "txtGRD"
            Me.txtGRD.ReadOnly = True
            Me.txtGRD.Size = New System.Drawing.Size(66, 20)
            Me.txtGRD.TabIndex = 5
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(35, 75)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(164, 13)
            Me.Label10.TabIndex = 4
            Me.Label10.Text = "Ganancia Redondeo Ddecimales"
            '
            'txtPDC
            '
            Me.txtPDC.Location = New System.Drawing.Point(205, 50)
            Me.txtPDC.Name = "txtPDC"
            Me.txtPDC.ReadOnly = True
            Me.txtPDC.Size = New System.Drawing.Size(66, 20)
            Me.txtPDC.TabIndex = 3
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(61, 53)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(138, 13)
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "Perdida Diferencia Ccambio"
            '
            'txtGDC
            '
            Me.txtGDC.Location = New System.Drawing.Point(205, 28)
            Me.txtGDC.Name = "txtGDC"
            Me.txtGDC.ReadOnly = True
            Me.txtGDC.Size = New System.Drawing.Size(66, 20)
            Me.txtGDC.TabIndex = 1
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(51, 31)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(148, 13)
            Me.Label8.TabIndex = 0
            Me.Label8.Text = "Ganancia Diferencia Ccambio"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtIgvRetencionDescripcionCompra
            '
            Me.txtIgvRetencionDescripcionCompra.Location = New System.Drawing.Point(301, 137)
            Me.txtIgvRetencionDescripcionCompra.Name = "txtIgvRetencionDescripcionCompra"
            Me.txtIgvRetencionDescripcionCompra.ReadOnly = True
            Me.txtIgvRetencionDescripcionCompra.Size = New System.Drawing.Size(254, 20)
            Me.txtIgvRetencionDescripcionCompra.TabIndex = 39
            '
            'btnRetCompra
            '
            Me.btnRetCompra.Location = New System.Drawing.Point(274, 137)
            Me.btnRetCompra.Name = "btnRetCompra"
            Me.btnRetCompra.Size = New System.Drawing.Size(24, 23)
            Me.btnRetCompra.TabIndex = 38
            Me.btnRetCompra.Text = ":::"
            Me.btnRetCompra.UseVisualStyleBackColor = True
            '
            'txtIgvPercepcionDescripcionCompra
            '
            Me.txtIgvPercepcionDescripcionCompra.Location = New System.Drawing.Point(301, 116)
            Me.txtIgvPercepcionDescripcionCompra.Name = "txtIgvPercepcionDescripcionCompra"
            Me.txtIgvPercepcionDescripcionCompra.ReadOnly = True
            Me.txtIgvPercepcionDescripcionCompra.Size = New System.Drawing.Size(254, 20)
            Me.txtIgvPercepcionDescripcionCompra.TabIndex = 37
            '
            'btnPercCompra
            '
            Me.btnPercCompra.Location = New System.Drawing.Point(274, 114)
            Me.btnPercCompra.Name = "btnPercCompra"
            Me.btnPercCompra.Size = New System.Drawing.Size(24, 23)
            Me.btnPercCompra.TabIndex = 36
            Me.btnPercCompra.Text = ":::"
            Me.btnPercCompra.UseVisualStyleBackColor = True
            '
            'txtIgvRetencionCompra
            '
            Me.txtIgvRetencionCompra.Location = New System.Drawing.Point(207, 136)
            Me.txtIgvRetencionCompra.Name = "txtIgvRetencionCompra"
            Me.txtIgvRetencionCompra.ReadOnly = True
            Me.txtIgvRetencionCompra.Size = New System.Drawing.Size(66, 20)
            Me.txtIgvRetencionCompra.TabIndex = 35
            '
            'txtIgvPercepcionCompra
            '
            Me.txtIgvPercepcionCompra.Location = New System.Drawing.Point(207, 115)
            Me.txtIgvPercepcionCompra.Name = "txtIgvPercepcionCompra"
            Me.txtIgvPercepcionCompra.ReadOnly = True
            Me.txtIgvPercepcionCompra.Size = New System.Drawing.Size(66, 20)
            Me.txtIgvPercepcionCompra.TabIndex = 34
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(84, 140)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(118, 13)
            Me.Label12.TabIndex = 33
            Me.Label12.Text = "Igv Retencion Compras"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(87, 119)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(118, 13)
            Me.Label13.TabIndex = 32
            Me.Label13.Text = "Igv Percepcion Compra"
            '
            'frmCuentasVarias
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(592, 315)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCuentasVarias"
            Me.Text = "frmCuentasVarias"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage1.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage2.PerformLayout()
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtIgvCompras As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtIgvRetencionVenta As System.Windows.Forms.TextBox
        Friend WithEvents txtIgvPercepcionVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtIGVVentas As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtRentaCuarta As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtComprasExisten As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents txtPRD As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtGRD As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtPDC As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtGDC As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtRentaCuartaDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnRentaCuarta As System.Windows.Forms.Button
        Friend WithEvents txtIgvRetencionDescripcionVenta As System.Windows.Forms.TextBox
        Friend WithEvents btnIgvRetencion As System.Windows.Forms.Button
        Friend WithEvents txtIgvPercepcionDescripcionVenta As System.Windows.Forms.TextBox
        Friend WithEvents btnIgvPercepcion As System.Windows.Forms.Button
        Friend WithEvents txtIGVVentasDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnIGVVentas As System.Windows.Forms.Button
        Friend WithEvents txtIgvComprasDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnIgvCompras As System.Windows.Forms.Button
        Friend WithEvents txtComprasExistenDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnComprasExisten As System.Windows.Forms.Button
        Friend WithEvents txtPRDDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnPRD As System.Windows.Forms.Button
        Friend WithEvents txtGRDDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnGRD As System.Windows.Forms.Button
        Friend WithEvents txtPDCDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnPDC As System.Windows.Forms.Button
        Friend WithEvents txtGDCDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnGDC As System.Windows.Forms.Button
        Friend WithEvents txtIgvRetencionDescripcionCompra As System.Windows.Forms.TextBox
        Friend WithEvents btnRetCompra As System.Windows.Forms.Button
        Friend WithEvents txtIgvPercepcionDescripcionCompra As System.Windows.Forms.TextBox
        Friend WithEvents btnPercCompra As System.Windows.Forms.Button
        Friend WithEvents txtIgvRetencionCompra As System.Windows.Forms.TextBox
        Friend WithEvents txtIgvPercepcionCompra As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
    End Class

End Namespace