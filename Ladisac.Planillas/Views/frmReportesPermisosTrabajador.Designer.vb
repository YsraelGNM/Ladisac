Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportesPermisosTrabajador
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
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.btnSituacionCL = New System.Windows.Forms.Button()
            Me.btnTipoCl = New System.Windows.Forms.Button()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnSituacionADD = New System.Windows.Forms.Button()
            Me.btnTipoADD = New System.Windows.Forms.Button()
            Me.txtAutoriza = New System.Windows.Forms.TextBox()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(438, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.btnSituacionCL)
            Me.Panel1.Controls.Add(Me.btnTipoCl)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnSituacionADD)
            Me.Panel1.Controls.Add(Me.btnTipoADD)
            Me.Panel1.Controls.Add(Me.txtAutoriza)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(3, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(431, 124)
            Me.Panel1.TabIndex = 2
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(53, 21)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(81, 13)
            Me.Label4.TabIndex = 13
            Me.Label4.Text = "Permisos desde"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(231, 21)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 12
            Me.Label3.Text = "Hasta"
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(141, 17)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(84, 20)
            Me.dateDesde.TabIndex = 11
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(271, 17)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(84, 20)
            Me.dateHasta.TabIndex = 10
            '
            'btnSituacionCL
            '
            Me.btnSituacionCL.Location = New System.Drawing.Point(395, 66)
            Me.btnSituacionCL.Name = "btnSituacionCL"
            Me.btnSituacionCL.Size = New System.Drawing.Size(28, 23)
            Me.btnSituacionCL.TabIndex = 9
            Me.btnSituacionCL.Text = "Cl"
            Me.btnSituacionCL.UseVisualStyleBackColor = True
            '
            'btnTipoCl
            '
            Me.btnTipoCl.Location = New System.Drawing.Point(396, 38)
            Me.btnTipoCl.Name = "btnTipoCl"
            Me.btnTipoCl.Size = New System.Drawing.Size(28, 23)
            Me.btnTipoCl.TabIndex = 8
            Me.btnTipoCl.Text = "Cl"
            Me.btnTipoCl.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(280, 94)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 6
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnSituacionADD
            '
            Me.btnSituacionADD.Location = New System.Drawing.Point(361, 67)
            Me.btnSituacionADD.Name = "btnSituacionADD"
            Me.btnSituacionADD.Size = New System.Drawing.Size(28, 23)
            Me.btnSituacionADD.TabIndex = 5
            Me.btnSituacionADD.Text = ":::"
            Me.btnSituacionADD.UseVisualStyleBackColor = True
            '
            'btnTipoADD
            '
            Me.btnTipoADD.Location = New System.Drawing.Point(362, 39)
            Me.btnTipoADD.Name = "btnTipoADD"
            Me.btnTipoADD.Size = New System.Drawing.Size(28, 23)
            Me.btnTipoADD.TabIndex = 4
            Me.btnTipoADD.Text = ":::"
            Me.btnTipoADD.UseVisualStyleBackColor = True
            '
            'txtAutoriza
            '
            Me.txtAutoriza.Location = New System.Drawing.Point(141, 68)
            Me.txtAutoriza.Name = "txtAutoriza"
            Me.txtAutoriza.ReadOnly = True
            Me.txtAutoriza.Size = New System.Drawing.Size(214, 20)
            Me.txtAutoriza.TabIndex = 3
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(141, 41)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(214, 20)
            Me.txtTrabajador.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(89, 71)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(45, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Autoriza"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(76, 43)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(58, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Trabajador"
            '
            'frmReportesPermisosTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(438, 159)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportesPermisosTrabajador"
            Me.Text = "frmReportesPermisosTrabajador"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnSituacionCL As System.Windows.Forms.Button
        Friend WithEvents btnTipoCl As System.Windows.Forms.Button
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnSituacionADD As System.Windows.Forms.Button
        Friend WithEvents btnTipoADD As System.Windows.Forms.Button
        Friend WithEvents txtAutoriza As System.Windows.Forms.TextBox
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class

End Namespace
