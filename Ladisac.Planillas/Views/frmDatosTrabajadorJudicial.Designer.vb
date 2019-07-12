
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDatosTrabajadorJudicial
        Inherits ViewManMasterPlanillas

        'Inherits System.Windows.Forms.Form

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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tip_TipoPlan_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Planilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dtj_idTiposConceptos = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.con_Conceptos_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Conceptos = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EsPorcentaje = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.dateFechaFin = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTrabajador = New System.Windows.Forms.TextBox()
            Me.txtBeneficiario = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnBeneficiario = New System.Windows.Forms.Button()
            Me.btnTrabajador = New System.Windows.Forms.Button()
            Me.btnSerie = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.dateFechaInicio = New System.Windows.Forms.DateTimePicker()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(574, 28)
            Me.lblTitle.Text = "Datos Judiciales"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.tip_TipoPlan_Id, Me.Planilla, Me.dtj_idTiposConceptos, Me.con_Conceptos_Id, Me.Conceptos, Me.Importe, Me.EsPorcentaje})
            Me.dgvDetalle.Location = New System.Drawing.Point(19, 141)
            Me.dgvDetalle.MultiSelect = False
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(528, 214)
            Me.dgvDetalle.TabIndex = 107
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            '
            'tip_TipoPlan_Id
            '
            Me.tip_TipoPlan_Id.HeaderText = "tip_TipoPlan_Id"
            Me.tip_TipoPlan_Id.Name = "tip_TipoPlan_Id"
            '
            'Planilla
            '
            Me.Planilla.HeaderText = "Planilla"
            Me.Planilla.Name = "Planilla"
            '
            'dtj_idTiposConceptos
            '
            Me.dtj_idTiposConceptos.HeaderText = "dtj_idTiposConceptos"
            Me.dtj_idTiposConceptos.Name = "dtj_idTiposConceptos"
            '
            'con_Conceptos_Id
            '
            Me.con_Conceptos_Id.HeaderText = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Name = "con_Conceptos_Id"
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
            'EsPorcentaje
            '
            Me.EsPorcentaje.HeaderText = "EsPorcentaje"
            Me.EsPorcentaje.Name = "EsPorcentaje"
            Me.EsPorcentaje.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.EsPorcentaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(16, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(73, 13)
            Me.Label1.TabIndex = 108
            Me.Label1.Text = "Serie/Numero"
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(98, 10)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(35, 20)
            Me.txtSerie.TabIndex = 109
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(166, 10)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(87, 20)
            Me.txtNumero.TabIndex = 110
            '
            'dateFechaFin
            '
            Me.dateFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaFin.Location = New System.Drawing.Point(425, 9)
            Me.dateFechaFin.Name = "dateFechaFin"
            Me.dateFechaFin.Size = New System.Drawing.Size(87, 20)
            Me.dateFechaFin.TabIndex = 111
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(382, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(42, 13)
            Me.Label2.TabIndex = 112
            Me.Label2.Text = "Finaliza"
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(432, 105)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(56, 17)
            Me.chkActivo.TabIndex = 113
            Me.chkActivo.Text = "Activo"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(16, 35)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(58, 13)
            Me.Label3.TabIndex = 114
            Me.Label3.Text = "Trabajador"
            '
            'txtTrabajador
            '
            Me.txtTrabajador.Location = New System.Drawing.Point(98, 32)
            Me.txtTrabajador.Name = "txtTrabajador"
            Me.txtTrabajador.Size = New System.Drawing.Size(414, 20)
            Me.txtTrabajador.TabIndex = 115
            '
            'txtBeneficiario
            '
            Me.txtBeneficiario.Location = New System.Drawing.Point(98, 54)
            Me.txtBeneficiario.Name = "txtBeneficiario"
            Me.txtBeneficiario.Size = New System.Drawing.Size(414, 20)
            Me.txtBeneficiario.TabIndex = 116
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(16, 57)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(62, 13)
            Me.Label4.TabIndex = 117
            Me.Label4.Text = "Beneficiario"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(98, 77)
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(310, 45)
            Me.txtObservaciones.TabIndex = 118
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(16, 80)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(78, 13)
            Me.Label5.TabIndex = 119
            Me.Label5.Text = "Observaciones"
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.btnBeneficiario)
            Me.Panel1.Controls.Add(Me.btnTrabajador)
            Me.Panel1.Controls.Add(Me.btnSerie)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.dateFechaInicio)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.txtObservaciones)
            Me.Panel1.Controls.Add(Me.txtSerie)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtNumero)
            Me.Panel1.Controls.Add(Me.txtBeneficiario)
            Me.Panel1.Controls.Add(Me.dateFechaFin)
            Me.Panel1.Controls.Add(Me.txtTrabajador)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.chkActivo)
            Me.Panel1.Location = New System.Drawing.Point(4, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(565, 360)
            Me.Panel1.TabIndex = 120
            '
            'btnBeneficiario
            '
            Me.btnBeneficiario.Location = New System.Drawing.Point(523, 53)
            Me.btnBeneficiario.Name = "btnBeneficiario"
            Me.btnBeneficiario.Size = New System.Drawing.Size(24, 23)
            Me.btnBeneficiario.TabIndex = 124
            Me.btnBeneficiario.Text = ":::"
            Me.btnBeneficiario.UseVisualStyleBackColor = True
            '
            'btnTrabajador
            '
            Me.btnTrabajador.Location = New System.Drawing.Point(523, 30)
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
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(259, 12)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(32, 13)
            Me.Label6.TabIndex = 121
            Me.Label6.Text = "Inicia"
            '
            'dateFechaInicio
            '
            Me.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaInicio.Location = New System.Drawing.Point(297, 9)
            Me.dateFechaInicio.Name = "dateFechaInicio"
            Me.dateFechaInicio.Size = New System.Drawing.Size(84, 20)
            Me.dateFechaInicio.TabIndex = 120
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDatosTrabajadorJudicial
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(574, 428)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmDatosTrabajadorJudicial"
            Me.Text = "Datos Judiciales"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents dateFechaFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dateFechaInicio As System.Windows.Forms.DateTimePicker
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btnSerie As System.Windows.Forms.Button
        Friend WithEvents btnBeneficiario As System.Windows.Forms.Button
        Friend WithEvents btnTrabajador As System.Windows.Forms.Button
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tip_TipoPlan_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Planilla As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dtj_idTiposConceptos As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents con_Conceptos_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Conceptos As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EsPorcentaje As System.Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace