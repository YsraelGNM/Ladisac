Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteDepositoTerceros
        ' Inherits System.Windows.Forms.Form
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
            Me.rdbNotaCargo = New System.Windows.Forms.RadioButton()
            Me.rdbDepositoTercero = New System.Windows.Forms.RadioButton()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnLimpiarCliente = New System.Windows.Forms.Button()
            Me.txtCliente = New System.Windows.Forms.TextBox()
            Me.btnCliente = New System.Windows.Forms.Button()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnLimpiarBanco = New System.Windows.Forms.Button()
            Me.txtBanco = New System.Windows.Forms.TextBox()
            Me.btnBanco = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCLSPersona = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(460, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.rdbNotaCargo)
            Me.Panel1.Controls.Add(Me.rdbDepositoTercero)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.btnLimpiarCliente)
            Me.Panel1.Controls.Add(Me.txtCliente)
            Me.Panel1.Controls.Add(Me.btnCliente)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.btnLimpiarBanco)
            Me.Panel1.Controls.Add(Me.txtBanco)
            Me.Panel1.Controls.Add(Me.btnBanco)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnCLSPersona)
            Me.Panel1.Controls.Add(Me.txtPersona)
            Me.Panel1.Controls.Add(Me.btnPersona)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(439, 173)
            Me.Panel1.TabIndex = 1
            '
            'rdbNotaCargo
            '
            Me.rdbNotaCargo.AutoSize = True
            Me.rdbNotaCargo.Location = New System.Drawing.Point(85, 149)
            Me.rdbNotaCargo.Name = "rdbNotaCargo"
            Me.rdbNotaCargo.Size = New System.Drawing.Size(113, 17)
            Me.rdbNotaCargo.TabIndex = 22
            Me.rdbNotaCargo.Text = "Nota Cargo Banco"
            Me.rdbNotaCargo.UseVisualStyleBackColor = True
            '
            'rdbDepositoTercero
            '
            Me.rdbDepositoTercero.AutoSize = True
            Me.rdbDepositoTercero.Checked = True
            Me.rdbDepositoTercero.Location = New System.Drawing.Point(85, 125)
            Me.rdbDepositoTercero.Name = "rdbDepositoTercero"
            Me.rdbDepositoTercero.Size = New System.Drawing.Size(112, 17)
            Me.rdbDepositoTercero.TabIndex = 21
            Me.rdbDepositoTercero.TabStop = True
            Me.rdbDepositoTercero.Text = "Deposito Terceros"
            Me.rdbDepositoTercero.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(40, 100)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(39, 13)
            Me.Label5.TabIndex = 20
            Me.Label5.Text = "Cliente"
            '
            'btnLimpiarCliente
            '
            Me.btnLimpiarCliente.Location = New System.Drawing.Point(341, 98)
            Me.btnLimpiarCliente.Name = "btnLimpiarCliente"
            Me.btnLimpiarCliente.Size = New System.Drawing.Size(54, 23)
            Me.btnLimpiarCliente.TabIndex = 19
            Me.btnLimpiarCliente.Text = "Limpiar"
            Me.btnLimpiarCliente.UseVisualStyleBackColor = True
            '
            'txtCliente
            '
            Me.txtCliente.Location = New System.Drawing.Point(85, 98)
            Me.txtCliente.Name = "txtCliente"
            Me.txtCliente.ReadOnly = True
            Me.txtCliente.Size = New System.Drawing.Size(216, 20)
            Me.txtCliente.TabIndex = 17
            '
            'btnCliente
            '
            Me.btnCliente.Location = New System.Drawing.Point(307, 98)
            Me.btnCliente.Name = "btnCliente"
            Me.btnCliente.Size = New System.Drawing.Size(28, 23)
            Me.btnCliente.TabIndex = 18
            Me.btnCliente.Text = ":::"
            Me.btnCliente.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(320, 147)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 16
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(40, 77)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(38, 13)
            Me.Label4.TabIndex = 15
            Me.Label4.Text = "Banco"
            '
            'btnLimpiarBanco
            '
            Me.btnLimpiarBanco.Location = New System.Drawing.Point(341, 74)
            Me.btnLimpiarBanco.Name = "btnLimpiarBanco"
            Me.btnLimpiarBanco.Size = New System.Drawing.Size(54, 23)
            Me.btnLimpiarBanco.TabIndex = 14
            Me.btnLimpiarBanco.Text = "Limpiar"
            Me.btnLimpiarBanco.UseVisualStyleBackColor = True
            '
            'txtBanco
            '
            Me.txtBanco.Location = New System.Drawing.Point(85, 74)
            Me.txtBanco.Name = "txtBanco"
            Me.txtBanco.ReadOnly = True
            Me.txtBanco.Size = New System.Drawing.Size(216, 20)
            Me.txtBanco.TabIndex = 12
            '
            'btnBanco
            '
            Me.btnBanco.Location = New System.Drawing.Point(307, 74)
            Me.btnBanco.Name = "btnBanco"
            Me.btnBanco.Size = New System.Drawing.Size(28, 23)
            Me.btnBanco.TabIndex = 13
            Me.btnBanco.Text = ":::"
            Me.btnBanco.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(9, 54)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(69, 13)
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "Responsable"
            '
            'btnCLSPersona
            '
            Me.btnCLSPersona.Location = New System.Drawing.Point(341, 50)
            Me.btnCLSPersona.Name = "btnCLSPersona"
            Me.btnCLSPersona.Size = New System.Drawing.Size(54, 23)
            Me.btnCLSPersona.TabIndex = 10
            Me.btnCLSPersona.Text = "Limpiar"
            Me.btnCLSPersona.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(85, 51)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(216, 20)
            Me.txtPersona.TabIndex = 8
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(307, 51)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(28, 23)
            Me.btnPersona.TabIndex = 9
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(235, 14)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(92, 20)
            Me.dateHasta.TabIndex = 3
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(85, 14)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(92, 20)
            Me.dateDesde.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(194, 14)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(44, 14)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Desde"
            '
            'frmReporteDepositoTerceros
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(460, 217)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteDepositoTerceros"
            Me.Text = "frmReporteDepositoTerceros"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCLSPersona As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnLimpiarBanco As System.Windows.Forms.Button
        Friend WithEvents txtBanco As System.Windows.Forms.TextBox
        Friend WithEvents btnBanco As System.Windows.Forms.Button
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnLimpiarCliente As System.Windows.Forms.Button
        Friend WithEvents txtCliente As System.Windows.Forms.TextBox
        Friend WithEvents btnCliente As System.Windows.Forms.Button
        Friend WithEvents rdbNotaCargo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbDepositoTercero As System.Windows.Forms.RadioButton
    End Class

End Namespace
