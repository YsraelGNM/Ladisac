<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptPesoQuema
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.PRO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ART_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRO_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DPE_PESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DPE_PORCENTAJE_HUMEDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarFila = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(784, 28)
        Me.lblTitle.Text = "Pesos para la Quema"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Fecha Carga"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(84, 47)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha.TabIndex = 170
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PRO_ID, Me.ART_DESCRIPCION, Me.PRO_FECHA, Me.DPE_PESO, Me.DPE_PORCENTAJE_HUMEDAD, Me.CAR_FECHA})
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 95)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(757, 357)
        Me.dgvDetalle.TabIndex = 172
        '
        'PRO_ID
        '
        Me.PRO_ID.HeaderText = "NROPROD"
        Me.PRO_ID.Name = "PRO_ID"
        '
        'ART_DESCRIPCION
        '
        Me.ART_DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.ART_DESCRIPCION.Name = "ART_DESCRIPCION"
        '
        'PRO_FECHA
        '
        Me.PRO_FECHA.HeaderText = "FECHAPROD"
        Me.PRO_FECHA.Name = "PRO_FECHA"
        '
        'DPE_PESO
        '
        Me.DPE_PESO.HeaderText = "PESO"
        Me.DPE_PESO.Name = "DPE_PESO"
        '
        'DPE_PORCENTAJE_HUMEDAD
        '
        Me.DPE_PORCENTAJE_HUMEDAD.HeaderText = "HUMEDAD"
        Me.DPE_PORCENTAJE_HUMEDAD.Name = "DPE_PORCENTAJE_HUMEDAD"
        '
        'CAR_FECHA
        '
        Me.CAR_FECHA.HeaderText = "FECHA CARGA"
        Me.CAR_FECHA.Name = "CAR_FECHA"
        '
        'btnAgregarFila
        '
        Me.btnAgregarFila.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarFila.Location = New System.Drawing.Point(15, 474)
        Me.btnAgregarFila.Name = "btnAgregarFila"
        Me.btnAgregarFila.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarFila.TabIndex = 173
        Me.btnAgregarFila.Text = "Agregar Fila"
        Me.btnAgregarFila.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "NROPROD"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHAPROD"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "PESO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "HUMEDAD"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "FECHA CARGA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Location = New System.Drawing.Point(107, 474)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 174
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Location = New System.Drawing.Point(201, 474)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(95, 23)
        Me.btnPrintPreview.TabIndex = 175
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'frmRptPesoQuema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(784, 515)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnAgregarFila)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Name = "frmRptPesoQuema"
        Me.Text = "Pesos para la Quema"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.btnAgregarFila, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.btnPrintPreview, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents PRO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ART_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRO_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPE_PESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPE_PORCENTAJE_HUMEDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAR_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarFila As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button

End Class
