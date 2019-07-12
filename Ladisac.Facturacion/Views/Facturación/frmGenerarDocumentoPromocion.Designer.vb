Namespace Ladisac.Facturacion.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGenerarDocumentoPromocion
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.btnJalarDatos = New System.Windows.Forms.Button()
            Me.lblDPR_FECHA = New System.Windows.Forms.Label()
            Me.dtpDPR_FECHA = New System.Windows.Forms.DateTimePicker()
            Me.lblPER_ESTADO_PRO = New System.Windows.Forms.Label()
            Me.chkPER_ESTADO_PRO = New System.Windows.Forms.CheckBox()
            Me.lblPER_ID_PRO = New System.Windows.Forms.Label()
            Me.lblPER_DESCRIPCION_PRO = New System.Windows.Forms.Label()
            Me.txtPER_ID_PRO = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_PRO = New System.Windows.Forms.TextBox()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cDDP_ITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cTDO_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDTD_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_ID_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cCCT_DESCRIPCION_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDP_SERIE_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDP_NUMERO_DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDP_PUNTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDP_PUNTOS_CONTROL = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDP_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblDPR_TIPO_PROMOCION = New System.Windows.Forms.Label()
            Me.cboDPR_TIPO_PROMOCION = New System.Windows.Forms.ComboBox()
            Me.lblDPR_NUMERO = New System.Windows.Forms.Label()
            Me.txtDPR_NUMERO = New System.Windows.Forms.TextBox()
            Me.lblLPR_ESTADO = New System.Windows.Forms.Label()
            Me.chkDPR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
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
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(967, 28)
            Me.lblTitle.Text = "Promoción"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.btnJalarDatos)
            Me.pnCuerpo.Controls.Add(Me.lblDPR_FECHA)
            Me.pnCuerpo.Controls.Add(Me.dtpDPR_FECHA)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ESTADO_PRO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_PRO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_PRO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_DESCRIPCION_PRO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_PRO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_PRO)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblDPR_TIPO_PROMOCION)
            Me.pnCuerpo.Controls.Add(Me.cboDPR_TIPO_PROMOCION)
            Me.pnCuerpo.Controls.Add(Me.lblDPR_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.txtDPR_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkDPR_ESTADO)
            Me.pnCuerpo.Location = New System.Drawing.Point(39, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(890, 312)
            Me.pnCuerpo.TabIndex = 19
            '
            'btnJalarDatos
            '
            Me.btnJalarDatos.Location = New System.Drawing.Point(217, 67)
            Me.btnJalarDatos.Name = "btnJalarDatos"
            Me.btnJalarDatos.Size = New System.Drawing.Size(75, 23)
            Me.btnJalarDatos.TabIndex = 82
            Me.btnJalarDatos.Text = "Jalar datos"
            Me.btnJalarDatos.UseVisualStyleBackColor = True
            '
            'lblDPR_FECHA
            '
            Me.lblDPR_FECHA.AutoSize = True
            Me.lblDPR_FECHA.Location = New System.Drawing.Point(532, 14)
            Me.lblDPR_FECHA.Name = "lblDPR_FECHA"
            Me.lblDPR_FECHA.Size = New System.Drawing.Size(75, 13)
            Me.lblDPR_FECHA.TabIndex = 81
            Me.lblDPR_FECHA.Text = "Fecha emisión"
            '
            'dtpDPR_FECHA
            '
            Me.dtpDPR_FECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDPR_FECHA.Location = New System.Drawing.Point(617, 14)
            Me.dtpDPR_FECHA.Name = "dtpDPR_FECHA"
            Me.dtpDPR_FECHA.Size = New System.Drawing.Size(85, 20)
            Me.dtpDPR_FECHA.TabIndex = 80
            '
            'lblPER_ESTADO_PRO
            '
            Me.lblPER_ESTADO_PRO.AutoSize = True
            Me.lblPER_ESTADO_PRO.Location = New System.Drawing.Point(706, 41)
            Me.lblPER_ESTADO_PRO.Name = "lblPER_ESTADO_PRO"
            Me.lblPER_ESTADO_PRO.Size = New System.Drawing.Size(81, 13)
            Me.lblPER_ESTADO_PRO.TabIndex = 44
            Me.lblPER_ESTADO_PRO.Text = "Estado persona"
            '
            'chkPER_ESTADO_PRO
            '
            Me.chkPER_ESTADO_PRO.AutoSize = True
            Me.chkPER_ESTADO_PRO.Enabled = False
            Me.chkPER_ESTADO_PRO.Location = New System.Drawing.Point(791, 41)
            Me.chkPER_ESTADO_PRO.Name = "chkPER_ESTADO_PRO"
            Me.chkPER_ESTADO_PRO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_PRO.TabIndex = 5
            Me.chkPER_ESTADO_PRO.UseVisualStyleBackColor = True
            '
            'lblPER_ID_PRO
            '
            Me.lblPER_ID_PRO.AutoSize = True
            Me.lblPER_ID_PRO.Location = New System.Drawing.Point(6, 41)
            Me.lblPER_ID_PRO.Name = "lblPER_ID_PRO"
            Me.lblPER_ID_PRO.Size = New System.Drawing.Size(46, 13)
            Me.lblPER_ID_PRO.TabIndex = 42
            Me.lblPER_ID_PRO.Text = "Persona"
            '
            'lblPER_DESCRIPCION_PRO
            '
            Me.lblPER_DESCRIPCION_PRO.AutoSize = True
            Me.lblPER_DESCRIPCION_PRO.Location = New System.Drawing.Point(176, 41)
            Me.lblPER_DESCRIPCION_PRO.Name = "lblPER_DESCRIPCION_PRO"
            Me.lblPER_DESCRIPCION_PRO.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_DESCRIPCION_PRO.TabIndex = 43
            Me.lblPER_DESCRIPCION_PRO.Text = "Desc. "
            '
            'txtPER_ID_PRO
            '
            Me.txtPER_ID_PRO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_ID_PRO.Location = New System.Drawing.Point(53, 41)
            Me.txtPER_ID_PRO.Name = "txtPER_ID_PRO"
            Me.txtPER_ID_PRO.Size = New System.Drawing.Size(117, 20)
            Me.txtPER_ID_PRO.TabIndex = 3
            '
            'txtPER_DESCRIPCION_PRO
            '
            Me.txtPER_DESCRIPCION_PRO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPER_DESCRIPCION_PRO.Enabled = False
            Me.txtPER_DESCRIPCION_PRO.Location = New System.Drawing.Point(217, 41)
            Me.txtPER_DESCRIPCION_PRO.Name = "txtPER_DESCRIPCION_PRO"
            Me.txtPER_DESCRIPCION_PRO.ReadOnly = True
            Me.txtPER_DESCRIPCION_PRO.Size = New System.Drawing.Size(485, 20)
            Me.txtPER_DESCRIPCION_PRO.TabIndex = 4
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cDDP_ITEM, Me.cTDO_ID_DOC, Me.cTDO_DESCRIPCION_DOC, Me.cDTD_ID_DOC, Me.cDTD_DESCRIPCION_DOC, Me.cCCT_ID_DOC, Me.cCCT_DESCRIPCION_DOC, Me.cDDP_SERIE_DOC, Me.cDDP_NUMERO_DOC, Me.cART_ID, Me.cART_DESCRIPCION, Me.cDDP_PUNTOS, Me.cDDP_PUNTOS_CONTROL, Me.cDDP_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Location = New System.Drawing.Point(6, 96)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(861, 206)
            Me.dgvDetalle.TabIndex = 10
            '
            'cDDP_ITEM
            '
            Me.cDDP_ITEM.HeaderText = "Item"
            Me.cDDP_ITEM.Name = "cDDP_ITEM"
            Me.cDDP_ITEM.ReadOnly = True
            Me.cDDP_ITEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'cTDO_ID_DOC
            '
            Me.cTDO_ID_DOC.HeaderText = "Doc."
            Me.cTDO_ID_DOC.Name = "cTDO_ID_DOC"
            Me.cTDO_ID_DOC.ReadOnly = True
            Me.cTDO_ID_DOC.Visible = False
            Me.cTDO_ID_DOC.Width = 88
            '
            'cTDO_DESCRIPCION_DOC
            '
            Me.cTDO_DESCRIPCION_DOC.HeaderText = "Doc. Descripción"
            Me.cTDO_DESCRIPCION_DOC.Name = "cTDO_DESCRIPCION_DOC"
            Me.cTDO_DESCRIPCION_DOC.ReadOnly = True
            Me.cTDO_DESCRIPCION_DOC.Visible = False
            Me.cTDO_DESCRIPCION_DOC.Width = 53
            '
            'cDTD_ID_DOC
            '
            Me.cDTD_ID_DOC.HeaderText = "Tipo Doc."
            Me.cDTD_ID_DOC.Name = "cDTD_ID_DOC"
            Me.cDTD_ID_DOC.ReadOnly = True
            Me.cDTD_ID_DOC.Visible = False
            Me.cDTD_ID_DOC.Width = 90
            '
            'cDTD_DESCRIPCION_DOC
            '
            Me.cDTD_DESCRIPCION_DOC.HeaderText = "Tipo Doc. Descripción"
            Me.cDTD_DESCRIPCION_DOC.Name = "cDTD_DESCRIPCION_DOC"
            Me.cDTD_DESCRIPCION_DOC.ReadOnly = True
            Me.cDTD_DESCRIPCION_DOC.Width = 97
            '
            'cCCT_ID_DOC
            '
            Me.cCCT_ID_DOC.HeaderText = "Cta. Cte."
            Me.cCCT_ID_DOC.Name = "cCCT_ID_DOC"
            Me.cCCT_ID_DOC.ReadOnly = True
            Me.cCCT_ID_DOC.Visible = False
            Me.cCCT_ID_DOC.Width = 111
            '
            'cCCT_DESCRIPCION_DOC
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.cCCT_DESCRIPCION_DOC.DefaultCellStyle = DataGridViewCellStyle1
            Me.cCCT_DESCRIPCION_DOC.HeaderText = "Cta. Cte. Descripción"
            Me.cCCT_DESCRIPCION_DOC.Name = "cCCT_DESCRIPCION_DOC"
            Me.cCCT_DESCRIPCION_DOC.ReadOnly = True
            Me.cCCT_DESCRIPCION_DOC.Visible = False
            Me.cCCT_DESCRIPCION_DOC.Width = 55
            '
            'cDDP_SERIE_DOC
            '
            Me.cDDP_SERIE_DOC.HeaderText = "Serie Doc."
            Me.cDDP_SERIE_DOC.Name = "cDDP_SERIE_DOC"
            Me.cDDP_SERIE_DOC.ReadOnly = True
            Me.cDDP_SERIE_DOC.Width = 90
            '
            'cDDP_NUMERO_DOC
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N2"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.cDDP_NUMERO_DOC.DefaultCellStyle = DataGridViewCellStyle2
            Me.cDDP_NUMERO_DOC.HeaderText = "Número Doc."
            Me.cDDP_NUMERO_DOC.Name = "cDDP_NUMERO_DOC"
            Me.cDDP_NUMERO_DOC.ReadOnly = True
            Me.cDDP_NUMERO_DOC.Width = 80
            '
            'cART_ID
            '
            Me.cART_ID.HeaderText = "Código artículo"
            Me.cART_ID.Name = "cART_ID"
            Me.cART_ID.ReadOnly = True
            '
            'cART_DESCRIPCION
            '
            Me.cART_DESCRIPCION.HeaderText = "Descripción artículo"
            Me.cART_DESCRIPCION.Name = "cART_DESCRIPCION"
            Me.cART_DESCRIPCION.ReadOnly = True
            '
            'cDDP_PUNTOS
            '
            DataGridViewCellStyle3.Format = "N2"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.cDDP_PUNTOS.DefaultCellStyle = DataGridViewCellStyle3
            Me.cDDP_PUNTOS.HeaderText = "Puntos"
            Me.cDDP_PUNTOS.Name = "cDDP_PUNTOS"
            '
            'cDDP_PUNTOS_CONTROL
            '
            DataGridViewCellStyle4.Format = "n2"
            Me.cDDP_PUNTOS_CONTROL.DefaultCellStyle = DataGridViewCellStyle4
            Me.cDDP_PUNTOS_CONTROL.HeaderText = "Puntos control"
            Me.cDDP_PUNTOS_CONTROL.Name = "cDDP_PUNTOS_CONTROL"
            Me.cDDP_PUNTOS_CONTROL.ReadOnly = True
            '
            'cDDP_ESTADO
            '
            Me.cDDP_ESTADO.HeaderText = "Estado de detalle"
            Me.cDDP_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDDP_ESTADO.Name = "cDDP_ESTADO"
            Me.cDDP_ESTADO.ReadOnly = True
            Me.cDDP_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDDP_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cDDP_ESTADO.Visible = False
            Me.cDDP_ESTADO.Width = 86
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "Estado de registro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            Me.cEstadoRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cEstadoRegistro.Visible = False
            Me.cEstadoRegistro.Width = 88
            '
            'lblDPR_TIPO_PROMOCION
            '
            Me.lblDPR_TIPO_PROMOCION.AutoSize = True
            Me.lblDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(176, 14)
            Me.lblDPR_TIPO_PROMOCION.Name = "lblDPR_TIPO_PROMOCION"
            Me.lblDPR_TIPO_PROMOCION.Size = New System.Drawing.Size(28, 13)
            Me.lblDPR_TIPO_PROMOCION.TabIndex = 32
            Me.lblDPR_TIPO_PROMOCION.Text = "Tipo"
            '
            'cboDPR_TIPO_PROMOCION
            '
            Me.cboDPR_TIPO_PROMOCION.FormattingEnabled = True
            Me.cboDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(217, 14)
            Me.cboDPR_TIPO_PROMOCION.Name = "cboDPR_TIPO_PROMOCION"
            Me.cboDPR_TIPO_PROMOCION.Size = New System.Drawing.Size(184, 21)
            Me.cboDPR_TIPO_PROMOCION.TabIndex = 2
            '
            'lblDPR_NUMERO
            '
            Me.lblDPR_NUMERO.AutoSize = True
            Me.lblDPR_NUMERO.Location = New System.Drawing.Point(6, 14)
            Me.lblDPR_NUMERO.Name = "lblDPR_NUMERO"
            Me.lblDPR_NUMERO.Size = New System.Drawing.Size(40, 13)
            Me.lblDPR_NUMERO.TabIndex = 28
            Me.lblDPR_NUMERO.Text = "Código"
            '
            'txtDPR_NUMERO
            '
            Me.txtDPR_NUMERO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDPR_NUMERO.Location = New System.Drawing.Point(53, 14)
            Me.txtDPR_NUMERO.Name = "txtDPR_NUMERO"
            Me.txtDPR_NUMERO.Size = New System.Drawing.Size(117, 20)
            Me.txtDPR_NUMERO.TabIndex = 0
            '
            'lblLPR_ESTADO
            '
            Me.lblLPR_ESTADO.AutoSize = True
            Me.lblLPR_ESTADO.Location = New System.Drawing.Point(6, 67)
            Me.lblLPR_ESTADO.Name = "lblLPR_ESTADO"
            Me.lblLPR_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblLPR_ESTADO.TabIndex = 4
            Me.lblLPR_ESTADO.Text = "Estado"
            '
            'chkDPR_ESTADO
            '
            Me.chkDPR_ESTADO.AutoSize = True
            Me.chkDPR_ESTADO.Location = New System.Drawing.Point(53, 67)
            Me.chkDPR_ESTADO.Name = "chkDPR_ESTADO"
            Me.chkDPR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDPR_ESTADO.TabIndex = 9
            Me.chkDPR_ESTADO.UseVisualStyleBackColor = True
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(875, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(54, 28)
            Me.btnImagen.TabIndex = 20
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
            Me.ErrorProvider1.ContainerControl = Me
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "Item"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "Doc."
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Width = 88
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Doc. Descripción"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Width = 53
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Tipo Doc."
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Width = 90
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Tipo Doc. Descripción"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            Me.DataGridViewTextBoxColumn5.Width = 97
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "Cta. Cte."
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Width = 111
            '
            'DataGridViewTextBoxColumn7
            '
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewTextBoxColumn7.HeaderText = "Cta. Cte. Descripción"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Width = 55
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Serie Doc."
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Width = 90
            '
            'DataGridViewTextBoxColumn9
            '
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.Format = "N2"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewTextBoxColumn9.HeaderText = "Número Doc."
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 80
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.HeaderText = "Estado de registro"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn10.Width = 88
            '
            'frmGenerarDocumentoPromocion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(967, 372)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmGenerarDocumentoPromocion"
            Me.Text = "Promoción"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblDPR_NUMERO As System.Windows.Forms.Label
        Public WithEvents txtDPR_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents lblLPR_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkDPR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblDPR_TIPO_PROMOCION As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents cboDPR_TIPO_PROMOCION As System.Windows.Forms.ComboBox
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblPER_ESTADO_PRO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO_PRO As System.Windows.Forms.CheckBox
        Friend WithEvents lblPER_ID_PRO As System.Windows.Forms.Label
        Friend WithEvents lblPER_DESCRIPCION_PRO As System.Windows.Forms.Label
        Public WithEvents txtPER_ID_PRO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_PRO As System.Windows.Forms.TextBox
        Friend WithEvents lblDPR_FECHA As System.Windows.Forms.Label
        Public WithEvents dtpDPR_FECHA As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnJalarDatos As System.Windows.Forms.Button
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
        Friend WithEvents cDDP_ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cTDO_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDTD_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_ID_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cCCT_DESCRIPCION_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDP_SERIE_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDP_NUMERO_DOC As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDP_PUNTOS As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDP_PUNTOS_CONTROL As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDP_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace