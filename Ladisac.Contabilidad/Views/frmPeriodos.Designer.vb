

Namespace Ladisac.Contabilidad.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPeriodos
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
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.chkContabilidad = New System.Windows.Forms.CheckBox()
            Me.chkCompras = New System.Windows.Forms.CheckBox()
            Me.chkTesoreria = New System.Windows.Forms.CheckBox()
            Me.chkFacturacion = New System.Windows.Forms.CheckBox()
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(405, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.chkFacturacion)
            Me.Panel1.Controls.Add(Me.chkTesoreria)
            Me.Panel1.Controls.Add(Me.chkCompras)
            Me.Panel1.Controls.Add(Me.chkContabilidad)
            Me.Panel1.Controls.Add(Me.txtCodigo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 65)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(395, 131)
            Me.Panel1.TabIndex = 4
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(52, 15)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(78, 20)
            Me.txtCodigo.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(7, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Codigo"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'chkContabilidad
            '
            Me.chkContabilidad.AutoSize = True
            Me.chkContabilidad.Location = New System.Drawing.Point(238, 12)
            Me.chkContabilidad.Name = "chkContabilidad"
            Me.chkContabilidad.Size = New System.Drawing.Size(84, 17)
            Me.chkContabilidad.TabIndex = 9
            Me.chkContabilidad.Text = "Contabilidad"
            Me.chkContabilidad.UseVisualStyleBackColor = True
            '
            'chkCompras
            '
            Me.chkCompras.AutoSize = True
            Me.chkCompras.Location = New System.Drawing.Point(238, 36)
            Me.chkCompras.Name = "chkCompras"
            Me.chkCompras.Size = New System.Drawing.Size(67, 17)
            Me.chkCompras.TabIndex = 10
            Me.chkCompras.Text = "Compras"
            Me.chkCompras.UseVisualStyleBackColor = True
            '
            'chkTesoreria
            '
            Me.chkTesoreria.AutoSize = True
            Me.chkTesoreria.Location = New System.Drawing.Point(238, 59)
            Me.chkTesoreria.Name = "chkTesoreria"
            Me.chkTesoreria.Size = New System.Drawing.Size(70, 17)
            Me.chkTesoreria.TabIndex = 11
            Me.chkTesoreria.Text = "Tesoreria"
            Me.chkTesoreria.UseVisualStyleBackColor = True
            '
            'chkFacturacion
            '
            Me.chkFacturacion.AutoSize = True
            Me.chkFacturacion.Location = New System.Drawing.Point(238, 82)
            Me.chkFacturacion.Name = "chkFacturacion"
            Me.chkFacturacion.Size = New System.Drawing.Size(59, 17)
            Me.chkFacturacion.TabIndex = 12
            Me.chkFacturacion.Text = "Ventas"
            Me.chkFacturacion.UseVisualStyleBackColor = True
            '
            'frmPeriodos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(405, 208)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPeriodos"
            Me.Text = "frmPeriodos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents chkFacturacion As System.Windows.Forms.CheckBox
        Friend WithEvents chkTesoreria As System.Windows.Forms.CheckBox
        Friend WithEvents chkCompras As System.Windows.Forms.CheckBox
        Friend WithEvents chkContabilidad As System.Windows.Forms.CheckBox
    End Class
End Namespace