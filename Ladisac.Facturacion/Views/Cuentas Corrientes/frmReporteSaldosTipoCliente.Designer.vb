Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteSaldosTipoCliente
        ' Inherits System.Windows.Forms.Form
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
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbDetalle = New System.Windows.Forms.RadioButton()
            Me.rdbGeneral = New System.Windows.Forms.RadioButton()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.lblTipoCliente = New System.Windows.Forms.Label()
            Me.cboTipoCliente = New System.Windows.Forms.ComboBox()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.chkContraEntregaSinCancelar = New System.Windows.Forms.RadioButton()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.lblDesde = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(558, 28)
            Me.lblTitle.Text = "Reporte saldos tipo cliente"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.lblDesde)
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.lblTipoCliente)
            Me.Panel1.Controls.Add(Me.cboTipoCliente)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(6, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(545, 111)
            Me.Panel1.TabIndex = 1
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.chkContraEntregaSinCancelar)
            Me.GroupBox1.Controls.Add(Me.rdbDetalle)
            Me.GroupBox1.Controls.Add(Me.rdbGeneral)
            Me.GroupBox1.Location = New System.Drawing.Point(358, 9)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(180, 95)
            Me.GroupBox1.TabIndex = 137
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Tipo de Reporte"
            '
            'rdbDetalle
            '
            Me.rdbDetalle.AutoSize = True
            Me.rdbDetalle.Location = New System.Drawing.Point(7, 45)
            Me.rdbDetalle.Name = "rdbDetalle"
            Me.rdbDetalle.Size = New System.Drawing.Size(120, 17)
            Me.rdbDetalle.TabIndex = 1
            Me.rdbDetalle.Text = "Detalle Movimientos"
            Me.rdbDetalle.UseVisualStyleBackColor = True
            '
            'rdbGeneral
            '
            Me.rdbGeneral.AutoSize = True
            Me.rdbGeneral.Checked = True
            Me.rdbGeneral.Location = New System.Drawing.Point(7, 21)
            Me.rdbGeneral.Name = "rdbGeneral"
            Me.rdbGeneral.Size = New System.Drawing.Size(62, 17)
            Me.rdbGeneral.TabIndex = 0
            Me.rdbGeneral.TabStop = True
            Me.rdbGeneral.Text = "General"
            Me.rdbGeneral.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(266, 73)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 136
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'lblTipoCliente
            '
            Me.lblTipoCliente.AutoSize = True
            Me.lblTipoCliente.Location = New System.Drawing.Point(24, 35)
            Me.lblTipoCliente.Name = "lblTipoCliente"
            Me.lblTipoCliente.Size = New System.Drawing.Size(62, 13)
            Me.lblTipoCliente.TabIndex = 135
            Me.lblTipoCliente.Text = "Tipo cliente"
            '
            'cboTipoCliente
            '
            Me.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTipoCliente.Enabled = False
            Me.cboTipoCliente.FormattingEnabled = True
            Me.cboTipoCliente.Location = New System.Drawing.Point(97, 35)
            Me.cboTipoCliente.Name = "cboTipoCliente"
            Me.cboTipoCliente.Size = New System.Drawing.Size(244, 21)
            Me.cboTipoCliente.TabIndex = 134
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(243, 9)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(98, 20)
            Me.dateHasta.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(195, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(35, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Hasta"
            '
            'chkContraEntregaSinCancelar
            '
            Me.chkContraEntregaSinCancelar.AutoSize = True
            Me.chkContraEntregaSinCancelar.Location = New System.Drawing.Point(7, 72)
            Me.chkContraEntregaSinCancelar.Name = "chkContraEntregaSinCancelar"
            Me.chkContraEntregaSinCancelar.Size = New System.Drawing.Size(155, 17)
            Me.chkContraEntregaSinCancelar.TabIndex = 2
            Me.chkContraEntregaSinCancelar.TabStop = True
            Me.chkContraEntregaSinCancelar.Text = "Contra entrega sin cancelar"
            Me.chkContraEntregaSinCancelar.UseVisualStyleBackColor = True
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(91, 9)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(98, 20)
            Me.dateDesde.TabIndex = 139
            Me.dateDesde.Visible = False
            '
            'lblDesde
            '
            Me.lblDesde.AutoSize = True
            Me.lblDesde.Location = New System.Drawing.Point(43, 16)
            Me.lblDesde.Name = "lblDesde"
            Me.lblDesde.Size = New System.Drawing.Size(38, 13)
            Me.lblDesde.TabIndex = 138
            Me.lblDesde.Text = "Desde"
            Me.lblDesde.Visible = False
            '
            'frmReporteSaldosTipoCliente
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(558, 153)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteSaldosTipoCliente"
            Me.Text = "Reporte saldos tipo cliente"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
        Public WithEvents cboTipoCliente As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbDetalle As System.Windows.Forms.RadioButton
        Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents chkContraEntregaSinCancelar As System.Windows.Forms.RadioButton
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDesde As System.Windows.Forms.Label
    End Class
End Namespace