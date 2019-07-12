<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanCargaDescargaHorno
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
        Me.cboHorno = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboPuerta = New System.Windows.Forms.ComboBox()
        Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUNT_ID_10 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_9 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_8 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_6 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_7 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_5 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_4 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_2 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_3 = New System.Windows.Forms.TextBox()
        Me.txtUNT_ID_1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtENO_ID_4 = New System.Windows.Forms.TextBox()
        Me.txtENO_ID_2 = New System.Windows.Forms.TextBox()
        Me.txtENO_ID_3 = New System.Windows.Forms.TextBox()
        Me.txtENO_ID_1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtDR = New System.Windows.Forms.RadioButton()
        Me.rbtDC = New System.Windows.Forms.RadioButton()
        Me.rbtCR = New System.Windows.Forms.RadioButton()
        Me.rbtDV = New System.Windows.Forms.RadioButton()
        Me.rbtCC = New System.Windows.Forms.RadioButton()
        Me.rbtCV = New System.Windows.Forms.RadioButton()
        Me.tabProHor = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tabProHor.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(570, 28)
        Me.lblTitle.Text = "Planificacion"
        '
        'cboHorno
        '
        Me.cboHorno.FormattingEnabled = True
        Me.cboHorno.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboHorno.Location = New System.Drawing.Point(60, 10)
        Me.cboHorno.Name = "cboHorno"
        Me.cboHorno.Size = New System.Drawing.Size(204, 21)
        Me.cboHorno.TabIndex = 159
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 158
        Me.Label11.Text = "Horno"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(426, 62)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(131, 20)
        Me.dtpFecha.TabIndex = 157
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(374, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Fecha"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 160
        Me.Label10.Text = "Puertas"
        '
        'cboPuerta
        '
        Me.cboPuerta.FormattingEnabled = True
        Me.cboPuerta.Location = New System.Drawing.Point(60, 41)
        Me.cboPuerta.Name = "cboPuerta"
        Me.cboPuerta.Size = New System.Drawing.Size(56, 21)
        Me.cboPuerta.TabIndex = 161
        '
        'Error_Validacion
        '
        Me.Error_Validacion.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_10)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_9)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_8)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_6)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_7)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_5)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_4)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_2)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_3)
        Me.GroupBox1.Controls.Add(Me.txtUNT_ID_1)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 303)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 164)
        Me.GroupBox1.TabIndex = 162
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transporte"
        '
        'txtUNT_ID_10
        '
        Me.txtUNT_ID_10.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_10.Location = New System.Drawing.Point(137, 133)
        Me.txtUNT_ID_10.Name = "txtUNT_ID_10"
        Me.txtUNT_ID_10.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_10.TabIndex = 41
        '
        'txtUNT_ID_9
        '
        Me.txtUNT_ID_9.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_9.Location = New System.Drawing.Point(15, 133)
        Me.txtUNT_ID_9.Name = "txtUNT_ID_9"
        Me.txtUNT_ID_9.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_9.TabIndex = 40
        '
        'txtUNT_ID_8
        '
        Me.txtUNT_ID_8.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_8.Location = New System.Drawing.Point(137, 107)
        Me.txtUNT_ID_8.Name = "txtUNT_ID_8"
        Me.txtUNT_ID_8.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_8.TabIndex = 39
        '
        'txtUNT_ID_6
        '
        Me.txtUNT_ID_6.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_6.Location = New System.Drawing.Point(137, 81)
        Me.txtUNT_ID_6.Name = "txtUNT_ID_6"
        Me.txtUNT_ID_6.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_6.TabIndex = 38
        '
        'txtUNT_ID_7
        '
        Me.txtUNT_ID_7.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_7.Location = New System.Drawing.Point(15, 107)
        Me.txtUNT_ID_7.Name = "txtUNT_ID_7"
        Me.txtUNT_ID_7.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_7.TabIndex = 37
        '
        'txtUNT_ID_5
        '
        Me.txtUNT_ID_5.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_5.Location = New System.Drawing.Point(15, 81)
        Me.txtUNT_ID_5.Name = "txtUNT_ID_5"
        Me.txtUNT_ID_5.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_5.TabIndex = 36
        '
        'txtUNT_ID_4
        '
        Me.txtUNT_ID_4.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_4.Location = New System.Drawing.Point(137, 55)
        Me.txtUNT_ID_4.Name = "txtUNT_ID_4"
        Me.txtUNT_ID_4.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_4.TabIndex = 35
        '
        'txtUNT_ID_2
        '
        Me.txtUNT_ID_2.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_2.Location = New System.Drawing.Point(137, 29)
        Me.txtUNT_ID_2.Name = "txtUNT_ID_2"
        Me.txtUNT_ID_2.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_2.TabIndex = 34
        '
        'txtUNT_ID_3
        '
        Me.txtUNT_ID_3.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_3.Location = New System.Drawing.Point(15, 55)
        Me.txtUNT_ID_3.Name = "txtUNT_ID_3"
        Me.txtUNT_ID_3.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_3.TabIndex = 33
        '
        'txtUNT_ID_1
        '
        Me.txtUNT_ID_1.BackColor = System.Drawing.Color.White
        Me.txtUNT_ID_1.Location = New System.Drawing.Point(15, 29)
        Me.txtUNT_ID_1.Name = "txtUNT_ID_1"
        Me.txtUNT_ID_1.Size = New System.Drawing.Size(90, 20)
        Me.txtUNT_ID_1.TabIndex = 32
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtENO_ID_4)
        Me.GroupBox2.Controls.Add(Me.txtENO_ID_2)
        Me.GroupBox2.Controls.Add(Me.txtENO_ID_3)
        Me.GroupBox2.Controls.Add(Me.txtENO_ID_1)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(276, 164)
        Me.GroupBox2.TabIndex = 163
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cancha"
        '
        'txtENO_ID_4
        '
        Me.txtENO_ID_4.BackColor = System.Drawing.Color.White
        Me.txtENO_ID_4.Location = New System.Drawing.Point(139, 90)
        Me.txtENO_ID_4.Name = "txtENO_ID_4"
        Me.txtENO_ID_4.Size = New System.Drawing.Size(90, 20)
        Me.txtENO_ID_4.TabIndex = 39
        '
        'txtENO_ID_2
        '
        Me.txtENO_ID_2.BackColor = System.Drawing.Color.White
        Me.txtENO_ID_2.Location = New System.Drawing.Point(139, 29)
        Me.txtENO_ID_2.Name = "txtENO_ID_2"
        Me.txtENO_ID_2.Size = New System.Drawing.Size(90, 20)
        Me.txtENO_ID_2.TabIndex = 38
        '
        'txtENO_ID_3
        '
        Me.txtENO_ID_3.BackColor = System.Drawing.Color.White
        Me.txtENO_ID_3.Location = New System.Drawing.Point(17, 90)
        Me.txtENO_ID_3.Name = "txtENO_ID_3"
        Me.txtENO_ID_3.Size = New System.Drawing.Size(90, 20)
        Me.txtENO_ID_3.TabIndex = 37
        '
        'txtENO_ID_1
        '
        Me.txtENO_ID_1.BackColor = System.Drawing.Color.White
        Me.txtENO_ID_1.Location = New System.Drawing.Point(17, 29)
        Me.txtENO_ID_1.Name = "txtENO_ID_1"
        Me.txtENO_ID_1.Size = New System.Drawing.Size(90, 20)
        Me.txtENO_ID_1.TabIndex = 36
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(515, 128)
        Me.GroupBox3.TabIndex = 164
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbtDR)
        Me.GroupBox4.Controls.Add(Me.rbtDC)
        Me.GroupBox4.Controls.Add(Me.rbtCR)
        Me.GroupBox4.Controls.Add(Me.rbtDV)
        Me.GroupBox4.Controls.Add(Me.rbtCC)
        Me.GroupBox4.Controls.Add(Me.rbtCV)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(484, 100)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Carga                                                                            " & _
            "     Descarga"
        '
        'rbtDR
        '
        Me.rbtDR.AutoSize = True
        Me.rbtDR.Location = New System.Drawing.Point(325, 45)
        Me.rbtDR.Name = "rbtDR"
        Me.rbtDR.Size = New System.Drawing.Size(121, 17)
        Me.rbtDR.TabIndex = 1
        Me.rbtDR.TabStop = True
        Me.rbtDR.Text = "Descarga Realizada"
        Me.rbtDR.UseVisualStyleBackColor = True
        '
        'rbtDC
        '
        Me.rbtDC.AutoSize = True
        Me.rbtDC.Location = New System.Drawing.Point(325, 68)
        Me.rbtDC.Name = "rbtDC"
        Me.rbtDC.Size = New System.Drawing.Size(125, 17)
        Me.rbtDC.TabIndex = 2
        Me.rbtDC.TabStop = True
        Me.rbtDC.Text = "Descarga Cancelada"
        Me.rbtDC.UseVisualStyleBackColor = True
        '
        'rbtCR
        '
        Me.rbtCR.AutoSize = True
        Me.rbtCR.Location = New System.Drawing.Point(42, 45)
        Me.rbtCR.Name = "rbtCR"
        Me.rbtCR.Size = New System.Drawing.Size(103, 17)
        Me.rbtCR.TabIndex = 1
        Me.rbtCR.TabStop = True
        Me.rbtCR.Text = "Carga Realizada"
        Me.rbtCR.UseVisualStyleBackColor = True
        '
        'rbtDV
        '
        Me.rbtDV.AutoSize = True
        Me.rbtDV.Location = New System.Drawing.Point(325, 22)
        Me.rbtDV.Name = "rbtDV"
        Me.rbtDV.Size = New System.Drawing.Size(110, 17)
        Me.rbtDV.TabIndex = 0
        Me.rbtDV.TabStop = True
        Me.rbtDV.Text = "Descarga Vigente"
        Me.rbtDV.UseVisualStyleBackColor = True
        '
        'rbtCC
        '
        Me.rbtCC.AutoSize = True
        Me.rbtCC.Location = New System.Drawing.Point(42, 68)
        Me.rbtCC.Name = "rbtCC"
        Me.rbtCC.Size = New System.Drawing.Size(107, 17)
        Me.rbtCC.TabIndex = 2
        Me.rbtCC.TabStop = True
        Me.rbtCC.Text = "Carga Cancelada"
        Me.rbtCC.UseVisualStyleBackColor = True
        '
        'rbtCV
        '
        Me.rbtCV.AutoSize = True
        Me.rbtCV.Location = New System.Drawing.Point(42, 22)
        Me.rbtCV.Name = "rbtCV"
        Me.rbtCV.Size = New System.Drawing.Size(92, 17)
        Me.rbtCV.TabIndex = 0
        Me.rbtCV.Text = "Carga Vigente"
        Me.rbtCV.UseVisualStyleBackColor = True
        '
        'tabProHor
        '
        Me.tabProHor.Controls.Add(Me.TabPage1)
        Me.tabProHor.Controls.Add(Me.TabPage2)
        Me.tabProHor.Location = New System.Drawing.Point(15, 64)
        Me.tabProHor.Name = "tabProHor"
        Me.tabProHor.SelectedIndex = 0
        Me.tabProHor.Size = New System.Drawing.Size(546, 235)
        Me.tabProHor.TabIndex = 165
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.cboHorno)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cboPuerta)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(538, 209)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Carga Descarga de Horno"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtPlanta)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtProduccion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(538, 209)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Produccion de Ladrillo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Produccion"
        '
        'txtProduccion
        '
        Me.txtProduccion.Location = New System.Drawing.Point(90, 22)
        Me.txtProduccion.Name = "txtProduccion"
        Me.txtProduccion.Size = New System.Drawing.Size(442, 20)
        Me.txtProduccion.TabIndex = 111
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(90, 58)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(163, 20)
        Me.txtPlanta.TabIndex = 113
        '
        'frmPlanCargaDescargaHorno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(570, 472)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.tabProHor)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPlanCargaDescargaHorno"
        Me.Text = "Planificacion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.tabProHor, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tabProHor.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboHorno As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPuerta As System.Windows.Forms.ComboBox
    Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtENO_ID_4 As System.Windows.Forms.TextBox
    Friend WithEvents txtENO_ID_2 As System.Windows.Forms.TextBox
    Friend WithEvents txtENO_ID_3 As System.Windows.Forms.TextBox
    Friend WithEvents txtENO_ID_1 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_4 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDR As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDC As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDV As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtCR As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCC As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCV As System.Windows.Forms.RadioButton
    Friend WithEvents tabProHor As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtUNT_ID_10 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_9 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_8 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_6 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_7 As System.Windows.Forms.TextBox
    Friend WithEvents txtUNT_ID_5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox

End Class
