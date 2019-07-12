Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesXPersona
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
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelLibro = New System.Windows.Forms.Panel()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.PanelLibro.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(468, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.PanelLibro)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(461, 83)
            Me.Panel1.TabIndex = 2
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(211, 7)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "Hasta"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(266, 3)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(90, 20)
            Me.dateHasta.TabIndex = 10
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(80, 4)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(90, 20)
            Me.dateDesde.TabIndex = 9
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(36, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "Desde"
            '
            'PanelLibro
            '
            Me.PanelLibro.Controls.Add(Me.txtPersona)
            Me.PanelLibro.Controls.Add(Me.btnPersona)
            Me.PanelLibro.Controls.Add(Me.Label2)
            Me.PanelLibro.Location = New System.Drawing.Point(3, 30)
            Me.PanelLibro.Name = "PanelLibro"
            Me.PanelLibro.Size = New System.Drawing.Size(427, 24)
            Me.PanelLibro.TabIndex = 7
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(77, 2)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(313, 20)
            Me.txtPersona.TabIndex = 5
            '
            'btnPersona
            '
            Me.btnPersona.Location = New System.Drawing.Point(396, 1)
            Me.btnPersona.Name = "btnPersona"
            Me.btnPersona.Size = New System.Drawing.Size(28, 23)
            Me.btnPersona.TabIndex = 6
            Me.btnPersona.Text = ":::"
            Me.btnPersona.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(25, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 13)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Persona"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(266, 55)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 3
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmReportesXPersona
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(468, 119)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesXPersona"
            Me.Text = "frmReportesXPersona"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.PanelLibro.ResumeLayout(False)
            Me.PanelLibro.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents PanelLibro As System.Windows.Forms.Panel
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class

End Namespace