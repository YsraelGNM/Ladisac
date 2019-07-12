Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportePersonaTipoFichas
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
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtAreaTrabajo = New System.Windows.Forms.TextBox()
            Me.btnAreaTrabajo = New System.Windows.Forms.Button()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnTipoADD = New System.Windows.Forms.Button()
            Me.txtTipos = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(462, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.Label16)
            Me.Panel1.Controls.Add(Me.txtAreaTrabajo)
            Me.Panel1.Controls.Add(Me.btnAreaTrabajo)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnTipoADD)
            Me.Panel1.Controls.Add(Me.txtTipos)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Location = New System.Drawing.Point(5, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(453, 150)
            Me.Panel1.TabIndex = 1
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(31, 46)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(83, 13)
            Me.Label16.TabIndex = 24
            Me.Label16.Text = "Area de Trabajo"
            '
            'txtAreaTrabajo
            '
            Me.txtAreaTrabajo.Location = New System.Drawing.Point(117, 42)
            Me.txtAreaTrabajo.Name = "txtAreaTrabajo"
            Me.txtAreaTrabajo.ReadOnly = True
            Me.txtAreaTrabajo.Size = New System.Drawing.Size(295, 20)
            Me.txtAreaTrabajo.TabIndex = 23
            '
            'btnAreaTrabajo
            '
            Me.btnAreaTrabajo.Location = New System.Drawing.Point(418, 39)
            Me.btnAreaTrabajo.Name = "btnAreaTrabajo"
            Me.btnAreaTrabajo.Size = New System.Drawing.Size(26, 23)
            Me.btnAreaTrabajo.TabIndex = 22
            Me.btnAreaTrabajo.Text = ":::"
            Me.btnAreaTrabajo.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(338, 114)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 21
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnTipoADD
            '
            Me.btnTipoADD.Location = New System.Drawing.Point(418, 63)
            Me.btnTipoADD.Name = "btnTipoADD"
            Me.btnTipoADD.Size = New System.Drawing.Size(28, 23)
            Me.btnTipoADD.TabIndex = 20
            Me.btnTipoADD.Text = ":::"
            Me.btnTipoADD.UseVisualStyleBackColor = True
            '
            'txtTipos
            '
            Me.txtTipos.Location = New System.Drawing.Point(117, 65)
            Me.txtTipos.Name = "txtTipos"
            Me.txtTipos.ReadOnly = True
            Me.txtTipos.Size = New System.Drawing.Size(295, 20)
            Me.txtTipos.TabIndex = 19
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(8, 69)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(102, 13)
            Me.Label1.TabIndex = 18
            Me.Label1.Text = "Tipos de Trabajador"
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(418, 86)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(28, 23)
            Me.btnTrabajador.TabIndex = 17
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(117, 88)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(296, 20)
            Me.txtTrabajador.TabIndex = 16
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(51, 91)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 15
            Me.Label4.Text = "Trabajador"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.dateDesde)
            Me.Panel2.Controls.Add(Me.dateHasta)
            Me.Panel2.Location = New System.Drawing.Point(8, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(436, 32)
            Me.Panel2.TabIndex = 25
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(319, 4)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(85, 20)
            Me.dateHasta.TabIndex = 0
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(109, 4)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(85, 20)
            Me.dateDesde.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(5, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(98, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Fecha Vencimiento"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(278, 7)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Hasta"
            '
            'frmReportePersonaTipoFichas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(462, 184)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportePersonaTipoFichas"
            Me.Text = "frmReportePersonaTipoFichas"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnTipoADD As System.Windows.Forms.Button
        Friend WithEvents txtTipos As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtAreaTrabajo As System.Windows.Forms.TextBox
        Friend WithEvents btnAreaTrabajo As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
    End Class

End Namespace
