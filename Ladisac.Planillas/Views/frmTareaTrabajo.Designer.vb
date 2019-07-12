
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTareaTrabajo
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
            Me.chkTareoPll = New System.Windows.Forms.CheckBox()
            Me.btnLimpia = New System.Windows.Forms.Button()
            Me.btnArticulo = New System.Windows.Forms.Button()
            Me.txtArticulo = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.btnTipo = New System.Windows.Forms.Button()
            Me.txtTipo = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtfactor = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTarea = New System.Windows.Forms.TextBox()
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
            Me.lblTitle.Size = New System.Drawing.Size(542, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.chkTareoPll)
            Me.Panel1.Controls.Add(Me.btnLimpia)
            Me.Panel1.Controls.Add(Me.btnArticulo)
            Me.Panel1.Controls.Add(Me.txtArticulo)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.chkActivo)
            Me.Panel1.Controls.Add(Me.btnTipo)
            Me.Panel1.Controls.Add(Me.txtTipo)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtfactor)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.txtTarea)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtCodigo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(8, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(528, 167)
            Me.Panel1.TabIndex = 3
            '
            'chkTareoPll
            '
            Me.chkTareoPll.AutoSize = True
            Me.chkTareoPll.Location = New System.Drawing.Point(288, 136)
            Me.chkTareoPll.Name = "chkTareoPll"
            Me.chkTareoPll.Size = New System.Drawing.Size(216, 17)
            Me.chkTareoPll.TabIndex = 20
            Me.chkTareoPll.Text = "Se Aplica para Destajo / Planillas Pagos"
            Me.chkTareoPll.UseVisualStyleBackColor = True
            '
            'btnLimpia
            '
            Me.btnLimpia.Location = New System.Drawing.Point(476, 60)
            Me.btnLimpia.Name = "btnLimpia"
            Me.btnLimpia.Size = New System.Drawing.Size(23, 23)
            Me.btnLimpia.TabIndex = 19
            Me.btnLimpia.Text = "CL"
            Me.btnLimpia.UseVisualStyleBackColor = True
            '
            'btnArticulo
            '
            Me.btnArticulo.Location = New System.Drawing.Point(449, 61)
            Me.btnArticulo.Name = "btnArticulo"
            Me.btnArticulo.Size = New System.Drawing.Size(25, 23)
            Me.btnArticulo.TabIndex = 18
            Me.btnArticulo.Text = ":::"
            Me.btnArticulo.UseVisualStyleBackColor = True
            '
            'txtArticulo
            '
            Me.txtArticulo.Location = New System.Drawing.Point(131, 64)
            Me.txtArticulo.Name = "txtArticulo"
            Me.txtArticulo.ReadOnly = True
            Me.txtArticulo.Size = New System.Drawing.Size(312, 20)
            Me.txtArticulo.TabIndex = 17
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(84, 68)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(42, 13)
            Me.Label5.TabIndex = 16
            Me.Label5.Text = "Articulo"
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(131, 136)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(56, 17)
            Me.chkActivo.TabIndex = 15
            Me.chkActivo.Text = "Activo"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'btnTipo
            '
            Me.btnTipo.Location = New System.Drawing.Point(233, 39)
            Me.btnTipo.Name = "btnTipo"
            Me.btnTipo.Size = New System.Drawing.Size(24, 23)
            Me.btnTipo.TabIndex = 14
            Me.btnTipo.Text = ":::"
            Me.btnTipo.UseVisualStyleBackColor = True
            '
            'txtTipo
            '
            Me.txtTipo.Location = New System.Drawing.Point(131, 42)
            Me.txtTipo.Name = "txtTipo"
            Me.txtTipo.ReadOnly = True
            Me.txtTipo.Size = New System.Drawing.Size(100, 20)
            Me.txtTipo.TabIndex = 13
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(98, 45)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(28, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Tipo"
            '
            'txtfactor
            '
            Me.txtfactor.Location = New System.Drawing.Point(131, 109)
            Me.txtfactor.MaxLength = 7
            Me.txtfactor.Name = "txtfactor"
            Me.txtfactor.Size = New System.Drawing.Size(100, 20)
            Me.txtfactor.TabIndex = 11
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(89, 112)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(37, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Factor"
            '
            'txtTarea
            '
            Me.txtTarea.Location = New System.Drawing.Point(131, 86)
            Me.txtTarea.MaxLength = 150
            Me.txtTarea.Name = "txtTarea"
            Me.txtTarea.Size = New System.Drawing.Size(373, 20)
            Me.txtTarea.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(91, 89)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Tarea"
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(131, 19)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(86, 22)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Codigo"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmTareaTrabajo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(542, 229)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmTareaTrabajo"
            Me.Text = "  "
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtfactor As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTarea As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnTipo As System.Windows.Forms.Button
        Friend WithEvents txtTipo As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnArticulo As System.Windows.Forms.Button
        Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
        Friend WithEvents btnLimpia As System.Windows.Forms.Button
        Friend WithEvents chkTareoPll As System.Windows.Forms.CheckBox
    End Class
End Namespace