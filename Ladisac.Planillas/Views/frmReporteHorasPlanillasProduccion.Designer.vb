Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReporteHorasPlanillasProduccion
        'Inherits System.Windows.Forms.Form
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
            Me.components = New System.ComponentModel.Container()
            Me.dgvPLanillas = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnAgregarPorRango = New System.Windows.Forms.Button()
            Me.btnPeriodoHasta = New System.Windows.Forms.Button()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtPeriodoHasta = New System.Windows.Forms.TextBox()
            Me.btnPeriodoDesde = New System.Windows.Forms.Button()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtPeriodoDesde = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.btnQuitar = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnAgregar = New System.Windows.Forms.Button()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.btnBoleta = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnReporte = New System.Windows.Forms.Button()
            CType(Me.dgvPLanillas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(794, 28)
            '
            'dgvPLanillas
            '
            Me.dgvPLanillas.AllowUserToAddRows = False
            Me.dgvPLanillas.AllowUserToDeleteRows = False
            Me.dgvPLanillas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPLanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPLanillas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
            Me.dgvPLanillas.Location = New System.Drawing.Point(4, 141)
            Me.dgvPLanillas.Name = "dgvPLanillas"
            Me.dgvPLanillas.ReadOnly = True
            Me.dgvPLanillas.Size = New System.Drawing.Size(786, 263)
            Me.dgvPLanillas.TabIndex = 9
            '
            'Column1
            '
            Me.Column1.HeaderText = "Serie"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            '
            'Column2
            '
            Me.Column2.HeaderText = "Numero"
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            '
            'Column3
            '
            Me.Column3.HeaderText = "Descripcion"
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            Me.Column3.Width = 200
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.GroupBox2)
            Me.Panel4.Controls.Add(Me.GroupBox1)
            Me.Panel4.Location = New System.Drawing.Point(4, 31)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(790, 107)
            Me.Panel4.TabIndex = 8
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.btnReporte)
            Me.GroupBox2.Controls.Add(Me.btnAgregarPorRango)
            Me.GroupBox2.Controls.Add(Me.btnPeriodoHasta)
            Me.GroupBox2.Controls.Add(Me.Label19)
            Me.GroupBox2.Controls.Add(Me.txtPeriodoHasta)
            Me.GroupBox2.Controls.Add(Me.btnPeriodoDesde)
            Me.GroupBox2.Controls.Add(Me.Label18)
            Me.GroupBox2.Controls.Add(Me.txtPeriodoDesde)
            Me.GroupBox2.Location = New System.Drawing.Point(4, 51)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(781, 45)
            Me.GroupBox2.TabIndex = 24
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Buscar por Rango de Periodo"
            '
            'btnAgregarPorRango
            '
            Me.btnAgregarPorRango.Location = New System.Drawing.Point(432, 17)
            Me.btnAgregarPorRango.Name = "btnAgregarPorRango"
            Me.btnAgregarPorRango.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregarPorRango.TabIndex = 29
            Me.btnAgregarPorRango.Text = "Agregar"
            Me.btnAgregarPorRango.UseVisualStyleBackColor = True
            '
            'btnPeriodoHasta
            '
            Me.btnPeriodoHasta.Location = New System.Drawing.Point(392, 17)
            Me.btnPeriodoHasta.Name = "btnPeriodoHasta"
            Me.btnPeriodoHasta.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoHasta.TabIndex = 28
            Me.btnPeriodoHasta.Text = ":::"
            Me.btnPeriodoHasta.UseVisualStyleBackColor = True
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(216, 23)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(85, 13)
            Me.Label19.TabIndex = 27
            Me.Label19.Text = "Hasta el Periodo"
            '
            'txtPeriodoHasta
            '
            Me.txtPeriodoHasta.Location = New System.Drawing.Point(304, 19)
            Me.txtPeriodoHasta.Name = "txtPeriodoHasta"
            Me.txtPeriodoHasta.ReadOnly = True
            Me.txtPeriodoHasta.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoHasta.TabIndex = 26
            '
            'btnPeriodoDesde
            '
            Me.btnPeriodoDesde.Location = New System.Drawing.Point(184, 17)
            Me.btnPeriodoDesde.Name = "btnPeriodoDesde"
            Me.btnPeriodoDesde.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodoDesde.TabIndex = 25
            Me.btnPeriodoDesde.Text = ":::"
            Me.btnPeriodoDesde.UseVisualStyleBackColor = True
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(3, 22)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(88, 13)
            Me.Label18.TabIndex = 24
            Me.Label18.Text = "Desde el Periodo"
            '
            'txtPeriodoDesde
            '
            Me.txtPeriodoDesde.Location = New System.Drawing.Point(96, 19)
            Me.txtPeriodoDesde.Name = "txtPeriodoDesde"
            Me.txtPeriodoDesde.ReadOnly = True
            Me.txtPeriodoDesde.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodoDesde.TabIndex = 23
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.txtNumero)
            Me.GroupBox1.Controls.Add(Me.btnQuitar)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.btnAgregar)
            Me.GroupBox1.Controls.Add(Me.txtSerie)
            Me.GroupBox1.Controls.Add(Me.txtDescripcion)
            Me.GroupBox1.Controls.Add(Me.btnBoleta)
            Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(782, 45)
            Me.GroupBox1.TabIndex = 23
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Buscar por Planilla"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(157, 16)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(132, 20)
            Me.txtNumero.TabIndex = 16
            '
            'btnQuitar
            '
            Me.btnQuitar.Location = New System.Drawing.Point(613, 14)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 22
            Me.btnQuitar.Text = "Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(20, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(76, 13)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Serie /Numero"
            '
            'btnAgregar
            '
            Me.btnAgregar.Location = New System.Drawing.Point(535, 14)
            Me.btnAgregar.Name = "btnAgregar"
            Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregar.TabIndex = 21
            Me.btnAgregar.Text = "Agregar"
            Me.btnAgregar.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(102, 16)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.ReadOnly = True
            Me.txtSerie.Size = New System.Drawing.Size(49, 20)
            Me.txtSerie.TabIndex = 18
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(295, 16)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.ReadOnly = True
            Me.txtDescripcion.Size = New System.Drawing.Size(205, 20)
            Me.txtDescripcion.TabIndex = 20
            '
            'btnBoleta
            '
            Me.btnBoleta.Location = New System.Drawing.Point(506, 14)
            Me.btnBoleta.Name = "btnBoleta"
            Me.btnBoleta.Size = New System.Drawing.Size(22, 23)
            Me.btnBoleta.TabIndex = 19
            Me.btnBoleta.Text = ":::"
            Me.btnBoleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBoleta.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnReporte
            '
            Me.btnReporte.Location = New System.Drawing.Point(602, 13)
            Me.btnReporte.Name = "btnReporte"
            Me.btnReporte.Size = New System.Drawing.Size(75, 23)
            Me.btnReporte.TabIndex = 30
            Me.btnReporte.Text = "Reporte"
            Me.btnReporte.UseVisualStyleBackColor = True
            '
            'frmReporteHorasPlanillasProduccion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(794, 416)
            Me.Controls.Add(Me.dgvPLanillas)
            Me.Controls.Add(Me.Panel4)
            Me.Name = "frmReporteHorasPlanillasProduccion"
            Me.Text = "frmReporteHorasPlanillasProduccion"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel4, 0)
            Me.Controls.SetChildIndex(Me.dgvPLanillas, 0)
            CType(Me.dgvPLanillas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dgvPLanillas As System.Windows.Forms.DataGridView
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents btnAgregarPorRango As System.Windows.Forms.Button
        Friend WithEvents btnPeriodoHasta As System.Windows.Forms.Button
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoHasta As System.Windows.Forms.TextBox
        Friend WithEvents btnPeriodoDesde As System.Windows.Forms.Button
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodoDesde As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents btnQuitar As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnAgregar As System.Windows.Forms.Button
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnBoleta As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnReporte As System.Windows.Forms.Button
    End Class

End Namespace