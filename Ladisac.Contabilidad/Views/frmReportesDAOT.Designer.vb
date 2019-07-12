Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesDAOT
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
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.rdbCompraAcumulado = New System.Windows.Forms.RadioButton()
            Me.rdbComprasDetalle = New System.Windows.Forms.RadioButton()
            Me.rdbVentaAcumulado = New System.Windows.Forms.RadioButton()
            Me.rdbVentaDetalle = New System.Windows.Forms.RadioButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnCancelar = New System.Windows.Forms.Button()
            Me.txtAño = New System.Windows.Forms.TextBox()
            Me.PanelLibro = New System.Windows.Forms.Panel()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.btnPersona = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.PanelLibro.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(621, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.PanelLibro)
            Me.Panel1.Controls.Add(Me.txtAño)
            Me.Panel1.Controls.Add(Me.btnCancelar)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(613, 134)
            Me.Panel1.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.rdbVentaDetalle)
            Me.Panel2.Controls.Add(Me.rdbVentaAcumulado)
            Me.Panel2.Controls.Add(Me.rdbComprasDetalle)
            Me.Panel2.Controls.Add(Me.rdbCompraAcumulado)
            Me.Panel2.Location = New System.Drawing.Point(461, 10)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(149, 116)
            Me.Panel2.TabIndex = 0
            '
            'rdbCompraAcumulado
            '
            Me.rdbCompraAcumulado.AutoSize = True
            Me.rdbCompraAcumulado.Checked = True
            Me.rdbCompraAcumulado.Location = New System.Drawing.Point(14, 16)
            Me.rdbCompraAcumulado.Name = "rdbCompraAcumulado"
            Me.rdbCompraAcumulado.Size = New System.Drawing.Size(122, 17)
            Me.rdbCompraAcumulado.TabIndex = 0
            Me.rdbCompraAcumulado.TabStop = True
            Me.rdbCompraAcumulado.Text = "Compras Acumulado"
            Me.rdbCompraAcumulado.UseVisualStyleBackColor = True
            '
            'rdbComprasDetalle
            '
            Me.rdbComprasDetalle.AutoSize = True
            Me.rdbComprasDetalle.Location = New System.Drawing.Point(14, 39)
            Me.rdbComprasDetalle.Name = "rdbComprasDetalle"
            Me.rdbComprasDetalle.Size = New System.Drawing.Size(102, 17)
            Me.rdbComprasDetalle.TabIndex = 1
            Me.rdbComprasDetalle.Text = "Compras Detalle"
            Me.rdbComprasDetalle.UseVisualStyleBackColor = True
            '
            'rdbVentaAcumulado
            '
            Me.rdbVentaAcumulado.AutoSize = True
            Me.rdbVentaAcumulado.Location = New System.Drawing.Point(14, 57)
            Me.rdbVentaAcumulado.Name = "rdbVentaAcumulado"
            Me.rdbVentaAcumulado.Size = New System.Drawing.Size(114, 17)
            Me.rdbVentaAcumulado.TabIndex = 2
            Me.rdbVentaAcumulado.Text = "Ventas Acumulado"
            Me.rdbVentaAcumulado.UseVisualStyleBackColor = True
            '
            'rdbVentaDetalle
            '
            Me.rdbVentaDetalle.AutoSize = True
            Me.rdbVentaDetalle.Location = New System.Drawing.Point(14, 80)
            Me.rdbVentaDetalle.Name = "rdbVentaDetalle"
            Me.rdbVentaDetalle.Size = New System.Drawing.Size(94, 17)
            Me.rdbVentaDetalle.TabIndex = 3
            Me.rdbVentaDetalle.Text = "Ventas Detalle"
            Me.rdbVentaDetalle.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(48, 27)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(26, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Año"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(243, 99)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 2
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnCancelar
            '
            Me.btnCancelar.Location = New System.Drawing.Point(324, 99)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.btnCancelar.TabIndex = 3
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'txtAño
            '
            Me.txtAño.Location = New System.Drawing.Point(86, 27)
            Me.txtAño.Name = "txtAño"
            Me.txtAño.Size = New System.Drawing.Size(100, 20)
            Me.txtAño.TabIndex = 4
            '
            'PanelLibro
            '
            Me.PanelLibro.Controls.Add(Me.txtPersona)
            Me.PanelLibro.Controls.Add(Me.btnPersona)
            Me.PanelLibro.Controls.Add(Me.Label2)
            Me.PanelLibro.Location = New System.Drawing.Point(3, 53)
            Me.PanelLibro.Name = "PanelLibro"
            Me.PanelLibro.Size = New System.Drawing.Size(427, 24)
            Me.PanelLibro.TabIndex = 8
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(83, 1)
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
            'frmReportesDAOT
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(621, 171)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesDAOT"
            Me.Text = "frmReportesDAOT"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.PanelLibro.ResumeLayout(False)
            Me.PanelLibro.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents rdbVentaAcumulado As System.Windows.Forms.RadioButton
        Friend WithEvents rdbComprasDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents rdbCompraAcumulado As System.Windows.Forms.RadioButton
        Friend WithEvents txtAño As System.Windows.Forms.TextBox
        Friend WithEvents btnCancelar As System.Windows.Forms.Button
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents rdbVentaDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents PanelLibro As System.Windows.Forms.Panel
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnPersona As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
    End Class

End Namespace
