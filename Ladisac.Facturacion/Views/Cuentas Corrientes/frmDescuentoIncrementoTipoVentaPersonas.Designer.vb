Namespace Ladisac.CuentasCorrientes.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDescuentoIncrementoTipoVentaPersonas
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
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.cboDTP_TIPO_DESC_INC = New System.Windows.Forms.ComboBox()
            Me.lblDTP_TIPO_DESC_INC = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDT_MONTO_MINIMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDT_MONTO_MAXIMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDT_MONTO_TIV = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cDDT_ESTADO = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.cEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblDTP_SUB_CRITERIO = New System.Windows.Forms.Label()
            Me.chkDTP_SUB_CRITERIO = New System.Windows.Forms.CheckBox()
            Me.lblDTP_MONTO_MAXIMO = New System.Windows.Forms.Label()
            Me.lblDTP_MONTO_MINIMO = New System.Windows.Forms.Label()
            Me.txtDTP_MONTO_MAXIMO = New System.Windows.Forms.TextBox()
            Me.txtDTP_MONTO_MINIMO = New System.Windows.Forms.TextBox()
            Me.txtDTP_ID = New System.Windows.Forms.TextBox()
            Me.lblART_FACTOR = New System.Windows.Forms.Label()
            Me.lblDTP_FEC_FIN = New System.Windows.Forms.Label()
            Me.dtpDTP_FEC_FIN = New System.Windows.Forms.DateTimePicker()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.lblTIV_DIAS = New System.Windows.Forms.Label()
            Me.txtTIV_DIAS = New System.Windows.Forms.TextBox()
            Me.lblTIV_ID = New System.Windows.Forms.Label()
            Me.txtTIV_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTIV_ID = New System.Windows.Forms.TextBox()
            Me.lblDLP_RECARGO_ENVIO = New System.Windows.Forms.Label()
            Me.chkTIV_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtDLP_RECARGO_ENVIO = New System.Windows.Forms.TextBox()
            Me.txtART_FACTOR = New System.Windows.Forms.TextBox()
            Me.txtUM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.chkART_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblDTP_ESTADO = New System.Windows.Forms.Label()
            Me.lblDTP_FEC_INI = New System.Windows.Forms.Label()
            Me.lblDTP_CANT_MAXIMA = New System.Windows.Forms.Label()
            Me.lblDTP_CANT_MINIMA = New System.Windows.Forms.Label()
            Me.lblDTP_MONTO_PER = New System.Windows.Forms.Label()
            Me.lblDTP_MONTO_TIV = New System.Windows.Forms.Label()
            Me.lblDTP_CRITERIO = New System.Windows.Forms.Label()
            Me.lblDLP_PRECIO_UNITARIO = New System.Windows.Forms.Label()
            Me.lblDLP_PRECIO_MINIMO = New System.Windows.Forms.Label()
            Me.lblART_ID = New System.Windows.Forms.Label()
            Me.lblLPR_ID = New System.Windows.Forms.Label()
            Me.lblDTP_DESCRIPCION = New System.Windows.Forms.Label()
            Me.dtpDTP_FEC_INI = New System.Windows.Forms.DateTimePicker()
            Me.chkDTP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtDTP_CANT_MAXIMA = New System.Windows.Forms.TextBox()
            Me.txtDTP_CANT_MINIMA = New System.Windows.Forms.TextBox()
            Me.txtDTP_MONTO_PER = New System.Windows.Forms.TextBox()
            Me.txtDTP_MONTO_TIV = New System.Windows.Forms.TextBox()
            Me.chkDTP_CRITERIO = New System.Windows.Forms.CheckBox()
            Me.txtDLP_PRECIO_UNITARIO = New System.Windows.Forms.TextBox()
            Me.txtDLP_PRECIO_MINIMO = New System.Windows.Forms.TextBox()
            Me.txtART_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtLPR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtART_ID = New System.Windows.Forms.TextBox()
            Me.txtLPR_ID = New System.Windows.Forms.TextBox()
            Me.txtDTP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
            Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(664, 28)
            Me.lblTitle.Text = "Descuentos / Incrementos"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(579, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.cboDTP_TIPO_DESC_INC)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_TIPO_DESC_INC)
            Me.pnCuerpo.Controls.Add(Me.dgvDetalle)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_SUB_CRITERIO)
            Me.pnCuerpo.Controls.Add(Me.chkDTP_SUB_CRITERIO)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_MONTO_MAXIMO)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_MONTO_MINIMO)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_MONTO_MAXIMO)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_MONTO_MINIMO)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblART_FACTOR)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_FEC_FIN)
            Me.pnCuerpo.Controls.Add(Me.dtpDTP_FEC_FIN)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_DIAS)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DIAS)
            Me.pnCuerpo.Controls.Add(Me.lblTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTIV_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDLP_RECARGO_ENVIO)
            Me.pnCuerpo.Controls.Add(Me.chkTIV_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDLP_RECARGO_ENVIO)
            Me.pnCuerpo.Controls.Add(Me.txtART_FACTOR)
            Me.pnCuerpo.Controls.Add(Me.txtUM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.chkART_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_FEC_INI)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_CANT_MAXIMA)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_CANT_MINIMA)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_MONTO_PER)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_MONTO_TIV)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_CRITERIO)
            Me.pnCuerpo.Controls.Add(Me.lblDLP_PRECIO_UNITARIO)
            Me.pnCuerpo.Controls.Add(Me.lblDLP_PRECIO_MINIMO)
            Me.pnCuerpo.Controls.Add(Me.lblART_ID)
            Me.pnCuerpo.Controls.Add(Me.lblLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.lblDTP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.dtpDTP_FEC_INI)
            Me.pnCuerpo.Controls.Add(Me.chkDTP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_CANT_MAXIMA)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_CANT_MINIMA)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_MONTO_PER)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_MONTO_TIV)
            Me.pnCuerpo.Controls.Add(Me.chkDTP_CRITERIO)
            Me.pnCuerpo.Controls.Add(Me.txtDLP_PRECIO_UNITARIO)
            Me.pnCuerpo.Controls.Add(Me.txtDLP_PRECIO_MINIMO)
            Me.pnCuerpo.Controls.Add(Me.txtART_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtART_ID)
            Me.pnCuerpo.Controls.Add(Me.txtLPR_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDTP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.ShapeContainer1)
            Me.pnCuerpo.Location = New System.Drawing.Point(31, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(593, 513)
            Me.pnCuerpo.TabIndex = 118
            '
            'cboDTP_TIPO_DESC_INC
            '
            Me.cboDTP_TIPO_DESC_INC.FormattingEnabled = True
            Me.cboDTP_TIPO_DESC_INC.Location = New System.Drawing.Point(82, 137)
            Me.cboDTP_TIPO_DESC_INC.Name = "cboDTP_TIPO_DESC_INC"
            Me.cboDTP_TIPO_DESC_INC.Size = New System.Drawing.Size(221, 21)
            Me.cboDTP_TIPO_DESC_INC.TabIndex = 68
            '
            'lblDTP_TIPO_DESC_INC
            '
            Me.lblDTP_TIPO_DESC_INC.AutoSize = True
            Me.lblDTP_TIPO_DESC_INC.Location = New System.Drawing.Point(6, 137)
            Me.lblDTP_TIPO_DESC_INC.Name = "lblDTP_TIPO_DESC_INC"
            Me.lblDTP_TIPO_DESC_INC.Size = New System.Drawing.Size(59, 13)
            Me.lblDTP_TIPO_DESC_INC.TabIndex = 67
            Me.lblDTP_TIPO_DESC_INC.Text = "Tipo Desc."
            '
            'dgvDetalle
            '
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cITEM, Me.cART_ID, Me.cART_DESCRIPCION, Me.cDDT_MONTO_MINIMO, Me.cDDT_MONTO_MAXIMO, Me.cDDT_MONTO_TIV, Me.cDDT_ESTADO, Me.cEstadoRegistro})
            Me.dgvDetalle.Enabled = False
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 292)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(567, 214)
            Me.dgvDetalle.TabIndex = 65
            '
            'cITEM
            '
            Me.cITEM.HeaderText = "Item"
            Me.cITEM.Name = "cITEM"
            Me.cITEM.ReadOnly = True
            Me.cITEM.Visible = False
            '
            'cART_ID
            '
            Me.cART_ID.HeaderText = "Codigo"
            Me.cART_ID.Name = "cART_ID"
            '
            'cART_DESCRIPCION
            '
            Me.cART_DESCRIPCION.HeaderText = "Descripcion"
            Me.cART_DESCRIPCION.Name = "cART_DESCRIPCION"
            Me.cART_DESCRIPCION.ReadOnly = True
            '
            'cDDT_MONTO_MINIMO
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "N0"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.cDDT_MONTO_MINIMO.DefaultCellStyle = DataGridViewCellStyle1
            Me.cDDT_MONTO_MINIMO.HeaderText = "Ventas desde"
            Me.cDDT_MONTO_MINIMO.Name = "cDDT_MONTO_MINIMO"
            '
            'cDDT_MONTO_MAXIMO
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N0"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.cDDT_MONTO_MAXIMO.DefaultCellStyle = DataGridViewCellStyle2
            Me.cDDT_MONTO_MAXIMO.HeaderText = "Hasta"
            Me.cDDT_MONTO_MAXIMO.Name = "cDDT_MONTO_MAXIMO"
            '
            'cDDT_MONTO_TIV
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N2"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.cDDT_MONTO_TIV.DefaultCellStyle = DataGridViewCellStyle3
            Me.cDDT_MONTO_TIV.HeaderText = "Desc./Inc."
            Me.cDDT_MONTO_TIV.Name = "cDDT_MONTO_TIV"
            '
            'cDDT_ESTADO
            '
            Me.cDDT_ESTADO.HeaderText = "Estado"
            Me.cDDT_ESTADO.Items.AddRange(New Object() {"NO ACTIVO", "ACTIVO"})
            Me.cDDT_ESTADO.Name = "cDDT_ESTADO"
            Me.cDDT_ESTADO.ReadOnly = True
            Me.cDDT_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cDDT_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cEstadoRegistro
            '
            Me.cEstadoRegistro.HeaderText = "EstadoRegistro"
            Me.cEstadoRegistro.Name = "cEstadoRegistro"
            Me.cEstadoRegistro.ReadOnly = True
            '
            'lblDTP_SUB_CRITERIO
            '
            Me.lblDTP_SUB_CRITERIO.AutoSize = True
            Me.lblDTP_SUB_CRITERIO.Location = New System.Drawing.Point(221, 193)
            Me.lblDTP_SUB_CRITERIO.Name = "lblDTP_SUB_CRITERIO"
            Me.lblDTP_SUB_CRITERIO.Size = New System.Drawing.Size(60, 13)
            Me.lblDTP_SUB_CRITERIO.TabIndex = 64
            Me.lblDTP_SUB_CRITERIO.Text = "Sub criterio"
            '
            'chkDTP_SUB_CRITERIO
            '
            Me.chkDTP_SUB_CRITERIO.AutoSize = True
            Me.chkDTP_SUB_CRITERIO.Enabled = False
            Me.chkDTP_SUB_CRITERIO.Location = New System.Drawing.Point(305, 193)
            Me.chkDTP_SUB_CRITERIO.Name = "chkDTP_SUB_CRITERIO"
            Me.chkDTP_SUB_CRITERIO.Size = New System.Drawing.Size(15, 14)
            Me.chkDTP_SUB_CRITERIO.TabIndex = 20
            Me.chkDTP_SUB_CRITERIO.UseVisualStyleBackColor = True
            '
            'lblDTP_MONTO_MAXIMO
            '
            Me.lblDTP_MONTO_MAXIMO.AutoSize = True
            Me.lblDTP_MONTO_MAXIMO.Location = New System.Drawing.Point(221, 214)
            Me.lblDTP_MONTO_MAXIMO.Name = "lblDTP_MONTO_MAXIMO"
            Me.lblDTP_MONTO_MAXIMO.Size = New System.Drawing.Size(75, 13)
            Me.lblDTP_MONTO_MAXIMO.TabIndex = 62
            Me.lblDTP_MONTO_MAXIMO.Text = "Monto máximo"
            '
            'lblDTP_MONTO_MINIMO
            '
            Me.lblDTP_MONTO_MINIMO.AutoSize = True
            Me.lblDTP_MONTO_MINIMO.Location = New System.Drawing.Point(5, 214)
            Me.lblDTP_MONTO_MINIMO.Name = "lblDTP_MONTO_MINIMO"
            Me.lblDTP_MONTO_MINIMO.Size = New System.Drawing.Size(74, 13)
            Me.lblDTP_MONTO_MINIMO.TabIndex = 61
            Me.lblDTP_MONTO_MINIMO.Text = "Monto mínimo"
            '
            'txtDTP_MONTO_MAXIMO
            '
            Me.txtDTP_MONTO_MAXIMO.Location = New System.Drawing.Point(305, 214)
            Me.txtDTP_MONTO_MAXIMO.Name = "txtDTP_MONTO_MAXIMO"
            Me.txtDTP_MONTO_MAXIMO.Size = New System.Drawing.Size(103, 20)
            Me.txtDTP_MONTO_MAXIMO.TabIndex = 22
            Me.txtDTP_MONTO_MAXIMO.Text = "0"
            '
            'txtDTP_MONTO_MINIMO
            '
            Me.txtDTP_MONTO_MINIMO.Location = New System.Drawing.Point(81, 214)
            Me.txtDTP_MONTO_MINIMO.Name = "txtDTP_MONTO_MINIMO"
            Me.txtDTP_MONTO_MINIMO.Size = New System.Drawing.Size(103, 20)
            Me.txtDTP_MONTO_MINIMO.TabIndex = 21
            Me.txtDTP_MONTO_MINIMO.Text = "0"
            '
            'txtDTP_ID
            '
            Me.txtDTP_ID.Enabled = False
            Me.txtDTP_ID.Location = New System.Drawing.Point(470, 5)
            Me.txtDTP_ID.Name = "txtDTP_ID"
            Me.txtDTP_ID.Size = New System.Drawing.Size(99, 20)
            Me.txtDTP_ID.TabIndex = 58
            Me.txtDTP_ID.Visible = False
            '
            'lblART_FACTOR
            '
            Me.lblART_FACTOR.AutoSize = True
            Me.lblART_FACTOR.Location = New System.Drawing.Point(382, 60)
            Me.lblART_FACTOR.Name = "lblART_FACTOR"
            Me.lblART_FACTOR.Size = New System.Drawing.Size(37, 13)
            Me.lblART_FACTOR.TabIndex = 57
            Me.lblART_FACTOR.Text = "Factor"
            '
            'lblDTP_FEC_FIN
            '
            Me.lblDTP_FEC_FIN.AutoSize = True
            Me.lblDTP_FEC_FIN.Location = New System.Drawing.Point(221, 263)
            Me.lblDTP_FEC_FIN.Name = "lblDTP_FEC_FIN"
            Me.lblDTP_FEC_FIN.Size = New System.Drawing.Size(60, 13)
            Me.lblDTP_FEC_FIN.TabIndex = 55
            Me.lblDTP_FEC_FIN.Text = "Fecha. Fin."
            '
            'dtpDTP_FEC_FIN
            '
            Me.dtpDTP_FEC_FIN.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDTP_FEC_FIN.Location = New System.Drawing.Point(305, 263)
            Me.dtpDTP_FEC_FIN.Name = "dtpDTP_FEC_FIN"
            Me.dtpDTP_FEC_FIN.Size = New System.Drawing.Size(103, 20)
            Me.dtpDTP_FEC_FIN.TabIndex = 26
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(6, 164)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(71, 13)
            Me.lblPER_ID.TabIndex = 53
            Me.lblPER_ID.Text = "Cód. Persona"
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(153, 164)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(222, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 17
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(82, 164)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.Size = New System.Drawing.Size(69, 20)
            Me.txtPER_ID.TabIndex = 16
            '
            'lblTIV_DIAS
            '
            Me.lblTIV_DIAS.AutoSize = True
            Me.lblTIV_DIAS.Location = New System.Drawing.Point(382, 110)
            Me.lblTIV_DIAS.Name = "lblTIV_DIAS"
            Me.lblTIV_DIAS.Size = New System.Drawing.Size(30, 13)
            Me.lblTIV_DIAS.TabIndex = 50
            Me.lblTIV_DIAS.Text = "Días"
            '
            'txtTIV_DIAS
            '
            Me.txtTIV_DIAS.Enabled = False
            Me.txtTIV_DIAS.Location = New System.Drawing.Point(430, 110)
            Me.txtTIV_DIAS.Name = "txtTIV_DIAS"
            Me.txtTIV_DIAS.ReadOnly = True
            Me.txtTIV_DIAS.Size = New System.Drawing.Size(39, 20)
            Me.txtTIV_DIAS.TabIndex = 13
            Me.txtTIV_DIAS.Text = "0"
            '
            'lblTIV_ID
            '
            Me.lblTIV_ID.AutoSize = True
            Me.lblTIV_ID.Location = New System.Drawing.Point(6, 110)
            Me.lblTIV_ID.Name = "lblTIV_ID"
            Me.lblTIV_ID.Size = New System.Drawing.Size(58, 13)
            Me.lblTIV_ID.TabIndex = 48
            Me.lblTIV_ID.Text = "Tipo venta"
            '
            'txtTIV_DESCRIPCION
            '
            Me.txtTIV_DESCRIPCION.Enabled = False
            Me.txtTIV_DESCRIPCION.Location = New System.Drawing.Point(122, 110)
            Me.txtTIV_DESCRIPCION.Name = "txtTIV_DESCRIPCION"
            Me.txtTIV_DESCRIPCION.ReadOnly = True
            Me.txtTIV_DESCRIPCION.Size = New System.Drawing.Size(253, 20)
            Me.txtTIV_DESCRIPCION.TabIndex = 12
            '
            'txtTIV_ID
            '
            Me.txtTIV_ID.Location = New System.Drawing.Point(82, 110)
            Me.txtTIV_ID.Name = "txtTIV_ID"
            Me.txtTIV_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTIV_ID.TabIndex = 11
            '
            'lblDLP_RECARGO_ENVIO
            '
            Me.lblDLP_RECARGO_ENVIO.AutoSize = True
            Me.lblDLP_RECARGO_ENVIO.Location = New System.Drawing.Point(382, 80)
            Me.lblDLP_RECARGO_ENVIO.Name = "lblDLP_RECARGO_ENVIO"
            Me.lblDLP_RECARGO_ENVIO.Size = New System.Drawing.Size(97, 13)
            Me.lblDLP_RECARGO_ENVIO.TabIndex = 45
            Me.lblDLP_RECARGO_ENVIO.Text = "Recargo por envío"
            '
            'chkTIV_ESTADO
            '
            Me.chkTIV_ESTADO.AutoSize = True
            Me.chkTIV_ESTADO.Enabled = False
            Me.chkTIV_ESTADO.Location = New System.Drawing.Point(500, 110)
            Me.chkTIV_ESTADO.Name = "chkTIV_ESTADO"
            Me.chkTIV_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTIV_ESTADO.TabIndex = 14
            Me.chkTIV_ESTADO.UseVisualStyleBackColor = True
            '
            'txtDLP_RECARGO_ENVIO
            '
            Me.txtDLP_RECARGO_ENVIO.Enabled = False
            Me.txtDLP_RECARGO_ENVIO.Location = New System.Drawing.Point(500, 80)
            Me.txtDLP_RECARGO_ENVIO.Name = "txtDLP_RECARGO_ENVIO"
            Me.txtDLP_RECARGO_ENVIO.ReadOnly = True
            Me.txtDLP_RECARGO_ENVIO.Size = New System.Drawing.Size(69, 20)
            Me.txtDLP_RECARGO_ENVIO.TabIndex = 10
            Me.txtDLP_RECARGO_ENVIO.Text = "0"
            '
            'txtART_FACTOR
            '
            Me.txtART_FACTOR.Enabled = False
            Me.txtART_FACTOR.Location = New System.Drawing.Point(430, 57)
            Me.txtART_FACTOR.Name = "txtART_FACTOR"
            Me.txtART_FACTOR.ReadOnly = True
            Me.txtART_FACTOR.Size = New System.Drawing.Size(39, 20)
            Me.txtART_FACTOR.TabIndex = 6
            '
            'txtUM_DESCRIPCION
            '
            Me.txtUM_DESCRIPCION.Enabled = False
            Me.txtUM_DESCRIPCION.Location = New System.Drawing.Point(305, 57)
            Me.txtUM_DESCRIPCION.Name = "txtUM_DESCRIPCION"
            Me.txtUM_DESCRIPCION.ReadOnly = True
            Me.txtUM_DESCRIPCION.Size = New System.Drawing.Size(70, 20)
            Me.txtUM_DESCRIPCION.TabIndex = 5
            '
            'chkART_ESTADO
            '
            Me.chkART_ESTADO.AutoSize = True
            Me.chkART_ESTADO.Enabled = False
            Me.chkART_ESTADO.Location = New System.Drawing.Point(500, 57)
            Me.chkART_ESTADO.Name = "chkART_ESTADO"
            Me.chkART_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkART_ESTADO.TabIndex = 7
            Me.chkART_ESTADO.UseVisualStyleBackColor = True
            '
            'lblDTP_ESTADO
            '
            Me.lblDTP_ESTADO.AutoSize = True
            Me.lblDTP_ESTADO.Location = New System.Drawing.Point(427, 263)
            Me.lblDTP_ESTADO.Name = "lblDTP_ESTADO"
            Me.lblDTP_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblDTP_ESTADO.TabIndex = 36
            Me.lblDTP_ESTADO.Text = "Estado"
            '
            'lblDTP_FEC_INI
            '
            Me.lblDTP_FEC_INI.AutoSize = True
            Me.lblDTP_FEC_INI.Location = New System.Drawing.Point(6, 263)
            Me.lblDTP_FEC_INI.Name = "lblDTP_FEC_INI"
            Me.lblDTP_FEC_INI.Size = New System.Drawing.Size(57, 13)
            Me.lblDTP_FEC_INI.TabIndex = 35
            Me.lblDTP_FEC_INI.Text = "Fecha. Ini."
            '
            'lblDTP_CANT_MAXIMA
            '
            Me.lblDTP_CANT_MAXIMA.AutoSize = True
            Me.lblDTP_CANT_MAXIMA.Location = New System.Drawing.Point(221, 238)
            Me.lblDTP_CANT_MAXIMA.Name = "lblDTP_CANT_MAXIMA"
            Me.lblDTP_CANT_MAXIMA.Size = New System.Drawing.Size(70, 13)
            Me.lblDTP_CANT_MAXIMA.TabIndex = 34
            Me.lblDTP_CANT_MAXIMA.Text = "Cant. máxima"
            '
            'lblDTP_CANT_MINIMA
            '
            Me.lblDTP_CANT_MINIMA.AutoSize = True
            Me.lblDTP_CANT_MINIMA.Location = New System.Drawing.Point(6, 238)
            Me.lblDTP_CANT_MINIMA.Name = "lblDTP_CANT_MINIMA"
            Me.lblDTP_CANT_MINIMA.Size = New System.Drawing.Size(69, 13)
            Me.lblDTP_CANT_MINIMA.TabIndex = 33
            Me.lblDTP_CANT_MINIMA.Text = "Cant. mínima"
            '
            'lblDTP_MONTO_PER
            '
            Me.lblDTP_MONTO_PER.AutoSize = True
            Me.lblDTP_MONTO_PER.Location = New System.Drawing.Point(382, 164)
            Me.lblDTP_MONTO_PER.Name = "lblDTP_MONTO_PER"
            Me.lblDTP_MONTO_PER.Size = New System.Drawing.Size(111, 13)
            Me.lblDTP_MONTO_PER.TabIndex = 31
            Me.lblDTP_MONTO_PER.Text = "Dscto./Inc. x Persona"
            '
            'lblDTP_MONTO_TIV
            '
            Me.lblDTP_MONTO_TIV.AutoSize = True
            Me.lblDTP_MONTO_TIV.Location = New System.Drawing.Point(382, 137)
            Me.lblDTP_MONTO_TIV.Name = "lblDTP_MONTO_TIV"
            Me.lblDTP_MONTO_TIV.Size = New System.Drawing.Size(61, 13)
            Me.lblDTP_MONTO_TIV.TabIndex = 30
            Me.lblDTP_MONTO_TIV.Text = "Dscto./Inc."
            '
            'lblDTP_CRITERIO
            '
            Me.lblDTP_CRITERIO.AutoSize = True
            Me.lblDTP_CRITERIO.Location = New System.Drawing.Point(6, 193)
            Me.lblDTP_CRITERIO.Name = "lblDTP_CRITERIO"
            Me.lblDTP_CRITERIO.Size = New System.Drawing.Size(39, 13)
            Me.lblDTP_CRITERIO.TabIndex = 29
            Me.lblDTP_CRITERIO.Text = "Criterio"
            '
            'lblDLP_PRECIO_UNITARIO
            '
            Me.lblDLP_PRECIO_UNITARIO.AutoSize = True
            Me.lblDLP_PRECIO_UNITARIO.Location = New System.Drawing.Point(221, 80)
            Me.lblDLP_PRECIO_UNITARIO.Name = "lblDLP_PRECIO_UNITARIO"
            Me.lblDLP_PRECIO_UNITARIO.Size = New System.Drawing.Size(74, 13)
            Me.lblDLP_PRECIO_UNITARIO.TabIndex = 28
            Me.lblDLP_PRECIO_UNITARIO.Text = "Precio unitario"
            '
            'lblDLP_PRECIO_MINIMO
            '
            Me.lblDLP_PRECIO_MINIMO.AutoSize = True
            Me.lblDLP_PRECIO_MINIMO.Location = New System.Drawing.Point(6, 80)
            Me.lblDLP_PRECIO_MINIMO.Name = "lblDLP_PRECIO_MINIMO"
            Me.lblDLP_PRECIO_MINIMO.Size = New System.Drawing.Size(74, 13)
            Me.lblDLP_PRECIO_MINIMO.TabIndex = 27
            Me.lblDLP_PRECIO_MINIMO.Text = "Precio mínimo"
            '
            'lblART_ID
            '
            Me.lblART_ID.AutoSize = True
            Me.lblART_ID.Location = New System.Drawing.Point(6, 57)
            Me.lblART_ID.Name = "lblART_ID"
            Me.lblART_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblART_ID.TabIndex = 26
            Me.lblART_ID.Text = "Cód. Art."
            '
            'lblLPR_ID
            '
            Me.lblLPR_ID.AutoSize = True
            Me.lblLPR_ID.Location = New System.Drawing.Point(6, 33)
            Me.lblLPR_ID.Name = "lblLPR_ID"
            Me.lblLPR_ID.Size = New System.Drawing.Size(66, 13)
            Me.lblLPR_ID.TabIndex = 25
            Me.lblLPR_ID.Text = "Lista precios"
            '
            'lblDTP_DESCRIPCION
            '
            Me.lblDTP_DESCRIPCION.AutoSize = True
            Me.lblDTP_DESCRIPCION.Location = New System.Drawing.Point(6, 5)
            Me.lblDTP_DESCRIPCION.Name = "lblDTP_DESCRIPCION"
            Me.lblDTP_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblDTP_DESCRIPCION.TabIndex = 22
            Me.lblDTP_DESCRIPCION.Text = "Descripción"
            '
            'dtpDTP_FEC_INI
            '
            Me.dtpDTP_FEC_INI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDTP_FEC_INI.Location = New System.Drawing.Point(82, 263)
            Me.dtpDTP_FEC_INI.Name = "dtpDTP_FEC_INI"
            Me.dtpDTP_FEC_INI.Size = New System.Drawing.Size(103, 20)
            Me.dtpDTP_FEC_INI.TabIndex = 25
            '
            'chkDTP_ESTADO
            '
            Me.chkDTP_ESTADO.AutoSize = True
            Me.chkDTP_ESTADO.Location = New System.Drawing.Point(500, 263)
            Me.chkDTP_ESTADO.Name = "chkDTP_ESTADO"
            Me.chkDTP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDTP_ESTADO.TabIndex = 27
            Me.chkDTP_ESTADO.UseVisualStyleBackColor = True
            '
            'txtDTP_CANT_MAXIMA
            '
            Me.txtDTP_CANT_MAXIMA.Location = New System.Drawing.Point(305, 238)
            Me.txtDTP_CANT_MAXIMA.Name = "txtDTP_CANT_MAXIMA"
            Me.txtDTP_CANT_MAXIMA.Size = New System.Drawing.Size(103, 20)
            Me.txtDTP_CANT_MAXIMA.TabIndex = 24
            Me.txtDTP_CANT_MAXIMA.Text = "0"
            '
            'txtDTP_CANT_MINIMA
            '
            Me.txtDTP_CANT_MINIMA.Location = New System.Drawing.Point(82, 238)
            Me.txtDTP_CANT_MINIMA.Name = "txtDTP_CANT_MINIMA"
            Me.txtDTP_CANT_MINIMA.Size = New System.Drawing.Size(103, 20)
            Me.txtDTP_CANT_MINIMA.TabIndex = 23
            Me.txtDTP_CANT_MINIMA.Text = "0"
            '
            'txtDTP_MONTO_PER
            '
            Me.txtDTP_MONTO_PER.Location = New System.Drawing.Point(500, 164)
            Me.txtDTP_MONTO_PER.Name = "txtDTP_MONTO_PER"
            Me.txtDTP_MONTO_PER.Size = New System.Drawing.Size(69, 20)
            Me.txtDTP_MONTO_PER.TabIndex = 18
            Me.txtDTP_MONTO_PER.Text = "0"
            '
            'txtDTP_MONTO_TIV
            '
            Me.txtDTP_MONTO_TIV.Location = New System.Drawing.Point(500, 137)
            Me.txtDTP_MONTO_TIV.Name = "txtDTP_MONTO_TIV"
            Me.txtDTP_MONTO_TIV.Size = New System.Drawing.Size(69, 20)
            Me.txtDTP_MONTO_TIV.TabIndex = 15
            Me.txtDTP_MONTO_TIV.Text = "0"
            '
            'chkDTP_CRITERIO
            '
            Me.chkDTP_CRITERIO.AutoSize = True
            Me.chkDTP_CRITERIO.Enabled = False
            Me.chkDTP_CRITERIO.Location = New System.Drawing.Point(82, 193)
            Me.chkDTP_CRITERIO.Name = "chkDTP_CRITERIO"
            Me.chkDTP_CRITERIO.Size = New System.Drawing.Size(15, 14)
            Me.chkDTP_CRITERIO.TabIndex = 19
            Me.chkDTP_CRITERIO.UseVisualStyleBackColor = True
            '
            'txtDLP_PRECIO_UNITARIO
            '
            Me.txtDLP_PRECIO_UNITARIO.Enabled = False
            Me.txtDLP_PRECIO_UNITARIO.Location = New System.Drawing.Point(305, 80)
            Me.txtDLP_PRECIO_UNITARIO.Name = "txtDLP_PRECIO_UNITARIO"
            Me.txtDLP_PRECIO_UNITARIO.ReadOnly = True
            Me.txtDLP_PRECIO_UNITARIO.Size = New System.Drawing.Size(69, 20)
            Me.txtDLP_PRECIO_UNITARIO.TabIndex = 9
            Me.txtDLP_PRECIO_UNITARIO.Text = "0"
            '
            'txtDLP_PRECIO_MINIMO
            '
            Me.txtDLP_PRECIO_MINIMO.Enabled = False
            Me.txtDLP_PRECIO_MINIMO.Location = New System.Drawing.Point(82, 80)
            Me.txtDLP_PRECIO_MINIMO.Name = "txtDLP_PRECIO_MINIMO"
            Me.txtDLP_PRECIO_MINIMO.ReadOnly = True
            Me.txtDLP_PRECIO_MINIMO.Size = New System.Drawing.Size(69, 20)
            Me.txtDLP_PRECIO_MINIMO.TabIndex = 8
            Me.txtDLP_PRECIO_MINIMO.Text = "0"
            '
            'txtART_DESCRIPCION
            '
            Me.txtART_DESCRIPCION.Enabled = False
            Me.txtART_DESCRIPCION.Location = New System.Drawing.Point(153, 57)
            Me.txtART_DESCRIPCION.Name = "txtART_DESCRIPCION"
            Me.txtART_DESCRIPCION.ReadOnly = True
            Me.txtART_DESCRIPCION.Size = New System.Drawing.Size(150, 20)
            Me.txtART_DESCRIPCION.TabIndex = 4
            '
            'txtLPR_DESCRIPCION
            '
            Me.txtLPR_DESCRIPCION.Enabled = False
            Me.txtLPR_DESCRIPCION.Location = New System.Drawing.Point(122, 33)
            Me.txtLPR_DESCRIPCION.Name = "txtLPR_DESCRIPCION"
            Me.txtLPR_DESCRIPCION.ReadOnly = True
            Me.txtLPR_DESCRIPCION.Size = New System.Drawing.Size(447, 20)
            Me.txtLPR_DESCRIPCION.TabIndex = 2
            '
            'txtART_ID
            '
            Me.txtART_ID.Enabled = False
            Me.txtART_ID.Location = New System.Drawing.Point(82, 57)
            Me.txtART_ID.Name = "txtART_ID"
            Me.txtART_ID.ReadOnly = True
            Me.txtART_ID.Size = New System.Drawing.Size(69, 20)
            Me.txtART_ID.TabIndex = 3
            '
            'txtLPR_ID
            '
            Me.txtLPR_ID.Enabled = False
            Me.txtLPR_ID.Location = New System.Drawing.Point(82, 33)
            Me.txtLPR_ID.Name = "txtLPR_ID"
            Me.txtLPR_ID.ReadOnly = True
            Me.txtLPR_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtLPR_ID.TabIndex = 1
            '
            'txtDTP_DESCRIPCION
            '
            Me.txtDTP_DESCRIPCION.Location = New System.Drawing.Point(82, 5)
            Me.txtDTP_DESCRIPCION.Name = "txtDTP_DESCRIPCION"
            Me.txtDTP_DESCRIPCION.Size = New System.Drawing.Size(487, 20)
            Me.txtDTP_DESCRIPCION.TabIndex = 0
            '
            'ShapeContainer1
            '
            Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
            Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
            Me.ShapeContainer1.Name = "ShapeContainer1"
            Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
            Me.ShapeContainer1.Size = New System.Drawing.Size(589, 509)
            Me.ShapeContainer1.TabIndex = 56
            Me.ShapeContainer1.TabStop = False
            '
            'LineShape6
            '
            Me.LineShape6.Name = "LineShape6"
            Me.LineShape6.X1 = 6
            Me.LineShape6.X2 = 575
            Me.LineShape6.Y1 = 286
            Me.LineShape6.Y2 = 286
            '
            'LineShape5
            '
            Me.LineShape5.Name = "LineShape5"
            Me.LineShape5.X1 = 6
            Me.LineShape5.X2 = 575
            Me.LineShape5.Y1 = 187
            Me.LineShape5.Y2 = 187
            '
            'LineShape4
            '
            Me.LineShape4.Name = "LineShape4"
            Me.LineShape4.X1 = 5
            Me.LineShape4.X2 = 574
            Me.LineShape4.Y1 = 160
            Me.LineShape4.Y2 = 160
            '
            'LineShape3
            '
            Me.LineShape3.Name = "LineShape3"
            Me.LineShape3.X1 = 7
            Me.LineShape3.X2 = 574
            Me.LineShape3.Y1 = 133
            Me.LineShape3.Y2 = 133
            '
            'LineShape2
            '
            Me.LineShape2.Name = "LineShape2"
            Me.LineShape2.X1 = 7
            Me.LineShape2.X2 = 574
            Me.LineShape2.Y1 = 103
            Me.LineShape2.Y2 = 103
            '
            'LineShape1
            '
            Me.LineShape1.Name = "LineShape1"
            Me.LineShape1.X1 = 5
            Me.LineShape1.X2 = 572
            Me.LineShape1.Y1 = 28
            Me.LineShape1.Y2 = 28
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmDescuentoIncrementoTipoVentaPersonas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(664, 571)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmDescuentoIncrementoTipoVentaPersonas"
            Me.Text = "Descuentos / Incrementos"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblDTP_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblDTP_FEC_INI As System.Windows.Forms.Label
        Friend WithEvents lblDTP_CANT_MINIMA As System.Windows.Forms.Label
        Friend WithEvents lblDTP_MONTO_PER As System.Windows.Forms.Label
        Friend WithEvents lblDTP_MONTO_TIV As System.Windows.Forms.Label
        Friend WithEvents lblDTP_CRITERIO As System.Windows.Forms.Label
        Friend WithEvents lblDLP_PRECIO_UNITARIO As System.Windows.Forms.Label
        Friend WithEvents lblDLP_PRECIO_MINIMO As System.Windows.Forms.Label
        Friend WithEvents lblART_ID As System.Windows.Forms.Label
        Friend WithEvents lblLPR_ID As System.Windows.Forms.Label
        Public WithEvents dtpDTP_FEC_INI As System.Windows.Forms.DateTimePicker
        Public WithEvents chkDTP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtDTP_CANT_MAXIMA As System.Windows.Forms.TextBox
        Public WithEvents txtDTP_CANT_MINIMA As System.Windows.Forms.TextBox
        Public WithEvents txtDTP_MONTO_PER As System.Windows.Forms.TextBox
        Public WithEvents txtDTP_MONTO_TIV As System.Windows.Forms.TextBox
        Public WithEvents chkDTP_CRITERIO As System.Windows.Forms.CheckBox
        Public WithEvents txtDLP_PRECIO_UNITARIO As System.Windows.Forms.TextBox
        Public WithEvents txtDLP_PRECIO_MINIMO As System.Windows.Forms.TextBox
        Public WithEvents chkTIV_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkART_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtART_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtLPR_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtART_ID As System.Windows.Forms.TextBox
        Public WithEvents txtLPR_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDTP_DESCRIPCION As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents txtUM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtART_FACTOR As System.Windows.Forms.TextBox
        Friend WithEvents lblDLP_RECARGO_ENVIO As System.Windows.Forms.Label
        Public WithEvents txtDLP_RECARGO_ENVIO As System.Windows.Forms.TextBox
        Friend WithEvents lblTIV_ID As System.Windows.Forms.Label
        Public WithEvents txtTIV_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTIV_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblTIV_DIAS As System.Windows.Forms.Label
        Public WithEvents txtTIV_DIAS As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblDTP_CANT_MAXIMA As System.Windows.Forms.Label
        Friend WithEvents lblDTP_FEC_FIN As System.Windows.Forms.Label
        Public WithEvents dtpDTP_FEC_FIN As System.Windows.Forms.DateTimePicker
        Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
        Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
        Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
        Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
        Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
        Friend WithEvents lblART_FACTOR As System.Windows.Forms.Label
        Public WithEvents txtDTP_ID As System.Windows.Forms.TextBox
        Public WithEvents lblDTP_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblDTP_SUB_CRITERIO As System.Windows.Forms.Label
        Public WithEvents chkDTP_SUB_CRITERIO As System.Windows.Forms.CheckBox
        Friend WithEvents lblDTP_MONTO_MAXIMO As System.Windows.Forms.Label
        Friend WithEvents lblDTP_MONTO_MINIMO As System.Windows.Forms.Label
        Public WithEvents txtDTP_MONTO_MAXIMO As System.Windows.Forms.TextBox
        Public WithEvents txtDTP_MONTO_MINIMO As System.Windows.Forms.TextBox
        Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
        Public WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents lblDTP_TIPO_DESC_INC As System.Windows.Forms.Label
        Public WithEvents cboDTP_TIPO_DESC_INC As System.Windows.Forms.ComboBox
        Friend WithEvents cITEM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDT_MONTO_MINIMO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDT_MONTO_MAXIMO As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDT_MONTO_TIV As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cDDT_ESTADO As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents cEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace