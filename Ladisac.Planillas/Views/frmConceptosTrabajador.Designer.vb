
Namespace Ladisac.Planillas.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConceptosTrabajador
        Inherits ViewManMasterPlanillas
        ' Inherits System.Windows.Forms.Form

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
            Me.dataPersonas = New System.Windows.Forms.DataGridView()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnTrabajadorCLS = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.btnTipoTrabLimpiar = New System.Windows.Forms.Button()
            Me.btnTipoTrabaBuscar = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.btnLimpiarRegimen = New System.Windows.Forms.Button()
            Me.btnBucarRegimen = New System.Windows.Forms.Button()
            Me.txtRegimen = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dataRegimen = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnConceptoBuscar = New System.Windows.Forms.Button()
            Me.chkEsPorcentaje = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtImporte = New System.Windows.Forms.TextBox()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dataPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.dataRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(809, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.dataPersonas)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.dataRegimen)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(800, 484)
            Me.Panel1.TabIndex = 3
            '
            'dataPersonas
            '
            Me.dataPersonas.AllowUserToAddRows = False
            Me.dataPersonas.AllowUserToDeleteRows = False
            Me.dataPersonas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.dataPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataPersonas.Location = New System.Drawing.Point(8, 160)
            Me.dataPersonas.Name = "dataPersonas"
            Me.dataPersonas.ReadOnly = True
            Me.dataPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dataPersonas.Size = New System.Drawing.Size(453, 311)
            Me.dataPersonas.TabIndex = 15
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.btnTrabajadorCLS)
            Me.Panel3.Controls.Add(Me.btnTrabajador)
            Me.Panel3.Controls.Add(Me.Label7)
            Me.Panel3.Controls.Add(Me.txtTrabajador)
            Me.Panel3.Controls.Add(Me.btnBuscar)
            Me.Panel3.Controls.Add(Me.btnTipoTrabLimpiar)
            Me.Panel3.Controls.Add(Me.btnTipoTrabaBuscar)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Controls.Add(Me.txtTipoTrabajador)
            Me.Panel3.Controls.Add(Me.btnLimpiarRegimen)
            Me.Panel3.Controls.Add(Me.btnBucarRegimen)
            Me.Panel3.Controls.Add(Me.txtRegimen)
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Location = New System.Drawing.Point(7, 3)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(454, 151)
            Me.Panel3.TabIndex = 14
            '
            'btnTrabajadorCLS
            '
            Me.btnTrabajadorCLS.Location = New System.Drawing.Point(345, 56)
            Me.btnTrabajadorCLS.Name = "btnTrabajadorCLS"
            Me.btnTrabajadorCLS.Size = New System.Drawing.Size(30, 23)
            Me.btnTrabajadorCLS.TabIndex = 13
            Me.btnTrabajadorCLS.Text = "cls"
            Me.btnTrabajadorCLS.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(315, 56)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(30, 23)
            Me.btnTrabajador.TabIndex = 12
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(37, 61)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(46, 13)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Persona"
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(89, 58)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(220, 20)
            Me.txtTrabajador.TabIndex = 10
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(317, 123)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 9
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'btnTipoTrabLimpiar
            '
            Me.btnTipoTrabLimpiar.Location = New System.Drawing.Point(345, 33)
            Me.btnTipoTrabLimpiar.Name = "btnTipoTrabLimpiar"
            Me.btnTipoTrabLimpiar.Size = New System.Drawing.Size(30, 23)
            Me.btnTipoTrabLimpiar.TabIndex = 8
            Me.btnTipoTrabLimpiar.Text = "cls"
            Me.btnTipoTrabLimpiar.UseVisualStyleBackColor = True
            '
            'btnTipoTrabaBuscar
            '
            Me.btnTipoTrabaBuscar.Location = New System.Drawing.Point(315, 33)
            Me.btnTipoTrabaBuscar.Name = "btnTipoTrabaBuscar"
            Me.btnTipoTrabaBuscar.Size = New System.Drawing.Size(30, 23)
            Me.btnTipoTrabaBuscar.TabIndex = 7
            Me.btnTipoTrabaBuscar.Text = ":::"
            Me.btnTipoTrabaBuscar.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(7, 38)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(76, 13)
            Me.Label5.TabIndex = 5
            Me.Label5.Text = "Tipo Trabajaro"
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(89, 35)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(220, 20)
            Me.txtTipoTrabajador.TabIndex = 4
            '
            'btnLimpiarRegimen
            '
            Me.btnLimpiarRegimen.Location = New System.Drawing.Point(345, 10)
            Me.btnLimpiarRegimen.Name = "btnLimpiarRegimen"
            Me.btnLimpiarRegimen.Size = New System.Drawing.Size(30, 23)
            Me.btnLimpiarRegimen.TabIndex = 3
            Me.btnLimpiarRegimen.Text = "cls"
            Me.btnLimpiarRegimen.UseVisualStyleBackColor = True
            '
            'btnBucarRegimen
            '
            Me.btnBucarRegimen.Location = New System.Drawing.Point(315, 10)
            Me.btnBucarRegimen.Name = "btnBucarRegimen"
            Me.btnBucarRegimen.Size = New System.Drawing.Size(30, 23)
            Me.btnBucarRegimen.TabIndex = 2
            Me.btnBucarRegimen.Text = ":::"
            Me.btnBucarRegimen.UseVisualStyleBackColor = True
            '
            'txtRegimen
            '
            Me.txtRegimen.Location = New System.Drawing.Point(89, 13)
            Me.txtRegimen.Name = "txtRegimen"
            Me.txtRegimen.ReadOnly = True
            Me.txtRegimen.Size = New System.Drawing.Size(220, 20)
            Me.txtRegimen.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(34, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(49, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Regimen"
            '
            'dataRegimen
            '
            Me.dataRegimen.AllowUserToAddRows = False
            Me.dataRegimen.AllowUserToDeleteRows = False
            Me.dataRegimen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dataRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataRegimen.Location = New System.Drawing.Point(463, 160)
            Me.dataRegimen.Name = "dataRegimen"
            Me.dataRegimen.ReadOnly = True
            Me.dataRegimen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dataRegimen.Size = New System.Drawing.Size(332, 307)
            Me.dataRegimen.TabIndex = 13
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.txtPersona)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.btnConceptoBuscar)
            Me.Panel2.Controls.Add(Me.chkEsPorcentaje)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtImporte)
            Me.Panel2.Controls.Add(Me.txtTipoConcepto)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.txtConcepto)
            Me.Panel2.Location = New System.Drawing.Point(464, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(331, 151)
            Me.Panel2.TabIndex = 12
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(57, 8)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(255, 20)
            Me.txtPersona.TabIndex = 19
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(7, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(46, 13)
            Me.Label6.TabIndex = 18
            Me.Label6.Text = "Persona"
            '
            'btnConceptoBuscar
            '
            Me.btnConceptoBuscar.Location = New System.Drawing.Point(243, 49)
            Me.btnConceptoBuscar.Name = "btnConceptoBuscar"
            Me.btnConceptoBuscar.Size = New System.Drawing.Size(24, 23)
            Me.btnConceptoBuscar.TabIndex = 13
            Me.btnConceptoBuscar.Text = ":::"
            Me.btnConceptoBuscar.UseVisualStyleBackColor = True
            '
            'chkEsPorcentaje
            '
            Me.chkEsPorcentaje.AutoSize = True
            Me.chkEsPorcentaje.Checked = True
            Me.chkEsPorcentaje.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkEsPorcentaje.Enabled = False
            Me.chkEsPorcentaje.Location = New System.Drawing.Point(57, 98)
            Me.chkEsPorcentaje.Name = "chkEsPorcentaje"
            Me.chkEsPorcentaje.Size = New System.Drawing.Size(92, 17)
            Me.chkEsPorcentaje.TabIndex = 12
            Me.chkEsPorcentaje.Text = "Es Porcentaje"
            Me.chkEsPorcentaje.UseVisualStyleBackColor = True
            Me.chkEsPorcentaje.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(25, 30)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(28, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Tipo"
            '
            'txtImporte
            '
            Me.txtImporte.Location = New System.Drawing.Point(57, 73)
            Me.txtImporte.MaxLength = 15
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.Size = New System.Drawing.Size(100, 20)
            Me.txtImporte.TabIndex = 11
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(57, 30)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(61, 20)
            Me.txtTipoConcepto.TabIndex = 7
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(11, 77)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(42, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Importe"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(0, 54)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(53, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(57, 52)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(180, 20)
            Me.txtConcepto.TabIndex = 9
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmConceptosTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(809, 546)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmConceptosTrabajador"
            Me.Text = "frmConceptosTrabajador"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dataPersonas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.dataRegimen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtImporte As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents dataPersonas As System.Windows.Forms.DataGridView
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents dataRegimen As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnTipoTrabaBuscar As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents btnLimpiarRegimen As System.Windows.Forms.Button
        Friend WithEvents btnBucarRegimen As System.Windows.Forms.Button
        Friend WithEvents txtRegimen As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnConceptoBuscar As System.Windows.Forms.Button
        Friend WithEvents chkEsPorcentaje As System.Windows.Forms.CheckBox
        Friend WithEvents btnTipoTrabLimpiar As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents btnTrabajadorCLS As System.Windows.Forms.Button
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
    End Class


End Namespace
