Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCuentasPlanillas
        Inherits ViewManMasterContabilidad 'System.Windows.Forms.Form

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
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.btnTipoTrabaBuscar = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPlanilla = New System.Windows.Forms.TextBox()
            Me.txtTipoPlanilla = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dataRegimen = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btngasto = New System.Windows.Forms.Button()
            Me.btnPasivo = New System.Windows.Forms.Button()
            Me.txtGasto = New System.Windows.Forms.TextBox()
            Me.txtPasivo = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtItem = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnLImpiarPasivo = New System.Windows.Forms.Button()
            Me.btnLimpiarGasto = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.dataRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(695, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.dataRegimen)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 59)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(687, 458)
            Me.Panel1.TabIndex = 5
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.Label7)
            Me.Panel3.Controls.Add(Me.txtTipoTrabajador)
            Me.Panel3.Controls.Add(Me.btnBuscar)
            Me.Panel3.Controls.Add(Me.btnTipoTrabaBuscar)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Controls.Add(Me.txtPlanilla)
            Me.Panel3.Controls.Add(Me.txtTipoPlanilla)
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Location = New System.Drawing.Point(7, 2)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(674, 73)
            Me.Panel3.TabIndex = 14
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(291, 16)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(76, 13)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Tipo Trabajaro"
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(373, 13)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(185, 20)
            Me.txtTipoTrabajador.TabIndex = 10
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(584, 39)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 9
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'btnTipoTrabaBuscar
            '
            Me.btnTipoTrabaBuscar.Location = New System.Drawing.Point(285, 37)
            Me.btnTipoTrabaBuscar.Name = "btnTipoTrabaBuscar"
            Me.btnTipoTrabaBuscar.Size = New System.Drawing.Size(30, 23)
            Me.btnTipoTrabaBuscar.TabIndex = 7
            Me.btnTipoTrabaBuscar.Text = ":::"
            Me.btnTipoTrabaBuscar.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(52, 42)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(40, 13)
            Me.Label5.TabIndex = 5
            Me.Label5.Text = "Planilla"
            '
            'txtPlanilla
            '
            Me.txtPlanilla.Location = New System.Drawing.Point(98, 39)
            Me.txtPlanilla.Name = "txtPlanilla"
            Me.txtPlanilla.ReadOnly = True
            Me.txtPlanilla.Size = New System.Drawing.Size(185, 20)
            Me.txtPlanilla.TabIndex = 4
            '
            'txtTipoPlanilla
            '
            Me.txtTipoPlanilla.Location = New System.Drawing.Point(98, 13)
            Me.txtTipoPlanilla.Name = "txtTipoPlanilla"
            Me.txtTipoPlanilla.ReadOnly = True
            Me.txtTipoPlanilla.Size = New System.Drawing.Size(185, 20)
            Me.txtTipoPlanilla.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(14, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(78, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Tipo de planilla"
            '
            'dataRegimen
            '
            Me.dataRegimen.AllowUserToAddRows = False
            Me.dataRegimen.AllowUserToDeleteRows = False
            Me.dataRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataRegimen.Location = New System.Drawing.Point(7, 192)
            Me.dataRegimen.Name = "dataRegimen"
            Me.dataRegimen.ReadOnly = True
            Me.dataRegimen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dataRegimen.Size = New System.Drawing.Size(674, 259)
            Me.dataRegimen.TabIndex = 13
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnLimpiarGasto)
            Me.Panel2.Controls.Add(Me.btnLImpiarPasivo)
            Me.Panel2.Controls.Add(Me.btngasto)
            Me.Panel2.Controls.Add(Me.btnPasivo)
            Me.Panel2.Controls.Add(Me.txtGasto)
            Me.Panel2.Controls.Add(Me.txtPasivo)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.txtItem)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtTipoConcepto)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.txtConcepto)
            Me.Panel2.Location = New System.Drawing.Point(7, 78)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(674, 108)
            Me.Panel2.TabIndex = 12
            '
            'btngasto
            '
            Me.btngasto.Location = New System.Drawing.Point(205, 73)
            Me.btngasto.Name = "btngasto"
            Me.btngasto.Size = New System.Drawing.Size(28, 23)
            Me.btngasto.TabIndex = 31
            Me.btngasto.Text = ":::"
            Me.btngasto.UseVisualStyleBackColor = True
            '
            'btnPasivo
            '
            Me.btnPasivo.Location = New System.Drawing.Point(204, 50)
            Me.btnPasivo.Name = "btnPasivo"
            Me.btnPasivo.Size = New System.Drawing.Size(30, 23)
            Me.btnPasivo.TabIndex = 30
            Me.btnPasivo.Text = ":::"
            Me.btnPasivo.UseVisualStyleBackColor = True
            '
            'txtGasto
            '
            Me.txtGasto.Location = New System.Drawing.Point(98, 75)
            Me.txtGasto.Name = "txtGasto"
            Me.txtGasto.ReadOnly = True
            Me.txtGasto.Size = New System.Drawing.Size(100, 20)
            Me.txtGasto.TabIndex = 29
            '
            'txtPasivo
            '
            Me.txtPasivo.Location = New System.Drawing.Point(98, 52)
            Me.txtPasivo.Name = "txtPasivo"
            Me.txtPasivo.ReadOnly = True
            Me.txtPasivo.Size = New System.Drawing.Size(100, 20)
            Me.txtPasivo.TabIndex = 28
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(219, 6)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(16, 13)
            Me.Label3.TabIndex = 27
            Me.Label3.Text = "Id"
            '
            'txtItem
            '
            Me.txtItem.Location = New System.Drawing.Point(241, 3)
            Me.txtItem.Name = "txtItem"
            Me.txtItem.ReadOnly = True
            Me.txtItem.Size = New System.Drawing.Size(41, 20)
            Me.txtItem.TabIndex = 26
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(17, 56)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(76, 13)
            Me.Label10.TabIndex = 24
            Me.Label10.Text = "Cuenta Pasivo"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(21, 80)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(72, 13)
            Me.Label6.TabIndex = 15
            Me.Label6.Text = "Cuenta Gasto"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(65, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(28, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Tipo"
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(98, 7)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(61, 20)
            Me.txtTipoConcepto.TabIndex = 7
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(40, 31)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(53, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(98, 29)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(185, 20)
            Me.txtConcepto.TabIndex = 9
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnLImpiarPasivo
            '
            Me.btnLImpiarPasivo.Location = New System.Drawing.Point(241, 50)
            Me.btnLImpiarPasivo.Name = "btnLImpiarPasivo"
            Me.btnLImpiarPasivo.Size = New System.Drawing.Size(75, 23)
            Me.btnLImpiarPasivo.TabIndex = 32
            Me.btnLImpiarPasivo.Text = "Limpiar"
            Me.btnLImpiarPasivo.UseVisualStyleBackColor = True
            '
            'btnLimpiarGasto
            '
            Me.btnLimpiarGasto.Location = New System.Drawing.Point(241, 75)
            Me.btnLimpiarGasto.Name = "btnLimpiarGasto"
            Me.btnLimpiarGasto.Size = New System.Drawing.Size(75, 23)
            Me.btnLimpiarGasto.TabIndex = 33
            Me.btnLimpiarGasto.Text = "Limpiar"
            Me.btnLimpiarGasto.UseVisualStyleBackColor = True
            '
            'frmCuentasPlanillas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(695, 520)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCuentasPlanillas"
            Me.Text = "frmCuentasPlanillas"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
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
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents btnTipoTrabaBuscar As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents txtTipoPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dataRegimen As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtItem As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents btngasto As System.Windows.Forms.Button
        Friend WithEvents btnPasivo As System.Windows.Forms.Button
        Friend WithEvents txtGasto As System.Windows.Forms.TextBox
        Friend WithEvents txtPasivo As System.Windows.Forms.TextBox
        Friend WithEvents btnLimpiarGasto As System.Windows.Forms.Button
        Friend WithEvents btnLImpiarPasivo As System.Windows.Forms.Button
    End Class
End Namespace