
Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteAnalisisVentas
        '        Inherits System.Windows.Forms.Form
        Inherits Foundation.Views.ViewMaster
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnLimpiarDependencia = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbVentasRecordArticulo = New System.Windows.Forms.RadioButton()
            Me.rdbVentasRecordVendedor = New System.Windows.Forms.RadioButton()
            Me.rdbTonelaje = New System.Windows.Forms.RadioButton()
            Me.rdbVentasTipoVleinteArticulo = New System.Windows.Forms.RadioButton()
            Me.rdbGraficaEmpresaMes = New System.Windows.Forms.RadioButton()
            Me.rdbVendedorResumenLadrillo = New System.Windows.Forms.RadioButton()
            Me.rdbReportexMes = New System.Windows.Forms.RadioButton()
            Me.rdbVentasVendedor = New System.Windows.Forms.RadioButton()
            Me.rdbPuntoVentaResumen = New System.Windows.Forms.RadioButton()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnLimpiarArticulo = New System.Windows.Forms.Button()
            Me.txtArticulo = New System.Windows.Forms.TextBox()
            Me.btnArticulo = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnClsVendedor = New System.Windows.Forms.Button()
            Me.txtVendedor = New System.Windows.Forms.TextBox()
            Me.btnVendedor = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnCLSPersona = New System.Windows.Forms.Button()
            Me.btnAgencia = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.txtPuntoVenta = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.rbtTonelajeResumenForma1 = New System.Windows.Forms.RadioButton()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(744, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnLimpiarDependencia)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnLimpiarArticulo)
            Me.Panel1.Controls.Add(Me.txtArticulo)
            Me.Panel1.Controls.Add(Me.btnArticulo)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.btnClsVendedor)
            Me.Panel1.Controls.Add(Me.txtVendedor)
            Me.Panel1.Controls.Add(Me.btnVendedor)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.btnCLSPersona)
            Me.Panel1.Controls.Add(Me.btnAgencia)
            Me.Panel1.Controls.Add(Me.txtPersona)
            Me.Panel1.Controls.Add(Me.btnPersona)
            Me.Panel1.Controls.Add(Me.txtPuntoVenta)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(737, 294)
            Me.Panel1.TabIndex = 1
            '
            'btnLimpiarDependencia
            '
            Me.btnLimpiarDependencia.Location = New System.Drawing.Point(273, 140)
            Me.btnLimpiarDependencia.Name = "btnLimpiarDependencia"
            Me.btnLimpiarDependencia.Size = New System.Drawing.Size(54, 23)
            Me.btnLimpiarDependencia.TabIndex = 74
            Me.btnLimpiarDependencia.Text = "Limpiar"
            Me.btnLimpiarDependencia.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(9, 272)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(512, 13)
            Me.Label6.TabIndex = 73
            Me.Label6.Text = "Informacion de ventas de Diamante+Comercializadora(no figura como cliente Diamant" & _
                "e ni comercializadora)"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rbtTonelajeResumenForma1)
            Me.GroupBox1.Controls.Add(Me.rdbVentasRecordArticulo)
            Me.GroupBox1.Controls.Add(Me.rdbVentasRecordVendedor)
            Me.GroupBox1.Controls.Add(Me.rdbTonelaje)
            Me.GroupBox1.Controls.Add(Me.rdbVentasTipoVleinteArticulo)
            Me.GroupBox1.Controls.Add(Me.rdbGraficaEmpresaMes)
            Me.GroupBox1.Controls.Add(Me.rdbVendedorResumenLadrillo)
            Me.GroupBox1.Controls.Add(Me.rdbReportexMes)
            Me.GroupBox1.Controls.Add(Me.rdbVentasVendedor)
            Me.GroupBox1.Controls.Add(Me.rdbPuntoVentaResumen)
            Me.GroupBox1.Location = New System.Drawing.Point(497, 20)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(229, 249)
            Me.GroupBox1.TabIndex = 72
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Reportes"
            '
            'rdbVentasRecordArticulo
            '
            Me.rdbVentasRecordArticulo.AutoSize = True
            Me.rdbVentasRecordArticulo.Location = New System.Drawing.Point(16, 199)
            Me.rdbVentasRecordArticulo.Name = "rdbVentasRecordArticulo"
            Me.rdbVentasRecordArticulo.Size = New System.Drawing.Size(152, 17)
            Me.rdbVentasRecordArticulo.TabIndex = 8
            Me.rdbVentasRecordArticulo.TabStop = True
            Me.rdbVentasRecordArticulo.Text = "Record Ventas por Articulo"
            Me.rdbVentasRecordArticulo.UseVisualStyleBackColor = True
            '
            'rdbVentasRecordVendedor
            '
            Me.rdbVentasRecordVendedor.AutoSize = True
            Me.rdbVentasRecordVendedor.Location = New System.Drawing.Point(16, 176)
            Me.rdbVentasRecordVendedor.Name = "rdbVentasRecordVendedor"
            Me.rdbVentasRecordVendedor.Size = New System.Drawing.Size(163, 17)
            Me.rdbVentasRecordVendedor.TabIndex = 7
            Me.rdbVentasRecordVendedor.TabStop = True
            Me.rdbVentasRecordVendedor.Text = "Record Ventas por Vendedor"
            Me.rdbVentasRecordVendedor.UseVisualStyleBackColor = True
            '
            'rdbTonelaje
            '
            Me.rdbTonelaje.AutoSize = True
            Me.rdbTonelaje.Location = New System.Drawing.Point(16, 152)
            Me.rdbTonelaje.Name = "rdbTonelaje"
            Me.rdbTonelaje.Size = New System.Drawing.Size(155, 17)
            Me.rdbTonelaje.TabIndex = 6
            Me.rdbTonelaje.TabStop = True
            Me.rdbTonelaje.Text = "Reporte Tonelaje Resumen"
            Me.rdbTonelaje.UseVisualStyleBackColor = True
            '
            'rdbVentasTipoVleinteArticulo
            '
            Me.rdbVentasTipoVleinteArticulo.AutoSize = True
            Me.rdbVentasTipoVleinteArticulo.Location = New System.Drawing.Point(16, 130)
            Me.rdbVentasTipoVleinteArticulo.Name = "rdbVentasTipoVleinteArticulo"
            Me.rdbVentasTipoVleinteArticulo.Size = New System.Drawing.Size(188, 17)
            Me.rdbVentasTipoVleinteArticulo.TabIndex = 5
            Me.rdbVentasTipoVleinteArticulo.TabStop = True
            Me.rdbVentasTipoVleinteArticulo.Text = "Ventas por Tipo de Cliente Articulo"
            Me.rdbVentasTipoVleinteArticulo.UseVisualStyleBackColor = True
            '
            'rdbGraficaEmpresaMes
            '
            Me.rdbGraficaEmpresaMes.AutoSize = True
            Me.rdbGraficaEmpresaMes.Location = New System.Drawing.Point(16, 108)
            Me.rdbGraficaEmpresaMes.Name = "rdbGraficaEmpresaMes"
            Me.rdbGraficaEmpresaMes.Size = New System.Drawing.Size(189, 17)
            Me.rdbGraficaEmpresaMes.TabIndex = 4
            Me.rdbGraficaEmpresaMes.TabStop = True
            Me.rdbGraficaEmpresaMes.Text = "Grafica Tonelaje Por Empresa-Mes"
            Me.rdbGraficaEmpresaMes.UseVisualStyleBackColor = True
            '
            'rdbVendedorResumenLadrillo
            '
            Me.rdbVendedorResumenLadrillo.AutoSize = True
            Me.rdbVendedorResumenLadrillo.Location = New System.Drawing.Point(16, 85)
            Me.rdbVendedorResumenLadrillo.Name = "rdbVendedorResumenLadrillo"
            Me.rdbVendedorResumenLadrillo.Size = New System.Drawing.Size(191, 17)
            Me.rdbVendedorResumenLadrillo.TabIndex = 3
            Me.rdbVendedorResumenLadrillo.TabStop = True
            Me.rdbVendedorResumenLadrillo.Text = "Ventas Vendedor Resumen Ladrillo"
            Me.rdbVendedorResumenLadrillo.UseVisualStyleBackColor = True
            '
            'rdbReportexMes
            '
            Me.rdbReportexMes.AutoSize = True
            Me.rdbReportexMes.Location = New System.Drawing.Point(16, 63)
            Me.rdbReportexMes.Name = "rdbReportexMes"
            Me.rdbReportexMes.Size = New System.Drawing.Size(155, 17)
            Me.rdbReportexMes.TabIndex = 2
            Me.rdbReportexMes.TabStop = True
            Me.rdbReportexMes.Text = "Tonelaje por mes-Vendedor"
            Me.rdbReportexMes.UseVisualStyleBackColor = True
            '
            'rdbVentasVendedor
            '
            Me.rdbVentasVendedor.AutoSize = True
            Me.rdbVentasVendedor.Location = New System.Drawing.Point(16, 41)
            Me.rdbVentasVendedor.Name = "rdbVentasVendedor"
            Me.rdbVentasVendedor.Size = New System.Drawing.Size(155, 17)
            Me.rdbVentasVendedor.TabIndex = 1
            Me.rdbVentasVendedor.TabStop = True
            Me.rdbVentasVendedor.Text = "Ventas Vendedor Resumen"
            Me.rdbVentasVendedor.UseVisualStyleBackColor = True
            '
            'rdbPuntoVentaResumen
            '
            Me.rdbPuntoVentaResumen.AutoSize = True
            Me.rdbPuntoVentaResumen.Location = New System.Drawing.Point(16, 20)
            Me.rdbPuntoVentaResumen.Name = "rdbPuntoVentaResumen"
            Me.rdbPuntoVentaResumen.Size = New System.Drawing.Size(183, 17)
            Me.rdbPuntoVentaResumen.TabIndex = 0
            Me.rdbPuntoVentaResumen.TabStop = True
            Me.rdbPuntoVentaResumen.Text = "Ventas Punto de Venta Resumen"
            Me.rdbPuntoVentaResumen.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(416, 196)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 71
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnLimpiarArticulo
            '
            Me.btnLimpiarArticulo.Location = New System.Drawing.Point(437, 95)
            Me.btnLimpiarArticulo.Name = "btnLimpiarArticulo"
            Me.btnLimpiarArticulo.Size = New System.Drawing.Size(54, 23)
            Me.btnLimpiarArticulo.TabIndex = 70
            Me.btnLimpiarArticulo.Text = "Limpiar"
            Me.btnLimpiarArticulo.UseVisualStyleBackColor = True
            '
            'txtArticulo
            '
            Me.txtArticulo.Location = New System.Drawing.Point(85, 95)
            Me.txtArticulo.Name = "txtArticulo"
            Me.txtArticulo.ReadOnly = True
            Me.txtArticulo.Size = New System.Drawing.Size(313, 20)
            Me.txtArticulo.TabIndex = 68
            '
            'btnArticulo
            '
            Me.btnArticulo.Location = New System.Drawing.Point(404, 95)
            Me.btnArticulo.Name = "btnArticulo"
            Me.btnArticulo.Size = New System.Drawing.Size(28, 23)
            Me.btnArticulo.TabIndex = 69
            Me.btnArticulo.Text = ":::"
            Me.btnArticulo.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(33, 98)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(47, 13)
            Me.Label5.TabIndex = 67
            Me.Label5.Text = "Articulos"
            '
            'btnClsVendedor
            '
            Me.btnClsVendedor.Location = New System.Drawing.Point(437, 69)
            Me.btnClsVendedor.Name = "btnClsVendedor"
            Me.btnClsVendedor.Size = New System.Drawing.Size(54, 23)
            Me.btnClsVendedor.TabIndex = 66
            Me.btnClsVendedor.Text = "Limpiar"
            Me.btnClsVendedor.UseVisualStyleBackColor = True
            '
            'txtVendedor
            '
            Me.txtVendedor.Location = New System.Drawing.Point(85, 69)
            Me.txtVendedor.Name = "txtVendedor"
            Me.txtVendedor.ReadOnly = True
            Me.txtVendedor.Size = New System.Drawing.Size(313, 20)
            Me.txtVendedor.TabIndex = 64
            '
            'btnVendedor
            '
            Me.btnVendedor.Location = New System.Drawing.Point(404, 69)
            Me.btnVendedor.Name = "btnVendedor"
            Me.btnVendedor.Size = New System.Drawing.Size(28, 23)
            Me.btnVendedor.TabIndex = 65
            Me.btnVendedor.Text = ":::"
            Me.btnVendedor.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(27, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(53, 13)
            Me.Label4.TabIndex = 63
            Me.Label4.Text = "Vendedor"
            '
            'btnCLSPersona
            '
            Me.btnCLSPersona.Location = New System.Drawing.Point(438, 42)
            Me.btnCLSPersona.Name = "btnCLSPersona"
            Me.btnCLSPersona.Size = New System.Drawing.Size(54, 23)
            Me.btnCLSPersona.TabIndex = 7
            Me.btnCLSPersona.Text = "Limpiar"
            Me.btnCLSPersona.UseVisualStyleBackColor = True
            '
            'btnAgencia
            '
            Me.btnAgencia.Location = New System.Drawing.Point(240, 140)
            Me.btnAgencia.Name = "btnAgencia"
            Me.btnAgencia.Size = New System.Drawing.Size(28, 23)
            Me.btnAgencia.TabIndex = 60
            Me.btnAgencia.Text = ":::"
            Me.btnAgencia.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(85, 43)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(313, 20)
            Me.txtPersona.TabIndex = 5
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(404, 43)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(28, 23)
            Me.btnPersona.TabIndex = 6
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'txtPuntoVenta
            '
            Me.txtPuntoVenta.Enabled = False
            Me.txtPuntoVenta.Location = New System.Drawing.Point(85, 141)
            Me.txtPuntoVenta.Name = "txtPuntoVenta"
            Me.txtPuntoVenta.ReadOnly = True
            Me.txtPuntoVenta.Size = New System.Drawing.Size(150, 20)
            Me.txtPuntoVenta.TabIndex = 62
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(41, 46)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(39, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Cliente"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(9, 143)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(71, 13)
            Me.Label8.TabIndex = 61
            Me.Label8.Text = "Dependencia"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(216, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 16
            Me.Label3.Text = "Hasta"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(271, 16)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(90, 20)
            Me.dateHasta.TabIndex = 15
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(85, 17)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(90, 20)
            Me.dateDesde.TabIndex = 14
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(42, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Desde"
            '
            'rbtTonelajeResumenForma1
            '
            Me.rbtTonelajeResumenForma1.AutoSize = True
            Me.rbtTonelajeResumenForma1.Location = New System.Drawing.Point(16, 222)
            Me.rbtTonelajeResumenForma1.Name = "rbtTonelajeResumenForma1"
            Me.rbtTonelajeResumenForma1.Size = New System.Drawing.Size(196, 17)
            Me.rbtTonelajeResumenForma1.TabIndex = 9
            Me.rbtTonelajeResumenForma1.TabStop = True
            Me.rbtTonelajeResumenForma1.Text = "Reporte Tonelaje Resumen Forma 1"
            Me.rbtTonelajeResumenForma1.UseVisualStyleBackColor = True
            '
            'frmReporteAnalisisVentas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(744, 337)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteAnalisisVentas"
            Me.Text = "frmReporteAnalisisVentas"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnAgencia As System.Windows.Forms.Button
        Friend WithEvents txtPuntoVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnCLSPersona As System.Windows.Forms.Button
        Friend WithEvents btnClsVendedor As System.Windows.Forms.Button
        Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
        Friend WithEvents btnVendedor As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnLimpiarArticulo As System.Windows.Forms.Button
        Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
        Friend WithEvents btnArticulo As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbPuntoVentaResumen As System.Windows.Forms.RadioButton
        Friend WithEvents rdbVentasVendedor As System.Windows.Forms.RadioButton
        Friend WithEvents rdbReportexMes As System.Windows.Forms.RadioButton
        Friend WithEvents rdbVendedorResumenLadrillo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbGraficaEmpresaMes As System.Windows.Forms.RadioButton
        Friend WithEvents rdbVentasTipoVleinteArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbTonelaje As System.Windows.Forms.RadioButton
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnLimpiarDependencia As System.Windows.Forms.Button
        Friend WithEvents rdbVentasRecordVendedor As System.Windows.Forms.RadioButton
        Friend WithEvents rdbVentasRecordArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents rbtTonelajeResumenForma1 As System.Windows.Forms.RadioButton
    End Class

End Namespace
