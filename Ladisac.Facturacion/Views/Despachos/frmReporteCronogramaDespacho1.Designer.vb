Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteCronogramaDespacho1
        Inherits Ladisac.Foundation.Views.ViewManMaster
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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbGuias = New System.Windows.Forms.RadioButton()
            Me.rdbPorArticulo = New System.Windows.Forms.RadioButton()
            Me.rdbGeneral = New System.Windows.Forms.RadioButton()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.cboEstado = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblPER_ID_VEN = New System.Windows.Forms.Label()
            Me.txtPER_ID_VEN = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_VEN = New System.Windows.Forms.TextBox()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(590, 28)
            Me.lblTitle.Text = "Reporte cronograma despacho"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.Label5)
            Me.pnCuerpo.Controls.Add(Me.GroupBox1)
            Me.pnCuerpo.Controls.Add(Me.btnGenerar)
            Me.pnCuerpo.Controls.Add(Me.cboEstado)
            Me.pnCuerpo.Controls.Add(Me.Label4)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_VEN)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_VEN)
            Me.pnCuerpo.Controls.Add(Me.dateHasta)
            Me.pnCuerpo.Controls.Add(Me.dateDesde)
            Me.pnCuerpo.Controls.Add(Me.Label2)
            Me.pnCuerpo.Controls.Add(Me.Label1)
            Me.pnCuerpo.Location = New System.Drawing.Point(4, 32)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(578, 208)
            Me.pnCuerpo.TabIndex = 1
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(14, 119)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(67, 13)
            Me.Label5.TabIndex = 106
            Me.Label5.Text = "Tipo reporte:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rdbGuias)
            Me.GroupBox1.Controls.Add(Me.rdbPorArticulo)
            Me.GroupBox1.Controls.Add(Me.rdbGeneral)
            Me.GroupBox1.Location = New System.Drawing.Point(80, 103)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(334, 39)
            Me.GroupBox1.TabIndex = 105
            Me.GroupBox1.TabStop = False
            '
            'rdbGuias
            '
            Me.rdbGuias.AutoSize = True
            Me.rdbGuias.Location = New System.Drawing.Point(185, 14)
            Me.rdbGuias.Name = "rdbGuias"
            Me.rdbGuias.Size = New System.Drawing.Size(139, 17)
            Me.rdbGuias.TabIndex = 8
            Me.rdbGuias.TabStop = True
            Me.rdbGuias.Text = "Guías por programación"
            Me.rdbGuias.UseVisualStyleBackColor = True
            '
            'rdbPorArticulo
            '
            Me.rdbPorArticulo.AutoSize = True
            Me.rdbPorArticulo.Location = New System.Drawing.Point(86, 14)
            Me.rdbPorArticulo.Name = "rdbPorArticulo"
            Me.rdbPorArticulo.Size = New System.Drawing.Size(78, 17)
            Me.rdbPorArticulo.TabIndex = 7
            Me.rdbPorArticulo.TabStop = True
            Me.rdbPorArticulo.Text = "Por articulo"
            Me.rdbPorArticulo.UseVisualStyleBackColor = True
            '
            'rdbGeneral
            '
            Me.rdbGeneral.AutoSize = True
            Me.rdbGeneral.Checked = True
            Me.rdbGeneral.Location = New System.Drawing.Point(7, 14)
            Me.rdbGeneral.Name = "rdbGeneral"
            Me.rdbGeneral.Size = New System.Drawing.Size(62, 17)
            Me.rdbGeneral.TabIndex = 6
            Me.rdbGeneral.TabStop = True
            Me.rdbGeneral.Text = "General"
            Me.rdbGeneral.UseVisualStyleBackColor = True
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(80, 148)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(76, 41)
            Me.btnGenerar.TabIndex = 9
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'cboEstado
            '
            Me.cboEstado.FormattingEnabled = True
            Me.cboEstado.Items.AddRange(New Object() {"Estado 0", "Estado 1", "Estado 2", "Estado 3"})
            Me.cboEstado.Location = New System.Drawing.Point(80, 78)
            Me.cboEstado.Name = "cboEstado"
            Me.cboEstado.Size = New System.Drawing.Size(121, 21)
            Me.cboEstado.TabIndex = 5
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(14, 78)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(43, 13)
            Me.Label4.TabIndex = 100
            Me.Label4.Text = "Estado:"
            '
            'lblPER_ID_VEN
            '
            Me.lblPER_ID_VEN.AutoSize = True
            Me.lblPER_ID_VEN.Location = New System.Drawing.Point(14, 48)
            Me.lblPER_ID_VEN.Name = "lblPER_ID_VEN"
            Me.lblPER_ID_VEN.Size = New System.Drawing.Size(56, 13)
            Me.lblPER_ID_VEN.TabIndex = 99
            Me.lblPER_ID_VEN.Text = "Vendedor:"
            '
            'txtPER_ID_VEN
            '
            Me.txtPER_ID_VEN.Location = New System.Drawing.Point(80, 48)
            Me.txtPER_ID_VEN.Name = "txtPER_ID_VEN"
            Me.txtPER_ID_VEN.Size = New System.Drawing.Size(68, 20)
            Me.txtPER_ID_VEN.TabIndex = 3
            '
            'txtPER_DESCRIPCION_VEN
            '
            Me.txtPER_DESCRIPCION_VEN.Enabled = False
            Me.txtPER_DESCRIPCION_VEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPER_DESCRIPCION_VEN.Location = New System.Drawing.Point(150, 48)
            Me.txtPER_DESCRIPCION_VEN.Name = "txtPER_DESCRIPCION_VEN"
            Me.txtPER_DESCRIPCION_VEN.ReadOnly = True
            Me.txtPER_DESCRIPCION_VEN.Size = New System.Drawing.Size(407, 20)
            Me.txtPER_DESCRIPCION_VEN.TabIndex = 4
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateHasta.Location = New System.Drawing.Point(239, 19)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(92, 20)
            Me.dateHasta.TabIndex = 2
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateDesde.Location = New System.Drawing.Point(81, 19)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(92, 20)
            Me.dateDesde.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(198, 19)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Desde:"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmReporteCronogramaDespacho
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(590, 252)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmReporteCronogramaDespacho"
            Me.Text = "Reporte cronograma despacho"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_VEN As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_VEN As System.Windows.Forms.TextBox
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbPorArticulo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
        Friend WithEvents rdbGuias As System.Windows.Forms.RadioButton
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace
