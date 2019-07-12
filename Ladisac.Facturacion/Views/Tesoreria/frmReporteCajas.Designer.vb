Namespace Ladisac.Tesoreria.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteCajas
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.rbResumen = New System.Windows.Forms.RadioButton()
            Me.rbDetalle = New System.Windows.Forms.RadioButton()
            Me.grbTipoReporte = New System.Windows.Forms.GroupBox()
            Me.rbDetalle1 = New System.Windows.Forms.RadioButton()
            Me.grbTipoReporte.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(509, 28)
            Me.lblTitle.Text = "Reporte caja bancos por documento de origen"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(27, 51)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Desde"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(269, 51)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Hasta"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(73, 131)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(85, 31)
            Me.btnGenerar.TabIndex = 4
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(73, 51)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(85, 20)
            Me.dateDesde.TabIndex = 1
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(310, 51)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(85, 20)
            Me.dateHasta.TabIndex = 2
            '
            'rbResumen
            '
            Me.rbResumen.AutoSize = True
            Me.rbResumen.Checked = True
            Me.rbResumen.Location = New System.Drawing.Point(19, 18)
            Me.rbResumen.Name = "rbResumen"
            Me.rbResumen.Size = New System.Drawing.Size(70, 17)
            Me.rbResumen.TabIndex = 7
            Me.rbResumen.TabStop = True
            Me.rbResumen.Text = "Resumen"
            Me.rbResumen.UseVisualStyleBackColor = True
            '
            'rbDetalle
            '
            Me.rbDetalle.AutoSize = True
            Me.rbDetalle.Location = New System.Drawing.Point(119, 18)
            Me.rbDetalle.Name = "rbDetalle"
            Me.rbDetalle.Size = New System.Drawing.Size(58, 17)
            Me.rbDetalle.TabIndex = 8
            Me.rbDetalle.Text = "Detalle"
            Me.rbDetalle.UseVisualStyleBackColor = True
            '
            'grbTipoReporte
            '
            Me.grbTipoReporte.Controls.Add(Me.rbDetalle1)
            Me.grbTipoReporte.Controls.Add(Me.rbResumen)
            Me.grbTipoReporte.Controls.Add(Me.rbDetalle)
            Me.grbTipoReporte.Location = New System.Drawing.Point(73, 77)
            Me.grbTipoReporte.Name = "grbTipoReporte"
            Me.grbTipoReporte.Size = New System.Drawing.Size(322, 41)
            Me.grbTipoReporte.TabIndex = 3
            Me.grbTipoReporte.TabStop = False
            Me.grbTipoReporte.Text = "Visualización"
            '
            'rbDetalle1
            '
            Me.rbDetalle1.AutoSize = True
            Me.rbDetalle1.Location = New System.Drawing.Point(211, 18)
            Me.rbDetalle1.Name = "rbDetalle1"
            Me.rbDetalle1.Size = New System.Drawing.Size(103, 17)
            Me.rbDetalle1.TabIndex = 9
            Me.rbDetalle1.Text = "Detalle con doc."
            Me.rbDetalle1.UseVisualStyleBackColor = True
            '
            'frmReporteCajas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(509, 174)
            Me.Controls.Add(Me.grbTipoReporte)
            Me.Controls.Add(Me.dateHasta)
            Me.Controls.Add(Me.dateDesde)
            Me.Controls.Add(Me.btnGenerar)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Name = "frmReporteCajas"
            Me.Text = "Reporte caja bancos por documento de origen"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.btnGenerar, 0)
            Me.Controls.SetChildIndex(Me.dateDesde, 0)
            Me.Controls.SetChildIndex(Me.dateHasta, 0)
            Me.Controls.SetChildIndex(Me.grbTipoReporte, 0)
            Me.grbTipoReporte.ResumeLayout(False)
            Me.grbTipoReporte.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
        Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents grbTipoReporte As System.Windows.Forms.GroupBox
        Friend WithEvents rbDetalle1 As System.Windows.Forms.RadioButton
    End Class

End Namespace
