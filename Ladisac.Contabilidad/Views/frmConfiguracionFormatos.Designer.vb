
Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConfiguracionFormatos
        Inherits ViewManMasterContabilidad

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
            Me.components = New System.ComponentModel.Container()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.txtCuentaDesde = New System.Windows.Forms.TextBox()
            Me.btnCuentaDesde = New System.Windows.Forms.Button()
            Me.txtCuentaDesdeDescripcion = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtCuentaHastaDescripcion = New System.Windows.Forms.TextBox()
            Me.btnCuentaHasta = New System.Windows.Forms.Button()
            Me.txtCuentaHasta = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(575, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.txtCuentaHastaDescripcion)
            Me.Panel1.Controls.Add(Me.btnCuentaHasta)
            Me.Panel1.Controls.Add(Me.txtCuentaHasta)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.txtCuentaDesdeDescripcion)
            Me.Panel1.Controls.Add(Me.btnCuentaDesde)
            Me.Panel1.Controls.Add(Me.txtCuentaDesde)
            Me.Panel1.Controls.Add(Me.txtDescripcion)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtCodigo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(566, 120)
            Me.Panel1.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(62, 18)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Codigo"
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(108, 15)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(39, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(63, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Descripcion"
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(108, 37)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.ReadOnly = True
            Me.txtDescripcion.Size = New System.Drawing.Size(432, 20)
            Me.txtDescripcion.TabIndex = 3
            '
            'txtCuentaDesde
            '
            Me.txtCuentaDesde.Location = New System.Drawing.Point(108, 60)
            Me.txtCuentaDesde.Name = "txtCuentaDesde"
            Me.txtCuentaDesde.ReadOnly = True
            Me.txtCuentaDesde.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaDesde.TabIndex = 4
            '
            'btnCuentaDesde
            '
            Me.btnCuentaDesde.Location = New System.Drawing.Point(210, 59)
            Me.btnCuentaDesde.Name = "btnCuentaDesde"
            Me.btnCuentaDesde.Size = New System.Drawing.Size(29, 23)
            Me.btnCuentaDesde.TabIndex = 5
            Me.btnCuentaDesde.Text = "Button1"
            Me.btnCuentaDesde.UseVisualStyleBackColor = True
            '
            'txtCuentaDesdeDescripcion
            '
            Me.txtCuentaDesdeDescripcion.Location = New System.Drawing.Point(242, 60)
            Me.txtCuentaDesdeDescripcion.Name = "txtCuentaDesdeDescripcion"
            Me.txtCuentaDesdeDescripcion.ReadOnly = True
            Me.txtCuentaDesdeDescripcion.Size = New System.Drawing.Size(298, 20)
            Me.txtCuentaDesdeDescripcion.TabIndex = 6
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(16, 63)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(86, 13)
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Desde la Cuenta"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(19, 86)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(83, 13)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Hasta la Cuenta"
            '
            'txtCuentaHastaDescripcion
            '
            Me.txtCuentaHastaDescripcion.Location = New System.Drawing.Point(242, 83)
            Me.txtCuentaHastaDescripcion.Name = "txtCuentaHastaDescripcion"
            Me.txtCuentaHastaDescripcion.ReadOnly = True
            Me.txtCuentaHastaDescripcion.Size = New System.Drawing.Size(298, 20)
            Me.txtCuentaHastaDescripcion.TabIndex = 11
            '
            'btnCuentaHasta
            '
            Me.btnCuentaHasta.Location = New System.Drawing.Point(210, 82)
            Me.btnCuentaHasta.Name = "btnCuentaHasta"
            Me.btnCuentaHasta.Size = New System.Drawing.Size(29, 23)
            Me.btnCuentaHasta.TabIndex = 10
            Me.btnCuentaHasta.Text = "Button2"
            Me.btnCuentaHasta.UseVisualStyleBackColor = True
            '
            'txtCuentaHasta
            '
            Me.txtCuentaHasta.Location = New System.Drawing.Point(108, 83)
            Me.txtCuentaHasta.Name = "txtCuentaHasta"
            Me.txtCuentaHasta.ReadOnly = True
            Me.txtCuentaHasta.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaHasta.TabIndex = 9
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmConfiguracionFormatos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(575, 180)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmConfiguracionFormatos"
            Me.Text = "frmConfiguracionFormatos"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtCuentaHastaDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnCuentaHasta As System.Windows.Forms.Button
        Friend WithEvents txtCuentaHasta As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtCuentaDesdeDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnCuentaDesde As System.Windows.Forms.Button
        Friend WithEvents txtCuentaDesde As System.Windows.Forms.TextBox
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class

End Namespace