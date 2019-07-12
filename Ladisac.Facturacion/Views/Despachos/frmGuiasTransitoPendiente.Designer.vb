<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiasTransitoPendiente
    Inherits Ladisac.Foundation.Views.ViewMaster

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
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.dgvProcesar = New System.Windows.Forms.DataGridView()
        Me.DTD_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMO_SERIE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMO_NRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMO_FECHA_DOCUMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES_FEC_SAL_PLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transportista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TSa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROCESO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        CType(Me.dgvProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1132, 28)
        Me.lblTitle.Text = "Guias en Transito Pendiente"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(722, 47)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 133
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'dgvProcesar
        '
        Me.dgvProcesar.AllowUserToAddRows = False
        Me.dgvProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProcesar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcesar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DTD_DESCRIPCION, Me.DMO_SERIE, Me.DMO_NRO, Me.DMO_FECHA_DOCUMENTO, Me.DES_FEC_SAL_PLA, Me.Transportista, Me.Placa, Me.ART_DESCRIPCION, Me.TSa, Me.PROCESO, Me.DTD_ID, Me.TDO_ID})
        Me.dgvProcesar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProcesar.Location = New System.Drawing.Point(11, 92)
        Me.dgvProcesar.Name = "dgvProcesar"
        Me.dgvProcesar.Size = New System.Drawing.Size(1109, 327)
        Me.dgvProcesar.TabIndex = 128
        '
        'DTD_DESCRIPCION
        '
        Me.DTD_DESCRIPCION.HeaderText = "Documento"
        Me.DTD_DESCRIPCION.Name = "DTD_DESCRIPCION"
        Me.DTD_DESCRIPCION.ReadOnly = True
        Me.DTD_DESCRIPCION.Width = 170
        '
        'DMO_SERIE
        '
        Me.DMO_SERIE.HeaderText = "Serie"
        Me.DMO_SERIE.Name = "DMO_SERIE"
        Me.DMO_SERIE.ReadOnly = True
        '
        'DMO_NRO
        '
        Me.DMO_NRO.HeaderText = "Numero"
        Me.DMO_NRO.Name = "DMO_NRO"
        Me.DMO_NRO.ReadOnly = True
        Me.DMO_NRO.Width = 75
        '
        'DMO_FECHA_DOCUMENTO
        '
        Me.DMO_FECHA_DOCUMENTO.HeaderText = "Fecha"
        Me.DMO_FECHA_DOCUMENTO.Name = "DMO_FECHA_DOCUMENTO"
        Me.DMO_FECHA_DOCUMENTO.ReadOnly = True
        '
        'DES_FEC_SAL_PLA
        '
        Me.DES_FEC_SAL_PLA.HeaderText = "FechaHoraSalidaPlanta"
        Me.DES_FEC_SAL_PLA.Name = "DES_FEC_SAL_PLA"
        '
        'Transportista
        '
        Me.Transportista.HeaderText = "Transportista"
        Me.Transportista.Name = "Transportista"
        '
        'Placa
        '
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        '
        'ART_DESCRIPCION
        '
        Me.ART_DESCRIPCION.HeaderText = "Articulo"
        Me.ART_DESCRIPCION.Name = "ART_DESCRIPCION"
        Me.ART_DESCRIPCION.ReadOnly = True
        Me.ART_DESCRIPCION.Width = 150
        '
        'TSa
        '
        Me.TSa.HeaderText = "Cantidad"
        Me.TSa.Name = "TSa"
        Me.TSa.ReadOnly = True
        Me.TSa.Width = 75
        '
        'PROCESO
        '
        Me.PROCESO.HeaderText = "PROCESAR"
        Me.PROCESO.Name = "PROCESO"
        Me.PROCESO.Width = 80
        '
        'DTD_ID
        '
        Me.DTD_ID.HeaderText = "DTD_ID"
        Me.DTD_ID.Name = "DTD_ID"
        Me.DTD_ID.ReadOnly = True
        Me.DTD_ID.Visible = False
        '
        'TDO_ID
        '
        Me.TDO_ID.HeaderText = "TDO_ID"
        Me.TDO_ID.Name = "TDO_ID"
        Me.TDO_ID.ReadOnly = True
        Me.TDO_ID.Visible = False
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(65, 48)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(312, 20)
        Me.txtAlmacen.TabIndex = 135
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "GUI_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "NRO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "EMPRESA TRANSPORTE"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "ARTICULO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "CANTIDAD"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Almacen"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(621, 48)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 138
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(578, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Fecha"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(867, 47)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 139
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmGuiasTransitoPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1132, 429)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.dgvProcesar)
        Me.Name = "frmGuiasTransitoPendiente"
        Me.Text = "Guias en Transito Pendiente"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dgvProcesar, 0)
        Me.Controls.SetChildIndex(Me.btnProcesar, 0)
        Me.Controls.SetChildIndex(Me.txtAlmacen, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        CType(Me.dgvProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dgvProcesar As System.Windows.Forms.DataGridView
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTD_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMO_SERIE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMO_NRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMO_FECHA_DOCUMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES_FEC_SAL_PLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transportista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog

End Class
