Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmExportarSunatPLE
        Inherits Ladisac.Foundation.Views.ViewMaster

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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.chkCuentas = New System.Windows.Forms.CheckBox()
            Me.chkLibroMayor = New System.Windows.Forms.CheckBox()
            Me.chkLibroDiario = New System.Windows.Forms.CheckBox()
            Me.chkRegistroVenta = New System.Windows.Forms.CheckBox()
            Me.chkRegistroCompra = New System.Windows.Forms.CheckBox()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnCancelar = New System.Windows.Forms.Button()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.chkRegistroCompraNoDomiciliados = New System.Windows.Forms.CheckBox()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(346, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Controls.Add(Me.btnPeriodo)
            Me.Panel1.Controls.Add(Me.Panel4)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(339, 240)
            Me.Panel1.TabIndex = 1
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.chkRegistroCompraNoDomiciliados)
            Me.GroupBox1.Controls.Add(Me.chkCuentas)
            Me.GroupBox1.Controls.Add(Me.chkLibroMayor)
            Me.GroupBox1.Controls.Add(Me.chkLibroDiario)
            Me.GroupBox1.Controls.Add(Me.chkRegistroVenta)
            Me.GroupBox1.Controls.Add(Me.chkRegistroCompra)
            Me.GroupBox1.Location = New System.Drawing.Point(9, 38)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(323, 154)
            Me.GroupBox1.TabIndex = 12
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Libros Electronicos PLE."
            '
            'chkCuentas
            '
            Me.chkCuentas.AutoSize = True
            Me.chkCuentas.Location = New System.Drawing.Point(59, 129)
            Me.chkCuentas.Name = "chkCuentas"
            Me.chkCuentas.Size = New System.Drawing.Size(103, 17)
            Me.chkCuentas.TabIndex = 8
            Me.chkCuentas.Text = "Plan de cuentas"
            Me.chkCuentas.UseVisualStyleBackColor = True
            '
            'chkLibroMayor
            '
            Me.chkLibroMayor.AutoSize = True
            Me.chkLibroMayor.Location = New System.Drawing.Point(60, 107)
            Me.chkLibroMayor.Name = "chkLibroMayor"
            Me.chkLibroMayor.Size = New System.Drawing.Size(81, 17)
            Me.chkLibroMayor.TabIndex = 7
            Me.chkLibroMayor.Text = "Libro Mayor"
            Me.chkLibroMayor.UseVisualStyleBackColor = True
            '
            'chkLibroDiario
            '
            Me.chkLibroDiario.AutoSize = True
            Me.chkLibroDiario.Location = New System.Drawing.Point(60, 85)
            Me.chkLibroDiario.Name = "chkLibroDiario"
            Me.chkLibroDiario.Size = New System.Drawing.Size(79, 17)
            Me.chkLibroDiario.TabIndex = 6
            Me.chkLibroDiario.Text = "Libro Diario"
            Me.chkLibroDiario.UseVisualStyleBackColor = True
            '
            'chkRegistroVenta
            '
            Me.chkRegistroVenta.AutoSize = True
            Me.chkRegistroVenta.Location = New System.Drawing.Point(60, 64)
            Me.chkRegistroVenta.Name = "chkRegistroVenta"
            Me.chkRegistroVenta.Size = New System.Drawing.Size(116, 17)
            Me.chkRegistroVenta.TabIndex = 5
            Me.chkRegistroVenta.Text = "Registro de Ventas"
            Me.chkRegistroVenta.UseVisualStyleBackColor = True
            '
            'chkRegistroCompra
            '
            Me.chkRegistroCompra.AutoSize = True
            Me.chkRegistroCompra.Location = New System.Drawing.Point(60, 22)
            Me.chkRegistroCompra.Name = "chkRegistroCompra"
            Me.chkRegistroCompra.Size = New System.Drawing.Size(124, 17)
            Me.chkRegistroCompra.TabIndex = 4
            Me.chkRegistroCompra.Text = "Registro de Compras"
            Me.chkRegistroCompra.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(157, 13)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 9
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.btnCancelar)
            Me.Panel4.Controls.Add(Me.btnGenerar)
            Me.Panel4.Location = New System.Drawing.Point(6, 198)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(329, 34)
            Me.Panel4.TabIndex = 2
            '
            'btnCancelar
            '
            Me.btnCancelar.Location = New System.Drawing.Point(243, 5)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.btnCancelar.TabIndex = 1
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(162, 5)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 0
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(68, 15)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(83, 20)
            Me.txtPeriodo.TabIndex = 11
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(15, 18)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Periodo"
            '
            'chkRegistroCompraNoDomiciliados
            '
            Me.chkRegistroCompraNoDomiciliados.AutoSize = True
            Me.chkRegistroCompraNoDomiciliados.Location = New System.Drawing.Point(60, 43)
            Me.chkRegistroCompraNoDomiciliados.Name = "chkRegistroCompraNoDomiciliados"
            Me.chkRegistroCompraNoDomiciliados.Size = New System.Drawing.Size(201, 17)
            Me.chkRegistroCompraNoDomiciliados.TabIndex = 9
            Me.chkRegistroCompraNoDomiciliados.Text = "Registro de Compras no Domiciliados"
            Me.chkRegistroCompraNoDomiciliados.UseVisualStyleBackColor = True
            '
            'frmExportarSunatPLE
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(346, 275)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmExportarSunatPLE"
            Me.Text = "frmExportarSunatPLE"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents chkLibroMayor As System.Windows.Forms.CheckBox
        Friend WithEvents chkLibroDiario As System.Windows.Forms.CheckBox
        Friend WithEvents chkRegistroVenta As System.Windows.Forms.CheckBox
        Friend WithEvents chkRegistroCompra As System.Windows.Forms.CheckBox
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnCancelar As System.Windows.Forms.Button
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents chkCuentas As System.Windows.Forms.CheckBox
        Friend WithEvents chkRegistroCompraNoDomiciliados As System.Windows.Forms.CheckBox
    End Class

End Namespace