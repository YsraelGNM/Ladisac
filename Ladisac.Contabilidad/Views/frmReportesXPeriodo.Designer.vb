Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesXPeriodo
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
            Me.PanelDigito = New System.Windows.Forms.Panel()
            Me.nudDigitos = New System.Windows.Forms.NumericUpDown()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnGenerarDigitos = New System.Windows.Forms.Button()
            Me.btnGenerarCuenta = New System.Windows.Forms.Button()
            Me.PanelCuenta = New System.Windows.Forms.Panel()
            Me.txtCuenta = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelLibro = New System.Windows.Forms.Panel()
            Me.txtLibro = New System.Windows.Forms.TextBox()
            Me.btnLibro = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.PanelDigito.SuspendLayout()
            CType(Me.nudDigitos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelCuenta.SuspendLayout()
            Me.PanelLibro.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(468, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.PanelDigito)
            Me.Panel1.Controls.Add(Me.btnGenerarDigitos)
            Me.Panel1.Controls.Add(Me.btnGenerarCuenta)
            Me.Panel1.Controls.Add(Me.PanelCuenta)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnPeriodo)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.PanelLibro)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(461, 157)
            Me.Panel1.TabIndex = 1
            '
            'PanelDigito
            '
            Me.PanelDigito.Controls.Add(Me.nudDigitos)
            Me.PanelDigito.Controls.Add(Me.Label4)
            Me.PanelDigito.Location = New System.Drawing.Point(63, 58)
            Me.PanelDigito.Name = "PanelDigito"
            Me.PanelDigito.Size = New System.Drawing.Size(325, 24)
            Me.PanelDigito.TabIndex = 9
            Me.PanelDigito.Visible = False
            '
            'nudDigitos
            '
            Me.nudDigitos.Location = New System.Drawing.Point(86, 2)
            Me.nudDigitos.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.nudDigitos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudDigitos.Name = "nudDigitos"
            Me.nudDigitos.Size = New System.Drawing.Size(200, 20)
            Me.nudDigitos.TabIndex = 5
            Me.nudDigitos.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(5, 4)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "Por dígitos"
            '
            'btnGenerarDigitos
            '
            Me.btnGenerarDigitos.Location = New System.Drawing.Point(104, 121)
            Me.btnGenerarDigitos.Name = "btnGenerarDigitos"
            Me.btnGenerarDigitos.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerarDigitos.TabIndex = 10
            Me.btnGenerarDigitos.Text = "Por dígitos"
            Me.btnGenerarDigitos.UseVisualStyleBackColor = True
            Me.btnGenerarDigitos.Visible = False
            '
            'btnGenerarCuenta
            '
            Me.btnGenerarCuenta.Location = New System.Drawing.Point(185, 121)
            Me.btnGenerarCuenta.Name = "btnGenerarCuenta"
            Me.btnGenerarCuenta.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerarCuenta.TabIndex = 9
            Me.btnGenerarCuenta.Text = "Por cuenta"
            Me.btnGenerarCuenta.UseVisualStyleBackColor = True
            Me.btnGenerarCuenta.Visible = False
            '
            'PanelCuenta
            '
            Me.PanelCuenta.Controls.Add(Me.txtCuenta)
            Me.PanelCuenta.Controls.Add(Me.Label3)
            Me.PanelCuenta.Location = New System.Drawing.Point(63, 89)
            Me.PanelCuenta.Name = "PanelCuenta"
            Me.PanelCuenta.Size = New System.Drawing.Size(325, 24)
            Me.PanelCuenta.TabIndex = 8
            Me.PanelCuenta.Visible = False
            '
            'txtCuenta
            '
            Me.txtCuenta.Location = New System.Drawing.Point(86, 2)
            Me.txtCuenta.Name = "txtCuenta"
            Me.txtCuenta.Size = New System.Drawing.Size(200, 20)
            Me.txtCuenta.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(5, 4)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(59, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Por cuenta"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(266, 121)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 3
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(352, 2)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 2
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(149, 5)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(200, 20)
            Me.txtPeriodo.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(68, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(79, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Buscar Periodo"
            '
            'PanelLibro
            '
            Me.PanelLibro.Controls.Add(Me.txtLibro)
            Me.PanelLibro.Controls.Add(Me.btnLibro)
            Me.PanelLibro.Controls.Add(Me.Label2)
            Me.PanelLibro.Location = New System.Drawing.Point(63, 29)
            Me.PanelLibro.Name = "PanelLibro"
            Me.PanelLibro.Size = New System.Drawing.Size(325, 24)
            Me.PanelLibro.TabIndex = 7
            Me.PanelLibro.Visible = False
            '
            'txtLibro
            '
            Me.txtLibro.Location = New System.Drawing.Point(86, 2)
            Me.txtLibro.Name = "txtLibro"
            Me.txtLibro.ReadOnly = True
            Me.txtLibro.Size = New System.Drawing.Size(200, 20)
            Me.txtLibro.TabIndex = 5
            '
            'btnLibro
            '
            Me.btnLibro.Location = New System.Drawing.Point(289, 0)
            Me.btnLibro.Name = "btnLibro"
            Me.btnLibro.Size = New System.Drawing.Size(28, 23)
            Me.btnLibro.TabIndex = 6
            Me.btnLibro.Text = ":::"
            Me.btnLibro.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(5, 4)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(66, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Buscar Libro"
            '
            'frmReportesXPeriodo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(468, 201)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesXPeriodo"
            Me.Text = "frmReportesXPeriodo"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.PanelDigito.ResumeLayout(False)
            Me.PanelDigito.PerformLayout()
            CType(Me.nudDigitos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelCuenta.ResumeLayout(False)
            Me.PanelCuenta.PerformLayout()
            Me.PanelLibro.ResumeLayout(False)
            Me.PanelLibro.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnLibro As System.Windows.Forms.Button
        Friend WithEvents txtLibro As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents PanelLibro As System.Windows.Forms.Panel
        Friend WithEvents PanelCuenta As System.Windows.Forms.Panel
        Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnGenerarCuenta As System.Windows.Forms.Button
        Friend WithEvents btnGenerarDigitos As System.Windows.Forms.Button
        Friend WithEvents PanelDigito As System.Windows.Forms.Panel
        Friend WithEvents nudDigitos As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label4 As System.Windows.Forms.Label
    End Class

End Namespace