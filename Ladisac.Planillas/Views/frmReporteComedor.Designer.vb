Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteComedor
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
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnNumero = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.btnConceptoBuscar = New System.Windows.Forms.Button()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(417, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.txtNumero)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnNumero)
            Me.Panel1.Controls.Add(Me.txtPersona)
            Me.Panel1.Controls.Add(Me.Label13)
            Me.Panel1.Controls.Add(Me.btnPersona)
            Me.Panel1.Controls.Add(Me.btnConceptoBuscar)
            Me.Panel1.Controls.Add(Me.txtTipoConcepto)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.txtConcepto)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(409, 153)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(292, 114)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 29
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(92, 100)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(90, 20)
            Me.txtNumero.TabIndex = 28
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(44, 103)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(44, 13)
            Me.Label3.TabIndex = 27
            Me.Label3.Text = "Numero"
            '
            'btnNumero
            '
            Me.btnNumero.Location = New System.Drawing.Point(184, 98)
            Me.btnNumero.Name = "btnNumero"
            Me.btnNumero.Size = New System.Drawing.Size(25, 23)
            Me.btnNumero.TabIndex = 26
            Me.btnNumero.Text = ":::"
            Me.btnNumero.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(92, 33)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(276, 20)
            Me.txtPersona.TabIndex = 25
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(13, 36)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(73, 13)
            Me.Label13.TabIndex = 24
            Me.Label13.Text = "Entrega datos"
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(373, 30)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(24, 23)
            Me.btnPersona.TabIndex = 23
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'btnConceptoBuscar
            '
            Me.btnConceptoBuscar.Location = New System.Drawing.Point(373, 77)
            Me.btnConceptoBuscar.Name = "btnConceptoBuscar"
            Me.btnConceptoBuscar.Size = New System.Drawing.Size(24, 23)
            Me.btnConceptoBuscar.TabIndex = 22
            Me.btnConceptoBuscar.Text = ":::"
            Me.btnConceptoBuscar.UseVisualStyleBackColor = True
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(92, 77)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(90, 20)
            Me.txtTipoConcepto.TabIndex = 19
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(35, 80)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(53, 13)
            Me.Label7.TabIndex = 20
            Me.Label7.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(185, 77)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(182, 20)
            Me.txtConcepto.TabIndex = 21
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(373, 53)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 17
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(92, 55)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(276, 20)
            Me.txtTrabajador.TabIndex = 16
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(18, 58)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(70, 13)
            Me.Label4.TabIndex = 15
            Me.Label4.Text = "Recibe datos"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(183, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(50, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Desde"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(224, 7)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(84, 20)
            Me.dateHasta.TabIndex = 1
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(92, 7)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(84, 20)
            Me.dateDesde.TabIndex = 0
            '
            'frmReporteComedor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(417, 191)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteComedor"
            Me.Text = "Reporte Conceptos"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnConceptoBuscar As System.Windows.Forms.Button
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnNumero As System.Windows.Forms.Button
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
    End Class

End Namespace