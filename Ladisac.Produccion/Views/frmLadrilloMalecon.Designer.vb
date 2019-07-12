<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLadrilloMalecon
    Inherits Ladisac.Foundation.Views.ViewManMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtArt_Id_Ladrillo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMaleconPuerta = New System.Windows.Forms.TextBox()
        Me.numCantidad = New System.Windows.Forms.NumericUpDown()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(463, 28)
        Me.lblTitle.Text = "Ladrillo Malecon"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Ladrillo"
        '
        'txtArt_Id_Ladrillo
        '
        Me.txtArt_Id_Ladrillo.Location = New System.Drawing.Point(114, 91)
        Me.txtArt_Id_Ladrillo.Name = "txtArt_Id_Ladrillo"
        Me.txtArt_Id_Ladrillo.Size = New System.Drawing.Size(224, 20)
        Me.txtArt_Id_Ladrillo.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Cantidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(114, 65)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 113
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Malecon"
        '
        'txtMaleconPuerta
        '
        Me.txtMaleconPuerta.Location = New System.Drawing.Point(114, 117)
        Me.txtMaleconPuerta.Name = "txtMaleconPuerta"
        Me.txtMaleconPuerta.Size = New System.Drawing.Size(224, 20)
        Me.txtMaleconPuerta.TabIndex = 111
        '
        'numCantidad
        '
        Me.numCantidad.Location = New System.Drawing.Point(114, 146)
        Me.numCantidad.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numCantidad.Name = "numCantidad"
        Me.numCantidad.Size = New System.Drawing.Size(90, 20)
        Me.numCantidad.TabIndex = 119
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'frmLadrilloMalecon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(463, 190)
        Me.Controls.Add(Me.numCantidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtArt_Id_Ladrillo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMaleconPuerta)
        Me.Name = "frmLadrilloMalecon"
        Me.Text = "Ladrillo Malecon"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtMaleconPuerta, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtArt_Id_Ladrillo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.numCantidad, 0)
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtArt_Id_Ladrillo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMaleconPuerta As System.Windows.Forms.TextBox
    Friend WithEvents numCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider

End Class
