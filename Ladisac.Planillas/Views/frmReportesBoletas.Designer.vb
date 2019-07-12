Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesBoletas
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
            Me.components = New System.ComponentModel.Container()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnBoleta = New System.Windows.Forms.Button()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(441, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnBoleta)
            Me.Panel1.Controls.Add(Me.txtSerie)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.txtNumero)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(433, 110)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(350, 79)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 16
            Me.btnGenerar.Text = "Generara"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnBoleta
            '
            Me.btnBoleta.Location = New System.Drawing.Point(289, 19)
            Me.btnBoleta.Name = "btnBoleta"
            Me.btnBoleta.Size = New System.Drawing.Size(22, 23)
            Me.btnBoleta.TabIndex = 15
            Me.btnBoleta.Text = ":::"
            Me.btnBoleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBoleta.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(95, 23)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.ReadOnly = True
            Me.txtSerie.Size = New System.Drawing.Size(49, 20)
            Me.txtSerie.TabIndex = 14
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(13, 23)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(76, 13)
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Serie /Numero"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(150, 23)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(132, 20)
            Me.txtNumero.TabIndex = 12
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(398, 50)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(28, 23)
            Me.btnTrabajador.TabIndex = 11
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(97, 52)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(296, 20)
            Me.txtTrabajador.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(31, 55)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Trabajador"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmReportesBoletas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(441, 145)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesBoletas"
            Me.Text = "frmReporteBoletas"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnBoleta As System.Windows.Forms.Button
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class

End Namespace