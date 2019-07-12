Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAreaTrabajos
        'Inherits System.Windows.Forms.Form
        Inherits ViewManMasterPlanillas
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
            Me.chkEsPlanilla = New System.Windows.Forms.CheckBox()
            Me.txtCodigoSunat = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtAreaTrabajo = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(414, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.chkEsPlanilla)
            Me.Panel1.Controls.Add(Me.txtCodigoSunat)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.txtAreaTrabajo)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtCodigo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(12, 65)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(394, 125)
            Me.Panel1.TabIndex = 3
            '
            'chkEsPlanilla
            '
            Me.chkEsPlanilla.AutoSize = True
            Me.chkEsPlanilla.Location = New System.Drawing.Point(129, 95)
            Me.chkEsPlanilla.Name = "chkEsPlanilla"
            Me.chkEsPlanilla.Size = New System.Drawing.Size(103, 17)
            Me.chkEsPlanilla.TabIndex = 12
            Me.chkEsPlanilla.Text = "Es para Planillas"
            Me.chkEsPlanilla.UseVisualStyleBackColor = True
            '
            'txtCodigoSunat
            '
            Me.txtCodigoSunat.Location = New System.Drawing.Point(129, 57)
            Me.txtCodigoSunat.MaxLength = 3
            Me.txtCodigoSunat.Name = "txtCodigoSunat"
            Me.txtCodigoSunat.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoSunat.TabIndex = 11
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(53, 61)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Codigo Sunat"
            '
            'txtAreaTrabajo
            '
            Me.txtAreaTrabajo.Location = New System.Drawing.Point(129, 34)
            Me.txtAreaTrabajo.MaxLength = 100
            Me.txtAreaTrabajo.Name = "txtAreaTrabajo"
            Me.txtAreaTrabajo.Size = New System.Drawing.Size(208, 20)
            Me.txtAreaTrabajo.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(41, 37)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(83, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Area de Trabajo"
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(129, 11)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(84, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Codigo"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmAreaTrabajos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(414, 204)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmAreaTrabajos"
            Me.Text = "frmAreaTrabajos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtCodigoSunat As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtAreaTrabajo As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents chkEsPlanilla As System.Windows.Forms.CheckBox
    End Class
End Namespace