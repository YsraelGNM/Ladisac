<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImagen))
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DescargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.fbdImagen = New System.Windows.Forms.FolderBrowserDialog()
        Me.IMA_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMA_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMA_RUTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMA_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRuta = New System.Windows.Forms.Label()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(918, 28)
        Me.lblTitle.Text = "Imagen"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IMA_ID, Me.IMA_DESCRIPCION, Me.IMA_RUTA, Me.IMA_OBSERVACION})
        Me.dgvDetalle.Location = New System.Drawing.Point(26, 114)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(491, 232)
        Me.dgvDetalle.TabIndex = 97
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DescargarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(127, 26)
        '
        'DescargarToolStripMenuItem
        '
        Me.DescargarToolStripMenuItem.Name = "DescargarToolStripMenuItem"
        Me.DescargarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.DescargarToolStripMenuItem.Text = "Descargar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Entidad"
        '
        'txtEntidad
        '
        Me.txtEntidad.Location = New System.Drawing.Point(72, 73)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(445, 20)
        Me.txtEntidad.TabIndex = 95
        '
        'picImagen
        '
        Me.picImagen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImagen.Location = New System.Drawing.Point(572, 73)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(324, 273)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 98
        Me.picImagen.TabStop = False
        '
        'ofdImagen
        '
        Me.ofdImagen.Filter = "Bmp files (*.bmp)|*.bmp|Jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'IMA_ID
        '
        Me.IMA_ID.HeaderText = "IMA_ID"
        Me.IMA_ID.Name = "IMA_ID"
        Me.IMA_ID.Visible = False
        '
        'IMA_DESCRIPCION
        '
        Me.IMA_DESCRIPCION.HeaderText = "Descripcion"
        Me.IMA_DESCRIPCION.Name = "IMA_DESCRIPCION"
        '
        'IMA_RUTA
        '
        Me.IMA_RUTA.ContextMenuStrip = Me.ContextMenuStrip1
        Me.IMA_RUTA.HeaderText = "Ruta"
        Me.IMA_RUTA.Name = "IMA_RUTA"
        Me.IMA_RUTA.ReadOnly = True
        '
        'IMA_OBSERVACION
        '
        Me.IMA_OBSERVACION.HeaderText = "Observacion"
        Me.IMA_OBSERVACION.Name = "IMA_OBSERVACION"
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Location = New System.Drawing.Point(23, 366)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(873, 23)
        Me.lblRuta.TabIndex = 153
        Me.lblRuta.Text = "Label2"
        '
        'frmImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(918, 398)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEntidad)
        Me.Name = "frmImagen"
        Me.Text = "Imagen"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtEntidad, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.picImagen, 0)
        Me.Controls.SetChildIndex(Me.lblRuta, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ofdImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DescargarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbdImagen As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents IMA_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMA_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMA_RUTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMA_OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRuta As System.Windows.Forms.Label

End Class
