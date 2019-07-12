Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCartaFianza
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
            Me.lblCAF_IX_ORDEN_COM = New System.Windows.Forms.Label()
            Me.txtCAF_IX_ORDEN_COM = New System.Windows.Forms.TextBox()
            Me.lblCAF_FECHA_VEN = New System.Windows.Forms.Label()
            Me.dtpCAF_FECHA_VEN = New System.Windows.Forms.DateTimePicker()
            Me.lblCAF_OBSERVACIONES = New System.Windows.Forms.Label()
            Me.lblCAF_ESTADO = New System.Windows.Forms.Label()
            Me.lblCAF_FECHA_EMI = New System.Windows.Forms.Label()
            Me.lblCAF_IX_NUMERO_PRO = New System.Windows.Forms.Label()
            Me.lblCAF_DIAS_VEN = New System.Windows.Forms.Label()
            Me.lblCAF_NUMERO = New System.Windows.Forms.Label()
            Me.lblCAF_MONTO = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblMON_ID = New System.Windows.Forms.Label()
            Me.lbCAF_ESTADO_DOC = New System.Windows.Forms.Label()
            Me.lblCAF_TIPO_DOC = New System.Windows.Forms.Label()
            Me.lblCAF_ID = New System.Windows.Forms.Label()
            Me.dtpCAF_FECHA_EMI = New System.Windows.Forms.DateTimePicker()
            Me.chkCAF_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtCAF_IX_NUMERO_PRO = New System.Windows.Forms.TextBox()
            Me.txtCAF_OBSERVACIONES = New System.Windows.Forms.TextBox()
            Me.txtCAF_DIAS_VEN = New System.Windows.Forms.TextBox()
            Me.txtCAF_NUMERO = New System.Windows.Forms.TextBox()
            Me.txtCAF_MONTO = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMON_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtMON_ID = New System.Windows.Forms.TextBox()
            Me.cboCAF_ESTADO_DOC = New System.Windows.Forms.ComboBox()
            Me.cboCAF_TIPO_DOC = New System.Windows.Forms.ComboBox()
            Me.txtCAF_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(761, 28)
            Me.lblTitle.Text = "Carta fianza"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblCAF_IX_ORDEN_COM)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_IX_ORDEN_COM)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_FECHA_VEN)
            Me.pnCuerpo.Controls.Add(Me.dtpCAF_FECHA_VEN)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_OBSERVACIONES)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_IX_NUMERO_PRO)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_DIAS_VEN)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_MONTO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMON_ID)
            Me.pnCuerpo.Controls.Add(Me.lbCAF_ESTADO_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_TIPO_DOC)
            Me.pnCuerpo.Controls.Add(Me.lblCAF_ID)
            Me.pnCuerpo.Controls.Add(Me.dtpCAF_FECHA_EMI)
            Me.pnCuerpo.Controls.Add(Me.chkCAF_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_IX_NUMERO_PRO)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_OBSERVACIONES)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_DIAS_VEN)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_MONTO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMON_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMON_ID)
            Me.pnCuerpo.Controls.Add(Me.cboCAF_ESTADO_DOC)
            Me.pnCuerpo.Controls.Add(Me.cboCAF_TIPO_DOC)
            Me.pnCuerpo.Controls.Add(Me.txtCAF_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(29, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(697, 353)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblCAF_IX_ORDEN_COM
            '
            Me.lblCAF_IX_ORDEN_COM.AutoSize = True
            Me.lblCAF_IX_ORDEN_COM.Location = New System.Drawing.Point(11, 210)
            Me.lblCAF_IX_ORDEN_COM.Name = "lblCAF_IX_ORDEN_COM"
            Me.lblCAF_IX_ORDEN_COM.Size = New System.Drawing.Size(66, 13)
            Me.lblCAF_IX_ORDEN_COM.TabIndex = 45
            Me.lblCAF_IX_ORDEN_COM.Text = "Ord. Compra"
            '
            'txtCAF_IX_ORDEN_COM
            '
            Me.txtCAF_IX_ORDEN_COM.Location = New System.Drawing.Point(82, 210)
            Me.txtCAF_IX_ORDEN_COM.Name = "txtCAF_IX_ORDEN_COM"
            Me.txtCAF_IX_ORDEN_COM.Size = New System.Drawing.Size(115, 20)
            Me.txtCAF_IX_ORDEN_COM.TabIndex = 12
            '
            'lblCAF_FECHA_VEN
            '
            Me.lblCAF_FECHA_VEN.AutoSize = True
            Me.lblCAF_FECHA_VEN.Location = New System.Drawing.Point(254, 48)
            Me.lblCAF_FECHA_VEN.Name = "lblCAF_FECHA_VEN"
            Me.lblCAF_FECHA_VEN.Size = New System.Drawing.Size(71, 13)
            Me.lblCAF_FECHA_VEN.TabIndex = 43
            Me.lblCAF_FECHA_VEN.Text = "Fecha. Venc."
            '
            'dtpCAF_FECHA_VEN
            '
            Me.dtpCAF_FECHA_VEN.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpCAF_FECHA_VEN.Location = New System.Drawing.Point(348, 48)
            Me.dtpCAF_FECHA_VEN.Name = "dtpCAF_FECHA_VEN"
            Me.dtpCAF_FECHA_VEN.Size = New System.Drawing.Size(108, 20)
            Me.dtpCAF_FECHA_VEN.TabIndex = 3
            '
            'lblCAF_OBSERVACIONES
            '
            Me.lblCAF_OBSERVACIONES.AutoSize = True
            Me.lblCAF_OBSERVACIONES.Location = New System.Drawing.Point(11, 269)
            Me.lblCAF_OBSERVACIONES.Name = "lblCAF_OBSERVACIONES"
            Me.lblCAF_OBSERVACIONES.Size = New System.Drawing.Size(29, 13)
            Me.lblCAF_OBSERVACIONES.TabIndex = 40
            Me.lblCAF_OBSERVACIONES.Text = "Obs."
            '
            'lblCAF_ESTADO
            '
            Me.lblCAF_ESTADO.AutoSize = True
            Me.lblCAF_ESTADO.Location = New System.Drawing.Point(11, 326)
            Me.lblCAF_ESTADO.Name = "lblCAF_ESTADO"
            Me.lblCAF_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblCAF_ESTADO.TabIndex = 36
            Me.lblCAF_ESTADO.Text = "Estado"
            '
            'lblCAF_FECHA_EMI
            '
            Me.lblCAF_FECHA_EMI.AutoSize = True
            Me.lblCAF_FECHA_EMI.Location = New System.Drawing.Point(11, 48)
            Me.lblCAF_FECHA_EMI.Name = "lblCAF_FECHA_EMI"
            Me.lblCAF_FECHA_EMI.Size = New System.Drawing.Size(63, 13)
            Me.lblCAF_FECHA_EMI.TabIndex = 35
            Me.lblCAF_FECHA_EMI.Text = "Fecha. Emi."
            '
            'lblCAF_IX_NUMERO_PRO
            '
            Me.lblCAF_IX_NUMERO_PRO.AutoSize = True
            Me.lblCAF_IX_NUMERO_PRO.Location = New System.Drawing.Point(11, 184)
            Me.lblCAF_IX_NUMERO_PRO.Name = "lblCAF_IX_NUMERO_PRO"
            Me.lblCAF_IX_NUMERO_PRO.Size = New System.Drawing.Size(69, 13)
            Me.lblCAF_IX_NUMERO_PRO.TabIndex = 33
            Me.lblCAF_IX_NUMERO_PRO.Text = "Nro. Proceso"
            '
            'lblCAF_DIAS_VEN
            '
            Me.lblCAF_DIAS_VEN.AutoSize = True
            Me.lblCAF_DIAS_VEN.Location = New System.Drawing.Point(11, 74)
            Me.lblCAF_DIAS_VEN.Name = "lblCAF_DIAS_VEN"
            Me.lblCAF_DIAS_VEN.Size = New System.Drawing.Size(61, 13)
            Me.lblCAF_DIAS_VEN.TabIndex = 30
            Me.lblCAF_DIAS_VEN.Text = "Días Venc."
            '
            'lblCAF_NUMERO
            '
            Me.lblCAF_NUMERO.AutoSize = True
            Me.lblCAF_NUMERO.Location = New System.Drawing.Point(254, 74)
            Me.lblCAF_NUMERO.Name = "lblCAF_NUMERO"
            Me.lblCAF_NUMERO.Size = New System.Drawing.Size(44, 13)
            Me.lblCAF_NUMERO.TabIndex = 28
            Me.lblCAF_NUMERO.Text = "Número"
            '
            'lblCAF_MONTO
            '
            Me.lblCAF_MONTO.AutoSize = True
            Me.lblCAF_MONTO.Location = New System.Drawing.Point(11, 128)
            Me.lblCAF_MONTO.Name = "lblCAF_MONTO"
            Me.lblCAF_MONTO.Size = New System.Drawing.Size(37, 13)
            Me.lblCAF_MONTO.TabIndex = 27
            Me.lblCAF_MONTO.Text = "Monto"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(11, 157)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID.TabIndex = 26
            Me.lblPER_ID.Text = "Persona"
            '
            'lblMON_ID
            '
            Me.lblMON_ID.AutoSize = True
            Me.lblMON_ID.Location = New System.Drawing.Point(11, 100)
            Me.lblMON_ID.Name = "lblMON_ID"
            Me.lblMON_ID.Size = New System.Drawing.Size(46, 13)
            Me.lblMON_ID.TabIndex = 25
            Me.lblMON_ID.Text = "Moneda"
            '
            'lbCAF_ESTADO_DOC
            '
            Me.lbCAF_ESTADO_DOC.AutoSize = True
            Me.lbCAF_ESTADO_DOC.Location = New System.Drawing.Point(11, 240)
            Me.lbCAF_ESTADO_DOC.Name = "lbCAF_ESTADO_DOC"
            Me.lbCAF_ESTADO_DOC.Size = New System.Drawing.Size(51, 13)
            Me.lbCAF_ESTADO_DOC.TabIndex = 24
            Me.lbCAF_ESTADO_DOC.Text = "Est. Doc."
            '
            'lblCAF_TIPO_DOC
            '
            Me.lblCAF_TIPO_DOC.AutoSize = True
            Me.lblCAF_TIPO_DOC.Location = New System.Drawing.Point(254, 13)
            Me.lblCAF_TIPO_DOC.Name = "lblCAF_TIPO_DOC"
            Me.lblCAF_TIPO_DOC.Size = New System.Drawing.Size(28, 13)
            Me.lblCAF_TIPO_DOC.TabIndex = 23
            Me.lblCAF_TIPO_DOC.Text = "Tipo"
            '
            'lblCAF_ID
            '
            Me.lblCAF_ID.AutoSize = True
            Me.lblCAF_ID.Location = New System.Drawing.Point(11, 13)
            Me.lblCAF_ID.Name = "lblCAF_ID"
            Me.lblCAF_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblCAF_ID.TabIndex = 22
            Me.lblCAF_ID.Text = "Código"
            '
            'dtpCAF_FECHA_EMI
            '
            Me.dtpCAF_FECHA_EMI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpCAF_FECHA_EMI.Location = New System.Drawing.Point(82, 48)
            Me.dtpCAF_FECHA_EMI.Name = "dtpCAF_FECHA_EMI"
            Me.dtpCAF_FECHA_EMI.Size = New System.Drawing.Size(108, 20)
            Me.dtpCAF_FECHA_EMI.TabIndex = 2
            '
            'chkCAF_ESTADO
            '
            Me.chkCAF_ESTADO.AutoSize = True
            Me.chkCAF_ESTADO.Location = New System.Drawing.Point(82, 325)
            Me.chkCAF_ESTADO.Name = "chkCAF_ESTADO"
            Me.chkCAF_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkCAF_ESTADO.TabIndex = 15
            Me.chkCAF_ESTADO.UseVisualStyleBackColor = True
            '
            'txtCAF_IX_NUMERO_PRO
            '
            Me.txtCAF_IX_NUMERO_PRO.Location = New System.Drawing.Point(82, 184)
            Me.txtCAF_IX_NUMERO_PRO.Name = "txtCAF_IX_NUMERO_PRO"
            Me.txtCAF_IX_NUMERO_PRO.Size = New System.Drawing.Size(115, 20)
            Me.txtCAF_IX_NUMERO_PRO.TabIndex = 11
            '
            'txtCAF_OBSERVACIONES
            '
            Me.txtCAF_OBSERVACIONES.Location = New System.Drawing.Point(82, 269)
            Me.txtCAF_OBSERVACIONES.Multiline = True
            Me.txtCAF_OBSERVACIONES.Name = "txtCAF_OBSERVACIONES"
            Me.txtCAF_OBSERVACIONES.Size = New System.Drawing.Size(591, 48)
            Me.txtCAF_OBSERVACIONES.TabIndex = 14
            '
            'txtCAF_DIAS_VEN
            '
            Me.txtCAF_DIAS_VEN.Location = New System.Drawing.Point(82, 74)
            Me.txtCAF_DIAS_VEN.Name = "txtCAF_DIAS_VEN"
            Me.txtCAF_DIAS_VEN.Size = New System.Drawing.Size(108, 20)
            Me.txtCAF_DIAS_VEN.TabIndex = 4
            Me.txtCAF_DIAS_VEN.Text = "0"
            '
            'txtCAF_NUMERO
            '
            Me.txtCAF_NUMERO.Location = New System.Drawing.Point(348, 74)
            Me.txtCAF_NUMERO.Name = "txtCAF_NUMERO"
            Me.txtCAF_NUMERO.Size = New System.Drawing.Size(108, 20)
            Me.txtCAF_NUMERO.TabIndex = 5
            '
            'txtCAF_MONTO
            '
            Me.txtCAF_MONTO.Location = New System.Drawing.Point(82, 128)
            Me.txtCAF_MONTO.Name = "txtCAF_MONTO"
            Me.txtCAF_MONTO.Size = New System.Drawing.Size(108, 20)
            Me.txtCAF_MONTO.TabIndex = 8
            Me.txtCAF_MONTO.Text = "0"
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(154, 157)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(519, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 10
            '
            'txtMON_DESCRIPCION
            '
            Me.txtMON_DESCRIPCION.Enabled = False
            Me.txtMON_DESCRIPCION.Location = New System.Drawing.Point(126, 100)
            Me.txtMON_DESCRIPCION.Name = "txtMON_DESCRIPCION"
            Me.txtMON_DESCRIPCION.ReadOnly = True
            Me.txtMON_DESCRIPCION.Size = New System.Drawing.Size(547, 20)
            Me.txtMON_DESCRIPCION.TabIndex = 7
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(82, 157)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(66, 20)
            Me.txtPER_ID.TabIndex = 9
            '
            'txtMON_ID
            '
            Me.txtMON_ID.Location = New System.Drawing.Point(82, 100)
            Me.txtMON_ID.Name = "txtMON_ID"
            Me.txtMON_ID.Size = New System.Drawing.Size(38, 20)
            Me.txtMON_ID.TabIndex = 6
            '
            'cboCAF_ESTADO_DOC
            '
            Me.cboCAF_ESTADO_DOC.FormattingEnabled = True
            Me.cboCAF_ESTADO_DOC.Location = New System.Drawing.Point(82, 240)
            Me.cboCAF_ESTADO_DOC.Name = "cboCAF_ESTADO_DOC"
            Me.cboCAF_ESTADO_DOC.Size = New System.Drawing.Size(108, 21)
            Me.cboCAF_ESTADO_DOC.TabIndex = 13
            '
            'cboCAF_TIPO_DOC
            '
            Me.cboCAF_TIPO_DOC.FormattingEnabled = True
            Me.cboCAF_TIPO_DOC.Location = New System.Drawing.Point(348, 13)
            Me.cboCAF_TIPO_DOC.Name = "cboCAF_TIPO_DOC"
            Me.cboCAF_TIPO_DOC.Size = New System.Drawing.Size(143, 21)
            Me.cboCAF_TIPO_DOC.TabIndex = 1
            '
            'txtCAF_ID
            '
            Me.txtCAF_ID.Location = New System.Drawing.Point(82, 13)
            Me.txtCAF_ID.Name = "txtCAF_ID"
            Me.txtCAF_ID.Size = New System.Drawing.Size(103, 20)
            Me.txtCAF_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(681, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmCartaFianza
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(761, 413)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmCartaFianza"
            Me.Text = "Carta fianza"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblCAF_OBSERVACIONES As System.Windows.Forms.Label
        Friend WithEvents lblCAF_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblCAF_FECHA_EMI As System.Windows.Forms.Label
        Friend WithEvents lblCAF_IX_NUMERO_PRO As System.Windows.Forms.Label
        Friend WithEvents lblCAF_DIAS_VEN As System.Windows.Forms.Label
        Friend WithEvents lblCAF_NUMERO As System.Windows.Forms.Label
        Friend WithEvents lblCAF_MONTO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblMON_ID As System.Windows.Forms.Label
        Friend WithEvents lbCAF_ESTADO_DOC As System.Windows.Forms.Label
        Friend WithEvents lblCAF_TIPO_DOC As System.Windows.Forms.Label
        Friend WithEvents lblCAF_ID As System.Windows.Forms.Label
        Public WithEvents dtpCAF_FECHA_EMI As System.Windows.Forms.DateTimePicker
        Public WithEvents chkCAF_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtCAF_IX_NUMERO_PRO As System.Windows.Forms.TextBox
        Public WithEvents txtCAF_OBSERVACIONES As System.Windows.Forms.TextBox
        Public WithEvents txtCAF_DIAS_VEN As System.Windows.Forms.TextBox
        Public WithEvents txtCAF_NUMERO As System.Windows.Forms.TextBox
        Public WithEvents txtCAF_MONTO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMON_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMON_ID As System.Windows.Forms.TextBox
        Public WithEvents cboCAF_ESTADO_DOC As System.Windows.Forms.ComboBox
        Public WithEvents cboCAF_TIPO_DOC As System.Windows.Forms.ComboBox
        Public WithEvents txtCAF_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblCAF_FECHA_VEN As System.Windows.Forms.Label
        Public WithEvents dtpCAF_FECHA_VEN As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCAF_IX_ORDEN_COM As System.Windows.Forms.Label
        Public WithEvents txtCAF_IX_ORDEN_COM As System.Windows.Forms.TextBox
    End Class
End Namespace