Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConceptosPlanilla
        Inherits ViewManMasterPlanillas
        '        Inherits System.Windows.Forms.Form

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
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboTipoTareo = New System.Windows.Forms.ComboBox()
            Me.btnPeriodisidadCls = New System.Windows.Forms.Button()
            Me.btnPeriodisidadAdd = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPeriodisidad = New System.Windows.Forms.TextBox()
            Me.btnTipoPlanilla = New System.Windows.Forms.Button()
            Me.txtTipoPlanilla = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnTipoTrabajador = New System.Windows.Forms.Button()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.chkEsPDT = New System.Windows.Forms.CheckBox()
            Me.txtDescripcion = New System.Windows.Forms.TextBox()
            Me.Label05 = New System.Windows.Forms.Label()
            Me.txtItem = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(447, 28)
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.chkActivo)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.cboTipoTareo)
            Me.Panel1.Controls.Add(Me.btnPeriodisidadCls)
            Me.Panel1.Controls.Add(Me.btnPeriodisidadAdd)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.txtPeriodisidad)
            Me.Panel1.Controls.Add(Me.btnTipoPlanilla)
            Me.Panel1.Controls.Add(Me.txtTipoPlanilla)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnTipoTrabajador)
            Me.Panel1.Controls.Add(Me.txtTipoTrabajador)
            Me.Panel1.Controls.Add(Me.chkEsPDT)
            Me.Panel1.Controls.Add(Me.txtDescripcion)
            Me.Panel1.Controls.Add(Me.Label05)
            Me.Panel1.Controls.Add(Me.txtItem)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 59)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(431, 199)
            Me.Panel1.TabIndex = 3
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(131, 174)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(157, 17)
            Me.chkActivo.TabIndex = 23
            Me.chkActivo.Text = "No mostrar para Busquedas"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(65, 110)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(59, 13)
            Me.Label6.TabIndex = 22
            Me.Label6.Text = "Tipo Tareo"
            '
            'cboTipoTareo
            '
            Me.cboTipoTareo.FormattingEnabled = True
            Me.cboTipoTareo.Location = New System.Drawing.Point(131, 107)
            Me.cboTipoTareo.Name = "cboTipoTareo"
            Me.cboTipoTareo.Size = New System.Drawing.Size(191, 21)
            Me.cboTipoTareo.TabIndex = 21
            '
            'btnPeriodisidadCls
            '
            Me.btnPeriodisidadCls.Location = New System.Drawing.Point(365, 83)
            Me.btnPeriodisidadCls.Name = "btnPeriodisidadCls"
            Me.btnPeriodisidadCls.Size = New System.Drawing.Size(42, 23)
            Me.btnPeriodisidadCls.TabIndex = 20
            Me.btnPeriodisidadCls.Text = "Borrar"
            Me.btnPeriodisidadCls.UseVisualStyleBackColor = True
            '
            'btnPeriodisidadAdd
            '
            Me.btnPeriodisidadAdd.Location = New System.Drawing.Point(328, 83)
            Me.btnPeriodisidadAdd.Name = "btnPeriodisidadAdd"
            Me.btnPeriodisidadAdd.Size = New System.Drawing.Size(31, 23)
            Me.btnPeriodisidadAdd.TabIndex = 19
            Me.btnPeriodisidadAdd.Text = ":::"
            Me.btnPeriodisidadAdd.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(60, 88)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(64, 13)
            Me.Label5.TabIndex = 18
            Me.Label5.Text = "Periodisidad"
            '
            'txtPeriodisidad
            '
            Me.txtPeriodisidad.Location = New System.Drawing.Point(131, 84)
            Me.txtPeriodisidad.Name = "txtPeriodisidad"
            Me.txtPeriodisidad.ReadOnly = True
            Me.txtPeriodisidad.Size = New System.Drawing.Size(191, 20)
            Me.txtPeriodisidad.TabIndex = 17
            '
            'btnTipoPlanilla
            '
            Me.btnTipoPlanilla.Location = New System.Drawing.Point(328, 12)
            Me.btnTipoPlanilla.Name = "btnTipoPlanilla"
            Me.btnTipoPlanilla.Size = New System.Drawing.Size(31, 23)
            Me.btnTipoPlanilla.TabIndex = 16
            Me.btnTipoPlanilla.Text = ":::"
            Me.btnTipoPlanilla.UseVisualStyleBackColor = True
            '
            'txtTipoPlanilla
            '
            Me.txtTipoPlanilla.Location = New System.Drawing.Point(131, 15)
            Me.txtTipoPlanilla.Name = "txtTipoPlanilla"
            Me.txtTipoPlanilla.ReadOnly = True
            Me.txtTipoPlanilla.Size = New System.Drawing.Size(191, 20)
            Me.txtTipoPlanilla.TabIndex = 15
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(60, 18)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 13)
            Me.Label4.TabIndex = 14
            Me.Label4.Text = "Tipo Planilla"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(42, 41)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(82, 13)
            Me.Label3.TabIndex = 13
            Me.Label3.Text = "Tipo Trabajador"
            '
            'btnTipoTrabajador
            '
            Me.btnTipoTrabajador.Location = New System.Drawing.Point(328, 38)
            Me.btnTipoTrabajador.Name = "btnTipoTrabajador"
            Me.btnTipoTrabajador.Size = New System.Drawing.Size(31, 23)
            Me.btnTipoTrabajador.TabIndex = 12
            Me.btnTipoTrabajador.Text = ":::"
            Me.btnTipoTrabajador.UseVisualStyleBackColor = True
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(131, 38)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(191, 20)
            Me.txtTipoTrabajador.TabIndex = 11
            '
            'chkEsPDT
            '
            Me.chkEsPDT.AutoSize = True
            Me.chkEsPDT.Location = New System.Drawing.Point(131, 154)
            Me.chkEsPDT.Name = "chkEsPDT"
            Me.chkEsPDT.Size = New System.Drawing.Size(98, 17)
            Me.chkEsPDT.TabIndex = 10
            Me.chkEsPDT.Text = "Es para el PDT"
            Me.chkEsPDT.UseVisualStyleBackColor = True
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(131, 131)
            Me.txtDescripcion.MaxLength = 45
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Size = New System.Drawing.Size(265, 20)
            Me.txtDescripcion.TabIndex = 9
            '
            'Label05
            '
            Me.Label05.AutoSize = True
            Me.Label05.Location = New System.Drawing.Point(84, 134)
            Me.Label05.Name = "Label05"
            Me.Label05.Size = New System.Drawing.Size(40, 13)
            Me.Label05.TabIndex = 8
            Me.Label05.Text = "Planilla"
            '
            'txtItem
            '
            Me.txtItem.Location = New System.Drawing.Point(131, 61)
            Me.txtItem.Name = "txtItem"
            Me.txtItem.ReadOnly = True
            Me.txtItem.Size = New System.Drawing.Size(61, 20)
            Me.txtItem.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(97, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(27, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Item"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmConceptosPlanilla
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(447, 265)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmConceptosPlanilla"
            Me.Text = "frmConceptosPlanilla"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents Label05 As System.Windows.Forms.Label
        Friend WithEvents txtItem As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents chkEsPDT As System.Windows.Forms.CheckBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodisidad As System.Windows.Forms.TextBox
        Friend WithEvents btnTipoPlanilla As System.Windows.Forms.Button
        Friend WithEvents txtTipoPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnTipoTrabajador As System.Windows.Forms.Button
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cboTipoTareo As System.Windows.Forms.ComboBox
        Friend WithEvents btnPeriodisidadCls As System.Windows.Forms.Button
        Friend WithEvents btnPeriodisidadAdd As System.Windows.Forms.Button
    End Class
End Namespace