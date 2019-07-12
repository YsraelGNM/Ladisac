Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteGrupoTrabajoHora
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.rdbHoraReales = New System.Windows.Forms.RadioButton()
            Me.dbTodo = New System.Windows.Forms.RadioButton()
            Me.rdbMostrarTotales = New System.Windows.Forms.RadioButton()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbRangoFecha = New System.Windows.Forms.RadioButton()
            Me.rdbSoloSemana = New System.Windows.Forms.RadioButton()
            Me.cboFiltro = New System.Windows.Forms.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(663, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.GroupBox2)
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Controls.Add(Me.cboFiltro)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.dateHasta)
            Me.Panel1.Controls.Add(Me.dateDesde)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(655, 161)
            Me.Panel1.TabIndex = 2
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.rdbHoraReales)
            Me.GroupBox2.Controls.Add(Me.dbTodo)
            Me.GroupBox2.Controls.Add(Me.rdbMostrarTotales)
            Me.GroupBox2.Location = New System.Drawing.Point(399, 69)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(252, 85)
            Me.GroupBox2.TabIndex = 24
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Tipo de Reporte"
            '
            'rdbHoraReales
            '
            Me.rdbHoraReales.AutoSize = True
            Me.rdbHoraReales.Location = New System.Drawing.Point(6, 65)
            Me.rdbHoraReales.Name = "rdbHoraReales"
            Me.rdbHoraReales.Size = New System.Drawing.Size(245, 17)
            Me.rdbHoraReales.TabIndex = 24
            Me.rdbHoraReales.Text = "Mostrar Horas Reales(No Incluye Bonificacion)"
            Me.rdbHoraReales.UseVisualStyleBackColor = True
            '
            'dbTodo
            '
            Me.dbTodo.AutoSize = True
            Me.dbTodo.Location = New System.Drawing.Point(6, 19)
            Me.dbTodo.Name = "dbTodo"
            Me.dbTodo.Size = New System.Drawing.Size(88, 17)
            Me.dbTodo.TabIndex = 23
            Me.dbTodo.Text = "Mostrar Todo"
            Me.dbTodo.UseVisualStyleBackColor = True
            '
            'rdbMostrarTotales
            '
            Me.rdbMostrarTotales.AutoSize = True
            Me.rdbMostrarTotales.Checked = True
            Me.rdbMostrarTotales.Location = New System.Drawing.Point(6, 42)
            Me.rdbMostrarTotales.Name = "rdbMostrarTotales"
            Me.rdbMostrarTotales.Size = New System.Drawing.Size(230, 17)
            Me.rdbMostrarTotales.TabIndex = 22
            Me.rdbMostrarTotales.TabStop = True
            Me.rdbMostrarTotales.Text = "Mostrar Horas Totales(Incluye Bonificacion)"
            Me.rdbMostrarTotales.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rdbRangoFecha)
            Me.GroupBox1.Controls.Add(Me.rdbSoloSemana)
            Me.GroupBox1.Location = New System.Drawing.Point(399, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(251, 62)
            Me.GroupBox1.TabIndex = 23
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Tipo de Reporte"
            '
            'rdbRangoFecha
            '
            Me.rdbRangoFecha.AutoSize = True
            Me.rdbRangoFecha.Location = New System.Drawing.Point(6, 42)
            Me.rdbRangoFecha.Name = "rdbRangoFecha"
            Me.rdbRangoFecha.Size = New System.Drawing.Size(124, 17)
            Me.rdbRangoFecha.TabIndex = 23
            Me.rdbRangoFecha.Text = "Por Rango de Fecha"
            Me.rdbRangoFecha.UseVisualStyleBackColor = True
            '
            'rdbSoloSemana
            '
            Me.rdbSoloSemana.AutoSize = True
            Me.rdbSoloSemana.Checked = True
            Me.rdbSoloSemana.Location = New System.Drawing.Point(7, 19)
            Me.rdbSoloSemana.Name = "rdbSoloSemana"
            Me.rdbSoloSemana.Size = New System.Drawing.Size(83, 17)
            Me.rdbSoloSemana.TabIndex = 22
            Me.rdbSoloSemana.TabStop = True
            Me.rdbSoloSemana.Text = "Por Semana"
            Me.rdbSoloSemana.UseVisualStyleBackColor = True
            '
            'cboFiltro
            '
            Me.cboFiltro.FormattingEnabled = True
            Me.cboFiltro.Items.AddRange(New Object() {"General", "Tarea", "Area de Tabajo", "Produccion", "Planta"})
            Me.cboFiltro.Location = New System.Drawing.Point(76, 78)
            Me.cboFiltro.Name = "cboFiltro"
            Me.cboFiltro.Size = New System.Drawing.Size(277, 21)
            Me.cboFiltro.TabIndex = 20
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(10, 83)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(62, 13)
            Me.Label3.TabIndex = 19
            Me.Label3.Text = "Agrupar por"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(225, 34)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 18
            Me.Label2.Text = "Hasta"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(34, 34)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Desde"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(266, 31)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(89, 20)
            Me.dateHasta.TabIndex = 16
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(76, 30)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(89, 20)
            Me.dateDesde.TabIndex = 15
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(359, 54)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(28, 23)
            Me.btnTrabajador.TabIndex = 14
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(76, 56)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(277, 20)
            Me.txtTrabajador.TabIndex = 13
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(14, 59)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Trabajador"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(278, 108)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 0
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'frmReporteGrupoTrabajoHora
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(663, 197)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReporteGrupoTrabajoHora"
            Me.Text = "frmReporteGrupoTrabajoHora"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboFiltro As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbRangoFecha As System.Windows.Forms.RadioButton
        Friend WithEvents rdbSoloSemana As System.Windows.Forms.RadioButton
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbHoraReales As System.Windows.Forms.RadioButton
        Friend WithEvents dbTodo As System.Windows.Forms.RadioButton
        Friend WithEvents rdbMostrarTotales As System.Windows.Forms.RadioButton
    End Class
End Namespace
