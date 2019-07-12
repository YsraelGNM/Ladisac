Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesTareaTrabajoExportar
        '  Inherits System.Windows.Forms.Form
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
            Me.btnTipo = New System.Windows.Forms.Button()
            Me.txtTipo = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(354, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnTipo)
            Me.Panel1.Controls.Add(Me.txtTipo)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(350, 93)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(175, 57)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 18
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnTipo
            '
            Me.btnTipo.Location = New System.Drawing.Point(256, 19)
            Me.btnTipo.Name = "btnTipo"
            Me.btnTipo.Size = New System.Drawing.Size(24, 23)
            Me.btnTipo.TabIndex = 17
            Me.btnTipo.Text = ":::"
            Me.btnTipo.UseVisualStyleBackColor = True
            '
            'txtTipo
            '
            Me.txtTipo.Location = New System.Drawing.Point(84, 22)
            Me.txtTipo.Name = "txtTipo"
            Me.txtTipo.ReadOnly = True
            Me.txtTipo.Size = New System.Drawing.Size(166, 20)
            Me.txtTipo.TabIndex = 16
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(51, 25)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(28, 13)
            Me.Label4.TabIndex = 15
            Me.Label4.Text = "Tipo"
            '
            'frmReportesTareaTrabajoExportar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(354, 128)
            Me.Controls.Add(Me.Panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmReportesTareaTrabajoExportar"
            Me.Text = "frmTareaTrabajoExportar"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTipo As System.Windows.Forms.Button
        Friend WithEvents txtTipo As System.Windows.Forms.TextBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
    End Class

End Namespace
