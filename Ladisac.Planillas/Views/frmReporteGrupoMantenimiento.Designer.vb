Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteGrupoMantenimiento
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
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.rdbDetalle = New System.Windows.Forms.RadioButton()
            Me.rdbAgrupar = New System.Windows.Forms.RadioButton()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(424, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.rdbDetalle)
            Me.Panel1.Controls.Add(Me.rdbAgrupar)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(416, 109)
            Me.Panel1.TabIndex = 2
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(219, 7)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(91, 20)
            Me.dateHasta.TabIndex = 20
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(177, 9)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 19
            Me.Label2.Text = "Hasta"
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(76, 7)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(91, 20)
            Me.dateDesde.TabIndex = 18
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(34, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Desde"
            '
            'rdbDetalle
            '
            Me.rdbDetalle.AutoSize = True
            Me.rdbDetalle.Location = New System.Drawing.Point(219, 55)
            Me.rdbDetalle.Name = "rdbDetalle"
            Me.rdbDetalle.Size = New System.Drawing.Size(111, 17)
            Me.rdbDetalle.TabIndex = 16
            Me.rdbDetalle.Text = "Reporte Detallado"
            Me.rdbDetalle.UseVisualStyleBackColor = True
            '
            'rdbAgrupar
            '
            Me.rdbAgrupar.AutoSize = True
            Me.rdbAgrupar.Checked = True
            Me.rdbAgrupar.Location = New System.Drawing.Point(76, 55)
            Me.rdbAgrupar.Name = "rdbAgrupar"
            Me.rdbAgrupar.Size = New System.Drawing.Size(112, 17)
            Me.rdbAgrupar.TabIndex = 15
            Me.rdbAgrupar.TabStop = True
            Me.rdbAgrupar.Text = "Reporte Agrupado"
            Me.rdbAgrupar.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(377, 27)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(28, 23)
            Me.btnTrabajador.TabIndex = 14
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(76, 29)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(296, 20)
            Me.txtTrabajador.TabIndex = 13
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(10, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Trabajador"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(330, 79)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 0
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmReporteGrupoMantenimiento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(424, 144)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteGrupoMantenimiento"
            Me.Text = "frmReporteGrupoMantenimiento"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents rdbDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents rdbAgrupar As System.Windows.Forms.RadioButton
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace
