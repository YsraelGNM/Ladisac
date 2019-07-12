Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteMayorAuxiliarMes
        '  Inherits System.Windows.Forms.Form
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
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btbBuscarCargo = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtCuentaCargo = New System.Windows.Forms.TextBox()
            Me.txtDescripcioncargo = New System.Windows.Forms.TextBox()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(510, 28)
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(226, 45)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 5
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(124, 47)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(100, 20)
            Me.txtPeriodo.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(39, 50)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(79, 13)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Buscar Periodo"
            '
            'btbBuscarCargo
            '
            Me.btbBuscarCargo.Location = New System.Drawing.Point(226, 72)
            Me.btbBuscarCargo.Name = "btbBuscarCargo"
            Me.btbBuscarCargo.Size = New System.Drawing.Size(24, 23)
            Me.btbBuscarCargo.TabIndex = 23
            Me.btbBuscarCargo.Text = ":::"
            Me.btbBuscarCargo.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(77, 77)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(41, 13)
            Me.Label4.TabIndex = 22
            Me.Label4.Text = "Cuenta"
            '
            'txtCuentaCargo
            '
            Me.txtCuentaCargo.Location = New System.Drawing.Point(124, 73)
            Me.txtCuentaCargo.Name = "txtCuentaCargo"
            Me.txtCuentaCargo.ReadOnly = True
            Me.txtCuentaCargo.Size = New System.Drawing.Size(100, 20)
            Me.txtCuentaCargo.TabIndex = 21
            '
            'txtDescripcioncargo
            '
            Me.txtDescripcioncargo.Location = New System.Drawing.Point(256, 74)
            Me.txtDescripcioncargo.Name = "txtDescripcioncargo"
            Me.txtDescripcioncargo.ReadOnly = True
            Me.txtDescripcioncargo.Size = New System.Drawing.Size(247, 20)
            Me.txtDescripcioncargo.TabIndex = 24
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(428, 100)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 25
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmReporteMayorAuxiliarMes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(510, 151)
            Me.Controls.Add(Me.btnGenerar)
            Me.Controls.Add(Me.txtDescripcioncargo)
            Me.Controls.Add(Me.btbBuscarCargo)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.txtCuentaCargo)
            Me.Controls.Add(Me.btnPeriodo)
            Me.Controls.Add(Me.txtPeriodo)
            Me.Controls.Add(Me.Label1)
            Me.Name = "frmReporteMayorAuxiliarMes"
            Me.Text = "frmReporteMayorAuxiliarMes"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtPeriodo, 0)
            Me.Controls.SetChildIndex(Me.btnPeriodo, 0)
            Me.Controls.SetChildIndex(Me.txtCuentaCargo, 0)
            Me.Controls.SetChildIndex(Me.Label4, 0)
            Me.Controls.SetChildIndex(Me.btbBuscarCargo, 0)
            Me.Controls.SetChildIndex(Me.txtDescripcioncargo, 0)
            Me.Controls.SetChildIndex(Me.btnGenerar, 0)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btbBuscarCargo As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtCuentaCargo As System.Windows.Forms.TextBox
        Friend WithEvents txtDescripcioncargo As System.Windows.Forms.TextBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
    End Class

End Namespace

