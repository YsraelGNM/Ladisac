
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPrestamosTrabajador
        ' Inherits System.Windows.Forms.Form
        Inherits ViewManMasterPlanillas

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
            Me.btnMoneda = New System.Windows.Forms.Button()
            Me.txtMoneda = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.btnAgencia = New System.Windows.Forms.Button()
            Me.txtPuntoVenta = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtImporte = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnBeneficiario = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtAutoriza = New System.Windows.Forms.TextBox()
            Me.dateFechaFin = New System.Windows.Forms.DateTimePicker()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tic_TipoConcep_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.con_Conceptos_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Conceptos = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(573, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.btnMoneda)
            Me.Panel1.Controls.Add(Me.txtMoneda)
            Me.Panel1.Controls.Add(Me.Label18)
            Me.Panel1.Controls.Add(Me.btnAgencia)
            Me.Panel1.Controls.Add(Me.txtPuntoVenta)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Controls.Add(Me.txtImporte)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.btnBeneficiario)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.btnSerie)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.txtObservaciones)
            Me.Panel1.Controls.Add(Me.txtSerie)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtNumero)
            Me.Panel1.Controls.Add(Me.txtAutoriza)
            Me.Panel1.Controls.Add(Me.dateFechaFin)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.chkActivo)
            Me.Panel1.Location = New System.Drawing.Point(5, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(565, 327)
            Me.Panel1.TabIndex = 121
            '
            'btnMoneda
            '
            Me.btnMoneda.Location = New System.Drawing.Point(502, 78)
            Me.btnMoneda.Name = "btnMoneda"
            Me.btnMoneda.Size = New System.Drawing.Size(24, 23)
            Me.btnMoneda.TabIndex = 132
            Me.btnMoneda.Text = ":::"
            Me.btnMoneda.UseVisualStyleBackColor = True
            '
            'txtMoneda
            '
            Me.txtMoneda.Location = New System.Drawing.Point(421, 76)
            Me.txtMoneda.Name = "txtMoneda"
            Me.txtMoneda.ReadOnly = True
            Me.txtMoneda.Size = New System.Drawing.Size(76, 20)
            Me.txtMoneda.TabIndex = 131
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(369, 79)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(46, 13)
            Me.Label18.TabIndex = 130
            Me.Label18.Text = "Moneda"
            '
            'btnAgencia
            '
            Me.btnAgencia.Location = New System.Drawing.Point(321, 76)
            Me.btnAgencia.Name = "btnAgencia"
            Me.btnAgencia.Size = New System.Drawing.Size(28, 23)
            Me.btnAgencia.TabIndex = 129
            Me.btnAgencia.Text = ":::"
            Me.btnAgencia.UseVisualStyleBackColor = True
            '
            'txtPuntoVenta
            '
            Me.txtPuntoVenta.Location = New System.Drawing.Point(98, 76)
            Me.txtPuntoVenta.Name = "txtPuntoVenta"
            Me.txtPuntoVenta.ReadOnly = True
            Me.txtPuntoVenta.Size = New System.Drawing.Size(217, 20)
            Me.txtPuntoVenta.TabIndex = 128
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(25, 79)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(71, 13)
            Me.Label8.TabIndex = 127
            Me.Label8.Text = "Dependencia"
            '
            'txtImporte
            '
            Me.txtImporte.Location = New System.Drawing.Point(421, 125)
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.ReadOnly = True
            Me.txtImporte.Size = New System.Drawing.Size(105, 20)
            Me.txtImporte.TabIndex = 126
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(373, 132)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(42, 13)
            Me.Label6.TabIndex = 125
            Me.Label6.Text = "Importe"
            '
            'btnBeneficiario
            '
            Me.btnBeneficiario.Location = New System.Drawing.Point(502, 53)
            Me.btnBeneficiario.Name = "btnBeneficiario"
            Me.btnBeneficiario.Size = New System.Drawing.Size(24, 23)
            Me.btnBeneficiario.TabIndex = 124
            Me.btnBeneficiario.Text = ":::"
            Me.btnBeneficiario.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(502, 30)
            Me.btnTrabajador.Name = "btnTrabajador"
            Me.btnTrabajador.Size = New System.Drawing.Size(24, 23)
            Me.btnTrabajador.TabIndex = 123
            Me.btnTrabajador.Text = ":::"
            Me.btnTrabajador.UseVisualStyleBackColor = True
            '
            'btnSerie
            '
            Me.btnSerie.Location = New System.Drawing.Point(135, 8)
            Me.btnSerie.Name = "btnSerie"
            Me.btnSerie.Size = New System.Drawing.Size(27, 23)
            Me.btnSerie.TabIndex = 122
            Me.btnSerie.Text = ":::"
            Me.btnSerie.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(23, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(73, 13)
            Me.Label1.TabIndex = 108
            Me.Label1.Text = "Serie/Numero"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(18, 103)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(78, 13)
            Me.Label5.TabIndex = 119
            Me.Label5.Text = "Observaciones"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.Item, Me.tic_TipoConcep_Id, Me.con_Conceptos_Id, Me.Conceptos, Me.Importe, Me.Vencimiento})
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 166)
            Me.dgvDetalle.MultiSelect = False
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(543, 150)
            Me.dgvDetalle.TabIndex = 107
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(98, 100)
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(248, 45)
            Me.txtObservaciones.TabIndex = 118
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(98, 10)
            Me.txtSerie.MaxLength = 3
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(35, 20)
            Me.txtSerie.TabIndex = 109
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(51, 57)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(45, 13)
            Me.Label4.TabIndex = 117
            Me.Label4.Text = "Autoriza"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(166, 10)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 110
            '
            'txtAutoriza
            '
            Me.txtAutoriza.Location = New System.Drawing.Point(98, 54)
            Me.txtAutoriza.Name = "txtAutoriza"
            Me.txtAutoriza.ReadOnly = True
            Me.txtAutoriza.Size = New System.Drawing.Size(399, 20)
            Me.txtAutoriza.TabIndex = 116
            '
            'dateFechaFin
            '
            Me.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaFin.Location = New System.Drawing.Point(331, 6)
            Me.dateFechaFin.Name = "dateFechaFin"
            Me.dateFechaFin.Size = New System.Drawing.Size(87, 20)
            Me.dateFechaFin.TabIndex = 111
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(98, 32)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.ReadOnly = True
            Me.txtTrabajador.Size = New System.Drawing.Size(399, 20)
            Me.txtTrabajador.TabIndex = 115
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(288, 9)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 112
            Me.Label2.Text = "Fecha"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(38, 35)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(58, 13)
            Me.Label3.TabIndex = 114
            Me.Label3.Text = "Trabajador"
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(470, 9)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(56, 17)
            Me.chkActivo.TabIndex = 113
            Me.chkActivo.Text = "Activo"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.Visible = False
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            Me.Item.Visible = False
            '
            'tic_TipoConcep_Id
            '
            Me.tic_TipoConcep_Id.HeaderText = "tic_TipoConcep_Id"
            Me.tic_TipoConcep_Id.Name = "tic_TipoConcep_Id"
            Me.tic_TipoConcep_Id.Visible = False
            '
            'con_Conceptos_Id
            '
            Me.con_Conceptos_Id.HeaderText = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Name = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Visible = False
            '
            'Conceptos
            '
            Me.Conceptos.HeaderText = "Conceptos"
            Me.Conceptos.Name = "Conceptos"
            '
            'Importe
            '
            Me.Importe.HeaderText = "Importe"
            Me.Importe.Name = "Importe"
            '
            'Vencimiento
            '
            Me.Vencimiento.HeaderText = "Vencimiento"
            Me.Vencimiento.Name = "Vencimiento"
            '
            'frmPrestamosTrabajador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(573, 387)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmPrestamosTrabajador"
            Me.Text = "frmPrestamosTrabajador"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnBeneficiario As System.Windows.Forms.Button
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtAutoriza As System.Windows.Forms.TextBox
        Friend WithEvents dateFechaFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtImporte As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnAgencia As System.Windows.Forms.Button
        Friend WithEvents txtPuntoVenta As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnMoneda As System.Windows.Forms.Button
        Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tic_TipoConcep_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents con_Conceptos_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Conceptos As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn '.DataGridViewComboBoxColumn
    End Class
End Namespace
