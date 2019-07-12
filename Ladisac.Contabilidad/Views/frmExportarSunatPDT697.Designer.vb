Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmExportarSunatPDT697
        Inherits Ladisac.Foundation.Views.ViewMaster

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
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.chkComprobatePago = New System.Windows.Forms.CheckBox()
            Me.chkComprobatePercepcion = New System.Windows.Forms.CheckBox()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(408, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.chkComprobatePago)
            Me.Panel1.Controls.Add(Me.chkComprobatePercepcion)
            Me.Panel1.Controls.Add(Me.btnPeriodo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(401, 152)
            Me.Panel1.TabIndex = 1
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(86, 106)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 14
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'chkComprobatePago
            '
            Me.chkComprobatePago.AutoSize = True
            Me.chkComprobatePago.Location = New System.Drawing.Point(86, 73)
            Me.chkComprobatePago.Name = "chkComprobatePago"
            Me.chkComprobatePago.Size = New System.Drawing.Size(283, 17)
            Me.chkComprobatePago.TabIndex = 13
            Me.chkComprobatePago.Text = "Comprobante de pago es Comprobante de Percepcion"
            Me.chkComprobatePago.UseVisualStyleBackColor = True
            '
            'chkComprobatePercepcion
            '
            Me.chkComprobatePercepcion.AutoSize = True
            Me.chkComprobatePercepcion.Location = New System.Drawing.Point(86, 49)
            Me.chkComprobatePercepcion.Name = "chkComprobatePercepcion"
            Me.chkComprobatePercepcion.Size = New System.Drawing.Size(166, 17)
            Me.chkComprobatePercepcion.TabIndex = 12
            Me.chkComprobatePercepcion.Text = "Comprobantes de Percepcion"
            Me.chkComprobatePercepcion.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(167, 13)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 9
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(33, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Periodo"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Enabled = False
            Me.txtPeriodo.Location = New System.Drawing.Point(86, 13)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(75, 20)
            Me.txtPeriodo.TabIndex = 11
            '
            'OpenFileDialog1
            '
            Me.OpenFileDialog1.FileName = "OpenFileDialog1"
            '
            'frmExportarSunatPDT697
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(408, 187)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmExportarSunatPDT697"
            Me.Text = "frmExportarSunatPDT697"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents chkComprobatePago As System.Windows.Forms.CheckBox
        Friend WithEvents chkComprobatePercepcion As System.Windows.Forms.CheckBox
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    End Class

    End Namespace