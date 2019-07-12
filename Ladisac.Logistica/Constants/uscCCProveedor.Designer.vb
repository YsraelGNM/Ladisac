<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uscCCProveedor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvProveedor = New System.Windows.Forms.DataGridView()
        Me.chkAprobado = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picDoc = New System.Windows.Forms.PictureBox()
        Me.cmAdjDocu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooAdDocuCargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdDocuDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdDocuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.picPre = New System.Windows.Forms.PictureBox()
        Me.cmAdjPre = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooAdPreCargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdPreDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdPreEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmUsc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooUscEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
        Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
        Me.btnOC = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAP_CANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAP_PU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAP_APROBADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdjDocu.SuspendLayout()
        CType(Me.picPre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdjPre.SuspendLayout()
        Me.cmUsc.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProveedor
        '
        Me.dgvProveedor.AllowUserToAddRows = False
        Me.dgvProveedor.AllowUserToDeleteRows = False
        Me.dgvProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProveedor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CAP_CANT, Me.CAP_PU, Me.Total, Me.CAP_APROBADO})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedor.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProveedor.Location = New System.Drawing.Point(6, 138)
        Me.dgvProveedor.Name = "dgvProveedor"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProveedor.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProveedor.RowHeadersVisible = False
        Me.dgvProveedor.Size = New System.Drawing.Size(265, 175)
        Me.dgvProveedor.TabIndex = 132
        '
        'chkAprobado
        '
        Me.chkAprobado.AutoSize = True
        Me.chkAprobado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAprobado.Location = New System.Drawing.Point(6, 115)
        Me.chkAprobado.Name = "chkAprobado"
        Me.chkAprobado.Size = New System.Drawing.Size(72, 17)
        Me.chkAprobado.TabIndex = 131
        Me.chkAprobado.Text = "Aprobado"
        Me.chkAprobado.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Adj.Presupuesto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Adj.Documento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 128
        Me.Label7.Text = "O.R."
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(65, 35)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(59, 20)
        Me.txtDocumento.TabIndex = 127
        '
        'txtProveedor
        '
        Me.txtProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProveedor.Location = New System.Drawing.Point(65, 9)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(206, 20)
        Me.txtProveedor.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Proveedor"
        '
        'picDoc
        '
        Me.picDoc.ContextMenuStrip = Me.cmAdjDocu
        Me.picDoc.Location = New System.Drawing.Point(89, 65)
        Me.picDoc.Name = "picDoc"
        Me.picDoc.Size = New System.Drawing.Size(34, 13)
        Me.picDoc.TabIndex = 133
        Me.picDoc.TabStop = False
        '
        'cmAdjDocu
        '
        Me.cmAdjDocu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooAdDocuCargar, Me.tooAdDocuDescargar, Me.tooAdDocuEliminar})
        Me.cmAdjDocu.Name = "cmUsc"
        Me.cmAdjDocu.Size = New System.Drawing.Size(239, 70)
        '
        'tooAdDocuCargar
        '
        Me.tooAdDocuCargar.Name = "tooAdDocuCargar"
        Me.tooAdDocuCargar.Size = New System.Drawing.Size(238, 22)
        Me.tooAdDocuCargar.Text = "Cargar Adjunto Documento"
        '
        'tooAdDocuDescargar
        '
        Me.tooAdDocuDescargar.Name = "tooAdDocuDescargar"
        Me.tooAdDocuDescargar.Size = New System.Drawing.Size(238, 22)
        Me.tooAdDocuDescargar.Text = "Descargar Adjunto Documento"
        '
        'tooAdDocuEliminar
        '
        Me.tooAdDocuEliminar.Name = "tooAdDocuEliminar"
        Me.tooAdDocuEliminar.Size = New System.Drawing.Size(238, 22)
        Me.tooAdDocuEliminar.Text = "Eliminar Adjunto Documento"
        '
        'picPre
        '
        Me.picPre.ContextMenuStrip = Me.cmAdjPre
        Me.picPre.Location = New System.Drawing.Point(90, 92)
        Me.picPre.Name = "picPre"
        Me.picPre.Size = New System.Drawing.Size(34, 13)
        Me.picPre.TabIndex = 134
        Me.picPre.TabStop = False
        '
        'cmAdjPre
        '
        Me.cmAdjPre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooAdPreCargar, Me.tooAdPreDescargar, Me.tooAdPreEliminar})
        Me.cmAdjPre.Name = "cmUsc"
        Me.cmAdjPre.Size = New System.Drawing.Size(241, 70)
        '
        'tooAdPreCargar
        '
        Me.tooAdPreCargar.Name = "tooAdPreCargar"
        Me.tooAdPreCargar.Size = New System.Drawing.Size(240, 22)
        Me.tooAdPreCargar.Text = "Cargar Adjunto Presupuesto"
        '
        'tooAdPreDescargar
        '
        Me.tooAdPreDescargar.Name = "tooAdPreDescargar"
        Me.tooAdPreDescargar.Size = New System.Drawing.Size(240, 22)
        Me.tooAdPreDescargar.Text = "Descargar Adjunto Presupuesto"
        '
        'tooAdPreEliminar
        '
        Me.tooAdPreEliminar.Name = "tooAdPreEliminar"
        Me.tooAdPreEliminar.Size = New System.Drawing.Size(240, 22)
        Me.tooAdPreEliminar.Text = "Eliminar Adjunto Presupuesto"
        '
        'cmUsc
        '
        Me.cmUsc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooUscEliminar})
        Me.cmUsc.Name = "cmUsc"
        Me.cmUsc.Size = New System.Drawing.Size(118, 26)
        '
        'tooUscEliminar
        '
        Me.tooUscEliminar.Name = "tooUscEliminar"
        Me.tooUscEliminar.Size = New System.Drawing.Size(117, 22)
        Me.tooUscEliminar.Text = "Eliminar"
        '
        'ofdImagen
        '
        Me.ofdImagen.Filter = "All files (*.*)|*.*"
        '
        'sfdImagen
        '
        Me.sfdImagen.CheckFileExists = True
        Me.sfdImagen.Filter = "All files (*.*)|*.*"
        '
        'btnOC
        '
        Me.btnOC.Location = New System.Drawing.Point(196, 109)
        Me.btnOC.Name = "btnOC"
        Me.btnOC.Size = New System.Drawing.Size(75, 23)
        Me.btnOC.TabIndex = 135
        Me.btnOC.Text = "O.C."
        Me.btnOC.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "PU"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 65
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Aprobado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 65
        '
        'CAP_CANT
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CAP_CANT.DefaultCellStyle = DataGridViewCellStyle2
        Me.CAP_CANT.HeaderText = "Cant"
        Me.CAP_CANT.Name = "CAP_CANT"
        Me.CAP_CANT.Width = 65
        '
        'CAP_PU
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CAP_PU.DefaultCellStyle = DataGridViewCellStyle3
        Me.CAP_PU.HeaderText = "PU"
        Me.CAP_PU.Name = "CAP_PU"
        Me.CAP_PU.Width = 65
        '
        'Total
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle4
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 65
        '
        'CAP_APROBADO
        '
        Me.CAP_APROBADO.HeaderText = "Aprobado"
        Me.CAP_APROBADO.Name = "CAP_APROBADO"
        Me.CAP_APROBADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CAP_APROBADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CAP_APROBADO.Width = 60
        '
        'uscCCProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.cmUsc
        Me.Controls.Add(Me.btnOC)
        Me.Controls.Add(Me.picPre)
        Me.Controls.Add(Me.picDoc)
        Me.Controls.Add(Me.dgvProveedor)
        Me.Controls.Add(Me.chkAprobado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.Label5)
        Me.Name = "uscCCProveedor"
        Me.Size = New System.Drawing.Size(279, 322)
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdjDocu.ResumeLayout(False)
        CType(Me.picPre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdjPre.ResumeLayout(False)
        Me.cmUsc.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents chkAprobado As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picDoc As System.Windows.Forms.PictureBox
    Friend WithEvents picPre As System.Windows.Forms.PictureBox
    Friend WithEvents cmAdjDocu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooAdDocuCargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tooAdDocuEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmAdjPre As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooAdPreCargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tooAdPreEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmUsc As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooUscEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tooAdDocuDescargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tooAdPreDescargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnOC As System.Windows.Forms.Button
    Friend WithEvents CAP_CANT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAP_PU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAP_APROBADO As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
