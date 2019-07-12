Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesCentroCosto
        ' Inherits System.Windows.Forms.Form
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
            Me.btnCentroCosto = New System.Windows.Forms.Button()
            Me.txtcentroCosto = New System.Windows.Forms.TextBox()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnPeriodoFinal = New System.Windows.Forms.Button()
            Me.txtPeriodoFinal = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnPeriodoinicial = New System.Windows.Forms.Button()
            Me.txtPeriodoinicial = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(469, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Button2)
            Me.Panel1.Controls.Add(Me.Button1)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnCentroCosto)
            Me.Panel1.Controls.Add(Me.txtcentroCosto)
            Me.Panel1.Controls.Add(Me.Label29)
            Me.Panel1.Controls.Add(Me.txtPersona)
            Me.Panel1.Controls.Add(Me.btnPersona)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnPeriodoFinal)
            Me.Panel1.Controls.Add(Me.txtPeriodoFinal)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.btnPeriodoinicial)
            Me.Panel1.Controls.Add(Me.txtPeriodoinicial)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(5, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(461, 143)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(308, 106)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 4
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnCentroCosto
            '
            Me.btnCentroCosto.Location = New System.Drawing.Point(389, 80)
            Me.btnCentroCosto.Name = "btnCentroCosto"
            Me.btnCentroCosto.Size = New System.Drawing.Size(27, 23)
            Me.btnCentroCosto.TabIndex = 63
            Me.btnCentroCosto.Text = ":::"
            Me.btnCentroCosto.UseVisualStyleBackColor = True
            '
            'txtcentroCosto
            '
            Me.txtcentroCosto.Enabled = False
            Me.txtcentroCosto.Location = New System.Drawing.Point(98, 80)
            Me.txtcentroCosto.Name = "txtcentroCosto"
            Me.txtcentroCosto.ReadOnly = True
            Me.txtcentroCosto.Size = New System.Drawing.Size(285, 20)
            Me.txtcentroCosto.TabIndex = 65
            '
            'Label29
            '
            Me.Label29.AutoSize = True
            Me.Label29.Location = New System.Drawing.Point(24, 83)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(68, 13)
            Me.Label29.TabIndex = 64
            Me.Label29.Text = "Centro Costo"
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(98, 58)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(285, 20)
            Me.txtPersona.TabIndex = 10
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(389, 54)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(28, 23)
            Me.btnPersona.TabIndex = 11
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(46, 62)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(46, 13)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Persona"
            '
            'btnPeriodoFinal
            '
            Me.btnPeriodoFinal.Location = New System.Drawing.Point(188, 33)
            Me.btnPeriodoFinal.Name = "btnPeriodoFinal"
            Me.btnPeriodoFinal.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodoFinal.TabIndex = 8
            Me.btnPeriodoFinal.Text = ":::"
            Me.btnPeriodoFinal.UseVisualStyleBackColor = True
            '
            'txtPeriodoFinal
            '
            Me.txtPeriodoFinal.Location = New System.Drawing.Point(98, 36)
            Me.txtPeriodoFinal.Name = "txtPeriodoFinal"
            Me.txtPeriodoFinal.ReadOnly = True
            Me.txtPeriodoFinal.Size = New System.Drawing.Size(84, 20)
            Me.txtPeriodoFinal.TabIndex = 7
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(13, 39)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(79, 13)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Buscar Periodo"
            '
            'btnPeriodoinicial
            '
            Me.btnPeriodoinicial.Location = New System.Drawing.Point(188, 11)
            Me.btnPeriodoinicial.Name = "btnPeriodoinicial"
            Me.btnPeriodoinicial.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodoinicial.TabIndex = 5
            Me.btnPeriodoinicial.Text = ":::"
            Me.btnPeriodoinicial.UseVisualStyleBackColor = True
            '
            'txtPeriodoinicial
            '
            Me.txtPeriodoinicial.Location = New System.Drawing.Point(98, 14)
            Me.txtPeriodoinicial.Name = "txtPeriodoinicial"
            Me.txtPeriodoinicial.ReadOnly = True
            Me.txtPeriodoinicial.Size = New System.Drawing.Size(84, 20)
            Me.txtPeriodoinicial.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(13, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(79, 13)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Buscar Periodo"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(421, 54)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(28, 23)
            Me.Button1.TabIndex = 66
            Me.Button1.Text = "CL"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(421, 80)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(28, 23)
            Me.Button2.TabIndex = 67
            Me.Button2.Text = "CL"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'frmReportesCentroCosto
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(469, 177)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesCentroCosto"
            Me.Text = "frmReportesCentroCosto"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnPeriodoFinal As System.Windows.Forms.Button
        Friend WithEvents txtPeriodoFinal As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPeriodoinicial As System.Windows.Forms.Button
        Friend WithEvents txtPeriodoinicial As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCentroCosto As System.Windows.Forms.Button
        Friend WithEvents txtcentroCosto As System.Windows.Forms.TextBox
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
    End Class

End Namespace