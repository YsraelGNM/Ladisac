<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntidad
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtTipoEntidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodPadre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUso = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtKilometros = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCentroCosto = New System.Windows.Forms.TextBox()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(491, 28)
        Me.lblTitle.Text = "Entidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo Entidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(90, 69)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(90, 150)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(349, 20)
        Me.txtDescripcion.TabIndex = 16
        '
        'txtTipoEntidad
        '
        Me.txtTipoEntidad.Location = New System.Drawing.Point(90, 98)
        Me.txtTipoEntidad.Name = "txtTipoEntidad"
        Me.txtTipoEntidad.Size = New System.Drawing.Size(205, 20)
        Me.txtTipoEntidad.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Codigo Padre"
        '
        'txtCodPadre
        '
        Me.txtCodPadre.Location = New System.Drawing.Point(90, 124)
        Me.txtCodPadre.Name = "txtCodPadre"
        Me.txtCodPadre.Size = New System.Drawing.Size(349, 20)
        Me.txtCodPadre.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Horas"
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.White
        Me.txtHora.Location = New System.Drawing.Point(90, 176)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(90, 20)
        Me.txtHora.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Tn"
        '
        'txtTN
        '
        Me.txtTN.BackColor = System.Drawing.Color.White
        Me.txtTN.Location = New System.Drawing.Point(90, 229)
        Me.txtTN.Name = "txtTN"
        Me.txtTN.ReadOnly = True
        Me.txtTN.Size = New System.Drawing.Size(90, 20)
        Me.txtTN.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Dias"
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.White
        Me.txtDia.Location = New System.Drawing.Point(90, 255)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ReadOnly = True
        Me.txtDia.Size = New System.Drawing.Size(90, 20)
        Me.txtDia.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Uso"
        '
        'txtUso
        '
        Me.txtUso.BackColor = System.Drawing.Color.White
        Me.txtUso.Location = New System.Drawing.Point(90, 281)
        Me.txtUso.Name = "txtUso"
        Me.txtUso.ReadOnly = True
        Me.txtUso.Size = New System.Drawing.Size(90, 20)
        Me.txtUso.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 310)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Placa"
        '
        'txtPlaca
        '
        Me.txtPlaca.BackColor = System.Drawing.Color.White
        Me.txtPlaca.Location = New System.Drawing.Point(90, 307)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.ReadOnly = True
        Me.txtPlaca.Size = New System.Drawing.Size(90, 20)
        Me.txtPlaca.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Kilometros"
        '
        'txtKilometros
        '
        Me.txtKilometros.BackColor = System.Drawing.Color.White
        Me.txtKilometros.Location = New System.Drawing.Point(90, 202)
        Me.txtKilometros.Name = "txtKilometros"
        Me.txtKilometros.ReadOnly = True
        Me.txtKilometros.Size = New System.Drawing.Size(90, 20)
        Me.txtKilometros.TabIndex = 33
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 336)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "C.Costo Spring"
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.BackColor = System.Drawing.Color.White
        Me.txtCentroCosto.Location = New System.Drawing.Point(90, 333)
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.Size = New System.Drawing.Size(90, 20)
        Me.txtCentroCosto.TabIndex = 35
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'frmEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(491, 379)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCentroCosto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtKilometros)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPlaca)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUso)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodPadre)
        Me.Controls.Add(Me.txtTipoEntidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEntidad"
        Me.Text = "Entidad"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtTipoEntidad, 0)
        Me.Controls.SetChildIndex(Me.txtCodPadre, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtHora, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtTN, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtDia, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtUso, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtPlaca, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtKilometros, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtCentroCosto, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoEntidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodPadre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTN As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUso As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtKilometros As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider

End Class
