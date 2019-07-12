Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTiposPlanillas
        Inherits ViewManMasterPlanillas
        'Inherits System.Windows.Forms.Form

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
            Me.chkEsGrupoPLanillas = New System.Windows.Forms.CheckBox()
            Me.txtTipoPlanilla = New System.Windows.Forms.TextBox()
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
            Me.lblTitle.Size = New System.Drawing.Size(409, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.chkEsGrupoPLanillas)
            Me.Panel1.Controls.Add(Me.txtTipoPlanilla)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtCodigo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(12, 64)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(385, 95)
            Me.Panel1.TabIndex = 3
            '
            'chkEsGrupoPLanillas
            '
            Me.chkEsGrupoPLanillas.AutoSize = True
            Me.chkEsGrupoPLanillas.Location = New System.Drawing.Point(131, 57)
            Me.chkEsGrupoPLanillas.Name = "chkEsGrupoPLanillas"
            Me.chkEsGrupoPLanillas.Size = New System.Drawing.Size(146, 17)
            Me.chkEsGrupoPLanillas.TabIndex = 12
            Me.chkEsGrupoPLanillas.Text = "Es Agrupador de Planillas"
            Me.chkEsGrupoPLanillas.UseVisualStyleBackColor = True
            '
            'txtTipoPlanilla
            '
            Me.txtTipoPlanilla.Location = New System.Drawing.Point(131, 31)
            Me.txtTipoPlanilla.MaxLength = 100
            Me.txtTipoPlanilla.Name = "txtTipoPlanilla"
            Me.txtTipoPlanilla.Size = New System.Drawing.Size(208, 20)
            Me.txtTipoPlanilla.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(43, 36)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(82, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Tipo  de Planilla"
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(131, 7)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(85, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Codigo"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmTiposPlanillas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(409, 163)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmTiposPlanillas"
            Me.Text = "Tipo de Planilla"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtTipoPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkEsGrupoPLanillas As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class

End Namespace