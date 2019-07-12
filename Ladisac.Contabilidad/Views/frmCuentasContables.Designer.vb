Namespace Ladisac.Contabilidad.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasContables
        Inherits ViewManMasterContabilidad

        '        Inherits System.Windows.Forms.Form

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
            Me.txtAbreviatura = New System.Windows.Forms.MaskedTextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cboEsCuentaDe = New System.Windows.Forms.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtCuentaGeneral = New System.Windows.Forms.MaskedTextBox()
            Me.btnEliminarClase = New System.Windows.Forms.Button()
            Me.btnBuscarClase = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtClase = New System.Windows.Forms.TextBox()
            Me.btnEliminarAbono = New System.Windows.Forms.Button()
            Me.btnEliminarCargo = New System.Windows.Forms.Button()
            Me.btnBuscarAbono = New System.Windows.Forms.Button()
            Me.btbBuscarCargo = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtDescripcionAbono = New System.Windows.Forms.TextBox()
            Me.txtCuentaAbono = New System.Windows.Forms.TextBox()
            Me.txtDescripcioncargo = New System.Windows.Forms.TextBox()
            Me.txtCuentaCargo = New System.Windows.Forms.TextBox()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.chkCentroCosto = New System.Windows.Forms.CheckBox()
            Me.txtDescripcionGeneral = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(412, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.txtAbreviatura)
            Me.Panel1.Controls.Add(Me.Label10)
            Me.Panel1.Controls.Add(Me.Label9)
            Me.Panel1.Controls.Add(Me.cboEsCuentaDe)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Controls.Add(Me.txtCuentaGeneral)
            Me.Panel1.Controls.Add(Me.btnEliminarClase)
            Me.Panel1.Controls.Add(Me.btnBuscarClase)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.txtClase)
            Me.Panel1.Controls.Add(Me.btnEliminarAbono)
            Me.Panel1.Controls.Add(Me.btnEliminarCargo)
            Me.Panel1.Controls.Add(Me.btnBuscarAbono)
            Me.Panel1.Controls.Add(Me.btbBuscarCargo)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtDescripcionAbono)
            Me.Panel1.Controls.Add(Me.txtCuentaAbono)
            Me.Panel1.Controls.Add(Me.txtDescripcioncargo)
            Me.Panel1.Controls.Add(Me.txtCuentaCargo)
            Me.Panel1.Controls.Add(Me.chkActivo)
            Me.Panel1.Controls.Add(Me.chkCentroCosto)
            Me.Panel1.Controls.Add(Me.txtDescripcionGeneral)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(11, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(394, 245)
            Me.Panel1.TabIndex = 4
            '
            'txtAbreviatura
            '
            Me.txtAbreviatura.Location = New System.Drawing.Point(282, 6)
            Me.txtAbreviatura.Name = "txtAbreviatura"
            Me.txtAbreviatura.Size = New System.Drawing.Size(100, 20)
            Me.txtAbreviatura.TabIndex = 33
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(219, 10)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(61, 13)
            Me.Label10.TabIndex = 32
            Me.Label10.Text = "Abreviatura"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(228, 177)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(130, 13)
            Me.Label9.TabIndex = 31
            Me.Label9.Text = "Comportamiento Tesoreria"
            '
            'cboEsCuentaDe
            '
            Me.cboEsCuentaDe.FormattingEnabled = True
            Me.cboEsCuentaDe.Items.AddRange(New Object() {"Cargo", "Abono", "Cargo -Abono"})
            Me.cboEsCuentaDe.Location = New System.Drawing.Point(101, 174)
            Me.cboEsCuentaDe.Name = "cboEsCuentaDe"
            Me.cboEsCuentaDe.Size = New System.Drawing.Size(121, 21)
            Me.cboEsCuentaDe.TabIndex = 30
            Me.cboEsCuentaDe.Text = "Ingreso"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(26, 177)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(74, 13)
            Me.Label8.TabIndex = 29
            Me.Label8.Text = "Es Cuenta de "
            '
            'txtCuentaGeneral
            '
            Me.txtCuentaGeneral.Location = New System.Drawing.Point(100, 6)
            Me.txtCuentaGeneral.Name = "txtCuentaGeneral"
            Me.txtCuentaGeneral.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaGeneral.TabIndex = 28
            '
            'btnEliminarClase
            '
            Me.btnEliminarClase.Location = New System.Drawing.Point(231, 55)
            Me.btnEliminarClase.Name = "btnEliminarClase"
            Me.btnEliminarClase.Size = New System.Drawing.Size(30, 23)
            Me.btnEliminarClase.TabIndex = 27
            Me.btnEliminarClase.Text = "cls"
            Me.btnEliminarClase.UseVisualStyleBackColor = True
            '
            'btnBuscarClase
            '
            Me.btnBuscarClase.Location = New System.Drawing.Point(200, 55)
            Me.btnBuscarClase.Name = "btnBuscarClase"
            Me.btnBuscarClase.Size = New System.Drawing.Size(28, 23)
            Me.btnBuscarClase.TabIndex = 26
            Me.btnBuscarClase.Text = ":::"
            Me.btnBuscarClase.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(61, 62)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(33, 13)
            Me.Label7.TabIndex = 25
            Me.Label7.Text = "Clase"
            '
            'txtClase
            '
            Me.txtClase.Location = New System.Drawing.Point(100, 56)
            Me.txtClase.Name = "txtClase"
            Me.txtClase.ReadOnly = True
            Me.txtClase.Size = New System.Drawing.Size(100, 20)
            Me.txtClase.TabIndex = 24
            '
            'btnEliminarAbono
            '
            Me.btnEliminarAbono.Location = New System.Drawing.Point(233, 126)
            Me.btnEliminarAbono.Name = "btnEliminarAbono"
            Me.btnEliminarAbono.Size = New System.Drawing.Size(29, 23)
            Me.btnEliminarAbono.TabIndex = 23
            Me.btnEliminarAbono.Text = "cls"
            Me.btnEliminarAbono.UseVisualStyleBackColor = True
            '
            'btnEliminarCargo
            '
            Me.btnEliminarCargo.Location = New System.Drawing.Point(232, 79)
            Me.btnEliminarCargo.Name = "btnEliminarCargo"
            Me.btnEliminarCargo.Size = New System.Drawing.Size(29, 23)
            Me.btnEliminarCargo.TabIndex = 22
            Me.btnEliminarCargo.Text = "cls"
            Me.btnEliminarCargo.UseVisualStyleBackColor = True
            '
            'btnBuscarAbono
            '
            Me.btnBuscarAbono.Location = New System.Drawing.Point(203, 126)
            Me.btnBuscarAbono.Name = "btnBuscarAbono"
            Me.btnBuscarAbono.Size = New System.Drawing.Size(27, 23)
            Me.btnBuscarAbono.TabIndex = 21
            Me.btnBuscarAbono.Text = ":::"
            Me.btnBuscarAbono.UseVisualStyleBackColor = True
            '
            'btbBuscarCargo
            '
            Me.btbBuscarCargo.Location = New System.Drawing.Point(202, 79)
            Me.btbBuscarCargo.Name = "btbBuscarCargo"
            Me.btbBuscarCargo.Size = New System.Drawing.Size(24, 23)
            Me.btbBuscarCargo.TabIndex = 20
            Me.btbBuscarCargo.Text = ":::"
            Me.btbBuscarCargo.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(31, 158)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(63, 13)
            Me.Label5.TabIndex = 19
            Me.Label5.Text = "Descripcion"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(19, 134)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(75, 13)
            Me.Label6.TabIndex = 18
            Me.Label6.Text = "Cuenta Abono"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(31, 109)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(63, 13)
            Me.Label3.TabIndex = 17
            Me.Label3.Text = "Descripcion"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(22, 85)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 13)
            Me.Label4.TabIndex = 16
            Me.Label4.Text = "Cuenta Cargo"
            '
            'txtDescripcionAbono
            '
            Me.txtDescripcionAbono.Location = New System.Drawing.Point(100, 152)
            Me.txtDescripcionAbono.Name = "txtDescripcionAbono"
            Me.txtDescripcionAbono.ReadOnly = True
            Me.txtDescripcionAbono.Size = New System.Drawing.Size(282, 20)
            Me.txtDescripcionAbono.TabIndex = 15
            '
            'txtCuentaAbono
            '
            Me.txtCuentaAbono.Location = New System.Drawing.Point(100, 128)
            Me.txtCuentaAbono.Name = "txtCuentaAbono"
            Me.txtCuentaAbono.ReadOnly = True
            Me.txtCuentaAbono.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaAbono.TabIndex = 14
            '
            'txtDescripcioncargo
            '
            Me.txtDescripcioncargo.Location = New System.Drawing.Point(100, 104)
            Me.txtDescripcioncargo.Name = "txtDescripcioncargo"
            Me.txtDescripcioncargo.ReadOnly = True
            Me.txtDescripcioncargo.Size = New System.Drawing.Size(282, 20)
            Me.txtDescripcioncargo.TabIndex = 13
            '
            'txtCuentaCargo
            '
            Me.txtCuentaCargo.Location = New System.Drawing.Point(100, 80)
            Me.txtCuentaCargo.Name = "txtCuentaCargo"
            Me.txtCuentaCargo.ReadOnly = True
            Me.txtCuentaCargo.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaCargo.TabIndex = 12
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(277, 204)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(59, 17)
            Me.chkActivo.TabIndex = 11
            Me.chkActivo.Text = "Estado"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'chkCentroCosto
            '
            Me.chkCentroCosto.AutoSize = True
            Me.chkCentroCosto.Location = New System.Drawing.Point(100, 204)
            Me.chkCentroCosto.Name = "chkCentroCosto"
            Me.chkCentroCosto.Size = New System.Drawing.Size(144, 17)
            Me.chkCentroCosto.TabIndex = 10
            Me.chkCentroCosto.Text = "Requiere Costo de Costo"
            Me.chkCentroCosto.UseVisualStyleBackColor = True
            '
            'txtDescripcionGeneral
            '
            Me.txtDescripcionGeneral.Location = New System.Drawing.Point(100, 32)
            Me.txtDescripcionGeneral.MaxLength = 160
            Me.txtDescripcionGeneral.Name = "txtDescripcionGeneral"
            Me.txtDescripcionGeneral.Size = New System.Drawing.Size(282, 20)
            Me.txtDescripcionGeneral.TabIndex = 9
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(31, 34)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(63, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Descripcion"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(53, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Cuenta"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmCuentasContables
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(412, 313)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCuentasContables"
            Me.Text = "frmCuentasContables"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtDescripcionGeneral As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtDescripcionAbono As System.Windows.Forms.TextBox
        Friend WithEvents txtCuentaAbono As System.Windows.Forms.TextBox
        Friend WithEvents txtDescripcioncargo As System.Windows.Forms.TextBox
        Friend WithEvents txtCuentaCargo As System.Windows.Forms.TextBox
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents chkCentroCosto As System.Windows.Forms.CheckBox
        Friend WithEvents btnBuscarAbono As System.Windows.Forms.Button
        Friend WithEvents btbBuscarCargo As System.Windows.Forms.Button
        Friend WithEvents btnEliminarAbono As System.Windows.Forms.Button
        Friend WithEvents btnEliminarCargo As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtClase As System.Windows.Forms.TextBox
        Friend WithEvents btnEliminarClase As System.Windows.Forms.Button
        Friend WithEvents btnBuscarClase As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtCuentaGeneral As System.Windows.Forms.MaskedTextBox
        Friend WithEvents cboEsCuentaDe As System.Windows.Forms.ComboBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtAbreviatura As System.Windows.Forms.MaskedTextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
    End Class
End Namespace