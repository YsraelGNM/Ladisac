Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasArticulo
        Inherits ViewManMasterContabilidad    'System.Windows.Forms.Form

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
            Me.btnCompraBorrar = New System.Windows.Forms.Button()
            Me.btnexistencias = New System.Windows.Forms.Button()
            Me.btnCompra = New System.Windows.Forms.Button()
            Me.btnVenta = New System.Windows.Forms.Button()
            Me.btnLinea = New System.Windows.Forms.Button()
            Me.txtExistencias = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtCompra = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtVenta = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtLinea = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(429, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnCompraBorrar)
            Me.Panel1.Controls.Add(Me.btnexistencias)
            Me.Panel1.Controls.Add(Me.btnCompra)
            Me.Panel1.Controls.Add(Me.btnVenta)
            Me.Panel1.Controls.Add(Me.btnLinea)
            Me.Panel1.Controls.Add(Me.txtExistencias)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtCompra)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.txtVenta)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtLinea)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(5, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(420, 117)
            Me.Panel1.TabIndex = 5
            '
            'btnCompraBorrar
            '
            Me.btnCompraBorrar.Location = New System.Drawing.Point(234, 61)
            Me.btnCompraBorrar.Name = "btnCompraBorrar"
            Me.btnCompraBorrar.Size = New System.Drawing.Size(29, 23)
            Me.btnCompraBorrar.TabIndex = 18
            Me.btnCompraBorrar.Text = "cls"
            Me.btnCompraBorrar.UseVisualStyleBackColor = True
            '
            'btnexistencias
            '
            Me.btnexistencias.Location = New System.Drawing.Point(208, 84)
            Me.btnexistencias.Name = "btnexistencias"
            Me.btnexistencias.Size = New System.Drawing.Size(24, 23)
            Me.btnexistencias.TabIndex = 17
            Me.btnexistencias.Text = ":::"
            Me.btnexistencias.UseVisualStyleBackColor = True
            '
            'btnCompra
            '
            Me.btnCompra.Location = New System.Drawing.Point(208, 62)
            Me.btnCompra.Name = "btnCompra"
            Me.btnCompra.Size = New System.Drawing.Size(24, 23)
            Me.btnCompra.TabIndex = 16
            Me.btnCompra.Text = ":::"
            Me.btnCompra.UseVisualStyleBackColor = True
            '
            'btnVenta
            '
            Me.btnVenta.Location = New System.Drawing.Point(208, 40)
            Me.btnVenta.Name = "btnVenta"
            Me.btnVenta.Size = New System.Drawing.Size(24, 23)
            Me.btnVenta.TabIndex = 15
            Me.btnVenta.Text = ":::"
            Me.btnVenta.UseVisualStyleBackColor = True
            '
            'btnLinea
            '
            Me.btnLinea.Location = New System.Drawing.Point(344, 18)
            Me.btnLinea.Name = "btnLinea"
            Me.btnLinea.Size = New System.Drawing.Size(29, 23)
            Me.btnLinea.TabIndex = 14
            Me.btnLinea.Text = ":::"
            Me.btnLinea.UseVisualStyleBackColor = True
            '
            'txtExistencias
            '
            Me.txtExistencias.Location = New System.Drawing.Point(135, 86)
            Me.txtExistencias.Name = "txtExistencias"
            Me.txtExistencias.ReadOnly = True
            Me.txtExistencias.Size = New System.Drawing.Size(72, 20)
            Me.txtExistencias.TabIndex = 13
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(32, 88)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(97, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Cuenta Existencias"
            '
            'txtCompra
            '
            Me.txtCompra.Location = New System.Drawing.Point(135, 64)
            Me.txtCompra.Name = "txtCompra"
            Me.txtCompra.ReadOnly = True
            Me.txtCompra.Size = New System.Drawing.Size(72, 20)
            Me.txtCompra.TabIndex = 11
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(49, 69)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Cuenta Compra"
            '
            'txtVenta
            '
            Me.txtVenta.Location = New System.Drawing.Point(135, 42)
            Me.txtVenta.Name = "txtVenta"
            Me.txtVenta.ReadOnly = True
            Me.txtVenta.Size = New System.Drawing.Size(72, 20)
            Me.txtVenta.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(57, 47)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Cuenta Venta"
            '
            'txtLinea
            '
            Me.txtLinea.Location = New System.Drawing.Point(135, 20)
            Me.txtLinea.Name = "txtLinea"
            Me.txtLinea.ReadOnly = True
            Me.txtLinea.Size = New System.Drawing.Size(203, 20)
            Me.txtLinea.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(96, 25)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(33, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Linea"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmCuentasArticulo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(429, 180)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCuentasArticulo"
            Me.Text = "frmCuentasArticulo"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtExistencias As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtCompra As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtLinea As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnLinea As System.Windows.Forms.Button
        Friend WithEvents btnVenta As System.Windows.Forms.Button
        Friend WithEvents btnexistencias As System.Windows.Forms.Button
        Friend WithEvents btnCompra As System.Windows.Forms.Button
        Friend WithEvents btnCompraBorrar As System.Windows.Forms.Button
    End Class

End Namespace