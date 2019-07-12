Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRestriccionArticulo
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
            Me.lblREA_ESTADO = New System.Windows.Forms.Label()
            Me.lblREA_FECHA = New System.Windows.Forms.Label()
            Me.lblREA_CONDICION = New System.Windows.Forms.Label()
            Me.lblREA_CANTIDAD = New System.Windows.Forms.Label()
            Me.lblART_ID = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblREA_MOVIMIENTO = New System.Windows.Forms.Label()
            Me.dtpREA_FECHA = New System.Windows.Forms.DateTimePicker()
            Me.chkREA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkREA_CONDICION = New System.Windows.Forms.CheckBox()
            Me.txtREA_CANTIDAD = New System.Windows.Forms.TextBox()
            Me.txtART_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtART_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.cboREA_MOVIMIENTO = New System.Windows.Forms.ComboBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(632, 28)
            Me.lblTitle.Text = "Restricción artículo"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblREA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblREA_FECHA)
            Me.pnCuerpo.Controls.Add(Me.lblREA_CONDICION)
            Me.pnCuerpo.Controls.Add(Me.lblREA_CANTIDAD)
            Me.pnCuerpo.Controls.Add(Me.lblART_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblREA_MOVIMIENTO)
            Me.pnCuerpo.Controls.Add(Me.dtpREA_FECHA)
            Me.pnCuerpo.Controls.Add(Me.chkREA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkREA_CONDICION)
            Me.pnCuerpo.Controls.Add(Me.txtREA_CANTIDAD)
            Me.pnCuerpo.Controls.Add(Me.txtART_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtART_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.cboREA_MOVIMIENTO)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(571, 154)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblREA_ESTADO
            '
            Me.lblREA_ESTADO.AutoSize = True
            Me.lblREA_ESTADO.Location = New System.Drawing.Point(8, 126)
            Me.lblREA_ESTADO.Name = "lblREA_ESTADO"
            Me.lblREA_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblREA_ESTADO.TabIndex = 36
            Me.lblREA_ESTADO.Text = "Estado"
            '
            'lblREA_FECHA
            '
            Me.lblREA_FECHA.AutoSize = True
            Me.lblREA_FECHA.Location = New System.Drawing.Point(8, 66)
            Me.lblREA_FECHA.Name = "lblREA_FECHA"
            Me.lblREA_FECHA.Size = New System.Drawing.Size(37, 13)
            Me.lblREA_FECHA.TabIndex = 35
            Me.lblREA_FECHA.Text = "Fecha"
            '
            'lblREA_CONDICION
            '
            Me.lblREA_CONDICION.AutoSize = True
            Me.lblREA_CONDICION.Location = New System.Drawing.Point(256, 66)
            Me.lblREA_CONDICION.Name = "lblREA_CONDICION"
            Me.lblREA_CONDICION.Size = New System.Drawing.Size(54, 13)
            Me.lblREA_CONDICION.TabIndex = 29
            Me.lblREA_CONDICION.Text = "Condición"
            '
            'lblREA_CANTIDAD
            '
            Me.lblREA_CANTIDAD.AutoSize = True
            Me.lblREA_CANTIDAD.Location = New System.Drawing.Point(435, 66)
            Me.lblREA_CANTIDAD.Name = "lblREA_CANTIDAD"
            Me.lblREA_CANTIDAD.Size = New System.Drawing.Size(49, 13)
            Me.lblREA_CANTIDAD.TabIndex = 27
            Me.lblREA_CANTIDAD.Text = "Cantidad"
            '
            'lblART_ID
            '
            Me.lblART_ID.AutoSize = True
            Me.lblART_ID.Location = New System.Drawing.Point(8, 39)
            Me.lblART_ID.Name = "lblART_ID"
            Me.lblART_ID.Size = New System.Drawing.Size(69, 13)
            Me.lblART_ID.TabIndex = 26
            Me.lblART_ID.Text = "Cód. Artículo"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(8, 12)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(71, 13)
            Me.lblPER_ID.TabIndex = 25
            Me.lblPER_ID.Text = "Cód. Persona"
            '
            'lblREA_MOVIMIENTO
            '
            Me.lblREA_MOVIMIENTO.AutoSize = True
            Me.lblREA_MOVIMIENTO.Location = New System.Drawing.Point(8, 95)
            Me.lblREA_MOVIMIENTO.Name = "lblREA_MOVIMIENTO"
            Me.lblREA_MOVIMIENTO.Size = New System.Drawing.Size(61, 13)
            Me.lblREA_MOVIMIENTO.TabIndex = 23
            Me.lblREA_MOVIMIENTO.Text = "Movimiento"
            '
            'dtpREA_FECHA
            '
            Me.dtpREA_FECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpREA_FECHA.Location = New System.Drawing.Point(97, 66)
            Me.dtpREA_FECHA.Name = "dtpREA_FECHA"
            Me.dtpREA_FECHA.Size = New System.Drawing.Size(103, 20)
            Me.dtpREA_FECHA.TabIndex = 5
            '
            'chkREA_ESTADO
            '
            Me.chkREA_ESTADO.AutoSize = True
            Me.chkREA_ESTADO.Location = New System.Drawing.Point(97, 125)
            Me.chkREA_ESTADO.Name = "chkREA_ESTADO"
            Me.chkREA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkREA_ESTADO.TabIndex = 9
            Me.chkREA_ESTADO.UseVisualStyleBackColor = True
            '
            'chkREA_CONDICION
            '
            Me.chkREA_CONDICION.AutoSize = True
            Me.chkREA_CONDICION.Location = New System.Drawing.Point(314, 66)
            Me.chkREA_CONDICION.Name = "chkREA_CONDICION"
            Me.chkREA_CONDICION.Size = New System.Drawing.Size(15, 14)
            Me.chkREA_CONDICION.TabIndex = 6
            Me.chkREA_CONDICION.UseVisualStyleBackColor = True
            '
            'txtREA_CANTIDAD
            '
            Me.txtREA_CANTIDAD.Location = New System.Drawing.Point(489, 66)
            Me.txtREA_CANTIDAD.Name = "txtREA_CANTIDAD"
            Me.txtREA_CANTIDAD.Size = New System.Drawing.Size(71, 20)
            Me.txtREA_CANTIDAD.TabIndex = 7
            Me.txtREA_CANTIDAD.Text = "0"
            '
            'txtART_DESCRIPCION
            '
            Me.txtART_DESCRIPCION.Enabled = False
            Me.txtART_DESCRIPCION.Location = New System.Drawing.Point(183, 39)
            Me.txtART_DESCRIPCION.Name = "txtART_DESCRIPCION"
            Me.txtART_DESCRIPCION.ReadOnly = True
            Me.txtART_DESCRIPCION.Size = New System.Drawing.Size(377, 20)
            Me.txtART_DESCRIPCION.TabIndex = 4
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(183, 12)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(377, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 2
            '
            'txtART_ID
            '
            Me.txtART_ID.Location = New System.Drawing.Point(97, 39)
            Me.txtART_ID.Name = "txtART_ID"
            Me.txtART_ID.Size = New System.Drawing.Size(80, 20)
            Me.txtART_ID.TabIndex = 3
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(97, 12)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(80, 20)
            Me.txtPER_ID.TabIndex = 1
            '
            'cboREA_MOVIMIENTO
            '
            Me.cboREA_MOVIMIENTO.FormattingEnabled = True
            Me.cboREA_MOVIMIENTO.Location = New System.Drawing.Point(97, 95)
            Me.cboREA_MOVIMIENTO.Name = "cboREA_MOVIMIENTO"
            Me.cboREA_MOVIMIENTO.Size = New System.Drawing.Size(103, 21)
            Me.cboREA_MOVIMIENTO.TabIndex = 8
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(559, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmRestriccionArticulo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(632, 217)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmRestriccionArticulo"
            Me.Text = "Restricción artículo"
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
        Friend WithEvents lblREA_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblREA_FECHA As System.Windows.Forms.Label
        Friend WithEvents lblREA_CONDICION As System.Windows.Forms.Label
        Friend WithEvents lblREA_CANTIDAD As System.Windows.Forms.Label
        Friend WithEvents lblART_ID As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblREA_MOVIMIENTO As System.Windows.Forms.Label
        Public WithEvents dtpREA_FECHA As System.Windows.Forms.DateTimePicker
        Public WithEvents chkREA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkREA_CONDICION As System.Windows.Forms.CheckBox
        Public WithEvents txtREA_CANTIDAD As System.Windows.Forms.TextBox
        Public WithEvents txtART_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtART_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents cboREA_MOVIMIENTO As System.Windows.Forms.ComboBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    End Class
End Namespace