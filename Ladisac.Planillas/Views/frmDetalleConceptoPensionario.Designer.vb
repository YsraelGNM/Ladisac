Namespace Ladisac.Planillas.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDetalleConceptoPensionario
        Inherits ViewManMasterPlanillas

        ' Inherits System.Windows.Forms.Form

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
            Me.btnCuenta = New System.Windows.Forms.Button()
            Me.btnConcepto = New System.Windows.Forms.Button()
            Me.btnBuscarRegimen = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtEdad = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtImporteMAximo = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkRestrcciones = New System.Windows.Forms.CheckBox()
            Me.txtCuentaContable = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtFactor = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtRegimen = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(429, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.btnCuenta)
            Me.Panel1.Controls.Add(Me.btnConcepto)
            Me.Panel1.Controls.Add(Me.btnBuscarRegimen)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.chkRestrcciones)
            Me.Panel1.Controls.Add(Me.txtCuentaContable)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.txtConcepto)
            Me.Panel1.Controls.Add(Me.txtTipoConcepto)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtFactor)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.txtRegimen)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 61)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(419, 212)
            Me.Panel1.TabIndex = 3
            '
            'btnCuenta
            '
            Me.btnCuenta.Location = New System.Drawing.Point(310, 71)
            Me.btnCuenta.Name = "btnCuenta"
            Me.btnCuenta.Size = New System.Drawing.Size(31, 23)
            Me.btnCuenta.TabIndex = 24
            Me.btnCuenta.Text = ":::"
            Me.btnCuenta.UseVisualStyleBackColor = True
            '
            'btnConcepto
            '
            Me.btnConcepto.Location = New System.Drawing.Point(310, 47)
            Me.btnConcepto.Name = "btnConcepto"
            Me.btnConcepto.Size = New System.Drawing.Size(31, 23)
            Me.btnConcepto.TabIndex = 23
            Me.btnConcepto.Text = ":::"
            Me.btnConcepto.UseVisualStyleBackColor = True
            '
            'btnBuscarRegimen
            '
            Me.btnBuscarRegimen.Location = New System.Drawing.Point(310, 6)
            Me.btnBuscarRegimen.Name = "btnBuscarRegimen"
            Me.btnBuscarRegimen.Size = New System.Drawing.Size(31, 23)
            Me.btnBuscarRegimen.TabIndex = 22
            Me.btnBuscarRegimen.Text = ":::"
            Me.btnBuscarRegimen.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.Add(Me.txtEdad)
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.txtImporteMAximo)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Enabled = False
            Me.Panel2.Location = New System.Drawing.Point(3, 142)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(410, 61)
            Me.Panel2.TabIndex = 21
            '
            'txtEdad
            '
            Me.txtEdad.Location = New System.Drawing.Point(127, 31)
            Me.txtEdad.Name = "txtEdad"
            Me.txtEdad.Size = New System.Drawing.Size(100, 20)
            Me.txtEdad.TabIndex = 19
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(89, 37)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(32, 13)
            Me.Label7.TabIndex = 18
            Me.Label7.Text = "Edad"
            '
            'txtImporteMAximo
            '
            Me.txtImporteMAximo.Location = New System.Drawing.Point(127, 9)
            Me.txtImporteMAximo.MaxLength = 10
            Me.txtImporteMAximo.Name = "txtImporteMAximo"
            Me.txtImporteMAximo.Size = New System.Drawing.Size(100, 20)
            Me.txtImporteMAximo.TabIndex = 11
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(40, 15)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(81, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Importe Maximo"
            '
            'chkRestrcciones
            '
            Me.chkRestrcciones.AutoSize = True
            Me.chkRestrcciones.Location = New System.Drawing.Point(132, 120)
            Me.chkRestrcciones.Name = "chkRestrcciones"
            Me.chkRestrcciones.Size = New System.Drawing.Size(120, 17)
            Me.chkRestrcciones.TabIndex = 20
            Me.chkRestrcciones.Text = "Tiene Restricciones"
            Me.chkRestrcciones.UseVisualStyleBackColor = True
            '
            'txtCuentaContable
            '
            Me.txtCuentaContable.Location = New System.Drawing.Point(131, 72)
            Me.txtCuentaContable.Name = "txtCuentaContable"
            Me.txtCuentaContable.ReadOnly = True
            Me.txtCuentaContable.Size = New System.Drawing.Size(176, 20)
            Me.txtCuentaContable.TabIndex = 17
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(39, 78)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(85, 13)
            Me.Label6.TabIndex = 16
            Me.Label6.Text = "cuenta Contable"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(131, 50)
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(176, 20)
            Me.txtConcepto.TabIndex = 15
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(131, 28)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(176, 20)
            Me.txtTipoConcepto.TabIndex = 14
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(71, 53)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(53, 13)
            Me.Label5.TabIndex = 13
            Me.Label5.Text = "Concepto"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(47, 34)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(77, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Tipo Concepto"
            '
            'txtFactor
            '
            Me.txtFactor.Location = New System.Drawing.Point(131, 94)
            Me.txtFactor.MaxLength = 45
            Me.txtFactor.Name = "txtFactor"
            Me.txtFactor.Size = New System.Drawing.Size(81, 20)
            Me.txtFactor.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(87, 100)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Factor"
            '
            'txtRegimen
            '
            Me.txtRegimen.Location = New System.Drawing.Point(131, 6)
            Me.txtRegimen.Name = "txtRegimen"
            Me.txtRegimen.ReadOnly = True
            Me.txtRegimen.Size = New System.Drawing.Size(176, 20)
            Me.txtRegimen.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(75, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(49, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Regimen"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDetalleConceptoPensionario
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(429, 278)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmDetalleConceptoPensionario"
            Me.Text = "frmDetalleConceptoPensionario"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtImporteMAximo As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtFactor As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtRegimen As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCuenta As System.Windows.Forms.Button
        Friend WithEvents btnConcepto As System.Windows.Forms.Button
        Friend WithEvents btnBuscarRegimen As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtEdad As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents chkRestrcciones As System.Windows.Forms.CheckBox
        Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace