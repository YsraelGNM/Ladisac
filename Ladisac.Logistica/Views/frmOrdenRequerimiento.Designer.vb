Namespace Ladisac.Logistica.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmOrdenRequerimiento
        Inherits Ladisac.Foundation.Views.ViewManMaster

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtAutorizado = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSolicitado = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.dtpFechaMax = New System.Windows.Forms.DateTimePicker()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dtpTiempo = New System.Windows.Forms.DateTimePicker()
            Me.cboImportancia = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.ORD_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OT = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ENO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Mantenimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Art = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CantAtendida = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ALM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ORD_CONFORMIDAD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.chkNuevo = New System.Windows.Forms.CheckBox()
            Me.Error_Validacion = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
            Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
            Me.lblHecho = New System.Windows.Forms.Label()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.chkLadrillo = New System.Windows.Forms.CheckBox()
            Me.chkCerrada = New System.Windows.Forms.CheckBox()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(861, 28)
            Me.lblTitle.Text = "Orden de Requerimiento"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(15, 153)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(57, 13)
            Me.Label3.TabIndex = 28
            Me.Label3.Text = "Autorizado"
            '
            'txtAutorizado
            '
            Me.txtAutorizado.Location = New System.Drawing.Point(92, 149)
            Me.txtAutorizado.Name = "txtAutorizado"
            Me.txtAutorizado.Size = New System.Drawing.Size(441, 20)
            Me.txtAutorizado.TabIndex = 27
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(15, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 13)
            Me.Label2.TabIndex = 26
            Me.Label2.Text = "Código"
            '
            'txtCodigo
            '
            Me.txtCodigo.BackColor = System.Drawing.Color.White
            Me.txtCodigo.Location = New System.Drawing.Point(92, 68)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
            Me.txtCodigo.TabIndex = 25
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(15, 127)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(53, 13)
            Me.Label1.TabIndex = 24
            Me.Label1.Text = "Solicitado"
            '
            'txtSolicitado
            '
            Me.txtSolicitado.Location = New System.Drawing.Point(92, 123)
            Me.txtSolicitado.Name = "txtSolicitado"
            Me.txtSolicitado.Size = New System.Drawing.Size(441, 20)
            Me.txtSolicitado.TabIndex = 23
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(257, 72)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(37, 13)
            Me.Label6.TabIndex = 33
            Me.Label6.Text = "Fecha"
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(366, 68)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(80, 20)
            Me.dtpFecha.TabIndex = 34
            '
            'dtpFechaMax
            '
            Me.dtpFechaMax.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            Me.dtpFechaMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFechaMax.Location = New System.Drawing.Point(366, 97)
            Me.dtpFechaMax.Name = "dtpFechaMax"
            Me.dtpFechaMax.Size = New System.Drawing.Size(167, 20)
            Me.dtpFechaMax.TabIndex = 36
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(257, 101)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(103, 13)
            Me.Label7.TabIndex = 35
            Me.Label7.Text = "Fecha Max. Entrega"
            '
            'dtpTiempo
            '
            Me.dtpTiempo.Enabled = False
            Me.dtpTiempo.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpTiempo.Location = New System.Drawing.Point(448, 68)
            Me.dtpTiempo.Name = "dtpTiempo"
            Me.dtpTiempo.Size = New System.Drawing.Size(85, 20)
            Me.dtpTiempo.TabIndex = 37
            '
            'cboImportancia
            '
            Me.cboImportancia.FormattingEnabled = True
            Me.cboImportancia.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
            Me.cboImportancia.Location = New System.Drawing.Point(92, 175)
            Me.cboImportancia.Name = "cboImportancia"
            Me.cboImportancia.Size = New System.Drawing.Size(90, 21)
            Me.cboImportancia.TabIndex = 39
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(15, 179)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(62, 13)
            Me.Label5.TabIndex = 38
            Me.Label5.Text = "Importancia"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ORD_Id, Me.OT, Me.ENO_ID, Me.Mantenimiento, Me.Art, Me.UM, Me.Cantidad, Me.CantAtendida, Me.Observacion, Me.ALM_ID, Me.ORD_CONFORMIDAD})
            Me.dgvDetalle.Location = New System.Drawing.Point(17, 211)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(828, 278)
            Me.dgvDetalle.TabIndex = 40
            '
            'ORD_Id
            '
            Me.ORD_Id.HeaderText = "ORD_Id"
            Me.ORD_Id.Name = "ORD_Id"
            Me.ORD_Id.Visible = False
            '
            'OT
            '
            Me.OT.HeaderText = "OT.Codigo"
            Me.OT.Name = "OT"
            '
            'ENO_ID
            '
            Me.ENO_ID.HeaderText = "Entidad"
            Me.ENO_ID.Name = "ENO_ID"
            '
            'Mantenimiento
            '
            Me.Mantenimiento.HeaderText = "Mantenimiento"
            Me.Mantenimiento.Name = "Mantenimiento"
            Me.Mantenimiento.ReadOnly = True
            '
            'Art
            '
            Me.Art.HeaderText = "Art.Codigo"
            Me.Art.Name = "Art"
            Me.Art.Width = 250
            '
            'UM
            '
            Me.UM.HeaderText = "UM"
            Me.UM.Name = "UM"
            Me.UM.ReadOnly = True
            Me.UM.Width = 50
            '
            'Cantidad
            '
            Me.Cantidad.HeaderText = "Cantidad"
            Me.Cantidad.Name = "Cantidad"
            '
            'CantAtendida
            '
            Me.CantAtendida.HeaderText = "Cant.Atendida"
            Me.CantAtendida.Name = "CantAtendida"
            Me.CantAtendida.ReadOnly = True
            '
            'Observacion
            '
            Me.Observacion.HeaderText = "Observacion"
            Me.Observacion.MaxInputLength = 500
            Me.Observacion.Name = "Observacion"
            '
            'ALM_ID
            '
            Me.ALM_ID.HeaderText = "Almacen Destino"
            Me.ALM_ID.Name = "ALM_ID"
            '
            'ORD_CONFORMIDAD
            '
            Me.ORD_CONFORMIDAD.HeaderText = "Conformidad"
            Me.ORD_CONFORMIDAD.Name = "ORD_CONFORMIDAD"
            Me.ORD_CONFORMIDAD.Visible = False
            '
            'chkNuevo
            '
            Me.chkNuevo.AutoSize = True
            Me.chkNuevo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkNuevo.Location = New System.Drawing.Point(260, 177)
            Me.chkNuevo.Name = "chkNuevo"
            Me.chkNuevo.Size = New System.Drawing.Size(58, 17)
            Me.chkNuevo.TabIndex = 41
            Me.chkNuevo.Text = "Nuevo"
            Me.chkNuevo.UseVisualStyleBackColor = True
            '
            'Error_Validacion
            '
            Me.Error_Validacion.ContainerControl = Me
            '
            'PrintDocument1
            '
            '
            'PrintDialog1
            '
            Me.PrintDialog1.Document = Me.PrintDocument1
            Me.PrintDialog1.UseEXDialog = True
            '
            'lblHecho
            '
            Me.lblHecho.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblHecho.AutoSize = True
            Me.lblHecho.Location = New System.Drawing.Point(15, 500)
            Me.lblHecho.Name = "lblHecho"
            Me.lblHecho.Size = New System.Drawing.Size(0, 13)
            Me.lblHecho.TabIndex = 111
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "ORD_Id"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "OT.Codigo"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Entidad"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Mantenimiento"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Art.Codigo"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "UM"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "Cantidad"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Cant.Atendida"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.HeaderText = "Observacion"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.HeaderText = "Almacen Destino"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            '
            'chkLadrillo
            '
            Me.chkLadrillo.AutoSize = True
            Me.chkLadrillo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkLadrillo.Location = New System.Drawing.Point(342, 177)
            Me.chkLadrillo.Name = "chkLadrillo"
            Me.chkLadrillo.Size = New System.Drawing.Size(100, 17)
            Me.chkLadrillo.TabIndex = 112
            Me.chkLadrillo.Text = "Req. de Ladrillo"
            Me.chkLadrillo.UseVisualStyleBackColor = True
            '
            'chkCerrada
            '
            Me.chkCerrada.AutoSize = True
            Me.chkCerrada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCerrada.Location = New System.Drawing.Point(470, 177)
            Me.chkCerrada.Name = "chkCerrada"
            Me.chkCerrada.Size = New System.Drawing.Size(63, 17)
            Me.chkCerrada.TabIndex = 113
            Me.chkCerrada.Text = "Cerrada"
            Me.chkCerrada.UseVisualStyleBackColor = True
            '
            'frmOrdenRequerimiento
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(861, 522)
            Me.Controls.Add(Me.chkCerrada)
            Me.Controls.Add(Me.chkLadrillo)
            Me.Controls.Add(Me.lblHecho)
            Me.Controls.Add(Me.chkNuevo)
            Me.Controls.Add(Me.dgvDetalle)
            Me.Controls.Add(Me.cboImportancia)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.dtpTiempo)
            Me.Controls.Add(Me.dtpFechaMax)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.dtpFecha)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.txtAutorizado)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.txtCodigo)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtSolicitado)
            Me.Name = "frmOrdenRequerimiento"
            Me.Text = "Orden de Requerimiento"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.txtSolicitado, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtCodigo, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.txtAutorizado, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.Label6, 0)
            Me.Controls.SetChildIndex(Me.dtpFecha, 0)
            Me.Controls.SetChildIndex(Me.Label7, 0)
            Me.Controls.SetChildIndex(Me.dtpFechaMax, 0)
            Me.Controls.SetChildIndex(Me.dtpTiempo, 0)
            Me.Controls.SetChildIndex(Me.Label5, 0)
            Me.Controls.SetChildIndex(Me.cboImportancia, 0)
            Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
            Me.Controls.SetChildIndex(Me.chkNuevo, 0)
            Me.Controls.SetChildIndex(Me.lblHecho, 0)
            Me.Controls.SetChildIndex(Me.chkLadrillo, 0)
            Me.Controls.SetChildIndex(Me.chkCerrada, 0)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtAutorizado As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtSolicitado As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFechaMax As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents dtpTiempo As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboImportancia As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents chkNuevo As System.Windows.Forms.CheckBox
        Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider
        Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
        Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
        Friend WithEvents lblHecho As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents chkLadrillo As System.Windows.Forms.CheckBox
        Friend WithEvents chkCerrada As System.Windows.Forms.CheckBox
        Friend WithEvents ORD_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OT As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ENO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Mantenimiento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Art As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CantAtendida As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ALM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ORD_CONFORMIDAD As System.Windows.Forms.DataGridViewCheckBoxColumn

    End Class


End Namespace