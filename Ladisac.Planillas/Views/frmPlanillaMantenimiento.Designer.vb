Namespace Ladisac.Planillas.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPlanillaMantenimiento
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
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.dgvBoletas = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnEliminarBoleta = New System.Windows.Forms.Button()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.dgvPersonas = New System.Windows.Forms.DataGridView()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.txtCodigoBuscar = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.btnEliminarTrabajador = New System.Windows.Forms.Button()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.btnBoleta = New System.Windows.Forms.Button()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dgvConceptosTrabajador = New System.Windows.Forms.DataGridView()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnBuscarDatos = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnModificar = New System.Windows.Forms.Button()
            Me.txtDescripcionPLL = New System.Windows.Forms.TextBox()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.txtSeriePLL = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtNumeroPLL = New System.Windows.Forms.TextBox()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.dgvBoletas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.dgvConceptosTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(703, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.TabControl1)
            Me.Panel1.Location = New System.Drawing.Point(3, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(695, 355)
            Me.Panel1.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Location = New System.Drawing.Point(4, 7)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(684, 345)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.dgvBoletas)
            Me.TabPage1.Controls.Add(Me.Panel2)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(676, 319)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Eliminar Boleta"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'dgvBoletas
            '
            Me.dgvBoletas.AllowUserToAddRows = False
            Me.dgvBoletas.AllowUserToDeleteRows = False
            Me.dgvBoletas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvBoletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvBoletas.Location = New System.Drawing.Point(4, 49)
            Me.dgvBoletas.Name = "dgvBoletas"
            Me.dgvBoletas.ReadOnly = True
            Me.dgvBoletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvBoletas.Size = New System.Drawing.Size(666, 264)
            Me.dgvBoletas.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.btnEliminarBoleta)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(666, 38)
            Me.Panel2.TabIndex = 0
            '
            'btnEliminarBoleta
            '
            Me.btnEliminarBoleta.Location = New System.Drawing.Point(525, 9)
            Me.btnEliminarBoleta.Name = "btnEliminarBoleta"
            Me.btnEliminarBoleta.Size = New System.Drawing.Size(75, 23)
            Me.btnEliminarBoleta.TabIndex = 19
            Me.btnEliminarBoleta.Text = "Eliminar"
            Me.btnEliminarBoleta.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(179, 7)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(26, 23)
            Me.btnPeriodo.TabIndex = 18
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(91, 9)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
            Me.txtPeriodo.TabIndex = 17
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(42, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Periodo"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.dgvPersonas)
            Me.TabPage2.Controls.Add(Me.Panel3)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(676, 319)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Eliminar Personas de una boleta"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'dgvPersonas
            '
            Me.dgvPersonas.AllowUserToAddRows = False
            Me.dgvPersonas.AllowUserToDeleteRows = False
            Me.dgvPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPersonas.Location = New System.Drawing.Point(4, 65)
            Me.dgvPersonas.Name = "dgvPersonas"
            Me.dgvPersonas.ReadOnly = True
            Me.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPersonas.Size = New System.Drawing.Size(667, 249)
            Me.dgvPersonas.TabIndex = 1
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.txtCodigoBuscar)
            Me.Panel3.Controls.Add(Me.Label21)
            Me.Panel3.Controls.Add(Me.btnEliminarTrabajador)
            Me.Panel3.Controls.Add(Me.txtDescripcion)
            Me.Panel3.Controls.Add(Me.btnBoleta)
            Me.Panel3.Controls.Add(Me.txtSerie)
            Me.Panel3.Controls.Add(Me.Label2)
            Me.Panel3.Controls.Add(Me.txtNumero)
            Me.Panel3.Location = New System.Drawing.Point(3, 5)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(669, 54)
            Me.Panel3.TabIndex = 0
            '
            'txtCodigoBuscar
            '
            Me.txtCodigoBuscar.Location = New System.Drawing.Point(90, 31)
            Me.txtCodigoBuscar.Name = "txtCodigoBuscar"
            Me.txtCodigoBuscar.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigoBuscar.TabIndex = 28
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(8, 34)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(76, 13)
            Me.Label21.TabIndex = 27
            Me.Label21.Text = "Buscar Codigo"
            '
            'btnEliminarTrabajador
            '
            Me.btnEliminarTrabajador.Location = New System.Drawing.Point(532, 7)
            Me.btnEliminarTrabajador.Name = "btnEliminarTrabajador"
            Me.btnEliminarTrabajador.Size = New System.Drawing.Size(75, 23)
            Me.btnEliminarTrabajador.TabIndex = 26
            Me.btnEliminarTrabajador.Text = "Eliminar"
            Me.btnEliminarTrabajador.UseVisualStyleBackColor = True
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(283, 9)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.ReadOnly = True
            Me.txtDescripcion.Size = New System.Drawing.Size(205, 20)
            Me.txtDescripcion.TabIndex = 25
            '
            'btnBoleta
            '
            Me.btnBoleta.Location = New System.Drawing.Point(494, 6)
            Me.btnBoleta.Name = "btnBoleta"
            Me.btnBoleta.Size = New System.Drawing.Size(22, 23)
            Me.btnBoleta.TabIndex = 24
            Me.btnBoleta.Text = ":::"
            Me.btnBoleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBoleta.UseVisualStyleBackColor = True
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(90, 9)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.ReadOnly = True
            Me.txtSerie.Size = New System.Drawing.Size(49, 20)
            Me.txtSerie.TabIndex = 23
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(8, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(76, 13)
            Me.Label2.TabIndex = 22
            Me.Label2.Text = "Serie /Numero"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(145, 9)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(132, 20)
            Me.txtNumero.TabIndex = 21
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.Label5)
            Me.TabPage3.Controls.Add(Me.dgvConceptosTrabajador)
            Me.TabPage3.Controls.Add(Me.Panel4)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(676, 319)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Modificar Importes  de Conceptos por Trabajador"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(7, 303)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(308, 13)
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "Tal como se observa los importes , se actualizara  en el sistema "
            '
            'dgvConceptosTrabajador
            '
            Me.dgvConceptosTrabajador.AllowUserToAddRows = False
            Me.dgvConceptosTrabajador.AllowUserToDeleteRows = False
            Me.dgvConceptosTrabajador.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvConceptosTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvConceptosTrabajador.Location = New System.Drawing.Point(5, 69)
            Me.dgvConceptosTrabajador.Name = "dgvConceptosTrabajador"
            Me.dgvConceptosTrabajador.Size = New System.Drawing.Size(668, 231)
            Me.dgvConceptosTrabajador.TabIndex = 2
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.Controls.Add(Me.btnBuscarDatos)
            Me.Panel4.Controls.Add(Me.btnTrabajador)
            Me.Panel4.Controls.Add(Me.txtTrabajador)
            Me.Panel4.Controls.Add(Me.Label4)
            Me.Panel4.Controls.Add(Me.btnModificar)
            Me.Panel4.Controls.Add(Me.txtDescripcionPLL)
            Me.Panel4.Controls.Add(Me.Button2)
            Me.Panel4.Controls.Add(Me.txtSeriePLL)
            Me.Panel4.Controls.Add(Me.Label3)
            Me.Panel4.Controls.Add(Me.txtNumeroPLL)
            Me.Panel4.Location = New System.Drawing.Point(3, 5)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(669, 59)
            Me.Panel4.TabIndex = 1
            '
            'btnBuscarDatos
            '
            Me.btnBuscarDatos.Location = New System.Drawing.Point(524, 7)
            Me.btnBuscarDatos.Name = "btnBuscarDatos"
            Me.btnBuscarDatos.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscarDatos.TabIndex = 30
            Me.btnBuscarDatos.Text = "Buscar"
            Me.btnBuscarDatos.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(494, 33)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 29
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(90, 35)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(398, 20)
            Me.txtTrabajador.TabIndex = 28
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(29, 38)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 27
            Me.Label4.Text = "Trabajador"
            '
            'btnModificar
            '
            Me.btnModificar.Location = New System.Drawing.Point(524, 32)
            Me.btnModificar.Name = "btnModificar"
            Me.btnModificar.Size = New System.Drawing.Size(75, 23)
            Me.btnModificar.TabIndex = 26
            Me.btnModificar.Text = "Modificar"
            Me.btnModificar.UseVisualStyleBackColor = True
            '
            'txtDescripcionPLL
            '
            Me.txtDescripcionPLL.Location = New System.Drawing.Point(283, 9)
            Me.txtDescripcionPLL.Name = "txtDescripcionPLL"
            Me.txtDescripcionPLL.ReadOnly = True
            Me.txtDescripcionPLL.Size = New System.Drawing.Size(205, 20)
            Me.txtDescripcionPLL.TabIndex = 25
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(494, 6)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(22, 23)
            Me.Button2.TabIndex = 24
            Me.Button2.Text = ":::"
            Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.Button2.UseVisualStyleBackColor = True
            '
            'txtSeriePLL
            '
            Me.txtSeriePLL.Location = New System.Drawing.Point(90, 9)
            Me.txtSeriePLL.Name = "txtSeriePLL"
            Me.txtSeriePLL.ReadOnly = True
            Me.txtSeriePLL.Size = New System.Drawing.Size(49, 20)
            Me.txtSeriePLL.TabIndex = 23
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(8, 12)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(76, 13)
            Me.Label3.TabIndex = 22
            Me.Label3.Text = "Serie /Numero"
            '
            'txtNumeroPLL
            '
            Me.txtNumeroPLL.Location = New System.Drawing.Point(145, 9)
            Me.txtNumeroPLL.Name = "txtNumeroPLL"
            Me.txtNumeroPLL.ReadOnly = True
            Me.txtNumeroPLL.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroPLL.TabIndex = 21
            '
            'frmPlanillaMantenimiento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(703, 389)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPlanillaMantenimiento"
            Me.Text = "frmPlanillaMantenimiento"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.dgvBoletas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout()
            CType(Me.dgvConceptosTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnEliminarBoleta As System.Windows.Forms.Button
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents dgvBoletas As System.Windows.Forms.DataGridView
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnEliminarTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents btnBoleta As System.Windows.Forms.Button
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents dgvPersonas As System.Windows.Forms.DataGridView
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnModificar As System.Windows.Forms.Button
        Friend WithEvents txtDescripcionPLL As System.Windows.Forms.TextBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents txtSeriePLL As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroPLL As System.Windows.Forms.TextBox
        Friend WithEvents dgvConceptosTrabajador As System.Windows.Forms.DataGridView
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnBuscarDatos As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtCodigoBuscar As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
    End Class


End Namespace