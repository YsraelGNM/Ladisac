Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteFechaPersona
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
            Me.lblTitle.Size = New System.Drawing.Size(420, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Location = New System.Drawing.Point(4, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(412, 103)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(261, 68)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(107, 23)
            Me.btnGenerar.TabIndex = 30
            Me.btnGenerar.Text = "Generar Excel"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(373, 40)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 24
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(72, 42)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(296, 20)
            Me.txtTrabajador.TabIndex = 23
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(9, 45)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 22
            Me.Label4.Text = "Trabajador"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(163, 22)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 21
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(29, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 20
            Me.Label1.Text = "Desde"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(204, 16)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(84, 20)
            Me.dateHasta.TabIndex = 19
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(72, 16)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(84, 20)
            Me.dateDesde.TabIndex = 18
            '
            'frmReporteFechaPersona
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(420, 140)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteFechaPersona"
            Me.Text = "frmReporteFechaPersona"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
    End Class

End Namespace
