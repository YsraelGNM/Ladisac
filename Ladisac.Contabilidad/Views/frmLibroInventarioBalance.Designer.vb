Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLibroInventarioBalance
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
            Me.btnPatrimonioNeto = New System.Windows.Forms.Button()
            Me.btnEstadoGananciasPerdidas = New System.Windows.Forms.Button()
            Me.btnBalanceGeneral = New System.Windows.Forms.Button()
            Me.btnExistencias59 = New System.Windows.Forms.Button()
            Me.btnExistencias58 = New System.Windows.Forms.Button()
            Me.btnExistencias56 = New System.Windows.Forms.Button()
            Me.btnCta47X = New System.Windows.Forms.Button()
            Me.btnCta30 = New System.Windows.Forms.Button()
            Me.btnCta34 = New System.Windows.Forms.Button()
            Me.btnCta31 = New System.Windows.Forms.Button()
            Me.btnCta49 = New System.Windows.Forms.Button()
            Me.btnCta48 = New System.Windows.Forms.Button()
            Me.btnCta47 = New System.Windows.Forms.Button()
            Me.btnCta45 = New System.Windows.Forms.Button()
            Me.btnCta44 = New System.Windows.Forms.Button()
            Me.btnCta43 = New System.Windows.Forms.Button()
            Me.btnCta37 = New System.Windows.Forms.Button()
            Me.btnExistencias39 = New System.Windows.Forms.Button()
            Me.btnExistencias33 = New System.Windows.Forms.Button()
            Me.btnExistencias32 = New System.Windows.Forms.Button()
            Me.btnCta18 = New System.Windows.Forms.Button()
            Me.btnCta17 = New System.Windows.Forms.Button()
            Me.btnCajaBancosCtaCte = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnCajaBancos = New System.Windows.Forms.Button()
            Me.btnCta50 = New System.Windows.Forms.Button()
            Me.btnCta19 = New System.Windows.Forms.Button()
            Me.btnBalanceComprobacion = New System.Windows.Forms.Button()
            Me.btnCta10 = New System.Windows.Forms.Button()
            Me.btnCta41 = New System.Windows.Forms.Button()
            Me.btnExistencias = New System.Windows.Forms.Button()
            Me.btnCta46 = New System.Windows.Forms.Button()
            Me.btnCta42 = New System.Windows.Forms.Button()
            Me.btnCta40 = New System.Windows.Forms.Button()
            Me.btnCta16 = New System.Windows.Forms.Button()
            Me.btnCta14 = New System.Windows.Forms.Button()
            Me.nudAnio = New System.Windows.Forms.NumericUpDown()
            Me.btnCta12 = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboMes = New System.Windows.Forms.ComboBox()
            Me.Panel1.SuspendLayout()
            CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(491, 28)
            Me.lblTitle.Text = "Libro de Inventarios y Balances"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.cboMes)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnPatrimonioNeto)
            Me.Panel1.Controls.Add(Me.btnEstadoGananciasPerdidas)
            Me.Panel1.Controls.Add(Me.btnBalanceGeneral)
            Me.Panel1.Controls.Add(Me.btnExistencias59)
            Me.Panel1.Controls.Add(Me.btnExistencias58)
            Me.Panel1.Controls.Add(Me.btnExistencias56)
            Me.Panel1.Controls.Add(Me.btnCta47X)
            Me.Panel1.Controls.Add(Me.btnCta30)
            Me.Panel1.Controls.Add(Me.btnCta34)
            Me.Panel1.Controls.Add(Me.btnCta31)
            Me.Panel1.Controls.Add(Me.btnCta49)
            Me.Panel1.Controls.Add(Me.btnCta48)
            Me.Panel1.Controls.Add(Me.btnCta47)
            Me.Panel1.Controls.Add(Me.btnCta45)
            Me.Panel1.Controls.Add(Me.btnCta44)
            Me.Panel1.Controls.Add(Me.btnCta43)
            Me.Panel1.Controls.Add(Me.btnCta37)
            Me.Panel1.Controls.Add(Me.btnExistencias39)
            Me.Panel1.Controls.Add(Me.btnExistencias33)
            Me.Panel1.Controls.Add(Me.btnExistencias32)
            Me.Panel1.Controls.Add(Me.btnCta18)
            Me.Panel1.Controls.Add(Me.btnCta17)
            Me.Panel1.Controls.Add(Me.btnCajaBancosCtaCte)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.btnCajaBancos)
            Me.Panel1.Controls.Add(Me.btnCta50)
            Me.Panel1.Controls.Add(Me.btnCta19)
            Me.Panel1.Controls.Add(Me.btnBalanceComprobacion)
            Me.Panel1.Controls.Add(Me.btnCta10)
            Me.Panel1.Controls.Add(Me.btnCta41)
            Me.Panel1.Controls.Add(Me.btnExistencias)
            Me.Panel1.Controls.Add(Me.btnCta46)
            Me.Panel1.Controls.Add(Me.btnCta42)
            Me.Panel1.Controls.Add(Me.btnCta40)
            Me.Panel1.Controls.Add(Me.btnCta16)
            Me.Panel1.Controls.Add(Me.btnCta14)
            Me.Panel1.Controls.Add(Me.nudAnio)
            Me.Panel1.Controls.Add(Me.btnCta12)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(470, 361)
            Me.Panel1.TabIndex = 2
            '
            'btnPatrimonioNeto
            '
            Me.btnPatrimonioNeto.Location = New System.Drawing.Point(8, 241)
            Me.btnPatrimonioNeto.Name = "btnPatrimonioNeto"
            Me.btnPatrimonioNeto.Size = New System.Drawing.Size(70, 35)
            Me.btnPatrimonioNeto.TabIndex = 52
            Me.btnPatrimonioNeto.Text = "Formato 3.19"
            Me.btnPatrimonioNeto.UseVisualStyleBackColor = True
            '
            'btnEstadoGananciasPerdidas
            '
            Me.btnEstadoGananciasPerdidas.Location = New System.Drawing.Point(84, 241)
            Me.btnEstadoGananciasPerdidas.Name = "btnEstadoGananciasPerdidas"
            Me.btnEstadoGananciasPerdidas.Size = New System.Drawing.Size(70, 35)
            Me.btnEstadoGananciasPerdidas.TabIndex = 51
            Me.btnEstadoGananciasPerdidas.Text = "Formato 3.20"
            Me.btnEstadoGananciasPerdidas.UseVisualStyleBackColor = True
            '
            'btnBalanceGeneral
            '
            Me.btnBalanceGeneral.Location = New System.Drawing.Point(160, 241)
            Me.btnBalanceGeneral.Name = "btnBalanceGeneral"
            Me.btnBalanceGeneral.Size = New System.Drawing.Size(70, 35)
            Me.btnBalanceGeneral.TabIndex = 50
            Me.btnBalanceGeneral.Text = "Balance General"
            Me.btnBalanceGeneral.UseVisualStyleBackColor = True
            '
            'btnExistencias59
            '
            Me.btnExistencias59.Location = New System.Drawing.Point(84, 118)
            Me.btnExistencias59.Name = "btnExistencias59"
            Me.btnExistencias59.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias59.TabIndex = 49
            Me.btnExistencias59.Text = "Formato 3.7 Cta. 59"
            Me.btnExistencias59.UseVisualStyleBackColor = True
            '
            'btnExistencias58
            '
            Me.btnExistencias58.Location = New System.Drawing.Point(8, 118)
            Me.btnExistencias58.Name = "btnExistencias58"
            Me.btnExistencias58.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias58.TabIndex = 48
            Me.btnExistencias58.Text = "Formato 3.7 Cta. 58"
            Me.btnExistencias58.UseVisualStyleBackColor = True
            '
            'btnExistencias56
            '
            Me.btnExistencias56.Location = New System.Drawing.Point(383, 77)
            Me.btnExistencias56.Name = "btnExistencias56"
            Me.btnExistencias56.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias56.TabIndex = 47
            Me.btnExistencias56.Text = "Formato 3.7 Cta. 56"
            Me.btnExistencias56.UseVisualStyleBackColor = True
            '
            'btnCta47X
            '
            Me.btnCta47X.Enabled = False
            Me.btnCta47X.Location = New System.Drawing.Point(383, 316)
            Me.btnCta47X.Name = "btnCta47X"
            Me.btnCta47X.Size = New System.Drawing.Size(70, 35)
            Me.btnCta47X.TabIndex = 46
            Me.btnCta47X.Text = "Formato 3.14 Cta.47"
            Me.btnCta47X.UseVisualStyleBackColor = True
            Me.btnCta47X.Visible = False
            '
            'btnCta30
            '
            Me.btnCta30.Location = New System.Drawing.Point(232, 118)
            Me.btnCta30.Name = "btnCta30"
            Me.btnCta30.Size = New System.Drawing.Size(70, 35)
            Me.btnCta30.TabIndex = 45
            Me.btnCta30.Text = "Formato 3.9 Cta.30"
            Me.btnCta30.UseVisualStyleBackColor = True
            '
            'btnCta34
            '
            Me.btnCta34.Location = New System.Drawing.Point(308, 118)
            Me.btnCta34.Name = "btnCta34"
            Me.btnCta34.Size = New System.Drawing.Size(70, 35)
            Me.btnCta34.TabIndex = 44
            Me.btnCta34.Text = "Formato 3.9 Cta.34"
            Me.btnCta34.UseVisualStyleBackColor = True
            '
            'btnCta31
            '
            Me.btnCta31.Location = New System.Drawing.Point(160, 118)
            Me.btnCta31.Name = "btnCta31"
            Me.btnCta31.Size = New System.Drawing.Size(70, 35)
            Me.btnCta31.TabIndex = 43
            Me.btnCta31.Text = "Formato 3.8 Cta.31"
            Me.btnCta31.UseVisualStyleBackColor = True
            '
            'btnCta49
            '
            Me.btnCta49.Location = New System.Drawing.Point(232, 200)
            Me.btnCta49.Name = "btnCta49"
            Me.btnCta49.Size = New System.Drawing.Size(70, 35)
            Me.btnCta49.TabIndex = 42
            Me.btnCta49.Text = "Formato 3.15 Cta.49"
            Me.btnCta49.UseVisualStyleBackColor = True
            '
            'btnCta48
            '
            Me.btnCta48.Location = New System.Drawing.Point(8, 200)
            Me.btnCta48.Name = "btnCta48"
            Me.btnCta48.Size = New System.Drawing.Size(70, 35)
            Me.btnCta48.TabIndex = 41
            Me.btnCta48.Text = "Formato 3.12 Cta.48"
            Me.btnCta48.UseVisualStyleBackColor = True
            '
            'btnCta47
            '
            Me.btnCta47.Location = New System.Drawing.Point(160, 200)
            Me.btnCta47.Name = "btnCta47"
            Me.btnCta47.Size = New System.Drawing.Size(70, 35)
            Me.btnCta47.TabIndex = 40
            Me.btnCta47.Text = "Formato 3.14 Cta.47"
            Me.btnCta47.UseVisualStyleBackColor = True
            '
            'btnCta45
            '
            Me.btnCta45.Location = New System.Drawing.Point(383, 159)
            Me.btnCta45.Name = "btnCta45"
            Me.btnCta45.Size = New System.Drawing.Size(70, 35)
            Me.btnCta45.TabIndex = 39
            Me.btnCta45.Text = "Formato 3.12 Cta.45"
            Me.btnCta45.UseVisualStyleBackColor = True
            '
            'btnCta44
            '
            Me.btnCta44.Location = New System.Drawing.Point(308, 159)
            Me.btnCta44.Name = "btnCta44"
            Me.btnCta44.Size = New System.Drawing.Size(70, 35)
            Me.btnCta44.TabIndex = 38
            Me.btnCta44.Text = "Formato 3.12 Cta.44"
            Me.btnCta44.UseVisualStyleBackColor = True
            '
            'btnCta43
            '
            Me.btnCta43.Location = New System.Drawing.Point(232, 159)
            Me.btnCta43.Name = "btnCta43"
            Me.btnCta43.Size = New System.Drawing.Size(70, 35)
            Me.btnCta43.TabIndex = 37
            Me.btnCta43.Text = "Formato 3.12 Cta.43"
            Me.btnCta43.UseVisualStyleBackColor = True
            '
            'btnCta37
            '
            Me.btnCta37.Location = New System.Drawing.Point(84, 159)
            Me.btnCta37.Name = "btnCta37"
            Me.btnCta37.Size = New System.Drawing.Size(70, 35)
            Me.btnCta37.TabIndex = 36
            Me.btnCta37.Text = "Formato 3.12 Cta.37"
            Me.btnCta37.UseVisualStyleBackColor = True
            '
            'btnExistencias39
            '
            Me.btnExistencias39.Location = New System.Drawing.Point(308, 77)
            Me.btnExistencias39.Name = "btnExistencias39"
            Me.btnExistencias39.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias39.TabIndex = 35
            Me.btnExistencias39.Text = "Formato 3.7 Cta. 39"
            Me.btnExistencias39.UseVisualStyleBackColor = True
            '
            'btnExistencias33
            '
            Me.btnExistencias33.Location = New System.Drawing.Point(232, 77)
            Me.btnExistencias33.Name = "btnExistencias33"
            Me.btnExistencias33.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias33.TabIndex = 34
            Me.btnExistencias33.Text = "Formato 3.7 Cta. 33"
            Me.btnExistencias33.UseVisualStyleBackColor = True
            '
            'btnExistencias32
            '
            Me.btnExistencias32.Location = New System.Drawing.Point(160, 77)
            Me.btnExistencias32.Name = "btnExistencias32"
            Me.btnExistencias32.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias32.TabIndex = 33
            Me.btnExistencias32.Text = "Formato 3.7 Cta. 32"
            Me.btnExistencias32.UseVisualStyleBackColor = True
            '
            'btnCta18
            '
            Me.btnCta18.Location = New System.Drawing.Point(383, 36)
            Me.btnCta18.Name = "btnCta18"
            Me.btnCta18.Size = New System.Drawing.Size(70, 35)
            Me.btnCta18.TabIndex = 32
            Me.btnCta18.Text = "Formato 3.5 Cta. 18"
            Me.btnCta18.UseVisualStyleBackColor = True
            '
            'btnCta17
            '
            Me.btnCta17.Location = New System.Drawing.Point(308, 36)
            Me.btnCta17.Name = "btnCta17"
            Me.btnCta17.Size = New System.Drawing.Size(70, 35)
            Me.btnCta17.TabIndex = 31
            Me.btnCta17.Text = "Formato 3.5 Cta. 17"
            Me.btnCta17.UseVisualStyleBackColor = True
            '
            'btnCajaBancosCtaCte
            '
            Me.btnCajaBancosCtaCte.Location = New System.Drawing.Point(84, 316)
            Me.btnCajaBancosCtaCte.Name = "btnCajaBancosCtaCte"
            Me.btnCajaBancosCtaCte.Size = New System.Drawing.Size(70, 35)
            Me.btnCajaBancosCtaCte.TabIndex = 30
            Me.btnCajaBancosCtaCte.Text = "Formato 1.2"
            Me.btnCajaBancosCtaCte.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!)
            Me.Label2.Location = New System.Drawing.Point(-1, 285)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(231, 23)
            Me.Label2.TabIndex = 29
            Me.Label2.Text = "Libro de Caja y Bancos"
            '
            'btnCajaBancos
            '
            Me.btnCajaBancos.Location = New System.Drawing.Point(8, 316)
            Me.btnCajaBancos.Name = "btnCajaBancos"
            Me.btnCajaBancos.Size = New System.Drawing.Size(70, 35)
            Me.btnCajaBancos.TabIndex = 28
            Me.btnCajaBancos.Text = "Formato 1.1"
            Me.btnCajaBancos.UseVisualStyleBackColor = True
            '
            'btnCta50
            '
            Me.btnCta50.Location = New System.Drawing.Point(308, 200)
            Me.btnCta50.Name = "btnCta50"
            Me.btnCta50.Size = New System.Drawing.Size(70, 35)
            Me.btnCta50.TabIndex = 27
            Me.btnCta50.Text = "Formato 3.16 Cta.50"
            Me.btnCta50.UseVisualStyleBackColor = True
            '
            'btnCta19
            '
            Me.btnCta19.Location = New System.Drawing.Point(8, 77)
            Me.btnCta19.Name = "btnCta19"
            Me.btnCta19.Size = New System.Drawing.Size(70, 35)
            Me.btnCta19.TabIndex = 26
            Me.btnCta19.Text = "Formato 3.6 Cta.19"
            Me.btnCta19.UseVisualStyleBackColor = True
            '
            'btnBalanceComprobacion
            '
            Me.btnBalanceComprobacion.Location = New System.Drawing.Point(383, 200)
            Me.btnBalanceComprobacion.Name = "btnBalanceComprobacion"
            Me.btnBalanceComprobacion.Size = New System.Drawing.Size(70, 35)
            Me.btnBalanceComprobacion.TabIndex = 25
            Me.btnBalanceComprobacion.Text = "Formato 3.17"
            Me.btnBalanceComprobacion.UseVisualStyleBackColor = True
            '
            'btnCta10
            '
            Me.btnCta10.Location = New System.Drawing.Point(8, 36)
            Me.btnCta10.Name = "btnCta10"
            Me.btnCta10.Size = New System.Drawing.Size(70, 35)
            Me.btnCta10.TabIndex = 24
            Me.btnCta10.Text = "Formato 3.2 Cta.10"
            Me.btnCta10.UseVisualStyleBackColor = True
            '
            'btnCta41
            '
            Me.btnCta41.Location = New System.Drawing.Point(8, 159)
            Me.btnCta41.Name = "btnCta41"
            Me.btnCta41.Size = New System.Drawing.Size(70, 35)
            Me.btnCta41.TabIndex = 23
            Me.btnCta41.Text = "Formato 3.11 Cta.41"
            Me.btnCta41.UseVisualStyleBackColor = True
            '
            'btnExistencias
            '
            Me.btnExistencias.Location = New System.Drawing.Point(84, 77)
            Me.btnExistencias.Name = "btnExistencias"
            Me.btnExistencias.Size = New System.Drawing.Size(70, 35)
            Me.btnExistencias.TabIndex = 22
            Me.btnExistencias.Text = "Formato 3.7"
            Me.btnExistencias.UseVisualStyleBackColor = True
            '
            'btnCta46
            '
            Me.btnCta46.Location = New System.Drawing.Point(84, 200)
            Me.btnCta46.Name = "btnCta46"
            Me.btnCta46.Size = New System.Drawing.Size(70, 35)
            Me.btnCta46.TabIndex = 21
            Me.btnCta46.Text = "Formato 3.13 Cta.46"
            Me.btnCta46.UseVisualStyleBackColor = True
            '
            'btnCta42
            '
            Me.btnCta42.Location = New System.Drawing.Point(160, 159)
            Me.btnCta42.Name = "btnCta42"
            Me.btnCta42.Size = New System.Drawing.Size(70, 35)
            Me.btnCta42.TabIndex = 20
            Me.btnCta42.Text = "Formato 3.12 Cta.42"
            Me.btnCta42.UseVisualStyleBackColor = True
            '
            'btnCta40
            '
            Me.btnCta40.Location = New System.Drawing.Point(383, 118)
            Me.btnCta40.Name = "btnCta40"
            Me.btnCta40.Size = New System.Drawing.Size(70, 35)
            Me.btnCta40.TabIndex = 19
            Me.btnCta40.Text = "Formato 3.10 Cta.40"
            Me.btnCta40.UseVisualStyleBackColor = True
            '
            'btnCta16
            '
            Me.btnCta16.Location = New System.Drawing.Point(232, 36)
            Me.btnCta16.Name = "btnCta16"
            Me.btnCta16.Size = New System.Drawing.Size(70, 35)
            Me.btnCta16.TabIndex = 18
            Me.btnCta16.Text = "Formato 3.5 Cta. 16"
            Me.btnCta16.UseVisualStyleBackColor = True
            '
            'btnCta14
            '
            Me.btnCta14.Location = New System.Drawing.Point(160, 36)
            Me.btnCta14.Name = "btnCta14"
            Me.btnCta14.Size = New System.Drawing.Size(70, 35)
            Me.btnCta14.TabIndex = 17
            Me.btnCta14.Text = "Formato 3.4 Cta.14"
            Me.btnCta14.UseVisualStyleBackColor = True
            '
            'nudAnio
            '
            Me.nudAnio.Location = New System.Drawing.Point(66, 8)
            Me.nudAnio.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
            Me.nudAnio.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
            Me.nudAnio.Name = "nudAnio"
            Me.nudAnio.Size = New System.Drawing.Size(75, 20)
            Me.nudAnio.TabIndex = 16
            Me.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.nudAnio.Value = New Decimal(New Integer() {2000, 0, 0, 0})
            '
            'btnCta12
            '
            Me.btnCta12.Location = New System.Drawing.Point(84, 36)
            Me.btnCta12.Name = "btnCta12"
            Me.btnCta12.Size = New System.Drawing.Size(70, 35)
            Me.btnCta12.TabIndex = 14
            Me.btnCta12.Text = "Formato 3.3 Cta.12"
            Me.btnCta12.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(31, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(26, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Año"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(238, 12)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(27, 13)
            Me.Label3.TabIndex = 53
            Me.Label3.Text = "Mes"
            '
            'cboMes
            '
            Me.cboMes.FormattingEnabled = True
            Me.cboMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
            Me.cboMes.Location = New System.Drawing.Point(272, 8)
            Me.cboMes.Name = "cboMes"
            Me.cboMes.Size = New System.Drawing.Size(121, 21)
            Me.cboMes.TabIndex = 54
            '
            'frmLibroInventarioBalance
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(491, 399)
            Me.Controls.Add(Me.Panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLibroInventarioBalance"
            Me.Text = "Libro de Inventarios y Balances"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnCta12 As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents nudAnio As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnCta14 As System.Windows.Forms.Button
        Friend WithEvents btnCta16 As System.Windows.Forms.Button
        Friend WithEvents btnCta40 As System.Windows.Forms.Button
        Friend WithEvents btnCta42 As System.Windows.Forms.Button
        Friend WithEvents btnCta46 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias As System.Windows.Forms.Button
        Friend WithEvents btnCta41 As System.Windows.Forms.Button
        Friend WithEvents btnCta10 As System.Windows.Forms.Button
        Friend WithEvents btnBalanceComprobacion As System.Windows.Forms.Button
        Friend WithEvents btnCta19 As System.Windows.Forms.Button
        Friend WithEvents btnCta50 As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnCajaBancos As System.Windows.Forms.Button
        Friend WithEvents btnCajaBancosCtaCte As System.Windows.Forms.Button
        Friend WithEvents btnCta17 As System.Windows.Forms.Button
        Friend WithEvents btnCta18 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias32 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias33 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias39 As System.Windows.Forms.Button
        Friend WithEvents btnCta49 As System.Windows.Forms.Button
        Friend WithEvents btnCta48 As System.Windows.Forms.Button
        Friend WithEvents btnCta47 As System.Windows.Forms.Button
        Friend WithEvents btnCta45 As System.Windows.Forms.Button
        Friend WithEvents btnCta44 As System.Windows.Forms.Button
        Friend WithEvents btnCta43 As System.Windows.Forms.Button
        Friend WithEvents btnCta37 As System.Windows.Forms.Button
        Friend WithEvents btnCta31 As System.Windows.Forms.Button
        Friend WithEvents btnCta34 As System.Windows.Forms.Button
        Friend WithEvents btnCta30 As System.Windows.Forms.Button
        Friend WithEvents btnCta47X As System.Windows.Forms.Button
        Friend WithEvents btnExistencias56 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias59 As System.Windows.Forms.Button
        Friend WithEvents btnExistencias58 As System.Windows.Forms.Button
        Friend WithEvents btnBalanceGeneral As System.Windows.Forms.Button
        Friend WithEvents btnPatrimonioNeto As System.Windows.Forms.Button
        Friend WithEvents btnEstadoGananciasPerdidas As System.Windows.Forms.Button
        Friend WithEvents cboMes As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
    End Class

End Namespace