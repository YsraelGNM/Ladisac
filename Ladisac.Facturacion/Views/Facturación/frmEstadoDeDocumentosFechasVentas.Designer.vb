Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmEstadoDeDocumentosFechasVentas
        'Inherits System.Windows.Forms.Form
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
            Me.btnAgencia = New System.Windows.Forms.Button()
            Me.txtPuntoVenta = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnClsVendedor = New System.Windows.Forms.Button()
            Me.txtVendedor = New System.Windows.Forms.TextBox()
            Me.btnVendedor = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(510, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnClsVendedor)
            Me.Panel1.Controls.Add(Me.txtVendedor)
            Me.Panel1.Controls.Add(Me.btnVendedor)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.btnLimpiarDependencia)
            Me.Panel1.Controls.Add(Me.btnAgencia)
            Me.Panel1.Controls.Add(Me.txtPuntoVenta)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(502, 123)
            Me.Panel1.TabIndex = 1
            '
            'btnLimpiarDependencia
            '
            Me.btnLimpiarDependencia.Location = New System.Drawing.Point(275, 36)
            Me.btnLimpiarDependencia.Name = "btnLimpiarDependencia"
            Me.btnLimpiarDependencia.Size = New System.Drawing.Size(54, 23)
            Me.btnLimpiarDependencia.TabIndex = 78
            Me.btnLimpiarDependencia.Text = "Limpiar"
            Me.btnLimpiarDependencia.UseVisualStyleBackColor = True
            '
            'btnAgencia
            '
            Me.btnAgencia.Location = New System.Drawing.Point(242, 36)
            Me.btnAgencia.Name = "btnAgencia"
            Me.btnAgencia.Size = New System.Drawing.Size(28, 23)
            Me.btnAgencia.TabIndex = 75
            Me.btnAgencia.Text = ":::"
            Me.btnAgencia.UseVisualStyleBackColor = True
            '
            'txtPuntoVenta
            '
            Me.txtPuntoVenta.Enabled = False
            Me.txtPuntoVenta.Location = New System.Drawing.Point(87, 37)
            Me.txtPuntoVenta.Name = "txtPuntoVenta"
            Me.txtPuntoVenta.ReadOnly = True
            Me.txtPuntoVenta.Size = New System.Drawing.Size(150, 20)
            Me.txtPuntoVenta.TabIndex = 77
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(11, 39)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(71, 13)
            Me.Label8.TabIndex = 76
            Me.Label8.Text = "Dependencia"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(218, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 82
            Me.Label3.Text = "Hasta"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(273, 12)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(90, 20)
            Me.dateHasta.TabIndex = 81
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(87, 13)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(90, 20)
            Me.dateDesde.TabIndex = 80
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(44, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 79
            Me.Label1.Text = "Desde"
            '
            'btnClsVendedor
            '
            Me.btnClsVendedor.Location = New System.Drawing.Point(439, 61)
            Me.btnClsVendedor.Name = "btnClsVendedor"
            Me.btnClsVendedor.Size = New System.Drawing.Size(54, 23)
            Me.btnClsVendedor.TabIndex = 86
            Me.btnClsVendedor.Text = "Limpiar"
            Me.btnClsVendedor.UseVisualStyleBackColor = True
            '
            'txtVendedor
            '
            Me.txtVendedor.Location = New System.Drawing.Point(87, 61)
            Me.txtVendedor.Name = "txtVendedor"
            Me.txtVendedor.ReadOnly = True
            Me.txtVendedor.Size = New System.Drawing.Size(313, 20)
            Me.txtVendedor.TabIndex = 84
            '
            'btnVendedor
            '
            Me.btnVendedor.Location = New System.Drawing.Point(406, 61)
            Me.btnVendedor.Name = "btnVendedor"
            Me.btnVendedor.Size = New System.Drawing.Size(28, 23)
            Me.btnVendedor.TabIndex = 85
            Me.btnVendedor.Text = ":::"
            Me.btnVendedor.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(29, 64)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(53, 13)
            Me.Label4.TabIndex = 83
            Me.Label4.Text = "Vendedor"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(359, 95)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 72
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmEstadoDeDocumentosFechasVentas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(510, 159)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmEstadoDeDocumentosFechasVentas"
            Me.Text = "frmEstadoDeDocumentosFechasVentas"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnLimpiarDependencia As System.Windows.Forms.Button
        Friend WithEvents btnAgencia As System.Windows.Forms.Button
        Friend WithEvents txtPuntoVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnClsVendedor As System.Windows.Forms.Button
        Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
        Friend WithEvents btnVendedor As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
    End Class

End Namespace
