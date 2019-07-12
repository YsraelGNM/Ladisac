Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConceptos
        Inherits Ladisac.Planillas.Views.ViewManMasterPlanillas

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
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Pan = New System.Windows.Forms.Panel()
            Me.chkCrearFunctionSecundario = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboNivelCalculo = New System.Windows.Forms.ComboBox()
            Me.chkCrearFunction = New System.Windows.Forms.CheckBox()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.chkEsPrestamo = New System.Windows.Forms.CheckBox()
            Me.chkEsJuridico = New System.Windows.Forms.CheckBox()
            Me.chkEsCalculoHoras = New System.Windows.Forms.CheckBox()
            Me.chkEsCalculo = New System.Windows.Forms.CheckBox()
            Me.chkEsFijo = New System.Windows.Forms.CheckBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtCodigoSunat = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboTipoConcepto = New System.Windows.Forms.ComboBox()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Pan.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(586, 28)
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Pan
            '
            Me.Pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Pan.Controls.Add(Me.chkCrearFunctionSecundario)
            Me.Pan.Controls.Add(Me.Label1)
            Me.Pan.Controls.Add(Me.cboNivelCalculo)
            Me.Pan.Controls.Add(Me.chkCrearFunction)
            Me.Pan.Controls.Add(Me.Panel4)
            Me.Pan.Controls.Add(Me.Label6)
            Me.Pan.Controls.Add(Me.Label3)
            Me.Pan.Controls.Add(Me.txtCodigoSunat)
            Me.Pan.Controls.Add(Me.Label2)
            Me.Pan.Controls.Add(Me.cboTipoConcepto)
            Me.Pan.Controls.Add(Me.txtCodigo)
            Me.Pan.Controls.Add(Me.txtDescripcion)
            Me.Pan.Controls.Add(Me.txtConcepto)
            Me.Pan.Controls.Add(Me.Label5)
            Me.Pan.Controls.Add(Me.Label4)
            Me.Pan.Location = New System.Drawing.Point(7, 56)
            Me.Pan.Name = "Pan"
            Me.Pan.Size = New System.Drawing.Size(577, 216)
            Me.Pan.TabIndex = 10
            '
            'chkCrearFunctionSecundario
            '
            Me.chkCrearFunctionSecundario.AutoSize = True
            Me.chkCrearFunctionSecundario.Location = New System.Drawing.Point(6, 194)
            Me.chkCrearFunctionSecundario.Name = "chkCrearFunctionSecundario"
            Me.chkCrearFunctionSecundario.Size = New System.Drawing.Size(463, 17)
            Me.chkCrearFunctionSecundario.TabIndex = 29
            Me.chkCrearFunctionSecundario.Text = "Crear una funcion acumulado Segundo Nivel por periodo SS[nombreConcepto] -  Otros" & _
                " (dias)"
            Me.chkCrearFunctionSecundario.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 108)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(84, 13)
            Me.Label1.TabIndex = 27
            Me.Label1.Text = "Nivel de Calculo"
            '
            'cboNivelCalculo
            '
            Me.cboNivelCalculo.FormattingEnabled = True
            Me.cboNivelCalculo.Items.AddRange(New Object() {"Nivel 0", "Nivel 1", "Nivel 2", "Nivel 3", "Nivel 4", "Nivel 5", "Nivel 6", "Nivel 7", "Nivel 8", "Nivel 9", "Nivel 10", "Nivel 11", "Nivel 12"})
            Me.cboNivelCalculo.Location = New System.Drawing.Point(91, 102)
            Me.cboNivelCalculo.Name = "cboNivelCalculo"
            Me.cboNivelCalculo.Size = New System.Drawing.Size(252, 21)
            Me.cboNivelCalculo.TabIndex = 28
            '
            'chkCrearFunction
            '
            Me.chkCrearFunction.AutoSize = True
            Me.chkCrearFunction.Location = New System.Drawing.Point(6, 173)
            Me.chkCrearFunction.Name = "chkCrearFunction"
            Me.chkCrearFunction.Size = New System.Drawing.Size(561, 17)
            Me.chkCrearFunction.TabIndex = 26
            Me.chkCrearFunction.Text = "Crear una funcion priner nivel acumulado por periodo SS[nombreConcepto] -Ingresos" & _
                " ,Descuentos y Aportaciones"
            Me.chkCrearFunction.UseVisualStyleBackColor = True
            '
            'Panel4
            '
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.chkEsPrestamo)
            Me.Panel4.Controls.Add(Me.chkEsJuridico)
            Me.Panel4.Controls.Add(Me.chkEsCalculoHoras)
            Me.Panel4.Controls.Add(Me.chkEsCalculo)
            Me.Panel4.Controls.Add(Me.chkEsFijo)
            Me.Panel4.Location = New System.Drawing.Point(419, 8)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(147, 114)
            Me.Panel4.TabIndex = 25
            '
            'chkEsPrestamo
            '
            Me.chkEsPrestamo.AutoSize = True
            Me.chkEsPrestamo.Location = New System.Drawing.Point(6, 85)
            Me.chkEsPrestamo.Name = "chkEsPrestamo"
            Me.chkEsPrestamo.Size = New System.Drawing.Size(134, 17)
            Me.chkEsPrestamo.TabIndex = 16
            Me.chkEsPrestamo.Text = "Es Concepto Prestamo"
            Me.chkEsPrestamo.UseVisualStyleBackColor = True
            '
            'chkEsJuridico
            '
            Me.chkEsJuridico.AutoSize = True
            Me.chkEsJuridico.Location = New System.Drawing.Point(6, 67)
            Me.chkEsJuridico.Name = "chkEsJuridico"
            Me.chkEsJuridico.Size = New System.Drawing.Size(125, 17)
            Me.chkEsJuridico.TabIndex = 15
            Me.chkEsJuridico.Text = "Es Concepto Judicial"
            Me.chkEsJuridico.UseVisualStyleBackColor = True
            '
            'chkEsCalculoHoras
            '
            Me.chkEsCalculoHoras.AutoSize = True
            Me.chkEsCalculoHoras.Location = New System.Drawing.Point(6, 48)
            Me.chkEsCalculoHoras.Name = "chkEsCalculoHoras"
            Me.chkEsCalculoHoras.Size = New System.Drawing.Size(132, 17)
            Me.chkEsCalculoHoras.TabIndex = 14
            Me.chkEsCalculoHoras.Text = "Es Para Calculo Horas"
            Me.chkEsCalculoHoras.UseVisualStyleBackColor = True
            '
            'chkEsCalculo
            '
            Me.chkEsCalculo.AutoSize = True
            Me.chkEsCalculo.Location = New System.Drawing.Point(6, 30)
            Me.chkEsCalculo.Name = "chkEsCalculo"
            Me.chkEsCalculo.Size = New System.Drawing.Size(76, 17)
            Me.chkEsCalculo.TabIndex = 13
            Me.chkEsCalculo.Text = "Es Calculo"
            Me.chkEsCalculo.UseVisualStyleBackColor = True
            '
            'chkEsFijo
            '
            Me.chkEsFijo.AutoSize = True
            Me.chkEsFijo.Location = New System.Drawing.Point(6, 10)
            Me.chkEsFijo.Name = "chkEsFijo"
            Me.chkEsFijo.Size = New System.Drawing.Size(110, 17)
            Me.chkEsFijo.TabIndex = 12
            Me.chkEsFijo.Text = "Es por Trabajador"
            Me.chkEsFijo.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(16, 81)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(71, 13)
            Me.Label6.TabIndex = 24
            Me.Label6.Text = "Codigo Sunat"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(10, 59)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(77, 13)
            Me.Label3.TabIndex = 18
            Me.Label3.Text = "Tipo Concepto"
            '
            'txtCodigoSunat
            '
            Me.txtCodigoSunat.Location = New System.Drawing.Point(91, 78)
            Me.txtCodigoSunat.MaxLength = 4
            Me.txtCodigoSunat.Name = "txtCodigoSunat"
            Me.txtCodigoSunat.Size = New System.Drawing.Size(61, 20)
            Me.txtCodigoSunat.TabIndex = 23
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(47, 10)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 13)
            Me.Label2.TabIndex = 15
            Me.Label2.Text = "Codigo"
            '
            'cboTipoConcepto
            '
            Me.cboTipoConcepto.FormattingEnabled = True
            Me.cboTipoConcepto.Location = New System.Drawing.Point(91, 54)
            Me.cboTipoConcepto.Name = "cboTipoConcepto"
            Me.cboTipoConcepto.Size = New System.Drawing.Size(306, 21)
            Me.cboTipoConcepto.TabIndex = 22
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(91, 10)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(31, 20)
            Me.txtCodigo.TabIndex = 16
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(91, 126)
            Me.txtDescripcion.MaxLength = 100
            Me.txtDescripcion.Multiline = True
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Size = New System.Drawing.Size(475, 45)
            Me.txtDescripcion.TabIndex = 21
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(91, 32)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.Size = New System.Drawing.Size(306, 20)
            Me.txtConcepto.TabIndex = 17
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(24, 129)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(63, 13)
            Me.Label5.TabIndex = 20
            Me.Label5.Text = "Descripcion"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(34, 34)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(53, 13)
            Me.Label4.TabIndex = 19
            Me.Label4.Text = "Concepto"
            '
            'frmConceptos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(586, 276)
            Me.Controls.Add(Me.Pan)
            Me.Name = "frmConceptos"
            Me.Text = "frmConceptos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Pan, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Pan.ResumeLayout(False)
            Me.Pan.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Pan As System.Windows.Forms.Panel
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents chkEsJuridico As System.Windows.Forms.CheckBox
        Friend WithEvents chkEsCalculoHoras As System.Windows.Forms.CheckBox
        Friend WithEvents chkEsCalculo As System.Windows.Forms.CheckBox
        Friend WithEvents chkEsFijo As System.Windows.Forms.CheckBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtCodigoSunat As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboTipoConcepto As System.Windows.Forms.ComboBox
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents chkEsPrestamo As System.Windows.Forms.CheckBox
        Friend WithEvents chkCrearFunction As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboNivelCalculo As System.Windows.Forms.ComboBox
        Friend WithEvents chkCrearFunctionSecundario As System.Windows.Forms.CheckBox
    End Class
End Namespace
