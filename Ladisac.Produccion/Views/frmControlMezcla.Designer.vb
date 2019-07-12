<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlMezcla
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduccion = New System.Windows.Forms.TextBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.dgvDetalle2 = New System.Windows.Forms.DataGridView()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
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
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_ID_MP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMR_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAT_VOL_PALA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMR_M3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMR_M3_BRUTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAT_ID_M = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PER_ID_OPERADOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_CANTIDAD_BRUTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_HORA_INICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_HORA_FINAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAT_VOL_PALA_M = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DMM_TOTAL_LADRILLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1066, 28)
        Me.lblTitle.Text = "Control Mezcla"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(98, 67)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Produccion"
        '
        'txtProduccion
        '
        Me.txtProduccion.Location = New System.Drawing.Point(98, 93)
        Me.txtProduccion.Name = "txtProduccion"
        Me.txtProduccion.Size = New System.Drawing.Size(276, 20)
        Me.txtProduccion.TabIndex = 131
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DMR_ID, Me.ART_ID_MP, Me.DMR_CANTIDAD, Me.CAT_ID, Me.CAT_VOL_PALA, Me.DMR_M3, Me.DMR_M3_BRUTO})
        Me.dgvDetalle.Location = New System.Drawing.Point(23, 134)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(434, 345)
        Me.dgvDetalle.TabIndex = 135
        '
        'dgvDetalle2
        '
        Me.dgvDetalle2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DMM_ID, Me.CAT_ID_M, Me.PER_ID_OPERADOR, Me.DMM_CANTIDAD, Me.DMM_CANTIDAD_BRUTA, Me.DMM_HORA_INICIO, Me.DMM_HORA_FINAL, Me.CAT_VOL_PALA_M, Me.DMM_TOTAL_LADRILLO})
        Me.dgvDetalle2.Location = New System.Drawing.Point(477, 134)
        Me.dgvDetalle2.Name = "dgvDetalle2"
        Me.dgvDetalle2.Size = New System.Drawing.Size(563, 345)
        Me.dgvDetalle2.TabIndex = 136
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DMR_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Materia_Prima"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "CAT_ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "CAT_VOL_PALA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "DMR_M3"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "DMM_ID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "CAT"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Operador"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Hora Inicio"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Hora Final"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Vol. Pala"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Total Ladrillo"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DMR_ID
        '
        Me.DMR_ID.HeaderText = "DMR_ID"
        Me.DMR_ID.Name = "DMR_ID"
        Me.DMR_ID.Visible = False
        '
        'ART_ID_MP
        '
        Me.ART_ID_MP.HeaderText = "Materia_Prima"
        Me.ART_ID_MP.Name = "ART_ID_MP"
        Me.ART_ID_MP.Width = 200
        '
        'DMR_CANTIDAD
        '
        Me.DMR_CANTIDAD.HeaderText = "Cantidad"
        Me.DMR_CANTIDAD.Name = "DMR_CANTIDAD"
        '
        'CAT_ID
        '
        Me.CAT_ID.HeaderText = "CAT_ID"
        Me.CAT_ID.Name = "CAT_ID"
        Me.CAT_ID.Visible = False
        '
        'CAT_VOL_PALA
        '
        Me.CAT_VOL_PALA.HeaderText = "CAT_VOL_PALA"
        Me.CAT_VOL_PALA.Name = "CAT_VOL_PALA"
        Me.CAT_VOL_PALA.Visible = False
        '
        'DMR_M3
        '
        Me.DMR_M3.HeaderText = "M3"
        Me.DMR_M3.Name = "DMR_M3"
        '
        'DMR_M3_BRUTO
        '
        Me.DMR_M3_BRUTO.HeaderText = "M3 BRUTO"
        Me.DMR_M3_BRUTO.Name = "DMR_M3_BRUTO"
        '
        'DMM_ID
        '
        Me.DMM_ID.HeaderText = "DMM_ID"
        Me.DMM_ID.Name = "DMM_ID"
        Me.DMM_ID.Visible = False
        '
        'CAT_ID_M
        '
        Me.CAT_ID_M.HeaderText = "CAT"
        Me.CAT_ID_M.Name = "CAT_ID_M"
        '
        'PER_ID_OPERADOR
        '
        Me.PER_ID_OPERADOR.HeaderText = "Operador"
        Me.PER_ID_OPERADOR.Name = "PER_ID_OPERADOR"
        '
        'DMM_CANTIDAD
        '
        Me.DMM_CANTIDAD.HeaderText = "Cantidad"
        Me.DMM_CANTIDAD.Name = "DMM_CANTIDAD"
        '
        'DMM_CANTIDAD_BRUTA
        '
        Me.DMM_CANTIDAD_BRUTA.HeaderText = "Cantidad Bruta"
        Me.DMM_CANTIDAD_BRUTA.Name = "DMM_CANTIDAD_BRUTA"
        '
        'DMM_HORA_INICIO
        '
        Me.DMM_HORA_INICIO.HeaderText = "Hora Inicio"
        Me.DMM_HORA_INICIO.Name = "DMM_HORA_INICIO"
        Me.DMM_HORA_INICIO.Visible = False
        '
        'DMM_HORA_FINAL
        '
        Me.DMM_HORA_FINAL.HeaderText = "Hora Final"
        Me.DMM_HORA_FINAL.Name = "DMM_HORA_FINAL"
        Me.DMM_HORA_FINAL.Visible = False
        '
        'CAT_VOL_PALA_M
        '
        Me.CAT_VOL_PALA_M.HeaderText = "Vol. Pala"
        Me.CAT_VOL_PALA_M.Name = "CAT_VOL_PALA_M"
        Me.CAT_VOL_PALA_M.ReadOnly = True
        '
        'DMM_TOTAL_LADRILLO
        '
        Me.DMM_TOTAL_LADRILLO.HeaderText = "Total Ladrillo"
        Me.DMM_TOTAL_LADRILLO.Name = "DMM_TOTAL_LADRILLO"
        '
        'frmControlMezcla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1066, 491)
        Me.Controls.Add(Me.dgvDetalle2)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProduccion)
        Me.Name = "frmControlMezcla"
        Me.Text = "Control Mezcla"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtProduccion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle2, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProduccion As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetalle2 As System.Windows.Forms.DataGridView
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
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
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_ID_MP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMR_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAT_VOL_PALA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMR_M3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMR_M3_BRUTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAT_ID_M As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PER_ID_OPERADOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_CANTIDAD_BRUTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_HORA_INICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_HORA_FINAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAT_VOL_PALA_M As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DMM_TOTAL_LADRILLO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
